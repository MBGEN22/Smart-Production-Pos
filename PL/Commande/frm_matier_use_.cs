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
	public partial class frm_matier_use_ : Form
	{
		BL.Bl_commande.BL_MATIER classMatier = new BL.Bl_commande.BL_MATIER();
		public int id_commande;
		public frm_matier_use_()
		{
			InitializeComponent();
		}

		private void frm_matier_use__Load(object sender, EventArgs e)
		{
			grid_sub_commande.DataSource = classMatier.GET_mtier(id_commande);
		}
	}
}
