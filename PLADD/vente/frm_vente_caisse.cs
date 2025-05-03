using ComponentFactory.Krypton.Toolkit;
using Smart_Production_Pos.BL;
using Smart_Production_Pos.BL.BL_FICHIER;
using Smart_Production_Pos.PL.Achat_revente;
using Smart_Production_Pos.PL.vente;
using Smart_Production_Pos.PLADD.Achat_revente;
using Smart_Production_Pos.PLADD.Fichier;
using Smart_Production_Pos.report;
using Smart_Production_Pos.TAB_CONTROL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Smart_Production_Pos.PLADD.vente
{
    public partial class frm_vente_caisse : Form
    {
        BL.BL_vente.Bl_fctr_vente factureManager = new BL.BL_vente.Bl_fctr_vente();
        BL.BL_vente.BL_vente_Fonction classFacteure = new BL.BL_vente.BL_vente_Fonction();
        private bool isNewBarcodeEntry = true;
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
        string barcodee;
        BL.BL_vente.BL_vente_Fonction class_facturation = new BL.BL_vente.BL_vente_Fonction();
        BL.BL_CAISSE caisseVente_classe = new BL.BL_CAISSE();
        BL.BL_PRODUCTION.BL_GESTION_PRODUIT_FINAUX ClassProduction = new BL.BL_PRODUCTION.BL_GESTION_PRODUIT_FINAUX();
        BL.BL_ACHAT_REVENT.BL_PRODUIT classProduit = new BL.BL_ACHAT_REVENT.BL_PRODUIT();
        BL.BL_vente.BL_vente_Fonction classVente = new BL.BL_vente.BL_vente_Fonction();
        BL.Client_history_sold historique_Client = new BL.Client_history_sold();
        BL.BL_vente.BL_SP_LOGINE_Caisse classCaisse = new BL.BL_vente.BL_SP_LOGINE_Caisse();
        BL.BL_vente.bl_diminuer_la_Qt_vente classQt_vente = new BL.BL_vente.bl_diminuer_la_Qt_vente();
        BL.BL_parametre.BL_paramtre_informatiion class_setting = new BL.BL_parametre.BL_paramtre_informatiion();
        BL.BL_Vente_Caisse classFnctionCaisse = new BL_Vente_Caisse();
        public string Typpped;
        public int type;
        public int ID_historique;
        public decimal Prix_Cloture;
        public int ID_caissier;
        decimal Price_achat;
        string txt_new_montant;
        string Typpe;
        int facture_vente;
        int list_vente;
        public string pourcentageRemise;
        Object price_Vente;
        Sp_Logine classLogine = new Sp_Logine();
        // //////////////// 
        DataTable table = new DataTable();
        int rowIndex;
        List<string> listeFactures = new List<string>();
        int currentIndex = 0;
        BL.BL_vente.BL_class_vente classvente = new BL.BL_vente.BL_class_vente();
        public frm_vente_caisse()
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
            caiss_Color();

        }

        private void caiss_Color()
        {
            if (Properties.Settings.Default.Color_Caiss == 1)
            {
                panel2.BackColor = Color.DimGray;
                flowLayoutPanel2.BackColor = Color.DimGray;
                panel18.BackColor = Color.DimGray;
                panel19.BackColor = Color.DimGray;
                flowLayoutPanel4.BackColor = Color.DimGray;
                flowLAyoutProduct.BackColor = Color.DimGray;
                flowCategories.BackColor = Color.DimGray;
                dataGridView1.BackgroundColor = Color.DimGray;

                label7.ForeColor = Color.White;
                label6.ForeColor = Color.White;
                label8.ForeColor = Color.White;
                chek_prix1.StateCommon.ShortText.Color1 = Color.White;
                check_prix2.StateCommon.ShortText.Color1 = Color.White;
                check_prix3.StateCommon.ShortText.Color1 = Color.White;
                label9.ForeColor = Color.White;
                LB_Date.ForeColor = Color.White;
                LB_heures.ForeColor = Color.White;
            }
            else if (Properties.Settings.Default.Color_Caiss == 2)
            {
                panel2.BackColor = Color.White;
                flowLayoutPanel2.BackColor = Color.White;
                panel18.BackColor = Color.White;
                panel19.BackColor = Color.White;
                flowLayoutPanel4.BackColor = Color.White;
                flowLAyoutProduct.BackColor = Color.White;
                flowCategories.BackColor = Color.White;
                dataGridView1.BackgroundColor = Color.White;

                label7.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
                label8.ForeColor = Color.Black;
                chek_prix1.StateCommon.ShortText.Color1 = Color.Black;
                check_prix2.StateCommon.ShortText.Color1 = Color.Black;
                check_prix3.StateCommon.ShortText.Color1 = Color.Black;
                label9.ForeColor = Color.Black;
                LB_Date.ForeColor = Color.Black;
                LB_heures.ForeColor = Color.Black;

            }
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Load_facture_en_attend()
        {
            string Qry = @"SELECT [NMR_FACTURE] 
				,[DATE] 
				,[HEURE]
				,TB_CLIENT.NAME +' '+TB_CLIENT.PRENAME 
                ,[TB_FACTURE_VENTE].ID_CLIENT as 'Clientt'
				,[TOTAL_FACURE_TTC]
				,[TOTAL_FACTURE_HT]
				,[TVA]
				,[TB_FACTURE_VENTE].ETAT
				 FROM [dbo].[TB_FACTURE_VENTE]
				 inner join TB_CLIENT on TB_CLIENT.id = TB_FACTURE_VENTE.ID_CLIENT
				 inner join TB_INFO_CAISSIER on TB_INFO_CAISSIER.id = TB_FACTURE_VENTE.ID_CAISSIER
				 inner join TB_USER on TB_USER.id = TB_FACTURE_VENTE.ID_USER
				 inner join TB_OUVERIER on TB_OUVERIER.id = TB_USER.ID_OUVERIER
				 WHERE [TB_FACTURE_VENTE].ETAT COLLATE Arabic_CI_AS LIKE N'%فاتورة قيد الانتظار%'
";
            SqlCommand cmd = new SqlCommand(Qry, daoo.sqlConnection);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                foreach (DataRow row in Dt.Rows)
                {

                    add_fctr_attend(
                        row["NMR_FACTURE"].ToString(),
                        Convert.ToInt32(row["Clientt"].ToString()),
                        decimal.Parse(row["TOTAL_FACURE_TTC"].ToString())
                        );
                }
            }
        }
        private void add_fctr_attend(string ID, int client, decimal Total_facture)
        {
            var W = new U_c_fctr_attend()
            {
                nmr_fctr = ID,
                id_client = client,
                Price_ttl = Total_facture
            };
            flowLayoutPanel2.Controls.Add(W);
            W.onSelect += (ss, ee) =>
            {
                //delete all 
                DeleteRowByCodeBarre();
                dataGridView1.Refresh();
                GetTTL();
                txtCount.Text = getCount().ToString();
                var wdg = (U_c_fctr_attend)ss;
                string txt_nmr_fctr = wdg.nmr_fctr;
                int txt_client = wdg.id_client;
                decimal txt_TTL = wdg.Price_ttl;
                DataTable kryptonDataGridView2 = new DataTable();
                kryptonDataGridView2 = class_facturation.get_vente_by_nmr(txt_nmr_fctr);


                foreach (DataRow roww in kryptonDataGridView2.Rows)
                {

                    string CodeBarrre = roww["رقم المنتوج"].ToString();
                    string Qt = roww["كمية المنتوج"].ToString();
                    DataTable Dt = new DataTable();
                    Dt = caisseVente_classe.getSold_MAtier_revent(CodeBarrre);
                    if (Dt.Rows.Count > 0)
                    {
                        Object codeBarre = Dt.Rows[0][0];
                        Object name_product = Dt.Rows[0][1];
                        Object price_Vente = Dt.Rows[0][15];
                        Object price_achat_produit_revent = Dt.Rows[0][12];
                        Object Quanite_dans_pack = Dt.Rows[0][24];
                        #region 
                        ////foreach (DataGridViewRow row in frmVente.dataGridView1.Rows)
                        ////{
                        ////    if (!row.IsNewRow)
                        ////    {
                        ////        var cellValue = row.Cells["DgvCodeBarre"].Value;

                        ////        // Check if the cell value is not null before comparison
                        ////        if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                        ////        {
                        ////            row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                        ////            row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                        ////                                    decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
                        ////            row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                        ////                    decimal.Parse(price_achat_produit_revent.ToString());
                        ////            frmVente.GetTTL();
                        ////            frmVente.txtCount.Text = frmVente.getCount().ToString();

                        ////            return;
                        ////        }
                        ////    }
                        ////}
                        ///
                        #endregion
                        //this Line add new product
                        this.dataGridView1.Rows.Add(new object[] {
                                0,
                                codeBarre.ToString(),
                                name_product.ToString(),
                                Qt,
                                price_Vente.ToString(),
                                 (decimal.Parse(price_Vente.ToString()) * (decimal.Parse(Qt.ToString()))) ,
                                "U"
                                ,
                                (decimal.Parse(price_achat_produit_revent.ToString()) * (decimal.Parse(Qt.ToString())))
                            });

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
                            #region 
                            //foreach (DataGridViewRow row in frmVente.dataGridView1.Rows)
                            //{
                            //    if (!row.IsNewRow)
                            //    {
                            //        var cellValue = row.Cells["DgvCodeBarre"].Value;

                            //        // Check if the cell value is not null before comparison
                            //        if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                            //        {
                            //            row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                            //            row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
                            //                                    decimal.Parse(row.Cells["dgvAmount"].Value.ToString());

                            //            frmVente.GetTTL();
                            //            frmVente.txtCount.Text = frmVente.getCount().ToString();

                            //            return;
                            //        }
                            //    }
                            //}
                            #endregion
                            //this Line add new product
                            this.dataGridView1.Rows.Add(new object[] {
                                            0,
                                            codeBarre.ToString(),
                                            name_product.ToString(),
                                            Qt,
                                            price_Vente.ToString(),
                                             (decimal.Parse(price_Vente.ToString())*(decimal.Parse(Qt.ToString()))),
                                            "P",
                                             (decimal.Parse(cout_produire_pack_favrique.ToString())*(decimal.Parse(Qt.ToString())))
                                        });

                        }
                        else if (Dt.Rows.Count == 0)
                        {
                            Dt = caisseVente_classe.select_pack_Produit_finaux_info(CodeBarrre);
                            if (Dt.Rows.Count > 0)
                            {

                                Object codeBarre = Dt.Rows[0][0];
                                Object name_product = Dt.Rows[0][1];
                                Object price_Vente = Dt.Rows[0][4];

                                foreach (DataGridViewRow row in this.dataGridView1.Rows)
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

                                            this.GetTTL();
                                            this.txtCount.Text = this.getCount().ToString();

                                            return;
                                        }
                                    }
                                }
                                //this Line add new product
                                this.dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "P" });

                            }
                            else if (Dt.Rows.Count == 0)
                            {
                                Dt = caisseVente_classe.select_produit_by_code_barre_reserve(CodeBarrre);
                                if (Dt.Rows.Count > 0)
                                {

                                    Object codeBarre = Dt.Rows[0][0];
                                    Object name_product = Dt.Rows[0][1];
                                    Object price_Vente = Dt.Rows[0][2];

                                    foreach (DataGridViewRow row in this.dataGridView1.Rows)
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

                                                this.GetTTL();
                                                this.txtCount.Text = this.getCount().ToString();

                                                return;
                                            }
                                        }
                                    }
                                    //this Line add new product
                                    this.dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "U" });

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

                                        foreach (DataGridViewRow row in this.dataGridView1.Rows)
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

                                                    this.GetTTL();
                                                    this.txtCount.Text = this.getCount().ToString();

                                                    return;
                                                }
                                            }
                                        }
                                        //this Line add new product
                                        this.dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "P" });

                                        //MessageBox.Show("هذا المنتوج غير موجود في قاعدة البيانات");
                                    }

                                    //
                                }
                            }
                        }
                    }



                    this.txt_id_fctr.Text = txt_nmr_fctr;
                    this.clientCmb.SelectedValue = txt_client;
                    this.Typpped = "edit";
                    this.GetTTL();
                    this.txtCount.Text = this.getCount().ToString();
                    this.txt_barcode.Focus();
                    // Redundant line (explained below)

                }
                this.txt_barcode.Focus();
            };
        }
        public void loadFav()
        {
            string Qry = @"SELECT TOP (SELECT COUNT(*) / 2 FROM [dbo].[TB_FAVORIS]) 
									[ID], 
									[FAVOIRE]
									FROM [dbo].[TB_FAVORIS]
									ORDER BY [ID];";
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
        public void loadFav2()
        {
            string Qry = @"WITH CTE_FAVORIS AS (
				SELECT [ID], [FAVOIRE],
				ROW_NUMBER() OVER (ORDER BY [ID]) AS RowNum
				FROM [dbo].[TB_FAVORIS] )
				SELECT [ID], [FAVOIRE]
				FROM CTE_FAVORIS
				WHERE RowNum > (SELECT COUNT(*) / 2 FROM [dbo].[TB_FAVORIS])
				ORDER BY RowNum; ";
            SqlCommand cmd = new SqlCommand(Qry, daoo.sqlConnection);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                foreach (DataRow row in Dt.Rows)
                {

                    ADD_FAV2(
                        Convert.ToInt32(row["ID"].ToString()),
                        row["FAVOIRE"].ToString()
                        );
                }
            }
        }
        private void ADD_FAV2(int ID, string Name)
        {

            var W = new User_Fav()
            {
                PID = ID,
                PName = Name
            };

            flowLayoutPanel4.Controls.Add(W);

            W.onSelect += (ss, ee) =>
            {

                var wdg = (User_Fav)ss;
                txt_fav.Text = ID.ToString();
                flowLAyoutProduct.Controls.Clear();
                loadProduct(ID);
                loadPack(ID);
                txt_barcode.Focus();
            };
        }
        private void ADD_FAV(int ID, string Name)
        {

            var W = new User_Fav()
            {
                PID = ID,
                PName = Name
            };

            flowCategories.Controls.Add(W);

            W.onSelect += (ss, ee) =>
            {
                var wdg = (User_Fav)ss;
                txt_fav.Text = ID.ToString();
                flowLAyoutProduct.Controls.Clear();
                loadProduct(ID);
                loadPack(ID);
                txt_barcode.Focus();
            };
        }
        #region favOld
        /*
        private void addFavoires()
		{
			string Qyr = "Select * from [TB_FAVORIS]";
			SqlCommand cmd = new SqlCommand(Qyr, daoo.sqlConnection);
			SqlDataAdapter Da = new SqlDataAdapter(cmd);
			DataTable Dt = new DataTable();
			Da.Fill(Dt);
			if (Dt.Rows.Count > 0)
			{
				foreach (DataRow row in Dt.Rows)
				{
					KryptonButton btnFav = new KryptonButton();
					btnFav.Size = new Size(100, 44);
					btnFav.Text = row["FAVOIRE"].ToString();
					btnFav.StateCommon.Back.Color1 = Color.DodgerBlue;
					btnFav.StateCommon.Back.Color2 = Color.FromArgb(0, 102, 255);
					btnFav.StateCommon.Content.ShortText.Color1 = Color.White;
					btnFav.StateCommon.Content.ShortText.Font = new Font("Cairo", 12, FontStyle.Regular);

					//event Click
					btnFav.Click += new EventHandler(btn_Clic);
					flowCategories.Controls.Add(btnFav);
				}
			}
		}
		private void btn_Clic(object sender, EventArgs e)
		{
			KryptonButton btnFav = (KryptonButton)sender;
			foreach (var item in flowLAyoutProduct.Controls)
			{
				var pro = (Caisse_user_controle)item;
				pro.Visible = pro.PFavoire.ToLower().Contains(btnFav.Text.Trim().ToLower());
			}
		}
        */
        #endregion
        private void addiTem(string CodeBarre, string Name, string Price, int IDFAV, string Fav, Image pic, string Type, string Achat, float qtRest, float qtaler)
        {

            var W = new Caisse_user_controle()
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

                var wdg = (Caisse_user_controle)ss;
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
                            txt_barcode.Focus();
                            select_last_rows();
                            return;
                        }
                    }
                }
                //this Line add new product
                if (qtRest <= qtaler)
                {
                    if (Properties.Settings.Default.box_Qt_zero == "true")
                    {
                        if (MessageBox.Show("الكمية قريبة من النفاذ او نفذت هل تريد المواصلة", "كمية قليلة", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            dataGridView1.Rows.Add(new object[] { 0, wdg.PCodeBarre, wdg.PName, 1, wdg.PPriceTTC, wdg.PPriceTTC, wdg.Ptype, wdg.PPriceAchat });
                            Price_achat = decimal.Parse(wdg.PPriceAchat);
                            GetTTL();
                            txtCount.Text = getCount().ToString();
                            txt_barcode.Focus();
                            select_last_rows();
                        }
                    }
                    else
                    {
                        dataGridView1.Rows.Add(new object[] { 0, wdg.PCodeBarre, wdg.PName, 1, wdg.PPriceTTC, wdg.PPriceTTC, wdg.Ptype, wdg.PPriceAchat });
                        Price_achat = decimal.Parse(wdg.PPriceAchat);
                        GetTTL();
                        txtCount.Text = getCount().ToString();
                        txt_barcode.Focus();
                        select_last_rows();
                    }

                }
                else
                {
                    dataGridView1.Rows.Add(new object[] { 0, wdg.PCodeBarre, wdg.PName, 1, wdg.PPriceTTC, wdg.PPriceTTC, wdg.Ptype, wdg.PPriceAchat });
                    Price_achat = decimal.Parse(wdg.PPriceAchat);
                    GetTTL();
                    txtCount.Text = getCount().ToString();
                    txt_barcode.Focus();
                    select_last_rows();
                }
            };

        }
        private void loadProductLoad()
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
		  ,TB_FAVORIS.FAVOIRE as'fav' 
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
		from TB_Produit_revente   
		inner join TB_FAVORIS on TB_FAVORIS.ID = TB_Produit_revente.id_favoire 
		where  [id_favoire] = 1";
            SqlCommand cmd = new SqlCommand(Qry, daoo.sqlConnection);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                foreach (DataRow row in Dt.Rows)
                {
                    Byte[] immage_array = (byte[])row["Photo"];
                    byte[] immage_byte_array = immage_array;
                    if (chek_prix1.Checked == true)
                    {
                        addiTem(
                            row["CodeBarre"].ToString(),
                            row["designation"].ToString(),
                            row["price_vente1"].ToString(),
                            Convert.ToInt32(row["id_favoire"].ToString()),
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
                            Convert.ToInt32(row["id_favoire"].ToString()),
                            row["fav"].ToString(),
                            Image.FromStream(new MemoryStream(immage_array)),
                            "U",
                            row["price_achat_TTC"].ToString(),
                            float.Parse(row["Quantite_rest"].ToString()),
                            float.Parse(row["Quantite_alert"].ToString()));
                    }
                    else if (check_prix3.Checked == true)
                    {
                        addiTem(
                            row["CodeBarre"].ToString(),
                            row["designation"].ToString(),
                            row["price_min"].ToString(),
                            Convert.ToInt32(row["id_favoire"].ToString()),
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
        //private gettion product from db
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

        private void loadPackLoad()
        {
            string Qry = @"SELECT [pack_code_barre] 
						,TB_Produit_revente.price_achat_TTC * TB_Produit_revente.QT_DANS_PACK as'Achat' 
						,[pack_designation] 
						,[code_barre_produit] 
						,[quantite]   
						,[price_unitair]   
						,[TB_PACK_PRODUIT_REVENT].[photo] 
						,[TB_PACK_PRODUIT_REVENT].[id_favoire]
						,TB_Produit_revente.Quantite_alert as'QT' ,
						TB_Produit_revente.Quantite_rest as'QR'   
						FROM [dbo].[TB_PACK_PRODUIT_REVENT] 
						INNER JOIN   TB_FAVORIS ON TB_FAVORIS.ID = [TB_PACK_PRODUIT_REVENT].id_favoire
						inner join TB_Produit_revente on TB_Produit_revente.CodeBarre = TB_PACK_PRODUIT_REVENT.code_barre_produit 
						where [TB_PACK_PRODUIT_REVENT].id_favoire = 1";
            SqlCommand cmd = new SqlCommand(Qry, daoo.sqlConnection);
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            if (Dt.Rows.Count > 0)
            {
                foreach (DataRow row in Dt.Rows)
                {
                    Byte[] immage_array = (byte[])row["photo"];
                    byte[] immage_byte_array = immage_array;

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

        private void getparamtre()
        {
            //prix
            if (Properties.Settings.Default.Change_de_prix == "true")
            {
                chek_prix1.Visible = false;
                check_prix2.Visible = false;
                check_prix3.Visible = false;
            }
            else if (Properties.Settings.Default.Change_de_prix == "false")
            {
                chek_prix1.Visible = true;
                check_prix2.Visible = true;
                check_prix3.Visible = true;
            }

            //reference 
            if (Properties.Settings.Default.hide_reference == "true")
            {
                textBox1.Visible = false;
            }
            else if (Properties.Settings.Default.hide_reference == "false")
            {
                textBox1.Visible = true;
            }

            //time
            if (Properties.Settings.Default.hide_time == "true")
            {
                LB_heures.Visible = false;
                LB_Date.Visible = false;
            }
            else if (Properties.Settings.Default.hide_time == "false")
            {
                LB_heures.Visible = true;
                LB_Date.Visible = true;
            }

            //keyboard 
            if (Properties.Settings.Default.hide_keyboard == "true")
            {
                kryptonButton4.Visible = false;
            }
            else if (Properties.Settings.Default.hide_keyboard == "false")
            {
                kryptonButton4.Visible = true;
            }

            //detaille 
            if (Properties.Settings.Default.detaille_produit == "true")
            {
                kryptonButton1.Visible = false;
            }
            else if (Properties.Settings.Default.detaille_produit == "false")
            {
                kryptonButton1.Visible = true;
            }

            //old_facture 
            if (Properties.Settings.Default.old_facture == "true")
            {
                kryptonButton21.Visible = false;
            }
            else if (Properties.Settings.Default.old_facture == "false")
            {
                kryptonButton21.Visible = true;
            }

            //list_vente 
            if (Properties.Settings.Default.list_vente == "true")
            {
                kryptonButton8.Visible = false;
            }
            else if (Properties.Settings.Default.list_vente == "false")
            {
                kryptonButton8.Visible = true;
            }

            //old_credit 
            if (Properties.Settings.Default.old_credit == "true")
            {
                panel14.Visible = false;
            }
            else if (Properties.Settings.Default.list_vente == "false")
            {
                panel14.Visible = true;
            }

            //new_credit 
            if (Properties.Settings.Default.new_credit == "true")
            {
                panel16.Visible = false;
            }
            else if (Properties.Settings.Default.list_vente == "false")
            {
                panel16.Visible = true;
            }

            //check_plus_minez 
            if (Properties.Settings.Default.plus_and_minez == "true")
            {
                kryptonButton2.Visible = false;
                kryptonButton3.Visible = false;
            }
            else if (Properties.Settings.Default.plus_and_minez == "false")
            {
                kryptonButton2.Visible = true;
                kryptonButton3.Visible = true;
            }

            //convert_to_pack 
            if (Properties.Settings.Default.convert_to_pack == "true")
            {
                kryptonButton9.Visible = false;
            }
            else if (Properties.Settings.Default.convert_to_pack == "false")
            {
                kryptonButton9.Visible = true;
            }


            //btn_taklufa
            if (Properties.Settings.Default.taklufa == "true")
            {
                dataGridView1.Columns["cout_ttl"].Visible = true;
            }
            else
            {
                dataGridView1.Columns["cout_ttl"].Visible = false;
            }

            //btn_edit
            if (Properties.Settings.Default.edit == "true")
            {
                dataGridView1.Columns["dgvEdit"].Visible = true;
            }
            else
            {
                dataGridView1.Columns["dgvEdit"].Visible = false;
            }


            //btn_supp
            if (Properties.Settings.Default.supp == "true")
            {
                dataGridView1.Columns["dgvDellete"].Visible = true;
            }
            else
            {
                dataGridView1.Columns["dgvDellete"].Visible = false;
            }


            //btn_pack
            if (Properties.Settings.Default.pack == "true")
            {
                dataGridView1.Columns["DgvPack"].Visible = true;
            }
            else
            {
                dataGridView1.Columns["DgvPack"].Visible = false;
            }

            //btn_remise
            if (Properties.Settings.Default.remise == "true")
            {
                dataGridView1.Columns["DgvREMISE"].Visible = true;
            }
            else
            {
                dataGridView1.Columns["DgvREMISE"].Visible = false;
            }

            //btn_edit_price
            if (Properties.Settings.Default.change_price == "true")
            {
                dataGridView1.Columns["DgvEditPrice"].Visible = true;
            }
            else
            {
                dataGridView1.Columns["DgvEditPrice"].Visible = false;
            }

            //panel _attend 
            if (Properties.Settings.Default.photo_and_attend == "true")
            {
                panel8.Visible = false;
            }
            else if (Properties.Settings.Default.photo_and_attend == "false")
            {
                panel8.Visible = true;
            }

        }
        private void frm_vente_caisse_Load(object sender, EventArgs e)
        {
            getparamtre();

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

            flowLayoutPanel2.Controls.Clear();
            Load_facture_en_attend();
            loadFav();
            loadFav2();
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
                debutjourne.frmVenteCaisse = this;
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

            LB_heures.Text = DateTime.Now.ToLongDateString();
            LB_Date.Text = DateTime.Now.ToLongTimeString();

            //foreach (Control ctrl in this.Controls)
            //{
            //    if (!(ctrl is TextBox)) // تجاهل مربع النص نفسه
            //    {
            //        // إرفاق معالجات الأحداث لإعادة التركيز على مربع النص بعد التفاعل
            //        ctrl.Click += (s, ev) => txt_barcode.Focus();
            //        ctrl.MouseDown += (s, ev) => txt_barcode.Focus();
            //    }
            //}

            // تعيين التركيز مبدئيًا إلى مربع النص
            txt_barcode.Focus();


        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in flowLAyoutProduct.Controls)
            {
                var pro = (Caisse_user_controle)item;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void txt_Versement_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            //{
            //    e.Handled = true;
            //}

        }

        private void txt_Versement_Click(object sender, EventArgs e)
        {
            txt_Versement.SelectAll();
            txt_Versement.Focus();
        }

        private void txt_qt_Click_1(object sender, EventArgs e)
        {
            txt_qt.SelectAll();
        }

        private void txt_Versement_TextChanged_2(object sender, EventArgs e)
        {
            try
            {
                lb_rest.Text = calculeRest(decimal.Parse(lb_Total.Text), decimal.Parse(txt_Versement.Text)).ToString();

                decimal sold_non_pays = decimal.Parse(lb_historique_credit.Text);
                //calcule_credit_after(decimal.Parse(sold_non_pays.ToString()));
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

        private void lb_new_credit_Click(object sender, EventArgs e)
        {

        }

        private void txtCount_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton14_Click(object sender, EventArgs e)
        {
            frm_money_debut_de_joune money = new frm_money_debut_de_joune();
            money.frmVenteCaisse = this;
            money.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //private void enterValue(string valueBtn)
        //{
        //    if (txt_qt.Focused == true)
        //    {
        //        txt_qt.Text = txt_qt.Text + valueBtn;
        //        txt_qt.Focus();
        //    }
        //    else if (txt_Versement.Focused == true)
        //    {
        //        txt_Versement.Text = txt_Versement.Text + valueBtn;
        //        txt_Versement.Focus();
        //    }
        //}

        private void kryptonButton75_Click(object sender, EventArgs e)
        {
            //enterValue(".");
        }

        private void kryptonButton76_Click(object sender, EventArgs e)
        {
            //enterValue("0");
        }

        private void kryptonButton72_Click(object sender, EventArgs e)
        {
            //enterValue("1");
        }

        private void kryptonButton73_Click(object sender, EventArgs e)
        {
            //enterValue("2");
        }

        private void kryptonButton74_Click(object sender, EventArgs e)
        {
            //enterValue("3");
        }

        private void kryptonButton69_Click(object sender, EventArgs e)
        {
            //enterValue("4");
        }

        private void kryptonButton70_Click(object sender, EventArgs e)
        {
            //enterValue("5");
        }

        private void kryptonButton71_Click(object sender, EventArgs e)
        {
            //enterValue("6");
        }

        private void kryptonButton67_Click(object sender, EventArgs e)
        {
            if (txt_qt.Focused)
            {
                txt_qt.Text += "7";
                txt_qt.Focus();
            }
            else if (txt_Versement.Focused)
            {
                txt_Versement.Text += "7";
                txt_Versement.Focus();
            }
            //enterValue("7");
        }

        private void kryptonButton65_Click(object sender, EventArgs e)
        {
            //enterValue("8");
        }

        private void kryptonButton68_Click(object sender, EventArgs e)
        {
            //enterValue("9");
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

        private void produit_fabrique_CheckedChanged(object sender, EventArgs e)
        {
            cmbProduct.DataSource = Bl_combobox.produit_fabrique();
            cmbProduct.DisplayMember = "DESIGNATION";
            cmbProduct.ValueMember = "CODE_BARRE";
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

        private void txt_barcode_Enter(object sender, EventArgs e)
        {


        }
        private void check_date_periptition(object date_pérétion)
        {
            DateTime today = DateTime.Today;
            int number_alert_day = 15;
            if (date_pérétion is DateTime expirationDate)
            {
                // حساب الفرق بالأيام
                int daysDifference = (expirationDate - today).Days;

                // التحقق مما إذا كان الفرق أقل من عدد الأيام المحددة
                if (daysDifference < number_alert_day)
                {
                    if(Properties.Settings.Default.chech_date_pereprtion == "true")
                    { 
                        MessageBox.Show(" المنتج قريب من تاريخ نهاية الصلاحية او قد انتهت صلاحيته يرجى التحقق !");
                    }
                } 
            }
        }
        public void getinformation_matier_revent(string CodeBarrre)
        {
            #region code متسحقوش
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
            #endregion
            barcodee = CodeBarrre;
            if (barcodee.Length == 13 && barcodee.StartsWith("99"))
            {
                // استخراج الكود بار
                string productCode = barcodee.Substring(2, 5);

                // استخراج الوزن وتحويله إلى رقم عشري
                string weightStr = barcodee.Substring(7, 5);
                if (decimal.TryParse(weightStr.Insert(2, ","), out decimal weight))
                {
                    // استخراج رقم التحقق
                    char checkDigit = barcodee[12];

                    // عرض النتائج
                    //txt_barcode.Text = productCode;
                    string QT = weight.ToString();

                    DataTable Dt = new DataTable();
                    Dt = caisseVente_classe.getSold_MAtier_revent(productCode);
                    if (Dt.Rows.Count > 0)
                    {
                        Object codeBarre = Dt.Rows[0][0];
                        Object name_product = Dt.Rows[0][1]; 
                        Object Quanite_dans_pack = Dt.Rows[0][24];
                        Object price_achat_produit_revent = Dt.Rows[0][12];

                        if (chek_prix1.Checked == true)
                        {
                            price_Vente = Dt.Rows[0][15];
                        }
                        else if (check_prix2.Checked == true)
                        {
                            price_Vente = Dt.Rows[0][16];
                        }
                        else if (check_prix3.Checked == true)
                        {
                            price_Vente = Dt.Rows[0][17];
                        }

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                var cellValue = row.Cells["DgvCodeBarre"].Value;

                                // Check if the cell value is not null before comparison
                                if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                {
                                    row.Cells["dgvQt"].Value = (float.Parse(row.Cells["dgvQt"].Value.ToString()) + float.Parse(QT)).ToString();
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
                                                DataTable DtPack = caisseVente_classe.select_pack_revent_by_code_barre_produit(productCode);
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
                                                dataGridView1.Rows.Add(new object[] { 
                                                    0, 
                                                    codeBarrePack.ToString(), 
                                                    name_productPack.ToString(), 
                                                    QT, 
                                                    price_VentePAck.ToString(), 
                                                    price_VentePAck.ToString(), 
                                                    "P", 
                                                    price_achat_revent_pack.ToString() 
                                                });
                                                GetTTL();
                                                txtCount.Text = getCount().ToString();
                                                txt_barcode.Focus();
                                                select_last_rows();

                                                return;
                                            }
                                        }
                                    }
                                    GetTTL();
                                    txtCount.Text = getCount().ToString();
                                    txt_barcode.Focus();
                                    select_last_rows();

                                    return;
                                }
                            }
                        }
                        //this Line add new product
                        dataGridView1.Rows.Add(new object[] { 
                            0, 
                            codeBarre.ToString(), 
                            name_product.ToString(), 
                            QT, 
                            price_Vente.ToString(), 
                            (decimal.Parse(price_Vente.ToString())*decimal.Parse(QT.ToString())), 
                            "U",
                            (decimal.Parse(price_achat_produit_revent.ToString())*decimal.Parse(QT.ToString())) 
                        });

                    }
                }
                else
                {
                    MessageBox.Show("الوزن غير صالح.");
                }
            }
            else
            {
                DataTable Dt = new DataTable();
                Dt = caisseVente_classe.getSold_MAtier_revent(CodeBarrre);
                if (Dt.Rows.Count > 0)
                {
                    Object codeBarre = Dt.Rows[0][0];
                    Object name_product = Dt.Rows[0][1];
                    if (chek_prix1.Checked == true)
                    {
                        price_Vente = Dt.Rows[0][15];
                    }
                    else if (check_prix2.Checked == true)
                    {
                        price_Vente = Dt.Rows[0][16];
                    }
                    else if (check_prix3.Checked == true)
                    {
                        price_Vente = Dt.Rows[0][17];
                    }
                    Object Quanite_dans_pack = Dt.Rows[0][24]; 
                    Object Qt_alter = Dt.Rows[0][25];
                    Object Qt_rest = Dt.Rows[0][21]; 
                    Object date_pérétion = Dt.Rows[0][10];
                    Object price_achat_produit_revent = Dt.Rows[0][12];
                    #region old_code
                    //foreach (DataGridViewRow row in dataGridView1.Rows)
                    //{
                    //    if (!row.IsNewRow)
                    //    {
                    //        var cellValue = row.Cells["DgvCodeBarre"].Value;

                    //        // Check if the cell value is not null before comparison
                    //        if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                    //        {
                    //            row.Cells["dgvQt"].Value = (float.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                    //            row.Cells["dgbTtl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                    //                                    float.Parse(row.Cells["dgvAmount"].Value.ToString());
                    //            row.Cells["cout_ttl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                    //                float.Parse(price_achat_produit_revent.ToString());
                    //            //------------------------------------------------------------------------------//
                    //            if (Quanite_dans_pack.ToString() != "")
                    //            {
                    //                if (float.Parse(row.Cells["dgvQt"].Value.ToString()) == float.Parse(Quanite_dans_pack.ToString()))
                    //                {
                    //                    DialogResult dg = MessageBox.Show("هل تريد بيع حزمة من هذا المنتوج مباشرة؟", "بيع بالحزمة؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //                    if (dg == DialogResult.Yes)
                    //                    {
                    //                        dataGridView1.Rows.Remove(row);
                    //                        DataTable DtPack = caisseVente_classe.select_pack_revent_by_code_barre_produit(CodeBarrre);
                    //                        Object codeBarrePack = DtPack.Rows[0][0];
                    //                        Object name_productPack = DtPack.Rows[0][1];
                    //                        Object price_VentePAck = DtPack.Rows[0][4];
                    //                        Object price_achat_revent = DtPack.Rows[0][7];
                    //                        Object qt_dans_pack = DtPack.Rows[0][8];
                    //                        decimal price_achat_revent_pack = decimal.Parse(price_achat_revent.ToString()) *
                    //                            decimal.Parse(qt_dans_pack.ToString());
                    //                        foreach (DataGridViewRow rowP in dataGridView1.Rows)
                    //                        {
                    //                            if (!row.IsNewRow)
                    //                            {
                    //                                var cellValued = row.Cells["DgvCodeBarre"].Value;

                    //                                // Check if the cell value is not null before comparison
                    //                                if (cellValued != null && cellValued.ToString() == codeBarrePack.ToString())
                    //                                {
                    //                                    row.Cells["dgvQt"].Value = (float.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
                    //                                    row.Cells["dgbTtl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                    //                                                            float.Parse(row.Cells["dgvAmount"].Value.ToString());
                    //                                    row.Cells["cout_ttl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                    //                                                            float.Parse(price_achat_revent_pack.ToString());

                    //                                    GetTTL();
                    //                                    txtCount.Text = getCount().ToString();

                    //                                    return;
                    //                                }
                    //                            }
                    //                        }
                    //                        //this Line add new product

                    //                        float ttlprice_pack = float.Parse(price_VentePAck.ToString()) * float.Parse(txt_qt.Text);
                    //                        float ttl_cout_achat_pack = float.Parse(price_achat_revent_pack.ToString()) * float.Parse(txt_qt.Text);
                    //                        dataGridView1.Rows.Add(new object[] { 0, codeBarrePack.ToString(), name_productPack.ToString(), txt_qt.Text, price_VentePAck.ToString(), ttlprice_pack.ToString(), "P", price_achat_revent_pack.ToString() });
                    //                        GetTTL();
                    //                        txtCount.Text = getCount().ToString();
                    //                        txt_barcode.Focus();
                    //                        select_last_rows();

                    //                        return;
                    //                    }
                    //                }
                    //            }
                    //            GetTTL();
                    //            txtCount.Text = getCount().ToString();
                    //            txt_barcode.Focus();
                    //            select_last_rows();

                    //            return;
                    //        }
                    //    }
                    //}
                    ////this Line add new product
                    //float ttlprice = float.Parse(price_Vente.ToString()) * float.Parse(txt_qt.Text);
                    //float ttl_cout_achat = float.Parse(price_achat_produit_revent.ToString()) * float.Parse(txt_qt.Text);
                    //dataGridView1.Rows.Add(new object[] { 
                    //    0, 
                    //    codeBarre.ToString(), 
                    //    name_product.ToString(), 
                    //    txt_qt.Text, 
                    //    price_Vente.ToString(), 
                    //    ttlprice.ToString(), 
                    //    "U", 
                    //    ttl_cout_achat.ToString()
                    //});
                    //txt_qt.Text = "1";
                    #endregion
                    if (float.Parse(Qt_rest.ToString()) <= float.Parse(Qt_alter.ToString()))
                    {
                        if (Properties.Settings.Default.box_Qt_zero == "true")
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
                                check_date_periptition(date_pérétion);
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
                                        txt_barcode.Focus();
                                        select_last_rows();
                                        return;
                                    }
                                }
                            }
                            check_date_periptition(date_pérétion);
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
                            txt_barcode.Focus();
                            select_last_rows();
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
                                    txt_barcode.Focus();
                                    select_last_rows();
                                    return;
                                }
                            }
                        }
                        check_date_periptition(date_pérétion);
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
                        txt_barcode.Focus();
                        select_last_rows();
                    }
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
                                                float ttlprice_pack_fab = float.Parse(price_VentePAck.ToString()) * float.Parse(txt_qt.Text);
                                                float ttl_cout_achat_pack_fab = float.Parse(cout_produire_pack_favrique.ToString()) * float.Parse(txt_qt.Text); 
                                                dataGridView1.Rows.Add(new object[] { 0, codeBarrePack.ToString(), name_productPack.ToString(), txt_qt.Text, price_VentePAck.ToString(), ttlprice_pack_fab.ToString(), "P", ttl_cout_achat_pack_fab.ToString() });
                                                GetTTL();
                                                txtCount.Text = getCount().ToString();
                                                txt_barcode.Focus();
                                                select_last_rows();
                                                txt_qt.Text = "1";
                                                return;
                                            }
                                        }
                                    }
                                    GetTTL();
                                    txtCount.Text = getCount().ToString();
                                    txt_barcode.Focus();
                                    select_last_rows();
                                    txt_qt.Text = "1";
                                    return;
                                }
                            }
                        }
                        //this Line add new product
                        float ttlprice_fab = float.Parse(price_Vente.ToString()) * float.Parse(txt_qt.Text);
                        float ttl_cout_achat_fab = float.Parse(cout_de_prodution.ToString()) * float.Parse(txt_qt.Text); 
                        dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), txt_qt.Text, price_Vente.ToString(), ttlprice_fab.ToString(), "U", ttl_cout_achat_fab.ToString() });
                        txt_qt.Text = "1";
                        txt_barcode.Focus();
                        select_last_rows();
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
                                        select_last_rows();

                                        return;
                                    }
                                }
                            }
                            //this Line add new product

                            float ttl_vente_pack = float.Parse(price_Vente.ToString()) * float.Parse(txt_qt.Text);
                            float ttl_cout_achat_pack = float.Parse(cout_produire_pack_favrique.ToString()) * float.Parse(txt_qt.Text); 

                            dataGridView1.Rows.Add(new object[] { 
                                0, 
                                codeBarre.ToString(), 
                                name_product.ToString(), 
                                txt_qt.Text, 
                                price_Vente.ToString(),
                                ttl_vente_pack.ToString(), 
                                "P",
                                ttl_cout_achat_pack });
                            txt_qt.Text = "1";
                            txt_barcode.Focus();
                            select_last_rows();
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
                                            select_last_rows();

                                            return;
                                        }
                                    }
                                }
                                //this Line add new product
                                float ttl_vente_packk = float.Parse(price_Vente.ToString()) * float.Parse(txt_qt.Text);
                                float ttl_cout_achat_packk = float.Parse(cout_produire_pack_favrique.ToString()) * float.Parse(txt_qt.Text);

                                dataGridView1.Rows.Add(new object[] { 
                                    0, 
                                    codeBarre.ToString(), 
                                    name_product.ToString(), 
                                    txt_qt.Text, 
                                    price_Vente.ToString(),
                                    ttl_vente_packk.ToString(), 
                                    "P",
                                    ttl_cout_achat_packk.ToString() });
                                txt_qt.Text = "1";
                                txt_barcode.Focus();
                                select_last_rows();
                            }
                            else if (Dt.Rows.Count == 0)
                            {
                                Dt = caisseVente_classe.select_produit_by_code_barre_reserve(CodeBarrre);
                                if (Dt.Rows.Count > 0)
                                {

                                    Object codeBarre = Dt.Rows[0][0];
                                    Object name_product = Dt.Rows[0][1];
                                    Object price_Vente = Dt.Rows[0][2];
                                    DataTable Dft = new DataTable();
                                    Dft = caisseVente_classe.getSold_MAtier_revent(codeBarre.ToString());
                                    if (Dft.Rows.Count > 0)
                                    {

                                        Object codeBarreR = Dft.Rows[0][0];
                                        Object name_productT = Dft.Rows[0][1];
                                        if (chek_prix1.Checked == true)
                                        {
                                            price_Vente = Dft.Rows[0][15];
                                        }
                                        else if (check_prix2.Checked == true)
                                        {
                                            price_Vente = Dft.Rows[0][16];
                                        }
                                        else if (check_prix3.Checked == true)
                                        {
                                            price_Vente = Dft.Rows[0][17];
                                        }
                                        Object date_pérétion = Dft.Rows[0][10];
                                        Object Quanite_dans_pack = Dft.Rows[0][24];
                                        Object price_achat_produit_revent = Dft.Rows[0][12];

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
                                                GetTTL();
                                                txtCount.Text = getCount().ToString();
                                                txt_barcode.Focus();
                                                select_last_rows();

                                                return;
                                            }
                                        }
                                        }
                                    //this Line add new product
                                   
                                        float ttl_vente_packkk = float.Parse(price_Vente.ToString()) * float.Parse(txt_qt.Text);
                                        float ttl_cout_achat_packk = float.Parse(price_achat_produit_revent.ToString()) * float.Parse(txt_qt.Text);

                                        check_date_periptition(date_pérétion);
                                        dataGridView1.Rows.Add(new object[] {
                                        0,
                                        codeBarreR.ToString(),
                                        name_productT.ToString(),
                                        txt_qt.Text,
                                        price_Vente.ToString(),
                                        ttl_vente_packkk.ToString(),
                                        "U",
                                        ttl_cout_achat_packk.ToString()});
                                    }
                                    txt_qt.Text = "1";
                                    txt_barcode.Focus();
                                    select_last_rows();
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
                                        DataTable tb_pack = new DataTable();
                                        tb_pack = caisseVente_classe.select_pack_info(codeBarre.ToString());
                                        if (tb_pack.Rows.Count > 0)
                                        {

                                            Object codeBarre_1 = tb_pack.Rows[0][0];
                                            Object name_product_1 = tb_pack.Rows[0][1];
                                            Object price_Vente_1 = tb_pack.Rows[0][4];
                                            Object price_Achat = tb_pack.Rows[0][7];
                                            Object Qt_dans_pack = tb_pack.Rows[0][8];
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
                                                        select_last_rows();

                                                        return;
                                                    }
                                                }
                                            }
                                            //this Line add new product

                                            float ttl_vente_pack = float.Parse(price_Vente.ToString()) * float.Parse(txt_qt.Text);
                                            float ttl_cout_achat_pack = float.Parse(cout_produire_pack_favrique.ToString()) * float.Parse(txt_qt.Text);

                                            dataGridView1.Rows.Add(new object[] {
                                            0,
                                            codeBarre.ToString(),
                                            name_product.ToString(),
                                            txt_qt.Text,
                                            price_Vente.ToString(),
                                            ttl_vente_pack.ToString(),
                                            "P",
                                            ttl_cout_achat_pack });
                                            txt_qt.Text = "1";
                                            txt_barcode.Focus();
                                            select_last_rows();
                                        }
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



            }

            GetTTL();
            txtCount.Text = getCount().ToString();
            txt_barcode.Focus();
            select_last_rows();
        }

        private void txt_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            //if (isNewBarcodeEntry)
            //{
            //    txt_barcode.Clear();
            //    isNewBarcodeEntry = false; // تحديث الحالة بحيث لا يتم مسح الحقل في كل مرة
            //}
            //        if (e.KeyCode == Keys.ShiftKey)
            //        {
            //            DataTable Dt = new DataTable();
            ////this.dataGridView1.Rows.Add(new object[] { 0, txt_name_divers.Text, txt_name_divers.Text, 1, txtPriceU.Text, txtPriceU.Text, "D" }); ;
            //this.dataGridView1.Rows.Add(new object[] { 0,"منتج غير معرف", "منتج غير معرف", 1 , txt_barcode.Text, txt_barcode.Text, "D" }); ;
            //this.GetTTL();
            //            this.txtCount.Text = this.getCount().ToString();
            //txt_barcode.Text = "";
            //txt_barcode.Focus();
            //        }
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
                LB_QT_REST.Text = drv["Quantite_rest"].ToString();
                byte[] imageBytes = (byte[])drv["Photo"];
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    picture_article.Image = Image.FromStream(ms);
                }
                textBox1.Text = reference.ToString();
            }

            //if (pack_check_produit_revent.Checked == true)
            //{
            //	barcode = drv["pack_code_barre"].ToString();
            //	Price = decimal.Parse(drv["price_unitair"].ToString());
            //	NamePO = drv["pack_designation"].ToString();
            //}
            //else
            //else if (kryptonRadioButton1.Checked == true)
            //{
            //	barcode = drv["CODE_BARRE"].ToString();
            //	Price = decimal.Parse(drv["PRICE_VENTE_TTC"].ToString());
            //	NamePO = drv["DESIGNATION"].ToString();
            //}
            //else if (pack_produit_fabrique.Checked == true)
            //{
            //	barcode = drv["BARCODE_PACK"].ToString();
            //	Price = decimal.Parse(drv["price_unitair"].ToString());
            //	NamePO = drv["DESIGNATION"].ToString();
            //}

            //DataRowView drv = (DataRowView)cmbProduct.SelectedItem;


            //try
            //{
            //	if (pack_check_produit_revent.Checked)
            //	{ 
            //		barcode = drv["pack_code_barre"].ToString();
            //		Price = decimal.Parse(drv["price_unitair"].ToString());
            //		NamePO = drv["pack_designation"].ToString();
            //	}
            //	else if (check_produit_revent.Checked)
            //	{
            //		barcode = drv["CodeBarre"].ToString();
            //		Price = decimal.Parse(drv["price_vente1"].ToString());
            //		NamePO = drv["designation"].ToString();
            //	}
            //	else if (kryptonRadioButton1.Checked)
            //	{
            //		barcode = drv["CODE_BARRE"].ToString();
            //		Price = decimal.Parse(drv["PRICE_VENTE_TTC"].ToString());
            //		NamePO = drv["DESIGNATION"].ToString();
            //	}
            //	else if (pack_produit_fabrique.Checked)
            //	{
            //		barcode = drv["BARCODE_PACK"].ToString();
            //		Price = decimal.Parse(drv["price_unitair"].ToString());
            //		NamePO = drv["DESIGNATION"].ToString();
            //	}
            //}
            //catch (ArgumentException ex)
            //{
            //	MessageBox.Show($"Column not found: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (Exception ex)
            //{
            //	MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        private void select_last_rows()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                // Select the last row
                int lastRowIndex = dataGridView1.Rows.Count - 1;
                dataGridView1.ClearSelection();
                dataGridView1.Rows[lastRowIndex].Selected = true;

                // Scroll to the last row
                dataGridView1.FirstDisplayedScrollingRowIndex = lastRowIndex;

                string Codebarre = dataGridView1.Rows[lastRowIndex].Cells[1].Value.ToString();
                string designation = dataGridView1.Rows[lastRowIndex].Cells[2].Value.ToString();
                string QT = dataGridView1.Rows[lastRowIndex].Cells[3].Value.ToString();
                string priceU = dataGridView1.Rows[lastRowIndex].Cells[4].Value.ToString();
                string priceTTl = dataGridView1.Rows[lastRowIndex].Cells[5].Value.ToString();

                // تعيين القيم إلى العناصر المراد عرضها فيها
                LB_NAME.Text = designation;
                LB_QT.Text = QT;
                LB_PRICE_U.Text = priceU;
                LB_TTL.Text = priceTTl;


                DataTable Dtt = caisseVente_classe.getSold_MAtier_revent(Codebarre);
                if (Dtt.Rows.Count > 0) // تحقق من وجود صفوف في الجدول
                {
                    DataRow row = Dtt.Rows[0]; // الحصول على الصف الأول
                    if (row[23] != DBNull.Value) // التحقق من أن العمود 23 يحتوي على قيمة
                    {
                        byte[] imageBytes = (byte[])row[23]; // استخراج البيانات كـ byte[]
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            picture_article.Image = Image.FromStream(ms); // عرض الصورة في PictureBox
                        }
                    }
                }  
            }

        }
        private void kryptonButton12_Click_1(object sender, EventArgs e)
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
                                txt_barcode.Focus();
                                select_last_rows();

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
                    }

                    );


                    txt_barcode.Focus();
                    select_last_rows();


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
                    Object date_pérétion = Dtt.Rows[0][10];
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
                        if (Properties.Settings.Default.box_Qt_zero == "true")
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
                                check_date_periptition(date_pérétion);
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
                                        txt_barcode.Focus();
                                        select_last_rows();
                                        return;
                                    }
                                }
                            }
                            check_date_periptition(date_pérétion);
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
                            txt_barcode.Focus();
                            select_last_rows();
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
                                    txt_barcode.Focus();
                                    select_last_rows();
                                    return;
                                }
                            }
                        }
                        check_date_periptition(date_pérétion);
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
                        txt_barcode.Focus();
                        select_last_rows();
                    }
                }
            }
            else if (kryptonRadioButton1.Checked)
            {
                barcode = drv["CODE_BARRE"].ToString();
                Price = decimal.Parse(drv["PRICE_VENTE_TTC"].ToString());
                NamePO = drv["DESIGNATION"].ToString();
            }
            else if (pack_produit_fabrique.Checked)
            {
                barcode = drv["BARCODE_PACK"].ToString();
                Price = decimal.Parse(drv["PRICE_DETAILLE"].ToString());
                NamePO = drv["DESIGNATION"].ToString();
            }
            #region OLD CODE
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
            txt_barcode.Focus();
            select_last_rows();
        }

        private void produit_xfabrique_CheckedChanged(object sender, EventArgs e)
        {
            cmbProduct.DataSource = Bl_combobox.get_combo_pack_fabrique();
            cmbProduct.DisplayMember = "DESIGNATION";
            cmbProduct.ValueMember = "BARCODE_PACK";
        }

        private void kryptonButton16_Click(object sender, EventArgs e)
        {
            frm_add_divers add_divers = new frm_add_divers();
            add_divers.formVente = this;
            add_divers.ShowDialog();
        }

        private void lb_rest_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton22_Click(object sender, EventArgs e)
        {
            frm_remise addRemise = new frm_remise();
            addRemise.txt_price_product.Text = lb_Total.Text;
            addRemise.formVentePrincipale = this;
            addRemise.ShowDialog();

        }

        private void txt_barcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {

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
            report.vente.direct_receipt rpt = new report.vente.direct_receipt();
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
            // تعيين حجم الورق والاتجاه
            rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
            rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
 
            rpt.SetParameterValue("@nmr_Facture", txt_id_fctr.Text);

            // Print the report directly
            rpt.PrintToPrinter(1, false, 0, 0);
        }
        private void PlaySystemSound()
        {
            try
            {
                // You can replace 'Asterisk' with other sounds like 'Beep', 'Exclamation', etc.
                SystemSounds.Asterisk.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing system sound: {ex.Message}");
            }
        }
        private void btn1_Click(object sender, EventArgs e)
        {

            if (Properties.Settings.Default.form_confirme_bon == "true")
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    frm_confirme_bon form_bon = new frm_confirme_bon();
                    form_bon.txt_versement.Text = txt_Versement.Text;
                    form_bon.txt_ttl_fctr.Text = lb_Total.Text;
                    form_bon.txt_retour.Text = lb_rest.Text;
                    form_bon.txt_client.Text = clientCmb.Text;
                    form_bon.txt_user.Text = "";
                    form_bon.txt_caissier.Text = "";
                    form_bon.txt_nmr_bon.Text = txt_id_fctr.Text;
                    form_bon.Typpped = Typpped;
                    form_bon.lb_historique_credit.Text = lb_historique_credit.Text;
                    form_bon.txt_vlr_remise.Text = lbl_prix_remisier.Text;
                    form_bon.txt_originale_praix.Text = lbl_price_off.Text; 
                    form_bon.Count = int.Parse(this.txtCount.Text);
                    form_bon.id_client = Convert.ToInt32(this.clientCmb.SelectedValue);
                    form_bon.id_user = this.id_user;
                    form_bon.ID_caissier = this.ID_caissier;
                    form_bon.form_caisse = this;
                    form_bon.ShowDialog();

                }
            }
            else
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
                        txt_barcode.Focus();

                        flowLayoutPanel2.Controls.Clear();
                        Load_facture_en_attend();
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
                        txt_barcode.Focus();

                        flowLayoutPanel2.Controls.Clear();
                        Load_facture_en_attend();
                    }
                    //PopupNotifier notify = new PopupNotifier();
                    if (Properties.Settings.Default.notif_vente == "true")
                    {
                        notify.Image = Properties.Resources.info2;
                        notify.BodyColor = Color.Green;
                        notify.TitleText = "تم حفظ المبيعة بنجاح";
                        notify.TitleText =
                        notify.ContentText = "تم تسجيل الفاتورة بنجاح";
                        notify.Popup();
                    }
                    PlaySystemSound();

                }
                else
                {
                    MessageBox.Show("لاتوجد منتوجات لبيعها ");
                }
                clientCmb.DataSource = Bl_combobox.get_combo_client();
                clientCmb.DisplayMember = "Client";
                clientCmb.ValueMember = "ID";
            }



        }
        public decimal SumColumn(DataGridView dataGridView, string columnName)
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
            if (pourcentageRemise == null)
            {
                pourcentageRemise = "0";
            }
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
                                              IdFacture, cout_ttl, DgvType
                                              );
                    // Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit 
                }
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

        private void BTN9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هذا الخيار سيقوم بغلق النافذة", "غلق الواجهة  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Properties.Settings.Default.alert_facture_attend == "true")
                {
                    DataTable dt_attend = new DataTable();
                    dt_attend = class_facturation.get_facture_attend("فاتورة قيد الانتظار");
                    if (dt_attend.Rows.Count > 0)
                    {
                        MessageBox.Show("هناك فواتير معلقة لم تغلق بعد");
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }
        public void edit_fctr_termeinier()
        {
            if (pourcentageRemise == null)
            {
                pourcentageRemise = "0";
            }
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
                                              IdFacture, cout_ttl, DgvType
                                              );
                    // Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit 
                }
            }
        }

        private void BTN2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count > 0)
            {
                if (Typpped == "edit")
                {
                    classFnctionCaisse.delete_just_one_fctr_en_attend(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    //-----------------------------------------------------------------------------//
                    DeleteRowByCodeBarre(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    dataGridView1.Refresh();
                    GetTTL();
                    txtCount.Text = getCount().ToString();
                    if (dataGridView1.Rows.Count == 0)
                    {
                        LB_NAME.Text = string.Empty;
                        LB_QT.Text = "00";
                        LB_PRICE_U.Text = "00";
                        LB_TTL.Text = "00";
                    }
                    Load_facture_en_attend();
                    return;

                }
                else
                {
                    DeleteRowByCodeBarre(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    dataGridView1.Refresh();
                    GetTTL();
                    txtCount.Text = getCount().ToString();
                    if (dataGridView1.Rows.Count == 0)
                    {
                        LB_NAME.Text = string.Empty;
                        LB_QT.Text = "00";
                        LB_PRICE_U.Text = "00";
                        LB_TTL.Text = "00";
                    }
                    Load_facture_en_attend();
                    return;
                }

            }
            else
            {
                MessageBox.Show("لاتوجد منتوجات  لحذفها ");
            }

            txt_barcode.Focus();
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
                    if (Typpped == "edit")
                    {
                        //-------------------------------------------------------------//
                        classFnctionCaisse.delete_fctr_vente_product(txt_id_fctr.Text);
                        classFnctionCaisse.delete_fct_vente_edit(txt_id_fctr.Text);

                        //-------------------------------------------------------------//
                        DeleteRowByCodeBarre();
                        dataGridView1.Refresh();
                        GetTTL();
                        txtCount.Text = getCount().ToString();

                        //-------------------------------------------------------------//
                        Typpped = "";
                        if (dataGridView1.Rows.Count == 0)
                        {
                            LB_NAME.Text = string.Empty;
                            LB_QT.Text = "00";
                            LB_PRICE_U.Text = "00";
                            LB_TTL.Text = "00";
                        }

                        txt_barcode.Focus();
                        flowLayoutPanel2.Controls.Clear();
                        Load_facture_en_attend();
                        return;
                    }
                    else
                    {
                        DeleteRowByCodeBarre();
                        dataGridView1.Refresh();
                        GetTTL();
                        txtCount.Text = getCount().ToString();
                        if (dataGridView1.Rows.Count == 0)
                        {
                            LB_NAME.Text = string.Empty;
                            LB_QT.Text = "00";
                            LB_PRICE_U.Text = "00";
                            LB_TTL.Text = "00";
                        }
                        flowLayoutPanel2.Controls.Clear();
                        Load_facture_en_attend();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("الجدول فارغ");
                }

            }
            txt_barcode.Focus();
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

        private void BTN5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {

                if (Typpped == "edit")
                {
                    if (pourcentageRemise == null)
                    {
                        pourcentageRemise = "0";
                    }
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
                        "فاتورة قيد الانتظار",
                        id_user,
                        ID_caissier,
                        Sum_cout_ttl
                        );

                    classFnctionCaisse.delete_fctr_vente_product(txt_id_fctr.Text);
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
                                                      IdFacture, cout_ttl, DgvType
                                                      );
                            // Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit 
                        }
                    }
                    DeleteRowByCodeBarre();
                    dataGridView1.Refresh();
                    GetTTL();
                    txtCount.Text = getCount().ToString();
                    ChecK_And_print();
                    txt_id_fctr.Text = classVente.get_fctr_vnt();
                    Typpped = "add";
                    txt_barcode.Focus();

                    flowLayoutPanel2.Controls.Clear();
                    Load_facture_en_attend();
                }
                else
                {
                    pourcentageRemise = "0";
                    facture_non_terminer();
                    DeleteRowByCodeBarre();
                    dataGridView1.Refresh();
                    GetTTL();
                    txtCount.Text = getCount().ToString();
                    txt_id_fctr.Text = classVente.get_fctr_vnt();
                    flowLayoutPanel2.Controls.Clear();
                    Load_facture_en_attend();
                }

            }
            else
            {
                MessageBox.Show("الفاتورة فارغة لايمكن ارساله كفاتورة انتظار");
            }

            txt_barcode.Focus();
        }

        private void BTN7_Click(object sender, EventArgs e)
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
            txt_barcode.Focus();
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
                                              IdFacture, cout_ttl, DgvType
                                              );
                    // Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit 
                }
            }
            //MessageBox.Show("تم  تسجيل الفاتورة بنجاح");

        }

        private void BTN6_Click(object sender, EventArgs e)
        {
            frm_fctr_en_attende_caisse factr_en_attend = new frm_fctr_en_attende_caisse();
            factr_en_attend.frmVente = this;
            factr_en_attend.ShowDialog();
        }

        private void BTN8_Click(object sender, EventArgs e)
        {
            PLADD.PL_Statistique.frm_add_depense addDepense = new PLADD.PL_Statistique.frm_add_depense();
            addDepense.iduser = id_user;
            addDepense.ID_historique = ID_historique;
            addDepense.Caisse = this;
            addDepense.ShowDialog();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
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

                    LB_NAME.Text = designation;
                    LB_QT.Text = QT;
                    LB_PRICE_U.Text = priceU;
                    LB_TTL.Text = priceTTl;
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
                if (dataGridView1.Columns[e.ColumnIndex].Name == "dgvDellete")
                {
                    if (dataGridView1.Rows.Count > 0)
                    {

                        if (Typpped == "edit")
                        {
                            classFnctionCaisse.delete_just_one_fctr_en_attend(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
                            //-----------------------------------------------------------------------------//
                            DeleteRowByCodeBarre(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
                            dataGridView1.Refresh();
                            GetTTL();
                            txtCount.Text = getCount().ToString();
                            if (dataGridView1.Rows.Count == 0)
                            {
                                LB_NAME.Text = string.Empty;
                                LB_QT.Text = "00";
                                LB_PRICE_U.Text = "00";
                                LB_TTL.Text = "00";
                            }
                            return;

                        }
                        else
                        {
                            DeleteRowByCodeBarre(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
                            dataGridView1.Refresh();
                            GetTTL();
                            txtCount.Text = getCount().ToString();
                            if (dataGridView1.Rows.Count == 0)
                            {
                                LB_NAME.Text = string.Empty;
                                LB_QT.Text = "00";
                                LB_PRICE_U.Text = "00";
                                LB_TTL.Text = "00";
                            }
                            return;
                        }
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
                        changeInfo.formCaisse = this;
                        changeInfo.type = "A";
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
                                    //dataGridView1.Rows.Remove(row);
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
                                    DeleteRowByCodeBarre(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
                                    dataGridView1.Refresh();
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
                if (dataGridView1.Columns[e.ColumnIndex].Name == "DgvREMISE")
                {
                    frm_change_Price change_Price = new frm_change_Price();
                    change_Price.codebarre = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    change_Price.txt_price_product.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    DataTable Dtt  = caisseVente_classe.getSold_MAtier_revent(barcode); 
                    object price_Vente_min = Dtt.Rows[0][17];
                    change_Price.price_min = decimal.Parse(price_Vente_min.ToString());
                    change_Price.frmVente = this;
                    change_Price.ShowDialog();
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

                LB_NAME.Text = designation;
                LB_QT.Text = QT;
                LB_PRICE_U.Text = priceU;
                LB_TTL.Text = priceTTl;

                DataTable Dtt = caisseVente_classe.getSold_MAtier_revent(Codebarre);
                if (Dtt.Rows.Count > 0) // تحقق من وجود صفوف في الجدول
                {
                    DataRow row = Dtt.Rows[0]; // الحصول على الصف الأول
                    if (row[23] != DBNull.Value) // التحقق من أن العمود 23 يحتوي على قيمة
                    {
                        byte[] imageBytes = (byte[])row[23]; // استخراج البيانات كـ byte[]
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            picture_article.Image = Image.FromStream(ms); // عرض الصورة في PictureBox
                        }
                    }
                } 
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
                editFctr.frmVente = this;
                editFctr.ShowDialog();
            }
            else
            {
                MessageBox.Show("يرجى تحديد المنتوج");
            }
        }

        private void kryptonButton15_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.Rows.Count > 0)
            //{
            //	if (Typpped == "edit")
            //	{
            //		DateTime currentDateTime = DateTime.Now;


            //		edit_fctr_termeinier();
            //		DeleteRowByCodeBarre();
            //		dataGridView1.Refresh();
            //		GetTTL();
            //		txtCount.Text = getCount().ToString();
            //		txt_id_fctr.Text = classVente.get_fctr_vnt();

            //		Typpped = "add";
            //	}
            //	else
            //	{
            //		DateTime currentDateTime = DateTime.Now;


            //		Facture_terminer();
            //		DeleteRowByCodeBarre();
            //		dataGridView1.Refresh();
            //		GetTTL();
            //		txtCount.Text = getCount().ToString();
            //		txt_id_fctr.Text = classVente.get_fctr_vnt();
            //		Typpped = "add";
            //	}

            //}
            //else
            //{
            //	MessageBox.Show("لاتوجد منتوجات لبيعها ");
            //}
        }

        private void kryptonButton21_Click(object sender, EventArgs e)
        {
            frm_routour_ routeur_Article = new frm_routour_();
            routeur_Article.id_usser = id_user;
            routeur_Article.ID_CAISSIER = ID_caissier;
            routeur_Article.ID_historique = ID_historique;
            routeur_Article.form_caisse = this;
            routeur_Article.ShowDialog();
        }

        private void kryptodnButton6_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton24_Click(object sender, EventArgs e)
        {
            // إذا كانت هناك صفوف محددة
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // احصل على الفهرس الحالي للصف المحدد
                int currentIndex = dataGridView1.SelectedRows[0].Index;

                // إذا لم يكن الصف الأول
                if (currentIndex > 0)
                {
                    // قم بإلغاء تحديد الصف الحالي
                    dataGridView1.Rows[currentIndex].Selected = false;

                    // حدد الصف السابق
                    dataGridView1.Rows[currentIndex - 1].Selected = true;

                    // تعيين الصف المحدد كصف حالي
                    dataGridView1.CurrentCell = dataGridView1.Rows[currentIndex - 1].Cells[0];

                    // تأكد من أن الصف المحدد مرئي
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.SelectedRows[0].Index;

                    // استدعاء دالة تحديث التسميات
                    UpdateLabels();
                }
            }

            txt_barcode.Focus();
        }

        private void kryptonButton17_Click(object sender, EventArgs e)
        {
            // إذا كانت هناك صفوف محددة
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // احصل على الفهرس الحالي للصف المحدد
                int currentIndex = dataGridView1.SelectedRows[0].Index;

                // إذا لم يكن الصف الأخير
                if (currentIndex < dataGridView1.Rows.Count - 1)
                {
                    // قم بإلغاء تحديد الصف الحالي
                    dataGridView1.Rows[currentIndex].Selected = false;

                    // حدد الصف التالي
                    dataGridView1.Rows[currentIndex + 1].Selected = true;

                    // تعيين الصف المحدد كصف حالي
                    dataGridView1.CurrentCell = dataGridView1.Rows[currentIndex + 1].Cells[0];

                    // تأكد من أن الصف المحدد مرئي
                    dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.SelectedRows[0].Index;

                    // استدعاء دالة تحديث التسميات
                    UpdateLabels();
                }
            }

            txt_barcode.Focus();
        }

        private void kryptonButton23_Click(object sender, EventArgs e)
        {

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
                                //dataGridView1.Rows.Remove(row);
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
                                DeleteRowByCodeBarre(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
                                dataGridView1.Refresh();
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
            if (dataGridView1.Rows.Count > 0)
            {
                if (e.KeyCode == Keys.Down) // السهم للأسفل
                {
                    if (dataGridView1.CurrentRow.Index < dataGridView1.Rows.Count - 1)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index + 1].Cells[0];
                    }
                    e.Handled = true; // منع تكرار الحدث
                }
                else if (e.KeyCode == Keys.Up) // السهم للأعلى
                {
                    if (dataGridView1.CurrentRow.Index > 0)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index - 1].Cells[0];
                    }
                    e.Handled = true; // منع تكرار الحدث
                }
                // استدعاء دالة تحديث التسميات
                UpdateLabels();
            }
            GetTTL();
            txtCount.Text = getCount().ToString();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // التحقق مما إذا كان الصف محددًا
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // الحصول على الصف المحدد
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // التحقق مما إذا كان الصف يحتوي على خلية في العمود dgvQt
                if (selectedRow.Cells["dgvQt"].Value != null && int.TryParse(selectedRow.Cells["dgvQt"].Value.ToString(), out int cellValue))
                {
                    // التحقق من أن المستخدم ضغط على الزر "+" بجانب الضغط على Ctrl
                    if (Control.ModifierKeys == Keys.Control && e != null && e is KeyEventArgs && ((KeyEventArgs)e).KeyCode == Keys.Oemplus)
                    {
                        // زيادة القيمة في الخلية
                        selectedRow.Cells["dgvQt"].Value = cellValue + 1;
                    }
                }
            }
        }

        private void frm_vente_caisse_KeyDown(object sender, KeyEventArgs e)
        {

            // التحقق مما إذا كان المدخل رقمًا أو حرفًا

            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.Divide)
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
                    editFctr.frmVente = this;
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
                factr_en_attend.frmVente = this;
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
                stock_Detaille.VenteCaisse = this;
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
                    frm_Edit_By_Price.frmVente = this;
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

            // إذا كان الـ Text_Barcode ليس في وضع التركيز، أعد التركيز إليه
            //if (!txt_barcode.Focused)
            //{
            //    txt_barcode.Focus();
            //}
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
                                //dataGridView1.Rows.Remove(row);
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
                                DeleteRowByCodeBarre(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
                                dataGridView1.Refresh();
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
            if (e.Control && e.KeyCode == Keys.D)
            {
                frm_add_divers add_divers = new frm_add_divers();
                add_divers.formVente = this;
                add_divers.ShowDialog();
            }
            if (dataGridView1.Focused || dataGridView1.CanFocus)
            {
                if (e.KeyCode == Keys.Down) // السهم للأسفل
                {
                    if (dataGridView1.CurrentRow.Index < dataGridView1.Rows.Count - 1)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index + 1].Cells[0];
                    }
                    e.Handled = true; // منع تكرار الحدث
                }
                else if (e.KeyCode == Keys.Up) // السهم للأعلى
                {
                    if (dataGridView1.CurrentRow.Index > 0)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index - 1].Cells[0];
                    }
                    e.Handled = true; // منع تكرار الحدث
                }
            }
            //GetTTL();
            //txtCount.Text = getCount().ToString();
        }

        private void dataGridView1_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // التحقق من الحرف الأول إذا كان رقم
            // if (txt_barcode.Text.Length == 0 && char.IsDigit(e.KeyChar))
            // {
            //     txt_barcode.Clear(); // مسح النص
            // } 
            //if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            //{
            //	// منع الأحرف غير الرقمية من الظهور
            //	e.Handled = true;
            //}

            if (e.KeyChar == (char)Keys.Enter)
            {

                getinformation_matier_revent(barcode);
                txt_barcode.Clear(); // تنظيف الـ TextBox بعد استدعاء الدالة
                e.Handled = true; // منع إصدار الصوت
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

        private void kryptonButton1_Click_1(object sender, EventArgs e)
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
                frm_Edit_By_Price.frmVente = this;
                frm_Edit_By_Price.ShowDialog();
            }
            else
            {
                MessageBox.Show("يرجى تحديد المنتوج");
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LB_Date.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            try {
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

        private void detail_Stcoketton12_Click_1(object sender, EventArgs e)
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
                stock_Detaille.VenteCaisse = this;
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

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            //if(dataGridView1.HitTest(e.X , e.Y).Type == DataGridViewHitTestType.ColumnHeader ||
            //	dataGridView1.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.TopLeftHeader)
            //{
            //	ContextMenu menu = new ContextMenu();

            //	//add item to the menu
            //	foreach(DataGridViewColumn column in dataGridView1.Columns)
            //	{
            //		MenuItem item = new MenuItem();
            //		item.Text = column.HeaderText;
            //		item.Checked = column.Visible;

            //		//now let add the event if the item was cheked
            //		item.Click += (obj, ea) =>
            //		{
            //			column.Visible = !item.Checked;

            //			//update the check
            //			item.Checked = column.Visible;

            //                     //show the selection item 
            //                     menu.Show(dataGridView1, e.Location);
            //                 };
            //		menu.MenuItems.Add(item);
            //	}
            //	//show the menu 
            //	menu.Show(dataGridView1, e.Location);

            //}
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            flowCategories.Controls.Clear();
            flowLayoutPanel4.Controls.Clear();
            flowLAyoutProduct.Controls.Clear();
            Load_facture_en_attend();
            loadFav();
            loadFav2();
            loadProduct(1);
            loadPack(1);
        }

        private void lb_Total_Click(object sender, EventArgs e)
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

        private void remise(object sender, EventArgs e)
        {
            frm_remise addRemise = new frm_remise();
            addRemise.txt_price_product.Text = lb_Total.Text;
            addRemise.formVentePrincipale = this;
            addRemise.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_add_client addClient = new frm_add_client();
            addClient.Type = "A";
            addClient.vente_Caisse = this;
            addClient.ShowDialog();
        }

        private void إضافةالىالمفضلةToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void اضافةمنتجاتمباشرةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Add_stock_sans_facture addstock = new frm_Add_stock_sans_facture();
            addstock.ShowDialog();
        }

        private void فاتورةشراءToolStripMenuItem_Click(object sender, EventArgs e)
        {

            PL.Achat_revente.frm_facture frmachat = new PL.Achat_revente.frm_facture();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][16];
                facture_achat = Convert.ToInt32(stock);

            }
            if (facture_achat == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frmachat.pn_fctre);

            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void kءءryptonButton16_Click(object sender, EventArgs e)
        {
            PL.vente.frm_list_vente frm_fctr = new PL.vente.frm_list_vente();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][22];
                list_vente = Convert.ToInt32(stock);

            }
            if (list_vente == 1)
            {
                frm_fctr.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_fctr.WindowState = FormWindowState.Maximized;
                frm_fctr.ShowDialog();
                //change_color_whene_click(button1);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void kryptoءءnButton21_Click(object sender, EventArgs e)
        {
            PL.vente.frm_facture_vente frm_fctr = new PL.vente.frm_facture_vente();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(id_user);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][21];
                facture_vente = Convert.ToInt32(stock);

            }
            if (facture_vente == 1)
            {
                frm_fctr.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_fctr.WindowState = FormWindowState.Maximized;
                frm_fctr.ShowDialog();
                //change_color_whene_click(button1);
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

        private void تعديلكميةToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void البيعبالسعرToolStripMenuItem_Click(object sender, EventArgs e)
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
                frm_Edit_By_Price.frmVente = this;
                frm_Edit_By_Price.ShowDialog();
            }
            else
            {
                MessageBox.Show("يرجى تحديد المنتوج");
            }
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

        private void versement_Click(object sender, EventArgs e)
        {
            PLADD.vente.frm_historique_client add_historique_client = new PLADD.vente.frm_historique_client();
            add_historique_client.Type = "A";
            add_historique_client.cmb_frnsre.Text = this.clientCmb.Text;
            add_historique_client.caisse = this;
            add_historique_client.ShowDialog();
        }

        private void detailles_lisT_vente_Click(object sender, EventArgs e)
        {
            PL.vente.frm_list_vente_credit_client list_credit = new PL.vente.frm_list_vente_credit_client();
            list_credit.Text = "تفاصيل الشراء للزبون " + " ( " + clientCmb.Text + " )";
            list_credit.dataGridView1.DataSource = classvente.get_list_vente_credit_client("فاتورة مكتملة", Convert.ToInt32(clientCmb.SelectedValue));
            list_credit.Show();
        }

        private void krypctonButton2_Click(object sender, EventArgs e)
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
                                //dataGridView1.Rows.Remove(row);
                                DeleteRowByCodeBarre(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
                                dataGridView1.Refresh();
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

        private void frm_vente_caisse_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar))
            //{
            //    barcoder += e.KeyChar; // إضافة المدخل إلى متغير الباركود
            //}

            //// عند الضغط على Enter
            //if (e.KeyChar == (char)Keys.Enter && barcoder.Length > 0)
            //{
            //    txt_barcode.Text = barcoder; // إدخال الباركود في الـ TextBox
            //    barcoder = ""; // تفريغ المتغير بعد الإدخال
            //    e.Handled = true; // منع الإجراءات الافتراضية الأخرى
            //}
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

        private void krydptonButton5_Click(object sender, EventArgs e)
        {
            txt_id_fctr.Text = classVente.get_fctr_vnt();
        }

        private void kryptonButton4_Click_1(object sender, EventArgs e)
        {
            //txt_barcode.Clear();
            Process.Start("osk.exe");
        }

        private void kryptonButton14_Click_1(object sender, EventArgs e)
        {

        }

        private void kryptonButton15_Click_1(object sender, EventArgs e)
        {


        }
        public void LoadFactureDetails(string factureID)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable dt = DAL.SelectData("GetVenteDetails", new SqlParameter[] { new SqlParameter("@facteure", factureID) });
            DAL.Close();

            // Clear existing rows
            dataGridView1.Rows.Clear();

            // Loop through the DataTable and add rows to DataGridView
            foreach (DataRow row in dt.Rows)
            {
                int rowIndex = dataGridView1.Rows.Add();  // Add a new row and get its index

                // Fill in the row's cells with data from DataTable 
                dataGridView1.Rows[rowIndex].Cells["DgvCodeBarre"].Value = row["Code-barre"].ToString();  // Column for Code-barre
                dataGridView1.Rows[rowIndex].Cells["dgvName"].Value = row["Designation"].ToString();  // Column for Designation
                dataGridView1.Rows[rowIndex].Cells["dgvQt"].Value = Convert.ToInt32(row["Qt"]);
                dataGridView1.Rows[rowIndex].Cells["dgvAmount"].Value = Convert.ToDecimal(row["Prixe U"]);
                dataGridView1.Rows[rowIndex].Cells["dgbTtl"].Value = Convert.ToDecimal(row["Prixe TTL"]);
                // Column for Total Price (Prixe TTL)

                // Determine the product type (P or U)
                string codeBarre = row["Code-barre"].ToString();
                if (IsPackProduit(codeBarre))  // This is a method to check if it's from TB_PACK_PRODUIT_REVENT
                {
                    dataGridView1.Rows[rowIndex].Cells["DgvType"].Value = "P";  // Set type to 'P' for Pack
                }
                else
                {
                    dataGridView1.Rows[rowIndex].Cells["DgvType"].Value = "U";  // Set type to 'U' for regular product
                }
            }
        }

        // Method to determine if the CodeBarre comes from TB_PACK_PRODUIT_REVENT
        private bool IsPackProduit(string codeBarre)
        {
            // Implement logic to check if codeBarre is from TB_PACK_PRODUIT_REVENT.
            // For example, query the TB_PACK_PRODUIT_REVENT table or check if the code follows certain patterns.
            // Here you can just return a dummy check:
            // return true if codeBarre is in TB_PACK_PRODUIT_REVENT.
            return codeBarre.StartsWith("P");  // Example check, modify this based on your data.
        }


        private void kryptonButton18_Click(object sender, EventArgs e)
        {
            //int nmr_Fct = Convert.ToInt32(txt_id_fctr.Text);
            //int nmr_now = nmr_Fct + 1;
            //txt_id_fctr.Text = nmr_now.ToString();
        }

        private void frm_vente_caisse_Activated(object sender, EventArgs e)
        {

            //this.txt_barcode.Focus();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // افحص إذا كان الـ DataGridView فارغًا بعد تحديث البيانات
            if (dataGridView1.Rows.Count == 0)
            {
                LB_NAME.Text = string.Empty;
                LB_QT.Text = "00";
                LB_PRICE_U.Text = "00";
                LB_TTL.Text = "00";
            }
        }

        private void txt_barcode_MouseLeave(object sender, EventArgs e)
        {
            //txt_barcode.Focus();
            if (!cmbProduct.Focused)
            {
                txt_barcode.Focus();
            }
        }

        private void txt_barcode_Leave(object sender, EventArgs e)
        {
            //txt_barcode.Focus();
        }

        private void txt_barcode_MouseLeave_1(object sender, EventArgs e)
        {
            //if (!cmbProduct.Focused)
            //{
            //    txt_barcode.Focus();
            //}
        }

        private void txt_barcode_KeyPress_1(object sender, KeyPressEventArgs e)
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
                
                getinformation_matier_revent(bar);
                txt_qt.Text = "1";
                txt_barcode.Clear(); // تنظيف الـ TextBox بعد استدعاء الدالة
                e.Handled = true; // منع إصدار الصوت
            }
        }
     

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["DgvType"].Value.ToString() == "U")
            {
                frm_code_barre_reserve frmCode = new frm_code_barre_reserve();
                frmCode.txt_officale_barCode.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                frmCode.Show();
            }
            else
            {
                frm_pack_reserver_code_barre frmCode = new frm_pack_reserver_code_barre();
                frmCode.codeBarre_produit = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                frmCode.Show();
            } 
        }

        private void kryptonButton14_Click_2(object sender, EventArgs e)
        {

            if (Properties.Settings.Default.form_confirme_bon == "true")
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    frm_confirme_bon form_bon = new frm_confirme_bon();
                    form_bon.txt_versement.Text = txt_Versement.Text;
                    form_bon.txt_ttl_fctr.Text = lb_Total.Text;
                    form_bon.txt_retour.Text = lb_rest.Text;
                    form_bon.txt_client.Text = clientCmb.Text;
                    form_bon.txt_user.Text = "";
                    form_bon.txt_caissier.Text = "";
                    form_bon.txt_nmr_bon.Text = txt_id_fctr.Text;
                    form_bon.Typpped = Typpped;
                    form_bon.lb_historique_credit.Text = lb_historique_credit.Text;
                    form_bon.txt_vlr_remise.Text = lbl_prix_remisier.Text;
                    form_bon.txt_originale_praix.Text = lbl_price_off.Text;

                    form_bon.Count = int.Parse(this.txtCount.Text);
                    form_bon.id_client = Convert.ToInt32(this.clientCmb.SelectedValue);
                    form_bon.id_user = this.id_user;
                    form_bon.ID_caissier = this.ID_caissier;
                    form_bon.form_caisse = this;
                    form_bon.ShowDialog();

                }
            }
            else
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
                        print_bon();
                        txt_id_fctr.Text = classVente.get_fctr_vnt();
                        Typpped = "add";
                        txt_barcode.Focus();

                        flowLayoutPanel2.Controls.Clear();
                        Load_facture_en_attend();
                    }
                    else
                    {
                        DateTime currentDateTime = DateTime.Now;
                        Facture_terminer();
                        DeleteRowByCodeBarre();
                        dataGridView1.Refresh();
                        GetTTL();
                        txtCount.Text = getCount().ToString();
                        print_bon();
                        txt_id_fctr.Text = classVente.get_fctr_vnt();
                        Typpped = "add";
                        txt_barcode.Focus(); 
                        flowLayoutPanel2.Controls.Clear();
                        Load_facture_en_attend();
                    }
                    //PopupNotifier notify = new PopupNotifier();
                    if (Properties.Settings.Default.notif_vente == "true")
                    {
                        notify.Image = Properties.Resources.info2;
                        notify.BodyColor = Color.Green;
                        notify.TitleText = "تم حفظ المبيعة بنجاح";
                        notify.TitleText =
                        notify.ContentText = "تم تسجيل الفاتورة بنجاح";
                        notify.Popup();
                    }
                    PlaySystemSound();

                }
                else
                {
                    MessageBox.Show("لاتوجد منتوجات لبيعها ");
                }
                clientCmb.DataSource = Bl_combobox.get_combo_client();
                clientCmb.DisplayMember = "Client";
                clientCmb.ValueMember = "ID";
            }
        }

        private void ADD_PRODUCT1_Click(object sender, EventArgs e)
        {
            frm_add_produit_simple addstock = new frm_add_produit_simple();
            addstock.ShowDialog();
        }

        private void txt_barcode_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod)
            {
                // التحقق من أن النص المدخل في txtPriceU هو رقم صالح (السعر)
                if (decimal.TryParse(txt_barcode.Text, out decimal price))
                {
                    // إضافة صف جديد في DataGridView مع السعر المدخل
                    dataGridView1.Rows.Add(new object[] { 0, "منتج غير معروف", "منتج غير معروف", 1, txt_barcode.Text, txt_barcode.Text, "D" });

                    // تحديث إجمالي المبيعات
                    GetTTL();

                    // تحديث العدد الإجمالي
                    txtCount.Text = getCount().ToString();

                    // تنظيف الـ TextBox بعد الإدخال
                    txt_barcode.Clear();
                    // تركيز النص على الـ TextBox مرة أخرى
                    txt_barcode.Focus();
                    txt_barcode.Text = "";
                    e.Handled = true;
                }
                else
                {
                    // إذا لم يكن النص رقماً صالحاً، عرض رسالة خطأ (اختياري)
                    MessageBox.Show("الرجاء إدخال سعر صالح.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Handled = true;
                }
                 
            }
        }

        private void kryptonButton20_Click(object sender, EventArgs e)
        {
            frm_help_caisse caissehelp = new frm_help_caisse();
            caissehelp.Show();
        }

        private void ADD_X_PRODUCT1_Click(object sender, EventArgs e)
        {
            frm_add_produit_editable frm_add = new frm_add_produit_editable();
            frm_add.ShowDialog();
        }
        private void ChargerListeFactures()
        {
            listeFactures = factureManager.GetListeFacturesDesc(); 
            if (listeFactures.Count > 0)
            {
                currentIndex = 0; 
            }
        }
        private void kءءrypnButton16_Click(object sender, EventArgs e)
        {
            ChargerListeFactures();
            if (currentIndex   < listeFactures.Count)
            {
                currentIndex++; 
                frm_edit_bon edit = new frm_edit_bon();
                edit.ID_bon = listeFactures[0];
                edit.ShowDialog();
            }
            else
            {
                MessageBox.Show("وصلت لأول فاتورة.");
            }
        }
    }
}

