using Smart_Production_Pos.BL.Bl_commande;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Smart_Production_Pos.form_plus
{
	public partial class frm_add_divers_commade : Form
	{ 
		public string id_commande;
		public int id_type_edit_or_add;
		public int id_sub_commande;
		BL.Bl_commande.BL_MATIER classMAtier = new BL.Bl_commande.BL_MATIER();
		public PLADD.commande.frm_add_commande formComande;
		public PLADD.commande.edit_comande_proforma form_edit_commande;
		public decimal total_sum;
		BL.Bl_commande.BL_sub_commande classSubCommande = new BL.Bl_commande.BL_sub_commande();

		public frm_add_divers_commade()
		{
			InitializeComponent();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (id_type_edit_or_add == 1)
			{
				total_sum = classMAtier.get_total_(id_sub_commande);
				//MessageBox.Show(total_sum.ToString());
				classMAtier.insert_TB_MATIER_USE_SUB_CMND
					(
					"",
					id_sub_commande,
					Convert.ToInt32(textBox3.Text),
					decimal.Parse(textBox4.Text),
					textBox1.Text,
					0,
					"لا"
					);
				total_sum = classMAtier.get_total_(id_sub_commande);
				classMAtier.edit_cout_sub(
					id_sub_commande,
					total_sum
					);
				formComande.txtQtee.Text = classSubCommande.get_sum_Qt().ToString();
				formComande.txtTotalpriceHT.Text = classSubCommande.get_sum_money().ToString();
				formComande.cout_ttl_cmnd.Text = classSubCommande.get_sum_money_cout().ToString();

				formComande.grid_sub_commande.DataSource = classSubCommande.get_tb_sub_commande_caisse(id_commande);
				formComande.grid_matier.DataSource = classMAtier.get_tb_matier();
				this.Close();
			}
			else if(id_type_edit_or_add == 0)//edit
			{
				total_sum = classMAtier.get_total_(id_sub_commande);
				//MessageBox.Show(total_sum.ToString());
				classMAtier.insert_TB_MATIER_USE_SUB_CMND
					(
					"",
					id_sub_commande,
					Convert.ToInt32(textBox3.Text),
					decimal.Parse(textBox4.Text),
					textBox1.Text,
					0,
					"لا"
					);
				total_sum = classMAtier.get_total_(id_sub_commande);
				classMAtier.edit_cout_sub(
					id_sub_commande,
					total_sum
					);
				form_edit_commande.txtQtee.Text = classSubCommande.get_sum_Qt().ToString();
				form_edit_commande.txtTotalpriceHT.Text = classSubCommande.get_sum_money().ToString();
				form_edit_commande.cout_ttl_cmnd.Text = classSubCommande.get_sum_money_cout().ToString();

				form_edit_commande.grid_sub_commande.DataSource = classSubCommande.get_tb_sub_commande_caisse(id_commande);
				form_edit_commande.grid_matier.DataSource = classMAtier.get_tb_matier();
				this.Close();
			}
		}
	}
} 
