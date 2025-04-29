namespace Smart_Production_Pos.PL.Commande
{
	partial class frm_sub_commande
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
			this.pn_sub_commande = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.txt_rest_ttl = new System.Windows.Forms.TextBox();
			this.txt_livre_ttl = new System.Windows.Forms.TextBox();
			this.label46 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.txt_Quantite = new System.Windows.Forms.TextBox();
			this.dataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
			this.pn_sub_commande.SuspendLayout();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// pn_sub_commande
			// 
			this.pn_sub_commande.Controls.Add(this.dataGridView1);
			this.pn_sub_commande.Controls.Add(this.panel5);
			this.pn_sub_commande.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pn_sub_commande.Location = new System.Drawing.Point(0, 0);
			this.pn_sub_commande.Name = "pn_sub_commande";
			this.pn_sub_commande.Size = new System.Drawing.Size(1055, 564);
			this.pn_sub_commande.TabIndex = 0;
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(51)))), ((int)(((byte)(63)))));
			this.panel5.Controls.Add(this.txt_rest_ttl);
			this.panel5.Controls.Add(this.txt_livre_ttl);
			this.panel5.Controls.Add(this.label1);
			this.panel5.Controls.Add(this.label33);
			this.panel5.Controls.Add(this.txt_Quantite);
			this.panel5.Controls.Add(this.label46);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(1055, 145);
			this.panel5.TabIndex = 44;
			// 
			// txt_rest_ttl
			// 
			this.txt_rest_ttl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_rest_ttl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.txt_rest_ttl.Enabled = false;
			this.txt_rest_ttl.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_rest_ttl.Location = new System.Drawing.Point(12, 94);
			this.txt_rest_ttl.Name = "txt_rest_ttl";
			this.txt_rest_ttl.Size = new System.Drawing.Size(918, 37);
			this.txt_rest_ttl.TabIndex = 3;
			this.txt_rest_ttl.Text = "00";
			this.txt_rest_ttl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txt_livre_ttl
			// 
			this.txt_livre_ttl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_livre_ttl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.txt_livre_ttl.Enabled = false;
			this.txt_livre_ttl.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_livre_ttl.Location = new System.Drawing.Point(12, 53);
			this.txt_livre_ttl.Name = "txt_livre_ttl";
			this.txt_livre_ttl.Size = new System.Drawing.Size(918, 37);
			this.txt_livre_ttl.TabIndex = 3;
			this.txt_livre_ttl.Text = "00";
			this.txt_livre_ttl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label46
			// 
			this.label46.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label46.AutoSize = true;
			this.label46.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label46.ForeColor = System.Drawing.Color.White;
			this.label46.Location = new System.Drawing.Point(928, 16);
			this.label46.Name = "label46";
			this.label46.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label46.Size = new System.Drawing.Size(107, 30);
			this.label46.TabIndex = 48;
			this.label46.Text = "الكمية الكلية :";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(928, 97);
			this.label1.Name = "label1";
			this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label1.Size = new System.Drawing.Size(122, 30);
			this.label1.TabIndex = 49;
			this.label1.Text = "الكمية المتبقية :";
			// 
			// label33
			// 
			this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label33.AutoSize = true;
			this.label33.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label33.ForeColor = System.Drawing.Color.White;
			this.label33.Location = new System.Drawing.Point(928, 56);
			this.label33.Name = "label33";
			this.label33.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label33.Size = new System.Drawing.Size(127, 30);
			this.label33.TabIndex = 49;
			this.label33.Text = "الكمية المسلمة :";
			// 
			// txt_Quantite
			// 
			this.txt_Quantite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_Quantite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.txt_Quantite.Enabled = false;
			this.txt_Quantite.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_Quantite.Location = new System.Drawing.Point(12, 13);
			this.txt_Quantite.Name = "txt_Quantite";
			this.txt_Quantite.Size = new System.Drawing.Size(918, 37);
			this.txt_Quantite.TabIndex = 4;
			this.txt_Quantite.Text = "00";
			this.txt_Quantite.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToOrderColumns = true;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.NullValue = null;
			this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
			this.dataGridView1.Location = new System.Drawing.Point(0, 145);
			this.dataGridView1.Name = "dataGridView1";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView1.Size = new System.Drawing.Size(1055, 419);
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
			this.dataGridView1.TabIndex = 45;
			this.dataGridView1.VirtualMode = true;
			// 
			// frm_sub_commande
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1055, 564);
			this.Controls.Add(this.pn_sub_commande);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frm_sub_commande";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frm_sub_commande";
			this.pn_sub_commande.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel5;
		public System.Windows.Forms.TextBox txt_rest_ttl;
		public System.Windows.Forms.TextBox txt_livre_ttl;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label33;
		public System.Windows.Forms.TextBox txt_Quantite;
		public System.Windows.Forms.Panel pn_sub_commande;
		public ComponentFactory.Krypton.Toolkit.KryptonDataGridView dataGridView1;
	}
}