namespace Smart_Production_Pos.PLADD.PL_Statistique
{
	partial class frm_add_versement_ouberier
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_add_versement_ouberier));
			this.txtDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
			this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.separator1 = new Shade.Controls.Separator();
			this.separator3 = new Shade.Controls.Separator();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_money = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.txt_remarque = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmb_ouverier = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			((System.ComponentModel.ISupportInitialize)(this.cmb_ouverier)).BeginInit();
			this.SuspendLayout();
			// 
			// txtDate
			// 
			this.txtDate.Location = new System.Drawing.Point(99, 11);
			this.txtDate.Name = "txtDate";
			this.txtDate.Size = new System.Drawing.Size(377, 37);
			this.txtDate.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
			this.txtDate.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txtDate.StateCommon.Border.Rounding = 3;
			this.txtDate.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDate.TabIndex = 136;
			// 
			// kryptonButton2
			// 
			this.kryptonButton2.Location = new System.Drawing.Point(38, 272);
			this.kryptonButton2.Name = "kryptonButton2";
			this.kryptonButton2.Size = new System.Drawing.Size(149, 45);
			this.kryptonButton2.StateCommon.Back.Color1 = System.Drawing.Color.Gray;
			this.kryptonButton2.StateCommon.Back.Color2 = System.Drawing.Color.LightSlateGray;
			this.kryptonButton2.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonButton2.StateCommon.Border.Rounding = 5;
			this.kryptonButton2.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
			this.kryptonButton2.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonButton2.TabIndex = 140;
			this.kryptonButton2.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton2.Values.Image")));
			this.kryptonButton2.Values.Text = "إغلاق";
			this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
			// 
			// kryptonButton1
			// 
			this.kryptonButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.kryptonButton1.Location = new System.Drawing.Point(288, 272);
			this.kryptonButton1.Name = "kryptonButton1";
			this.kryptonButton1.Size = new System.Drawing.Size(188, 47);
			this.kryptonButton1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.kryptonButton1.StateCommon.Back.Color2 = System.Drawing.Color.LimeGreen;
			this.kryptonButton1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonButton1.StateCommon.Border.Rounding = 5;
			this.kryptonButton1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
			this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonButton1.TabIndex = 139;
			this.kryptonButton1.Values.Image = global::Smart_Production_Pos.Properties.Resources.sauvegarder;
			this.kryptonButton1.Values.Text = "حفظ";
			this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
			// 
			// separator1
			// 
			this.separator1.LineColor = System.Drawing.Color.Gray;
			this.separator1.Location = new System.Drawing.Point(38, 48);
			this.separator1.Name = "separator1";
			this.separator1.Size = new System.Drawing.Size(440, 13);
			this.separator1.TabIndex = 137;
			this.separator1.Text = "separator1";
			// 
			// separator3
			// 
			this.separator3.LineColor = System.Drawing.Color.Gray;
			this.separator3.Location = new System.Drawing.Point(38, 253);
			this.separator3.Name = "separator3";
			this.separator3.Size = new System.Drawing.Size(440, 13);
			this.separator3.TabIndex = 138;
			this.separator3.Text = "separator1";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(33, 11);
			this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 30);
			this.label3.TabIndex = 133;
			this.label3.Text = "التاريخ :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(33, 106);
			this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 30);
			this.label2.TabIndex = 134;
			this.label2.Text = "المبلغ :";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(21, 149);
			this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 30);
			this.label1.TabIndex = 135;
			this.label1.Text = "ملاحظة :";
			// 
			// txt_money
			// 
			this.txt_money.Location = new System.Drawing.Point(99, 102);
			this.txt_money.Margin = new System.Windows.Forms.Padding(5);
			this.txt_money.Name = "txt_money";
			this.txt_money.Size = new System.Drawing.Size(377, 39);
			this.txt_money.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txt_money.StateCommon.Border.Rounding = 3;
			this.txt_money.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_money.TabIndex = 132;
			this.txt_money.Text = "0";
			this.txt_money.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txt_remarque
			// 
			this.txt_remarque.Location = new System.Drawing.Point(99, 149);
			this.txt_remarque.Margin = new System.Windows.Forms.Padding(5);
			this.txt_remarque.Multiline = true;
			this.txt_remarque.Name = "txt_remarque";
			this.txt_remarque.Size = new System.Drawing.Size(377, 96);
			this.txt_remarque.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txt_remarque.StateCommon.Border.Rounding = 3;
			this.txt_remarque.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_remarque.TabIndex = 131;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(28, 64);
			this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 30);
			this.label4.TabIndex = 135;
			this.label4.Text = "العامل :";
			// 
			// cmb_ouverier
			// 
			this.cmb_ouverier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmb_ouverier.DropDownWidth = 219;
			this.cmb_ouverier.Location = new System.Drawing.Point(99, 58);
			this.cmb_ouverier.Name = "cmb_ouverier";
			this.cmb_ouverier.Size = new System.Drawing.Size(377, 38);
			this.cmb_ouverier.StateCommon.ComboBox.Border.Color1 = System.Drawing.Color.DarkGray;
			this.cmb_ouverier.StateCommon.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.cmb_ouverier.StateCommon.ComboBox.Border.Rounding = 4;
			this.cmb_ouverier.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmb_ouverier.TabIndex = 141;
			// 
			// frm_add_versement_ouberier
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 30F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(494, 330);
			this.Controls.Add(this.cmb_ouverier);
			this.Controls.Add(this.txtDate);
			this.Controls.Add(this.kryptonButton2);
			this.Controls.Add(this.kryptonButton1);
			this.Controls.Add(this.separator1);
			this.Controls.Add(this.separator3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txt_money);
			this.Controls.Add(this.txt_remarque);
			this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
			this.Name = "frm_add_versement_ouberier";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.RightToLeftLayout = true;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frm_add_versement_ouberier";
			((System.ComponentModel.ISupportInitialize)(this.cmb_ouverier)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker txtDate;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
		public ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
		public Shade.Controls.Separator separator1;
		public Shade.Controls.Separator separator3;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
		public ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_money;
		public ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_remarque;
		public System.Windows.Forms.Label label4;
		public ComponentFactory.Krypton.Toolkit.KryptonComboBox cmb_ouverier;
	}
}