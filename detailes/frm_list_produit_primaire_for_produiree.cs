using Smart_Production_Pos.PLADD.commande;
using Smart_Production_Pos.PLADD.production;
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
	public partial class frm_list_produit_primaire_for_produiree : Form
	{
		BL.Bl_commande.BL_MATIER classMatier = new BL.Bl_commande.BL_MATIER();
		public string id_produit;
		public int id_type_edit_or_add;
		public frm_paramétrage form_paramétrage;
		public edit_comande_proforma frm_edit_commande;
		public frm_list_produit_primaire_for_produiree()
		{
			InitializeComponent();
		}

		private void frm_list_produit_primaire_for_produiree_Load(object sender, EventArgs e)
		{
			dataGridView1.DataSource = classMatier.get_list_achat_by_id(id_produit);
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (id_type_edit_or_add == 0)
			{
				frm_edit_commande.price_matier.Text = (this.dataGridView1.CurrentRow.Cells[5].Value).ToString();
				this.Close();
			}
			else if (id_type_edit_or_add == 1)
			{
				form_paramétrage.price_matier.Text = (this.dataGridView1.CurrentRow.Cells[5].Value).ToString();
				this.Close();
			}
		}
	}
}
