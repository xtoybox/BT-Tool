using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using Newtonsoft.Json;

namespace markform
{
    public partial class frm_file_eval : Form
    {
        #region Initialize Classes
        SQLClass db = new SQLClass();
        CustomClass cf = new CustomClass();
        #endregion Initialize Classes

        #region Setting Variables
        private int btid, fid, uid, evaluwee_uid, evalid, evaluator_uid;
        private string uname, upos, udep, evaluwee_name, evaluwee_pos, evaluwee_dep, filename,
            ComparesStoragePath = @"\\Pdx-fs\mediafiles\Jeff\06 IT PEOPLE\MARK\bt_compares\",
            ComparesFileName = "", ErrorQry = "",
            ComparesPath = "", CurUserRestriction = "";
        private CancellationTokenSource _cnl;
        /// <summary>
        /// If <seealso cref="IsAllowViewEval"/> is <see langword="true"/> then this will filter the allowed department to view.
        /// </summary>
        string[] ViewDep = new string[] { };
        bool IsAllowViewEval = false;
        #endregion Setting Variables

        #region Form Class Initialization
        /// <summary>
        /// Performance evaluation form
        /// <paramref name="args"/> example: <para><c>New String[]{userid,username,userpos,uderdep,btid,fid,filename,compares directory,client,words,mistakes}</c></para>
        /// </summary>
        /// <param name="args">
        /// <para>Array must contain the following values in order.</para>
        /// <para>btid, fid and filename are optional and will only be used if the <paramref name="viewtype"/> is equal to "save"</para>
        /// </param>
        /// <param name="viewtype">
        /// own, view, save
        /// </param>
        public frm_file_eval(object[] args = null, string viewtype = null,string restriction = null)
        {
            InitializeComponent();
            if (args != null)
            {
                uid = int.Parse(args[0].ToString());
                uname = args[1].ToString();
                upos = args[2].ToString();
                udep = args[3].ToString();
                CurUserRestriction = restriction;
                btid = 0; this.fid = 0;

                Tag = viewtype;



                sb_info.Items.Add("User ID: " + this.uid);
                sb_info.Items.Add("User Name: " + this.uname.ToUpper());
                sb_info.Items.Add("User Position: " + cf.GetPositionFull(this.upos).ToUpper());
                sb_info.Items.Add("User Department: " + this.udep.ToUpper());

                foreach (ToolStripStatusLabel itm in sb_info.Items)
                {
                    itm.BorderSides = ToolStripStatusLabelBorderSides.All;
                    itm.BorderStyle = Border3DStyle.Sunken;
                }

                this.SetCboDataSource();
                if (viewtype == "save")
                {
                    this.btid = int.Parse(args[4].ToString());
                    this.fid = int.Parse(args[5].ToString());
                    this.ComparesPath = args[7].ToString();
                    this.evaluator_uid = this.uid;
                    txt_filename.Text = args[6].ToString();
                    txt_compares.Text = this.ComparesPath;
                    filename = args[6].ToString();
                    cbo_accounts.SelectedValue = this.GetClientID(args[8].ToString());
                    cbo_accounts.Visible = false;
                    lbl_accounts_cbo.Visible = true;
                    lbl_accounts_cbo.Text = cbo_accounts.Text;
                    btn_save.Visible = true;
                    Set_EvaluweeInfo();
                    this.SetEventHandler();
                    tlp_evaluator_evaluwee_container.Visible = false;

                    txt_words.Text = args[9].ToString();
                    txt_mistakes.Text = args[10].ToString();
                }
                else if (viewtype == "view")
                {
                    this.Text = this.Text + "[View Only]";
                    tlp_1.Visible = true;
                    tlp_2.Visible = true;
                    //EnabledControls(false);
                    if(IsAllowViewEval && ViewDep.Length > 0) { DisplayUserList(); }
                }
                else//own
                {
                    this.Text = "My Evaluation";
                    tlp_2.Visible = true;
                    pnl_mycontrol_container.Visible = true;
                    this.EnabledControls(false);
                    this.DisplayEvals();
                    lbl_name_label.Visible = false;
                    lbl_evaluwee.Visible = false;
                }
                SetRestrictions();
            }
        }
        #endregion Form Class Initialization

        #region Events
        /// <summary>
        /// Used by the txt_words and txt_mistakes event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EA_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal m, w;
                string mistakes = txt_mistakes.Text, words = txt_words.Text;
                m = (cf.IsStringEmpty(mistakes)) ? 0 : decimal.Parse(mistakes);
                w = (cf.IsStringEmpty(words)) ? 0 : decimal.Parse(words);
                this.EACompute(w, m);
            }
            catch (Exception ex)
            {
                cf.Debug(ex, false);
            }

        }
        /// <summary>
        /// Save Evals Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_save_Click(object sender, EventArgs e)
        {
            List<string> msg = new List<string>();
            string words = txt_words.Text, mistakes = txt_mistakes.Text;
            int accounts = int.Parse(cbo_accounts.SelectedValue.ToString()),
                aq = int.Parse(cbo_aq.SelectedValue.ToString());
            if (cf.IsStringEmpty(filename))
            {
                msg.Add("-Filename is empty.");
            }
            if (cf.IsStringEmpty(words))
            {
                msg.Add("-Please input the total number of words.");
            }
            if (cf.IsStringEmpty(mistakes))
            {
                msg.Add("-Please input the total number of mistakes.");
            }
            if (cf.IsStringEmpty(txt_compares.Text))
            {
                msg.Add("-Please select compares.");
            }
            if (msg.Count > 0)
            {
                MessageBox.Show(this, String.Join("\n", msg.ToArray()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show(this, "You are about to submit this evaluation.", "Confirm Submission", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    tlp_info_container.Enabled = false;
                    tlp_question_container.Enabled = false;
                    this.Cursor = Cursors.AppStarting;
                    tssl_status.Visible = true;
                    tssl_status.Text = "Initializing...";
                    string tssStr = "";
                    string[] qdt = this.GetQuestionData();
                    bool isCancel = false;
                    string CancelMsg = "";
                    Progress<string> progressHandler = new Progress<string>(val => { tssl_status.Text = val; });
                    IProgress<string> progress = (IProgress<string>)progressHandler;
                    try
                    {
                        await Task.Run(() => {
                            progress.Report("Creating folder if not exist...");
                            Directory.CreateDirectory(this.ComparesStoragePath + cf.GetCurrentDate() + "\\" + evaluwee_uid + "." + evaluwee_name);
                            progress.Report("Getting the questionnaire data...");
                            string[] ComPatArr = ComparesPath.Split('\\');
                            string transferpath = this.ComparesStoragePath + cf.GetCurrentDate() + "\\" + evaluwee_uid + "." + evaluwee_name + "\\" + ComPatArr[ComPatArr.Length - 1];
                            string qry = "INSERT INTO dbo.tbl_btpr_eval(user_id,eval_user_id,dep,filename,filepath,cl_id,autofail,q1,q2,q3,audio_quality,total_score,other,dt_created) " +
                                "VALUES (@user_id,@eval_user_id,@dep,@filename,@filepath,@cl_id,@autofail,@q1,@q2,@q3,@audio_quality,@total_score,@other,@dt_created)";
                            int qryR = 0;
                            try
                            {
                                qryR = db.nQuery(qry, new string[] {"user_id", this.evaluwee_uid.ToString(), "eval_user_id", this.evaluator_uid.ToString(), "dep", this.evaluwee_dep, "filename", this.filename, "filepath", transferpath, "cl_id", accounts.ToString(),
                                     "autofail", qdt[3], "q1", qdt[0], "q2", qdt[1], "q3", qdt[2], "audio_quality", aq.ToString(), "total_score", lbl_score.Text,
                                     "other", qdt[4], "dt_created", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")});

                                if (qryR == 0)
                                {
                                    ErrorQry = qry;
                                    isCancel = true;
                                    CancelMsg = "Something went wrong while trying to save data";
                                }
                                else
                                {
                                    progress.Report("Copying compares from desktop to server...");
                                    try
                                    {
                                        File.Copy(ComparesPath, transferpath, true);
                                        progress.Report("Finishing...");

                                        int eid = GetEvalID();
                                        qry = "UPDATE dbo.Main SET evalid = " + eid + " WHERE Id = " + this.fid;
                                        try
                                        {
                                            int uqry = db.nQuery(qry);
                                        }
                                        catch (Exception)
                                        {
                                            ErrorQry = qry;
                                            throw;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        tssStr = "Error Encountered!";cf.Debug(ex,true,"", ComparesPath);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                tssStr = "Error Encountered!";cf.Debug(ex,true,"", qry);
                            }

                        });
                        tssStr = "Saved...";
                        MessageBox.Show(this, "Saved!\n\nThe eval form will close after this message box is closed.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.Yes;
                        this.Dispose();
                    }
                    catch (Exception ex)
                    {
                        tssStr = "Error Encountered!";cf.Debug(ex,true,"", ErrorQry);
                    }
                    if (isCancel)
                    {
                        MessageBox.Show(this, CancelMsg, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    tssl_status.Text = tssStr;
                    this.Cursor = Cursors.Default;
                    tlp_info_container.Enabled = true;
                    tlp_question_container.Enabled = true;
                }
            }


        }
        /// <summary>
        /// Event for changing the question combobox value and calculate the result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbo_q_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ScoreCalculator();
        }
        /// <summary>
        /// opens a file browser to select a .doc file and putting the file path to txt_compares
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_compares_Click(object sender, EventArgs e)
        {
            this.GetSetCompares();
        }
        /// <summary>
        /// Change date event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtcontrol = (DateTimePicker)sender;
            if (dtcontrol.Name == "dtpicker")
            {
                this.DisplayUserList();
            }
            else//own
            {
                this.DisplayEvals();
            }
        }
        /// <summary>
        /// Filter datagridview by name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchName_TextChanged(object sender, EventArgs e)
        {
            DataGridView[] dgvarr = new DataGridView[] { dgv_bt, dgv_pr, dgv_bet };
            string str = txt_searchname.Text;
            foreach (DataGridView dgv in dgvarr)
            {
                (dgv.DataSource as DataTable).DefaultView.RowFilter = "Name LIKE '" + str + "*'";
            }
        }
        /// <summary>
        /// Only Numbers is allowed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtNumbersOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }
        /// <summary>
        /// Datagridview user list cell click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVUlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridView[] dgvarr = new DataGridView[] { dgv_bt, dgv_pr, dgv_bet };
                DataGridView dgv = sender as DataGridView;
                string uname = dgv[0, e.RowIndex].Value.ToString(),
                    dep = dgv[2, e.RowIndex].Value.ToString(),
                    pos = dgv[3, e.RowIndex].Value.ToString();
                int userid = (int)dgv[4, e.RowIndex].Value;
                foreach (DataGridView dv in dgvarr)
                {
                    if (dv.Name != dgv.Name) { dv.ClearSelection(); }
                }
                lbl_evaluwee.Text = uname;

                evaluwee_uid = userid;
                evaluwee_name = uname;
                evaluwee_dep = dep;
                evaluwee_pos = pos;

                DisplayEvals(userid);
            }
        }
        /// <summary>
        /// Datagridview eval list cell click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_eval_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                this.Cursor = Cursors.AppStarting;

                DataGridView dgv = sender as DataGridView;
                string evaluator = dgv[0, e.RowIndex].Value.ToString(), score = dgv[1, e.RowIndex].Value.ToString(),
                    filename = dgv[5, e.RowIndex].Value.ToString(), filepath = dgv[7, e.RowIndex].Value.ToString(),
                    other = dgv[8, e.RowIndex].Value.ToString(), q1 = dgv[9, e.RowIndex].Value.ToString(),
                    q2 = dgv[10, e.RowIndex].Value.ToString(), q3 = dgv[11, e.RowIndex].Value.ToString(),
                    q4 = dgv[12, e.RowIndex].Value.ToString(), dt = dgv[13, e.RowIndex].Value.ToString();
                int evaluatorID = (int)dgv[2, e.RowIndex].Value, eid = (int)dgv[3, e.RowIndex].Value,
                    accounts = (int)dgv[4, e.RowIndex].Value, aq = (int)dgv[6, e.RowIndex].Value;

                QuestionData.Others others = JsonConvert.DeserializeObject<QuestionData.Others>(other);
                QuestionData.Q1 q1o = JsonConvert.DeserializeObject<QuestionData.Q1>(q1);
                QuestionData.Q2 q2o = JsonConvert.DeserializeObject<QuestionData.Q2>(q2);
                QuestionData.Q3 q3o = JsonConvert.DeserializeObject<QuestionData.Q3>(q3);
                QuestionData.Q4 q4o = JsonConvert.DeserializeObject<QuestionData.Q4>(q4);

                cbo_accounts.SelectedValue = accounts;
                cbo_aq.SelectedValue = aq;
                cbo_q1_1.SelectedValue = q1o.sel1;
                cbo_q1_2.SelectedValue = q1o.sel2;
                cbo_q2_1.SelectedValue = q2o.sel1;
                cbo_q2_2.SelectedValue = q2o.sel2;
                cbo_q3_1.SelectedValue = q3o.sel1;
                cbo_q3_2.SelectedValue = q3o.sel2;
                cbo_q4.SelectedValue = q4o.sel;

                txt_filename.Text = filename;
                txt_compares.Text = filepath;
                txt_words.Text = others.words;
                txt_mistakes.Text = others.mistakes;

                rtxt_q1_1.Text = q1o.feedback1;
                rtxt_q1_2.Text = q1o.feedback2;
                rtxt_q2_1.Text = q2o.feedback1;
                rtxt_q2_2.Text = q2o.feedback2;
                rtxt_q3_1.Text = q3o.feedback1;
                rtxt_q3_2.Text = q3o.feedback2;
                rtxt_q4.Text = q4o.feedback;

                lbl_evaluator.Text = evaluator;
                evaluator_uid = evaluatorID;
                this.ScoreCalculator();
                this.CboReadOnlyAlt();
                this.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// Reload current user evaluation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reload_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Name == "btn_refresh")
            {
                this.DisplayUserList();
            }
            else
            {
                this.DisplayEvals();
            }
        }
        private void frm_file_eval_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_cnl != null) { _cnl.Cancel(); }
        }

        /// <summary>
        /// Open bulk download form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_bulk_download_Click(object sender, EventArgs e)
        {
            DataTable dt = dgv_eval_list.DataSource as DataTable;
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(this, "No compares to download", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                List<string> lst = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    object[] obj = row.ItemArray;
                    lst.Add(obj[7].ToString());
                }

                frm_file_eval_bulkdownload ffeb = new frm_file_eval_bulkdownload(lst.ToArray());
                ffeb.ShowDialog(this);
            }


        }
        /// <summary>
        /// Opens export to excel form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_export_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;

            frm_export frmex = new frm_export(new string[] { this.uid.ToString(), this.uname, this.upos, this.udep }, "eval");
            frmex.ShowDialog(this);

            this.Cursor = Cursors.Default;
        }
        #endregion Events

        #region Void Methods
        /// <summary>
        /// Enabled/Disable combobox, textbox and richtextbox controls.
        /// </summary>
        private void EnabledControls(bool b = true)
        {
            bool readOnly = (!b);
            Label[] lblarr = new Label[] {lbl_accounts_cbo,lbl_aq_cbo,lbl_q1_1_cbo,lbl_q1_2_cbo,lbl_q2_1_cbo,lbl_q2_2_cbo,
            lbl_q3_1_cbo,lbl_q3_2_cbo,lbl_q4_cbo};
            ComboBox[] cboarr = new ComboBox[] {cbo_accounts, cbo_aq,cbo_q1_1,cbo_q1_2,cbo_q2_1,cbo_q2_2,cbo_q3_1,cbo_q3_2,
            cbo_q4};
            int index = 0;
            foreach (ComboBox cbo in cboarr)
            {
                cbo.Visible = b;
                if (readOnly)
                {
                    lblarr[index].Visible = true;
                    lblarr[index].Text = cbo.Text;
                }
                index++;
            }

            txt_filename.ReadOnly = readOnly;
            txt_compares.ReadOnly = readOnly;
            txt_mistakes.ReadOnly = readOnly;
            txt_words.ReadOnly = readOnly;

            rtxt_q1_1.ReadOnly = readOnly;
            rtxt_q1_2.ReadOnly = readOnly;
            rtxt_q2_1.ReadOnly = readOnly;
            rtxt_q2_2.ReadOnly = readOnly;
            rtxt_q3_1.ReadOnly = readOnly;
            rtxt_q3_2.ReadOnly = readOnly;
            rtxt_q4.ReadOnly = readOnly;
        }
        /// <summary>
        /// Change label.text base on the combobox.text
        /// </summary>
        private void CboReadOnlyAlt()
        {
            Label[] lblarr = new Label[] {lbl_accounts_cbo,lbl_aq_cbo,lbl_q1_1_cbo,lbl_q1_2_cbo,lbl_q2_1_cbo,lbl_q2_2_cbo,
            lbl_q3_1_cbo,lbl_q3_2_cbo,lbl_q4_cbo};
            ComboBox[] cboarr = new ComboBox[] {cbo_accounts, cbo_aq,cbo_q1_1,cbo_q1_2,cbo_q2_1,cbo_q2_2,cbo_q3_1,cbo_q3_2,
            cbo_q4};

            int index = 0;
            foreach (ComboBox cbo in cboarr)
            {
                lblarr[index].Text = cbo.Text;
                index++;
            }
        }
        /// <summary>
        /// Populating combobox (Accounts, Audio Quality, Questions)
        /// </summary>
        private void SetCboDataSource()
        {
            DataTable dt = new DataTable();
            //---Accounts---
            cbo_accounts.DisplayMember = "client";
            cbo_accounts.ValueMember = "cl_id";
            cbo_accounts.DataSource = db.query("SELECT cl_id, client FROM dbo.tbl_client ORDER BY client");
            //---Audio Quality---
            dt.Columns.Add("text", typeof(string));
            dt.Columns.Add("value", typeof(int));
            dt.Rows.Add("Bad", 1);
            dt.Rows.Add("Fair", 2);
            dt.Rows.Add("Good", 3);
            dt.Rows.Add("Very Good", 4);
            dt.Rows.Add("Excellent", 5);

            cbo_aq.DisplayMember = "text";
            cbo_aq.ValueMember = "value";
            cbo_aq.DataSource = dt;
            cbo_aq.SelectedValue = 3;
            //---q1.1---
            dt = new DataTable();
            dt.Columns.Add("text", typeof(string));
            dt.Columns.Add("value", typeof(double));

            dt.Rows.Add("Met all requirements", 1.11);
            dt.Rows.Add("Did not meet 1 requirement", 0.833333333);
            dt.Rows.Add("Did not meet 2 requirements", 0.556666667);
            dt.Rows.Add("Did not meet 3 requirements", 0.28);
            dt.Rows.Add("Failed to meet all requirements", 0);
            cbo_q1_1.DisplayMember = "text";
            cbo_q1_1.ValueMember = "value";
            cbo_q1_1.DataSource = dt;
            //---q1.2---
            dt = new DataTable();
            dt.Columns.Add("text", typeof(string));
            dt.Columns.Add("value", typeof(double));
            dt.Rows.Add("Yes", 0.553333333);
            dt.Rows.Add("No", 0);
            cbo_q1_2.DisplayMember = "text";
            cbo_q1_2.ValueMember = "value";
            cbo_q1_2.DataSource = dt;
            //---q2.1---
            dt = new DataTable();
            dt.Columns.Add("text", typeof(string));
            dt.Columns.Add("value", typeof(double));
            dt.Rows.Add("Yes", 0.666666667);
            dt.Rows.Add("No", 0);
            cbo_q2_1.DisplayMember = "text";
            cbo_q2_1.ValueMember = "value";
            cbo_q2_1.DataSource = dt;
            //---q2.2---
            dt = new DataTable();
            dt.Columns.Add("text", typeof(string));
            dt.Columns.Add("value", typeof(double));
            dt.Rows.Add("Excellent", 2);
            dt.Rows.Add("Very Good", 1.75);
            dt.Rows.Add("Good", 1.5);
            dt.Rows.Add("Okay", 1.25);
            dt.Rows.Add("Fair", 1);
            dt.Rows.Add("Weak to Fair", 0.75);
            dt.Rows.Add("Weak", 0.5);
            dt.Rows.Add("Poor", 0.25);
            dt.Rows.Add("Fail", 0);
            cbo_q2_2.DisplayMember = "text";
            cbo_q2_2.ValueMember = "value";
            cbo_q2_2.DataSource = dt;
            //---q3.1---
            dt = new DataTable();
            dt.Columns.Add("text", typeof(string));
            dt.Columns.Add("value", typeof(double));
            dt.Rows.Add("Excellent", 4.666666667);
            dt.Rows.Add("Very Good", 4);
            dt.Rows.Add("Good", 3.333333333);
            dt.Rows.Add("Okay", 2.666666667);
            dt.Rows.Add("Fair", 2);
            dt.Rows.Add("Weak to Fair", 1.333333333);
            dt.Rows.Add("Weak", 0.666666667);
            dt.Rows.Add("Poor", 0.333333333);
            dt.Rows.Add("Fail", 0);
            cbo_q3_1.DisplayMember = "text";
            cbo_q3_1.ValueMember = "value";
            cbo_q3_1.DataSource = dt;
            //---q3.2---
            dt = new DataTable();
            dt.Columns.Add("text", typeof(string));
            dt.Columns.Add("value", typeof(double));
            dt.Rows.Add("Yes", 1);
            dt.Rows.Add("No", 0);
            cbo_q3_2.DisplayMember = "text";
            cbo_q3_2.ValueMember = "value";
            cbo_q3_2.DataSource = dt;
            //---q4---
            dt = new DataTable();
            dt.Columns.Add("text", typeof(string));
            dt.Columns.Add("value", typeof(double));
            dt.Rows.Add("No", 30.004);
            dt.Rows.Add("Yes", 0.00);
            cbo_q4.DisplayMember = "text";
            cbo_q4.ValueMember = "value";
            cbo_q4.DataSource = dt;
        }
        /// <summary>
        /// Calculate the score from all the question combobox
        /// </summary>
        private void ScoreCalculator()
        {
            double q1_1 = double.Parse(cbo_q1_1.SelectedValue.ToString());
            double q1_2 = double.Parse(cbo_q1_2.SelectedValue.ToString());
            double q2_1 = double.Parse(cbo_q2_1.SelectedValue.ToString());
            double q2_2 = double.Parse(cbo_q2_2.SelectedValue.ToString());
            double q3_1 = double.Parse(cbo_q3_1.SelectedValue.ToString());
            double q3_2 = double.Parse(cbo_q3_2.SelectedValue.ToString());
            double q4 = double.Parse(cbo_q4.SelectedValue.ToString());

            double Q1Score = 0.00, Q2Score = 0.00, Q3Score = 0.00, TotalScore = 0.00;

            if (q4 == 0)
            {
                TotalScore = q4;
            }
            else
            {
                Q1Score = (q1_1 + q1_2) * 3; Q2Score = (q2_1 + q2_2) * 3; Q3Score = ((q3_1 + q3_2) * 3) + 0.01;
                TotalScore = (Q1Score + Q2Score + Q3Score);
            }
            lbl_q1_score.Text = Q1Score.ToString("0.00");
            lbl_q2_score.Text = Q2Score.ToString("0.00");
            lbl_q3_score.Text = Q3Score.ToString("0.00");
            lbl_score.Text = TotalScore.ToString("0.00");
            //---Set score text and color---
            string scoretxt = ""; Color scoretxtcolor = Color.FromArgb(0, 138, 0);
            double score = Math.Floor(TotalScore);
            switch (score)
            {
                case double n when n == 30 && n > 29:
                    scoretxt = "Excellent"; scoretxtcolor = Color.FromArgb(0, 138, 0);
                    break;
                case double n when n <= 29 && n > 27:
                    scoretxt = "Very Good"; scoretxtcolor = Color.FromArgb(96, 169, 23);
                    break;
                case double n when n <= 27 && n > 25:
                    scoretxt = "Good"; scoretxtcolor = Color.FromArgb(164, 196, 0);
                    break;
                case double n when n <= 25 && n > 23:
                    scoretxt = "Okay"; scoretxtcolor = Color.FromArgb(51, 51, 51);
                    break;
                case double n when n <= 23 && n > 22:
                    scoretxt = "Fair"; scoretxtcolor = Color.FromArgb(85, 85, 85);
                    break;
                case double n when n <= 22 && n > 21:
                    scoretxt = "Weak to Fair"; scoretxtcolor = Color.FromArgb(153, 153, 153);
                    break;
                case double n when n <= 21 && n > 20:
                    scoretxt = "Weak"; scoretxtcolor = Color.FromArgb(227, 200, 0);
                    break;
                case double n when n <= 20 && n > 19:
                    scoretxt = "Poor"; scoretxtcolor = Color.FromArgb(240, 163, 10);
                    break;
                case double n when n <= 19:
                    scoretxt = "Fail"; scoretxtcolor = Color.FromArgb(162, 0, 37);
                    break;
            }
            lbl_score_txt.Text = scoretxt;
            lbl_score_txt.ForeColor = scoretxtcolor;
        }
        /// <summary>
        /// Compute the accuracy and error
        /// </summary>
        /// <param name="w">words</param>
        /// <param name="m">mistakes</param>
        private void EACompute(decimal w = 0, decimal m = 0)
        {
            decimal escore = 0, ascore = 0;
            escore = (m == 0 && w == 0) ? 0 : ((m / w) * 100);
            ascore = (escore > 100) ? 0 : (100 - escore);
            lbl_ac.Text = ascore.ToString("0.00");
            lbl_error.Text = escore.ToString("0.00");
        }
        /// <summary>
        /// Set the event handler to all the question combobox after the datasources of the combobox is loaded
        /// </summary>
        private void SetEventHandler()
        {
            this.cbo_q1_1.SelectedIndexChanged += cbo_q_SelectedIndexChanged;
            this.cbo_q1_2.SelectedIndexChanged += cbo_q_SelectedIndexChanged;
            this.cbo_q2_1.SelectedIndexChanged += cbo_q_SelectedIndexChanged;
            this.cbo_q2_2.SelectedIndexChanged += cbo_q_SelectedIndexChanged;
            this.cbo_q3_1.SelectedIndexChanged += cbo_q_SelectedIndexChanged;
            this.cbo_q3_2.SelectedIndexChanged += cbo_q_SelectedIndexChanged;
            this.cbo_q4.SelectedIndexChanged += cbo_q_SelectedIndexChanged;
        }
        /// <summary>
        /// Set the evaluwee info (only if viewtype is "save")
        /// </summary>
        private void Set_EvaluweeInfo()
        {
            try
            {
                string[] qry = db.row("SELECT Id,UPPER(LEFT(username,1))+LOWER(SUBSTRING(username,2,LEN(username))) AS uname,department,position FROM dbo.UserData WHERE Id = " + btid);
                evaluwee_uid = int.Parse(qry[0]);
                evaluwee_name = qry[1];
                evaluwee_dep = qry[2];
                evaluwee_pos = qry[3];
            }
            catch (Exception ex)
            {
                cf.Debug(ex, true, "Failed to get the evaluwee info.");
            }
        }
        /// <summary>
        /// Getting or setting the compares depends on the viewtype.
        /// <para>If the viewtype is "save" then this will set the compares to the textbox.</para>
        /// <para>Other than that then this will copy the compares from the server.</para>
        /// </summary>
        private void GetSetCompares()
        {
            if (this.Tag.ToString() == "save")
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "Please select the Compares";
                    ofd.Filter = "Word Documents|*.doc";
                    ofd.Multiselect = false;

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        this.ComparesFileName = ofd.SafeFileName;
                        txt_compares.Text = ofd.FileName;
                    }
                }
            }
            else
            {
                string path = txt_compares.Text;
                if (!cf.IsStringEmpty(path))
                {
                    using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                    {

                        string[] pathArr = path.Split('\\');
                        fbd.Description = "Please select a folder";
                        if (fbd.ShowDialog() == DialogResult.OK)
                        {
                            string newpath = fbd.SelectedPath + "\\" + pathArr[pathArr.Length - 1];
                            File.Copy(path, newpath);
                            if (cf.IsExist(newpath, true) == "ok")
                            {
                                MessageBox.Show(this, "Success", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(this, "Something went wrong while copying the compares from the server.\n" +
                                    "Please check the compares from this path: \n" +
                                    path, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Loading user list to the respective datagridview
        /// </summary>
        private void DisplayUserList()
        {

            this.Cursor = Cursors.AppStarting;
            tssl_status.Visible = true; tssl_status.Text = "Fetching user data...";
            string SelDT = dtpicker.Value.Date.ToString("MM/dd/yyyy"), tssStr = "";
            DataTable btdt = new DataTable(), prdt = new DataTable(), betdt = new DataTable();
            //---Setting the column headers property---
            List<CustomClass.GridHeaders> header = new List<CustomClass.GridHeaders>()
            {
                new CustomClass.GridHeaders{index = 0, text = "Name", width = 100, type = typeof(string)},
                new CustomClass.GridHeaders{index = 1, text = "Evals", width = 100, type = typeof(string)},
                new CustomClass.GridHeaders{index = 2, text = "Dep", width = 0, visible = false, type = typeof(string)},
                new CustomClass.GridHeaders{index = 3, text = "Pos", width = 0, visible = false, type = typeof(string)},
                new CustomClass.GridHeaders{index = 4, text = "UserID", width = 0, visible = false, type = typeof(int)}
            };
            //---Setting the datagridview control and its datasource---
            List<DGVData> dgvdata = new List<DGVData>();
            //{
            //    new DGVData{dgv = dgv_bt,dataTable = btdt},
            //    new DGVData{dgv = dgv_pr,dataTable = prdt},
            //    new DGVData{dgv = dgv_bet,dataTable = betdt}
            //};
            if (ViewDep.Contains("bt")) { dgvdata.Add(new DGVData { dgv = dgv_bt, dataTable = btdt }); }
            if (ViewDep.Contains("pr")) { dgvdata.Add(new DGVData { dgv = dgv_bt, dataTable = prdt }); }
            if (ViewDep.Contains("bet")) { dgvdata.Add(new DGVData { dgv = dgv_bt, dataTable = betdt }); }
            //---Adding columns to the datatable with each of the datagridview---
            foreach (var dgvd in dgvdata)
            {
                foreach (var hdata in header)
                {
                    dgvd.dataTable.Columns.Add(hdata.text, hdata.type);
                }
            }

            try
            {
                string qry = "SELECT Id, UPPER(LEFT(username,1))+LOWER(SUBSTRING(username,2,LEN(username))) AS uname, " +
                "position, department, status,(SELECT COUNT(eid) FROM dbo.tbl_btpr_eval WHERE user_id = Id AND " +
                "CONVERT(date, dt_created) LIKE CONVERT(date, '" + SelDT + "')) AS cnt FROM dbo.UserData WHERE " +
                "department IN('" + string.Join("','", ViewDep) + "') AND deactivated = 0 ORDER " +
                "BY CASE department WHEN 'bt' THEN 1 WHEN 'pr' THEN 2 WHEN 'bet' THEN 3 ELSE 4 END, username";

                //---Getting data from the database---
                DataTable dt = new DataTable();
                dt = db.query(qry);
                //---Declaring an array to be used for sorting the data to its respective department---
                string[] depArr = ViewDep;
                //---Iterate through all the data from the database---
                foreach (DataRow row in dt.Rows)
                {
                    object[] obj = row.ItemArray;
                    string dep = obj[3].ToString(),
                        uname = obj[1].ToString(),
                        pos = obj[2].ToString(),
                        evalcnt = ((int)obj[5] != 0) ? obj[5].ToString() : "";
                    int userid = (int)obj[0];
                    dgvdata[Array.IndexOf(depArr, dep)].dataTable.Rows.Add(uname, evalcnt, dep, pos, userid);

                }
                //---Setting the datagridview datasource---
                foreach (var dgvd in dgvdata)
                {
                    dgvd.dgv.DataSource = dgvd.dataTable;
                    dgvd.dgv.ClearSelection();
                    //---Setting additional properties to the datagridview column header---
                    foreach (var hdata in header)
                    {
                        dgvd.dgv.Columns[hdata.index].Visible = hdata.visible;
                        dgvd.dgv.Columns[hdata.index].Width = hdata.width;
                    }

                }
                tssStr = "Ready!";
            }
            catch (Exception ex)
            {
                tssStr = "Error Encountered!";
                cf.Debug(ex,true,"", ErrorQry);
            }

            tssl_status.Text = tssStr;
            this.Cursor = Cursors.Default;
        }
        /// <summary>
        /// Loading evaluation list
        /// </summary>
        /// <param name="userID"></param>
        private async void DisplayEvals(int userID = 0)
        {
            _cnl = new CancellationTokenSource();
            CancellationToken token = _cnl.Token;

            tssl_status.Visible = true; tssl_status.Text = "Fetching eval data...";
            this.Cursor = Cursors.AppStarting;
            DateTimePicker dtpcker = (this.Tag.ToString() == "view") ? this.dtpicker : this.dt_mypicker;
            string SelDT = dtpcker.Value.Date.ToString("MM/dd/yyyy"), tssStr = "";
            int userid = (this.Tag.ToString() == "view") ? userID : this.uid;
            DataTable newdt = new DataTable();
            List<CustomClass.GridHeaders> header = new List<CustomClass.GridHeaders>()
            {
                new CustomClass.GridHeaders{index = 0, text = "Evaluator", width = 100, type = typeof(string)},
                new CustomClass.GridHeaders{index = 1, text = "Score", width = 100, type = typeof(string)},
                new CustomClass.GridHeaders{index = 2, text = "evaluatorID", width = 0, type = typeof(int), visible = false},
                new CustomClass.GridHeaders{index = 3, text = "eid", width = 0, type = typeof(int), visible = false},
                new CustomClass.GridHeaders{index = 4, text = "accounts", width = 0, type = typeof(int), visible = false},
                new CustomClass.GridHeaders{index = 5, text = "filename", width = 0, type = typeof(string), visible = false},
                new CustomClass.GridHeaders{index = 6, text = "aq", width = 0, type = typeof(int), visible = false},
                new CustomClass.GridHeaders{index = 7, text = "filepath", width = 0, type = typeof(string), visible = false},
                new CustomClass.GridHeaders{index = 8, text = "other", width = 0, type = typeof(string), visible = false},
                new CustomClass.GridHeaders{index = 9, text = "q1", width = 0, type = typeof(string), visible = false},
                new CustomClass.GridHeaders{index = 10, text = "q2", width = 0, type = typeof(string), visible = false},
                new CustomClass.GridHeaders{index = 11, text = "q3", width = 0, type = typeof(string), visible = false},
                new CustomClass.GridHeaders{index = 12, text = "q4", width = 0, type = typeof(string), visible = false},
                new CustomClass.GridHeaders{index = 13, text = "dt", width = 0, type = typeof(string), visible = false}
            };

            foreach (var h in header)
            {
                newdt.Columns.Add(h.text, h.type);
            }

            Progress<string> progressHandler = new Progress<string>(val => { tssl_status.Text = val; });
            IProgress<string> progress = (IProgress<string>)progressHandler;
            try
            {
                await Task.Run(() => {
                    string qry = "SELECT eid,user_id,eval_user_id," +
                        "(SELECT UPPER(LEFT(username, 1)) + LOWER(SUBSTRING(username, 2, LEN(username))) FROM dbo.UserData WHERE Id = eval_user_id) AS uname," +
                        "dep, filename, filepath, cl_id, autofail, q1, q2, q3, audio_quality, total_score, other, dt_created FROM dbo.tbl_btpr_eval WHERE user_id = " + userid + " AND CONVERT(date, dt_created) LIKE CONVERT(date, '" + SelDT + "')";
                    DataTable dt = new DataTable();
                    try
                    {
                        dt = db.query(qry);
                        token.ThrowIfCancellationRequested();
                    }
                    catch (Exception)
                    {
                        ErrorQry = qry;
                        throw;
                    }
                    int x = 0, cnt = dt.Rows.Count;
                    foreach (DataRow row in dt.Rows)
                    {
                        token.ThrowIfCancellationRequested();
                        progress.Report("Evals: " + x + " of " + cnt);
                        object[] obj = row.ItemArray;
                        newdt.Rows.Add(obj[3], obj[13], obj[2], obj[0], obj[7], obj[5], obj[12], obj[6], obj[14], obj[9], obj[10], obj[11], obj[8], obj[15]);
                    }
                });
                dgv_eval_list.DataSource = newdt;
                foreach (var h in header)
                {
                    dgv_eval_list.Columns[h.index].Visible = h.visible;
                    dgv_eval_list.Columns[h.index].Width = h.width;
                }
                dgv_eval_list.ClearSelection();
                tssStr = "Ready!";
            }
            catch (Exception ex)
            {
                tssStr = "Error Encountered!";cf.Debug(ex,true,"", ErrorQry);
            }

            ErrorQry = "";
            tssl_status.Text = tssStr;
            this.Cursor = Cursors.Default;
        }

        private void SetRestrictions()
        {
            FileEval fe = new FileEval();
            if (!cf.IsStringEmpty(CurUserRestriction))
            {
                try
                {
                    UserRestrictionsClass urc = JsonConvert.DeserializeObject<UserRestrictionsClass>(CurUserRestriction);
                    fe = urc.FileEval;
                }
                catch (Exception ex)
                {
                    cf.Debug(ex, true, "Something is wrong with the current restrictions.\nRestrictions will revert to default.");
                }
            }

            EnabledControls(fe.AllowCreateEval);
            btn_export.Enabled = fe.AllowExport;
            tc_dep.Enabled = fe.AllowViewEval;
            IsAllowViewEval = fe.AllowViewEval;
            
        }
        #endregion Void Methods

        #region Functions
        /// <summary>
        /// Get the array of json format question data
        /// </summary>
        /// <returns>Array(q1,q2,q3,q4)</returns>
        private string[] GetQuestionData()
        {
            string q1o, q2o, q3o, q4o, othersO;
            QuestionData.Q1 q1 = new QuestionData.Q1();
            QuestionData.Q2 q2 = new QuestionData.Q2();
            QuestionData.Q3 q3 = new QuestionData.Q3();
            QuestionData.Q4 q4 = new QuestionData.Q4();
            QuestionData.Others others = new QuestionData.Others();

            q1.sel1 = cbo_q1_1.SelectedValue.ToString();
            q1.sel2 = cbo_q1_2.SelectedValue.ToString();
            q2.sel1 = cbo_q2_1.SelectedValue.ToString();
            q2.sel2 = cbo_q2_2.SelectedValue.ToString();
            q3.sel1 = cbo_q3_1.SelectedValue.ToString();
            q3.sel2 = cbo_q3_2.SelectedValue.ToString();
            q4.sel = cbo_q4.SelectedValue.ToString();

            q1.feedback1 = rtxt_q1_1.Text;
            q1.feedback2 = rtxt_q1_2.Text;
            q2.feedback1 = rtxt_q2_1.Text;
            q2.feedback2 = rtxt_q2_2.Text;
            q3.feedback1 = rtxt_q3_1.Text;
            q3.feedback2 = rtxt_q3_2.Text;
            q4.feedback = rtxt_q4.Text;

            others.words = txt_words.Text;
            others.mistakes = txt_mistakes.Text;

            q1o = JsonConvert.SerializeObject(q1);
            q2o = JsonConvert.SerializeObject(q2);
            q3o = JsonConvert.SerializeObject(q3);
            q4o = JsonConvert.SerializeObject(q4);
            othersO = JsonConvert.SerializeObject(others);

            return new string[] { q1o, q2o, q3o, q4o, othersO };
        }
        /// <summary>
        /// Getting the evaluation ID after the evaluation is saved
        /// </summary>
        /// <returns></returns>
        private int GetEvalID()
        {
            int evalid = 0; string filename = txt_filename.Text;
            try
            {
                string dts = db.single("SELECT eid FROM dbo.tbl_btpr_eval WHERE user_id = " + evaluwee_uid.ToString() + " AND eval_user_id = " + evaluator_uid.ToString() + " AND filename LIKE '" + filename + "'");
                evalid = int.Parse(dts);
            }
            catch (Exception ex)
            {
                cf.Debug(ex,true,"Failed to get evaluation ID.");
            }
            
            return evalid;
        }
        /// <summary>
        /// Getting the ID of the given client name
        /// </summary>
        /// <param name="cl">Client name</param>
        /// <returns>int</returns>
        private int GetClientID(string cl)
        {
            int id = 0;
            string qry = "SELECT cl_id FROM dbo.tbl_client WHERE client LIKE '" + cl + "'", qryr;
            try
            {
                qryr = db.single(qry);
                id = int.Parse(qryr);
            }
            catch (Exception ex)
            {
                cf.Debug(ex, true, "", qry);
            }
            return id;
        }
        #endregion Functions
    }

    public class QuestionData
    {
        public class Q1
        {
            public string sel1 { get; set; }
            public string feedback1 { get; set; }
            public string sel2 { get; set; }
            public string feedback2 { get; set; }
        }
        public class Q2
        {
            public string sel1 { get; set; }
            public string feedback1 { get; set; }
            public string sel2 { get; set; }
            public string feedback2 { get; set; }
        }
        public class Q3
        {
            public string sel1 { get; set; }
            public string feedback1 { get; set; }
            public string sel2 { get; set; }
            public string feedback2 { get; set; }
        }
        public class Q4
        {
            public string sel { get; set; }
            public string feedback { get; set; }
        }
        public class Others
        {
            public string words { get; set; }
            public string mistakes { get; set; }
        }
    }
    /// <summary>
    /// Store the datagridview control as well as its datatable
    /// </summary>
    public class DGVData
    {
        public DataGridView dgv { get; set; }
        public DataTable dataTable { get; set; }
    }
}
