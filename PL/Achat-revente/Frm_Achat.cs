using Smart_Production_Pos.PL.Achats;
using Smart_Production_Pos.PLADD.Achat_revente;
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

namespace Smart_Production_Pos.PL.Achat_revente
{
	public partial class Frm_Achat : Form
	{
		BL.BL_ACHAT_REVENT.BL_facture classFacture = new BL.BL_ACHAT_REVENT.BL_facture();
		BL.BL_ACHAT_REVENT.BL_ACHAT classAchat = new BL.BL_ACHAT_REVENT.BL_ACHAT(); 
		BL.BL_Achats.BL_Achats classAchats = new BL.BL_Achats.BL_Achats();
		BL.BL_ACHAT_REVENT.BL_calculate classCalculate = new BL.BL_ACHAT_REVENT.BL_calculate();
		BL.frnsre_history_sold class_frnsr_sold = new BL.frnsre_history_sold();
		DAL.DAL daoo;
		BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
		public int id_user;
		float Qt_add_pack;
        public DataTable productsTable = new DataTable("Products");
        public Frm_Achat()
		{
			InitializeComponent();
			dataGridView1.DataSource = classCalculate.get_Caisse_table();
			txt_id_fctr.Text = classCalculate.get_facture_number().ToString();
			lb_total_ht.Text = classCalculate.get_TOTAL_HT().ToString();
			lb_total_ttc.Text = classCalculate.get_TOTAL_TTC().ToString();
			txt_nmbre_produit.Text = classCalculate._nmbre_produit().ToString();
			cmbfrnse.DataSource = clasCombobox.getfrnsr();

			cmbfrnse.DisplayMember = "frnsr";
			cmbfrnse.ValueMember = "ID";

			cmb_product.DataSource = clasCombobox.get_combo_produit_prevent();
			cmb_product.DisplayMember = "designation";
			cmb_product.ValueMember = "CodeBarre";
			get_sold();
            productsTable.Columns.Add("codeBarre", typeof(string));
            productsTable.Columns.Add("achat pric HT", typeof(decimal));
            productsTable.Columns.Add("achat pric TTC", typeof(decimal));
            productsTable.Columns.Add("TVA", typeof(decimal));
            productsTable.Columns.Add("Quantite ajouter", typeof(float));
            productsTable.Columns.Add("prix vente 1", typeof(decimal));
            productsTable.Columns.Add("prix vente 2", typeof(decimal));
            productsTable.Columns.Add("prix vente 3", typeof(decimal));
            productsTable.Columns.Add("Quantite alert", typeof(float));
            productsTable.Columns.Add("Quantite  ithiyaj", typeof(float));
        }
		private decimal calcule_credit_after(decimal sold_old)
		{
			decimal sold_after = decimal.Parse(lb_total_ttc.Text) - decimal.Parse(txt_versement.Text);
			decimal soldnew = sold_old + sold_after;
			return soldnew;
		}

		public void get_sold()
		{
			int id_frnsrt = Convert.ToInt32(cmbfrnse.SelectedValue);
			DataTable Dt = new DataTable();
			Dt = classAchats.get_sold_frnser(id_frnsrt);
			if (Dt .Rows.Count> 0)
			{
				Object ID = Dt.Rows[0][0];
				Object sold_non_pays = Dt.Rows[0][8];
				lb_historique_credit.Text = sold_non_pays.ToString();
				calcule_credit_after(decimal.Parse(sold_non_pays.ToString()));
				lb_new_credit.Text = calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString();
			}
			
		}
		private void button7_Click(object sender, EventArgs e)
		{
			PLADD.Achat_revente.frm_add_achat add_achat = new PLADD.Achat_revente.frm_add_achat();
			add_achat.form_achat = this;
			add_achat.id_fctr = txt_id_fctr.Text; 
			add_achat.ShowDialog();
		}

		private void cmbfrnse_SelectedIndexChanged(object sender, EventArgs e)
		{
			DataRowView drv = (DataRowView)cmbfrnse.SelectedItem;
			string sold_non_pays = drv["SOLD_NON_PAYE"].ToString();
			lb_historique_credit.Text = sold_non_pays.ToString();
			calcule_credit_after(decimal.Parse(sold_non_pays.ToString()));
			lb_new_credit.Text = calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString();
		}
		private void send_toAchat()
		{
			DAL.DAL DAaL = new DAL.DAL();
			 
			string insertQuery = @"
			INSERT INTO [dbo].[TB_ACHAT_PRODUIT_REVENT]
			   (
				[ID]
			   ,[CODE_PRODUIT]
			   ,[QUANTITE]
			   ,[PRICE_ACHAT_HT]
			   ,[TVA]
			   ,[PRICE_ACHAT_TTC]
			   ,[TOTAL_HT]
			   ,[TOTAL_TTC]
			   ,[REMARQUE]
			   ,[ID_FACTURE]
			   ,[QUANTITE_BEFOR]
			   ,[QUANTITE_AFTER]
				)
			SELECT 
			   [ID]
			  ,[CODE_PRODUIT]
			  ,[QUANTITE]
			  ,[PRICE_ACHAT_HT]
			  ,[TVA]
			  ,[PRICE_ACHAT_TTC]
			  ,[TOTAL_HT]
			  ,[TOTAL_TTC]
			  ,[REMARQUE]
			  ,[ID_FACTURE]
			  ,[QUANTITE_BEFOR]
			  ,[QUANTITE_AFTER] 
		  FROM [dbo].[TB_ACHAT_PRODUIT_REVENT_CAISSE]";

			try
			{
				using (DAaL.sqlConnection)
				{
					DAaL.sqlConnection.Open();

					// Turn on identity insert
					//using (SqlCommand command = new SqlCommand(setIdentityOnQuery, DAaL.sqlConnection))
					//{
					//	command.ExecuteNonQuery();
					//}

					// Execute the insert query
					using (SqlCommand command = new SqlCommand(insertQuery, DAaL.sqlConnection))
					{
						int rowsAffected = command.ExecuteNonQuery(); 
					}

					// Turn off identity insert
					//using (SqlCommand command = new SqlCommand(setIdentityOffQuery, DAaL.sqlConnection))
					//{
					//	command.ExecuteNonQuery();
					//}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}
		private void delletFromCaisse()
		{
			DAL.DAL daoo = new DAL.DAL();
			SqlConnection sqlConnection = daoo.sqlConnection; 
			// SQL query
			string query = @"DELETE FROM [TB_ACHAT_PRODUIT_REVENT_CAISSE];"; 
			try
			{
				using (sqlConnection)
				{
					sqlConnection.Open();

					using (SqlCommand command = new SqlCommand(query, sqlConnection))
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

		private void txt_versement_TextChanged(object sender, EventArgs e)
		{
			try
			{
				get_sold();
			}
			catch
			{

			}
		}

		private void cmb_product_SelectedIndexChanged(object sender, EventArgs e)
		{
			DataRowView drv = (DataRowView)cmb_product.SelectedItem;

			string codeBare = drv["CodeBarre"].ToString();
			string Quantite_rest = drv["Quantite_rest"].ToString();
			string Qt_Dans_pack = drv["QT_DANS_PACK"].ToString();
			if (Qt_Dans_pack == "")
			{
				txt_qt_pack.Text = Qt_Dans_pack;
				txtBarcode.Text = codeBare.ToString();
				txt_qt_rest.Text = Quantite_rest.ToString();
			}
			else
			{ 
				txt_qt_pack.Text = Qt_Dans_pack;
				txtBarcode.Text = codeBare.ToString();
				txt_qt_rest.Text = Quantite_rest.ToString();
			}
			
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{

			if (MessageBox.Show("هذا الخيار سيقوم بحفظ الفاتورة هل انت متأكد", "عملية انشاء فاتورة  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				classFacture.InsertFactureAchatProduitRevent( 
					txt_id_fctr.Text,
					Convert.ToDateTime(kryptonDateTimePicker1.Value),
					Convert.ToInt32(cmbfrnse.SelectedValue),
					Convert.ToInt32(txt_nmbre_produit.Text),
					decimal.Parse(txt_versement.Text),
					decimal.Parse(lb_total_ttc.Text),
					id_user,
					decimal.Parse(lb_total_ht.Text),
					decimal.Parse(lb_historique_credit.Text),
					decimal.Parse(lb_new_credit.Text)
					);
				class_frnsr_sold.edit_sold_frnse(
					Convert.ToInt16(cmbfrnse.SelectedValue),
					decimal.Parse(lb_total_ttc.Text),
					decimal.Parse(txt_versement.Text),
					decimal.Parse(lb_new_credit.Text)
					);
				class_frnsr_sold.insert_history_frnsre(
					Convert.ToDateTime(kryptonDateTimePicker1.Value),
					Convert.ToInt32(cmbfrnse.SelectedValue),
					decimal.Parse(txt_versement.Text),
					decimal.Parse(lb_historique_credit.Text),
					decimal.Parse(lb_new_credit.Text), 
					txt_id_fctr.Text
                    );
				edit_information_apres_update(); 
                send_toAchat();
				delletFromCaisse();
				MessageBox.Show("تم انشاء الفاتورة وحفظها بنجاح");
				this.dataGridView1.DataSource = classCalculate.get_Caisse_table();
				txt_id_fctr.Text = classCalculate.get_facture_number().ToString();
				lb_total_ht.Text = classCalculate.get_TOTAL_HT().ToString();
				lb_total_ttc.Text = classCalculate.get_TOTAL_TTC().ToString();
				txt_nmbre_produit.Text = classCalculate._nmbre_produit().ToString();
			}
		}
		public void edit_information_apres_update()
		{
            foreach (DataRow row in productsTable.Rows)
            {
				decimal PriceHT_calculate, Price_TTC_calculte;
                string CodeBarre = row["codeBarre"].ToString();
                DateTime? date_expiration = null; // إذا كان لديك تاريخ انتهاء الصلاحية، يمكنك استخراج قيمته هنا
                decimal price_achat_HT = (decimal)row["achat pric HT"];
                decimal price_achat_TTC = (decimal)row["achat pric TTC"];
                float TVA = float.Parse(row["TVA"].ToString());
                float Quantite_shop = Convert.ToSingle(row["Quantite ajouter"]);
                decimal price_vente1 = (decimal)row["prix vente 1"];
                decimal price_vente2 = (decimal)row["prix vente 2"];
                decimal price_min = (decimal)row["prix vente 3"];
                float Quantite_alert = float.Parse(row["Quantite alert"].ToString());
                float ihtiyaj = float.Parse(row["Quantite  ithiyaj"].ToString());
				DataTable Dt_OLD_information = new DataTable();
				Dt_OLD_information = classAchat.get_Price_and_QT_OLD(CodeBarre);
				
				object OldPrice_Ht = Dt_OLD_information.Rows[0][0];
                object OldPrice_ttc = Dt_OLD_information.Rows[0][1];
                object QtRest = Dt_OLD_information.Rows[0][3];

				//Calcule PriceHT New 
				PriceHT_calculate = calcule_New_Price(
													  decimal.Parse(OldPrice_Ht.ToString()),
													  decimal.Parse(QtRest.ToString()),
                                                      decimal.Parse(price_achat_HT.ToString()),
                                                      decimal.Parse(Quantite_shop.ToString())
													  );
                //Calcule Price TTC new
                Price_TTC_calculte = calcule_New_Price(
                                                      decimal.Parse(OldPrice_ttc.ToString()),
                                                      decimal.Parse(QtRest.ToString()),
                                                      decimal.Parse(price_achat_TTC.ToString()),
                                                      decimal.Parse(Quantite_shop.ToString())
                                                      );

                // استدعاء الدالة مع القيم المستخرجة
                classAchat.update_QT_produit_prevent(
                    CodeBarre,
                    date_expiration,
                    PriceHT_calculate,
                    Price_TTC_calculte,
                    TVA,
                    Quantite_shop,
                    price_vente1,
                    price_vente2,
                    price_min,
                    Quantite_alert,
                    ihtiyaj
                );
            }

        }
        private void kryptonButton2_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				string type_achat = this.dataGridView1.CurrentRow.Cells["نوع الشراء"].Value.ToString();
				string idProduit = this.dataGridView1.CurrentRow.Cells["رقم المنتج"].Value.ToString();
				float quantite_achat = float.Parse(this.dataGridView1.CurrentRow.Cells["الكمية"].Value.ToString());
				float quantite_rest =  float.Parse(this.dataGridView1.CurrentRow.Cells["كمية المنتج بعد الشراء"].Value.ToString());
				float qte_rest_original = quantite_rest - quantite_achat;

				// Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit 
				if (type_achat == "تحديث كمية")
				{
					classAchat.edit_matier_on_caisse(idProduit, quantite_achat, qte_rest_original);
				}
				else if (type_achat == "شراء جديد")
                {
                    //classAchat.edit_qt_pack_achat_whene_delet(idProduit, quantite_achat);
                    classAchat.delet_pack_produit_revent(idProduit);
                    classAchat.delete_caisse_new_pro(idProduit);
                }
				classAchat.delete_caisse_product((int)this.dataGridView1.CurrentRow.Cells[0].Value);

				//delete_produit_revene_caisse
				MessageBox.Show("تم حذف عملية الشراء بنجاح");

				//
				txt_versement.Text = "0"; 
                this.dataGridView1.DataSource = classCalculate.get_Caisse_table();
				txt_id_fctr.Text = classCalculate.get_facture_number().ToString();
				lb_total_ht.Text = classCalculate.get_TOTAL_HT().ToString();
				lb_total_ttc.Text = classCalculate.get_TOTAL_TTC().ToString();
				txt_nmbre_produit.Text = classCalculate._nmbre_produit().ToString(); 
                get_sold();
            }
		}

		private decimal calcule_New_Price(decimal PriceOLd , decimal QtOld , decimal PriceNew , decimal Qt_new)
		{
			decimal PriceNew_Calculate = ((PriceOLd * QtOld) + (PriceNew * Qt_new)) / (QtOld + Qt_new); 
			return PriceNew_Calculate;
		}

		private void txt_rmrq_Click(object sender, EventArgs e)
		{
			float qt_after = float.Parse(txt_qt.Text) + float.Parse(txt_qt_rest.Text);
			DateTime? datePeretion = null;
			if (check_date_expiration.Checked == true)
			{
				datePeretion = Convert.ToDateTime(date_expiration.Value);
			}
			else
			{
				datePeretion = null;
			} 
			classAchat.InsertAchatProduitReventCaisse(
					txtBarcode.Text,
					float.Parse(txt_qt.Text),
					decimal.Parse(txt_achat_ht.Text),
					float.Parse(txt_tva.Text),
					decimal.Parse(txt_achat_ttc.Text),
					decimal.Parse(txt_total_ht.Text),
					decimal.Parse(txt_total_ttc.Text),
					txt_rmrq.Text,
					txt_id_fctr.Text,
					float.Parse(txt_qt_rest.Text),
					qt_after,
					"تحديث كمية"
				);
			//classAchat.update_QT_produit_prevent( 
			//		txtBarcode.Text,
			//		datePeretion, 
			//		decimal.Parse(txt_achat_ht.Text),
			//		decimal.Parse(txt_achat_ttc.Text),
			//		float.Parse(txt_tva.Text),
			//		float.Parse(txt_qt.Text) 
			//		);
			if (txt_qt_pack.Text != "")
			{
				if (float.Parse(txt_qt_pack.Text) > 0)
				{
					Qt_add_pack = float.Parse(txt_qt_pack.Text) * float.Parse(txt_qt.Text);
					classAchat.edit_qt_pack_achat(
						txtBarcode.Text,
						Qt_add_pack
						);
				}
			}
			dataGridView1.DataSource = classCalculate.get_Caisse_table();
			txt_id_fctr.Text = classCalculate.get_facture_number().ToString();
			lb_total_ht.Text = classCalculate.get_TOTAL_HT().ToString();
			lb_total_ttc.Text = classCalculate.get_TOTAL_TTC().ToString();
			txt_nmbre_produit.Text = classCalculate._nmbre_produit().ToString();
			get_sold();
		}

		private void check_date_expiration_CheckedChanged(object sender, EventArgs e)
		{
			if (check_date_expiration.Checked == true)
			{
				date_expiration.Enabled = true;
			}
			else if (check_date_expiration.Checked == false)
			{
				date_expiration.Enabled = false;
			}
		}

		private void txt_qt_TextChanged(object sender, EventArgs e)
		{
			txt_total_ht.Text = _calcule_total(decimal.Parse(txt_achat_ht.Text),decimal.Parse(txt_qt.Text)).ToString();
			txt_total_ttc.Text = _calcule_total(decimal.Parse(txt_achat_ttc.Text), decimal.Parse(txt_qt.Text)).ToString();
		}
		public decimal calcule_TVA(decimal PrixeTTc, decimal TVA)
		{
			decimal priceHT = PrixeTTc / (1 + (TVA / 100));
			priceHT = Math.Round(priceHT, 2);
			return priceHT;
		}
		public decimal _calcule_total(decimal price, decimal QT)
		{
			decimal total = price * QT;
			return total;
		}
		private void txt_achat_ht_TextChanged(object sender, EventArgs e)
		{ 
			txt_total_ht.Text = _calcule_total(decimal.Parse(txt_achat_ht.Text), decimal.Parse(txt_qt.Text)).ToString();
		}

		private void txt_tva_TextChanged(object sender, EventArgs e)
		{
			txt_achat_ht.Text = calcule_TVA(decimal.Parse(txt_achat_ttc.Text), decimal.Parse(txt_tva.Text)).ToString();
		}

		private void txt_achat_ttc_TextChanged(object sender, EventArgs e)
		{
			txt_achat_ht.Text = calcule_TVA(decimal.Parse(txt_achat_ttc.Text), decimal.Parse(txt_tva.Text)).ToString();
			txt_total_ttc.Text = _calcule_total(decimal.Parse(txt_achat_ttc.Text), decimal.Parse(txt_qt.Text)).ToString();
		}

		private void Frm_Achat_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (dataGridView1.RowCount > 0)
				{
					foreach (DataGridViewRow row in dataGridView1.Rows)
					{
						if (!row.IsNewRow)
						{
							// Assuming that type_achat, idProduit, quantite_achat, and qte_rest_original
							// are columns in your DataGridView, you can get their values like this:
							string type_achat = row.Cells["نوع الشراء"].Value.ToString();
							string idProduit = row.Cells["رقم المنتج"].Value.ToString();
							float quantite_achat = float.Parse(row.Cells["الكمية"].Value.ToString());
							float quantite_rest = float.Parse(row.Cells["كمية المنتج بعد الشراء"].Value.ToString());
							float qte_rest_original = quantite_rest - quantite_achat;

							// Apply your logic
							if (type_achat == "تحديث كمية")
							{
								classAchat.edit_matier_on_caisse(idProduit, quantite_achat, qte_rest_original);
							}
							else if (type_achat == "شراء جديد")
							{
								classAchat.delete_caisse_new_pro(idProduit);
								classAchat.edit_qt_pack_achat_whene_delet(idProduit, quantite_achat);
							}
							classAchat.delete_caisse_product((int)row.Cells[0].Value); 
						}
					}  
				} 
			}
            else 
            {
                e.Cancel = true;
            }
		}

        private void txt_nmbre_produit_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
			frm_add_on_Stock add_on_Stock = new frm_add_on_Stock(); 
           
            add_on_Stock.frm_Achat_caisse = this;
			add_on_Stock.id_facture = txt_id_fctr.Text; 
            add_on_Stock.ShowDialog();
        }
    }
}
