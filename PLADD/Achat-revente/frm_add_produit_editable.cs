using iTextSharp.text.pdf;
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
    public partial class frm_add_produit_editable : Form
    {
        BL.BL_ACHAT_REVENT.BL_facture classFacture = new BL.BL_ACHAT_REVENT.BL_facture();
        BL.BL_ACHAT_REVENT.BL_ACHAT classAchat = new BL.BL_ACHAT_REVENT.BL_ACHAT();
        BL.BL_Achats.BL_Achats classAchats = new BL.BL_Achats.BL_Achats();
        BL.BL_ACHAT_REVENT.BL_calculate classCalculate = new BL.BL_ACHAT_REVENT.BL_calculate();
        BL.frnsre_history_sold class_frnsr_sold = new BL.frnsre_history_sold();
        BL.BL_ACHAT_REVENT.BL_produit_reserve classProduit = new BL.BL_ACHAT_REVENT.BL_produit_reserve();

        DAL.DAL daoo;
        BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
        public int id_user;
        float Qt_add_pack;
        public string id_facture;
        public PL.Achat_revente.Frm_Achat frm_Achat_caisse;
        string QT_ALERT;
        string QT_DANS_PACK;
        int? Vr_check_favoire_U, favunite;
        public frm_add_produit_editable()
        {
            InitializeComponent();
            cmb_product.DataSource = clasCombobox.get_combo_produit_prevent();
            cmb_product.DisplayMember = "designation";
            cmb_product.ValueMember = "CodeBarre";
              
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
        private float Calcule_ALL_QT(float QT_Dans_pack, float nbr_pack)
        {
            float all_Qt = QT_Dans_pack * nbr_pack;
            return all_Qt;
        }
        private void frm_add_produit_editable_Load(object sender, EventArgs e)
        {

        }

        private void cmb_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)cmb_product.SelectedItem;

            string codeBare = drv["CodeBarre"].ToString();
            string Quantite_rest = drv["Quantite_rest"].ToString();
            string Qt_Dans_pack = drv["QT_DANS_PACK"].ToString();
            string prix_Achat_TTC = drv["price_achat_TTC"].ToString();
            string idFav = drv["id_favoire"].ToString(); 
            string TVA = drv["TVA"].ToString();
            string PrixVente1 = drv["price_vente1"].ToString();
            string PrixVente2 = drv["price_vente2"].ToString();
            string PrixVente3 = drv["price_min"].ToString();
            string QT_Rest = drv["Quantite_rest"].ToString();
            string reference = drv["reference"].ToString();
            string date_expxxiration = drv["date_expiration"].ToString();
            QT_ALERT     = drv["Quantite_alert"].ToString();
            QT_DANS_PACK = drv["QT_DANS_PACK"].ToString();



            String QT_ihtiyaj = drv["ihtiyaj"].ToString();
            Byte[] image_array = (byte[])drv["Photo"];
             
            if (Qt_Dans_pack == "")
            {
                crownGroupBox1.Enabled = false;
                crownGroupBox1.Visible = false;
                QT_Dans_ack.Text = Qt_Dans_pack;
                txtBarcode.Text = codeBare.ToString();
                txt_qt_rest.Text = Quantite_rest.ToString();
                txt_achat_ttc.Text = prix_Achat_TTC.ToString();
                txt_old_achat.Text = prix_Achat_TTC.ToString();
                txt_vente_1.Text = PrixVente1.ToString();
                txt_vente_1.Text = PrixVente2.ToString();
                txt_vente_1.Text = PrixVente3.ToString();
                //txtQT_Alert.Text = QT_ALERT;
                //txt_QT_ihtiyaj.Text = QT_ihtiyaj;
                //TXT_REFERENCE.Text = reference;
                if (date_expxxiration != "")
                {
                    date_expiration.Value = Convert.ToDateTime(date_expxxiration);
                }
                using (MemoryStream ms = new MemoryStream(image_array))
                {
                    this.pictureBox2.Image = Image.FromStream(ms);
                }
                if (idFav != "")
                {
                    cmb_favoire.Enabled = Enabled;
                    cmb_favoire.SelectedValue = idFav;
                }
                else
                {
                    cmb_favoire.Enabled = false;
                }
                //label8.Visible = false;
                //label4.Visible = false;
                //label6.Visible = false;
                label9.Visible = false;
                //Pric_Pack_achat.Visible = false;
                //QT_Dans_ack.Visible = false;
                //nbr_pack.Visible = false;
                textBox4.Visible = false; 
            }
            else
            {
                label8.Visible = true;
                label4.Visible = true;
                label6.Visible = true;
                label9.Visible = true;
                Pric_Pack_achat.Visible = true;
                QT_Dans_ack.Visible = true;
                nbr_pack.Visible = true;
                textBox4.Visible = true;
                crownGroupBox1.Enabled = true;
                crownGroupBox1.Visible = true;
                DataTable dt = new DataTable();
                dt = classAchat.check_if_pack_exite(codeBare);
                if (dt.Rows.Count > 0)
                {
                    object CodeBarrePack = dt.Rows[0][0];
                    object NamePack = dt.Rows[0][1];
                    object price_unitair = dt.Rows[0][4];
                    object id_favoire = dt.Rows[0][6];
                    Byte[] image_arrayy = (byte[])dt.Rows[0][5];
                    txt_designation_pack.Text = NamePack.ToString();
                    code_barre_pack.Text = CodeBarrePack.ToString();
                    txt_vente_pack.Text = price_unitair.ToString();
                    QT_Dans_ack.Text = Qt_Dans_pack; 
                    txtBarcode.Text = codeBare.ToString();
                    txt_qt_rest.Text = Quantite_rest.ToString();
                    txt_achat_ttc.Text = prix_Achat_TTC.ToString(); 
                    txt_vente_1.Text = PrixVente1.ToString();
                    txt_old_achat.Text = prix_Achat_TTC.ToString();
                    Pric_Pack_achat.Text = (decimal.Parse(prix_Achat_TTC.ToString())*
                                            decimal.Parse(Qt_Dans_pack.ToString())).ToString();

                    textBox4.Text =  (float.Parse(Quantite_rest.ToString()) /
                                            float.Parse(Qt_Dans_pack.ToString())).ToString();

                    if (idFav != "")
                    {
                        cmb_favoire.Enabled = Enabled;
                        cmb_favoire.SelectedValue = idFav;
                    }
                    else
                    {
                        cmb_favoire.Enabled = false;
                    }
                    if (id_favoire.ToString() != "")
                    {
                        cmb_favoir_pack.Enabled = Enabled;
                        cmb_favoir_pack.SelectedValue = Convert.ToInt32(id_favoire.ToString());
                    }
                    else
                    {
                        cmb_favoir_pack.Enabled = false;
                    }
                    if (date_expxxiration != "")
                    {
                        date_expiration.Value = Convert.ToDateTime(date_expxxiration);
                    }
                    using (MemoryStream ms = new MemoryStream(image_array))
                    {
                        this.pictureBox2.Image = Image.FromStream(ms);
                    }

                    using (MemoryStream ms1 = new MemoryStream(image_arrayy))
                    {
                        this.pictureBox4.Image = Image.FromStream(ms1);
                    }
                }
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
        private decimal calcule_New_Price(decimal PriceOLd, decimal QtOld, decimal PriceNew, decimal Qt_new)
        {
            decimal PriceNew_Calculate = ((PriceOLd * QtOld) + (PriceNew * Qt_new)) / (QtOld + Qt_new);
            return PriceNew_Calculate;
        }

        public void edit_information_apres_update()
        {
            
            try
            {
                DateTime? date_expirations = null;
                decimal PriceHT_calculate, Price_TTC_calculte;
                //Calcule PriceHT New 
                if (date_expiration.Enabled == true)
                {
                    date_expirations = Convert.ToDateTime(date_expiration.Text);
                }
                else
                {
                    date_expirations = null;
                }
                //Calcule Price TTC new
                Price_TTC_calculte = calcule_New_Price(
                                                      decimal.Parse(txt_old_achat.Text),
                                                      decimal.Parse(txt_qt_rest.Text),
                                                      decimal.Parse(txt_achat_ttc.Text),
                                                      decimal.Parse(txt_qt.Text)
                                                      );

                // استدعاء الدالة مع القيم المستخرجة
                classAchat.update_QT_produit_prevent(
                    txtBarcode.Text,
                    date_expirations,
                    Price_TTC_calculte,
                    Price_TTC_calculte,
                    0,
                    float.Parse(txt_qt.Text),
                    decimal.Parse(txt_vente_1.Text),
                    decimal.Parse(txt_vente_1.Text),
                    decimal.Parse(txt_vente_1.Text),
                    float.Parse(QT_ALERT),
                    float.Parse(txt_qt.Text));

                //edit Pack

                MemoryStream ms = new MemoryStream();
                pictureBox4.Image.Save(ms, pictureBox4.Image.RawFormat);
                byte[] byteImage = ms.ToArray();

                if (cmb_favoir_pack.Enabled == true)
                {
                    Vr_check_favoire_U = Convert.ToInt32(cmb_favoire.SelectedValue);
                }
                else if (cmb_favoir_pack.Enabled == false)
                {
                    Vr_check_favoire_U = null;
                }

                classProduit.edit_pack_information(
                    code_barre_pack.Text,
                    txt_designation_pack.Text,
                    decimal.Parse(txt_vente_pack.Text),
                    byteImage,
                    Vr_check_favoire_U
                    ); 
                MessageBox.Show("تم تعديل معلومات الحزمة  بنجاح اضغط على تحديث");
                this.Close();
            }
            catch
            {
                DateTime? date_expirations = null;
                decimal PriceHT_calculate, Price_TTC_calculte;
                //Calcule PriceHT New 
                if (date_expiration.Enabled == true)
                {
                    date_expirations = Convert.ToDateTime(date_expiration.Text);
                }
                else
                {
                    date_expirations = null;
                }
                //Calcule Price TTC new
                Price_TTC_calculte = calcule_New_Price(
                                                      decimal.Parse(txt_old_achat.Text),
                                                      decimal.Parse(txt_qt_rest.Text),
                                                      decimal.Parse(txt_achat_ttc.Text),
                                                      decimal.Parse(txt_qt.Text)
                                                      );

                // استدعاء الدالة مع القيم المستخرجة
                classAchat.update_QT_produit_prevent(
                    code_barre_pack.Text,
                    date_expirations,
                    Price_TTC_calculte,
                    Price_TTC_calculte,
                    0,
                    float.Parse(txt_qt.Text),
                    decimal.Parse(txt_vente_1.Text),
                    decimal.Parse(txt_vente_1.Text),
                    decimal.Parse(txt_vente_1.Text),
                    float.Parse(QT_ALERT),
                    float.Parse(txt_qt.Text));

                //edit Pack

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
                    txt_designation_pack.Text,
                    decimal.Parse(txt_vente_pack.Text),
                    Vr_check_favoire_U
                    );
                 MessageBox.Show("تم تعديل معلومات الحزمة  بنجاح اضغط على تحديث");
                this.Close();
            }
            
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            edit_information_apres_update();
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

        private void Pric_Pack_achat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_achat_ttc.Text = calcule_Prix_achat(decimal.Parse(Pric_Pack_achat.Text), decimal.Parse(QT_Dans_ack.Text)).ToString("F2");
            }
            catch
            {

            }
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFileDialog Ofd = new OpenFileDialog();
            Ofd.Filter = "Photo |*.JPG; *.PNG; *.GIF; *.BMP ;*.JPEG;";
            if (Ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.Image = Image.FromFile(Ofd.FileName);
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
