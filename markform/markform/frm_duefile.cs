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
    public partial class frm_duefile : Form
    {
        /// <summary>
        /// Initialize CustomClass()
        /// </summary>
        CustomClass cf = new CustomClass();
        /// <summary>
        /// Initialize SQL database class. This class is used for easy database manipulation.
        /// </summary>
        markDBOClass.SQLClass db = new markDBOClass.SQLClass();
        /// <summary>
        /// Container for all the query string when an exception encountered.
        /// </summary>
        private string ErrorQry = "";
        /// <summary>
        /// setting cancel token source variable to be able to cancel the asynchronous function.
        /// </summary>
        private CancellationTokenSource _cts;
        /// <summary>
        /// Load Form
        /// </summary>
        public frm_duefile()
        {
            InitializeComponent();
            this.Tag = "duefiles";
            DisplayData();
        }
        /// <summary>
        /// Populate datagridview with the data from the database
        /// </summary>
        private async void DisplayData()
        {
            _cts = new CancellationTokenSource(); CancellationToken token = _cts.Token;

            this.Cursor = Cursors.AppStarting;
            db.SQLDependency(false);//this will prevent SQL Error due to SQLDependency.

            string SelDT = dtpicker.Value.Date.ToString("yyyy/MM/dd"),tssStr = "";
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

            //Display progress report to the UI during the asychronous process.
            Progress<string> progressHandler = new Progress<string>(val => { tss_status.Text = val; });
            IProgress<string> progress = (IProgress<string>)progressHandler;

            try
            {
                await Task.Run(()=> {
                    DataTable dt = new DataTable();
                    string qry = "SELECT client,dateRec,sFile,duration,dateDue FROM dbo.Main WHERE CONVERT(date,dateDue) LIKE CONVERT(date,'" + SelDT + "') ORDER BY client";
                    try
                    {
                        dt = db.query(qry);
                    }
                    catch (Exception)
                    {
                        ErrorQry = qry;
                        throw;
                    }

                    int x = 0, cnt = dt.Rows.Count;
                    foreach (DataRow row in dt.Rows)
                    {
                        token.ThrowIfCancellationRequested();//cancel task.run when requested.
                        progress.Report("Fetching data: " + x + " of " + cnt);//report progress to be displayed to the user
                        object[] obj = row.ItemArray;
                        newdt.Rows.Add(obj[0], obj[1], obj[2], obj[3], obj[4]);
                        x++;
                    }
                });
                dgv_duefile.DataSource = newdt;
                foreach(var itm in header)
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
        /// <summary>
        /// This will cancel the <seealso cref="DisplayData"/> before closing this form to prevent error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_duefile_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_cts != null) { _cts.Cancel(); }
        }
    }
}
