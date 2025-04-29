using Smart_Production_Pos.TAB_CONTROL;
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

namespace Smart_Production_Pos.PL.Achats
{
	public partial class frm_stock_matier_premier : Form
	{
		BL.BL_Achats.BL_Produit classSTock_matier_premier = new BL.BL_Achats.BL_Produit();
		BL.BL_FILL_COMBOBOX_MATIER_PREMIER classFILL = new BL.BL_FILL_COMBOBOX_MATIER_PREMIER();
		public frm_stock_matier_premier()
		{
			InitializeComponent();
			this.dataGridView1.DataSource= classSTock_matier_premier.get_tb_stock_matier_premier();

			 
			cmb_matier_search.DataSource = classFILL.fill_combo_matier_premier();
			cmb_matier_search.DisplayMember = "DESIGNATION";
			cmb_matier_search.ValueMember = "CODEBARRE";
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			detailes.frm_details_product_M_P detailes = new detailes.frm_details_product_M_P();
			detailes.id_produit_txt.Text =  this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
			detailes.id_produit = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
			detailes.Show();
			this.Close();
		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void kryptonGroupBox1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classSTock_matier_premier.get_detailles_produit(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
			object codeBarre = dt.Rows[0][0];
			object designation = dt.Rows[0][1];
			object marque = dt.Rows[0][5];
			object categories = dt.Rows[0][3];
			object reference = dt.Rows[0][15];
			object unite = dt.Rows[0][2];
			object stock = dt.Rows[0][4];
			object PHOTO = dt.Rows[0][10];
			object QT_TTL = dt.Rows[0][6];
			object QT_REST = dt.Rows[0][7];


			Byte[] image_array = (byte[])dt.Rows[0][10];
			using (MemoryStream ms = new MemoryStream(image_array))
			{
				pictureBox1.Image = Image.FromStream(ms);
			}

			txt_codeBare.Text = codeBarre.ToString();
			txt_designation.Text = designation.ToString();
			txt_reference.Text = reference.ToString();
			txtMarque.Text = marque.ToString();
			txt_stock.Text = stock.ToString();
			txtQT_TTL.Text = QT_TTL.ToString();
			txtQT_REST.Text = QT_REST.ToString();
		}

		private void txt_codeBare_TextChanged(object sender, EventArgs e)
		{
			long randomNum = long.Parse(txt_codeBare.Text);
			string barCode = txt_codeBare.Text;
			try
			{
				Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
				pictureBox2.Image = brCode.Draw(barCode, 100);
				txt_codeBare.Text = barCode;

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void frm_stock_matier_premier_DoubleClick(object sender, EventArgs e)
		{
		}

		private void button6_Click(object sender, EventArgs e)
		{
			report.codeBArre.rpt_code_barre_price rpt = new report.codeBArre.rpt_code_barre_price();
			//#region re
			string mode = Properties.Settings.Default.mode;
			if (mode == "SQL")
			{
				rpt.DataSourceConnections[0].IntegratedSecurity = false;
				rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

				rpt.Refresh();
				rpt.SetParameterValue("@codeBarre", this.dataGridView1.CurrentRow.Cells[0].Value);
				report.viewer_report viewer = new report.viewer_report();
				viewer.crystalReportViewer1.ReportSource = rpt;
				viewer.ShowDialog();
			}
			else
			{
				rpt.DataSourceConnections[0].IntegratedSecurity = true;
				rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

				rpt.Refresh();
				rpt.SetParameterValue("@codeBarre", this.dataGridView1.CurrentRow.Cells[0].Value);
				report.viewer_report viewer = new report.viewer_report();
				viewer.crystalReportViewer1.ReportSource = rpt;
				viewer.ShowDialog();
			}

		}

		private void button4_Click(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = classSTock_matier_premier.get_tb_stock_matier_premier();
		}

		 
		private void cmb_choose_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmb_choose.SelectedIndex == 0)
			{
				cmb_matier_search.DataSource = classFILL.fill_combo_matier_premier();
				cmb_matier_search.DisplayMember = "DESIGNATION";
				cmb_matier_search.ValueMember = "CODEBARRE";
			}
			else if (cmb_choose.SelectedIndex == 1)
			{
				cmb_matier_search.DataSource = classFILL.fill_combo_matier_premier();
				cmb_matier_search.DisplayMember = "REFERENCE";
				cmb_matier_search.ValueMember = "CODEBARRE";
			}
			else if (cmb_choose.SelectedIndex ==2 )
			{
				cmb_matier_search.DataSource = classFILL.fill_combo_matier_premier();
				cmb_matier_search.DisplayMember = "الصنف";
				cmb_matier_search.ValueMember = "CODEBARRE";
			}
			else if (cmb_choose.SelectedIndex ==3 )
			{
				cmb_matier_search.DataSource = classFILL.fill_combo_matier_premier();
				cmb_matier_search.DisplayMember = "الوحدة";
				cmb_matier_search.ValueMember = "CODEBARRE";
			}
			else if (cmb_choose.SelectedIndex == 4)
			{
				cmb_matier_search.DataSource = classFILL.fill_combo_matier_premier();
				cmb_matier_search.DisplayMember = "العلامة";
				cmb_matier_search.ValueMember = "CODEBARRE";
			}
			else if (cmb_choose.SelectedIndex == 5)
			{
				cmb_matier_search.DataSource = classFILL.fill_combo_matier_premier();
				cmb_matier_search.DisplayMember = "المخزن";
				cmb_matier_search.ValueMember = "CODEBARRE";
			} 

		}

		private void button10_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classSTock_matier_premier.SEARCH_matier_premier(cmb_matier_search.Text);
			dataGridView1.DataSource = dt;
		}

		private void kryptonTextBox1_TextChanged_1(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classSTock_matier_premier.SEARCH_matier_premier(kryptonTextBox1.Text);
			dataGridView1.DataSource = dt;
		}
	}
}
