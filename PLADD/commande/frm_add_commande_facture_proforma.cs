using Smart_Production_Pos.BL.Bl_commande;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.commande
{
	public partial class frm_add_commande_facture_proforma : Form
	{
		frm_add_commande frm_add_commnde = new frm_add_commande();

		//Classe
		BL.Bl_commande.Bl_commande classCommande = new BL.Bl_commande.Bl_commande();
		BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
		BL.Bl_commande.BL_TOOLS classTools = new BL.Bl_commande.BL_TOOLS();
		BL.Bl_commande.BL_MATIER classMatier = new BL.Bl_commande.BL_MATIER();
		BL.Bl_commande.BL_sub_commande classSubCommande = new BL.Bl_commande.BL_sub_commande();
		BL.Client_history_sold historique_Client = new BL.Client_history_sold();
		BL.Bl_commande.BL_DECHET classDechet = new BL_DECHET();
		string delte;

		//variable
		public int id_type_entre;//1 add , 0update 
		int id_sub_commande;
		decimal total_price;
		decimal Sold_old_non_pay;
		public int price_total_production;
		public decimal Credit_avance;
		public decimal total_sum;
		DateTime? deadLineDate;
		public decimal max_credit;
		public int id_user;
		public frm_add_commande_facture_proforma()
		{
			InitializeComponent();

			//id facture
			txt_id_commande.Text = classCommande.get_commande_nmr().ToString();

			//datagrid 
			grid_sub_commande.DataSource = classSubCommande.get_tb_sub_commande_caisse(txt_id_commande.Text);

			//combo
			cmb_client.DataSource = clasCombobox.get_combo_client();
			cmb_client.DisplayMember = "Client";
			cmb_client.ValueMember = "ID";

			//sum
			txtQtee.Text = classSubCommande.get_sum_Qt().ToString();
			txtTotalpriceHT.Text = classSubCommande.get_sum_money().ToString();
		}



		private void txt_prix_unite_TextChanged(object sender, EventArgs e)
		{
			txt_prix_total.Text = frm_add_commnde.calcule_ttl_sub_cmnd(
			   decimal.Parse(txt_prix_unite.Text),
			   Convert.ToInt32(txt_Quantite.Text))
			   .ToString();
		}

		private void txt_Quantite_TextChanged(object sender, EventArgs e)
		{

			txt_prix_total.Text = frm_add_commnde.calcule_ttl_sub_cmnd(
							decimal.Parse(txt_prix_unite.Text),
							Convert.ToInt32(txt_Quantite.Text))
							.ToString();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			classSubCommande.add_sub_commande_caise(
			   txt_id_commande.Text,
			   txt_sub_name_commande.Text,
			   Convert.ToInt32(txt_Quantite.Text),
			   decimal.Parse(txt_prix_unite.Text),
			   decimal.Parse(txt_prix_total.Text),
			   Convert.ToInt32(txt_Quantite.Text),
			   0,
			   0
			   );
			txtQtee.Text = classSubCommande.get_sum_Qt().ToString();
			txtTotalpriceHT.Text = classSubCommande.get_sum_money().ToString();

			grid_sub_commande.DataSource = classSubCommande.get_tb_sub_commande_caisse(txt_id_commande.Text);
			txt_sub_name_commande.Text = "";
			txt_Quantite.Text = txt_prix_unite.Text = txt_prix_total.Text = "0";
		}
		private void button6_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				classSubCommande.delete_sub_comnd((int)this.grid_sub_commande.CurrentRow.Cells[0].Value);
				grid_sub_commande.DataSource = classSubCommande.get_tb_sub_commande_caisse(txt_id_commande.Text);
				MessageBox.Show("تمت عملية الحذف بنجاح");
			}
			txtQtee.Text = classSubCommande.get_sum_Qt().ToString();
			txtTotalpriceHT.Text = classSubCommande.get_sum_money().ToString();

			grid_sub_commande.DataSource = classSubCommande.get_tb_sub_commande_caisse(txt_id_commande.Text);
			txt_sub_name_commande.Text = "";
			txt_Quantite.Text = txt_prix_unite.Text = txt_prix_total.Text = "0";
		}

		private void txtTotalpriceHT_TextChanged(object sender, EventArgs e)
		{
			txt_ttl_ttc.Text = frm_add_commnde.calcule_TVA(
			   decimal.Parse(txtTotalpriceHT.Text),
			   decimal.Parse(txt_tva.Text)
			   ).ToString();
		}

		private void txt_tva_TextChanged(object sender, EventArgs e)
		{
			txt_ttl_ttc.Text = frm_add_commnde.calcule_TVA(
			  decimal.Parse(txtTotalpriceHT.Text),
			  decimal.Parse(txt_tva.Text)
			  ).ToString();
		}

		private void txt_ttl_ttc_TextChanged(object sender, EventArgs e)
		{

		}

		private void txt_Quantite_Click(object sender, EventArgs e)
		{
		}

		private void txt_prix_unite_Click(object sender, EventArgs e)
		{

		}
		private double calculeTmbr(double pric_befor_TTC, double tmbr)
		{
			double pric_after_TTC = pric_befor_TTC + (pric_befor_TTC * tmbr);
			return pric_after_TTC;
		}
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			decimal ttc_befor = frm_add_commnde.calcule_TVA(
				decimal.Parse(txtTotalpriceHT.Text),
				decimal.Parse(txt_tva.Text)
				);

			if (check_tmber.Checked == true)
			{
				txt_ttl_ttc.Text = calculeTmbr(Convert.ToDouble(ttc_befor), 0.01).ToString();
			}
			else if (check_tmber.Checked == false)
			{
				txt_ttl_ttc.Text = calculeTmbr(Convert.ToDouble(ttc_befor), 0).ToString();
			}
		}

		private void checkBox10_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox10.Checked == true)
			{
				txtTotalpriceHT.Enabled = true;
				txt_ttl_ttc.Enabled = true;
			}
			else if (checkBox10.Checked == false)
			{
				txtTotalpriceHT.Enabled = false;
				txt_ttl_ttc.Enabled = false;
			}
		}

		private void checkBox9_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox9.Checked == true)
			{
				txtQtee.Enabled = true;
			}
			else if (checkBox9.Checked == false)
			{
				txtQtee.Enabled = false;
			}
		}

		private void cmb_client_SelectedIndexChanged(object sender, EventArgs e)
		{
			DataRowView drv = (DataRowView)cmb_client.SelectedItem;

			DataTable dt = new DataTable();
			DataRowView selectedRow = (DataRowView)cmb_client.SelectedItem;
			int id_client = Convert.ToInt32(selectedRow["ID"]);
			max_credit = decimal.Parse(drv["MAX_CREDIT"].ToString());
			string sold_non_pays = drv["SOLD_NON_PAYE"].ToString();
			string Credit = drv["Sold_avance"].ToString();
			Credit_avance = decimal.Parse(drv["Sold_avance"].ToString());
			txtCredit.Text = Credit;

		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			double? tmber;
			#region if
			

			if (check_tmber.Checked == true)
			{
				tmber = 0.01;
			}
			else
			{
				tmber = null;
			}

			#endregion
			#region insert commande information
			classCommande.insert_new_commande
				(
				txt_id_commande.Text,
				dateTimePicker1.Value,
				txtname.Text,
				Convert.ToInt32(cmb_client.SelectedValue),
				cmb_tupe.Text,
				0,
				0,
				Convert.ToInt32(txtQtee.Text),
				"فاتورة أولية",
				decimal.Parse(txtTotalpriceHT.Text),
				decimal.Parse(txt_ttl_ttc.Text),
				float.Parse(txt_tva.Text),
				deadLineDate,
				"في طور الانجاز"
				, id_user
				, tmber
				, textBox1.Text
				,0
				,0
				);


			#endregion  
			#region sendTotable_sub_cmd
			sendTotable_sub_cmd();
			#endregion

			#region delete sub  
			delletFromCaisse_tb_sub_commande();
			#endregion
			MessageBox.Show("تم تسجيل هذه الطلبية بنجاح");
			this.Close();
		}

		private void sendTotable_sub_cmd()
		{
			DAL.DAL daoo = new DAL.DAL();
			// SQL query
			string query = @"  
						INSERT INTO [dbo].[TB_SUM_COMMANDE]
						(
						[ID]
						,[ID_COMMANDE]
						,[SUB_COMMANDE_TITLE]
						,[QUANTITE]
						,[PRIX_UNITAIR]
						,[PRIX_TOTAL]
						,[QTE_REST]
						,[QT_LIVRE]
						,[price_cout]
						)

						SELECT 
						 [ID]
						,[ID_COMMANDE]
						,[SUB_COMMANDE_TITLE]
						,[QUANTITE]
						,[PRIX_UNITAIR]
						,[PRIX_TOTAL]
						,[QTE_REST]
						,[QT_LIVRE]
						,[price_cout]
						FROM [dbo].[TB_SUM_COMMANDE_caise]  ";
			try
			{
				using (daoo.sqlConnection)
				{
					daoo.sqlConnection.Open();

					using (SqlCommand command = new SqlCommand(query, daoo.sqlConnection))
					{
						int rowsAffected = command.ExecuteNonQuery();
						MessageBox.Show($"{rowsAffected} تم حفظ الجدول.");
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}

		}
		private void delletFromCaisse_tb_sub_commande()
		{
			DAL.DAL DAaL = new DAL.DAL();
			// SQL query
			string query = @"DELETE FROM [dbo].[TB_SUM_COMMANDE_caise];";
			try
			{
				using (DAaL.sqlConnection)
				{
					DAaL.sqlConnection.Open();

					using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
					{
						int rowsAffected = command.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}
	}
}
