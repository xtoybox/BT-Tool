using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace markform
{
    public partial class frm_file_eval_bulkdownload : Form
    {
        #region Initialize Classes
        CustomClass cf = new CustomClass();
        #endregion

        #region Setting Variables
        private string[] lst = new string[] { };
        private int TotalItem = 0;
        #endregion

        #region Form Class Initialization
        /// <summary>
        /// Initialize form
        /// </summary>
        /// <param name="args">Array of comparse</param>
        public frm_file_eval_bulkdownload(string[] args = null)
        {
            InitializeComponent();
            if (args != null)
            {
                lst = args;
                txt_directory.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                this.LoadList();
                this.PopulateCbo();
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Changing the view type of the listview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbo_viewtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            View view = (View)cbo_viewtype.SelectedValue;
            listview.View = view;
            listview.LabelWrap = (new View[] { View.List }.Contains(view)) ? false : true;
        }
        /// <summary>
        /// Changing the enabled state of download button and showing
        /// the number of items selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listview_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            btn_download.Enabled = (listview.SelectedItems.Count > 0);
            string ws = (listview.SelectedItems.Count > 1) ? "s" : "";
            tss_status.Text = "Total Selected Item" + ws + ": " + listview.SelectedItems.Count;
        }
        private void btn_browse_folder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select download folder";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txt_directory.Text = fbd.SelectedPath;
                }
            }
        }
        private void btn_download_Click(object sender, EventArgs e)
        {
            List<string> ValidItem = new List<string>();
            foreach (ListViewItem itm in listview.SelectedItems)
            {
                string path = itm.SubItems[2].Text;
                if (path != "File does not exist")
                {
                    ValidItem.Add(path);
                }
            }

            if (ValidItem.Count == 0)
            {
                MessageBox.Show(this, "No valid item selected. \nValid items are items that has a valid Path.\nThis means that the item does exist.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string ws = (ValidItem.Count > 1) ? "s" : "";
                DialogResult dr = MessageBox.Show(this, "You are about to download " + ValidItem.Count + " valid item" + ws + ".\nThe selected item" + ws + " will be transferred to the set download directory.", "Confirm Download", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    tss_status.Text = "Initializing...";
                    this.TotalItem = ValidItem.Count;
                    BWArgs bwa = new BWArgs()
                    {
                        item = ValidItem.ToArray(),
                        dir = txt_directory.Text
                    };
                    bw.RunWorkerAsync(bwa);
                }
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        #endregion

        #region Void Methods
        /// <summary>
        /// Populate combobox to list the available viewtype for the listview
        /// </summary>
        private void PopulateCbo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("text", typeof(string));
            dt.Columns.Add("value", typeof(View));
            dt.Rows.Add("Large Icon", View.LargeIcon);
            dt.Rows.Add("Small Icon", View.SmallIcon);
            dt.Rows.Add("List", View.List);
            dt.Rows.Add("Details", View.Details);
            dt.Rows.Add("Tiles", View.Tile);

            cbo_viewtype.DisplayMember = "text";
            cbo_viewtype.ValueMember = "value";
            cbo_viewtype.DataSource = dt;
            cbo_viewtype.SelectedValue = View.Details;
        }
        /// <summary>
        /// validate and load the list
        /// </summary>
        private void LoadList()
        {
            listview.Clear();
            tss_status.Text = "Initializing...";
            int x = 1;
            listview.Columns.Add("Filename", 200);
            listview.Columns.Add("Size", 70);
            listview.Columns.Add("Path", 150);
            List<ListViewItem> lstviewitm = new List<ListViewItem>();
            foreach (string str in lst)
            {
                Application.DoEvents();
                string filename = "", fullname = "";
                double fnLen = 0;

                try
                {
                    FileInfo fi = new FileInfo(str);
                    filename = fi.Name; fnLen = fi.Length; fullname = fi.FullName;
                }
                catch (Exception)
                {
                    string[] strArr = str.Split('\\');
                    filename = strArr[strArr.Length - 1];
                    fullname = "File does not exist";
                }

                ListViewItem itm = new ListViewItem(new string[] { filename, cf.ReadableFileSize(fnLen), fullname }, 0);
                listview.Items.Add(itm);
                tss_status.Text = "Adding item...(" + x + " of " + lst.Length + ")";
                x++;
            }
            tss_status.Text = "Ready";
        }
        #endregion

        #region Background Worker
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BWArgs bwa = e.Argument as BWArgs;
            string[] itm = bwa.item;
            int x = 1;
            foreach (string str in itm)
            {
                bw.ReportProgress(x, str);
                string[] strArr = str.Split('\\');
                try
                {
                    File.Copy(str, bwa.dir + "\\" + strArr[strArr.Length - 1], true);
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    throw;
                }

                x++;
            }
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tss_status.Text = "(" + e.ProgressPercentage + " of " + this.TotalItem + ") Transferring " + e.UserState.ToString();
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Cancelled)
                {
                    MessageBox.Show(this, "Exception:\n" + e.Error.InnerException.Message, "Operation was cancelled due to an error encountered during the process.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    tss_status.Text = "Transfer done.";
                    MessageBox.Show(this, "Transfer Done.", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, "Exception:\n" + e.Error.InnerException.Message, "Operation was cancelled due to an error encountered during the process.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Functions

        #endregion
        
    }
    public class BWArgs
    {
        public string[] item { get; set; }
        public string dir { get; set; }
    }
}
