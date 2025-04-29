namespace Smart_Production_Pos.PLADD.vente
{
	partial class frm_remise
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.kryptonButton12 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_new_montant = new System.Windows.Forms.TextBox();
            this.txt_porcntg_remise = new System.Windows.Forms.TextBox();
            this.txt_montant_remise = new System.Windows.Forms.TextBox();
            this.txt_price_product = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.kryptonButton12);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.kryptonButton1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 278);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(15, 5, 5, 5);
            this.panel3.Size = new System.Drawing.Size(323, 52);
            this.panel3.TabIndex = 5;
            // 
            // kryptonButton12
            // 
            this.kryptonButton12.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonButton12.Location = new System.Drawing.Point(134, 5);
            this.kryptonButton12.Name = "kryptonButton12";
            this.kryptonButton12.Size = new System.Drawing.Size(175, 40);
            this.kryptonButton12.StateCommon.Back.Color1 = System.Drawing.SystemColors.MenuHighlight;
            this.kryptonButton12.StateCommon.Back.Color2 = System.Drawing.Color.DodgerBlue;
            this.kryptonButton12.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton12.StateCommon.Border.Rounding = 6;
            this.kryptonButton12.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonButton12.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton12.TabIndex = 8;
            this.kryptonButton12.Values.Image = global::Smart_Production_Pos.Properties.Resources.sauvegarder;
            this.kryptonButton12.Values.Text = "حفظ";
            this.kryptonButton12.Click += new System.EventHandler(this.kryptonButton12_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(117, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(17, 40);
            this.panel2.TabIndex = 7;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonButton1.Location = new System.Drawing.Point(15, 5);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(102, 40);
            this.kryptonButton1.StateCommon.Back.Color1 = System.Drawing.SystemColors.ControlDark;
            this.kryptonButton1.StateCommon.Back.Color2 = System.Drawing.Color.DimGray;
            this.kryptonButton1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateCommon.Border.Rounding = 6;
            this.kryptonButton1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 4;
            this.kryptonButton1.Values.Image = global::Smart_Production_Pos.Properties.Resources.sauvegarder;
            this.kryptonButton1.Values.Text = "إغلاق";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txt_new_montant);
            this.panel1.Controls.Add(this.txt_porcntg_remise);
            this.panel1.Controls.Add(this.txt_montant_remise);
            this.panel1.Controls.Add(this.txt_price_product);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 278);
            this.panel1.TabIndex = 6;
            // 
            // txt_new_montant
            // 
            this.txt_new_montant.BackColor = System.Drawing.Color.Gold;
            this.txt_new_montant.Font = new System.Drawing.Font("Arial CE", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_new_montant.Location = new System.Drawing.Point(8, 107);
            this.txt_new_montant.Name = "txt_new_montant";
            this.txt_new_montant.Size = new System.Drawing.Size(307, 29);
            this.txt_new_montant.TabIndex = 127;
            this.txt_new_montant.Text = "0";
            this.txt_new_montant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_new_montant.TextChanged += new System.EventHandler(this.txt_new_montant_TextChanged);
            // 
            // txt_porcntg_remise
            // 
            this.txt_porcntg_remise.BackColor = System.Drawing.Color.White;
            this.txt_porcntg_remise.Enabled = false;
            this.txt_porcntg_remise.Font = new System.Drawing.Font("Arial CE", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_porcntg_remise.Location = new System.Drawing.Point(8, 239);
            this.txt_porcntg_remise.Name = "txt_porcntg_remise";
            this.txt_porcntg_remise.Size = new System.Drawing.Size(307, 29);
            this.txt_porcntg_remise.TabIndex = 127;
            this.txt_porcntg_remise.Text = "0";
            this.txt_porcntg_remise.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_montant_remise
            // 
            this.txt_montant_remise.BackColor = System.Drawing.Color.White;
            this.txt_montant_remise.Font = new System.Drawing.Font("Arial CE", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_montant_remise.Location = new System.Drawing.Point(8, 174);
            this.txt_montant_remise.Name = "txt_montant_remise";
            this.txt_montant_remise.Size = new System.Drawing.Size(307, 29);
            this.txt_montant_remise.TabIndex = 127;
            this.txt_montant_remise.Text = "0";
            this.txt_montant_remise.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_montant_remise.TextChanged += new System.EventHandler(this.txt_montant_remise_TextChanged);
            // 
            // txt_price_product
            // 
            this.txt_price_product.BackColor = System.Drawing.Color.White;
            this.txt_price_product.Enabled = false;
            this.txt_price_product.Font = new System.Drawing.Font("Arial CE", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_price_product.Location = new System.Drawing.Point(8, 42);
            this.txt_price_product.Name = "txt_price_product";
            this.txt_price_product.Size = new System.Drawing.Size(307, 29);
            this.txt_price_product.TabIndex = 127;
            this.txt_price_product.Text = "0";
            this.txt_price_product.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(213, 74);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(104, 30);
            this.label3.TabIndex = 126;
            this.label3.Text = "المبلغ الجديد :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cairo Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(255, 206);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(62, 30);
            this.label2.TabIndex = 126;
            this.label2.Text = "النسبة :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(194, 141);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(123, 30);
            this.label1.TabIndex = 126;
            this.label1.Text = "المبلغ المخفَّض :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Cairo Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(217, 9);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(100, 30);
            this.label12.TabIndex = 126;
            this.label12.Text = "ثمن الفاتورة :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frm_remise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 330);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "frm_remise";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "صفحة التخفيضات";
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel3;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label12;
		public System.Windows.Forms.TextBox txt_new_montant;
		public System.Windows.Forms.TextBox txt_porcntg_remise;
		public System.Windows.Forms.TextBox txt_montant_remise;
		public System.Windows.Forms.TextBox txt_price_product;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton12;
		private System.Windows.Forms.Panel panel2;
	}
}