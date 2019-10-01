namespace markform
{
    partial class frm_sub_report_log
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_sub_report_log));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dgv_breaklog = new System.Windows.Forms.DataGridView();
            this.tss_total_dur = new System.Windows.Forms.ToolStripStatusLabel();
            this.tss_sel_dur = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_breaklog)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tss_total_dur,
            this.tss_sel_dur});
            this.statusStrip1.Location = new System.Drawing.Point(0, 193);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(600, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dgv_breaklog
            // 
            this.dgv_breaklog.AllowUserToAddRows = false;
            this.dgv_breaklog.AllowUserToDeleteRows = false;
            this.dgv_breaklog.AllowUserToResizeRows = false;
            this.dgv_breaklog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_breaklog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_breaklog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_breaklog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_breaklog.Location = new System.Drawing.Point(0, 0);
            this.dgv_breaklog.Name = "dgv_breaklog";
            this.dgv_breaklog.ReadOnly = true;
            this.dgv_breaklog.RowHeadersVisible = false;
            this.dgv_breaklog.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_breaklog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_breaklog.Size = new System.Drawing.Size(600, 193);
            this.dgv_breaklog.TabIndex = 1;
            this.dgv_breaklog.SelectionChanged += new System.EventHandler(this.dgv_breaklog_SelectionChanged);
            // 
            // tss_total_dur
            // 
            this.tss_total_dur.Name = "tss_total_dur";
            this.tss_total_dur.Size = new System.Drawing.Size(79, 17);
            this.tss_total_dur.Text = "Total Duration:";
            // 
            // tss_sel_dur
            // 
            this.tss_sel_dur.Name = "tss_sel_dur";
            this.tss_sel_dur.Size = new System.Drawing.Size(123, 17);
            this.tss_sel_dur.Text = "Selected Total Duration:";
            // 
            // frm_sub_report_log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 215);
            this.Controls.Add(this.dgv_breaklog);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(608, 242);
            this.Name = "frm_sub_report_log";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Break Log";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_breaklog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView dgv_breaklog;
        private System.Windows.Forms.ToolStripStatusLabel tss_total_dur;
        private System.Windows.Forms.ToolStripStatusLabel tss_sel_dur;
    }
}