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

namespace markform
{
    public partial class frm_flagging : Form
    {
        CustomClass cf = new CustomClass();
        markDBOClass.SQLClass db = new markDBOClass.SQLClass();
        private CancellationTokenSource _cts;
        private int uid, ulvl;
        private string uname, udep, upos, ErrorQry = "";

        /// <summary>
        /// <paramref name="args"/> should contain an array of Array(user id, username, user position, user department, user level)
        /// </summary>
        /// <param name="args"></param>
        public frm_flagging(string[] args = null)
        {
            InitializeComponent();
            if(args != null)
            {
                this.Tag = "flag";

                this.uid = int.Parse(args[0].ToString());
                this.uname = args[1].ToString();
                this.upos = args[2].ToString();
                this.udep = args[3].ToString();
                this.ulvl = int.Parse(args[4].ToString());

                strip_info.Items.Add("User ID: " + this.uid);
                strip_info.Items.Add("User Name: " + this.uname.ToUpper());
                strip_info.Items.Add("User Position: " + cf.GetPositionFull(this.upos).ToUpper());
                strip_info.Items.Add("User Department: " + this.udep.ToUpper());
                strip_info.Items.Add("User Level: " + this.ulvl);

                foreach (ToolStripStatusLabel itm in strip_info.Items)
                {
                    itm.BorderSides = ToolStripStatusLabelBorderSides.All;
                    itm.BorderStyle = Border3DStyle.Sunken;
                }
                this.SetCboDataSource();
                this.LoadData();
                cbo_type.SelectedIndexChanged += new EventHandler(Cbo_SeletedItemChanged);
                cbo_dep.SelectedIndexChanged += new EventHandler(Cbo_SeletedItemChanged);
            }
        }
        /// <summary>
        /// Populating data to the comboboxes
        /// </summary>
        private void SetCboDataSource()
        {
            DataTable dt = new DataTable();
            //---type---
            dt.Columns.Add("text", typeof(string));
            dt.Columns.Add("value", typeof(string));

            dt.Rows.Add("All", "all");
            dt.Rows.Add("Insurance", "ins");
            dt.Rows.Add("Non-Insurance", "non");

            cbo_type.DisplayMember = "text";
            cbo_type.ValueMember = "value";
            cbo_type.DataSource = dt;

            //---dep---
            dt = new DataTable();
            dt.Columns.Add("text", typeof(string));
            dt.Columns.Add("value", typeof(string));

            dt.Rows.Add("All", "all");
            dt.Rows.Add("Business Transcirber", "bt");
            dt.Rows.Add("Proofreader", "pr");
            dt.Rows.Add("BET", "bet");

            cbo_dep.DisplayMember = "text";
            cbo_dep.ValueMember = "value";
            cbo_dep.DataSource = dt;

            //---client---
            dt = new DataTable();
            dt = db.query("SELECT cl_id,client FROM dbo.tbl_client ORDER BY client");
            cbo_client.DisplayMember = "client";
            cbo_client.ValueMember = "cl_id";
            cbo_client.DataSource = dt;
        }
        /// <summary>
        /// Population the datagridview
        /// </summary>
        private async void LoadData()
        {
            _cts = new CancellationTokenSource(); CancellationToken token = _cts.Token;

            db.SQLDependency(false);
            this.Cursor = Cursors.AppStarting;
            DataTable newdt = new DataTable();
            string SelDT = dtpicker.Value.Date.ToString("MM/dd/yyyy"),tssStr = "";
            tss_status.Text = "Initializing...";
            List<string> qryWhere = new List<string>();
            if(upos == "prod")
            {
                qryWhere.Add("user_id = " + uid);
            }
            qryWhere.Add("type LIKE 'flag' AND CONVERT(date,dt_created) LIKE CONVERT(date,'" +SelDT+ "')");
            List<CustomClass.GridHeaders> header = new List<CustomClass.GridHeaders>()
            {
                new CustomClass.GridHeaders{index = 0, text = "Seen/Unseen", type = typeof(string), width = 50},
                new CustomClass.GridHeaders{index = 1, text = "Date Submitted", type = typeof(string), width = 60},
                new CustomClass.GridHeaders{index = 2, text = "Username", type = typeof(string), width = 50},
                new CustomClass.GridHeaders{index = 3, text = "Client", type = typeof(string), width = 80},
                new CustomClass.GridHeaders{index = 4, text = "Type", type = typeof(string), width = 80},
                new CustomClass.GridHeaders{index = 5, text = "Filename", type = typeof(string), width = 300},
                new CustomClass.GridHeaders{index = 6, text = "Problem", type = typeof(string), width = 200},
                new CustomClass.GridHeaders{index = 7, text = "fid", type = typeof(int), visible = false},
                new CustomClass.GridHeaders{index = 8, text = "dep", type = typeof(string), visible = false},
                new CustomClass.GridHeaders{index = 9, text = "cltype", type = typeof(string), visible = false}
            };
            foreach(var itm in header)
            {
                newdt.Columns.Add(itm.text, itm.type);
            }
            Progress<string> progressHandler = new Progress<string>(val => { tss_status.Text = val; });
            IProgress<string> progress = (IProgress<string>)progressHandler;

            try
            {
                await Task.Run(()=> {
                    string qry = "SELECT fid,user_id,dep,filename,problem,seen," +
                    "CONVERT(varchar(15),CAST(dt_created AS time),100)," +
                    "(SELECT client FROM dbo.tbl_client WHERE cl_id = a.cl_id) AS cl," +
                    "(SELECT ctype FROM dbo.tbl_client WHERE cl_id = a.cl_id) AS cltype," +
                    "(SELECT username FROM dbo.UserData WHERE Id = user_id) AS uname FROM dbo.tbl_flag_return AS a " +
                    "WHERE " +string.Join(" AND ", qryWhere.ToArray()) + " ORDER BY Convert(varchar(30), dt_created, 101) DESC";
                    DataTable dataTable = new DataTable();
                    try
                    {
                        dataTable = db.query(qry);
                        token.ThrowIfCancellationRequested();
                    }
                    catch (Exception)
                    {
                        ErrorQry = qry;
                        throw;
                    }
                    
                    int x = 0, cnt = dataTable.Rows.Count;
                    foreach(DataRow row in dataTable.Rows)
                    {
                        token.ThrowIfCancellationRequested();
                        progress.Report("Fetching flags: " + x + " of " + cnt);
                        object[] obj = row.ItemArray;
                        string seen = (int.Parse(obj[5].ToString()) == 0) ? "Unseen" : "Seen",
                        ins = (obj[8].ToString() == "non")?"Non-Insurance":"Insurance";
                        newdt.Rows.Add(seen, obj[6], obj[9], obj[7], ins, obj[3], obj[4], obj[0], obj[2], obj[8]);
                        x++;
                    }
                });
                dgv_flag.DataSource = newdt;
                foreach(var itm in header)
                {
                    dgv_flag.Columns[itm.index].Visible = itm.visible;
                    dgv_flag.Columns[itm.index].Width = itm.width;
                }
                cf.RowsNumber(dgv_flag);
                tssStr = "Ready!";
                this.FilterData();
            }
            catch (Exception ex)
            {
                tssStr = "Error Encountered!";
                cf.WriteToFile("{0}==>" + ex.ToString() + "\n\n" + ErrorQry, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\err.txt");
                MessageBox.Show(this, "Exception:\n" + ex.Message, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tss_status.Text = tssStr;
            this.Cursor = Cursors.Default;
        }
        /// <summary>
        /// Call FilterData() when type or dep combobox selection is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cbo_SeletedItemChanged(object sender, EventArgs e)
        {
            this.FilterData();
        }
        /// <summary>
        /// Call LoadData() when date is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpicker_ValueChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }
        /// <summary>
        /// Filter data
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
            Console.Write(string.Join(" AND ", filter.ToArray()));
            (dgv_flag.DataSource as DataTable).DefaultView.RowFilter = (filter.Count == 0) ? "" : string.Join(" AND ", filter.ToArray());
            cf.RowsNumber(dgv_flag);
        }
        /// <summary>
        /// Reinitialize row number when sorting to be always from 1 to n
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_flag_Sorted(object sender, EventArgs e)
        {
            cf.RowsNumber(dgv_flag);
        }
        /// <summary>
        /// This will call the LoadData();
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reload_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
        /// <summary>
        /// Opens the export form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_export_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;

            frm_export frmex = new frm_export(new string[] { this.uid.ToString(), this.uname, this.upos, this.udep }, "flag");
            frmex.ShowDialog(this);

            this.Cursor = Cursors.Default;
        }
        /// <summary>
        /// Saving flag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            int clid = int.Parse(cbo_client.SelectedValue.ToString());
            string filename = txt_filename.Text, probs = rtxt_problem.Text, tssStr="";
            tss_status.Text = "Preparing...";
            List<string> msg = new List<string>();
            if (cf.IsStringEmpty(filename))
            {
                msg.Add("-Filename field is empty.");
            }
            if (cf.IsStringEmpty(probs))
            {
                msg.Add("Problem field is empty.");
            }

            if(msg.Count > 0)
            {
                MessageBox.Show(this, String.Join("\n", msg.ToArray()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show(this, "You are about to send a flag.", "Confirm Flagging", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string qry = "INSERT INTO dbo.tbl_flag_return(user_id,cl_id,filename,problem,dep,type,dt_created) VALUES(@user_id, @cl_id, @filename, @problem, @dep, @type, @dt_created)";
                    int qryR = 0;
                    try
                    {
                        qryR = db.nQuery(qry,
                            new string[] { "user_id", uid.ToString(), "cl_id", clid.ToString(), "filename", filename, "problem", probs, "dep", udep, "type", "flag", "dt_created", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") });
                        tssStr = "Done!";
                        MessageBox.Show(this, "Success", "Success!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        ResetForm();
                        this.LoadData();
                    }
                    catch (Exception ex)
                    {
                        tssStr = "Error Encountered!";
                        cf.WriteToFile("{0}==>" + ex.ToString() + "\n\n" + qry, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\err.txt");
                        MessageBox.Show(this, "Exception:\n" + ex.Message, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void frm_flagging_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cts != null) { _cts.Cancel(); }
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

            foreach (DataGridViewCell cell in dgv_flag.SelectedCells)
            {
                Ids.Add(int.Parse(dgv_flag[7,cell.RowIndex].Value.ToString()));
            }
            Ids = Ids.Distinct().ToList();
            if (Ids.Count == 0)
            {
                MessageBox.Show(this, "No item selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string ws = (Ids.Count > 1) ? "s" : "";
                msgContent = (btn.Text.ToLower() == "delete") ?
                    "You are about to delete " + Ids.Count + " selected item" + ws + "." :
                    "You are about to " + btn.Text.ToLower() + " " + Ids.Count + " selected item" + ws + ".";
                msgTitle = "Confirm " + (btn.Text.ToLower() == "delete" ? "Delete" : "Update");

                DialogResult dr = MessageBox.Show(this, msgContent, msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    this.Cursor = Cursors.AppStarting;
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
                    this.Cursor = Cursors.Default;
                    this.LoadData();
                }
            }

        }
        /// <summary>
        /// Enable/Disable form after a certain action
        /// </summary>
        /// <param name="b"></param>
        private void DisableForm(bool b = true)
        {
            gb_filter_export_container.Enabled = b;
            gb_flagform_container.Enabled = b;
            dgv_flag.Enabled = b;
        }
        /// <summary>
        /// Reset form to default after saving
        /// </summary>
        private void ResetForm()
        {
            cbo_client.SelectedIndex = 0;
            cbo_client.Select();
            txt_filename.Text = "";
            rtxt_problem.Text = "";
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
    }
}
