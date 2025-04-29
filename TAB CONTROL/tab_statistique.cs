using Smart_Production_Pos.BL;
using Smart_Production_Pos.BL.BL_FICHIER;
using Smart_Production_Pos.PL.Statistique;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.TAB_CONTROL
{
	public partial class tab_statistique : UserControl
    {
        Sp_Logine classLogine = new Sp_Logine();
        public int id_user;
        int les_charge;
        int lapie;
        int transition_caissier;
        int state_total;
        int benifice;
        public tab_statistique()
		{
			InitializeComponent();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			PL.Statistique.frm_depense frm_stock = new PL.Statistique.frm_depense();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][25];
                les_charge = Convert.ToInt32(stock);

            }
            if (les_charge == 1)
            {
                frm_stock.id_user = id_user;
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_stock.pn_caissier);
                //change_color_whene_click(button4);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void button2_Click(object sender, EventArgs e)
		{
			PL.Statistique.frm_Statistique_generale frm_stock = new PL.Statistique.frm_Statistique_generale();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][28];
                state_total = Convert.ToInt32(stock);

            }
            if (state_total == 1)
            {
                //frm_stock.id_user = id_user;
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_stock.panel19);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
		}

		private void button5_Click(object sender, EventArgs e)
		{
			PL.Statistique.frm_versement_ouverier frm_stock = new PL.Statistique.frm_versement_ouverier();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][26];
                lapie = Convert.ToInt32(stock);

            }
            if (lapie == 1)
            {
                frm_stock.id_user = id_user;
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_stock.pn_caissier);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void button1_Click(object sender, EventArgs e)
		{
			PL.Statistique.frm_historique_caisier frm_stock = new PL.Statistique.frm_historique_caisier();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][27];
                transition_caissier = Convert.ToInt32(stock);

            }
            if (transition_caissier == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_stock.panel1);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void button3_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            PL.Statistique.frm_statiq_e_detalle Frm_state = new PL.Statistique.frm_statiq_e_detalle();
            Frm_state.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frm_inventaire inventaire = new frm_inventaire();
            inventaire._id_user = id_user;
            inventaire.ShowDialog();
        }
    }
}
