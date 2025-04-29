using Smart_Production_Pos.BL.BL_Achats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.detailes
{
	public partial class frm_details_product_M_P : Form
	{
		public string id_produit;
		BL_Produit classProduit = new BL_Produit();

		public frm_details_product_M_P()
		{
			InitializeComponent();
		}

		private void frm_details_product_M_P_Load(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = classProduit.get_detailles(id_produit);
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			classProduit.insert_option_product(
				id_produit , 
				txt_detaille.Text,
				txt_value.Text
				);
			this.dataGridView1.DataSource = classProduit.get_detailles(id_produit);
			MessageBox.Show("تم اضافة معلومات المنتج بنجاح");
			txt_detaille.Text = txt_value.Text = "";
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				classProduit.delte_detailles((int)this.dataGridView1.CurrentRow.Cells[0].Value);
				dataGridView1.DataSource = classProduit.get_detailles(id_produit);
				MessageBox.Show("تمت عملية الحذف بنجاح");
			}
		}
	}
}
