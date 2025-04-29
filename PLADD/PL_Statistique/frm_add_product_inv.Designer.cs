namespace Smart_Production_Pos.PLADD.PL_Statistique
{
    partial class frm_add_product_inv
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonDropButton1 = new ComponentFactory.Krypton.Toolkit.KryptonDropButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.kryptonButton3 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.check_reference = new System.Windows.Forms.CheckBox();
            this.check_categorie = new System.Windows.Forms.CheckBox();
            this.check_stock = new System.Windows.Forms.CheckBox();
            this.check_marque = new System.Windows.Forms.CheckBox();
            this.check_unite = new System.Windows.Forms.CheckBox();
            this.check_taille = new System.Windows.Forms.CheckBox();
            this.check_clr = new System.Windows.Forms.CheckBox();
            this.check_fav = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.kryptonDropButton1);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1062, 59);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // kryptonDropButton1
            // 
            this.kryptonDropButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonDropButton1.Location = new System.Drawing.Point(788, 9);
            this.kryptonDropButton1.Name = "kryptonDropButton1";
            this.kryptonDropButton1.Size = new System.Drawing.Size(55, 38);
            this.kryptonDropButton1.TabIndex = 27;
            this.kryptonDropButton1.Values.Image = global::Smart_Production_Pos.Properties.Resources.oeil;
            this.kryptonDropButton1.Values.Text = "";
            this.kryptonDropButton1.Click += new System.EventHandler(this.kryptonDropButton1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(11, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(228, 29);
            this.textBox3.TabIndex = 8;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(245, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "البحث :";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::Smart_Production_Pos.Properties.Resources.edition;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(849, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 36);
            this.button2.TabIndex = 5;
            this.button2.Text = "تعديل";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Smart_Production_Pos.Properties.Resources.ajouter_un_bouton1;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(951, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "إضافة";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.kryptonButton3);
            this.panel2.Controls.Add(this.kryptonButton2);
            this.panel2.Controls.Add(this.kryptonButton1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 477);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1062, 58);
            this.panel2.TabIndex = 0;
            // 
            // kryptonButton3
            // 
            this.kryptonButton3.Location = new System.Drawing.Point(130, 8);
            this.kryptonButton3.Name = "kryptonButton3";
            this.kryptonButton3.Size = new System.Drawing.Size(114, 40);
            this.kryptonButton3.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.kryptonButton3.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.kryptonButton3.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonButton3.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton3.TabIndex = 0;
            this.kryptonButton3.Values.Image = global::Smart_Production_Pos.Properties.Resources.cancel;
            this.kryptonButton3.Values.Text = "إلغاء";
            this.kryptonButton3.Click += new System.EventHandler(this.kryptonButton3_Click);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(10, 8);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(114, 40);
            this.kryptonButton2.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.kryptonButton2.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.kryptonButton2.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonButton2.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton2.TabIndex = 0;
            this.kryptonButton2.Values.Image = global::Smart_Production_Pos.Properties.Resources.check_mark__1_;
            this.kryptonButton2.Values.Text = "إضافة";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(835, 8);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(213, 40);
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 0;
            this.kryptonButton1.Values.Text = "إضافة كل الكميات مع كمية = 0";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1062, 418);
            this.dataGridView1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.check_reference);
            this.flowLayoutPanel1.Controls.Add(this.check_categorie);
            this.flowLayoutPanel1.Controls.Add(this.check_stock);
            this.flowLayoutPanel1.Controls.Add(this.check_marque);
            this.flowLayoutPanel1.Controls.Add(this.check_unite);
            this.flowLayoutPanel1.Controls.Add(this.check_taille);
            this.flowLayoutPanel1.Controls.Add(this.check_clr);
            this.flowLayoutPanel1.Controls.Add(this.check_fav);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(218, 65);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 293);
            this.flowLayoutPanel1.TabIndex = 28;
            this.flowLayoutPanel1.Visible = false;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // check_reference
            // 
            this.check_reference.Dock = System.Windows.Forms.DockStyle.Top;
            this.check_reference.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_reference.Location = new System.Drawing.Point(70, 3);
            this.check_reference.Name = "check_reference";
            this.check_reference.Size = new System.Drawing.Size(125, 32);
            this.check_reference.TabIndex = 0;
            this.check_reference.Text = "رقم المرجع";
            this.check_reference.UseVisualStyleBackColor = true;
            this.check_reference.CheckedChanged += new System.EventHandler(this.check_reference_CheckedChanged);
            // 
            // check_categorie
            // 
            this.check_categorie.Dock = System.Windows.Forms.DockStyle.Top;
            this.check_categorie.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_categorie.Location = new System.Drawing.Point(33, 41);
            this.check_categorie.Name = "check_categorie";
            this.check_categorie.Size = new System.Drawing.Size(162, 26);
            this.check_categorie.TabIndex = 1;
            this.check_categorie.Text = "الصنف";
            this.check_categorie.UseVisualStyleBackColor = true;
            this.check_categorie.CheckedChanged += new System.EventHandler(this.check_categorie_CheckedChanged);
            // 
            // check_stock
            // 
            this.check_stock.Dock = System.Windows.Forms.DockStyle.Top;
            this.check_stock.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_stock.Location = new System.Drawing.Point(33, 73);
            this.check_stock.Name = "check_stock";
            this.check_stock.Size = new System.Drawing.Size(162, 33);
            this.check_stock.TabIndex = 2;
            this.check_stock.Text = "المخزن";
            this.check_stock.UseVisualStyleBackColor = true;
            this.check_stock.CheckedChanged += new System.EventHandler(this.check_stock_CheckedChanged);
            // 
            // check_marque
            // 
            this.check_marque.Dock = System.Windows.Forms.DockStyle.Top;
            this.check_marque.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_marque.Location = new System.Drawing.Point(33, 112);
            this.check_marque.Name = "check_marque";
            this.check_marque.Size = new System.Drawing.Size(162, 26);
            this.check_marque.TabIndex = 3;
            this.check_marque.Text = "العلامة";
            this.check_marque.UseVisualStyleBackColor = true;
            this.check_marque.CheckedChanged += new System.EventHandler(this.check_marque_CheckedChanged);
            // 
            // check_unite
            // 
            this.check_unite.Dock = System.Windows.Forms.DockStyle.Top;
            this.check_unite.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_unite.Location = new System.Drawing.Point(58, 144);
            this.check_unite.Name = "check_unite";
            this.check_unite.Size = new System.Drawing.Size(137, 26);
            this.check_unite.TabIndex = 4;
            this.check_unite.Text = "الوحدة";
            this.check_unite.UseVisualStyleBackColor = true;
            this.check_unite.CheckedChanged += new System.EventHandler(this.check_unite_CheckedChanged);
            // 
            // check_taille
            // 
            this.check_taille.Dock = System.Windows.Forms.DockStyle.Top;
            this.check_taille.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_taille.Location = new System.Drawing.Point(58, 176);
            this.check_taille.Name = "check_taille";
            this.check_taille.Size = new System.Drawing.Size(137, 33);
            this.check_taille.TabIndex = 5;
            this.check_taille.Text = "القياس";
            this.check_taille.UseVisualStyleBackColor = true;
            this.check_taille.CheckedChanged += new System.EventHandler(this.check_taille_CheckedChanged);
            // 
            // check_clr
            // 
            this.check_clr.Dock = System.Windows.Forms.DockStyle.Top;
            this.check_clr.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_clr.Location = new System.Drawing.Point(58, 215);
            this.check_clr.Name = "check_clr";
            this.check_clr.Size = new System.Drawing.Size(137, 33);
            this.check_clr.TabIndex = 6;
            this.check_clr.Text = "اللون";
            this.check_clr.UseVisualStyleBackColor = true;
            this.check_clr.CheckedChanged += new System.EventHandler(this.check_clr_CheckedChanged);
            // 
            // check_fav
            // 
            this.check_fav.Dock = System.Windows.Forms.DockStyle.Top;
            this.check_fav.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_fav.Location = new System.Drawing.Point(58, 254);
            this.check_fav.Name = "check_fav";
            this.check_fav.Size = new System.Drawing.Size(137, 33);
            this.check_fav.TabIndex = 7;
            this.check_fav.Text = "المفضلة";
            this.check_fav.UseVisualStyleBackColor = true;
            this.check_fav.CheckedChanged += new System.EventHandler(this.check_fav_CheckedChanged);
            // 
            // frm_add_product_inv
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1062, 535);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frm_add_product_inv";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "قائمة المنتجات";
            this.Load += new System.EventHandler(this.frm_add_product_inv_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonDropButton kryptonDropButton1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox check_reference;
        private System.Windows.Forms.CheckBox check_categorie;
        private System.Windows.Forms.CheckBox check_stock;
        private System.Windows.Forms.CheckBox check_marque;
        private System.Windows.Forms.CheckBox check_unite;
        private System.Windows.Forms.CheckBox check_taille;
        private System.Windows.Forms.CheckBox check_clr;
        private System.Windows.Forms.CheckBox check_fav;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
    }
}