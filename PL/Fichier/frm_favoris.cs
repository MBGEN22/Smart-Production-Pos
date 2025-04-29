using iTextSharp.text.pdf;
using Smart_Production_Pos.BL.BL_FICHIER;
using Smart_Production_Pos.PL.Achat_revente;
using Smart_Production_Pos.PLADD.vente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Fichier
{
	public partial class frm_favoris : Form
	{
		BL.BL_FICHIER.BL_favoire classFav = new BL.BL_FICHIER.BL_favoire();
		public frm_favoris()
		{
			InitializeComponent(); LoadStockDataAsync();
			 
        }
        private async void LoadStockDataAsync()
        {
            // قم بتحميل البيانات بشكل غير متزامن
            var data = await Task.Run(() => classFav.select_table_fav());

            // تحديث واجهة المستخدم بعد تحميل البيانات
            this.dataGridView1.DataSource = data;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_add_favoris add_favoris = new PLADD.Fichier.frm_add_favoris();
			add_favoris.ShowDialog();
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{

		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_update_fav frmfav = new PLADD.Fichier.frm_update_fav();
			frmfav.frmFav = this;
			frmfav.id = (int)this.dataGridView1.CurrentRow.Cells[1].Value;
			frmfav.txt_reference.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString() ;
			frmfav.ShowDialog(); 
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{ 
			this.dataGridView1.DataSource = classFav.select_table_fav();
		}

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Dgv_empitying")
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        classFav.delete_all_fav((int)this.dataGridView1.CurrentRow.Cells[1].Value); 
                        classFav.delete_all_fav_pack((int)this.dataGridView1.CurrentRow.Cells[1].Value);
                        MessageBox.Show("تم التفريغ");
                    }
                    else
                    {
                        MessageBox.Show("حدث خطأ");
                    }
                }
             }
            catch
            {
            }
        }
    }
}
