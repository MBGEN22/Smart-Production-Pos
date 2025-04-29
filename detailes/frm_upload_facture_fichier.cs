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
	public partial class frm_upload_facture_fichier : Form
	{
		BL.BL_Achats.BL_facture class_facture = new BL.BL_Achats.BL_facture();
		public string id_facture;
		public frm_upload_facture_fichier()
		{
			InitializeComponent();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			OpenFileDialog Ofd = new OpenFileDialog();
			Ofd.Filter = "Photo |*.JPG; *.PNG; *.GIF; *.BMP ";
			if (Ofd.ShowDialog() == DialogResult.OK)
			{
				pictureBox1.Image = Image.FromFile(Ofd.FileName);
			}
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			MemoryStream ms = new MemoryStream();
			pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
			byte[] byteImage = ms.ToArray();

			class_facture.INSERT_upload_folder(id_facture, txt_detaille.Text, byteImage);
			MessageBox.Show("تم التحميل بنجاح");
			this.Close();
		}
	}
}
