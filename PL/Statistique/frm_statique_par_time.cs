using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Statistique
{
	public partial class frm_statique_par_time : Form
	{
		BL.BL_Statistique.classStatistique_prive classStatistirque = new BL.BL_Statistique.classStatistique_prive();
		public frm_statique_par_time()
		{
			InitializeComponent();
			calculeBenificie_journre();
		}

		private decimal calcule_sortie_money( decimal cout_comande ,decimal cout_facture , decimal depense , decimal LaPaye)
		{
			decimal lesortie =(cout_comande + cout_facture + depense + LaPaye);
			return lesortie;
		}
		private decimal calcule_entre_money(decimal price_commande, decimal Price_facture)
		{
			decimal entre = (price_commande + Price_facture);
			return entre;
		}
		private decimal calcule_entre_observe(decimal price_commande, decimal Price_facture)
		{
			decimal entre = (price_commande + Price_facture);
			return entre;
		}
		private void calculeBenificie_journre()
		{
			//LBTOTALCOMMANDE.Text = classStatistirque.total__ttc_commande_jrn(DateTime.Now.ToString());
			//LB_VERSEMENT_COMMANDE.Text = classStatistirque.total_versemnt_ttc_commande_jrn(DateTime.Now.ToString());
			//---------------------------------------------------------------------------------------------------------------------------------//	 
			LB_FACTURE_VENTE_TTL.Text = classStatistirque.total_facture_Vente(DateTime.Now.ToString("yyyy-MM-dd"));
			LB_FACTUR_VENTE_VERSEMENT.Text = classStatistirque.versement_facture_Vente(DateTime.Now.ToString("yyyy-MM-dd"));
			//---------------------------------------------------------------------------------------------------------------------------------//
			//LB_COUT_COMMANDE.Text = classStatistirque.total__COUT_TOTAL_commande_jrn(DateTime.Now.ToString());
			LB_COUT_FACTURE.Text = classStatistirque.cout_facteure_vente(DateTime.Now.ToString("yyyy-MM-dd")); 
			//---------------------------------------------------------------------------------------------------------------------------------//
			LB_DEPENSE.Text = classStatistirque.cout_depense(DateTime.Now.ToString("yyyy-MM-dd"));
			//---------------------------------------------------------------------------------------------------------------------------------//
			LB_COUT_OUVERIER.Text = classStatistirque.cout_ouverier(DateTime.Now.ToString("yyyy-MM-dd"));
            //---------------------------------------------------------------------------------------------------------------------------------//
            //---------------------------------------------------------------------------------------------------------------------------------// 
            lb_routeur_ttl.Text = classStatistirque.total_routeure_price(DateTime.Now.ToString("yyyy-MM-dd"));
            lb_cout_routeur.Text = classStatistirque.cout_derouteure(DateTime.Now.ToString("yyyy-MM-dd"));
            lb_deference_routeur.Text = classStatistirque.deference_routeur(DateTime.Now.ToString("yyyy-MM-dd"));

            if (check_paie.Checked == true) 
			{
                lb_sotie_jrn.Text = calcule_sortie_money(
                    0,
                    decimal.Parse(LB_COUT_FACTURE.Text),
                    decimal.Parse(LB_DEPENSE.Text),
                    decimal.Parse(LB_COUT_OUVERIER.Text)
                    ).ToString();
                total_entre_jrn.Text = calcule_entre_money(
                    0,
                    decimal.Parse(LB_FACTUR_VENTE_VERSEMENT.Text)
                    ).ToString();
                lb_enterd_ttl.Text = calcule_entre_observe(
                    0,
                    decimal.Parse(LB_FACTURE_VENTE_TTL.Text)
                    ).ToString();
                lb_fayda_ttl_jrn.Text = calcule_benifice_money(
                    decimal.Parse(total_entre_jrn.Text),
                    decimal.Parse(lb_sotie_jrn.Text) + decimal.Parse(lb_deference_routeur.Text)
                    ).ToString(); ;
            }
			else
			{
                lb_sotie_jrn.Text = calcule_sortie_money(
                0,
                decimal.Parse(LB_COUT_FACTURE.Text),
                decimal.Parse(LB_DEPENSE.Text),
				0
                ).ToString();
                total_entre_jrn.Text = calcule_entre_money(
                    0,
                    decimal.Parse(LB_FACTUR_VENTE_VERSEMENT.Text)
                    ).ToString();
                lb_enterd_ttl.Text = calcule_entre_observe(
                    0,
                    decimal.Parse(LB_FACTURE_VENTE_TTL.Text)
                    ).ToString();
                lb_fayda_ttl_jrn.Text = calcule_benifice_money(
                    decimal.Parse(total_entre_jrn.Text),
                    decimal.Parse(lb_sotie_jrn.Text) + decimal.Parse(lb_deference_routeur.Text)
                    ).ToString(); ;
            }
		}

		private decimal calcule_benifice_money(decimal entre , decimal sortie)
		{
			decimal benificie = entre - sortie;
			return benificie;
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			//LBTOTALCOMMANDE.Text = classStatistirque.total__ttc_commande_last_week();
			//LB_VERSEMENT_COMMANDE.Text = classStatistirque.total_versemnt_ttc_commande_last_week();
			//---------------------------------------------------------------------------------------------------------------------------------//
			LB_FACTURE_VENTE_TTL.Text = classStatistirque.total_facture_Vente_last_week();
			LB_FACTUR_VENTE_VERSEMENT.Text = classStatistirque.versement_facture_Vente_last_week();
			//---------------------------------------------------------------------------------------------------------------------------------//
			//LB_COUT_COMMANDE.Text = classStatistirque.total__COUT_TOTAL_commande_last_week();
			LB_COUT_FACTURE.Text = classStatistirque.cout_facteure_vente_last_week();
			//---------------------------------------------------------------------------------------------------------------------------------//
			LB_DEPENSE.Text = classStatistirque.cout_depense_last_week();
			//---------------------------------------------------------------------------------------------------------------------------------//
			LB_COUT_OUVERIER.Text = classStatistirque.cout_ouverier_last_week();
            //---------------------------------------------------------------------------------------------------------------------------------//
            //---------------------------------------------------------------------------------------------------------------------------------// 
            lb_routeur_ttl.Text = classStatistirque.total_routeure_week();
            lb_cout_routeur.Text = classStatistirque.cout_routeure_week();
            lb_deference_routeur.Text = classStatistirque.deference_routeure_week();

            if (check_paie.Checked == true)
            {
                sortie_last_week.Text = calcule_sortie_money(
                    //decimal.Parse(LB_COUT_COMMANDE.Text),
                    0,
                    decimal.Parse(LB_COUT_FACTURE.Text),
                    decimal.Parse(LB_DEPENSE.Text),
                    decimal.Parse(LB_COUT_OUVERIER.Text)
                    ).ToString();
                entre_total_last_week.Text = calcule_entre_money(
                    //decimal.Parse(LB_VERSEMENT_COMMANDE.Text),
                    0,
                    decimal.Parse(LB_FACTUR_VENTE_VERSEMENT.Text)
                    ).ToString();
                entre_observe_last_week.Text = calcule_entre_observe(
                    //decimal.Parse(LBTOTALCOMMANDE.Text),
                    0,
                    decimal.Parse(LB_FACTURE_VENTE_TTL.Text)
                    ).ToString();
                lb_benifice_last_week.Text = calcule_benifice_money(
                    decimal.Parse(entre_total_last_week.Text),
                    decimal.Parse(sortie_last_week.Text)+ decimal.Parse(lb_deference_routeur.Text)
                    ).ToString();
            }
			else
            {
                sortie_last_week.Text = calcule_sortie_money(
                    //decimal.Parse(LB_COUT_COMMANDE.Text),
                    0,
                    decimal.Parse(LB_COUT_FACTURE.Text),
                    decimal.Parse(LB_DEPENSE.Text),
					0
                    ).ToString();
                entre_total_last_week.Text = calcule_entre_money(
                    //decimal.Parse(LB_VERSEMENT_COMMANDE.Text),
                    0,
                    decimal.Parse(LB_FACTUR_VENTE_VERSEMENT.Text)
                    ).ToString();
                entre_observe_last_week.Text = calcule_entre_observe(
                    //decimal.Parse(LBTOTALCOMMANDE.Text),
                    0,
                    decimal.Parse(LB_FACTURE_VENTE_TTL.Text)
                    ).ToString();
                lb_benifice_last_week.Text = calcule_benifice_money(
                    decimal.Parse(entre_total_last_week.Text),
                    decimal.Parse(sortie_last_week.Text) + decimal.Parse(lb_deference_routeur.Text)
                    ).ToString();
            }
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			//LBTOTALCOMMANDE.Text = classStatistirque.total__ttc_commande_jrn(dateOne.Value.ToString());
			//LB_VERSEMENT_COMMANDE.Text = classStatistirque.total_versemnt_ttc_commande_jrn(dateOne.Value.ToString());
			//---------------------------------------------------------------------------------------------------------------------------------//
			LB_FACTURE_VENTE_TTL.Text = classStatistirque.total_facture_Vente( dateOne.Value.ToString("yyyy-MM-dd"));
			LB_FACTUR_VENTE_VERSEMENT.Text = classStatistirque.versement_facture_Vente( dateOne.Value.ToString("yyyy-MM-dd"));
			//---------------------------------------------------------------------------------------------------------------------------------//
			//LB_COUT_COMMANDE.Text = classStatistirque.total__COUT_TOTAL_commande_jrn(dateOne.Value.ToString());
			LB_COUT_FACTURE.Text = classStatistirque.cout_facteure_vente( dateOne.Value.ToString("yyyy-MM-dd"));
			//---------------------------------------------------------------------------------------------------------------------------------//
			LB_DEPENSE.Text = classStatistirque.cout_depense( dateOne.Value.ToString("yyyy-MM-dd"));
			//---------------------------------------------------------------------------------------------------------------------------------//
			LB_COUT_OUVERIER.Text = classStatistirque.cout_ouverier( dateOne.Value.ToString("yyyy-MM-dd"));
            //---------------------------------------------------------------------------------------------------------------------------------//
            //---------------------------------------------------------------------------------------------------------------------------------// 
            lb_routeur_ttl.Text = classStatistirque.total_routeure_price(dateOne.Value.ToString("yyyy-MM-dd"));
            lb_cout_routeur.Text = classStatistirque.cout_derouteure(dateOne.Value.ToString("yyyy-MM-dd"));
            lb_deference_routeur.Text = classStatistirque.deference_routeur(dateOne.Value.ToString("yyyy-MM-dd"));
            lb_depense_joune.Text = calcule_sortie_money(
				//decimal.Parse(LB_COUT_COMMANDE.Text),
				0,
				decimal.Parse(LB_COUT_FACTURE.Text),
				decimal.Parse(LB_DEPENSE.Text),
				decimal.Parse(LB_COUT_OUVERIER.Text)
				).ToString();
			lb_entre_jouner.Text = calcule_entre_money(
				//decimal.Parse(LB_VERSEMENT_COMMANDE.Text),
				0,
				decimal.Parse(LB_FACTUR_VENTE_VERSEMENT.Text)
				).ToString();
			lb_ente_obseve_joune.Text = calcule_entre_observe(
				//decimal.Parse(LBTOTALCOMMANDE.Text),
				0,
				decimal.Parse(LB_FACTURE_VENTE_TTL.Text)
				).ToString();
			label16.Text = calcule_benifice_money(
				decimal.Parse(lb_entre_jouner.Text),
				decimal.Parse(lb_depense_joune.Text)+decimal.Parse(lb_deference_routeur.Text)
                ).ToString(); ;
		}

		private void kryptonGroup1_Panel_Paint(object sender, PaintEventArgs e)
		{

		}

		private void groupBox1_Click(object sender, EventArgs e)
		{

		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			calculeBenificie_journre();
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{
			//LBTOTALCOMMANDE.Text = classStatistirque.total__ttc_commande_last_month();
			//LB_VERSEMENT_COMMANDE.Text = classStatistirque.total_versemnt_ttc_commande_last_month();
			//---------------------------------------------------------------------------------------------------------------------------------//
			LB_FACTURE_VENTE_TTL.Text = classStatistirque.total_facture_Vente_last_month();
			LB_FACTUR_VENTE_VERSEMENT.Text = classStatistirque.versement_facture_Vente_last_month();
			//---------------------------------------------------------------------------------------------------------------------------------//
			//LB_COUT_COMMANDE.Text = classStatistirque.total__COUT_TOTAL_commande_last_month();
			LB_COUT_FACTURE.Text = classStatistirque.cout_facteure_vente_last_month();
			//---------------------------------------------------------------------------------------------------------------------------------//
			LB_DEPENSE.Text = classStatistirque.cout_depense_last_month();
			//---------------------------------------------------------------------------------------------------------------------------------//
			LB_COUT_OUVERIER.Text = classStatistirque.cout_ouverier_last_month();
            //---------------------------------------------------------------------------------------------------------------------------------//
            lb_routeur_ttl.Text = classStatistirque.cout_ouverier_last_month();
            lb_cout_routeur.Text = classStatistirque.cout_ouverier_last_month();
            lb_deference_routeur.Text = classStatistirque.cout_ouverier_last_month();
            //---------------------------------------------------------------------------------------------------------------------------------// 
            lb_routeur_ttl.Text = classStatistirque.total_routeur();
            lb_cout_routeur.Text = classStatistirque.coout_route();
            lb_deference_routeur.Text = classStatistirque.defernce();

            sortie_last_month.Text = calcule_sortie_money(
				/*decimal.Parse(LB_COUT_COMMANDE.Text)*/
				0,
				decimal.Parse(LB_COUT_FACTURE.Text),
				decimal.Parse(LB_DEPENSE.Text),
				decimal.Parse(LB_COUT_OUVERIER.Text)
				).ToString();
			entre_total_last_month.Text = calcule_entre_money(
				//decimal.Parse(LB_VERSEMENT_COMMANDE.Text),
				0,
				decimal.Parse(LB_FACTUR_VENTE_VERSEMENT.Text)
				).ToString();
			entre_observe_last_month.Text = calcule_entre_observe(
				//decimal.Parse(LBTOTALCOMMANDE.Text),
				0,
				decimal.Parse(LB_FACTURE_VENTE_TTL.Text)
				).ToString();
			lb_benifice_last_month.Text = calcule_benifice_money(
				decimal.Parse(entre_total_last_month.Text),
				decimal.Parse(sortie_last_month.Text) + decimal.Parse(lb_deference_routeur.Text)
                ).ToString();
		}

		private void kryptonButton5_Click(object sender, EventArgs e)
		{
			//LBTOTALCOMMANDE.Text = classStatistirque.total__ttc_commande_between_dates(
			//																																									datefirsst.Value.ToString(),
			//																																									dateSecound.Value.ToString()
			//																																									);
			//LB_VERSEMENT_COMMANDE.Text = classStatistirque.total_versemnt_ttc_commande_between_dates(
			//																																									datefirsst.Value.ToString(),
			//																																									dateSecound.Value.ToString()
			//																																									);
			//---------------------------------------------------------------------------------------------------------------------------------//
			LB_FACTURE_VENTE_TTL.Text = classStatistirque.total_facture_Vente_between_dates(
																																												datefirsst.Value.ToString(),
																																												dateSecound.Value.ToString()
																																												);
			LB_FACTUR_VENTE_VERSEMENT.Text = classStatistirque.versement_facture_Vente_between_dates(
																																												datefirsst.Value.ToString(),
																																												dateSecound.Value.ToString()
																																												);
			//---------------------------------------------------------------------------------------------------------------------------------//
			//LB_COUT_COMMANDE.Text = classStatistirque.total__COUT_TOTAL_commande_between_dates(
			//																																									datefirsst.Value.ToString(),
			//																																									dateSecound.Value.ToString()
			//																																									);
			LB_COUT_FACTURE.Text = classStatistirque.cout_facteure_vente_between_dates(
																																												datefirsst.Value.ToString(),
																																												dateSecound.Value.ToString()
																																												);
			//---------------------------------------------------------------------------------------------------------------------------------//
			LB_DEPENSE.Text = classStatistirque.cout_depense_between_dates(
																																												datefirsst.Value.ToString(),
																																												dateSecound.Value.ToString()
																																												);
			//---------------------------------------------------------------------------------------------------------------------------------//
			LB_COUT_OUVERIER.Text = classStatistirque.cout_ouverier_between_dates( datefirsst.Value.ToString(),
																				dateSecound.Value.ToString()
																			);
            //---------------------------------------------------------------------------------------------------------------------------------//

            lb_routeur_ttl.Text = classStatistirque.total_routeure(datefirsst.Value.ToString(),
                                                                                dateSecound.Value.ToString()
                                                                            );
            lb_cout_routeur.Text = classStatistirque.cout_total(datefirsst.Value.ToString(),
                                                                                dateSecound.Value.ToString()
                                                                            );
            lb_deference_routeur.Text = classStatistirque.deference(datefirsst.Value.ToString(),
                                                                                dateSecound.Value.ToString()
                                                                            );
            //---------------------------------------------------------------------------------------------------------------------------------// 

            sortie_last_between_date.Text = calcule_sortie_money(
				//decimal.Parse(LB_COUT_COMMANDE.Text),
				0,
				decimal.Parse(LB_COUT_FACTURE.Text),
				decimal.Parse(LB_DEPENSE.Text),
				decimal.Parse(LB_COUT_OUVERIER.Text)
				).ToString();
			entre_total_between_date.Text = calcule_entre_money(
				//decimal.Parse(LB_VERSEMENT_COMMANDE.Text),
				0,
				decimal.Parse(LB_FACTUR_VENTE_VERSEMENT.Text)
				).ToString();
			entre_observe_between_Date.Text = calcule_entre_observe(
				//decimal.Parse(LBTOTALCOMMANDE.Text),
				0,
				decimal.Parse(LB_FACTURE_VENTE_TTL.Text)
				).ToString();
			benifiece_entre_2_date.Text = calcule_benifice_money(
				decimal.Parse(entre_total_between_date.Text),
				decimal.Parse(sortie_last_between_date.Text)+ decimal.Parse(lb_deference_routeur.Text)
                ).ToString();
		}

        private void check_paie_CheckedChanged(object sender, EventArgs e)
        {
            calculeBenificie_journre();
        }

        private void benifiece_entre_2_date_Click(object sender, EventArgs e)
        {

        }
    }
}
