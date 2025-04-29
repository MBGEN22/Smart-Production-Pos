namespace Smart_Production_Pos.PL.CLient
{
	partial class frm_remarque_client
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.groupBox1 = new Shade.Controls.GroupBox();
			this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pn_historique_client = new System.Windows.Forms.Panel();
			this.groupBox1.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel2.SuspendLayout();
			this.pn_historique_client.SuspendLayout();
			this.SuspendLayout();
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
			this.groupBox1.BorderColorG = System.Drawing.Color.DodgerBlue;
			this.groupBox1.BorderColorH = System.Drawing.Color.DodgerBlue;
			this.groupBox1.Controls.Add(this.kryptonTextBox1);
			this.groupBox1.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
			this.groupBox1.HeaderColor = System.Drawing.Color.White;
			this.groupBox1.Location = new System.Drawing.Point(392, 3);
			this.groupBox1.MinimumSize = new System.Drawing.Size(136, 50);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
			this.groupBox1.Size = new System.Drawing.Size(438, 79);
			this.groupBox1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			this.groupBox1.TabIndex = 4;
			this.groupBox1.Text = "البحث ";
			// 
			// kryptonButton1
			// 
			this.kryptonButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.kryptonButton1.Location = new System.Drawing.Point(836, 12);
			this.kryptonButton1.Name = "kryptonButton1";
			this.kryptonButton1.Size = new System.Drawing.Size(162, 70);
			this.kryptonButton1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.kryptonButton1.StateCommon.Back.Color2 = System.Drawing.Color.Teal;
			this.kryptonButton1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonButton1.StateCommon.Border.Rounding = 5;
			this.kryptonButton1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
			this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonButton1.TabIndex = 0;
			this.kryptonButton1.Values.Image = global::Smart_Production_Pos.Properties.Resources.ajouter_un_bouton;
			this.kryptonButton1.Values.Text = "إضافة";
			this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
			// 
			// kryptonTextBox1
			// 
			this.kryptonTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.kryptonTextBox1.Location = new System.Drawing.Point(8, 31);
			this.kryptonTextBox1.Name = "kryptonTextBox1";
			this.kryptonTextBox1.Size = new System.Drawing.Size(422, 43);
			this.kryptonTextBox1.StateCommon.Border.Color1 = System.Drawing.Color.DodgerBlue;
			this.kryptonTextBox1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonTextBox1.StateCommon.Border.Rounding = 10;
			this.kryptonTextBox1.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonTextBox1.TabIndex = 2;
			this.kryptonTextBox1.TextChanged += new System.EventHandler(this.kryptonTextBox1_TextChanged);
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.White;
			this.panel3.Controls.Add(this.dataGridView1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 91);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1010, 499);
			this.panel3.TabIndex = 2;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToOrderColumns = true;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle7.NullValue = null;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
			this.dataGridView1.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
			this.dataGridView1.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.dataGridView1.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.dataGridView1.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.On;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
			this.dataGridView1.Size = new System.Drawing.Size(1010, 499);
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
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.White;
			this.panel2.Controls.Add(this.groupBox1);
			this.panel2.Controls.Add(this.kryptonButton1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1010, 91);
			this.panel2.TabIndex = 1;
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
			this.pn_historique_client.Size = new System.Drawing.Size(1010, 590);
			this.pn_historique_client.TabIndex = 7;
			// 
			// frm_remarque_client
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1010, 590);
			this.Controls.Add(this.pn_historique_client);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frm_remarque_client";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.RightToLeftLayout = true;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "صفحة ملاحظات الزبائن";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.pn_historique_client.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Shade.Controls.GroupBox groupBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
		private System.Windows.Forms.Panel panel3;
		public ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridView1;
		private System.Windows.Forms.Panel panel2;
		public System.Windows.Forms.Panel pn_historique_client;
	}
}