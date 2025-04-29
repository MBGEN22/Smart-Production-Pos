using Smart_Production_Pos.PL.Fichier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.Fichier
{
	public partial class frm_update_fav : Form
	{
		BL.BL_FICHIER.BL_favoire classFav = new BL.BL_FICHIER.BL_favoire();
		public int id;
		public frm_favoris frmFav;
		public frm_update_fav()
		{
			InitializeComponent();
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			classFav.update_favoire(id, txt_reference.Text);
			frmFav.dataGridView1.DataSource = classFav.select_table_fav();
			this.Close();

		}
	}
}
