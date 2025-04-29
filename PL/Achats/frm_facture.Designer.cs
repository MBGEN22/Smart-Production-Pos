namespace Smart_Production_Pos.PL.Achats
{
	partial class frm_facture
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txt_seach = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.groupBox3 = new Shade.Controls.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.end_date = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
			this.startDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBox2 = new Shade.Controls.GroupBox();
			this.txt_Date = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1 = new Shade.Controls.GroupBox();
			this.cmbfrnse = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.kryptonButton3 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
			this.kryptonButton4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.panel3 = new System.Windows.Forms.Panel();
			this.pn_fctre = new System.Windows.Forms.Panel();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.طباعةالفاتورةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmbfrnse)).BeginInit();
			this.panel3.SuspendLayout();
			this.pn_fctre.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(1229, 446);
			this.dataGridView1.TabIndex = 2;
			this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.White;
			this.panel2.Controls.Add(this.txt_seach);
			this.panel2.Controls.Add(this.groupBox3);
			this.panel2.Controls.Add(this.groupBox2);
			this.panel2.Controls.Add(this.groupBox1);
			this.panel2.Controls.Add(this.kryptonButton3);
			this.panel2.Controls.Add(this.bigLabel1);
			this.panel2.Controls.Add(this.kryptonButton4);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1229, 141);
			this.panel2.TabIndex = 1;
			// 
			// txt_seach
			// 
			this.txt_seach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_seach.Location = new System.Drawing.Point(652, 88);
			this.txt_seach.Name = "txt_seach";
			this.txt_seach.Size = new System.Drawing.Size(464, 43);
			this.txt_seach.StateCommon.Border.Color1 = System.Drawing.Color.DodgerBlue;
			this.txt_seach.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txt_seach.StateCommon.Border.Rounding = 10;
			this.txt_seach.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_seach.TabIndex = 126;
			this.txt_seach.TextChanged += new System.EventHandler(this.kryptonTextBox1_TextChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.AutoScroll = true;
			this.groupBox3.AutoScrollMinSize = new System.Drawing.Size(0, 20);
			this.groupBox3.BackColor = System.Drawing.Color.Transparent;
			this.groupBox3.BackGColor = System.Drawing.Color.White;
			this.groupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.groupBox3.BaseColor = System.Drawing.Color.Transparent;
			this.groupBox3.BorderColorG = System.Drawing.Color.DodgerBlue;
			this.groupBox3.BorderColorH = System.Drawing.Color.DodgerBlue;
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.end_date);
			this.groupBox3.Controls.Add(this.startDate);
			this.groupBox3.Controls.Add(this.button3);
			this.groupBox3.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
			this.groupBox3.HeaderColor = System.Drawing.Color.White;
			this.groupBox3.Location = new System.Drawing.Point(103, 3);
			this.groupBox3.MinimumSize = new System.Drawing.Size(136, 50);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
			this.groupBox3.Size = new System.Drawing.Size(543, 79);
			this.groupBox3.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.groupBox3.TabIndex = 122;
			this.groupBox3.Text = "البحث بين تاريخين";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(249, 37);
			this.label2.Name = "label2";
			this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label2.Size = new System.Drawing.Size(32, 24);
			this.label2.TabIndex = 6;
			this.label2.Text = "إلى :";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(496, 37);
			this.label1.Name = "label1";
			this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label1.Size = new System.Drawing.Size(33, 24);
			this.label1.TabIndex = 6;
			this.label1.Text = "من :";
			// 
			// end_date
			// 
			this.end_date.Location = new System.Drawing.Point(47, 31);
			this.end_date.Name = "end_date";
			this.end_date.Size = new System.Drawing.Size(196, 41);
			this.end_date.StateCommon.Border.Color1 = System.Drawing.Color.DodgerBlue;
			this.end_date.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.end_date.StateCommon.Border.Rounding = 9;
			this.end_date.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.end_date.TabIndex = 5;
			// 
			// startDate
			// 
			this.startDate.Location = new System.Drawing.Point(294, 30);
			this.startDate.Name = "startDate";
			this.startDate.Size = new System.Drawing.Size(196, 41);
			this.startDate.StateCommon.Border.Color1 = System.Drawing.Color.DodgerBlue;
			this.startDate.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.startDate.StateCommon.Border.Rounding = 9;
			this.startDate.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.startDate.TabIndex = 5;
			// 
			// button3
			// 
			this.button3.FlatAppearance.BorderSize = 0;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Image = global::Smart_Production_Pos.Properties.Resources.rechercher;
			this.button3.Location = new System.Drawing.Point(4, 33);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(37, 36);
			this.button3.TabIndex = 5;
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.AutoScroll = true;
			this.groupBox2.AutoScrollMinSize = new System.Drawing.Size(0, 20);
			this.groupBox2.BackColor = System.Drawing.Color.Transparent;
			this.groupBox2.BackGColor = System.Drawing.Color.White;
			this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.groupBox2.BaseColor = System.Drawing.Color.Transparent;
			this.groupBox2.BorderColorG = System.Drawing.Color.DodgerBlue;
			this.groupBox2.BorderColorH = System.Drawing.Color.DodgerBlue;
			this.groupBox2.Controls.Add(this.txt_Date);
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
			this.groupBox2.HeaderColor = System.Drawing.Color.White;
			this.groupBox2.Location = new System.Drawing.Point(652, 3);
			this.groupBox2.MinimumSize = new System.Drawing.Size(136, 50);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
			this.groupBox2.Size = new System.Drawing.Size(284, 79);
			this.groupBox2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.groupBox2.TabIndex = 123;
			this.groupBox2.Text = "البحث عن طريق التاريخ";
			// 
			// txt_Date
			// 
			this.txt_Date.Location = new System.Drawing.Point(47, 31);
			this.txt_Date.Name = "txt_Date";
			this.txt_Date.Size = new System.Drawing.Size(229, 41);
			this.txt_Date.StateCommon.Border.Color1 = System.Drawing.Color.DodgerBlue;
			this.txt_Date.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txt_Date.StateCommon.Border.Rounding = 9;
			this.txt_Date.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_Date.TabIndex = 5;
			// 
			// button2
			// 
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Image = global::Smart_Production_Pos.Properties.Resources.rechercher;
			this.button2.Location = new System.Drawing.Point(4, 33);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(37, 36);
			this.button2.TabIndex = 5;
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.AutoScroll = true;
			this.groupBox1.AutoScrollMinSize = new System.Drawing.Size(0, 20);
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.BackGColor = System.Drawing.Color.White;
			this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.groupBox1.BaseColor = System.Drawing.Color.Transparent;
			this.groupBox1.BorderColorG = System.Drawing.Color.DodgerBlue;
			this.groupBox1.BorderColorH = System.Drawing.Color.DodgerBlue;
			this.groupBox1.Controls.Add(this.cmbfrnse);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
			this.groupBox1.HeaderColor = System.Drawing.Color.White;
			this.groupBox1.Location = new System.Drawing.Point(942, 3);
			this.groupBox1.MinimumSize = new System.Drawing.Size(136, 50);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
			this.groupBox1.Size = new System.Drawing.Size(284, 79);
			this.groupBox1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.groupBox1.TabIndex = 124;
			this.groupBox1.Text = "البحث عن طريق المورد";
			// 
			// cmbfrnse
			// 
			this.cmbfrnse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbfrnse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbfrnse.DropDownWidth = 229;
			this.cmbfrnse.Location = new System.Drawing.Point(41, 31);
			this.cmbfrnse.Name = "cmbfrnse";
			this.cmbfrnse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.cmbfrnse.Size = new System.Drawing.Size(235, 41);
			this.cmbfrnse.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.DodgerBlue;
			this.cmbfrnse.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.cmbfrnse.StateCommon.ComboBox.Border.Rounding = 8;
			this.cmbfrnse.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbfrnse.StateCommon.Item.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.cmbfrnse.StateCommon.Item.Border.Rounding = 15;
			this.cmbfrnse.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbfrnse.TabIndex = 5;
			this.cmbfrnse.Tag = "search";
			// 
			// button1
			// 
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Image = global::Smart_Production_Pos.Properties.Resources.rechercher;
			this.button1.Location = new System.Drawing.Point(4, 33);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(37, 36);
			this.button1.TabIndex = 5;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// kryptonButton3
			// 
			this.kryptonButton3.Location = new System.Drawing.Point(4, 17);
			this.kryptonButton3.Name = "kryptonButton3";
			this.kryptonButton3.Size = new System.Drawing.Size(97, 63);
			this.kryptonButton3.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
			this.kryptonButton3.StateCommon.Back.Color2 = System.Drawing.SystemColors.Highlight;
			this.kryptonButton3.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonButton3.StateCommon.Border.Rounding = 5;
			this.kryptonButton3.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
			this.kryptonButton3.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonButton3.TabIndex = 121;
			this.kryptonButton3.Values.Image = global::Smart_Production_Pos.Properties.Resources.mettre_a_jour_les_fleches1;
			this.kryptonButton3.Values.Text = "التحديث";
			this.kryptonButton3.Click += new System.EventHandler(this.kryptonButton3_Click_1);
			// 
			// bigLabel1
			// 
			this.bigLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bigLabel1.AutoSize = true;
			this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
			this.bigLabel1.Font = new System.Drawing.Font("Cairo", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bigLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.bigLabel1.Location = new System.Drawing.Point(1110, 74);
			this.bigLabel1.Name = "bigLabel1";
			this.bigLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.bigLabel1.Size = new System.Drawing.Size(116, 62);
			this.bigLabel1.TabIndex = 125;
			this.bigLabel1.Text = "البحث :";
			this.bigLabel1.Click += new System.EventHandler(this.bigLabel1_Click);
			// 
			// kryptonButton4
			// 
			this.kryptonButton4.Location = new System.Drawing.Point(4, 86);
			this.kryptonButton4.Name = "kryptonButton4";
			this.kryptonButton4.Size = new System.Drawing.Size(240, 46);
			this.kryptonButton4.StateCommon.Back.Color1 = System.Drawing.Color.CornflowerBlue;
			this.kryptonButton4.StateCommon.Back.Color2 = System.Drawing.SystemColors.Highlight;
			this.kryptonButton4.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonButton4.StateCommon.Border.Rounding = 5;
			this.kryptonButton4.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
			this.kryptonButton4.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonButton4.TabIndex = 120;
			this.kryptonButton4.Values.Image = global::Smart_Production_Pos.Properties.Resources.telecharger_Wpng;
			this.kryptonButton4.Values.Text = "تحميل ملفات تابعة للفاتورة";
			this.kryptonButton4.Click += new System.EventHandler(this.update4_Click);
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.White;
			this.panel3.Controls.Add(this.dataGridView1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 141);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1229, 446);
			this.panel3.TabIndex = 2;
			// 
			// pn_fctre
			// 
			this.pn_fctre.BackColor = System.Drawing.Color.White;
			this.pn_fctre.Controls.Add(this.panel3);
			this.pn_fctre.Controls.Add(this.panel2);
			this.pn_fctre.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pn_fctre.Location = new System.Drawing.Point(0, 0);
			this.pn_fctre.Name = "pn_fctre";
			this.pn_fctre.Size = new System.Drawing.Size(1229, 587);
			this.pn_fctre.TabIndex = 5;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.طباعةالفاتورةToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
			// 
			// طباعةالفاتورةToolStripMenuItem
			// 
			this.طباعةالفاتورةToolStripMenuItem.Name = "طباعةالفاتورةToolStripMenuItem";
			this.طباعةالفاتورةToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.طباعةالفاتورةToolStripMenuItem.Text = " طباعة الفاتورة";
			this.طباعةالفاتورةToolStripMenuItem.Click += new System.EventHandler(this.طباعةالفاتورةToolStripMenuItem_Click);
			// 
			// frm_facture
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1229, 587);
			this.Controls.Add(this.pn_fctre);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frm_facture";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frm_facture";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmbfrnse)).EndInit();
			this.panel3.ResumeLayout(false);
			this.pn_fctre.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		public System.Windows.Forms.Panel pn_fctre;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton4;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_seach;
		private Shade.Controls.GroupBox groupBox3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker end_date;
		private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker startDate;
		private System.Windows.Forms.Button button3;
		private Shade.Controls.GroupBox groupBox2;
		private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker txt_Date;
		private System.Windows.Forms.Button button2;
		private Shade.Controls.GroupBox groupBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbfrnse;
		private System.Windows.Forms.Button button1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton3;
		private ReaLTaiizor.Controls.BigLabel bigLabel1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem طباعةالفاتورةToolStripMenuItem;
	}
}