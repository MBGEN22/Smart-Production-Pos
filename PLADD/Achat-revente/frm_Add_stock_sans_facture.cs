using ComponentFactory.Krypton.Toolkit;
using Smart_Production_Pos.PL.Achat_revente;
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

namespace Smart_Production_Pos.PLADD.Achat_revente
{
    public partial class frm_Add_stock_sans_facture : Form
    {
        BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
        BL.BL_ACHAT_REVENT.BL_PRODUIT classProduit = new BL.BL_ACHAT_REVENT.BL_PRODUIT();
        BL.BL_ACHAT_REVENT.BL_ACHAT classAchat = new BL.BL_ACHAT_REVENT.BL_ACHAT();
        BL.BL_ACHAT_REVENT.BL_calculate classCalculate = new BL.BL_ACHAT_REVENT.BL_calculate();
        string vente_apres_expiration; string stocke_negatif;
        public string id_fctr;
        int? Vr_check_favoire_U, Vr_check_color, Vr_check_taille, favoire_pack , id_categorie , id_marque , id_stock , id_unite;
        public PL.Achat_revente.Frm_Achat form_achat;
        public frm_stock_produit_revente formstck;
        public string Type;
        public frm_Add_stock_sans_facture()
        {
            InitializeComponent(); 
            cmb_categories.DataSource = clasCombobox.get_combo_Categorie();
            cmb_categories.DisplayMember = "CATEGORIES";
            cmb_categories.ValueMember = "ID";

            cmb_marque.DataSource = clasCombobox.get_combo_Marque();
            cmb_marque.DisplayMember = "Marque";
            cmb_marque.ValueMember = "ID";

            cmb_stocke.DataSource = clasCombobox.get_combo_stock();
            cmb_stocke.DisplayMember = "STOCKE";
            cmb_stocke.ValueMember = "ID";

            cmb_unite.DataSource = clasCombobox.get_combo_Iunite();
            cmb_unite.DisplayMember = "UNITE";
            cmb_unite.ValueMember = "ID";

            cmb_taille.DataSource = clasCombobox.get_combo_taille();
            cmb_taille.DisplayMember = "TAILLE";
            cmb_taille.ValueMember = "ID";

            cmb_color.DataSource = clasCombobox.get_combo_color();
            cmb_color.DisplayMember = "COLOR";
            cmb_color.ValueMember = "ID";

            cmb_favoire.DataSource = clasCombobox.get_combo_FAV();
            cmb_favoire.DisplayMember = "FAVOIRE";
            cmb_favoire.ValueMember = "ID";


            cmb_favoir_pack.DataSource = clasCombobox.get_combo_FAV();
            cmb_favoir_pack.DisplayMember = "FAVOIRE";
            cmb_favoir_pack.ValueMember = "ID";
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
        private long GenerateRandomNumber()
        {
            Random random = new Random();

            // Generate a random 10-digit number
            long randomNumberPart = random.Next(0, 10_000_000_0);

            // Append "612" to the random number to ensure it starts with "612"
            long randomNum = long.Parse("612" + randomNumberPart.ToString("D9"));

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
                lbBrCode.Text = barCode;
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

        private void check_taille_CheckedChanged(object sender, EventArgs e)
        {
            if (check_taille.Checked == true)
            {
                cmb_taille.Enabled = true;
            }
            else if (check_taille.Checked == false)
            {
                cmb_taille.Enabled = false;
            }
        }

        private void check_color_CheckedChanged(object sender, EventArgs e)
        {
            if (check_color.Checked == true)
            {
                cmb_color.Enabled = true;
            }
            else if (check_color.Checked == false)
            {
                cmb_color.Enabled = false;
            }
        }

        private void label36_Click(object sender, EventArgs e)
        {
            frm_calcule_by_pack_sans_fctr add_info_by_pack = new frm_calcule_by_pack_sans_fctr();
            add_info_by_pack.add_achat = this;
            add_info_by_pack.ShowDialog();
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

        private void txt_achat_ttc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_achat_ht.Text = calcule_TVA(
              decimal.Parse(txt_achat_ttc.Text),
              decimal.Parse(txt_tva.Text)
              ).ToString();
            }
            catch
            {
            }
        }

        private void txt_tva_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_tva.Text))
                {
                    txt_tva.Text = "0";
                }

                txt_achat_ht.Text = calcule_TVA(
                    decimal.Parse(txt_achat_ttc.Text),
                    decimal.Parse(txt_tva.Text)
                    ).ToString();
            }
            catch
            {
            }
        }

        private void txt_vente_1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //lb_marge_1.Text =
                //Marge_Calculate(float.Parse(txt_vente_1.Text), float.Parse(txt_achat_ttc.Text)).ToString() + " %";
                //if (Marge_Calculate(float.Parse(txt_vente_1.Text), float.Parse(txt_achat_ttc.Text)) < 0)
                //{
                //    lb_marge_1.ForeColor = Color.Red;
                //}
                //else
                //{
                //    lb_marge_min.ForeColor = Color.Green;
                //}
            }
            catch
            {
            }
        }

        private void txt_vente_2_TextChanged(object sender, EventArgs e)
        {
            try
            {
            //    lb_marge_2.Text =
            //Marge_Calculate(float.Parse(txt_vente_2.Text), float.Parse(txt_achat_ttc.Text)).ToString() + " %";
            //    if (Marge_Calculate(float.Parse(txt_vente_2.Text), float.Parse(txt_achat_ttc.Text)) < 0)
            //    {
            //        lb_marge_2.ForeColor = Color.Red;
            //    }
            //    else
            //    {
            //        lb_marge_min.ForeColor = Color.Green;
            //    }
            }
            catch
            {
            }
        }

        private void txt_vente_min_TextChanged(object sender, EventArgs e)
        {
            try
            {
            //    lb_marge_min.Text =
            //Marge_Calculate(float.Parse(txt_vente_min.Text), float.Parse(txt_achat_ttc.Text)).ToString() + " %";
            //    if (Marge_Calculate(float.Parse(txt_vente_min.Text), float.Parse(txt_achat_ttc.Text)) < 0)
            //    {
            //        lb_marge_min.ForeColor = Color.Red;
            //    }
            //    else
            //    {
            //        lb_marge_min.ForeColor = Color.Green;
            //    }
            }
            catch
            {
            }
        }
        public decimal calcule_TVA(decimal PrixeTTc, decimal TVA)
        {
            decimal priceHT = PrixeTTc / (1 + (TVA / 100));
            priceHT = Math.Round(priceHT, 2);
            return priceHT;
        }
        private float Marge_Calculate(float PriceVente, float Price_achat)
        {
            float Marge = ((PriceVente / Price_achat) - 1) * 100;
            return Marge;
        }

        private void qt_dans_pack_txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                nmbre_pack.Text = get_number_pack(
                                float.Parse(txt_qt.Text),
                                float.Parse(qt_dans_pack_txt.Text)
                                ).ToString();
            }
            catch
            {
            }
        }
        private float get_number_pack(float numberTotal, float numberDansPack)
        {
            float numberPack = numberTotal / numberDansPack;
            numberPack = (float)Math.Round(numberPack, 2);
            return numberPack;
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

        private void txt_qt_TextChanged(object sender, EventArgs e)
        {
            try
            { 
                qt_rest.Text = txt_qt.Text;
                qt_vente.Text = calculeVente(float.Parse(txt_qt.Text), float.Parse(qt_rest.Text)).ToString();
            }
            catch
            {

            }
        }
        private float calculeVente(float QT_TLL , float QT_rest)
        {
            float QT_VEnte = QT_TLL - QT_rest;
            return QT_VEnte;
        }
        private float calculatAlertByPack(float QTONPACK, float QTPACK)
        {
            float Alert = QTPACK * QTONPACK;
            return Alert;
        }
        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TXTqT_ALERT.Text = calculatAlertByPack(float.Parse(qt_dans_pack_txt.Text), float.Parse(kryptonTextBox2.Text)).ToString();
            }
            catch
            {

            }
        }

        private void check_Pack_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Pack.Checked == true)
            {
                crownGroupBox1.Enabled = true;
                kryptonTextBox2.Enabled = true;
                crownGroupBox1.Visible = true;
            }
            else if (check_Pack.Checked == false)
            {
                crownGroupBox1.Enabled = false;
                kryptonTextBox2.Enabled = false;
                crownGroupBox1.Visible = false;

            }
        }

        private void qt_rest_TextChanged(object sender, EventArgs e)
        {
            try
            {
                qt_vente.Text = calculeVente(float.Parse(txt_qt.Text), float.Parse(qt_rest.Text)).ToString();
            }
            catch
            {

            }
        }

        private void qt_vente_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            PLADD.Fichier.frm_categories categories = new Fichier.frm_categories();
            categories.Type = "c";
            categories.frm_achat_sans_fctr = this;
            categories.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PLADD.Fichier.frm_add_Stockes categories = new Fichier.frm_add_Stockes();
            categories.Type = "c";
            categories.frm_achat_sans_fctr = this;
            categories.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PLADD.Fichier.frm_add_marque categories = new Fichier.frm_add_marque();
            categories.Type = "c";
            categories.frm_achat_sans_fctr = this;
            categories.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PLADD.Fichier.frm_unite categories = new Fichier.frm_unite();
            categories.Type = "c";
            categories.frm_achat_sans_fctr = this;
            categories.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PLADD.Fichier.frm_add_taille categories = new Fichier.frm_add_taille();
            categories.Type = "c";
            categories.frm_achat_sans_fctr = this;
            categories.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PLADD.Fichier.frm_add_favoris addColor = new PLADD.Fichier.frm_add_favoris();
            addColor.Type = "c";
            addColor.frm_achat_sans_fctr = this;
            addColor.ShowDialog();
        }

        private void frm_Add_stock_sans_facture_Load(object sender, EventArgs e)
        {
            if (check_Pack.Checked == true)
            {
                crownGroupBox1.Enabled = true;
                kryptonTextBox2.Enabled = true;
                crownGroupBox1.Visible = true;
            }
            else if (check_Pack.Checked == false)
            {
                crownGroupBox1.Enabled = false;
                kryptonTextBox2.Enabled = false;
                crownGroupBox1.Visible = false; 
            }
            txt_tva.Text = Properties.Settings.Default.tva;
            TXTqT_ALERT.Text = Properties.Settings.Default.alert;
            txtihtiyadj.Text = Properties.Settings.Default.ihtiyaj;

            if (Properties.Settings.Default.txt_referennce == "true")
            {
                label28.Visible = true;
                txt_reference.Visible = true;
            }
            else
            {
                label28.Visible = false;
                txt_reference.Visible = false;
            }

            if (Properties.Settings.Default.txt_categorie == "true")
            {
                label5.Visible = true;
                cmb_categories.Visible = true;
                button5.Visible = true;
            }
            else
            {
                label5.Visible = false;
                cmb_categories.Visible = false;
                button5.Visible = false;
            }

            if (Properties.Settings.Default.check_Stock == "true")
            {
                label6.Visible = true;
                cmb_stocke.Visible = true;
                button2.Visible = true;
            }
            else
            {
                label6.Visible = false;
                cmb_stocke.Visible = false;
                button2.Visible = false;
            }

            if (Properties.Settings.Default.txt_marque == "true")
            {
                label11.Visible = true;
                cmb_marque.Visible = true;
                button7.Visible = true;
            }
            else
            {

                label11.Visible = false;
                cmb_marque.Visible = false;
                button7.Visible = false;
            }

            if (Properties.Settings.Default.txt_unite == "true")
            {
                label7.Visible = true;
                cmb_unite.Visible = true;
                button3.Visible = true;
            }
            else
            {
                label7.Visible = false;
                cmb_unite.Visible = false;
                button3.Visible = false;
            }

            if (Properties.Settings.Default.txt_taille == "true")
            {
                label4.Visible = true;
                check_taille.Visible = true;
                cmb_taille.Visible = true;
                button4.Visible = true;
            }
            else
            {

                label4.Visible = false;
                check_taille.Visible = false;
                cmb_taille.Visible = false;
                button4.Visible = false;
            }

            if (Properties.Settings.Default.txt_couleur == "true")
            {
                cmb_color.Visible = true;
                label12.Visible = true;
                check_color.Visible = true;
                button8.Visible = true;
            }
            else
            {
                cmb_color.Visible = false;
                label12.Visible = false;
                check_color.Visible = false;
                button8.Visible = false;
            }

            if (Properties.Settings.Default.txt_fav == "true")
            {
                cmb_favoire.Visible = true;
                label13.Visible = true;
                check_favoire_U.Visible = true;
            }
            else
            {
                cmb_favoire.Visible = false;
                label13.Visible = false;
                check_favoire_U.Visible = false;
            }

            if (Properties.Settings.Default.txt_date_expir == "true")
            {
                check_date_expiration.Visible = true;
                date_expiration.Visible = true;
            }
            else
            {
                check_date_expiration.Visible = false;
                date_expiration.Visible = false;
            }
            //-------------------------------------------------------------------------->   
            if (Properties.Settings.Default.photo_produit == "true")
            {
                pictureBox2.Visible = true;
            }
            else
            {
                pictureBox2.Visible = false;
            }

            if (Properties.Settings.Default.photo_code_barre == "true")
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }

            if (Properties.Settings.Default.txt_prix_ht == "true")
            {
                label10.Visible = true;
                txt_achat_ht.Visible = true;
            }
            else
            {
                label10.Visible = false;
                txt_achat_ht.Visible = false;
            }

            if (Properties.Settings.Default.txt_tva == "true")
            {
                label9.Visible = true;
                txt_tva.Visible = true;
            }
            else
            {
                label9.Visible = false;
                txt_tva.Visible = false;
            }

            

            if (Properties.Settings.Default.txt_price_2 == "true")
            {
                txt_vente_2.Visible = true;
                label17.Visible = true;
            }
            else
            {
                txt_vente_2.Visible = false;
                label17.Visible = false;
            }

            if (Properties.Settings.Default.txt_price_3 == "true")
            {
                txt_vente_min.Visible = true;
                label21.Visible = true;
            }
            else
            {
                txt_vente_min.Visible = false;
                label21.Visible = false;
            }

            if (Properties.Settings.Default.txt_benifice_1 == "true")
            {
                lb_marge_1.Visible = true;
                label23.Visible = true;
            }
            else
            {
                lb_marge_1.Visible = false;
                label23.Visible = false;
            }

            if (Properties.Settings.Default.txt_benifice_2 == "true")
            {
                lb_marge_2.Visible = true;
                label25.Visible = true;
            }
            else
            {
                lb_marge_2.Visible = false;
                label25.Visible = false;
            }

            if (Properties.Settings.Default.txt_benifice_3 == "true")
            {
                lb_marge_min.Visible = true;
                label27.Visible = true;
            }
            else
            {
                lb_marge_min.Visible = false;
                label27.Visible = false;
            }

            if (Properties.Settings.Default.chech_vente_after_expiration == "true")
            {
                vente_apres_expiration_check.Visible = true;
            }
            else
            {
                vente_apres_expiration_check.Visible = false;
            }

            if (Properties.Settings.Default.check_vente_after_qt == "true")
            {
                stocke_negatif_check.Visible = true;
            }
            else
            {
                stocke_negatif_check.Visible = false;
            }

            if (Properties.Settings.Default.txt_qt_alert == "true")
            {
                TXTqT_ALERT.Visible = true;
                label24.Visible = true;
            }
            else
            {
                TXTqT_ALERT.Visible = false;
                label24.Visible = false;
            }

            if (Properties.Settings.Default.txt_qt_ihiyaj == "true")
            {
                txtihtiyadj.Visible = true;
                label26.Visible = true;
            }
            else
            {
                txtihtiyadj.Visible = false;
                label26.Visible = false;
            }


        }

        private void txt_designation_TextChanged(object sender, EventArgs e)
        {
            txt_designation_pack.Text = txt_designation.Text + " /Pack";
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
                txt_achat_ttc.Focus();
            }
        }

        private void txt_achat_ttc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_tva.Focus();
            }
        }

        private void txt_tva_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_achat_ht.Focus();
            }
        }

        private void txt_achat_ht_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_qt.Focus();
            }
        }

        private void txt_vente_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_vente_2.Focus();
            }
        }
        private decimal calculeBy_pourcentage(decimal price_achat, decimal prntge)
        {
            decimal price_vente = price_achat + ((price_achat * prntge) / 100);
            return price_vente;
        }
        private void lb_marge_1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_vente_1.Text = calculeBy_pourcentage(decimal.Parse(txt_achat_ttc.Text), decimal.Parse(lb_marge_1.Text)).ToString();
            }
            catch
            {

            }
        }

        private void lb_marge_2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_vente_2.Text = calculeBy_pourcentage(decimal.Parse(txt_achat_ttc.Text), decimal.Parse(lb_marge_2.Text)).ToString();
            }
            catch
            {

            }
        }

        private void lb_marge_min_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_vente_min.Text = calculeBy_pourcentage(decimal.Parse(txt_achat_ttc.Text), decimal.Parse(lb_marge_min.Text)).ToString();
            }
            catch
            {

            }
        }

        private void txt_designation_ImeModeChanged(object sender, EventArgs e)
        {

        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_achat_ht_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void txt_qt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                qt_rest.Focus();
            }
        }

        private void qt_rest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_vente_1.Focus();
            }
        }

        private void txt_vente_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_vente_min.Focus();
            }
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (Type == "A")
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
                            add_new_product();
                            if (check_Pack.Checked == true)
                            {
                                add_new_pack();
                            }
                            this.Close(); 
                            MessageBox.Show("تم اضافة المنتوج بنجاح الى المخزن");
                        }
                    }
                }
                else
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
                            add_new_product();
                            if (check_Pack.Checked == true)
                            {
                                add_new_pack();
                            }
                            this.Close();
                            formstck.dataGridView1.DataSource = classProduit.get_stock_produit_revenet();
                            formstck.lbttl_rest.Text = classProduit.inventaire_Total().ToString();
                            formstck.lb_ttl_Qt.Text = classProduit.inventaire_TotalQT_TTL().ToString();
                            formstck.lb_ttl_vente.Text = classProduit.inventaire_TotalQT_VENTE().ToString();
                            formstck.lblCount_produit.Text = classProduit.Count_Ttl_produit().ToString();
                            MessageBox.Show("تم اضافة المنتوج بنجاح الى المخزن");
                        }
                    }
                }
            }
            catch
            {

            } 
        }
        private void add_new_product()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
            byte[] byteImage = ms.ToArray();

            int? qt_pack = null;
            DateTime? datePeretion = null;
            string produitPies;
            int stock_min;

            if (check_Pack.Checked == true)
            {
                qt_pack = Convert.ToInt32(qt_dans_pack_txt.Text);
            }
            else
            {
                qt_pack = null;
            }


            if (check_date_expiration.Checked == true)
            {
                datePeretion = Convert.ToDateTime(date_expiration.Value);
            }
            else
            {
                datePeretion = null;
            }


            if (check_favoire_U.Checked == true)
            {
                produitPies = "yes";
            }
            else
            {
                produitPies = "no";
            }
            if (vente_apres_expiration_check.Checked == true)
            {
                vente_apres_expiration = "oui";
            }
            else if (vente_apres_expiration_check.Checked == false)
            {
                vente_apres_expiration = "non";
            }
            if (stocke_negatif_check.Checked == true)
            {
                stocke_negatif = "oui";
            }
            else if (stocke_negatif_check.Checked == false)
            {
                stocke_negatif = "non";
            }


            if (check_favoire_U.Checked == true)
            {
                Vr_check_favoire_U = Convert.ToInt32(cmb_favoire.SelectedValue);
            }
            else if (check_favoire_U.Checked == false)
            {
                Vr_check_favoire_U = null;
            }


            if (check_taille.Checked == true)
            {
                Vr_check_taille = Convert.ToInt32(cmb_taille.SelectedValue);
            }
            else if (check_taille.Checked == false)
            {
                Vr_check_taille = null;
            }


            if (check_color.Checked == true)
            {
                Vr_check_color = Convert.ToInt32(cmb_color.SelectedValue);
            }
            else if (check_color.Checked == false)
            {
                Vr_check_color = null;
            }

            DataTable dt_categorie = new DataTable();
            DataTable dt_marque = new DataTable();
            DataTable dt_stock = new DataTable();
            DataTable dt_unite = new DataTable();

            dt_categorie = clasCombobox.get_combo_Categorie(); 

            dt_marque = clasCombobox.get_combo_Marque(); 

            dt_stock = clasCombobox.get_combo_stock(); 

            dt_unite = clasCombobox.get_combo_Iunite();

            // id_categorie , id_marque , id_stock , id_unite
            if (dt_categorie.Rows.Count == 0)
            {
                id_categorie = null;
            }
            else
            {
                id_categorie = Convert.ToInt32(cmb_categories.SelectedValue);

            }
            if (dt_marque.Rows.Count == 0)
            {
                id_marque = null;
            }
            else
            {
                id_marque = Convert.ToInt32(cmb_marque.SelectedValue);
            }
            if (dt_stock.Rows.Count == 0)
            {
                id_stock = null;
            }
            else
            {
                id_stock = Convert.ToInt32(cmb_stocke.SelectedValue);
            }
            if (dt_unite.Rows.Count == 0)
            {
                id_unite = null;
            }
            else
            {
                id_unite = Convert.ToInt32(cmb_unite.SelectedValue);
            }

            classProduit.Add_Funct(
                txtBarcode.Text,
                txt_designation.Text,
                txt_reference.Text,
                id_categorie,
                id_stock,
                id_marque,
                id_unite,
                Vr_check_taille,//taille
                Vr_check_color,//color
                Vr_check_favoire_U,//favoire
                datePeretion,
                decimal.Parse(txt_achat_ht.Text),
                decimal.Parse(txt_achat_ttc.Text),
                float.Parse(txt_tva.Text),
                float.Parse(txt_qt.Text),
                decimal.Parse(txt_vente_1.Text),
                decimal.Parse(txt_vente_2.Text),
                decimal.Parse(txt_vente_min.Text),
                vente_apres_expiration,
                stocke_negatif,
                float.Parse(qt_vente.Text),
                float.Parse(qt_rest.Text),
                0,
                byteImage,
                qt_pack,
                float.Parse(TXTqT_ALERT.Text),
                float.Parse(txtihtiyadj.Text)
                );
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
        }

    }
}


