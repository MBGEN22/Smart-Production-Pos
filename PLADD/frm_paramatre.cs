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

namespace Smart_Production_Pos.PLADD
{
    public partial class frm_paramatre : Form
    {

        BL.BL_parametre.BL_paramtre_informatiion classInformation = new BL.BL_parametre.BL_paramtre_informatiion();
        public int id;
        string PRINT_FACTURE;
        string PRINT_BON;
        string PRINT_BON_A4;
        BL.BL_NOTOFY classNotify = new BL.BL_NOTOFY();

        int Caiss_Type;
        int Caiss_theme ;
        string DONT_PRINT;
        BL.BL_parametre.BL_paramtre_informatiion class_setting = new BL.BL_parametre.BL_paramtre_informatiion();
        public frm_paramatre()
        {
            InitializeComponent();
            DataTable dt = classInformation.get_inforamtion();
            if (dt.Rows.Count > 0)
            {

                DataTable dtP = new DataTable();
                dtP = classNotify.get_parametre_day();
                object DayVelue = dtP.Rows[0][0];
                int DayVelueC = Convert.ToInt16(DayVelue);
                numericUpDown1.Value = DayVelueC;

                object NAME = dt.Rows[0][0];
                object PRENAME = dt.Rows[0][1];
                object ADRESS = dt.Rows[0][2];
                object ACTIVITY = dt.Rows[0][3];
                object NMR_REGISTRE = dt.Rows[0][4];
                object NMR_MATIER = dt.Rows[0][5];
                object NMR_JIBAI = dt.Rows[0][6];
                object LOGO = dt.Rows[0][7];
                object WILAYA = dt.Rows[0][9];
                object ID = dt.Rows[0][8];
                object CompanyName = dt.Rows[0][10];
                object Phone = dt.Rows[0][11];
                object Message = dt.Rows[0][12];
                if (LOGO != DBNull.Value && LOGO is Image logoImage)
                {
                    pictureBox1.Image = logoImage;
                }
                txt_name.Text = NAME.ToString();
                txt_prename.Text = PRENAME.ToString();
                txt_adress.Text = ADRESS.ToString();
                txt_activity.Text = ACTIVITY.ToString();
                txt_nmr_sjl.Text = NMR_REGISTRE.ToString();
                nmr_matier.Text = NMR_MATIER.ToString();
                nmr_txt_jibai.Text = NMR_JIBAI.ToString();
                wilayay.Text = WILAYA.ToString();
                kryptonTextBox1.Text = CompanyName.ToString();
                id = int.Parse(ID.ToString());
                kryptonTextBox2.Text = Phone.ToString();
                kryptonTextBox3.Text = Message.ToString();
            }
            else
            {
                MessageBox.Show("لاتوجد معلومات مسبقة");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox21_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // تعريف المتغيرات وتحويل حالات checkboxes
            string one_price = chek_one_price.Checked ? "true" : "false";
            string plus_minez = check_plus_minez.Checked ? "true" : "false";
            string pack = check_pack.Checked ? "true" : "false";
            string new_credit = check_new_credit.Checked ? "true" : "false";
            string old_credit = check_old_credit.Checked ? "true" : "false";
            string list_vente = check_list_vente.Checked ? "true" : "false";
            string old_fctr = check_old_fctr.Checked ? "true" : "false";
            string hide_reference = check_hide_refernce.Checked ? "true" : "false";
            string detaille_prdct = check_detaille_prdct.Checked ? "true" : "false";
            string time = check_time.Checked ? "true" : "false";
            string qt_alert = check_qt_alert.Checked ? "true" : "false";
            string keyboard_ = check_keyboard_.Checked ? "true" : "false";
            string confirme_bon = check_confirme_bon.Checked ? "true" : "false";
            string alert_fctr_attend = check_alert_fctr_attend.Checked ? "true" : "false";
            string btn_remise = check_btn_remise.Checked ? "true" : "false";
            string btn_pack = check_btn_pack.Checked ? "true" : "false";
            string btn_edit = check_btn_edit.Checked ? "true" : "false";
            string btn_supp = check_btn_supp.Checked ? "true" : "false";
            string btn_taklufa = check_btn_taklufa.Checked ? "true" : "false";
            string open_direct = check_open_direct.Checked ? "true" : "false";
            string code_barre_false = check_code_barre_false.Checked ? "true" : "false";
            string change_price = check_edit_price.Checked ? "true" : "false";
            string photo_and_attend = attend_and_photo.Checked ? "true" : "false";
            string check_min_price = check_min_prix.Checked ? "true" : "false";
            string check_date_pere = check_date_pereprtion.Checked ? "true" : "false";



            if (caiss_cmplt.Checked == true)
            {
                Caiss_Type = 1;
            }
            else if (caiss_v5.Checked == true)
            {
                Caiss_Type = 2;
            }


            if (rad_black.Checked == true)
            {
                Caiss_theme = 1;
            }
            else if (rad_white.Checked == true)
            {
                Caiss_theme = 2;
            }

            Properties.Settings.Default.Change_de_prix                  = one_price;
            Properties.Settings.Default.plus_and_minez                  = plus_minez;
            Properties.Settings.Default.convert_to_pack                 = pack;
            Properties.Settings.Default.new_credit                      = new_credit;
            Properties.Settings.Default.old_credit                      = old_credit;
            Properties.Settings.Default.list_vente                      = list_vente;
            Properties.Settings.Default.old_facture                     = old_fctr;
            Properties.Settings.Default.hide_reference                  = hide_reference;
            Properties.Settings.Default.detaille_produit                 = detaille_prdct;
            Properties.Settings.Default.hide_time                       = time;
            Properties.Settings.Default.box_Qt_zero                     = qt_alert;
            Properties.Settings.Default.hide_keyboard                   = keyboard_;
            Properties.Settings.Default.form_confirme_bon               = confirme_bon;
            Properties.Settings.Default.alert_facture_attend            = alert_fctr_attend;
            Properties.Settings.Default.remise                          = btn_remise;
            Properties.Settings.Default.pack                            = btn_pack;
            Properties.Settings.Default.edit                            = btn_edit;
            Properties.Settings.Default.supp                            = btn_supp;
            Properties.Settings.Default.taklufa                         = btn_taklufa;
            Properties.Settings.Default.oppen_form_vente                = open_direct;
            Properties.Settings.Default.add_prdct_whene_codebarre_error = code_barre_false;
            Properties.Settings.Default.change_price                    = change_price; 
            Properties.Settings.Default.FORMVENTE                       = Caiss_Type;
            Properties.Settings.Default.Color_Caiss                     = Caiss_theme;
            Properties.Settings.Default.photo_and_attend                = photo_and_attend;
            Properties.Settings.Default.check_price_min                 = check_min_price;
            Properties.Settings.Default.chech_date_pereprtion           = check_date_pere;
            Properties.Settings.Default.Save();

            notify.Image = Properties.Resources.info2;
            notify.BodyColor = Color.Green;
            notify.TitleText = "تم حفظ الاعدادات بنجاح";
            notify.TitleText =
            notify.ContentText = "تم تسجيل الاعدادات بنجاح";
            notify.Popup();

        }

        private void frm_paramatre_Load(object sender, EventArgs e)
        {
            txtBackupPath.Text = Properties.Settings.Default.BackupPath;
            // تحديث حالة CheckBox عند تحميل الفورم
            chek_one_price.Checked = Properties.Settings.Default.Change_de_prix == "true";
            check_plus_minez.Checked = Properties.Settings.Default.plus_and_minez == "true";
            check_pack.Checked = Properties.Settings.Default.convert_to_pack == "true";
            check_new_credit.Checked = Properties.Settings.Default.new_credit == "true";
            check_old_credit.Checked = Properties.Settings.Default.old_credit == "true";
            check_list_vente.Checked = Properties.Settings.Default.list_vente == "true";
            check_old_fctr.Checked = Properties.Settings.Default.old_facture == "true";
            check_hide_refernce.Checked = Properties.Settings.Default.hide_reference == "true";
            check_detaille_prdct.Checked = Properties.Settings.Default.detaille_produit == "true";
            check_time.Checked = Properties.Settings.Default.hide_time == "true";
            check_qt_alert.Checked = Properties.Settings.Default.box_Qt_zero == "true";
            check_keyboard_.Checked = Properties.Settings.Default.hide_keyboard == "true";
            check_confirme_bon.Checked = Properties.Settings.Default.form_confirme_bon == "true";
            check_alert_fctr_attend.Checked = Properties.Settings.Default.alert_facture_attend == "true";
            check_btn_remise.Checked = Properties.Settings.Default.remise == "true";
            check_btn_pack.Checked = Properties.Settings.Default.pack == "true";
            check_btn_edit.Checked = Properties.Settings.Default.edit == "true";
            check_btn_supp.Checked = Properties.Settings.Default.supp == "true";
            check_btn_taklufa.Checked = Properties.Settings.Default.taklufa == "true";
            check_open_direct.Checked = Properties.Settings.Default.oppen_form_vente == "true";
            check_code_barre_false.Checked = Properties.Settings.Default.add_prdct_whene_codebarre_error == "true";
            check_edit_price.Checked = Properties.Settings.Default.change_price == "true";
            caiss_cmplt.Checked = Properties.Settings.Default.FORMVENTE == 1;
            caiss_v5.Checked = Properties.Settings.Default.FORMVENTE == 2;
            attend_and_photo.Checked = Properties.Settings.Default.photo_and_attend == "true"; 
            check_min_prix.Checked = Properties.Settings.Default.check_price_min == "true";
            check_date_pereprtion.Checked = Properties.Settings.Default.chech_date_pereprtion == "true";


            rad_white.Checked = Properties.Settings.Default.Color_Caiss == 2;
            rad_black.Checked = Properties.Settings.Default.Color_Caiss == 1;


            check_stoked.Checked = Properties.Settings.Default.check_Stock == "true";
            txt_doaa.Text = Properties.Settings.Default.doaa.ToString();

            checkBox1.Checked = Properties.Settings.Default.save_the_db == "true";
            txtBackupPath.Text = Properties.Settings.Default.BackupPath.ToString();

            txt_tva.Text = Properties.Settings.Default.tva.ToString();
            txt_alert_Qt.Text = Properties.Settings.Default.alert.ToString(); 
            txt_Qt_ihtiyaje.Text = Properties.Settings.Default.ihtiyaj.ToString();

             
            check_show_reference.Checked  = Properties.Settings.Default.txt_referennce == "true";
            show__cate.Checked  = Properties.Settings.Default.txt_categorie                         == "true";
            show__stock.Checked  = Properties.Settings.Default.check_Stock                           == "true";
            show__marque.Checked  = Properties.Settings.Default.txt_marque                            == "true";
            show__unite.Checked  = Properties.Settings.Default.txt_unite                             == "true";
            show__taille.Checked  = Properties.Settings.Default.txt_taille                            == "true";
            show__color.Checked  = Properties.Settings.Default.txt_couleur                           == "true";
            show__fav.Checked  = Properties.Settings.Default.txt_fav                               == "true";
            show__date_exp.Checked  = Properties.Settings.Default.txt_date_expir                        == "true";
            show__photo.Checked  = Properties.Settings.Default.photo_produit                         == "true";
            show__codebare.Checked  = Properties.Settings.Default.photo_code_barre                      == "true";
            ch_HT.Checked  = Properties.Settings.Default.txt_prix_ht                           == "true";
            ch_TVA.Checked  = Properties.Settings.Default.txt_tva                               == "true";
            ch_ttl_ht.Checked  = Properties.Settings.Default.txt_total_ht                          == "true";
            ch_prix_2.Checked  = Properties.Settings.Default.txt_price_2                           == "true";
            ch_pric_3.Checked  = Properties.Settings.Default.txt_price_3                           == "true";
            ch_beni_1.Checked  = Properties.Settings.Default.txt_benifice_1                        == "true";
            ch_beni_2.Checked  = Properties.Settings.Default.txt_benifice_2                        == "true";
            ch_beni_3.Checked  = Properties.Settings.Default.txt_benifice_3                        == "true";
            ch_date_exp.Checked  = Properties.Settings.Default.chech_vente_after_expiration          == "true";
            ch_vente_Qt.Checked  = Properties.Settings.Default.check_vente_after_qt                  == "true";
            ch_alet.Checked  = Properties.Settings.Default.txt_qt_alert                               == "true";
            ch_ihtiyaj.Checked  = Properties.Settings.Default.txt_qt_ihiyaj                              == "true";

            DataTable dt = classInformation.get_inforamtion();
            if (dt.Rows.Count > 0)
            {
                try
                {
                    object NAME = dt.Rows[0][0];
                    object PRENAME = dt.Rows[0][1];
                    object ADRESS = dt.Rows[0][2];
                    object ACTIVITY = dt.Rows[0][3];
                    object NMR_REGISTRE = dt.Rows[0][4];
                    object NMR_MATIER = dt.Rows[0][5];
                    object NMR_JIBAI = dt.Rows[0][6];
                    object LOGO = dt.Rows[0][7];
                    object WILAYA = dt.Rows[0][9];
                    object CompanyName = dt.Rows[0][10];
                    object Phone = dt.Rows[0][11];
                    object Message = dt.Rows[0][12];

                    Byte[] image_array = (byte[])dt.Rows[0][7];
                    using (MemoryStream ms = new MemoryStream(image_array))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                    txt_name.Text = NAME.ToString();
                    txt_prename.Text = PRENAME.ToString();
                    txt_adress.Text = ADRESS.ToString();
                    txt_activity.Text = ACTIVITY.ToString();
                    txt_nmr_sjl.Text = NMR_REGISTRE.ToString();
                    nmr_matier.Text = NMR_MATIER.ToString();
                    nmr_txt_jibai.Text = NMR_JIBAI.ToString();
                    wilayay.Text = WILAYA.ToString();
                    kryptonTextBox1.Text = CompanyName.ToString();
                    kryptonTextBox2.Text = Phone.ToString();
                    kryptonTextBox3.Text = Message.ToString();
                }
                catch
                {
                    object NAME = dt.Rows[0][0];
                    object PRENAME = dt.Rows[0][1];
                    object ADRESS = dt.Rows[0][2];
                    object ACTIVITY = dt.Rows[0][3];
                    object NMR_REGISTRE = dt.Rows[0][4];
                    object NMR_MATIER = dt.Rows[0][5];
                    object NMR_JIBAI = dt.Rows[0][6];
                    object LOGO = dt.Rows[0][7];
                    object WILAYA = dt.Rows[0][9];
                    object CompanyName = dt.Rows[0][10];
                    object Phone = dt.Rows[0][11];
                    object Message = dt.Rows[0][12]; 
                    txt_name.Text = NAME.ToString();
                    txt_prename.Text = PRENAME.ToString();
                    txt_adress.Text = ADRESS.ToString();
                    txt_activity.Text = ACTIVITY.ToString();
                    txt_nmr_sjl.Text = NMR_REGISTRE.ToString();
                    nmr_matier.Text = NMR_MATIER.ToString();
                    nmr_txt_jibai.Text = NMR_JIBAI.ToString();
                    wilayay.Text = WILAYA.ToString();
                    kryptonTextBox1.Text = CompanyName.ToString();
                    kryptonTextBox2.Text = Phone.ToString();
                    kryptonTextBox3.Text = Message.ToString();
                }
                
            }
            else
            {
                MessageBox.Show("لاتوجد معلومات مسبقة");
            }

            DataTable dtt = new DataTable();
            dtt = class_setting.Get_paramater_tb();
            object PRINT_FACTURE = dtt.Rows[0][0]; ;
            object PRINT_BON = dtt.Rows[0][1]; ;
            object PRINT_BON_A4 = dtt.Rows[0][2]; ;
            object DONT_PRINT = dtt.Rows[0][3]; ;

            string PRINT_FACTUREe = PRINT_FACTURE.ToString();
            string PRINT_BONn = PRINT_BON.ToString();
            string PRINT_BON_A44 = PRINT_BON_A4.ToString();
            string DONT_PRINTt = DONT_PRINT.ToString();

            if (PRINT_FACTUREe.ToString() == "true")
            {
                chech_facture.Checked = true;

            }
            else if (PRINT_BONn.ToString() == "true")
            {
                check_bon.Checked = true;
            }
            else if (PRINT_BON_A44.ToString() == "true")
            {
                check_bon_A4.Checked = true;
            }
            else if (DONT_PRINTt.ToString() == "true")
            {
                chec_no.Checked = true;
            }

            DataTable dtP = new DataTable();
            dtP = classNotify.get_parametre_day();
            object DayVelue = dtP.Rows[0][0];
            int DayVelueC = Convert.ToInt16(DayVelue);
            numericUpDown1.Value = DayVelueC;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string check_stoke = check_stoked.Checked ? "true" : "false";
            string doaaa = txt_doaa.Text;

            Properties.Settings.Default.check_Stock = check_stoke; 
            Properties.Settings.Default.doaa = doaaa;

            Properties.Settings.Default.Save();
            notify.Image = Properties.Resources.info2;
            notify.BodyColor = Color.Green;
            notify.TitleText = "تم حفظ الاعدادات بنجاح";
            notify.TitleText =
            notify.ContentText = "تم تسجيل الاعدادات بنجاح";
            notify.Popup();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tva      = txt_tva.Text;
            string alert_QT = txt_alert_Qt.Text;
            string ihtiyaj  = txt_Qt_ihtiyaje.Text;

            string txt_refrence = check_show_reference.Checked ? "true" : "false";
            string categorie = show__cate.Checked ? "true" : "false";
            string stock = show__stock.Checked ? "true" : "false";
            string marque = show__marque.Checked ? "true" : "false";
            string unite = show__unite.Checked ? "true" : "false";
            string taille = show__taille.Checked ? "true" : "false";
            string color = show__color.Checked ? "true" : "false";
            string favoris = show__fav.Checked ? "true" : "false";
            string show_date = show__date_exp.Checked ? "true" : "false";
            string show_img = show__photo.Checked ? "true" : "false";
            string show_code_barre = show__codebare.Checked ? "true" : "false";
            string show_prix_ht = ch_HT.Checked ? "true" : "false";
            string show_tva = ch_TVA.Checked ? "true" : "false";
            string show_total_ht = ch_ttl_ht.Checked ? "true" : "false";
            string show_prix2 = ch_prix_2.Checked ? "true" : "false";
            string show_prix1 = ch_pric_3.Checked ? "true" : "false";
            string show_beni_1 = ch_beni_1.Checked ? "true" : "false";
            string show_beni_2 = ch_beni_2.Checked ? "true" : "false";
            string show_beni_3 = ch_beni_3.Checked ? "true" : "false";
            string check_vente_after_date = ch_date_exp.Checked ? "true" : "false";
            string check_vente_after_Qt = ch_vente_Qt.Checked ? "true" : "false";
            string show_Qt_alert = ch_alet.Checked ? "true" : "false";
            string show_Qt_ihtiyak = ch_ihtiyaj.Checked ? "true" : "false";
             
            Properties.Settings.Default.txt_referennce                  = txt_refrence;
            Properties.Settings.Default.txt_categorie                   = categorie;
            Properties.Settings.Default.check_Stock                     = stock;
            Properties.Settings.Default.txt_marque                      = marque;
            Properties.Settings.Default.txt_unite                       = unite;
            Properties.Settings.Default.txt_taille                      = taille;
            Properties.Settings.Default.txt_couleur                     = color;
            Properties.Settings.Default.txt_fav                         = favoris;
            Properties.Settings.Default.txt_date_expir                  = show_date;
            Properties.Settings.Default.photo_produit                   = show_img;
            Properties.Settings.Default.photo_code_barre                = show_code_barre;
            Properties.Settings.Default.txt_prix_ht                     = show_prix_ht;
            Properties.Settings.Default.txt_tva                         = show_tva;
            Properties.Settings.Default.txt_total_ht                    = show_total_ht;
            Properties.Settings.Default.txt_price_2                     = show_prix2;
            Properties.Settings.Default.txt_price_3                     = show_prix1;
            Properties.Settings.Default.txt_benifice_1                  = show_beni_1;
            Properties.Settings.Default.txt_benifice_2                  = show_beni_2;
            Properties.Settings.Default.txt_benifice_3                  = show_beni_3;
            Properties.Settings.Default.chech_vente_after_expiration    = check_vente_after_date;
            Properties.Settings.Default.check_vente_after_qt            = check_vente_after_Qt;
            Properties.Settings.Default.txt_qt_alert                    = show_Qt_alert;
            Properties.Settings.Default.txt_qt_ihiyaj                   = show_Qt_ihtiyak; 
            Properties.Settings.Default.tva                             = tva;
            Properties.Settings.Default.alert                           = alert_QT;
            Properties.Settings.Default.ihtiyaj                         = ihtiyaj; 
            Properties.Settings.Default.Save();


            notify.Image = Properties.Resources.info2;
            notify.BodyColor = Color.Green;
            notify.TitleText = "تم حفظ الاعدادات بنجاح";
            notify.TitleText =
            notify.ContentText = "تم تسجيل الاعدادات بنجاح";
            notify.Popup();

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

            if (chech_facture.Checked == true)
            {
                PRINT_FACTURE = "true";
            }
            else if (chech_facture.Checked == false)
            {
                PRINT_FACTURE = "false";
            }
            //
            if (check_bon.Checked == true)
            {
                PRINT_BON = "true";
            }
            else if (check_bon.Checked == false)
            {
                PRINT_BON = "false";
            }
            //
            if (check_bon_A4.Checked == true)
            {
                PRINT_BON_A4 = "true";
            }
            else if (check_bon_A4.Checked == false)
            {
                PRINT_BON_A4 = "false";
            }
            //
            if (chec_no.Checked == true)
            {
                DONT_PRINT = "true";
            }
            else if (chec_no.Checked == false)
            {
                DONT_PRINT = "false";
            }
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] byteImage = ms.ToArray();


            classInformation.edit_setting(
                txt_name.Text
                , txt_prename.Text
                , txt_adress.Text
                , txt_activity.Text
                , txt_nmr_sjl.Text
                , nmr_matier.Text
                , nmr_txt_jibai.Text
                , byteImage
                , wilayay.Text
                , kryptonTextBox1.Text
                , id
                , kryptonTextBox2.Text
                , kryptonTextBox3.Text
                , PRINT_FACTURE,
                  PRINT_BON,
                 PRINT_BON_A4,
                 DONT_PRINT,
                Convert.ToInt32(numericUpDown1.Value)
                );
            MessageBox.Show("تم تعديل المعلوما بنجاح");


            DataTable dt = classInformation.get_inforamtion();
            if (dt.Rows.Count > 0)
            {
                object NAME = dt.Rows[0][0];
                object PRENAME = dt.Rows[0][1];
                object ADRESS = dt.Rows[0][2];
                object ACTIVITY = dt.Rows[0][3];
                object NMR_REGISTRE = dt.Rows[0][4];
                object NMR_MATIER = dt.Rows[0][5];
                object NMR_JIBAI = dt.Rows[0][6];
                object LOGO = dt.Rows[0][7];
                object WILAYA = dt.Rows[0][9];
                object CompanyName = dt.Rows[0][10];
                object Phone = dt.Rows[0][11];
                object Message = dt.Rows[0][12];

                txt_name.Text = NAME.ToString();
                txt_prename.Text = PRENAME.ToString();
                txt_adress.Text = ADRESS.ToString();
                txt_activity.Text = ACTIVITY.ToString();
                txt_nmr_sjl.Text = NMR_REGISTRE.ToString();
                nmr_matier.Text = NMR_MATIER.ToString();
                nmr_txt_jibai.Text = NMR_JIBAI.ToString();
                wilayay.Text = WILAYA.ToString();
                kryptonTextBox1.Text = CompanyName.ToString();
                kryptonTextBox2.Text = Phone.ToString();
                kryptonTextBox3.Text = Message.ToString();
            }
            else
            {
                MessageBox.Show("لاتوجد معلومات مسبقة");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void attend_and_photo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.BackupPath = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                    txtBackupPath.Text = fbd.SelectedPath; // تحديث المسار في الواجهة
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string check_save = checkBox1.Checked ? "true" : "false";
            string buckup_patch = txtBackupPath.Text;

            Properties.Settings.Default.BackupPath = buckup_patch;
            Properties.Settings.Default.save_the_db = check_save;

            Properties.Settings.Default.Save();
            notify.Image = Properties.Resources.info2;
            notify.BodyColor = Color.Green;
            notify.TitleText = "تم حفظ الاعدادات بنجاح";
            notify.TitleText =
            notify.ContentText = "تم تسجيل الاعدادات بنجاح";
            notify.Popup();
        }
    }
}
