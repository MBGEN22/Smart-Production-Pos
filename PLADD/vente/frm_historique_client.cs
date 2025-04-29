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

namespace Smart_Production_Pos.PLADD.vente
{
	public partial class frm_historique_client : Form
	{
		BL.Client_history_sold class_client_history = new BL.Client_history_sold();
		public PL.CLient.frm_historique_client frm_historique;
		BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
		public string Type; 
        BL.BL_COMBOBOX Bl_combobox = new BL.BL_COMBOBOX();
        public frm_vente_caisse caisse;
        public Frm_vente_caissev5 caisse5; 
        public frm_historique_client()
		{
			InitializeComponent();
			cmb_frnsre.DataSource = clasCombobox.get_combo_client();
			cmb_frnsre.DisplayMember = "Client";
			cmb_frnsre.ValueMember = "ID";
		}
		private decimal calculate_the_sold(decimal lb_old, decimal payé)
		{
			decimal sold_new = lb_old - payé;
			return sold_new;
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

		private void txt_paye_TextChanged(object sender, EventArgs e)
		{
			try
			{
				txt_rest_after.Text = calculate_the_sold(
				decimal.Parse(lb_rest.Text),
				decimal.Parse(txt_paye.Text)
				).ToString();
			}
			catch
			{

			}
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			try
			{
				if (Type == "A")
				{
                    class_client_history.edit_sold_client(
                        Convert.ToInt16(cmb_frnsre.SelectedValue),
                        decimal.Parse(txt_paye.Text),
                        decimal.Parse(txt_rest_after.Text),
                        0
                        );
                    class_client_history.insert_history_client(
                        dateTimePicker1.Value,
                        Convert.ToInt32(cmb_frnsre.SelectedValue),
                        0,
                        decimal.Parse(txt_paye.Text),
                        decimal.Parse(lb_rest.Text),
                        decimal.Parse(txt_rest_after.Text),
                        "دفع مستحقات",
                        ""
                        );
                    MessageBox.Show("تم الدفع بنجاح");
                    txt_paye.Text = "0"; txt_rest_after.Text = "0";
                    caisse.clientCmb.DataSource = Bl_combobox.get_combo_client();
                    caisse.clientCmb.DisplayMember = "Client";
                    caisse.clientCmb.ValueMember = "ID";
                    DataRowView drv = (DataRowView)caisse.clientCmb.SelectedItem;
                    string sold_non_pays = drv["SOLD_NON_PAYE"].ToString();
                    caisse.lb_historique_credit.Text = sold_non_pays.ToString();
                    caisse.calcule_credit_after(decimal.Parse(sold_non_pays.ToString()));
                    caisse.lb_new_credit.Text = caisse.calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString();
                }
				else if (Type == "B")
				{
                    class_client_history.edit_sold_client(
                        Convert.ToInt16(cmb_frnsre.SelectedValue),
                        decimal.Parse(txt_paye.Text),
                        decimal.Parse(txt_rest_after.Text),
                        0
                        );
                    class_client_history.insert_history_client(
                        dateTimePicker1.Value,
                        Convert.ToInt32(cmb_frnsre.SelectedValue),
                        0,
                        decimal.Parse(txt_paye.Text),
                        decimal.Parse(lb_rest.Text),
                        decimal.Parse(txt_rest_after.Text),
                        "دفع مستحقات",
                        ""
                        );
                    MessageBox.Show("تم الدفع بنجاح");
                    txt_paye.Text = "0"; txt_rest_after.Text = "0";
                    caisse5.clientCmb.DataSource = Bl_combobox.get_combo_client();
                    caisse5.clientCmb.DisplayMember = "Client";
                    caisse5.clientCmb.ValueMember = "ID";
                    DataRowView drv = (DataRowView)caisse5.clientCmb.SelectedItem;
                    string sold_non_pays = drv["SOLD_NON_PAYE"].ToString();
                    caisse5.lb_historique_credit.Text = sold_non_pays.ToString();
                    caisse5.calcule_credit_after(decimal.Parse(sold_non_pays.ToString()));
                    caisse5.lb_new_credit.Text = caisse5.calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString();
                }
				else
				{
                    class_client_history.edit_sold_client(
                        Convert.ToInt16(cmb_frnsre.SelectedValue),
                        decimal.Parse(txt_paye.Text),
                        decimal.Parse(txt_rest_after.Text),
                        0
                        );
                    class_client_history.insert_history_client(
                        dateTimePicker1.Value,
                        Convert.ToInt32(cmb_frnsre.SelectedValue),
                        0,
                        decimal.Parse(txt_paye.Text),
                        decimal.Parse(lb_rest.Text),
                        decimal.Parse(txt_rest_after.Text),
                        "دفع مستحقات",""
                        );
                    MessageBox.Show("تم الدفع بنجاح");
                    txt_paye.Text = "0"; txt_rest_after.Text = "0";
                    frm_historique.dataGridView1.DataSource = class_client_history.get_TB_historique_Client();
                }
				
			}
			catch
			{
				this.Close();
			}
		}
	}
}
