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
	public partial class frm_fournisseur : Form
	{
		BL.BL_FICHIER.BL_Fournisseur classFournisseur = new BL.BL_FICHIER.BL_Fournisseur();
		public frm_fournisseur()
		{
			InitializeComponent(); LoadStockDataAsync();
		}
        private async void LoadStockDataAsync()
        {
            // قم بتحميل البيانات بشكل غير متزامن
            var data = await Task.Run(() => classFournisseur.Get_clien_Table());

            // تحديث واجهة المستخدم بعد تحميل البيانات
            this.dataGridView1.DataSource = data;
        }
        private void kryptonButton1_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_add_fournisseures add_fournisseure = new PLADD.Fichier.frm_add_fournisseures();
			add_fournisseure.frm_fournisseur = this;
			add_fournisseure.ShowDialog();
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_add_fournisseures add_fournisseure = new PLADD.Fichier.frm_add_fournisseures();
			add_fournisseure.frm_fournisseur = this;
			add_fournisseure.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
			add_fournisseure.name_client.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
			add_fournisseure.prename_client.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
			add_fournisseure.txt_adress.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
			add_fournisseure.txt_phone.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
			add_fournisseure.txt_fax.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
			add_fournisseure.txt_email.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
			add_fournisseure.txt_total.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
			add_fournisseure.txt_versé.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
			add_fournisseure.txt_rest.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString(); 
			add_fournisseure.txt_nif.Text = this.dataGridView1.CurrentRow.Cells[10].Value.ToString();
			add_fournisseure.txt_rc.Text = this.dataGridView1.CurrentRow.Cells[11].Value.ToString();
			add_fournisseure.txt_nic.Text = this.dataGridView1.CurrentRow.Cells[12].Value.ToString();
			add_fournisseure.txt_article.Text = this.dataGridView1.CurrentRow.Cells[13].Value.ToString();
			add_fournisseure.ShowDialog();
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{

			this.dataGridView1.DataSource = classFournisseur.Get_clien_Table();
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				classFournisseur.delte_Client((int)this.dataGridView1.CurrentRow.Cells[0].Value);
				dataGridView1.DataSource = classFournisseur.Get_clien_Table();
				MessageBox.Show("تمت عملية الحذف بنجاح");
			}
		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{
			DataTable dtt = new DataTable();
			dtt =  classFournisseur.search_fournisseur(txtSearch.Text);
			dataGridView1.DataSource = dtt; 
		}

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (dataGridView1.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.ColumnHeader ||
                dataGridView1.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.TopLeftHeader)
            {
                ContextMenu menu = new ContextMenu();

                //add item to the menu
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    MenuItem item = new MenuItem();
                    item.Text = column.HeaderText;
                    item.Checked = column.Visible;

                    //now let add the event if the item was cheked
                    item.Click += (obj, ea) =>
                    {
                        column.Visible = !item.Checked;

                        //update the check
                        item.Checked = column.Visible;

                        //show the selection item 
                        menu.Show(dataGridView1, e.Location);
                    };
                    menu.MenuItems.Add(item);
                }
                //show the menu 
                menu.Show(dataGridView1, e.Location);

            }
        }
    }
}
