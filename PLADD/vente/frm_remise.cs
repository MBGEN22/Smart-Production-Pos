using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Smart_Production_Pos.PL.vente;

namespace Smart_Production_Pos.PLADD.vente
{
	public partial class frm_remise : Form
	{
		public decimal limite_price;
		public frm_vente_caisse formVentePrincipale;
        public frm_edit_bon frm_edit_bon;
        public Frm_vente_caissev5 formVentePrincipaleV5;
		public string Type;
        public frm_remise()
		{
			InitializeComponent();
		}

		private decimal calcule_montant_remisier(decimal montant_Principale , decimal new_montant)
		{
			decimal montant_remisiser = montant_Principale - new_montant;
            montant_remisiser = Math.Round(montant_remisiser, 2);
			return montant_remisiser;
		}
		private decimal calcule_pourcentage(decimal montant_Principale, decimal montant_new )
		{
			decimal pourcentage = 100 -((montant_new * 100) / montant_Principale); 
			pourcentage = Math.Round(pourcentage, 2);
			return pourcentage;
		}
		private void kryptonButton12_Click(object sender, EventArgs e)
		{
			if (Type == "V5")
			{
                if (decimal.Parse(txt_new_montant.Text) < limite_price)
                {
                    MessageBox.Show("لايمكنك البيع تحت الثمن المحدود");
                }
                else
                {
                    formVentePrincipaleV5.lbl_prix_remisier.Text = txt_montant_remise.Text;
                    formVentePrincipaleV5.lb_Total.Text = txt_new_montant.Text;
                    formVentePrincipaleV5.txt_Versement.Text = txt_new_montant.Text;
                    formVentePrincipaleV5.pourcentageRemise = txt_porcntg_remise.Text; 
                    formVentePrincipaleV5.txt_barcode.Focus();
                    this.Close();
                }
            }
            if (Type == "edit")
            {
                if (decimal.Parse(txt_new_montant.Text) < limite_price)
                {
                    MessageBox.Show("لايمكنك البيع تحت الثمن المحدود");
                }
                else
                {
                    frm_edit_bon.lbl_prix_remisier.Text = txt_montant_remise.Text;
                    frm_edit_bon.lb_Total.Text = txt_new_montant.Text;
                    frm_edit_bon.txt_Versement.Text = txt_new_montant.Text;
                    frm_edit_bon.pourcentageRemise = txt_porcntg_remise.Text;
                    frm_edit_bon.txt_barcode.Focus();
                    this.Close();
                }
            }
            else
			{

				if (decimal.Parse(txt_new_montant.Text) < limite_price)
				{
					MessageBox.Show("لايمكنك البيع تحت الثمن المحدود");
				}
				else
				{
					formVentePrincipale.lbl_prix_remisier.Text = txt_montant_remise.Text;
					formVentePrincipale.lb_Total.Text = txt_new_montant.Text;
					formVentePrincipale.txt_Versement.Text = txt_new_montant.Text;
					formVentePrincipale.pourcentageRemise = txt_porcntg_remise.Text;
                    formVentePrincipale.txt_barcode.Focus();
                    this.Close();
				}
			}
		}

		private void txt_montant_remise_TextChanged(object sender, EventArgs e)
		{
				//txt_new_montant.Text = 
				//CalculeNew_montant(decimal.Parse(txt_price_product.Text) , decimal.Parse(txt_montant_remise.Text) ).ToString();
				//txt_porcntg_remise.Text =
				//calcule_pourcentage(decimal.Parse(txt_price_product.Text), decimal.Parse(txt_montant_remise.Text)).ToString()+"%";

		}

        private void txt_new_montant_TextChanged(object sender, EventArgs e)
        {
			try
			{
                txt_porcntg_remise.Text = calcule_pourcentage(decimal.Parse(txt_price_product.Text),
                                                              decimal.Parse(txt_new_montant.Text)).ToString();
                txt_montant_remise.Text = calcule_montant_remisier(decimal.Parse(txt_price_product.Text),
																   decimal.Parse(txt_new_montant.Text)).ToString();
            }
			catch
			{

			}
        }
    }
}
