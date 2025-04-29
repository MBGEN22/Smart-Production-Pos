using ComponentFactory.Krypton.Toolkit;
using Smart_Production_Pos.BL.BL_FICHIER;
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
	public partial class frm_versement_ouverier : Form
	{
		BL.BL_Statistique.BL_la_PAye classLa_paye = new BL.BL_Statistique.BL_la_PAye();
		public int id_user;
		public frm_versement_ouverier()
		{
			InitializeComponent();
			dataGridView1.DataSource = classLa_paye.select_versement_ouverier();
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			dataGridView1.DataSource = classLa_paye.select_versement_ouverier();
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			PLADD.PL_Statistique.frm_add_versement_ouberier addDepense = new PLADD.PL_Statistique.frm_add_versement_ouberier();
			addDepense.ouverier = this;
			addDepense.id_user = id_user;
			addDepense.ShowDialog();
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			PLADD.PL_Statistique.frm_add_versement_ouberier addDepense = new PLADD.PL_Statistique.frm_add_versement_ouberier();
			DataTable dt = new DataTable();
			dt = classLa_paye.select_versement_ouverier();
			if (dt.Rows.Count > 0)
			{
				addDepense.ouverier = this;
				addDepense.id_user = id_user;
				addDepense.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
				addDepense.txtDate.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells[1].Value);
				addDepense.txt_remarque.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
				addDepense.txt_money.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
				addDepense.cmb_ouverier.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
				addDepense.ShowDialog();
			}
			else
			{
				MessageBox.Show("لاتوجد بيانات لتعديلها");
			}
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				DataTable dt = new DataTable();
				dt = classLa_paye.select_versement_ouverier();
				if (dt.Rows.Count > 0)
				{
					classLa_paye.delte_ouverier((int)this.dataGridView1.CurrentRow.Cells[0].Value);
					dataGridView1.DataSource = classLa_paye.select_versement_ouverier();
					MessageBox.Show("تمت عملية الحذف  بنجاح");
				}
				else
				{
					MessageBox.Show("لاتوجد بيانات  لحذفها");
				}
			}
		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{ 
			dataGridView1.DataSource = classLa_paye.search_select_versement_ouverier(kryptonTextBox1.Text);
		}
	}
}
