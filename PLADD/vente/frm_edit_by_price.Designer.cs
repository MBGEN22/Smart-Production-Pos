namespace Smart_Production_Pos.PLADD.vente
{
	partial class frm_edit_by_price
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPriceU = new System.Windows.Forms.TextBox();
            this.txtPRice_balance = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQT = new System.Windows.Forms.TextBox();
            this.kryptonButton12 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "سعر الوحدة :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-2, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "السعر الموزون :";
            // 
            // txtPriceU
            // 
            this.txtPriceU.Enabled = false;
            this.txtPriceU.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPriceU.Location = new System.Drawing.Point(115, 16);
            this.txtPriceU.Name = "txtPriceU";
            this.txtPriceU.Size = new System.Drawing.Size(364, 37);
            this.txtPriceU.TabIndex = 0;
            this.txtPriceU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPRice_balance
            // 
            this.txtPRice_balance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPRice_balance.Location = new System.Drawing.Point(115, 61);
            this.txtPRice_balance.Name = "txtPRice_balance";
            this.txtPRice_balance.Size = new System.Drawing.Size(364, 37);
            this.txtPRice_balance.TabIndex = 1;
            this.txtPRice_balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPRice_balance.TextChanged += new System.EventHandler(this.txtPRice_balance_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "الكمية :";
            // 
            // txtQT
            // 
            this.txtQT.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQT.Location = new System.Drawing.Point(115, 106);
            this.txtQT.Name = "txtQT";
            this.txtQT.Size = new System.Drawing.Size(364, 37);
            this.txtQT.TabIndex = 2;
            this.txtQT.Text = "1";
            this.txtQT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kryptonButton12
            // 
            this.kryptonButton12.Location = new System.Drawing.Point(343, 149);
            this.kryptonButton12.Name = "kryptonButton12";
            this.kryptonButton12.Size = new System.Drawing.Size(136, 46);
            this.kryptonButton12.StateCommon.Back.Color1 = System.Drawing.SystemColors.Highlight;
            this.kryptonButton12.StateCommon.Back.Color2 = System.Drawing.Color.DodgerBlue;
            this.kryptonButton12.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton12.StateCommon.Border.Rounding = 10;
            this.kryptonButton12.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonButton12.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton12.TabIndex = 3;
            this.kryptonButton12.Values.Image = global::Smart_Production_Pos.Properties.Resources.save1;
            this.kryptonButton12.Values.Text = "حفظ";
            this.kryptonButton12.Click += new System.EventHandler(this.kryptonButton12_Click);
            // 
            // frm_edit_by_price
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 213);
            this.Controls.Add(this.kryptonButton12);
            this.Controls.Add(this.txtQT);
            this.Controls.Add(this.txtPRice_balance);
            this.Controls.Add(this.txtPriceU);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frm_edit_by_price";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_edit_by_price_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton12;
		public System.Windows.Forms.TextBox txtPriceU;
		public System.Windows.Forms.TextBox txtPRice_balance;
		public System.Windows.Forms.TextBox txtQT;
	}
}