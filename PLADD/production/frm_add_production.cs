using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.production
{
	
	public partial class frm_add_production : Form
	{
		
		public string nmr_produit; 
		BL.BL_PRODUCTION.BL_GESTION_PRODUIT_FINAUX classProduit_finaux = new BL.BL_PRODUCTION.BL_GESTION_PRODUIT_FINAUX();
		decimal pricettl;
		public int Qt_dans_pack;
		float Qt_add_pack;
		BL.Bl_commande.BL_MATIER classMatier = new BL.Bl_commande.BL_MATIER();
		public int Qt_befor;
		string delte; 
		BL.BL_PRODUCTION.BL_Prodution classProduction = new BL.BL_PRODUCTION.BL_Prodution();
		public frm_add_production()
		{
			InitializeComponent();
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void frm_add_production_Load(object sender, EventArgs e)
		{

			this.grid_matier.DataSource = classProduit_finaux.get_tb_matier_where_edit(nmr_produit); 
		}
		private void Calculate_max_production()
		{
			//pour produit	$Quantite parametrage il faut consom ----> $Quantite 
			//On'a			$Quantite matier prermier		     ----> $quantite Patmetrage
			//On'a			$Quantite matier prermier on Stock ----------> $quantite produit
			//Quantite produit = (Matier prermier on Stockon Stock (on tb commande where id produit) * Quantite parametrage )/ Quantite matier prermier(paramtre) line par line
			//string idProduit = row.Cells["ر,م"].Value.ToString(); 
			//parametrage
			//string use = row.Cells["إ,ت"].Value.ToString();
		}
		public void delte_qt_matier()
		{

			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (!row.IsNewRow)
				{
					// Récupérez les valeurs nécessaires de la ligne actuelle du DataGridView
					string idProduit = row.Cells["IdProduit"].Value.ToString();
					int quantite_vnt = Convert.ToInt32(row.Cells["QtUse"].Value); // Assurez-vous de remplacer "nouvelle_quantite" par le nom réel de la colonne

					// Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit
					classMatier.edit_qt_table(idProduit, quantite_vnt);
				}
			}
		}
		public void insert_dechet()
		{
			List<float> list_min = new List<float>();
			float Quantite_parmetrage;
			float Parametre;
			float Quantite_production; 

			foreach (DataGridViewRow row in grid_matier.Rows)
			{
				float Quantite_on_Stock =0;
				if (!row.IsNewRow)
				{
					//function_get_stock
					string id_product = row.Cells["رقم المادة الاولية"].Value.ToString();
					DataTable Dt = new DataTable();
					Dt = classProduction.get_quantite_matier_premier(id_product);
					if (Dt != null)
					{
						Object QUANTITE_REST = Dt.Rows[0][7];
						Quantite_on_Stock = Convert.ToInt32(QUANTITE_REST);
					}
					//classProduction.get_quantite_matier_premier();
					Quantite_parmetrage = Convert.ToInt32(row.Cells["الكمية"].Value);
					//function_get_parametage
					Parametre = Convert.ToInt32(txt_qt_parametrage.Text);
					//function calculate
					Quantite_production = ( Quantite_on_Stock * Parametre) / Quantite_parmetrage; 
					list_min.Add(Quantite_production); 
					
				}
			} 
			double floatingNumber = list_min.Min();
			int convertedNumber = (int)Math.Floor(floatingNumber); // This will result in 6 
			Qt_product.Text = convertedNumber.ToString();
		}
		public class ProductData
		{
			[DisplayName("رقم المنتوج")]
			public string IdProduit { get; set; }

			[DisplayName("الكمية المستعملة")]
			public int QtUse { get; set; }

			[DisplayName("الكمية المتبقية")]
			public int QtRest { get; set; }
		}
		public void get_quantite_rest()
		{
			List<ProductData> productList = new List<ProductData>();
			List<int> list_min = new List<int>();
			/*//1//*/ int Parametrage	  = Convert.ToInt32(txt_qt_parametrage.Text);
			/*//2//*/ int Quantiteproduit = Convert.ToInt32(Qt_product.Text);
			/*//3//*/ int Quantiteuse;
			/*//4//*/ int Quantite_rest;
			foreach (DataGridViewRow row in grid_matier.Rows)
			{
				int Qt_use_for_parametre = 0;
				int Quantite_on_Stock = 0;
				if (!row.IsNewRow)
				{
					//function_get_stock
					string id_product = row.Cells["رقم المادة الاولية"].Value.ToString();
					Qt_use_for_parametre = Convert.ToInt32(row.Cells["الكمية"].Value);
					DataTable Dt = new DataTable();
					Dt = classProduction.get_quantite_matier_premier(id_product);
					if (Dt != null)
					{
						Object QUANTITE_REST = Dt.Rows[0][7];
						Quantite_on_Stock = Convert.ToInt32(QUANTITE_REST);
					}

					Quantiteuse = (Quantiteproduit * Qt_use_for_parametre) / Parametrage;
					Quantite_rest = Quantite_on_Stock - Quantiteuse;

					ProductData product = new ProductData
					{
						IdProduit = id_product,
						QtUse = Quantiteuse,
						QtRest = Quantite_rest
					};

					productList.Add(product);

					#region
					////classProduction.get_quantite_matier_premier();
					//Quantite_parmetrage = Convert.ToInt32(row.Cells["الكمية"].Value);
					////function_get_parametage
					//Parametre = Convert.ToInt32(txt_qt_parametrage.Text);
					////function calculate
					//Quantite_production = (Quantite_on_Stock * Parametre) / Quantite_parmetrage;

					//list_min.Add(Quantite_production);
					#endregion
				}
			} 
			dataGridView1.DataSource = productList;

		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{
			
			
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.Checked == true)
			{
				insert_dechet();
			}
			else if (checkBox2.Checked == false)
			{
				Qt_product.Text = "0";
			}
		}
		 

		private void kryptonButton3_Click_1(object sender, EventArgs e)
		{
			get_quantite_rest();
			txt_cout_ttl.Text=Cout_ttl(
				decimal.Parse(Qt_product.Text),
				decimal.Parse(cout_production.Text)
				).ToString();
		}
		
		private decimal Cout_ttl(decimal CoutU , decimal Qt_product)
		{
			decimal coutttl = CoutU * Qt_product;
			return coutttl;
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			Qt_add_pack = float.Parse(Qt_product.Text) / Qt_dans_pack;
			//insert_histpro
			classProduction.INSERT_HISTORY_PRODUCTION(
				Convert.ToDateTime(txtDate.Value),
				txtBarcode.Text,
				Qt_befor,
				Convert.ToInt32(Qt_product.Text),
				Qt_befor+ Convert.ToInt32(Qt_product.Text),
				decimal.Parse(txt_cout_ttl.Text),
				1
				) ;
			
			classProduction.update_stock_produit_fabrique(
					txtBarcode.Text,
					Convert.ToInt32(Qt_product.Text)
					);
			dt = classProduction.select_tb_pack_pf_where(txtBarcode.Text);
			if (dt.Rows.Count > 0)
			{ 
				classProduction.update_qt_pack(
					txtBarcode.Text,
					Qt_add_pack
					);
			}
			if (stockmoin.Checked == true)
			{
				delte_qt_matier();
			}
			MessageBox.Show("تم تسجيل معلومات الانتاج بنجاح");
			this.Close();
		}
	}
}
