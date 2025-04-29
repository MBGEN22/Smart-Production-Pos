using Microsoft.VisualBasic.Logging;
using Smart_Production_Pos.BL.BL_FICHIER;
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
	public partial class frm_caisse_logine : Form
	{
		BL.BL_vente.BL_SP_LOGINE_Caisse classLogineCaisse = new BL.BL_vente.BL_SP_LOGINE_Caisse();
		public int id_user;
		public frm_caisse_logine()
		{
			InitializeComponent();
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			DataTable Dt = classLogineCaisse.LOGIN(txtUser.Text, txtPassword.Text);
			if (Dt.Rows.Count > 0)
			{
					Object ID_Caissier =Dt.Rows[0][0]; 
				     PLADD.vente.frmVente_facturation frmCaisse = new PLADD.vente.frmVente_facturation();
					frmCaisse.type = 1;
					frmCaisse.ID_caissier = Convert.ToInt32(ID_Caissier);
			        frmCaisse.id_user = id_user; 
			        frmCaisse.ShowDialog();
				    this.Close();
			}
			else
			{
				MessageBox.Show("تسجيل دخول خاطئ ");
			}
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
