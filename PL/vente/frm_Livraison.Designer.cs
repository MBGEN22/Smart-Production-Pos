namespace Smart_Production_Pos.PL.vente
{
	partial class frm_Livraison
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pn_historique_client = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.kryptonGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
			this.groupBox1 = new Shade.Controls.GroupBox();
			this.cmb_client = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox2 = new Shade.Controls.GroupBox();
			this.kryptonDateTimePicker1 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
			this.button2 = new System.Windows.Forms.Button();
			this.txt_Search = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
			this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.pn_historique_client.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).BeginInit();
			this.kryptonGroup1.Panel.SuspendLayout();
			this.kryptonGroup1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmb_client)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pn_historique_client
			// 
			this.pn_historique_client.BackColor = System.Drawing.Color.White;
			this.pn_historique_client.Controls.Add(this.panel3);
			this.pn_historique_client.Controls.Add(this.panel2);
			this.pn_historique_client.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pn_historique_client.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pn_historique_client.Location = new System.Drawing.Point(0, 0);
			this.pn_historique_client.Name = "pn_historique_client";
			this.pn_historique_client.Size = new System.Drawing.Size(1174, 594);
			this.pn_historique_client.TabIndex = 8;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.White;
			this.panel3.Controls.Add(this.dataGridView1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 164);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1174, 430);
			this.panel3.TabIndex = 2;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToOrderColumns = true;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle5.NullValue = null;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
			this.dataGridView1.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
			this.dataGridView1.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.dataGridView1.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.dataGridView1.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.On;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridView1.Size = new System.Drawing.Size(1174, 430);
			this.dataGridView1.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
			this.dataGridView1.StateCommon.DataCell.Border.Color1 = System.Drawing.Color.Black;
			this.dataGridView1.StateCommon.DataCell.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.dataGridView1.StateCommon.DataCell.Content.Color1 = System.Drawing.Color.Black;
			this.dataGridView1.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dataGridView1.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.White;
			this.dataGridView1.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dataGridView1.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed;
			this.dataGridView1.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.White;
			this.dataGridView1.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.dataGridView1.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black;
			this.dataGridView1.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black;
			this.dataGridView1.StateCommon.HeaderColumn.Content.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed;
			this.dataGridView1.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dataGridView1.TabIndex = 2;
			this.dataGridView1.VirtualMode = true;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.White;
			this.panel2.Controls.Add(this.kryptonGroup1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(5);
			this.panel2.Size = new System.Drawing.Size(1174, 164);
			this.panel2.TabIndex = 1;
			// 
			// kryptonGroup1
			// 
			this.kryptonGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonGroup1.Location = new System.Drawing.Point(5, 5);
			this.kryptonGroup1.Name = "kryptonGroup1";
			// 
			// kryptonGroup1.Panel
			// 
			this.kryptonGroup1.Panel.Controls.Add(this.groupBox1);
			this.kryptonGroup1.Panel.Controls.Add(this.groupBox2);
			this.kryptonGroup1.Panel.Controls.Add(this.txt_Search);
			this.kryptonGroup1.Panel.Controls.Add(this.bigLabel1);
			this.kryptonGroup1.Panel.Controls.Add(this.kryptonButton2);
			this.kryptonGroup1.Size = new System.Drawing.Size(1164, 154);
			this.kryptonGroup1.StateCommon.Border.Color1 = System.Drawing.Color.DodgerBlue;
			this.kryptonGroup1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonGroup1.StateCommon.Border.Rounding = 10;
			this.kryptonGroup1.StateCommon.Border.Width = 2;
			this.kryptonGroup1.TabIndex = 6;
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
			this.groupBox1.Controls.Add(this.cmb_client);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
			this.groupBox1.HeaderColor = System.Drawing.Color.White;
			this.groupBox1.Location = new System.Drawing.Point(866, 3);
			this.groupBox1.MinimumSize = new System.Drawing.Size(136, 50);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
			this.groupBox1.Size = new System.Drawing.Size(276, 79);
			this.groupBox1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.groupBox1.TabIndex = 4;
			this.groupBox1.Text = "البحث عن طريق الزبون";
			// 
			// cmb_client
			// 
			this.cmb_client.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmb_client.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmb_client.DropDownWidth = 229;
			this.cmb_client.Location = new System.Drawing.Point(41, 30);
			this.cmb_client.Name = "cmb_client";
			this.cmb_client.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.cmb_client.Size = new System.Drawing.Size(224, 41);
			this.cmb_client.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.DodgerBlue;
			this.cmb_client.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.cmb_client.StateCommon.ComboBox.Border.Rounding = 8;
			this.cmb_client.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmb_client.StateCommon.Item.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.cmb_client.StateCommon.Item.Border.Rounding = 15;
			this.cmb_client.StateCommon.Item.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmb_client.TabIndex = 5;
			this.cmb_client.Tag = "search";
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
			this.groupBox2.Controls.Add(this.kryptonDateTimePicker1);
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
			this.groupBox2.HeaderColor = System.Drawing.Color.White;
			this.groupBox2.Location = new System.Drawing.Point(576, 3);
			this.groupBox2.MinimumSize = new System.Drawing.Size(136, 50);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
			this.groupBox2.Size = new System.Drawing.Size(284, 79);
			this.groupBox2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.groupBox2.TabIndex = 4;
			this.groupBox2.Text = "البحث عن طريق التاريخ";
			// 
			// kryptonDateTimePicker1
			// 
			this.kryptonDateTimePicker1.Location = new System.Drawing.Point(47, 31);
			this.kryptonDateTimePicker1.Name = "kryptonDateTimePicker1";
			this.kryptonDateTimePicker1.Size = new System.Drawing.Size(229, 41);
			this.kryptonDateTimePicker1.StateCommon.Border.Color1 = System.Drawing.Color.DodgerBlue;
			this.kryptonDateTimePicker1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonDateTimePicker1.StateCommon.Border.Rounding = 9;
			this.kryptonDateTimePicker1.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonDateTimePicker1.TabIndex = 5;
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
			// txt_Search
			// 
			this.txt_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_Search.Location = new System.Drawing.Point(157, 29);
			this.txt_Search.Name = "txt_Search";
			this.txt_Search.Size = new System.Drawing.Size(307, 43);
			this.txt_Search.StateCommon.Border.Color1 = System.Drawing.Color.DodgerBlue;
			this.txt_Search.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txt_Search.StateCommon.Border.Rounding = 10;
			this.txt_Search.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_Search.TabIndex = 2;
			this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
			// 
			// bigLabel1
			// 
			this.bigLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bigLabel1.AutoSize = true;
			this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
			this.bigLabel1.Font = new System.Drawing.Font("Cairo", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bigLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.bigLabel1.Location = new System.Drawing.Point(458, 17);
			this.bigLabel1.Name = "bigLabel1";
			this.bigLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.bigLabel1.Size = new System.Drawing.Size(116, 62);
			this.bigLabel1.TabIndex = 0;
			this.bigLabel1.Text = "البحث :";
			// 
			// kryptonButton2
			// 
			this.kryptonButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.kryptonButton2.Location = new System.Drawing.Point(870, 88);
			this.kryptonButton2.Name = "kryptonButton2";
			this.kryptonButton2.Size = new System.Drawing.Size(272, 44);
			this.kryptonButton2.StateCommon.Back.Color1 = System.Drawing.Color.Red;
			this.kryptonButton2.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.kryptonButton2.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed;
			this.kryptonButton2.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonButton2.StateCommon.Border.Rounding = 5;
			this.kryptonButton2.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
			this.kryptonButton2.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonButton2.TabIndex = 0;
			this.kryptonButton2.Values.Image = global::Smart_Production_Pos.Properties.Resources.imprimerw2;
			this.kryptonButton2.Values.Text = "ورقة النقل";
			this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
			// 
			// frm_Livraison
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 30F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1174, 594);
			this.Controls.Add(this.pn_historique_client);
			this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
			this.Name = "frm_Livraison";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frm_Livraison";
			this.pn_historique_client.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).EndInit();
			this.kryptonGroup1.Panel.ResumeLayout(false);
			this.kryptonGroup1.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).EndInit();
			this.kryptonGroup1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmb_client)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.Panel pn_historique_client;
		private System.Windows.Forms.Panel panel3;
		public ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridView1;
		private System.Windows.Forms.Panel panel2;
		private ComponentFactory.Krypton.Toolkit.KryptonGroup kryptonGroup1;
		private Shade.Controls.GroupBox groupBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmb_client;
		private System.Windows.Forms.Button button1;
		private Shade.Controls.GroupBox groupBox2;
		private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker1;
		private System.Windows.Forms.Button button2;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_Search;
		private ReaLTaiizor.Controls.BigLabel bigLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
	}
}