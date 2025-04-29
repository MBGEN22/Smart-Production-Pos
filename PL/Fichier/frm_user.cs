using Smart_Production_Pos.PLADD.Fichier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Fichier
{
	public partial class frm_user : Form
	{
		BL.BL_FICHIER.BL_user classUSer = new BL.BL_FICHIER.BL_user();
		public frm_user()
		{
			InitializeComponent(); LoadStockDataAsync();
		}
        private async void LoadStockDataAsync()
        {
            // قم بتحميل البيانات بشكل غير متزامن
            var data = await Task.Run(() => classUSer.select_user_());

            // تحديث واجهة المستخدم بعد تحميل البيانات
            this.dataGridView1.DataSource = data;
        }
        private void kryptonButton1_Click(object sender, EventArgs e)
		{
			frm_add_user add_User = new frm_add_user();
			add_User.frm_uuser = this;
			add_User.ShowDialog();
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = classUSer.select_user_();
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			frm_add_user add_User = new frm_add_user();
			add_User.frm_uuser = this;
			add_User.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
			add_User.kryptonComboBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
			add_User.txt_user.Text =this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
			add_User.txt_pass.Text =this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
			add_User.cmb_type.Text =this.dataGridView1.CurrentRow.Cells[4].Value.ToString();

			add_User.ShowDialog();
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				classUSer.delte_Client((int)this.dataGridView1.CurrentRow.Cells[0].Value);
				dataGridView1.DataSource = classUSer.select_user_();
				MessageBox.Show("تمت عملية الحذف بنجاح");
			}
		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{
			DataTable dtt = new DataTable();
			dtt = classUSer.search_user(txtSearch.Text);
			dataGridView1.DataSource = dtt;
		}
	}
}
