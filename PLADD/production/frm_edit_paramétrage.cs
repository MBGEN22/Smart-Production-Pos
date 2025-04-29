using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.production
{
	public partial class frm_edit_paramétrage : Form
	{
		public string nmr_produit;
		BL.BL_PRODUCTION.BL_GESTION_PRODUIT_FINAUX classProduit_finaux = new BL.BL_PRODUCTION.BL_GESTION_PRODUIT_FINAUX();
		decimal pricettl;
		string delte;
		public frm_edit_paramétrage()
		{
			InitializeComponent();
		}

		private void frm_edit_paramétrage_Load(object sender, EventArgs e)
		{

			this.grid_matier.DataSource = classProduit_finaux.get_tb_matier_where_edit(nmr_produit);
			DataTable dt = new DataTable();
			dt = classProduit_finaux.select_pack(nmr_produit);
			if (dt.Rows.Count > 0)
			{
				Object BARCODE_PACK = dt.Rows[0][0];
				Object DESIGNATION_pack = dt.Rows[0][1];
				Object ID_PRODUIT_FINAUX = dt.Rows[0][2];
				Object QT_DISPONIBLE = dt.Rows[0][3];
				Object PRICE_GROS_pack = dt.Rows[0][4];
				Object PRICE_DETAILLE = dt.Rows[0][5];
				Object PRICE_MIN_pack = dt.Rows[0][6];
				this.pack_designation.Text = BARCODE_PACK.ToString();
				this.nmr_pack.Text = DESIGNATION_pack.ToString();
				this.ttc_pack.Text = PRICE_DETAILLE.ToString();
				this.gros_pack.Text = PRICE_GROS_pack.ToString();
			}
			else
			{
				kryptonGroup4.Enabled = false;
			}
		}
		public decimal calcule_TVA(decimal priceHt, decimal TVA)
		{
			decimal priceTTC = priceHt + (priceHt * (TVA / 100));
			return priceTTC;
		}
		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			classProduit_finaux.edit_gestion_produit_finaux(
				txtBarcode.Text,
				txt_designation.Text,
				Convert.ToInt16(txt_qt_parametrage.Text),//
				Convert.ToInt16(cmb_unite.SelectedValue),//
				Convert.ToInt16(cmb_categories.SelectedValue),//
				decimal.Parse(cout_production.Text),//
				Convert.ToInt16(qt_dans_pack.Text),// 
				decimal.Parse(price_vente_HT.Text),//
				decimal.Parse(txt_vente_ttc.Text),//
				float.Parse(txt_tva.Text),//
				decimal.Parse(txt_price_gros.Text),
				decimal.Parse(txt_price_min.Text),
				Convert.ToInt32(txt_qt_alert.Text)
				);
			MessageBox.Show("تم تعديل معلومات المنتج بنجاح");
			this.Close();

		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (check_recyvle.Checked == true)
			{
				delte = "نعم";
			}
			else if (check_recyvle.Checked == false)
			{
				delte = "لا";
			}
			pricettl = decimal.Parse(price_matier.Text) * decimal.Parse(qt_matier.Text);
			if (txtBarcode.Text == "")
			{
				MessageBox.Show("يجب أولا ملئ رقم المنتوج");
			}
			else
			{
				classProduit_finaux.INSERT_matier_premier_production_for_edit(
					txtBarcode.Text,
					cmb_matier.SelectedValue.ToString(),
					Convert.ToInt16(qt_matier.Text),
					decimal.Parse(price_matier.Text),
					pricettl,
					Convert.ToInt16(qt_dechet.Text),
					delte
					);
				grid_matier.DataSource = classProduit_finaux.get_matier_premier_production_caisse();
				qt_matier.Text = qt_dechet.Text = price_matier.Text = "0";
				check_recyvle.Checked = false;
			}
			cout_production.Text = get_sum_money_cout().ToString();
			
		}
		public decimal get_sum_money_cout()
		{
			DAL.DAL DAaL = new DAL.DAL();

			decimal sum = 0;

			using (DAaL.sqlConnection)
			{
				string query = "SELECT SUM(PRICE_TTL) FROM [dbo].[TB_MATIER_PREMIER_PRODUCTION_CAISS]";
				using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
				{
					DAaL.sqlConnection.Open();
					var result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						sum = Convert.ToInt32(result);
					}
				}
			}
			return sum;
		}

		private void price_vente_HT_TextChanged(object sender, EventArgs e)
		{
			txt_vente_ttc.Text = calcule_TVA(
				decimal.Parse(price_vente_HT.Text),
				decimal.Parse(txt_tva.Text)
				).ToString();
		}

		private void txt_tva_TextChanged(object sender, EventArgs e)
		{
			txt_vente_ttc.Text = calcule_TVA(
				decimal.Parse(price_vente_HT.Text),
				decimal.Parse(txt_tva.Text)
				).ToString();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				classProduit_finaux.delte_matier_for_edit(
					(int)this.grid_matier.CurrentRow.Cells[0].Value
					);
				grid_matier.DataSource = classProduit_finaux.get_matier_premier_production_caisse();
				MessageBox.Show("تمت عملية الحذف بنجاح");
			}
			cout_production.Text = get_sum_money_cout().ToString();
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void cmb_unite_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void txt_qt_parametrage_TextChanged(object sender, EventArgs e)
		{

		}

		private void button5_Click(object sender, EventArgs e)
		{

		}

		private void pack_designation_TextChanged(object sender, EventArgs e)
		{

		}

		private void kryptonGroupBox1_Panel_Paint(object sender, PaintEventArgs e)
		{

		}

		private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void grid_matier_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
