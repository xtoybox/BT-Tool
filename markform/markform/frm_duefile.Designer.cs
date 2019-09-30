namespace markform
{
    partial class frm_duefile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_duefile));
            this.gb_filter_export_container = new System.Windows.Forms.GroupBox();
            this.dtpicker = new System.Windows.Forms.DateTimePicker();
            this.dgv_duefile = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tss_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.gb_filter_export_container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_duefile)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_filter_export_container
            // 
            this.gb_filter_export_container.Controls.Add(this.dtpicker);
            this.gb_filter_export_container.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_filter_export_container.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_filter_export_container.Location = new System.Drawing.Point(0, 0);
            this.gb_filter_export_container.Name = "gb_filter_export_container";
            this.gb_filter_export_container.Size = new System.Drawing.Size(712, 50);
            this.gb_filter_export_container.TabIndex = 0;
            this.gb_filter_export_container.TabStop = false;
            this.gb_filter_export_container.Text = "Filter";
            // 
            // dtpicker
            // 
            this.dtpicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpicker.Location = new System.Drawing.Point(12, 19);
            this.dtpicker.Name = "dtpicker";
            this.dtpicker.Size = new System.Drawing.Size(83, 20);
            this.dtpicker.TabIndex = 0;
            this.dtpicker.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dgv_duefile
            // 
            this.dgv_duefile.AllowUserToAddRows = false;
            this.dgv_duefile.AllowUserToDeleteRows = false;
            this.dgv_duefile.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_duefile.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_duefile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_duefile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_duefile.Location = new System.Drawing.Point(0, 50);
            this.dgv_duefile.Name = "dgv_duefile";
            this.dgv_duefile.ReadOnly = true;
            this.dgv_duefile.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_duefile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_duefile.Size = new System.Drawing.Size(712, 381);
            this.dgv_duefile.TabIndex = 1;
            this.dgv_duefile.Sorted += new System.EventHandler(this.dgv_duefile_Sorted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tss_status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(712, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tss_status
            // 
            this.tss_status.Name = "tss_status";
            this.tss_status.Size = new System.Drawing.Size(109, 17);
            this.tss_status.Text = "toolStripStatusLabel1";
            // 
            // frm_duefile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 453);
            this.Controls.Add(this.dgv_duefile);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gb_filter_export_container);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(720, 480);
            this.Name = "frm_duefile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Files On Due";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_duefile_FormClosing);
            this.gb_filter_export_container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_duefile)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_filter_export_container;
        private System.Windows.Forms.DateTimePicker dtpicker;
        private System.Windows.Forms.DataGridView dgv_duefile;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tss_status;
    }
}