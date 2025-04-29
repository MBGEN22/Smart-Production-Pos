namespace Smart_Production_Pos.PL.Achats
{
	partial class frm_stock_matier_premier
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pn_stock_matier_premier = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.kryptonGroup2 = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txt_stock = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.txtQT_REST = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.txtQT_TTL = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.txt_reference = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.txtMarque = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.txt_designation = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.txt_codeBare = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.kryptonGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
			this.cmb_choose = new System.Windows.Forms.ComboBox();
			this.button4 = new System.Windows.Forms.Button();
			this.groupBox6 = new Shade.Controls.GroupBox();
			this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.groupBox1 = new Shade.Controls.GroupBox();
			this.cmb_matier_search = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.button10 = new System.Windows.Forms.Button();
			this.pn_stock_matier_premier.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup2.Panel)).BeginInit();
			this.kryptonGroup2.Panel.SuspendLayout();
			this.kryptonGroup2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).BeginInit();
			this.kryptonGroup1.Panel.SuspendLayout();
			this.kryptonGroup1.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmb_matier_search)).BeginInit();
			this.SuspendLayout();
			// 
			// pn_stock_matier_premier
			// 
			this.pn_stock_matier_premier.Controls.Add(this.panel3);
			this.pn_stock_matier_premier.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pn_stock_matier_premier.Location = new System.Drawing.Point(0, 0);
			this.pn_stock_matier_premier.Name = "pn_stock_matier_premier";
			this.pn_stock_matier_premier.Size = new System.Drawing.Size(1175, 563);
			this.pn_stock_matier_premier.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.White;
			this.panel3.Controls.Add(this.dataGridView1);
			this.panel3.Controls.Add(this.panel2);
			this.panel3.Controls.Add(this.panel1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1175, 563);
			this.panel3.TabIndex = 4;
			// 
			// dataGridView1
			// 
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 100);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(1175, 322);
			this.dataGridView1.TabIndex = 1;
			this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.kryptonGroup2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 422);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(5);
			this.panel2.Size = new System.Drawing.Size(1175, 141);
			this.panel2.TabIndex = 14;
			// 
			// kryptonGroup2
			// 
			this.kryptonGroup2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonGroup2.Location = new System.Drawing.Point(5, 5);
			this.kryptonGroup2.Name = "kryptonGroup2";
			// 
			// kryptonGroup2.Panel
			// 
			this.kryptonGroup2.Panel.Controls.Add(this.pictureBox1);
			this.kryptonGroup2.Panel.Controls.Add(this.label11);
			this.kryptonGroup2.Panel.Controls.Add(this.txt_stock);
			this.kryptonGroup2.Panel.Controls.Add(this.txtQT_REST);
			this.kryptonGroup2.Panel.Controls.Add(this.txtQT_TTL);
			this.kryptonGroup2.Panel.Controls.Add(this.txt_reference);
			this.kryptonGroup2.Panel.Controls.Add(this.txtMarque);
			this.kryptonGroup2.Panel.Controls.Add(this.label28);
			this.kryptonGroup2.Panel.Controls.Add(this.txt_designation);
			this.kryptonGroup2.Panel.Controls.Add(this.label2);
			this.kryptonGroup2.Panel.Controls.Add(this.button6);
			this.kryptonGroup2.Panel.Controls.Add(this.pictureBox2);
			this.kryptonGroup2.Panel.Controls.Add(this.txt_codeBare);
			this.kryptonGroup2.Panel.Controls.Add(this.label1);
			this.kryptonGroup2.Panel.Controls.Add(this.label6);
			this.kryptonGroup2.Panel.Controls.Add(this.label3);
			this.kryptonGroup2.Panel.Controls.Add(this.label5);
			this.kryptonGroup2.Size = new System.Drawing.Size(1165, 131);
			this.kryptonGroup2.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
			this.kryptonGroup2.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonGroup2.StateCommon.Border.Rounding = 15;
			this.kryptonGroup2.StateCommon.Border.Width = 2;
			this.kryptonGroup2.TabIndex = 12;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Image = global::Smart_Production_Pos.Properties.Resources.produit;
			this.pictureBox1.Location = new System.Drawing.Point(1028, 9);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(118, 97);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.ForeColor = System.Drawing.Color.Black;
			this.label11.Location = new System.Drawing.Point(415, 11);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(69, 30);
			this.label11.TabIndex = 139;
			this.label11.Text = "العلامة :";
			// 
			// txt_stock
			// 
			this.txt_stock.Enabled = false;
			this.txt_stock.Location = new System.Drawing.Point(261, 60);
			this.txt_stock.Margin = new System.Windows.Forms.Padding(5);
			this.txt_stock.Name = "txt_stock";
			this.txt_stock.Size = new System.Drawing.Size(151, 41);
			this.txt_stock.StateCommon.Border.Color1 = System.Drawing.SystemColors.ControlDarkDark;
			this.txt_stock.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txt_stock.StateCommon.Border.Rounding = 5;
			this.txt_stock.StateCommon.Content.Color1 = System.Drawing.Color.Black;
			this.txt_stock.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_stock.TabIndex = 137;
			this.txt_stock.Text = "1";
			// 
			// txtQT_REST
			// 
			this.txtQT_REST.Enabled = false;
			this.txtQT_REST.Location = new System.Drawing.Point(30, 60);
			this.txtQT_REST.Margin = new System.Windows.Forms.Padding(5);
			this.txtQT_REST.Name = "txtQT_REST";
			this.txtQT_REST.Size = new System.Drawing.Size(115, 41);
			this.txtQT_REST.StateCommon.Border.Color1 = System.Drawing.SystemColors.ControlDarkDark;
			this.txtQT_REST.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txtQT_REST.StateCommon.Border.Rounding = 5;
			this.txtQT_REST.StateCommon.Content.Color1 = System.Drawing.Color.Black;
			this.txtQT_REST.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtQT_REST.TabIndex = 135;
			// 
			// txtQT_TTL
			// 
			this.txtQT_TTL.Enabled = false;
			this.txtQT_TTL.Location = new System.Drawing.Point(30, 6);
			this.txtQT_TTL.Margin = new System.Windows.Forms.Padding(5);
			this.txtQT_TTL.Name = "txtQT_TTL";
			this.txtQT_TTL.Size = new System.Drawing.Size(115, 41);
			this.txtQT_TTL.StateCommon.Border.Color1 = System.Drawing.SystemColors.ControlDarkDark;
			this.txtQT_TTL.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txtQT_TTL.StateCommon.Border.Rounding = 5;
			this.txtQT_TTL.StateCommon.Content.Color1 = System.Drawing.Color.Black;
			this.txtQT_TTL.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtQT_TTL.TabIndex = 135;
			// 
			// txt_reference
			// 
			this.txt_reference.Enabled = false;
			this.txt_reference.Location = new System.Drawing.Point(488, 60);
			this.txt_reference.Margin = new System.Windows.Forms.Padding(5);
			this.txt_reference.Name = "txt_reference";
			this.txt_reference.Size = new System.Drawing.Size(175, 41);
			this.txt_reference.StateCommon.Border.Color1 = System.Drawing.SystemColors.ControlDarkDark;
			this.txt_reference.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txt_reference.StateCommon.Border.Rounding = 5;
			this.txt_reference.StateCommon.Content.Color1 = System.Drawing.Color.Black;
			this.txt_reference.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_reference.TabIndex = 137;
			this.txt_reference.Text = "1";
			// 
			// txtMarque
			// 
			this.txtMarque.Enabled = false;
			this.txtMarque.Location = new System.Drawing.Point(260, 6);
			this.txtMarque.Margin = new System.Windows.Forms.Padding(5);
			this.txtMarque.Name = "txtMarque";
			this.txtMarque.Size = new System.Drawing.Size(152, 41);
			this.txtMarque.StateCommon.Border.Color1 = System.Drawing.SystemColors.ControlDarkDark;
			this.txtMarque.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txtMarque.StateCommon.Border.Rounding = 5;
			this.txtMarque.StateCommon.Content.Color1 = System.Drawing.Color.Black;
			this.txtMarque.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMarque.TabIndex = 135;
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.BackColor = System.Drawing.Color.Transparent;
			this.label28.Location = new System.Drawing.Point(660, 65);
			this.label28.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(93, 30);
			this.label28.TabIndex = 138;
			this.label28.Text = "رقم المرجع :";
			// 
			// txt_designation
			// 
			this.txt_designation.Enabled = false;
			this.txt_designation.Location = new System.Drawing.Point(488, 6);
			this.txt_designation.Margin = new System.Windows.Forms.Padding(5);
			this.txt_designation.Name = "txt_designation";
			this.txt_designation.Size = new System.Drawing.Size(176, 41);
			this.txt_designation.StateCommon.Border.Color1 = System.Drawing.SystemColors.ControlDarkDark;
			this.txt_designation.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txt_designation.StateCommon.Border.Rounding = 5;
			this.txt_designation.StateCommon.Content.Color1 = System.Drawing.Color.Black;
			this.txt_designation.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_designation.TabIndex = 135;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(661, 11);
			this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 30);
			this.label2.TabIndex = 136;
			this.label2.Text = "اسم المنتج :";
			// 
			// button6
			// 
			this.button6.FlatAppearance.BorderSize = 0;
			this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button6.Image = global::Smart_Production_Pos.Properties.Resources.imprimer;
			this.button6.Location = new System.Drawing.Point(932, 52);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(33, 35);
			this.button6.TabIndex = 134;
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox2.Location = new System.Drawing.Point(757, 55);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(174, 51);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox2.TabIndex = 133;
			this.pictureBox2.TabStop = false;
			// 
			// txt_codeBare
			// 
			this.txt_codeBare.Enabled = false;
			this.txt_codeBare.Location = new System.Drawing.Point(757, 6);
			this.txt_codeBare.Margin = new System.Windows.Forms.Padding(5);
			this.txt_codeBare.Name = "txt_codeBare";
			this.txt_codeBare.Size = new System.Drawing.Size(174, 41);
			this.txt_codeBare.StateCommon.Back.Color1 = System.Drawing.Color.WhiteSmoke;
			this.txt_codeBare.StateCommon.Border.Color1 = System.Drawing.SystemColors.ControlDarkDark;
			this.txt_codeBare.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txt_codeBare.StateCommon.Border.Rounding = 5;
			this.txt_codeBare.StateCommon.Content.Color1 = System.Drawing.Color.Black;
			this.txt_codeBare.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_codeBare.TabIndex = 132;
			this.txt_codeBare.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txt_codeBare.TextChanged += new System.EventHandler(this.txt_codeBare_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(934, 11);
			this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label1.Name = "label1";
			this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label1.Size = new System.Drawing.Size(97, 30);
			this.label1.TabIndex = 131;
			this.label1.Text = "رقم المنتوج :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ForeColor = System.Drawing.Color.Black;
			this.label6.Location = new System.Drawing.Point(412, 65);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(66, 30);
			this.label6.TabIndex = 141;
			this.label6.Text = "المخزن :";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(143, 65);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(122, 30);
			this.label3.TabIndex = 142;
			this.label3.Text = "الكمية المتبقية :";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(143, 11);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(107, 30);
			this.label5.TabIndex = 142;
			this.label5.Text = "الكمية الكلية :";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.kryptonGroup1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(5);
			this.panel1.Size = new System.Drawing.Size(1175, 100);
			this.panel1.TabIndex = 13;
			// 
			// kryptonGroup1
			// 
			this.kryptonGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonGroup1.Location = new System.Drawing.Point(5, 5);
			this.kryptonGroup1.Name = "kryptonGroup1";
			// 
			// kryptonGroup1.Panel
			// 
			this.kryptonGroup1.Panel.Controls.Add(this.cmb_choose);
			this.kryptonGroup1.Panel.Controls.Add(this.button4);
			this.kryptonGroup1.Panel.Controls.Add(this.groupBox6);
			this.kryptonGroup1.Panel.Controls.Add(this.groupBox1);
			this.kryptonGroup1.Size = new System.Drawing.Size(1165, 90);
			this.kryptonGroup1.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
			this.kryptonGroup1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonGroup1.StateCommon.Border.Rounding = 15;
			this.kryptonGroup1.StateCommon.Border.Width = 2;
			this.kryptonGroup1.TabIndex = 12;
			// 
			// cmb_choose
			// 
			this.cmb_choose.FormattingEnabled = true;
			this.cmb_choose.Items.AddRange(new object[] {
            "البحث عن طريق اسم المنتج",
            "البحث عن طريق المرجع",
            "البحث عن طريق الصنف",
            "البحث عن طريق الوحدة ",
            "البحث عن طريق العلامة",
            "البحث عن طريق المخزن",
            "البحث عشوائيا"});
			this.cmb_choose.Location = new System.Drawing.Point(5, 29);
			this.cmb_choose.Name = "cmb_choose";
			this.cmb_choose.Size = new System.Drawing.Size(282, 38);
			this.cmb_choose.TabIndex = 11;
			this.cmb_choose.SelectedIndexChanged += new System.EventHandler(this.cmb_choose_SelectedIndexChanged);
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button4.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.button4.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.ForeColor = System.Drawing.Color.White;
			this.button4.Image = global::Smart_Production_Pos.Properties.Resources.actualise;
			this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button4.Location = new System.Drawing.Point(450, 18);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(106, 52);
			this.button4.TabIndex = 10;
			this.button4.Text = "تحديث";
			this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox6.AutoScroll = true;
			this.groupBox6.AutoScrollMinSize = new System.Drawing.Size(0, 20);
			this.groupBox6.BackColor = System.Drawing.Color.Transparent;
			this.groupBox6.BackGColor = System.Drawing.Color.White;
			this.groupBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.groupBox6.BaseColor = System.Drawing.Color.Transparent;
			this.groupBox6.BorderColorG = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.groupBox6.BorderColorH = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.groupBox6.Controls.Add(this.kryptonTextBox1);
			this.groupBox6.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
			this.groupBox6.HeaderColor = System.Drawing.Color.White;
			this.groupBox6.Location = new System.Drawing.Point(850, 3);
			this.groupBox6.MinimumSize = new System.Drawing.Size(136, 50);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
			this.groupBox6.Size = new System.Drawing.Size(284, 70);
			this.groupBox6.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.groupBox6.TabIndex = 9;
			this.groupBox6.Text = "البحث عن طريق الرقم";
			// 
			// kryptonTextBox1
			// 
			this.kryptonTextBox1.Location = new System.Drawing.Point(15, 24);
			this.kryptonTextBox1.Name = "kryptonTextBox1";
			this.kryptonTextBox1.Size = new System.Drawing.Size(260, 43);
			this.kryptonTextBox1.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
			this.kryptonTextBox1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonTextBox1.StateCommon.Border.Rounding = 10;
			this.kryptonTextBox1.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonTextBox1.TabIndex = 10;
			this.kryptonTextBox1.TextChanged += new System.EventHandler(this.kryptonTextBox1_TextChanged_1);
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
			this.groupBox1.BorderColorG = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.groupBox1.BorderColorH = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.groupBox1.Controls.Add(this.cmb_matier_search);
			this.groupBox1.Controls.Add(this.button10);
			this.groupBox1.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
			this.groupBox1.HeaderColor = System.Drawing.Color.White;
			this.groupBox1.Location = new System.Drawing.Point(559, 3);
			this.groupBox1.MinimumSize = new System.Drawing.Size(136, 50);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
			this.groupBox1.Size = new System.Drawing.Size(285, 70);
			this.groupBox1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.groupBox1.TabIndex = 7;
			this.groupBox1.Text = "البحث عن طريق الصنف";
			// 
			// cmb_matier_search
			// 
			this.cmb_matier_search.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmb_matier_search.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmb_matier_search.DropDownWidth = 229;
			this.cmb_matier_search.Location = new System.Drawing.Point(42, 25);
			this.cmb_matier_search.Name = "cmb_matier_search";
			this.cmb_matier_search.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.cmb_matier_search.Size = new System.Drawing.Size(235, 41);
			this.cmb_matier_search.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.DodgerBlue;
			this.cmb_matier_search.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.cmb_matier_search.StateCommon.ComboBox.Border.Rounding = 8;
			this.cmb_matier_search.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmb_matier_search.StateCommon.Item.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.cmb_matier_search.StateCommon.Item.Border.Rounding = 15;
			this.cmb_matier_search.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmb_matier_search.TabIndex = 11;
			this.cmb_matier_search.Tag = "search";
			// 
			// button10
			// 
			this.button10.FlatAppearance.BorderSize = 0;
			this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button10.Image = global::Smart_Production_Pos.Properties.Resources.rechercher;
			this.button10.Location = new System.Drawing.Point(3, 26);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(37, 36);
			this.button10.TabIndex = 5;
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.button10_Click);
			// 
			// frm_stock_matier_premier
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(1175, 563);
			this.Controls.Add(this.pn_stock_matier_premier);
			this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frm_stock_matier_premier";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.RightToLeftLayout = true;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frm_stock_matier_premier";
			this.DoubleClick += new System.EventHandler(this.frm_stock_matier_premier_DoubleClick);
			this.pn_stock_matier_premier.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup2.Panel)).EndInit();
			this.kryptonGroup2.Panel.ResumeLayout(false);
			this.kryptonGroup2.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup2)).EndInit();
			this.kryptonGroup2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).EndInit();
			this.kryptonGroup1.Panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).EndInit();
			this.kryptonGroup1.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmb_matier_search)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel3;
		public System.Windows.Forms.Panel pn_stock_matier_premier;
		private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.DataGridView dataGridView1;
		private ComponentFactory.Krypton.Toolkit.KryptonGroup kryptonGroup1;
		private System.Windows.Forms.ComboBox cmb_choose;
		private System.Windows.Forms.Button button4;
		private Shade.Controls.GroupBox groupBox6;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
		private Shade.Controls.GroupBox groupBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmb_matier_search;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Panel panel2;
		private ComponentFactory.Krypton.Toolkit.KryptonGroup kryptonGroup2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_codeBare;
		public System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Button button6;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_designation;
		private System.Windows.Forms.Label label2;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_reference;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label6;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_stock;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMarque;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtQT_REST;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtQT_TTL;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
	}
}