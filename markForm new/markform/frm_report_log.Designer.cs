namespace markform
{
    partial class frm_report_log
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_report_log));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tab_main = new System.Windows.Forms.TabControl();
            this.tab_break = new System.Windows.Forms.TabPage();
            this.dgv_break = new System.Windows.Forms.DataGridView();
            this.tab_notif = new System.Windows.Forms.TabPage();
            this.dgv_notif = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tss_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.tab_main.SuspendLayout();
            this.tab_break.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_break)).BeginInit();
            this.tab_notif.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_notif)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(438, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // tab_main
            // 
            this.tab_main.Controls.Add(this.tab_break);
            this.tab_main.Controls.Add(this.tab_notif);
            this.tab_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_main.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_main.Location = new System.Drawing.Point(0, 24);
            this.tab_main.Name = "tab_main";
            this.tab_main.SelectedIndex = 0;
            this.tab_main.Size = new System.Drawing.Size(438, 314);
            this.tab_main.TabIndex = 1;
            this.tab_main.SelectedIndexChanged += new System.EventHandler(this.tab_main_SelectedIndexChanged);
            // 
            // tab_break
            // 
            this.tab_break.Controls.Add(this.dgv_break);
            this.tab_break.Location = new System.Drawing.Point(4, 22);
            this.tab_break.Name = "tab_break";
            this.tab_break.Padding = new System.Windows.Forms.Padding(3);
            this.tab_break.Size = new System.Drawing.Size(430, 288);
            this.tab_break.TabIndex = 0;
            this.tab_break.Text = "Break Log";
            this.tab_break.UseVisualStyleBackColor = true;
            // 
            // dgv_break
            // 
            this.dgv_break.AllowUserToAddRows = false;
            this.dgv_break.AllowUserToDeleteRows = false;
            this.dgv_break.AllowUserToResizeRows = false;
            this.dgv_break.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_break.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_break.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_break.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_break.Location = new System.Drawing.Point(3, 3);
            this.dgv_break.Name = "dgv_break";
            this.dgv_break.ReadOnly = true;
            this.dgv_break.RowHeadersVisible = false;
            this.dgv_break.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_break.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_break.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_break.Size = new System.Drawing.Size(424, 282);
            this.dgv_break.TabIndex = 0;
            this.dgv_break.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_break_CellDoubleClick);
            // 
            // tab_notif
            // 
            this.tab_notif.Controls.Add(this.dgv_notif);
            this.tab_notif.Location = new System.Drawing.Point(4, 22);
            this.tab_notif.Name = "tab_notif";
            this.tab_notif.Padding = new System.Windows.Forms.Padding(3);
            this.tab_notif.Size = new System.Drawing.Size(430, 288);
            this.tab_notif.TabIndex = 1;
            this.tab_notif.Text = "Idle Notification Log";
            this.tab_notif.UseVisualStyleBackColor = true;
            // 
            // dgv_notif
            // 
            this.dgv_notif.AllowUserToAddRows = false;
            this.dgv_notif.AllowUserToDeleteRows = false;
            this.dgv_notif.AllowUserToResizeRows = false;
            this.dgv_notif.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_notif.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_notif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_notif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_notif.Location = new System.Drawing.Point(3, 3);
            this.dgv_notif.Name = "dgv_notif";
            this.dgv_notif.ReadOnly = true;
            this.dgv_notif.RowHeadersVisible = false;
            this.dgv_notif.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_notif.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_notif.Size = new System.Drawing.Size(424, 282);
            this.dgv_notif.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tss_status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 338);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(438, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tss_status
            // 
            this.tss_status.Name = "tss_status";
            this.tss_status.Size = new System.Drawing.Size(109, 17);
            this.tss_status.Text = "toolStripStatusLabel1";
            // 
            // frm_report_log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 360);
            this.Controls.Add(this.tab_main);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(446, 387);
            this.Name = "frm_report_log";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm_report_log";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tab_main.ResumeLayout(false);
            this.tab_break.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_break)).EndInit();
            this.tab_notif.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_notif)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.TabControl tab_main;
        private System.Windows.Forms.TabPage tab_break;
        private System.Windows.Forms.TabPage tab_notif;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView dgv_break;
        private System.Windows.Forms.DataGridView dgv_notif;
        private System.Windows.Forms.ToolStripStatusLabel tss_status;
    }
}