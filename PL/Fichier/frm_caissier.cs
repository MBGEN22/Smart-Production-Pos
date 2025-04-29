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
	public partial class frm_caissier : Form
	{
		BL.BL_FICHIER.BL_CAISSIER classclient = new BL.BL_FICHIER.BL_CAISSIER();
		public frm_caissier()
		{
			InitializeComponent(); 
			LoadStockDataAsync();

		}
        private async void LoadStockDataAsync()
        {
            // قم بتحميل البيانات بشكل غير متزامن
            var data = await Task.Run(() => classclient.get_tb_caissier());

            // تحديث واجهة المستخدم بعد تحميل البيانات
            this.dataGridView1.DataSource = data;
        }
        private void kryptonButton1_Click(object sender, EventArgs e)
		{
			PLADD.production.frm_add_caissier add_caissier = new PLADD.production.frm_add_caissier();
			add_caissier.frm_caissier = this;
			add_caissier.ShowDialog();
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			PLADD.production.frm_add_caissier add_caissier = new PLADD.production.frm_add_caissier();
			add_caissier.frm_caissier = this;
			add_caissier.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
			add_caissier.txt_prname.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
			add_caissier.txt_name.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
			add_caissier.txt_user.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
			add_caissier.txt_mdps.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
			add_caissier.ShowDialog();
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				classclient.delte_Client((int)this.dataGridView1.CurrentRow.Cells[0].Value);
				dataGridView1.DataSource = classclient.get_tb_caissier();
				MessageBox.Show("تمت عملية الحذف  بنجاح");
			}
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			dataGridView1.DataSource = classclient.get_tb_caissier();
		}

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			DataTable dtt = new DataTable();
			dtt = classclient.search_caisiier(txtSearch.Text);
			dataGridView1.DataSource = dtt;
		}
	}
}
