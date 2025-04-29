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
	public partial class tab_production : UserControl
	{
		public tab_production()
		{
			InitializeComponent();
		}
		public void change_color_whene_click(Button bt)
		{
			button1.BackColor = Color.Transparent;
			this.button3.BackColor = Color.Transparent;
			this.button4.BackColor = Color.Transparent;
			this.button6.BackColor = Color.Transparent;
			bt.BackColor = Color.LightSeaGreen;
		}
		private void button6_Click(object sender, EventArgs e)
		{
			PL.production.frm_gestion_product_finaux frm_production = new PL.production.frm_gestion_product_finaux();
			Form1.getMainForm.pn_container.Controls.Clear();
			Form1.getMainForm.pn_container.Controls.Add(frm_production.pn_historique_client);
			change_color_whene_click(button6);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			PLADD.production.frm_demonter frm_production = new PLADD.production.frm_demonter();
			Form1.getMainForm.pn_container.Controls.Clear();
			Form1.getMainForm.pn_container.Controls.Add(frm_production.pn_history_production);
			change_color_whene_click(button4);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			PL.production.frm_history_of_production history_production = new PL.production.frm_history_of_production();
			Form1.getMainForm.pn_container.Controls.Clear();
			Form1.getMainForm.pn_container.Controls.Add(history_production.pn_history_production);
			change_color_whene_click(button3);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			PL.production.frm_pack history_production = new PL.production.frm_pack();
			Form1.getMainForm.pn_container.Controls.Clear();
			Form1.getMainForm.pn_container.Controls.Add(history_production.pn_container);
			change_color_whene_click(button1);
		}
	}
}
