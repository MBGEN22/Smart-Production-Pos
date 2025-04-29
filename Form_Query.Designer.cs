﻿namespace Smart_Production_Pos
{
    partial class Form_Query
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Query));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_query = new System.Windows.Forms.TextBox();
            this.cmb_db = new System.Windows.Forms.ComboBox();
            this.cmb_server = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_refreshDb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Database :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Query :";
            // 
            // txt_query
            // 
            this.txt_query.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_query.Location = new System.Drawing.Point(102, 89);
            this.txt_query.MaxLength = 0;
            this.txt_query.Multiline = true;
            this.txt_query.Name = "txt_query";
            this.txt_query.Size = new System.Drawing.Size(638, 351);
            this.txt_query.TabIndex = 1;
            // 
            // cmb_db
            // 
            this.cmb_db.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_db.FormattingEnabled = true;
            this.cmb_db.Location = new System.Drawing.Point(102, 48);
            this.cmb_db.Name = "cmb_db";
            this.cmb_db.Size = new System.Drawing.Size(552, 28);
            this.cmb_db.TabIndex = 2;
            // 
            // cmb_server
            // 
            this.cmb_server.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_server.FormattingEnabled = true;
            this.cmb_server.Location = new System.Drawing.Point(102, 9);
            this.cmb_server.Name = "cmb_server";
            this.cmb_server.Size = new System.Drawing.Size(552, 28);
            this.cmb_server.TabIndex = 2;
            this.cmb_server.SelectedIndexChanged += new System.EventHandler(this.cmb_server_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Smart_Production_Pos.Properties.Resources.accept1;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(555, 455);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 46);
            this.button1.TabIndex = 3;
            this.button1.Text = "Execute";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_refreshDb
            // 
            this.btn_refreshDb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_refreshDb.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refreshDb.Image = global::Smart_Production_Pos.Properties.Resources.rechercher;
            this.btn_refreshDb.Location = new System.Drawing.Point(660, 9);
            this.btn_refreshDb.Name = "btn_refreshDb";
            this.btn_refreshDb.Size = new System.Drawing.Size(80, 67);
            this.btn_refreshDb.TabIndex = 3;
            this.btn_refreshDb.UseVisualStyleBackColor = true;
            this.btn_refreshDb.Click += new System.EventHandler(this.btn_refreshDb_Click);
            // 
            // Form_Query
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 514);
            this.Controls.Add(this.btn_refreshDb);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmb_server);
            this.Controls.Add(this.cmb_db);
            this.Controls.Add(this.txt_query);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Myanmar Text", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Form_Query";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الاستعلامات";
            this.Load += new System.EventHandler(this.Form_Query_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_query;
        private System.Windows.Forms.ComboBox cmb_db;
        private System.Windows.Forms.ComboBox cmb_server;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_refreshDb;
    }
}