using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.detailes
{
	public partial class frm_Detaille_fctr_Produit_revent : Form
	{
		BL.BL_ACHAT_REVENT.BL_facture classFacture = new BL.BL_ACHAT_REVENT.BL_facture();
		public string id_fctre;
		public frm_Detaille_fctr_Produit_revent()
		{
			InitializeComponent();
		}

		private void frm_Detaille_fctr_Produit_revent_Load(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = classFacture.get_detaiile_fctr(id_fctre);
		}
	}
}
