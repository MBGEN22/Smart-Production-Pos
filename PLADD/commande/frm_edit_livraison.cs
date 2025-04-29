using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.commande
{
	public partial class frm_edit_livraison : Form
	{
		public string id;
		public int id_livraison;
		public string id_commande;
		public int Count = 0;
		BL.Bl_commande.BL_sub_commande class_Sub_Commande = new BL.Bl_commande.BL_sub_commande();
		public frm_edit_livraison()
		{
			InitializeComponent();
		}

		private void frm_edit_livraison_Load(object sender, EventArgs e)
		{
			textBox1.Text = id.ToString();
			this.dataGridView1.DataSource = class_Sub_Commande.get_detailles_sub_commande(id_commande);
			//this.dataGridView1.DataSource = ; //get_datagrid_view //
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (textBox3.Text == string.Empty || textBox3.Text == "")
			{
				MessageBox.Show("يرجى اولا اختيار المنتوج بالضغط مرتيين عليه");
			}
			else
			{
				//edit commande quantite 
				class_Sub_Commande.EDIT_not_COMPLETE_ORDER(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox2.Text));
				Count = Count + Convert.ToInt32(textBox2.Text);
				MessageBox.Show("تم تعديل الكمية بنجاح");
				Count = Count + Convert.ToInt32(textBox2.Text);

				//insert_historique_livraison 
				class_Sub_Commande.add_info_livraison(
					id_livraison,
					Convert.ToInt32(textBox3.Text),
					Convert.ToInt32(textBox2.Text)
					);
				this.dataGridView1.DataSource = class_Sub_Commande.get_detailles_sub_commande(id_commande);
				textBox3.Text = ""; textBox2.Text = "";
			}
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			textBox3.Text = (this.dataGridView1.CurrentRow.Cells[0].Value).ToString();
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
			{
				e.Handled = true; // Prevent the character from being entered
			}
		}
	}
}
