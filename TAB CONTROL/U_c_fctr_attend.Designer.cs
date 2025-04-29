namespace Smart_Production_Pos.TAB_CONTROL
{
    partial class U_c_fctr_attend
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel26 = new System.Windows.Forms.Panel();
            this.lb_Price_ttl = new System.Windows.Forms.Label();
            this.panel26.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel26
            // 
            this.panel26.BackColor = System.Drawing.Color.Salmon;
            this.panel26.Controls.Add(this.lb_Price_ttl);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel26.Location = new System.Drawing.Point(0, 0);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(81, 40);
            this.panel26.TabIndex = 4;
            // 
            // lb_Price_ttl
            // 
            this.lb_Price_ttl.BackColor = System.Drawing.Color.LawnGreen;
            this.lb_Price_ttl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Price_ttl.Font = new System.Drawing.Font("Cairo SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Price_ttl.ForeColor = System.Drawing.Color.Black;
            this.lb_Price_ttl.Location = new System.Drawing.Point(0, 0);
            this.lb_Price_ttl.Name = "lb_Price_ttl";
            this.lb_Price_ttl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lb_Price_ttl.Size = new System.Drawing.Size(81, 40);
            this.lb_Price_ttl.TabIndex = 8;
            this.lb_Price_ttl.Text = "00";
            this.lb_Price_ttl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Price_ttl.Click += new System.EventHandler(this.lb_Price_ttl_Click);
            // 
            // U_c_fctr_attend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel26);
            this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "U_c_fctr_attend";
            this.Size = new System.Drawing.Size(81, 40);
            this.panel26.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel26;
        public System.Windows.Forms.Label lb_Price_ttl;
    }
}
