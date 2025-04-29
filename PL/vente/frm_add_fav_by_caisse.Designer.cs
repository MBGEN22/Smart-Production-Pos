namespace Smart_Production_Pos.PL.vente
{
    partial class frm_add_fav_by_caisse
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pack_check_produit_revent = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.check_produit_revent = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 56);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(285, 37);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.pack_check_produit_revent);
            this.panel1.Controls.Add(this.check_produit_revent);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cmbProduct);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(393, 247);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(96, 199);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(200, 34);
            this.checkBox1.TabIndex = 125;
            this.checkBox1.Text = "تعديل اسم المفضلة فقط";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pack_check_produit_revent
            // 
            this.pack_check_produit_revent.Location = new System.Drawing.Point(204, 12);
            this.pack_check_produit_revent.Name = "pack_check_produit_revent";
            this.pack_check_produit_revent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pack_check_produit_revent.Size = new System.Drawing.Size(92, 34);
            this.pack_check_produit_revent.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pack_check_produit_revent.StateCommon.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pack_check_produit_revent.TabIndex = 123;
            this.pack_check_produit_revent.Values.Text = "حزمة منتج";
            this.pack_check_produit_revent.CheckedChanged += new System.EventHandler(this.pack_check_produit_revent_CheckedChanged);
            // 
            // check_produit_revent
            // 
            this.check_produit_revent.Checked = true;
            this.check_produit_revent.Location = new System.Drawing.Point(98, 12);
            this.check_produit_revent.Name = "check_produit_revent";
            this.check_produit_revent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_produit_revent.Size = new System.Drawing.Size(90, 34);
            this.check_produit_revent.StateCommon.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.check_produit_revent.StateCommon.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_produit_revent.TabIndex = 124;
            this.check_produit_revent.Values.Text = "منتج جاهز";
            this.check_produit_revent.CheckedChanged += new System.EventHandler(this.check_produit_revent_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Image = global::Smart_Production_Pos.Properties.Resources.save;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(11, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(285, 49);
            this.button1.TabIndex = 3;
            this.button1.Text = "حفظ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbProduct
            // 
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(11, 100);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(285, 38);
            this.cmbProduct.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "المنتوج :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "المفضلة :";
            // 
            // frm_add_fav_by_caisse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 247);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "frm_add_fav_by_caisse";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Button button1;
        public ComponentFactory.Krypton.Toolkit.KryptonRadioButton pack_check_produit_revent;
        public ComponentFactory.Krypton.Toolkit.KryptonRadioButton check_produit_revent;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}