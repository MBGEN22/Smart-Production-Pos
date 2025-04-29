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
	public partial class frm_color : Form
	{
		BL.BL_FICHIER.class_color classeColor = new BL.BL_FICHIER.class_color();

		public frm_color()
		{
			InitializeComponent(); LoadStockDataAsync();
		}
        private async void LoadStockDataAsync()
        {
            // قم بتحميل البيانات بشكل غير متزامن
            var data = await Task.Run(() => classeColor.select_TB_color());

            // تحديث واجهة المستخدم بعد تحميل البيانات
            this.dataGridView1.DataSource = data;
        }
        private void kryptonButton1_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_add_favoris addColor = new PLADD.Fichier.frm_add_favoris();
			addColor.formColor = this;
			addColor.ShowDialog();
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_add_favoris addColor = new PLADD.Fichier.frm_add_favoris();
			addColor.formColor = this;
			addColor.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
			addColor.txt_color.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
			addColor.ShowDialog();
			
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{ 
			this.dataGridView1.DataSource = classeColor.select_TB_color();
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{
			DialogResult Dg = MessageBox.Show("ستتم عملية حذف هذا اللون هل انت متأكد", "عملية حذف البيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if(Dg == DialogResult.Yes)
			{
				classeColor.delete_color_((int)this.dataGridView1.CurrentRow.Cells[0].Value);
				dataGridView1.DataSource = classeColor.select_TB_color();
				MessageBox.Show("تمت عملية الحذف بنجاح");
			}
		}

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
