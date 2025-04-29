namespace Smart_Production_Pos.PL.Commande
{
	partial class frm_matier_use_
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
			this.grid_sub_commande = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.grid_sub_commande)).BeginInit();
			this.SuspendLayout();
			// 
			// grid_sub_commande
			// 
			this.grid_sub_commande.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.grid_sub_commande.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grid_sub_commande.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid_sub_commande.Location = new System.Drawing.Point(0, 0);
			this.grid_sub_commande.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
			this.grid_sub_commande.Name = "grid_sub_commande";
			this.grid_sub_commande.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.grid_sub_commande.Size = new System.Drawing.Size(726, 416);
			this.grid_sub_commande.TabIndex = 45;
			// 
			// frm_matier_use_
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 30F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(726, 416);
			this.Controls.Add(this.grid_sub_commande);
			this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
			this.Name = "frm_matier_use_";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.RightToLeftLayout = true;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "المواد المستعملة";
			this.Load += new System.EventHandler(this.frm_matier_use__Load);
			((System.ComponentModel.ISupportInitialize)(this.grid_sub_commande)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.DataGridView grid_sub_commande;
	}
}