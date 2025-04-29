using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Z.Dapper.Plus;

namespace Smart_Production_Pos.PL.Achat_revente
{
    public partial class frm_import_by_excel : Form
    {
        string _path;
        BL.BL_ACHAT_REVENT.BL_PRODUIT classProduit = new BL.BL_ACHAT_REVENT.BL_PRODUIT();
        public frm_import_by_excel()
        {
            InitializeComponent(); 
        }
        DataTableCollection tableCollection;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook |*.xls" })
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        txtFileName.Text = openFileDialog.FileName;
                        using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                        {
                            using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                                });
                                tableCollection = result.Tables;
                                cboSheet.Items.Clear();
                                foreach (DataTable table in tableCollection)
                                    cboSheet.Items.Add(table.TableName);
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("تأكد من اغلاق ملف الاكسل قبل العملية");
            }
            //OpenFileDialog OFD = new OpenFileDialog();
            //OFD.Filter = "Excell|*.xls;*.xlsx;";
            //OFD.FileName = "Product.xlsx";
            //DialogResult dr = OFD.ShowDialog();
            //if (dr == DialogResult.Abort)
            //    return;
            //if (dr == DialogResult.Cancel)
            //    return;
            //textBox1.Text = OFD.FileName.ToString();
            //_path = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            insert();
            MessageBox.Show("تم ادخال البيانات بنجاح");
            #region
            //insertRecord();//insertRecord();
            //     try
            //     {
            //         SqlConnection sqlConnection;
            //         string mode = Properties.Settings.Default.mode; 
            //if (mode == "SQL")
            //{
            // sqlConnection = new SqlConnection(@"Server=" + Properties.Settings.Default.server + "; Database=" + Properties.Settings.Default.dataBase +
            //  "; Integrated Security=false ; User ID =" + Properties.Settings.Default.ID + ";Password=" + Properties.Settings.Default.PASS + "");
            //}
            //else
            //{
            // sqlConnection = new SqlConnection(@"Server=" + Properties.Settings.Default.server + "; Database=" + Properties.Settings.Default.dataBase + "; Integrated Security=true");
            //}
            //         DapperPlusManager.Entity<product>().Table("TB_Produit_revente");
            //         List<product> produits = productBindingSource1.DataSource as List<product>;
            //         if(produits != null)
            //         {
            //             using (IDbConnection db = sqlConnection)
            //             {
            //                 db.BulkInsert(produits);
            //             }
            //             MessageBox.Show("تم ادخال البيانات بنجاح");
            //         }
            //     }
            //     catch
            //     {

            //     }
            #endregion
        }
        private void insert()
        {
            //try
            //{
                MemoryStream ms = new MemoryStream();
                pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
                byte[] byteImage = ms.ToArray();

                int? qt_pack = null;
                DateTime? datePeretion = null;
                string produitPies;
                int stock_min;


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        // Récupérez les valeurs nécessaires de la ligne actuelle du DataGridView
                        string CodeBarre = row.Cells[0].Value.ToString();
                        string Designation = row.Cells[1].Value.ToString();
                        string Reference = row.Cells[2].Value.ToString();
                        int? IdCategories = null; // Convert.ToInt32(row.Cells[3].Value?.ToString());
                        int? IdStocke = null; // Convert.ToInt32(row.Cells[4].Value?.ToString());
                        int? IdMarque = null; // Convert.ToInt32(row.Cells[5].Value?.ToString());
                        int? IdUnite = null; // Convert.ToInt32(row.Cells[6].Value?.ToString());
                        int? IdTaille = null; // Convert.ToInt32(row.Cells[7].Value?.ToString());
                        int? IdColor = null; // Convert.ToInt32(row.Cells[8].Value?.ToString());
                        int? IdFavoire = null; // Convert.ToInt32(row.Cells[9].Value?.ToString());
                        DateTime? DateExpiration = null;
                        decimal PriceAchatHT = decimal.Parse(row.Cells[3].Value.ToString());
                        decimal PriceAchatTTC = decimal.Parse(row.Cells[4].Value.ToString());
                        float TVA = float.Parse(row.Cells[5].Value.ToString());
                        float QuantiteTotal = float.Parse(row.Cells[6].Value.ToString());
                        decimal PriceVente1 = decimal.Parse(row.Cells[7].Value.ToString());
                        decimal PriceVente2 = decimal.Parse(row.Cells[8].Value.ToString());
                        decimal PriceMin = decimal.Parse(row.Cells[9].Value.ToString());
                        string VenteApresExpiration = row.Cells[10].Value.ToString();
                        string StockeNegatif = row.Cells[11].Value.ToString();
                        float QuantiteVente = float.Parse(row.Cells[12].Value.ToString());
                        float QuantiteRest = float.Parse(row.Cells[13].Value.ToString());
                        float QuantiteDechet = float.Parse(row.Cells[14].Value.ToString());
                        float QuantiteAlert = float.Parse(row.Cells[15].Value.ToString());
                        float Ihtiyaj = float.Parse(row.Cells[16].Value.ToString());

                        // Call the Add_Funct method to add the row data
                        classProduit.Add_Funct(
                            CodeBarre,
                            Designation,
                            Reference,
                            IdCategories,
                            IdStocke,
                            IdMarque,
                            IdUnite,
                            IdTaille,
                            IdColor,
                            IdFavoire,
                            DateExpiration,
                            PriceAchatHT,
                            PriceAchatTTC,
                            TVA,
                            QuantiteTotal,
                            PriceVente1,
                            PriceVente2,
                            PriceMin,
                            VenteApresExpiration,
                            StockeNegatif,
                            QuantiteVente,
                            QuantiteRest,
                            QuantiteDechet,
                            byteImage,
                            qt_pack,
                            QuantiteAlert,
                            Ihtiyaj
                        );

                        // Optionally, call the Edit_Produit function to update the product if needed
                    }
                }


            //}
            //catch
            //{
            //    MessageBox.Show("تأكد من أن الملف ترتيبه صحيح");
            //}

        }
        #region    ancien
        //public void insertRecord()
        //{



        //        //  ExcelConn(_path);
        //        string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", _path);
        //        var Econ = new OleDbConnection(constr);
        //        string Query = string.Format("Select [CodeBarre],[designation],[reference]" +
        //            " ,[id_categories],[id_stocke],[id_marque],[id_unite],[id_taille],[id_color],[id_favoire]" +
        //            ",[date_expiration],[price_achat_HT],[price_achat_TTC],[TVA],[Quantite_TOTAL]" +
        //            ",[price_vente1],[price_vente2],[price_min],[vente_apres_expiration],[stocke_negatif]," +
        //            "[Quantite_vente],[Quantite_rest],[Quantite_dechet],[Photo],[QT_DANS_PACK]," +
        //            "[Quantite_alert],[ihtiyaj] FROM [Sheet1$]");
        //        OleDbCommand Ecom = new OleDbCommand(Query, Econ);
        //        Econ.Open();
        //        DataSet ds = new DataSet();
        //        OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
        //        Econ.Close();
        //        oda.Fill(ds);
        //        DataTable Exceldt = ds.Tables[0];

        //        for (int i = Exceldt.Rows.Count - 1; i != 0; i--)
        //        {
        //            if (Exceldt.Rows[i]["CodeBarre"] == DBNull.Value || Exceldt.Rows[i]["designation"] == DBNull.Value)
        //            {

        //                Exceldt.Rows[i].Delete();
        //            }
        //        }
        //        Exceldt.AcceptChanges();

        //        // SQL Server connection string
        //        string sqlConnectionString = string.Format(@"Server={0}; Database={1}; Integrated Security=false; User ID={2}; Password={3};",
        //                                                   Properties.Settings.Default.server,
        //                                                   Properties.Settings.Default.dataBase,
        //                                                   Properties.Settings.Default.ID,
        //                                                   Properties.Settings.Default.PASS);

        //        using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
        //        {
        //            sqlConnection.Open();

        //            using (SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection))
        //            {
        //                // Assigning Destination table name
        //                objbulk.DestinationTableName = "TB_Produit_revente";

        //                // Mapping Table columns (assuming your Excel and SQL table columns match)
        //                objbulk.ColumnMappings.Add("CodeBarre", "CodeBarre");
        //                objbulk.ColumnMappings.Add("designation", "designation");
        //                objbulk.ColumnMappings.Add("reference", "reference");
        //                objbulk.ColumnMappings.Add("id_categories", "id_categories");
        //                objbulk.ColumnMappings.Add("id_stocke", "id_stocke");
        //                objbulk.ColumnMappings.Add("id_marque", "id_marque");
        //                objbulk.ColumnMappings.Add("id_unite", "id_unite");
        //                objbulk.ColumnMappings.Add("id_taille", "id_taille");
        //                objbulk.ColumnMappings.Add("id_color", "id_color");
        //                objbulk.ColumnMappings.Add("id_favoire", "id_favoire");
        //                objbulk.ColumnMappings.Add("date_expiration", "date_expiration");
        //                objbulk.ColumnMappings.Add("price_achat_HT", "price_achat_HT");
        //                objbulk.ColumnMappings.Add("price_achat_TTC", "price_achat_TTC");
        //                objbulk.ColumnMappings.Add("TVA", "TVA");
        //                objbulk.ColumnMappings.Add("Quantite_TOTAL", "Quantite_TOTAL");
        //                objbulk.ColumnMappings.Add("price_vente1", "price_vente1");
        //                objbulk.ColumnMappings.Add("price_vente2", "price_vente2");
        //                objbulk.ColumnMappings.Add("price_min", "price_min");
        //                objbulk.ColumnMappings.Add("vente_apres_expiration", "vente_apres_expiration");
        //                objbulk.ColumnMappings.Add("stocke_negatif", "stocke_negatif");
        //                objbulk.ColumnMappings.Add("Quantite_vente", "Quantite_vente");
        //                objbulk.ColumnMappings.Add("Quantite_rest", "Quantite_rest");
        //                objbulk.ColumnMappings.Add("Quantite_dechet", "Quantite_dechet");
        //                objbulk.ColumnMappings.Add("Photo", "Photo");
        //                objbulk.ColumnMappings.Add("QT_DANS_PACK", "QT_DANS_PACK");
        //                objbulk.ColumnMappings.Add("Quantite_alert", "Quantite_alert");
        //                objbulk.ColumnMappings.Add("ihtiyaj", "ihtiyaj");

        //                // Inserting Datatable Records to DataBase
        //                objbulk.WriteToServer(Exceldt);
        //            }

        //            sqlConnection.Close();
        //        }

        //        MessageBox.Show("تمت العمليه بنجاح", "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);


        //}
        #endregion
        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
            if (dt != null)
            {
                List<product> produittts = new List<product>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    product produits = new product();
                    produits.CodeBarre =      dt.Rows[i]["رمز المنتج"].ToString();
                    produits.Designation =    dt.Rows[i]["اسم المنتج"].ToString();
                    produits.Reference =      dt.Rows[i]["رقم المرجع"].ToString();
                    produits.IdCategories =   dt.Rows[i].IsNull("الصنف") ? (int?)null : Convert.ToInt32(dt.Rows[i]["الصنف"]); 
                    produits.IdStocke =       dt.Rows[i].IsNull("المخزن") ? (int?)null : Convert.ToInt32(dt.Rows[i]["المخزن"]);   
                    produits.IdMarque =       dt.Rows[i].IsNull("العلامة") ? (int?)null : Convert.ToInt32(dt.Rows[i]["العلامة"]);   
                    produits.IdUnite =        dt.Rows[i].IsNull("الوحدة") ? (int?)null : Convert.ToInt32(dt.Rows[i]["الوحدة"]);    
                    produits.IdTaille =       dt.Rows[i].IsNull("القياس") ? (int?)null : Convert.ToInt32(dt.Rows[i]["القياس"]);
                    produits.IdColor =        dt.Rows[i].IsNull("اللون") ? (int?)null : Convert.ToInt32(dt.Rows[i]["اللون"]); 
                    produits.IdFavoire =      dt.Rows[i].IsNull("المفضلة") ? (int?)null : Convert.ToInt32(dt.Rows[i]["المفضلة"]);
                    produits.DateExpiration = dt.Rows[i]["تاريخ انتهاء الصلاحية"].ToString() ;
                    produits.PriceAchatHT =   dt.Rows[i]["سعر الشراء HT"].ToString();
                    produits.PriceAchatTTC =  dt.Rows[i]["سعر الشراء TTC"].ToString();
                    produits.TVA =            dt.Rows[i]["TVA"].ToString();
                    produits.QuantiteTotal =  dt.Rows[i]["الكمية الكلية"].ToString();
                    produits.PriceVente1 =    dt.Rows[i]["سعر البيع الأول"].ToString();
                    produits.PriceVente2 =    dt.Rows[i]["سعر البيع الثاني"].ToString();
                    produits.PriceMin =       dt.Rows[i]["سعر البيع الأدنى"].ToString();
                    produits.VenteApresExpiration =  dt.Rows[i]["البيع بعد انتهاء الصلاحية"].ToString();
                    produits.StockeNegatif =  dt.Rows[i]["البيع بعد -"].ToString();
                    produits.QuantiteVente =  dt.Rows[i]["الكمبة المباعة"].ToString();
                    produits.QuantiteRest =   dt.Rows[i]["الكمية المتبقية"].ToString();
                    produits.QuantiteDechet = dt.Rows[i]["الكمية المرمية"].ToString();
                    produits.QTDansPack = dt.Rows[i].IsNull("الكمية في الحزمة") ? 0 : Convert.ToInt32(dt.Rows[i]["الكمية في الحزمة"]);
                    produits.QuantiteAlert = Convert.ToInt32(dt.Rows[i]["كمية التنبيه"].ToString());
                    produits.Ihtiyaj =        dt.Rows[i]["كمية الاحتياج"].ToString();
                    produittts.Add(produits);


                    
                    //produits.QTDansPack = dt.Rows[i].IsNull("الكمية في الحزمة") ? 0 : Convert.ToInt32(dt.Rows[i]["الكمية في الحزمة"]);

                }

                // Binding the list to the DataSource
                productBindingSource.DataSource = produittts;

                // Insert records into the database
                
            }



        }
        private void insertRecord()
        {
            try
            {
                SqlConnection sqlConnection;
                string mode = Properties.Settings.Default.mode;
                if (mode == "SQL")
                {
                    sqlConnection = new SqlConnection(@"Server=" + Properties.Settings.Default.server + "; Database=" + Properties.Settings.Default.dataBase +
                        "; Integrated Security=false ; User ID =" + Properties.Settings.Default.ID + ";Password=" + Properties.Settings.Default.PASS + "");
                }
                else
                {
                    sqlConnection = new SqlConnection(@"Server=" + Properties.Settings.Default.server + "; Database=" + Properties.Settings.Default.dataBase + "; Integrated Security=true");
                }

                DapperPlusManager.Entity<product>().Table("TB_Produit_revente");
                List<product> produits = productBindingSource.DataSource as List<product>;
                if (produits != null)
                {
                    using (IDbConnection db = sqlConnection)
                    {
                        db.BulkInsert(produits);
                    }
                    MessageBox.Show("تم ادخال البيانات بنجاح");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ: " + ex.Message);
            }
        }
    }
}

