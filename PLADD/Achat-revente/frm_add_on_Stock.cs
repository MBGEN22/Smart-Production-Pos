using Smart_Production_Pos.report.code_barre_P_Revent.pack;
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
    public partial class frm_add_on_Stock : Form
    {
        BL.BL_ACHAT_REVENT.BL_facture classFacture = new BL.BL_ACHAT_REVENT.BL_facture();
        BL.BL_ACHAT_REVENT.BL_ACHAT classAchat = new BL.BL_ACHAT_REVENT.BL_ACHAT();
        BL.BL_Achats.BL_Achats classAchats = new BL.BL_Achats.BL_Achats();
        BL.BL_ACHAT_REVENT.BL_calculate classCalculate = new BL.BL_ACHAT_REVENT.BL_calculate();
        BL.frnsre_history_sold class_frnsr_sold = new BL.frnsre_history_sold();
        DAL.DAL daoo;
        BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
        public int id_user;
        float Qt_add_pack;
        public string id_facture;
        public PL.Achat_revente.Frm_Achat frm_Achat_caisse;
        public frm_add_on_Stock()
        {
            InitializeComponent();
            cmb_product.DataSource = clasCombobox.get_combo_produit_prevent();
            cmb_product.DisplayMember = "designation";
            cmb_product.ValueMember = "CodeBarre";

            cmb_favoir_pack.DataSource = clasCombobox.get_combo_FAV();
            cmb_favoir_pack.DisplayMember = "NAME_FAV";
            cmb_favoir_pack.ValueMember = "ID";
        }

        private void cmb_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)cmb_product.SelectedItem;

            string codeBare = drv["CodeBarre"].ToString();
            string Quantite_rest = drv["Quantite_rest"].ToString();
            string Qt_Dans_pack = drv["QT_DANS_PACK"].ToString();
            string prix_Achat_TTC = drv["price_achat_TTC"].ToString();
            string TVA = drv["TVA"].ToString();
            string PrixVente1 = drv["price_vente1"].ToString();
            string PrixVente2 = drv["price_vente2"].ToString();
            string PrixVente3 = drv["price_min"].ToString();
            string QT_Rest = drv["Quantite_rest"].ToString();
            string reference = drv["reference"].ToString();
            string date_expxxiration = drv["date_expiration"].ToString();
            string QT_ALERT = drv["Quantite_alert"].ToString();
            string QT_DANS_PACK = drv["QT_DANS_PACK"].ToString();



            String QT_ihtiyaj = drv["ihtiyaj"].ToString(); 
            Byte[] image_array = (byte[])drv["Photo"];




            if (Qt_Dans_pack == "")
            {
                crownGroupBox1.Enabled = false;
                crownGroupBox1.Visible = false;
                txt_qt_pack.Text = Qt_Dans_pack;
                txtBarcode.Text = codeBare.ToString();
                txt_qt_rest.Text = Quantite_rest.ToString();
                txt_achat_ttc.Text = prix_Achat_TTC.ToString();
                txt_tva.Text = TVA.ToString();
                txt_vente_1.Text = PrixVente1.ToString();
                txt_vente_2.Text = PrixVente2.ToString();
                txt_vente_min.Text = PrixVente3.ToString();
                txtQT_Alert.Text = QT_ALERT;
                txt_QT_ihtiyaj.Text = QT_ihtiyaj;
                TXT_REFERENCE.Text = reference;
                if (date_expxxiration != "")
                {
                    date_expiration.Value = Convert.ToDateTime(date_expxxiration);
                }
                using (MemoryStream ms = new MemoryStream(image_array))
                {
                    this.pictureBox2.Image = Image.FromStream(ms);
                }
            }
            else
            {
                crownGroupBox1.Enabled = true;
                crownGroupBox1.Visible = true;
                DataTable dt = new DataTable();
                dt = classAchat.check_if_pack_exite(codeBare);
                if (dt.Rows.Count > 0)
                {
                    object CodeBarrePack = dt.Rows[0][0];
                    object NamePack = dt.Rows[0][1];
                    object price_unitair = dt.Rows[0][4];
                    Byte[] image_arrayy = (byte[])dt.Rows[0][5];
                    txt_designation_pack.Text = NamePack.ToString();
                    code_barre_pack.Text = CodeBarrePack.ToString();
                    txt_vente_pack.Text = price_unitair.ToString();
                    qt_dans_pack_txt.Text = Qt_Dans_pack;

                    txt_qt_pack.Text = Qt_Dans_pack;
                    txtBarcode.Text = codeBare.ToString();
                    txt_qt_rest.Text = Quantite_rest.ToString();
                    txt_achat_ttc.Text = prix_Achat_TTC.ToString();
                    txt_tva.Text = TVA.ToString();
                    txt_vente_1.Text = PrixVente1.ToString();
                    txt_vente_2.Text = PrixVente2.ToString();
                    txt_vente_min.Text = PrixVente3.ToString();
                    txtQT_Alert.Text = QT_ALERT;
                    txt_QT_ihtiyaj.Text = QT_ihtiyaj;
                    TXT_REFERENCE.Text = reference;
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
            string barCode = txtBarcode.Text;
            string barCodePack = code_barre_pack.Text;
            try
            {
                Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                pictureBox1.Image = brCode.Draw(barCode, 100);
                lbBrCode.Text = barCode;
                if (Qt_Dans_pack != "")
                {
                    pictureBox3.Image = brCode.Draw(barCodePack, 100);
                    code_barre_packcode_barre_pack.Text = barCodePack;
                }     
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            txt_qt.Text = "0";

        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_achat_ttc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_achat_ht.Text = calcule_TVA(
              decimal.Parse(txt_achat_ttc.Text),
              decimal.Parse(txt_tva.Text)
              ).ToString();
                txt_total_ttc.Text = _calcule_total(decimal.Parse(txt_achat_ttc.Text), decimal.Parse(txt_qt.Text)).ToString();
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
        public decimal calcule_TVA(decimal PrixeTTc, decimal TVA)
        {
            decimal priceHT = PrixeTTc / (1 + (TVA / 100));
            priceHT = Math.Round(priceHT, 2);
            return priceHT;
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
        public decimal _calcule_total(decimal price, decimal QT)
        {
            decimal total = price * QT;
            return total;
        }
        private void txt_qt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_total_ht.Text = _calcule_total(decimal.Parse(txt_achat_ht.Text), decimal.Parse(txt_qt.Text)).ToString();
                txt_total_ttc.Text = _calcule_total(decimal.Parse(txt_achat_ttc.Text), decimal.Parse(txt_qt.Text)).ToString();

                if (crownGroupBox1.Enabled == true)
                {
                    nmbre_pack.Text = calculeQt_By_unite(float.Parse(txt_qt.Text), float.Parse(qt_dans_pack_txt.Text)).ToString();
                }
            }
            catch { }
           
        }

        private void txt_total_ht_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_achat_ht_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_total_ht.Text = _calcule_total(decimal.Parse(txt_achat_ht.Text), decimal.Parse(txt_qt.Text)).ToString();
            }
            catch
            {

            }
        }

        private void check_favoire_U_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {
            frm_calcule_by_pack_whene_add_on_stock add_info_by_pack = new frm_calcule_by_pack_whene_add_on_stock();
            add_info_by_pack.add_achat = this;
            add_info_by_pack.ShowDialog();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            float qt_after = float.Parse(txt_qt.Text) + float.Parse(txt_qt_rest.Text);
            DateTime? datePeretion = null;
            if (check_date_expiration.Checked == true)
            {
                datePeretion = Convert.ToDateTime(date_expiration.Value);
            }
            else
            {
                datePeretion = null;
            }
            classAchat.InsertAchatProduitReventCaisse(
                    txtBarcode.Text,
                    float.Parse(txt_qt.Text),
                    decimal.Parse(txt_achat_ht.Text),
                    float.Parse(txt_tva.Text),
                    decimal.Parse(txt_achat_ttc.Text),
                    decimal.Parse(txt_total_ht.Text),
                    decimal.Parse(txt_total_ttc.Text),
                    "تحديث الكمية",
                    id_facture,
                    float.Parse(txt_qt_rest.Text),
                    qt_after,
                    "تحديث كمية"
                );
            frm_Achat_caisse.productsTable.Rows.Add(
                txtBarcode.Text,
                decimal.Parse(txt_achat_ht.Text),
                decimal.Parse(txt_achat_ttc.Text),
                float.Parse(txt_tva.Text),
                float.Parse(txt_qt.Text),
                decimal.Parse(txt_vente_1.Text),
                decimal.Parse(txt_vente_2.Text),
                decimal.Parse(txt_vente_min.Text),
                float.Parse(txtQT_Alert.Text),
                float.Parse(txt_QT_ihtiyaj.Text) 
                );
            //classAchat.update_QT_produit_prevent(
            //        txtBarcode.Text,
            //        datePeretion,
            //        decimal.Parse(txt_achat_ht.Text),
            //        decimal.Parse(txt_achat_ttc.Text),
            //        float.Parse(txt_tva.Text),
            //        float.Parse(txt_qt.Text)
            //        );
            //if (txt_qt_pack.Text != "")
            //{
            //    if (float.Parse(txt_qt_pack.Text) > 0)
            //    {
            //        Qt_add_pack = float.Parse(txt_qt_pack.Text) * float.Parse(txt_qt.Text);
            //        classAchat.edit_qt_pack_achat(
            //            txtBarcode.Text,
            //            Qt_add_pack
            //            );
            //    }
            //}

            frm_Achat_caisse.dataGridView1.DataSource = classCalculate.get_Caisse_table();
            frm_Achat_caisse.txt_id_fctr.Text = classCalculate.get_facture_number().ToString();
            frm_Achat_caisse.lb_total_ht.Text = classCalculate.get_TOTAL_HT().ToString();
            frm_Achat_caisse.lb_total_ttc.Text = classCalculate.get_TOTAL_TTC().ToString();
            frm_Achat_caisse.txt_nmbre_produit.Text = classCalculate._nmbre_produit().ToString();
            frm_Achat_caisse.get_sold();
            this.Close();
        }

        private void qt_dans_pack_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private float calculeQt_By_unite(float Qt_on_unite , float QT_dansPack)
        {
            float QT_on_pack = Qt_on_unite / QT_dansPack;
            return QT_on_pack;
        }
        private float calculeQt_By_pack(float QT_pack, float QT_dansPack)
        {
            float QT_By_unite= QT_pack * QT_dansPack;
            return QT_By_unite;
        }

        private void nmbre_pack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_qt.Text = calculeQt_By_pack(float.Parse(nmbre_pack.Text), float.Parse(qt_dans_pack_txt.Text)).ToString();
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
    }
}
