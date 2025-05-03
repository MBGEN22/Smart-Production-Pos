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
using Azure;
using ComponentFactory.Krypton.Toolkit;
using iTextSharp.text.pdf;
using Smart_Production_Pos.BL;
using Smart_Production_Pos.BL.BL_FICHIER;
using Smart_Production_Pos.PLADD.vente;

namespace Smart_Production_Pos.PL.vente
{
    public partial class frm_edit_bon : Form
    {
        BL.BL_vente.Bl_fctr_vente factureManager = new BL.BL_vente.Bl_fctr_vente();
        BL.BL_vente.BL_FACTURE_VENTE class_facture_vente = new BL.BL_vente.BL_FACTURE_VENTE();
        BL.BL_vente.Bl_edit_bon class_edit_bon = new BL.BL_vente.Bl_edit_bon();
        BL.BL_CAISSE caisseVente_classe = new BL.BL_CAISSE();
        BL.BL_COMBOBOX Bl_combobox = new BL.BL_COMBOBOX();
        BL.BL_vente.BL_DELETE_FCTR classDelete = new BL.BL_vente.BL_DELETE_FCTR();
        BL.BL_vente.BL_vente_Fonction classVente = new BL.BL_vente.BL_vente_Fonction();
        BL.Client_history_sold historique_Client = new BL.Client_history_sold();
        BL.BL_vente.BL_SP_LOGINE_Caisse classCaisse = new BL.BL_vente.BL_SP_LOGINE_Caisse();
        BL.BL_vente.bl_diminuer_la_Qt_vente classQt_vente = new BL.BL_vente.bl_diminuer_la_Qt_vente();
        BL.BL_parametre.BL_paramtre_informatiion class_setting = new BL.BL_parametre.BL_paramtre_informatiion();
        Sp_Logine classLogine = new Sp_Logine();
        public string ID_bon; 
        public string barcode;
        public string NamePO;
        public string reference;
        public decimal Price;
        public string pourcentageRemise;
        public int ID_historique; 
        public int ID_caissier;
        string barcodee;
        int list_vente;
        int facture_vente;
        public int id_user;
        Object price_Vente;
        List<string> listeFactures = new List<string>();
        int currentIndex = 0;
        DataTable dt_list_vente = new DataTable();
        public frm_edit_bon()
        {
            InitializeComponent(); 
            clientCmb.DataSource = Bl_combobox.get_combo_client();
            clientCmb.DisplayMember = "Client";
            clientCmb.ValueMember = "ID"; 
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
        }
        private void ChargerListeFactures()
        {
            listeFactures = factureManager.GetListeFacturesDesc();

            if (listeFactures.Count > 0)
            {
                currentIndex = 0;
                txt_id_fctr.Text = listeFactures[currentIndex];
            }
        }
        private void frm_edit_bon_Load(object sender, EventArgs e)
        {
            ChargerListeFactures();
            get_the_bon(ID_bon);
        }
        private void get_the_bon(string id_bn)
        {
            DataTable dt_info = class_edit_bon.get_information_bon(id_bn);
            object NMR_FACTURE = dt_info.Rows[0][0].ToString();
            object DATE = dt_info.Rows[0][1].ToString();
            object HEURE = dt_info.Rows[0][2].ToString();
            object ID_CLIENT = dt_info.Rows[0][3].ToString();
            object TOTAL_FACURE_TTC = dt_info.Rows[0][4].ToString();
            object TOTAL_FACTURE_HT = dt_info.Rows[0][5].ToString();
            object TVA = dt_info.Rows[0][6].ToString();
            object OLD_SOLD = dt_info.Rows[0][7].ToString();
            object VERSEMENT = dt_info.Rows[0][8].ToString();
            object NEW_SOLD = dt_info.Rows[0][9].ToString();
            object REMISE = dt_info.Rows[0][10].ToString();
            object POURSENTAGE_REMISE = dt_info.Rows[0][11].ToString();
            object COUNT_ARTICLE = dt_info.Rows[0][12].ToString();
            object REMARQUE = dt_info.Rows[0][13].ToString();
            object ETAT = dt_info.Rows[0][14].ToString();
            object ID_USER = dt_info.Rows[0][15].ToString();
            object ID_CAISSIER = dt_info.Rows[0][16].ToString();
            object cout_of_fctr = dt_info.Rows[0][17].ToString();
            object tmbre = dt_info.Rows[0][18].ToString();
            object pricearabe = dt_info.Rows[0][19].ToString();

            ID_caissier = Convert.ToInt32(ID_CAISSIER.ToString());
            id_user = Convert.ToInt32(ID_USER.ToString());
            lb_historique_credit.Text = OLD_SOLD.ToString();
            lb_new_credit.Text = NEW_SOLD.ToString();
            pourcentageRemise = POURSENTAGE_REMISE.ToString();
            txtCount.Text = COUNT_ARTICLE.ToString();
            txt_id_fctr.Text = NMR_FACTURE.ToString();
            dateTimetxt.Value = Convert.ToDateTime(DATE.ToString());
            clientCmb.SelectedValue = ID_CLIENT.ToString();
            lb_Total.Text = TOTAL_FACURE_TTC.ToString();
            txt_Versement.Text = VERSEMENT.ToString();
            lbl_prix_remisier.Text = REMISE.ToString();
            double price_org = double.Parse(TOTAL_FACURE_TTC.ToString()) + double.Parse(REMISE.ToString());
            lbl_price_off.Text = price_org.ToString();

            dataGridView1.DataSource = class_edit_bon.get_vente_dtl(id_bn);
            dt_list_vente = class_edit_bon.get_vente_dtl(id_bn);
            //dataGridView1.Columns["التكلفة"].Visible = false;
            //dataGridView1.Columns["النوع"].Visible = false;
            //dataGridView1.Columns["رقم المنتوج"].Visible = false;

            // التأكد من أن الأعمدة غير مكررة
            if (!dataGridView1.Columns.Contains("dgvEdit"))
            {
                // عمود تعديل
                DataGridViewImageColumn dgvEdit = new DataGridViewImageColumn();
                dgvEdit.HeaderText = "تعديل";
                dgvEdit.Image = global::Smart_Production_Pos.Properties.Resources.bouton_modifier;
                dgvEdit.Name = "dgvEdit";
                dgvEdit.Width = 55;
                dataGridView1.Columns.Add(dgvEdit);
            }

            if (!dataGridView1.Columns.Contains("dgvDellete"))
            {
                // عمود حذف
                DataGridViewImageColumn dgvDellete = new DataGridViewImageColumn();
                dgvDellete.HeaderText = "حذف";
                dgvDellete.Image = global::Smart_Production_Pos.Properties.Resources.marque_de_croix;
                dgvDellete.Name = "dgvDellete";
                dgvDellete.Width = 52;
                dataGridView1.Columns.Add(dgvDellete);
            }

            if (!dataGridView1.Columns.Contains("DgvEditPrice"))
            {
                // تعديل السعر (مخفي)
                DataGridViewImageColumn DgvEditPrice = new DataGridViewImageColumn();
                DgvEditPrice.HeaderText = "تعديل السعر";
                DgvEditPrice.Image = global::Smart_Production_Pos.Properties.Resources.etiqueter;
                DgvEditPrice.Name = "DgvEditPrice";
                DgvEditPrice.Width = 96;
                DgvEditPrice.Visible = false;
                dataGridView1.Columns.Add(DgvEditPrice);
            }
             
            if (!dataGridView1.Columns.Contains("DgvREMISE"))
            {
                // عمود خصم
                DataGridViewImageColumn DgvREMISE = new DataGridViewImageColumn();
                DgvREMISE.HeaderText = "خصم";
                DgvREMISE.Image = global::Smart_Production_Pos.Properties.Resources.remise;
                DgvREMISE.Name = "DgvREMISE";
                DgvREMISE.Width = 51;
                dataGridView1.Columns.Add(DgvREMISE);
            }

            // إعادة ترتيب الأعمدة لتكون الأزرار في الأخير
            int lastIndex = dataGridView1.Columns.Count - 1;
            dataGridView1.Columns["dgvEdit"].DisplayIndex = lastIndex - 3;
            dataGridView1.Columns["dgvDellete"].DisplayIndex = lastIndex - 2;
            dataGridView1.Columns["DgvREMISE"].DisplayIndex = lastIndex - 1;
            //dataGridView1.Columns["DgvPack"].DisplayIndex = lastIndex - 1;

            select_last_rows();
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
                 
                string designation = dataGridView1.Rows[lastRowIndex].Cells["اسم المنتوج"].Value.ToString();
                string QT = dataGridView1.Rows[lastRowIndex].Cells["كمية المنتوج"].Value.ToString();
                string priceU = dataGridView1.Rows[lastRowIndex].Cells["سعر البيع"].Value.ToString();
                string priceTTl = dataGridView1.Rows[lastRowIndex].Cells["السعر الكلي"].Value.ToString();

                // تعيين القيم إلى العناصر المراد عرضها فيها
                LB_NAME.Text = designation;
                LB_QT.Text = QT;
                LB_PRICE_U.Text = priceU;
                LB_TTL.Text = priceTTl; 
            }

        }
        private void btn1_Click(object sender, EventArgs e)
        {
            DataTable dt_facture = new DataTable();
            dt_facture = classDelete.get_tb_fctr_vente(txt_id_fctr.Text);
            object id_client = dt_facture.Rows[0][3];
            object total_ttc = dt_facture.Rows[0][4];
            object versement = dt_facture.Rows[0][8];
             
            //DELETE_HISTORIQUE
            classDelete.DELETE_HISTORIQUE_CLIENT_BY_ID_FCTR(txt_id_fctr.Text, "سند جديد");
            //DELETE_FACTURE_VENTE
            classDelete.DELETE_FACTURE_VENTE(txt_id_fctr.Text);

            foreach (DataRow row in dt_list_vente.Rows)
            {
                if (!string.IsNullOrWhiteSpace(row["رقم المنتوج"].ToString()))
                {
                    string produitId = row["رقم المنتوج"].ToString();
                    float quantite = float.Parse(row["كمية المنتوج"].ToString());

                    DataTable Dt_produit = caisseVente_classe.getSold_MAtier_revent(produitId);
                    if (Dt_produit.Rows.Count > 0)
                    {
                        classDelete.rectefier_after_vente(produitId, quantite);
                    }
                    else
                    {
                        DataTable dt_pack = classDelete.get_pack_liee_with_product(produitId);
                        if (dt_pack.Rows.Count > 0)
                        {
                            object codeBarre_produit = dt_pack.Rows[0][1];
                            object qt_dans_pack = dt_pack.Rows[0][3];
                            float Qt_ttl = float.Parse(qt_dans_pack.ToString()) * quantite;
                            string code_pr = codeBarre_produit.ToString();
                            classDelete.rectefier_after_vente(code_pr, Qt_ttl);
                        }
                    }
                }
            } 
            classDelete.insert_hitorique(
                $"قام المستخدم {id_user} بتعديل الفاتورة رقم {txt_id_fctr.Text}",
                DateTime.Today,
                DateTime.Now.TimeOfDay
            );
            reconfimre_bon();
        }

        public  void reconfimre_bon()
        {
            DateTime currentDateTime = DateTime.Now;
            Facture_terminer();
            DeleteRowByCodeBarre();
            dataGridView1.Refresh();
            GetTTL();
            txtCount.Text = getCount().ToString();
            ChecK_And_print();  
            this.Close();
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
            decimal Sum_cout_ttl = SumColumn(dataGridView1, "التكلفة");
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
                    string codeBarrePRoduit = row.Cells["رقم المنتوج"].Value.ToString();
                    float Quantitevente = float.Parse(row.Cells["كمية المنتوج"].Value.ToString());
                    decimal PrixVente = decimal.Parse(row.Cells["سعر البيع"].Value.ToString());
                    decimal PrixTotal = decimal.Parse(row.Cells["السعر الكلي"].Value.ToString());
                    decimal cout_ttl = decimal.Parse(row.Cells["التكلفة"].Value.ToString());
                    string DgvType = row.Cells["النوع"].Value.ToString();

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
        public void delte_qt_matier()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Récupérez les valeurs nécessaires de la ligne actuelle du DataGridView
                    string idProduit = row.Cells["رقم المنتوج"].Value.ToString();
                    DataTable Dt = new DataTable();
                    Dt = caisseVente_classe.getSold_MAtier_revent(idProduit);
                    if (Dt.Rows.Count > 0)
                    {
                        Object codeBarre = Dt.Rows[0][0];
                        Object name_product = Dt.Rows[0][1];
                        Object price_Vente = Dt.Rows[0][15];
                        Object Quanite_dans_pack = Dt.Rows[0][24];
                        Object price_achat_produit_revent = Dt.Rows[0][12];
                        float quantite_vnt = float.Parse(row.Cells["كمية المنتوج"].Value.ToString()); // Assurez-vous de remplacer "nouvelle_quantite" par le nom réel de la colonne 
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
                            float quantite_vnt = float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
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
            this.Close();
        }
        public void GetTTL()
        {
            double ttl = 0;
            lb_Total.Text = "0";
            lbl_price_off.Text = "0";

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells["السعر الكلي"].Value != null)
                {
                    double cellValue;
                    // Try to parse the cell value to double
                    if (double.TryParse(row.Cells["السعر الكلي"].Value.ToString(), out cellValue))
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dataGridView1.Columns[e.ColumnIndex].Name == "dgvEdit")
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        frm_edit_Qt_facture_for_caisse editFctr = new frm_edit_Qt_facture_for_caisse();
                        editFctr.txtBox.Text = this.dataGridView1.CurrentRow.Cells["كمية المنتوج"].Value.ToString();
                        editFctr.type = this.dataGridView1.CurrentRow.Cells["النوع"].Value.ToString();
                        editFctr.codebarre = this.dataGridView1.CurrentRow.Cells["رقم المنتوج"].Value.ToString();

                        if (this.dataGridView1.CurrentRow.Cells[6].Value.ToString() == "P")
                        {
                            string CodeBarrre = this.dataGridView1.CurrentRow.Cells["رقم المنتوج"].Value.ToString();
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
                            barcode = this.dataGridView1.CurrentRow.Cells["رقم المنتوج"].Value.ToString();
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
                        editFctr.edit_bn = this;
                        editFctr.Type = "edit";
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
                    DeleteRowByCodeBarre(this.dataGridView1.CurrentRow.Cells["رقم المنتوج"].Value.ToString());
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
                if (dataGridView1.Columns[e.ColumnIndex].Name == "DgvREMISE")
                {
                    frm_change_Price change_Price = new frm_change_Price();
                    change_Price.codebarre = this.dataGridView1.CurrentRow.Cells["رقم المنتوج"].Value.ToString();
                    change_Price.txt_price_product.Text = this.dataGridView1.CurrentRow.Cells["السعر الكلي"].Value.ToString();
                    DataTable Dtt = caisseVente_classe.getSold_MAtier_revent(barcode);
                    object price_Vente_min = Dtt.Rows[0][17];
                    change_Price.price_min = decimal.Parse(price_Vente_min.ToString());
                    change_Price.frm_edit_bon = this;
                    change_Price.Typee = "edit";
                    change_Price.ShowDialog();
                }
            }
            catch
            {

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
                            var cellValue = row.Cells["رقم المنتوج"].Value;

                            // Check if the cell value is not null before comparison
                            if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                            {
                                row.Cells["كمية المنتوج"].Value = (int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) + 1).ToString();
                                row.Cells["السعر الكلي"].Value = int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                        decimal.Parse(row.Cells["سعر البيع"].Value.ToString());
                                row.Cells["التكلفة"].Value = int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                        decimal.Parse(cout_produire_pack_favrique.ToString());
                                GetTTL();
                                txtCount.Text = getCount().ToString();
                                txt_barcode.Focus();
                                select_last_rows();

                                return;
                            }
                        }
                    }
                     
                    DataTable dt = (DataTable)dataGridView1.DataSource;

                    DataRow newRow = dt.NewRow();
                    newRow["رقم المنتوج"] = codeBarre.ToString();
                    newRow["اسم المنتوج"] = name_product.ToString();
                    newRow["كمية المنتوج"] = txt_qt.Text;
                    newRow["سعر البيع"] = price_Vente.ToString();
                    newRow["السعر الكلي"] = decimal.Parse(price_Vente.ToString()) * decimal.Parse(txt_qt.Text);
                    newRow["التكلفة"] = decimal.Parse(cout_produire_pack_favrique.ToString()) * (decimal.Parse(txt_qt.Text));
                    newRow["النوع"] = "P";

                    dt.Rows.Add(newRow); 


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
                                        var cellValue = row.Cells["رقم المنتوج"].Value;

                                        // Check if the cell value is not null before comparison
                                        if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                        {
                                            row.Cells["كمية المنتوج"].Value = (int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) + 1).ToString();
                                            row.Cells["السعر الكلي"].Value = int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                                    decimal.Parse(row.Cells["سعر البيع"].Value.ToString());
                                            row.Cells["التكلفة"].Value = int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                decimal.Parse(price_achat_produit_revent.ToString());
                                            GetTTL();
                                            txtCount.Text = getCount().ToString();
                                            return;
                                        }
                                    }
                                }
                                check_date_periptition(date_pérétion); 
                                DataTable dt = (DataTable)dataGridView1.DataSource;

                                DataRow newRow = dt.NewRow();
                                newRow["رقم المنتوج"] = codeBarre.ToString();
                                newRow["اسم المنتوج"] = name_product.ToString();
                                newRow["كمية المنتوج"] = txt_qt.Text;
                                newRow["سعر البيع"] = price_Vente.ToString();
                                newRow["السعر الكلي"] = decimal.Parse(price_Vente.ToString()) * decimal.Parse(txt_qt.Text);
                                newRow["التكلفة"] = (decimal.Parse(price_achat_produit_revent.ToString()) * (decimal.Parse(txt_qt.Text)));
                                newRow["النوع"] = "P";

                                dt.Rows.Add(newRow);
                            }
                        }
                        else
                        {
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    var cellValue = row.Cells["رقم المنتوج"].Value;

                                    // Check if the cell value is not null before comparison
                                    if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                    {
                                        row.Cells["كمية المنتوج"].Value = (int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) + 1).ToString();
                                        row.Cells["السعر الكلي"].Value = int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                                decimal.Parse(row.Cells["سعر البيع"].Value.ToString());
                                        row.Cells["التكلفة"].Value = int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
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
                             
                            DataTable dt = (DataTable)dataGridView1.DataSource;

                            DataRow newRow = dt.NewRow();
                            newRow["رقم المنتوج"] = codeBarre.ToString();
                            newRow["اسم المنتوج"] = name_product.ToString();
                            newRow["كمية المنتوج"] = txt_qt.Text;
                            newRow["سعر البيع"] = price_Vente.ToString();
                            newRow["السعر الكلي"] = decimal.Parse(price_Vente.ToString()) * decimal.Parse(txt_qt.Text);
                            newRow["التكلفة"] = (decimal.Parse(price_achat_produit_revent.ToString()) * (decimal.Parse(txt_qt.Text)));
                                newRow["النوع"] = "U";

                            dt.Rows.Add(newRow);
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
                                var cellValue = row.Cells["رقم المنتوج"].Value;

                                // Check if the cell value is not null before comparison
                                if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                {
                                    row.Cells["كمية المنتوج"].Value = (int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) + 1).ToString();
                                    row.Cells["السعر الكلي"].Value = int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                            decimal.Parse(row.Cells["سعر البيع"].Value.ToString());
                                    row.Cells["التكلفة"].Value = int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
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
                        DataTable dt = (DataTable)dataGridView1.DataSource;

                        DataRow newRow = dt.NewRow();
                        newRow["رقم المنتوج"] = codeBarre.ToString();
                        newRow["اسم المنتوج"] = name_product.ToString();
                        newRow["كمية المنتوج"] = txt_qt.Text;
                        newRow["سعر البيع"] = price_Vente.ToString();
                        newRow["السعر الكلي"] = decimal.Parse(price_Vente.ToString()) * decimal.Parse(txt_qt.Text);
                        newRow["التكلفة"] = decimal.Parse(price_achat_produit_revent.ToString()) * decimal.Parse(txt_qt.Text);
                        newRow["النوع"] = "U";

                        dt.Rows.Add(newRow);

                        txt_barcode.Focus();
                        select_last_rows();
                    }
                }
            }
          
             
            GetTTL();
            txtCount.Text = getCount().ToString();
            txt_qt.Text = "1";
            txt_barcode.Focus();
            select_last_rows();
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
                    if (Properties.Settings.Default.chech_date_pereprtion == "true")
                    {
                        MessageBox.Show(" المنتج قريب من تاريخ نهاية الصلاحية او قد انتهت صلاحيته يرجى التحقق !");
                    }
                }
            }
        }

        private void pack_check_produit_revent_CheckedChanged(object sender, EventArgs e)
        {
            cmbProduct.DataSource = Bl_combobox.pack_produit_prevent();
            cmbProduct.DisplayMember = "pack_designation";
            cmbProduct.ValueMember = "pack_code_barre";
        }

        private void kryptonButton22_Click(object sender, EventArgs e)
        {
            frm_remise addRemise = new frm_remise();
            addRemise.txt_price_product.Text = lb_Total.Text;
            addRemise.frm_edit_bon = this;
            addRemise.Type = "edit";
            addRemise.ShowDialog();
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
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

        private void kryptonButton21_Click(object sender, EventArgs e)
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
        private void UpdateLabels()
        {
            if (dataGridView1.CurrentRow != null)
            {
                 

                string designation = dataGridView1.CurrentRow.Cells["اسم المنتوج"].Value.ToString();
                string QT = dataGridView1.CurrentRow.Cells["كمية المنتوج"].Value.ToString();
                string priceU = dataGridView1.CurrentRow.Cells["سعر البيع"].Value.ToString();
                string priceTTl = dataGridView1.CurrentRow.Cells["السعر الكلي"].Value.ToString();

                // تعيين القيم إلى العناصر المراد عرضها فيها
                LB_NAME.Text = designation;
                LB_QT.Text = QT;
                LB_PRICE_U.Text = priceU;
                LB_TTL.Text = priceTTl;

            }
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

        private void kryptonButton16_Click(object sender, EventArgs e)
        {
            frm_add_divers add_divers = new frm_add_divers();
            add_divers.frm_edit = this;
            add_divers.Type = "edit";
            add_divers.ShowDialog();
        }

        private void txt_barcode_KeyDown(object sender, KeyEventArgs e)
        {
             

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

                getinformation_matier_revent(bar);
                txt_qt.Text = "1";
                txt_barcode.Clear(); // تنظيف الـ TextBox بعد استدعاء الدالة
                e.Handled = true; // منع إصدار الصوت
            }
        }

        public void getinformation_matier_revent(string CodeBarrre)
        { 
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
                                var cellValue = row.Cells["رقم المنتوج"].Value;

                                // Check if the cell value is not null before comparison
                                if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                {
                                    row.Cells["كمية المنتوج"].Value = (float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) + float.Parse(QT)).ToString();
                                    row.Cells["السعر الكلي"].Value = float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                            float.Parse(row.Cells["سعر البيع"].Value.ToString());
                                    row.Cells["التكلفة"].Value = float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                        float.Parse(price_achat_produit_revent.ToString());
                                    //------------------------------------------------------------------------------//
                                    if (Quanite_dans_pack.ToString() != "")
                                    {
                                        if (float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) == float.Parse(Quanite_dans_pack.ToString()))
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
                                                        var cellValued = row.Cells["رقم المنتوج"].Value;

                                                        // Check if the cell value is not null before comparison
                                                        if (cellValued != null && cellValued.ToString() == codeBarrePack.ToString())
                                                        {
                                                            row.Cells["كمية المنتوج"].Value = (float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) + 1).ToString();
                                                            row.Cells["السعر الكلي"].Value = float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                                                    float.Parse(row.Cells["سعر البيع"].Value.ToString());
                                                            row.Cells["التكلفة"].Value = float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
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
                                        var cellValue = row.Cells["رقم المنتوج"].Value;

                                        // Check if the cell value is not null before comparison
                                        if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                        {
                                            row.Cells["كمية المنتوج"].Value = (int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) + 1).ToString();
                                            row.Cells["السعر الكلي"].Value = int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                                    decimal.Parse(row.Cells["سعر البيع"].Value.ToString());
                                            row.Cells["التكلفة"].Value = int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
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
                                    var cellValue = row.Cells["رقم المنتوج"].Value;

                                    // Check if the cell value is not null before comparison
                                    if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                    {
                                        row.Cells["كمية المنتوج"].Value = (int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) + 1).ToString();
                                        row.Cells["السعر الكلي"].Value = int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                                decimal.Parse(row.Cells["سعر البيع"].Value.ToString());
                                        row.Cells["التكلفة"].Value = int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
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
                             
                            DataTable dt = (DataTable)dataGridView1.DataSource;

                            DataRow newRow = dt.NewRow();
                            newRow["رقم المنتوج"] = codeBarre.ToString();
                            newRow["اسم المنتوج"] = name_product.ToString();
                            newRow["كمية المنتوج"] = txt_qt.Text;
                            newRow["سعر البيع"] = price_Vente.ToString();
                            newRow["السعر الكلي"] = decimal.Parse(price_Vente.ToString()) * decimal.Parse(txt_qt.Text);
                            newRow["التكلفة"] = (decimal.Parse(price_achat_produit_revent.ToString()) * (decimal.Parse(txt_qt.Text)));
                            newRow["النوع"] = "U";

                            dt.Rows.Add(newRow);
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
                                var cellValue = row.Cells["رقم المنتوج"].Value;

                                // Check if the cell value is not null before comparison
                                if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                {
                                    row.Cells["كمية المنتوج"].Value = (int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) + 1).ToString();
                                    row.Cells["السعر الكلي"].Value = int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                            decimal.Parse(row.Cells["سعر البيع"].Value.ToString());
                                    row.Cells["التكلفة"].Value = int.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
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
                        DataTable dt = (DataTable)dataGridView1.DataSource;

                        DataRow newRow = dt.NewRow();
                        newRow["رقم المنتوج"] = codeBarre.ToString();
                        newRow["اسم المنتوج"] = name_product.ToString();
                        newRow["كمية المنتوج"] = txt_qt.Text;
                        newRow["سعر البيع"] = price_Vente.ToString();
                        newRow["السعر الكلي"] = decimal.Parse(price_Vente.ToString()) * decimal.Parse(txt_qt.Text);
                        newRow["التكلفة"] = (decimal.Parse(price_achat_produit_revent.ToString()) * (decimal.Parse(txt_qt.Text)));
                        newRow["النوع"] = "U";

                        dt.Rows.Add(newRow);
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
                                var cellValue = row.Cells["رقم المنتوج"].Value;

                                // Check if the cell value is not null before comparison
                                if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                {
                                    row.Cells["كمية المنتوج"].Value = (float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) + 1).ToString();
                                    row.Cells["السعر الكلي"].Value = float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                            float.Parse(row.Cells["سعر البيع"].Value.ToString());
                                    row.Cells["التكلفة"].Value = float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                            float.Parse(cout_de_prodution.ToString());
                                    if (Quanite_dans_pack.ToString() != "")
                                    {
                                        if (float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) == float.Parse(Quanite_dans_pack.ToString()))
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
                                                        var cellValued = row.Cells["رقم المنتوج"].Value;

                                                        // Check if the cell value is not null before comparison
                                                        if (cellValued != null && cellValued.ToString() == codeBarrePack.ToString())
                                                        {
                                                            row.Cells["كمية المنتوج"].Value = (float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) + 1).ToString();
                                                            row.Cells["السعر الكلي"].Value = float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                                                    float.Parse(row.Cells["سعر البيع"].Value.ToString());
                                                            row.Cells["التكلفة"].Value = float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
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
                                    var cellValue = row.Cells["رقم المنتوج"].Value;

                                    // Check if the cell value is not null before comparison
                                    if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                    {
                                        row.Cells["كمية المنتوج"].Value = (float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) + 1).ToString();
                                        row.Cells["السعر الكلي"].Value = float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                                float.Parse(row.Cells["سعر البيع"].Value.ToString());
                                        row.Cells["التكلفة"].Value = float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
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

                            DataTable dt = (DataTable)dataGridView1.DataSource;

                            DataRow newRow = dt.NewRow();
                            newRow["رقم المنتوج"] = codeBarre.ToString();
                            newRow["اسم المنتوج"] = name_product.ToString();
                            newRow["كمية المنتوج"] = txt_qt.Text;
                            newRow["سعر البيع"] = price_Vente.ToString();
                            newRow["السعر الكلي"] = ttl_vente_pack;
                            newRow["التكلفة"] = ttl_cout_achat_pack;
                            newRow["النوع"] = "P";

                            dt.Rows.Add(newRow);
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
                                        var cellValue = row.Cells["رقم المنتوج"].Value;

                                        // Check if the cell value is not null before comparison
                                        if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                        {
                                            row.Cells["كمية المنتوج"].Value = (float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) + 1).ToString();
                                            row.Cells["السعر الكلي"].Value = float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                                    float.Parse(row.Cells["سعر البيع"].Value.ToString());
                                            row.Cells["التكلفة"].Value = float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
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
                                                var cellValue = row.Cells["رقم المنتوج"].Value;

                                                // Check if the cell value is not null before comparison
                                                if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                                {
                                                    row.Cells["كمية المنتوج"].Value = (float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) + 1).ToString();
                                                    row.Cells["السعر الكلي"].Value = float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                                                        float.Parse(row.Cells["سعر البيع"].Value.ToString());
                                                    row.Cells["التكلفة"].Value = float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
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
                                        DataTable dt = (DataTable)dataGridView1.DataSource;

                                        DataRow newRow = dt.NewRow();
                                        newRow["رقم المنتوج"] = codeBarre.ToString();
                                        newRow["اسم المنتوج"] = name_product.ToString();
                                        newRow["كمية المنتوج"] = txt_qt.Text;
                                        newRow["سعر البيع"] = price_Vente.ToString();
                                        newRow["السعر الكلي"] = ttl_vente_packkk.ToString();
                                        newRow["التكلفة"] = ttl_cout_achat_packk.ToString();
                                        newRow["النوع"] = "U";

                                        dt.Rows.Add(newRow);
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
                                                    var cellValue = row.Cells["رقم المنتوج"].Value;

                                                    // Check if the cell value is not null before comparison
                                                    if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
                                                    {
                                                        row.Cells["كمية المنتوج"].Value = (float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) + 1).ToString();
                                                        row.Cells["السعر الكلي"].Value = float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                                                float.Parse(row.Cells["سعر البيع"].Value.ToString());
                                                        row.Cells["التكلفة"].Value = float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
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
                                            DataTable dt = (DataTable)dataGridView1.DataSource;

                                            DataRow newRow = dt.NewRow();
                                            newRow["رقم المنتوج"] = codeBarre.ToString();
                                            newRow["اسم المنتوج"] = name_product.ToString();
                                            newRow["كمية المنتوج"] = txt_qt.Text;
                                            newRow["سعر البيع"] = price_Vente.ToString();
                                            newRow["السعر الكلي"] = ttl_vente_pack.ToString();
                                            newRow["التكلفة"] = ttl_cout_achat_pack;
                                            newRow["النوع"] = "P";

                                            dt.Rows.Add(newRow);

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
                    MessageBox.Show("الجدول فارغ");
                }

            }
            txt_barcode.Focus();
        }
        public void DeleteRowByCodeBarre()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView1.DataSource = null; // أولًا فك الربط
                dataGridView1.Rows.Clear();      // ثم امسح الصفوف
            }
        }

        private void BTN2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            { 
                DeleteRowByCodeBarre(this.dataGridView1.CurrentRow.Cells["رقم المنتوج"].Value.ToString());
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
                MessageBox.Show("لاتوجد منتوجات  لحذفها ");
            }
        }

        private void DeleteRowByCodeBarre(string codeBarre)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["رقم المنتوج"].Value != null &&
                    row.Cells["رقم المنتوج"].Value.ToString() == codeBarre)
                {
                    dataGridView1.Rows.Remove(row);
                    break; // Exit the loop after removing the row
                }
            }
        }

        private void txt_Versement_TextChanged(object sender, EventArgs e)
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
        public decimal calcule_credit_after(decimal sold_old)
        {
            decimal sold_after = decimal.Parse(lb_rest.Text);
            decimal soldnew = sold_old + sold_after;
            return soldnew;
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            if (currentIndex + 1 < listeFactures.Count)
            {
                currentIndex++;
                txt_id_fctr.Text = listeFactures[currentIndex];
                get_the_bon(txt_id_fctr.Text);
            }
            else
            {
                MessageBox.Show("وصلت لأول فاتورة.");
            }
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                txt_id_fctr.Text = listeFactures[currentIndex];
                get_the_bon(txt_id_fctr.Text);                
            }
            else
            {
                MessageBox.Show("وصلت لاخر فاتورة.");
            }
        }
    }
}
