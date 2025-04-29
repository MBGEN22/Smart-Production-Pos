namespace Smart_Production_Pos.PL.Achat_revente
{
    partial class frm_import_by_excel
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
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.sheetxx = new System.Windows.Forms.Label();
            this.cboSheet = new System.Windows.Forms.ComboBox();
            this.panel1 = new Shade.Controls.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codeBarreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.designationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceAchatHTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceAchatTTCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantiteTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceVente1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceVente2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceMinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.venteApresExpirationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockeNegatifDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantiteVenteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantiteRestDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantiteDechetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantiteAlertDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ihtiyajDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(60, 14);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(1003, 37);
            this.txtFileName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1067, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "اسم الملف";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Smart_Production_Pos.Properties.Resources.search;
            this.button1.Location = new System.Drawing.Point(12, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 40);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Image = global::Smart_Production_Pos.Properties.Resources.xls;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(61, 55);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button2.Size = new System.Drawing.Size(122, 38);
            this.button2.TabIndex = 15;
            this.button2.Text = "استراد";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // sheetxx
            // 
            this.sheetxx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sheetxx.AutoSize = true;
            this.sheetxx.BackColor = System.Drawing.Color.Transparent;
            this.sheetxx.ForeColor = System.Drawing.Color.White;
            this.sheetxx.Location = new System.Drawing.Point(1067, 59);
            this.sheetxx.Name = "sheetxx";
            this.sheetxx.Size = new System.Drawing.Size(64, 30);
            this.sheetxx.TabIndex = 8;
            this.sheetxx.Text = "الصفحة";
            // 
            // cboSheet
            // 
            this.cboSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSheet.FormattingEnabled = true;
            this.cboSheet.Location = new System.Drawing.Point(198, 55);
            this.cboSheet.Name = "cboSheet";
            this.cboSheet.Size = new System.Drawing.Size(865, 38);
            this.cboSheet.TabIndex = 16;
            this.cboSheet.SelectedIndexChanged += new System.EventHandler(this.cboSheet_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(51)))), ((int)(((byte)(63)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboSheet);
            this.panel1.Controls.Add(this.txtFileName);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.sheetxx);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(1167, 105);
            this.panel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.panel1.TabIndex = 17;
            this.panel1.Text = "panel1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Smart_Production_Pos.Properties.Resources.stock;
            this.pictureBox2.Location = new System.Drawing.Point(1066, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(101, 83);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 127;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeBarreDataGridViewTextBoxColumn,
            this.designationDataGridViewTextBoxColumn,
            this.referenceDataGridViewTextBoxColumn,
            this.priceAchatHTDataGridViewTextBoxColumn,
            this.priceAchatTTCDataGridViewTextBoxColumn,
            this.tVADataGridViewTextBoxColumn,
            this.quantiteTotalDataGridViewTextBoxColumn,
            this.priceVente1DataGridViewTextBoxColumn,
            this.priceVente2DataGridViewTextBoxColumn,
            this.priceMinDataGridViewTextBoxColumn,
            this.venteApresExpirationDataGridViewTextBoxColumn,
            this.stockeNegatifDataGridViewTextBoxColumn,
            this.quantiteVenteDataGridViewTextBoxColumn,
            this.quantiteRestDataGridViewTextBoxColumn,
            this.quantiteDechetDataGridViewTextBoxColumn,
            this.quantiteAlertDataGridViewTextBoxColumn,
            this.ihtiyajDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.productBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 105);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1167, 468);
            this.dataGridView1.TabIndex = 18;
            // 
            // codeBarreDataGridViewTextBoxColumn
            // 
            this.codeBarreDataGridViewTextBoxColumn.DataPropertyName = "CodeBarre";
            this.codeBarreDataGridViewTextBoxColumn.HeaderText = "CodeBarre";
            this.codeBarreDataGridViewTextBoxColumn.Name = "codeBarreDataGridViewTextBoxColumn";
            this.codeBarreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // designationDataGridViewTextBoxColumn
            // 
            this.designationDataGridViewTextBoxColumn.DataPropertyName = "Designation";
            this.designationDataGridViewTextBoxColumn.HeaderText = "Designation";
            this.designationDataGridViewTextBoxColumn.Name = "designationDataGridViewTextBoxColumn";
            this.designationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // referenceDataGridViewTextBoxColumn
            // 
            this.referenceDataGridViewTextBoxColumn.DataPropertyName = "Reference";
            this.referenceDataGridViewTextBoxColumn.HeaderText = "Reference";
            this.referenceDataGridViewTextBoxColumn.Name = "referenceDataGridViewTextBoxColumn";
            this.referenceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceAchatHTDataGridViewTextBoxColumn
            // 
            this.priceAchatHTDataGridViewTextBoxColumn.DataPropertyName = "PriceAchatHT";
            this.priceAchatHTDataGridViewTextBoxColumn.HeaderText = "PriceAchatHT";
            this.priceAchatHTDataGridViewTextBoxColumn.Name = "priceAchatHTDataGridViewTextBoxColumn";
            this.priceAchatHTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceAchatTTCDataGridViewTextBoxColumn
            // 
            this.priceAchatTTCDataGridViewTextBoxColumn.DataPropertyName = "PriceAchatTTC";
            this.priceAchatTTCDataGridViewTextBoxColumn.HeaderText = "PriceAchatTTC";
            this.priceAchatTTCDataGridViewTextBoxColumn.Name = "priceAchatTTCDataGridViewTextBoxColumn";
            this.priceAchatTTCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tVADataGridViewTextBoxColumn
            // 
            this.tVADataGridViewTextBoxColumn.DataPropertyName = "TVA";
            this.tVADataGridViewTextBoxColumn.HeaderText = "TVA";
            this.tVADataGridViewTextBoxColumn.Name = "tVADataGridViewTextBoxColumn";
            this.tVADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantiteTotalDataGridViewTextBoxColumn
            // 
            this.quantiteTotalDataGridViewTextBoxColumn.DataPropertyName = "QuantiteTotal";
            this.quantiteTotalDataGridViewTextBoxColumn.HeaderText = "QuantiteTotal";
            this.quantiteTotalDataGridViewTextBoxColumn.Name = "quantiteTotalDataGridViewTextBoxColumn";
            this.quantiteTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceVente1DataGridViewTextBoxColumn
            // 
            this.priceVente1DataGridViewTextBoxColumn.DataPropertyName = "PriceVente1";
            this.priceVente1DataGridViewTextBoxColumn.HeaderText = "PriceVente1";
            this.priceVente1DataGridViewTextBoxColumn.Name = "priceVente1DataGridViewTextBoxColumn";
            this.priceVente1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceVente2DataGridViewTextBoxColumn
            // 
            this.priceVente2DataGridViewTextBoxColumn.DataPropertyName = "PriceVente2";
            this.priceVente2DataGridViewTextBoxColumn.HeaderText = "PriceVente2";
            this.priceVente2DataGridViewTextBoxColumn.Name = "priceVente2DataGridViewTextBoxColumn";
            this.priceVente2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceMinDataGridViewTextBoxColumn
            // 
            this.priceMinDataGridViewTextBoxColumn.DataPropertyName = "PriceMin";
            this.priceMinDataGridViewTextBoxColumn.HeaderText = "PriceMin";
            this.priceMinDataGridViewTextBoxColumn.Name = "priceMinDataGridViewTextBoxColumn";
            this.priceMinDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // venteApresExpirationDataGridViewTextBoxColumn
            // 
            this.venteApresExpirationDataGridViewTextBoxColumn.DataPropertyName = "VenteApresExpiration";
            this.venteApresExpirationDataGridViewTextBoxColumn.HeaderText = "VenteApresExpiration";
            this.venteApresExpirationDataGridViewTextBoxColumn.Name = "venteApresExpirationDataGridViewTextBoxColumn";
            this.venteApresExpirationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stockeNegatifDataGridViewTextBoxColumn
            // 
            this.stockeNegatifDataGridViewTextBoxColumn.DataPropertyName = "StockeNegatif";
            this.stockeNegatifDataGridViewTextBoxColumn.HeaderText = "StockeNegatif";
            this.stockeNegatifDataGridViewTextBoxColumn.Name = "stockeNegatifDataGridViewTextBoxColumn";
            this.stockeNegatifDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantiteVenteDataGridViewTextBoxColumn
            // 
            this.quantiteVenteDataGridViewTextBoxColumn.DataPropertyName = "QuantiteVente";
            this.quantiteVenteDataGridViewTextBoxColumn.HeaderText = "QuantiteVente";
            this.quantiteVenteDataGridViewTextBoxColumn.Name = "quantiteVenteDataGridViewTextBoxColumn";
            this.quantiteVenteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantiteRestDataGridViewTextBoxColumn
            // 
            this.quantiteRestDataGridViewTextBoxColumn.DataPropertyName = "QuantiteRest";
            this.quantiteRestDataGridViewTextBoxColumn.HeaderText = "QuantiteRest";
            this.quantiteRestDataGridViewTextBoxColumn.Name = "quantiteRestDataGridViewTextBoxColumn";
            this.quantiteRestDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantiteDechetDataGridViewTextBoxColumn
            // 
            this.quantiteDechetDataGridViewTextBoxColumn.DataPropertyName = "QuantiteDechet";
            this.quantiteDechetDataGridViewTextBoxColumn.HeaderText = "QuantiteDechet";
            this.quantiteDechetDataGridViewTextBoxColumn.Name = "quantiteDechetDataGridViewTextBoxColumn";
            this.quantiteDechetDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantiteAlertDataGridViewTextBoxColumn
            // 
            this.quantiteAlertDataGridViewTextBoxColumn.DataPropertyName = "QuantiteAlert";
            this.quantiteAlertDataGridViewTextBoxColumn.HeaderText = "QuantiteAlert";
            this.quantiteAlertDataGridViewTextBoxColumn.Name = "quantiteAlertDataGridViewTextBoxColumn";
            this.quantiteAlertDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ihtiyajDataGridViewTextBoxColumn
            // 
            this.ihtiyajDataGridViewTextBoxColumn.DataPropertyName = "Ihtiyaj";
            this.ihtiyajDataGridViewTextBoxColumn.HeaderText = "Ihtiyaj";
            this.ihtiyajDataGridViewTextBoxColumn.Name = "ihtiyajDataGridViewTextBoxColumn";
            this.ihtiyajDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(Smart_Production_Pos.product);
            // 
            // frm_import_by_excel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 573);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "frm_import_by_excel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "استيراد المنتوجات عن طريق الأكسل";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label sheetxx;
        private System.Windows.Forms.ComboBox cboSheet;
        private Shade.Controls.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeBarreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn designationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCategoriesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idStockeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMarqueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUniteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTailleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFavoireDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateExpirationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceAchatHTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceAchatTTCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tVADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantiteTotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceVente1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceVente2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceMinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn venteApresExpirationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockeNegatifDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantiteVenteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantiteRestDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantiteDechetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn photoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qTDansPackDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantiteAlertDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ihtiyajDataGridViewTextBoxColumn;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.BindingSource productBindingSource;
    }
}