namespace Smart_Production_Pos.TAB_CONTROL
{
    partial class favCaisseV5
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
            this.LB_Name = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // LB_Name
            // 
            this.LB_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LB_Name.Location = new System.Drawing.Point(0, 0);
            this.LB_Name.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.LB_Name.Name = "LB_Name";
            this.LB_Name.Size = new System.Drawing.Size(119, 57);
            this.LB_Name.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.LB_Name.StateCommon.Back.Color2 = System.Drawing.Color.Azure;
            this.LB_Name.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Dashed;
            this.LB_Name.StateCommon.Border.Color1 = System.Drawing.Color.Black;
            this.LB_Name.StateCommon.Border.Color2 = System.Drawing.Color.Black;
            this.LB_Name.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.LB_Name.StateCommon.Border.Rounding = 10;
            this.LB_Name.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.LB_Name.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Name.TabIndex = 4;
            this.LB_Name.Values.Text = "ctrl + F";
            this.LB_Name.Click += new System.EventHandler(this.LB_Name_Click_2);
            // 
            // favCaisseV5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LB_Name);
            this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "favCaisseV5";
            this.Size = new System.Drawing.Size(119, 57);
            this.ResumeLayout(false);

        }

        #endregion

        public ComponentFactory.Krypton.Toolkit.KryptonButton LB_Name;
    }
}
