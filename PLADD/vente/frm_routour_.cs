using iTextSharp.text.pdf;
using Smart_Production_Pos.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.vente
{
	public partial class frm_routour_ : Form
	{
		BL.BL_CAISSE caisseVente_classe = new BL.BL_CAISSE();
		BL.BL_PRODUCTION.BL_GESTION_PRODUIT_FINAUX ClassProduction = new BL.BL_PRODUCTION.BL_GESTION_PRODUIT_FINAUX();
		BL.BL_ACHAT_REVENT.BL_PRODUIT classProduit = new BL.BL_ACHAT_REVENT.BL_PRODUIT();
		BL.BL_vente.BL_vente_Fonction classVente = new BL.BL_vente.BL_vente_Fonction();
		BL.Client_history_sold historique_Client = new BL.Client_history_sold();
		BL.BL_vente.BL_SP_LOGINE_Caisse classCaisse = new BL.BL_vente.BL_SP_LOGINE_Caisse();
		BL.BL_vente.bl_diminuer_la_Qt_vente classQt_vente = new BL.BL_vente.bl_diminuer_la_Qt_vente();
		float Money_Achat_u;
		public int ID_historique;
		float Money_Achat_TTL;
		public int ID_CAISSIER, 	id_usser;
		BL.BL_COMBOBOX Bl_combobox = new BL.BL_COMBOBOX();
        string barcode;
        decimal Price;
		public frm_vente_caisse form_caisse ;
        public frm_routour_()
		{
			InitializeComponent();

            cmbProduct.DataSource = Bl_combobox.get_combo_produit_prevent();
            cmbProduct.DisplayMember = "designation";
            cmbProduct.ValueMember = "CodeBarre";

            clientCmb.DataSource = Bl_combobox.get_combo_client();
			clientCmb.DisplayMember = "Client";
			clientCmb.ValueMember = "ID";

            cmb_Client.DataSource = Bl_combobox.get_combo_client();
            cmb_Client.DisplayMember = "Client";
            cmb_Client.ValueMember = "ID";

        }

		public void getinformation_matier_revent(string CodeBarrre)
		{ 
			DataTable Dt = new DataTable();
			Dt = caisseVente_classe.getSold_MAtier_revent(CodeBarrre);
			if (Dt.Rows.Count > 0)
			{
				Object codeBarre = Dt.Rows[0][0];
				Object name_product = Dt.Rows[0][1];
				Object price_Vente = Dt.Rows[0][15];
				Object Quanite_dans_pack = Dt.Rows[0][24];
				Object price_achat_produit_revent = Dt.Rows[0]["price_achat_TTC"];
				txt_name.Text = name_product.ToString();
				txt_vente_U.Text = price_Vente.ToString();
				txt_vnt_ttl.Text = (float.Parse(price_Vente.ToString()) * float.Parse(kryptonTextBox1.Text)).ToString();
				Money_Achat_u = float.Parse(price_achat_produit_revent.ToString());
			}
			else if (Dt.Rows.Count == 0)
			{
				Dt = caisseVente_classe.select_produit_fabrique(CodeBarrre);
				if (Dt.Rows.Count > 0)
				{
					Object codeBarre = Dt.Rows[0][0];
					Object name_product = Dt.Rows[0][1];
					Object price_Vente = Dt.Rows[0][11];
					Object Quanite_dans_pack = Dt.Rows[0][6];
					Object cout_de_prodution = Dt.Rows[0][5];
					txt_name.Text = name_product.ToString();
				}
				else if (Dt.Rows.Count == 0)
				{
					Dt = caisseVente_classe.select_pack_info(CodeBarrre);
					if (Dt.Rows.Count > 0)
					{

						Object codeBarre = Dt.Rows[0][0];
						Object name_product = Dt.Rows[0][1];
						Object price_Vente = Dt.Rows[0][4];
						Object price_Achat = Dt.Rows[0][7];
						Object Qt_dans_pack = Dt.Rows[0][8];
						txt_name.Text = name_product.ToString();
						txt_vente_U.Text = price_Vente.ToString();
						txt_vnt_ttl.Text = (float.Parse(price_Vente.ToString()) * float.Parse(kryptonTextBox1.Text)).ToString();
						Money_Achat_u = (float.Parse(Qt_dans_pack.ToString()) * float.Parse(price_Achat.ToString()));
						Money_Achat_TTL = (float.Parse(kryptonTextBox1.Text)) * (Money_Achat_u);
					}
					else if (Dt.Rows.Count == 0)
					{
						Dt = caisseVente_classe.select_pack_Produit_finaux_info(CodeBarrre);
						if (Dt.Rows.Count > 0)
						{

							Object codeBarre = Dt.Rows[0][0];
							Object name_product = Dt.Rows[0][1];
							Object price_Vente = Dt.Rows[0][4];
							Object coutTTL = Dt.Rows[0][8];
							Object qt_dans_pack = Dt.Rows[0][9];
							txt_name.Text = name_product.ToString();

						}
						else if (Dt.Rows.Count == 0)
						{
							Dt = caisseVente_classe.select_produit_by_code_barre_reserve(CodeBarrre);
							if (Dt.Rows.Count > 0)
							{

								Object codeBarre = Dt.Rows[0][0];
								Object name_product = Dt.Rows[0][1];
								Object price_Vente = Dt.Rows[0][2]; 
								txt_name.Text = name_product.ToString();
								//MessageBox.Show("هذا المنتوج غير موجود في قاعدة البيانات");
							}
							else if (Dt.Rows.Count == 0)
							{
								//
								Dt = caisseVente_classe.get_information_by_code_Reserve_pack(CodeBarrre);
								if (Dt.Rows.Count > 0)
								{ 
									Object codeBarre = Dt.Rows[0][0];
									Object name_product = Dt.Rows[0][1];
									Object price_Vente = Dt.Rows[0][2];
									txt_name.Text = name_product.ToString(); 
								}

								//
							}
						}
					}
				}
			}
			 
		}

		private void txt_code_barre_MouseDown(object sender, MouseEventArgs e)
		{
			
		}

		private void txt_code_barre_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				getinformation_matier_revent(txt_code_barre.Text);
			} 
		}
		private decimal calcule_credit_after(decimal sold_old)
		{
			decimal sold_after = decimal.Parse(txt_vnt_ttl.Text);
			decimal soldnew = sold_old - sold_after;
			return soldnew;
		}
		private void clientCmb_SelectedIndexChanged(object sender, EventArgs e)
		{
			DataRowView drv = (DataRowView)clientCmb.SelectedItem;
			string sold_non_pays = drv["SOLD_NON_PAYE"].ToString();
			lb_historique_credit.Text = sold_non_pays.ToString();
			calcule_credit_after(decimal.Parse(sold_non_pays.ToString()));
			lb_new_credit.Text = calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString();
		}
		private decimal calculeRest(decimal ttl, decimal verse)
		{
			decimal rest = ttl - verse;
			return rest;
		}
		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{
			try
			{

                txt_vnt_ttl.Text = calcule_TTL_vnt(float.Parse(txt_vente_U.Text),
                    float.Parse(kryptonTextBox1.Text)).ToString();
            }
			catch
			{

			}
		}
		private float calcule_TTL_vnt(float pric_U , float QT)
		{
			float ttl = pric_U * QT;
			return ttl;
		}
		private void txt_vnt_ttl_TextChanged(object sender, EventArgs e)
		{

		}

        private void txt_code_barre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTN9_Click(object sender, EventArgs e)
        {
			this.Close();
        }

        private void pack_check_produit_revent_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Bl_combobox.pack_produit_prevent();
			if (dt.Rows.Count > 0)
			{
                cmbProduct.DataSource = Bl_combobox.pack_produit_prevent();
                cmbProduct.DisplayMember = "pack_designation";
                cmbProduct.ValueMember = "pack_code_barre";
            }
			
        }

        private void check_produit_revent_CheckedChanged(object sender, EventArgs e)
        {
			DataTable dt = new DataTable();
			dt= Bl_combobox.get_combo_produit_prevent();
			if (dt.Rows.Count > 0)
            {
                cmbProduct.DataSource = Bl_combobox.get_combo_produit_prevent();
                cmbProduct.DisplayMember = "designation";
                cmbProduct.ValueMember = "CodeBarre";
			}
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
			this.Close();
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)cmbProduct.SelectedItem;
			
            if (check_produit_revent.Checked == true)
            {
                 barcode = drv["CodeBarre"].ToString();
                 Price = decimal.Parse(drv["price_vente1"].ToString()); 
            }
			else
			{
                DataTable dt = new DataTable();
                dt = Bl_combobox.pack_produit_prevent();
                if (dt.Rows.Count > 0)
                {
                    barcode = drv["pack_code_barre"].ToString();
                    Price = decimal.Parse(drv["price_unitair"].ToString());
                }

            }
            txt_produit_codeBarre.Text = barcode.ToString();
			txt_Price_unitaire.Text = Price.ToString();
            getinformation_matier_revent(txt_produit_codeBarre.Text);

        }

        private void cmb_Client_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)clientCmb.SelectedItem;
            string sold_non_pays = drv["SOLD_NON_PAYE"].ToString();
            lb_Old_Price.Text = sold_non_pays.ToString();
            calcule_credit_after(decimal.Parse(sold_non_pays.ToString()));
            lb_New_Price.Text = calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString();
        }

        private void txt_vente_U_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Qt_TextChanged(object sender, EventArgs e)
        {
			try
			{
                txt_Total_Price.Text = calcule_TTL_vnt(float.Parse(txt_Price_unitaire.Text),
                    float.Parse(txt_Qt.Text)).ToString();
            }
			catch
			{

			}
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
			//حساب التكلفة الكلية
            Money_Achat_TTL = (float.Parse(txt_Qt.Text)) * (Money_Achat_u);
			
			//البحث عن الكودبار
            DateTime currentDateTime = DateTime.Now;
            DialogResult Dg = MessageBox.Show("هل انت متاكد من هذا الاختيار", "تعديل في الفاتورة", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Dg == DialogResult.Yes)
            {
                //update_qt_stock
                classQt_vente.update_QT_apres_routour(
                    txt_produit_codeBarre.Text,
                    float.Parse(txt_Qt.Text));


                //add_historique_ routoue
                classQt_vente.insert_routour_historique(
                    txt_produit_codeBarre.Text,
                    float.Parse(txt_Qt.Text),
                    ID_CAISSIER,
                    id_usser,
                    Convert.ToDateTime(DateTime.Today.ToString()),
                    currentDateTime.TimeOfDay,
                    decimal.Parse(txt_Price_unitaire.Text),
                    decimal.Parse(txt_Total_Price.Text),
                    decimal.Parse(Money_Achat_TTL.ToString())
                    );


                //add_historique_client
                historique_Client.insert_history_client(
                        Convert.ToDateTime(DateTime.Today.ToString()),
                        Convert.ToInt32(cmb_Client.SelectedValue),
                        - decimal.Parse(txt_Total_Price.Text),
                        - decimal.Parse(txt_Total_Price.Text),
                        decimal.Parse(lb_Old_Price.Text),
                        decimal.Parse(lb_New_Price.Text),
                        "ارجاع سلعة",
						""
                        );
                //update Client 
                historique_Client.edit_sold_client(
                        Convert.ToInt32(cmb_Client.SelectedValue),
                        decimal.Parse(txt_Total_Price.Text),
                        decimal.Parse(lb_New_Price.Text),
                        -decimal.Parse(txt_Total_Price.Text)
                        );
                classCaisse.update_history_caissier(
                    ID_historique,
                    currentDateTime.TimeOfDay,
                    -decimal.Parse(txt_Total_Price.Text)
                    );
            }
            this.Close();
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
		{

            Money_Achat_TTL = (float.Parse(kryptonTextBox1.Text)) * (Money_Achat_u); 
			DateTime currentDateTime = DateTime.Now;
			DialogResult Dg = MessageBox.Show("هل انت متاكد من هذا الاختيار", "تعديل في الفاتورة", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (Dg == DialogResult.Yes)
			{
				//update_qt_stock
				classQt_vente.update_QT_apres_routour(
					txt_code_barre.Text,
					float.Parse(kryptonTextBox1.Text));
				//add_historique_ routoue
				classQt_vente.insert_routour_historique(
					txt_code_barre.Text,
					float.Parse(kryptonTextBox1.Text),
					ID_CAISSIER,
					id_usser,
					Convert.ToDateTime(DateTime.Today.ToString()),
					currentDateTime.TimeOfDay,
					decimal.Parse(txt_vente_U.Text),
					decimal.Parse(txt_vnt_ttl.Text),
					decimal.Parse(Money_Achat_TTL.ToString()) 
					) ;
				//add_historique_client
				historique_Client.insert_history_client(
						Convert.ToDateTime(DateTime.Today.ToString()),
						Convert.ToInt32(clientCmb.SelectedValue),
                        -decimal.Parse(txt_vnt_ttl.Text),
                        - decimal.Parse(txt_vnt_ttl.Text),
						decimal.Parse(lb_historique_credit.Text),
						decimal.Parse(lb_new_credit.Text),
						"ارجاع سلعة",
						""
						);
				//update Client 
				historique_Client.edit_sold_client(
						Convert.ToInt32(clientCmb.SelectedValue),
						decimal.Parse(txt_vnt_ttl.Text),
						decimal.Parse(lb_new_credit.Text),
						- decimal.Parse(txt_vnt_ttl.Text)
						); 
				classCaisse.update_history_caissier(
					ID_historique,
					currentDateTime.TimeOfDay,
					- decimal.Parse(txt_vnt_ttl.Text)
					);
			}
			form_caisse.txt_barcode.Focus();
            this.Close();
		}
	}
}
