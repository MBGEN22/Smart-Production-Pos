using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.detailes
{
	public partial class frm_detailles_fctrr : Form
	{
		BL.BL_Achats.BL_facture classFacture = new BL.BL_Achats.BL_facture();
		public string id_fctre;
		public frm_detailles_fctrr()
		{
			InitializeComponent();

		}

		private void frm_detailles_fctrr_Load(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = classFacture.get_detailles(id_fctre);
		}
	}
}
