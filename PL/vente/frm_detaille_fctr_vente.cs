using Smart_Production_Pos.TAB_CONTROL;
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
	public partial class frm_detaille_fctr_vente : Form
	{
		BL.BL_vente.BL_vente_retoure classVente_retour = new BL.BL_vente.BL_vente_retoure();
		BL.BL_vente.BL_vente_Fonction classFacteure = new BL.BL_vente.BL_vente_Fonction();
		public string id_fctr;
		public frm_detaille_fctr_vente()
		{
			InitializeComponent();
			
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void kryptonDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			txt_code_barre.Text = this.kryptonDataGridView2.CurrentRow.Cells[1].Value.ToString();
			txtdesignation.Text = this.kryptonDataGridView2.CurrentRow.Cells[2].Value.ToString();
			txtQT.Text = this.kryptonDataGridView2.CurrentRow.Cells[3].Value.ToString();
			txt_Price_u.Text = this.kryptonDataGridView2.CurrentRow.Cells[4].Value.ToString();
			txt_ttl.Text = this.kryptonDataGridView2.CurrentRow.Cells[5].Value.ToString();
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			DialogResult Dg = MessageBox.Show("هل انت متاكد من هذا الاختيار", "تعديل في الفاتورة", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (Dg == DialogResult.Yes)
			{
				classVente_retour.edit_vente_QT(
					Convert.ToInt32(this.kryptonDataGridView2.CurrentRow.Cells[0].Value),
					float.Parse(txt_edit.Text)
					);
				kryptonDataGridView2.DataSource = classFacteure.get_vente_by_nmrr(id_fctr);
				LB_ttl_facture.Text = classVente_retour.sum_vente(id_fctr);
			} 
		}

		private void txt_edit_TextChanged(object sender, EventArgs e)
		{

		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			DialogResult Dg = MessageBox.Show("هل انت متاكد من هذا الاختيار", "تعديل في الفاتورة", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (Dg == DialogResult.Yes)
			{
				classVente_retour.delete_vente_QT(
					Convert.ToInt32(this.kryptonDataGridView2.CurrentRow.Cells[0].Value)
					);
				kryptonDataGridView2.DataSource = classFacteure.get_vente_by_nmrr(id_fctr);
				LB_ttl_facture.Text = classVente_retour.sum_vente(id_fctr);
			}
		}

		private void frm_detaille_fctr_vente_Load(object sender, EventArgs e)
		{ 
			lb_nmr_fctr.Text = id_fctr;
			LB_ttl_facture.Text = classVente_retour.sum_vente(id_fctr);
		}

		private void kryptonDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
