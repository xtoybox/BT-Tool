using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace markform
{
    public partial class frm_monitoring : Form
    {
        CustomClass cf = new CustomClass();
        markDBOClass.SQLClass db = new markDBOClass.SQLClass();
        frm_sub_monitoring frm = new frm_sub_monitoring();
        public frm_monitoring()
        {
            InitializeComponent();
            this.Tag = "monitor";
            LoadData();
            Notif();
        }

        /// <summary>
        /// Populating datagridview
        /// </summary>
        private void LoadData()
        {
            db.SQLDependency(false);
            this.Cursor = Cursors.AppStarting;
            string curdate = dtpicker.Value.Date.ToString("MM/dd/yyyy"), tssStr = "";//DateTime.Now.ToString("MM/dd/yyyy");
            tss_status.Text = "Fetching data...";
            
            List<CustomClass.GridHeaders> headers = new List<CustomClass.GridHeaders>()
            {
                new CustomClass.GridHeaders{index = 0, text = "Client", type = typeof(string), width = 100},
                new CustomClass.GridHeaders{index = 1, text = "BT Sched", type = typeof(string), width = 60, align = DataGridViewContentAlignment.MiddleCenter},
                new CustomClass.GridHeaders{index = 2, text = "PR Sched", type = typeof(string), width = 60, align = DataGridViewContentAlignment.MiddleCenter},
                new CustomClass.GridHeaders{index = 3, text = "CC Sched", type = typeof(string), width = 60, align = DataGridViewContentAlignment.MiddleCenter},
                new CustomClass.GridHeaders{index = 4, text = "S&T Sched", type = typeof(string), width = 60, align = DataGridViewContentAlignment.MiddleCenter},
                new CustomClass.GridHeaders{index = 5, text = "For BT", type = typeof(string), width = 60, align = DataGridViewContentAlignment.MiddleCenter},
                new CustomClass.GridHeaders{index = 6, text = "For PR", type = typeof(string), width = 60, align = DataGridViewContentAlignment.MiddleCenter},
                new CustomClass.GridHeaders{index = 7, text = "For CC", type = typeof(string), width = 60, align = DataGridViewContentAlignment.MiddleCenter},
                new CustomClass.GridHeaders{index = 8, text = "For S&T", type = typeof(string), width = 60, align = DataGridViewContentAlignment.MiddleCenter},
                new CustomClass.GridHeaders{index = 9, text = "For TS", type = typeof(string), width = 60, align = DataGridViewContentAlignment.MiddleCenter},
                new CustomClass.GridHeaders{index = 10, text = "For Audit", type = typeof(string), width = 60, align = DataGridViewContentAlignment.MiddleCenter},
                new CustomClass.GridHeaders{index = 11, text = "Ready", type = typeof(string), width = 60, align = DataGridViewContentAlignment.MiddleCenter},
                new CustomClass.GridHeaders{index = 12, text = "Done", type = typeof(string), width = 60, align = DataGridViewContentAlignment.MiddleCenter}
            };

            DataTable newdt = new DataTable();
            foreach(var itm in headers)
            {
                newdt.Columns.Add(itm.text, itm.type);
            }

            DataTable dt = new DataTable();//AND CONVERT(date, dateServ) LIKE CONVERT(date,'" +curdate+ "')
            string qry = "SELECT client AS Client," +
                "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'bt sched' AND client = a.client) AS [BT Sched]," +
                "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'pr sched' AND client = a.client) AS [PR Sched]," +
                "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'cc sched' AND client = a.client) AS [CC Sched]," +
                "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'st sched' AND client = a.client) AS [S & T Sched]," +
                "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'for bt' AND client = a.client) AS [For BT]," +
                "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'for pr' AND client = a.client) AS [For PR]," +
                "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'for cc' AND client = a.client) AS [For CC]," +
                "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'for st' AND client = a.client) AS [For S & T]," +
                "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'for ts' AND client = a.client) AS [For TS]," +
                "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'for audit' AND client = a.client) AS [For Audit]," +
                "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'ready' AND client = a.client) AS [Ready]," +
                "(SELECT COUNT(Id) FROM dbo.Main WHERE LOWER([status]) LIKE 'done' AND client = a.client) AS [Done] " +
                "FROM dbo.Main AS a WHERE LOWER([status]) NOT LIKE 'archive' GROUP BY client";
            try
            {
                dt = db.query(qry);
                foreach(DataRow row in dt.Rows)
                {
                    object[] obj = row.ItemArray;
                    newdt.Rows.Add(obj[0], obj[1], obj[2], obj[3], obj[4], obj[5], obj[6], obj[7], obj[8], obj[9],
                        obj[10], obj[11], obj[12]);
                }

                dgv_monitoring.DataSource = newdt;
                foreach(var itm in headers)
                {
                    dgv_monitoring.Columns[itm.index].Width = itm.width;
                    dgv_monitoring.Columns[itm.index].DefaultCellStyle.Alignment = itm.align;
                }
                cf.RowsNumber(dgv_monitoring);
            }
            catch (Exception ex)
            {
                tssStr = "Error Encountered!";
                cf.WriteToFile("{0}==>" + ex.ToString() + "\n\n" + qry, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\err.txt");
                MessageBox.Show(this, "Exception:\n" + ex.Message, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tss_status.Text = tssStr;
            this.Cursor = Cursors.Default;
        }

        void OnNewMessage()
        {
            ISynchronizeInvoke i = (ISynchronizeInvoke)this;
            if (i.InvokeRequired)
            {
                markDBOClass.SQLClass.NewMessage tempDelegate = new markDBOClass.SQLClass.NewMessage(OnNewMessage);
                i.BeginInvoke(tempDelegate, null);
                return;
            }
            db.OnNewMessage -= OnNewMessage;
            LoadData();
            Notif();
        }

        private void Notif()
        {
            string curdate = dtpicker.Value.Date.ToString("MM/dd/yyyy");//DateTime.Now.ToString("MM/dd/yyyy");
            db.SQLDependency(true);
            db.OnNewMessage += new markDBOClass.SQLClass.NewMessage(OnNewMessage);
            db.query("SELECT Id,status,dateServ FROM dbo.Main ");
        }

        private void dgv_monitoring_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                string curdate = dtpicker.Value.Date.ToString("MM/dd/yyyy");
                string clname = dgv_monitoring[0, e.RowIndex].Value.ToString();
                frm.SetSelectedTab(clname,(e.ColumnIndex - 1), curdate);
                if (!cf.IsFormOpen("frm_sub_monitoring", true, "monitoringlog"))
                {
                    try
                    {
                        frm.Show(this);
                    }
                    catch (Exception)
                    {
                        frm = new frm_sub_monitoring();
                        frm.SetSelectedTab(clname, (e.ColumnIndex - 1), curdate);
                        frm.Show(this);
                    }
                }
                else
                {
                    cf.GetForm.Activate();
                }
            }
        }

        private void dtpicker_ValueChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }
    }
}
