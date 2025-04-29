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
	public partial class frm_sub_commaned_ : Form
	{
		public string id_commande;
		BL.Bl_commande.BL_sub_commande sub_commandeclass = new  BL.Bl_commande.BL_sub_commande();
		public frm_sub_commaned_()
		{
			InitializeComponent();
		}

		private void frm_sub_commaned__Load(object sender, EventArgs e)
		{ 
			grid_sub_commande.DataSource = sub_commandeclass.get_detailles_sub_commande(id_commande);
		}

		private void الموادالمستعملةToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PL.Commande.frm_matier_use_ formSub_commande = new frm_matier_use_();
			formSub_commande.id_commande = (int)this.grid_sub_commande.CurrentRow.Cells[0].Value;
			formSub_commande.Show();
		}

		private void grid_sub_commande_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
