namespace Smart_Production_Pos.PL.Achat_revente
{
	partial class FRM_fichier_fctr_produit_revente
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.pn_list_folder = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txt_seach = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.pn_list_folder.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
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
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(1028, 513);
			this.dataGridView1.TabIndex = 1;
			this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
			// 
			// pn_list_folder
			// 
			this.pn_list_folder.BackColor = System.Drawing.Color.White;
			this.pn_list_folder.Controls.Add(this.panel3);
			this.pn_list_folder.Controls.Add(this.panel2);
			this.pn_list_folder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pn_list_folder.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pn_list_folder.Location = new System.Drawing.Point(0, 0);
			this.pn_list_folder.Name = "pn_list_folder";
			this.pn_list_folder.Size = new System.Drawing.Size(1028, 578);
			this.pn_list_folder.TabIndex = 7;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.White;
			this.panel3.Controls.Add(this.dataGridView1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 65);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1028, 513);
			this.panel3.TabIndex = 2;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.White;
			this.panel2.Controls.Add(this.txt_seach);
			this.panel2.Controls.Add(this.bigLabel1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1028, 65);
			this.panel2.TabIndex = 1;
			// 
			// txt_seach
			// 
			this.txt_seach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_seach.Location = new System.Drawing.Point(12, 12);
			this.txt_seach.Name = "txt_seach";
			this.txt_seach.Size = new System.Drawing.Size(905, 43);
			this.txt_seach.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
			this.txt_seach.StateCommon.Border.Rounding = 10;
			this.txt_seach.StateCommon.Content.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_seach.TabIndex = 2;
			this.txt_seach.TextChanged += new System.EventHandler(this.txt_seach_TextChanged);
			// 
			// bigLabel1
			// 
			this.bigLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bigLabel1.AutoSize = true;
			this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
			this.bigLabel1.Font = new System.Drawing.Font("Cairo", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bigLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.bigLabel1.Location = new System.Drawing.Point(910, 1);
			this.bigLabel1.Name = "bigLabel1";
			this.bigLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.bigLabel1.Size = new System.Drawing.Size(116, 62);
			this.bigLabel1.TabIndex = 0;
			this.bigLabel1.Text = "البحث :";
			// 
			// FRM_fichier_fctr_produit_revente
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 30F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1028, 578);
			this.Controls.Add(this.pn_list_folder);
			this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
			this.Name = "FRM_fichier_fctr_produit_revente";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.pn_list_folder.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.DataGridView dataGridView1;
		public System.Windows.Forms.Panel pn_list_folder;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel2;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_seach;
		private ReaLTaiizor.Controls.BigLabel bigLabel1;
	}
}