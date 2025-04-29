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
	public partial class frm_categories : Form
	{
		BL.BL_FICHIER.BL_Categories classUnite = new BL.BL_FICHIER.BL_Categories();

		public frm_categories()
		{
			InitializeComponent();
			LoadStockDataAsync(); 
		}
        private async void LoadStockDataAsync()
        {
            // قم بتحميل البيانات بشكل غير متزامن
            var data = await Task.Run(() => classUnite.get_tb_Categories());

            // تحديث واجهة المستخدم بعد تحميل البيانات
            this.dataGridView1.DataSource = data;
        }
        private void kryptonButton1_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_categories add_categories = new PLADD.Fichier.frm_categories();
			add_categories.frm_categoriess = this;
			add_categories.ShowDialog();
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_categories add_categories = new PLADD.Fichier.frm_categories();
			add_categories.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
			add_categories.txt_Stocke.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
			add_categories.frm_categoriess = this;
			add_categories.ShowDialog();
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				classUnite.delte_CATEGORIES((int)this.dataGridView1.CurrentRow.Cells[0].Value);
				dataGridView1.DataSource = classUnite.get_tb_Categories();
				MessageBox.Show("تمت عملية الحذف بنجاح");
			}
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			dataGridView1.DataSource = classUnite.get_tb_Categories();

		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classUnite.searche_list_Categories(kryptonTextBox1.Text);
			dataGridView1.DataSource = dt;
		}
	}
}
