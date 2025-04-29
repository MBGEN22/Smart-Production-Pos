using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.vente
{
	public partial class frm_retoure_Article : Form
	{
		BL.BL_vente.BL_vente_Fonction classFacteure = new BL.BL_vente.BL_vente_Fonction();
		public frm_retoure_Article()
		{
			InitializeComponent();
			kryptonDataGridView1.DataSource = classFacteure.get_facture_detailles(); 
		}

		private void kryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			txt_nmr_fctr.Text = this.kryptonDataGridView1.CurrentRow.Cells[0].Value.ToString();
			txt_client.Text = this.kryptonDataGridView1.CurrentRow.Cells[3].Value.ToString();
			txt_TTL.Text = this.kryptonDataGridView1.CurrentRow.Cells[4].Value.ToString();
			kryptonDataGridView2.DataSource = classFacteure.get_vente_by_nmrr(this.kryptonDataGridView1.CurrentRow.Cells[0].Value.ToString());

		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			frm_detaille_fctr_vente detaille = new frm_detaille_fctr_vente();
			detaille.kryptonDataGridView2.DataSource = classFacteure.get_vente_by_nmrr(this.kryptonDataGridView1.CurrentRow.Cells[0].Value.ToString());
			detaille.id_fctr = this.kryptonDataGridView1.CurrentRow.Cells[0].Value.ToString();
			detaille.ShowDialog();
		}
	}
}
