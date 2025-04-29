namespace Smart_Production_Pos.PLADD.vente
{
    partial class frm_change_Price
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
            this.txt_new_montant = new System.Windows.Forms.TextBox();
            this.txt_price_product = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.kryptonButton12 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_new_montant
            // 
            this.txt_new_montant.BackColor = System.Drawing.Color.Gold;
            this.txt_new_montant.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_new_montant.Location = new System.Drawing.Point(13, 98);
            this.txt_new_montant.Name = "txt_new_montant";
            this.txt_new_montant.Size = new System.Drawing.Size(307, 29);
            this.txt_new_montant.TabIndex = 127;
            this.txt_new_montant.Text = "0";
            this.txt_new_montant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_price_product
            // 
            this.txt_price_product.BackColor = System.Drawing.Color.White;
            this.txt_price_product.Enabled = false;
            this.txt_price_product.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_price_product.Location = new System.Drawing.Point(13, 33);
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
            this.label3.Location = new System.Drawing.Point(217, 65);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(119, 30);
            this.label3.TabIndex = 126;
            this.label3.Text = "المبلغ الجديد :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Cairo Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(231, 0);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(102, 30);
            this.label12.TabIndex = 126;
            this.label12.Text = "ثمن المنتج :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txt_new_montant);
            this.panel1.Controls.Add(this.txt_price_product);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 149);
            this.panel1.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.kryptonButton12);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.kryptonButton1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 149);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(15, 5, 5, 5);
            this.panel3.Size = new System.Drawing.Size(332, 52);
            this.panel3.TabIndex = 8;
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
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // frm_change_Price
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 201);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "frm_change_Price";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "خصم للمنتج";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox txt_new_montant;
        public System.Windows.Forms.TextBox txt_price_product;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton12;
        private System.Windows.Forms.Panel panel2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
    }
}