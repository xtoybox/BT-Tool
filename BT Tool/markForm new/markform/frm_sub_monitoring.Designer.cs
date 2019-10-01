namespace markform
{
    partial class frm_sub_monitoring
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_sub_monitoring));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tss_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabctrl = new System.Windows.Forms.TabControl();
            this.tab_btshced = new System.Windows.Forms.TabPage();
            this.dgv_btsched = new System.Windows.Forms.DataGridView();
            this.tab_prsched = new System.Windows.Forms.TabPage();
            this.dgv_prsched = new System.Windows.Forms.DataGridView();
            this.tab_ccsched = new System.Windows.Forms.TabPage();
            this.dgv_ccsched = new System.Windows.Forms.DataGridView();
            this.tab_stsched = new System.Windows.Forms.TabPage();
            this.dgv_stsched = new System.Windows.Forms.DataGridView();
            this.tab_forbt = new System.Windows.Forms.TabPage();
            this.dgv_forbt = new System.Windows.Forms.DataGridView();
            this.tab_forpr = new System.Windows.Forms.TabPage();
            this.dgv_forpr = new System.Windows.Forms.DataGridView();
            this.tab_forcc = new System.Windows.Forms.TabPage();
            this.dgv_forcc = new System.Windows.Forms.DataGridView();
            this.tab_forst = new System.Windows.Forms.TabPage();
            this.dgv_forst = new System.Windows.Forms.DataGridView();
            this.tab_forts = new System.Windows.Forms.TabPage();
            this.dgv_forts = new System.Windows.Forms.DataGridView();
            this.tab_audits = new System.Windows.Forms.TabPage();
            this.dgv_foraudit = new System.Windows.Forms.DataGridView();
            this.tab_ready = new System.Windows.Forms.TabPage();
            this.dgv_ready = new System.Windows.Forms.DataGridView();
            this.tab_done = new System.Windows.Forms.TabPage();
            this.dgv_done = new System.Windows.Forms.DataGridView();
            this.statusStrip1.SuspendLayout();
            this.tabctrl.SuspendLayout();
            this.tab_btshced.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_btsched)).BeginInit();
            this.tab_prsched.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_prsched)).BeginInit();
            this.tab_ccsched.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ccsched)).BeginInit();
            this.tab_stsched.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_stsched)).BeginInit();
            this.tab_forbt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_forbt)).BeginInit();
            this.tab_forpr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_forpr)).BeginInit();
            this.tab_forcc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_forcc)).BeginInit();
            this.tab_forst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_forst)).BeginInit();
            this.tab_forts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_forts)).BeginInit();
            this.tab_audits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_foraudit)).BeginInit();
            this.tab_ready.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ready)).BeginInit();
            this.tab_done.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_done)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tss_status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 324);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(678, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tss_status
            // 
            this.tss_status.Name = "tss_status";
            this.tss_status.Size = new System.Drawing.Size(109, 17);
            this.tss_status.Text = "toolStripStatusLabel1";
            // 
            // tabctrl
            // 
            this.tabctrl.Controls.Add(this.tab_btshced);
            this.tabctrl.Controls.Add(this.tab_prsched);
            this.tabctrl.Controls.Add(this.tab_ccsched);
            this.tabctrl.Controls.Add(this.tab_stsched);
            this.tabctrl.Controls.Add(this.tab_forbt);
            this.tabctrl.Controls.Add(this.tab_forpr);
            this.tabctrl.Controls.Add(this.tab_forcc);
            this.tabctrl.Controls.Add(this.tab_forst);
            this.tabctrl.Controls.Add(this.tab_forts);
            this.tabctrl.Controls.Add(this.tab_audits);
            this.tabctrl.Controls.Add(this.tab_ready);
            this.tabctrl.Controls.Add(this.tab_done);
            this.tabctrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabctrl.Location = new System.Drawing.Point(0, 0);
            this.tabctrl.Name = "tabctrl";
            this.tabctrl.SelectedIndex = 0;
            this.tabctrl.Size = new System.Drawing.Size(678, 324);
            this.tabctrl.TabIndex = 1;
            this.tabctrl.SelectedIndexChanged += new System.EventHandler(this.tabctrl_SelectedIndexChanged);
            // 
            // tab_btshced
            // 
            this.tab_btshced.Controls.Add(this.dgv_btsched);
            this.tab_btshced.Location = new System.Drawing.Point(4, 22);
            this.tab_btshced.Name = "tab_btshced";
            this.tab_btshced.Padding = new System.Windows.Forms.Padding(3);
            this.tab_btshced.Size = new System.Drawing.Size(670, 298);
            this.tab_btshced.TabIndex = 0;
            this.tab_btshced.Text = "BT Sched";
            this.tab_btshced.UseVisualStyleBackColor = true;
            // 
            // dgv_btsched
            // 
            this.dgv_btsched.AllowUserToAddRows = false;
            this.dgv_btsched.AllowUserToDeleteRows = false;
            this.dgv_btsched.AllowUserToResizeRows = false;
            this.dgv_btsched.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_btsched.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_btsched.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_btsched.Location = new System.Drawing.Point(3, 3);
            this.dgv_btsched.Name = "dgv_btsched";
            this.dgv_btsched.ReadOnly = true;
            this.dgv_btsched.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_btsched.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_btsched.Size = new System.Drawing.Size(664, 292);
            this.dgv_btsched.TabIndex = 0;
            // 
            // tab_prsched
            // 
            this.tab_prsched.Controls.Add(this.dgv_prsched);
            this.tab_prsched.Location = new System.Drawing.Point(4, 22);
            this.tab_prsched.Name = "tab_prsched";
            this.tab_prsched.Padding = new System.Windows.Forms.Padding(3);
            this.tab_prsched.Size = new System.Drawing.Size(670, 298);
            this.tab_prsched.TabIndex = 1;
            this.tab_prsched.Text = "PR Sched";
            this.tab_prsched.UseVisualStyleBackColor = true;
            // 
            // dgv_prsched
            // 
            this.dgv_prsched.AllowUserToAddRows = false;
            this.dgv_prsched.AllowUserToDeleteRows = false;
            this.dgv_prsched.AllowUserToResizeRows = false;
            this.dgv_prsched.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_prsched.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_prsched.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_prsched.Location = new System.Drawing.Point(3, 3);
            this.dgv_prsched.Name = "dgv_prsched";
            this.dgv_prsched.ReadOnly = true;
            this.dgv_prsched.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_prsched.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_prsched.Size = new System.Drawing.Size(664, 292);
            this.dgv_prsched.TabIndex = 1;
            // 
            // tab_ccsched
            // 
            this.tab_ccsched.Controls.Add(this.dgv_ccsched);
            this.tab_ccsched.Location = new System.Drawing.Point(4, 22);
            this.tab_ccsched.Name = "tab_ccsched";
            this.tab_ccsched.Size = new System.Drawing.Size(670, 298);
            this.tab_ccsched.TabIndex = 2;
            this.tab_ccsched.Text = "CC Sched";
            this.tab_ccsched.UseVisualStyleBackColor = true;
            // 
            // dgv_ccsched
            // 
            this.dgv_ccsched.AllowUserToAddRows = false;
            this.dgv_ccsched.AllowUserToDeleteRows = false;
            this.dgv_ccsched.AllowUserToResizeRows = false;
            this.dgv_ccsched.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ccsched.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ccsched.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ccsched.Location = new System.Drawing.Point(0, 0);
            this.dgv_ccsched.Name = "dgv_ccsched";
            this.dgv_ccsched.ReadOnly = true;
            this.dgv_ccsched.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_ccsched.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ccsched.Size = new System.Drawing.Size(670, 298);
            this.dgv_ccsched.TabIndex = 1;
            // 
            // tab_stsched
            // 
            this.tab_stsched.Controls.Add(this.dgv_stsched);
            this.tab_stsched.Location = new System.Drawing.Point(4, 22);
            this.tab_stsched.Name = "tab_stsched";
            this.tab_stsched.Size = new System.Drawing.Size(670, 298);
            this.tab_stsched.TabIndex = 3;
            this.tab_stsched.Text = "S&T Sched";
            this.tab_stsched.UseVisualStyleBackColor = true;
            // 
            // dgv_stsched
            // 
            this.dgv_stsched.AllowUserToAddRows = false;
            this.dgv_stsched.AllowUserToDeleteRows = false;
            this.dgv_stsched.AllowUserToResizeRows = false;
            this.dgv_stsched.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_stsched.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_stsched.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_stsched.Location = new System.Drawing.Point(0, 0);
            this.dgv_stsched.Name = "dgv_stsched";
            this.dgv_stsched.ReadOnly = true;
            this.dgv_stsched.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_stsched.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_stsched.Size = new System.Drawing.Size(670, 298);
            this.dgv_stsched.TabIndex = 1;
            // 
            // tab_forbt
            // 
            this.tab_forbt.Controls.Add(this.dgv_forbt);
            this.tab_forbt.Location = new System.Drawing.Point(4, 22);
            this.tab_forbt.Name = "tab_forbt";
            this.tab_forbt.Size = new System.Drawing.Size(670, 298);
            this.tab_forbt.TabIndex = 4;
            this.tab_forbt.Text = "For BT";
            this.tab_forbt.UseVisualStyleBackColor = true;
            // 
            // dgv_forbt
            // 
            this.dgv_forbt.AllowUserToAddRows = false;
            this.dgv_forbt.AllowUserToDeleteRows = false;
            this.dgv_forbt.AllowUserToResizeRows = false;
            this.dgv_forbt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_forbt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_forbt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_forbt.Location = new System.Drawing.Point(0, 0);
            this.dgv_forbt.Name = "dgv_forbt";
            this.dgv_forbt.ReadOnly = true;
            this.dgv_forbt.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_forbt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_forbt.Size = new System.Drawing.Size(670, 298);
            this.dgv_forbt.TabIndex = 1;
            // 
            // tab_forpr
            // 
            this.tab_forpr.Controls.Add(this.dgv_forpr);
            this.tab_forpr.Location = new System.Drawing.Point(4, 22);
            this.tab_forpr.Name = "tab_forpr";
            this.tab_forpr.Size = new System.Drawing.Size(670, 298);
            this.tab_forpr.TabIndex = 5;
            this.tab_forpr.Text = "For PR";
            this.tab_forpr.UseVisualStyleBackColor = true;
            // 
            // dgv_forpr
            // 
            this.dgv_forpr.AllowUserToAddRows = false;
            this.dgv_forpr.AllowUserToDeleteRows = false;
            this.dgv_forpr.AllowUserToResizeRows = false;
            this.dgv_forpr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_forpr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_forpr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_forpr.Location = new System.Drawing.Point(0, 0);
            this.dgv_forpr.Name = "dgv_forpr";
            this.dgv_forpr.ReadOnly = true;
            this.dgv_forpr.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_forpr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_forpr.Size = new System.Drawing.Size(670, 298);
            this.dgv_forpr.TabIndex = 1;
            // 
            // tab_forcc
            // 
            this.tab_forcc.Controls.Add(this.dgv_forcc);
            this.tab_forcc.Location = new System.Drawing.Point(4, 22);
            this.tab_forcc.Name = "tab_forcc";
            this.tab_forcc.Size = new System.Drawing.Size(670, 298);
            this.tab_forcc.TabIndex = 6;
            this.tab_forcc.Text = "For CC";
            this.tab_forcc.UseVisualStyleBackColor = true;
            // 
            // dgv_forcc
            // 
            this.dgv_forcc.AllowUserToAddRows = false;
            this.dgv_forcc.AllowUserToDeleteRows = false;
            this.dgv_forcc.AllowUserToResizeRows = false;
            this.dgv_forcc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_forcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_forcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_forcc.Location = new System.Drawing.Point(0, 0);
            this.dgv_forcc.Name = "dgv_forcc";
            this.dgv_forcc.ReadOnly = true;
            this.dgv_forcc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_forcc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_forcc.Size = new System.Drawing.Size(670, 298);
            this.dgv_forcc.TabIndex = 1;
            // 
            // tab_forst
            // 
            this.tab_forst.Controls.Add(this.dgv_forst);
            this.tab_forst.Location = new System.Drawing.Point(4, 22);
            this.tab_forst.Name = "tab_forst";
            this.tab_forst.Size = new System.Drawing.Size(670, 298);
            this.tab_forst.TabIndex = 7;
            this.tab_forst.Text = "For S&T";
            this.tab_forst.UseVisualStyleBackColor = true;
            // 
            // dgv_forst
            // 
            this.dgv_forst.AllowUserToAddRows = false;
            this.dgv_forst.AllowUserToDeleteRows = false;
            this.dgv_forst.AllowUserToResizeRows = false;
            this.dgv_forst.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_forst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_forst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_forst.Location = new System.Drawing.Point(0, 0);
            this.dgv_forst.Name = "dgv_forst";
            this.dgv_forst.ReadOnly = true;
            this.dgv_forst.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_forst.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_forst.Size = new System.Drawing.Size(670, 298);
            this.dgv_forst.TabIndex = 1;
            // 
            // tab_forts
            // 
            this.tab_forts.Controls.Add(this.dgv_forts);
            this.tab_forts.Location = new System.Drawing.Point(4, 22);
            this.tab_forts.Name = "tab_forts";
            this.tab_forts.Size = new System.Drawing.Size(670, 298);
            this.tab_forts.TabIndex = 8;
            this.tab_forts.Text = "For TS";
            this.tab_forts.UseVisualStyleBackColor = true;
            // 
            // dgv_forts
            // 
            this.dgv_forts.AllowUserToAddRows = false;
            this.dgv_forts.AllowUserToDeleteRows = false;
            this.dgv_forts.AllowUserToResizeRows = false;
            this.dgv_forts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_forts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_forts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_forts.Location = new System.Drawing.Point(0, 0);
            this.dgv_forts.Name = "dgv_forts";
            this.dgv_forts.ReadOnly = true;
            this.dgv_forts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_forts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_forts.Size = new System.Drawing.Size(670, 298);
            this.dgv_forts.TabIndex = 1;
            // 
            // tab_audits
            // 
            this.tab_audits.Controls.Add(this.dgv_foraudit);
            this.tab_audits.Location = new System.Drawing.Point(4, 22);
            this.tab_audits.Name = "tab_audits";
            this.tab_audits.Size = new System.Drawing.Size(670, 298);
            this.tab_audits.TabIndex = 9;
            this.tab_audits.Text = "For Audit";
            this.tab_audits.UseVisualStyleBackColor = true;
            // 
            // dgv_foraudit
            // 
            this.dgv_foraudit.AllowUserToAddRows = false;
            this.dgv_foraudit.AllowUserToDeleteRows = false;
            this.dgv_foraudit.AllowUserToResizeRows = false;
            this.dgv_foraudit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_foraudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_foraudit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_foraudit.Location = new System.Drawing.Point(0, 0);
            this.dgv_foraudit.Name = "dgv_foraudit";
            this.dgv_foraudit.ReadOnly = true;
            this.dgv_foraudit.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_foraudit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_foraudit.Size = new System.Drawing.Size(670, 298);
            this.dgv_foraudit.TabIndex = 1;
            // 
            // tab_ready
            // 
            this.tab_ready.Controls.Add(this.dgv_ready);
            this.tab_ready.Location = new System.Drawing.Point(4, 22);
            this.tab_ready.Name = "tab_ready";
            this.tab_ready.Size = new System.Drawing.Size(670, 298);
            this.tab_ready.TabIndex = 10;
            this.tab_ready.Text = "Ready";
            this.tab_ready.UseVisualStyleBackColor = true;
            // 
            // dgv_ready
            // 
            this.dgv_ready.AllowUserToAddRows = false;
            this.dgv_ready.AllowUserToDeleteRows = false;
            this.dgv_ready.AllowUserToResizeRows = false;
            this.dgv_ready.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ready.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ready.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ready.Location = new System.Drawing.Point(0, 0);
            this.dgv_ready.Name = "dgv_ready";
            this.dgv_ready.ReadOnly = true;
            this.dgv_ready.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_ready.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ready.Size = new System.Drawing.Size(670, 298);
            this.dgv_ready.TabIndex = 1;
            // 
            // tab_done
            // 
            this.tab_done.Controls.Add(this.dgv_done);
            this.tab_done.Location = new System.Drawing.Point(4, 22);
            this.tab_done.Name = "tab_done";
            this.tab_done.Size = new System.Drawing.Size(670, 298);
            this.tab_done.TabIndex = 11;
            this.tab_done.Text = "Done";
            this.tab_done.UseVisualStyleBackColor = true;
            // 
            // dgv_done
            // 
            this.dgv_done.AllowUserToAddRows = false;
            this.dgv_done.AllowUserToDeleteRows = false;
            this.dgv_done.AllowUserToResizeRows = false;
            this.dgv_done.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_done.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_done.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_done.Location = new System.Drawing.Point(0, 0);
            this.dgv_done.Name = "dgv_done";
            this.dgv_done.ReadOnly = true;
            this.dgv_done.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_done.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_done.Size = new System.Drawing.Size(670, 298);
            this.dgv_done.TabIndex = 1;
            // 
            // frm_sub_monitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 346);
            this.Controls.Add(this.tabctrl);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(637, 373);
            this.Name = "frm_sub_monitoring";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Monitoring (Client)";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabctrl.ResumeLayout(false);
            this.tab_btshced.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_btsched)).EndInit();
            this.tab_prsched.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_prsched)).EndInit();
            this.tab_ccsched.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ccsched)).EndInit();
            this.tab_stsched.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_stsched)).EndInit();
            this.tab_forbt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_forbt)).EndInit();
            this.tab_forpr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_forpr)).EndInit();
            this.tab_forcc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_forcc)).EndInit();
            this.tab_forst.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_forst)).EndInit();
            this.tab_forts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_forts)).EndInit();
            this.tab_audits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_foraudit)).EndInit();
            this.tab_ready.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ready)).EndInit();
            this.tab_done.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_done)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabctrl;
        private System.Windows.Forms.TabPage tab_btshced;
        private System.Windows.Forms.TabPage tab_prsched;
        private System.Windows.Forms.DataGridView dgv_btsched;
        private System.Windows.Forms.TabPage tab_ccsched;
        private System.Windows.Forms.TabPage tab_stsched;
        private System.Windows.Forms.TabPage tab_forbt;
        private System.Windows.Forms.TabPage tab_forpr;
        private System.Windows.Forms.TabPage tab_forcc;
        private System.Windows.Forms.TabPage tab_forst;
        private System.Windows.Forms.TabPage tab_forts;
        private System.Windows.Forms.TabPage tab_audits;
        private System.Windows.Forms.TabPage tab_ready;
        private System.Windows.Forms.TabPage tab_done;
        private System.Windows.Forms.DataGridView dgv_prsched;
        private System.Windows.Forms.DataGridView dgv_ccsched;
        private System.Windows.Forms.DataGridView dgv_stsched;
        private System.Windows.Forms.DataGridView dgv_forbt;
        private System.Windows.Forms.DataGridView dgv_forpr;
        private System.Windows.Forms.DataGridView dgv_forcc;
        private System.Windows.Forms.DataGridView dgv_forst;
        private System.Windows.Forms.DataGridView dgv_forts;
        private System.Windows.Forms.DataGridView dgv_foraudit;
        private System.Windows.Forms.DataGridView dgv_ready;
        private System.Windows.Forms.DataGridView dgv_done;
        private System.Windows.Forms.ToolStripStatusLabel tss_status;
    }
}