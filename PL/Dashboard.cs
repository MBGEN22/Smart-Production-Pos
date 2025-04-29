using Smart_Production_Pos.BL;
using Smart_Production_Pos.BL.BL_FICHIER;
using Smart_Production_Pos.PL.Achats;
using Smart_Production_Pos.PL.Fichier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;  // Add this namespace

namespace Smart_Production_Pos.PL
{
	public partial class Dashboard : Form
	{
		BL.Bl_commande.Bl_commande classComande = new BL.Bl_commande.Bl_commande();
		BL.BL_NOTOFY classNotify = new BL.BL_NOTOFY();
		public int id_user;
        int facture_info;
        int stock_produit;
        int state_total;
        int serverss;
        int facture_achat;
        int fournisseure;
        int POS;
        int historique_client;
        Sp_Logine classLogine = new Sp_Logine();
        public Dashboard()
		{
			InitializeComponent();

            if (Properties.Settings.Default.check_Stock == "true")
            {

                DataTable dt = new DataTable();
                dt = classNotify.GET_ALL_PRODUCT();
                DateTime dateToday = DateTime.Today;
                DataTable dtP = new DataTable();
                dtP = classNotify.get_parametre_day();
                object DayVelue = dtP.Rows[0][0];
                int DayVelueC = Convert.ToInt16(DayVelue);
                classNotify.DeleteAllRows();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    double Qt_Rest;
                    object CodeBarre = dt.Rows[i][0];
                    object designation = dt.Rows[i][1];
                    string cellValue = dt.Rows[i][3]?.ToString(); // Use the null-conditional operator to handle null values.

                    if (double.TryParse(cellValue, out Qt_Rest))
                    {
                        // Parsing succeeded, Qt_Rest contains the double value.
                    }
                    else
                    {
                        // Parsing failed, you can set Qt_Rest to a default value, e.g., 0.
                        Qt_Rest = 0;

                        // Optionally, you can log or handle this situation depending on your application's needs.
                        Console.WriteLine($"Warning: Could not parse '{cellValue}' to a double.");
                    }

                    object date_preparation = dt.Rows[i][2];

                    double Qt_Alert;
                    string cellValueu = dt.Rows[i][4]?.ToString(); // Use the null-conditional operator to handle null values.

                    if (double.TryParse(cellValueu, out Qt_Alert))
                    {
                        // Parsing succeeded, Qt_Rest contains the double value.
                    }
                    else
                    {
                        // Parsing failed, you can set Qt_Rest to a default value, e.g., 0.
                        Qt_Alert = 0;

                        // Optionally, you can log or handle this situation depending on your application's needs.
                        Console.WriteLine($"Warning: Could not parse '{cellValue}' to a double.");
                    }
                    if (Qt_Rest <= Qt_Alert)
                    {
                        classNotify.insert_notif("المنتوج " + designation.ToString() + " قريب  من النفاذ");
                    }
                    if (date_preparation != "")
                    {
                        if (date_preparation != DBNull.Value)
                        {
                            DateTime date_preparationn = Convert.ToDateTime(date_preparation);
                            if ((date_preparationn - dateToday).Days < DayVelueC)
                            {
                                classNotify.insert_notif("المنتوج " + designation.ToString() + " قريب من تاريخ نهايةالصلاحية");
                            }
                        }
                    }
                }
                badge1.Value = classNotify.GetCountNotify();
            }
            else
            {

            }
        } 
        private void kryptonButton9_Click(object sender, EventArgs e)
		{
			PL.Commande.frm_commande frm_commande = new PL.Commande.frm_commande();
			Form1.getMainForm.pn_container.Controls.Clear();
			frm_commande.id_user = id_user;
			Form1.getMainForm.pn_container.Controls.Add(frm_commande.pn_commande); 
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			PLADD.vente.frm_logine_caiise1 frmCaisse = new PLADD.vente.frm_logine_caiise1();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][24];
                POS = Convert.ToInt32(stock);

            }
            if (POS == 1)
            {
                frmCaisse.id_user = id_user;
                frmCaisse.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
			
			//PLADD.vente.frm_vente_caisse frmCaisse = new PLADD.vente.frm_vente_caisse();
			//frmCaisse.id_user = id_user;
			//frmCaisse.ShowDialog();
		}

		private void kryptonButton7_Click(object sender, EventArgs e)
		{
			PLADD.commande.frm_add_commande frm_add_commande = new PLADD.commande.frm_add_commande();
			frm_add_commande.id_type_entre = 1;
			frm_add_commande.id_user = id_user;
			frm_add_commande.Show();
		}

		private void kryptonButton8_Click(object sender, EventArgs e)
		{
			PL.Achats.frm_historique_fournisseur frmhistorique_fournisseur = new PL.Achats.frm_historique_fournisseur();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][18];
                fournisseure = Convert.ToInt32(stock);

            }
            if (fournisseure == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frmhistorique_fournisseur.pn_marque);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void kryptonButton6_Click(object sender, EventArgs e)
		{
			PL.CLient.frm_historique_client histoeique_Client = new PL.CLient.frm_historique_client();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][13];
                historique_client = Convert.ToInt32(stock);

            }
            if (historique_client == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(histoeique_Client.pn_historique_client);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void kryptonButton5_Click(object sender, EventArgs e)
		{
            PL.Achat_revente.frm_stock_produit_revente frm_Stock = new PL.Achat_revente.frm_stock_produit_revente();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(id_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][19];
                stock_produit = Convert.ToInt32(stock);

            }
            if (stock_produit == 1)
            {
                frm_Stock.id_user = Convert.ToInt32(id_user);
                frm_Stock.ShowDialog();

            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }

        }

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			frm_fournisseur frnsre = new frm_fournisseur();
			PLADD.Fichier.frm_add_fournisseures add_fournisseure = new PLADD.Fichier.frm_add_fournisseures();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][8];
                fournisseure = Convert.ToInt32(stock);

            }
            if (fournisseure == 1)
            {
                add_fournisseure.frm_fournisseur = frnsre;
                add_fournisseure.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{
			frm_client frnsre = new frm_client();
			PLADD.Fichier.frm_add_client add_client = new PLADD.Fichier.frm_add_client();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][12];
                historique_client = Convert.ToInt32(stock);

            }
            if (historique_client == 1)
            {
                add_client.frm_clieent = frnsre;
                add_client.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			//PL.Achats.frm_facture frm_fctr = new PL.Achats.frm_facture();
			//Form1.getMainForm.pn_container.Controls.Clear();
			//Form1.getMainForm.pn_container.Controls.Add(frm_fctr.pn_fctre); 
			PL.Achat_revente.frm_facture frm_fctr = new PL.Achat_revente.frm_facture();
			DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][16];

                 facture_achat = Convert.ToInt32(stock);

            }
            if (facture_achat == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_fctr.pn_fctre);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
		}

		private void kryptonButton10_Click(object sender, EventArgs e)
		{
			PL.Statistique.frm_statique_par_time frm_stock = new PL.Statistique.frm_statique_par_time();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][29];
                state_total = Convert.ToInt32(stock);

            }
            if (state_total == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_stock.panel2);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void kryptonButton12_Click(object sender, EventArgs e)
		{
			PL.paramtre.frm_information frm_paramtre = new PL.paramtre.frm_information();

            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][31];
                facture_info = Convert.ToInt32(stock);

            }
            if (facture_info == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_paramtre.pn_info);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void kryptonButton11_Click(object sender, EventArgs e)
		{
			PL.paramtre.frm_server frm_paramtre = new PL.paramtre.frm_server();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][30];
                serverss = Convert.ToInt32(stock);

            }
            if (serverss == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_paramtre.pn_info);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void Dashboard_Load(object sender, EventArgs e)
		{
            
            //DataTable dt = new DataTable() ; dt =  classComande.get_tb_commande();


            //foreach 
            //if (dt.Rows[i][1])
        }

        private void krypnButton7_Click(object sender, EventArgs e)
        {
			frm_notify frm_not = new frm_notify();
			frm_not.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void kryptonGroup1_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void downloadAnydesk_Click(object sender, EventArgs e)
        {

        }

        private void OpenAnydesk(object sender, EventArgs e)
        {
            try
            {
                // Specify the path to the AnyDesk executable
                string anyDeskPath = @"C:\Program Files (x86)\AnyDesk\AnyDesk.exe"; 
                // Start the AnyDesk application
                Process.Start(anyDeskPath);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., if the file path is incorrect)
                MessageBox.Show("Could not open AnyDesk: " + ex.Message);
            }
        }
    }
}
