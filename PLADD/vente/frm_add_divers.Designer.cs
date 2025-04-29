namespace Smart_Production_Pos.PLADD.vente
{
	partial class frm_add_divers
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
            this.txt_name_divers = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.kryptonButton12 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPriceU = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.SuspendLayout();
            // 
            // txt_name_divers
            // 
            this.txt_name_divers.Location = new System.Drawing.Point(127, 14);
            this.txt_name_divers.Margin = new System.Windows.Forms.Padding(5);
            this.txt_name_divers.Name = "txt_name_divers";
            this.txt_name_divers.Size = new System.Drawing.Size(293, 41);
            this.txt_name_divers.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.txt_name_divers.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txt_name_divers.StateCommon.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.txt_name_divers.StateCommon.Border.Rounding = 5;
            this.txt_name_divers.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name_divers.TabIndex = 1;
            this.txt_name_divers.Text = "منتج غير معروف";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Cairo Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(15, 20);
            this.label18.Name = "label18";
            this.label18.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label18.Size = new System.Drawing.Size(104, 30);
            this.label18.TabIndex = 122;
            this.label18.Text = "اسم المنتج :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // kryptonButton12
            // 
            this.kryptonButton12.Location = new System.Drawing.Point(248, 111);
            this.kryptonButton12.Name = "kryptonButton12";
            this.kryptonButton12.Size = new System.Drawing.Size(174, 41);
            this.kryptonButton12.StateCommon.Back.Color1 = System.Drawing.SystemColors.Highlight;
            this.kryptonButton12.StateCommon.Back.Color2 = System.Drawing.Color.DodgerBlue;
            this.kryptonButton12.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonButton12.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton12.StateCommon.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonButton12.StateCommon.Border.Rounding = 10;
            this.kryptonButton12.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonButton12.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton12.StateCommon.Content.ShortText.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.kryptonButton12.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.kryptonButton12.TabIndex = 124;
            this.kryptonButton12.Values.Image = global::Smart_Production_Pos.Properties.Resources.ajouter_un_bouton;
            this.kryptonButton12.Values.Text = "إضافة";
            this.kryptonButton12.Click += new System.EventHandler(this.kryptonButton12_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 68);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(109, 30);
            this.label3.TabIndex = 122;
            this.label3.Text = "سعر الوحدة :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPriceU
            // 
            this.txtPriceU.Location = new System.Drawing.Point(127, 62);
            this.txtPriceU.Margin = new System.Windows.Forms.Padding(5);
            this.txtPriceU.Name = "txtPriceU";
            this.txtPriceU.Size = new System.Drawing.Size(293, 41);
            this.txtPriceU.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
            this.txtPriceU.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtPriceU.StateCommon.Border.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.txtPriceU.StateCommon.Border.Rounding = 5;
            this.txtPriceU.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceU.TabIndex = 0;
            this.txtPriceU.Text = "0";
            this.txtPriceU.TextChanged += new System.EventHandler(this.txtPriceU_TextChanged);
            this.txtPriceU.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPriceU_KeyDown);
            // 
            // frm_add_divers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 161);
            this.Controls.Add(this.kryptonButton12);
            this.Controls.Add(this.txtPriceU);
            this.Controls.Add(this.txt_name_divers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label18);
            this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "frm_add_divers";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اضافة منتجات عشوائية";
            this.Load += new System.EventHandler(this.frm_add_divers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_name_divers;
		private System.Windows.Forms.Label label18;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton12;
		private System.Windows.Forms.Label label3;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPriceU;
	}
}