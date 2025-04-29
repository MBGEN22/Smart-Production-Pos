using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.production
{
	public partial class frm_pack : Form
	{
		BL.BL_PRODUCTION.BL_GESTION_PRODUIT_FINAUX class_Production = new BL.BL_PRODUCTION.BL_GESTION_PRODUIT_FINAUX();
		public frm_pack()
		{
			InitializeComponent();
			this.dataGridView1.DataSource = class_Production.get_tab_pack();
		}

		private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
		{
			kryptonRadioButton1.Checked = false;
			this.dataGridView1.DataSource = class_Production.search_pack_by_code_barre(kryptonTextBox2.Text);

		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{
			kryptonRadioButton1.Checked = false;
			this.dataGridView1.DataSource = class_Production.search_get_table_pack(kryptonTextBox1.Text);
		}

		private void kryptonRadioButton1_CheckedChanged(object sender, EventArgs e)
		{ 
			this.dataGridView1.DataSource = class_Production.get_tab_pack();
		}
	}
}
