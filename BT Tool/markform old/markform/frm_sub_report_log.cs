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
    public partial class frm_sub_report_log : Form
    {
        CustomClass cf = new CustomClass();
        public frm_sub_report_log()
        {
            InitializeComponent();
            this.Tag = "breaklog";
        }
        public void SetLocation(int mainfrmwidth)
        {
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - (this.Width + mainfrmwidth)), (Screen.PrimaryScreen.WorkingArea.Height - this.Height));
        }
        public void DisplayData(string breakdata, string username)
        {
            this.Text = "Break Log - " + username.ToUpper();
            List<BreakLogData> bdata = JsonConvert.DeserializeObject<List<BreakLogData>>(breakdata);
            DataTable dt = new DataTable();
            dt.Columns.Add("Filename", typeof(string));
            dt.Columns.Add("Break Start", typeof(string));
            dt.Columns.Add("Break End", typeof(string));
            dt.Columns.Add("Duration", typeof(string));
            double dur = 0;
            foreach(BreakLogData bld in bdata)
            {
                dt.Rows.Add(bld.filename, bld.bstart, bld.bend, bld.duration);
                dur = dur + TimeSpan.Parse(bld.duration).TotalSeconds;
            }
            dgv_breaklog.DataSource = dt;
            tss_total_dur.Text = "Total Duration: " + cf.SecondsToTime24(dur);

            tss_total_dur.ForeColor = (dur > 5400)?Color.Red:Color.Black;
            cf.RowsNumber(dgv_breaklog);
        }
        private void dgv_breaklog_SelectionChanged(object sender, EventArgs e)
        {
            GetSelectedTotalDur();
        }

        private void GetSelectedTotalDur()
        {
            double dur = 0;
            foreach (DataGridViewRow row in dgv_breaklog.SelectedRows)
            {
                dur = dur + TimeSpan.Parse(row.Cells[3].Value.ToString()).TotalSeconds;
            }
            tss_sel_dur.Text = "Selected Total Duration: " + cf.SecondsToTime24(dur);
        }
    }
}
