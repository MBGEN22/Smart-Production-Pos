using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Smart_Production_Pos.BL.BL_vente
{
    public class BL_FACTURE_VENTE
    {
        public string get_id_facture_achat()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "";

            using (SqlConnection conn = DAaL.sqlConnection)
            {
                string query = @"
                     DECLARE @YearMonth NVARCHAR(6) = FORMAT(GETDATE(), 'yyyyMM');
                    DECLARE @LastNumber INT;

                    SELECT TOP 1 @LastNumber = CAST(RIGHT(Nmr_facture, 5) AS INT)
                    FROM TB_FACTURATION
                    WHERE Nmr_facture LIKE @YearMonth + '-%'
                    ORDER BY Nmr_facture DESC;

                    SET @LastNumber = ISNULL(@LastNumber, 0) + 1;

                    DECLARE @NewInvoiceNumber NVARCHAR(50) = @YearMonth + '-' + FORMAT(@LastNumber, '00000');

                    SELECT @NewInvoiceNumber; -- ✅ هذا هو الحل الصحيح
                ";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        newID = result.ToString();
                    }
                }
            }
            return newID;
        }
        public string get_fct_total()
        {

            DAL.DAL DAaL = new DAL.DAL();

            string newID = "";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT Sum([Total_ttc]) FROM [dbo].[TB_FACTURATION] ";
                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    DAaL.sqlConnection.Open();
                    var result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        newID = result.ToString();
                    }
                }
            }
            return newID;
        }
        public DataTable list_facture_vente()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            Dt = DAL.SelectData("list_facture_vente", null);
            DAL.Close();
            return Dt;
        }
        public DataTable get_list_detaille_facture_vente()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            Dt = DAL.SelectData("get_list_detaille_facture_vente", null);
            DAL.Close();
            return Dt;
        }
        public DataTable searh_facture_vente_by_date(DateTime id)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Date", SqlDbType.Date);
            param[0].Value = id;
            Dt = DAL.SelectData("searh_facture_vente_by_date", param);
            DAL.Close();
            return Dt;
        }
        
        public DataTable get_list_detaille_facture_vente_by_date(DateTime id)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Date", SqlDbType.Date);
            param[0].Value = id;
            Dt = DAL.SelectData("get_list_detaille_facture_vente_by_date", param);
            DAL.Close();
            return Dt;
        }
        public DataTable search_facture_par_client(int id)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_client", SqlDbType.NVarChar);
            param[0].Value = id;
            Dt = DAL.SelectData("searh_facture_vente_by_client", param);
            DAL.Close();
            return Dt;
        }
        public DataTable searh_facture_vente(string id)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar);
            param[0].Value = id;
            Dt = DAL.SelectData("searh_facture_vente", param);
            DAL.Close();
            return Dt;
        }
        public DataTable list_detaille_facture_vente(string codeBarre)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@nmr_facture", SqlDbType.NVarChar);
            param[0].Value = codeBarre;
            Dt = DAL.SelectData("list_detaille_facture_vente", param);
            DAL.Close();
            return Dt;
        }

        DAL.DAL daoo;
        public void InsertFacturation(
         string Nmr_facture,
         int id_client,
         int id_caissie,
         int id_user,
         DateTime date,
         TimeSpan heure,
         decimal Total_ttc,
         decimal total_ht,
         decimal tva,
         decimal remise,
         float pourcentage_remise,
         float tembre,
         decimal price_originale,
         int Count_article,
         float ttl_QTT,
         string price_arabe,
         string price_fr,
         string type_payment,
         decimal old_sold,
         decimal versement,
         decimal new_sold,
         string remarque,
         decimal cout_fctr,
         string etas)
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("InsertFacturation", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Nmr_facture", SqlDbType.NVarChar).Value = Nmr_facture;
                    cmd.Parameters.Add("@id_client", SqlDbType.Int).Value = id_client;
                    cmd.Parameters.Add("@id_caissie", SqlDbType.Int).Value = id_caissie;
                    cmd.Parameters.Add("@id_user", SqlDbType.Int).Value = id_user;
                    cmd.Parameters.Add("@date", SqlDbType.Date).Value = date;
                    cmd.Parameters.Add("@heure", SqlDbType.Time).Value = heure;
                    cmd.Parameters.Add("@Total_ttc", SqlDbType.Decimal).Value = Total_ttc;
                    cmd.Parameters.Add("@total_ht", SqlDbType.Decimal).Value = total_ht;
                    cmd.Parameters.Add("@tva", SqlDbType.Decimal).Value = tva;
                    cmd.Parameters.Add("@remise", SqlDbType.Decimal).Value = remise;
                    cmd.Parameters.Add("@pourcentage_remise", SqlDbType.Float).Value = pourcentage_remise;
                    cmd.Parameters.Add("@tembre", SqlDbType.Float).Value = tembre;
                    cmd.Parameters.Add("@price_originale", SqlDbType.Decimal).Value = price_originale;
                    cmd.Parameters.Add("@Count_article", SqlDbType.Int).Value = Count_article;
                    cmd.Parameters.Add("@ttl_QTT", SqlDbType.Float).Value = ttl_QTT;
                    cmd.Parameters.Add("@price_arabe", SqlDbType.NVarChar).Value = price_arabe;
                    cmd.Parameters.Add("@price_fr", SqlDbType.NVarChar).Value = price_fr;
                    cmd.Parameters.Add("@type_payment", SqlDbType.NVarChar).Value = type_payment;
                    cmd.Parameters.Add("@old_sold", SqlDbType.Decimal).Value = old_sold;
                    cmd.Parameters.Add("@versement", SqlDbType.Decimal).Value = versement;
                    cmd.Parameters.Add("@new_sold", SqlDbType.Decimal).Value = new_sold;
                    cmd.Parameters.Add("@remarque", SqlDbType.NVarChar).Value = remarque;
                    cmd.Parameters.Add("@cout_fctr", SqlDbType.Decimal).Value = cout_fctr;
                    cmd.Parameters.Add("@etas", SqlDbType.NVarChar).Value = etas;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertFacturationVente(
    string CODE_BARRE,
    string DESIGNATION,
    float? N_COLIS,
    float? COLISSAGE,
    float QTE,
    decimal PRIC_U,
    decimal PRIE_TTL,
    decimal REMISE,
    decimal PRICE_APRES_REMISE,
    float PRNST,
    string nmr_fctr
)
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("InsertFacturationVente", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CODE_BARRE", SqlDbType.NVarChar).Value = CODE_BARRE;
                    cmd.Parameters.Add("@DESIGNATION", SqlDbType.NVarChar).Value = DESIGNATION;

                    // التعامل مع القيم الفارغة (NULL)
                    cmd.Parameters.Add("@N_COLIS", SqlDbType.Float).Value = N_COLIS.HasValue ? (object)N_COLIS.Value : DBNull.Value;
                    cmd.Parameters.Add("@COLISSAGE", SqlDbType.Float).Value = COLISSAGE.HasValue ? (object)COLISSAGE.Value : DBNull.Value;

                    cmd.Parameters.Add("@QTE", SqlDbType.Float).Value = QTE;
                    cmd.Parameters.Add("@PRIC_U", SqlDbType.Decimal).Value = PRIC_U;
                    cmd.Parameters.Add("@PRIE_TTL", SqlDbType.Decimal).Value = PRIE_TTL;
                    cmd.Parameters.Add("@REMISE", SqlDbType.Decimal).Value = REMISE;
                    cmd.Parameters.Add("@PRICE_APRES_REMISE", SqlDbType.Decimal).Value = PRICE_APRES_REMISE;
                    cmd.Parameters.Add("@PRNST", SqlDbType.Float).Value = PRNST;
                    cmd.Parameters.Add("@nmr_fctr", SqlDbType.NVarChar).Value = nmr_fctr;

                    cmd.ExecuteNonQuery();
                }
            }
        }



    }
}
