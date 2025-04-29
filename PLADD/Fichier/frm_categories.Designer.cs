namespace Smart_Production_Pos.PLADD.Fichier
{
	partial class frm_categories
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
			this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.txt_Stocke = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// kryptonButton1
			// 
			this.kryptonButton1.Location = new System.Drawing.Point(7, 65);
			this.kryptonButton1.Name = "kryptonButton1";
			this.kryptonButton1.Size = new System.Drawing.Size(436, 54);
			this.kryptonButton1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.kryptonButton1.StateCommon.Back.Color2 = System.Drawing.Color.Teal;
			this.kryptonButton1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonButton1.StateCommon.Border.Rounding = 5;
			this.kryptonButton1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
			this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonButton1.TabIndex = 9;
			this.kryptonButton1.Values.Image = global::Smart_Production_Pos.Properties.Resources.sauvegarder;
			this.kryptonButton1.Values.Text = "حفظ";
			this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
			// 
			// txt_Stocke
			// 
			this.txt_Stocke.Location = new System.Drawing.Point(107, 12);
			this.txt_Stocke.Name = "txt_Stocke";
			this.txt_Stocke.Size = new System.Drawing.Size(336, 47);
			this.txt_Stocke.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txt_Stocke.StateCommon.Border.Rounding = 15;
			this.txt_Stocke.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_Stocke.TabIndex = 8;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(7, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 30);
			this.label1.TabIndex = 7;
			this.label1.Text = "اسم الصنف :";
			// 
			// frm_categories
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(455, 137);
			this.Controls.Add(this.kryptonButton1);
			this.Controls.Add(this.txt_Stocke);
			this.Controls.Add(this.label1);
			this.Name = "frm_categories";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.RightToLeftLayout = true;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "تسيير الأصناف";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
		private System.Windows.Forms.Label label1;
		public ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_Stocke;
	}
}