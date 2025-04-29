using Smart_Production_Pos.detailes;
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

namespace Smart_Production_Pos.PL.Achat_revente
{
	public partial class FRM_fichier_fctr_produit_revente : Form
	{
		BL.BL_ACHAT_REVENT.BL_facture classFActure = new BL.BL_ACHAT_REVENT.BL_facture();
		public FRM_fichier_fctr_produit_revente()
		{
			InitializeComponent();
			dataGridView1.DataSource = classFActure.get_fichier_facture_produit_prevent();
		}

		private void txt_seach_TextChanged(object sender, EventArgs e)
		{ 
			dataGridView1.DataSource = classFActure.search_fichier_facture_produit_prevent(txt_seach.Text);
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			show_image_fichier_facture preview = new show_image_fichier_facture();
			byte[] image = (byte[])classFActure.get_image_folder_produit_revernet((int)this.dataGridView1.CurrentRow.Cells[0].Value).Rows[0][0];
			MemoryStream ms = new MemoryStream(image);
			preview.pictureBox1.Image = Image.FromStream(ms);
			preview.ShowDialog();
		}
	}
}
