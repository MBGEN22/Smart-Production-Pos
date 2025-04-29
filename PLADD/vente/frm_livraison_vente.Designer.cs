namespace Smart_Production_Pos.PLADD.vente
{
	partial class frm_livraison_vente
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_livraison_vente));
			this.kryptonGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
			this.txt_nom_liv = new System.Windows.Forms.TextBox();
			this.txt_recu = new System.Windows.Forms.TextBox();
			this.txt_chaufeur = new System.Windows.Forms.TextBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.txt_price = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.cmb_type = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txt_matricule = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.kryptonButton4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).BeginInit();
			this.kryptonGroup1.Panel.SuspendLayout();
			this.kryptonGroup1.SuspendLayout();
			this.SuspendLayout();
			// 
			// kryptonGroup1
			// 
			this.kryptonGroup1.Dock = System.Windows.Forms.DockStyle.Top;
			this.kryptonGroup1.Location = new System.Drawing.Point(5, 5);
			this.kryptonGroup1.Name = "kryptonGroup1";
			// 
			// kryptonGroup1.Panel
			// 
			this.kryptonGroup1.Panel.Controls.Add(this.txt_nom_liv);
			this.kryptonGroup1.Panel.Controls.Add(this.txt_recu);
			this.kryptonGroup1.Panel.Controls.Add(this.txt_chaufeur);
			this.kryptonGroup1.Panel.Controls.Add(this.dateTimePicker1);
			this.kryptonGroup1.Panel.Controls.Add(this.txt_price);
			this.kryptonGroup1.Panel.Controls.Add(this.label7);
			this.kryptonGroup1.Panel.Controls.Add(this.cmb_type);
			this.kryptonGroup1.Panel.Controls.Add(this.label6);
			this.kryptonGroup1.Panel.Controls.Add(this.txt_matricule);
			this.kryptonGroup1.Panel.Controls.Add(this.label5);
			this.kryptonGroup1.Panel.Controls.Add(this.label4);
			this.kryptonGroup1.Panel.Controls.Add(this.label3);
			this.kryptonGroup1.Panel.Controls.Add(this.label2);
			this.kryptonGroup1.Panel.Controls.Add(this.label8);
			this.kryptonGroup1.Size = new System.Drawing.Size(514, 370);
			this.kryptonGroup1.StateCommon.Border.Color1 = System.Drawing.Color.DodgerBlue;
			this.kryptonGroup1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonGroup1.StateCommon.Border.Rounding = 10;
			this.kryptonGroup1.StateCommon.Border.Width = 3;
			this.kryptonGroup1.TabIndex = 126;
			// 
			// txt_nom_liv
			// 
			this.txt_nom_liv.Location = new System.Drawing.Point(6, 71);
			this.txt_nom_liv.Name = "txt_nom_liv";
			this.txt_nom_liv.Size = new System.Drawing.Size(385, 37);
			this.txt_nom_liv.TabIndex = 1;
			// 
			// txt_recu
			// 
			this.txt_recu.Location = new System.Drawing.Point(6, 115);
			this.txt_recu.Name = "txt_recu";
			this.txt_recu.Size = new System.Drawing.Size(385, 37);
			this.txt_recu.TabIndex = 1;
			// 
			// txt_chaufeur
			// 
			this.txt_chaufeur.Enabled = false;
			this.txt_chaufeur.Location = new System.Drawing.Point(6, 248);
			this.txt_chaufeur.Name = "txt_chaufeur";
			this.txt_chaufeur.Size = new System.Drawing.Size(359, 37);
			this.txt_chaufeur.TabIndex = 1;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(6, 27);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(426, 37);
			this.dateTimePicker1.TabIndex = 3;
			// 
			// txt_price
			// 
			this.txt_price.Enabled = false;
			this.txt_price.Location = new System.Drawing.Point(6, 204);
			this.txt_price.Name = "txt_price";
			this.txt_price.Size = new System.Drawing.Size(385, 37);
			this.txt_price.TabIndex = 1;
			this.txt_price.Text = "0";
			this.txt_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txt_price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_price_KeyPress);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.White;
			this.label7.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(362, 251);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(132, 30);
			this.label7.TabIndex = 0;
			this.label7.Text = "معلومات السائق :";
			// 
			// cmb_type
			// 
			this.cmb_type.FormattingEnabled = true;
			this.cmb_type.Items.AddRange(new object[] {
            "توصيل",
            "لا يوجد توصيل"});
			this.cmb_type.Location = new System.Drawing.Point(6, 159);
			this.cmb_type.Name = "cmb_type";
			this.cmb_type.Size = new System.Drawing.Size(385, 38);
			this.cmb_type.TabIndex = 2;
			this.cmb_type.SelectedIndexChanged += new System.EventHandler(this.cmb_type_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.White;
			this.label6.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(390, 207);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(104, 30);
			this.label6.TabIndex = 0;
			this.label6.Text = "سعر التوصيل :";
			// 
			// txt_matricule
			// 
			this.txt_matricule.Enabled = false;
			this.txt_matricule.Location = new System.Drawing.Point(6, 292);
			this.txt_matricule.Name = "txt_matricule";
			this.txt_matricule.Size = new System.Drawing.Size(396, 37);
			this.txt_matricule.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.White;
			this.label5.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(390, 162);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(98, 30);
			this.label5.TabIndex = 0;
			this.label5.Text = "نوع التوصيل :";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.White;
			this.label4.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(390, 117);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(107, 30);
			this.label4.TabIndex = 0;
			this.label4.Text = "اسم المسّتلم :";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.White;
			this.label3.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(390, 72);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(102, 30);
			this.label3.TabIndex = 0;
			this.label3.Text = "اسم المسّلم :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.White;
			this.label2.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(432, 30);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 30);
			this.label2.TabIndex = 0;
			this.label2.Text = "التاريخ :";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.White;
			this.label8.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(402, 297);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(95, 30);
			this.label8.TabIndex = 0;
			this.label8.Text = "رقم السيارة :";
			// 
			// kryptonButton4
			// 
			this.kryptonButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.kryptonButton4.Location = new System.Drawing.Point(247, 381);
			this.kryptonButton4.Name = "kryptonButton4";
			this.kryptonButton4.Size = new System.Drawing.Size(260, 55);
			this.kryptonButton4.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.kryptonButton4.StateCommon.Back.Color2 = System.Drawing.Color.DodgerBlue;
			this.kryptonButton4.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonButton4.StateCommon.Border.Rounding = 5;
			this.kryptonButton4.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
			this.kryptonButton4.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonButton4.TabIndex = 123;
			this.kryptonButton4.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton4.Values.Image")));
			this.kryptonButton4.Values.Text = "حفظ";
			this.kryptonButton4.Click += new System.EventHandler(this.kryptonButton4_Click);
			// 
			// frm_livraison_vente
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 30F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(524, 444);
			this.Controls.Add(this.kryptonGroup1);
			this.Controls.Add(this.kryptonButton4);
			this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
			this.Name = "frm_livraison_vente";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.RightToLeftLayout = true;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ارسا الفاتورة";
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).EndInit();
			this.kryptonGroup1.Panel.ResumeLayout(false);
			this.kryptonGroup1.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).EndInit();
			this.kryptonGroup1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonGroup kryptonGroup1;
		private System.Windows.Forms.TextBox txt_nom_liv;
		private System.Windows.Forms.TextBox txt_recu;
		private System.Windows.Forms.TextBox txt_chaufeur;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.TextBox txt_price;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cmb_type;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txt_matricule;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label8;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton4;
	}
}