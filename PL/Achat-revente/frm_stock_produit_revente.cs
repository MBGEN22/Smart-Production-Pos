using Smart_Production_Pos.BL;
using Smart_Production_Pos.PLADD.Achat_revente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ZXing.OneD; 
using ZXing.QrCode.Internal;
using iTextSharp.text;
using iTextSharp.text.pdf;

using System.Data.SqlClient;
using System.Drawing.Imaging;
using iTextSharp.text.pdf.qrcode;
using CrystalDecisions.Windows.Forms;
using Zen.Barcode;
using Smart_Production_Pos.report.code_barre_P_Revent.pack;
using Smart_Production_Pos.report.NewFolder1;
using System.Web.UI.WebControls;
using Smart_Production_Pos.report;
using System.Windows.Forms.DataVisualization.Charting;


namespace Smart_Production_Pos.PL.Achat_revente
{
	public partial class frm_stock_produit_revente : Form
    {
        public SqlConnection sqlConnection;
        BL.BL_ACHAT_REVENT.BL_produit_reserve classPack_reserve = new BL.BL_ACHAT_REVENT.BL_produit_reserve();
        BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
        Sp_Logine classLogine = new Sp_Logine();
        BL.BL_ACHAT_REVENT.BL_PRODUIT classProduit = new BL.BL_ACHAT_REVENT.BL_PRODUIT();
        bl_produit_delete classproduit_delete = new bl_produit_delete();
		BL.BL_FILL_COMBOBOX_MATIER_PREMIER classFILL = new BL.BL_FILL_COMBOBOX_MATIER_PREMIER();
		public int id_user; 
        int facture_achat;
        private Dictionary<string, Color> invoiceColors = new Dictionary<string, Color>();
        private Color[] colors = { Color.LightBlue, Color.LightGreen, Color.LightSalmon, Color.LightYellow, Color.LightPink };
        private int colorIndex = 0;
        BL.BL_ACHAT_REVENT.BL_CLASS_BARCODE_RESERVER classReserver = new BL.BL_ACHAT_REVENT.BL_CLASS_BARCODE_RESERVER();
        public frm_stock_produit_revente()
		{
			InitializeComponent();
			this.dataGridView1.DataSource = classProduit.get_stock_produit_revenet(); 
			if (cmb_choose.SelectedIndex == 0);
			lbttl_rest.Text = classProduit.inventaire_Total().ToString();
            lb_ttl_Qt.Text = classProduit.inventaire_TotalQT_TTL().ToString();
            lb_ttl_vente.Text = classProduit.inventaire_TotalQT_VENTE().ToString();
            lblCount_produit.Text = classProduit.Count_Ttl_produit().ToString();
            this.dataGridView2.DataSource = classProduit.get_stock_pack();

            dataU.DataSource = classReserver.get_reserve_code_all();
            dataP.DataSource = classReserver.get_reserve_code_all_pack();

            flowLayoutPanel1.Visible = false;
        }

        private void show_and_hide_columns(System.Windows.Forms.CheckBox check, string name)
        {
            if (check.Checked == true)
            {
                dataGridView1.Columns[name].Visible = true;
            }
            else if (check.Checked == false)
            {
                dataGridView1.Columns[name].Visible = false;
            }
        }
        private void ColorizeRowsByInvoiceNumberU()
        {
            // Check if the DataGridView has any rows
            if (dataU.Rows.Count == 0)
                return;

            // Create a dictionary to store the unique nmr_bon values and their associated color
            Dictionary<string, Color> invoiceColors = new Dictionary<string, Color>();

            // Define an array of colors to cycle through
            Color[] colors = { Color.LightBlue, Color.LightGreen, Color.LightSalmon, Color.LightYellow, Color.LightPink };
            int colorIndex = 0;

            // Loop through the rows in the DataGridView
            foreach (DataGridViewRow row in dataU.Rows)
            {
                // Make sure the cell is not null or empty
                if (row.Cells["الباركود الاساسي"].Value != null)
                {
                    string nmrBon = row.Cells["الباركود الاساسي"].Value.ToString();

                    // If this nmr_bon doesn't have an assigned color yet, assign one
                    if (!invoiceColors.ContainsKey(nmrBon))
                    {
                        invoiceColors[nmrBon] = colors[colorIndex % colors.Length];
                        colorIndex++;
                    }

                    // Apply the color to the entire row
                    row.DefaultCellStyle.BackColor = invoiceColors[nmrBon];
                }
            }
        }

        private void اضافةكودباراحتياطيToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frm_code_barre_reserve frmCode = new frm_code_barre_reserve();
			frmCode.txt_officale_barCode.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
			frmCode.Show();
		}

		private void اضافةكودباراحتياطيللحزمةToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frm_pack_reserver_code_barre frmCode = new frm_pack_reserver_code_barre();
			frmCode.codeBarre_produit = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
			frmCode.Show();
		}
        private DataTable CreateBarcodeDataTable(string codeBarre)
        {
            // Create a DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("BarcodeImage", typeof(byte[]));

            // Generate the barcode image
            Code128BarcodeDraw brCode = BarcodeDrawFactory.Code128WithChecksum;
            System.Drawing.Image barcodeImage = brCode.Draw(codeBarre, 100);

            // Convert image to byte array
            byte[] barcodeImageBytes = ImageToByteArray(barcodeImage);

            // Add the image to the DataTable
            dt.Rows.Add(barcodeImageBytes);

            return dt;
        }

        private byte[] ImageToByteArray(System.Drawing.Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        private void طبعالكودبارToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
            report.code_barre_P_Revent.rp_Code_barre rpt = new report.code_barre_P_Revent.rp_Code_barre(); 
            string mode = Properties.Settings.Default.mode;
            if (mode == "SQL")
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                rpt.Refresh();
                rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[0].Value);
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
            else
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = true;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                rpt.Refresh();
                rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[0].Value);
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
            try
            {

                DataTable dt = new DataTable();
                dt = classProduit.GET_INFORATION_FOR_AFFICHER_PRODUIT_REVENT(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                object codeBarre = dt.Rows[0][0];
                object designation = dt.Rows[0][1];
                object marque = dt.Rows[0][5];
                object categories = dt.Rows[0][3];
                object reference = dt.Rows[0][2];
                object unite = dt.Rows[0][2];
                object stock = dt.Rows[0][4];
                object PHOTO = dt.Rows[0][10];
                object QT_TTL = dt.Rows[0][14];
                object QT_REST = dt.Rows[0][21];
                object PriceVente = dt.Rows[0][15];
                object Rest_by_Pack = dt.Rows[0][25];


                Byte[] image_array = (byte[])dt.Rows[0][24];
                using (MemoryStream ms = new MemoryStream(image_array))
                {
                    pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                }
                string barCode = codeBarre.ToString();
                Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                pictureBox2.Image = brCode.Draw(barCode, 100);

                txt_codeBare.Text = codeBarre.ToString();
                txt_designation.Text = designation.ToString();
                txt_reference.Text = reference.ToString();
                txtMarque.Text = marque.ToString();
                txt_stock.Text = stock.ToString();
                txtQT_TTL.Text = QT_TTL.ToString();
                txtQT_REST.Text = QT_REST.ToString();
                txt_resT_pack.Text = Rest_by_Pack.ToString();
                txt_vente_1.Text = PriceVente.ToString();

                using (MemoryStream mss = new MemoryStream())
                {
                    System.Drawing.Image barcodeImage = brCode.Draw(barCode, 100);
                    barcodeImage.Save(mss, ImageFormat.Png); // Save the image in PNG format

                    // Convert MemoryStream to byte array
                    byte[] byteImage = mss.ToArray();

                    // Call the method to add the picture
                    classProduit.add_picture(txt_codeBare.Text, byteImage);
                }
            }
            catch
            {

            }

        }

		private void panel4_Paint(object sender, PaintEventArgs e)
		{

		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{ 
			dataGridView1.DataSource  = classProduit.search_code_barre_produit_revent(kryptonTextBox1.Text);
		}

		private void cmb_choose_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmb_choose.SelectedIndex == 0)
			{
				cmb_matier_search.DataSource = classFILL.fill_produit_revent();
				cmb_matier_search.DisplayMember = "اسم المنتج";
				cmb_matier_search.ValueMember = "رمز المنتج";
			}
			else if (cmb_choose.SelectedIndex == 1)
			{
				cmb_matier_search.DataSource = classFILL.fill_produit_revent();
				cmb_matier_search.DisplayMember = "رقم المرجع";
				cmb_matier_search.ValueMember = "رمز المنتج";
			}
			else if (cmb_choose.SelectedIndex == 2)
			{
                cmb_matier_search.DataSource = clasCombobox.get_combo_Categorie();
                cmb_matier_search.DisplayMember = "CATEGORIES";
                cmb_matier_search.ValueMember = "ID"; 
			}
			else if (cmb_choose.SelectedIndex == 3)
			{
                cmb_matier_search.DataSource = clasCombobox.get_combo_Iunite();
                cmb_matier_search.DisplayMember = "UNITE";
                cmb_matier_search.ValueMember = "ID";
            }
			else if (cmb_choose.SelectedIndex == 4)
			{
                cmb_matier_search.DataSource = clasCombobox.get_combo_Marque();
                cmb_matier_search.DisplayMember = "Marque";
                cmb_matier_search.ValueMember = "ID";
            }
			else if (cmb_choose.SelectedIndex == 5)
			{
                cmb_matier_search.DataSource = clasCombobox.get_combo_stock();
                cmb_matier_search.DisplayMember = "STOCKE";
                cmb_matier_search.ValueMember = "ID";
            }
            else if (cmb_choose.SelectedIndex == 6)
            {
                cmb_matier_search.DataSource = clasCombobox.get_combo_taille();
                cmb_matier_search.DisplayMember = "TAILLE";
                cmb_matier_search.ValueMember = "ID";
            }
            else if (cmb_choose.SelectedIndex == 7)
            {
                cmb_matier_search.DataSource = clasCombobox.get_combo_color();
                cmb_matier_search.DisplayMember = "COLOR";
                cmb_matier_search.ValueMember = "ID";
            }
        }

		private void button10_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classProduit.search_produit_revente(cmb_matier_search.Text);
			dataGridView1.DataSource = dt;
		}

		private void button4_Click(object sender, EventArgs e)
		{ 
			
		}

		private void طبعالكودبارالثمنToolStripMenuItem_Click(object sender, EventArgs e)
		{
			report.code_barre_P_Revent.rpt_Code_barreprice rpt = new report.code_barre_P_Revent.rpt_Code_barreprice();
			//#region re
			string mode = Properties.Settings.Default.mode;
			if (mode == "SQL")
			{
				rpt.DataSourceConnections[0].IntegratedSecurity = false;
				rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

				rpt.Refresh();
				rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[0].Value);
                report.viewer_report viewer = new report.viewer_report();
				viewer.crystalReportViewer1.ReportSource = rpt;
				viewer.ShowDialog();
			}
			else
			{
				rpt.DataSourceConnections[0].IntegratedSecurity = true;
				rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

				rpt.Refresh();
				rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[0].Value);
                report.viewer_report viewer = new report.viewer_report();
				viewer.crystalReportViewer1.ReportSource = rpt;
				viewer.ShowDialog();
			}
		}

		private void طبعالكودبارالثمنالاسمToolStripMenuItem_Click(object sender, EventArgs e)
		{
			report.code_barre_P_Revent.code_price_designation rpt = new report.code_barre_P_Revent.code_price_designation();
			//#region re
			string mode = Properties.Settings.Default.mode;
			if (mode == "SQL")
			{
				rpt.DataSourceConnections[0].IntegratedSecurity = false;
				rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

				rpt.Refresh();
				rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[0].Value);
                report.viewer_report viewer = new report.viewer_report();
				viewer.crystalReportViewer1.ReportSource = rpt;
				viewer.ShowDialog();
			}
			else
			{
				rpt.DataSourceConnections[0].IntegratedSecurity = true;
				rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

				rpt.Refresh();
				rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[0].Value);
                report.viewer_report viewer = new report.viewer_report();
				viewer.crystalReportViewer1.ReportSource = rpt;
				viewer.ShowDialog();
			}
		}

		private void طبعكودباراسمToolStripMenuItem_Click(object sender, EventArgs e)
		{
			report.code_barre_P_Revent.code_Barre_designation rpt = new report.code_barre_P_Revent.code_Barre_designation();
			//#region re
			string mode = Properties.Settings.Default.mode;
			if (mode == "SQL")
			{
				rpt.DataSourceConnections[0].IntegratedSecurity = false;
				rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

				rpt.Refresh();
				rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[0].Value);

                report.viewer_report viewer = new report.viewer_report();
				viewer.crystalReportViewer1.ReportSource = rpt;
				viewer.ShowDialog();
			}
			else
			{
				rpt.DataSourceConnections[0].IntegratedSecurity = true;
				rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

				rpt.Refresh();
				rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[0].Value);
                report.viewer_report viewer = new report.viewer_report();
				viewer.crystalReportViewer1.ReportSource = rpt;
				viewer.ShowDialog();
			}
		}

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
            // Assuming "الكمية المتبقية" is the name of the column
            if (dataGridView1.Columns[e.ColumnIndex].Name == "الكمية المتبقية" || dataGridView1.Columns[e.ColumnIndex].Name == "كمية التنبيه")
            {
                float quantiteRest;
                float quantiteAlert;

                if (float.TryParse(dataGridView1.Rows[e.RowIndex].Cells["الكمية المتبقية"].Value?.ToString(), out quantiteRest) &&
                    float.TryParse(dataGridView1.Rows[e.RowIndex].Cells["كمية التنبيه"].Value?.ToString(), out quantiteAlert))
                {
                    if (quantiteRest <= quantiteAlert)
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "سعر البيع الأول")
            {
                e.CellStyle.BackColor = Color.LightGreen; // اختر لون قريب
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "سعر البيع الثاني")
            {
                e.CellStyle.BackColor = Color.LightBlue; // اختر لون قريب
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "سعر البيع الأدنى")
            {
                e.CellStyle.BackColor = Color.LightCyan; // اختر لون قريب
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "الكمية المتبقية")
            {
                e.CellStyle.BackColor = Color.Yellow; // اختر لون قريب
            }


        } 
		private void frm_stock_produit_revente_Load(object sender, EventArgs e)
		{
            cmb_choose.SelectedIndex = 0;
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
            ColorizeRowsByInvoiceNumberU();
            show_and_hide_columns(check_reference, "رقم المرجع");
            show_and_hide_columns(check_categorie, "الصنف");
            show_and_hide_columns(check_stock, "المخزن");
            show_and_hide_columns(check_marque, "العلامة");
            show_and_hide_columns(check_taille, "القياس");
            show_and_hide_columns(check_clr, "اللون");
            show_and_hide_columns(check_fav, "المفضلة");
            show_and_hide_columns(check_unite, "الوحدة"); 
            show_and_hide_columns(checkBox1, "تاريخ انتهاء الصلاحية");
        }

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			frm_information_change changeInfo = new frm_information_change();
			DataTable dtProduit = new DataTable();
			dtProduit = classProduit.get_stock_produit_revenet_for_edit(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
			object codeBarre = dtProduit.Rows[0][0];
			object designation = dtProduit.Rows[0][1];
			object reference = dtProduit.Rows[0][2];
			object categories = dtProduit.Rows[0][3];
			object stock = dtProduit.Rows[0][4];
			object marque = dtProduit.Rows[0][5];
			object unite = dtProduit.Rows[0][6]; ;
			object taille = dtProduit.Rows[0][7];
			object color = dtProduit.Rows[0][8];
			object fav = dtProduit.Rows[0][9];
			object dateExp = dtProduit.Rows[0][10];
			object Prix1 = dtProduit.Rows[0][15];
			object Prix2 = dtProduit.Rows[0][16];
			object Prix3 = dtProduit.Rows[0][17];
            object prixAchatTTC = dtProduit.Rows[0][12];
            object prixAchatHT = dtProduit.Rows[0][11];
            object TVA = dtProduit.Rows[0][13];
            object QT_alert = dtProduit.Rows[0][25];
            object QT_ihtiyaj = dtProduit.Rows[0][26]; 
			Byte[] image_array = (byte[])dtProduit.Rows[0][24]; 
            using (MemoryStream ms = new MemoryStream(image_array))
            {
                changeInfo.pictureBox1.Image = System.Drawing.Image.FromStream(ms);
            } 
            changeInfo.txtBarcode.Text = codeBarre.ToString();
			changeInfo.txt_designation.Text = designation.ToString();
			changeInfo.txt_reference.Text = reference.ToString();
			changeInfo.cmb_categories.Text = categories.ToString();
			changeInfo.cmb_stocke.Text = stock.ToString();
			changeInfo.cmb_marque.Text = marque.ToString();
			changeInfo.cmb_unite.Text = unite.ToString();
			changeInfo.cmb_taille.Text =  taille.ToString();
			changeInfo.cmb_color.Text =  color.ToString(); 
			if (fav.ToString() != "")
			{
				changeInfo.cmb_favoire.Enabled = true;
				changeInfo.cmb_favoire.Text = fav.ToString();
            }
			else
			{
                changeInfo.cmb_favoire.Enabled = false ;
            }
			changeInfo.date_expiration.Text = dateExp .ToString();
			changeInfo.txt_vente_1.Text =  Prix1.ToString();
			changeInfo.txt_vente_2.Text = Prix2.ToString();
			changeInfo.txt_vente_min.Text = Prix3.ToString(); 
            changeInfo.txt_achat_ht.Text = prixAchatHT.ToString();
            changeInfo.txt_achat_ttc.Text = prixAchatTTC.ToString();
            changeInfo.txt_tva.Text = TVA.ToString();
            changeInfo.TXTqT_ALERT.Text = QT_alert.ToString();
            changeInfo.txtihtiyadj.Text = QT_ihtiyaj.ToString(); 
            changeInfo.ShowDialog();
		}

		private void buttoxn4_Click(object sender, EventArgs e)
		{
			
		}

        private void buxxttoxn4import_Click(object sender, EventArgs e)
        {
			
        }

        private void buttxxxoxn4_Click(object sender, EventArgs e)
        {
        
        }

		private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
		{

			//if (dataGridView1.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.ColumnHeader ||
			//	dataGridView1.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.TopLeftHeader)
			//{
			//	ContextMenu menu = new ContextMenu();

			//	//add item to the menu
			//	foreach (DataGridViewColumn column in dataGridView1.Columns)
			//	{
			//		MenuItem item = new MenuItem();
			//		item.Text = column.HeaderText;
			//		item.Checked = column.Visible;

			//		//now let add the event if the item was cheked
			//		item.Click += (obj, ea) =>
			//		{
			//			column.Visible = !item.Checked;

			//			//update the check
			//			item.Checked = column.Visible;

			//			//show the selection item 
			//			menu.Show(dataGridView1, e.Location);
			//		};
			//		menu.MenuItems.Add(item);
			//	}
			//	//show the menu 
			//	menu.Show(dataGridView1, e.Location);

			//}
		}

        private void buttonx10_Click(object sender, EventArgs e)
        {
			this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
			if (panel1.Visible == true)
			{
				panel1.Visible = false;

            }
            else if (panel1.Visible == false)
			{
				panel1.Visible = true;

            }
        }

        private void استيرادمنExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_import_by_excel import = new frm_import_by_excel(); 
            import.ShowDialog();
        }

        private void تحديثToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = classProduit.get_stock_produit_revenet(); 
			if (cmb_choose.SelectedIndex == 0) ; 
            lbttl_rest.Text = classProduit.inventaire_Total().ToString();
            lb_ttl_Qt.Text = classProduit.inventaire_TotalQT_TTL().ToString();
            lb_ttl_vente.Text = classProduit.inventaire_TotalQT_VENTE().ToString();
            lblCount_produit.Text = classProduit.Count_Ttl_produit().ToString();
        }

        private void استخراجالىExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.ApplicationClass MExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                MExcel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    MExcel.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        MExcel.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                MExcel.Columns.AutoFit();
                MExcel.Rows.AutoFit();
                MExcel.Columns.Font.Size = 12;
                MExcel.Visible = true;
            }
            else
            {
                MessageBox.Show("No records found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void المخصوصةحسبالصنفToolStripMenuItem_Click(object sender, EventArgs e)
        {


            DataTable dt = new DataTable();
            dt = classProduit.search_produit_revente_repture_stock(cmb_matier_search.Text);
            dataGridView1.DataSource = dt;
        }

        private void ادخالسلعةبدونفاتورةToolStripMenuItem_Click(object sender, EventArgs e)
        {
			frm_Add_stock_sans_facture addstock = new frm_Add_stock_sans_facture();
			addstock.formstck = this;
			addstock.ShowDialog();
        }

        private void lbttl_Click(object sender, EventArgs e)
        {

        }

		private void اضافةحزنToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DataTable dtt = new DataTable();
			dtt = classPack_reserve.get_number_pack(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
			if (dtt.Rows.Count > 0)
			{
				MessageBox.Show("لايمكن اضافة حزمة لمنتج لديه حزمة");
			}
			else
			{
                frm_add_pack_for_product add_pack = new frm_add_pack_for_product();
                add_pack.txtBarcode.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
				add_pack.txt_designation_pack.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString()+ " /Pack";
                add_pack.ShowDialog(); 
            }
		}

        private void تفاصيلالشراءToolStripMenuItem_Click(object sender, EventArgs e)
        {
			frm_historique_achat_produitr historique = new frm_historique_achat_produitr();
			historique.id_produit = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            historique.txt_designation.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            historique.ShowDialog();

        }

        private void تفاصيلالبيعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_historique_vennte historique = new frm_historique_vennte();
            historique.id_produit = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            historique.txt_designation.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            historique.ShowDialog();
        }

        private void إضافةكميةضائعةToolStripMenuItem_Click(object sender, EventArgs e)
        {
			frm_add_quantite_dechet add_dechet = new frm_add_quantite_dechet();
			add_dechet.id_user = id_user; 
			add_dechet.txtCode_barre.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString(); 
			add_dechet.txtDesignation.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
			add_dechet.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PL.Achat_revente.Frm_Achat frmachat = new PL.Achat_revente.Frm_Achat();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][16];
                facture_achat = Convert.ToInt32(stock);

            }
            if (facture_achat == 1)
            {
                frmachat.ShowDialog();


            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void سجلالضياعToolStripMenuItem_Click(object sender, EventArgs e)
        {
			frm_Historique_dechet historique = new frm_Historique_dechet();
            historique.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_Add_stock_sans_facture addstock = new frm_Add_stock_sans_facture();
            addstock.formstck = this;
            addstock.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = classProduit.search_produit_revente(cmb_matier_search.Text);
            dataGridView1.DataSource = dt;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = classProduit.search_produit_revente(cmb_matier_search.Text);
            dataGridView1.DataSource = dt;
        }

        private void kryptonTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = classProduit.search_produit_revente(kryptonTextBox1.Text);
            dataGridView1.DataSource = dt; 
        }

        private void cmb_choose_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmb_choose.SelectedIndex == 0)
            {
                cmb_matier_search.DataSource = classFILL.fill_produit_revent();
                cmb_matier_search.DisplayMember = "اسم المنتج";
                cmb_matier_search.ValueMember = "رمز المنتج";
            }
            else if (cmb_choose.SelectedIndex == 1)
            {
                cmb_matier_search.DataSource = classFILL.fill_produit_revent();
                cmb_matier_search.DisplayMember = "رقم المرجع";
                cmb_matier_search.ValueMember = "رمز المنتج";
            }
            else if (cmb_choose.SelectedIndex == 2)
            {
                cmb_matier_search.DataSource = classFILL.fill_produit_revent();
                cmb_matier_search.DisplayMember = "الصنف";
                cmb_matier_search.ValueMember = "رمز المنتج";
            }
            else if (cmb_choose.SelectedIndex == 3)
            {
                cmb_matier_search.DataSource = classFILL.fill_produit_revent();
                cmb_matier_search.DisplayMember = "الوحدة";
                cmb_matier_search.ValueMember = "رمز المنتج";
            }
            else if (cmb_choose.SelectedIndex == 4)
            {
                cmb_matier_search.DataSource = classFILL.fill_produit_revent();
                cmb_matier_search.DisplayMember = "العلامة";
                cmb_matier_search.ValueMember = "رمز المنتج";
            }
            else if (cmb_choose.SelectedIndex == 5)
            {
                cmb_matier_search.DataSource = classFILL.fill_produit_revent();
                cmb_matier_search.DisplayMember = "المخزن";
                cmb_matier_search.ValueMember = "رمز المنتج";
            }
        }

        private void اضافةكميةجديدةToolStripMenuItem_Click(object sender, EventArgs e)
        {
			frm_adD_QT_produit_Existe add_QT = new frm_adD_QT_produit_Existe();
			add_QT.txtBarcode.Text = this.dataGridView1.CurrentRow.Cells["رمز المنتج"].Value.ToString();
            add_QT.txtDesignation.Text = this.dataGridView1.CurrentRow.Cells["اسم المنتج"].Value.ToString();
            add_QT.TXT_REFERENCE.Text = this.dataGridView1.CurrentRow.Cells["رقم المرجع"].Value.ToString();
            add_QT.txt_qt_rest.Text = this.dataGridView1.CurrentRow.Cells["الكمية المتبقية"].Value.ToString();
			add_QT.frmStock = this; 
            add_QT.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frm_Add_stock_sans_facture addstock = new frm_Add_stock_sans_facture();
            addstock.formstck = this;
            addstock.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            frm_import_by_excel import = new frm_import_by_excel();
            import.ShowDialog();
        }
        private void SaveImageToFile(System.Drawing.Image image, string filePath)
        {
            image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
        }
        private void butprint10_Click_1(object sender, EventArgs e)
        {
           
        }
        

        private void تفاصيلالبيعحسبالمدةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_historique_detailles historique_Detaille = new Frm_historique_detailles();
            historique_Detaille.code_barre = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            historique_Detaille.txt_name.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            historique_Detaille.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frm_statistique_de_vente state_vente = new frm_statistique_de_vente();
            state_vente.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frm_calcule_benifice benifce = new frm_calcule_benifice();
            benifce.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            report.code_barre_P_Revent.rp_Code_barre rpt = new report.code_barre_P_Revent.rp_Code_barre();
            string mode = Properties.Settings.Default.mode;
            if (mode == "SQL")
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                rpt.Refresh();
                rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[0].Value);
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
            else
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = true;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                rpt.Refresh();
                rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[0].Value);
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            report.code_barre_P_Revent.rpt_Code_barreprice rpt = new report.code_barre_P_Revent.rpt_Code_barreprice();
            //#region re
            string mode = Properties.Settings.Default.mode;
            if (mode == "SQL")
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                rpt.Refresh();
                rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[0].Value);
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
            else
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = true;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                rpt.Refresh();
                rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[0].Value);
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {


            if (check_4040.Checked == true)
            {
                report.code_barre_P_Revent.codebarre40_40 rpt = new report.code_barre_P_Revent.codebarre40_40();
                //#region re
                string mode = Properties.Settings.Default.mode;
                if (mode == "Local")
                {

                }
                else
                {
                    if (mode == "SQL")
                    {
                        rpt.DataSourceConnections[0].IntegratedSecurity = false;
                        rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                        rpt.Refresh();
                        rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                        rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[0].Value);
                        report.viewer_report viewer = new report.viewer_report();
                        viewer.crystalReportViewer1.ReportSource = rpt;
                        viewer.ShowDialog();
                    }
                    else
                    {
                        rpt.DataSourceConnections[0].IntegratedSecurity = true;
                        rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                        rpt.Refresh();
                        rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                        rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[0].Value);
                        report.viewer_report viewer = new report.viewer_report();
                        viewer.crystalReportViewer1.ReportSource = rpt;
                        viewer.ShowDialog();
                    }
                }
            }
            else if (chech20_40.Checked == true)
            {
                report.code_barre_P_Revent.code_price_designation rpt = new report.code_barre_P_Revent.code_price_designation();
                //#region re
                string mode = Properties.Settings.Default.mode;
                if (mode == "Local")
                {
                     
                }
                else
                {
                    if (mode == "SQL")
                    {
                        rpt.DataSourceConnections[0].IntegratedSecurity = false;
                        rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                        rpt.Refresh();
                        rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                        rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[0].Value);
                        report.viewer_report viewer = new report.viewer_report();
                        viewer.crystalReportViewer1.ReportSource = rpt;
                        viewer.ShowDialog();
                    }
                    else
                    {
                        rpt.DataSourceConnections[0].IntegratedSecurity = true;
                        rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                        rpt.Refresh();
                        rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                        rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[0].Value);
                        report.viewer_report viewer = new report.viewer_report();
                        viewer.crystalReportViewer1.ReportSource = rpt;
                        viewer.ShowDialog();
                    }
                }
            }

            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
            if(check_4040.Checked==true)
            {
                report.code_barre_P_Revent.codebarre_40_40_mdl2 rpt = new report.code_barre_P_Revent.codebarre_40_40_mdl2();
                //#region re
                string mode = Properties.Settings.Default.mode;
                if (mode == "SQL")
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = false;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                    rpt.Refresh();
                    rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                    rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[0].Value);

                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
                else
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = true;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                    rpt.Refresh();
                    rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                    rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[0].Value);
                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
            }
            else if (chech20_40.Checked==true)
            {
                report.code_barre_P_Revent.code_Barre_designation rpt = new report.code_barre_P_Revent.code_Barre_designation();
                //#region re
                string mode = Properties.Settings.Default.mode;
                if (mode == "SQL")
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = false;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                    rpt.Refresh();
                    rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                    rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[0].Value);

                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
                else
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = true;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                    rpt.Refresh();
                    rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                    rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[0].Value);
                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
            }
            
        }

        private void buttonX13_Click(object sender, EventArgs e)
        {
            frm_code_barre_reserve frmCode = new frm_code_barre_reserve();
            frmCode.txt_officale_barCode.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frmCode.Show();
        }

        private void buXXtton13_Click(object sender, EventArgs e)
        {
            frm_pack_reserver_code_barre frmCode = new frm_pack_reserver_code_barre();
            frmCode.codeBarre_produit = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frmCode.Show();
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtt = new DataTable();
                dtt = classPack_reserve.get_number_pack(this.dataGridView1.CurrentRow.Cells[0].Value.ToString()); 
                if (dtt.Rows.Count > 0)
                {
                    Object CodeBarrePack = dtt.Rows[0][0];

                    //delet reserve pack code barre 
                    classproduit_delete.delet_reserve_pack_code_barre(CodeBarrePack.ToString());

                    //delete pack link to produit
                    classproduit_delete.delete_pack_link_to_produit(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());

                }

                //delete reserve produit code barre  
                classproduit_delete.delete_reserve_produit_code_barre(this.dataGridView1.CurrentRow.Cells[0].Value.ToString()); 
                
                //delete produit
                classproduit_delete.delete_produit(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("تم حذف المنتج بنجاح");
            }
            catch
            {
                MessageBox.Show("لايمكن حذف منتج موجود في قائمة البيع");
            }
        }

        private void kryptonTextBox3_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = classProduit.search_pack_prevent_by_code_Barre_U(kryptonTextBox1.Text);
        }

        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = classProduit.search_pack_prevent_by_code_Barre_Pack(kryptonTextBox2.Text);
        }

        private void طباعةالكودبارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            report.code_barre_P_Revent.pack.code_Barre_pack rpt = new report.code_barre_P_Revent.pack.code_Barre_pack();
            string mode = Properties.Settings.Default.mode;
            if (mode == "SQL")
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                rpt.Refresh();
                rpt.SetParameterValue("@code_barre", this.dataGridView2.CurrentRow.Cells[0].Value);
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
            else
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = true;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                rpt.Refresh();
                rpt.SetParameterValue("@code_barre", this.dataGridView2.CurrentRow.Cells[0].Value);
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
        }

        private void تعديلمعلوماتالحزمةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PLADD.Achat_revente.frm_edit_Pack_information pack_info = new PLADD.Achat_revente.frm_edit_Pack_information();
            DataTable dtProduit = new DataTable();
            dtProduit = classProduit.get_info_Pack_edit(this.dataGridView2.CurrentRow.Cells[0].Value.ToString());
            object codeBarre = dtProduit.Rows[0][0];
            object designation = dtProduit.Rows[0][1];
            object fav = dtProduit.Rows[0][6];
            object Prix1 = dtProduit.Rows[0][4];
            Byte[] image_array = (byte[])dtProduit.Rows[0][5];

            pack_info.txtBarcode.Text = codeBarre.ToString();
            pack_info.txt_vente_1.Text = Prix1.ToString();
            if (fav.ToString() != "")
            {
                pack_info.cmb_favoire.Enabled = true;
                pack_info.cmb_favoire.Text = fav.ToString();
            }
            else
            {
                pack_info.cmb_favoire.Enabled = false;
            }
            pack_info.cmb_favoire.Text = fav.ToString();
            pack_info.txt_designation.Text = designation.ToString();
            using (MemoryStream ms = new MemoryStream(image_array))
            {
                pack_info.pictureBox2.Image = System.Drawing.Image.FromStream(ms);
            }
            //pack_info.formStock = this;
            pack_info.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                dataU.DataSource = classReserver.get_reserve_code_all();
                dataP.DataSource = classReserver.get_reserve_code_all_pack();
            }
        }

        private void dataU_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow row = dataU.Rows[e.RowIndex];

            // Make sure the cell is not null or empty
            if (row.Cells["الباركود الاساسي"].Value != null)
            {
                string nmrBon = row.Cells["الباركود الاساسي"].Value.ToString();

                // If this nmr_bon doesn't have an assigned color yet, assign one
                if (!invoiceColors.ContainsKey(nmrBon))
                {
                    invoiceColors[nmrBon] = colors[colorIndex % colors.Length];
                    colorIndex++;
                }

                // Apply the color to the entire row
                row.DefaultCellStyle.BackColor = invoiceColors[nmrBon];
            }
        }

        private void dataP_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow row = dataP.Rows[e.RowIndex];

            // Make sure the cell is not null or empty
            if (row.Cells["الباركود الاساسي"].Value != null)
            {
                string nmrBon = row.Cells["الباركود الاساسي"].Value.ToString();

                // If this nmr_bon doesn't have an assigned color yet, assign one
                if (!invoiceColors.ContainsKey(nmrBon))
                {
                    invoiceColors[nmrBon] = colors[colorIndex % colors.Length];
                    colorIndex++;
                }

                // Apply the color to the entire row
                row.DefaultCellStyle.BackColor = invoiceColors[nmrBon];
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataTable dt_u = new DataTable();
                dt_u = classReserver.search_get_reserve_code_all(textBox1.Text);
                DataTable dt_p = new DataTable();
                dt_p = classReserver.search_get_reserve_code_all_pack(textBox1.Text);
                dataU.DataSource = dt_u;
                dataP.DataSource = dt_p;
                if (textBox1.Text == "")
                {
                    dataU.DataSource = classReserver.get_reserve_code_all();
                    dataP.DataSource = classReserver.get_reserve_code_all_pack();
                }
                //if (dt_u.Rows.Count == 0 && dt_p.Rows.Count == 0 && textBox1.Text!="")
                //{
                //    frm_barcodeempty barccodeemty = new frm_barcodeempty();
                //    barccodeemty.Show();
                //}  

            }
        }

        private void check_reference_CheckedChanged(object sender, EventArgs e)
        {
            show_and_hide_columns(check_reference, "رقم المرجع");
        }

        private void check_categorie_CheckedChanged(object sender, EventArgs e)
        {

            show_and_hide_columns(check_categorie, "الصنف");
        }

        private void check_stock_CheckedChanged(object sender, EventArgs e)
        {

            show_and_hide_columns(check_stock, "المخزن");
        }

        private void check_marque_CheckedChanged(object sender, EventArgs e)
        {

            show_and_hide_columns(check_marque, "العلامة");
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void check_unite_CheckedChanged(object sender, EventArgs e)
        { 
            show_and_hide_columns(check_unite, "الوحدة");
        }

        private void check_taille_CheckedChanged(object sender, EventArgs e)
        {

            show_and_hide_columns(check_taille, "القياس");
        }

        private void check_clr_CheckedChanged(object sender, EventArgs e)
        {

            show_and_hide_columns(check_clr, "اللون");
        }

        private void check_fav_CheckedChanged(object sender, EventArgs e)
        {

            show_and_hide_columns(check_fav, "المفضلة");
        }

        private void kryptonDropButton1_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Visible == true)
            {
                flowLayoutPanel1.Visible = false;
            }
            else if (flowLayoutPanel1.Visible == false)
            {
                flowLayoutPanel1.Visible = true;
            }
        }

        private void PRIX_DESIGN(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                report.code_barre_P_Revent.price_designation rpt = new report.code_barre_P_Revent.price_designation();
                string mode = Properties.Settings.Default.mode;
                if (mode == "SQL")
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = false;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                    rpt.Refresh();
                    rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
                else
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = true;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                    rpt.Refresh();
                    rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
            }
            else if (radioButton1.Checked == true)
            {
                report.code_barre_P_Revent.price_design_80 rpt = new report.code_barre_P_Revent.price_design_80();
                string mode = Properties.Settings.Default.mode;
                if (mode == "SQL")
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = false;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                    rpt.Refresh();
                    rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
                else
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = true;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                    rpt.Refresh();
                    rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value);
                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                DataTable dt = new DataTable();
                dt = classProduit.Search_stock_Null();
                dataGridView1.DataSource = dt;
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                DataTable dt = new DataTable();
                dt = classProduit.Search_stock_Alert();
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                DataTable dt = new DataTable();
                dt = classProduit.Search_stock_negative();
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                DataTable dt = new DataTable();
                dt = classProduit.Search_stock_exagere();
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                DataTable dt = new DataTable();
                dt = classProduit.Search_stock_Controle_prix_Détail();
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                DataTable dt = new DataTable();
                dt = classProduit.Search_stock_Controle_prix_Gros();
                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                DataTable dt = new DataTable();
                dt = classProduit.Search_stock_Controle_prix_min();
                dataGridView1.DataSource = dt;
            }
        }

        private void kryptonGroup1_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buctton9_Click(object sender, EventArgs e)
        {
            frm_Inventaire_detaille form = new frm_Inventaire_detaille();
            form.Show();
        }

        private void buttoXn13_Click(object sender, EventArgs e)
        {
            report.code_barre_P_Revent.rpt_juste_name rpt = new report.code_barre_P_Revent.rpt_juste_name();
            //#region re
            string mode = Properties.Settings.Default.mode;
            if (mode == "Local")
            {

            }
            else
            {
                if (mode == "SQL")
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = false;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                    rpt.Refresh();
                    rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value); 
                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
                else
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = true;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                    rpt.Refresh();
                    rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value); 
                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string codebr = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
            label9.Text = codebr;
            Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBox7.Image = brCode.Draw(codebr, 100);
            using (MemoryStream mss = new MemoryStream())
            {
                System.Drawing.Image barcodeImage = brCode.Draw(codebr, 100);
                barcodeImage.Save(mss, ImageFormat.Png); // Save the image in PNG format

                // Convert MemoryStream to byte array
                byte[] byteImage = mss.ToArray();

                // Call the method to add the picture
                classProduit.update_code_baree_pack(codebr, byteImage);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            report.code_barre_P_Revent.pack.code_Barre_pack rpt = new report.code_barre_P_Revent.pack.code_Barre_pack();
            string mode = Properties.Settings.Default.mode;
            if (mode == "SQL")
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                rpt.Refresh();
                rpt.SetParameterValue("@code_barre", this.dataGridView2.CurrentRow.Cells[0].Value);
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
            else
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = true;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                rpt.Refresh();
                rpt.SetParameterValue("@code_barre", this.dataGridView2.CurrentRow.Cells[0].Value);
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            show_and_hide_columns(checkBox1, "تاريخ انتهاء الصلاحية");
        }
    }
}