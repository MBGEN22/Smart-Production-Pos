using iTextSharp.text.pdf;
using Smart_Production_Pos.BL.BL_FICHIER;
using Smart_Production_Pos.report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace Smart_Production_Pos.PL.Achat_revente
{
    public partial class frm_add_produit_simple : Form
    {
        BL.BL_ACHAT_REVENT.BL_calculate classCalculate = new BL.BL_ACHAT_REVENT.BL_calculate();
        BL.BL_ACHAT_REVENT.BL_PRODUIT classProduit = new BL.BL_ACHAT_REVENT.BL_PRODUIT();
        BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
        int? Vr_check_favoire_U, Vr_check_color, Vr_check_taille, favoire_pack, id_categorie, id_marque, id_stock, id_unite;
        int? qt_pack;
        // Initialize the SoundPlayer with the MemoryStream 

        public frm_add_produit_simple()
        {
            InitializeComponent();
            cmb_favoire.DataSource = clasCombobox.get_combo_FAV();
            cmb_favoire.DisplayMember = "FAVOIRE";
            cmb_favoire.ValueMember = "ID";


            cmb_favoir_pack.DataSource = clasCombobox.get_combo_FAV();
            cmb_favoir_pack.DisplayMember = "FAVOIRE";
            cmb_favoir_pack.ValueMember = "ID";
        }

        private decimal calcule_Prix_achat(decimal Price_Pack, decimal nbr_dans_Pack)
        {
            decimal Price_achat = Price_Pack / nbr_dans_Pack;
            return Price_achat;
        }
        private float Calcule_ALL_QT(float QT_Dans_pack , float nbr_pack)
        {
            float all_Qt = QT_Dans_pack * nbr_pack; 
            return all_Qt;
        }
        ///////////////////////////////////////////////////////////////////////////////
        private void frm_add_produit_simple_Load(object sender, EventArgs e)
        {
            if (yes.Checked == true)
            {
                crownGroupBox1.Enabled = true;
            }
            else if (no.Checked == true)
            {
                crownGroupBox1.Enabled = false;
            }  
        }
        
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            string barCode = txtBarcode.Text;
            try
            {
                Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                pictureBox1.Image = brCode.Draw(barCode, 100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txt_designation_TextChanged(object sender, EventArgs e)
        {
            txt_designation_pack.Text = txt_designation.Text + " /Pack";
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void cmb_favoire_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void yes_CheckedChanged(object sender, EventArgs e)
        {
            if (yes.Checked == true)
            {
                crownGroupBox1.Enabled = true;
            }
            else if (no.Checked == true)
            {
                crownGroupBox1.Enabled = false;
            }
        }

        private void no_CheckedChanged(object sender, EventArgs e)
        {
            if (yes.Checked == true)
            {
                crownGroupBox1.Enabled = true;
            }
            else if (no.Checked == true)
            {
                crownGroupBox1.Enabled = false;
            }
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

        private void code_barre_pack_TextChanged(object sender, EventArgs e)
        {
            string barCode = code_barre_pack.Text;
            try
            {
                Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                pictureBox3.Image = brCode.Draw(barCode, 100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private long GenerateRandomNumber()
        {
            Random random = new Random();

            // Generate a random 9-digit number
            long randomNumberPart = random.Next(0, 1_000_000_000);

            // Append "612" to the random number to ensure it starts with "612"
            string randomNumStr = "612" + randomNumberPart.ToString("D9");

            // Convert the 12-digit number string back to long
            long randomNum = long.Parse(randomNumStr);

            return randomNum;
        }
        private void button1_Click(object sender, EventArgs e)
        { 
            long randomNum = GenerateRandomNumber();

            // Display the random number in the textbox
            txtBarcode.Text = randomNum.ToString();
            string barCode = txtBarcode.Text;
            try
            {
                Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                pictureBox1.Image = brCode.Draw(barCode, 100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private long GenerateRandomNumber1()
        {
            Random random = new Random();

            // Generate a random 10-digit number
            long randomNumberPart = random.Next(0, 10_000_000_0);

            // Append "612" to the randomè number to ensure it starts with "612"
            long randomNum = long.Parse("712" + randomNumberPart.ToString("D9"));

            return randomNum;
        }
        private void GENERATE_PACKClick(object sender, EventArgs e)
        {
            long randomNum = GenerateRandomNumber1();

            // Display the random number in the textbox
            code_barre_pack.Text = randomNum.ToString();
            string barCode = code_barre_pack.Text;
            try
            {
                Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                pictureBox3.Image = brCode.Draw(barCode, 100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_achat_ttc.Text = calcule_Prix_achat(decimal.Parse(Pric_Pack_achat.Text), decimal.Parse(QT_Dans_ack.Text)).ToString("F2");
            }
            catch
            {

            }
        }

        private void txt_designation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBarcode.Focus();
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Pric_Pack_achat.Focus();
            }
        }

        private void Pric_Pack_achat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                QT_Dans_ack.Focus();
            }
        }

        private void QT_Dans_ack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nbr_pack.Focus();
            }
        }

        private void nbr_pack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_achat_ttc.Focus();
            }
        }

        private void txt_achat_ttc_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txt_qt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_qt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_vente_1.Focus();
            }
        }

        private void txt_achat_ttc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_vente_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // تشغيل لوحة المفاتيح الافتراضية
                Process.Start("osk.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Problème", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void check_date_expiration_CheckedChanged(object sender, EventArgs e)
        {
            if (check_date_expiration.Checked == true)
            {
                date_expiration.Enabled = true;
            }
            else if (check_date_expiration.Checked == false)
            {
                date_expiration.Enabled = false;
            }
        }

        private void nbr_pack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_qt.Text = Calcule_ALL_QT(float.Parse(QT_Dans_ack.Text), float.Parse(nbr_pack.Text)).ToString("F2");
                txt_achat_ttc.Text = calcule_Prix_achat(decimal.Parse(Pric_Pack_achat.Text), decimal.Parse(QT_Dans_ack.Text)).ToString("F2");
            }
            catch
            {
            }
        }

        private void QT_Dans_ack_TextChanged(object sender, EventArgs e)
        {
            try 
            {
                txt_qt.Text = Calcule_ALL_QT(float.Parse(QT_Dans_ack.Text), float.Parse(nbr_pack.Text)).ToString("F2");
                txt_achat_ttc.Text = calcule_Prix_achat(decimal.Parse(Pric_Pack_achat.Text), decimal.Parse(QT_Dans_ack.Text)).ToString("F2");
            }
            catch
            {

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog Ofd = new OpenFileDialog();
            Ofd.Filter = "Photo |*.JPG; *.PNG; *.GIF; *.BMP ;*.JPEG;";
            if (Ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(Ofd.FileName);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog Ofd = new OpenFileDialog();
            Ofd.Filter = "Photo |*.JPG; *.PNG; *.GIF; *.BMP ;*.JPEG;";
            if (Ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image = Image.FromFile(Ofd.FileName);
            }
        }
        private void add_new_product()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
            byte[] byteImage = ms.ToArray();

            if (no.Checked == true)
            {
                qt_pack = null;
            }
            else if (yes.Checked == true)
            {
                qt_pack = Convert.ToInt32(QT_Dans_ack.Text);
            }

            DateTime? datePeretion = null;
            string produitPies;
            int stock_min;
            String ente_apres_expiration = "oui"; 
            String stocke_negatif = "oui";

            Vr_check_taille = null;
            Vr_check_color = null;

            if (check_favoire_U.Checked == true)
            {
                Vr_check_favoire_U = Convert.ToInt32(cmb_favoire.SelectedValue);
            }
            else if (check_favoire_U.Checked == false)
            {
            }


            if (check_date_expiration.Checked == true)
            {
                datePeretion = Convert.ToDateTime(date_expiration.Value);
            }
            else
            {
                datePeretion = null;
            }



            DataTable dt_categorie = new DataTable();
            DataTable dt_marque = new DataTable();
            DataTable dt_stock = new DataTable();
            DataTable dt_unite = new DataTable();

            dt_categorie = clasCombobox.get_combo_Categorie();

            dt_marque = clasCombobox.get_combo_Marque();

            dt_stock = clasCombobox.get_combo_stock();

            dt_unite = clasCombobox.get_combo_Iunite();

            id_categorie = null;
            id_marque = null;
            id_stock = null;
            id_unite = null;


            //TXTqT_ALERT.Text = Properties.Settings.Default.alert;
            //txtihtiyadj.Text = Properties.Settings.Default.ihtiyaj;

            classProduit.Add_Funct(
                txtBarcode.Text,
                txt_designation.Text,
                "",
                id_categorie,
                id_stock,
                id_marque,
                id_unite,
                Vr_check_taille,//taille
                Vr_check_color,//color
                Vr_check_favoire_U,//favoire
                datePeretion,
                decimal.Parse(txt_achat_ttc.Text),
                decimal.Parse(txt_achat_ttc.Text),
                0,
                float.Parse(txt_qt.Text),
                decimal.Parse(txt_vente_1.Text),
                decimal.Parse(txt_vente_1.Text),
                decimal.Parse(txt_vente_1.Text),
                "oui",
                stocke_negatif,
                0,
                float.Parse(txt_qt.Text),
                0,
                byteImage,
                qt_pack,
                Convert.ToInt32(Properties.Settings.Default.alert),
                Convert.ToInt32(Properties.Settings.Default.ihtiyaj)
                );

            
        }
         
        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            //txt_tva.Text = Properties.Settings.Default.tva;
            //TXTqT_ALERT.Text = Properties.Settings.Default.alert;
            //txtihtiyadj.Text = Properties.Settings.Default.ihtiyaj;
            // Charger le fichier MP3 depuis les ressources
            SoundPlayer sp = new SoundPlayer(Smart_Production_Pos.Properties.Resources.complete_sound_effectfree1); 

            try
            {
                if (txtBarcode.Text == "")
                {
                    MessageBox.Show("اضافة كود بار للمنتج واجب تأكد من ذلك");
                    txtBarcode.StateCommon.Back.Color1 = Color.Red;
                }
                else
                {
                    DataTable dtt = new DataTable();
                    dtt = classCalculate.get_count_product(txtBarcode.Text);
                    if (dtt.Rows.Count > 0)
                    {
                        MessageBox.Show("هذا المنتوج موجود سابقا في المخزن أو يشترك مع منتج اخر في نفس الرقم");
                        txtBarcode.StateCommon.Back.Color1 = Color.Red;
                    }
                    else
                    {
                        if (decimal.Parse(txt_achat_ttc.Text) > decimal.Parse(txt_vente_1.Text))
                        {
                            DialogResult dt = MessageBox.Show("تنبيه سعر الشراء أكثر من سعرالبيع وهذا خطأ اذا اردت الاستمرار اضغط على ok", "خطأ في كتابة السعر", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            if (dt == DialogResult.OK)
                            {
                                add_new_product();
                                if (yes.Checked == true)
                                { 
                                    add_new_pack();
                                }

                                string barCode = txtBarcode.Text;
                                Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

                                pictureBox2.Image = brCode.Draw(barCode, 100);
                                using (MemoryStream mss = new MemoryStream())
                                {
                                    System.Drawing.Image barcodeImage = brCode.Draw(barCode, 100);
                                    barcodeImage.Save(mss, ImageFormat.Png); // Save the image in PNG format

                                    // Convert MemoryStream to byte array
                                    byte[] byteImage = mss.ToArray();

                                    // Call the method to add the picture
                                    classProduit.add_picture(barCode, byteImage);
                                }

                                sp.Play();

                                this.Close();
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            add_new_product();
                            if (yes.Checked == true)
                            {
                                add_new_pack();
                            }
                            string barCode = txtBarcode.Text;
                            Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

                            pictureBox2.Image = brCode.Draw(barCode, 100);
                            using (MemoryStream mss = new MemoryStream())
                            {
                                System.Drawing.Image barcodeImage = brCode.Draw(barCode, 100);
                                barcodeImage.Save(mss, ImageFormat.Png); // Save the image in PNG format

                                // Convert MemoryStream to byte array
                                byte[] byteImage = mss.ToArray();

                                // Call the method to add the picture
                                classProduit.add_picture(barCode, byteImage);
                            }
                            sp.Play();
                            this.Close();
                        }
                       
                    }
                }
            }
            catch
            {

            }
        }
        private void add_new_pack()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox4.Image.Save(ms, pictureBox4.Image.RawFormat);
            byte[] byteImage = ms.ToArray();
            float Qtpack_ttl = float.Parse(QT_Dans_ack.Text) * float.Parse(nbr_pack.Text);
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
        }
    }
}
