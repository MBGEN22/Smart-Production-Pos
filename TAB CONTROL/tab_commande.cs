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
	public partial class tab_commande : UserControl
	{
		public int id_user;
		public tab_commande()
		{
			InitializeComponent();
		}

		private void tab_commande_Load(object sender, EventArgs e)
		{

		}
		public void change_color_whene_click(Button bt)
		{
			this.button1.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button4.BackColor = Color.Transparent;
			this.button6.BackColor = Color.Transparent;
			this.button2.BackColor = Color.Transparent;

			bt.BackColor = Color.LightSeaGreen;
		}

		private void button6_Click(object sender, EventArgs e)
		{
			PL.Commande.frm_commande frm_commande = new PL.Commande.frm_commande();
			Form1.getMainForm.pn_container.Controls.Clear();
			frm_commande.id_user = id_user;
			Form1.getMainForm.pn_container.Controls.Add(frm_commande.pn_commande);
			change_color_whene_click(button6);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			PL.Commande.frm_facture_commande frm_commande = new PL.Commande.frm_facture_commande();
			Form1.getMainForm.pn_container.Controls.Clear();
			Form1.getMainForm.pn_container.Controls.Add(frm_commande.pn_historique_client);
			change_color_whene_click(button1);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			PL.Commande.frm_sub_commande frm_commande = new PL.Commande.frm_sub_commande();
			Form1.getMainForm.pn_container.Controls.Clear();
			Form1.getMainForm.pn_container.Controls.Add(frm_commande.pn_sub_commande);
			change_color_whene_click(button4);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			PL.Commande.frm_livraison frm_livraison = new PL.Commande.frm_livraison();
			Form1.getMainForm.pn_container.Controls.Clear();
			Form1.getMainForm.pn_container.Controls.Add(frm_livraison.pn_historique_client);
			change_color_whene_click(button3);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			PL.Commande.frm_facture_vierge frm_livraison = new PL.Commande.frm_facture_vierge();
			Form1.getMainForm.pn_container.Controls.Clear();
			Form1.getMainForm.pn_container.Controls.Add(frm_livraison.panel1);
			change_color_whene_click(button2);
		}

		private void kryptonSeparator3_SplitterMoved(object sender, SplitterEventArgs e)
		{

		}

		private void kryptonSeparator1_SplitterMoved(object sender, SplitterEventArgs e)
		{

		}

		private void kryptonSeparator2_SplitterMoved(object sender, SplitterEventArgs e)
		{

		}
	}
}
