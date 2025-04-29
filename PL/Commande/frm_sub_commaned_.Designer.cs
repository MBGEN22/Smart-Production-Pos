namespace Smart_Production_Pos.PL.Commande
{
	partial class frm_sub_commaned_
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
			this.grid_sub_commande = new System.Windows.Forms.DataGridView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.الموادالمستعملةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel5 = new System.Windows.Forms.Panel();
			this.txt_cout = new System.Windows.Forms.TextBox();
			this.txt_prix_total = new System.Windows.Forms.TextBox();
			this.label46 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.txt_Quantite = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.grid_sub_commande)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// grid_sub_commande
			// 
			this.grid_sub_commande.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.grid_sub_commande.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grid_sub_commande.ContextMenuStrip = this.contextMenuStrip1;
			this.grid_sub_commande.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid_sub_commande.Location = new System.Drawing.Point(0, 145);
			this.grid_sub_commande.Name = "grid_sub_commande";
			this.grid_sub_commande.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.grid_sub_commande.Size = new System.Drawing.Size(968, 397);
			this.grid_sub_commande.TabIndex = 44;
			this.grid_sub_commande.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_sub_commande_CellContentClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.الموادالمستعملةToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.contextMenuStrip1.Size = new System.Drawing.Size(159, 26);
			// 
			// الموادالمستعملةToolStripMenuItem
			// 
			this.الموادالمستعملةToolStripMenuItem.Name = "الموادالمستعملةToolStripMenuItem";
			this.الموادالمستعملةToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.الموادالمستعملةToolStripMenuItem.Text = "المواد المستعملة";
			this.الموادالمستعملةToolStripMenuItem.Click += new System.EventHandler(this.الموادالمستعملةToolStripMenuItem_Click);
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(51)))), ((int)(((byte)(63)))));
			this.panel5.Controls.Add(this.txt_cout);
			this.panel5.Controls.Add(this.txt_prix_total);
			this.panel5.Controls.Add(this.label46);
			this.panel5.Controls.Add(this.label1);
			this.panel5.Controls.Add(this.label33);
			this.panel5.Controls.Add(this.txt_Quantite);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(968, 145);
			this.panel5.TabIndex = 43;
			// 
			// txt_cout
			// 
			this.txt_cout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_cout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.txt_cout.Enabled = false;
			this.txt_cout.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_cout.Location = new System.Drawing.Point(12, 94);
			this.txt_cout.Name = "txt_cout";
			this.txt_cout.Size = new System.Drawing.Size(831, 37);
			this.txt_cout.TabIndex = 3;
			this.txt_cout.Text = "00";
			this.txt_cout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txt_prix_total
			// 
			this.txt_prix_total.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_prix_total.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.txt_prix_total.Enabled = false;
			this.txt_prix_total.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_prix_total.Location = new System.Drawing.Point(12, 53);
			this.txt_prix_total.Name = "txt_prix_total";
			this.txt_prix_total.Size = new System.Drawing.Size(831, 37);
			this.txt_prix_total.TabIndex = 3;
			this.txt_prix_total.Text = "00";
			this.txt_prix_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label46
			// 
			this.label46.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label46.AutoSize = true;
			this.label46.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label46.ForeColor = System.Drawing.Color.White;
			this.label46.Location = new System.Drawing.Point(849, 13);
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
			this.label1.Location = new System.Drawing.Point(849, 97);
			this.label1.Name = "label1";
			this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label1.Size = new System.Drawing.Size(111, 30);
			this.label1.TabIndex = 49;
			this.label1.Text = "التكلفة الكلية :";
			// 
			// label33
			// 
			this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label33.AutoSize = true;
			this.label33.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label33.ForeColor = System.Drawing.Color.White;
			this.label33.Location = new System.Drawing.Point(849, 56);
			this.label33.Name = "label33";
			this.label33.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label33.Size = new System.Drawing.Size(98, 30);
			this.label33.TabIndex = 49;
			this.label33.Text = "السعر الكلي :";
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
			this.txt_Quantite.Size = new System.Drawing.Size(831, 37);
			this.txt_Quantite.TabIndex = 4;
			this.txt_Quantite.Text = "00";
			this.txt_Quantite.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// frm_sub_commaned_
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 30F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(968, 542);
			this.Controls.Add(this.grid_sub_commande);
			this.Controls.Add(this.panel5);
			this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
			this.Name = "frm_sub_commaned_";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.RightToLeftLayout = true;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "تفاصيل الطلبية";
			this.Load += new System.EventHandler(this.frm_sub_commaned__Load);
			((System.ComponentModel.ISupportInitialize)(this.grid_sub_commande)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.DataGridView grid_sub_commande;
		private System.Windows.Forms.Panel panel5;
		public System.Windows.Forms.TextBox txt_prix_total;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label33;
		public System.Windows.Forms.TextBox txt_Quantite;
		public System.Windows.Forms.TextBox txt_cout;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem الموادالمستعملةToolStripMenuItem;
	}
}