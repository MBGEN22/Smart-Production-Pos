namespace Smart_Production_Pos.TAB_CONTROL
{
    partial class User_Fav
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LB_Name = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.وضعمنتجاتمربوطةبالمفضلةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LB_Name
            // 
            this.LB_Name.ContextMenuStrip = this.contextMenuStrip2;
            this.LB_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LB_Name.Location = new System.Drawing.Point(0, 0);
            this.LB_Name.Name = "LB_Name";
            this.LB_Name.Size = new System.Drawing.Size(147, 60);
            this.LB_Name.StateCommon.Back.Color1 = System.Drawing.SystemColors.Highlight;
            this.LB_Name.StateCommon.Back.Color2 = System.Drawing.Color.DodgerBlue;
            this.LB_Name.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.LB_Name.StateCommon.Border.Rounding = 10;
            this.LB_Name.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.LB_Name.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Name.TabIndex = 3;
            this.LB_Name.Values.Text = "ctrl + F";
            this.LB_Name.Click += new System.EventHandler(this.LB_Name_Click_1);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.وضعمنتجاتمربوطةبالمفضلةToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(229, 48);
            // 
            // وضعمنتجاتمربوطةبالمفضلةToolStripMenuItem
            // 
            this.وضعمنتجاتمربوطةبالمفضلةToolStripMenuItem.Image = global::Smart_Production_Pos.Properties.Resources.bouton_modifier;
            this.وضعمنتجاتمربوطةبالمفضلةToolStripMenuItem.Name = "وضعمنتجاتمربوطةبالمفضلةToolStripMenuItem";
            this.وضعمنتجاتمربوطةبالمفضلةToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.وضعمنتجاتمربوطةبالمفضلةToolStripMenuItem.Text = "وضع منتجات مربوطة بالمفضلة";
            this.وضعمنتجاتمربوطةبالمفضلةToolStripMenuItem.Click += new System.EventHandler(this.وضعمنتجاتمربوطةبالمفضلةToolStripMenuItem_Click);
            // 
            // User_Fav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LB_Name);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "User_Fav";
            this.Size = new System.Drawing.Size(147, 60);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public ComponentFactory.Krypton.Toolkit.KryptonButton LB_Name;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem وضعمنتجاتمربوطةبالمفضلةToolStripMenuItem;
    }
}
