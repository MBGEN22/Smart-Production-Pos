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
	public partial class frm_history_of_production : Form
	{
		BL.BL_PRODUCTION.BL_Prodution classProduction = new BL.BL_PRODUCTION.BL_Prodution();
		public frm_history_of_production()
		{
			InitializeComponent();
			this.dataGridView1.DataSource = classProduction.select_tb_history_production();
		}

		private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
		{

			this.dataGridView1.DataSource = classProduction.search_tb_history_production_by_code_barre(kryptonTextBox2.Text);
		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{

			this.dataGridView1.DataSource = classProduction.search_tb_history_production(kryptonTextBox1.Text);
		}

		private void button2_Click(object sender, EventArgs e)
		{

			this.dataGridView1.DataSource = classProduction.search_tb_history_production_by_date(Convert.ToDateTime(kryptonDateTimePicker1.Value));
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{

			this.dataGridView1.DataSource = classProduction.select_tb_history_production();
		}
	}
}
