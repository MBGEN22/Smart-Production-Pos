using ComponentFactory.Krypton.Toolkit;
using Smart_Production_Pos.BL;
using Smart_Production_Pos.PL.Achat_revente;
using Smart_Production_Pos.PLADD.Fichier;
using Smart_Production_Pos.TAB_CONTROL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.vente
{
    public partial class Frm_vente_caissev5 : Form
    {
        BL.BL_COMBOBOX Bl_combobox = new BL.BL_COMBOBOX();
        DAL.DAL daoo = new DAL.DAL();
        public int user;
        string barcoder = "";
        public int caissier;
        public decimal price_of_product;
        public string barcode;
        public string NamePO;
        public string reference;
        public decimal Price;
        public decimal FontCaisse;
        public int id_user;
        int achat;
        int stock_produit;
        int facture_achat;
        BL.BL_CAISSE caisseVente_classe = new BL.BL_CAISSE();
        BL.BL_PRODUCTION.BL_GESTION_PRODUIT_FINAUX ClassProduction = new BL.BL_PRODUCTION.BL_GESTION_PRODUIT_FINAUX();
        BL.BL_ACHAT_REVENT.BL_PRODUIT classProduit = new BL.BL_ACHAT_REVENT.BL_PRODUIT();
        BL.BL_vente.BL_vente_Fonction classVente = new BL.BL_vente.BL_vente_Fonction();
        BL.Client_history_sold historique_Client = new BL.Client_history_sold();
        BL.BL_vente.BL_SP_LOGINE_Caisse classCaisse = new BL.BL_vente.BL_SP_LOGINE_Caisse();
        BL.BL_vente.bl_diminuer_la_Qt_vente classQt_vente = new BL.BL_vente.bl_diminuer_la_Qt_vente();
        BL.BL_parametre.BL_paramtre_informatiion class_setting = new BL.BL_parametre.BL_paramtre_informatiion();
        public string Typpped;
        public int type;
        public int ID_historique;
        public decimal Prix_Cloture;
        public int ID_caissier;
        decimal Price_achat;
        string txt_new_montant;
        string Typpe;
        public string pourcentageRemise;
        Object price_Vente;
        Sp_Logine classLogine = new Sp_Logine();
        // //////////////// 
        DataTable table = new DataTable();
        int rowIndex;
        BL.BL_vente.BL_class_vente classvente = new BL.BL_vente.BL_class_vente();
        public Frm_vente_caissev5()
        {
            InitializeComponent();
            clientCmb.DataSource = Bl_combobox.get_combo_client();
            clientCmb.DisplayMember = "Client";
            clientCmb.ValueMember = "ID";
            dataGridView1.Columns["cout_ttl"].Visible = false;
            //dataGridView1.Columns[7].Visible = false;
            txt_id_fctr.Text = classVente.get_fctr_vnt();
            if (pack_check_produit_revent.Checked == true)
            {
                cmbProduct.DataSource = Bl_combobox.pack_produit_prevent();
                cmbProduct.ValueMember = "pack_code_barre";
                cmbProduct.DisplayMember = "pack_designation";
            }
            else if (check_produit_revent.Checked == true)
            {
                cmbProduct.DataSource = Bl_combobox.get_combo_produit_prevent();
                cmbProduct.DisplayMember = "designation";
                cmbProduct.ValueMember = "CodeBarre";
            }
            else if (kryptonRadioButton1.Checked == true)
            {
                cmbProduct.DataSource = Bl_combobox.produit_fabrique();
                cmbProduct.DisplayMember = "DESIGNATION";
                cmbProduct.ValueMember = "CODE_BARRE";
            }
            else if (pack_produit_fabrique.Checked == true)
            {
                cmbProduct.DataSource = Bl_combobox.get_combo_pack_fabrique();
                cmbProduct.DisplayMember = "DESIGNATION";
                cmbProduct.ValueMember = "PRICE_DETAILLE";
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void spaceSeparatorVertical2_Click(object sender, EventArgs e)
        {

        }

        private void BTN9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هذا الخيار سيقوم بغلق النافذة", "غلق الواجهة  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public void loadFav()
        {
            string Qry = "SELECT [ID] ,[FAVOIRE] FROM [dbo].[TB_FAVORIS]";
            SqlCommand cmd = new SqlCommand(Qry, daoo.sqlConnection);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                foreach (DataRow row in Dt.Rows)
                {

                    ADD_FAV(
                        Convert.ToInt32(row["ID"].ToString()),
                        row["FAVOIRE"].ToString()
                        );
                }
            }
        }
        private void ADD_FAV(int ID, string Name)
        {

            var W = new favCaisseV5()
            {
                PID = ID,
                PName = Name
            };

            flowCategories.Controls.Add(W);

            W.onSelect += (ss, ee) =>
            {
                var wdg = (favCaisseV5)ss;
                //foreach (User_Fav fav in flowCategories.Controls.OfType<User_Fav>())
                //{
                //    if (fav.PID == wdg.PID)
                //    {
                //        fav.SetLabelBackColor(Color.DeepSkyBlue); // Change color to Red or any color you like
                //    }
                //    else
                //    {
                //        fav.SetLabelBackColor(Color.Transparent); // Default color or any other color
                //    }
                //}
                flowLAyoutProduct.Controls.Clear();
                loadProduct(ID);
                loadPack(ID);
            };
        }
        private void addiTem(string CodeBarre, string Name, string Price, int IDFAV, string Fav, Image pic, string Type, string Achat, float qtRest, float qtaler)
        {

            var W = new Caisse_V5()
            {
                PName = Name,
                PPriceTTC = decimal.Parse(Price),
                PCodeBarre = CodeBarre,
                PIDFAV = IDFAV,
                PFavoire = Fav,
                PImage = pic,
                Ptype = Type,
                PPriceAchat = Achat,
                QT_rest = qtRest,
                QT_Alert = qtaler
            };

            flowLAyoutProduct.Controls.Add(W);

            W.onSelect += (ss, ee) =>
            {
                var wdg = (Caisse_V5)ss;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var cellValue = row.Cells["DgvCodeBarre"].Value;

                        // Check if the cell value is not null before comparison
                        if (cellValue != null && cellValue.ToString() == wdg.PCodeBarre)
                        {
                            row.Cells["dgvQt"].Value = (float.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                            row.Cells["dgbTtl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                    float.Parse(row.Cells["dgvAmount"].Value.ToString());
                            row.Cells["cout_ttl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                float.Parse(Achat.ToString());

                            GetTTL();
                            txtCount.Text = getCount().ToString();

                            return;
                        }
                    }
                }
                //this Line add new product
                if (qtRest <= qtaler)
                {
                    if (MessageBox.Show("الكمية قريبة من النفاذ او نفذت هل تريد المواصلة", "كمية قليلة", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dataGridView1.Rows.Add(new object[] { 0, wdg.PCodeBarre, wdg.PName, 1, wdg.PPriceTTC, wdg.PPriceTTC, wdg.Ptype, wdg.PPriceAchat });
                        Price_achat = decimal.Parse(wdg.PPriceAchat);
                        GetTTL();
                        txtCount.Text = getCount().ToString();
                    }
                }
                else
                {
                    dataGridView1.Rows.Add(new object[] { 0, wdg.PCodeBarre, wdg.PName, 1, wdg.PPriceTTC, wdg.PPriceTTC, wdg.Ptype, wdg.PPriceAchat });
                    Price_achat = decimal.Parse(wdg.PPriceAchat);
                    GetTTL();
                    txtCount.Text = getCount().ToString();
                }



            };
        }
        public void loadProduct(int id)
        {
            string Qry = @"SELECT [CodeBarre]     
                        ,[designation]      
                        ,[reference] 
                        ,[id_categories] 
                        ,[id_stocke] 
                        ,[id_marque] 
                        ,[id_unite] 
                        ,[id_taille] 
                        ,[id_color] 
                        ,[id_favoire]  
                        ,TB_FAVORIS.FAVOIRE as 'fav' 
                        ,[date_expiration] 
                        ,[price_achat_HT] 
                        ,[price_achat_TTC] 
                        ,[TVA] 
                        ,[Quantite_TOTAL] 
                        ,[price_vente1] 
                        ,[price_vente2] 
                        ,[price_min] 
                        ,[vente_apres_expiration] 
                        ,[stocke_negatif] 
                        ,[Quantite_vente] 
                        ,[Quantite_rest] 
                        ,[Quantite_dechet] 
                        ,[Photo] 
                        ,[QT_DANS_PACK] 
                        ,[Quantite_alert] 
                   FROM TB_Produit_revente   
                   INNER JOIN TB_FAVORIS on TB_FAVORIS.ID = TB_Produit_revente.id_favoire 
                   WHERE [id_favoire] = @id";

            using (SqlCommand cmd = new SqlCommand(Qry, daoo.sqlConnection))
            {
                // Set the value for the @id parameter
                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataAdapter Da = new SqlDataAdapter(cmd))
                {
                    DataTable Dt = new DataTable();
                    Da.Fill(Dt);

                    if (Dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in Dt.Rows)
                        {
                            Byte[] immage_array = (byte[])row["Photo"];

                            if (chek_prix1.Checked == true)
                            {
                                addiTem(
                                    row["CodeBarre"].ToString(),
                                    row["designation"].ToString(),
                                    row["price_vente1"].ToString(),
                                    Convert.ToInt32(row["id_favoire"]),
                                    row["fav"].ToString(),
                                    Image.FromStream(new MemoryStream(immage_array)),
                                    "U",
                                    row["price_achat_TTC"].ToString(),
                                    float.Parse(row["Quantite_rest"].ToString()),
                                    float.Parse(row["Quantite_alert"].ToString())
                                );
                            }
                            else if (check_prix2.Checked == true)
                            {
                                addiTem(
                                    row["CodeBarre"].ToString(),
                                    row["designation"].ToString(),
                                    row["price_vente2"].ToString(),
                                    Convert.ToInt32(row["id_favoire"]),
                                    row["fav"].ToString(),
                                    Image.FromStream(new MemoryStream(immage_array)),
                                    "U",
                                    row["price_achat_TTC"].ToString(),
                                    float.Parse(row["Quantite_rest"].ToString()),
                                    float.Parse(row["Quantite_alert"].ToString())
                                );
                            }
                            else if (check_prix3.Checked == true)
                            {
                                addiTem(
                                    row["CodeBarre"].ToString(),
                                    row["designation"].ToString(),
                                    row["price_min"].ToString(),
                                    Convert.ToInt32(row["id_favoire"]),
                                    row["fav"].ToString(),
                                    Image.FromStream(new MemoryStream(immage_array)),
                                    "U",
                                    row["price_achat_TTC"].ToString(),
                                    float.Parse(row["Quantite_rest"].ToString()),
                                    float.Parse(row["Quantite_alert"].ToString())
                                );
                            }
                        }
                    }
                }
            }
        }
        public void loadPack(int id)
        {
            string Qry = @"SELECT [pack_code_barre] 
                        ,TB_Produit_revente.price_achat_TTC * TB_Produit_revente.QT_DANS_PACK as 'Achat' 
                        ,[pack_designation] 
                        ,[code_barre_produit] 
                        ,[quantite]   
                        ,[price_unitair]   
                        ,[TB_PACK_PRODUIT_REVENT].[photo] 
                        ,[TB_PACK_PRODUIT_REVENT].[id_favoire]
                        ,TB_Produit_revente.Quantite_alert as 'QT'
                        ,TB_Produit_revente.Quantite_rest as 'QR'   
                   FROM [dbo].[TB_PACK_PRODUIT_REVENT] 
                   INNER JOIN TB_FAVORIS ON TB_FAVORIS.ID = [TB_PACK_PRODUIT_REVENT].id_favoire
                   INNER JOIN TB_Produit_revente ON TB_Produit_revente.CodeBarre = TB_PACK_PRODUIT_REVENT.code_barre_produit
                   WHERE [TB_PACK_PRODUIT_REVENT].id_favoire = @id";

            using (SqlCommand cmd = new SqlCommand(Qry, daoo.sqlConnection))
            {
                // Set the value for the @id parameter
                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataAdapter Da = new SqlDataAdapter(cmd))
                {
                    DataTable Dt = new DataTable();
                    Da.Fill(Dt);

                    if (Dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in Dt.Rows)
                        {
                            Byte[] immage_array = (byte[])row["photo"];

                            addiTem(
                                row["pack_code_barre"].ToString(),
                                row["pack_designation"].ToString(),
                                row["price_unitair"].ToString(),
                                Convert.ToInt32(row["id_favoire"]),
                                row["id_favoire"].ToString(),
                                Image.FromStream(new MemoryStream(immage_array)),
                                "P",
                                row["Achat"].ToString(),
                                float.Parse(row["QR"].ToString()),
                                float.Parse(row["QT"].ToString())
                            );
                        }
                    }
                }
            }
        }

        private void Frm_vente_caissev5_Load(object sender, EventArgs e)
        {
            if (pack_check_produit_revent.Checked == true)
            {
                cmbProduct.DataSource = Bl_combobox.pack_produit_prevent();
                cmbProduct.ValueMember = "pack_code_barre";
                cmbProduct.DisplayMember = "pack_designation";
            }
            else if (check_produit_revent.Checked == true)
            {
                cmbProduct.DataSource = Bl_combobox.get_combo_produit_prevent();
                cmbProduct.DisplayMember = "designation";
                cmbProduct.ValueMember = "CodeBarre";
            }
            else if (kryptonRadioButton1.Checked == true)
            {
                cmbProduct.DataSource = Bl_combobox.produit_fabrique();
                cmbProduct.DisplayMember = "DESIGNATION";
                cmbProduct.ValueMember = "CODE_BARRE";
            }
            else if (pack_produit_fabrique.Checked == true)
            {
                cmbProduct.DataSource = Bl_combobox.get_combo_pack_fabrique();
                cmbProduct.DisplayMember = "DESIGNATION";
                cmbProduct.ValueMember = "PRICE_DETAILLE";
            }

            //loadProduct();
            //addFavoires();
            //loadProductLoad();
            //loadPackLoad();
            loadFav();
            flowLAyoutProduct.Controls.Clear();
            loadProduct(1);
            loadPack(1);
            //foreach (var item in flowLAyoutProduct.Controls)
            //{
            //	var pro = (Caisse_user_controle)item;
            //	pro.Visible = Convert.ToInt32(pro.PIDFAV) == 1;
            //}
            txt_barcode.Focus();
            txtCount.Text = getCount().ToString();

            if (type == 1)
            {
                frm_money_debut_de_joune debutjourne = new frm_money_debut_de_joune();
                debutjourne.frmVenteCaisseV5 = this;
                debutjourne.Type = "CaisseV5";
                debutjourne.ID_caissier = ID_caissier;
                debutjourne.ShowDialog();
                txt_barcode.Focus();
            }
            else
            {
                this.flowLAyoutProduct.Enabled = true;
                this.panel1.Enabled = true;
                this.panel2.Enabled = true;
                this.panel3.Enabled = true;
                this.panel4.Enabled = true;
                this.panel5.Enabled = true;
                this.btn1.Enabled = true;
                this.BTN2.Enabled = true;
                this.BTN3.Enabled = true;
                this.BTN4.Enabled = true;
                this.BTN5.Enabled = true;
                this.BTN6.Enabled = true;
                this.BTN7.Enabled = true;
                this.BTN8.Enabled = true;
                this.BTN9.Enabled = true;
                this.btn10.Enabled = true;
                this.txt_barcode.Focus();
            }

            //LB_heures.Text = DateTime.Now.ToLongDateString();
            //LB_Date.Text = DateTime.Now.ToLongTimeString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in flowLAyoutProduct.Controls)
            {
                var pro = (Caisse_V5)item;
                pro.Visible = pro.PName.ToLower().Contains(txtSearch.Text.Trim().ToLower());
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
        public void GetTTL()
        {
            double ttl = 0;
            lb_Total.Text = "0";
            lbl_price_off.Text = "0";

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells["dgbTtl"].Value != null)
                {
                    double cellValue;
                    // Try to parse the cell value to double
                    if (double.TryParse(row.Cells["dgbTtl"].Value.ToString(), out cellValue))
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

            // تطبيق قاعدة التدوير الجديدة
            //double roundedValue;

            //if (ttl < 2.5)
            //{
            //    roundedValue = 0;
            //}
            //else if (ttl < 5)
            //{
            //    roundedValue = 5;
            //}
            //else if (ttl < 7.5)
            //{
            //    roundedValue = 5;
            //}
            //else if (ttl < 10)
            //{
            //    roundedValue = 10;
            //}
            //else
            //{
            //    roundedValue = ttl; // إذا كانت القيمة أكبر من 10، تُترك كما هي
            //}

            lb_Total.Text = ttl.ToString("N2");
            lbl_price_off.Text = ttl.ToString("N2");
            txt_Versement.Text = ttl.ToString("N2");
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
                calcule_credit_after(decimal.Parse(sold_non_pays.ToString()));
                lb_new_credit.Text = calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString();
                if (decimal.Parse(lb_rest.Text) < 0)
                {
                    lb_rest.ForeColor = Color.Green;
                }
                else if (decimal.Parse(lb_rest.Text) > 0)
                {
                    lb_rest.ForeColor = Color.Red;
                }
            }
            catch
            {

            }
        }
        public decimal calcule_credit_after(decimal sold_old)
        {
            decimal sold_after = decimal.Parse(lb_rest.Text);
            decimal soldnew = sold_old + sold_after;
            return soldnew;
        }

        private void clientCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)clientCmb.SelectedItem;
            string sold_non_pays = drv["SOLD_NON_PAYE"].ToString();
            lb_historique_credit.Text = sold_non_pays.ToString();
            calcule_credit_after(decimal.Parse(sold_non_pays.ToString()));
            lb_new_credit.Text = calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString();
        }

        private void check_produit_revent_CheckedChanged(object sender, EventArgs e)
        {
            cmbProduct.DataSource = Bl_combobox.get_combo_produit_prevent();
            cmbProduct.DisplayMember = "designation";
            cmbProduct.ValueMember = "CodeBarre";
        }

        private void pack_check_produit_revent_CheckedChanged(object sender, EventArgs e)
        {
            cmbProduct.DataSource = Bl_combobox.pack_produit_prevent();
            cmbProduct.DisplayMember = "pack_designation";
            cmbProduct.ValueMember = "pack_code_barre";
        }
        public void getinformation_matier_revent()
        {
            string CodeBarrre = txt_barcode.Text;
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

                                        return;
                                    }
                                }
                            }
                            GetTTL();
                            txtCount.Text = getCount().ToString();

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

                                            return;
                                        }
                                    }
                                }
                                GetTTL();
                                txtCount.Text = getCount().ToString();

                                return;
                            }
                        }
                    }
                    //this Line add new product
                    dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "U", cout_de_prodution.ToString() });

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

                                    return;
                                }
                            }
                        }
                        //this Line add new product
                        dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "P", cout_produire_pack_favrique });

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

                                        return;
                                    }
                                }
                            }
                            //this Line add new product
                            dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "P", cout_produire_pack_favrique.ToString() });

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

                                            return;
                                        }
                                    }
                                }
                                //this Line add new product
                                dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "U" });

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

                                                return;
                                            }
                                        }
                                    }
                                    //this Line add new product
                                    dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "P" });

                                    //MessageBox.Show("هذا المنتوج غير موجود في قاعدة البيانات");
                                }
                                else
                                {
                                    frm_barcodeempty barccodeemty = new frm_barcodeempty();
                                    barccodeemty.TextBarcode.Text = CodeBarrre.ToString();
                                    barccodeemty.Show();
                                }

                                //
                            }
                        }
                    }
                }
            }

            GetTTL();
            txtCount.Text = getCount().ToString();
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)cmbProduct.SelectedItem;

            if (check_produit_revent.Checked == true)
            {
                barcode = drv["CodeBarre"].ToString();
                Price = decimal.Parse(drv["price_vente1"].ToString());
                NamePO = drv["designation"].ToString();
                reference = drv["reference"].ToString();
                textBox1.Text = reference.ToString();
            }
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            //string barcode;
            //decimal Price; 
            DataRowView drv = (DataRowView)cmbProduct.SelectedItem;
            if (pack_check_produit_revent.Checked)
            {
                barcode = drv["pack_code_barre"].ToString();
                DataTable Dst = new DataTable();
                Dst = caisseVente_classe.select_pack_info(barcode);
                if (Dst.Rows.Count > 0)
                {
                    Object codeBarre = Dst.Rows[0][0];
                    Object name_product = Dst.Rows[0][1];
                    Object price_Vente = Dst.Rows[0][4];
                    Object price_Achat = Dst.Rows[0][7];
                    Object Qt_dans_pack = Dst.Rows[0][8];
                    decimal cout_produire_pack_favrique = decimal.Parse(price_Achat.ToString()) * decimal.Parse(Qt_dans_pack.ToString());
                    foreach (DataGridViewRow row in dataGridView1.Rows)
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
                                                        decimal.Parse(cout_produire_pack_favrique.ToString());
                                GetTTL();
                                txtCount.Text = getCount().ToString();

                                return;
                            }
                        }
                    }
                    //this Line add new product
                    dataGridView1.Rows.Add(new object[] {
                        0,
                        codeBarre.ToString(),
                        name_product.ToString(),
                        txt_qt.Text ,
                        price_Vente.ToString(),
                         (decimal.Parse(price_Vente.ToString())*(decimal.Parse(txt_qt.Text))),
                        "P",
                         (decimal.Parse(cout_produire_pack_favrique.ToString())*(decimal.Parse(txt_qt.Text)))
                    });

                }


            }
            else if (check_produit_revent.Checked)
            {
                barcode = drv["CodeBarre"].ToString();
                Price = decimal.Parse(drv["price_vente1"].ToString());
                NamePO = drv["designation"].ToString();
                DataTable Dtt = new DataTable();
                Dtt = caisseVente_classe.getSold_MAtier_revent(barcode);
                if (Dtt.Rows.Count > 0)
                {
                    Object codeBarre = Dtt.Rows[0][0];
                    Object name_product = Dtt.Rows[0][1];
                    Object Qt_alter = Dtt.Rows[0][25];
                    Object Qt_rest = Dtt.Rows[0][21];

                    if (chek_prix1.Checked == true)
                    {
                        price_Vente = Dtt.Rows[0][15];
                    }
                    else if (check_prix2.Checked == true)
                    {
                        price_Vente = Dtt.Rows[0][16];
                    }
                    else if (check_prix3.Checked == true)
                    {
                        price_Vente = Dtt.Rows[0][17];
                    }
                    Object Quanite_dans_pack = Dtt.Rows[0][24];
                    Object price_achat_produit_revent = Dtt.Rows[0][12];
                    if (float.Parse(Qt_rest.ToString()) <= float.Parse(Qt_alter.ToString()))
                    {
                        if (MessageBox.Show("الكمية قريبة من النفاذ او نفذت هل تريد المواصلة", "كمية قليلة", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            foreach (DataGridViewRow row in dataGridView1.Rows)
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
                                        GetTTL();
                                        txtCount.Text = getCount().ToString();
                                        return;
                                    }
                                }
                            }
                            dataGridView1.Rows.Add(new object[] {
                            0,
                            codeBarre.ToString(),
                            name_product.ToString(),
                            txt_qt.Text ,
                            price_Vente.ToString(),
                             (decimal.Parse(price_Vente.ToString())*(decimal.Parse(txt_qt.Text))),
                            "U",
                             (decimal.Parse(price_achat_produit_revent.ToString())*(decimal.Parse(txt_qt.Text)))
                             });
                        }


                    }
                    else
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
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
                                    GetTTL();
                                    txtCount.Text = getCount().ToString();
                                    return;
                                }
                            }
                        }
                        dataGridView1.Rows.Add(new object[] {
                            0,
                            codeBarre.ToString(),
                            name_product.ToString(),
                            txt_qt.Text ,
                            price_Vente.ToString(),
                             (decimal.Parse(price_Vente.ToString())*(decimal.Parse(txt_qt.Text))),
                            "U",
                             (decimal.Parse(price_achat_produit_revent.ToString())*(decimal.Parse(txt_qt.Text)))
                             });
                    }
                }
            }
            //else if (kryptonRadioButton1.Checked)
            //{
            //    barcode = drv["CODE_BARRE"].ToString();
            //    Price = decimal.Parse(drv["PRICE_VENTE_TTC"].ToString());
            //    NamePO = drv["DESIGNATION"].ToString();
            //}
            //else if (pack_produit_fabrique.Checked)
            //{
            //    barcode = drv["BARCODE_PACK"].ToString();
            //    Price = decimal.Parse(drv["PRICE_DETAILLE"].ToString());
            //    NamePO = drv["DESIGNATION"].ToString();
            //}
            #region
            //DataTable Dt = new DataTable();
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //	if (!row.IsNewRow)
            //	{
            //		var cellValue = row.Cells["DgvCodeBarre"].Value;

            //		// Check if the cell value is not null before comparison
            //		if (cellValue != null && cellValue.ToString() == barcode.ToString())
            //		{
            //			row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
            //			row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
            //									decimal.Parse(row.Cells["dgvAmount"].Value.ToString());

            //			GetTTL();
            //			txtCount.Text = getCount().ToString();

            //			return;
            //		}
            //	}
            //}
            ////this Line add new product
            //float ttlPrice = float.Parse(txt_qt.Text) * float.Parse(Price.ToString());
            //dataGridView1.Rows.Add(new object[] { 0, barcode, NamePO.ToString(), txt_qt.Text, Price.ToString(), ttlPrice.ToString() });
            #endregion
            GetTTL();
            txtCount.Text = getCount().ToString();
            txt_qt.Text = "1";
        }

        private void kryptonButton16_Click(object sender, EventArgs e)
        {
            frm_add_divers add_divers = new frm_add_divers();
            add_divers.formVenteV5 = this; 
            add_divers.Type = "V5";
            add_divers.ShowDialog();
        }

        private void kryptonButton22_Click(object sender, EventArgs e)
        {
            frm_remise addRemise = new frm_remise();
            addRemise.txt_price_product.Text = lb_Total.Text;
            addRemise.formVentePrincipaleV5 = this;
            addRemise.Type = "V5";
            addRemise.ShowDialog();
        }
        private void ChecK_And_print()
        {
            DataTable dt = new DataTable();
            dt = class_setting.Get_paramater_tb();
            object PRINT_FACTURE = dt.Rows[0][0]; ;
            object PRINT_BON = dt.Rows[0][1]; ;
            object PRINT_BON_A4 = dt.Rows[0][2]; ;
            object DONT_PRINT = dt.Rows[0][3]; ;

            string PRINT_FACTUREe = PRINT_FACTURE.ToString();
            string PRINT_BONn = PRINT_BON.ToString();
            string PRINT_BON_A44 = PRINT_BON_A4.ToString();
            string DONT_PRINTt = DONT_PRINT.ToString();

            if (PRINT_FACTUREe.ToString() == "true")
            {
                print_facture();

            }
            else if (PRINT_BONn.ToString() == "true")
            {
                print_bon();
            }
            else if (PRINT_BON_A44.ToString() == "true")
            {
                print_bon_A4();
            }
            else if (DONT_PRINTt.ToString() == "true")
            {

            }
        }
        private void print_facture()
        {
            report.vente.RP_fctr_vente rpt = new report.vente.RP_fctr_vente();
            string mode = Properties.Settings.Default.mode;

            if (mode == "SQL")
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                rpt.DataSourceConnections[0].SetConnection(
                    Properties.Settings.Default.server,
                    Properties.Settings.Default.dataBase,
                    Properties.Settings.Default.ID,
                    Properties.Settings.Default.PASS
                );
            }
            else
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = true;
                rpt.DataSourceConnections[0].SetConnection(
                    Properties.Settings.Default.server,
                    Properties.Settings.Default.dataBase,
                    true
                );
            }

            rpt.Refresh();
            rpt.SetParameterValue("@nmr_Facture", txt_id_fctr.Text);

            // Print the report directly
            rpt.PrintToPrinter(1, false, 0, 0);
        }
        private void print_bon_A4()
        {
            report.vente.bon_de_vente rpt = new report.vente.bon_de_vente();
            string mode = Properties.Settings.Default.mode;

            if (mode == "SQL")
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                rpt.DataSourceConnections[0].SetConnection(
                    Properties.Settings.Default.server,
                    Properties.Settings.Default.dataBase,
                    Properties.Settings.Default.ID,
                    Properties.Settings.Default.PASS
                );
            }
            else
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = true;
                rpt.DataSourceConnections[0].SetConnection(
                    Properties.Settings.Default.server,
                    Properties.Settings.Default.dataBase,
                    true
                );
            }

            rpt.Refresh();
            rpt.SetParameterValue("@nmr_Facture", txt_id_fctr.Text);

            // Print the report directly
            rpt.PrintToPrinter(1, false, 0, 0);
        }
        private void print_bon()
        {
            report.vente.receipt1 rpt = new report.vente.receipt1();
            string mode = Properties.Settings.Default.mode;

            if (mode == "SQL")
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                rpt.DataSourceConnections[0].SetConnection(
                    Properties.Settings.Default.server,
                    Properties.Settings.Default.dataBase,
                    Properties.Settings.Default.ID,
                    Properties.Settings.Default.PASS
                );
            }
            else
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = true;
                rpt.DataSourceConnections[0].SetConnection(
                    Properties.Settings.Default.server,
                    Properties.Settings.Default.dataBase,
                    true
                );
            }

            rpt.Refresh();
            rpt.SetParameterValue("@nmr_Facture", txt_id_fctr.Text);

            // Print the report directly
            rpt.PrintToPrinter(1, false, 0, 0);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (Typpped == "edit")
                {
                    DateTime currentDateTime = DateTime.Now;
                    edit_fctr_termeinier();
                    DeleteRowByCodeBarre();
                    dataGridView1.Refresh();
                    GetTTL();
                    txtCount.Text = getCount().ToString();
                    ChecK_And_print();
                    txt_id_fctr.Text = classVente.get_fctr_vnt();
                    Typpped = "add";
                }
                else
                {
                    DateTime currentDateTime = DateTime.Now;
                    Facture_terminer();
                    DeleteRowByCodeBarre();
                    dataGridView1.Refresh();
                    GetTTL();
                    txtCount.Text = getCount().ToString();
                    ChecK_And_print();
                    txt_id_fctr.Text = classVente.get_fctr_vnt();
                    Typpped = "add";
                }
                //PopupNotifier notify = new PopupNotifier();
                notify.Image = Properties.Resources.info2;
                notify.BodyColor = Color.Green;
                notify.TitleText = "تم حفظ المبيعة بنجاح";
                notify.TitleText =
                notify.ContentText = "تم تسجيل الفاتورة بنجاح";
                notify.Popup();
            }
            else
            {
                MessageBox.Show("لاتوجد منتوجات لبيعها ");
            }

        }
        private decimal SumColumn(DataGridView dataGridView, string columnName)
        {
            decimal sum = 0;

            // Iterate through each row in the DataGridView
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells[columnName].Value != null && row.Cells[columnName].Value != DBNull.Value)
                {
                    // Try to parse the cell value to decimal and add to the sum
                    if (decimal.TryParse(row.Cells[columnName].Value.ToString(), out decimal value))
                    {
                        sum += value;
                    }
                }
            }

            return sum;
        }
        public void Facture_terminer()
        {
            pourcentageRemise = "0";
            decimal Sum_cout_ttl = SumColumn(dataGridView1, "cout_ttl");
            DateTime currentDateTime = DateTime.Now;
            classVente.insertFacture(
                        txt_id_fctr.Text,
                        Convert.ToDateTime(dateTimetxt.Value),
                        currentDateTime.TimeOfDay,
                        Convert.ToInt32(clientCmb.SelectedValue),
                        decimal.Parse(lb_Total.Text),
                        decimal.Parse(lb_Total.Text),
                        0,
                        decimal.Parse(lb_historique_credit.Text),
                        decimal.Parse(txt_Versement.Text),
                        decimal.Parse(lb_new_credit.Text),
                        decimal.Parse(lbl_prix_remisier.Text),
                        float.Parse(pourcentageRemise),
                        int.Parse(txtCount.Text),
                        "",
                        "فاتورة مكتملة",
                        id_user,
                        ID_caissier,
                        Sum_cout_ttl
                        );
            classCaisse.update_history_caissier(
                    ID_historique,
                    currentDateTime.TimeOfDay,
                    decimal.Parse(lb_Total.Text)
                    );
            historique_Client.insert_history_client(
                        Convert.ToDateTime(dateTimetxt.Value),
                        Convert.ToInt32(clientCmb.SelectedValue),
                        decimal.Parse(lb_Total.Text),
                        decimal.Parse(txt_Versement.Text),
                        decimal.Parse(lb_historique_credit.Text),
                        decimal.Parse(lb_new_credit.Text),
                        "سند جديد",
                        txt_id_fctr.Text
                        );
            historique_Client.edit_sold_client(
                        Convert.ToInt32(clientCmb.SelectedValue),
                        decimal.Parse(txt_Versement.Text),
                        decimal.Parse(lb_new_credit.Text),
                        decimal.Parse(lb_Total.Text)
                        );
            delte_qt_matier();
            //insert list de vente
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Récupérez les valeurs nécessaires de la ligne actuelle du DataGridView
                    string codeBarrePRoduit = row.Cells["DgvCodeBarre"].Value.ToString();
                    float Quantitevente = float.Parse(row.Cells["dgvQt"].Value.ToString());
                    decimal PrixVente = decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
                    decimal PrixTotal = decimal.Parse(row.Cells["dgbTtl"].Value.ToString());
                    decimal cout_ttl = decimal.Parse(row.Cells["cout_ttl"].Value.ToString()); 
                    string DgvType = row.Cells["DgvType"].Value.ToString();

                    string IdFacture = txt_id_fctr.Text;
                    // Assurez-vous de remplacer "nouvelle_quantite" par le nom réel de la colonne
                    classVente.InsertVente(
                                              codeBarrePRoduit,
                                              Quantitevente,
                                              PrixVente,
                                              PrixTotal,
                                              IdFacture, cout_ttl,
                                              DgvType
                                              );
                    // Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit 
                }
            }
        }
        private void DeleteRowByCodeBarre()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView1.Rows.Clear();
                break; // Exit the loop after removing the row 
            }
        }
        public void delte_qt_matier()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Récupérez les valeurs nécessaires de la ligne actuelle du DataGridView
                    string idProduit = row.Cells["DgvCodeBarre"].Value.ToString();
                    DataTable Dt = new DataTable();
                    Dt = caisseVente_classe.getSold_MAtier_revent(idProduit);
                    if (Dt.Rows.Count > 0)
                    {
                        Object codeBarre = Dt.Rows[0][0];
                        Object name_product = Dt.Rows[0][1];
                        Object price_Vente = Dt.Rows[0][15];
                        Object Quanite_dans_pack = Dt.Rows[0][24];
                        Object price_achat_produit_revent = Dt.Rows[0][12];
                        float quantite_vnt = float.Parse(row.Cells["dgvQt"].Value.ToString()); // Assurez-vous de remplacer "nouvelle_quantite" par le nom réel de la colonne 
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
                            float quantite_vnt = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                                                float.Parse(Qt_dans_pack.ToString());
                            // Appelez la fonction dellte produit apartire du pack
                            classQt_vente.delete_Produit_revent(codeBarre_Produit.ToString(), quantite_vnt);

                        }
                    }

                }
            }
        }
        public void edit_fctr_termeinier()
        {
            pourcentageRemise = "0";
            DateTime currentDateTime = DateTime.Now;
            decimal Sum_cout_ttl = SumColumn(dataGridView1, "cout_ttl");
            classVente.edit_facture(
                        txt_id_fctr.Text,
                        Convert.ToDateTime(dateTimetxt.Value),
                        currentDateTime.TimeOfDay,
                        Convert.ToInt32(clientCmb.SelectedValue),
                        decimal.Parse(lb_Total.Text),
                        decimal.Parse(lb_Total.Text),
                        0,
                        decimal.Parse(lb_historique_credit.Text),
                        decimal.Parse(txt_Versement.Text),
                        decimal.Parse(lb_new_credit.Text),
                        decimal.Parse(lbl_prix_remisier.Text),
                        float.Parse(pourcentageRemise),
                        int.Parse(txtCount.Text),
                        "",
                        "فاتورة مكتملة",
                        id_user,
                        ID_caissier, 
                        Sum_cout_ttl
                        );

            classCaisse.clear_vente_where_edit(txt_id_fctr.Text);
            classCaisse.update_history_caissier(
                   ID_historique,
                   currentDateTime.TimeOfDay,
                   decimal.Parse(lb_Total.Text)
                   );
            historique_Client.insert_history_client(
                        Convert.ToDateTime(dateTimetxt.Value),
                        Convert.ToInt32(clientCmb.SelectedValue),
                        decimal.Parse(lb_Total.Text),
                        decimal.Parse(txt_Versement.Text),
                        decimal.Parse(lb_historique_credit.Text),
                        decimal.Parse(lb_new_credit.Text),
                        "سند جديد",
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
                    string codeBarrePRoduit = row.Cells["DgvCodeBarre"].Value.ToString();
                    float Quantitevente = float.Parse(row.Cells["dgvQt"].Value.ToString());
                    decimal PrixVente = decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
                    decimal PrixTotal = decimal.Parse(row.Cells["dgbTtl"].Value.ToString());
                    decimal cout_ttl = decimal.Parse(row.Cells["cout_ttl"].Value.ToString());
                    string DgvType = row.Cells["DgvType"].Value.ToString();
                    string IdFacture = txt_id_fctr.Text;
                    // Assurez-vous de remplacer "nouvelle_quantite" par le nom réel de la colonne
                    classVente.InsertVente(
                                              codeBarrePRoduit,
                                              Quantitevente,
                                              PrixVente,
                                              PrixTotal,
                                              IdFacture, cout_ttl,
                                              DgvType
                                              );
                    // Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit 
                }
            }
        }

        private void BTN2_Click(object sender, EventArgs e)
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
                if (row.Cells["DgvCodeBarre"].Value != null &&
                    row.Cells["DgvCodeBarre"].Value.ToString() == codeBarre)
                {
                    dataGridView1.Rows.Remove(row);
                    break; // Exit the loop after removing the row
                }
            }
        }

        private void BTN3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هذا الخيار سيقوم بحذف  كل البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dataGridView1.Rows.Count > 0)
                {

                    DeleteRowByCodeBarre();
                    dataGridView1.Refresh();
                    GetTTL();
                    txtCount.Text = getCount().ToString();

                    return;
                }
                else
                {
                    MessageBox.Show("الجدول فارغ");
                }
            }
        }

        private void BTN4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                frm_edit_Qt_facture_for_caisse editFctr = new frm_edit_Qt_facture_for_caisse();
                editFctr.txtBox.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                editFctr.type = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                editFctr.codebarre = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

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
                    barcode = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
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
                editFctr.frmVenteV5 = this;
                editFctr.Type = "V5";
                editFctr.txtBox.Focus();
                editFctr.txtBox.SelectAll();
                editFctr.ShowDialog();
            }
            else
            {
                MessageBox.Show("يرجى تحديد المنتوج");
            }
        }

        private void BTN5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                pourcentageRemise = "0";
                facture_non_terminer();
                DeleteRowByCodeBarre();
                dataGridView1.Refresh();
                GetTTL();
                txtCount.Text = getCount().ToString();
                txt_id_fctr.Text = classVente.get_fctr_vnt();
            }
            else
            {
                MessageBox.Show("الفاتورة فارغة لايمكن ارساله كفاتورة انتظار");
            }
        }

        private void BTN6_Click(object sender, EventArgs e)
        {

            if (Typpped == "edit")
            {

            }
            else
            {
                frm_livraison_vente liv = new frm_livraison_vente();
                if (dataGridView1.Rows.Count > 0)
                {
                    DateTime currentDateTime = DateTime.Now;
                    Facture_terminer();

                    DeleteRowByCodeBarre();
                    dataGridView1.Refresh();
                    GetTTL();
                    txtCount.Text = getCount().ToString();

                    liv.nmr_fctr = txt_id_fctr.Text;
                    liv.id_caisier = ID_caissier;
                    liv.id_user = id_user;
                    txt_id_fctr.Text = classVente.get_fctr_vnt();
                    liv.ShowDialog();
                }
                else
                {
                    MessageBox.Show("لاتوجد منتوجات لبيعها ");
                }
            }

        }
        private void facture_non_terminer()
        {

            decimal Sum_cout_ttl = SumColumn(dataGridView1, "cout_ttl");
            DateTime currentDateTime = DateTime.Now;
            classVente.insertFacture(
                            txt_id_fctr.Text,
                            Convert.ToDateTime(dateTimetxt.Value),
                            currentDateTime.TimeOfDay,
                            Convert.ToInt32(clientCmb.SelectedValue),
                            decimal.Parse(lb_Total.Text),
                            decimal.Parse(lb_Total.Text),
                            0,
                            decimal.Parse(lb_historique_credit.Text),
                            decimal.Parse(txt_Versement.Text),
                            decimal.Parse(lb_new_credit.Text),
                            decimal.Parse(lbl_prix_remisier.Text),
                            float.Parse(pourcentageRemise),
                            int.Parse(txtCount.Text),
                            "",
                            "فاتورة قيد الانتظار",
                            id_user,
                            ID_caissier,
                            Sum_cout_ttl
                            );
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Récupérez les valeurs nécessaires de la ligne actuelle du DataGridView
                    string codeBarrePRoduit = row.Cells["DgvCodeBarre"].Value.ToString();
                    float Quantitevente = float.Parse(row.Cells["dgvQt"].Value.ToString());
                    decimal PrixVente = decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
                    decimal PrixTotal = decimal.Parse(row.Cells["dgbTtl"].Value.ToString());
                    decimal cout_ttl = decimal.Parse(row.Cells["cout_ttl"].Value.ToString());
                    string DgvType = row.Cells["DgvType"].Value.ToString();
                    string IdFacture = txt_id_fctr.Text;
                    // Assurez-vous de remplacer "nouvelle_quantite" par le nom réel de la colonne
                    classVente.InsertVente(
                                              codeBarrePRoduit,
                                              Quantitevente,
                                              PrixVente,
                                              PrixTotal,
                                              IdFacture, 
                                              cout_ttl,
                                              DgvType
                                              );
                    // Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit 
                }
            }
            MessageBox.Show("تم  تسجيل الفاتورة بنجاح");

        }

        private void BTN7_Click(object sender, EventArgs e)
        {
            frm_fctr_en_attende_caisse factr_en_attend = new frm_fctr_en_attende_caisse();
            factr_en_attend.frmVente5 = this;
            factr_en_attend.Type = "V5";
            factr_en_attend.ShowDialog();
        }

        private void BTN8_Click(object sender, EventArgs e)
        {
            PLADD.PL_Statistique.frm_add_depense addDepense = new PLADD.PL_Statistique.frm_add_depense();
            addDepense.iduser = id_user;
            addDepense.ID_historique = ID_historique;
            addDepense.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    string Codebarre = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    string designation = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    string QT = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    string priceU = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    string priceTTl = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();

                    //LB_NAME.Text = designation;
                    //LB_QT.Text = QT;
                    //LB_PRICE_U.Text = priceU;
                    //LB_TTL.Text = priceTTl;
                }

                if (dataGridView1.Columns[e.ColumnIndex].Name == "dgvEdit")
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        frm_edit_Qt_facture_for_caisse editFctr = new frm_edit_Qt_facture_for_caisse();
                        editFctr.txtBox.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                        editFctr.type = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                        editFctr.codebarre = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

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
                            barcode = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
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
                        editFctr.frmVenteV5 = this;
                        editFctr.Type = "V5"; 
                        editFctr.txtBox.Focus();
                        editFctr.txtBox.SelectAll();
                        editFctr.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("يرجى تحديد المنتوج");
                    }
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name == "dgvDellete")
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
                if (dataGridView1.Columns[e.ColumnIndex].Name == "DgvEditPrice")
                {
                    frm_Detaile_Stocke stock_Detaille = new frm_Detaile_Stocke();
                    DataTable DT_acces = new DataTable(); ;
                    DT_acces = classLogine.get_ACCES_USer(id_user);
                    if (DT_acces.Rows.Count > 0)
                    {
                        object stock = DT_acces.Rows[0][19];
                        stock_produit = Convert.ToInt32(stock);

                    }
                    if (stock_produit == 1)
                    {

                        frm_information_change changeInfo = new frm_information_change();
                        DataTable dtProduit = new DataTable();
                        dtProduit = classProduit.get_stock_produit_revenet_for_edit(this.dataGridView1.CurrentRow.Cells["DgvCodeBarre"].Value.ToString());
                        object codeBarre = dtProduit.Rows[0][0];
                        object designation = dtProduit.Rows[0][1];
                        object reference = dtProduit.Rows[0][2];
                        object categories = dtProduit.Rows[0][3];
                        object stock = dtProduit.Rows[0][4];
                        object marque = dtProduit.Rows[0][5];
                        object unite = dtProduit.Rows[0][6]; ;
                        object taille = dtProduit.Rows[0][7];
                        object color = dtProduit.Rows[0][8];
                        object fav = dtProduit.Rows[0][9];
                        object dateExp = dtProduit.Rows[0][10];
                        object Prix1 = dtProduit.Rows[0][15];
                        object Prix2 = dtProduit.Rows[0][16];
                        object Prix3 = dtProduit.Rows[0][17];
                        object prixAchatTTC = dtProduit.Rows[0][12];
                        object prixAchatHT = dtProduit.Rows[0][11];
                        object TVA = dtProduit.Rows[0][13];
                        object QT_alert = dtProduit.Rows[0][25];
                        object QT_ihtiyaj = dtProduit.Rows[0][26];
                        Byte[] image_array = (byte[])dtProduit.Rows[0][24];
                        using (MemoryStream ms = new MemoryStream(image_array))
                        {
                            changeInfo.pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                        }
                        changeInfo.txtBarcode.Text = codeBarre.ToString();
                        changeInfo.txt_designation.Text = designation.ToString();
                        changeInfo.txt_reference.Text = reference.ToString();
                        changeInfo.cmb_categories.Text = categories.ToString();
                        changeInfo.cmb_stocke.Text = stock.ToString();
                        changeInfo.cmb_marque.Text = marque.ToString();
                        changeInfo.cmb_unite.Text = unite.ToString();
                        changeInfo.cmb_taille.Text = taille.ToString();
                        changeInfo.cmb_color.Text = color.ToString();
                        if (fav.ToString() != "")
                        {
                            changeInfo.cmb_favoire.Enabled = true;
                            changeInfo.cmb_favoire.Text = fav.ToString();
                        }
                        else
                        {
                            changeInfo.cmb_favoire.Enabled = false;
                        }
                        changeInfo.date_expiration.Text = dateExp.ToString();
                        changeInfo.txt_vente_1.Text = Prix1.ToString();
                        changeInfo.txt_vente_2.Text = Prix2.ToString();
                        changeInfo.txt_vente_min.Text = Prix3.ToString();

                        changeInfo.txt_achat_ht.Text = prixAchatHT.ToString();
                        changeInfo.txt_achat_ttc.Text = prixAchatTTC.ToString();
                        changeInfo.txt_tva.Text = TVA.ToString();
                        changeInfo.TXTqT_ALERT.Text = QT_alert.ToString();
                        changeInfo.txtihtiyadj.Text = QT_ihtiyaj.ToString();
                        changeInfo.formCaisseV5 = this; 
                        changeInfo.type = "B";
                        changeInfo.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
                    }
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name == "DgvPack")
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    DataTable Dt = new DataTable();
                    Dt = caisseVente_classe.getSold_MAtier_revent(selectedRow.Cells["DgvCodeBarre"].Value.ToString());
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
                                var cellValue = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                                //------------------------------------------------------------------------------//
                                if (Quanite_dans_pack.ToString() != "")
                                {
                                    dataGridView1.Rows.Remove(row);
                                    DataTable DtPack = caisseVente_classe.select_pack_revent_by_code_barre_produit(selectedRow.Cells[1].Value.ToString());
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
                                            var cellValued = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

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

                                    return;

                                }
                                GetTTL();
                                txtCount.Text = getCount().ToString();
                                return;

                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void UpdateLabels()
        {
            if (dataGridView1.CurrentRow != null)
            {
                string Codebarre = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string designation = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string QT = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string priceU = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                string priceTTl = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();

                //LB_NAME.Text = designation;
                //LB_QT.Text = QT;
                //LB_PRICE_U.Text = priceU;
                //LB_TTL.Text = priceTTl;
            }
        }

        private void LB_QT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                frm_edit_Qt_facture_for_caisse editFctr = new frm_edit_Qt_facture_for_caisse();
                editFctr.txtBox.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                editFctr.type = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                editFctr.codebarre = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

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
                    barcode = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
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
                editFctr.frmVenteV5 = this;
                editFctr.Type = "V5";
                editFctr.ShowDialog();
            }
            else
            {
                MessageBox.Show("يرجى تحديد المنتوج");
            }
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            frm_routour_ routeur_Article = new frm_routour_();
            routeur_Article.id_usser = id_user;
            routeur_Article.ID_CAISSIER = ID_caissier;
            routeur_Article.ID_historique = ID_historique;
            routeur_Article.ShowDialog();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if a row is selected and the key pressed is '+'
            if (dataGridView1.SelectedRows.Count > 0 && e.KeyCode == Keys.Oemplus)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Assuming 'dgvQt' is the name of the column
                if (selectedRow.Cells["dgvQt"].Value != null && int.TryParse(selectedRow.Cells["dgvQt"].Value.ToString(), out int cellValue))
                {
                    DataTable Dt = caisseVente_classe.getSold_MAtier_revent(selectedRow.Cells["DgvCodeBarre"].Value.ToString());
                    if (Dt.Rows.Count > 0)
                    {
                        Object codeBarre = Dt.Rows[0][0];
                        Object name_product = Dt.Rows[0][1];
                        Object price_Vente = Dt.Rows[0][15];
                        Object Quanite_dans_pack = Dt.Rows[0][24];
                        Object price_achat_produit_revent = Dt.Rows[0][12];
                        selectedRow.Cells["dgvQt"].Value = cellValue + 1;
                        selectedRow.Cells["dgbTtl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                                                        float.Parse(selectedRow.Cells["dgvAmount"].Value.ToString());
                        selectedRow.Cells["cout_ttl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                            float.Parse(price_achat_produit_revent.ToString());

                    }
                    else
                    {
                        Dt = caisseVente_classe.select_pack_info(selectedRow.Cells["DgvCodeBarre"].Value.ToString());
                        if (Dt.Rows.Count > 0)
                        {

                            Object codeBarre = Dt.Rows[0][0];
                            Object name_product = Dt.Rows[0][1];
                            Object price_Vente = Dt.Rows[0][4];
                            Object price_Achat = Dt.Rows[0][7];
                            Object Qt_dans_pack = Dt.Rows[0][8];
                            decimal cout_produire_pack_favrique = decimal.Parse(price_Achat.ToString()) * decimal.Parse(Qt_dans_pack.ToString());
                            selectedRow.Cells["dgvQt"].Value = cellValue + 1;
                            selectedRow.Cells["dgbTtl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                                                                float.Parse(selectedRow.Cells["dgvAmount"].Value.ToString());
                            selectedRow.Cells["cout_ttl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                                                                float.Parse(cout_produire_pack_favrique.ToString());
                            GetTTL();
                            txtCount.Text = getCount().ToString();

                            return;

                        }
                    }
                    // Increment the value in 'dgvQt' column

                }
            }
            if (dataGridView1.SelectedRows.Count > 0 && e.KeyCode == Keys.Add)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Assuming 'dgvQt' is the name of the column
                if (selectedRow.Cells["dgvQt"].Value != null && int.TryParse(selectedRow.Cells["dgvQt"].Value.ToString(), out int cellValue))
                {
                    DataTable Dt = caisseVente_classe.getSold_MAtier_revent(selectedRow.Cells["DgvCodeBarre"].Value.ToString());
                    if (Dt.Rows.Count > 0)
                    {
                        Object codeBarre = Dt.Rows[0][0];
                        Object name_product = Dt.Rows[0][1];
                        Object price_Vente = Dt.Rows[0][15];
                        Object Quanite_dans_pack = Dt.Rows[0][24];
                        Object price_achat_produit_revent = Dt.Rows[0][12];
                        selectedRow.Cells["dgvQt"].Value = cellValue + 1;
                        selectedRow.Cells["dgbTtl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                                                        float.Parse(selectedRow.Cells["dgvAmount"].Value.ToString());
                        selectedRow.Cells["cout_ttl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                            float.Parse(price_achat_produit_revent.ToString());

                    }
                    else
                    {
                        Dt = caisseVente_classe.select_pack_info(selectedRow.Cells["DgvCodeBarre"].Value.ToString());
                        if (Dt.Rows.Count > 0)
                        {

                            Object codeBarre = Dt.Rows[0][0];
                            Object name_product = Dt.Rows[0][1];
                            Object price_Vente = Dt.Rows[0][4];
                            Object price_Achat = Dt.Rows[0][7];
                            Object Qt_dans_pack = Dt.Rows[0][8];
                            decimal cout_produire_pack_favrique = decimal.Parse(price_Achat.ToString()) * decimal.Parse(Qt_dans_pack.ToString());
                            selectedRow.Cells["dgvQt"].Value = cellValue + 1;
                            selectedRow.Cells["dgbTtl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                                                                float.Parse(selectedRow.Cells["dgvAmount"].Value.ToString());
                            selectedRow.Cells["cout_ttl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                                                                float.Parse(cout_produire_pack_favrique.ToString());
                            GetTTL();
                            txtCount.Text = getCount().ToString();

                            return;

                        }
                    }
                    // Increment the value in 'dgvQt' column

                }
            }
            //Check if a row is selected and the key pressed is '-'
            if (dataGridView1.SelectedRows.Count > 0 && e.KeyCode == Keys.OemMinus)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Assuming 'dgvQt' is the name of the column
                if (selectedRow.Cells["dgvQt"].Value != null && int.TryParse(selectedRow.Cells["dgvQt"].Value.ToString(), out int cellValue))
                {
                    DataTable Dt = caisseVente_classe.getSold_MAtier_revent(selectedRow.Cells["DgvCodeBarre"].Value.ToString());
                    if (Dt.Rows.Count > 0)
                    {
                        Object codeBarre = Dt.Rows[0][0];
                        Object name_product = Dt.Rows[0][1];
                        Object price_Vente = Dt.Rows[0][15];
                        Object Quanite_dans_pack = Dt.Rows[0][24];
                        Object price_achat_produit_revent = Dt.Rows[0][12];
                        selectedRow.Cells["dgvQt"].Value = cellValue - 1;
                        selectedRow.Cells["dgbTtl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                                                        float.Parse(selectedRow.Cells["dgvAmount"].Value.ToString());
                        selectedRow.Cells["cout_ttl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                            float.Parse(price_achat_produit_revent.ToString());

                    }
                    // Increment the value in 'dgvQt' column
                    else
                    {
                        Dt = caisseVente_classe.select_pack_info(selectedRow.Cells["DgvCodeBarre"].Value.ToString());
                        if (Dt.Rows.Count > 0)
                        {

                            Object codeBarre = Dt.Rows[0][0];
                            Object name_product = Dt.Rows[0][1];
                            Object price_Vente = Dt.Rows[0][4];
                            Object price_Achat = Dt.Rows[0][7];
                            Object Qt_dans_pack = Dt.Rows[0][8];
                            decimal cout_produire_pack_favrique = decimal.Parse(price_Achat.ToString()) * decimal.Parse(Qt_dans_pack.ToString());
                            selectedRow.Cells["dgvQt"].Value = cellValue - 1;
                            selectedRow.Cells["dgbTtl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                                                                float.Parse(selectedRow.Cells["dgvAmount"].Value.ToString());
                            selectedRow.Cells["cout_ttl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                                                                float.Parse(cout_produire_pack_favrique.ToString());
                            GetTTL();
                            txtCount.Text = getCount().ToString();

                            return;

                        }
                    }

                }
            }
            if (dataGridView1.SelectedRows.Count > 0 && e.KeyCode == Keys.Subtract)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Assuming 'dgvQt' is the name of the column
                if (selectedRow.Cells["dgvQt"].Value != null && float.TryParse(selectedRow.Cells["dgvQt"].Value.ToString(), out float cellValue))
                {
                    DataTable Dt = caisseVente_classe.getSold_MAtier_revent(selectedRow.Cells["DgvCodeBarre"].Value.ToString());
                    if (Dt.Rows.Count > 0)
                    {
                        Object codeBarre = Dt.Rows[0][0];
                        Object name_product = Dt.Rows[0][1];
                        Object price_Vente = Dt.Rows[0][15];
                        Object Quanite_dans_pack = Dt.Rows[0][24];
                        Object price_achat_produit_revent = Dt.Rows[0][12];
                        selectedRow.Cells["dgvQt"].Value = cellValue - 1;
                        selectedRow.Cells["dgbTtl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                                                        float.Parse(selectedRow.Cells["dgvAmount"].Value.ToString());
                        selectedRow.Cells["cout_ttl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                                                        float.Parse(price_achat_produit_revent.ToString());

                    }
                    // Increment the value in 'dgvQt' column
                    else
                    {
                        Dt = caisseVente_classe.select_pack_info(selectedRow.Cells["DgvCodeBarre"].Value.ToString());
                        if (Dt.Rows.Count > 0)
                        {

                            Object codeBarre = Dt.Rows[0][0];
                            Object name_product = Dt.Rows[0][1];
                            Object price_Vente = Dt.Rows[0][4];
                            Object price_Achat = Dt.Rows[0][7];
                            Object Qt_dans_pack = Dt.Rows[0][8];
                            decimal cout_produire_pack_favrique = decimal.Parse(price_Achat.ToString()) * decimal.Parse(Qt_dans_pack.ToString());
                            selectedRow.Cells["dgvQt"].Value = cellValue - 1;
                            selectedRow.Cells["dgbTtl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                                                                float.Parse(selectedRow.Cells["dgvAmount"].Value.ToString());
                            selectedRow.Cells["cout_ttl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                                                                float.Parse(cout_produire_pack_favrique.ToString());
                            GetTTL();
                            txtCount.Text = getCount().ToString();

                            return;

                        }
                    }
                }
            }
            // Check if a row is selected and the key pressed is '*'
            if (dataGridView1.SelectedRows.Count > 0 && e.KeyCode == Keys.Multiply)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                DataTable Dt = new DataTable();
                Dt = caisseVente_classe.getSold_MAtier_revent(selectedRow.Cells["DgvCodeBarre"].Value.ToString());
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
                            var cellValue = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                            //------------------------------------------------------------------------------//
                            if (Quanite_dans_pack.ToString() != "")
                            {
                                dataGridView1.Rows.Remove(row);
                                DataTable DtPack = caisseVente_classe.select_pack_revent_by_code_barre_produit(selectedRow.Cells[1].Value.ToString());
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
                                        var cellValued = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

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

                                return;

                            }
                            GetTTL();
                            txtCount.Text = getCount().ToString();
                            return;

                        }
                    }
                }
            }
            GetTTL();
            txtCount.Text = getCount().ToString();
        }

        private void Frm_vente_caissev5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    if (Typpped == "edit")
                    {
                        DateTime currentDateTime = DateTime.Now;


                        edit_fctr_termeinier();
                        DeleteRowByCodeBarre();
                        dataGridView1.Refresh();
                        GetTTL();
                        txtCount.Text = getCount().ToString();
                        txt_id_fctr.Text = classVente.get_fctr_vnt();

                        Typpped = "add";
                    }
                    else
                    {
                        DateTime currentDateTime = DateTime.Now;


                        Facture_terminer();
                        DeleteRowByCodeBarre();
                        dataGridView1.Refresh();
                        GetTTL();
                        txtCount.Text = getCount().ToString();
                        txt_id_fctr.Text = classVente.get_fctr_vnt();
                        Typpped = "add";
                    }

                }
                else
                {
                    MessageBox.Show("لاتوجد منتوجات لبيعها ");
                }

            }
            if (e.KeyCode == Keys.F2)
            {
                if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            }
            if (e.KeyCode == Keys.F3)
            {
                if (MessageBox.Show("هذا الخيار سيقوم بحذف  كل البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dataGridView1.Rows.Count > 0)
                    {

                        DeleteRowByCodeBarre();
                        dataGridView1.Refresh();
                        GetTTL();
                        txtCount.Text = getCount().ToString();

                        return;
                    }
                    else
                    {
                        MessageBox.Show("الجدول فارغ");
                    }
                }
            }
            if (e.KeyCode == Keys.F4)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    frm_edit_Qt_facture_for_caisse editFctr = new frm_edit_Qt_facture_for_caisse();
                    editFctr.txtBox.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    editFctr.frmVenteV5 = this;
                    editFctr.Type = "V5";
                    editFctr.codebarre = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    editFctr.ShowDialog();
                }
                else
                {
                    MessageBox.Show("يرجى تحديد المنتوج");
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                facture_non_terminer();
                DeleteRowByCodeBarre();
                dataGridView1.Refresh();
                GetTTL();
                txtCount.Text = getCount().ToString();
            }
            if (e.KeyCode == Keys.F6)
            {
                frm_fctr_en_attende_caisse factr_en_attend = new frm_fctr_en_attende_caisse();
                factr_en_attend.frmVente5 = this;
                factr_en_attend.Type = "V5";
                factr_en_attend.ShowDialog();
            }
            if (e.KeyCode == Keys.F7)
            {
                if (Typpped == "edit")
                {

                }
                else
                {
                    frm_livraison_vente liv = new frm_livraison_vente();
                    if (dataGridView1.Rows.Count > 0)
                    {
                        DateTime currentDateTime = DateTime.Now;
                        Facture_terminer();

                        DeleteRowByCodeBarre();
                        dataGridView1.Refresh();
                        GetTTL();
                        txtCount.Text = getCount().ToString();

                        liv.nmr_fctr = txt_id_fctr.Text;
                        liv.id_caisier = ID_caissier;
                        liv.id_user = id_user;
                        txt_id_fctr.Text = classVente.get_fctr_vnt();
                        liv.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("لاتوجد منتوجات لبيعها ");
                    }
                }

            }
            if (e.KeyCode == Keys.F8)
            {
                PLADD.PL_Statistique.frm_add_depense addDepense = new PLADD.PL_Statistique.frm_add_depense();
                addDepense.iduser = id_user;
                addDepense.ID_historique = ID_historique;
                addDepense.ShowDialog();
            }
            if (e.KeyCode == Keys.F10)
            {
                PL.Achat_revente.Frm_Achat frmachat = new PL.Achat_revente.Frm_Achat();

                DataTable DT_acces = new DataTable(); ;
                DT_acces = classLogine.get_ACCES_USer(id_user);
                if (DT_acces.Rows.Count > 0)
                {
                    object stock = DT_acces.Rows[0][15];
                    achat = Convert.ToInt32(stock);

                }
                if (achat == 1)
                {
                    frmachat.id_user = id_user;
                    frmachat.Show();
                    //Form1.getMainForm.pn_container.Controls.Clear();
                    //Form1.getMainForm.pn_container.Controls.Add(frmachat.pn_achats); 
                }
                else
                {
                    MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
                }
            }
            if (e.Control && e.KeyCode == Keys.F)
            {
                frm_Detaile_Stocke stock_Detaille = new frm_Detaile_Stocke();
                stock_Detaille.VenteCaisseV5 = this;
                stock_Detaille.Type = "V5";
                stock_Detaille.ShowDialog();
            }
            if (e.KeyCode == Keys.F9)
            {
                frm_edit_by_price frm_Edit_By_Price = new frm_edit_by_price();
                if (dataGridView1.Rows.Count > 0)
                {
                    frm_Edit_By_Price.txtPriceU.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    frm_Edit_By_Price.type = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    frm_Edit_By_Price.codebarre = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

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
                            frm_Edit_By_Price.qt_danspack = Qt_dans_pack.ToString();
                            frm_Edit_By_Price.price_achat_u = price_Achat.ToString();
                        }
                    }
                    else
                    {
                        barcode = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        DataTable Dtt = new DataTable();
                        Dtt = caisseVente_classe.getSold_MAtier_revent(barcode);
                        if (Dtt.Rows.Count > 0)
                        {
                            Object codeBarre = Dtt.Rows[0][0];
                            Object name_product = Dtt.Rows[0][1];
                            Object price_Vente = Dtt.Rows[0][15];
                            Object Quanite_dans_pack = Dtt.Rows[0][24];
                            Object price_achat_produit_revent = Dtt.Rows[0][12];
                            frm_Edit_By_Price.qt_danspack = "1";
                            frm_Edit_By_Price.price_achat_u = price_achat_produit_revent.ToString();
                        }

                    }
                    frm_Edit_By_Price.frmVenteV5 = this;
                    frm_Edit_By_Price.Type = "V5";
                    frm_Edit_By_Price.ShowDialog();
                }
                else
                {
                    MessageBox.Show("يرجى تحديد المنتوج");
                }
            }
            if (e.Control && e.KeyCode == Keys.R)
            {
                flowLAyoutProduct.Controls.Clear();
                loadProduct(1);
                loadPack(1);
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("هذا الخيار سيقوم بغلق النافذة", "غلق الواجهة  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '&') e.KeyChar = '1';
            else if (e.KeyChar == 'é') e.KeyChar = '2';
            else if (e.KeyChar == '"') e.KeyChar = '3';
            else if (e.KeyChar == '\'') e.KeyChar = '4';
            else if (e.KeyChar == '(') e.KeyChar = '5';
            else if (e.KeyChar == '§') e.KeyChar = '6';
            else if (e.KeyChar == 'è') e.KeyChar = '7';
            else if (e.KeyChar == '!') e.KeyChar = '8';
            else if (e.KeyChar == 'ç') e.KeyChar = '9';
            else if (e.KeyChar == 'à') e.KeyChar = '0';

            if (e.KeyChar == (char)Keys.Enter)
            {
                getinformation_matier_revent();
                txt_barcode.Text = ""; // Clear the textbox after the function call
                e.Handled = true; // Optionally, to prevent the beep sound
            }
        }

        private void chek_prix1_CheckedChanged(object sender, EventArgs e)
        {
            loadProduct(1);
            loadFav();
            flowLAyoutProduct.Controls.Clear();
            loadProduct(1);
            txt_barcode.Focus();
        }

        private void check_prix2_CheckedChanged(object sender, EventArgs e)
        {
            loadProduct(1);
            loadFav();
            flowLAyoutProduct.Controls.Clear();
            loadProduct(1);
            txt_barcode.Focus();
        }

        private void check_prix3_CheckedChanged(object sender, EventArgs e)
        {
            loadProduct(1);
            loadFav();
            flowLAyoutProduct.Controls.Clear();
            loadProduct(1);
            loadPack(1);

            txt_barcode.Focus();
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            frm_edit_by_price frm_Edit_By_Price = new frm_edit_by_price();
            if (dataGridView1.Rows.Count > 0)
            {
                frm_Edit_By_Price.txtPriceU.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                frm_Edit_By_Price.type = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                frm_Edit_By_Price.codebarre = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

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
                        frm_Edit_By_Price.qt_danspack = Qt_dans_pack.ToString();
                        frm_Edit_By_Price.price_achat_u = price_Achat.ToString();
                    }
                }
                else
                {
                    barcode = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    DataTable Dtt = new DataTable();
                    Dtt = caisseVente_classe.getSold_MAtier_revent(barcode);
                    if (Dtt.Rows.Count > 0)
                    {
                        Object codeBarre = Dtt.Rows[0][0];
                        Object name_product = Dtt.Rows[0][1];
                        Object price_Vente = Dtt.Rows[0][15];
                        Object Quanite_dans_pack = Dtt.Rows[0][24];
                        Object price_achat_produit_revent = Dtt.Rows[0][12];
                        frm_Edit_By_Price.qt_danspack = "1";
                        frm_Edit_By_Price.price_achat_u = price_achat_produit_revent.ToString();
                    }

                }
                frm_Edit_By_Price.frmVenteV5 = this;
                frm_Edit_By_Price.Type = "V5";
                frm_Edit_By_Price.ShowDialog();
            }
            else
            {
                MessageBox.Show("يرجى تحديد المنتوج");
            }
        }

        private void notify_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //LB_Date.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Assuming 'dgvQt' is the name of the column
                if (selectedRow.Cells["dgvQt"].Value != null && int.TryParse(selectedRow.Cells["dgvQt"].Value.ToString(), out int cellValue))
                {
                    DataTable Dt = caisseVente_classe.getSold_MAtier_revent(selectedRow.Cells["DgvCodeBarre"].Value.ToString());
                    if (Dt.Rows.Count > 0)
                    {
                        Object codeBarre = Dt.Rows[0][0];
                        Object name_product = Dt.Rows[0][1];
                        Object price_Vente = Dt.Rows[0][15];
                        Object Quanite_dans_pack = Dt.Rows[0][24];
                        Object price_achat_produit_revent = Dt.Rows[0][12];
                        selectedRow.Cells["dgvQt"].Value = cellValue + 1;
                        selectedRow.Cells["dgbTtl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                                                        float.Parse(selectedRow.Cells["dgvAmount"].Value.ToString());
                        selectedRow.Cells["cout_ttl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                            float.Parse(price_achat_produit_revent.ToString());

                    }
                    else
                    {
                        Dt = caisseVente_classe.select_pack_info(selectedRow.Cells["DgvCodeBarre"].Value.ToString());
                        if (Dt.Rows.Count > 0)
                        {

                            Object codeBarre = Dt.Rows[0][0];
                            Object name_product = Dt.Rows[0][1];
                            Object price_Vente = Dt.Rows[0][4];
                            Object price_Achat = Dt.Rows[0][7];
                            Object Qt_dans_pack = Dt.Rows[0][8];
                            decimal cout_produire_pack_favrique = decimal.Parse(price_Achat.ToString()) * decimal.Parse(Qt_dans_pack.ToString());
                            selectedRow.Cells["dgvQt"].Value = cellValue + 1;
                            selectedRow.Cells["dgbTtl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                                                                float.Parse(selectedRow.Cells["dgvAmount"].Value.ToString());
                            selectedRow.Cells["cout_ttl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                                                                float.Parse(cout_produire_pack_favrique.ToString());
                            GetTTL();
                            txtCount.Text = getCount().ToString();

                            return;

                        }
                    }
                    // Increment the value in 'dgvQt' column

                }
                GetTTL();
                txtCount.Text = getCount().ToString();
                return;
            }
            catch
            {

            }
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Assuming 'dgvQt' is the name of the column
                if (selectedRow.Cells["dgvQt"].Value != null && int.TryParse(selectedRow.Cells["dgvQt"].Value.ToString(), out int cellValue))
                {
                    DataTable Dt = caisseVente_classe.getSold_MAtier_revent(selectedRow.Cells["DgvCodeBarre"].Value.ToString());
                    if (Dt.Rows.Count > 0)
                    {
                        Object codeBarre = Dt.Rows[0][0];
                        Object name_product = Dt.Rows[0][1];
                        Object price_Vente = Dt.Rows[0][15];
                        Object Quanite_dans_pack = Dt.Rows[0][24];
                        Object price_achat_produit_revent = Dt.Rows[0][12];
                        selectedRow.Cells["dgvQt"].Value = cellValue - 1;
                        selectedRow.Cells["dgbTtl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                                                        float.Parse(selectedRow.Cells["dgvAmount"].Value.ToString());
                        selectedRow.Cells["cout_ttl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                            float.Parse(price_achat_produit_revent.ToString());

                    }
                    // Increment the value in 'dgvQt' column
                    else
                    {
                        Dt = caisseVente_classe.select_pack_info(selectedRow.Cells["DgvCodeBarre"].Value.ToString());
                        if (Dt.Rows.Count > 0)
                        {

                            Object codeBarre = Dt.Rows[0][0];
                            Object name_product = Dt.Rows[0][1];
                            Object price_Vente = Dt.Rows[0][4];
                            Object price_Achat = Dt.Rows[0][7];
                            Object Qt_dans_pack = Dt.Rows[0][8];
                            decimal cout_produire_pack_favrique = decimal.Parse(price_Achat.ToString()) * decimal.Parse(Qt_dans_pack.ToString());
                            selectedRow.Cells["dgvQt"].Value = cellValue - 1;
                            selectedRow.Cells["dgbTtl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                                                                float.Parse(selectedRow.Cells["dgvAmount"].Value.ToString());
                            selectedRow.Cells["cout_ttl"].Value = float.Parse(selectedRow.Cells["dgvQt"].Value.ToString()) *
                                                                float.Parse(cout_produire_pack_favrique.ToString());
                            GetTTL();
                            txtCount.Text = getCount().ToString();

                            return;

                        }
                    }

                }
                GetTTL();
                txtCount.Text = getCount().ToString();
                return;
            }
            catch
            {

            }
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                DataTable Dt = new DataTable();
                Dt = caisseVente_classe.getSold_MAtier_revent(selectedRow.Cells["DgvCodeBarre"].Value.ToString());
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
                            var cellValue = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                            //------------------------------------------------------------------------------//
                            if (Quanite_dans_pack.ToString() != "")
                            {
                                dataGridView1.Rows.Remove(row);
                                DataTable DtPack = caisseVente_classe.select_pack_revent_by_code_barre_produit(selectedRow.Cells[1].Value.ToString());
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
                                        var cellValued = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();

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

                                return;

                            }
                            GetTTL();
                            txtCount.Text = getCount().ToString();
                            return;

                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            frm_Detaile_Stocke stock_Detaille = new frm_Detaile_Stocke();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][19];
                stock_produit = Convert.ToInt32(stock);

            }
            if (stock_produit == 1)
            {
                stock_Detaille.VenteCaisseV5 = this;
                stock_Detaille.Type = "V5";
                stock_Detaille.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void txt_qt_TextChanged(object sender, EventArgs e)
        {
            if (txt_qt.Text == "")
            {
                txt_qt.Text = "0";
            }
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            flowLAyoutProduct.Controls.Clear();
            loadProduct(1);
            loadPack(1);
        }

        private void lb_Total_TextChanged(object sender, EventArgs e)
        {
            double ttl = double.Parse(lb_Total.Text);
            double roundedValue;

            if (ttl < 2.5)
            {
                roundedValue = 0;
            }
            else if (ttl < 5)
            {
                roundedValue = 5;
            }
            else if (ttl < 7.5)
            {
                roundedValue = 5;
            }
            else if (ttl < 10)
            {
                roundedValue = 10;
            }
            else
            {
                roundedValue = ttl; // إذا كانت القيمة أكبر من 10، تُترك كما هي
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frm_add_client addClient = new frm_add_client(); 
            addClient.Type = "B";
            addClient.vente_Caissev5 = this;
            addClient.ShowDialog();
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            PL.Achat_revente.Frm_Achat frmachat = new PL.Achat_revente.Frm_Achat();

            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][15];
                achat = Convert.ToInt32(stock);

            }
            if (achat == 1)
            {
                frmachat.id_user = id_user;
                frmachat.Show();
                //Form1.getMainForm.pn_container.Controls.Clear();
                //Form1.getMainForm.pn_container.Controls.Add(frmachat.pn_achats); 
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            PL.vente.frm_list_vente_credit_client list_credit = new PL.vente.frm_list_vente_credit_client();
            list_credit.Text = "تفاصيل الشراء للزبون " + " ( " + clientCmb.Text + " )";
            list_credit.dataGridView1.DataSource = classvente.get_list_vente_credit_client("فاتورة مكتملة", Convert.ToInt32(clientCmb.SelectedValue));
            list_credit.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PLADD.vente.frm_historique_client add_historique_client = new PLADD.vente.frm_historique_client();
            add_historique_client.Type = "B";
            add_historique_client.cmb_frnsre.Text = this.clientCmb.Text;
            add_historique_client.caisse5 = this;
            add_historique_client.ShowDialog();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // تأكد أن الخلية ليست فارغة لتفادي الأخطاء
                if (row.Cells["dgvAmount"] != null)
                {
                    row.Cells["dgvAmount"].Style.BackColor = Color.Yellow;
                }

                if (row.Cells["dgbTtl"] != null)
                {
                    row.Cells["dgbTtl"].Style.BackColor = Color.Red;
                }
            }
        }

        private void Frm_vente_caissev5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                barcoder += e.KeyChar; // إضافة المدخل إلى متغير الباركود
            }

            // عند الضغط على Enter
            if (e.KeyChar == (char)Keys.Enter && barcoder.Length > 0)
            {
                txt_barcode.Text = barcoder; // إدخال الباركود في الـ TextBox
                barcoder = ""; // تفريغ المتغير بعد الإدخال
                e.Handled = true; // منع الإجراءات الافتراضية الأخرى
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                getinformation_matier_revent();
                txt_barcode.Text = ""; // تفريغ الحقل بعد معالجة الكود
                e.Handled = true; // إيقاف الصوت
            }
        }

        private void txt_barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '&') e.KeyChar = '1';
            else if (e.KeyChar == 'é') e.KeyChar = '2';
            else if (e.KeyChar == '"') e.KeyChar = '3';
            else if (e.KeyChar == '\'') e.KeyChar = '4';
            else if (e.KeyChar == '(') e.KeyChar = '5';
            else if (e.KeyChar == '§') e.KeyChar = '6';
            else if (e.KeyChar == 'è') e.KeyChar = '7';
            else if (e.KeyChar == '!') e.KeyChar = '8';
            else if (e.KeyChar == 'ç') e.KeyChar = '9';
            else if (e.KeyChar == 'à') e.KeyChar = '0';

            if (e.KeyChar == (char)Keys.Enter)
            {
                getinformation_matier_revent();
                txt_barcode.Text = ""; // Clear the textbox after the function call
                e.Handled = true; // Optionally, to prevent the beep sound
            }
        }
    }
}
