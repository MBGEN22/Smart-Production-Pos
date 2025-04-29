using ComponentFactory.Krypton.Toolkit;
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
	public partial class frm_information_change : Form
    {
        BL.BL_ACHAT_REVENT.BL_produit_reserve classPack_reserve = new BL.BL_ACHAT_REVENT.BL_produit_reserve();
        BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
		BL.BL_ACHAT_REVENT.BL_produit_reserve classProduit = new BL.BL_ACHAT_REVENT.BL_produit_reserve(); 
		string vente_apres_expiration; string stocke_negatif;
		public string id_fctr;
		int? Vr_check_favoire_U, Vr_check_color, Vr_check_taille, favoire_pack, id_categorie, id_marque, id_stock, id_unite;
        public string type;
        public PLADD.vente.frm_vente_caisse formCaisse;
        public PLADD.vente.Frm_vente_caissev5 formCaisseV5;
        string CodeBarrePacke;
        private void check_taille_CheckedChanged(object sender, EventArgs e)
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

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
            if (type == "A")
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] byteImage = ms.ToArray();

                    int? qt_pack = null;
                    DateTime? datePeretion = null;
                    string produitPies;
                    int stock_min;




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



                    if (cmb_favoire.Enabled == true)
                    {
                        Vr_check_favoire_U = Convert.ToInt32(cmb_favoire.SelectedValue);
                    }
                    else if (cmb_favoire.Enabled == false)
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
                    classProduit.change_information_produit_revent(
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
                        decimal.Parse(txt_vente_1.Text),
                        decimal.Parse(txt_vente_2.Text),
                        decimal.Parse(txt_vente_min.Text),
                        byteImage,
                        decimal.Parse(txt_achat_ht.Text),
                        decimal.Parse(txt_achat_ttc.Text),
                        float.Parse(txt_tva.Text),
                        float.Parse(TXTqT_ALERT.Text),
                        float.Parse(txtihtiyadj.Text)
                        );
                    try
                    {
                        classPack_reserve.edit_price_info(CodeBarrePacke, decimal.Parse(kryptonTextBox1.Text));
                    }
                    catch
                    {

                    }
                    MessageBox.Show("تم تعديل معلومات المنتوج بنجاح اضغط على تحديث");
                    formCaisse.loadFav();
                    formCaisse.flowLAyoutProduct.Controls.Clear();
                    formCaisse.loadProduct(1);
                    formCaisse.loadPack(1);
                    this.Close();
                }
                catch
                {

                    int? qt_pack = null;
                    DateTime? datePeretion = null;
                    string produitPies;
                    int stock_min;




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

                    classProduit.change_information_produit_revent_no_img(
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
                        decimal.Parse(txt_vente_1.Text),
                        decimal.Parse(txt_vente_2.Text),
                        decimal.Parse(txt_vente_min.Text),
                        decimal.Parse(txt_achat_ht.Text),
                        decimal.Parse(txt_achat_ttc.Text),
                        float.Parse(txt_tva.Text),
                        float.Parse(TXTqT_ALERT.Text),
                        float.Parse(txtihtiyadj.Text)
                        );
                    try
                    {
                        classPack_reserve.edit_price_info(CodeBarrePacke, decimal.Parse(kryptonTextBox1.Text));
                    }
                    catch
                    {

                    }
                    MessageBox.Show("تم تعديل معلومات المنتوج بنجاح اضغط على تحديث");
                    formCaisse.loadFav();
                    formCaisse.flowLAyoutProduct.Controls.Clear();
                    formCaisse.loadProduct(1);
                    formCaisse.loadPack(1);
                    this.Close();
                }//byte[] byteImage;
            }
            if (type == "B")
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] byteImage = ms.ToArray();

                    int? qt_pack = null;
                    DateTime? datePeretion = null;
                    string produitPies;
                    int stock_min;




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



                    if (cmb_favoire.Enabled == true)
                    {
                        Vr_check_favoire_U = Convert.ToInt32(cmb_favoire.SelectedValue);
                    }
                    else if (cmb_favoire.Enabled == false)
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
                    classProduit.change_information_produit_revent(
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
                        decimal.Parse(txt_vente_1.Text),
                        decimal.Parse(txt_vente_2.Text),
                        decimal.Parse(txt_vente_min.Text),
                        byteImage,
                        decimal.Parse(txt_achat_ht.Text),
                        decimal.Parse(txt_achat_ttc.Text),
                        float.Parse(txt_tva.Text),
                        float.Parse(TXTqT_ALERT.Text),
                        float.Parse(txtihtiyadj.Text)
                        );
                    try
                    {
                        classPack_reserve.edit_price_info(CodeBarrePacke, decimal.Parse(kryptonTextBox1.Text));
                    }
                    catch
                    {

                    }
                    MessageBox.Show("تم تعديل معلومات المنتوج بنجاح اضغط على تحديث");
                    formCaisseV5.loadFav();
                    formCaisseV5.flowLAyoutProduct.Controls.Clear();
                    formCaisseV5.loadProduct(1);
                    formCaisseV5.loadPack(1);
                    this.Close();
                }
                catch
                {

                    int? qt_pack = null;
                    DateTime? datePeretion = null;
                    string produitPies;
                    int stock_min;




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

                    classProduit.change_information_produit_revent_no_img(
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
                        decimal.Parse(txt_vente_1.Text),
                        decimal.Parse(txt_vente_2.Text),
                        decimal.Parse(txt_vente_min.Text),
                        decimal.Parse(txt_achat_ht.Text),
                        decimal.Parse(txt_achat_ttc.Text),
                        float.Parse(txt_tva.Text),
                        float.Parse(TXTqT_ALERT.Text),
                        float.Parse(txtihtiyadj.Text)
                        );
                    try
                    {
                        classPack_reserve.edit_price_info(CodeBarrePacke, decimal.Parse(kryptonTextBox1.Text));
                    }
                    catch
                    {

                    }
                    MessageBox.Show("تم تعديل معلومات المنتوج بنجاح اضغط على تحديث");
                    formCaisseV5.loadFav();
                    formCaisseV5.flowLAyoutProduct.Controls.Clear();
                    formCaisseV5.loadProduct(1);
                    formCaisseV5.loadPack(1);
                    this.Close();
                }//byte[] byteImage;
            }
            else
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] byteImage = ms.ToArray();

                    int? qt_pack = null;
                    DateTime? datePeretion = null;
                    string produitPies;
                    int stock_min;




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



                    if (cmb_favoire.Enabled == true)
                    {
                        Vr_check_favoire_U = Convert.ToInt32(cmb_favoire.SelectedValue);
                    }
                    else if (cmb_favoire.Enabled == false)
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
                    classProduit.change_information_produit_revent(
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
                        decimal.Parse(txt_vente_1.Text),
                        decimal.Parse(txt_vente_2.Text),
                        decimal.Parse(txt_vente_min.Text),
                        byteImage,
                        decimal.Parse(txt_achat_ht.Text),
                        decimal.Parse(txt_achat_ttc.Text),
                        float.Parse(txt_tva.Text),
                        float.Parse(TXTqT_ALERT.Text),
                        float.Parse(txtihtiyadj.Text)
                        );
                    try
                    {
                        classPack_reserve.edit_price_info(CodeBarrePacke, decimal.Parse(kryptonTextBox1.Text));
                    }
                    catch
                    {

                    }
                    MessageBox.Show("تم تعديل معلومات المنتوج بنجاح اضغط على تحديث");
                    this.Close();
                }
                catch
                {

                    int? qt_pack = null;
                    DateTime? datePeretion = null;
                    string produitPies;
                    int stock_min;




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

                    classProduit.change_information_produit_revent_no_img(
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
                        decimal.Parse(txt_vente_1.Text),
                        decimal.Parse(txt_vente_2.Text),
                        decimal.Parse(txt_vente_min.Text),
                        decimal.Parse(txt_achat_ht.Text),
                        decimal.Parse(txt_achat_ttc.Text),
                        float.Parse(txt_tva.Text),
                        float.Parse(TXTqT_ALERT.Text),
                        float.Parse(txtihtiyadj.Text)
                        );
                    try
                    {
                        classPack_reserve.edit_price_info(CodeBarrePacke, decimal.Parse(kryptonTextBox1.Text));
                    }
                    catch
                    {

                    }
                    MessageBox.Show("تم تعديل معلومات المنتوج بنجاح اضغط على تحديث");
                    this.Close();
                }//byte[] byteImage;
            }
            

        }

		private void frm_information_change_Load(object sender, EventArgs e)
		{
            DataTable dtt = new DataTable();
            dtt = classPack_reserve.get_number_pack(txtBarcode.Text) ;
            if (dtt.Rows.Count > 0)
            {
                object CodeBarrePack = dtt.Rows[0][0];
                CodeBarrePacke = CodeBarrePack.ToString();
                object PrixCodeBarre = dtt.Rows[0][4];
                kryptonTextBox1.Visible = true;
                kryptonTextBox1.Text = PrixCodeBarre.ToString();
                label2.Visible = true;
            }
            else
            {
                kryptonTextBox1.Visible = false;
                label2.Visible = false;
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
		{
			OpenFileDialog Ofd = new OpenFileDialog();
			Ofd.Filter = "Photo |*.JPG; *.PNG; *.JPEG; *.GIF; *.BMP;";
			if (Ofd.ShowDialog() == DialogResult.OK)
			{
				pictureBox1.Image = Image.FromFile(Ofd.FileName);
			}
		}

        private void cmb_taille_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Ofd = new OpenFileDialog();
            Ofd.Filter = "Photo |*.JPG; *.PNG; *.GIF; *.BMP ;*.JPEG;";
            if (Ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(Ofd.FileName);
            }
        }

        private void check_color_CheckedChanged(object sender, EventArgs e)
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

		public frm_information_change()
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
			cmb_favoire.DisplayMember = "NAME_FAV";
			cmb_favoire.ValueMember = "ID";
		}
		private void add_new_product()
		{
			
		}


	}
}
