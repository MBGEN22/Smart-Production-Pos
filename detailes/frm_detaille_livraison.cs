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
	public partial class frm_detaille_livraison : Form
	{
		public int id_liv;
		BL.Bl_commande.detaille_de_livraison prd = new BL.Bl_commande.detaille_de_livraison();
		public frm_detaille_livraison()
		{
			InitializeComponent();
		}

		private void frm_detaille_livraison_Load(object sender, EventArgs e)
		{

			this.dataGridView1.DataSource = prd.get_table_detaille(id_liv);
		}
	}
}
