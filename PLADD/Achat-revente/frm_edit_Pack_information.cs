using Smart_Production_Pos.PL.Achat_revente;
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

namespace Smart_Production_Pos.PLADD.Achat_revente
{
	public partial class frm_edit_Pack_information : Form
	{
		BL.BL_ACHAT_REVENT.BL_PRODUIT classsProduit = new BL.BL_ACHAT_REVENT.BL_PRODUIT();
		BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
		BL.BL_ACHAT_REVENT.BL_produit_reserve classProduit = new BL.BL_ACHAT_REVENT.BL_produit_reserve();
		string vente_apres_expiration; string stocke_negatif;
		public string id_fctr;
		int? Vr_check_favoire_U, Vr_check_color, Vr_check_taille, favoire_pack;
		public frm_stock_pack formStock;

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			try
			{
                MemoryStream ms = new MemoryStream();
                pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
                byte[] byteImage = ms.ToArray();

                if (check_favoire_U.Checked == true)
                {
                    Vr_check_favoire_U = Convert.ToInt32(cmb_favoire.SelectedValue);
                }
                else if (check_favoire_U.Checked == false)
                {
                    Vr_check_favoire_U = null;
                }

                classProduit.edit_pack_information(
                    txtBarcode.Text,
                    txt_designation.Text,
                    decimal.Parse(txt_vente_1.Text),
                    byteImage,
                    Vr_check_favoire_U
                    );
                formStock.dataGridView1.DataSource = classsProduit.get_stock_pack();
                MessageBox.Show("تم تعديل معلومات الحزمة  بنجاح اضغط على تحديث");
                this.Close();
            }
			catch
			{
                 
                if (check_favoire_U.Checked == true)
                {
                    Vr_check_favoire_U = Convert.ToInt32(cmb_favoire.SelectedValue);
                }
                else if (check_favoire_U.Checked == false)
                {
                    Vr_check_favoire_U = null;
                }

                classProduit.edit_pack_info_without_pctr(
                    txtBarcode.Text,
                    txt_designation.Text,
                    decimal.Parse(txt_vente_1.Text), 
                    Vr_check_favoire_U
                    );
                formStock.dataGridView1.DataSource = classsProduit.get_stock_pack();
                MessageBox.Show("تم تعديل معلومات الحزمة  بنجاح اضغط على تحديث");
                this.Close();
            }
				
		}
		

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			OpenFileDialog Ofd = new OpenFileDialog();
			Ofd.Filter = "Photo |*.JPG; *.PNG; *.JPEG; *.GIF; *.BMP ";
			if (Ofd.ShowDialog() == DialogResult.OK)
			{
				pictureBox2.Image = Image.FromFile(Ofd.FileName);
			}
		}

		public frm_edit_Pack_information()
		{
			InitializeComponent();
			cmb_favoire.DataSource = clasCombobox.get_combo_FAV();
			cmb_favoire.DisplayMember = "FAVOIRE";
			cmb_favoire.ValueMember = "ID";
		}

		private void check_favoire_U_CheckedChanged(object sender, EventArgs e)
		{
			if (check_favoire_U.Checked == true)
			{
				cmb_favoire.Enabled = true;
				cmb_favoire.DataSource = clasCombobox.get_combo_FAV();
				cmb_favoire.DisplayMember = "FAVOIRE";
				cmb_favoire.ValueMember = "ID";
			}
			else if (check_favoire_U.Checked == false)
			{
				cmb_favoire.Enabled = false;
			}
		}
	}
}
