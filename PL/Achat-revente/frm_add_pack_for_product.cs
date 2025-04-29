using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Achat_revente
{
    public partial class frm_add_pack_for_product : Form
    {
        BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
        int? Vr_check_favoire_U, Vr_check_color, Vr_check_taille, favoire_pack;
        BL.BL_ACHAT_REVENT.BL_PRODUIT classProduit = new BL.BL_ACHAT_REVENT.BL_PRODUIT();
        public frm_add_pack_for_product()
        {
            InitializeComponent(); 
            cmb_favoir_pack.DataSource = clasCombobox.get_combo_FAV();
            cmb_favoir_pack.DisplayMember = "FAVOIRE";
            cmb_favoir_pack.ValueMember = "ID";
        }
        private long GenerateRandomNumber1()
        {
            Random random = new Random();

            // Generate a random 10-digit number
            long randomNumberPart = random.Next(0, 10_000_000_0);

            // Append "612" to the randomè number to ensure it starts with "612"
            long randomNum = long.Parse("712" + randomNumberPart.ToString("D10"));

            return randomNum;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            long randomNum = GenerateRandomNumber1();

            // Display the random number in the textbox
            code_barre_pack.Text = randomNum.ToString();
            string barCode = code_barre_pack.Text;
            try
            {
                Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                pictureBox3.Image = brCode.Draw(barCode, 100);
                code_barre_packcode_barre_pack.Text = barCode;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog Ofd = new OpenFileDialog();
            Ofd.Filter = "Photo |*.JPG; *.PNG; *.GIF; *.BMP ";
            if (Ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image = Image.FromFile(Ofd.FileName);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        { 
            add_new_pack();
            MessageBox.Show("تم اضافة حزمة بنجاح") ;
            this.Close();
        }
        private void add_new_pack()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox4.Image.Save(ms, pictureBox4.Image.RawFormat);
            byte[] byteImage = ms.ToArray();
            float Qtpack_ttl = float.Parse(qt_dans_pack_txt.Text) * float.Parse(nmbre_pack.Text);
            if (check_fav_pack.Checked == true)
            {
                favoire_pack = Convert.ToInt32(cmb_favoir_pack.SelectedValue);
            }
            else if (check_fav_pack.Checked == false)
            {
                favoire_pack = null;
            }


            string barCode = txtBarcode.Text;
            Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum; 
            pictureBox3.Image = brCode.Draw(barCode, 100);
            using (MemoryStream mss = new MemoryStream())
            {
                System.Drawing.Image barcodeImage = brCode.Draw(barCode, 100);
                barcodeImage.Save(mss, ImageFormat.Png); // Save the image in PNG format

                // Convert MemoryStream to byte array
                byte[] byteImage_br = mss.ToArray();

                // Call the method to add the picture
                classProduit.InsertPackProduitRevent(
                code_barre_pack.Text,
                txt_designation_pack.Text,
                txtBarcode.Text, Qtpack_ttl,
                decimal.Parse(txt_vente_pack.Text),
                byteImage,
                favoire_pack,
                byteImage_br
                );
                 
            }


           

            classProduit.update_QT_dans_pack(
                txtBarcode.Text,
                float.Parse(qt_dans_pack_txt.Text)
                );
        }

        private void check_fav_pack_CheckedChanged(object sender, EventArgs e)
        {
            if (check_fav_pack.Checked == true)
            {
                cmb_favoir_pack.Enabled = true;
            }
            else if (check_fav_pack.Checked == false)
            {
                cmb_favoir_pack.Enabled = false;
            }
        }
    }
}
