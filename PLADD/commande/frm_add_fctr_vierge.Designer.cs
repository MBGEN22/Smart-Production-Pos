namespace Smart_Production_Pos.PLADD.commande
{
	partial class frm_add_fctr_vierge
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_add_fctr_vierge));
			this.panel1 = new System.Windows.Forms.Panel();
			this.txt_nmr_faccture = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.separator1 = new Shade.Controls.Separator();
			this.panel2 = new System.Windows.Forms.Panel();
			this.grid_sub_commande = new System.Windows.Forms.DataGridView();
			this.panel5 = new System.Windows.Forms.Panel();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.txt_prix_unite = new System.Windows.Forms.TextBox();
			this.txt_prix_total = new System.Windows.Forms.TextBox();
			this.txt_sub_name_commande = new System.Windows.Forms.TextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.label46 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.txt_Quantite = new System.Windows.Forms.TextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.kryptonGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
			this.cmb_client = new System.Windows.Forms.ComboBox();
			this.kryptonButton4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label40 = new System.Windows.Forms.Label();
			this.txt_reste = new System.Windows.Forms.TextBox();
			this.txt_payes = new System.Windows.Forms.TextBox();
			this.check_tmber = new System.Windows.Forms.CheckBox();
			this.txt_ht_total = new System.Windows.Forms.TextBox();
			this.txt_tva = new System.Windows.Forms.TextBox();
			this.txt_total_ttc = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label39 = new System.Windows.Forms.Label();
			this.label38 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grid_sub_commande)).BeginInit();
			this.panel5.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).BeginInit();
			this.kryptonGroup1.Panel.SuspendLayout();
			this.kryptonGroup1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txt_nmr_faccture);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.dateTimePicker1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.separator1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(970, 56);
			this.panel1.TabIndex = 0;
			// 
			// txt_nmr_faccture
			// 
			this.txt_nmr_faccture.Enabled = false;
			this.txt_nmr_faccture.Location = new System.Drawing.Point(20, 6);
			this.txt_nmr_faccture.Name = "txt_nmr_faccture";
			this.txt_nmr_faccture.Size = new System.Drawing.Size(375, 42);
			this.txt_nmr_faccture.StateCommon.Back.Color1 = System.Drawing.Color.Gold;
			this.txt_nmr_faccture.StateCommon.Border.Color1 = System.Drawing.Color.DodgerBlue;
			this.txt_nmr_faccture.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txt_nmr_faccture.StateCommon.Border.Rounding = 10;
			this.txt_nmr_faccture.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_nmr_faccture.TabIndex = 93;
			this.txt_nmr_faccture.Text = "FV00000";
			this.txt_nmr_faccture.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(401, 9);
			this.label3.Name = "label3";
			this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label3.Size = new System.Drawing.Size(99, 30);
			this.label3.TabIndex = 92;
			this.label3.Text = "رقم الفاتورة :";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(506, 6);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(385, 41);
			this.dateTimePicker1.StateCommon.Border.Color1 = System.Drawing.Color.DodgerBlue;
			this.dateTimePicker1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.dateTimePicker1.StateCommon.Border.Rounding = 9;
			this.dateTimePicker1.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dateTimePicker1.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(897, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 30);
			this.label1.TabIndex = 1;
			this.label1.Text = "التاريخ :";
			// 
			// separator1
			// 
			this.separator1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.separator1.LineColor = System.Drawing.Color.Gray;
			this.separator1.Location = new System.Drawing.Point(0, 46);
			this.separator1.Name = "separator1";
			this.separator1.Size = new System.Drawing.Size(970, 10);
			this.separator1.TabIndex = 0;
			this.separator1.Text = "separator1";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.grid_sub_commande);
			this.panel2.Controls.Add(this.panel5);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 56);
			this.panel2.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(970, 307);
			this.panel2.TabIndex = 1;
			// 
			// grid_sub_commande
			// 
			this.grid_sub_commande.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.grid_sub_commande.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grid_sub_commande.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid_sub_commande.Location = new System.Drawing.Point(0, 146);
			this.grid_sub_commande.Name = "grid_sub_commande";
			this.grid_sub_commande.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.grid_sub_commande.Size = new System.Drawing.Size(970, 161);
			this.grid_sub_commande.TabIndex = 43;
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(51)))), ((int)(((byte)(63)))));
			this.panel5.Controls.Add(this.button6);
			this.panel5.Controls.Add(this.button5);
			this.panel5.Controls.Add(this.txt_prix_unite);
			this.panel5.Controls.Add(this.txt_prix_total);
			this.panel5.Controls.Add(this.txt_sub_name_commande);
			this.panel5.Controls.Add(this.label32);
			this.panel5.Controls.Add(this.label46);
			this.panel5.Controls.Add(this.label45);
			this.panel5.Controls.Add(this.label33);
			this.panel5.Controls.Add(this.txt_Quantite);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(970, 146);
			this.panel5.TabIndex = 42;
			// 
			// button6
			// 
			this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button6.BackColor = System.Drawing.Color.IndianRed;
			this.button6.FlatAppearance.BorderSize = 0;
			this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
			this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button6.Location = new System.Drawing.Point(680, 96);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(84, 39);
			this.button6.TabIndex = 51;
			this.button6.Text = "حذف";
			this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button6.UseVisualStyleBackColor = false;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button5.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.button5.FlatAppearance.BorderSize = 0;
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
			this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button5.Location = new System.Drawing.Point(768, 96);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(95, 39);
			this.button5.TabIndex = 52;
			this.button5.Text = "إضافة ";
			this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button5.UseVisualStyleBackColor = false;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// txt_prix_unite
			// 
			this.txt_prix_unite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_prix_unite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.txt_prix_unite.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_prix_unite.Location = new System.Drawing.Point(590, 53);
			this.txt_prix_unite.Name = "txt_prix_unite";
			this.txt_prix_unite.Size = new System.Drawing.Size(274, 37);
			this.txt_prix_unite.TabIndex = 1;
			this.txt_prix_unite.Text = "00";
			this.txt_prix_unite.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txt_prix_unite.TextChanged += new System.EventHandler(this.txt_prix_unite_TextChanged);
			this.txt_prix_unite.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ht_total_KeyPress);
			// 
			// txt_prix_total
			// 
			this.txt_prix_total.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_prix_total.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.txt_prix_total.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_prix_total.Location = new System.Drawing.Point(18, 53);
			this.txt_prix_total.Name = "txt_prix_total";
			this.txt_prix_total.Size = new System.Drawing.Size(462, 37);
			this.txt_prix_total.TabIndex = 3;
			this.txt_prix_total.Text = "00";
			this.txt_prix_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txt_prix_total.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ht_total_KeyPress);
			// 
			// txt_sub_name_commande
			// 
			this.txt_sub_name_commande.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_sub_name_commande.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_sub_name_commande.Location = new System.Drawing.Point(590, 12);
			this.txt_sub_name_commande.Name = "txt_sub_name_commande";
			this.txt_sub_name_commande.Size = new System.Drawing.Size(274, 37);
			this.txt_sub_name_commande.TabIndex = 0;
			this.txt_sub_name_commande.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label32
			// 
			this.label32.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label32.AutoSize = true;
			this.label32.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label32.ForeColor = System.Drawing.Color.White;
			this.label32.Location = new System.Drawing.Point(866, 56);
			this.label32.Name = "label32";
			this.label32.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label32.Size = new System.Drawing.Size(97, 30);
			this.label32.TabIndex = 47;
			this.label32.Text = "سعر الوحدة :";
			// 
			// label46
			// 
			this.label46.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label46.AutoSize = true;
			this.label46.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label46.ForeColor = System.Drawing.Color.White;
			this.label46.Location = new System.Drawing.Point(486, 15);
			this.label46.Name = "label46";
			this.label46.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label46.Size = new System.Drawing.Size(65, 30);
			this.label46.TabIndex = 48;
			this.label46.Text = "الكمية :";
			// 
			// label45
			// 
			this.label45.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label45.AutoSize = true;
			this.label45.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label45.ForeColor = System.Drawing.Color.White;
			this.label45.Location = new System.Drawing.Point(866, 15);
			this.label45.Name = "label45";
			this.label45.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label45.Size = new System.Drawing.Size(97, 30);
			this.label45.TabIndex = 50;
			this.label45.Text = "اسم الطلبية :";
			// 
			// label33
			// 
			this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label33.AutoSize = true;
			this.label33.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label33.ForeColor = System.Drawing.Color.White;
			this.label33.Location = new System.Drawing.Point(486, 56);
			this.label33.Name = "label33";
			this.label33.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label33.Size = new System.Drawing.Size(98, 30);
			this.label33.TabIndex = 49;
			this.label33.Text = "السعر الكلي :";
			// 
			// txt_Quantite
			// 
			this.txt_Quantite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_Quantite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.txt_Quantite.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_Quantite.Location = new System.Drawing.Point(18, 13);
			this.txt_Quantite.Name = "txt_Quantite";
			this.txt_Quantite.Size = new System.Drawing.Size(462, 37);
			this.txt_Quantite.TabIndex = 4;
			this.txt_Quantite.Text = "00";
			this.txt_Quantite.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txt_Quantite.TextChanged += new System.EventHandler(this.txt_Quantite_TextChanged);
			this.txt_Quantite.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ht_total_KeyPress);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.kryptonGroup1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 363);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(6);
			this.panel3.Size = new System.Drawing.Size(970, 217);
			this.panel3.TabIndex = 2;
			// 
			// kryptonGroup1
			// 
			this.kryptonGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonGroup1.Location = new System.Drawing.Point(6, 6);
			this.kryptonGroup1.Name = "kryptonGroup1";
			// 
			// kryptonGroup1.Panel
			// 
			this.kryptonGroup1.Panel.Controls.Add(this.cmb_client);
			this.kryptonGroup1.Panel.Controls.Add(this.kryptonButton4);
			this.kryptonGroup1.Panel.Controls.Add(this.textBox1);
			this.kryptonGroup1.Panel.Controls.Add(this.label40);
			this.kryptonGroup1.Panel.Controls.Add(this.txt_reste);
			this.kryptonGroup1.Panel.Controls.Add(this.txt_payes);
			this.kryptonGroup1.Panel.Controls.Add(this.check_tmber);
			this.kryptonGroup1.Panel.Controls.Add(this.txt_ht_total);
			this.kryptonGroup1.Panel.Controls.Add(this.txt_tva);
			this.kryptonGroup1.Panel.Controls.Add(this.txt_total_ttc);
			this.kryptonGroup1.Panel.Controls.Add(this.label16);
			this.kryptonGroup1.Panel.Controls.Add(this.label15);
			this.kryptonGroup1.Panel.Controls.Add(this.label2);
			this.kryptonGroup1.Panel.Controls.Add(this.label17);
			this.kryptonGroup1.Panel.Controls.Add(this.label39);
			this.kryptonGroup1.Panel.Controls.Add(this.label38);
			this.kryptonGroup1.Size = new System.Drawing.Size(958, 205);
			this.kryptonGroup1.StateCommon.Border.Color1 = System.Drawing.Color.DeepSkyBlue;
			this.kryptonGroup1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonGroup1.StateCommon.Border.Rounding = 10;
			this.kryptonGroup1.StateCommon.Border.Width = 3;
			this.kryptonGroup1.TabIndex = 126;
			// 
			// cmb_client
			// 
			this.cmb_client.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmb_client.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmb_client.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmb_client.FormattingEnabled = true;
			this.cmb_client.Location = new System.Drawing.Point(6, 9);
			this.cmb_client.Name = "cmb_client";
			this.cmb_client.Size = new System.Drawing.Size(789, 38);
			this.cmb_client.TabIndex = 139;
			// 
			// kryptonButton4
			// 
			this.kryptonButton4.Location = new System.Drawing.Point(6, 97);
			this.kryptonButton4.Name = "kryptonButton4";
			this.kryptonButton4.Size = new System.Drawing.Size(256, 82);
			this.kryptonButton4.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.kryptonButton4.StateCommon.Back.Color2 = System.Drawing.Color.DodgerBlue;
			this.kryptonButton4.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonButton4.StateCommon.Border.Rounding = 5;
			this.kryptonButton4.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
			this.kryptonButton4.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonButton4.TabIndex = 138;
			this.kryptonButton4.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton4.Values.Image")));
			this.kryptonButton4.Values.Text = "حفظ";
			this.kryptonButton4.Click += new System.EventHandler(this.kryptonButton4_Click);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.BackColor = System.Drawing.Color.White;
			this.textBox1.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(268, 99);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(525, 37);
			this.textBox1.TabIndex = 136;
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label40
			// 
			this.label40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label40.AutoSize = true;
			this.label40.BackColor = System.Drawing.Color.White;
			this.label40.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label40.Location = new System.Drawing.Point(495, 145);
			this.label40.Name = "label40";
			this.label40.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label40.Size = new System.Drawing.Size(74, 30);
			this.label40.TabIndex = 135;
			this.label40.Text = "المتبقي :";
			// 
			// txt_reste
			// 
			this.txt_reste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_reste.BackColor = System.Drawing.Color.White;
			this.txt_reste.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_reste.Location = new System.Drawing.Point(268, 142);
			this.txt_reste.Name = "txt_reste";
			this.txt_reste.Size = new System.Drawing.Size(221, 37);
			this.txt_reste.TabIndex = 132;
			this.txt_reste.Text = "00";
			this.txt_reste.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txt_reste.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ht_total_KeyPress);
			// 
			// txt_payes
			// 
			this.txt_payes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_payes.BackColor = System.Drawing.Color.White;
			this.txt_payes.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_payes.Location = new System.Drawing.Point(580, 142);
			this.txt_payes.Name = "txt_payes";
			this.txt_payes.Size = new System.Drawing.Size(213, 37);
			this.txt_payes.TabIndex = 133;
			this.txt_payes.Text = "00";
			this.txt_payes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txt_payes.TextChanged += new System.EventHandler(this.txt_payes_TextChanged);
			this.txt_payes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ht_total_KeyPress);
			// 
			// check_tmber
			// 
			this.check_tmber.AutoSize = true;
			this.check_tmber.BackColor = System.Drawing.Color.White;
			this.check_tmber.Location = new System.Drawing.Point(6, 55);
			this.check_tmber.Name = "check_tmber";
			this.check_tmber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.check_tmber.Size = new System.Drawing.Size(107, 34);
			this.check_tmber.TabIndex = 130;
			this.check_tmber.Text = "نسبة الطابع";
			this.check_tmber.UseVisualStyleBackColor = false;
			this.check_tmber.CheckedChanged += new System.EventHandler(this.check_tmber_CheckedChanged);
			// 
			// txt_ht_total
			// 
			this.txt_ht_total.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_ht_total.BackColor = System.Drawing.Color.Silver;
			this.txt_ht_total.Enabled = false;
			this.txt_ht_total.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_ht_total.Location = new System.Drawing.Point(583, 54);
			this.txt_ht_total.Name = "txt_ht_total";
			this.txt_ht_total.Size = new System.Drawing.Size(212, 37);
			this.txt_ht_total.TabIndex = 125;
			this.txt_ht_total.Text = "00";
			this.txt_ht_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txt_ht_total.TextChanged += new System.EventHandler(this.txt_ht_total_TextChanged);
			this.txt_ht_total.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ht_total_KeyPress);
			// 
			// txt_tva
			// 
			this.txt_tva.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_tva.BackColor = System.Drawing.Color.White;
			this.txt_tva.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_tva.Location = new System.Drawing.Point(445, 54);
			this.txt_tva.Name = "txt_tva";
			this.txt_tva.Size = new System.Drawing.Size(89, 37);
			this.txt_tva.TabIndex = 126;
			this.txt_tva.Text = "00";
			this.txt_tva.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txt_tva.TextChanged += new System.EventHandler(this.txt_tva_TextChanged);
			this.txt_tva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ht_total_KeyPress);
			// 
			// txt_total_ttc
			// 
			this.txt_total_ttc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_total_ttc.BackColor = System.Drawing.Color.LimeGreen;
			this.txt_total_ttc.Enabled = false;
			this.txt_total_ttc.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_total_ttc.Location = new System.Drawing.Point(126, 54);
			this.txt_total_ttc.Name = "txt_total_ttc";
			this.txt_total_ttc.Size = new System.Drawing.Size(192, 37);
			this.txt_total_ttc.TabIndex = 127;
			this.txt_total_ttc.Text = "00";
			this.txt_total_ttc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txt_total_ttc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ht_total_KeyPress);
			// 
			// label16
			// 
			this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label16.AutoSize = true;
			this.label16.BackColor = System.Drawing.Color.White;
			this.label16.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.Location = new System.Drawing.Point(532, 57);
			this.label16.Name = "label16";
			this.label16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label16.Size = new System.Drawing.Size(47, 30);
			this.label16.TabIndex = 128;
			this.label16.Text = "TVA :";
			// 
			// label15
			// 
			this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label15.AutoSize = true;
			this.label15.BackColor = System.Drawing.Color.White;
			this.label15.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(315, 57);
			this.label15.Name = "label15";
			this.label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label15.Size = new System.Drawing.Size(127, 30);
			this.label15.TabIndex = 129;
			this.label15.Text = "السعر الكلي TTC :";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(794, 12);
			this.label2.Name = "label2";
			this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label2.Size = new System.Drawing.Size(90, 30);
			this.label2.TabIndex = 140;
			this.label2.Text = "اسم الزبون :";
			// 
			// label17
			// 
			this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label17.AutoSize = true;
			this.label17.BackColor = System.Drawing.Color.White;
			this.label17.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label17.Location = new System.Drawing.Point(794, 102);
			this.label17.Name = "label17";
			this.label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label17.Size = new System.Drawing.Size(147, 30);
			this.label17.TabIndex = 137;
			this.label17.Text = "أوقفت الفاتورة عند :";
			// 
			// label39
			// 
			this.label39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label39.AutoSize = true;
			this.label39.BackColor = System.Drawing.Color.White;
			this.label39.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label39.Location = new System.Drawing.Point(794, 145);
			this.label39.Name = "label39";
			this.label39.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label39.Size = new System.Drawing.Size(81, 30);
			this.label39.TabIndex = 134;
			this.label39.Text = " المدفوع :";
			// 
			// label38
			// 
			this.label38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label38.AutoSize = true;
			this.label38.BackColor = System.Drawing.Color.White;
			this.label38.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label38.Location = new System.Drawing.Point(794, 57);
			this.label38.Name = "label38";
			this.label38.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label38.Size = new System.Drawing.Size(117, 30);
			this.label38.TabIndex = 131;
			this.label38.Text = "السعر الكلي HT:";
			// 
			// frm_add_fctr_vierge
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 30F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(970, 580);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frm_add_fctr_vierge";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.RightToLeftLayout = true;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "إضافة فاتورة فارغة";
			this.Load += new System.EventHandler(this.frm_add_fctr_vierge_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grid_sub_commande)).EndInit();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).EndInit();
			this.kryptonGroup1.Panel.ResumeLayout(false);
			this.kryptonGroup1.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).EndInit();
			this.kryptonGroup1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private Shade.Controls.Separator separator1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		public System.Windows.Forms.TextBox txt_prix_unite;
		public System.Windows.Forms.TextBox txt_prix_total;
		public System.Windows.Forms.TextBox txt_sub_name_commande;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label33;
		public System.Windows.Forms.TextBox txt_Quantite;
		public System.Windows.Forms.DataGridView grid_sub_commande;
		private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dateTimePicker1;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_nmr_faccture;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel3;
		private ComponentFactory.Krypton.Toolkit.KryptonGroup kryptonGroup1;
		private System.Windows.Forms.ComboBox cmb_client;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton4;
		public System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label40;
		public System.Windows.Forms.TextBox txt_reste;
		public System.Windows.Forms.TextBox txt_payes;
		private System.Windows.Forms.CheckBox check_tmber;
		public System.Windows.Forms.TextBox txt_ht_total;
		public System.Windows.Forms.TextBox txt_tva;
		public System.Windows.Forms.TextBox txt_total_ttc;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label38;
	}
}