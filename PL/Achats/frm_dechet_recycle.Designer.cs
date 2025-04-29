namespace Smart_Production_Pos.PL.Achats
{
	partial class frm_dechet_recycle
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pn_stock_matier_premier = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.DataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.kryptonButton4 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.txtSearch = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
			this.pn_stock_matier_premier.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pn_stock_matier_premier
			// 
			this.pn_stock_matier_premier.Controls.Add(this.panel3);
			this.pn_stock_matier_premier.Controls.Add(this.panel2);
			this.pn_stock_matier_premier.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pn_stock_matier_premier.Location = new System.Drawing.Point(0, 0);
			this.pn_stock_matier_premier.Name = "pn_stock_matier_premier";
			this.pn_stock_matier_premier.Size = new System.Drawing.Size(930, 575);
			this.pn_stock_matier_premier.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.White;
			this.panel3.Controls.Add(this.DataGridView1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 57);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(930, 518);
			this.panel3.TabIndex = 4;
			// 
			// DataGridView1
			// 
			this.DataGridView1.AllowUserToAddRows = false;
			this.DataGridView1.AllowUserToDeleteRows = false;
			this.DataGridView1.AllowUserToOrderColumns = true;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.NullValue = null;
			this.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.DataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DataGridView1.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
			this.DataGridView1.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
			this.DataGridView1.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.DataGridView1.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.DataGridView1.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
			this.DataGridView1.ImeMode = System.Windows.Forms.ImeMode.On;
			this.DataGridView1.Location = new System.Drawing.Point(0, 0);
			this.DataGridView1.Name = "DataGridView1";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.DataGridView1.Size = new System.Drawing.Size(930, 518);
			this.DataGridView1.StateCommon.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
			this.DataGridView1.StateCommon.DataCell.Border.Color1 = System.Drawing.Color.Black;
			this.DataGridView1.StateCommon.DataCell.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.DataGridView1.StateCommon.DataCell.Content.Color1 = System.Drawing.Color.Black;
			this.DataGridView1.StateCommon.DataCell.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DataGridView1.StateCommon.HeaderColumn.Back.Color1 = System.Drawing.Color.White;
			this.DataGridView1.StateCommon.HeaderColumn.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.DataGridView1.StateCommon.HeaderColumn.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed;
			this.DataGridView1.StateCommon.HeaderColumn.Border.Color1 = System.Drawing.Color.White;
			this.DataGridView1.StateCommon.HeaderColumn.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.DataGridView1.StateCommon.HeaderColumn.Content.Color1 = System.Drawing.Color.Black;
			this.DataGridView1.StateCommon.HeaderColumn.Content.Color2 = System.Drawing.Color.Black;
			this.DataGridView1.StateCommon.HeaderColumn.Content.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed;
			this.DataGridView1.StateCommon.HeaderColumn.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DataGridView1.TabIndex = 2;
			this.DataGridView1.VirtualMode = true;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.White;
			this.panel2.Controls.Add(this.kryptonButton4);
			this.panel2.Controls.Add(this.txtSearch);
			this.panel2.Controls.Add(this.bigLabel1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(930, 57);
			this.panel2.TabIndex = 3;
			// 
			// kryptonButton4
			// 
			this.kryptonButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.kryptonButton4.Location = new System.Drawing.Point(678, 5);
			this.kryptonButton4.Name = "kryptonButton4";
			this.kryptonButton4.Size = new System.Drawing.Size(240, 46);
			this.kryptonButton4.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.kryptonButton4.StateCommon.Back.Color2 = System.Drawing.Color.DodgerBlue;
			this.kryptonButton4.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.kryptonButton4.StateCommon.Border.Rounding = 5;
			this.kryptonButton4.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
			this.kryptonButton4.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kryptonButton4.TabIndex = 121;
			this.kryptonButton4.Values.Image = global::Smart_Production_Pos.Properties.Resources.editer;
			this.kryptonButton4.Values.Text = "تعديل حالة المخلفات";
			this.kryptonButton4.Click += new System.EventHandler(this.kryptonButton4_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearch.Location = new System.Drawing.Point(266, 7);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(307, 43);
			this.txtSearch.StateCommon.Border.Color1 = System.Drawing.Color.DodgerBlue;
			this.txtSearch.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txtSearch.StateCommon.Border.Rounding = 10;
			this.txtSearch.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSearch.TabIndex = 4;
			this.txtSearch.TextChanged += new System.EventHandler(this.kryptonTextBox1_TextChanged);
			// 
			// bigLabel1
			// 
			this.bigLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bigLabel1.AutoSize = true;
			this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
			this.bigLabel1.Font = new System.Drawing.Font("Cairo", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bigLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.bigLabel1.Location = new System.Drawing.Point(566, -2);
			this.bigLabel1.Name = "bigLabel1";
			this.bigLabel1.Size = new System.Drawing.Size(116, 62);
			this.bigLabel1.TabIndex = 0;
			this.bigLabel1.Text = "البحث :";
			// 
			// frm_dechet_recycle
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(930, 575);
			this.Controls.Add(this.pn_stock_matier_premier);
			this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frm_dechet_recycle";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.RightToLeftLayout = true;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "المخلفات";
			this.pn_stock_matier_premier.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		public System.Windows.Forms.Panel pn_stock_matier_premier;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel2;
		public ComponentFactory.Krypton.Toolkit.KryptonDataGridView DataGridView1;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearch;
		private ReaLTaiizor.Controls.BigLabel bigLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton4;
	}
}