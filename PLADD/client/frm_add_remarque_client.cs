using Smart_Production_Pos.PL.CLient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.client
{
	public partial class frm_add_remarque_client : Form
	{
		BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
		BL.BL_CLIENT.BL_REMARQUE_CLIENT classRemarque = new BL.BL_CLIENT.BL_REMARQUE_CLIENT();
		public frm_remarque_client frm_Remarque;
		public frm_add_remarque_client()
		{
			InitializeComponent(); 
			cmb_client.DataSource = clasCombobox.get_combo_client();
			cmb_client.DisplayMember = "Client";
			cmb_client.ValueMember = "ID";
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			classRemarque.add_tb_remarque_client
				(
				Convert.ToInt32(cmb_client.SelectedValue),
				kryptonTextBox1.Text
				);
			this.Close();
			frm_Remarque.dataGridView1.DataSource = classRemarque.get_tb_remarque_client();
		}
	}
}
