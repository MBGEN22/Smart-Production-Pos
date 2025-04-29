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
	public partial class frm_unite : Form
	{
		BL.BL_FICHIER.BL_unite classUnite = new BL.BL_FICHIER.BL_unite();

		public frm_unite()
		{
			InitializeComponent(); LoadStockDataAsync();

        }
        private async void LoadStockDataAsync()
        {
            // قم بتحميل البيانات بشكل غير متزامن
            var data = await Task.Run(() => classUnite.get_tb_unite());

            // تحديث واجهة المستخدم بعد تحميل البيانات
            this.dataGridView1.DataSource = data;
        }
        private void kryptonButton1_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_unite add_unite = new PLADD.Fichier.frm_unite();
			add_unite.frm_unitte = this;
			add_unite.ShowDialog();
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			dataGridView1.DataSource = classUnite.get_tb_unite();
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_unite add_unite = new PLADD.Fichier.frm_unite();
			add_unite.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
			add_unite.txt_Stocke.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
			add_unite.frm_unitte = this;
			add_unite.ShowDialog();
		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classUnite.searche_list_stocke(kryptonTextBox1.Text);
			dataGridView1.DataSource = dt;
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				classUnite.delete_stockes((int)this.dataGridView1.CurrentRow.Cells[0].Value);
				dataGridView1.DataSource = classUnite.get_tb_unite();
				MessageBox.Show("تمت عملية الحذف بنجاح");
			}
		}
	}
}
