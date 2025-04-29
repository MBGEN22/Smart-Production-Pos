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
	public partial class frm_tools_Commande : Form
	{
		BL.Bl_commande.BL_TOOLS Class_command_tools = new BL.Bl_commande.BL_TOOLS();
		public string id_commande;
		public frm_tools_Commande()
		{
			InitializeComponent();
		}

		private void frm_tools_Commande_Load(object sender, EventArgs e)
		{
			this.grid_sub_commande.DataSource = Class_command_tools.get_tools_commande(id_commande);
		}
	}
}
