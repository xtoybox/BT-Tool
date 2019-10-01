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
    public partial class frm_break_log : Form
    {
        CustomClass cf = new CustomClass();
        markDBOClass.SQLClass db = new markDBOClass.SQLClass();
        private int uid;
        /// <summary>
        /// <paramref name="args"/> should have Array(userid)
        /// </summary>
        /// <param name="args"></param>
        public frm_break_log(string[] args = null)
        {
            InitializeComponent();
            if(args != null)
            {
                this.Tag = "mybreaklog";
                this.uid = int.Parse(args[0]);
                DisplayData();
            }
        }
        /// <summary>
        /// Display data to the datagridview.
        /// </summary>
        private void DisplayData()
        {
            string SelDT = dtpicker.Value.Date.ToString("MM/dd/yyyy");
            string[] ColArr = new string[] { "Filename", "Break Start", "Break End", "Duration" };
            //Initialize new datatable container
            DataTable newdt = new DataTable();
            //loop through the array that contains the column header names and add columns to the datatable
            foreach(string col in ColArr)
            {
                newdt.Columns.Add(col, typeof(string));
            }
            //Initialize new datatable to store the result of the SELECT Query
            DataTable dt = new DataTable();
            //Store query string to a variable to be reuse when an exception is encountered during the query process to know what was the query before the error.
            string qry = "SELECT ISNULL((SELECT sFile FROM dbo.Main WHERE Id = fid),'None')," +
                "DATEDIFF(ss, CAST(bstart AS datetime), CAST(CASE bend WHEN 'pending' THEN GETDATE() ELSE bend END AS datetime)) AS tbhsec," +
                "bstart, bend FROM dbo.tbl_break WHERE uid = " +this.uid+ " AND " +
                "CONVERT(date,[bstart]) LIKE CONVERT(date,'" +SelDT+"') ORDER BY Convert(varchar(30), bstart, 101) DESC";
            try
            {
                dt = db.query(qry);
                double dur = 0;
                foreach(DataRow row in dt.Rows)
                {
                    object[] obj = row.ItemArray;
                    double tbhsec = double.Parse(obj[1].ToString());
                    string tbh = cf.SecondsToTime24(tbhsec),
                        bstart = obj[2].ToString(),
                        bend = obj[3].ToString();
                    bend = (bend == "pending") ? "On Break" : "";
                    dur = dur + tbhsec;
                    newdt.Rows.Add(obj[0], bstart, bend, tbh);
                }

                dgv_breaklog.DataSource = newdt;
                cf.RowsNumber(dgv_breaklog);
                lbl_total.Text = "Total Break Duration: " + cf.SecondsToTime24(dur);
                lbl_total.ForeColor = (dur > 5400) ? Color.Red : Color.Black;
            }
            catch (Exception ex)
            {
                cf.WriteToFile("{0}==>" + ex.ToString() + "\n\n" + qry, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\err.txt");
                MessageBox.Show(this, "Exception:\n" + ex.Message, "Error Encountered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }

        private void dtpicker_ValueChanged(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            DisplayData();
        }
    }
}
