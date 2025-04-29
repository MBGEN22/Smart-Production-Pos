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
	public partial class frm_ouverier : Form
	{
		BL.BL_FICHIER.BL_ouverier classOuverier = new BL.BL_FICHIER.BL_ouverier();
		public frm_ouverier()
		{
			InitializeComponent(); LoadStockDataAsync();
		}
        private async void LoadStockDataAsync()
        {
            // قم بتحميل البيانات بشكل غير متزامن
            var data = await Task.Run(() => classOuverier.get_tb_ouverier());

            // تحديث واجهة المستخدم بعد تحميل البيانات
            this.dataGridView1.DataSource = data;
        }
        private void kryptonButton1_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_add_ouverier add_ouverier = new PLADD.Fichier.frm_add_ouverier();
			add_ouverier.frmOuverier = this;
			add_ouverier.ShowDialog();
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_add_ouverier add_ouverier = new PLADD.Fichier.frm_add_ouverier();
			add_ouverier.frmOuverier = this;
			add_ouverier.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
			add_ouverier.txt_name.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
			add_ouverier.txt_prename.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
			add_ouverier.txt_fnction.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
			add_ouverier.txt_phone.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString(); 
			add_ouverier.ShowDialog();
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				classOuverier.delte_ouverierID((int)this.dataGridView1.CurrentRow.Cells[0].Value);
				dataGridView1.DataSource = classOuverier.get_tb_ouverier();
				MessageBox.Show("تمت عملية الحذف بنجاح");
			}
		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{
			DataTable dtt = new DataTable();
			dtt = classOuverier.search_ouverier(txtSearch.Text);
			dataGridView1.DataSource = dtt;
		}
	}
}
