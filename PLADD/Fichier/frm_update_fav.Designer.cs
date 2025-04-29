namespace Smart_Production_Pos.PLADD.Fichier
{
	partial class frm_update_fav
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
			this.txt_reference = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.kryptonButton4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.SuspendLayout();
			// 
			// txt_reference
			// 
			this.txt_reference.Location = new System.Drawing.Point(82, 22);
			this.txt_reference.Margin = new System.Windows.Forms.Padding(5);
			this.txt_reference.Name = "txt_reference";
			this.txt_reference.Size = new System.Drawing.Size(274, 41);
			this.txt_reference.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
			this.txt_reference.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txt_reference.StateCommon.Border.Rounding = 5;
			this.txt_reference.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_reference.TabIndex = 122;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.ForeColor = System.Drawing.Color.Black;
			this.label13.Location = new System.Drawing.Point(9, 28);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(74, 29);
			this.label13.TabIndex = 121;
			this.label13.Text = "المفضلة :";
			// 
			// kryptonButton4
			// 
			this.kryptonButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.kryptonButton4.Location = new System.Drawing.Point(82, 71);
			this.kryptonButton4.Name = "kryptonButton4";
			this.kryptonButton4.Size = new System.Drawing.Size(274, 46);
			this.kryptonButton4.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.kryptonButton4.StateCommon.Back.Color2 = System.Drawing.Color.DodgerBlue;
			this.kryptonButton4.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonButton4.StateCommon.Border.Rounding = 5;
			this.kryptonButton4.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
			this.kryptonButton4.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonButton4.TabIndex = 123;
			this.kryptonButton4.Values.Image = global::Smart_Production_Pos.Properties.Resources.sauvegarder;
			this.kryptonButton4.Values.Text = "حفظ";
			this.kryptonButton4.Click += new System.EventHandler(this.kryptonButton4_Click);
			// 
			// frm_update_fav
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(365, 132);
			this.Controls.Add(this.kryptonButton4);
			this.Controls.Add(this.txt_reference);
			this.Controls.Add(this.label13);
			this.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "frm_update_fav";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.RightToLeftLayout = true;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "تعديل اسم المفضلة";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label13;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton4;
		public ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_reference;
	}
}