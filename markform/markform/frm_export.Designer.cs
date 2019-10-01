namespace markform
{
    partial class frm_export
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_export));
            this.dtpicker = new System.Windows.Forms.MonthCalendar();
            this.pnl_cl_dep_container = new System.Windows.Forms.Panel();
            this.cbo_dep = new System.Windows.Forms.ComboBox();
            this.lbl_dep = new System.Windows.Forms.Label();
            this.cbo_client = new System.Windows.Forms.ComboBox();
            this.lbl_cltype = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tss_progressbar = new System.Windows.Forms.ToolStripProgressBar();
            this.tss_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnl_action_btn_container = new System.Windows.Forms.Panel();
            this.btn_export = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.lbl_status = new System.Windows.Forms.Label();
            this.pnl_cl_dep_container.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnl_action_btn_container.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpicker
            // 
            this.dtpicker.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpicker.Location = new System.Drawing.Point(10, 10);
            this.dtpicker.MaxSelectionCount = 500;
            this.dtpicker.Name = "dtpicker";
            this.dtpicker.TabIndex = 0;
            this.dtpicker.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.dtpicker_DateSelected);
            // 
            // pnl_cl_dep_container
            // 
            this.pnl_cl_dep_container.Controls.Add(this.cbo_dep);
            this.pnl_cl_dep_container.Controls.Add(this.lbl_dep);
            this.pnl_cl_dep_container.Controls.Add(this.cbo_client);
            this.pnl_cl_dep_container.Controls.Add(this.lbl_cltype);
            this.pnl_cl_dep_container.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_cl_dep_container.Location = new System.Drawing.Point(10, 173);
            this.pnl_cl_dep_container.Name = "pnl_cl_dep_container";
            this.pnl_cl_dep_container.Size = new System.Drawing.Size(199, 91);
            this.pnl_cl_dep_container.TabIndex = 1;
            this.pnl_cl_dep_container.Visible = false;
            // 
            // cbo_dep
            // 
            this.cbo_dep.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbo_dep.FormattingEnabled = true;
            this.cbo_dep.Location = new System.Drawing.Point(0, 65);
            this.cbo_dep.Name = "cbo_dep";
            this.cbo_dep.Size = new System.Drawing.Size(199, 21);
            this.cbo_dep.TabIndex = 2;
            // 
            // lbl_dep
            // 
            this.lbl_dep.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_dep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dep.Location = new System.Drawing.Point(0, 44);
            this.lbl_dep.Name = "lbl_dep";
            this.lbl_dep.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.lbl_dep.Size = new System.Drawing.Size(199, 21);
            this.lbl_dep.TabIndex = 1;
            this.lbl_dep.Text = "Department:";
            this.lbl_dep.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cbo_client
            // 
            this.cbo_client.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbo_client.FormattingEnabled = true;
            this.cbo_client.Location = new System.Drawing.Point(0, 23);
            this.cbo_client.Name = "cbo_client";
            this.cbo_client.Size = new System.Drawing.Size(199, 21);
            this.cbo_client.TabIndex = 1;
            // 
            // lbl_cltype
            // 
            this.lbl_cltype.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_cltype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cltype.Location = new System.Drawing.Point(0, 0);
            this.lbl_cltype.Name = "lbl_cltype";
            this.lbl_cltype.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.lbl_cltype.Size = new System.Drawing.Size(199, 23);
            this.lbl_cltype.TabIndex = 0;
            this.lbl_cltype.Text = "Client Type:";
            this.lbl_cltype.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tss_progressbar,
            this.tss_status});
            this.statusStrip1.Location = new System.Drawing.Point(10, 333);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(199, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tss_progressbar
            // 
            this.tss_progressbar.Name = "tss_progressbar";
            this.tss_progressbar.Size = new System.Drawing.Size(100, 16);
            this.tss_progressbar.Visible = false;
            // 
            // tss_status
            // 
            this.tss_status.Name = "tss_status";
            this.tss_status.Size = new System.Drawing.Size(26, 17);
            this.tss_status.Text = "stat";
            // 
            // pnl_action_btn_container
            // 
            this.pnl_action_btn_container.Controls.Add(this.btn_export);
            this.pnl_action_btn_container.Controls.Add(this.panel2);
            this.pnl_action_btn_container.Controls.Add(this.btn_close);
            this.pnl_action_btn_container.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_action_btn_container.Location = new System.Drawing.Point(10, 308);
            this.pnl_action_btn_container.Name = "pnl_action_btn_container";
            this.pnl_action_btn_container.Size = new System.Drawing.Size(199, 25);
            this.pnl_action_btn_container.TabIndex = 3;
            // 
            // btn_export
            // 
            this.btn_export.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_export.Enabled = false;
            this.btn_export.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.Location = new System.Drawing.Point(79, 0);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(55, 25);
            this.btn_export.TabIndex = 0;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(134, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 25);
            this.panel2.TabIndex = 2;
            // 
            // btn_close
            // 
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.Location = new System.Drawing.Point(144, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(55, 25);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lbl_status
            // 
            this.lbl_status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_status.Location = new System.Drawing.Point(10, 264);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(199, 44);
            this.lbl_status.TabIndex = 4;
            this.lbl_status.Text = "No Data to Export";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frm_export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_close;
            this.ClientSize = new System.Drawing.Size(219, 365);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.pnl_action_btn_container);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnl_cl_dep_container);
            this.Controls.Add(this.dtpicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_export";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export To Excel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_export_FormClosing);
            this.pnl_cl_dep_container.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnl_action_btn_container.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar dtpicker;
        private System.Windows.Forms.Panel pnl_cl_dep_container;
        private System.Windows.Forms.ComboBox cbo_dep;
        private System.Windows.Forms.Label lbl_dep;
        private System.Windows.Forms.ComboBox cbo_client;
        private System.Windows.Forms.Label lbl_cltype;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tss_status;
        private System.Windows.Forms.Panel pnl_action_btn_container;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.ToolStripProgressBar tss_progressbar;
    }
}