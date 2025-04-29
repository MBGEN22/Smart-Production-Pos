namespace Smart_Production_Pos.PL.Commande
{
	partial class frm_facture_commande
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pn_historique_client = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.تفاصيلالفاتورةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel2 = new System.Windows.Forms.Panel();
			this.groupBox2 = new Shade.Controls.GroupBox();
			this.kryptonDateTimePicker1 = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
			this.button2 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.pn_historique_client.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pn_historique_client
			// 
			this.pn_historique_client.BackColor = System.Drawing.Color.White;
			this.pn_historique_client.Controls.Add(this.panel3);
			this.pn_historique_client.Controls.Add(this.panel2);
			this.pn_historique_client.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pn_historique_client.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pn_historique_client.Location = new System.Drawing.Point(0, 0);
			this.pn_historique_client.Name = "pn_historique_client";
			this.pn_historique_client.Size = new System.Drawing.Size(1120, 562);
			this.pn_historique_client.TabIndex = 7;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.White;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.dataGridView1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 87);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1120, 475);
			this.panel3.TabIndex = 2;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToOrderColumns = true;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle3.NullValue = null;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
			this.dataGridView1.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
			this.dataGridView1.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.dataGridView1.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.dataGridView1.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.On;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
			this.dataGridView1.Size = new System.Drawing.Size(1118, 473);
			this.dataGridView1.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
			this.dataGridView1.StateCommon.DataCell.Border.Color1 = System.Drawing.Color.Black;
			this.dataGridView1.StateCommon.DataCell.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.dataGridView1.StateCommon.DataCell.Content.Color1 = System.Drawing.Color.Black;
			this.dataGridView1.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dataGridView1.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.White;
			this.dataGridView1.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dataGridView1.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed;
			this.dataGridView1.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.White;
			this.dataGridView1.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.dataGridView1.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black;
			this.dataGridView1.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black;
			this.dataGridView1.StateCommon.HeaderColumn.Content.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed;
			this.dataGridView1.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dataGridView1.TabIndex = 2;
			this.dataGridView1.VirtualMode = true;
			this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.تفاصيلالفاتورةToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.contextMenuStrip1.Size = new System.Drawing.Size(151, 26);
			// 
			// تفاصيلالفاتورةToolStripMenuItem
			// 
			this.تفاصيلالفاتورةToolStripMenuItem.Name = "تفاصيلالفاتورةToolStripMenuItem";
			this.تفاصيلالفاتورةToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.تفاصيلالفاتورةToolStripMenuItem.Text = "تفاصيل الفاتورة";
			this.تفاصيلالفاتورةToolStripMenuItem.Click += new System.EventHandler(this.تفاصيلالفاتورةToolStripMenuItem_Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.White;
			this.panel2.Controls.Add(this.button4);
			this.panel2.Controls.Add(this.groupBox2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1120, 87);
			this.panel2.TabIndex = 1;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.AutoScroll = true;
			this.groupBox2.AutoScrollMinSize = new System.Drawing.Size(0, 20);
			this.groupBox2.BackColor = System.Drawing.Color.Transparent;
			this.groupBox2.BackGColor = System.Drawing.Color.White;
			this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.groupBox2.BaseColor = System.Drawing.Color.Transparent;
			this.groupBox2.BorderColorG = System.Drawing.Color.DodgerBlue;
			this.groupBox2.BorderColorH = System.Drawing.Color.DodgerBlue;
			this.groupBox2.Controls.Add(this.kryptonDateTimePicker1);
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
			this.groupBox2.HeaderColor = System.Drawing.Color.White;
			this.groupBox2.Location = new System.Drawing.Point(824, 3);
			this.groupBox2.MinimumSize = new System.Drawing.Size(136, 50);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
			this.groupBox2.Size = new System.Drawing.Size(284, 79);
			this.groupBox2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.groupBox2.TabIndex = 4;
			this.groupBox2.Text = "البحث عن طريق التاريخ";
			// 
			// kryptonDateTimePicker1
			// 
			this.kryptonDateTimePicker1.Location = new System.Drawing.Point(47, 31);
			this.kryptonDateTimePicker1.Name = "kryptonDateTimePicker1";
			this.kryptonDateTimePicker1.Size = new System.Drawing.Size(229, 41);
			this.kryptonDateTimePicker1.StateCommon.Border.Color1 = System.Drawing.Color.DodgerBlue;
			this.kryptonDateTimePicker1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonDateTimePicker1.StateCommon.Border.Rounding = 9;
			this.kryptonDateTimePicker1.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonDateTimePicker1.TabIndex = 5;
			// 
			// button2
			// 
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Image = global::Smart_Production_Pos.Properties.Resources.rechercher;
			this.button2.Location = new System.Drawing.Point(4, 33);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(37, 36);
			this.button2.TabIndex = 5;
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.Color.Transparent;
			this.button4.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.Image = global::Smart_Production_Pos.Properties.Resources.actualise;
			this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button4.Location = new System.Drawing.Point(639, 31);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(181, 39);
			this.button4.TabIndex = 5;
			this.button4.Text = "تحديث";
			this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button4.UseVisualStyleBackColor = false;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// frm_facture_commande
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 30F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1120, 562);
			this.Controls.Add(this.pn_historique_client);
			this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
			this.Name = "frm_facture_commande";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.RightToLeftLayout = true;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.pn_historique_client.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.Panel pn_historique_client;
		private System.Windows.Forms.Panel panel3;
		public ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridView1;
		private System.Windows.Forms.Panel panel2;
		private Shade.Controls.GroupBox groupBox2;
		private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem تفاصيلالفاتورةToolStripMenuItem;
		private System.Windows.Forms.Button button4;
	}
}