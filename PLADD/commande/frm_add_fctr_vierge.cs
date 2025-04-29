using Smart_Production_Pos.PL.Commande;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.commande
{
	public partial class frm_add_fctr_vierge : Form
	{
		BL.Bl_commande.BL_FACTURE_VIERGE classVierge = new BL.Bl_commande.BL_FACTURE_VIERGE();
		BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
		public int id_user_ ;
		public frm_facture_vierge fctre_vierge;
		float tmbr;
		public frm_add_fctr_vierge()
		{
			InitializeComponent();
			cmb_client.DataSource = clasCombobox.get_combo_client();
			cmb_client.DisplayMember = "Client";
			cmb_client.ValueMember = "ID";
			txt_nmr_faccture.Text = classVierge.get_facture_number().ToString();
			this.grid_sub_commande.DataSource = classVierge.get_produit_of_principe(txt_nmr_faccture.Text);

		}
		private void calculeTTC(float prix_HT, float TVA)
		{
			double price_ttc_after;
			float price_ttc_befor = prix_HT + (prix_HT * (TVA / 100));
			if (check_tmber.Checked == true)
			{
				price_ttc_after = price_ttc_befor + (price_ttc_befor * 0.01);
			}
			else
			{
				price_ttc_after = price_ttc_befor;
			}

			txt_total_ttc.Text = price_ttc_after.ToString("0.00");
		}
		private void calcule_total(float prix_u, float quantite)
		{
			float ttl = quantite * prix_u;
			txt_prix_total.Text = ttl.ToString();
		}
		private void calcule_rst(float total, float payes)
		{
			float rest;
			rest = total - payes;
			txt_reste.Text = rest.ToString();
		}
		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			 
			classVierge.add_vierge_fctr(
				txt_nmr_faccture.Text,
				Convert.ToInt32(cmb_client.SelectedValue),
				Convert.ToDateTime(dateTimePicker1.Text),
				float.Parse(txt_ht_total.Text),
				float.Parse(txt_tva.Text),
				float.Parse(tmbr.ToString()),
				float.Parse(txt_total_ttc.Text),
				float.Parse(txt_payes.Text),
				float.Parse(txt_reste.Text),
				Convert.ToInt32(id_user_),
				textBox1.Text
				);
			this.Close();
			fctre_vierge.DataGridView1.DataSource = classVierge.get_produit_of_principe_globale();
		}

		private void check_tmber_CheckedChanged(object sender, EventArgs e)
		{
			if (check_tmber.Checked == true)
			{
				tmbr = 1;
			}
			else if (check_tmber.Checked == false)
			{
				tmbr = 0;
			} 
			calculeTTC(float.Parse(txt_ht_total.Text), float.Parse(txt_tva.Text));
		}

		private void txt_prix_unite_TextChanged(object sender, EventArgs e)
		{
			calcule_total(float.Parse(txt_prix_unite.Text), float.Parse(txt_Quantite.Text));
		}

		private void txt_Quantite_TextChanged(object sender, EventArgs e)
		{
			calcule_total(float.Parse(txt_prix_unite.Text), float.Parse(txt_Quantite.Text));
		}

		private void txt_ht_total_TextChanged(object sender, EventArgs e)
		{
			calculeTTC(float.Parse(txt_ht_total.Text), float.Parse(txt_tva.Text));
		}

		private void txt_tva_TextChanged(object sender, EventArgs e)
		{
			calculeTTC(float.Parse(txt_ht_total.Text), float.Parse(txt_tva.Text));

		}

		private void button5_Click(object sender, EventArgs e)
		{
			classVierge.add_product(
				txt_sub_name_commande.Text,
				decimal.Parse(txt_prix_unite.Text),
				Convert.ToInt32(txt_Quantite.Text),
				decimal.Parse(txt_prix_total.Text),
				txt_nmr_faccture.Text
				) ;
			txt_payes.Text = txt_ht_total.Text = classVierge.getSum(txt_nmr_faccture.Text).ToString();
			calcule_rst(float.Parse(txt_total_ttc.Text), float.Parse(txt_payes.Text));
			this.grid_sub_commande.DataSource = classVierge.get_produit_of_principe(txt_nmr_faccture.Text);
			txt_sub_name_commande.Text = ""; txt_prix_unite.Text = txt_Quantite.Text = txt_prix_total.Text = "0";
		}

		private void button6_Click(object sender, EventArgs e)
		{
			//
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				classVierge.delete_ouverier_Record((int)this.grid_sub_commande.CurrentRow.Cells[0].Value);
				this.grid_sub_commande.DataSource = classVierge.get_produit_of_principe(txt_nmr_faccture.Text);
				txt_sub_name_commande.Focus();
			}
		}

		private void txt_payes_TextChanged(object sender, EventArgs e)
		{
			calcule_rst(float.Parse(txt_total_ttc.Text), float.Parse(txt_payes.Text));
		}

		private void txt_ht_total_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
			{
				e.Handled = true; // Prevent the character from being entered
			}
		}

		private void frm_add_fctr_vierge_Load(object sender, EventArgs e)
		{

			txt_ht_total.Text = classVierge.getSum(txt_nmr_faccture.Text).ToString();
		}
	}
}
