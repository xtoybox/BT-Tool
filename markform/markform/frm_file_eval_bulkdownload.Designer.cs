namespace markform
{
    partial class frm_file_eval_bulkdownload
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_file_eval_bulkdownload));
            this.gb_directory_container = new System.Windows.Forms.GroupBox();
            this.txt_directory = new System.Windows.Forms.TextBox();
            this.btn_browse_folder = new System.Windows.Forms.Button();
            this.gb_listview_container = new System.Windows.Forms.GroupBox();
            this.listview = new System.Windows.Forms.ListView();
            this.imglst_large = new System.Windows.Forms.ImageList(this.components);
            this.imglst_small = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbo_viewtype = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tss_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnl_action_btn_container = new System.Windows.Forms.Panel();
            this.btn_download = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.gb_directory_container.SuspendLayout();
            this.gb_listview_container.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnl_action_btn_container.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_directory_container
            // 
            this.gb_directory_container.Controls.Add(this.txt_directory);
            this.gb_directory_container.Controls.Add(this.btn_browse_folder);
            this.gb_directory_container.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_directory_container.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_directory_container.Location = new System.Drawing.Point(10, 10);
            this.gb_directory_container.Name = "gb_directory_container";
            this.gb_directory_container.Padding = new System.Windows.Forms.Padding(10);
            this.gb_directory_container.Size = new System.Drawing.Size(440, 53);
            this.gb_directory_container.TabIndex = 0;
            this.gb_directory_container.TabStop = false;
            this.gb_directory_container.Text = "Download Directory:";
            // 
            // txt_directory
            // 
            this.txt_directory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_directory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_directory.Location = new System.Drawing.Point(10, 23);
            this.txt_directory.Name = "txt_directory";
            this.txt_directory.ReadOnly = true;
            this.txt_directory.Size = new System.Drawing.Size(382, 20);
            this.txt_directory.TabIndex = 0;
            // 
            // btn_browse_folder
            // 
            this.btn_browse_folder.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_browse_folder.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_browse_folder.Location = new System.Drawing.Point(392, 23);
            this.btn_browse_folder.Name = "btn_browse_folder";
            this.btn_browse_folder.Size = new System.Drawing.Size(38, 20);
            this.btn_browse_folder.TabIndex = 1;
            this.btn_browse_folder.Text = "...";
            this.btn_browse_folder.UseVisualStyleBackColor = true;
            this.btn_browse_folder.Click += new System.EventHandler(this.btn_browse_folder_Click);
            // 
            // gb_listview_container
            // 
            this.gb_listview_container.Controls.Add(this.listview);
            this.gb_listview_container.Controls.Add(this.panel2);
            this.gb_listview_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_listview_container.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_listview_container.Location = new System.Drawing.Point(10, 63);
            this.gb_listview_container.Name = "gb_listview_container";
            this.gb_listview_container.Padding = new System.Windows.Forms.Padding(10);
            this.gb_listview_container.Size = new System.Drawing.Size(440, 288);
            this.gb_listview_container.TabIndex = 1;
            this.gb_listview_container.TabStop = false;
            this.gb_listview_container.Text = "Select the file/s you want to download";
            // 
            // listview
            // 
            this.listview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listview.LargeImageList = this.imglst_large;
            this.listview.Location = new System.Drawing.Point(10, 45);
            this.listview.Name = "listview";
            this.listview.Size = new System.Drawing.Size(420, 233);
            this.listview.SmallImageList = this.imglst_small;
            this.listview.TabIndex = 0;
            this.listview.UseCompatibleStateImageBehavior = false;
            this.listview.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listview_ItemSelectionChanged);
            // 
            // imglst_large
            // 
            this.imglst_large.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglst_large.ImageStream")));
            this.imglst_large.TransparentColor = System.Drawing.Color.Transparent;
            this.imglst_large.Images.SetKeyName(0, "word_64.png");
            // 
            // imglst_small
            // 
            this.imglst_small.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglst_small.ImageStream")));
            this.imglst_small.TransparentColor = System.Drawing.Color.Transparent;
            this.imglst_small.Images.SetKeyName(0, "word_16.png");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbo_viewtype);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 22);
            this.panel2.TabIndex = 2;
            // 
            // cbo_viewtype
            // 
            this.cbo_viewtype.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbo_viewtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_viewtype.FormattingEnabled = true;
            this.cbo_viewtype.Location = new System.Drawing.Point(299, 0);
            this.cbo_viewtype.Name = "cbo_viewtype";
            this.cbo_viewtype.Size = new System.Drawing.Size(121, 21);
            this.cbo_viewtype.TabIndex = 1;
            this.cbo_viewtype.SelectedIndexChanged += new System.EventHandler(this.cbo_viewtype_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tss_status});
            this.statusStrip1.Location = new System.Drawing.Point(10, 378);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(440, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tss_status
            // 
            this.tss_status.Name = "tss_status";
            this.tss_status.Size = new System.Drawing.Size(109, 17);
            this.tss_status.Text = "toolStripStatusLabel1";
            // 
            // pnl_action_btn_container
            // 
            this.pnl_action_btn_container.Controls.Add(this.btn_download);
            this.pnl_action_btn_container.Controls.Add(this.panel1);
            this.pnl_action_btn_container.Controls.Add(this.btn_close);
            this.pnl_action_btn_container.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_action_btn_container.Location = new System.Drawing.Point(10, 351);
            this.pnl_action_btn_container.Name = "pnl_action_btn_container";
            this.pnl_action_btn_container.Size = new System.Drawing.Size(440, 27);
            this.pnl_action_btn_container.TabIndex = 3;
            // 
            // btn_download
            // 
            this.btn_download.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_download.Enabled = false;
            this.btn_download.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_download.Location = new System.Drawing.Point(309, 0);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(73, 27);
            this.btn_download.TabIndex = 1;
            this.btn_download.Text = "Download";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(382, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 27);
            this.panel1.TabIndex = 2;
            // 
            // btn_close
            // 
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(392, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(48, 27);
            this.btn_close.TabIndex = 0;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // bw
            // 
            this.bw.WorkerReportsProgress = true;
            this.bw.WorkerSupportsCancellation = true;
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_ProgressChanged);
            this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // frm_file_eval_bulkdownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_close;
            this.ClientSize = new System.Drawing.Size(460, 410);
            this.ControlBox = false;
            this.Controls.Add(this.gb_listview_container);
            this.Controls.Add(this.pnl_action_btn_container);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gb_directory_container);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_file_eval_bulkdownload";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Download Compares";
            this.gb_directory_container.ResumeLayout(false);
            this.gb_directory_container.PerformLayout();
            this.gb_listview_container.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnl_action_btn_container.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_directory_container;
        private System.Windows.Forms.TextBox txt_directory;
        private System.Windows.Forms.Button btn_browse_folder;
        private System.Windows.Forms.GroupBox gb_listview_container;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel pnl_action_btn_container;
        private System.Windows.Forms.ListView listview;
        private System.Windows.Forms.ToolStripStatusLabel tss_status;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.ImageList imglst_large;
        private System.Windows.Forms.ComboBox cbo_viewtype;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ImageList imglst_small;
        private System.ComponentModel.BackgroundWorker bw;
    }
}