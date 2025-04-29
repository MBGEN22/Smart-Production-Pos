using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Smart_Production_Pos.BL.BL_Statistique
{
    public class bl_inventaire
    {
        public DataTable GET_PRINCIPE_INVENTAIRE()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("GET_PRINCIPE_INVENTAIRE", null);
            DAL.Close();
            return Dt;
        }

        public DataTable search_PRINCIPE_INVENTAIRE(string search)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar, 50);
            param[0].Value = search;
            Dt = DAL.SelectData("search_PRINCIPE_INVENTAIRE", param);
            DAL.Close();
            return Dt;
        }

        public DataTable search_PRINCIPE_INVENTAIRE_by_date(DateTime search)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar, 50);
            param[0].Value = search;
            Dt = DAL.SelectData("search_PRINCIPE_INVENTAIRE_by_date", param);
            DAL.Close();
            return Dt;
        }
        DAL.DAL daoo;
        public void INSERT_INVENTAIRE_PRINCIPAL(
                      string NMR_INVENTAIR
                    , DateTime DATE
                    , TimeSpan HEURE
                    , decimal TOTAL_THEORIQUE
                    , decimal TOTAL_PHYSIQUE
                    , decimal MONTANT_ECART
                    , string OBSERVATION
                    , int ID_USER 
               )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT_INVENTAIRE_PRINCIPAL", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NMR_INVENTAIR", SqlDbType.NVarChar, 50).Value = NMR_INVENTAIR;
                    cmd.Parameters.Add("@DATE", SqlDbType.Date).Value = DATE;
                    cmd.Parameters.Add("@HEURE", SqlDbType.Time).Value = HEURE;
                    cmd.Parameters.Add("@TOTAL_THEORIQUE", SqlDbType.Decimal).Value = TOTAL_THEORIQUE;
                    cmd.Parameters.Add("@TOTAL_PHYSIQUE", SqlDbType.Decimal).Value = TOTAL_PHYSIQUE;
                    cmd.Parameters.Add("@MONTANT_ECART", SqlDbType.Decimal).Value = MONTANT_ECART;
                    cmd.Parameters.Add("@OBSERVATION", SqlDbType.NVarChar).Value = OBSERVATION;
                    cmd.Parameters.Add("@ID_USER", SqlDbType.Int).Value = ID_USER; 
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void INSERT_DETAILLE_INVENTAIRE(
            string  CODEBARRE_PRODUIT,
            decimal QUANTITE_THERORIQUE,
            decimal QUANTITE_PHY,
            decimal ECART,
            decimal PU,
            decimal P_TTL_ECART,
            string  OBSERVATION,
            string  ID_PRINCIPALE_INVENTAIRE
        )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("InsertDetailleInventaire", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CODEBARRE_PRODUIT", SqlDbType.NVarChar, 50).Value = CODEBARRE_PRODUIT;
                    cmd.Parameters.Add("@QUANTITE_THERORIQUE", SqlDbType.Decimal).Value = QUANTITE_THERORIQUE;
                    cmd.Parameters.Add("@QUANTITE_PHY", SqlDbType.Decimal).Value = QUANTITE_PHY;
                    cmd.Parameters.Add("@ECART", SqlDbType.Decimal).Value = ECART;
                    cmd.Parameters.Add("@PU", SqlDbType.Decimal).Value = PU;
                    cmd.Parameters.Add("@P_TTL_ECART", SqlDbType.Decimal).Value = P_TTL_ECART;
                    cmd.Parameters.Add("@OBSERVATION", SqlDbType.NVarChar).Value = OBSERVATION;
                    cmd.Parameters.Add("@ID_PRINCIPALE_INVENTAIRE", SqlDbType.NVarChar, 50).Value = ID_PRINCIPALE_INVENTAIRE;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public string get_inventaire_nmr()
        {

            DAL.DAL DAaL = new DAL.DAL();

            string newID = "";

            using (DAaL.sqlConnection)
            {
                string query = @" SELECT CONCAT('', 
						  FORMAT(
							ISNULL(
								CONVERT(INT, 
									MAX(CASE 
										WHEN ISNUMERIC(SUBSTRING(NMR_INVENTAIR, 3, LEN(NMR_INVENTAIR))) = 1 
										THEN SUBSTRING(NMR_INVENTAIR, 3, LEN(NMR_INVENTAIR)) 
										ELSE '0' 
									END)) + 1, 0
							), '0000')
									) 
							FROM TB_PRINCIPALE_INVENTAIRE;";

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
    }
}
