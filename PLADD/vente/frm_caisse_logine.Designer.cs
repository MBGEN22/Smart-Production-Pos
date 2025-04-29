namespace Smart_Production_Pos.PLADD.vente
{
	partial class frm_caisse_logine
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_caisse_logine));
			this.kryptonGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
			this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.kryptonButton4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.separator1 = new Shade.Controls.Separator();
			this.txtPassword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.txtUser = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).BeginInit();
			this.kryptonGroup1.Panel.SuspendLayout();
			this.kryptonGroup1.SuspendLayout();
			this.SuspendLayout();
			// 
			// kryptonGroup1
			// 
			this.kryptonGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kryptonGroup1.Location = new System.Drawing.Point(5, 5);
			this.kryptonGroup1.Name = "kryptonGroup1";
			// 
			// kryptonGroup1.Panel
			// 
			this.kryptonGroup1.Panel.Controls.Add(this.kryptonButton1);
			this.kryptonGroup1.Panel.Controls.Add(this.kryptonButton4);
			this.kryptonGroup1.Panel.Controls.Add(this.separator1);
			this.kryptonGroup1.Panel.Controls.Add(this.txtPassword);
			this.kryptonGroup1.Panel.Controls.Add(this.txtUser);
			this.kryptonGroup1.Panel.Controls.Add(this.label1);
			this.kryptonGroup1.Panel.Controls.Add(this.label18);
			this.kryptonGroup1.Size = new System.Drawing.Size(458, 192);
			this.kryptonGroup1.StateCommon.Border.Color1 = System.Drawing.SystemColors.MenuHighlight;
			this.kryptonGroup1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonGroup1.StateCommon.Border.Rounding = 10;
			this.kryptonGroup1.StateCommon.Border.Width = 2;
			this.kryptonGroup1.TabIndex = 1;
			// 
			// kryptonButton1
			// 
			this.kryptonButton1.Location = new System.Drawing.Point(15, 125);
			this.kryptonButton1.Name = "kryptonButton1";
			this.kryptonButton1.Size = new System.Drawing.Size(149, 45);
			this.kryptonButton1.StateCommon.Back.Color1 = System.Drawing.Color.Gray;
			this.kryptonButton1.StateCommon.Back.Color2 = System.Drawing.Color.LightSlateGray;
			this.kryptonButton1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonButton1.StateCommon.Border.Rounding = 5;
			this.kryptonButton1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
			this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonButton1.TabIndex = 129;
			this.kryptonButton1.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton1.Values.Image")));
			this.kryptonButton1.Values.Text = "إغلاق";
			this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
			// 
			// kryptonButton4
			// 
			this.kryptonButton4.Location = new System.Drawing.Point(191, 125);
			this.kryptonButton4.Name = "kryptonButton4";
			this.kryptonButton4.Size = new System.Drawing.Size(232, 45);
			this.kryptonButton4.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.kryptonButton4.StateCommon.Back.Color2 = System.Drawing.Color.DodgerBlue;
			this.kryptonButton4.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonButton4.StateCommon.Border.Rounding = 5;
			this.kryptonButton4.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
			this.kryptonButton4.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonButton4.TabIndex = 130;
			this.kryptonButton4.Values.Image = ((System.Drawing.Image)(resources.GetObject("kryptonButton4.Values.Image")));
			this.kryptonButton4.Values.Text = "دخول ";
			this.kryptonButton4.Click += new System.EventHandler(this.kryptonButton4_Click);
			// 
			// separator1
			// 
			this.separator1.BackColor = System.Drawing.Color.White;
			this.separator1.LineColor = System.Drawing.Color.Gray;
			this.separator1.Location = new System.Drawing.Point(22, 109);
			this.separator1.Name = "separator1";
			this.separator1.Size = new System.Drawing.Size(378, 10);
			this.separator1.TabIndex = 128;
			this.separator1.Text = "separator1";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(15, 60);
			this.txtPassword.Margin = new System.Windows.Forms.Padding(5);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '●';
			this.txtPassword.Size = new System.Drawing.Size(296, 41);
			this.txtPassword.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
			this.txtPassword.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txtPassword.StateCommon.Border.Rounding = 5;
			this.txtPassword.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPassword.TabIndex = 1;
			this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtPassword.UseSystemPasswordChar = true;
			// 
			// txtUser
			// 
			this.txtUser.Location = new System.Drawing.Point(12, 10);
			this.txtUser.Margin = new System.Windows.Forms.Padding(5);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(299, 41);
			this.txtUser.StateCommon.Border.Color1 = System.Drawing.Color.Gray;
			this.txtUser.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txtUser.StateCommon.Border.Rounding = 5;
			this.txtUser.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUser.TabIndex = 0;
			this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.White;
			this.label1.Font = new System.Drawing.Font("Cairo Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(308, 65);
			this.label1.Name = "label1";
			this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label1.Size = new System.Drawing.Size(97, 30);
			this.label1.TabIndex = 124;
			this.label1.Text = "كلمة المرور :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.BackColor = System.Drawing.Color.White;
			this.label18.Font = new System.Drawing.Font("Cairo Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label18.ForeColor = System.Drawing.Color.Black;
			this.label18.Location = new System.Drawing.Point(308, 15);
			this.label18.Name = "label18";
			this.label18.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label18.Size = new System.Drawing.Size(120, 30);
			this.label18.TabIndex = 124;
			this.label18.Text = "اسم المستخدم :";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frm_caisse_logine
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(468, 202);
			this.Controls.Add(this.kryptonGroup1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frm_caisse_logine";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frm_caisse_logine";
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).EndInit();
			this.kryptonGroup1.Panel.ResumeLayout(false);
			this.kryptonGroup1.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).EndInit();
			this.kryptonGroup1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonGroup kryptonGroup1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton4;
		private Shade.Controls.Separator separator1;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPassword;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUser;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label18;
	}
}