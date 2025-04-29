using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.vente
{
	public partial class frm_list_vente : Form
	{
		BL.BL_vente.BL_class_vente classvente = new BL.BL_vente.BL_class_vente();
        BL.BL_vente.BL_FACTURE_VENTE class_facturation = new BL.BL_vente.BL_FACTURE_VENTE();
        public frm_list_vente()
		{
			InitializeComponent();
            kryptonDataGridView1.DataSource = classvente.listVente("فاتورة مكتملة");
            dataGridView1.DataSource = class_facturation.get_list_detaille_facture_vente();
        }

		private void panel3_Paint(object sender, PaintEventArgs e)
		{

		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			if (kryptonDataGridView1.Rows.Count > 0)
			{
				Microsoft.Office.Interop.Excel.ApplicationClass MExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
				MExcel.Application.Workbooks.Add(Type.Missing);
				for (int i = 1; i < kryptonDataGridView1.Columns.Count + 1; i++)
				{
					MExcel.Cells[1, i] = kryptonDataGridView1.Columns[i - 1].HeaderText;
				}
				for (int i = 0; i < kryptonDataGridView1.Rows.Count; i++)
				{
					for (int j = 0; j < kryptonDataGridView1.Columns.Count; j++)
					{
						MExcel.Cells[i + 2, j + 1] = kryptonDataGridView1.Rows[i].Cells[j].Value.ToString();
					}
				}
				MExcel.Columns.AutoFit();
				MExcel.Rows.AutoFit();
				MExcel.Columns.Font.Size = 12;
				MExcel.Visible = true;
			}
			else
			{
				MessageBox.Show("No records found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classvente.get_list_vente_By_date(Convert.ToDateTime(kryptonDateTimePicker1.Value) , "فاتورة مكتملة");
			kryptonDataGridView1.DataSource = dt;
		}

		private void kryptonDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{

		}

        private void frm_list_vente_Load(object sender, EventArgs e)
        { 
           
        }

        private void kryxtonButton2_Click(object sender, EventArgs e)
        { 
            kryptonDataGridView1.DataSource = classvente.listVente("فاتورة مكتملة");
        }

        private void kryptonDataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

            //if (kryptonDataGridView1.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.ColumnHeader ||
            //    kryptonDataGridView1.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.TopLeftHeader)
            //{
            //    ContextMenu menu = new ContextMenu();

            //    //add item to the menu
            //    foreach (DataGridViewColumn column in kryptonDataGridView1.Columns)
            //    {
            //        MenuItem item = new MenuItem();
            //        item.Text = column.HeaderText;
            //        item.Checked = column.Visible;

            //        //now let add the event if the item was cheked
            //        item.Click += (obj, ea) =>
            //        {
            //            column.Visible = !item.Checked;

            //            //update the check
            //            item.Checked = column.Visible;

            //            //show the selection item 
            //            menu.Show(kryptonDataGridView1, e.Location);
            //        };
            //        menu.MenuItems.Add(item);
            //    }
            //    //show the menu 
            //    menu.Show(kryptonDataGridView1, e.Location);

            //}
        }

        private void قخعفثعقث_Click(object sender, EventArgs e)
        {
			frm_routeure_article articleRouteur = new frm_routeure_article();
			articleRouteur.ShowDialog();
        }

        private void kryptonDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (kryptonDataGridView1.Columns[e.ColumnIndex].Name == "سعر البيع")
            {
                e.CellStyle.BackColor = Color.LightGreen; // اختر لون قريب
            }
            else if (kryptonDataGridView1.Columns[e.ColumnIndex].Name == "سعر المنتج")
            {
                e.CellStyle.BackColor = Color.LightBlue; // اختر لون قريب
            } 
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        { 
            dataGridView1.DataSource = class_facturation.get_list_detaille_facture_vente();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.ApplicationClass MExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                MExcel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    MExcel.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        MExcel.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                MExcel.Columns.AutoFit();
                MExcel.Rows.AutoFit();
                MExcel.Columns.Font.Size = 12;
                MExcel.Visible = true;
            }
            else
            {
                MessageBox.Show("No records found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = class_facturation.get_list_detaille_facture_vente_by_date(Convert.ToDateTime(kryptonDateTimePicker2.Value));
            kryptonDataGridView1.DataSource = dt;
        }
    }
}
