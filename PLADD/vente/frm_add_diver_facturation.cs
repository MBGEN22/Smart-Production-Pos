using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.vente
{
	public partial class frm_add_diver_facturation : Form
	{
		string barcode = "/";
		public frmVente_facturation formVente;
		public frm_add_diver_facturation()
		{
			InitializeComponent();
		}
		private float CalculatePrice(float PriceU, float Qt)
		{
			float priceTTL = PriceU * Qt;
			return priceTTL;
		}

		private void txtQt_TextChanged(object sender, EventArgs e)
		{
			price_ttl_divers.Text = CalculatePrice(float.Parse(txtPriceU.Text), float.Parse(txtQt.Text)).ToString();

		}

		private void txtPriceU_TextChanged(object sender, EventArgs e)
		{
			price_ttl_divers.Text = CalculatePrice(float.Parse(txtPriceU.Text), float.Parse(txtQt.Text)).ToString();

		}

		private void kryptonButton12_Click(object sender, EventArgs e)
		{
			DataTable Dt = new DataTable();

			//this Line add new product 
			formVente.dataGridView1.Rows.Add(new object[] { 0, barcode, txt_name_divers.Text, txtQt.Text, txtPriceU.Text, price_ttl_divers.Text ,"D"}); ;

			formVente.GetTTL();
			formVente.txtCount.Text = formVente.getCount().ToString();
			this.Close();
		}
	}
}
