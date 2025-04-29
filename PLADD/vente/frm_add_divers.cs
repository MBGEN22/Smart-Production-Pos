using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ZXing.QrCode.Internal.Mode;
using ZXing.QrCode.Internal;
using Smart_Production_Pos.PL.vente;
using Smart_Production_Pos.report;

namespace Smart_Production_Pos.PLADD.vente
{
	public partial class frm_add_divers : Form
	{
		string barcode = "/";
		public frm_vente_caisse formVente;
        public Frm_vente_caissev5 formVenteV5;
		public frm_edit_bon frm_edit;

        public String Type;
        public frm_add_divers()
		{
			InitializeComponent();
			txtPriceU.Focus();
			txtPriceU.SelectAll();

        }
		private float CalculatePrice(float PriceU , float Qt)
		{
			float priceTTL = PriceU * Qt;
			return priceTTL;
		}
		private void frm_add_divers_Load(object sender, EventArgs e)
        {
            txtPriceU.Focus();
            txtPriceU.SelectAll();

        }

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{
			//price_ttl_divers.Text = CalculatePrice(float.Parse(txtPriceU.Text) , float.Parse(txtQt.Text)).ToString();
		}

		private void txtPriceU_TextChanged(object sender, EventArgs e)
		{
			//price_ttl_divers.Text = CalculatePrice(float.Parse(txtPriceU.Text), float.Parse(txtQt.Text)).ToString();
		}

		private void kryptonButton12_Click(object sender, EventArgs e)
		{
			DataTable Dt = new DataTable();
			if (Type == "V5")
			{
                //this Line add new product 
                formVenteV5.dataGridView1.Rows.Add(new object[] { 0, txt_name_divers.Text, txt_name_divers.Text, 1, txtPriceU.Text, txtPriceU.Text, "D" }); ;

                formVenteV5.GetTTL();
                formVenteV5.txtCount.Text = formVenteV5.getCount().ToString();
                formVenteV5.txt_barcode.Focus();
                this.Close();
            }
            if (Type == "edit")
            {
                //this Line add new product 
                 DataTable dt = (DataTable)frm_edit.dataGridView1.DataSource;

                DataRow newRow = dt.NewRow();
                newRow["رقم المنتوج"] = txt_name_divers.Text;
                newRow["اسم المنتوج"] = txt_name_divers.Text;
                newRow["كمية المنتوج"] = 1;
                newRow["سعر البيع"] = txtPriceU.Text;
                newRow["السعر الكلي"] = txtPriceU.Text;
                newRow["التكلفة"] = double.Parse(txtPriceU.Text)* 0.7;
                newRow["النوع"] = "D";

                dt.Rows.Add(newRow);

                frm_edit.GetTTL();
                frm_edit.txtCount.Text = frm_edit.getCount().ToString();
                frm_edit.txt_barcode.Focus();
                this.Close();
            }
            else
			{
				//this Line add new product 
				formVente.dataGridView1.Rows.Add(new object[] { 0, txt_name_divers.Text, txt_name_divers.Text, 1, txtPriceU.Text, txtPriceU.Text, "D" }); ;

				formVente.GetTTL();
				formVente.txtCount.Text = formVente.getCount().ToString();
                formVente.txt_barcode.Focus();
                this.Close();
			}
		}

        private void txtPriceU_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyCode == Keys.Enter)
			{
				DataTable Dt = new DataTable();
				if (Type == "V5")
				{
					//this Line add new product 
					formVenteV5.dataGridView1.Rows.Add(new object[] { 0, txt_name_divers.Text, txt_name_divers.Text, 1, txtPriceU.Text, txtPriceU.Text, "D" }); ;

					formVenteV5.GetTTL();
					formVenteV5.txtCount.Text = formVenteV5.getCount().ToString();
                    formVenteV5.txt_barcode.Focus();
                    this.Close();
				}
				else
				{
					//this Line add new product 
					formVente.dataGridView1.Rows.Add(new object[] { 0, txt_name_divers.Text, txt_name_divers.Text, 1, txtPriceU.Text, txtPriceU.Text, "D" }); ;

					formVente.GetTTL();
					formVente.txtCount.Text = formVente.getCount().ToString();
                    formVente.txt_barcode.Focus();
                    this.Close();
				}
			}
        }
    }
}
