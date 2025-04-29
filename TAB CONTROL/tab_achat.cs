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
	public partial class tab_achat : UserControl
	{
		public tab_achat()
		{
			InitializeComponent();
		}
		public void change_color_whene_click(Button bt)
		{
			this.button1.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button2.BackColor = Color.Transparent; 
			this.button4.BackColor = Color.Transparent; 
			bt.BackColor = Color.LightSeaGreen;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			PL.Achats.frm_achat frmachat = new PL.Achats.frm_achat();
			Form1.getMainForm.pn_container.Controls.Clear();
			Form1.getMainForm.pn_container.Controls.Add(frmachat.pn_achats);
			change_color_whene_click(button4);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			detailes.frm_liste_folder_facture list_facture_folder = new detailes.frm_liste_folder_facture();
			Form1.getMainForm.pn_container.Controls.Clear();
			Form1.getMainForm.pn_container.Controls.Add(list_facture_folder.pn_list_folder);
			change_color_whene_click(button2);
		}

		private void button5_Click(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			PL.Achats.frm_facture frm_fctr = new PL.Achats.frm_facture();
			Form1.getMainForm.pn_container.Controls.Clear();
			Form1.getMainForm.pn_container.Controls.Add(frm_fctr.pn_fctre);
			change_color_whene_click(button1);
		}

		private void button3_Click_1(object sender, EventArgs e)
		{
			PL.Achats.frm_historique_fournisseur frmhistorique_fournisseur= new PL.Achats.frm_historique_fournisseur();
			Form1.getMainForm.pn_container.Controls.Clear();
			Form1.getMainForm.pn_container.Controls.Add(frmhistorique_fournisseur.pn_marque);
			change_color_whene_click(button3);
		}
	}
}
