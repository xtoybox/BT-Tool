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
    public partial class frm_sub_monitoring : Form
    {
        CustomClass cf = new CustomClass();
        markDBOClass.SQLClass db = new markDBOClass.SQLClass();
        private DataGridView[] dgvarr;
        private string[] statArr;
        private string clientName = "";
        private string CurDt = "";
        public frm_sub_monitoring()
        {
            InitializeComponent();
            this.Tag = "monitoringlog";
            dgvarr = new DataGridView[] {dgv_btsched, dgv_prsched, dgv_ccsched, dgv_stsched, dgv_forbt,
            dgv_forpr, dgv_forcc, dgv_forst, dgv_forts, dgv_foraudit, dgv_ready, dgv_done};
            statArr = new string[] {"bt sched", "pr sched", "cc sched", "st sched", "for bt", "for pr", "for cc",
                "for st", "for ts","for audit", "ready", "done"};

        }
        public void SetSelectedTab(string clientname, int TabIndex, string dt)
        {
            this.tabctrl.SelectedIndex = TabIndex;
            this.CurDt = dt;
            clientName = clientname;
            this.Text = "Monitoring - " + clientname;
            LoadData();
            Notif();
        }
        private void LoadData()
        {
            this.Cursor = Cursors.AppStarting;
            db.SQLDependency(false);
            tss_status.Text = "Fetching data...";
            string curdt = CurDt, tssStr = "";//DateTime.Now.ToString("MM/dd/yyyy");
            DataTable dt = new DataTable();
            string qry = "SELECT branch,sFile,duration,status FROM dbo.Main WHERE client LIKE '" + clientName + "' AND LOWER([status]) NOT LIKE 'archive'";

            DataTable btscheddt = new DataTable(); DataTable prscheddt = new DataTable(); DataTable ccscheddt = new DataTable();
            DataTable stscheddt = new DataTable(); DataTable forbtdt = new DataTable(); DataTable forprdt = new DataTable();
            DataTable forccdt = new DataTable(); DataTable forstdt = new DataTable(); DataTable fortsdt = new DataTable();
            DataTable forauditdt = new DataTable(); DataTable readydt = new DataTable(); DataTable donedt = new DataTable();
            List<DGVData> dgvdata = new List<DGVData>()
            {
                new DGVData{dgv = dgv_btsched, dataTable = btscheddt},new DGVData{dgv = dgv_prsched, dataTable = prscheddt},
                new DGVData{dgv = dgv_ccsched, dataTable = ccscheddt},new DGVData{dgv = dgv_stsched, dataTable = stscheddt},
                new DGVData{dgv = dgv_forbt, dataTable = forbtdt},new DGVData{dgv = dgv_forpr, dataTable = forprdt},
                new DGVData{dgv = dgv_forcc, dataTable = forccdt},new DGVData{dgv = dgv_forst, dataTable = forstdt},
                new DGVData{dgv = dgv_forts, dataTable = fortsdt},new DGVData{dgv = dgv_foraudit, dataTable = forauditdt},
                new DGVData{dgv = dgv_ready, dataTable = readydt},new DGVData{dgv = dgv_done, dataTable = donedt}
            };

            foreach (var dgvd in dgvdata)
            {
                dgvd.dataTable.Columns.Add("Branch", typeof(string));
                dgvd.dataTable.Columns.Add("Filename", typeof(string));
                dgvd.dataTable.Columns.Add("Duration", typeof(string));
            }

            try
            {
                dt = db.query(qry);
                foreach(DataRow row in dt.Rows)
                {
                    object[] obj = row.ItemArray;
                    string stat = obj[3].ToString().ToLower();
                    dgvdata[Array.IndexOf(statArr, stat)].dataTable.Rows.Add(obj[0], obj[1], obj[2]);
                }

                foreach (var dgvd in dgvdata)
                {
                    dgvd.dgv.DataSource = dgvd.dataTable;
                    dgvd.dgv.ClearSelection();
                    cf.RowsNumber(dgvd.dgv);
                }
                tssStr = "Ready!";
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

        private void tabctrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridView dgv = dgvarr[tabctrl.SelectedIndex];
            cf.RowsNumber(dgv);
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
            string curdate = CurDt;//DateTime.Now.ToString("MM/dd/yyyy");
            db.SQLDependency(true);
            db.OnNewMessage += new markDBOClass.SQLClass.NewMessage(OnNewMessage);
            db.query("SELECT Id,status,dateServ FROM dbo.Main");
        }
    }
}
