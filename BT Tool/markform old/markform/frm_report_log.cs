using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;

namespace markform
{
    public partial class frm_report_log : Form
    {
        CustomClass cf = new CustomClass();
        markform.frm_sub_report_log frm = new frm_sub_report_log();
        markDBOClass.SQLClass db_break = new markDBOClass.SQLClass();
        markDBOClass.SQLClass db_notif = new markDBOClass.SQLClass();
        private string CurSelUser = "";
        public frm_report_log()
        {
            InitializeComponent();
            this.Tag = "report";
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width), (Screen.PrimaryScreen.WorkingArea.Height - this.Height));
            DisplayData("break");
            DisplayData("idle");
            Notif("break"); Notif("idle");
        }

        /// <summary>
        /// Notification receiver for break
        /// </summary>
        void OnNewMessage_break()
        {
            ISynchronizeInvoke i = (ISynchronizeInvoke)this;
            if (i.InvokeRequired)
            {
                markDBOClass.SQLClass.NewMessage tempDelegate = new markDBOClass.SQLClass.NewMessage(OnNewMessage_break);
                i.BeginInvoke(tempDelegate, null);
                return;
            }
            db_break.OnNewMessage -= OnNewMessage_break;
            DisplayData("break");
            Notif("break");
        }
        /// <summary>
        /// Notification receiver for idle
        /// </summary>
        void OnNewMessage_idle()
        {
            ISynchronizeInvoke i = (ISynchronizeInvoke)this;
            if (i.InvokeRequired)
            {
                markDBOClass.SQLClass.NewMessage tempDelegate = new markDBOClass.SQLClass.NewMessage(OnNewMessage_idle);
                i.BeginInvoke(tempDelegate, null);
                return;
            }
            db_notif.OnNewMessage -= OnNewMessage_idle;
            DisplayData("idle");
            Notif("idle");
        }
        /// <summary>
        /// Resetting the receiver 
        /// </summary>
        /// <param name="type">break or idle</param>
        private void Notif(string type)
        {
            //string curdt = DateTime.Now.ToString("MM/dd/yyyy");
            db_break.SQLDependency(true);
            string qry = (type == "break")? "SELECT bid,uid,bstart,bend FROM dbo.tbl_break":
                "SELECT Id,uid,time,date FROM dbo.tbl_idle";
            markDBOClass.SQLClass db = (type == "break") ? db_break : db_notif;
            if(type == "break")
            {
                db.OnNewMessage += new markDBOClass.SQLClass.NewMessage(OnNewMessage_break);
            }
            else
            {
                db.OnNewMessage += new markDBOClass.SQLClass.NewMessage(OnNewMessage_idle);
            }
            db.query(qry);
        }
        /// <summary>
        /// Loading data
        /// </summary>
        /// <param name="type"></param>
        private void DisplayData(string type)
        {
            this.Cursor = Cursors.AppStarting;

            tss_status.Text = "Fetching Data...";
            markDBOClass.SQLClass db = (type == "break") ? db_break : db_notif;
            db.SQLDependency(false);
            List<CustomClass.GridHeaders> header = new List<CustomClass.GridHeaders>();
            header = (type == "idle") ? new List<CustomClass.GridHeaders>()
            {
                new CustomClass.GridHeaders{index = 0, text = "Username", type = typeof(string)},
                new CustomClass.GridHeaders{index = 1, text = "Idle Time", type = typeof(string)}
            } : new List<CustomClass.GridHeaders>()
            {
                new CustomClass.GridHeaders{index = 0, text = "Username", type = typeof(string)},
                new CustomClass.GridHeaders{index = 1, text = "Duration", type = typeof(string)},
                new CustomClass.GridHeaders{index = 2, text = "logdata", type = typeof(string), visible = false},
                new CustomClass.GridHeaders{index = 3, text = "Status", type = typeof(string)}
            };
            string curdt = DateTime.Now.ToString("MM/dd/yyyy"),tssStr = "";
            DataGridView dgv = (type == "break")?dgv_break:dgv_notif;
            string qry = (type == "break") ?
                "SELECT bid,UPPER(LEFT(username,1))+LOWER(SUBSTRING(username,2,LEN(username)))," +
                "ISNULL((SELECT sFile FROM dbo.Main WHERE Id = fid),'None')," +
                "DATEDIFF(ss, CONVERT(datetime, bstart), CONVERT(datetime, CASE bend WHEN 'pending' THEN GETDATE() ELSE bend END)) AS tbhsec," +
                "bstart, bend, uid FROM dbo.tbl_break AS a LEFT JOIN dbo.UserData AS b ON a.uid = b.Id " +
                "WHERE CONVERT(date, [bstart]) LIKE CONVERT(date,'" + curdt + "') " +
                "ORDER BY username,Convert(varchar(30), bstart, 101) DESC":
                "SELECT a.Id,UPPER(LEFT(username,1))+LOWER(SUBSTRING(username,2,LEN(username))),time,[date],uid " +
                "FROM dbo.tbl_idle AS a LEFT JOIN dbo.UserData AS b ON a.uid = b.Id " +
                "WHERE CONVERT(date, [itime]) LIKE CONVERT(date,'" +curdt+ "') " +
                "ORDER BY username,Convert(varchar(30), itime, 101) DESC";

            DataTable newdt = new DataTable();
            foreach(var itm in header)
            {
                newdt.Columns.Add(itm.text, itm.type);
            }

            DataTable dt = new DataTable();
            try
            {
                dt = db.query(qry);
                List<BreakLogData> tempBreakLst = new List<BreakLogData>();
                int tempUid = 0, CurRow = 0;
                double tempDur = 0;
                string BreakOngoing = "";

                foreach (DataRow row in dt.Rows)
                {
                    object[] obj = row.ItemArray;

                    if (type == "idle")
                    {
                        newdt.Rows.Add(obj[1], obj[2]);
                    }
                    else
                    {
                        int uid = int.Parse(obj[6].ToString()), nxtUid = 0;
                        object[] nxtObj;
                        try
                        {
                            nxtObj = dt.Rows[CurRow + 1].ItemArray;
                            nxtUid = int.Parse(nxtObj[6].ToString());
                        }
                        catch (Exception)
                        {
                            nxtUid = 0;
                        }

                        double tbhsec = double.Parse(obj[3].ToString());
                        string tbh = cf.SecondsToTime24(tbhsec);
                        BreakLogData bld = new BreakLogData()
                        {
                            filename = obj[2].ToString(),
                            bstart = obj[4].ToString(),
                            bend = obj[5].ToString(),
                            duration = tbh
                        };
                        tempBreakLst.Add(bld);
                        tempDur = tempDur + tbhsec;
                        if (obj[5].ToString() == "pending") { BreakOngoing = "On Break"; }
                        if (uid != nxtUid)
                        {
                            string bld_output = JsonConvert.SerializeObject(tempBreakLst);

                            newdt.Rows.Add(obj[1], cf.SecondsToTime24(tempDur), bld_output, BreakOngoing);
                            if(this.CurSelUser.ToLower() == obj[1].ToString().ToLower())
                            {
                                frm.DisplayData(bld_output, this.CurSelUser);
                                frm.SetLocation(this.Width);
                            }
                            tempUid = uid; tempDur = 0; tempBreakLst = new List<BreakLogData>(); BreakOngoing = "";
                        }
                    }
                    CurRow++;
                }
            }
            catch (Exception ex)
            {
                tssStr = "Error Encountered!";
                cf.WriteToFile("{0}==>" + ex.ToString() + "\n\n" + qry, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\err.txt");
                MessageBox.Show(this, "Exception:\n" + ex.Message, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tssStr = "Done!";
            dgv.DataSource = newdt;
            foreach (var itm in header)
            {
                dgv.Columns[itm.index].Visible = itm.visible;
            }
            //db.CloseConnection();
            
            tss_status.Text = tssStr;
            this.Cursor = Cursors.Default;
        }
        /// <summary>
        /// Reinitializing the row number to be always increment starting from 1 to n when sorting the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_tracker_Sorted(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            cf.RowsNumber(dgv);
        }
        /// <summary>
        /// Reinitialize the row number to be always increment from 1 to n when tab is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tab_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.Write(tab_main.SelectedTab.Name);
        }

        private void dgv_break_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                string breakdata = dgv_break[2, e.RowIndex].Value.ToString(),
                    name = dgv_break[0, e.RowIndex].Value.ToString();
                this.CurSelUser = name;
                frm.DisplayData(breakdata, name);
                frm.SetLocation(this.Width);
                if (!cf.IsFormOpen("frm_sub_report_log", true, "breaklog"))
                {
                    try
                    {
                        frm.Show(this);
                    }
                    catch (Exception)
                    {
                        frm = new frm_sub_report_log();
                        frm.DisplayData(breakdata, name);
                        frm.SetLocation(this.Width);
                        frm.Show(this);
                    }

                }
                else
                {
                    cf.GetForm.Activate();
                }
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayData("break");
            DisplayData("idle");
        }
    }
}
