namespace markform
{
    partial class frm_return_file
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_return_file));
            this.sb_info = new System.Windows.Forms.StatusStrip();
            this.tss_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.tss_status2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnl_content_container = new System.Windows.Forms.Panel();
            this.dgv_return = new System.Windows.Forms.DataGridView();
            this.gb_filter_export_container = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_export = new System.Windows.Forms.Button();
            this.btn_reload = new System.Windows.Forms.Button();
            this.btn_unseen = new System.Windows.Forms.Button();
            this.btn_seen = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.dtpicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_type = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_dep = new System.Windows.Forms.ComboBox();
            this.gb_form_container = new System.Windows.Forms.GroupBox();
            this.pic_prank = new System.Windows.Forms.PictureBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.rtxt_com3 = new System.Windows.Forms.RichTextBox();
            this.rtxt_com2 = new System.Windows.Forms.RichTextBox();
            this.lbl_comment = new System.Windows.Forms.Label();
            this.lbl_sbs_feed = new System.Windows.Forms.Label();
            this.lbl_prbet_4 = new System.Windows.Forms.Label();
            this.rtxt_com1 = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_prbet_1 = new System.Windows.Forms.Label();
            this.cbo_second_assigned = new System.Windows.Forms.ComboBox();
            this.bl_fxby = new System.Windows.Forms.Label();
            this.cbo_fxby = new System.Windows.Forms.ComboBox();
            this.lbl_cl = new System.Windows.Forms.Label();
            this.lbl_ac = new System.Windows.Forms.Label();
            this.txt_ac = new System.Windows.Forms.TextBox();
            this.lbl_client = new System.Windows.Forms.Label();
            this.lbl_sp = new System.Windows.Forms.Label();
            this.txt_sp = new System.Windows.Forms.TextBox();
            this.lbl_fn = new System.Windows.Forms.Label();
            this.txt_fn = new System.Windows.Forms.TextBox();
            this.lbl_prbet_3 = new System.Windows.Forms.Label();
            this.cbo_actby = new System.Windows.Forms.ComboBox();
            this.cbo_cl = new System.Windows.Forms.ComboBox();
            this.cbo_name = new System.Windows.Forms.ComboBox();
            this.lbl_prbet_2 = new System.Windows.Forms.Label();
            this.sb_info.SuspendLayout();
            this.pnl_content_container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_return)).BeginInit();
            this.gb_filter_export_container.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gb_form_container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_prank)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sb_info
            // 
            this.sb_info.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tss_status,
            this.tss_status2});
            this.sb_info.Location = new System.Drawing.Point(0, 551);
            this.sb_info.Name = "sb_info";
            this.sb_info.Size = new System.Drawing.Size(1072, 22);
            this.sb_info.TabIndex = 0;
            this.sb_info.Text = "statusStrip1";
            // 
            // tss_status
            // 
            this.tss_status.Name = "tss_status";
            this.tss_status.Size = new System.Drawing.Size(42, 17);
            this.tss_status.Text = "Ready.";
            // 
            // tss_status2
            // 
            this.tss_status2.Name = "tss_status2";
            this.tss_status2.Size = new System.Drawing.Size(109, 17);
            this.tss_status2.Text = "toolStripStatusLabel1";
            this.tss_status2.Visible = false;
            // 
            // pnl_content_container
            // 
            this.pnl_content_container.Controls.Add(this.dgv_return);
            this.pnl_content_container.Controls.Add(this.gb_filter_export_container);
            this.pnl_content_container.Controls.Add(this.gb_form_container);
            this.pnl_content_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_content_container.Location = new System.Drawing.Point(0, 0);
            this.pnl_content_container.Name = "pnl_content_container";
            this.pnl_content_container.Padding = new System.Windows.Forms.Padding(10);
            this.pnl_content_container.Size = new System.Drawing.Size(1072, 551);
            this.pnl_content_container.TabIndex = 1;
            // 
            // dgv_return
            // 
            this.dgv_return.AllowUserToAddRows = false;
            this.dgv_return.AllowUserToDeleteRows = false;
            this.dgv_return.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_return.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_return.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_return.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_return.Location = new System.Drawing.Point(10, 259);
            this.dgv_return.Name = "dgv_return";
            this.dgv_return.ReadOnly = true;
            this.dgv_return.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_return.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_return.Size = new System.Drawing.Size(1052, 282);
            this.dgv_return.TabIndex = 20;
            this.dgv_return.Sorted += new System.EventHandler(this.dgv_return_Sorted);
            // 
            // gb_filter_export_container
            // 
            this.gb_filter_export_container.Controls.Add(this.tableLayoutPanel1);
            this.gb_filter_export_container.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_filter_export_container.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_filter_export_container.Location = new System.Drawing.Point(10, 208);
            this.gb_filter_export_container.Name = "gb_filter_export_container";
            this.gb_filter_export_container.Size = new System.Drawing.Size(1052, 51);
            this.gb_filter_export_container.TabIndex = 0;
            this.gb_filter_export_container.TabStop = false;
            this.gb_filter_export_container.Text = "Filter and Export";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpicker, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbo_type, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbo_dep, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1046, 32);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_export);
            this.flowLayoutPanel1.Controls.Add(this.btn_reload);
            this.flowLayoutPanel1.Controls.Add(this.btn_unseen);
            this.flowLayoutPanel1.Controls.Add(this.btn_seen);
            this.flowLayoutPanel1.Controls.Add(this.btn_del);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(433, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(610, 29);
            this.flowLayoutPanel1.TabIndex = 20;
            // 
            // btn_export
            // 
            this.btn_export.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.Location = new System.Drawing.Point(3, 3);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(55, 21);
            this.btn_export.TabIndex = 3;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // btn_reload
            // 
            this.btn_reload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reload.Location = new System.Drawing.Point(64, 3);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(55, 21);
            this.btn_reload.TabIndex = 4;
            this.btn_reload.Text = "Reload";
            this.btn_reload.UseVisualStyleBackColor = true;
            this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click);
            // 
            // btn_unseen
            // 
            this.btn_unseen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_unseen.Location = new System.Drawing.Point(125, 3);
            this.btn_unseen.Name = "btn_unseen";
            this.btn_unseen.Size = new System.Drawing.Size(55, 21);
            this.btn_unseen.TabIndex = 18;
            this.btn_unseen.Text = "Unseen";
            this.btn_unseen.UseVisualStyleBackColor = true;
            this.btn_unseen.Click += new System.EventHandler(this.ActionBtn_Click);
            // 
            // btn_seen
            // 
            this.btn_seen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_seen.Location = new System.Drawing.Point(186, 3);
            this.btn_seen.Name = "btn_seen";
            this.btn_seen.Size = new System.Drawing.Size(55, 21);
            this.btn_seen.TabIndex = 17;
            this.btn_seen.Text = "Seen";
            this.btn_seen.UseVisualStyleBackColor = true;
            this.btn_seen.Click += new System.EventHandler(this.ActionBtn_Click);
            // 
            // btn_del
            // 
            this.btn_del.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_del.Location = new System.Drawing.Point(247, 3);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(55, 21);
            this.btn_del.TabIndex = 19;
            this.btn_del.Text = "Delete";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.ActionBtn_Click);
            // 
            // dtpicker
            // 
            this.dtpicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpicker.Location = new System.Drawing.Point(3, 3);
            this.dtpicker.Name = "dtpicker";
            this.dtpicker.Size = new System.Drawing.Size(94, 20);
            this.dtpicker.TabIndex = 0;
            this.dtpicker.ValueChanged += new System.EventHandler(this.dtpicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type:";
            // 
            // cbo_type
            // 
            this.cbo_type.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbo_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_type.FormattingEnabled = true;
            this.cbo_type.Location = new System.Drawing.Point(148, 3);
            this.cbo_type.Name = "cbo_type";
            this.cbo_type.Size = new System.Drawing.Size(94, 21);
            this.cbo_type.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Department:";
            // 
            // cbo_dep
            // 
            this.cbo_dep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbo_dep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_dep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_dep.FormattingEnabled = true;
            this.cbo_dep.Location = new System.Drawing.Point(333, 3);
            this.cbo_dep.Name = "cbo_dep";
            this.cbo_dep.Size = new System.Drawing.Size(94, 21);
            this.cbo_dep.TabIndex = 2;
            // 
            // gb_form_container
            // 
            this.gb_form_container.Controls.Add(this.pic_prank);
            this.gb_form_container.Controls.Add(this.btn_save);
            this.gb_form_container.Controls.Add(this.tableLayoutPanel3);
            this.gb_form_container.Controls.Add(this.tableLayoutPanel2);
            this.gb_form_container.Controls.Add(this.cbo_cl);
            this.gb_form_container.Controls.Add(this.cbo_name);
            this.gb_form_container.Controls.Add(this.lbl_prbet_2);
            this.gb_form_container.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_form_container.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_form_container.Location = new System.Drawing.Point(10, 10);
            this.gb_form_container.Name = "gb_form_container";
            this.gb_form_container.Size = new System.Drawing.Size(1052, 198);
            this.gb_form_container.TabIndex = 1;
            this.gb_form_container.TabStop = false;
            this.gb_form_container.Text = "Return Form";
            // 
            // pic_prank
            // 
            this.pic_prank.BackgroundImage = global::markform.Properties.Resources.kayako;
            this.pic_prank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_prank.Location = new System.Drawing.Point(1019, 13);
            this.pic_prank.Name = "pic_prank";
            this.pic_prank.Size = new System.Drawing.Size(102, 177);
            this.pic_prank.TabIndex = 6;
            this.pic_prank.TabStop = false;
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(799, 163);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(119, 28);
            this.btn_save.TabIndex = 16;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.Controls.Add(this.rtxt_com3, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.rtxt_com2, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lbl_comment, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_sbs_feed, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_prbet_4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.rtxt_com1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(346, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(447, 179);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // rtxt_com3
            // 
            this.rtxt_com3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_com3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_com3.Location = new System.Drawing.Point(300, 18);
            this.rtxt_com3.Name = "rtxt_com3";
            this.rtxt_com3.Size = new System.Drawing.Size(144, 158);
            this.rtxt_com3.TabIndex = 15;
            this.rtxt_com3.Text = "";
            this.rtxt_com3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // rtxt_com2
            // 
            this.rtxt_com2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_com2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_com2.Location = new System.Drawing.Point(151, 18);
            this.rtxt_com2.Name = "rtxt_com2";
            this.rtxt_com2.Size = new System.Drawing.Size(143, 158);
            this.rtxt_com2.TabIndex = 14;
            this.rtxt_com2.Text = "";
            this.rtxt_com2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // lbl_comment
            // 
            this.lbl_comment.AutoSize = true;
            this.lbl_comment.Location = new System.Drawing.Point(300, 0);
            this.lbl_comment.Name = "lbl_comment";
            this.lbl_comment.Size = new System.Drawing.Size(62, 13);
            this.lbl_comment.TabIndex = 3;
            this.lbl_comment.Text = "Comment:";
            // 
            // lbl_sbs_feed
            // 
            this.lbl_sbs_feed.AutoSize = true;
            this.lbl_sbs_feed.Location = new System.Drawing.Point(151, 0);
            this.lbl_sbs_feed.Name = "lbl_sbs_feed";
            this.lbl_sbs_feed.Size = new System.Drawing.Size(140, 13);
            this.lbl_sbs_feed.TabIndex = 2;
            this.lbl_sbs_feed.Text = "Side-by-side Feedback:";
            // 
            // lbl_prbet_4
            // 
            this.lbl_prbet_4.AutoSize = true;
            this.lbl_prbet_4.Location = new System.Drawing.Point(3, 0);
            this.lbl_prbet_4.Name = "lbl_prbet_4";
            this.lbl_prbet_4.Size = new System.Drawing.Size(82, 13);
            this.lbl_prbet_4.TabIndex = 0;
            this.lbl_prbet_4.Text = "BT Comment:";
            // 
            // rtxt_com1
            // 
            this.rtxt_com1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_com1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_com1.Location = new System.Drawing.Point(3, 18);
            this.rtxt_com1.Name = "rtxt_com1";
            this.rtxt_com1.Size = new System.Drawing.Size(142, 158);
            this.rtxt_com1.TabIndex = 13;
            this.rtxt_com1.Text = "";
            this.rtxt_com1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lbl_prbet_1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbo_second_assigned, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.bl_fxby, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbo_fxby, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lbl_cl, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl_ac, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.txt_ac, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.lbl_client, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbl_sp, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.txt_sp, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.lbl_fn, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txt_fn, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lbl_prbet_3, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.cbo_actby, 1, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(343, 179);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lbl_prbet_1
            // 
            this.lbl_prbet_1.AutoSize = true;
            this.lbl_prbet_1.Location = new System.Drawing.Point(3, 0);
            this.lbl_prbet_1.Name = "lbl_prbet_1";
            this.lbl_prbet_1.Size = new System.Drawing.Size(130, 13);
            this.lbl_prbet_1.TabIndex = 0;
            this.lbl_prbet_1.Text = "Second PR Assigned:";
            // 
            // cbo_second_assigned
            // 
            this.cbo_second_assigned.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbo_second_assigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_second_assigned.FormattingEnabled = true;
            this.cbo_second_assigned.Location = new System.Drawing.Point(3, 18);
            this.cbo_second_assigned.Name = "cbo_second_assigned";
            this.cbo_second_assigned.Size = new System.Drawing.Size(165, 21);
            this.cbo_second_assigned.TabIndex = 5;
            this.cbo_second_assigned.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // bl_fxby
            // 
            this.bl_fxby.AutoSize = true;
            this.bl_fxby.Location = new System.Drawing.Point(3, 45);
            this.bl_fxby.Name = "bl_fxby";
            this.bl_fxby.Size = new System.Drawing.Size(83, 13);
            this.bl_fxby.TabIndex = 3;
            this.bl_fxby.Text = "File Fixed By:";
            // 
            // cbo_fxby
            // 
            this.cbo_fxby.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbo_fxby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_fxby.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_fxby.FormattingEnabled = true;
            this.cbo_fxby.Location = new System.Drawing.Point(3, 63);
            this.cbo_fxby.Name = "cbo_fxby";
            this.cbo_fxby.Size = new System.Drawing.Size(165, 21);
            this.cbo_fxby.TabIndex = 7;
            this.cbo_fxby.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // lbl_cl
            // 
            this.lbl_cl.AutoSize = true;
            this.lbl_cl.Location = new System.Drawing.Point(174, 0);
            this.lbl_cl.Name = "lbl_cl";
            this.lbl_cl.Size = new System.Drawing.Size(43, 13);
            this.lbl_cl.TabIndex = 4;
            this.lbl_cl.Text = "Client:";
            // 
            // lbl_ac
            // 
            this.lbl_ac.AutoSize = true;
            this.lbl_ac.Location = new System.Drawing.Point(3, 90);
            this.lbl_ac.Name = "lbl_ac";
            this.lbl_ac.Size = new System.Drawing.Size(64, 13);
            this.lbl_ac.TabIndex = 2;
            this.lbl_ac.Text = "Accuracy:";
            // 
            // txt_ac
            // 
            this.txt_ac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_ac.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ac.Location = new System.Drawing.Point(3, 108);
            this.txt_ac.Name = "txt_ac";
            this.txt_ac.Size = new System.Drawing.Size(165, 20);
            this.txt_ac.TabIndex = 8;
            this.txt_ac.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // lbl_client
            // 
            this.lbl_client.AutoSize = true;
            this.lbl_client.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_client.Location = new System.Drawing.Point(174, 15);
            this.lbl_client.Name = "lbl_client";
            this.lbl_client.Size = new System.Drawing.Size(0, 15);
            this.lbl_client.TabIndex = 13;
            // 
            // lbl_sp
            // 
            this.lbl_sp.AutoSize = true;
            this.lbl_sp.Location = new System.Drawing.Point(3, 135);
            this.lbl_sp.Name = "lbl_sp";
            this.lbl_sp.Size = new System.Drawing.Size(88, 13);
            this.lbl_sp.TabIndex = 1;
            this.lbl_sp.Text = "Specs (Issue):";
            // 
            // txt_sp
            // 
            this.txt_sp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_sp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sp.Location = new System.Drawing.Point(3, 153);
            this.txt_sp.Name = "txt_sp";
            this.txt_sp.Size = new System.Drawing.Size(165, 20);
            this.txt_sp.TabIndex = 9;
            this.txt_sp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // lbl_fn
            // 
            this.lbl_fn.AutoSize = true;
            this.lbl_fn.Location = new System.Drawing.Point(174, 45);
            this.lbl_fn.Name = "lbl_fn";
            this.lbl_fn.Size = new System.Drawing.Size(61, 13);
            this.lbl_fn.TabIndex = 6;
            this.lbl_fn.Text = "Filename:";
            // 
            // txt_fn
            // 
            this.txt_fn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fn.Location = new System.Drawing.Point(174, 63);
            this.txt_fn.Name = "txt_fn";
            this.txt_fn.ReadOnly = true;
            this.txt_fn.Size = new System.Drawing.Size(166, 20);
            this.txt_fn.TabIndex = 11;
            this.txt_fn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // lbl_prbet_3
            // 
            this.lbl_prbet_3.AutoSize = true;
            this.lbl_prbet_3.Location = new System.Drawing.Point(174, 90);
            this.lbl_prbet_3.Name = "lbl_prbet_3";
            this.lbl_prbet_3.Size = new System.Drawing.Size(149, 13);
            this.lbl_prbet_3.TabIndex = 5;
            this.lbl_prbet_3.Text = "Action By BT Supervisor:";
            // 
            // cbo_actby
            // 
            this.cbo_actby.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbo_actby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_actby.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_actby.FormattingEnabled = true;
            this.cbo_actby.Location = new System.Drawing.Point(174, 108);
            this.cbo_actby.Name = "cbo_actby";
            this.cbo_actby.Size = new System.Drawing.Size(166, 21);
            this.cbo_actby.TabIndex = 12;
            this.cbo_actby.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // cbo_cl
            // 
            this.cbo_cl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_cl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_cl.FormattingEnabled = true;
            this.cbo_cl.Location = new System.Drawing.Point(796, 79);
            this.cbo_cl.Name = "cbo_cl";
            this.cbo_cl.Size = new System.Drawing.Size(106, 21);
            this.cbo_cl.TabIndex = 10;
            this.cbo_cl.Visible = false;
            this.cbo_cl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // cbo_name
            // 
            this.cbo_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_name.FormattingEnabled = true;
            this.cbo_name.Location = new System.Drawing.Point(796, 46);
            this.cbo_name.Name = "cbo_name";
            this.cbo_name.Size = new System.Drawing.Size(105, 21);
            this.cbo_name.TabIndex = 6;
            this.cbo_name.Visible = false;
            this.cbo_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // lbl_prbet_2
            // 
            this.lbl_prbet_2.AutoSize = true;
            this.lbl_prbet_2.Location = new System.Drawing.Point(799, 30);
            this.lbl_prbet_2.Name = "lbl_prbet_2";
            this.lbl_prbet_2.Size = new System.Drawing.Size(63, 13);
            this.lbl_prbet_2.TabIndex = 7;
            this.lbl_prbet_2.Text = "BT Name:";
            this.lbl_prbet_2.Visible = false;
            // 
            // frm_return_file
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 573);
            this.Controls.Add(this.pnl_content_container);
            this.Controls.Add(this.sb_info);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1080, 600);
            this.Name = "frm_return_file";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Return File";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_return_file_FormClosing);
            this.sb_info.ResumeLayout(false);
            this.sb_info.PerformLayout();
            this.pnl_content_container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_return)).EndInit();
            this.gb_filter_export_container.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gb_form_container.ResumeLayout(false);
            this.gb_form_container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_prank)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sb_info;
        private System.Windows.Forms.Panel pnl_content_container;
        private System.Windows.Forms.DataGridView dgv_return;
        private System.Windows.Forms.GroupBox gb_form_container;
        private System.Windows.Forms.GroupBox gb_filter_export_container;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txt_ac;
        private System.Windows.Forms.TextBox txt_fn;
        private System.Windows.Forms.TextBox txt_sp;
        private System.Windows.Forms.ComboBox cbo_actby;
        private System.Windows.Forms.ComboBox cbo_cl;
        private System.Windows.Forms.ComboBox cbo_fxby;
        private System.Windows.Forms.ComboBox cbo_name;
        private System.Windows.Forms.Label lbl_prbet_3;
        private System.Windows.Forms.Label lbl_fn;
        private System.Windows.Forms.Label lbl_ac;
        private System.Windows.Forms.Label lbl_prbet_2;
        private System.Windows.Forms.Label lbl_prbet_1;
        private System.Windows.Forms.Label bl_fxby;
        private System.Windows.Forms.Label lbl_cl;
        private System.Windows.Forms.Label lbl_sp;
        private System.Windows.Forms.ComboBox cbo_second_assigned;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_reload;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.ComboBox cbo_dep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_type;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.RichTextBox rtxt_com3;
        private System.Windows.Forms.RichTextBox rtxt_com2;
        private System.Windows.Forms.Label lbl_comment;
        private System.Windows.Forms.Label lbl_sbs_feed;
        private System.Windows.Forms.Label lbl_prbet_4;
        private System.Windows.Forms.RichTextBox rtxt_com1;
        private System.Windows.Forms.Button btn_unseen;
        private System.Windows.Forms.Button btn_seen;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.PictureBox pic_prank;
        private System.Windows.Forms.ToolStripStatusLabel tss_status;
        private System.Windows.Forms.ToolStripStatusLabel tss_status2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lbl_client;
    }
}