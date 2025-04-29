using ComponentFactory.Krypton.Toolkit;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.PL_Statistique
{
    public partial class frm_add_product_inv : Form
    {
        BL.BL_ACHAT_REVENT.BL_PRODUIT classProduit = new BL.BL_ACHAT_REVENT.BL_PRODUIT();
        BL.BL_CAISSE caisseVente_classe = new BL.BL_CAISSE();
        public frm_add_inventaire add_inventaire;
        public frm_add_product_inv()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = classProduit.get_stock_produit_revenet();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = classProduit.search_produit_revente(textBox3.Text);
            dataGridView1.DataSource = dt;
        }

        private void show_and_hide_columns(System.Windows.Forms.CheckBox check, string name)
        {
            if (check.Checked == true)
            {
                dataGridView1.Columns[name].Visible = true;
            }
            else if (check.Checked == false)
            {
                dataGridView1.Columns[name].Visible = false;
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
             
        }

        private void check_reference_CheckedChanged(object sender, EventArgs e)
        {
            show_and_hide_columns(check_reference, "رقم المرجع");
        }

        private void check_categorie_CheckedChanged(object sender, EventArgs e)
        {
            show_and_hide_columns(check_categorie, "الصنف");
        }

        private void check_stock_CheckedChanged(object sender, EventArgs e)
        {
            show_and_hide_columns(check_stock, "المخزن");
        }

        private void check_marque_CheckedChanged(object sender, EventArgs e)
        {
            show_and_hide_columns(check_marque, "العلامة");
        }

        private void check_unite_CheckedChanged(object sender, EventArgs e)
        {
            show_and_hide_columns(check_unite, "الوحدة");
        }

        private void check_taille_CheckedChanged(object sender, EventArgs e)
        {

            show_and_hide_columns(check_taille, "القياس");
        }

        private void check_clr_CheckedChanged(object sender, EventArgs e)
        {

            show_and_hide_columns(check_clr, "اللون");
        }

        private void check_fav_CheckedChanged(object sender, EventArgs e)
        {

            show_and_hide_columns(check_fav, "المفضلة");
        }

        private void frm_add_product_inv_Load(object sender, EventArgs e)
        {

            show_and_hide_columns(check_reference, "رقم المرجع");
            show_and_hide_columns(check_categorie, "الصنف");
            show_and_hide_columns(check_stock, "المخزن");
            show_and_hide_columns(check_marque, "العلامة");
            show_and_hide_columns(check_taille, "القياس");
            show_and_hide_columns(check_clr, "اللون");
            show_and_hide_columns(check_fav, "المفضلة");
            show_and_hide_columns(check_unite, "الوحدة");
        }

        private void kryptonDropButton1_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Visible == true)
            {
                flowLayoutPanel1.Visible = false;
            }
            else if (flowLayoutPanel1.Visible == false)
            {
                flowLayoutPanel1.Visible = true;
            }
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            DataTable Dtt = new DataTable();
            string barcode = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Dtt = caisseVente_classe.getSold_MAtier_revent(barcode);
            if (Dtt.Rows.Count > 0)
            {
                Object codeBarre = Dtt.Rows[0][0];
                Object name_product = Dtt.Rows[0][1]; 
                Object Qt_rest = Dtt.Rows[0][21];
                Object price_achat_produit_revent = Dtt.Rows[0][12];

                frm_Qt_product_inventaire Qt_inventaire = new frm_Qt_product_inventaire();
                Qt_inventaire.form_add_Qt = add_inventaire;
                Qt_inventaire.frm_add_produt = this;
                Qt_inventaire.lb_Codebarre_.Text = barcode;
                Qt_inventaire.lb_product_designation.Text = name_product.ToString();
                Qt_inventaire.Lb_Qt_logiciels.Text = Qt_rest.ToString();
                Qt_inventaire.txt_prix_achats.Text = price_achat_produit_revent.ToString();
                Qt_inventaire.ShowDialog();
            }
        }
    }
}
