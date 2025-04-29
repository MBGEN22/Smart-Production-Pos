namespace Smart_Production_Pos.PL.Achat_revente
{
	partial class frm_stock_pack
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pn_stock_matier_premier = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.طباعةالكودبارToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.تعديلمعلوماتالحزمةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.kryptonGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonGroup();
            this.groupBox1 = new Shade.Controls.GroupBox();
            this.kryptonTextBox2 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.groupBox6 = new Shade.Controls.GroupBox();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.button19 = new System.Windows.Forms.Button();
            this.pn_stock_matier_premier.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).BeginInit();
            this.kryptonGroup1.Panel.SuspendLayout();
            this.kryptonGroup1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // pn_stock_matier_premier
            // 
            this.pn_stock_matier_premier.Controls.Add(this.panel3);
            this.pn_stock_matier_premier.Controls.Add(this.panel2);
            this.pn_stock_matier_premier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_stock_matier_premier.Location = new System.Drawing.Point(0, 0);
            this.pn_stock_matier_premier.Name = "pn_stock_matier_premier";
            this.pn_stock_matier_premier.Size = new System.Drawing.Size(1192, 781);
            this.pn_stock_matier_premier.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 118);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1192, 663);
            this.panel3.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1192, 663);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.طباعةالكودبارToolStripMenuItem,
            this.تعديلمعلوماتالحزمةToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(224, 56);
            // 
            // طباعةالكودبارToolStripMenuItem
            // 
            this.طباعةالكودبارToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.طباعةالكودبارToolStripMenuItem.Image = global::Smart_Production_Pos.Properties.Resources.code_a_barre;
            this.طباعةالكودبارToolStripMenuItem.Name = "طباعةالكودبارToolStripMenuItem";
            this.طباعةالكودبارToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.طباعةالكودبارToolStripMenuItem.Text = "طباعة الكودبار";
            this.طباعةالكودبارToolStripMenuItem.Click += new System.EventHandler(this.طباعةالكودبارToolStripMenuItem_Click);
            // 
            // تعديلمعلوماتالحزمةToolStripMenuItem
            // 
            this.تعديلمعلوماتالحزمةToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.تعديلمعلوماتالحزمةToolStripMenuItem.Image = global::Smart_Production_Pos.Properties.Resources.xx;
            this.تعديلمعلوماتالحزمةToolStripMenuItem.Name = "تعديلمعلوماتالحزمةToolStripMenuItem";
            this.تعديلمعلوماتالحزمةToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.تعديلمعلوماتالحزمةToolStripMenuItem.Text = "تعديل معلومات الحزمة";
            this.تعديلمعلوماتالحزمةToolStripMenuItem.Click += new System.EventHandler(this.تعديلمعلوماتالحزمةToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.kryptonGroup1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(1192, 118);
            this.panel2.TabIndex = 3;
            // 
            // kryptonGroup1
            // 
            this.kryptonGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroup1.Location = new System.Drawing.Point(5, 5);
            this.kryptonGroup1.Name = "kryptonGroup1";
            // 
            // kryptonGroup1.Panel
            // 
            this.kryptonGroup1.Panel.Controls.Add(this.panel12);
            this.kryptonGroup1.Panel.Controls.Add(this.button19);
            this.kryptonGroup1.Panel.Controls.Add(this.groupBox1);
            this.kryptonGroup1.Panel.Controls.Add(this.groupBox6);
            this.kryptonGroup1.Size = new System.Drawing.Size(1182, 108);
            this.kryptonGroup1.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
            this.kryptonGroup1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonGroup1.StateCommon.Border.Rounding = 15;
            this.kryptonGroup1.StateCommon.Border.Width = 2;
            this.kryptonGroup1.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoScroll = true;
            this.groupBox1.AutoScrollMinSize = new System.Drawing.Size(0, 20);
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackGColor = System.Drawing.Color.White;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.BaseColor = System.Drawing.Color.Transparent;
            this.groupBox1.BorderColorG = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.BorderColorH = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Controls.Add(this.kryptonTextBox2);
            this.groupBox1.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.groupBox1.HeaderColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(492, 3);
            this.groupBox1.MinimumSize = new System.Drawing.Size(136, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(302, 79);
            this.groupBox1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.groupBox1.TabIndex = 9;
            this.groupBox1.Text = "البحث عن طريق رقم الحزمة";
            // 
            // kryptonTextBox2
            // 
            this.kryptonTextBox2.Location = new System.Drawing.Point(11, 30);
            this.kryptonTextBox2.Name = "kryptonTextBox2";
            this.kryptonTextBox2.Size = new System.Drawing.Size(283, 43);
            this.kryptonTextBox2.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
            this.kryptonTextBox2.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonTextBox2.StateCommon.Border.Rounding = 10;
            this.kryptonTextBox2.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonTextBox2.TabIndex = 10;
            this.kryptonTextBox2.TextChanged += new System.EventHandler(this.kryptonTextBox2_TextChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.AutoScroll = true;
            this.groupBox6.AutoScrollMinSize = new System.Drawing.Size(0, 20);
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.BackGColor = System.Drawing.Color.White;
            this.groupBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox6.BaseColor = System.Drawing.Color.Transparent;
            this.groupBox6.BorderColorG = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox6.BorderColorH = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox6.Controls.Add(this.kryptonTextBox1);
            this.groupBox6.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.groupBox6.HeaderColor = System.Drawing.Color.White;
            this.groupBox6.Location = new System.Drawing.Point(842, 3);
            this.groupBox6.MinimumSize = new System.Drawing.Size(136, 50);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
            this.groupBox6.Size = new System.Drawing.Size(309, 79);
            this.groupBox6.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.groupBox6.TabIndex = 9;
            this.groupBox6.Text = "البحث عن طريق رقم الوحدة";
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(11, 30);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(290, 43);
            this.kryptonTextBox1.StateCommon.Border.Color1 = System.Drawing.SystemColors.Highlight;
            this.kryptonTextBox1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonTextBox1.StateCommon.Border.Rounding = 10;
            this.kryptonTextBox1.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonTextBox1.TabIndex = 10;
            this.kryptonTextBox1.TextChanged += new System.EventHandler(this.kryptonTextBox1_TextChanged);
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.label9);
            this.panel12.Controls.Add(this.pictureBox7);
            this.panel12.Location = new System.Drawing.Point(6, 7);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(168, 79);
            this.panel12.TabIndex = 152;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(0, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(166, 26);
            this.label9.TabIndex = 149;
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox7.Location = new System.Drawing.Point(0, 0);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(166, 51);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox7.TabIndex = 149;
            this.pictureBox7.TabStop = false;
            // 
            // button19
            // 
            this.button19.FlatAppearance.BorderSize = 0;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Image = global::Smart_Production_Pos.Properties.Resources.imprimer1;
            this.button19.Location = new System.Drawing.Point(179, 7);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(37, 36);
            this.button19.TabIndex = 151;
            this.button19.UseVisualStyleBackColor = true;
            // 
            // frm_stock_pack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 781);
            this.Controls.Add(this.pn_stock_matier_premier);
            this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "frm_stock_pack";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مخزن الحزم";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pn_stock_matier_premier.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).EndInit();
            this.kryptonGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).EndInit();
            this.kryptonGroup1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.Panel pn_stock_matier_premier;
		private System.Windows.Forms.Panel panel3;
		public System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Panel panel2;
		private ComponentFactory.Krypton.Toolkit.KryptonGroup kryptonGroup1;
		private Shade.Controls.GroupBox groupBox6;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
		private Shade.Controls.GroupBox groupBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox2;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem طباعةالكودبارToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem تعديلمعلوماتالحزمةToolStripMenuItem;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Button button19;
    }
}