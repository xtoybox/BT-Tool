namespace markform
{
    partial class frm_flagging
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_flagging));
            this.pnl_group_container = new System.Windows.Forms.Panel();
            this.gb_flagform_container = new System.Windows.Forms.GroupBox();
            this.tlp_flag_form_container = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_client = new System.Windows.Forms.Label();
            this.lbl_filename = new System.Windows.Forms.Label();
            this.lbl_problem = new System.Windows.Forms.Label();
            this.cbo_client = new System.Windows.Forms.ComboBox();
            this.txt_filename = new System.Windows.Forms.TextBox();
            this.rtxt_problem = new System.Windows.Forms.RichTextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.tlp_seen_unseen_container = new System.Windows.Forms.TableLayoutPanel();
            this.btn_seen = new System.Windows.Forms.Button();
            this.btn_unseen = new System.Windows.Forms.Button();
            this.gb_filter_export_container = new System.Windows.Forms.GroupBox();
            this.tlp_filter_export_container = new System.Windows.Forms.TableLayoutPanel();
            this.dtpicker = new System.Windows.Forms.DateTimePicker();
            this.cbo_type = new System.Windows.Forms.ComboBox();
            this.cbo_dep = new System.Windows.Forms.ComboBox();
            this.lbl_type = new System.Windows.Forms.Label();
            this.lbl_dep = new System.Windows.Forms.Label();
            this.tlp_export_reload_button_container = new System.Windows.Forms.TableLayoutPanel();
            this.btn_reload = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.strip_info = new System.Windows.Forms.StatusStrip();
            this.tss_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgv_flag = new System.Windows.Forms.DataGridView();
            this.pnl_group_container.SuspendLayout();
            this.gb_flagform_container.SuspendLayout();
            this.tlp_flag_form_container.SuspendLayout();
            this.tlp_seen_unseen_container.SuspendLayout();
            this.gb_filter_export_container.SuspendLayout();
            this.tlp_filter_export_container.SuspendLayout();
            this.tlp_export_reload_button_container.SuspendLayout();
            this.strip_info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_flag)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_group_container
            // 
            this.pnl_group_container.Controls.Add(this.gb_flagform_container);
            this.pnl_group_container.Controls.Add(this.gb_filter_export_container);
            this.pnl_group_container.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_group_container.Location = new System.Drawing.Point(0, 0);
            this.pnl_group_container.Name = "pnl_group_container";
            this.pnl_group_container.Padding = new System.Windows.Forms.Padding(5);
            this.pnl_group_container.Size = new System.Drawing.Size(200, 551);
            this.pnl_group_container.TabIndex = 0;
            // 
            // gb_flagform_container
            // 
            this.gb_flagform_container.Controls.Add(this.tlp_flag_form_container);
            this.gb_flagform_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_flagform_container.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_flagform_container.Location = new System.Drawing.Point(5, 184);
            this.gb_flagform_container.Name = "gb_flagform_container";
            this.gb_flagform_container.Size = new System.Drawing.Size(190, 362);
            this.gb_flagform_container.TabIndex = 1;
            this.gb_flagform_container.TabStop = false;
            this.gb_flagform_container.Text = "Flagging Form";
            // 
            // tlp_flag_form_container
            // 
            this.tlp_flag_form_container.ColumnCount = 1;
            this.tlp_flag_form_container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_flag_form_container.Controls.Add(this.lbl_client, 0, 0);
            this.tlp_flag_form_container.Controls.Add(this.lbl_filename, 0, 2);
            this.tlp_flag_form_container.Controls.Add(this.lbl_problem, 0, 4);
            this.tlp_flag_form_container.Controls.Add(this.cbo_client, 0, 1);
            this.tlp_flag_form_container.Controls.Add(this.txt_filename, 0, 3);
            this.tlp_flag_form_container.Controls.Add(this.rtxt_problem, 0, 5);
            this.tlp_flag_form_container.Controls.Add(this.btn_save, 0, 6);
            this.tlp_flag_form_container.Controls.Add(this.btn_delete, 0, 7);
            this.tlp_flag_form_container.Controls.Add(this.tlp_seen_unseen_container, 0, 8);
            this.tlp_flag_form_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_flag_form_container.Location = new System.Drawing.Point(3, 16);
            this.tlp_flag_form_container.Name = "tlp_flag_form_container";
            this.tlp_flag_form_container.RowCount = 9;
            this.tlp_flag_form_container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlp_flag_form_container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_flag_form_container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlp_flag_form_container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_flag_form_container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlp_flag_form_container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_flag_form_container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tlp_flag_form_container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tlp_flag_form_container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tlp_flag_form_container.Size = new System.Drawing.Size(184, 343);
            this.tlp_flag_form_container.TabIndex = 0;
            // 
            // lbl_client
            // 
            this.lbl_client.AutoSize = true;
            this.lbl_client.Location = new System.Drawing.Point(3, 0);
            this.lbl_client.Name = "lbl_client";
            this.lbl_client.Size = new System.Drawing.Size(43, 13);
            this.lbl_client.TabIndex = 0;
            this.lbl_client.Text = "Client:";
            // 
            // lbl_filename
            // 
            this.lbl_filename.AutoSize = true;
            this.lbl_filename.Location = new System.Drawing.Point(3, 45);
            this.lbl_filename.Name = "lbl_filename";
            this.lbl_filename.Size = new System.Drawing.Size(61, 13);
            this.lbl_filename.TabIndex = 1;
            this.lbl_filename.Text = "Filename:";
            // 
            // lbl_problem
            // 
            this.lbl_problem.AutoSize = true;
            this.lbl_problem.Location = new System.Drawing.Point(3, 90);
            this.lbl_problem.Name = "lbl_problem";
            this.lbl_problem.Size = new System.Drawing.Size(56, 13);
            this.lbl_problem.TabIndex = 2;
            this.lbl_problem.Text = "Problem:";
            // 
            // cbo_client
            // 
            this.cbo_client.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbo_client.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_client.FormattingEnabled = true;
            this.cbo_client.Location = new System.Drawing.Point(3, 18);
            this.cbo_client.Name = "cbo_client";
            this.cbo_client.Size = new System.Drawing.Size(178, 21);
            this.cbo_client.TabIndex = 3;
            this.cbo_client.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // txt_filename
            // 
            this.txt_filename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_filename.Location = new System.Drawing.Point(3, 63);
            this.txt_filename.Name = "txt_filename";
            this.txt_filename.Size = new System.Drawing.Size(178, 20);
            this.txt_filename.TabIndex = 4;
            this.txt_filename.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // rtxt_problem
            // 
            this.rtxt_problem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_problem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_problem.Location = new System.Drawing.Point(3, 108);
            this.rtxt_problem.Name = "rtxt_problem";
            this.rtxt_problem.Size = new System.Drawing.Size(178, 133);
            this.rtxt_problem.TabIndex = 5;
            this.rtxt_problem.Text = "";
            this.rtxt_problem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // btn_save
            // 
            this.btn_save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(3, 247);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(178, 27);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(3, 280);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(178, 27);
            this.btn_delete.TabIndex = 7;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.ActionBtn_Click);
            // 
            // tlp_seen_unseen_container
            // 
            this.tlp_seen_unseen_container.ColumnCount = 2;
            this.tlp_seen_unseen_container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_seen_unseen_container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_seen_unseen_container.Controls.Add(this.btn_seen, 0, 0);
            this.tlp_seen_unseen_container.Controls.Add(this.btn_unseen, 1, 0);
            this.tlp_seen_unseen_container.Location = new System.Drawing.Point(0, 310);
            this.tlp_seen_unseen_container.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_seen_unseen_container.Name = "tlp_seen_unseen_container";
            this.tlp_seen_unseen_container.RowCount = 1;
            this.tlp_seen_unseen_container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_seen_unseen_container.Size = new System.Drawing.Size(184, 33);
            this.tlp_seen_unseen_container.TabIndex = 8;
            // 
            // btn_seen
            // 
            this.btn_seen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_seen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_seen.Location = new System.Drawing.Point(3, 3);
            this.btn_seen.Name = "btn_seen";
            this.btn_seen.Size = new System.Drawing.Size(86, 27);
            this.btn_seen.TabIndex = 0;
            this.btn_seen.Text = "Seen";
            this.btn_seen.UseVisualStyleBackColor = true;
            this.btn_seen.Click += new System.EventHandler(this.ActionBtn_Click);
            // 
            // btn_unseen
            // 
            this.btn_unseen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_unseen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_unseen.Location = new System.Drawing.Point(95, 3);
            this.btn_unseen.Name = "btn_unseen";
            this.btn_unseen.Size = new System.Drawing.Size(86, 27);
            this.btn_unseen.TabIndex = 1;
            this.btn_unseen.Text = "Unseen";
            this.btn_unseen.UseVisualStyleBackColor = true;
            this.btn_unseen.Click += new System.EventHandler(this.ActionBtn_Click);
            // 
            // gb_filter_export_container
            // 
            this.gb_filter_export_container.Controls.Add(this.tlp_filter_export_container);
            this.gb_filter_export_container.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_filter_export_container.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_filter_export_container.Location = new System.Drawing.Point(5, 5);
            this.gb_filter_export_container.Name = "gb_filter_export_container";
            this.gb_filter_export_container.Padding = new System.Windows.Forms.Padding(5);
            this.gb_filter_export_container.Size = new System.Drawing.Size(190, 179);
            this.gb_filter_export_container.TabIndex = 0;
            this.gb_filter_export_container.TabStop = false;
            this.gb_filter_export_container.Text = "Filter and Export";
            // 
            // tlp_filter_export_container
            // 
            this.tlp_filter_export_container.ColumnCount = 1;
            this.tlp_filter_export_container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_filter_export_container.Controls.Add(this.dtpicker, 0, 0);
            this.tlp_filter_export_container.Controls.Add(this.cbo_type, 0, 2);
            this.tlp_filter_export_container.Controls.Add(this.cbo_dep, 0, 4);
            this.tlp_filter_export_container.Controls.Add(this.lbl_type, 0, 1);
            this.tlp_filter_export_container.Controls.Add(this.lbl_dep, 0, 3);
            this.tlp_filter_export_container.Controls.Add(this.tlp_export_reload_button_container, 0, 5);
            this.tlp_filter_export_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_filter_export_container.Location = new System.Drawing.Point(5, 18);
            this.tlp_filter_export_container.Name = "tlp_filter_export_container";
            this.tlp_filter_export_container.RowCount = 6;
            this.tlp_filter_export_container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_filter_export_container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlp_filter_export_container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_filter_export_container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlp_filter_export_container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_filter_export_container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_filter_export_container.Size = new System.Drawing.Size(180, 156);
            this.tlp_filter_export_container.TabIndex = 0;
            // 
            // dtpicker
            // 
            this.dtpicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpicker.Location = new System.Drawing.Point(3, 3);
            this.dtpicker.Name = "dtpicker";
            this.dtpicker.Size = new System.Drawing.Size(174, 20);
            this.dtpicker.TabIndex = 0;
            this.dtpicker.ValueChanged += new System.EventHandler(this.dtpicker_ValueChanged);
            // 
            // cbo_type
            // 
            this.cbo_type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbo_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_type.FormattingEnabled = true;
            this.cbo_type.Location = new System.Drawing.Point(3, 48);
            this.cbo_type.Name = "cbo_type";
            this.cbo_type.Size = new System.Drawing.Size(174, 21);
            this.cbo_type.TabIndex = 1;
            // 
            // cbo_dep
            // 
            this.cbo_dep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbo_dep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_dep.FormattingEnabled = true;
            this.cbo_dep.Location = new System.Drawing.Point(3, 93);
            this.cbo_dep.Name = "cbo_dep";
            this.cbo_dep.Size = new System.Drawing.Size(174, 21);
            this.cbo_dep.TabIndex = 2;
            // 
            // lbl_type
            // 
            this.lbl_type.AutoSize = true;
            this.lbl_type.Location = new System.Drawing.Point(3, 30);
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(39, 13);
            this.lbl_type.TabIndex = 3;
            this.lbl_type.Text = "Type:";
            // 
            // lbl_dep
            // 
            this.lbl_dep.AutoSize = true;
            this.lbl_dep.Location = new System.Drawing.Point(3, 75);
            this.lbl_dep.Name = "lbl_dep";
            this.lbl_dep.Size = new System.Drawing.Size(76, 13);
            this.lbl_dep.TabIndex = 4;
            this.lbl_dep.Text = "Department:";
            // 
            // tlp_export_reload_button_container
            // 
            this.tlp_export_reload_button_container.ColumnCount = 2;
            this.tlp_export_reload_button_container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_export_reload_button_container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_export_reload_button_container.Controls.Add(this.btn_reload, 1, 0);
            this.tlp_export_reload_button_container.Controls.Add(this.btn_export, 0, 0);
            this.tlp_export_reload_button_container.Location = new System.Drawing.Point(0, 123);
            this.tlp_export_reload_button_container.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.tlp_export_reload_button_container.Name = "tlp_export_reload_button_container";
            this.tlp_export_reload_button_container.RowCount = 1;
            this.tlp_export_reload_button_container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_export_reload_button_container.Size = new System.Drawing.Size(180, 33);
            this.tlp_export_reload_button_container.TabIndex = 5;
            // 
            // btn_reload
            // 
            this.btn_reload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_reload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reload.Location = new System.Drawing.Point(93, 3);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(84, 27);
            this.btn_reload.TabIndex = 1;
            this.btn_reload.Text = "Reload";
            this.btn_reload.UseVisualStyleBackColor = true;
            this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click);
            // 
            // btn_export
            // 
            this.btn_export.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_export.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.Location = new System.Drawing.Point(3, 3);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(84, 27);
            this.btn_export.TabIndex = 0;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // strip_info
            // 
            this.strip_info.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tss_status});
            this.strip_info.Location = new System.Drawing.Point(0, 551);
            this.strip_info.Name = "strip_info";
            this.strip_info.Size = new System.Drawing.Size(1072, 22);
            this.strip_info.TabIndex = 1;
            this.strip_info.Text = "statusStrip1";
            // 
            // tss_status
            // 
            this.tss_status.Name = "tss_status";
            this.tss_status.Size = new System.Drawing.Size(109, 17);
            this.tss_status.Text = "toolStripStatusLabel1";
            // 
            // dgv_flag
            // 
            this.dgv_flag.AllowUserToAddRows = false;
            this.dgv_flag.AllowUserToDeleteRows = false;
            this.dgv_flag.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_flag.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_flag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_flag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_flag.Location = new System.Drawing.Point(200, 0);
            this.dgv_flag.Name = "dgv_flag";
            this.dgv_flag.ReadOnly = true;
            this.dgv_flag.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_flag.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_flag.Size = new System.Drawing.Size(872, 551);
            this.dgv_flag.TabIndex = 2;
            this.dgv_flag.Sorted += new System.EventHandler(this.dgv_flag_Sorted);
            // 
            // frm_flagging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 573);
            this.Controls.Add(this.dgv_flag);
            this.Controls.Add(this.pnl_group_container);
            this.Controls.Add(this.strip_info);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1080, 600);
            this.Name = "frm_flagging";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "";
            this.Text = "d";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_flagging_FormClosing);
            this.pnl_group_container.ResumeLayout(false);
            this.gb_flagform_container.ResumeLayout(false);
            this.tlp_flag_form_container.ResumeLayout(false);
            this.tlp_flag_form_container.PerformLayout();
            this.tlp_seen_unseen_container.ResumeLayout(false);
            this.gb_filter_export_container.ResumeLayout(false);
            this.tlp_filter_export_container.ResumeLayout(false);
            this.tlp_filter_export_container.PerformLayout();
            this.tlp_export_reload_button_container.ResumeLayout(false);
            this.strip_info.ResumeLayout(false);
            this.strip_info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_flag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_group_container;
        private System.Windows.Forms.GroupBox gb_filter_export_container;
        private System.Windows.Forms.GroupBox gb_flagform_container;
        private System.Windows.Forms.StatusStrip strip_info;
        private System.Windows.Forms.DataGridView dgv_flag;
        private System.Windows.Forms.TableLayoutPanel tlp_filter_export_container;
        private System.Windows.Forms.DateTimePicker dtpicker;
        private System.Windows.Forms.ComboBox cbo_type;
        private System.Windows.Forms.ComboBox cbo_dep;
        private System.Windows.Forms.Label lbl_type;
        private System.Windows.Forms.Label lbl_dep;
        private System.Windows.Forms.TableLayoutPanel tlp_export_reload_button_container;
        private System.Windows.Forms.Button btn_reload;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.TableLayoutPanel tlp_flag_form_container;
        private System.Windows.Forms.Label lbl_client;
        private System.Windows.Forms.Label lbl_filename;
        private System.Windows.Forms.Label lbl_problem;
        private System.Windows.Forms.ComboBox cbo_client;
        private System.Windows.Forms.TextBox txt_filename;
        private System.Windows.Forms.RichTextBox rtxt_problem;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.TableLayoutPanel tlp_seen_unseen_container;
        private System.Windows.Forms.Button btn_seen;
        private System.Windows.Forms.Button btn_unseen;
        private System.Windows.Forms.ToolStripStatusLabel tss_status;
    }
}