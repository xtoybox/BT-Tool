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
    public partial class frm_flagging : Form
    {
        #region Initialize Classes
        CustomClass cf = new CustomClass();
        SQLClass db = new SQLClass();
        #endregion

        #region Setting Variables
        private int uid, ulvl;
        private string uname, udep, upos, ErrorQry = "";
        private CancellationTokenSource _cnl;
        private string CurrentRestriction = "";
        /// <summary>
        /// Allowing user to view other flags aside from the current user's flag.
        /// If allow then it will base on <seealso cref="AlloDep"/>.
        /// </summary>
        private bool IsAllowFlagView = false;
        private string[] AlloDep = new string[] { };
        /// <summary>
        /// Allowing user to delete oher flags beside current user flag.
        /// </summary>
        private bool IsAllowDeleteOther = false;
        #endregion

        #region Form Class Initialization
        /// <summary>
        /// <paramref name="args"/> should contain an array of Array(user id, username, user position, user department, user level,restriction)
        /// </summary>
        /// <param name="args"></param>
        public frm_flagging(string[] args = null)
        {
            InitializeComponent();
            if (args != null)
            {
                db.LogExceptions = true;//allow to write a log if an SQL error occured.
                this.Tag = "flag";

                uid = int.Parse(args[0].ToString());
                uname = args[1].ToString();
                upos = args[2].ToString();
                udep = args[3].ToString();
                ulvl = int.Parse(args[4].ToString());
                CurrentRestriction = args[5].ToString();

                strip_info.Items.Add("User ID: " + this.uid);
                strip_info.Items.Add("User Name: " + this.uname.ToUpper());
                strip_info.Items.Add("User Position: " + cf.GetPositionFull(this.upos).ToUpper());
                strip_info.Items.Add("User Department: " + this.udep.ToUpper());
                strip_info.Items.Add("User Level: " + this.ulvl);

                foreach (ToolStripStatusLabel itm in strip_info.Items)
                {
                    itm.BorderSides = ToolStripStatusLabelBorderSides.Right;
                    itm.BorderStyle = Border3DStyle.Flat;
                    itm.ForeColor = Color.White;
                }
                SetRestrictions();
                SetCboDataSource();
                LoadData();
                cbo_type.SelectedIndexChanged += new EventHandler(Cbo_SeletedItemChanged);
                cbo_dep.SelectedIndexChanged += new EventHandler(Cbo_SeletedItemChanged);
            }
        }
        #endregion

        #region Events
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
            string filename = txt_filename.Text, probs = rtxt_problem.Text, tssStr = "";
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

            if (msg.Count > 0)
            {
                MessageBox.Show(this, String.Join("\n", msg.ToArray()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show(this, "You are about to send a flag.", "Confirm Flagging", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    DisableForm(false);Cursor = Cursors.AppStarting;
                    string qry = "INSERT INTO dbo.tbl_flag_return(user_id,cl_id,filename,problem,dep,type,dt_created) VALUES(@user_id, @cl_id, @filename, @problem, @dep, @type, @dt_created)";
                    int qryR = 0;
                    try
                    {
                        qryR = db.nQuery(qry,
                            new string[] { "user_id", uid.ToString(), "cl_id", clid.ToString(), "filename", filename, "problem", probs, "dep", udep, "type", "flag", "dt_created", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") });
                        tssStr = "Done!";
                        MessageBox.Show(this, "Success", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetForm();
                        this.LoadData();
                    }
                    catch (Exception ex)
                    {
                        tssStr = "Error Encountered!";
                        cf.WriteToFile("{0}==>" + ex.ToString() + "\n\n" + qry, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\err.txt");
                        MessageBox.Show(this, "Exception:\n" + ex.Message, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    DisableForm(); Cursor = Cursors.Default;
                }

            }
        }
        /// <summary>
        /// Event for seen/unseen and delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActionBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;//getting the button that is being click from the buttons that is currently bound by this function

            int qryResult = 0;
            string msgContent = "", msgTitle = "";
            List<int> Ids = new List<int>();
            //getting the flag ID from the selected items
            foreach (DataGridViewCell cell in dgv_flag.SelectedCells)
            {
                if (IsAllowDeleteOther)
                {
                    Ids.Add(int.Parse(dgv_flag[7, cell.RowIndex].Value.ToString()));
                }
                else
                {
                    //check if the flag userid [10] is the same as the current user ID
                    if((int)dgv_flag[10,cell.RowIndex].Value == uid) { Ids.Add(int.Parse(dgv_flag[7, cell.RowIndex].Value.ToString())); }
                }
            }
            Ids = Ids.Distinct().ToList();//remove duplicate
            if (Ids.Count == 0)
            {
                MessageBox.Show(this, "No item selected"+(IsAllowDeleteOther?"": "\n You don't have permission to delete other flag.\n Only your own flag is allowed to be deleted."), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string ws = (Ids.Count > 1) ? "s" : "";//adding 's' if the Flag ID is more than 1
                msgContent = (btn.Text.ToLower() == "delete") ?
                    "You are about to delete " + Ids.Count + " selected item" + ws + "."+
                    (IsAllowDeleteOther?"": "\n Only your own flag" + ws + " will be delete.") :
                    "You are about to " + btn.Text.ToLower() + " " + Ids.Count + " selected item" + ws + ".";
                msgTitle = "Confirm " + (btn.Text.ToLower() == "delete" ? "Delete" : "Update");

                DialogResult dr = MessageBox.Show(this, msgContent, msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    this.Cursor = Cursors.AppStarting;//change cursor to AppStarting to let the user know that the process running.
                    DisableForm(false);//disable some form controls while processing the action to prevent the user from making another action just in case the current process takes time to finish

                    string idjoin = string.Join(",", Ids.ToArray());
                    string qry = (btn.Text.ToLower() == "delete") ?
                        "DELETE FROM dbo.tbl_flag_return WHERE fid IN (" + idjoin + ")" :
                        "UPDATE dbo.tbl_flag_return SET seen = " + (btn.Text.ToLower() == "seen" ? 1 : 0) + " WHERE fid IN (" + idjoin + ")";
                    try
                    {
                        qryResult = db.nQuery(qry);
                        if (qryResult == 0)
                        {
                            MessageBox.Show(this, "Query failed.", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        cf.Debug(ex, true, "Something went wrong while trying to execute the query.\n\nQuery: "+qry);
                    }
                    
                    DisableForm();//enable form controls
                    this.Cursor = Cursors.Default;//change the cursor to default
                    LoadData();//refresh the datagridview list
                }
            }

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
        private void frm_flagging_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cnl != null) { _cnl.Cancel(); }
        }
        #endregion

        #region Void Methods
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

            if (AlloDep.Length > 1 || AlloDep.Length == 0){dt.Rows.Add("All", "all");}
            foreach(string dep in AlloDep)
            {
                string LongName = dep.ToUpper();
                switch (dep)
                {
                    case "bt":
                        LongName = "Business Transcirber";
                        break;
                    case "pr":
                        LongName = "Proofreader";
                        break;
                }
                dt.Rows.Add(LongName, dep);
            }
            //dt.Rows.Add("Business Transcirber", "bt");
            //dt.Rows.Add("Proofreader", "pr");
            //dt.Rows.Add("BET", "bet");

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
            _cnl = new CancellationTokenSource();
            CancellationToken token = _cnl.Token;

            db.SQLDependency(false);

            this.Cursor = Cursors.AppStarting;
            DataTable newdt = new DataTable();
            string SelDT = dtpicker.Value.Date.ToString("MM/dd/yyyy"), tssStr = "";
            tss_status.Text = "Initializing...";
            List<string> qryWhere = new List<string>();

            if (IsAllowFlagView)
            {
                qryWhere.Add((AlloDep.Length > 0? "dep IN ('" + string.Join("','", AlloDep) + "')": "user_id = " + uid));
            }
            else
            {
                qryWhere.Add("user_id = " + uid);
            }


            qryWhere.Add("type LIKE 'flag' AND CONVERT(date,dt_created) LIKE CONVERT(date,'" + SelDT + "')");
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
                new CustomClass.GridHeaders{index = 9, text = "cltype", type = typeof(string), visible = false},
                new CustomClass.GridHeaders{index = 10, text = "userid", type = typeof(int), visible = false}
            };
            foreach (var itm in header)
            {
                newdt.Columns.Add(itm.text, itm.type);
            }
            Progress<string> progressHandler = new Progress<string>(val => { tss_status.Text = val; });
            IProgress<string> progress = (IProgress<string>)progressHandler;

            try
            {
                await Task.Run(() => {
                    string qry = "SELECT fid,user_id,dep,filename,problem,seen," +
                    "CONVERT(varchar(15),CAST(dt_created AS time),100)," +
                    "(SELECT client FROM dbo.tbl_client WHERE cl_id = a.cl_id) AS cl," +
                    "(SELECT ctype FROM dbo.tbl_client WHERE cl_id = a.cl_id) AS cltype," +
                    "(SELECT username FROM dbo.UserData WHERE Id = user_id) AS uname FROM dbo.tbl_flag_return AS a " +
                    "WHERE " + string.Join(" AND ", qryWhere.ToArray()) + " ORDER BY Convert(varchar(30), dt_created, 101) DESC";
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
                    foreach (DataRow row in dataTable.Rows)
                    {
                        token.ThrowIfCancellationRequested();
                        progress.Report("Fetching flags: " + x + " of " + cnt);
                        object[] obj = row.ItemArray;
                        string seen = (int.Parse(obj[5].ToString()) == 0) ? "Unseen" : "Seen",
                        ins = (obj[8].ToString() == "non") ? "Non-Insurance" : "Insurance";
                        newdt.Rows.Add(seen, obj[6], obj[9], obj[7], ins, obj[3], obj[4], obj[0], obj[2], obj[8],int.Parse(obj[1].ToString()));
                        x++;
                    }
                });
                dgv_flag.DataSource = newdt;
                foreach (var itm in header)
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
            //Console.Write(string.Join(" AND ", filter.ToArray()));
            try
            {
                (dgv_flag.DataSource as DataTable).DefaultView.RowFilter = (filter.Count == 0) ? "" : string.Join(" AND ", filter.ToArray());
                cf.RowsNumber(dgv_flag);
            }
            catch (Exception ex)
            {
                cf.Debug(ex);
            }
            
        }
        /// <summary>
        /// Enable/Disable form after a certain action
        /// </summary>
        /// <param name="b"></param>
        private void DisableForm(bool b = true)
        {
            tlp_filter_export.Enabled = b;
            tlp_flag_form_container.Enabled = b;
            tlp_seen_unseen_container.Enabled = b;
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
        /// Setting the restriction for the current user
        /// </summary>
        private void SetRestrictions()
        {
            Flagging flag = new Flagging();
            if (!cf.IsStringEmpty(CurrentRestriction))
            {
                try
                {
                    UserRestrictionsClass urc = JsonConvert.DeserializeObject<UserRestrictionsClass>(CurrentRestriction);
                    flag = urc.Flagging;
                }
                catch (Exception ex)
                {
                    cf.Debug(ex,true,"Something is wrong with the current restrictions.\nRestrictions will revert to default.");
                }
                
            }
            IsAllowDeleteOther = flag.AllowDelete;
            btn_export.Enabled = flag.AllowExport;
            btn_save.Enabled = flag.AllowSave;
            btn_seen.Enabled = flag.AllowChangeSeen;
            btn_unseen.Enabled = flag.AllowChangeSeen;
            IsAllowFlagView = flag.AllowViewFlag;
            AlloDep = flag.RestrictedDepartment;
            cbo_dep.Enabled = IsAllowFlagView;
        }
        #endregion

        #region Functions

        #endregion
    }
}
