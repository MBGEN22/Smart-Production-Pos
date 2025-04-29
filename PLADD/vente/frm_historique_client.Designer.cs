namespace Smart_Production_Pos.PLADD.vente
{
	partial class frm_historique_client
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.kryptonButton4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txt_rest_after = new System.Windows.Forms.TextBox();
            this.txt_paye = new System.Windows.Forms.TextBox();
            this.cmb_frnsre = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lb_rest = new Shade.Controls.BigLabel();
            this.bigLabel1 = new Shade.Controls.BigLabel();
            this.parrotControlEllipse1 = new Shade.Controls.ParrotControlEllipse();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.kryptonButton4);
            this.panel2.Controls.Add(this.txt_rest_after);
            this.panel2.Controls.Add(this.txt_paye);
            this.panel2.Controls.Add(this.cmb_frnsre);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 151);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(539, 245);
            this.panel2.TabIndex = 1;
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonButton4.Location = new System.Drawing.Point(12, 187);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.Size = new System.Drawing.Size(129, 46);
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
            // txt_rest_after
            // 
            this.txt_rest_after.Enabled = false;
            this.txt_rest_after.Location = new System.Drawing.Point(12, 137);
            this.txt_rest_after.Name = "txt_rest_after";
            this.txt_rest_after.Size = new System.Drawing.Size(353, 37);
            this.txt_rest_after.TabIndex = 3;
            this.txt_rest_after.Text = "00";
            this.txt_rest_after.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_paye
            // 
            this.txt_paye.Location = new System.Drawing.Point(12, 94);
            this.txt_paye.Name = "txt_paye";
            this.txt_paye.Size = new System.Drawing.Size(353, 37);
            this.txt_paye.TabIndex = 3;
            this.txt_paye.Text = "00";
            this.txt_paye.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_paye.TextChanged += new System.EventHandler(this.txt_paye_TextChanged);
            // 
            // cmb_frnsre
            // 
            this.cmb_frnsre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_frnsre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_frnsre.FormattingEnabled = true;
            this.cmb_frnsre.Location = new System.Drawing.Point(12, 50);
            this.cmb_frnsre.Name = "cmb_frnsre";
            this.cmb_frnsre.Size = new System.Drawing.Size(424, 38);
            this.cmb_frnsre.TabIndex = 2;
            this.cmb_frnsre.SelectedIndexChanged += new System.EventHandler(this.cmb_frnsre_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 7);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(424, 37);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(362, 139);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "المتبقي بعد الدفع :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(362, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "المبلغ المدفوع :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(434, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "التاريخ :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(434, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "المورد :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(539, 151);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.lb_rest);
            this.panel3.Controls.Add(this.bigLabel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(10, 10);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(519, 131);
            this.panel3.TabIndex = 0;
            // 
            // lb_rest
            // 
            this.lb_rest.BackColor = System.Drawing.Color.Transparent;
            this.lb_rest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_rest.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.lb_rest.ForeColor = System.Drawing.Color.Gold;
            this.lb_rest.Location = new System.Drawing.Point(0, 0);
            this.lb_rest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_rest.Name = "lb_rest";
            this.lb_rest.Size = new System.Drawing.Size(430, 131);
            this.lb_rest.TabIndex = 1;
            this.lb_rest.Text = "00";
            this.lb_rest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bigLabel1
            // 
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.bigLabel1.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.bigLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bigLabel1.Location = new System.Drawing.Point(430, 0);
            this.bigLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(89, 131);
            this.bigLabel1.TabIndex = 0;
            this.bigLabel1.Text = "D.A";
            this.bigLabel1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // parrotControlEllipse1
            // 
            this.parrotControlEllipse1.CornerRadius = 30;
            this.parrotControlEllipse1.EffectedControl = this.panel3;
            // 
            // frm_historique_client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 396);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "frm_historique_client";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "متتبع مصاريف الزبائن";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel2;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton4;
		private System.Windows.Forms.TextBox txt_rest_after;
		private System.Windows.Forms.TextBox txt_paye;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel3;
		private Shade.Controls.BigLabel lb_rest;
		private Shade.Controls.BigLabel bigLabel1;
		private Shade.Controls.ParrotControlEllipse parrotControlEllipse1;
        public System.Windows.Forms.ComboBox cmb_frnsre;
    }
}