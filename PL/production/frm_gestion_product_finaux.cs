using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.production
{
	public partial class frm_gestion_product_finaux : Form
	{
		BL.BL_PRODUCTION.BL_Prodution ClassProduction1 = new BL.BL_PRODUCTION.BL_Prodution();
		BL.BL_COMBOBOX classCombo = new BL.BL_COMBOBOX();
		BL.BL_PRODUCTION.BL_GESTION_PRODUIT_FINAUX ClassProduction =new BL.BL_PRODUCTION.BL_GESTION_PRODUIT_FINAUX();
		public frm_gestion_product_finaux()
		{
			InitializeComponent();
			this.dataGridView1.DataSource = ClassProduction.GET_TB_GESTION_PRODUIT_FINAUX(); 

		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			PLADD.production.frm_paramétrage add_paramétrage = new PLADD.production.frm_paramétrage();
			add_paramétrage.ShowDialog();
		}

		private void kryptonRadioButton1_CheckedChanged(object sender, EventArgs e)
		{
		 
			this.dataGridView1.DataSource = ClassProduction.GET_TB_GESTION_PRODUIT_FINAUX();
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			get_information();
		}
		public void get_information()
		{
			try
			{
				PLADD.production.frm_edit_paramétrage edit_pametre = new PLADD.production.frm_edit_paramétrage();
				string id_product = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();


				////////////////////////////////////////////////////////
				///////////////////////////////////////////////////////////
				///////////////////////////////////////////////////////////
				DataTable Dt = new DataTable();
				Dt = ClassProduction.getinformation_produtct_(id_product);
				if (Dt != null)
				{
					Object CODE_BARRE = Dt.Rows[0][0];
					Object DESIGNATION = Dt.Rows[0][1];
					Object QT_PARAMETRAGE = Dt.Rows[0][2];
					Object UNITE = Dt.Rows[0][3];
					Object CATEGORIE = Dt.Rows[0][4];
					Object COUT_DE_PRODUCTION = Dt.Rows[0][5];
					Object QT_DANS_PACK = Dt.Rows[0][6];
					Object PRICE_VENTE_HT = Dt.Rows[0][11];
					Object PRICE_VENTE_TTC = Dt.Rows[0][12];
					Object TVA = Dt.Rows[0][13];
					Object PRICE_GROS = Dt.Rows[0][14];
					Object PRICE_MIN = Dt.Rows[0][15];
					Object qt_alter = Dt.Rows[0][16];

					edit_pametre.txtBarcode.Text = CODE_BARRE.ToString();
					edit_pametre.txt_designation.Text = DESIGNATION.ToString();
					edit_pametre.txt_qt_parametrage.Text = QT_PARAMETRAGE.ToString();
					edit_pametre.cmb_unite.Text = UNITE.ToString();
					edit_pametre.cmb_categories.Text = CATEGORIE.ToString();
					edit_pametre.cout_production.Text = COUT_DE_PRODUCTION.ToString();
					edit_pametre.qt_dans_pack.Text = QT_DANS_PACK.ToString();
					edit_pametre.price_vente_HT.Text = PRICE_VENTE_HT.ToString();
					edit_pametre.txt_vente_ttc.Text = PRICE_VENTE_TTC.ToString();
					edit_pametre.txt_tva.Text = TVA.ToString();
					edit_pametre.txt_price_gros.Text = PRICE_GROS.ToString();
					edit_pametre.txt_price_min.Text = PRICE_MIN.ToString();
					edit_pametre.txt_qt_alert.Text = qt_alter.ToString();
				}
				////////////////////////////////////////////////////////
				///////////////////////////////////////////////////////////
				///////////////////////////////////////////////////////////
				///
				DataTable dt = new DataTable();
				dt = ClassProduction.select_pack(id_product); 
				if (dt.Rows.Count>0)
				{
					Object BARCODE_PACK = dt.Rows[0][0];
					Object DESIGNATION_pack = dt.Rows[0][1];
					Object ID_PRODUIT_FINAUX = dt.Rows[0][2];
					Object QT_DISPONIBLE = dt.Rows[0][3];
					Object PRICE_GROS_pack = dt.Rows[0][4];
					Object PRICE_DETAILLE = dt.Rows[0][5];
					Object PRICE_MIN_pack = dt.Rows[0][6];

					edit_pametre.pack_designation.Text = BARCODE_PACK.ToString();
					edit_pametre.nmr_pack.Text = DESIGNATION_pack.ToString();
					edit_pametre.ttc_pack.Text = PRICE_DETAILLE.ToString();
					edit_pametre.gros_pack.Text = PRICE_GROS_pack.ToString();
					edit_pametre.nmr_produit = id_product;
				}


				////////////////////////////////////////////////////////
				///////////////////////////////////////////////////////////
				///////////////////////////////////////////////////////////
				edit_pametre.nmr_produit = id_product;
				edit_pametre.ShowDialog();

			}
			catch
			{
				
			}

		}

		public void get_Pack()
		{
			try
			{
				PLADD.production.frm_edit_paramétrage edit_pametre = new PLADD.production.frm_edit_paramétrage();
				string id_product = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
				

			}
			catch
			{

			}


			
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{
			PLADD.production.frm_add_production edit_pametre = new PLADD.production.frm_add_production();
			string id_product = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();


			////////////////////////////////////////////////////////
			///////////////////////////////////////////////////////////
			///////////////////////////////////////////////////////////
			DataTable Dt = new DataTable();
			Dt = ClassProduction.getinformation_produtct_(id_product);
			if (Dt != null)
			{
				Object CODE_BARRE = Dt.Rows[0][0];
				Object DESIGNATION = Dt.Rows[0][1];
				Object QT_PARAMETRAGE = Dt.Rows[0][2];
				Object UNITE = Dt.Rows[0][3];
				Object CATEGORIE = Dt.Rows[0][4];
				Object COUT_DE_PRODUCTION = Dt.Rows[0][5];
				Object QT_DANS_PACK = Dt.Rows[0][6];
				Object QT_REST = Dt.Rows[0][9];
				Object PRICE_VENTE_HT = Dt.Rows[0][11];
				Object PRICE_VENTE_TTC = Dt.Rows[0][12];
				Object TVA = Dt.Rows[0][13];
				Object PRICE_GROS = Dt.Rows[0][14];
				Object PRICE_MIN = Dt.Rows[0][15];
				Object qt_alter = Dt.Rows[0][16];

				edit_pametre.Qt_dans_pack = Convert.ToInt32(QT_DANS_PACK);
				edit_pametre.txtBarcode.Text = CODE_BARRE.ToString();
				edit_pametre.txt_designation.Text = DESIGNATION.ToString();
				edit_pametre.txt_qt_parametrage.Text = QT_PARAMETRAGE.ToString(); 
				edit_pametre.cout_production.Text = COUT_DE_PRODUCTION.ToString(); 
				edit_pametre.price_vente_HT.Text = PRICE_VENTE_HT.ToString();
				edit_pametre.txt_vente_ttc.Text = PRICE_VENTE_TTC.ToString();
				edit_pametre.txt_tva.Text = TVA.ToString();
				edit_pametre.Qt_befor = (int)QT_REST;
				edit_pametre.txt_price_gros.Text = PRICE_GROS.ToString();
				edit_pametre.txt_price_min.Text = PRICE_MIN.ToString();
			}
			 


			////////////////////////////////////////////////////////
			///////////////////////////////////////////////////////////
			///////////////////////////////////////////////////////////
			edit_pametre.nmr_produit = id_product;
			edit_pametre.ShowDialog();
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			PLADD.production.frm_desambalez edit_pametre = new PLADD.production.frm_desambalez();
			string id_product = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
			DataTable dte = new DataTable();
			dte = ClassProduction1.GetLastProductionInfo(id_product); 
			if (dte.Rows.Count > 0)
			{
				Object QT_PROUDCTION = dte.Rows[0][3];
				edit_pametre.last_production.Text = QT_PROUDCTION.ToString();

				////////////////////////////////////////////////////////
				///////////////////////////////////////////////////////////
				///////////////////////////////////////////////////////////
				DataTable Dt = new DataTable();
				Dt = ClassProduction.getinformation_produtct_(id_product);
				if (Dt != null)
				{
					Object CODE_BARRE = Dt.Rows[0][0];
					Object DESIGNATION = Dt.Rows[0][1];
					Object QT_PARAMETRAGE = Dt.Rows[0][2];
					Object UNITE = Dt.Rows[0][3];
					Object CATEGORIE = Dt.Rows[0][4];
					Object COUT_DE_PRODUCTION = Dt.Rows[0][5];
					Object QT_DANS_PACK = Dt.Rows[0][6];
					Object QT_REST = Dt.Rows[0][9];
					Object PRICE_VENTE_HT = Dt.Rows[0][11];
					Object PRICE_VENTE_TTC = Dt.Rows[0][12];
					Object TVA = Dt.Rows[0][13];
					Object PRICE_GROS = Dt.Rows[0][14];
					Object PRICE_MIN = Dt.Rows[0][15];
					Object qt_alter = Dt.Rows[0][16];

					edit_pametre.Qt_dans_pack = Convert.ToInt32(QT_DANS_PACK);
					edit_pametre.txtBarcode.Text = CODE_BARRE.ToString();
					edit_pametre.txt_designation.Text = DESIGNATION.ToString();
					edit_pametre.txt_qt_parametrage.Text = QT_PARAMETRAGE.ToString();
					edit_pametre.cout_production.Text = COUT_DE_PRODUCTION.ToString();
					edit_pametre.Qt_befor = (int)QT_REST;
				}


				edit_pametre.nmr_produit = id_product;
				edit_pametre.ShowDialog();
			}
			else
			{
				MessageBox.Show("لايمكن التفكيك لانك لم تصنع من هذا المنتوج");
			}

		}

		private void kryptonGroup3_Panel_Paint(object sender, PaintEventArgs e)
		{

		}

		private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
		{
			kryptonRadioButton1.Checked = false;
			dataGridView1.DataSource = ClassProduction.search_by_code_barre(kryptonTextBox2.Text);
		}

		private void cmb_client_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		private void button10_Click(object sender, EventArgs e)
		{
			kryptonRadioButton1.Checked = false; 
			dataGridView1.DataSource = ClassProduction.search_gestion_produit_finaux_by_name(kryptonTextBox2.Text);
		}

		private void kryptonButton5_Click(object sender, EventArgs e)
		{

		}

		private void kryptonButton6_Click(object sender, EventArgs e)
		{
			if (dataGridView1.Rows.Count > 0)
			{
				report.Production.rpt_production rpt = new report.Production.rpt_production();
				#region re
				string mode = Properties.Settings.Default.mode;
				if (mode == "SQL")
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = false;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

					rpt.Refresh(); 
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				else
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = true;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

					rpt.Refresh(); 
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				#endregion
			}
		}
	}
}
