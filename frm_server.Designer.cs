namespace Smart_Production_Pos
{
	partial class frm_server
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
            this.pn_info = new System.Windows.Forms.Panel();
            this.kryptonGroup2 = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.rb_local = new System.Windows.Forms.RadioButton();
            this.rbSql = new System.Windows.Forms.RadioButton();
            this.rbWindows = new System.Windows.Forms.RadioButton();
            this.txtPAss = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtUser = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtDataBase = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtNomDeServeur = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pn_info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup2.Panel)).BeginInit();
            this.kryptonGroup2.Panel.SuspendLayout();
            this.kryptonGroup2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).BeginInit();
            this.kryptonGroup1.Panel.SuspendLayout();
            this.kryptonGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_info
            // 
            this.pn_info.Controls.Add(this.kryptonGroup2);
            this.pn_info.Controls.Add(this.panel1);
            this.pn_info.Controls.Add(this.kryptonGroup1);
            this.pn_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_info.Location = new System.Drawing.Point(0, 0);
            this.pn_info.Name = "pn_info";
            this.pn_info.Size = new System.Drawing.Size(789, 518);
            this.pn_info.TabIndex = 110;
            // 
            // kryptonGroup2
            // 
            this.kryptonGroup2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroup2.Location = new System.Drawing.Point(0, 0);
            this.kryptonGroup2.Name = "kryptonGroup2";
            // 
            // kryptonGroup2.Panel
            // 
            this.kryptonGroup2.Panel.Controls.Add(this.rb_local);
            this.kryptonGroup2.Panel.Controls.Add(this.rbSql);
            this.kryptonGroup2.Panel.Controls.Add(this.rbWindows);
            this.kryptonGroup2.Panel.Controls.Add(this.txtPAss);
            this.kryptonGroup2.Panel.Controls.Add(this.txtUser);
            this.kryptonGroup2.Panel.Controls.Add(this.txtDataBase);
            this.kryptonGroup2.Panel.Controls.Add(this.txtNomDeServeur);
            this.kryptonGroup2.Panel.Controls.Add(this.label3);
            this.kryptonGroup2.Panel.Controls.Add(this.label2);
            this.kryptonGroup2.Panel.Controls.Add(this.label1);
            this.kryptonGroup2.Panel.Controls.Add(this.label14);
            this.kryptonGroup2.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.kryptonGroup2_Panel_Paint);
            this.kryptonGroup2.Size = new System.Drawing.Size(789, 443);
            this.kryptonGroup2.StateCommon.Border.Color1 = System.Drawing.SystemColors.MenuHighlight;
            this.kryptonGroup2.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonGroup2.StateCommon.Border.Rounding = 10;
            this.kryptonGroup2.TabIndex = 2;
            // 
            // rb_local
            // 
            this.rb_local.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_local.AutoSize = true;
            this.rb_local.BackColor = System.Drawing.Color.White;
            this.rb_local.Checked = true;
            this.rb_local.Location = new System.Drawing.Point(519, 173);
            this.rb_local.Name = "rb_local";
            this.rb_local.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rb_local.Size = new System.Drawing.Size(110, 34);
            this.rb_local.TabIndex = 107;
            this.rb_local.TabStop = true;
            this.rb_local.Text = "اتصال محلي";
            this.rb_local.UseVisualStyleBackColor = false;
            this.rb_local.CheckedChanged += new System.EventHandler(this.rbSql_CheckedChanged);
            // 
            // rbSql
            // 
            this.rbSql.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbSql.AutoSize = true;
            this.rbSql.BackColor = System.Drawing.Color.White;
            this.rbSql.Location = new System.Drawing.Point(418, 139);
            this.rbSql.Name = "rbSql";
            this.rbSql.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbSql.Size = new System.Drawing.Size(211, 34);
            this.rbSql.TabIndex = 107;
            this.rbSql.Text = "SQL server authentication";
            this.rbSql.UseVisualStyleBackColor = false;
            this.rbSql.CheckedChanged += new System.EventHandler(this.rbSql_CheckedChanged);
            // 
            // rbWindows
            // 
            this.rbWindows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbWindows.AutoSize = true;
            this.rbWindows.BackColor = System.Drawing.Color.White;
            this.rbWindows.Location = new System.Drawing.Point(431, 105);
            this.rbWindows.Name = "rbWindows";
            this.rbWindows.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbWindows.Size = new System.Drawing.Size(198, 34);
            this.rbWindows.TabIndex = 107;
            this.rbWindows.Text = "Windows authentication";
            this.rbWindows.UseVisualStyleBackColor = false;
            this.rbWindows.CheckedChanged += new System.EventHandler(this.rbWindows_CheckedChanged);
            // 
            // txtPAss
            // 
            this.txtPAss.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPAss.Location = new System.Drawing.Point(17, 268);
            this.txtPAss.Name = "txtPAss";
            this.txtPAss.Size = new System.Drawing.Size(638, 43);
            this.txtPAss.StateCommon.Border.Color1 = System.Drawing.SystemColors.MenuHighlight;
            this.txtPAss.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtPAss.StateCommon.Border.Rounding = 8;
            this.txtPAss.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPAss.TabIndex = 106;
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.Location = new System.Drawing.Point(17, 221);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(638, 43);
            this.txtUser.StateCommon.Border.Color1 = System.Drawing.SystemColors.MenuHighlight;
            this.txtUser.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtUser.StateCommon.Border.Rounding = 8;
            this.txtUser.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.TabIndex = 106;
            // 
            // txtDataBase
            // 
            this.txtDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataBase.Location = new System.Drawing.Point(17, 56);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(612, 43);
            this.txtDataBase.StateCommon.Border.Color1 = System.Drawing.SystemColors.MenuHighlight;
            this.txtDataBase.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtDataBase.StateCommon.Border.Rounding = 8;
            this.txtDataBase.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataBase.TabIndex = 106;
            this.txtDataBase.Text = "|DataDirectory|\\DB_PRODUCTION_POS.mdf";
            // 
            // txtNomDeServeur
            // 
            this.txtNomDeServeur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomDeServeur.Location = new System.Drawing.Point(17, 9);
            this.txtNomDeServeur.Name = "txtNomDeServeur";
            this.txtNomDeServeur.Size = new System.Drawing.Size(659, 43);
            this.txtNomDeServeur.StateCommon.Border.Color1 = System.Drawing.SystemColors.MenuHighlight;
            this.txtNomDeServeur.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtNomDeServeur.StateCommon.Border.Rounding = 8;
            this.txtNomDeServeur.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomDeServeur.TabIndex = 106;
            this.txtNomDeServeur.Text = "(LocalDB)\\MSSQLLocalDB";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(654, 275);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(97, 30);
            this.label3.TabIndex = 105;
            this.label3.Text = "كلمة المرور :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(654, 227);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(120, 30);
            this.label2.TabIndex = 105;
            this.label2.Text = "اسم المستخدم :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(630, 60);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(144, 30);
            this.label1.TabIndex = 105;
            this.label1.Text = "اسم قاعدة البيانات :";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(674, 13);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(100, 30);
            this.label14.TabIndex = 105;
            this.label14.Text = "اسم السيرفر :";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 443);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(789, 16);
            this.panel1.TabIndex = 1;
            // 
            // kryptonGroup1
            // 
            this.kryptonGroup1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonGroup1.Location = new System.Drawing.Point(0, 459);
            this.kryptonGroup1.Name = "kryptonGroup1";
            // 
            // kryptonGroup1.Panel
            // 
            this.kryptonGroup1.Panel.Controls.Add(this.kryptonButton1);
            this.kryptonGroup1.Panel.Controls.Add(this.kryptonButton4);
            this.kryptonGroup1.Size = new System.Drawing.Size(789, 59);
            this.kryptonGroup1.StateCommon.Border.Color1 = System.Drawing.SystemColors.MenuHighlight;
            this.kryptonGroup1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonGroup1.StateCommon.Border.Rounding = 10;
            this.kryptonGroup1.TabIndex = 0;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(525, 2);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(253, 46);
            this.kryptonButton1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kryptonButton1.StateCommon.Back.Color2 = System.Drawing.Color.Gray;
            this.kryptonButton1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateCommon.Border.Rounding = 5;
            this.kryptonButton1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 119;
            this.kryptonButton1.Values.Image = global::Smart_Production_Pos.Properties.Resources.query2;
            this.kryptonButton1.Values.Text = "استعلامات";
            this.kryptonButton1.Click += new System.EventHandler(this.krypXXtonButton4_Click);
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.Location = new System.Drawing.Point(3, 3);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.Size = new System.Drawing.Size(253, 46);
            this.kryptonButton4.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.kryptonButton4.StateCommon.Back.Color2 = System.Drawing.Color.DodgerBlue;
            this.kryptonButton4.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton4.StateCommon.Border.Rounding = 5;
            this.kryptonButton4.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonButton4.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton4.TabIndex = 119;
            this.kryptonButton4.Values.Image = global::Smart_Production_Pos.Properties.Resources.sauvegarder;
            this.kryptonButton4.Values.Text = "حفظ";
            this.kryptonButton4.Click += new System.EventHandler(this.kryptonButton4_Click);
            // 
            // frm_server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 518);
            this.Controls.Add(this.pn_info);
            this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "frm_server";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "واجهة السيرفر";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_server_FormClosed);
            this.pn_info.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup2.Panel)).EndInit();
            this.kryptonGroup2.Panel.ResumeLayout(false);
            this.kryptonGroup2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup2)).EndInit();
            this.kryptonGroup2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).EndInit();
            this.kryptonGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).EndInit();
            this.kryptonGroup1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.Panel pn_info;
		private ComponentFactory.Krypton.Toolkit.KryptonGroup kryptonGroup2;
		private System.Windows.Forms.RadioButton rbSql;
		private System.Windows.Forms.RadioButton rbWindows;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPAss;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUser;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDataBase;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNomDeServeur;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Panel panel1;
		private ComponentFactory.Krypton.Toolkit.KryptonGroup kryptonGroup1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton4;
        private System.Windows.Forms.RadioButton rb_local;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
    }
}