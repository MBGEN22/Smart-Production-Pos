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
    public partial class frm_statiq_e_detalle : Form
    {
        BL.BL_State_new classNew_state = new BL.BL_State_new();
        BL.BL_Statistique.classStatistique_prive classStatistirque = new BL.BL_Statistique.classStatistique_prive();

        public frm_statiq_e_detalle()
        {
            InitializeComponent();
            //----------------------------- This Day ------------------------------------//
            dtg_count_unite.DataSource = classNew_state.get_sum_of_Qt_vente_state_unite();
            dtg_count_pack.DataSource = classNew_state.get_sum_of_Qt_vente_state_pack();
            dataGridView3.DataSource = classNew_state.get_fctr_on_state(DateTime.Today);

            data5.DataSource = classNew_state.get_sum_of_Qt_facture_state_unite();
            dataGridView6.DataSource = classNew_state.get_sum_of_Qt_facture_state_pack();
            dataGridView7.DataSource = classNew_state.get_facturation_on_state(DateTime.Today);

            //---------------------------- this Week ----------------------------------//
            dtg_product_Week.DataSource = classNew_state.get_sum_of_Qt_vente_state_unite_week();
            dtg_pack_week.DataSource = classNew_state.get_sum_of_Qt_vente_state_pack_week();
            dtg_fctr_week.DataSource = classNew_state.get_fctr_on_state_week();

            dataGridView5.DataSource = classNew_state.get_sum_of_Qt_facture_state_unite_week();
            dataGridView8.DataSource = classNew_state.get_sum_of_Qt_facture_state_pack_weel();
            dataGridView9.DataSource = classNew_state.get_facturantion_on_state_week();

            //---------------------------- this Month ----------------------------------//
            dtg_unite_month.DataSource = classNew_state.get_sum_of_Qt_vente_state_unite_Monthe();
            dtg_pack_month.DataSource = classNew_state.get_sum_of_Qt_vente_state_pack_Monthe();
            dtg_fctr_month.DataSource = classNew_state.get_fctr_on_state_Monthe();

            dataGridView10.DataSource = classNew_state.get_sum_of_Qt_facture_state_unite_month();
            dataGridView11.DataSource = classNew_state.get_sum_of_Qt_facture_state_pack_month();
            dataGridView12.DataSource = classNew_state.get_facturation_on_state_Month();
            //---------------------------            -----------------------------------//

            
        }
        private void calculefacture_type2()
        {
            label140.Text = classNew_state.total_facture_Vente(DateTime.Now.ToString("yyyy-MM-dd"));
            label164.Text = classNew_state.total_versement_facture_Vente(DateTime.Now.ToString("yyyy-MM-dd")); ;
            label148.Text = classNew_state.total_cout_facture_Vente(DateTime.Now.ToString("yyyy-MM-dd")); ;

            label162.Text = classNew_state.versement_facture_Vente_anonymos(DateTime.Now.ToString("yyyy-MM-dd"));
            label144.Text = classNew_state.versement_facture_Vente_non_anonymos(DateTime.Now.ToString("yyyy-MM-dd"));

            //WEEK
            label109.Text = classNew_state.cout_facteure_vente_last_week();
            label83.Text = classNew_state .total__ttc_commande_last_week();
            label136.Text = classNew_state.versement_facture_Vente_last_week();
            label119.Text = classNew_state.versement_facture_Vente_anonymos_week();
            label95.Text = classNew_state .versement_facture_Vente_non_anonymos_week();

            //MONTH
            label177.Text = classNew_state.cout_facteure_vente_last_month();
            label173.Text = classNew_state.total__ttc_commande_last_month();
            label181.Text = classNew_state.versement_facture_Vente_lastmonth();
            label179.Text = classNew_state.versement_facture_Vente_anonymos_month();
            label175.Text = classNew_state.versement_facture_Vente_non_anonymos_month();

        }
        private void calculeBenificie_journre()
        {

            //---------------------------------------------------------------- this Day -----------------------------------------------------------------//	
            #region Day
            lb_fct_achat_today.Text = classStatistirque.total_facture_Achat(DateTime.Now.ToString("yyyy-MM-dd"));
            versmenet_fctr_achat.Text = classStatistirque.total_versement_facture_Achat(DateTime.Now.ToString("yyyy-MM-dd"));

            lb_versement_anonymos.Text = classStatistirque.versement_facture_Vente_anonymos(DateTime.Now.ToString("yyyy-MM-dd"));
            versement_non_anonymos.Text = classStatistirque.versement_facture_Vente_non_anonymos(DateTime.Now.ToString("yyyy-MM-dd"));
            lb_versemnt_nrml.Text = classStatistirque.versemnt_normale(DateTime.Now.ToString("yyyy-MM-dd"));

            ttl_ttc1.Text = classStatistirque.versement_facture_Vente(DateTime.Now.ToString("yyyy-MM-dd"));
            ttl_cout1.Text = classStatistirque.cout_facteure_vente(DateTime.Now.ToString("yyyy-MM-dd"));
            depense1.Text = classStatistirque.cout_depense(DateTime.Now.ToString("yyyy-MM-dd"));
            ouver1.Text = classStatistirque.cout_ouverier(DateTime.Now.ToString("yyyy-MM-dd"));
            rtre_fyda1.Text = classStatistirque.deference_routeur(DateTime.Now.ToString("yyyy-MM-dd"));
            label5.Text = classStatistirque.total_facture_Vente(DateTime.Now.ToString("yyyy-MM-dd"));

            LB_FACTURE_VENTE_TTL.Text = classStatistirque.total_facture_Vente(DateTime.Now.ToString("yyyy-MM-dd"));
            LB_FACTUR_VENTE_VERSEMENT.Text = classStatistirque.versement_facture_Vente(DateTime.Now.ToString("yyyy-MM-dd")); 
            LB_COUT_FACTURE.Text = classStatistirque.cout_facteure_vente(DateTime.Now.ToString("yyyy-MM-dd")); 
            LB_DEPENSE.Text = classStatistirque.cout_depense(DateTime.Now.ToString("yyyy-MM-dd")); 
            LB_COUT_OUVERIER.Text = classStatistirque.cout_ouverier(DateTime.Now.ToString("yyyy-MM-dd")); 
            lb_routeur_ttl.Text = classStatistirque.total_routeure_price(DateTime.Now.ToString("yyyy-MM-dd"));
            //lb_cout_routeur.Text = classStatistirque.cout_derouteure(DateTime.Now.ToString("yyyy-MM-dd"));
            lb_deference_routeur.Text = classStatistirque.deference_routeur(DateTime.Now.ToString("yyyy-MM-dd"));
            lb_credit_en_fct.Text = (decimal.Parse(LB_FACTURE_VENTE_TTL.Text) - decimal.Parse(LB_FACTUR_VENTE_VERSEMENT.Text)).ToString();
            decimal SortieMoney = decimal.Parse(ttl_cout1.Text) + decimal.Parse(depense1.Text) + decimal.Parse(ouver1.Text) + decimal.Parse(rtre_fyda1.Text);

            Lb_fayda_Total.Text = calcule_benifice_money(
                decimal.Parse(ttl_ttc1.Text), SortieMoney, decimal.Parse(label164.Text), decimal.Parse(label148.Text)
                ).ToString();

            #endregion

            //---------------------------------------------------------------- this Week -----------------------------------------------------------------//	

            #region Week
            lb_fctr_achat_weel.Text = classStatistirque.total_facture_Achat_week().ToString();
            lb_fctr_versement_achat_weel.Text = classStatistirque.total_Versment_Achat_week().ToString();

            anonymos_weel.Text = classStatistirque.versement_facture_Vente_anonymos_week();
            other_week.Text = classStatistirque.versement_facture_Vente_non_anonymos_week();
            versement_week.Text = classStatistirque.versemnt_normale_week();

            lb_cout_fctr_week.Text = classStatistirque.cout_facteure_vente_last_week();
            Lb_ttl_fctr_vente_week.Text = classStatistirque.total_facture_Vente_last_week();
            lb_versemnt_fctr_week.Text = classStatistirque.versement_facture_Vente_last_week();

            depense_week.Text = classStatistirque.cout_depense_last_week();
            ouv_week.Text = classStatistirque.cout_ouverier_last_week();

            total_rtr_week.Text = classStatistirque.total_routeure_week();
            fyde_rtr_week.Text = classStatistirque.deference_routeure_week();

            credit_week.Text = (decimal.Parse(Lb_ttl_fctr_vente_week.Text) - decimal.Parse(lb_versemnt_fctr_week.Text)).ToString();


            lb_ttl_ttc_week.Text = classStatistirque.total_facture_Vente_last_week();
            lb_ttl_vers_week.Text = classStatistirque.versement_facture_Vente_last_week();
            lb_ttl_cout_week.Text = classStatistirque.cout_facteure_vente_last_week();
            lb_ttl_depense_week.Text = classStatistirque.cout_depense_last_week();
            lb_ttl_ouver_week.Text = classStatistirque.cout_ouverier_last_week();
            lb_ttl_fyda_rrt_week.Text = classStatistirque.deference_routeure_week();

            decimal SortieMoneyWeek = decimal.Parse(lb_ttl_cout_week.Text) + decimal.Parse(lb_ttl_depense_week.Text)
                + decimal.Parse(lb_ttl_ouver_week.Text) + decimal.Parse(lb_ttl_fyda_rrt_week.Text);

            lb_fayda_week.Text = calcule_benifice_money(
                decimal.Parse(lb_ttl_vers_week.Text), SortieMoneyWeek, decimal.Parse(label136.Text) , decimal.Parse(label109.Text) 
                ).ToString();

            #endregion

            //---------------------------------------------------------------- this Month -----------------------------------------------------------------//	

            #region Week
            lb_fctr_achat_Month.Text = classStatistirque.total_facture_Achat_Month().ToString();
            lb_fctr_versement_achat_Monthe.Text = classStatistirque.total_Versment_Achat_Month().ToString();

            anonymos_Month.Text = classStatistirque.versement_facture_Vente_anonymos_Month();
            other_Month.Text = classStatistirque.versement_facture_Vente_non_anonymos_Month();
            versement_Month.Text = classStatistirque.versemnt_normale_Month();

            lb_cout_fctr_Month.Text = classStatistirque.cout_facteure_vente_last_Month();
            Lb_ttl_fctr_vente_Month.Text = classStatistirque.total_facture_Vente_last_Month();
            lb_versemnt_fctr_Month.Text = classStatistirque.versement_facture_Vente_last_Month();

            depense_Month.Text = classStatistirque.cout_depense_last_Month();
            ouv_Month.Text = classStatistirque.cout_ouverier_last_month();

            total_rtr_Month.Text = classStatistirque.total_routeur();
            fyde_rtr_Month.Text = classStatistirque.defernce();

            credit_Month.Text = (decimal.Parse(Lb_ttl_fctr_vente_Month.Text) - decimal.Parse(lb_versemnt_fctr_Month.Text)).ToString();


            lb_ttl_ttc_Month.Text = classStatistirque.total_facture_Vente_last_Month();
            lb_ttl_vers_month.Text = classStatistirque.versement_facture_Vente_last_Month();
            lb_ttl_cout_Month.Text = classStatistirque.cout_facteure_vente_last_Month();
            lb_ttl_depense_Month.Text = classStatistirque.cout_depense_last_Month();
            lb_ttl_ouver_Month.Text = classStatistirque.cout_ouverier_last_month();
            lb_ttl_fyda_rrt_Month.Text = classStatistirque.defernce();

            decimal SortieMoneyMonth = decimal.Parse(lb_ttl_cout_Month.Text) + decimal.Parse(lb_ttl_depense_Month.Text)
                + decimal.Parse(lb_ttl_ouver_Month.Text) + decimal.Parse(lb_ttl_fyda_rrt_Month.Text);

            lb_fayda_month.Text = calcule_benifice_money(
                decimal.Parse(lb_ttl_vers_month.Text), SortieMoneyMonth, decimal.Parse(label181.Text), decimal.Parse(label177.Text)
                ).ToString();

            #endregion


        }

        private decimal calcule_benifice_money(decimal entre, decimal sortie, decimal entre_facturation, decimal cout_facturation)
        {
            decimal benificie = (entre - sortie) +(entre_facturation - cout_facturation) ;
            return benificie;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView3.Columns[e.ColumnIndex].Name == "السعر الكلي TTC")
            {
                e.CellStyle.BackColor = Color.LightBlue; // اختر لون قريب
            }
            else if (dataGridView3.Columns[e.ColumnIndex].Name == "التكلفة")
            {
                e.CellStyle.BackColor = Color.Yellow; // اختر لون قريب
            }
            else if (dataGridView3.Columns[e.ColumnIndex].Name == "الفائدة")
            {
                e.CellStyle.BackColor = Color.LightGreen; // اختر لون قريب
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void dtg_fctr_week_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dtg_fctr_week.Columns[e.ColumnIndex].Name == "السعر الكلي TTC")
            {
                e.CellStyle.BackColor = Color.LightBlue; // اختر لون قريب
            }
            else if (dtg_fctr_week.Columns[e.ColumnIndex].Name == "التكلفة")
            {
                e.CellStyle.BackColor = Color.Yellow; // اختر لون قريب
            }
            else if (dtg_fctr_week.Columns[e.ColumnIndex].Name == "الفائدة")
            {
                e.CellStyle.BackColor = Color.LightGreen; // اختر لون قريب
            }

        }

        private void dtg_fctr_month_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtg_fctr_month.Columns[e.ColumnIndex].Name == "السعر الكلي TTC")
            {
                e.CellStyle.BackColor = Color.LightBlue; // اختر لون قريب
            }
            else if (dtg_fctr_month.Columns[e.ColumnIndex].Name == "التكلفة")
            {
                e.CellStyle.BackColor = Color.Yellow; // اختر لون قريب
            }
            else if (dtg_fctr_month.Columns[e.ColumnIndex].Name == "الفائدة")
            {
                e.CellStyle.BackColor = Color.LightGreen; // اختر لون قريب
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            report.State.rpt_count_produit_days rpt = new report.State.rpt_count_produit_days();
            #region re
            string mode = Properties.Settings.Default.mode;
            if (mode == "SQL")
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                rpt.Refresh();
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
            else
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = true;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                rpt.Refresh();
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            report.State.rpt_count_produit_Week rpt = new report.State.rpt_count_produit_Week();
            #region re
            string mode = Properties.Settings.Default.mode;
            if (mode == "SQL")
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                rpt.Refresh();
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
            else
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = true;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                rpt.Refresh();
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
            #endregion
        }

        private void button35Click(object sender, EventArgs e)
        {
            report.State.rpt_count_produit_Month rpt = new report.State.rpt_count_produit_Month();
            #region re
            string mode = Properties.Settings.Default.mode;
            if (mode == "SQL")
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                rpt.Refresh();
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
            else
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = true;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                rpt.Refresh();
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
            #endregion
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //---------------------------- day specifique ----------------------------------//
            dataGridView1.DataSource = classNew_state.get_sum_of_Qt_vente_state_unite_day_specifique(Convert.ToDateTime(dateTimePicker1.Text));
            dataGridView2.DataSource = classNew_state.get_sum_of_Qt_vente_state_pack_day_specifiuqe(Convert.ToDateTime(dateTimePicker1.Text));
            dataGridView4.DataSource = classNew_state.get_fctr_on_state(Convert.ToDateTime(dateTimePicker1.Text));
            DateTime This_day = Convert.ToDateTime(dateTimePicker1.Text);
            #region Day
            lb_fct_achat_LAST.Text = classStatistirque.total_facture_Achat(This_day.ToString("yyyy-MM-dd"));
            versmenet_fctr_achat_last.Text = classStatistirque.total_versement_facture_Achat(This_day.ToString("yyyy-MM-dd"));

            lb_versement_anonymos_last.Text = classStatistirque.versement_facture_Vente_anonymos(This_day.ToString("yyyy-MM-dd"));
            versement_non_anonymos_last.Text = classStatistirque.versement_facture_Vente_non_anonymos(This_day.ToString("yyyy-MM-dd"));
            lb_versemnt_nrml_last.Text = classStatistirque.versemnt_normale(This_day.ToString("yyyy-MM-dd"));

            ttl_ttc1_last.Text = classStatistirque.versement_facture_Vente(This_day.ToString("yyyy-MM-dd"));
            ttl_cout1_last.Text = classStatistirque.cout_facteure_vente(This_day.ToString("yyyy-MM-dd"));
            depense1_lasr.Text = classStatistirque.cout_depense(This_day.ToString("yyyy-MM-dd"));
            ouver1_last.Text = classStatistirque.cout_ouverier(This_day.ToString("yyyy-MM-dd"));
            rtre_fyda1_last.Text = classStatistirque.deference_routeur(This_day.ToString("yyyy-MM-dd"));
            label5_last.Text = classStatistirque.total_facture_Vente(This_day.ToString("yyyy-MM-dd"));

            LB_FACTURE_VENTE_TTL_last.Text = classStatistirque.total_facture_Vente(This_day.ToString("yyyy-MM-dd"));
            LB_FACTUR_VENTE_VERSEMENT_lasr.Text = classStatistirque.versement_facture_Vente(This_day.ToString("yyyy-MM-dd"));
            LB_COUT_FACTURE_lat.Text = classStatistirque.cout_facteure_vente(This_day.ToString("yyyy-MM-dd"));
            LB_DEPENSE_last.Text = classStatistirque.cout_depense(This_day.ToString("yyyy-MM-dd"));
            LB_COUT_OUVERIER_last.Text = classStatistirque.cout_ouverier(This_day.ToString("yyyy-MM-dd"));
            lb_routeur_ttl_last.Text = classStatistirque.total_routeure_price(This_day.ToString("yyyy-MM-dd"));
            //lb_cout_routeur.Text = classStatistirque.cout_derouteure(DateTime.Now.ToString("yyyy-MM-dd"));
            lb_deference_routeur_last.Text = classStatistirque.deference_routeur(This_day.ToString("yyyy-MM-dd"));
            lb_credit_en_fct_last.Text = (decimal.Parse(LB_FACTURE_VENTE_TTL_last.Text) - decimal.Parse(LB_FACTUR_VENTE_VERSEMENT_lasr.Text)).ToString();
            decimal SortieMoney = decimal.Parse(ttl_cout1_last.Text) + decimal.Parse(depense1_lasr.Text) + decimal.Parse(ouver1_last.Text) + decimal.Parse(rtre_fyda1_last.Text);

            Lb_fayda_Total_last.Text = calcule_benifice_money(
                decimal.Parse(ttl_ttc1_last.Text), SortieMoney, decimal.Parse(label164.Text), decimal.Parse(label148.Text)
                ).ToString();

            #endregion
        }

        private void frm_statiq_e_detalle_Load(object sender, EventArgs e)
        {
            calculefacture_type2();
            calculeBenificie_journre();
        }
    }
}

    

