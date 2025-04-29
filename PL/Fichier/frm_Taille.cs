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

namespace Smart_Production_Pos.PL.Fichier
{
	public partial class frm_Taille : Form
	{
		BL.BL_FICHIER.classe_taille classe_taill = new BL.BL_FICHIER.classe_taille();

		public frm_Taille()
		{
			InitializeComponent(); LoadStockDataAsync();
			 
		}
        private async void LoadStockDataAsync()
        {
            // قم بتحميل البيانات بشكل غير متزامن
            var data = await Task.Run(() => classe_taill.select_tb_taille());

            // تحديث واجهة المستخدم بعد تحميل البيانات
            this.dataGridView1.DataSource = data;
        }
        private void kryptonButton1_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_add_taille add_taille = new PLADD.Fichier.frm_add_taille();
			add_taille.formTaille = this;
			add_taille.ShowDialog();
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_add_taille add_taille = new PLADD.Fichier.frm_add_taille();
			add_taille.formTaille = this;
			add_taille.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
			add_taille.txt_taille.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
			add_taille.ShowDialog();
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = classe_taill.select_tb_taille();
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{
			DialogResult Dg = MessageBox.Show("ستتم عملية حذف هذا اللون هل انت متأكد", "عملية حذف البيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (Dg == DialogResult.Yes)
			{
				classe_taill.delte_taille((int)this.dataGridView1.CurrentRow.Cells[0].Value);
				dataGridView1.DataSource = classe_taill.select_tb_taille();
				MessageBox.Show("تمت عملية الحذف بنجاح");
			}
		}

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
