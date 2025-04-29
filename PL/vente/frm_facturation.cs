using iTextSharp.text.pdf;
using Smart_Production_Pos.PLADD.Fichier;
using Smart_Production_Pos.PLADD.vente;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Humanizer;

namespace Smart_Production_Pos.PL.vente
{
    public partial class frm_facturation : Form
    {
        BL.BL_COMBOBOX Bl_combobox = new BL.BL_COMBOBOX();
        BL.BL_CAISSE caisseVente_classe = new BL.BL_CAISSE(); 
        BL.BL_vente.BL_FACTURE_VENTE class_facture_vente = new BL.BL_vente.BL_FACTURE_VENTE();
        BL.Client_history_sold historique_Client = new BL.Client_history_sold();
        BL.BL_vente.BL_SP_LOGINE_Caisse classCaisse = new BL.BL_vente.BL_SP_LOGINE_Caisse();
        BL.BL_vente.bl_diminuer_la_Qt_vente classQt_vente = new BL.BL_vente.bl_diminuer_la_Qt_vente();
        public int type;
        public int ID_caissier;
        public int ID_historique;
        public int id_user;
        string price_on_arabic, price_on_fr;
        public frm_facturation()
        {
            InitializeComponent();
            clientCmb.DataSource = Bl_combobox.get_combo_client();
            clientCmb.DisplayMember = "Client";
            clientCmb.ValueMember = "ID";
            txt_id_fctr.Text = class_facture_vente.get_id_facture_achat();
            dateTimetxt.Text = DateTime.Today.ToShortDateString().ToString();
        }
        public void convertTOwriter()
        {
            if (decimal.TryParse(lb_Total.Text, out decimal number))
            {
                // تقسيم الرقم إلى جزء صحيح وجزء عشري
                int integerPart = (int)number;
                int fractionalPart = (int)((number - integerPart) * 100); // تحويل الجزء العشري إلى سنتات

                // تحويل الجزء الصحيح إلى كلمات بالعربية
                string arabicWords = integerPart.ToWords(new CultureInfo("ar"));
                string arabicFractionalWords = fractionalPart > 0 ? " و " + fractionalPart.ToWords(new CultureInfo("ar")) + " سنتيم" : "";

                price_on_arabic = arabicWords + " دينار جزائري" + arabicFractionalWords;
                // تحويل الجزء الصحيح إلى كلمات بالفرنسية
                string frenchWords = integerPart.ToWords(new CultureInfo("fr"));
                string frenchFractionalWords = fractionalPart > 0 ? " et " + fractionalPart.ToWords(new CultureInfo("fr")) + " centimes" : "";
                price_on_fr = frenchWords + " DINAR ALGERIENE" + frenchFractionalWords;
            }
            else
            {
                MessageBox.Show("يرجى إدخال رقم صحيح.");
            }
        }
        public decimal calcule_credit_after(decimal sold_old)
        {
            decimal sold_after = decimal.Parse(lb_rest.Text);
            decimal soldnew = sold_old + sold_after;
            return soldnew;
        }
        
        private decimal calcule_TVA(decimal PRICE_HT , decimal TVA)
        {
            decimal PRICE_TTC = PRICE_HT * (1 + (TVA / 100));
            return PRICE_TTC;
        }

        private decimal calcule_Tmbr(decimal price_TTC, decimal pourcent_timbre)
        {
            decimal PRICE_TTC2 = price_TTC * (1 + (pourcent_timbre / 100));
            return PRICE_TTC2;
        }
        private decimal calcule_remise(decimal ancien_price , decimal price_remise)
        {
            decimal PRICE_TTC2 = ancien_price - price_remise;
            return PRICE_TTC2;
        }
        public void GetTTL()
        {
            double ttl = 0;
            double Qt_ttl = 0;
            lb_Total.Text = "0";  

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells["dgbTTTL"].Value != null)
                {
                    double cellValue;
                    // Try to parse the cell value to double
                    if (double.TryParse(row.Cells["dgbTTTL"].Value.ToString(), out cellValue))
                    {
                        ttl += cellValue;
                    }
                    else
                    {
                        // Handle the case where parsing fails (e.g., log the issue)
                        // Optionally you can display a message or handle it as needed
                    }
                }
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells["dgvQtt"].Value != null)
                {
                    double cellValue;
                    // Try to parse the cell value to double
                    if (double.TryParse(row.Cells["dgvQtt"].Value.ToString(), out cellValue))
                    {
                        Qt_ttl += cellValue;
                    }
                    else
                    {
                        // Handle the case where parsing fails (e.g., log the issue)
                        // Optionally you can display a message or handle it as needed
                    }
                }
            }
            lb_Total.Text = ttl.ToString("N2"); 
            txt_price_HT.Text = ttl.ToString("N2");
            txt_price_TTC.Text = ttl.ToString("N2");
            txt_Versement.Text = ttl.ToString("N2");
            txt_qt.Text = Qt_ttl.ToString("N2");
            txtCount.Text = dataGridView1.Rows.Count.ToString();
            lb_rest.Text = calculeRest(decimal.Parse(lb_Total.Text), decimal.Parse(txt_Versement.Text)).ToString();
            if (decimal.Parse(lb_rest.Text) < 0)
            {
                lb_rest.ForeColor = Color.Green;
            }
            else if (decimal.Parse(lb_rest.Text) > 0)
            {
                lb_rest.ForeColor = Color.Red;
            }
            lbl_prix_remisier.Text = "0";


        }
        private void frm_facturation_Load(object sender, EventArgs e)
        {
            //show_and_hide_columns(checkBox4, "ع.حزم");
            //show_and_hide_columns(checkBox5, "التغليف");
            //show_and_hide_columns(checkBox6, "الخصم");
            //show_and_hide_columns(checkBox7, "الخصم %");
            //show_and_hide_columns(checkBox8, "السعر الأصلي");
            //show_and_hide_columns(checkBox9, "النوع");
            //show_and_hide_columns(checkBox10, "التكلفة");
        }
        public int getCount()
        {
            int rowCount = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow) // This checks if the row is not the new row
                {
                    rowCount++;
                }
            }
            return rowCount;
        }
        private void BTN9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clientCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)clientCmb.SelectedItem;
            string sold_non_pays = drv["SOLD_NON_PAYE"].ToString();
            lb_historique_credit.Text = sold_non_pays.ToString();
            calcule_credit_after(decimal.Parse(sold_non_pays.ToString()));
            lb_new_credit.Text = calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_detaille_product_enter detaille_product = new frm_detaille_product_enter();
            detaille_product.VenteCaisse = this;
            detaille_product.ShowDialog();
        }
         
        private void calculate_TVA(decimal price_ht, decimal TVA)
        {
            decimal price_ttc = price_ht + price_ht * (TVA / 100);
            lb_Total.Text = price_ttc.ToString();
        }
        private void txt_barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var charMap = new Dictionary<char, char>
                {
                { '&', '1' },
                { 'é', '2' },
                { '"', '3' },
                { '\'', '4' },
                { '(', '5' },
                { '-', '6' },
                { 'è', '7' },
                { '_', '8' },
                { 'ç', '9' },
                { 'à', '0' }
            };

                // Use StringBuilder to build the converted string.
                var convertedCodeBarre = new StringBuilder(txt_barcode.Text.Length);

                foreach (char c in txt_barcode.Text)
                {
                    // If the character is in the dictionary, replace it; otherwise, keep it the same.
                    if (charMap.TryGetValue(c, out char replacement))
                    {
                        convertedCodeBarre.Append(replacement);
                    }
                    else
                    {
                        convertedCodeBarre.Append(c);
                    }
                }

                // Resulting converted code
                string bar = convertedCodeBarre.ToString();
                //MessageBox.Show(bar.ToString());

                getinformation_matier_revent(bar);
                txt_barcode.Clear(); // تنظيف الـ TextBox بعد استدعاء الدالة
                e.Handled = true; // منع إصدار الصوت
            }
        }
        public void getinformation_matier_revent(string CodeBarrre)
        {
            //MessageBox.Show(txt_barcode.Text);
            ////Create a dictionary to map special characters to their corresponding replacements.
            //var charMap = new Dictionary<char, char>
            //    {
            //    { '&', '1' },
            //    { 'é', '2' },
            //    { '"', '3' },
            //    { '\'', '4' },
            //    { '(', '5' },
            //    { '-', '6' },
            //    { 'è', '7' },
            //    { '_', '8' },
            //    { 'ç', '9' },
            //    { 'à', '0' }
            //};

            //// Use StringBuilder to build the converted string.
            //var convertedCodeBarre = new StringBuilder(txt_barcode.Text.Length);

            //foreach (char c in txt_barcode.Text)
            //{
            //    // If the character is in the dictionary, replace it; otherwise, keep it the same.
            //    if (charMap.TryGetValue(c, out char replacement))
            //    {
            //        convertedCodeBarre.Append(replacement);
            //    }
            //    else
            //    {
            //        convertedCodeBarre.Append(c);
            //    }
            //}

            //// Resulting converted code
            //string bar = convertedCodeBarre.ToString();

            ////// Resulting converted code
            ////string barcode = convertedCodeBarre.ToString();


            DataTable Dt = new DataTable();
            Dt = caisseVente_classe.getSold_MAtier_revent(CodeBarrre);
            if (Dt.Rows.Count > 0)
            {
                Object codeBarre = Dt.Rows[0][0];
                Object name_product = Dt.Rows[0][1];
                Object price_Vente = Dt.Rows[0][15];
                Object Quanite_dans_pack = Dt.Rows[0][24];
                Object price_achat_produit_revent = Dt.Rows[0][12];
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var cellValue = row.Cells["DgvCodeBarre"].Value;

                        // Check if the cell value is not null before comparison
                        if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                        {
                            row.Cells["dgvQt"].Value = (float.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                            row.Cells["dgbTtl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                    float.Parse(row.Cells["dgvAmount"].Value.ToString());
                            row.Cells["cout_ttl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                float.Parse(price_achat_produit_revent.ToString());
                            //------------------------------------------------------------------------------//
                            if (Quanite_dans_pack.ToString() != "")
                            {
                                if (float.Parse(row.Cells["dgvQt"].Value.ToString()) == float.Parse(Quanite_dans_pack.ToString()))
                                {
                                    DialogResult dg = MessageBox.Show("هل تريد بيع حزمة من هذا المنتوج مباشرة؟", "بيع بالحزمة؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dg == DialogResult.Yes)
                                    {
                                        dataGridView1.Rows.Remove(row);
                                        DataTable DtPack = caisseVente_classe.select_pack_revent_by_code_barre_produit(CodeBarrre);
                                        Object codeBarrePack = DtPack.Rows[0][0];
                                        Object name_productPack = DtPack.Rows[0][1];
                                        Object price_VentePAck = DtPack.Rows[0][4];
                                        Object price_achat_revent = DtPack.Rows[0][7];
                                        Object qt_dans_pack = DtPack.Rows[0][8];
                                        decimal price_achat_revent_pack = decimal.Parse(price_achat_revent.ToString()) *
                                            decimal.Parse(qt_dans_pack.ToString());
                                        foreach (DataGridViewRow rowP in dataGridView1.Rows)
                                        {
                                            if (!row.IsNewRow)
                                            {
                                                var cellValued = row.Cells["DgvCodeBarre"].Value;

                                                // Check if the cell value is not null before comparison
                                                if (cellValued != null && cellValued.ToString() == codeBarrePack.ToString())
                                                {
                                                    row.Cells["dgvQt"].Value = (float.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                                                    row.Cells["dgbTtl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                                            float.Parse(row.Cells["dgvAmount"].Value.ToString());
                                                    row.Cells["cout_ttl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                                            float.Parse(price_achat_revent_pack.ToString());

                                                    GetTTL();
                                                    txtCount.Text = getCount().ToString();

                                                    return;
                                                }
                                            }
                                        }
                                        //this Line add new product
                                        dataGridView1.Rows.Add(new object[] { 0, codeBarrePack.ToString(), name_productPack.ToString(), 1, price_VentePAck.ToString(), price_VentePAck.ToString(), "P", price_achat_revent_pack.ToString() });
                                        GetTTL();
                                        txtCount.Text = getCount().ToString();
                                        txt_barcode.Focus();


                                        return;
                                    }
                                }
                            }
                            GetTTL();
                            txtCount.Text = getCount().ToString();
                            txt_barcode.Focus();


                            return;
                        }
                    }
                }
                //this Line add new product
                dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "U", price_achat_produit_revent.ToString() });

            }
            else if (Dt.Rows.Count == 0)
            {
                Dt = caisseVente_classe.select_produit_fabrique(CodeBarrre);
                if (Dt.Rows.Count > 0)
                {
                    Object codeBarre = Dt.Rows[0][0];
                    Object name_product = Dt.Rows[0][1];
                    Object price_Vente = Dt.Rows[0][11];
                    Object Quanite_dans_pack = Dt.Rows[0][6];
                    Object cout_de_prodution = Dt.Rows[0][5];
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            var cellValue = row.Cells["DgvCodeBarre"].Value;

                            // Check if the cell value is not null before comparison
                            if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                            {
                                row.Cells["dgvQt"].Value = (float.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                                row.Cells["dgbTtl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                        float.Parse(row.Cells["dgvAmount"].Value.ToString());
                                row.Cells["cout_ttl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                        float.Parse(cout_de_prodution.ToString());
                                if (Quanite_dans_pack.ToString() != "")
                                {
                                    if (float.Parse(row.Cells["dgvQt"].Value.ToString()) == float.Parse(Quanite_dans_pack.ToString()))
                                    {
                                        DialogResult dg = MessageBox.Show("هل تريد بيع حزمة من هذا المنتوج مباشرة؟", "بيع بالحزمة؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (dg == DialogResult.Yes)
                                        {
                                            dataGridView1.Rows.Remove(row);
                                            DataTable DtPack = caisseVente_classe.select_pack_produit_finaux_by_Unite(CodeBarrre);
                                            Object codeBarrePack = DtPack.Rows[0][0];
                                            Object name_productPack = DtPack.Rows[0][1];
                                            Object price_VentePAck = DtPack.Rows[0][4];
                                            Object cout_produire_unite = DtPack.Rows[0][8];
                                            Object qt_dans_pack = DtPack.Rows[0][9];

                                            decimal cout_produire_pack_favrique = decimal.Parse(cout_produire_unite.ToString()) * decimal.Parse(qt_dans_pack.ToString());
                                            foreach (DataGridViewRow rowP in dataGridView1.Rows)
                                            {
                                                if (!row.IsNewRow)
                                                {
                                                    var cellValued = row.Cells["DgvCodeBarre"].Value;

                                                    // Check if the cell value is not null before comparison
                                                    if (cellValued != null && cellValued.ToString() == codeBarrePack.ToString())
                                                    {
                                                        row.Cells["dgvQt"].Value = (float.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                                                        row.Cells["dgbTtl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                                                float.Parse(row.Cells["dgvAmount"].Value.ToString());
                                                        row.Cells["cout_ttl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                                                float.Parse(cout_produire_pack_favrique.ToString());
                                                        GetTTL();
                                                        txtCount.Text = getCount().ToString();

                                                        return;
                                                    }
                                                }
                                            }
                                            //this Line add new product
                                            dataGridView1.Rows.Add(new object[] { 0, codeBarrePack.ToString(), name_productPack.ToString(), 1, price_VentePAck.ToString(), price_VentePAck.ToString(), "P", cout_produire_pack_favrique.ToString() });
                                            GetTTL();
                                            txtCount.Text = getCount().ToString();
                                            txt_barcode.Focus();


                                            return;
                                        }
                                    }
                                }
                                GetTTL();
                                txtCount.Text = getCount().ToString();
                                txt_barcode.Focus();


                                return;
                            }
                        }
                    }
                    //this Line add new product
                    dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "U", cout_de_prodution.ToString() });

                    txt_barcode.Focus();

                }
                else if (Dt.Rows.Count == 0)
                {
                    Dt = caisseVente_classe.select_pack_info(CodeBarrre);
                    if (Dt.Rows.Count > 0)
                    {

                        Object codeBarre = Dt.Rows[0][0];
                        Object name_product = Dt.Rows[0][1];
                        Object price_Vente = Dt.Rows[0][4];
                        Object price_Achat = Dt.Rows[0][7];
                        Object Qt_dans_pack = Dt.Rows[0][8];
                        decimal cout_produire_pack_favrique = decimal.Parse(price_Achat.ToString()) * decimal.Parse(Qt_dans_pack.ToString());
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                var cellValue = row.Cells["DgvCodeBarre"].Value;

                                // Check if the cell value is not null before comparison
                                if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                {
                                    row.Cells["dgvQt"].Value = (float.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                                    row.Cells["dgbTtl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                            float.Parse(row.Cells["dgvAmount"].Value.ToString());
                                    row.Cells["cout_ttl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                            float.Parse(cout_produire_pack_favrique.ToString());
                                    GetTTL();
                                    txtCount.Text = getCount().ToString();
                                    txt_barcode.Focus();


                                    return;
                                }
                            }
                        }
                        //this Line add new product
                        dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "P", cout_produire_pack_favrique });

                        txt_barcode.Focus();

                    }
                    else if (Dt.Rows.Count == 0)
                    {
                        Dt = caisseVente_classe.select_pack_Produit_finaux_info(CodeBarrre);
                        if (Dt.Rows.Count > 0)
                        {

                            Object codeBarre = Dt.Rows[0][0];
                            Object name_product = Dt.Rows[0][1];
                            Object price_Vente = Dt.Rows[0][4];
                            Object coutTTL = Dt.Rows[0][8];
                            Object qt_dans_pack = Dt.Rows[0][9];
                            decimal cout_produire_pack_favrique = decimal.Parse(coutTTL.ToString()) * decimal.Parse(qt_dans_pack.ToString());

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    var cellValue = row.Cells["DgvCodeBarre"].Value;

                                    // Check if the cell value is not null before comparison
                                    if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                    {
                                        row.Cells["dgvQt"].Value = (float.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                                        row.Cells["dgbTtl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                                float.Parse(row.Cells["dgvAmount"].Value.ToString());
                                        row.Cells["cout_ttl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                                float.Parse(cout_produire_pack_favrique.ToString());
                                        GetTTL();
                                        txtCount.Text = getCount().ToString();
                                        txt_barcode.Focus();


                                        return;
                                    }
                                }
                            }
                            //this Line add new product
                            dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "P", cout_produire_pack_favrique.ToString() });

                            txt_barcode.Focus();

                        }
                        else if (Dt.Rows.Count == 0)
                        {
                            Dt = caisseVente_classe.select_produit_by_code_barre_reserve(CodeBarrre);
                            if (Dt.Rows.Count > 0)
                            {

                                Object codeBarre = Dt.Rows[0][0];
                                Object name_product = Dt.Rows[0][1];
                                Object price_Vente = Dt.Rows[0][2];

                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    if (!row.IsNewRow)
                                    {
                                        var cellValue = row.Cells["DgvCodeBarre"].Value;

                                        // Check if the cell value is not null before comparison
                                        if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                        {
                                            row.Cells["dgvQt"].Value = (float.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                                            row.Cells["dgbTtl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                                                float.Parse(row.Cells["dgvAmount"].Value.ToString());

                                            GetTTL();
                                            txtCount.Text = getCount().ToString();
                                            txt_barcode.Focus();


                                            return;
                                        }
                                    }
                                }
                                //this Line add new product
                                dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "U" });

                                txt_barcode.Focus();

                                //MessageBox.Show("هذا المنتوج غير موجود في قاعدة البيانات");
                            }
                            else if (Dt.Rows.Count == 0)
                            {
                                //
                                Dt = caisseVente_classe.get_information_by_code_Reserve_pack(CodeBarrre);
                                if (Dt.Rows.Count > 0)
                                {

                                    Object codeBarre = Dt.Rows[0][0];
                                    Object name_product = Dt.Rows[0][1];
                                    Object price_Vente = Dt.Rows[0][2];

                                    foreach (DataGridViewRow row in dataGridView1.Rows)
                                    {
                                        if (!row.IsNewRow)
                                        {
                                            var cellValue = row.Cells["DgvCodeBarre"].Value;

                                            // Check if the cell value is not null before comparison
                                            if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                            {
                                                row.Cells["dgvQt"].Value = (float.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                                                row.Cells["dgbTtl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                                                    float.Parse(row.Cells["dgvAmount"].Value.ToString());

                                                GetTTL();
                                                txtCount.Text = getCount().ToString();
                                                txt_barcode.Focus();


                                                return;
                                            }
                                        }
                                    }
                                    //this Line add new product
                                    dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "P" });

                                    txt_barcode.Focus();

                                    //MessageBox.Show("هذا المنتوج غير موجود في قاعدة البيانات");
                                }
                                else
                                {
                                    if (Properties.Settings.Default.add_prdct_whene_codebarre_error == "true")
                                    {
                                        frm_barcodeempty barccodeemty = new frm_barcodeempty();
                                        barccodeemty.TextBarcode.Text = CodeBarrre.ToString();
                                        barccodeemty.Show();
                                    }
                                    else
                                    {
                                        txt_barcode.Text = "";
                                        txt_barcode.Focus();
                                    }
                                }

                                //
                            }
                        }
                    }
                }
            }

            GetTTL();
            txtCount.Text = getCount().ToString();
            txt_barcode.Focus();

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txt_barcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_price_HT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lb_Total.Text = calcule_TVA(decimal.Parse(txt_price_HT.Text), decimal.Parse(txt_TVA.Text)).ToString();
                txt_price_TTC.Text = calcule_TVA(decimal.Parse(txt_price_HT.Text), decimal.Parse(txt_TVA.Text)).ToString(); 
                LB_ttl_after_remise.Text = calcule_Tmbr(decimal.Parse(txt_price_TTC.Text), decimal.Parse(txt_timbre.Text)).ToString();
            }
            catch
            {

            }
        }

        private void txt_TVA_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lb_Total.Text = calcule_TVA(decimal.Parse(txt_price_HT.Text), decimal.Parse(txt_TVA.Text)).ToString();
                txt_price_TTC.Text = calcule_TVA(decimal.Parse(txt_price_HT.Text), decimal.Parse(txt_TVA.Text)).ToString();
                LB_ttl_after_remise.Text = calcule_Tmbr(decimal.Parse(txt_price_TTC.Text), decimal.Parse(txt_timbre.Text)).ToString(); 
                txt_Versement.Text = LB_ttl_after_remise.Text;
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            frm_add_client addClient = new frm_add_client();
            addClient.Type = "f";
            addClient.vente_facturation = this;
            addClient.ShowDialog();
        }
        private decimal calculeRest(decimal ttl, decimal verse)
        {
            decimal rest = ttl - verse;
            return rest;
        }
        private void txt_Versement_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lb_rest.Text = calculeRest(decimal.Parse(lb_Total.Text), decimal.Parse(txt_Versement.Text)).ToString();

                decimal sold_non_pays = decimal.Parse(lb_historique_credit.Text);
                //calcule_credit_after(decimal.Parse(sold_non_pays.ToString()));
                lb_new_credit.Text = calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString();
            }
            catch
            {

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
        private void kryptonDropButton1_Click(object sender, EventArgs e)
        {
            if (panel14.Visible == true)
            {
                panel14.Visible = false;
            }
            else if (panel14.Visible == false)
            {
                panel14.Visible = true;
            }
        }
        public void DeleteRowByCodeBarre()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView1.Rows.Clear();
                break; // Exit the loop after removing the row 
            }
        }
        private void BTN3_Click(object sender, EventArgs e)
        {
            DeleteRowByCodeBarre();
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {

                DeleteRowByCodeBarre(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
                dataGridView1.Refresh();
                GetTTL();
                txtCount.Text = getCount().ToString();
                return;

            }
            else
            {
                MessageBox.Show("لاتوجد منتوجات  لحذفها ");
            }
        }
        private void DeleteRowByCodeBarre(string codeBarre)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["DgvCodeBarr"].Value != null &&
                    row.Cells["DgvCodeBarr"].Value.ToString() == codeBarre)
                {
                    dataGridView1.Rows.Remove(row);
                    break; // Exit the loop after removing the row
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "dgvDelleteE")
            {
                if (dataGridView1.Rows.Count > 0)
                {

                    DeleteRowByCodeBarre(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    dataGridView1.Refresh();
                    GetTTL();
                    txtCount.Text = getCount().ToString();
                    return;

                }
                else
                {
                    MessageBox.Show("لاتوجد منتوجات  لحذفها ");
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Dgv_edit")
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    frm_edit_QT_facturation  editFctr = new frm_edit_QT_facturation();
                    editFctr.txtBox.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    editFctr.type = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    editFctr.codebarre = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    editFctr.original_price =decimal.Parse( this.dataGridView1.CurrentRow.Cells["org_pric"].Value.ToString());
                    if (this.dataGridView1.CurrentRow.Cells[6].Value.ToString() == "P")
                    {
                        string CodeBarrre = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        DataTable Dt = new DataTable();
                        Dt = caisseVente_classe.select_pack_info(CodeBarrre);
                        if (Dt.Rows.Count > 0)
                        {
                            Object codeBarre = Dt.Rows[0][0];
                            Object name_product = Dt.Rows[0][1];
                            Object price_Vente = Dt.Rows[0][4];
                            Object price_Achat = Dt.Rows[0][7];
                            Object Qt_dans_pack = Dt.Rows[0][8];
                            editFctr.qt_danspack = Qt_dans_pack.ToString();
                            editFctr.price_achat_u = price_Achat.ToString();
                        }
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
                            Object price_Vente = Dtt.Rows[0][15];
                            Object Quanite_dans_pack = Dtt.Rows[0][24];
                            Object price_achat_produit_revent = Dtt.Rows[0][12];
                            editFctr.qt_danspack = "1";
                            editFctr.price_achat_u = price_achat_produit_revent.ToString();
                        }

                    }
                    editFctr.frmVente = this;
                    editFctr.txtBox.Focus();
                    editFctr.txtBox.SelectAll();
                    editFctr.ShowDialog();
                }
                else
                {
                    MessageBox.Show("يرجى تحديد المنتوج");
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "dgv_remise_pro")
            {
                frm_remise_produit_facturation change_Price = new frm_remise_produit_facturation(); 
                change_Price.codebarre = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string barcode = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                change_Price.txt_price_product.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
                DataTable Dtt = caisseVente_classe.getSold_MAtier_revent(barcode);
                object price_Vente_min = Dtt.Rows[0][17];
                change_Price.price_min = decimal.Parse(price_Vente_min.ToString());
                change_Price.frmVente = this;
                change_Price.ShowDialog();
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            show_and_hide_columns(checkBox4, "n_colis");
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            show_and_hide_columns(checkBox5, "colissage");
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            show_and_hide_columns(checkBox6, "P_remise");
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

            show_and_hide_columns(checkBox7, "prsnt_remise");
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

            show_and_hide_columns(checkBox8, "org_pric");
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

            show_and_hide_columns(checkBox9, "dataGridViewTextBoxColumn7");
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

            show_and_hide_columns(checkBox10, "coute_ttl");
        }

        private void lb_Total_Click(object sender, EventArgs e)
        {

        }

        private void lb_Total_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    lb_Total.Text = calcule_TVA(decimal.Parse(txt_price_HT.Text), decimal.Parse(txt_TVA.Text)).ToString();
            //    txt_price_TTC.Text = calcule_TVA(decimal.Parse(txt_price_HT.Text), decimal.Parse(txt_TVA.Text)).ToString();
            //}
            //catch
            //{

            //}
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_prix_remisier_TextChanged(object sender, EventArgs e)
        {
            lb_Total.Text = calcule_remise
                    (
                    decimal.Parse(LB_ttl_after_remise.Text),
                    decimal.Parse(lbl_prix_remisier.Text)
                    ).ToString();

            txt_Versement.Text = lb_Total.Text;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal total = calcule_Tmbr(decimal.Parse(txt_price_TTC.Text), decimal.Parse(txt_timbre.Text));
                lb_Total.Text = total.ToString();
                LB_ttl_after_remise.Text = total.ToString();
                txt_Versement.Text = LB_ttl_after_remise.Text;
            }
            catch
            {

            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                count++;
                var cellValue = row.Cells[0].Value;
                cellValue = count;
                row.Cells[0].Value = cellValue;
            }
        }

        private void BTN5_Click(object sender, EventArgs e)
        {
            frm_liste_facturation_vente frm_facture = new frm_liste_facturation_vente();
            frm_facture.ShowDialog();
        }
        public void delte_qt_matier()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Récupérez les valeurs nécessaires de la ligne actuelle du DataGridView
                    string idProduit = row.Cells["DgvCodeBarr"].Value.ToString();
                    DataTable Dt = new DataTable();
                    Dt = caisseVente_classe.getSold_MAtier_revent(idProduit);
                    if (Dt.Rows.Count > 0)
                    {
                        Object codeBarre = Dt.Rows[0][0];
                        Object name_product = Dt.Rows[0][1];
                        Object price_Vente = Dt.Rows[0][15];
                        Object Quanite_dans_pack = Dt.Rows[0][24];
                        Object price_achat_produit_revent = Dt.Rows[0][12];
                        float quantite_vnt = float.Parse(row.Cells["dgvQtt"].Value.ToString()); // Assurez-vous de remplacer "nouvelle_quantite" par le nom réel de la colonne 
                        classQt_vente.delete_Produit_revent(codeBarre.ToString(), quantite_vnt);

                        //la fonction dellete
                    }
                    else
                    {
                        Dt = caisseVente_classe.select_pack_info(idProduit);
                        if (Dt.Rows.Count > 0)
                        {

                            Object codeBarre = Dt.Rows[0][0];
                            Object name_product = Dt.Rows[0][1];
                            Object codeBarre_Produit = Dt.Rows[0][2];
                            Object price_Vente = Dt.Rows[0][4];
                            Object price_Achat = Dt.Rows[0][7];
                            Object Qt_dans_pack = Dt.Rows[0][8];
                            float quantite_vnt = float.Parse(row.Cells["dgvQtt"].Value.ToString()) *
                                                                                float.Parse(Qt_dans_pack.ToString());
                            // Appelez la fonction dellte produit apartire du pack
                            classQt_vente.delete_Produit_revent(codeBarre_Produit.ToString(), quantite_vnt);

                        }
                    }

                }
            }
        }
        private void insert_detaille_facturation()
        {
            convertTOwriter();
            decimal cout = 0; 
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells["coute_ttl"].Value != null)
                {
                    decimal cellValue;
                    // Try to parse the cell value to double
                    if (decimal.TryParse(row.Cells["coute_ttl"].Value.ToString(), out cellValue))
                    {
                        cout += cellValue;
                    }
                    else
                    {
                        // Handle the case where parsing fails (e.g., log the issue)
                        // Optionally you can display a message or handle it as needed
                    }
                }
            }

            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            DateTime currentDateTime = DateTime.Now;
            class_facture_vente.InsertFacturation
                    (
                    txt_id_fctr.Text,
                    Convert.ToInt32(clientCmb.SelectedValue),
                    ID_caissier,
                    id_user,
                    Convert.ToDateTime(dateTimetxt.Text),
                    currentTime,
                    decimal.Parse(lb_Total.Text),
                    decimal.Parse(txt_price_HT.Text),
                    decimal.Parse(txt_TVA.Text),
                    decimal.Parse(lbl_prix_remisier.Text),
                    float.Parse(lbl_prix_remisier.Text),
                    float.Parse(txt_timbre.Text),
                    decimal.Parse(txt_price_TTC.Text),
                    Convert.ToInt32(txtCount.Text),
                    float.Parse(txt_qt.Text),
                    price_on_arabic,
                    price_on_fr,
                    comboBox2.Text,
                    decimal.Parse(lb_historique_credit.Text),
                    decimal.Parse(txt_Versement.Text),
                    decimal.Parse(lb_new_credit.Text),
                    txt_remarque.Text,
                    cout,
                    ""
                    );
            classCaisse.update_history_caissier(
                   ID_historique,
                   currentDateTime.TimeOfDay,
                   decimal.Parse(lb_Total.Text)
                   );
            historique_Client.insert_history_client(
                        Convert.ToDateTime(dateTimetxt.Text),
                        Convert.ToInt32(clientCmb.SelectedValue),
                        decimal.Parse(lb_Total.Text),
                        decimal.Parse(txt_Versement.Text),
                        decimal.Parse(lb_historique_credit.Text),
                        decimal.Parse(lb_new_credit.Text),
                        "فاتورة",
                        txt_id_fctr.Text
                        );
            historique_Client.edit_sold_client(
                        Convert.ToInt32(clientCmb.SelectedValue),
                        decimal.Parse(txt_Versement.Text),
                        decimal.Parse(lb_new_credit.Text),
                        decimal.Parse(lb_Total.Text)
                        );
            delte_qt_matier();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Récupérez les valeurs nécessaires de la ligne actuelle du DataGridView
                    string codeBarrePRoduit = row.Cells["DgvCodeBarr"].Value?.ToString();
                    string designation = row.Cells["dvg_designation"].Value?.ToString();
                    float? N_COLIS = float.TryParse(row.Cells["n_colis"].Value?.ToString(), out float tempNColis) ? tempNColis : (float?)null;
                    float? COLISSAGE = float.TryParse(row.Cells["colissage"].Value?.ToString(), out float tempColissage) ? tempColissage : (float?)null;
                    float QTE = float.TryParse(row.Cells["dgvQtt"].Value?.ToString(), out float tempQte) ? tempQte : 0;
                    decimal PRIC_U = decimal.TryParse(row.Cells["dgvAmountt"].Value?.ToString(), out decimal tempPriceU) ? tempPriceU : 0;
                    decimal PRIE_TTL = decimal.TryParse(row.Cells["org_pric"].Value?.ToString(), out decimal tempPrieTtl) ? tempPrieTtl : 0;
                    decimal REMIS = decimal.TryParse(row.Cells["P_remise"].Value?.ToString(), out decimal tempRemis) ? tempRemis : 0;
                    decimal PRICE_APRES_REMISE = decimal.TryParse(row.Cells["dgbTTTL"].Value?.ToString(), out decimal tempPriceApresRemise) ? tempPriceApresRemise : 0;
                    float PRNST = float.TryParse(row.Cells["prsnt_remise"].Value?.ToString(), out float tempPrnst) ? tempPrnst : 0;
                    string IdFacture = txt_id_fctr.Text;

                    // استدعاء الدالة بعد التأكد من صحة القيم
                    class_facture_vente.InsertFacturationVente(
                        codeBarrePRoduit,
                        designation,
                        N_COLIS,
                        COLISSAGE,
                        QTE,
                        PRIC_U,
                        PRIE_TTL,
                        REMIS,
                        PRICE_APRES_REMISE,
                        PRNST,
                        IdFacture
                    );

                    // Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit 
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                frm_edit_QT_facturation editFctr = new frm_edit_QT_facturation();
                editFctr.txtBox.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                editFctr.type = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                editFctr.codebarre = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                editFctr.original_price = decimal.Parse(this.dataGridView1.CurrentRow.Cells["org_pric"].Value.ToString());
                if (this.dataGridView1.CurrentRow.Cells[6].Value.ToString() == "P")
                {
                    string CodeBarrre = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    DataTable Dt = new DataTable();
                    Dt = caisseVente_classe.select_pack_info(CodeBarrre);
                    if (Dt.Rows.Count > 0)
                    {
                        Object codeBarre = Dt.Rows[0][0];
                        Object name_product = Dt.Rows[0][1];
                        Object price_Vente = Dt.Rows[0][4];
                        Object price_Achat = Dt.Rows[0][7];
                        Object Qt_dans_pack = Dt.Rows[0][8];
                        editFctr.qt_danspack = Qt_dans_pack.ToString();
                        editFctr.price_achat_u = price_Achat.ToString();
                    }
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
                        Object price_Vente = Dtt.Rows[0][15];
                        Object Quanite_dans_pack = Dtt.Rows[0][24];
                        Object price_achat_produit_revent = Dtt.Rows[0][12];
                        editFctr.qt_danspack = "1";
                        editFctr.price_achat_u = price_achat_produit_revent.ToString();
                    }

                }
                editFctr.frmVente = this;
                editFctr.txtBox.Focus();
                editFctr.txtBox.SelectAll();
                editFctr.ShowDialog();
            }
            else
            {
                MessageBox.Show("يرجى تحديد المنتوج");
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("هل أنت متأكد من تأكيد الفاتورة", "تأكيد فاتورة بيع", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { 
                insert_detaille_facturation(); 
                MessageBox.Show("تم تأكيد الفاتورة بنجاح");
                txt_id_fctr.Text = class_facture_vente.get_id_facture_achat();
                GetTTL();
                DeleteRowByCodeBarre();
                dataGridView1.Refresh();
            }
        }
    }
}
