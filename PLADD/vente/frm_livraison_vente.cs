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
	public partial class frm_livraison_vente : Form
	{
		BL.BL_vente.BL_livraison classLivraison = new BL.BL_vente.BL_livraison();
		public int id_caisier, id_user;
		public string nmr_fctr;
		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			classLivraison.insertLivraison(
				Convert.ToDateTime(dateTimePicker1.Text),
				txt_nom_liv.Text,
				txt_recu.Text,
				cmb_type.Text,
				decimal.Parse(txt_price.Text),
				txt_chaufeur.Text,
				txt_matricule.Text,
				id_caisier,
				id_user,
				nmr_fctr
				);
			MessageBox.Show("تم تسجيل معلومات النقل بنجاح");
			this.Close();
		}

		private void cmb_type_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmb_type.Text == "توصيل")
			{
				txt_price.Enabled = true;
				txt_chaufeur.Enabled = true;
				txt_matricule.Enabled = true;
			}
			else if (cmb_type.Text == "لا يوجد توصيل")
			{
				txt_price.Enabled = false;
				txt_chaufeur.Enabled = false;
				txt_matricule.Enabled = false;
			}
		}

		private void txt_price_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
			{
				e.Handled = true;
			}
		}

		public frm_livraison_vente()
		{
			InitializeComponent();
		}
	}
}
