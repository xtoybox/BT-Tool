using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace markform
{
    public partial class frm_duefile : Form
    {
        #region Initialize Classes
        CustomClass cf = new CustomClass();
        SQLClass db = new SQLClass();
        #endregion

        #region Setting Variables
        private string ErrorQry = "";
        private CancellationTokenSource _cnl;
        #endregion

        #region Form Class Initialization
        public frm_duefile()
        {
            InitializeComponent();
            this.Tag = "duefiles";
            DisplayData();
        }
        #endregion

        #region Events
        /// <summary>
        /// Calling the DisplayData() when date is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DisplayData();
        }
        /// <summary>
        /// Reinitializing the row number to be always increment starting from 1 to n when sorting the datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_duefile_Sorted(object sender, EventArgs e)
        {
            cf.RowsNumber(dgv_duefile);
        }

        private void frm_duefile_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cnl != null) { _cnl.Cancel(); }
        }
        #endregion

        #region Void Methods
        /// <summary>
        /// Population datagridview
        /// </summary>
        private async void DisplayData()
        {
            _cnl = new CancellationTokenSource();
            CancellationToken token = _cnl.Token;
            this.Cursor = Cursors.AppStarting;
            db.SQLDependency(false);//this will prevent SQL Error due to SQLDependency.

            string SelDT = dtpicker.Value.Date.ToString("yyyy/MM/dd"), tssStr = "";
            DataTable newdt = new DataTable();
            List<CustomClass.GridHeaders> header = new List<CustomClass.GridHeaders>()
            {
                new CustomClass.GridHeaders{index = 0, text = "Client", type = typeof(string), width = 70},
                new CustomClass.GridHeaders{index = 1, text = "Batch", type = typeof(string), width = 70},
                new CustomClass.GridHeaders{index = 2, text = "Filename", type = typeof(string), width = 300},
                new CustomClass.GridHeaders{index = 3, text = "Duration", type = typeof(string), width = 70},
                new CustomClass.GridHeaders{index = 4, text = "Due Date", type = typeof(string), width = 70}
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
                    DataTable dt = new DataTable();
                    string qry = "SELECT client,dateRec,sFile,duration,dateDue FROM dbo.Main WHERE CONVERT(date,dateDue) LIKE CONVERT(date,'" + SelDT + "') ORDER BY client";
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
                        progress.Report("Fetching data: " + x + " of " + cnt);
                        object[] obj = row.ItemArray;
                        newdt.Rows.Add(obj[0], obj[1], obj[2], obj[3], obj[4]);
                        x++;
                    }
                });
                dgv_duefile.DataSource = newdt;
                foreach (var itm in header)
                {
                    dgv_duefile.Columns[itm.index].Width = itm.width;
                }
                cf.RowsNumber(dgv_duefile);
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
        #endregion

        #region Functions

        #endregion

        
    }
}
