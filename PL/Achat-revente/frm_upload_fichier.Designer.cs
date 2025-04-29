namespace Smart_Production_Pos.PL.Achat_revente
{
	partial class frm_upload_fichier
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
			this.kryptonButton4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txt_detaille = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// kryptonButton4
			// 
			this.kryptonButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.kryptonButton4.Location = new System.Drawing.Point(19, 457);
			this.kryptonButton4.Name = "kryptonButton4";
			this.kryptonButton4.Size = new System.Drawing.Size(135, 46);
			this.kryptonButton4.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.kryptonButton4.StateCommon.Back.Color2 = System.Drawing.Color.DodgerBlue;
			this.kryptonButton4.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonButton4.StateCommon.Border.Rounding = 5;
			this.kryptonButton4.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
			this.kryptonButton4.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonButton4.TabIndex = 125;
			this.kryptonButton4.Values.Image = global::Smart_Production_Pos.Properties.Resources.sauvegarder;
			this.kryptonButton4.Values.Text = "حفظ";
			this.kryptonButton4.Click += new System.EventHandler(this.kryptonButton4_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::Smart_Production_Pos.Properties.Resources.photo;
			this.pictureBox1.Location = new System.Drawing.Point(368, 273);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(234, 230);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 124;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(14, 9);
			this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 30);
			this.label8.TabIndex = 122;
			this.label8.Text = "ملاحظة :";
			// 
			// txt_detaille
			// 
			this.txt_detaille.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_detaille.Location = new System.Drawing.Point(19, 39);
			this.txt_detaille.Multiline = true;
			this.txt_detaille.Name = "txt_detaille";
			this.txt_detaille.Size = new System.Drawing.Size(583, 228);
			this.txt_detaille.StateCommon.Border.Color1 = System.Drawing.Color.Red;
			this.txt_detaille.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txt_detaille.StateCommon.Border.Rounding = 8;
			this.txt_detaille.StateCommon.Content.Font = new System.Drawing.Font("Yu Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_detaille.TabIndex = 123;
			this.txt_detaille.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// frm_upload_fichier
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 30F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(614, 515);
			this.Controls.Add(this.kryptonButton4);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txt_detaille);
			this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
			this.Name = "frm_upload_fichier";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.RightToLeftLayout = true;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "تحميل ملف تابع للفاتورة";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton4;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label8;
		public ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_detaille;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}