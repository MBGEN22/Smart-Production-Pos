using Microsoft.Office.Interop.Excel;
using Smart_Production_Pos.BL;
using Smart_Production_Pos.BL.BL_FICHIER;
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

namespace Smart_Production_Pos.PLADD.Fichier
{
	public partial class frm_add_user : Form
	{
		BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
		BL.BL_FICHIER.BL_user ClassUSer = new BL.BL_FICHIER.BL_user();
		public PL.Fichier.frm_user frm_uuser;
        Sp_Logine classLogine = new Sp_Logine();
        public int id;

		int  Stock                          = 0        ;
		 int unite							=0;
		 int categorie					=0;
		 int marque						=0;
		 int favoris						=0;
		 int taille=						0;
		 int color =						 0;
		 int fournisseure				=0 ;
		 int ouverier						=0 ;
		 int users							=0	 ;
		 int caissier						=0	 ;
		 int client							=0	 ;
		 int historique_client		=0 ;
		 int remarque					=0	 ;
		 int achat							=0	 ;
		 int facture_achat			=0	 ;
		 int dossier_fctr_achat=	0	 ;
		 int historique_frnsre	=0	 ;
		 int stock_produit			=0	 ;
		 int pack							=0	 ;
		 int facture_vente			=0	 ;
		 int list_vente					=0	 ;
		 int liv								=0	 ;
		 int POS								=0 ;
		 int les_charge					=0 ;
		 int lapie							=0	 ;
		 int transition_caissier =	0  ;
		 int state_total					=0 ;
		 int benifice						=0	 ;
		 int serverss						=0 ;
		 int facture_info				=0	 ;
         
        public frm_add_user()
		{
			InitializeComponent();
			kryptonComboBox1.DataSource = clasCombobox.get_combo_ouverier();
			kryptonComboBox1.DisplayMember = "Name";
			kryptonComboBox1.ValueMember = "ID";

        }

		private void kryptonButton4_Click(object sender, EventArgs e)
		{



            if (chech_stock.Checked == true) { Stock = 1; }
            if (check_fav.Checked == true) { unite = 1; }
            if (check_marque.Checked == true) { marque = 1; }
            if (check_categori.Checked == true) { categorie = 1; }
            if (check_unite.Checked == true) { unite = 1; }
            if (check_taille.Checked == true) { taille = 1; }
            if (check_color.Checked == true) { color = 1; }
            if (check_ouverier.Checked == true) { ouverier = 1; }
            if (check_frnsre.Checked == true) { fournisseure = 1; }
            if (check_user.Checked == true) { users = 1; }
            if (check_caissier.Checked == true) { caissier = 1; }
            if (check_remarque_client.Checked == true) { remarque = 1; }
            if (check_historique_client.Checked == true) { historique_client = 1; }
            if (check_client.Checked == true) { client = 1; }
            if (check_historique_frnsre.Checked == true) { historique_frnsre = 1; }
            if (check_dossier_achat.Checked == true) { dossier_fctr_achat = 1; }
            if (check_fctr_achat.Checked == true) { facture_achat = 1; }
            if (check_achat.Checked == true) { achat = 1; }
            if (check_pack.Checked == true) { pack = 1; }
            if (check_stock.Checked == true) { stock_produit = 1; }
            if (check_pos.Checked == true) { POS = 1; }
            if (check_liv.Checked == true) { liv = 1; }
            if (check_liste_vente.Checked == true) { list_vente = 1; }
            if (check_facture_vente.Checked == true) { facture_vente = 1; }
            if (check_benifice.Checked == true) { benifice = 1; }
            if (check_stategenerale.Checked == true) { state_total = 1; }
            if (check_transisition.Checked == true) { transition_caissier = 1; }
            if (check_paie.Checked == true) { lapie = 1; }
            if (check_depense.Checked == true) { les_charge = 1; }
            if (check_info_fctr.Checked == true) { facture_info = 1; }
            if (check_server.Checked == true) { serverss = 1; }

            DAL.DAL DAL = new DAL.DAL();
			SqlConnection connectionString;
			connectionString = DAL.sqlConnection;
			if (kryptonButton4.Text == "حفظ واعادة تشغيل")
			{
				if (cmb_type.Text == "")
				{
					MessageBox.Show("يرجى اولا ادخال معلومات الحساب");
				}
				else if (kryptonComboBox1.Text == "")
				{
					MessageBox.Show("من فضلك قم بادخال عامل على الاقل لربطه بالمستخدم");
				}
                else if (txtrecupiration.Text == "")
                {
                    MessageBox.Show("من فضلك قم بادخال كود الاستعادة فهذا ضروري");
                }
                else
				{
					ClassUSer.Add_Funct( 
					Convert.ToInt32(kryptonComboBox1.SelectedValue),
					txt_user.Text,
					txt_pass.Text,
					"مسؤول",
					"OFF",
                    txtrecupiration.Text
					,1 
					,1
					,1
					,1
					,1
					,1
					,1
					,1	
					,1	
					,1
					,1
					,1
					,1	
					,1
					,1
					,1
					,1
					,1
					,1
					,1
					,1
					,1
					,1
					,1	
					,1	
					,1
					,1 
					,1	
					,1	
					,1	
					,1
                    );

					string query = "SELECT COUNT(*) FROM TB_FAVORIS";
					string QCLIET = "SELECT COUNT(*) FROM TB_CLIENT";
					string QFRNSRE = "SELECT COUNT(*) FROM TB_FOURNISSUER";
					string TB_PARAMETRE_INFO = "SELECT COUNT(*) FROM TB_PARAMETRE_INFO"; 
                    string TB_Caisse = "SELECT COUNT(*) FROM TB_INFO_CAISSIER";
                    using (connectionString)
					{
						connectionString.Open();

						// Check TB_FAVORIS
						SqlCommand command = new SqlCommand(query, connectionString);
						int Count_FAV = (int)command.ExecuteScalar();
						if (Count_FAV == 0)
						{
							for (int i = 1; i <= 15; i++)
							{
								string insertQuery = "INSERT INTO TB_FAVORIS (FAVOIRE) VALUES (@FAV)";
								using (SqlCommand insertCommand = new SqlCommand(insertQuery, connectionString))
								{
									insertCommand.Parameters.AddWithValue("@FAV", "FAV" + i);
									insertCommand.ExecuteNonQuery();
								}
							}
						}

						// Check TB_CLIENT
						SqlCommand cmd_client = new SqlCommand(QCLIET, connectionString);
						int count_client = (int)cmd_client.ExecuteScalar();
						if (count_client == 0)
						{
							string insertClientQuery = @"
												INSERT INTO [dbo].[TB_CLIENT]
													([NAME]
													,[PRENAME]
													,[PHONE]
													,[FAX]
													,[EMAIL]
													,[SOLD_TOTAL]
													,[SOLD_PAYE]
													,[SOLD_NON_PAYE]
													,[ADRESSE]
													,[Sold_avance]
													,[MAX_CREDIT]
													,[NIF]
													,[RC]
													,[Nic]
													,[article]
													,[originale_name_prename])
												VALUES
													(@NAME
													,@PRENAME
													,NULL
													,NULL
													,NULL
													,0
													,0
													,0
													,NULL
													,0
													,0
													,NULL
													,NULL
													,NULL
													,NULL
													,NULL)";

							using (SqlCommand insertCommand = new SqlCommand(insertClientQuery, connectionString))
							{
								insertCommand.Parameters.AddWithValue("@NAME", "مجهول");
								insertCommand.Parameters.AddWithValue("@PRENAME", "مجهول");
								insertCommand.ExecuteNonQuery();
							}
						}


						// Check TB_FOURNISSUER
						SqlCommand cmd_frnsre = new SqlCommand(QFRNSRE, connectionString);
						int count_frnsre = (int)cmd_frnsre.ExecuteScalar();
						if (count_frnsre == 0)
						{
							string insertSupplierQuery = @"
								INSERT INTO [dbo].[TB_FOURNISSUER]
									([NAME], [PRENAME], [PHONE], [FAX], [EMAIL], [SOLD_TOTAL], [SOLD_PAYE], 
									 [SOLD_NON_PAYE], [ADRESSE], [NIF], [RC], [Nic], [article], 
									 [originale_name_prename])
								VALUES
									(@NAME, @PRENAME, NULL, NULL, NULL, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL)";

							using (SqlCommand insertSupplierCommand = new SqlCommand(insertSupplierQuery, connectionString))
							{
								insertSupplierCommand.Parameters.AddWithValue("@NAME", "مجهول");
								insertSupplierCommand.Parameters.AddWithValue("@PRENAME", "مجهول");
								insertSupplierCommand.ExecuteNonQuery();
							}
						}


						// Check TB_PARAMETRE_INFO
						SqlCommand cmdParemtre = new SqlCommand(TB_PARAMETRE_INFO, connectionString);
						int CounteParamtre = (int)cmdParemtre.ExecuteScalar();
						if (CounteParamtre == 0)
						{

							string insert_paremtre = @"
							 INSERT INTO [dbo].[TB_PARAMETRE_INFO]
											   ([NAME]
											   ,[PRENAME]
											   ,[ADRESS]
											   ,[ACTIVITY]
											   ,[NMR_REGISTRE]
											   ,[NMR_MATIER]
											   ,[NMR_JIBAI]
											   ,[LOGO]
											   ,[WILAYA]
											   ,[CompanyName]
												,Phone
												,Message
											   , PRINT_FACTURE
											   , PRINT_BON
											   , PRINT_BON_A4
											   , DONT_PRINT
											  , [DAY_AVANT_PEREPRTION]
												)
										 VALUES
											   (
												@NAME
											   ,@PRENAME
												,NULL
												,NULL
												,NULL
												,NULL
												,NULL
												,NULL
												,NULL
												,NULL
												,NULL
												,@Message
												,@PRINT_FACTURE
												,@PRINT_BON
												,@PRINT_BON_A4
												,@DONT_PRINT
												,@DAY_AVANT_PEREPRTION
											   )";

							using (SqlCommand insert_paremtreCmd = new SqlCommand(insert_paremtre, connectionString))
							{
								insert_paremtreCmd.Parameters.AddWithValue("@NAME", "Bestha");
								insert_paremtreCmd.Parameters.AddWithValue("@PRENAME", "Smart");
								insert_paremtreCmd.Parameters.AddWithValue("@Message", "شكرا لثقتك بنا");
                                insert_paremtreCmd.Parameters.AddWithValue("@PRINT_FACTURE", "false");
                                insert_paremtreCmd.Parameters.AddWithValue("@PRINT_BON", "false");
                                insert_paremtreCmd.Parameters.AddWithValue("@PRINT_BON_A4", "false");
                                insert_paremtreCmd.Parameters.AddWithValue("@DONT_PRINT", "true");
                                insert_paremtreCmd.Parameters.AddWithValue("@DAY_AVANT_PEREPRTION", 15);
                                insert_paremtreCmd.ExecuteNonQuery();
							}
						}

                        // Check TB_INFO_CAISSIER
                        SqlCommand cmdCaisse = new SqlCommand(TB_Caisse, connectionString);
                        int CounteCaisse = (int)cmdCaisse.ExecuteScalar();
                        if (CounteCaisse == 0)
                        {

                            string insert_paremtre = @"
							 INSERT INTO [dbo].[TB_INFO_CAISSIER]
                                   ([NAME]
                                   ,[PRENAME]
                                   ,[USER-NAME]
                                   ,[PASSW])
                             VALUES
                                   (@Name
                                   ,@PRENAME 
                                   ,@USERNAME 
                                   ,@PASSW 
                                    )";

                            using (SqlCommand insert_paremtreCmd = new SqlCommand(insert_paremtre, connectionString))
                            {
                                insert_paremtreCmd.Parameters.AddWithValue("@NAME", kryptonComboBox1.Text);
                                insert_paremtreCmd.Parameters.AddWithValue("@PRENAME", "");
                                insert_paremtreCmd.Parameters.AddWithValue("@USERNAME", txt_user.Text);
                                insert_paremtreCmd.Parameters.AddWithValue("@PASSW", txt_pass.Text); 
                                insert_paremtreCmd.ExecuteNonQuery();
                            }
                        }


                        MessageBox.Show("تم حفظ ادخال معلومات الحساب بنجاح");
						this.Close();
						//frm_uuser.dataGridView1.DataSource = ClassUSer.select_user_();



					}
				}
			}
			else
			{
				if (id > 0)
				{
					if (cmb_type.Text == "")
					{
						MessageBox.Show("يرجى اولا ادخال معلومات الحساب");
                    }
                    else if (txtrecupiration.Text == "")
                    {
                        MessageBox.Show("من فضلك قم بادخال كود الاستعادة فهذا ضروري");
                    }
                    else
					{
						ClassUSer.edit_function(
						id,
						Convert.ToInt32(kryptonComboBox1.SelectedValue),
						txt_user.Text,
						txt_pass.Text,
						cmb_type.Text,
						"OFF",
						txtrecupiration.Text,
                       Stock
                    , unite
                    , categorie
                    , marque
                    , favoris
                    , taille
                    , color
                    , fournisseure
                    , ouverier
                    , users
                    , caissier
                    , client
                    , historique_client
                    , remarque
                    , achat
                    , facture_achat
                    , dossier_fctr_achat
                    , historique_frnsre
                    , stock_produit
                    , pack
                    , facture_vente
                    , list_vente
                    , liv
                    , POS
                    , les_charge
                    , lapie
                    , transition_caissier
                    , state_total
                    , benifice
                    , serverss
                    , facture_info
                        );
						MessageBox.Show("تم تعديل معلومات الحساب  بنجاح");
						this.Close();
						frm_uuser.dataGridView1.DataSource = ClassUSer.select_user_();
					}
				}
				else
				{
					if (cmb_type.Text == "")
					{
						MessageBox.Show("يرجى اولا ادخال معلومات الحساب");
                    }
                    else if (txtrecupiration.Text == "")
                    {
                        MessageBox.Show("من فضلك قم بادخال كود الاستعادة فهذا ضروري");
                    }
                    else
					{
						ClassUSer.Add_Funct(
						Convert.ToInt32(kryptonComboBox1.SelectedValue),
						txt_user.Text,
						txt_pass.Text,
						cmb_type.Text,
						"OFF",
						txtrecupiration.Text,
                       Stock
                    , unite
                    , categorie
                    , marque
                    , favoris
                    , taille
                    , color
                    , fournisseure
                    , ouverier
                    , users
                    , caissier
                    , client
                    , historique_client
                    , remarque
                    , achat
                    , facture_achat
                    , dossier_fctr_achat
                    , historique_frnsre
                    , stock_produit
                    , pack
                    , facture_vente
                    , list_vente
                    , liv
                    , POS
                    , les_charge
                    , lapie
                    , transition_caissier
                    , state_total
                    , benifice
                    , serverss
                    , facture_info
                        );
						MessageBox.Show("تم حفظ ادخال معلومات الحساب بنجاح");
						this.Close();
						frm_uuser.dataGridView1.DataSource = ClassUSer.select_user_();
					}
				}

			}

		}

		private void button3_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_add_ouverier add_ouverier = new frm_add_ouverier();
			add_ouverier.type = "logine";
			add_ouverier.FormUser = this; 
            add_ouverier.ShowDialog();
		}

		private void v(object sender, EventArgs e)
		{ 
			kryptonComboBox1.DataSource = clasCombobox.get_combo_ouverier();
			kryptonComboBox1.DisplayMember = "Name";
			kryptonComboBox1.ValueMember = "ID";
		}

        private void frm_add_user_Load(object sender, EventArgs e)
        {
			if (id > 0)
			{
                System.Data.DataTable DT_acces = new System.Data.DataTable(); ;
                DT_acces = classLogine.get_ACCES_USer(id); 
                object ID = DT_acces.Rows[0][0];
                object Stock = DT_acces.Rows[0][1];
                object unite = DT_acces.Rows[0][2];
                object categorie = DT_acces.Rows[0][3];
                object marque = DT_acces.Rows[0][4];
                object favoris = DT_acces.Rows[0][5];
                object taille = DT_acces.Rows[0][6];
                object color = DT_acces.Rows[0][7];
                object fournisseure = DT_acces.Rows[0][8];
                object ouverier = DT_acces.Rows[0][9];
                object users = DT_acces.Rows[0][10];
                object caissier = DT_acces.Rows[0][11];
                object client = DT_acces.Rows[0][12];
                object historique_client = DT_acces.Rows[0][13];
                object remarque = DT_acces.Rows[0][14];
                object achat = DT_acces.Rows[0][15];
                object facture_achat = DT_acces.Rows[0][16];
                object dossier_fctr_achat = DT_acces.Rows[0][17];
                object historique_frnsre = DT_acces.Rows[0][18];
                object stock_produit = DT_acces.Rows[0][19];
                object pack = DT_acces.Rows[0][20];
                object facture_vente = DT_acces.Rows[0][21];
                object list_vente = DT_acces.Rows[0][22];
                object liv = DT_acces.Rows[0][23];
                object POS = DT_acces.Rows[0][24];
                object les_charge = DT_acces.Rows[0][25];
                object lapie = DT_acces.Rows[0][26];
                object transition_caissier = DT_acces.Rows[0][27];
                object state_total = DT_acces.Rows[0][28];
                object benifice = DT_acces.Rows[0][29];
                object serverss = DT_acces.Rows[0][30];
                // Assuming all objects and checkboxes are declared and initialized

                //if ((int)Stock == 1) check_stock.Checked = true;
                //if ((int)favoris == 1) check_fav.Checked = true;
                //if ((int)marque == 1) check_marque.Checked = true;
                //if ((int)categorie == 1) check_categori.Checked = true;
                //if ((int)unite == 1) check_unite.Checked = true;
                //if ((int)taille == 1) check_taille.Checked = true;
                //if ((int)color == 1) check_color.Checked = true;
                //if ((int)ouverier == 1) check_ouverier.Checked = true;
                //if ((int)fournisseure == 1) check_frnsre.Checked = true;
                //if ((int)users == 1) check_user.Checked = true;
                //if ((int)caissier == 1) check_caissier.Checked = true;
                //if ((int)remarque == 1) check_remarque_client.Checked = true;
                //if ((int)historique_client == 1) check_historique_client.Checked = true;
                //if ((int)client == 1) check_client.Checked = true;
                //if ((int)historique_frnsre == 1) check_historique_frnsre.Checked = true;
                //if ((int)dossier_fctr_achat == 1) check_dossier_achat.Checked = true;
                //if ((int)facture_achat == 1) check_fctr_achat.Checked = true;
                //if ((int)achat == 1) check_achat.Checked = true;
                //if ((int)pack == 1) check_pack.Checked = true;
                //if ((int)stock_produit == 1) check_stock.Checked = true;
                //if ((int)POS == 1) check_pos.Checked = true;
                //if ((int)liv == 1) check_liv.Checked = true;
                //if ((int)list_vente == 1) check_liste_vente.Checked = true;
                //if ((int)facture_vente == 1) check_facture_vente.Checked = true;
                //if ((int)benifice == 1) check_benifice.Checked = true;
                //if ((int)state_total == 1) check_stategenerale.Checked = true;
                //if ((int)transition_caissier == 1) check_transisition.Checked = true;
                //if ((int)lapie == 1) check_paie.Checked = true;
                //if ((int)les_charge == 1) check_depense.Checked = true;
                //if ((int)facture_vente == 1) check_info_fctr.Checked = true;
                //if ((int)serverss == 1) check_server.Checked = true;
                if ((int)Stock == 1)
                    check_stock.Checked = true;
                else
                    check_stock.Checked = false;

                if ((int)favoris == 1)
                    check_fav.Checked = true;
                else
                    check_fav.Checked = false;

                if ((int)marque == 1)
                    check_marque.Checked = true;
                else
                    check_marque.Checked = false;

                if ((int)categorie == 1)
                    check_categori.Checked = true;
                else
                    check_categori.Checked = false;

                if ((int)unite == 1)
                    check_unite.Checked = true;
                else
                    check_unite.Checked = false;

                if ((int)taille == 1)
                    check_taille.Checked = true;
                else
                    check_taille.Checked = false;

                if ((int)color == 1)
                    check_color.Checked = true;
                else
                    check_color.Checked = false;

                if ((int)ouverier == 1)
                    check_ouverier.Checked = true;
                else
                    check_ouverier.Checked = false;

                if ((int)fournisseure == 1)
                    check_frnsre.Checked = true;
                else
                    check_frnsre.Checked = false;

                if ((int)users == 1)
                    check_user.Checked = true;
                else
                    check_user.Checked = false;

                if ((int)caissier == 1)
                    check_caissier.Checked = true;
                else
                    check_caissier.Checked = false;

                if ((int)remarque == 1)
                    check_remarque_client.Checked = true;
                else
                    check_remarque_client.Checked = false;

                if ((int)historique_client == 1)
                    check_historique_client.Checked = true;
                else
                    check_historique_client.Checked = false;

                if ((int)client == 1)
                    check_client.Checked = true;
                else
                    check_client.Checked = false;

                if ((int)historique_frnsre == 1)
                    check_historique_frnsre.Checked = true;
                else
                    check_historique_frnsre.Checked = false;

                if ((int)dossier_fctr_achat == 1)
                    check_dossier_achat.Checked = true;
                else
                    check_dossier_achat.Checked = false;

                if ((int)facture_achat == 1)
                    check_fctr_achat.Checked = true;
                else
                    check_fctr_achat.Checked = false;

                if ((int)achat == 1)
                    check_achat.Checked = true;
                else
                    check_achat.Checked = false;

                if ((int)pack == 1)
                    check_pack.Checked = true;
                else
                    check_pack.Checked = false;

                if ((int)stock_produit == 1)
                    check_stock.Checked = true;
                else
                    check_stock.Checked = false;

                if ((int)POS == 1)
                    check_pos.Checked = true;
                else
                    check_pos.Checked = false;

                if ((int)liv == 1)
                    check_liv.Checked = true;
                else
                    check_liv.Checked = false;

                if ((int)list_vente == 1)
                    check_liste_vente.Checked = true;
                else
                    check_liste_vente.Checked = false;

                if ((int)facture_vente == 1)
                    check_facture_vente.Checked = true;
                else
                    check_facture_vente.Checked = false;

                if ((int)benifice == 1)
                    check_benifice.Checked = true;
                else
                    check_benifice.Checked = false;

                if ((int)state_total == 1)
                    check_stategenerale.Checked = true;
                else
                    check_stategenerale.Checked = false;

                if ((int)transition_caissier == 1)
                    check_transisition.Checked = true;
                else
                    check_transisition.Checked = false;

                if ((int)lapie == 1)
                    check_paie.Checked = true;
                else
                    check_paie.Checked = false;

                if ((int)les_charge == 1)
                    check_depense.Checked = true;
                else
                    check_depense.Checked = false;

                if ((int)facture_vente == 1)
                    check_info_fctr.Checked = true;
                else
                    check_info_fctr.Checked = false;

                if ((int)serverss == 1)
                    check_server.Checked = true;
                else
                    check_server.Checked = false;


            }
            if (kryptonButton4.Text == "حفظ واعادة تشغيل")
			{
				cmb_type.SelectedIndex = 1;
				cmb_type.Enabled = false;
				tabControl1.Enabled = false;
				label5.Visible = true;
            }
			System.Data.DataTable dt = new System.Data.DataTable();
			dt = clasCombobox.get_combo_ouverier();
			if (dt.Rows.Count == 0)
			{
				label3.Visible = true;
				label3.Text = "قم أولا باضافة عامل جديد"; 
            }
            
        }

        private void cmb_type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
