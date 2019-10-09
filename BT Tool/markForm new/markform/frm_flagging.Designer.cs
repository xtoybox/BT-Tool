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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_flagging));
            this.pnl_group_container = new System.Windows.Forms.Panel();
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
            this.label1 = new System.Windows.Forms.Label();
            this.tlp_filter_export = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_dep = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpicker = new System.Windows.Forms.DateTimePicker();
            this.lbl_type = new System.Windows.Forms.Label();
            this.cbo_type = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_reload = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.strip_info = new System.Windows.Forms.StatusStrip();
            this.tss_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgv_flag = new System.Windows.Forms.DataGridView();
            this.pnl_group_container.SuspendLayout();
            this.tlp_flag_form_container.SuspendLayout();
            this.tlp_seen_unseen_container.SuspendLayout();
            this.tlp_filter_export.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.strip_info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_flag)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_group_container
            // 
            this.pnl_group_container.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(47)))), ((int)(((byte)(59)))));
            this.pnl_group_container.Controls.Add(this.tlp_flag_form_container);
            this.pnl_group_container.Controls.Add(this.label1);
            this.pnl_group_container.Controls.Add(this.tlp_filter_export);
            this.pnl_group_container.Controls.Add(this.label4);
            this.pnl_group_container.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_group_container.ForeColor = System.Drawing.Color.White;
            this.pnl_group_container.Location = new System.Drawing.Point(0, 0);
            this.pnl_group_container.Name = "pnl_group_container";
            this.pnl_group_container.Size = new System.Drawing.Size(200, 551);
            this.pnl_group_container.TabIndex = 0;
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
            this.tlp_flag_form_container.ForeColor = System.Drawing.Color.White;
            this.tlp_flag_form_container.Location = new System.Drawing.Point(0, 240);
            this.tlp_flag_form_container.Name = "tlp_flag_form_container";
            this.tlp_flag_form_container.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
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
            this.tlp_flag_form_container.Size = new System.Drawing.Size(200, 311);
            this.tlp_flag_form_container.TabIndex = 0;
            // 
            // lbl_client
            // 
            this.lbl_client.AutoSize = true;
            this.lbl_client.Location = new System.Drawing.Point(8, 5);
            this.lbl_client.Name = "lbl_client";
            this.lbl_client.Size = new System.Drawing.Size(39, 13);
            this.lbl_client.TabIndex = 0;
            this.lbl_client.Text = "Client:";
            // 
            // lbl_filename
            // 
            this.lbl_filename.AutoSize = true;
            this.lbl_filename.Location = new System.Drawing.Point(8, 50);
            this.lbl_filename.Name = "lbl_filename";
            this.lbl_filename.Size = new System.Drawing.Size(56, 13);
            this.lbl_filename.TabIndex = 1;
            this.lbl_filename.Text = "Filename:";
            // 
            // lbl_problem
            // 
            this.lbl_problem.AutoSize = true;
            this.lbl_problem.Location = new System.Drawing.Point(8, 95);
            this.lbl_problem.Name = "lbl_problem";
            this.lbl_problem.Size = new System.Drawing.Size(52, 13);
            this.lbl_problem.TabIndex = 2;
            this.lbl_problem.Text = "Problem:";
            // 
            // cbo_client
            // 
            this.cbo_client.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbo_client.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_client.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_client.FormattingEnabled = true;
            this.cbo_client.Location = new System.Drawing.Point(8, 23);
            this.cbo_client.Name = "cbo_client";
            this.cbo_client.Size = new System.Drawing.Size(184, 21);
            this.cbo_client.TabIndex = 3;
            this.cbo_client.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // txt_filename
            // 
            this.txt_filename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_filename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_filename.Location = new System.Drawing.Point(8, 68);
            this.txt_filename.Name = "txt_filename";
            this.txt_filename.Size = new System.Drawing.Size(184, 20);
            this.txt_filename.TabIndex = 4;
            this.txt_filename.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // rtxt_problem
            // 
            this.rtxt_problem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxt_problem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_problem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_problem.Location = new System.Drawing.Point(8, 113);
            this.rtxt_problem.Name = "rtxt_problem";
            this.rtxt_problem.Size = new System.Drawing.Size(184, 96);
            this.rtxt_problem.TabIndex = 5;
            this.rtxt_problem.Text = "";
            this.rtxt_problem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(58)))), ((int)(((byte)(85)))));
            this.btn_save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_save.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(31)))), ((int)(((byte)(39)))));
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(8, 215);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(184, 27);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(58)))), ((int)(((byte)(85)))));
            this.btn_delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_delete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(31)))), ((int)(((byte)(39)))));
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.White;
            this.btn_delete.Location = new System.Drawing.Point(8, 248);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(184, 27);
            this.btn_delete.TabIndex = 7;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.ActionBtn_Click);
            // 
            // tlp_seen_unseen_container
            // 
            this.tlp_seen_unseen_container.ColumnCount = 2;
            this.tlp_seen_unseen_container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_seen_unseen_container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_seen_unseen_container.Controls.Add(this.btn_seen, 0, 0);
            this.tlp_seen_unseen_container.Controls.Add(this.btn_unseen, 1, 0);
            this.tlp_seen_unseen_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_seen_unseen_container.Location = new System.Drawing.Point(5, 278);
            this.tlp_seen_unseen_container.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_seen_unseen_container.Name = "tlp_seen_unseen_container";
            this.tlp_seen_unseen_container.RowCount = 1;
            this.tlp_seen_unseen_container.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_seen_unseen_container.Size = new System.Drawing.Size(190, 33);
            this.tlp_seen_unseen_container.TabIndex = 8;
            // 
            // btn_seen
            // 
            this.btn_seen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(58)))), ((int)(((byte)(85)))));
            this.btn_seen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_seen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(31)))), ((int)(((byte)(39)))));
            this.btn_seen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_seen.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_seen.ForeColor = System.Drawing.Color.White;
            this.btn_seen.Location = new System.Drawing.Point(3, 3);
            this.btn_seen.Name = "btn_seen";
            this.btn_seen.Size = new System.Drawing.Size(89, 27);
            this.btn_seen.TabIndex = 0;
            this.btn_seen.Text = "Seen";
            this.btn_seen.UseVisualStyleBackColor = false;
            this.btn_seen.Click += new System.EventHandler(this.ActionBtn_Click);
            // 
            // btn_unseen
            // 
            this.btn_unseen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(58)))), ((int)(((byte)(85)))));
            this.btn_unseen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_unseen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(31)))), ((int)(((byte)(39)))));
            this.btn_unseen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_unseen.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_unseen.ForeColor = System.Drawing.Color.White;
            this.btn_unseen.Location = new System.Drawing.Point(98, 3);
            this.btn_unseen.Name = "btn_unseen";
            this.btn_unseen.Size = new System.Drawing.Size(89, 27);
            this.btn_unseen.TabIndex = 1;
            this.btn_unseen.Text = "Unseen";
            this.btn_unseen.UseVisualStyleBackColor = false;
            this.btn_unseen.Click += new System.EventHandler(this.ActionBtn_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(31)))), ((int)(((byte)(39)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flagging Form";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlp_filter_export
            // 
            this.tlp_filter_export.ColumnCount = 1;
            this.tlp_filter_export.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_filter_export.Controls.Add(this.label2, 0, 0);
            this.tlp_filter_export.Controls.Add(this.cbo_dep, 0, 5);
            this.tlp_filter_export.Controls.Add(this.label3, 0, 4);
            this.tlp_filter_export.Controls.Add(this.dtpicker, 0, 1);
            this.tlp_filter_export.Controls.Add(this.lbl_type, 0, 2);
            this.tlp_filter_export.Controls.Add(this.cbo_type, 0, 3);
            this.tlp_filter_export.Controls.Add(this.tableLayoutPanel2, 0, 6);
            this.tlp_filter_export.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlp_filter_export.ForeColor = System.Drawing.Color.White;
            this.tlp_filter_export.Location = new System.Drawing.Point(0, 30);
            this.tlp_filter_export.Name = "tlp_filter_export";
            this.tlp_filter_export.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.tlp_filter_export.RowCount = 7;
            this.tlp_filter_export.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlp_filter_export.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_filter_export.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlp_filter_export.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_filter_export.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlp_filter_export.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_filter_export.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_filter_export.Size = new System.Drawing.Size(200, 180);
            this.tlp_filter_export.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date:";
            // 
            // cbo_dep
            // 
            this.cbo_dep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbo_dep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_dep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_dep.FormattingEnabled = true;
            this.cbo_dep.Location = new System.Drawing.Point(8, 113);
            this.cbo_dep.Name = "cbo_dep";
            this.cbo_dep.Size = new System.Drawing.Size(184, 21);
            this.cbo_dep.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Department:";
            // 
            // dtpicker
            // 
            this.dtpicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpicker.Location = new System.Drawing.Point(8, 23);
            this.dtpicker.Name = "dtpicker";
            this.dtpicker.Size = new System.Drawing.Size(184, 20);
            this.dtpicker.TabIndex = 0;
            this.dtpicker.ValueChanged += new System.EventHandler(this.dtpicker_ValueChanged);
            // 
            // lbl_type
            // 
            this.lbl_type.AutoSize = true;
            this.lbl_type.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_type.ForeColor = System.Drawing.Color.White;
            this.lbl_type.Location = new System.Drawing.Point(8, 50);
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(34, 13);
            this.lbl_type.TabIndex = 3;
            this.lbl_type.Text = "Type:";
            // 
            // cbo_type
            // 
            this.cbo_type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbo_type.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbo_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_type.FormattingEnabled = true;
            this.cbo_type.Location = new System.Drawing.Point(8, 68);
            this.cbo_type.Name = "cbo_type";
            this.cbo_type.Size = new System.Drawing.Size(184, 21);
            this.cbo_type.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btn_export, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_reload, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 143);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(184, 34);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // btn_export
            // 
            this.btn_export.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(58)))), ((int)(((byte)(85)))));
            this.btn_export.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_export.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(31)))), ((int)(((byte)(39)))));
            this.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_export.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.ForeColor = System.Drawing.Color.White;
            this.btn_export.Location = new System.Drawing.Point(3, 3);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(86, 28);
            this.btn_export.TabIndex = 0;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = false;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_reload
            // 
            this.btn_reload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(58)))), ((int)(((byte)(85)))));
            this.btn_reload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_reload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(31)))), ((int)(((byte)(39)))));
            this.btn_reload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reload.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reload.ForeColor = System.Drawing.Color.White;
            this.btn_reload.Location = new System.Drawing.Point(95, 3);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(86, 28);
            this.btn_reload.TabIndex = 1;
            this.btn_reload.Text = "Reload";
            this.btn_reload.UseVisualStyleBackColor = false;
            this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(31)))), ((int)(((byte)(39)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 30);
            this.label4.TabIndex = 1;
            this.label4.Text = "Filter / Export";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // strip_info
            // 
            this.strip_info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(58)))), ((int)(((byte)(85)))));
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
            this.tss_status.ForeColor = System.Drawing.Color.White;
            this.tss_status.Name = "tss_status";
            this.tss_status.Size = new System.Drawing.Size(109, 17);
            this.tss_status.Text = "toolStripStatusLabel1";
            // 
            // dgv_flag
            // 
            this.dgv_flag.AllowUserToAddRows = false;
            this.dgv_flag.AllowUserToDeleteRows = false;
            this.dgv_flag.AllowUserToResizeRows = false;
            this.dgv_flag.BackgroundColor = System.Drawing.Color.White;
            this.dgv_flag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_flag.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(57)))), ((int)(((byte)(84)))));
            this.dgv_flag.RowsDefaultCellStyle = dataGridViewCellStyle2;
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
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1080, 600);
            this.Name = "frm_flagging";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Flagging";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_flagging_FormClosing);
            this.Load += new System.EventHandler(this.frm_flagging_Load);
            this.pnl_group_container.ResumeLayout(false);
            this.tlp_flag_form_container.ResumeLayout(false);
            this.tlp_flag_form_container.PerformLayout();
            this.tlp_seen_unseen_container.ResumeLayout(false);
            this.tlp_filter_export.ResumeLayout(false);
            this.tlp_filter_export.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.strip_info.ResumeLayout(false);
            this.strip_info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_flag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_group_container;
        private System.Windows.Forms.StatusStrip strip_info;
        private System.Windows.Forms.DataGridView dgv_flag;
        private System.Windows.Forms.DateTimePicker dtpicker;
        private System.Windows.Forms.ComboBox cbo_type;
        private System.Windows.Forms.ComboBox cbo_dep;
        private System.Windows.Forms.Label lbl_type;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tlp_filter_export;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label4;
    }
}