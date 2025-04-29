using Smart_Production_Pos.BL;
using Smart_Production_Pos.BL.BL_FICHIER;
using Smart_Production_Pos.PL.Fichier;
using Smart_Production_Pos.PL.vente;
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
	public partial class tab_vente : UserControl
	{
		public int id_user; 
		Sp_Logine classLogine = new Sp_Logine();
        int facture_vente;
        int list_vente;
        int liv;
        int POS;
        public tab_vente()
		{
			InitializeComponent();
		}

		private void button6_Click(object sender, EventArgs e)
		{
            frm_logine_facturation frmCaisse = new frm_logine_facturation();
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
                frmCaisse.Show();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

		private void button3_Click(object sender, EventArgs e)
		{
			PL.vente.frm_facture_vente frm_fctr = new PL.vente.frm_facture_vente();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][21];
                facture_vente = Convert.ToInt32(stock);

            }
            if (facture_vente == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_fctr.panel5);
                frm_fctr.id_user = id_user;
                //change_color_whene_click(button1);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void button4_Click(object sender, EventArgs e)
		{
			PL.vente.frm_list_vente frm_fctr = new PL.vente.frm_list_vente();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][22];
                list_vente = Convert.ToInt32(stock);

            }
            if (list_vente == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_fctr.panel1);
                //change_color_whene_click(button1);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void button1_Click(object sender, EventArgs e)
		{
			PL.vente.frm_Livraison frm_fctr = new PL.vente.frm_Livraison();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][23];
                liv = Convert.ToInt32(stock);

            }
            if (liv == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_fctr.pn_historique_client);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void buttond6_Click(object sender, EventArgs e)
		{
            if (Properties.Settings.Default.FORMVENTE == 1)
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
            }
            else if (Properties.Settings.Default.FORMVENTE == 2)
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
                    frmCaisse.Type = "B";
                    frmCaisse.ShowDialog();
                }
                else
                {
                    MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
                }
            }
               
            
		}

        private void button5_Click(object sender, EventArgs e)
        {
            PL.PL_reparation.frm_reparation frm_reparation = new PL.PL_reparation.frm_reparation();
            frm_reparation.id_user = id_user ;
            frm_reparation.ShowDialog();
        }
    }
}
