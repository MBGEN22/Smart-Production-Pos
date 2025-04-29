using Smart_Production_Pos.BL.Bl_commande;
using Smart_Production_Pos.PL.Commande;
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
	public partial class edit_comande_proforma : Form
	{
		//Classe
		BL.Bl_commande.BL_proforma_commande class_edit_Commande = new BL.Bl_commande.BL_proforma_commande();
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
		public edit_comande_proforma()
		{
			InitializeComponent();
			

			//combo
			cmb_client.DataSource = clasCombobox.get_combo_client();
			cmb_client.DisplayMember = "Client";
			cmb_client.ValueMember = "ID";

			cmb_matier.DataSource = clasCombobox.get_product();
			cmb_matier.DisplayMember = "DESIGNATION";
			cmb_matier.ValueMember = "CODEBARRE";

			
		}

		//function
		#region
		public decimal calcule_TVA(decimal priceHt, decimal TVA)
		{
			decimal priceTTC = priceHt + (priceHt * (TVA / 100));
			return priceTTC;
		}
		private decimal calcule_total_price(int qt, decimal _unit_price, int qt_dechet)
		{
			decimal total;
			if (check_recyvle.Checked == true)
			{
				total = _unit_price * (qt - qt_dechet);
			}
			else
			{
				total = qt * _unit_price;
			}
			return total;
		}
		public decimal calcule_ttl_sub_cmnd(decimal priceUnit, int Qte)
		{
			decimal ttl = priceUnit * Qte;
			return ttl;
		}
		private void get_notifictaniton(int id)
		{
			DataTable dt = new DataTable();
			dt = classCommande.get_notification(id);
			if (dt.Rows.Count > 0)
			{
				label14.Visible = true;
			}
			else
			{
				label14.Visible = false;
			}
		}
		private decimal calcule_credit_after(decimal sold_old)
		{
			decimal sold_after = decimal.Parse(txt_ttl_ttc.Text) - decimal.Parse(txtPricepayer.Text);
			decimal soldnew = sold_old + sold_after;
			return soldnew;
		}
		public decimal Check_max_credit(decimal rest_old, decimal rest_now, decimal Max_Credit)
		{
			decimal rest_after = rest_old + rest_now;

			return rest_after;
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
		private void sendTotable_matier()
		{
			DAL.DAL daoo = new DAL.DAL();
			// SQL query
			string query = @"
					      SET IDENTITY_INSERT [dbo].[TB_MATIER_USE_SUB_CMND] on 
						  INSERT INTO [dbo].[TB_MATIER_USE_SUB_CMND]
						 (ID
						 ,[ID_MATIER]
						 ,[ID_SUB_COMMANDE]
						 ,[QT]
						 ,[COUT]
						 ,[NAME_MATIER]
						 ,[QTDECHET])

								SELECT 
								[ID]
						,[ID_MATIER]
						,[ID_SUB_COMMANDE]
						,[QT]
						,[COUT]
						,[NAME_MATIER]
						,[QTDECHET]
						 FROM [dbo].[TB_MATIER_USE_SUB_CMND_caise]
						SET IDENTITY_INSERT [dbo].[TB_MATIER_USE_SUB_CMND] OFF ";
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
		private void sendTotable_tools()
		{
			DAL.DAL daoo = new DAL.DAL();
			// SQL query
			string query = @" 
						INSERT INTO [dbo].[TB_TOOLS_COMMANDE]
							   ([ID]
							   ,[TOOLS]
							   ,[ID_COMMANDE]) 

						SELECT [ID]
							  ,[TOOLS]
							  ,[ID_COMMANDE]
						  FROM [dbo].[TB_TOOLS_COMMANDE_caise]  ";
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
		public void delte_qt_matier()
		{

			foreach (DataGridViewRow row in grid_matier.Rows)
			{
				if (!row.IsNewRow)
				{
					// Récupérez les valeurs nécessaires de la ligne actuelle du DataGridView
					string idProduit = row.Cells["ر,م"].Value.ToString();
					int quantite_vnt = Convert.ToInt32(row.Cells["الكمية"].Value); // Assurez-vous de remplacer "nouvelle_quantite" par le nom réel de la colonne

					// Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit
					classMatier.edit_qt_table(idProduit, quantite_vnt);
				}
			}
		}
		public void insert_dechet()
		{

			foreach (DataGridViewRow row in grid_matier.Rows)
			{
				if (!row.IsNewRow)
				{
					// Récupérez les valeurs nécessaires de la ligne actuelle du DataGridView
					string idProduit = row.Cells["ر,م"].Value.ToString();
					int qt_dechet = Convert.ToInt32(row.Cells["كم مخ"].Value);
					string use = row.Cells["إ,ت"].Value.ToString(); ;// Assurez-vous de remplacer "nouvelle_quantite" par le nom réel de la colonne
					string etas = "غير مستخدم";
					decimal pricettl = decimal.Parse(row.Cells["التكلفة"].Value.ToString());
					decimal Qt_ttl = decimal.Parse(row.Cells["الكمية"].Value.ToString());
					decimal price_u = pricettl / Qt_ttl;
					decimal Cout_dechet = price_u * qt_dechet;
					// Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit
					if (use == "نعم")
					{
						classDechet.insert_dechet(idProduit, qt_dechet, etas, price_u, Cout_dechet);
					}
				}
			}
		}
		private void edit_comande_proforma_Load(object sender, EventArgs e)
		{

			//datagrid
			grid_tools.DataSource = classTools.get_tb_tools_commande();
			grid_matier.DataSource = classMatier.get_tb_matier();
			grid_sub_commande.DataSource = classSubCommande.get_tb_sub_commande_caisse(txt_id_commande.Text);
			//sum
			txtQtee.Text = classSubCommande.get_sum_Qt().ToString();
			txtTotalpriceHT.Text = classSubCommande.get_sum_money().ToString();
			cout_ttl_cmnd.Text = classSubCommande.get_sum_money_cout().ToString();

			//
			DataRowView drv = (DataRowView)cmb_client.SelectedItem;
			string sold_non_pays = drv["SOLD_NON_PAYE"].ToString();
			string Credit = drv["Sold_avance"].ToString();
			txtCredit.Text = Credit;

			lb_historique_credit.Text = sold_non_pays.ToString();
			calcule_credit_after(decimal.Parse(sold_non_pays.ToString()));
			lb_new_credit.Text = calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString();
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
		private void delletFromCaisse_matier()
		{
			DAL.DAL DAaL = new DAL.DAL();
			// SQL query
			string query = @"DELETE FROM [dbo].[TB_MATIER_USE_SUB_CMND_caise];";
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
		private void delletFromCaisse_tools()
		{
			DAL.DAL DAaL = new DAL.DAL();
			// SQL query
			string query = @"DELETE FROM [dbo].[TB_TOOLS_COMMANDE_caise];";
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
		private double calculeTmbr(double pric_befor_TTC, double tmbr)
		{
			double pric_after_TTC = pric_befor_TTC + (pric_befor_TTC * tmbr);
			return pric_after_TTC;
		}
		private void calculerest()
		{
			float total, rest, payes;
			total = float.Parse(txt_ttl_ttc.Text);
			payes = float.Parse(txtPricepayer.Text);
			rest = total - payes;
			txtreste.Text = rest.ToString();

		}
		#endregion
		private void grid_matier_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			form_plus.frm_add_divers_commade add_divers = new form_plus.frm_add_divers_commade();
			add_divers.id_type_edit_or_add = 0;
			add_divers.form_edit_commande = this;
			add_divers.id_commande = txt_id_commande.Text;
			add_divers.id_sub_commande = this.id_sub_commande;
			add_divers.ShowDialog();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			//
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				classSubCommande.delete_sub_comnd((int)this.grid_sub_commande.CurrentRow.Cells[0].Value);
				grid_sub_commande.DataSource = classSubCommande.get_tb_sub_commande_caisse(txt_id_commande.Text);
				MessageBox.Show("تمت عملية الحذف بنجاح");
			}
			txtQtee.Text = classSubCommande.get_sum_Qt().ToString();
			txtTotalpriceHT.Text = classSubCommande.get_sum_money().ToString();
			cout_ttl_cmnd.Text = classSubCommande.get_sum_money_cout().ToString();

			grid_sub_commande.DataSource = classSubCommande.get_tb_sub_commande_caisse(txt_id_commande.Text);
			txt_sub_name_commande.Text = "";
			txt_Quantite.Text = txt_prix_unite.Text = txt_prix_total.Text = cout_ttl.Text = "0";
		}

		private void button13_Click(object sender, EventArgs e)
		{
			classTools.add_TOOLS_COMMANDE(
				txt_tools.Text,
				txt_id_commande.Text
				);
			txt_tools.Text = "";
			grid_tools.DataSource = classTools.get_tb_tools_commande();
		}

		private void button11_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				classTools.delete_caisse_tools((int)this.grid_tools.CurrentRow.Cells[0].Value);
				grid_tools.DataSource = classTools.get_tb_tools_commande();
				MessageBox.Show("تمت عملية الحذف بنجاح");
			}
		}

		private void panel5_Paint(object sender, PaintEventArgs e)
		{

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
				decimal.Parse(cout_ttl.Text)
				);
			txtQtee.Text = classSubCommande.get_sum_Qt().ToString();
			txtTotalpriceHT.Text = classSubCommande.get_sum_money().ToString();
			cout_ttl_cmnd.Text = classSubCommande.get_sum_money_cout().ToString();

			grid_sub_commande.DataSource = classSubCommande.get_tb_sub_commande_caisse(txt_id_commande.Text);
			txt_sub_name_commande.Text = "";
			txt_Quantite.Text = txt_prix_unite.Text = txt_prix_total.Text = cout_ttl.Text = "0";
		}

		private void txt_prix_unite_TextChanged(object sender, EventArgs e)
		{
			txt_prix_total.Text = calcule_ttl_sub_cmnd(
				decimal.Parse(txt_prix_unite.Text),
				Convert.ToInt32(txt_Quantite.Text))
				.ToString();
		}

		private void txt_Quantite_TextChanged(object sender, EventArgs e)
		{
			txt_prix_total.Text = calcule_ttl_sub_cmnd(
				decimal.Parse(txt_prix_unite.Text),
				Convert.ToInt32(txt_Quantite.Text))
				.ToString();
		}

		private void grid_sub_commande_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			pn_cout.Enabled = true;
			id_sub_commande = (int)this.grid_sub_commande.CurrentRow.Cells[0].Value;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			//MessageBox.Show(id_sub_commande.ToString());
			if (check_recyvle.Checked == true)
			{
				delte = "نعم";
			}
			else if (check_recyvle.Checked == false)
			{
				delte = "لا";
			}
			total_sum = classMatier.get_total_(id_sub_commande);

			price_total_production = Convert.ToInt32(
				calcule_total_price(
				Convert.ToInt32(qt_matier.Text),
				decimal.Parse(price_matier.Text),
				Convert.ToInt32(qt_dechet.Text)
				)
			);

			classMatier.insert_TB_MATIER_USE_SUB_CMND
				(
				cmb_matier.SelectedValue.ToString(),
				id_sub_commande,
				Convert.ToInt32(qt_matier.Text),
				price_total_production,
				cmb_matier.Text,
				Convert.ToInt32(qt_dechet.Text),
				delte
				);
			total_sum = classMatier.get_total_(id_sub_commande);
			//MessageBox.Show(total_sum.ToString());

			classMatier.edit_cout_sub(
				id_sub_commande,
				total_sum
				);
			txtQtee.Text = classSubCommande.get_sum_Qt().ToString();
			txtTotalpriceHT.Text = classSubCommande.get_sum_money().ToString();
			cout_ttl_cmnd.Text = classSubCommande.get_sum_money_cout().ToString();

			grid_sub_commande.DataSource = classSubCommande.get_tb_sub_commande_caisse(txt_id_commande.Text);
			grid_matier.DataSource = classMatier.get_tb_matier();
			price_matier.Text = qt_dechet.Text = qt_matier.Text = "0";
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				classMatier.delte_matier((int)this.grid_matier.CurrentRow.Cells[0].Value);
				grid_matier.DataSource = classMatier.get_tb_matier();
				MessageBox.Show("تمت عملية الحذف بنجاح");
			}
			total_sum = classMatier.get_total_(id_sub_commande);
			MessageBox.Show(total_sum.ToString());

			classMatier.edit_cout_sub(
				id_sub_commande,
				total_sum
				);
			txtQtee.Text = classSubCommande.get_sum_Qt().ToString();
			txtTotalpriceHT.Text = classSubCommande.get_sum_money().ToString();
			cout_ttl_cmnd.Text = classSubCommande.get_sum_money_cout().ToString();

			grid_sub_commande.DataSource = classSubCommande.get_tb_sub_commande_caisse(txt_id_commande.Text);
			grid_matier.DataSource = classMatier.get_tb_matier();
			price_matier.Text = qt_dechet.Text = qt_matier.Text = "0";
		}

		private void button12_Click(object sender, EventArgs e)
		{
			detailes.frm_list_achat_by_produit list_achat = new detailes.frm_list_achat_by_produit();
			list_achat.frm_edit_commande = this;
			list_achat.id_type_edit_or_add = 0;
			list_achat.id_produit = cmb_matier.SelectedValue.ToString();
			list_achat.ShowDialog();
		}

		private void price_matier_TextChanged(object sender, EventArgs e)
		{
			calcule_total_price(
				Convert.ToInt32(qt_matier.Text),
				decimal.Parse(price_matier.Text),
				Convert.ToInt32(qt_dechet.Text)
				);
		}

		private void qt_matier_TextChanged(object sender, EventArgs e)
		{
			calcule_total_price(
				Convert.ToInt32(qt_matier.Text),
				decimal.Parse(price_matier.Text),
				Convert.ToInt32(qt_dechet.Text)
				);
		}

		private void qt_dechet_TextChanged(object sender, EventArgs e)
		{
			calcule_total_price(
				Convert.ToInt32(qt_matier.Text),
				decimal.Parse(price_matier.Text),
				Convert.ToInt32(qt_dechet.Text)
				);
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

		private void txtTotalpriceHT_TextChanged(object sender, EventArgs e)
		{
			txt_ttl_ttc.Text = calcule_TVA(
				decimal.Parse(txtTotalpriceHT.Text),
				decimal.Parse(txt_tva.Text)
				).ToString();
		}

		private void txt_tva_TextChanged(object sender, EventArgs e)
		{
			txt_ttl_ttc.Text = calcule_TVA(
				decimal.Parse(txtTotalpriceHT.Text),
				decimal.Parse(txt_tva.Text)
				).ToString();
		}

		private void txt_ttl_ttc_TextChanged(object sender, EventArgs e)
		{
			DataRowView drv = (DataRowView)cmb_client.SelectedItem;

			DataTable dt = new DataTable();
			DataRowView selectedRow = (DataRowView)cmb_client.SelectedItem;
			int id_client = Convert.ToInt32(selectedRow["ID"]);

			max_credit = decimal.Parse(drv["MAX_CREDIT"].ToString());
			string sold_non_pays = drv["SOLD_NON_PAYE"].ToString();
			calculerest();
			calcule_credit_after(decimal.Parse(sold_non_pays.ToString()));
			lb_new_credit.Text = calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString();
		}

		private void cmb_client_SelectedIndexChanged(object sender, EventArgs e)
		{
			DataRowView drv = (DataRowView)cmb_client.SelectedItem;

			DataTable dt = new DataTable();
			DataRowView selectedRow = (DataRowView)cmb_client.SelectedItem;
			int id_client = Convert.ToInt32(selectedRow["ID"]);
			get_notifictaniton(id_client);
			max_credit = decimal.Parse(drv["MAX_CREDIT"].ToString());
			string sold_non_pays = drv["SOLD_NON_PAYE"].ToString();
			string Credit = drv["Sold_avance"].ToString();
			Credit_avance = decimal.Parse(drv["Sold_avance"].ToString());
			txtCredit.Text = Credit;

			lb_historique_credit.Text = sold_non_pays.ToString();
			calcule_credit_after(decimal.Parse(sold_non_pays.ToString()));
			lb_new_credit.Text = calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString();
			//dt = prd44.search_produit_commande(id_client);
			//if (dt.Rows.Count > 0)
			//{
			//	MessageBox.Show("توجد ملاحظات خاصة بالزبون");
			//	pictureBox1.Image = Properties.Resources.notification;
			//}
			//else
			//{
			//	pictureBox1.Image = Properties.Resources.notificationv;
			//}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked == true)
			{
				dateTimePicker2.Enabled = true;
			}
			else if (checkBox1.Checked == false)
			{
				dateTimePicker2.Enabled = false;
			}
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			double? tmber;
			#region if
			if (checkBox1.Checked == true)
			{
				deadLineDate = dateTimePicker2.Value;
			}
			else if (checkBox1.Checked == false)
			{
				deadLineDate = null;
			}

			if (check_tmber.Checked == true)
			{
				tmber = 0.01;
			}
			else
			{
				tmber = null;
			}

			#endregion

			decimal total = decimal.Parse(txt_ttl_ttc.Text);
			decimal avance = decimal.Parse(txtCredit.Text);
			decimal rest_after = Check_max_credit(Sold_old_non_pay, decimal.Parse(txtreste.Text), max_credit);
			if (rest_after > max_credit)
			{
				DialogResult DT = MessageBox.Show("لا يمكنك المواصلة لانك تجاوزت سقف المبلغ المتبقي , هل تريد المواصلة ", "تم تجاوز سقف المبلغ المسموح", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				if (DT == DialogResult.OK)
				{
					MessageBox.Show("فشل في تسجيل الطلبية");
					this.Close();
				}
			}
			else
			{

				#region insert commande information
				class_edit_Commande.insert_new_commande
					(
					txt_id_commande.Text,
					dateTimePicker1.Value,
					txtname.Text,
					Convert.ToInt32(cmb_client.SelectedValue),
					cmb_tupe.Text,
					decimal.Parse(cout_ttl_cmnd.Text),
					decimal.Parse(txtPricepayer.Text),
					Convert.ToInt32(txtQtee.Text),
					"طلبية جديدة",
					decimal.Parse(txtTotalpriceHT.Text),
					decimal.Parse(txt_ttl_ttc.Text),
					float.Parse(txt_tva.Text),
					deadLineDate,
					"في طور الانجاز"
					, 1
					, tmber
					, textBox1.Text
					);


				#endregion

				#region checkbox _avance
				historique_Client.edit_sold_client_avance(
					Convert.ToInt32(cmb_client.SelectedValue),
					decimal.Parse(txtCredit.Text)
					);

				#endregion

				#region edit_sold_client
				historique_Client.edit_sold_client(
					Convert.ToInt32(cmb_client.SelectedValue),
					decimal.Parse(txtPricepayer.Text),
					decimal.Parse(lb_new_credit.Text),
					decimal.Parse(txt_ttl_ttc.Text)
					);
				#endregion

				#region add_historique_payement
				historique_Client.insert_history_client(
					dateTimePicker1.Value,
					Convert.ToInt32(cmb_client.SelectedValue),
                    decimal.Parse(txtPricepayer.Text),
                    decimal.Parse(txtPricepayer.Text),
					decimal.Parse(lb_historique_credit.Text),
					decimal.Parse(lb_new_credit.Text),
					"طلبية جديدة",
					""
					);
				#endregion

				insert_dechet();
				#region sendTotable_sub_cmd
				sendTotable_sub_cmd();
				#endregion

				#region sendTo_matier
				sendTotable_matier();
				#endregion

				#region sendTo tools
				sendTotable_tools();
				#endregion

				#region delete_qt
				delte_qt_matier();
				#endregion

				#region delete qt_use of matier _premier
				delletFromCaisse_matier();
				#endregion

				#region delete sub  
				delletFromCaisse_tb_sub_commande();
				#endregion

				#region dellete tools
				delletFromCaisse_tools();
				#endregion



				MessageBox.Show("تم تسجيل هذه الطلبية بنجاح");
				this.Close();

			}
		}

		private void check_avance_CheckedChanged(object sender, EventArgs e)
		{
			decimal total = decimal.Parse(txt_ttl_ttc.Text);
			decimal avance = decimal.Parse(txtCredit.Text);
			decimal reste = avance - total;
			decimal reste1 = total - avance;

			decimal rest_after = Check_max_credit(Sold_old_non_pay, decimal.Parse(txtreste.Text), max_credit);
			if (check_avance.Checked == true)
			{
				if (total >= avance)
				{
					txtPricepayer.Text = avance.ToString();
					txtCredit.Text = "0";
					txtreste.Text = reste1.ToString();
				}
				else if (total < avance)
				{
					decimal rest = avance - total;
					txtPricepayer.Text = total.ToString();
					txtCredit.Text = reste.ToString();
					//edit_client(avance
				}
			}
			if (check_avance.Checked == false)
			{
				DataRowView drv = (DataRowView)cmb_client.SelectedItem;
				string sold_non_pays = drv["SOLD_NON_PAYE"].ToString();
				string Credit = drv["Sold_avance"].ToString();
				txtCredit.Text = Credit;
				txtPricepayer.Text = "0";
				txtreste.Text = total.ToString();

			}
		}

		private void txtPricepayer_TextChanged(object sender, EventArgs e)
		{
			DataRowView drv = (DataRowView)cmb_client.SelectedItem;

			DataTable dt = new DataTable();
			DataRowView selectedRow = (DataRowView)cmb_client.SelectedItem;
			int id_client = Convert.ToInt32(selectedRow["ID"]);

			max_credit = decimal.Parse(drv["MAX_CREDIT"].ToString());
			string sold_non_pays = drv["SOLD_NON_PAYE"].ToString();
			calculerest();
			calcule_credit_after(decimal.Parse(sold_non_pays.ToString()));
			lb_new_credit.Text = calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString();
		}

		private void txtreste_TextChanged(object sender, EventArgs e)
		{
			DataRowView drv = (DataRowView)cmb_client.SelectedItem;

			DataTable dt = new DataTable();
			DataRowView selectedRow = (DataRowView)cmb_client.SelectedItem;
			int id_client = Convert.ToInt32(selectedRow["ID"]);

			max_credit = decimal.Parse(drv["MAX_CREDIT"].ToString());
			string sold_non_pays = drv["SOLD_NON_PAYE"].ToString();
			calculerest();
			calcule_credit_after(decimal.Parse(sold_non_pays.ToString()));
			lb_new_credit.Text = calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString();
		}

		private void label14_Click(object sender, EventArgs e)
		{
			frm_show_notifi_ not = new frm_show_notifi_();
			DataRowView selectedRow = (DataRowView)cmb_client.SelectedItem;
			int id_client = Convert.ToInt32(selectedRow["ID"]);
			not.id = id_client;
			not.ShowDialog();
		}

		private void check_tmber_CheckedChanged(object sender, EventArgs e)
		{
			decimal ttc_befor = calcule_TVA(
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

		private void edit_comande_proforma_FormClosing(object sender, FormClosingEventArgs e)
		{ 
			delletFromCaisse_tb_sub_commande(); 
			delletFromCaisse_matier(); 
			delletFromCaisse_tools();
		}

		private void txt_tva_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
			{
				e.Handled = true; // Prevent the character from being entered
			}
		}
	}
}
