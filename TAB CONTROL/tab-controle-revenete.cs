using Smart_Production_Pos.BL;
using Smart_Production_Pos.BL.BL_FICHIER;
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

namespace Smart_Production_Pos.TAB_CONTROL
{
	public partial class tab_controle_revenete : UserControl
    {
        Sp_Logine classLogine = new Sp_Logine();
        public int id_user; 
        int achat;
        int facture_achat;
        int dossier_fctr_achat;
        int historique_frnsre;
        public tab_controle_revenete()
		{
			InitializeComponent();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			PL.Achat_revente.Frm_Achat frmachat = new PL.Achat_revente.Frm_Achat();

            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][15];
                achat = Convert.ToInt32(stock);

            }
            if (achat == 1)
            {
                frmachat.id_user = id_user;
                frmachat.Show();
                //Form1.getMainForm.pn_container.Controls.Clear();
                //Form1.getMainForm.pn_container.Controls.Add(frmachat.pn_achats);
                change_color_whene_click(button4);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			PL.Achat_revente.frm_facture frmachat = new PL.Achat_revente.frm_facture();
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
                Form1.getMainForm.pn_container.Controls.Add(frmachat.pn_fctre);
                change_color_whene_click(button1);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void kryptonSeparator3_SplitterMoved(object sender, SplitterEventArgs e)
		{

		}
		public void change_color_whene_click(Button bt)
		{
			this.button1.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button2.BackColor = Color.Transparent;
			this.button4.BackColor = Color.Transparent; 
			this.button5.BackColor = Color.Transparent;
			this.button6.BackColor = Color.Transparent;
			this.button7.BackColor = Color.Transparent; 
			bt.BackColor = Color.LightSeaGreen;
		}
		private void button5_Click(object sender, EventArgs e)
		{
			PL.Achats.frm_facture frm_fctr = new PL.Achats.frm_facture();
			Form1.getMainForm.pn_container.Controls.Clear();
			Form1.getMainForm.pn_container.Controls.Add(frm_fctr.pn_fctre);
			change_color_whene_click(button5);
		}

		private void button6_Click(object sender, EventArgs e)
		{
			detailes.frm_liste_folder_facture list_facture_folder = new detailes.frm_liste_folder_facture();
			Form1.getMainForm.pn_container.Controls.Clear();
			Form1.getMainForm.pn_container.Controls.Add(list_facture_folder.pn_list_folder);
			change_color_whene_click(button6);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			PL.Achats.frm_historique_fournisseur frmhistorique_fournisseur = new PL.Achats.frm_historique_fournisseur();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][18];
                dossier_fctr_achat = Convert.ToInt32(stock);

            }
            if (dossier_fctr_achat == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frmhistorique_fournisseur.pn_marque);
                change_color_whene_click(button3);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}
		 
		private void button7_Click(object sender, EventArgs e)
		{
			PL.Achats.frm_achat frmachat = new PL.Achats.frm_achat();
			Form1.getMainForm.pn_container.Controls.Clear();
			frmachat.id_user = id_user;
			Form1.getMainForm.pn_container.Controls.Add(frmachat.pn_achats);
			change_color_whene_click(button7);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			PL.Achat_revente.FRM_fichier_fctr_produit_revente list_facture_folder = new PL.Achat_revente.FRM_fichier_fctr_produit_revente();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][17];
                dossier_fctr_achat = Convert.ToInt32(stock);

            }
            if (dossier_fctr_achat == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(list_facture_folder.pn_list_folder);
                change_color_whene_click(button6);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}
	}
}
