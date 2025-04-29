using Smart_Production_Pos.PLADD.vente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.PL_Statistique
{
	public partial class frm_add_depense : Form
	{
		BL.BL_Statistique.BL_Depense classDepense = new BL.BL_Statistique.BL_Depense();
		public PL.Statistique.frm_depense depenseForm;
		BL.BL_vente.BL_SP_LOGINE_Caisse classCaisse = new BL.BL_vente.BL_SP_LOGINE_Caisse();
		public int id, iduser, ID_historique;
		public frm_vente_caisse Caisse;
		public frm_add_depense()
		{
			InitializeComponent();
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void txt_money_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
			{
				e.Handled = true;
			}
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			DateTime currentDateTime = DateTime.Now;
			Form1 frm = new Form1();
			if (id > 0)
			{
				classDepense.update_Depense(
					id,
					txt_causse.Text,
					decimal.Parse(txt_money.Text),
					Convert.ToDateTime(txtDate.Value),
					Convert.ToInt32(frm.ID_user)
					);
				if (ID_historique != null)
				{
					classCaisse.update_history_caissier(
							ID_historique,
							currentDateTime.TimeOfDay,
							-decimal.Parse(txt_money.Text)
						);
				}
				MessageBox.Show("تم تعديل البيانات  بنجاح");
				Caisse.txt_barcode.Focus();
				this.Close();
			}
			else
			{
				classDepense.Add_Funct(
					txt_causse.Text,
					decimal.Parse(txt_money.Text),
					Convert.ToDateTime(txtDate.Value),
					iduser
					) ;
				if (ID_historique != null)
				{ 
					classCaisse.update_history_caissier(
							ID_historique,
							currentDateTime.TimeOfDay,
							- decimal.Parse(txt_money.Text)
						);
				}
				MessageBox.Show("تم اضافة البيانات  بنجاح");
                //Caisse.txt_barcode.Focus();
                this.Close();
			}
		}
	}
}
