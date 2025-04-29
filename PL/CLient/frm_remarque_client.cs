using Smart_Production_Pos.PL.Fichier;
using Smart_Production_Pos.PLADD.client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.CLient
{
	public partial class frm_remarque_client : Form
	{
		BL.BL_CLIENT.BL_REMARQUE_CLIENT classRemarque = new BL.BL_CLIENT.BL_REMARQUE_CLIENT();

		public frm_remarque_client()
		{
			InitializeComponent();
			this.dataGridView1.DataSource = classRemarque.get_tb_remarque_client();

		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			frm_add_remarque_client add_remarque = new frm_add_remarque_client();
			add_remarque.frm_Remarque = this;
			add_remarque.ShowDialog();
		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{
			DataTable dts = new DataTable();
			dts = classRemarque.search_by_client(kryptonButton1.Text);
			dataGridView1.DataSource = dts;
		}
	}
}
