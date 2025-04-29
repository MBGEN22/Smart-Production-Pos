namespace Smart_Production_Pos.PLADD.Achat_revente
{
	partial class frm_edit_Pack_information
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
			this.txtBarcode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_designation = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.check_favoire_U = new System.Windows.Forms.CheckBox();
			this.cmb_favoire = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txt_vente_1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.kryptonButton4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.cmb_favoire)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// txtBarcode
			// 
			this.txtBarcode.Enabled = false;
			this.txtBarcode.Location = new System.Drawing.Point(106, 50);
			this.txtBarcode.Margin = new System.Windows.Forms.Padding(5);
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.Size = new System.Drawing.Size(330, 41);
			this.txtBarcode.StateCommon.Border.Color1 = System.Drawing.Color.Red;
			this.txtBarcode.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txtBarcode.StateCommon.Border.Rounding = 5;
			this.txtBarcode.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBarcode.TabIndex = 113;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(18, 56);
			this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label3.Name = "label3";
			this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label3.Size = new System.Drawing.Size(86, 30);
			this.label3.TabIndex = 114;
			this.label3.Text = "رمز الحزمة :";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label1.Name = "label1";
			this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label1.Size = new System.Drawing.Size(95, 30);
			this.label1.TabIndex = 112;
			this.label1.Text = "اسم الحزمة :";
			// 
			// txt_designation
			// 
			this.txt_designation.Location = new System.Drawing.Point(107, 4);
			this.txt_designation.Margin = new System.Windows.Forms.Padding(5);
			this.txt_designation.Name = "txt_designation";
			this.txt_designation.Size = new System.Drawing.Size(329, 41);
			this.txt_designation.StateCommon.Border.Color1 = System.Drawing.Color.Red;
			this.txt_designation.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txt_designation.StateCommon.Border.Rounding = 5;
			this.txt_designation.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_designation.TabIndex = 111;
			// 
			// check_favoire_U
			// 
			this.check_favoire_U.AutoSize = true;
			this.check_favoire_U.BackColor = System.Drawing.Color.Transparent;
			this.check_favoire_U.ForeColor = System.Drawing.Color.Coral;
			this.check_favoire_U.Location = new System.Drawing.Point(421, 113);
			this.check_favoire_U.Name = "check_favoire_U";
			this.check_favoire_U.Size = new System.Drawing.Size(15, 14);
			this.check_favoire_U.TabIndex = 127;
			this.check_favoire_U.UseVisualStyleBackColor = false;
			this.check_favoire_U.CheckedChanged += new System.EventHandler(this.check_favoire_U_CheckedChanged);
			// 
			// cmb_favoire
			// 
			this.cmb_favoire.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmb_favoire.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmb_favoire.DropDownWidth = 239;
			this.cmb_favoire.Enabled = false;
			this.cmb_favoire.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.cmb_favoire.Location = new System.Drawing.Point(107, 98);
			this.cmb_favoire.Name = "cmb_favoire";
			this.cmb_favoire.Size = new System.Drawing.Size(308, 41);
			this.cmb_favoire.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.Gray;
			this.cmb_favoire.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.cmb_favoire.StateCommon.ComboBox.Border.Rounding = 8;
			this.cmb_favoire.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmb_favoire.TabIndex = 129;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.ForeColor = System.Drawing.Color.Black;
			this.label13.Location = new System.Drawing.Point(26, 104);
			this.label13.Name = "label13";
			this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label13.Size = new System.Drawing.Size(78, 30);
			this.label13.TabIndex = 128;
			this.label13.Text = "المفضلة :";
			// 
			// txt_vente_1
			// 
			this.txt_vente_1.Location = new System.Drawing.Point(107, 145);
			this.txt_vente_1.Name = "txt_vente_1";
			this.txt_vente_1.Size = new System.Drawing.Size(329, 39);
			this.txt_vente_1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.txt_vente_1.StateCommon.Border.Color1 = System.Drawing.Color.Red;
			this.txt_vente_1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txt_vente_1.StateCommon.Border.Rounding = 8;
			this.txt_vente_1.StateCommon.Content.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_vente_1.TabIndex = 133;
			this.txt_vente_1.Text = "0";
			this.txt_vente_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.ForeColor = System.Drawing.Color.Black;
			this.label16.Location = new System.Drawing.Point(23, 149);
			this.label16.Name = "label16";
			this.label16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label16.Size = new System.Drawing.Size(81, 30);
			this.label16.TabIndex = 131;
			this.label16.Text = "سعر البيع :";
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = global::Smart_Production_Pos.Properties.Resources.stock;
			this.pictureBox2.Location = new System.Drawing.Point(303, 191);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(134, 128);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 136;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
			// 
			// kryptonButton4
			// 
			this.kryptonButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.kryptonButton4.Location = new System.Drawing.Point(107, 269);
			this.kryptonButton4.Name = "kryptonButton4";
			this.kryptonButton4.Size = new System.Drawing.Size(190, 50);
			this.kryptonButton4.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.kryptonButton4.StateCommon.Back.Color2 = System.Drawing.Color.DodgerBlue;
			this.kryptonButton4.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonButton4.StateCommon.Border.Rounding = 5;
			this.kryptonButton4.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
			this.kryptonButton4.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonButton4.TabIndex = 137;
			this.kryptonButton4.Values.Image = global::Smart_Production_Pos.Properties.Resources.editer;
			this.kryptonButton4.Values.Text = "تعديل المنتوج";
			this.kryptonButton4.Click += new System.EventHandler(this.kryptonButton4_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// frm_edit_Pack_information
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 30F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(450, 324);
			this.Controls.Add(this.kryptonButton4);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.txt_vente_1);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.check_favoire_U);
			this.Controls.Add(this.cmb_favoire);
			this.Controls.Add(this.txtBarcode);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txt_designation);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
			this.Name = "frm_edit_Pack_information";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.RightToLeftLayout = true;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "تغيير معلومات الحزمة";
			((System.ComponentModel.ISupportInitialize)(this.cmb_favoire)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBarcode;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label1;
		public ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_designation;
		public System.Windows.Forms.CheckBox check_favoire_U;
		public ComponentFactory.Krypton.Toolkit.KryptonComboBox cmb_favoire;
		public System.Windows.Forms.Label label13;
		public ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_vente_1;
		public System.Windows.Forms.Label label16;
		public System.Windows.Forms.PictureBox pictureBox2;
		public ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton4;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}