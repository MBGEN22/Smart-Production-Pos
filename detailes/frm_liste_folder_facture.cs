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

namespace Smart_Production_Pos.detailes
{
	public partial class frm_liste_folder_facture : Form
	{
		BL.BL_Achats.BL_facture classFolder = new BL.BL_Achats.BL_facture();
		public frm_liste_folder_facture()
		{
			InitializeComponent();
			this.dataGridView1.DataSource = classFolder.GET_LIST_UPLOAD_FACTURE_ACHAT();
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			frm_image_facture preview = new frm_image_facture();
			byte[] image = (byte[])classFolder.GET_LIST_UPLOAD_FACTURE_ACHAT_img((int)this.dataGridView1.CurrentRow.Cells[0].Value).Rows[0][0];
			MemoryStream ms = new MemoryStream(image);
			preview.pictureBox1.Image = Image.FromStream(ms);
			preview.ShowDialog();
		}

		private void txt_seach_TextChanged(object sender, EventArgs e)
		{

			DataTable dt = new DataTable();
			dt = classFolder.search_upload_fichier_facture(txt_seach.Text);
			this.dataGridView1.DataSource = dt;
		}
	}
}
