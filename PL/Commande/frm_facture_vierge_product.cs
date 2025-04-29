using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Commande
{
	public partial class frm_facture_vierge_product : Form
	{
		public string ID_facture;
		BL.Bl_commande.BL_FACTURE_VIERGE classFacture = new BL.Bl_commande.BL_FACTURE_VIERGE();
		public frm_facture_vierge_product()
		{
			InitializeComponent();
		}

		private void frm_facture_vierge_product_Load(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = classFacture.GET_INFORMATION_FACTURE_VIERGE(ID_facture);
		}
	}
}
