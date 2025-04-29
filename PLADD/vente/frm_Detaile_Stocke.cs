using ComponentFactory.Krypton.Toolkit;
using iTextSharp.text.pdf;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.QrCode.Internal;

namespace Smart_Production_Pos.PLADD.vente
{
    public partial class frm_Detaile_Stocke : Form
    {
        BL.BL_ACHAT_REVENT.BL_PRODUIT classProduit = new BL.BL_ACHAT_REVENT.BL_PRODUIT();
        BL.BL_FILL_COMBOBOX_MATIER_PREMIER classFILL = new BL.BL_FILL_COMBOBOX_MATIER_PREMIER();
        BL.BL_CAISSE caisseVente_classe = new BL.BL_CAISSE();
        Object price_Vente;
        public frm_vente_caisse VenteCaisse;
        public Frm_vente_caissev5 VenteCaisseV5; 
        public string Type;
        public frm_Detaile_Stocke()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = classProduit.get_stock_produit_revenet();
            //if (cmb_choose.SelectedIndex == 0) ;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //dt = classProduit.search_produit_revente(cmb_matier_search.Text);
            dataGridView1.DataSource = dt;
        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = classProduit.search_code_barre_produit_revent(kryptonTextBox1.Text);
        }

        private void cmb_choose_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmb_choose.SelectedIndex == 0)
            //{
            //    cmb_matier_search.DataSource = classFILL.fill_produit_revent();
            //    cmb_matier_search.DisplayMember = "اسم المنتج";
            //    cmb_matier_search.ValueMember = "رمز المنتج";
            //}
            //else if (cmb_choose.SelectedIndex == 1)
            //{
            //    cmb_matier_search.DataSource = classFILL.fill_produit_revent();
            //    cmb_matier_search.DisplayMember = "رقم المرجع";
            //    cmb_matier_search.ValueMember = "رمز المنتج";
            //}
            //else if (cmb_choose.SelectedIndex == 2)
            //{
            //    cmb_matier_search.DataSource = classFILL.fill_produit_revent();
            //    cmb_matier_search.DisplayMember = "الصنف";
            //    cmb_matier_search.ValueMember = "رمز المنتج";
            //}
            //else if (cmb_choose.SelectedIndex == 3)
            //{
            //    cmb_matier_search.DataSource = classFILL.fill_produit_revent();
            //    cmb_matier_search.DisplayMember = "الوحدة";
            //    cmb_matier_search.ValueMember = "رمز المنتج";
            //}
            //else if (cmb_choose.SelectedIndex == 4)
            //{
            //    cmb_matier_search.DataSource = classFILL.fill_produit_revent();
            //    cmb_matier_search.DisplayMember = "العلامة";
            //    cmb_matier_search.ValueMember = "رمز المنتج";
            //}
            //else if (cmb_choose.SelectedIndex == 5)
            //{
            //    cmb_matier_search.DataSource = classFILL.fill_produit_revent();
            //    cmb_matier_search.DisplayMember = "المخزن";
            //    cmb_matier_search.ValueMember = "رمز المنتج";
            //}
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string barcode = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            DataTable Dtt = new DataTable();
            Dtt = caisseVente_classe.getSold_MAtier_revent(barcode);
            if (Dtt.Rows.Count > 0)
            {
                Object codeBarre = Dtt.Rows[0][0];
                Object name_product = Dtt.Rows[0][1];
                Object Qt_alter = Dtt.Rows[0][25];
                Object Qt_rest = Dtt.Rows[0][21];

                if (VenteCaisse.chek_prix1.Checked == true)
                {
                    price_Vente = Dtt.Rows[0][15];
                }
                else if (VenteCaisse.check_prix2.Checked == true)
                {
                    price_Vente = Dtt.Rows[0][16];
                }
                else if (VenteCaisse.check_prix3.Checked == true)
                {
                    price_Vente = Dtt.Rows[0][17];
                }
                Object Quanite_dans_pack = Dtt.Rows[0][24];
                Object price_achat_produit_revent = Dtt.Rows[0][12];
                if (float.Parse(Qt_rest.ToString()) <= float.Parse(Qt_alter.ToString()))
                {
                    if (MessageBox.Show("الكمية قريبة من النفاذ او نفذت هل تريد المواصلة", "كمية قليلة", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in VenteCaisse.dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                var cellValue = row.Cells["DgvCodeBarre"].Value;

                                // Check if the cell value is not null before comparison
                                if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                {
                                    row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                                    row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                            decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
                                    row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                        decimal.Parse(price_achat_produit_revent.ToString());
                                    VenteCaisse.GetTTL();
                                    VenteCaisse.txtCount.Text = VenteCaisse.getCount().ToString();
                                    return;
                                }
                            }
                        }
                        VenteCaisse.dataGridView1.Rows.Add(new object[] {
                            0,
                            codeBarre.ToString(),
                            name_product.ToString(),
                            VenteCaisse.txt_qt.Text ,
                            price_Vente.ToString(),
                             (decimal.Parse(price_Vente.ToString())*(decimal.Parse(VenteCaisse.txt_qt.Text))),
                            "U",
                             (decimal.Parse(price_achat_produit_revent.ToString())*(decimal.Parse(VenteCaisse.txt_qt.Text)))
                             });
                    }


                }
                else
                {
                    foreach (DataGridViewRow row in VenteCaisse.dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            var cellValue = row.Cells["DgvCodeBarre"].Value;

                            // Check if the cell value is not null before comparison
                            if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                            {
                                row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                                row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                        decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
                                row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                    decimal.Parse(price_achat_produit_revent.ToString());
                                VenteCaisse.GetTTL();
                                VenteCaisse.txtCount.Text = VenteCaisse.getCount().ToString();
                                return;
                            }
                        }
                    }
                    VenteCaisse.dataGridView1.Rows.Add(new object[] {
                            0,
                            codeBarre.ToString(),
                            name_product.ToString(),
                            VenteCaisse.txt_qt.Text ,
                            price_Vente.ToString(),
                             (decimal.Parse(price_Vente.ToString())*(decimal.Parse(VenteCaisse.txt_qt.Text))),
                            "U",
                             (decimal.Parse(price_achat_produit_revent.ToString())*(decimal.Parse(VenteCaisse.txt_qt.Text)))
                             });
                }
            }

            VenteCaisse.GetTTL();
            VenteCaisse.txtCount.Text = VenteCaisse.getCount().ToString();
            VenteCaisse.txt_qt.Text = "1";
            VenteCaisse.txt_barcode.Focus();
            MessageBox.Show("تم اضافة المنتوج بنجاح");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Type=="V5")
            {
                string barcode = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                DataTable Dtt = new DataTable();
                Dtt = caisseVente_classe.getSold_MAtier_revent(barcode);
                if (Dtt.Rows.Count > 0)
                {
                    Object codeBarre = Dtt.Rows[0][0];
                    Object name_product = Dtt.Rows[0][1];
                    Object Qt_alter = Dtt.Rows[0][25];
                    Object Qt_rest = Dtt.Rows[0][21];

                    if (VenteCaisseV5.chek_prix1.Checked == true)
                    {
                        price_Vente = Dtt.Rows[0][15];
                    }
                    else if (VenteCaisseV5.check_prix2.Checked == true)
                    {
                        price_Vente = Dtt.Rows[0][16];
                    }
                    else if (VenteCaisseV5.check_prix3.Checked == true)
                    {
                        price_Vente = Dtt.Rows[0][17];
                    }
                    Object Quanite_dans_pack = Dtt.Rows[0][24];
                    Object price_achat_produit_revent = Dtt.Rows[0][12];
                    if (float.Parse(Qt_rest.ToString()) <= float.Parse(Qt_alter.ToString()))
                    {
                        if (MessageBox.Show("الكمية قريبة من النفاذ او نفذت هل تريد المواصلة", "كمية قليلة", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            foreach (DataGridViewRow row in VenteCaisseV5.dataGridView1.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    var cellValue = row.Cells["DgvCodeBarre"].Value;

                                    // Check if the cell value is not null before comparison
                                    if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                    {
                                        row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                                        row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                                decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
                                        row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                            decimal.Parse(price_achat_produit_revent.ToString());
                                        VenteCaisseV5.GetTTL();
                                        VenteCaisseV5.txtCount.Text = VenteCaisseV5.getCount().ToString();
                                        return;
                                    }
                                }
                            }
                            VenteCaisseV5.dataGridView1.Rows.Add(new object[] {
                            0,
                            codeBarre.ToString(),
                            name_product.ToString(),
                            VenteCaisseV5.txt_qt.Text ,
                            price_Vente.ToString(),
                             (decimal.Parse(price_Vente.ToString())*(decimal.Parse(VenteCaisseV5.txt_qt.Text))),
                            "U",
                             (decimal.Parse(price_achat_produit_revent.ToString())*(decimal.Parse(VenteCaisseV5.txt_qt.Text)))
                             });
                        }


                    }
                    else
                    {
                        foreach (DataGridViewRow row in VenteCaisseV5.dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                var cellValue = row.Cells["DgvCodeBarre"].Value;

                                // Check if the cell value is not null before comparison
                                if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                {
                                    row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                                    row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                            decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
                                    row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                        decimal.Parse(price_achat_produit_revent.ToString());
                                    VenteCaisseV5.GetTTL();
                                    VenteCaisseV5.txtCount.Text = VenteCaisseV5.getCount().ToString();
                                    return;
                                }
                            }
                        }
                        VenteCaisseV5.dataGridView1.Rows.Add(new object[] {
                            0,
                            codeBarre.ToString(),
                            name_product.ToString(),
                            VenteCaisseV5.txt_qt.Text ,
                            price_Vente.ToString(),
                             (decimal.Parse(price_Vente.ToString())*(decimal.Parse(VenteCaisseV5.txt_qt.Text))),
                            "U",
                             (decimal.Parse(price_achat_produit_revent.ToString())*(decimal.Parse(VenteCaisseV5.txt_qt.Text)))
                             });
                    }
                }

                VenteCaisseV5.GetTTL();
                VenteCaisseV5.txtCount.Text = VenteCaisseV5.getCount().ToString();
                VenteCaisseV5.txt_qt.Text = "1";
                VenteCaisseV5.txt_barcode.Focus();
                MessageBox.Show("تم اضافة المنتوج بنجاح");
                this.Close();
            }
            else
            {
                string barcode = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                DataTable Dtt = new DataTable();
                Dtt = caisseVente_classe.getSold_MAtier_revent(barcode);
                if (Dtt.Rows.Count > 0)
                {
                    Object codeBarre = Dtt.Rows[0][0];
                    Object name_product = Dtt.Rows[0][1];
                    Object Qt_alter = Dtt.Rows[0][25];
                    Object Qt_rest = Dtt.Rows[0][21];

                    if (VenteCaisse.chek_prix1.Checked == true)
                    {
                        price_Vente = Dtt.Rows[0][15];
                    }
                    else if (VenteCaisse.check_prix2.Checked == true)
                    {
                        price_Vente = Dtt.Rows[0][16];
                    }
                    else if (VenteCaisse.check_prix3.Checked == true)
                    {
                        price_Vente = Dtt.Rows[0][17];
                    }
                    Object Quanite_dans_pack = Dtt.Rows[0][24];
                    Object price_achat_produit_revent = Dtt.Rows[0][12];
                    if (float.Parse(Qt_rest.ToString()) <= float.Parse(Qt_alter.ToString()))
                    {
                        if (MessageBox.Show("الكمية قريبة من النفاذ او نفذت هل تريد المواصلة", "كمية قليلة", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            foreach (DataGridViewRow row in VenteCaisse.dataGridView1.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    var cellValue = row.Cells["DgvCodeBarre"].Value;

                                    // Check if the cell value is not null before comparison
                                    if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                    {
                                        row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                                        row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                                decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
                                        row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                            decimal.Parse(price_achat_produit_revent.ToString());
                                        VenteCaisse.GetTTL();
                                        VenteCaisse.txtCount.Text = VenteCaisse.getCount().ToString();
                                        return;
                                    }
                                }
                            }
                            VenteCaisse.dataGridView1.Rows.Add(new object[] {
                            0,
                            codeBarre.ToString(),
                            name_product.ToString(),
                            VenteCaisse.txt_qt.Text ,
                            price_Vente.ToString(),
                             (decimal.Parse(price_Vente.ToString())*(decimal.Parse(VenteCaisse.txt_qt.Text))),
                            "U",
                             (decimal.Parse(price_achat_produit_revent.ToString())*(decimal.Parse(VenteCaisse.txt_qt.Text)))
                             });
                        }


                    }
                    else
                    {
                        foreach (DataGridViewRow row in VenteCaisse.dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                var cellValue = row.Cells["DgvCodeBarre"].Value;

                                // Check if the cell value is not null before comparison
                                if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                {
                                    row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                                    row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                            decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
                                    row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                        decimal.Parse(price_achat_produit_revent.ToString());
                                    VenteCaisse.GetTTL();
                                    VenteCaisse.txtCount.Text = VenteCaisse.getCount().ToString();
                                    return;
                                }
                            }
                        }
                        VenteCaisse.dataGridView1.Rows.Add(new object[] {
                            0,
                            codeBarre.ToString(),
                            name_product.ToString(),
                            VenteCaisse.txt_qt.Text ,
                            price_Vente.ToString(),
                             (decimal.Parse(price_Vente.ToString())*(decimal.Parse(VenteCaisse.txt_qt.Text))),
                            "U",
                             (decimal.Parse(price_achat_produit_revent.ToString())*(decimal.Parse(VenteCaisse.txt_qt.Text)))
                             });
                    }
                }

                VenteCaisse.GetTTL();
                VenteCaisse.txtCount.Text = VenteCaisse.getCount().ToString();
                VenteCaisse.txt_qt.Text = "1";
                VenteCaisse.txt_barcode.Focus();
                MessageBox.Show("تم اضافة المنتوج بنجاح");
                this.Close();
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dataGridView1.Columns[e.ColumnIndex].Name == "DGVADD")
                {
                    //DataTable dttt = new DataTable();
                    //dttt = classProduit.GET_INFORATION_FOR_AFFICHER_PRODUIT_REVENT(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    //object codeBarree = dttt.Rows[0][0]; 
                    //string barCode = codeBarree.ToString();
                    //Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

                    //pictureBox2.Image = brCode.Draw(barCode, 100);
                    //using (MemoryStream mss = new MemoryStream())
                    //{
                    //    System.Drawing.Image barcodeImage = brCode.Draw(barCode, 100);
                    //    barcodeImage.Save(mss, ImageFormat.Png); // Save the image in PNG format

                    //    // Convert MemoryStream to byte array
                    //    byte[] byteImage = mss.ToArray();

                    //    // Call the method to add the picture
                    //    classProduit.add_picture(barCode, byteImage);
                    //}
                    if (Type == "V5")
                    {
                        string barcode = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        DataTable Dtt = new DataTable();
                        Dtt = caisseVente_classe.getSold_MAtier_revent(barcode);
                        if (Dtt.Rows.Count > 0)
                        {
                            Object codeBarre = Dtt.Rows[0][0];
                            Object name_product = Dtt.Rows[0][1];
                            Object Qt_alter = Dtt.Rows[0][25];
                            Object Qt_rest = Dtt.Rows[0][21];

                            if (VenteCaisseV5.chek_prix1.Checked == true)
                            {
                                price_Vente = Dtt.Rows[0][15];
                            }
                            else if (VenteCaisseV5.check_prix2.Checked == true)
                            {
                                price_Vente = Dtt.Rows[0][16];
                            }
                            else if (VenteCaisseV5.check_prix3.Checked == true)
                            {
                                price_Vente = Dtt.Rows[0][17];
                            }
                            Object Quanite_dans_pack = Dtt.Rows[0][24];
                            Object price_achat_produit_revent = Dtt.Rows[0][12];
                            if (float.Parse(Qt_rest.ToString()) <= float.Parse(Qt_alter.ToString()))
                            {
                                if (MessageBox.Show("الكمية قريبة من النفاذ او نفذت هل تريد المواصلة", "كمية قليلة", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    foreach (DataGridViewRow row in VenteCaisseV5.dataGridView1.Rows)
                                    {
                                        if (!row.IsNewRow)
                                        {
                                            var cellValue = row.Cells["DgvCodeBarre"].Value;

                                            // Check if the cell value is not null before comparison
                                            if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                            {
                                                row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                                                row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                                        decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
                                                row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                    decimal.Parse(price_achat_produit_revent.ToString());
                                                VenteCaisseV5.GetTTL();
                                                VenteCaisseV5.txtCount.Text = VenteCaisseV5.getCount().ToString();
                                                return;
                                            }
                                        }
                                    }
                                    VenteCaisseV5.dataGridView1.Rows.Add(new object[] {
                            0,
                            codeBarre.ToString(),
                            name_product.ToString(),
                            VenteCaisseV5.txt_qt.Text ,
                            price_Vente.ToString(),
                             (decimal.Parse(price_Vente.ToString())*(decimal.Parse(VenteCaisseV5.txt_qt.Text))),
                            "U",
                             (decimal.Parse(price_achat_produit_revent.ToString())*(decimal.Parse(VenteCaisseV5.txt_qt.Text)))
                             });
                                }


                            }
                            else
                            {
                                foreach (DataGridViewRow row in VenteCaisseV5.dataGridView1.Rows)
                                {
                                    if (!row.IsNewRow)
                                    {
                                        var cellValue = row.Cells["DgvCodeBarre"].Value;

                                        // Check if the cell value is not null before comparison
                                        if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                        {
                                            row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                                            row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                                    decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
                                            row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                decimal.Parse(price_achat_produit_revent.ToString());
                                            VenteCaisseV5.GetTTL();
                                            VenteCaisseV5.txtCount.Text = VenteCaisseV5.getCount().ToString();
                                            return;
                                        }
                                    }
                                }
                                VenteCaisseV5.dataGridView1.Rows.Add(new object[] {
                            0,
                            codeBarre.ToString(),
                            name_product.ToString(),
                            VenteCaisseV5.txt_qt.Text ,
                            price_Vente.ToString(),
                             (decimal.Parse(price_Vente.ToString())*(decimal.Parse(VenteCaisseV5.txt_qt.Text))),
                            "U",
                             (decimal.Parse(price_achat_produit_revent.ToString())*(decimal.Parse(VenteCaisseV5.txt_qt.Text)))
                             });
                            }
                        }

                        VenteCaisseV5.GetTTL();
                        VenteCaisseV5.txtCount.Text = VenteCaisseV5.getCount().ToString();
                        VenteCaisseV5.txt_qt.Text = "1";
                        VenteCaisse.txt_barcode.Focus();
                        MessageBox.Show("تم اضافة المنتوج بنجاح");
                        this.Close();
                    }
                    else
                    {
                        string barcode = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        DataTable Dtt = new DataTable();
                        Dtt = caisseVente_classe.getSold_MAtier_revent(barcode);
                        if (Dtt.Rows.Count > 0)
                        {
                            Object codeBarre = Dtt.Rows[0][0];
                            Object name_product = Dtt.Rows[0][1];
                            Object Qt_alter = Dtt.Rows[0][25];
                            Object Qt_rest = Dtt.Rows[0][21];

                            if (VenteCaisse.chek_prix1.Checked == true)
                            {
                                price_Vente = Dtt.Rows[0][15];
                            }
                            else if (VenteCaisse.check_prix2.Checked == true)
                            {
                                price_Vente = Dtt.Rows[0][16];
                            }
                            else if (VenteCaisse.check_prix3.Checked == true)
                            {
                                price_Vente = Dtt.Rows[0][17];
                            }
                            Object Quanite_dans_pack = Dtt.Rows[0][24];
                            Object price_achat_produit_revent = Dtt.Rows[0][12];
                            if (float.Parse(Qt_rest.ToString()) <= float.Parse(Qt_alter.ToString()))
                            {
                                if (MessageBox.Show("الكمية قريبة من النفاذ او نفذت هل تريد المواصلة", "كمية قليلة", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    foreach (DataGridViewRow row in VenteCaisse.dataGridView1.Rows)
                                    {
                                        if (!row.IsNewRow)
                                        {
                                            var cellValue = row.Cells["DgvCodeBarre"].Value;

                                            // Check if the cell value is not null before comparison
                                            if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                            {
                                                row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                                                row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                                        decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
                                                row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                    decimal.Parse(price_achat_produit_revent.ToString());
                                                VenteCaisse.GetTTL();
                                                VenteCaisse.txtCount.Text = VenteCaisse.getCount().ToString();
                                                return;
                                            }
                                        }
                                    }
                                    VenteCaisse.dataGridView1.Rows.Add(new object[] {
                            0,
                            codeBarre.ToString(),
                            name_product.ToString(),
                            VenteCaisse.txt_qt.Text ,
                            price_Vente.ToString(),
                             (decimal.Parse(price_Vente.ToString())*(decimal.Parse(VenteCaisse.txt_qt.Text))),
                            "U",
                             (decimal.Parse(price_achat_produit_revent.ToString())*(decimal.Parse(VenteCaisse.txt_qt.Text)))
                             });
                                }


                            }
                            else
                            {
                                foreach (DataGridViewRow row in VenteCaisse.dataGridView1.Rows)
                                {
                                    if (!row.IsNewRow)
                                    {
                                        var cellValue = row.Cells["DgvCodeBarre"].Value;

                                        // Check if the cell value is not null before comparison
                                        if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                        {
                                            row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                                            row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                                    decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
                                            row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                decimal.Parse(price_achat_produit_revent.ToString());
                                            VenteCaisse.GetTTL();
                                            VenteCaisse.txtCount.Text = VenteCaisse.getCount().ToString();
                                            return;
                                        }
                                    }
                                }
                                VenteCaisse.dataGridView1.Rows.Add(new object[] {
                            0,
                            codeBarre.ToString(),
                            name_product.ToString(),
                            VenteCaisse.txt_qt.Text ,
                            price_Vente.ToString(),
                             (decimal.Parse(price_Vente.ToString())*(decimal.Parse(VenteCaisse.txt_qt.Text))),
                            "U",
                             (decimal.Parse(price_achat_produit_revent.ToString())*(decimal.Parse(VenteCaisse.txt_qt.Text)))
                             });
                            }
                        }

                        VenteCaisse.GetTTL();
                        VenteCaisse.txtCount.Text = VenteCaisse.getCount().ToString();
                        VenteCaisse.txt_qt.Text = "1";
                        VenteCaisse.txt_barcode.Focus();
                        MessageBox.Show("تم اضافة المنتوج بنجاح");
                        this.Close();
                    }
                }
                DataTable dt = new DataTable();
                dt = classProduit.GET_INFORATION_FOR_AFFICHER_PRODUIT_REVENT(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
                object QT_REST = dt.Rows[0][21];
                txt_resT_pack.Text = QT_REST.ToString();
            }
            catch
            {

            }
        }

        private void frm_Detaile_Stocke_Load(object sender, EventArgs e)
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

        private void kryptonTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = classProduit.search_produit_revente(kryptonTextBox1.Text);
            dataGridView1.DataSource = dt;
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

        private void button12_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = classProduit.GET_INFORATION_FOR_AFFICHER_PRODUIT_REVENT(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
            object codeBarre = dt.Rows[0][0];

            string barCode = codeBarre.ToString();
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
            
            report.code_barre_P_Revent.code_Barre_designation rpt = new report.code_barre_P_Revent.code_Barre_designation();
            //#region re
            string mode = Properties.Settings.Default.mode;
            if (mode == "SQL")
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                rpt.Refresh();
                rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[1].Value);
                rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[1].Value);

                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
            else
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = true;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                rpt.Refresh();
                rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[1].Value);
                rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[1].Value);
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = classProduit.GET_INFORATION_FOR_AFFICHER_PRODUIT_REVENT(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
            object codeBarre = dt.Rows[0][0];

            string barCode = codeBarre.ToString();
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
            
            report.code_barre_P_Revent.rpt_Code_barreprice rpt = new report.code_barre_P_Revent.rpt_Code_barreprice();
            //#region re
            string mode = Properties.Settings.Default.mode;
            if (mode == "SQL")
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                rpt.Refresh();
                rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[1].Value);
                rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[1].Value);
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
            else
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = true;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                rpt.Refresh();
                rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[1].Value);
                rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[1].Value);
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = classProduit.GET_INFORATION_FOR_AFFICHER_PRODUIT_REVENT(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
            object codeBarre = dt.Rows[0][0];

            string barCode = codeBarre.ToString();
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
            
            report.code_barre_P_Revent.rp_Code_barre rpt = new report.code_barre_P_Revent.rp_Code_barre();
            string mode = Properties.Settings.Default.mode;
            if (mode == "SQL")
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                rpt.Refresh();
                rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[1].Value);
                rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[1].Value);
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
            else
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = true;
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                rpt.Refresh();
                rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[1].Value);
                rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[1].Value);
                report.viewer_report viewer = new report.viewer_report();
                viewer.crystalReportViewer1.ReportSource = rpt;
                viewer.ShowDialog();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = classProduit.GET_INFORATION_FOR_AFFICHER_PRODUIT_REVENT(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
            object codeBarre = dt.Rows[0][0];

            string barCode = codeBarre.ToString();
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

            report.code_barre_P_Revent.code_price_designation rpt = new report.code_barre_P_Revent.code_price_designation();
            //#region re
            string mode = Properties.Settings.Default.mode;
            if (mode == "Local")
            {
                //report.viewer_report viewer = new report.viewer_report();
                //report_Local.CodeBarre.CodeBarre_All rptt = new report_Local.CodeBarre.CodeBarre_All();
                //sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " + @"|DataDirectory|\DB_PRODUCTION_POS.mdf" + "; Integrated Security = True");
                ////SqlDataAdapter sda = new SqlDataAdapter("Select * From TB_VENTE", sqlConnection);
                ////DataSet dst = new DataSet();
                ////sda.Fill(dst, "TB_VENTE");
                ////rptt.SetDataSource(dst); // Set the data source directly to the report instance 
                //viewer.crystalReportViewer1.ReportSource = rptt;
                //viewer.ShowDialog();
            }
            else
            {
                if (mode == "SQL")
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = false;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                    rpt.Refresh();
                    rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[1].Value);
                    rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[1].Value);
                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
                else
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = true;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                    rpt.Refresh();
                    rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[1].Value);
                    rpt.SetParameterValue("@codebarre", this.dataGridView1.CurrentRow.Cells[1].Value);
                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
            }
        }
    }
}
