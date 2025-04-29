using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Achats
{
	public partial class frm_dechet_recycle : Form
	{
		BL.BL_Achats.BL_dechet_recycle classResycle = new BL.BL_Achats.BL_dechet_recycle();
		public frm_dechet_recycle()
		{
			InitializeComponent();
			DataGridView1.DataSource = classResycle.get_recycle_dechet_();
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{ 
			int id  = Convert.ToInt32(this.DataGridView1.CurrentRow.Cells[0].Value);
			classResycle.edit_etas_dechet(id,"مستعمل");
			DataGridView1.DataSource = classResycle.get_recycle_dechet_();
		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classResycle.search_recycle_dechet(txtSearch.Text);
			DataGridView1.DataSource = dt;
		}
	}
}
