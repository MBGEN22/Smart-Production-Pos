using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Fichier
{
	public partial class frm_dechet : Form
	{
		BL.Bl_commande.bl_dechet_non_recycle classDechet = new BL.Bl_commande.bl_dechet_non_recycle();
		public frm_dechet()
		{
			InitializeComponent();
			this.DataGridView1.DataSource = classDechet.getdechet();
		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classDechet.search_get_dechet(kryptonTextBox1.Text);
			this.DataGridView1.DataSource = dt;
		}
	}
}
