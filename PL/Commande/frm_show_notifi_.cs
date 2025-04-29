using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Commande
{
	public partial class frm_show_notifi_ : Form
	{
		BL.Bl_commande.Bl_commande cmd = new BL.Bl_commande.Bl_commande();
		public int id;
		public frm_show_notifi_()
		{
			InitializeComponent();
		}

		private void frm_show_notifi__Load(object sender, EventArgs e)
		{
			dataGridView1.DataSource = cmd.get_notification(id);
		}
	}
}
