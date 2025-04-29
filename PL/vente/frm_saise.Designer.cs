namespace Smart_Production_Pos.PL.vente
{
    partial class frm_saise
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
            this.rd_prix_pack = new System.Windows.Forms.RadioButton();
            this.rd_prix_3 = new System.Windows.Forms.RadioButton();
            this.rd_prix_2 = new System.Windows.Forms.RadioButton();
            this.rd_prix_1 = new System.Windows.Forms.RadioButton();
            this.separator1 = new Shade.Controls.Separator();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_rest_Qt_p = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_rest_Qt_u = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Qt = new System.Windows.Forms.TextBox();
            this.txt_prix_vente_pack = new System.Windows.Forms.TextBox();
            this.txt_prix_vente_3 = new System.Windows.Forms.TextBox();
            this.txt_prix_vente_2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_prix_vente_1 = new System.Windows.Forms.TextBox();
            this.txt_colissage = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_N_colis = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_designation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_code_barre = new System.Windows.Forms.TextBox();
            this.txt_references = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.priceachat = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rd_prix_pack);
            this.panel1.Controls.Add(this.rd_prix_3);
            this.panel1.Controls.Add(this.rd_prix_2);
            this.panel1.Controls.Add(this.rd_prix_1);
            this.panel1.Controls.Add(this.separator1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt_Qt);
            this.panel1.Controls.Add(this.txt_prix_vente_pack);
            this.panel1.Controls.Add(this.txt_prix_vente_3);
            this.panel1.Controls.Add(this.txt_prix_vente_2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_prix_vente_1);
            this.panel1.Controls.Add(this.txt_colissage);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_N_colis);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 175);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 242);
            this.panel1.TabIndex = 0;
            // 
            // rd_prix_pack
            // 
            this.rd_prix_pack.AutoSize = true;
            this.rd_prix_pack.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_prix_pack.Location = new System.Drawing.Point(477, 194);
            this.rd_prix_pack.Name = "rd_prix_pack";
            this.rd_prix_pack.Size = new System.Drawing.Size(166, 25);
            this.rd_prix_pack.TabIndex = 5;
            this.rd_prix_pack.Text = "-- سعر البيع الحزمة --";
            this.rd_prix_pack.UseVisualStyleBackColor = true;
            this.rd_prix_pack.CheckedChanged += new System.EventHandler(this.rd_prix_pack_CheckedChanged);
            // 
            // rd_prix_3
            // 
            this.rd_prix_3.AutoSize = true;
            this.rd_prix_3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_prix_3.Location = new System.Drawing.Point(482, 159);
            this.rd_prix_3.Name = "rd_prix_3";
            this.rd_prix_3.Size = new System.Drawing.Size(161, 25);
            this.rd_prix_3.TabIndex = 5;
            this.rd_prix_3.Text = "-- سعر البيع الادنى --";
            this.rd_prix_3.UseVisualStyleBackColor = true;
            // 
            // rd_prix_2
            // 
            this.rd_prix_2.AutoSize = true;
            this.rd_prix_2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_prix_2.Location = new System.Drawing.Point(482, 125);
            this.rd_prix_2.Name = "rd_prix_2";
            this.rd_prix_2.Size = new System.Drawing.Size(161, 25);
            this.rd_prix_2.TabIndex = 5;
            this.rd_prix_2.Text = "-- سعر البيع الجملة --";
            this.rd_prix_2.UseVisualStyleBackColor = true;
            // 
            // rd_prix_1
            // 
            this.rd_prix_1.AutoSize = true;
            this.rd_prix_1.Checked = true;
            this.rd_prix_1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_prix_1.Location = new System.Drawing.Point(474, 92);
            this.rd_prix_1.Name = "rd_prix_1";
            this.rd_prix_1.Size = new System.Drawing.Size(169, 25);
            this.rd_prix_1.TabIndex = 5;
            this.rd_prix_1.TabStop = true;
            this.rd_prix_1.Text = "-- سعر البيع التجزئة --";
            this.rd_prix_1.UseVisualStyleBackColor = true;
            // 
            // separator1
            // 
            this.separator1.BackColor = System.Drawing.Color.White;
            this.separator1.LineColor = System.Drawing.Color.Gray;
            this.separator1.Location = new System.Drawing.Point(272, 72);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(385, 13);
            this.separator1.TabIndex = 4;
            this.separator1.Text = "separator1";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txt_rest_Qt_p);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txt_rest_Qt_u);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(266, 240);
            this.panel2.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(16, 65);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(236, 21);
            this.label13.TabIndex = 1;
            this.label13.Text = "--الكمية المتبقية في المخزن بالحزمة--";
            // 
            // txt_rest_Qt_p
            // 
            this.txt_rest_Qt_p.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txt_rest_Qt_p.Location = new System.Drawing.Point(16, 90);
            this.txt_rest_Qt_p.Margin = new System.Windows.Forms.Padding(4);
            this.txt_rest_Qt_p.Name = "txt_rest_Qt_p";
            this.txt_rest_Qt_p.ReadOnly = true;
            this.txt_rest_Qt_p.Size = new System.Drawing.Size(229, 26);
            this.txt_rest_Qt_p.TabIndex = 2;
            this.txt_rest_Qt_p.Text = "00";
            this.txt_rest_Qt_p.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(16, 10);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(233, 21);
            this.label12.TabIndex = 1;
            this.label12.Text = "--الكمية المتبقية في المخزن بالقطعة--";
            // 
            // txt_rest_Qt_u
            // 
            this.txt_rest_Qt_u.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txt_rest_Qt_u.Location = new System.Drawing.Point(16, 35);
            this.txt_rest_Qt_u.Margin = new System.Windows.Forms.Padding(4);
            this.txt_rest_Qt_u.Name = "txt_rest_Qt_u";
            this.txt_rest_Qt_u.ReadOnly = true;
            this.txt_rest_Qt_u.Size = new System.Drawing.Size(229, 26);
            this.txt_rest_Qt_u.TabIndex = 2;
            this.txt_rest_Qt_u.Text = "00";
            this.txt_rest_Qt_u.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(291, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "-- الكمية --";
            // 
            // txt_Qt
            // 
            this.txt_Qt.Location = new System.Drawing.Point(273, 36);
            this.txt_Qt.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Qt.Name = "txt_Qt";
            this.txt_Qt.Size = new System.Drawing.Size(110, 26);
            this.txt_Qt.TabIndex = 2;
            this.txt_Qt.Text = "00";
            this.txt_Qt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Qt.TextChanged += new System.EventHandler(this.txt_Qt_TextChanged);
            this.txt_Qt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Qt_KeyDown);
            // 
            // txt_prix_vente_pack
            // 
            this.txt_prix_vente_pack.BackColor = System.Drawing.Color.Lime;
            this.txt_prix_vente_pack.Location = new System.Drawing.Point(273, 194);
            this.txt_prix_vente_pack.Margin = new System.Windows.Forms.Padding(4);
            this.txt_prix_vente_pack.Name = "txt_prix_vente_pack";
            this.txt_prix_vente_pack.Size = new System.Drawing.Size(200, 26);
            this.txt_prix_vente_pack.TabIndex = 2;
            this.txt_prix_vente_pack.Text = "/";
            this.txt_prix_vente_pack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_prix_vente_3
            // 
            this.txt_prix_vente_3.BackColor = System.Drawing.Color.LightGreen;
            this.txt_prix_vente_3.Location = new System.Drawing.Point(273, 159);
            this.txt_prix_vente_3.Margin = new System.Windows.Forms.Padding(4);
            this.txt_prix_vente_3.Name = "txt_prix_vente_3";
            this.txt_prix_vente_3.Size = new System.Drawing.Size(200, 26);
            this.txt_prix_vente_3.TabIndex = 2;
            this.txt_prix_vente_3.Text = "00";
            this.txt_prix_vente_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_prix_vente_2
            // 
            this.txt_prix_vente_2.BackColor = System.Drawing.Color.LightGreen;
            this.txt_prix_vente_2.Location = new System.Drawing.Point(273, 125);
            this.txt_prix_vente_2.Margin = new System.Windows.Forms.Padding(4);
            this.txt_prix_vente_2.Name = "txt_prix_vente_2";
            this.txt_prix_vente_2.Size = new System.Drawing.Size(200, 26);
            this.txt_prix_vente_2.TabIndex = 2;
            this.txt_prix_vente_2.Text = "00";
            this.txt_prix_vente_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(436, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "التحزيم";
            // 
            // txt_prix_vente_1
            // 
            this.txt_prix_vente_1.BackColor = System.Drawing.Color.LightGreen;
            this.txt_prix_vente_1.Location = new System.Drawing.Point(273, 91);
            this.txt_prix_vente_1.Margin = new System.Windows.Forms.Padding(4);
            this.txt_prix_vente_1.Name = "txt_prix_vente_1";
            this.txt_prix_vente_1.Size = new System.Drawing.Size(200, 26);
            this.txt_prix_vente_1.TabIndex = 2;
            this.txt_prix_vente_1.Text = "00";
            this.txt_prix_vente_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_colissage
            // 
            this.txt_colissage.Location = new System.Drawing.Point(409, 36);
            this.txt_colissage.Margin = new System.Windows.Forms.Padding(4);
            this.txt_colissage.Name = "txt_colissage";
            this.txt_colissage.ReadOnly = true;
            this.txt_colissage.Size = new System.Drawing.Size(110, 26);
            this.txt_colissage.TabIndex = 2;
            this.txt_colissage.Text = "00";
            this.txt_colissage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(385, 38);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "=";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(523, 38);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 21);
            this.label7.TabIndex = 1;
            this.label7.Text = "×";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(556, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "--عدد الحزم--";
            // 
            // txt_N_colis
            // 
            this.txt_N_colis.Location = new System.Drawing.Point(547, 36);
            this.txt_N_colis.Margin = new System.Windows.Forms.Padding(4);
            this.txt_N_colis.Name = "txt_N_colis";
            this.txt_N_colis.Size = new System.Drawing.Size(110, 26);
            this.txt_N_colis.TabIndex = 2;
            this.txt_N_colis.Text = "00";
            this.txt_N_colis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_N_colis.TextChanged += new System.EventHandler(this.txt_N_colis_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(591, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "اسم المنتج :";
            // 
            // txt_designation
            // 
            this.txt_designation.Location = new System.Drawing.Point(268, 40);
            this.txt_designation.Margin = new System.Windows.Forms.Padding(4);
            this.txt_designation.Name = "txt_designation";
            this.txt_designation.ReadOnly = true;
            this.txt_designation.Size = new System.Drawing.Size(398, 26);
            this.txt_designation.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(581, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "رمز المنتج :";
            // 
            // txt_code_barre
            // 
            this.txt_code_barre.Location = new System.Drawing.Point(495, 95);
            this.txt_code_barre.Margin = new System.Windows.Forms.Padding(4);
            this.txt_code_barre.Name = "txt_code_barre";
            this.txt_code_barre.ReadOnly = true;
            this.txt_code_barre.Size = new System.Drawing.Size(171, 26);
            this.txt_code_barre.TabIndex = 2;
            // 
            // txt_references
            // 
            this.txt_references.Location = new System.Drawing.Point(268, 95);
            this.txt_references.Margin = new System.Windows.Forms.Padding(4);
            this.txt_references.Name = "txt_references";
            this.txt_references.ReadOnly = true;
            this.txt_references.Size = new System.Drawing.Size(215, 26);
            this.txt_references.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(143, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 21);
            this.label4.TabIndex = 1;
            this.label4.Text = "الصورة :";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(683, 452);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.txt_references);
            this.tabPage1.Controls.Add(this.priceachat);
            this.tabPage1.Controls.Add(this.txt_code_barre);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txt_designation);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(675, 420);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "معلومات المنتج";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Smart_Production_Pos.Properties.Resources.emballage;
            this.pictureBox1.Location = new System.Drawing.Point(6, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(198, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(425, 70);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 21);
            this.label14.TabIndex = 1;
            this.label14.Text = "المرجع :";
            // 
            // priceachat
            // 
            this.priceachat.Location = new System.Drawing.Point(268, 133);
            this.priceachat.Margin = new System.Windows.Forms.Padding(4);
            this.priceachat.Name = "priceachat";
            this.priceachat.ReadOnly = true;
            this.priceachat.Size = new System.Drawing.Size(215, 26);
            this.priceachat.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(495, 138);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 21);
            this.label9.TabIndex = 1;
            this.label9.Text = "سعر الشراء :";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonButton2);
            this.kryptonPanel1.Controls.Add(this.kryptonButton1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 452);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(683, 55);
            this.kryptonPanel1.TabIndex = 5;
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(221, 5);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(145, 46);
            this.kryptonButton2.StateCommon.Back.Color1 = System.Drawing.Color.Gainsboro;
            this.kryptonButton2.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonButton2.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonButton2.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton2.TabIndex = 0;
            this.kryptonButton2.Values.Image = global::Smart_Production_Pos.Properties.Resources.cancel;
            this.kryptonButton2.Values.Text = "إلغاء";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(372, 5);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(145, 46);
            this.kryptonButton1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kryptonButton1.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonButton1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 0;
            this.kryptonButton1.Values.Image = global::Smart_Production_Pos.Properties.Resources.check_mark__1_;
            this.kryptonButton1.Values.Text = "إضافة";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // frm_saise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 507);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.kryptonPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_saise";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الحجر";
            this.Load += new System.EventHandler(this.frm_saise_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txt_designation;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txt_code_barre;
        public System.Windows.Forms.TextBox txt_references;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txt_Qt;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txt_colissage;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txt_N_colis;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txt_rest_Qt_u;
        public System.Windows.Forms.TextBox txt_prix_vente_1;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txt_rest_Qt_p;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txt_prix_vente_3;
        public System.Windows.Forms.TextBox txt_prix_vente_2;
        private Shade.Controls.Separator separator1;
        public System.Windows.Forms.TextBox txt_prix_vente_pack;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private System.Windows.Forms.RadioButton rd_prix_pack;
        private System.Windows.Forms.RadioButton rd_prix_3;
        private System.Windows.Forms.RadioButton rd_prix_2;
        private System.Windows.Forms.RadioButton rd_prix_1;
        public System.Windows.Forms.TextBox priceachat;
        public System.Windows.Forms.Label label9;
    }
}