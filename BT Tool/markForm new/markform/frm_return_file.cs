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

using Newtonsoft.Json;

namespace markform
{
    public partial class frm_return_file : Form
    {
        #region Initialize Classes
        CustomClass cf = new CustomClass();
        SQLClass db = new SQLClass();
        private DataTable nDataTable = new DataTable();
        private List<CustomClass.GridHeaders> headers = new List<CustomClass.GridHeaders>();
        #endregion
                       
        #region Setting Variables
        private int uid, ulvl, btid;
        private string uname, upos, udep, UserRestriction = "";
        /// <summary>
        /// error occured during the query execution inside the DoWork()
        /// </summary>
        private string ErrorQuery = "";
        private CancellationTokenSource _cnl;
        private bool IsAllowSave = false, IsAllowView = false, IsViewOnly = false;
        private string[] AllowDep = new string[] { };
        #endregion

        #region Form Class Initialization
                /// <summary>
        /// <paramref name="args"/> should contain an array of Array(user id, username, user position, user department, user level,filename,client id,btid)
        /// </summary>
        /// <param name="args"></param>
        public frm_return_file(string[] args = null, bool viewonly = false,string CurrentUserRestriction = "")
        {
            InitializeComponent();
            Tag = "return";
            //pic_prank.Visible = false;
            //pic_prank.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - (pic_prank.Width + 100), 13);
            if (args != null)
            {
                uid = int.Parse(args[0].ToString());
                uname = args[1].ToString();
                upos = args[2].ToString();
                udep = args[3].ToString();
                ulvl = int.Parse(args[4].ToString());
                UserRestriction = CurrentUserRestriction;
                IsViewOnly = viewonly;

                sb_info.Items.Add("User ID: " + uid);
                sb_info.Items.Add("User Name: " + uname.ToUpper());
                sb_info.Items.Add("User Position: " + cf.GetPositionFull(upos).ToUpper());
                sb_info.Items.Add("User Department: " + udep.ToUpper());
                sb_info.Items.Add("User Level: " + ulvl);

                foreach (ToolStripStatusLabel itm in sb_info.Items)
                {
                    itm.BorderSides = ToolStripStatusLabelBorderSides.All;
                    itm.BorderStyle = Border3DStyle.Sunken;
                }
                
                if (!viewonly)
                {
                    
                    txt_fn.Text = args[5].ToString();
                    cbo_cl.SelectedValue = GetClientID(args[6].ToString());
                    lbl_client.Text = cbo_cl.Text;
                    btid = int.Parse(args[7].ToString());
                    cbo_name.SelectedValue = btid;
                }

                LoadReturn();
                Restrictions();
                cbo_type.SelectedIndexChanged += new EventHandler(FilterData_SelectedIndexChanged);
                cbo_dep.SelectedIndexChanged += new EventHandler(FilterData_SelectedIndexChanged);
            }
        }
        #endregion

        #region Events
        private void frm_return_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cnl != null) { _cnl.Cancel(); }
        }
        /// <summary>
        /// This will just call the LoadReturn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpicker_ValueChanged(object sender, EventArgs e)
        {
            LoadReturn();
        }
        /// <summary>
        /// This will just call the LoadReturn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reload_Click(object sender, EventArgs e)
        {
            LoadReturn();
        }
        /// <summary>
        /// Opens the export form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_export_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;

            frm_export frmex = new frm_export(new string[] { uid.ToString(), uname, upos, udep }, "return");
            frmex.ShowDialog(this);

            Cursor = Cursors.Default;
        }
        /// <summary>
        /// Save validation and action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            string SecondAssigned = cbo_second_assigned.SelectedValue.ToString(),
                name = cbo_name.SelectedValue.ToString(),
                fixby = cbo_fxby.SelectedValue.ToString(),
                actby = cbo_actby.SelectedValue.ToString(),
                cl = cbo_cl.SelectedValue.ToString(),
                ac = txt_ac.Text, sp = txt_sp.Text, fn = txt_fn.Text,
                com1 = rtxt_com1.Text, com2 = rtxt_com2.Text, com3 = rtxt_com3.Text;

            string opsdep = (udep == "pr") ? "BT" : "PR";

            List<string> errmsg = new List<string>();

            if (cf.IsStringEmpty(name))
            {
                errmsg.Add("-Please select " + opsdep + " Name.");
            }
            if (cf.IsStringEmpty(fixby))
            {
                errmsg.Add("-Please select File Fixed By.");
            }
            if (cf.IsStringEmpty(fn))
            {
                errmsg.Add("-Filename is empty.");
            }

            if (errmsg.Count > 0)
            {
                MessageBox.Show(this, string.Join("\n", errmsg.ToArray()), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show(this, "You are about to send a return file.", "Confirm Return File", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    Cursor = Cursors.AppStarting;
                    DisableForm(false);

                    ReturnFile rf = new ReturnFile()
                    {
                        accuracy = ac,
                        specs = sp,
                        btpr_comment = com1,
                        side_comment = com2,
                        comment = com3
                    };
                    tss_status.Text = "Saving...";
                    string rfo = JsonConvert.SerializeObject(rf), tssStr = "";
                    string qryStr = "INSERT INTO dbo.tbl_flag_return(user_id,user2_id,btpr_id,fixer_id,act_id,cl_id,filename,dep,type,others,dt_created) VALUES(@user_id,@user2_id,@btpr_id,@fixer_id,@act_id,@cl_id,@filename,@dep,@type,@others,@dt_created)";

                    try
                    {
                        int qryResult = db.nQuery(qryStr, new string[] { "user_id", uid.ToString(), "user2_id", SecondAssigned, "btpr_id", name, "fixer_id", fixby, "act_id", actby, "cl_id", cl, "filename", fn, "dep", udep, "type", "return", "others", rfo, "dt_created", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") });
                        if (qryResult == 0)
                        {
                            MessageBox.Show(this, "Something went wrong while trying to save the return file to the database.", "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            tssStr = "Done!";
                            MessageBox.Show(this, "Return file successfully send.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //ResetForm(); LoadReturn();
                            DialogResult = DialogResult.Yes;
                            Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        tssStr = "Error Encountered!";
                        cf.Debug(ex, true, "", "\n\n" + ErrorQuery);
                    }
                    tss_status.Text = tssStr;
                    DisableForm();
                    Cursor = Cursors.Default;
                    LoadReturn();
                }
            }


        }
        /// <summary>
        /// Reinitialize row number when sorting to be always from 1 to n
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_return_Sorted(object sender, EventArgs e)
        {
            cf.RowsNumber(dgv_return);
        }
        /// <summary>
        /// When the control inside the return form is focus and enter key is pressed then perform click event on save button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && !e.Shift)
            {
                btn_save.PerformClick();
            }
        }
        /// <summary>
        /// Event for seen/unseen and delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActionBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int qryResult = 0;
            string msgContent = "", msgTitle = "";
            List<int> Ids = new List<int>();

            foreach (DataGridViewRow row in dgv_return.SelectedRows)
            {
                Ids.Add(int.Parse(row.Cells[14].Value.ToString()));
            }

            if (Ids.Count == 0)
            {
                MessageBox.Show(this, "No item selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string ws = (Ids.Count > 1)     ? "s" : "";
                msgContent = (btn.Text.ToLower() == "delete") ?
                    "You are about to delete " + Ids.Count + " selected item" + ws + "." :
                    "You are about to " + btn.Text.ToLower() + " " + Ids.Count + " selected item" + ws + ".";
                msgTitle = "Confirm " + (btn.Text.ToLower() == "delete" ? "Delete" : "Update");

                DialogResult dr = MessageBox.Show(this, msgContent, msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    Cursor = Cursors.AppStarting;
                    DisableForm(false);

                    string idjoin = string.Join(",", Ids.ToArray());
                    string qry = (btn.Text.ToLower() == "delete") ?
                        "DELETE FROM dbo.tbl_flag_return WHERE fid IN (" + idjoin + ")" :
                        "UPDATE dbo.tbl_flag_return SET seen = " + (btn.Text.ToLower() == "seen" ? 1 : 0) + " WHERE fid IN (" + idjoin + ")";
                    qryResult = db.nQuery(qry);

                    if (qryResult == 0)
                    {
                        MessageBox.Show(this, "Something went wrong while trying to process the query.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    DisableForm();
                    Cursor = Cursors.Default;
                    LoadReturn();
                }
            }
        }
        /// <summary>
        /// Filter Data when combobox selected item is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterData_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterData();
        }
        
        #endregion

        #region Void Methods
        /// <summary>
        /// Setting the text of the dynamic labels
        /// </summary>
        private void SetPRBETLabel()
        {
            lbl_prbet_1.Text = "Second " + (udep == "pr" ? "PR" : "BET") + " Assigned";
            lbl_prbet_2.Text = (udep == "pr" ? "BT" : "PR") + " Name";
            lbl_prbet_3.Text = "Action By " + (udep == "pr" ? "BT" : "PR") + " Supervisor";
            lbl_prbet_4.Text = (udep == "pr" ? "BT" : "PR") + " Comment";
        }
        /// <summary>
        /// Setting the combobox datasource
        /// </summary>
        private void SetCboDataSource()
        {
            DataTable dt = new DataTable();
            DataRowView rdv;
            DataView dv = new DataView();
            if(!IsViewOnly || IsAllowSave)
            {
                //---Client---
                dt = db.query("SELECT cl_id,client FROM dbo.tbl_client ORDER BY client");
                cbo_cl.DisplayMember = "client";
                cbo_cl.ValueMember = "cl_id";
                cbo_cl.DataSource = dt;

                //--PR/BET--
                string opsdep = (udep == "pr") ? "bt" : "pr";
                dt = new DataTable();
                dt = db.query("SELECT Id,UPPER(LEFT(username,1))+LOWER(SUBSTRING(username,2,LEN(username))) AS uname,department,position FROM dbo.UserData WHERE deactivated = 0 ORDER BY department,username");
                dt.Rows.Add(0, "None", "bt", "prod"); dt.Rows.Add(0, "None", "pr", "prod");
                dt.Rows.Add(0, "None", "st", "prod"); dt.Rows.Add(0, "None", "cc", "prod");
                dt.Rows.Add(0, "None", "bt", "sup"); dt.Rows.Add(0, "None", "pr", "sup");
                dt.Rows.Add(0, "None", "st", "sup"); dt.Rows.Add(0, "None", "cc", "sup");
                //---Second PR/BET Assigned---
                dv = new DataView(dt);
                dv.RowFilter = "department LIKE '" + udep + "'";
                //rdv = dv.AddNew();
                //rdv["Id"] = 0;
                //rdv["uname"] = "None";
                //rdv["department"] = udep;
                //rdv["position"] = "prod";
                //rdv.EndEdit();

                cbo_second_assigned.DisplayMember = "uname";
                cbo_second_assigned.ValueMember = "Id";
                cbo_second_assigned.DataSource = dv;
                cbo_second_assigned.SelectedValue = 0;
                //---Name---
                dv = new DataView(dt);
                dv.RowFilter = "department LIKE '" + opsdep + "'";

                cbo_name.DisplayMember = "uname";
                cbo_name.ValueMember = "Id";
                cbo_name.DataSource = dv;
                //---fixby---
                dv = new DataView(dt);
                dv.RowFilter = "department LIKE '" + udep + "'";

                cbo_fxby.DisplayMember = "uname";
                cbo_fxby.ValueMember = "Id";
                cbo_fxby.DataSource = dv;
                //---action by sup---
                dv = new DataView(dt);
                dv.RowFilter = "department LIKE '" + opsdep + "' AND position LIKE 'sup'";
                //rdv = dv.AddNew();
                //rdv["Id"] = 0;
                //rdv["uname"] = "None";
                //rdv["department"] = opsdep;
                //rdv["position"] = "sup";
                //rdv.EndEdit();

                cbo_actby.DisplayMember = "uname";
                cbo_actby.ValueMember = "Id";
                cbo_actby.DataSource = dv;
                cbo_actby.SelectedValue = 0;
            }
            //---Type---
            dt = new DataTable();
            dt.Columns.Add("text", typeof(string));
            dt.Columns.Add("value", typeof(string));

            dt.Rows.Add("All", "all");
            dt.Rows.Add("Insurance", "ins");
            dt.Rows.Add("Non-Insurance", "non");

            cbo_type.DisplayMember = "text";
            cbo_type.ValueMember = "value";
            cbo_type.DataSource = dt;
            //---Department---
            dt = new DataTable();
            dt.Columns.Add("text", typeof(string));
            dt.Columns.Add("value", typeof(string));

            dt.Rows.Add("All", "all");
            dt.Rows.Add("Business Transcriber", "bt");
            dt.Rows.Add("Proofreader", "pr");
            dt.Rows.Add("BET", "bet");

            cbo_dep.DisplayMember = "text";
            cbo_dep.ValueMember = "value";
            cbo_dep.DataSource = dt;
        }
        /// <summary>
        /// This void will reset the return form back to default
        /// </summary>
        private void ResetForm()
        {
            cbo_actby.SelectedValue = 0;
            cbo_second_assigned.SelectedValue = 0;
            cbo_cl.SelectedIndex = 1;
            cbo_fxby.SelectedIndex = 1;
            cbo_name.SelectedIndex = 1;

            txt_ac.Text = "";
            txt_sp.Text = "";
            txt_fn.Text = "";

            rtxt_com1.Text = "";
            rtxt_com2.Text = "";
            rtxt_com3.Text = "";
        }
        /// <summary>
        /// Load data to the datagridview
        /// </summary>
        private async void LoadReturn()
        {
            _cnl = new CancellationTokenSource();
            CancellationToken token = _cnl.Token;

            db.SQLDependency(false);
            Cursor = Cursors.AppStarting;
            tss_status.Text = "Initializing...";
            string SelDT = dtpicker.Value.Date.ToString("MM/dd/yyyy"), tssStr = "";
            Progress<string> progressHandler = new Progress<string>(val => { tss_status.Text = val; });

            IProgress<string> progress = (IProgress<string>)progressHandler;
            try
            {
                await Task.Run(() =>
                {
                    string opsdep = (udep == "pr") ? "BT" : "PR";
                    string curdep = udep;
                    if (IsAllowView) { opsdep = "BT/PR"; curdep = "PR/BET"; }
                    string[] PosArr = new string[] { "sup", "tl", "auditor" };
                    List<string> qrywhere = new List<string>();
                    string q = (udep == "bt") ? "btpr_id = " + uid : "(user_id = " + uid + " OR " + "btpr_id = " + uid + ")";

                    if(AllowDep.Length > 0 && IsAllowView)
                    {
                        qrywhere.Add("dep IN ('" + string.Join("','", AllowDep) + "')");
                    }
                    progress.Report("Fetching Data...");
                    string qryStr = "SELECT fid,user_id,user2_id,btpr_id,fixer_id,act_id,[filename],dep,seen," +/*8*/
                        "CONVERT(varchar(15),CAST(dt_created AS date),100)," +/*9*/
                        "cl_id,(SELECT client FROM dbo.tbl_client WHERE cl_id = a.cl_id) AS cl," +/*11*/
                        "(SELECT ctype FROM dbo.tbl_client WHERE cl_id = a.cl_id) AS cltype," +/*12*/
                        "(SELECT username FROM dbo.UserData WHERE Id = user_id) AS uname, " +/*13*/
                        "(SELECT username FROM dbo.UserData WHERE Id = a.user2_id) AS uname2," +/*14*/
                        "(SELECT username FROM dbo.UserData WHERE Id = a.btpr_id) AS btprname," +/*15*/
                        "(SELECT username FROM dbo.UserData WHERE Id = a.fixer_id) AS fixername," +/*16*/
                        "(SELECT username FROM dbo.UserData WHERE Id = a.act_id) AS actname," +/*17*/
                        "others " +/*18*/
                        "FROM dbo.tbl_flag_return AS a WHERE CONVERT(date,dt_created) LIKE CONVERT(date,'" + SelDT + "') AND type LIKE 'return' " +
                        " AND ("+ q + " OR " + string.Join(" AND ", qrywhere.ToArray()) + ")" +
                        "ORDER BY Convert(varchar(30), dt_created, 101) DESC";
                    DataTable dt = new DataTable();
                    try
                    {
                        dt = db.query(qryStr);
                        token.ThrowIfCancellationRequested();
                    }
                    catch (Exception)
                    {
                        ErrorQuery = qryStr;
                        throw;
                    }

                    DataTable newdt = new DataTable();

                    List<CustomClass.GridHeaders> header = new List<CustomClass.GridHeaders>()
                    {
                        new CustomClass.GridHeaders{ index = 0, text = "Seen/Unseen", type = typeof(string), width = 50},
                        new CustomClass.GridHeaders{ index = 1, text = "Date Submitted", type = typeof(string), width = 50},
                        new CustomClass.GridHeaders{ index = 2, text = (!new string[] { "pr","bet"}.Contains(udep)?"BT":opsdep)+" Name", type = typeof(string),visible = false},
                        new CustomClass.GridHeaders{ index = 3, text = (!new string[] { "pr","bet"}.Contains(udep)?"PR":curdep.ToUpper())+" Name", type = typeof(string), width = 50},
                        new CustomClass.GridHeaders{ index = 4, text = "File Fixed By", type = typeof(string), width = 50},
                        new CustomClass.GridHeaders{ index = 5, text = (!new string[] { "pr","bet"}.Contains(udep)?"PR":curdep.ToUpper())+" Name 2", type = typeof(string), width = 50},
                        new CustomClass.GridHeaders{ index = 6, text = "Account", type = typeof(string), width = 80},
                        new CustomClass.GridHeaders{ index = 7, text = "Filename", type = typeof(string), width = 200},
                        new CustomClass.GridHeaders{ index = 8, text = "Accuracy", type = typeof(string), width = 50},
                        new CustomClass.GridHeaders{ index = 9, text = "Specs", type = typeof(string), width = 150},
                        new CustomClass.GridHeaders{ index = 10, text = (!new string[] { "pr","bet"}.Contains(udep)?"BT":opsdep)+" Comment", type = typeof(string), width = 150},
                        new CustomClass.GridHeaders{ index = 11, text = "Action By "+(!new string[] { "pr","bet"}.Contains(udep)?"BT":opsdep)+" Sup", type = typeof(string), width = 50},
                        new CustomClass.GridHeaders{ index = 12, text = "Side-by-side Feedback", type = typeof(string), width = 150},
                        new CustomClass.GridHeaders{ index = 13, text = "Comment", type = typeof(string), width = 150},
                        new CustomClass.GridHeaders{ index = 14, text = "fid", type = typeof(int), width = 50, visible = false},
                        new CustomClass.GridHeaders{ index = 15, text = "cltype", type = typeof(string), width = 50, visible = false},
                        new CustomClass.GridHeaders{ index = 16, text = "dep", type = typeof(string), width = 50, visible = false}
                    };
                    foreach (var itm in header)
                    {
                        newdt.Columns.Add(itm.text, itm.type);
                    }
                    int x = 1, cnt = dt.Rows.Count;
                    foreach (DataRow row in dt.Rows)
                    {
                        token.ThrowIfCancellationRequested();
                        progress.Report(x + " of " + cnt);
                        object[] obj = row.ItemArray;
                        ReturnFile rfobj = JsonConvert.DeserializeObject<ReturnFile>(obj[18].ToString());

                        string ac = rfobj.accuracy, sp = rfobj.specs, com1 = rfobj.btpr_comment, com2 = rfobj.side_comment,
                            com3 = rfobj.comment, seen = (int.Parse(obj[8].ToString()) == 0) ? "Unseen" : "Seen";

                        newdt.Rows.Add(seen, obj[9], obj[15], obj[13], obj[16], obj[14], obj[11], obj[6], ac, sp, com1, obj[17], com2, com3, obj[0], obj[12], obj[7]);
                        x++;
                    }
                    progress.Report("Finalizing...");
                    headers = header;
                    nDataTable = new DataTable();
                    nDataTable = newdt;
                });
                dgv_return.DataSource = nDataTable;
                foreach (var itm in headers)
                {
                    dgv_return.Columns[itm.index].Visible = itm.visible;
                    dgv_return.Columns[itm.index].Width = itm.width;
                }
                cf.RowsNumber(dgv_return);
                //Add filter void here
                tssStr = "Ready!";
                FilterData();
            }
            catch (Exception ex)
            {
                tssStr = "Error Encountered!";
                cf.WriteToFile("{0}==>" + ex.ToString() + "\n\n" + ErrorQuery, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\err.txt");
                MessageBox.Show(this, "Exception:\n" + ex.Message, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ErrorQuery = "";
            tss_status.Text = tssStr;
            Cursor = Cursors.Default;
        }
        /// <summary>
        /// Enable/Disable form
        /// </summary>
        /// <param name="b"></param>
        private void DisableForm(bool b = true)
        {
            gb_filter_export_container.Enabled = b;
            gb_form_container.Enabled = b;
            dgv_return.Enabled = b;
        }
        /// <summary>
        /// Filter Data
        /// </summary>
        private void FilterData()
        {
            string type = cbo_type.SelectedValue.ToString(),
                dep = cbo_dep.SelectedValue.ToString();

            List<string> filter = new List<string>();
            if (type != "all")
            {
                filter.Add("cltype LIKE '" + type + "'");
            }
            if (dep != "all")
            {
                filter.Add("dep LIKE '" + dep + "'");
            }

            (dgv_return.DataSource as DataTable).DefaultView.RowFilter = (filter.Count == 0) ? "" : string.Join(" AND ", filter.ToArray());
            cf.RowsNumber(dgv_return);
        }
        /// <summary>
        /// This will put some restrictions on the form like disabling buttons for specific restrictions
        /// </summary>
        private void Restrictions()
        {
            FileReturn rf = new FileReturn();
            if (!cf.IsStringEmpty(UserRestriction))
            {
                try
                {
                    UserRestrictionsClass urc = JsonConvert.DeserializeObject<UserRestrictionsClass>(UserRestriction);
                    rf = urc.FileReturn;
                }
                catch (Exception ex)
                {
                    cf.Debug(ex, true, "Something is wrong with the current restrictions.\nRestrictions will revert to default.");
                }
            }
            
            IsAllowSave = (IsViewOnly) ? false : rf.AllowSave;
            gb_form_container.Visible = (IsViewOnly)?false:IsAllowSave;
            btn_export.Visible = (IsViewOnly) ? false : rf.AllowExport;
            btn_seen.Visible = (IsViewOnly) ? false : rf.AllowChangeSeen;
            btn_unseen.Visible = (IsViewOnly) ? false : rf.AllowChangeSeen;
            btn_del.Visible = (IsViewOnly) ? false : rf.AllowDelete;
            IsAllowView = rf.AllowViewReturn;
            AllowDep = rf.RestrictedDepartment;

            if (!IsViewOnly || IsAllowSave)
            {
                SetPRBETLabel();
            }
            SetCboDataSource();
        }
        #endregion

        #region Functions
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
                cf.Debug(ex, true,"", "\n\n" + qry);
            }
            return id;
        }
        #endregion
    }
}
