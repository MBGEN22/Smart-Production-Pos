using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Fichier
{
	public partial class frm_marque : Form
	{
		BL.BL_FICHIER.BL_Marque class_Marke = new BL.BL_FICHIER.BL_Marque();

		public frm_marque()
		{
			InitializeComponent(); LoadStockDataAsync();
			 
		}
        private async void LoadStockDataAsync()
        {
            // قم بتحميل البيانات بشكل غير متزامن
            var data = await Task.Run(() => class_Marke.get_TB_MARQUE());

            // تحديث واجهة المستخدم بعد تحميل البيانات
            this.dataGridView1.DataSource = data;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_add_marque add_marque = new PLADD.Fichier.frm_add_marque();
			add_marque.frm_marque = this;
			add_marque.ShowDialog();
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{

			PLADD.Fichier.frm_add_marque add_marque = new PLADD.Fichier.frm_add_marque();
			add_marque.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
			add_marque.txt_Stocke.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
			add_marque.frm_marque = this;
			add_marque.ShowDialog();
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				class_Marke.delte_TB_MARQUE((int)this.dataGridView1.CurrentRow.Cells[0].Value);
				dataGridView1.DataSource = class_Marke.get_TB_MARQUE();
				MessageBox.Show("تمت عملية الحذف بنجاح");
			}
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			dataGridView1.DataSource = class_Marke.get_TB_MARQUE();

		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = class_Marke.searche_list_Marque(kryptonTextBox1.Text);
			dataGridView1.DataSource = dt;
		}
	}
}
