using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_vente
{
	public class BL_vente_Fonction
	{
        public string get_OLD_Fctr()
        {

            DAL.DAL DAaL = new DAL.DAL();

            string newID = "";

            using (DAaL.sqlConnection)
            {
                string query = @"  
								SELECT CONCAT('FV', FORMAT(ISNULL(
                              (SELECT TOP 1 CAST(SUBSTRING(NMR_FACTURE, 3, LEN(NMR_FACTURE)) AS INT)
                               FROM TB_FACTURE_VENTE 
                               WHERE CAST(SUBSTRING(NMR_FACTURE, 3, LEN(NMR_FACTURE)) AS INT) < {currentInvoiceNumber}
                               ORDER BY CAST(SUBSTRING(NMR_FACTURE, 3, LEN(NMR_FACTURE)) AS INT) DESC), 0), '0000'))
    ";

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

        public string get_previous_fctr_vnt(string currentInvoice)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string previousID = "";

            using (DAaL.sqlConnection)
            {
                // استخراج الرقم من الفاتورة الحالية (FV0001 -> 0001)
                string currentNumber = currentInvoice.Substring(2);

                string query = $@"
            SELECT CONCAT('FV', FORMAT(
                ISNULL(
                    (SELECT TOP 1 
                        CONVERT(INT, SUBSTRING(NMR_FACTURE, 3, LEN(NMR_FACTURE))) 
                    FROM TB_FACTURE_VENTE 
                    WHERE CONVERT(INT, SUBSTRING(NMR_FACTURE, 3, LEN(NMR_FACTURE))) < {currentNumber}
                    ORDER BY CONVERT(INT, SUBSTRING(NMR_FACTURE, 3, LEN(NMR_FACTURE))) DESC), 0
                ), '0000')
            )";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    DAaL.sqlConnection.Open();
                    var result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        previousID = result.ToString();
                    }
                }
            }
            return previousID;
        }
        public string get_fctr_vnt()
		{

			DAL.DAL DAaL = new DAL.DAL();

			string newID = "";

			using (DAaL.sqlConnection)
			{
				string query = @" SELECT 'FV' + 
					   CAST(
						   ISNULL(
							   MAX(CASE 
									   WHEN ISNUMERIC(SUBSTRING(NMR_FACTURE, 3, LEN(NMR_FACTURE))) = 1 
									   THEN CONVERT(BIGINT, SUBSTRING(NMR_FACTURE, 3, LEN(NMR_FACTURE))) 
									   ELSE 0 
								   END), 
							   0
						   ) + 1 AS VARCHAR
					   ) 
				FROM TB_FACTURE_VENTE;
				";

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
		public DataTable get_facture_detailles()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_facture_detailles", null);
			DAL.Close();
			return Dt;
		}
		public string get_fct_total()
		{

			DAL.DAL DAaL = new DAL.DAL();

			string newID = "";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Sum([TOTAL_FACURE_TTC]) FROM [dbo].[TB_FACTURE_VENTE] ";
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

		public DataTable get_facture_attend(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@IDsearch", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("get_vente_en_attend", param);
			DAL.Close();
			return Dt;
		}
		public DataTable get_vente_by_nmr(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@IDfacrue", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("get_vente_by_nmr", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_facture_vente(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("search_facture_vente", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_facture_par_date(DateTime id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@Date", SqlDbType.Date);
			param[0].Value = id;
			Dt = DAL.SelectData("search_facture_par_date", param);
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
			Dt = DAL.SelectData("search_facture_par_client", param);
			DAL.Close();
			return Dt;
		}
		public DataTable get_vente_by_nmrr(string id )
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1]; 
			param[0] = new SqlParameter("@facteure", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("GetVenteDetails", param);
			DAL.Close();
			return Dt;
		}
		DAL.DAL daoo;
		public void insertFacture(
				      string NmrFacture
					, DateTime Date
					, TimeSpan Heure
					, int IdClient
					, decimal TotalFactureTtc
					, decimal TotalFactureHt
					, float Tva
					, decimal OldSold
					, decimal Versement
					, decimal NewSold
					, decimal Remise
					, float PourcentageRemise
					, int CountArticle
					, string Remarque
					, string Etat
					, int IdUser
					, int IdCaissier
					, decimal cout_of_fctr
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("insert_facture", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure; 
					cmd.Parameters.Add("@NMR_FACTURE", SqlDbType.NVarChar, 50).Value = NmrFacture;
					cmd.Parameters.Add("@DATE", SqlDbType.Date).Value = Date;
					cmd.Parameters.Add("@HEURE", SqlDbType.Time).Value = Heure;
					cmd.Parameters.Add("@ID_CLIENT", SqlDbType.Int).Value = IdClient;
					cmd.Parameters.Add("@TOTAL_FACURE_TTC", SqlDbType.Money).Value = TotalFactureTtc;
					cmd.Parameters.Add("@TOTAL_FACTURE_HT", SqlDbType.Money).Value = TotalFactureHt;
					cmd.Parameters.Add("@TVA", SqlDbType.Float).Value = Tva;
					cmd.Parameters.Add("@OLD_SOLD", SqlDbType.Money).Value = OldSold;
					cmd.Parameters.Add("@VERSEMENT", SqlDbType.Money).Value = Versement;
					cmd.Parameters.Add("@NEW_SOLD", SqlDbType.Money).Value = NewSold;
					cmd.Parameters.Add("@REMISE", SqlDbType.Money).Value = Remise;
					cmd.Parameters.Add("@POURSENTAGE_REMISE", SqlDbType.Float).Value = PourcentageRemise;
					cmd.Parameters.Add("@COUNT_ARTICLE", SqlDbType.Int).Value = CountArticle;
					cmd.Parameters.Add("@REMARQUE", SqlDbType.NVarChar).Value = Remarque;
					cmd.Parameters.Add("@ETAT", SqlDbType.NVarChar, 50).Value = Etat;
					cmd.Parameters.Add("@ID_USER", SqlDbType.Int).Value = IdUser;
					cmd.Parameters.Add("@ID_CAISSIER", SqlDbType.Int).Value = IdCaissier;
					cmd.Parameters.Add("@cout_of_fctr", SqlDbType.Int).Value = cout_of_fctr;
					cmd.ExecuteNonQuery();
				}
			}
		}

		public void edit_facture(
					  string NmrFacture
					, DateTime Date
					, TimeSpan Heure
					, int IdClient
					, decimal TotalFactureTtc
					, decimal TotalFactureHt
					, float Tva
					, decimal OldSold
					, decimal Versement
					, decimal NewSold
					, decimal Remise
					, float PourcentageRemise
					, int CountArticle
					, string Remarque
					, string Etat
					, int IdUser
					, int IdCaissier
                    , decimal cout_of_fctr
               )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("edit_facture", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@NMR_FACTURE_ORIGINAL", SqlDbType.NVarChar, 50).Value = NmrFacture;
					cmd.Parameters.Add("@DATE", SqlDbType.Date).Value = Date;
					cmd.Parameters.Add("@HEURE", SqlDbType.Time).Value = Heure;
					cmd.Parameters.Add("@ID_CLIENT", SqlDbType.Int).Value = IdClient;
					cmd.Parameters.Add("@TOTAL_FACTURE_TTC", SqlDbType.Money).Value = TotalFactureTtc;
					cmd.Parameters.Add("@TOTAL_FACTURE_HT", SqlDbType.Money).Value = TotalFactureHt;
					cmd.Parameters.Add("@TVA", SqlDbType.Float).Value = Tva;
					cmd.Parameters.Add("@OLD_SOLD", SqlDbType.Money).Value = OldSold;
					cmd.Parameters.Add("@VERSEMENT", SqlDbType.Money).Value = Versement;
					cmd.Parameters.Add("@NEW_SOLD", SqlDbType.Money).Value = NewSold;
					cmd.Parameters.Add("@REMISE", SqlDbType.Money).Value = Remise;
					cmd.Parameters.Add("@POURSENTAGE_REMISE", SqlDbType.Float).Value = PourcentageRemise;
					cmd.Parameters.Add("@COUNT_ARTICLE", SqlDbType.Int).Value = CountArticle;
					cmd.Parameters.Add("@REMARQUE", SqlDbType.NVarChar).Value = Remarque;
					cmd.Parameters.Add("@ETAT", SqlDbType.NVarChar, 50).Value = Etat;
					cmd.Parameters.Add("@ID_USER", SqlDbType.Int).Value = IdUser;
					cmd.Parameters.Add("@ID_CAISSIER", SqlDbType.Int).Value = IdCaissier;
                    cmd.Parameters.Add("@cout_of_fctr", SqlDbType.Int).Value = cout_of_fctr;
                    cmd.ExecuteNonQuery();
				}
			}
		}
		//
		public void InsertVente(
		  string CodeBarreProduit,
		  float QuantiteVente,
		  decimal PrixVente,
		  decimal PrixTotal,
		  string IdFacture,
		  decimal cout ,
          string Type )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("insert_vente_", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@CODE_BARRE_PRODUIT", SqlDbType.NVarChar, 50).Value = CodeBarreProduit;
					cmd.Parameters.Add("@QUANTITE_VENTE", SqlDbType.Float).Value = QuantiteVente;
					cmd.Parameters.Add("@PRIX_VENTE", SqlDbType.Money).Value = PrixVente;
					cmd.Parameters.Add("@PRIX_TOTAL", SqlDbType.Money).Value = PrixTotal;
					cmd.Parameters.Add("@ID_FACTURE", SqlDbType.NVarChar, 50).Value = IdFacture;
                    cmd.Parameters.Add("@cout", SqlDbType.Money).Value = cout;
                    cmd.Parameters.Add("@typee", SqlDbType.NVarChar).Value = Type;

                    cmd.ExecuteNonQuery();
				}
			}
		}
		//
	}
}
