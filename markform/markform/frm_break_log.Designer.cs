namespace markform
{
    partial class frm_break_log
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_break_log));
            this.dgv_breaklog = new System.Windows.Forms.DataGridView();
            this.dtpicker = new System.Windows.Forms.DateTimePicker();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_total = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_breaklog)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_breaklog
            // 
            this.dgv_breaklog.AllowUserToAddRows = false;
            this.dgv_breaklog.AllowUserToDeleteRows = false;
            this.dgv_breaklog.AllowUserToResizeRows = false;
            this.dgv_breaklog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_breaklog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_breaklog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_breaklog.Location = new System.Drawing.Point(10, 30);
            this.dgv_breaklog.Name = "dgv_breaklog";
            this.dgv_breaklog.ReadOnly = true;
            this.dgv_breaklog.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_breaklog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_breaklog.Size = new System.Drawing.Size(548, 206);
            this.dgv_breaklog.TabIndex = 0;
            // 
            // dtpicker
            // 
            this.dtpicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpicker.Location = new System.Drawing.Point(3, 3);
            this.dtpicker.Name = "dtpicker";
            this.dtpicker.Size = new System.Drawing.Size(96, 20);
            this.dtpicker.TabIndex = 1;
            this.dtpicker.ValueChanged += new System.EventHandler(this.dtpicker_ValueChanged);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(105, 3);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(57, 20);
            this.btn_refresh.TabIndex = 2;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_total);
            this.panel1.Controls.Add(this.dtpicker);
            this.panel1.Controls.Add(this.btn_refresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 30);
            this.panel1.TabIndex = 3;
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total.Location = new System.Drawing.Point(168, 7);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(129, 13);
            this.lbl_total.TabIndex = 3;
            this.lbl_total.Text = "Total Break Duration:";
            // 
            // frm_break_log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 246);
            this.Controls.Add(this.dgv_breaklog);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(576, 273);
            this.Name = "frm_break_log";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "My Break Log";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_breaklog)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_breaklog;
        private System.Windows.Forms.DateTimePicker dtpicker;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_total;
    }
}