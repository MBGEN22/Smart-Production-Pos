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
	public partial class frm_stockes : Form
	{
		BL.BL_FICHIER.BL_STOCKE classStock = new BL.BL_FICHIER.BL_STOCKE();

		public frm_stockes()
		{
			InitializeComponent();
            LoadStockDataAsync();
        }
        private async void LoadStockDataAsync()
        {
            // قم بتحميل البيانات بشكل غير متزامن
            var data = await Task.Run(() => classStock.get_Stockes_table());

            // تحديث واجهة المستخدم بعد تحميل البيانات
            this.dataGridView1.DataSource = data;
        }
        private void kryptonButton1_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_add_Stockes add_Stockes = new PLADD.Fichier.frm_add_Stockes();
			add_Stockes.frm_Stock = this;
			add_Stockes.ShowDialog();
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = classStock.get_Stockes_table();
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_add_Stockes add_Stockes = new PLADD.Fichier.frm_add_Stockes();
			add_Stockes.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
			add_Stockes.txt_Stocke.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
			add_Stockes.frm_Stock = this;
			add_Stockes.ShowDialog();
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				classStock.delete_stockes((int)this.dataGridView1.CurrentRow.Cells[0].Value);
				dataGridView1.DataSource = classStock.get_Stockes_table();
				MessageBox.Show("تمت عملية الحذف بنجاح");
			}
		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classStock.searche_list_stocke(kryptonTextBox1.Text);
			dataGridView1.DataSource = dt;
		}
	}
}
