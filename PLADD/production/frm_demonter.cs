using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.production
{
	public partial class frm_demonter : Form
	{
		BL.BL_PRODUCTION.BL_Prodution classProduction = new BL.BL_PRODUCTION.BL_Prodution();
		public frm_demonter()
		{
			InitializeComponent();
			this.dataGridView1.DataSource = classProduction.select_TB_HISTORIQUE_DEMONTER();

		}

		private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = classProduction.search_TB_HISTORIQUE_DEMONTER_by_code_baree(kryptonTextBox2.Text);
		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{

			this.dataGridView1.DataSource = classProduction.search_TB_HISTORIQUE_DEMONTER(kryptonTextBox1.Text);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = classProduction.search_TB_HISTORIQUE_DEMONTER_by_date(Convert.ToDateTime(kryptonDateTimePicker1.Value));
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{

			this.dataGridView1.DataSource = classProduction.select_TB_HISTORIQUE_DEMONTER();
		}
	}
}
