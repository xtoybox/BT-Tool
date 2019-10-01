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
    public partial class frm_qrtracker : Form
    {
        CustomClass cf = new CustomClass();
        markDBOClass.SQLClass db = new markDBOClass.SQLClass();
        private string ErrorQry = "";
        private CancellationTokenSource _cts;
        public frm_qrtracker()
        {
            InitializeComponent();
            this.Tag = "track";
            DisplayData();
        }
        /// <summary>
        /// Populate datagridview
        /// </summary>
        private async void DisplayData()
        {
            _cts = new CancellationTokenSource(); CancellationToken token = _cts.Token;
            db.SQLDependency(false);
            this.Cursor = Cursors.AppStarting;
            string SelDT = dtpicker.Value.Date.ToString("MM/dd/yyyy"), tssStr = "";
            DataTable newdt = new DataTable();
            List<CustomClass.GridHeaders> header = new List<CustomClass.GridHeaders>()
            {
                new CustomClass.GridHeaders{index = 0, text = "Name", type = typeof(string), width = 70},
                new CustomClass.GridHeaders{index = 1, text = "Filename", type = typeof(string), width = 300},
                new CustomClass.GridHeaders{index = 2, text = "Client", type = typeof(string), width = 80},
                new CustomClass.GridHeaders{index = 3, text = "Duration", type = typeof(string), width = 60},
                new CustomClass.GridHeaders{index = 4, text = "Start", type = typeof(string), width = 70},
                new CustomClass.GridHeaders{index = 5, text = "End", type = typeof(string), width = 60},
                new CustomClass.GridHeaders{index = 6, text = "Total Working Hours", type = typeof(string), width = 50},
                new CustomClass.GridHeaders{index = 7, text = "Ratio", type = typeof(string), width = 50},
                new CustomClass.GridHeaders{index = 8, text = "mid", type = typeof(int), visible = false}
            };

            foreach(var itm in header)
            {
                newdt.Columns.Add(itm.text, itm.type);
            }
            Progress<string> progressHandler = new Progress<string>(val => { tss_status.Text = val; });
            IProgress<string> progress = (IProgress<string>)progressHandler;
            try
            {
                await Task.Run(()=>
                {
                    string qry = "SELECT Id, sFile, duration, client, accuracy, status, ISNULL(btStart, '') AS tstart," +
                    "ISNULL(btEnd, '') AS tend,(SELECT username FROM dbo.UserData WHERE Id = bt)," +
                    "DATEDIFF(second, 0, cast(duration as datetime)) AS dursec," +
                    "DATEDIFF(ss, CONVERT(datetime, btStart), CONVERT(datetime, btEnd)) AS twhsec " +
                    "FROM dbo.Main WHERE CONVERT(date, dateServ) LIKE CONVERT(date,'" + SelDT + "') ORDER BY CONVERT(date, dateServ)";

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

                    foreach(DataRow row in dt.Rows)
                    {
                        token.ThrowIfCancellationRequested();
                        progress.Report("Fetching data: " + x + " of " + cnt);
                        object[] obj = row.ItemArray; Console.Write("test: " + obj[10].ToString());
                        double dursec,twhsec;
                        double.TryParse(obj[9].ToString(), out dursec);
                        double.TryParse(obj[10].ToString(), out twhsec);
                        double r = twhsec / dursec;
                        string twh = cf.SecondsToTime24(twhsec),
                        bstart = (cf.IsStringEmpty(obj[6].ToString()))?"": DateTime.Parse(obj[6].ToString()).ToString("h:mm:ss tt"),
                        bend = (cf.IsStringEmpty(obj[7].ToString())) ? "" : DateTime.Parse(obj[7].ToString()).ToString("h:mm:ss tt");
                       
                        newdt.Rows.Add(obj[8], obj[1], obj[3], obj[2], bstart, bend, twh, r.ToString("0.00"), obj[0]);
                        x++;
                    }
                });
                dgv_tracker.DataSource = newdt;
                foreach(var itm in header)
                {
                    dgv_tracker.Columns[itm.index].Visible = itm.visible;
                    dgv_tracker.Columns[itm.index].Width = itm.width;
                }
                cf.RowsNumber(dgv_tracker);
                tssStr = "Ready!";
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
        /// Reinitializing the row number to be always increment starting from 1 to n when sorting the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_tracker_Sorted(object sender, EventArgs e)
        {
            cf.RowsNumber(dgv_tracker);
        }
        /// <summary>
        /// Calling DisplayData() when date is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpicker_ValueChanged(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {

        }

        private void frm_qrtracker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cts != null) { _cts.Cancel(); }
        }
    }
}
