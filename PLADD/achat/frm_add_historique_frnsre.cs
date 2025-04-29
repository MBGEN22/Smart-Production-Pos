using Smart_Production_Pos.PL.Achats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.achat
{
	public partial class frm_add_historique_frnsre : Form
	{
		BL.frnsre_history_sold classFrnsre = new BL.frnsre_history_sold();
		BL.frnsre_history_sold class_frnsr_sold = new BL.frnsre_history_sold();
		public frm_historique_fournisseur frm_historique;
		BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();


		public frm_add_historique_frnsre()
		{
			InitializeComponent(); 
			cmb_frnsre.DataSource = clasCombobox.getfrnsr();
			cmb_frnsre.DisplayMember = "frnsr";
			cmb_frnsre.ValueMember = "ID";

		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			class_frnsr_sold.edit_sold_frnse(
					Convert.ToInt16(cmb_frnsre.SelectedValue),
					0,
					decimal.Parse(txt_paye.Text),
					decimal.Parse(txt_rest_after.Text)
					);
			classFrnsre.insert_history_frnsre(
				dateTimePicker1.Value,
				Convert.ToInt32(cmb_frnsre.SelectedValue),
				decimal.Parse(txt_paye.Text),
				decimal.Parse(lb_rest.Text),
				decimal.Parse(txt_rest_after.Text),
				"دفع خارج الشراء"
				);
			MessageBox.Show("تم الدفع بنجاح");
			txt_paye.Text = "0"; txt_rest_after.Text = "0";
			frm_historique.dataGridView1.DataSource = class_frnsr_sold.get_TB_historique_fournisseur();

		}
		private decimal calculate_the_sold(decimal lb_old , decimal payé)
		{
			decimal sold_new = lb_old - payé;
			return sold_new;
		}

		private void txt_paye_TextChanged(object sender, EventArgs e)
		{
			txt_rest_after.Text = calculate_the_sold(
				decimal.Parse(lb_rest.Text),
				decimal.Parse(txt_paye.Text)
				).ToString();
		}

		private void lb_rest_Click(object sender, EventArgs e)
		{
			
		}

		private void cmb_frnsre_SelectedIndexChanged(object sender, EventArgs e)
		{
			DataRowView drv = (DataRowView)cmb_frnsre.SelectedItem;
			string sold_non_pays = drv["SOLD_NON_PAYE"].ToString();
			lb_rest.Text = sold_non_pays.ToString();
			txt_rest_after.Text = calculate_the_sold(
				decimal.Parse(lb_rest.Text),
				decimal.Parse(txt_paye.Text)
				).ToString();
		}
	}
}
