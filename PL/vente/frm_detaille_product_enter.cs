using ComponentFactory.Krypton.Toolkit;
using Smart_Production_Pos.PL.Achat_revente;
using Smart_Production_Pos.PLADD.vente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.vente
{
    public partial class frm_detaille_product_enter : Form
    {
        BL.BL_ACHAT_REVENT.BL_PRODUIT classProduit = new BL.BL_ACHAT_REVENT.BL_PRODUIT();
        BL.BL_FILL_COMBOBOX_MATIER_PREMIER classFILL = new BL.BL_FILL_COMBOBOX_MATIER_PREMIER();
        BL.BL_CAISSE caisseVente_classe = new BL.BL_CAISSE();
        Object price_Vente; 
        public string Type;
        int tab;
        public frm_facturation VenteCaisse;
        public frm_detaille_product_enter()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = classProduit.insert_stock_for_facturation();
            this.dataGridView2.DataSource = classProduit.get_stock_pack();
            flowLayoutPanel1.Visible = false;
            tab = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {

             
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
        private void show_and_hide_columns(CheckBox check, string name)
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

        private void frm_detaille_product_enter_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "سعر البيع الأول")
            {
                e.CellStyle.BackColor = Color.LightGreen; // اختر لون قريب
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "سعر البيع الثاني")
            {
                e.CellStyle.BackColor = Color.LightBlue; // اختر لون قريب
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "سعر البيع الأدنى")
            {
                e.CellStyle.BackColor = Color.LightCyan; // اختر لون قريب
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "الكمية المتبقية")
            {
                e.CellStyle.BackColor = Color.Yellow; // اختر لون قريب
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_add_produit_simple addstock = new frm_add_produit_simple();
            addstock.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                tab = 0;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                tab = 1;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (tab ==0)
            { 
                DataTable dt = new DataTable();
                dt = classProduit.search_produit_revente_on_fctr(textBox8.Text);
                dataGridView1.DataSource = dt;
            }
            else if(tab == 1)
            {
                DataTable dt = new DataTable();
                dt = classProduit.search_pack_produit_revent(textBox8.Text);
                dataGridView2.DataSource = dt;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                dt = classProduit.GET_INFORATION_FOR_AFFICHER_PRODUIT_REVENT(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                object codeBarre = dt.Rows[0][0];
                object designation = dt.Rows[0][1];
                object marque = dt.Rows[0][5];
                object categories = dt.Rows[0][3];
                object reference = dt.Rows[0][2];
                object unite = dt.Rows[0][2];
                object stock = dt.Rows[0][4];
                object PHOTO = dt.Rows[0][10];
                object QT_TTL = dt.Rows[0][14];
                object QT_REST = dt.Rows[0][21];
                object PriceVente = dt.Rows[0][15];
                object Rest_by_Pack = dt.Rows[0][25];


                Byte[] image_array = (byte[])dt.Rows[0][24];
                using (MemoryStream ms = new MemoryStream(image_array))
                {
                    pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                }
              
            }
            catch
            {

            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            frm_saise saise = new frm_saise(); 
            string barcode = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            DataTable Dtt = new DataTable();
            Dtt = caisseVente_classe.getSold_MAtier_revent(barcode);
            if (Dtt.Rows.Count > 0)
            {
                Object codeBarre = Dtt.Rows[0][0];
                Object name_product = Dtt.Rows[0][1];
                Object reference = Dtt.Rows[0][2];
                Object Qt_rest = Dtt.Rows[0][21]; 
                Object Qt_dans_pack = Dtt.Rows[0][24]; 
                Object prix_1 = Dtt.Rows[0][15];
                Object prix_achat = Dtt.Rows[0][12];
                Object prix_2 = Dtt.Rows[0][16];
                Object prix_3 = Dtt.Rows[0][17];
                Object unite = Dtt.Rows[0][6];

                if (Qt_dans_pack.ToString() == "")
                {
                    saise.txt_colissage.ReadOnly = true;
                    saise.txt_rest_Qt_p.ReadOnly = true;
                }
                else
                {
                    DataTable DtPack = caisseVente_classe.select_pack_revent_by_code_barre_produit(codeBarre.ToString());
                    Object codeBarrePack = DtPack.Rows[0][0];
                    Object name_productPack = DtPack.Rows[0][1];
                    Object price_VentePAck = DtPack.Rows[0][4];
                    Object price_achat_revent = DtPack.Rows[0][7];
                    Object qt_dans_pack = DtPack.Rows[0][8];


                    saise.txt_prix_vente_pack.Text = price_VentePAck.ToString();
                    saise.txt_colissage.Text = Qt_dans_pack.ToString();
                    float Qt_restt = float.Parse(Qt_rest.ToString());
                    float Qt_dans_packk = float.Parse(Qt_dans_pack.ToString());
                    saise.txt_rest_Qt_p.Text = (Qt_restt/Qt_dans_packk).ToString();
                }
                saise.priceachat.Text = prix_achat.ToString();
                saise.txt_prix_vente_1.Text = prix_1.ToString();
                saise.txt_prix_vente_2.Text = prix_2.ToString();
                saise.txt_prix_vente_3.Text = prix_3.ToString();
                saise.txt_code_barre.Text = barcode.ToString();
                saise.txt_designation.Text = name_product.ToString();
                saise.txt_references.Text = reference.ToString();
                saise.txt_rest_Qt_u.Text = Qt_rest.ToString();
                saise.unite = unite.ToString();
            }

            saise.frm_detaille_prdct = this;
            saise.VenteCaisse = VenteCaisse;
            saise.ShowDialog();


            //if (tab == 0)
            //{
            //    string barcode = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //    DataTable Dtt = new DataTable();
            //    Dtt = caisseVente_classe.getSold_MAtier_revent(barcode);
            //    if (Dtt.Rows.Count > 0)
            //    {
            //        Object codeBarre = Dtt.Rows[0][0];
            //        Object name_product = Dtt.Rows[0][1];
            //        Object Qt_alter = Dtt.Rows[0][25];
            //        Object Qt_rest = Dtt.Rows[0][21];

            //        if (VenteCaisse.chek_prix1.Checked == true)
            //        {
            //            price_Vente = Dtt.Rows[0][15];
            //        }
            //        else if (VenteCaisse.check_prix2.Checked == true)
            //        {
            //            price_Vente = Dtt.Rows[0][16];
            //        }
            //        else if (VenteCaisse.check_prix3.Checked == true)
            //        {
            //            price_Vente = Dtt.Rows[0][17];
            //        }
            //        Object Quanite_dans_pack = Dtt.Rows[0][24];
            //        Object price_achat_produit_revent = Dtt.Rows[0][12];
            //        if (float.Parse(Qt_rest.ToString()) <= float.Parse(Qt_alter.ToString()))
            //        {
            //            if (MessageBox.Show("الكمية قريبة من النفاذ او نفذت هل تريد المواصلة", "كمية قليلة", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //            {
            //                foreach (DataGridViewRow row in VenteCaisse.dataGridView1.Rows)
            //                {
            //                    if (!row.IsNewRow)
            //                    {
            //                        var cellValue = row.Cells["DgvCodeBarre"].Value;

            //                        // Check if the cell value is not null before comparison
            //                        if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
            //                        {
            //                            row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
            //                            row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
            //                                                    decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
            //                            row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
            //                                decimal.Parse(price_achat_produit_revent.ToString());
            //                            VenteCaisse.GetTTL();
            //                            VenteCaisse.txtCount.Text = VenteCaisse.getCount().ToString();
            //                            return;
            //                        }
            //                    }
            //                }
            //                VenteCaisse.dataGridView1.Rows.Add(new object[] {
            //                0,
            //                codeBarre.ToString(),
            //                name_product.ToString(),
            //                "1" ,
            //                price_Vente.ToString(),
            //                 (decimal.Parse(price_Vente.ToString())*(decimal.Parse("1"))),
            //                "U",
            //                 (decimal.Parse(price_achat_produit_revent.ToString())*(decimal.Parse("1")))
            //                 });
            //            }


            //        }
            //        else
            //        {
            //            foreach (DataGridViewRow row in VenteCaisse.dataGridView1.Rows)
            //            {
            //                if (!row.IsNewRow)
            //                {
            //                    var cellValue = row.Cells["DgvCodeBarre"].Value;

            //                    // Check if the cell value is not null before comparison
            //                    if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
            //                    {
            //                        row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
            //                        row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
            //                                                decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
            //                        row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
            //                            decimal.Parse(price_achat_produit_revent.ToString());
            //                        VenteCaisse.GetTTL();
            //                        VenteCaisse.txtCount.Text = VenteCaisse.getCount().ToString();
            //                        return;
            //                    }
            //                }
            //            }
            //            VenteCaisse.dataGridView1.Rows.Add(new object[] {
            //                0,
            //                codeBarre.ToString(),
            //                name_product.ToString(),
            //                "1" ,
            //                price_Vente.ToString(),
            //                 (decimal.Parse(price_Vente.ToString())*(decimal.Parse("1"))),
            //                "U",
            //                 (decimal.Parse(price_achat_produit_revent.ToString())*(decimal.Parse("1")))
            //                 });
            //        }
            //    }
            //    VenteCaisse.GetTTL();
            //    VenteCaisse.txtCount.Text = VenteCaisse.getCount().ToString();
            //    VenteCaisse.txt_qt.Text = "1";
            //    VenteCaisse.txt_barcode.Focus();
            //    MessageBox.Show("تم اضافة المنتوج بنجاح");
            //    this.Close();

        }
    }
}
