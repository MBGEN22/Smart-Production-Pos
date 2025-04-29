using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Statistique
{
	public partial class frm_depense : Form
	{
		public int id_user;
		BL.BL_Statistique.BL_Depense classDepense = new BL.BL_Statistique.BL_Depense();
		public frm_depense()
		{
			InitializeComponent();
			this.dataGridView1.DataSource = classDepense.get_TB_depense();
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = classDepense.get_TB_depense();
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			PLADD.PL_Statistique.frm_add_depense addDepense = new PLADD.PL_Statistique.frm_add_depense();
			addDepense.depenseForm = this;
			addDepense.iduser = id_user;
			addDepense.ShowDialog();
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			PLADD.PL_Statistique.frm_add_depense addDepense = new PLADD.PL_Statistique.frm_add_depense();
			addDepense.depenseForm = this; 
			addDepense.iduser = id_user;
			addDepense.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
			addDepense.txt_causse.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString(); 
			addDepense.txt_money.Text =  this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
			addDepense.txtDate.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
			addDepense.ShowDialog();
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				classDepense.delte_depense((int)this.dataGridView1.CurrentRow.Cells[0].Value);
				dataGridView1.DataSource = classDepense.get_TB_depense();
				MessageBox.Show("تمت عملية الحذف  بنجاح");
			}
		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{

			this.dataGridView1.DataSource = classDepense.search_get_tb_depense(kryptonTextBox1.Text);
		}
	}
}
