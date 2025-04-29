namespace Smart_Production_Pos.PLADD.PL_Statistique
{
	partial class frm_add_depense
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_add_depense));
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_money = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.txt_causse = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.txtDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
			this.separator3 = new Shade.Controls.Separator();
			this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.separator1 = new Shade.Controls.Separator();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 25);
			this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 30);
			this.label3.TabIndex = 27;
			this.label3.Text = "التاريخ :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 181);
			this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(110, 30);
			this.label2.TabIndex = 28;
			this.label2.Text = "قيمة الخسارة :";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 75);
			this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(106, 30);
			this.label1.TabIndex = 29;
			this.label1.Text = "سبب الخسارة :";
			// 
			// txt_money
			// 
			this.txt_money.Location = new System.Drawing.Point(130, 176);
			this.txt_money.Margin = new System.Windows.Forms.Padding(5);
			this.txt_money.Name = "txt_money";
			this.txt_money.Size = new System.Drawing.Size(327, 39);
			this.txt_money.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txt_money.StateCommon.Border.Rounding = 3;
			this.txt_money.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_money.TabIndex = 26;
			this.txt_money.Text = "0";
			this.txt_money.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txt_money.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_money_KeyPress);
			// 
			// txt_causse
			// 
			this.txt_causse.Location = new System.Drawing.Point(130, 75);
			this.txt_causse.Margin = new System.Windows.Forms.Padding(5);
			this.txt_causse.Multiline = true;
			this.txt_causse.Name = "txt_causse";
			this.txt_causse.Size = new System.Drawing.Size(327, 96);
			this.txt_causse.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txt_causse.StateCommon.Border.Rounding = 3;
			this.txt_causse.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_causse.TabIndex = 25;
			// 
			// txtDate
			// 
			this.txtDate.Location = new System.Drawing.Point(80, 25);
			this.txtDate.Name = "txtDate";
			this.txtDate.Size = new System.Drawing.Size(377, 37);
			this.txtDate.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
			this.txtDate.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txtDate.StateCommon.Border.Rounding = 3;
			this.txtDate.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDate.TabIndex = 30;
			// 
			// separator3
			// 
			this.separator3.LineColor = System.Drawing.Color.Gray;
			this.separator3.Location = new System.Drawing.Point(19, 223);
			this.separator3.Name = "separator3";
			this.separator3.Size = new System.Drawing.Size(440, 13);
			this.separator3.TabIndex = 31;
			this.separator3.Text = "separator1";
			// 
			// kryptonButton1
			// 
			this.kryptonButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.kryptonButton1.Location = new System.Drawing.Point(269, 242);
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
			this.kryptonButton1.TabIndex = 32;
			this.kryptonButton1.Values.Image = global::Smart_Production_Pos.Properties.Resources.sauvegarder;
			this.kryptonButton1.Values.Text = "حفظ";
			this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
			// 
			// kryptonButton2
			// 
			this.kryptonButton2.Location = new System.Drawing.Point(19, 242);
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
			this.kryptonButton2.TabIndex = 130;
			this.kryptonButton2.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton2.Values.Image")));
			this.kryptonButton2.Values.Text = "إغلاق";
			this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
			// 
			// separator1
			// 
			this.separator1.LineColor = System.Drawing.Color.Gray;
			this.separator1.Location = new System.Drawing.Point(19, 62);
			this.separator1.Name = "separator1";
			this.separator1.Size = new System.Drawing.Size(440, 13);
			this.separator1.TabIndex = 31;
			this.separator1.Text = "separator1";
			// 
			// frm_add_depense
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 30F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(471, 304);
			this.Controls.Add(this.txtDate);
			this.Controls.Add(this.kryptonButton2);
			this.Controls.Add(this.kryptonButton1);
			this.Controls.Add(this.separator1);
			this.Controls.Add(this.separator3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txt_money);
			this.Controls.Add(this.txt_causse);
			this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
			this.Name = "frm_add_depense";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.RightToLeftLayout = true;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ر";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
		public ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_money;
		public ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_causse;
		public Shade.Controls.Separator separator3;
		public ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
		public Shade.Controls.Separator separator1;
		public ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker txtDate;
	}
}