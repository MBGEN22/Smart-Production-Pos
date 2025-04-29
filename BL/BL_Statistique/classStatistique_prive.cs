using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_Statistique
{
	public class classStatistique_prive
	{


        #region jouner_et today
        //المدفوعات اليومية
        //totoal_commande
        //public string total__ttc_commande_jrn(string datee)
        //{
        //	DAL.DAL DAaL = new DAL.DAL();
        //	string newID = "0";

        //	using (DAaL.sqlConnection)
        //	{
        //		// Use today's date in the format 'YYYY-MM-DD' 

        //		// Modify the query to filter by today's date
        //		string query = "SELECT SUM(TB_COMMANDE.PRICE_TOTAL_TTC) FROM [dbo].TB_COMMANDE WHERE CAST(TB_COMMANDE.DATE AS DATE) = @Daya";

        //		using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
        //		{
        //			// Add the parameter to the query
        //			command.Parameters.AddWithValue("@Daya", datee);

        //			DAaL.sqlConnection.Open();
        //			var result = command.ExecuteScalar();
        //			if (result != DBNull.Value)
        //			{
        //				newID = result.ToString();
        //			}
        //		}
        //	}
        //	return newID;
        //}
        public string total__ttc_commande_jrn(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                // Modify the query to filter by the date parameter
                string query = "SELECT SUM(TB_COMMANDE.PRICE_TOTAL_TTC) FROM [dbo].TB_COMMANDE WHERE CAST(TB_COMMANDE.DATE AS DATE) = @Daya";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    // Format the date parameter explicitly
                    command.Parameters.AddWithValue("@Daya", DateTime.ParseExact(datee, "yyyy-MM-dd", CultureInfo.InvariantCulture));

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

        //versement_commande
        public string total_versemnt_ttc_commande_jrn(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                // Use today's date in the format 'YYYY-MM-DD' 

                // Modify the query to filter by today's date
                string query = "SELECT SUM(TB_COMMANDE.VERSEMENT) FROM [dbo].TB_COMMANDE WHERE CAST(TB_COMMANDE.DATE AS DATE) = @Daya";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    // Add the parameter to the query
                    command.Parameters.AddWithValue("@Daya", datee);

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
        //total_facture_Vente
        public string total_facture_Vente(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_FACTURE_VENTE.TOTAL_FACURE_TTC) FROM [dbo].TB_FACTURE_VENTE WHERE TB_FACTURE_VENTE.DATE = @Daya";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    command.Parameters.AddWithValue("@Daya", datee);

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
         
        public string total_facture_Achat(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                try
                {

                    string query = @"SELECT Sum([TOTAL]) FROM[dbo].[TB_FACTURE_ACHAT_PRODUIT_REVENT]
                                   where[TB_FACTURE_ACHAT_PRODUIT_REVENT].DATE = @Daya";

                    using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                    {
                        command.Parameters.AddWithValue("@Daya", datee);

                        DAaL.sqlConnection.Open();
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            newID = result.ToString();
                        }
                    }
                }
                catch
                {
                    return newID; 
                }
            }
            return newID;
        }

        public string total_facture_Achat_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = @" SELECT Sum([TOTAL])
                                    FROM[dbo].[TB_FACTURE_ACHAT_PRODUIT_REVENT]
                                    WHERE CAST(TB_FACTURE_ACHAT_PRODUIT_REVENT.DATE AS DATE)
                                    BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()";

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
        public string total_facture_Achat_Month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = @" SELECT Sum([TOTAL])
                                 FROM[dbo].[TB_FACTURE_ACHAT_PRODUIT_REVENT]
                                 WHERE CAST(TB_FACTURE_ACHAT_PRODUIT_REVENT.DATE AS DATE)
                                 BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE()";

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
        public string total_versement_facture_Achat(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                try
                {

                    string query = @"SELECT Sum([VERSEMNT]) FROM[dbo].[TB_FACTURE_ACHAT_PRODUIT_REVENT]
                                   where[TB_FACTURE_ACHAT_PRODUIT_REVENT].DATE = @Daya";

                    using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                    {
                        command.Parameters.AddWithValue("@Daya", datee);

                        DAaL.sqlConnection.Open();
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            newID = result.ToString();
                        }
                    }
                }
                catch
                {
                    return newID;
                } 
            }
            return newID;
        }

        public string total_Versment_Achat_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = @" SELECT Sum([VERSEMNT])
                                    FROM[dbo].[TB_FACTURE_ACHAT_PRODUIT_REVENT]
                                    WHERE CAST(TB_FACTURE_ACHAT_PRODUIT_REVENT.DATE AS DATE)
                                    BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()";

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

        public string total_Versment_Achat_Month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = @"  SELECT Sum([VERSEMNT])
                                    FROM[dbo].[TB_FACTURE_ACHAT_PRODUIT_REVENT]
                                    WHERE CAST(TB_FACTURE_ACHAT_PRODUIT_REVENT.DATE AS DATE)
                                    BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE()";

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
        //versement_facture_Vente
        public string versement_facture_Vente(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";


            using (DAaL.sqlConnection)
            {
                // Use today's date in the format 'YYYY-MM-DD' 

                // Modify the query to filter by today's date
                string query = "SELECT SUM(TB_FACTURE_VENTE.VERSEMENT) FROM [dbo].TB_FACTURE_VENTE WHERE CAST(TB_FACTURE_VENTE.DATE AS DATE) = @Daya";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    // Add the parameter to the query
                    command.Parameters.AddWithValue("@Daya", datee);

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
        public string versement_facture_Vente_anonymos(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";


            using (DAaL.sqlConnection)
            {
                // Use today's date in the format 'YYYY-MM-DD' 

                // Modify the query to filter by today's date
                string query = @"SELECT SUM(TB_FACTURE_VENTE.VERSEMENT) FROM [dbo].TB_FACTURE_VENTE WHERE 
                                CAST(TB_FACTURE_VENTE.DATE AS DATE) = @Daya and TB_FACTURE_VENTE.ID_CLIENT = 1; ";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    // Add the parameter to the query
                    command.Parameters.AddWithValue("@Daya", datee);

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

        public string versement_facture_Vente_anonymos_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = @" SELECT SUM(TB_FACTURE_VENTE.VERSEMENT) 
                                FROM [dbo].TB_FACTURE_VENTE 
                                WHERE CAST(TB_FACTURE_VENTE.DATE AS DATE) 
                                BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()
                                and TB_FACTURE_VENTE.ID_CLIENT = 1";

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

        public string versement_facture_Vente_anonymos_Month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = @" SELECT SUM(TB_FACTURE_VENTE.VERSEMENT) 
                                FROM [dbo].TB_FACTURE_VENTE 
                                WHERE CAST(TB_FACTURE_VENTE.DATE AS DATE) 
                                BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE()
                                and TB_FACTURE_VENTE.ID_CLIENT = 1";

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
        public string versement_facture_Vente_non_anonymos(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";


            using (DAaL.sqlConnection)
            {
                // Use today's date in the format 'YYYY-MM-DD' 

                // Modify the query to filter by today's date
                string query = @"SELECT SUM(TB_FACTURE_VENTE.VERSEMENT) FROM [dbo].TB_FACTURE_VENTE WHERE 
                                CAST(TB_FACTURE_VENTE.DATE AS DATE) = @Daya and TB_FACTURE_VENTE.ID_CLIENT != 1; ";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    // Add the parameter to the query
                    command.Parameters.AddWithValue("@Daya", datee);

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

        public string versement_facture_Vente_non_anonymos_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = @" SELECT SUM(TB_FACTURE_VENTE.VERSEMENT) 
                                FROM [dbo].TB_FACTURE_VENTE 
                                WHERE CAST(TB_FACTURE_VENTE.DATE AS DATE) 
                                BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()
                                and TB_FACTURE_VENTE.ID_CLIENT != 1";

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
        public string versement_facture_Vente_non_anonymos_Month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = @" SELECT SUM(TB_FACTURE_VENTE.VERSEMENT) 
                                FROM [dbo].TB_FACTURE_VENTE 
                                WHERE CAST(TB_FACTURE_VENTE.DATE AS DATE) 
                                BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()
                                and TB_FACTURE_VENTE.ID_CLIENT != 1";

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
        public string versemnt_normale(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";
            try
            {

                string query = @"SELECT SUM(TB_HISTORIQUE_CLIENT.PRICE) 
                                FROM [dbo].TB_HISTORIQUE_CLIENT 
                                WHERE CAST(TB_HISTORIQUE_CLIENT.DATE AS DATE) = @Daya";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    command.Parameters.AddWithValue("@Daya", datee);

                    DAaL.sqlConnection.Open();
                    var result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        newID = result.ToString();
                    }
                }
            }
            catch
            {
                return newID;
            } 
            return newID;  
        }

        public string versemnt_normale_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = @"  SELECT SUM(TB_HISTORIQUE_CLIENT.PRICE) 
                                FROM [dbo].TB_HISTORIQUE_CLIENT  
                                WHERE CAST(TB_HISTORIQUE_CLIENT.DATE AS DATE) 
                                BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()";

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

        public string versemnt_normale_Month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = @"  SELECT SUM(TB_HISTORIQUE_CLIENT.PRICE) 
                                FROM [dbo].TB_HISTORIQUE_CLIENT  
                                WHERE CAST(TB_HISTORIQUE_CLIENT.DATE AS DATE) 
                                BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE()";

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

        //cout_commande
        public string total__COUT_TOTAL_commande_jrn(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";


            using (DAaL.sqlConnection)
            {
                // Use today's date in the format 'YYYY-MM-DD' 

                // Modify the query to filter by today's date
                string query = "SELECT SUM(TB_COMMANDE.COUT_TOTAL) FROM [dbo].TB_COMMANDE WHERE CAST(TB_COMMANDE.DATE AS DATE) = @Daya";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    // Add the parameter to the query
                    command.Parameters.AddWithValue("@Daya", datee);

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
        //cout_facteure_vente
        public string cout_facteure_vente(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";


            using (DAaL.sqlConnection)
            {
                // Use today's date in the format 'YYYY-MM-DD' 

                // Modify the query to filter by today's date
                string query = "SELECT SUM(TB_FACTURE_VENTE.cout_of_fctr) FROM [dbo].TB_FACTURE_VENTE WHERE CAST(TB_FACTURE_VENTE.DATE AS DATE) = @Daya";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    // Add the parameter to the query
                    command.Parameters.AddWithValue("@Daya", datee);

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
        //cout_depense
        public string cout_depense(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";


            using (DAaL.sqlConnection)
            {
                // Use today's date in the format 'YYYY-MM-DD' 

                // Modify the query to filter by today's date
                string query = "SELECT Sum([VALEURE] )  FROM [dbo].[TB_DEPENSE] WHERE CAST([DATE] AS DATE)    = @Daya";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    // Add the parameter to the query
                    command.Parameters.AddWithValue("@Daya", datee);

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
        public string cout_ouverier(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";


            using (DAaL.sqlConnection)
            {
                // Use today's date in the format 'YYYY-MM-DD' 

                // Modify the query to filter by today's date
                string query = "SELECT SUM(PRICE_PAYER) FROM [dbo].[TB_VERSEMNT_OUVERIER] WHERE CAST([DATE] AS DATE)   = @Daya";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    // Add the parameter to the query
                    command.Parameters.AddWithValue("@Daya", datee);

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
        #endregion

        #region total ttc commande
        // Total TTC Commande for the last week
        public string total__ttc_commande_last_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_COMMANDE.PRICE_TOTAL_TTC) FROM [dbo].TB_COMMANDE WHERE CAST(TB_COMMANDE.DATE AS DATE) BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()";

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

        // Total TTC Commande for the last month
        public string total__ttc_commande_last_month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_COMMANDE.PRICE_TOTAL_TTC) FROM [dbo].TB_COMMANDE WHERE CAST(TB_COMMANDE.DATE AS DATE) BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE()";

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

        //total__ttc_commande_between_dates
        public string total__ttc_commande_between_dates(string startDate, string endDate)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_COMMANDE.PRICE_TOTAL_TTC) FROM [dbo].TB_COMMANDE WHERE CAST(TB_COMMANDE.DATE AS DATE) BETWEEN @StartDate AND @EndDate";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

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

        #endregion

        #region VersementCommande
        // Versement Commande for the last week
        public string total_versemnt_ttc_commande_last_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_COMMANDE.VERSEMENT) FROM [dbo].TB_COMMANDE WHERE CAST(TB_COMMANDE.DATE AS DATE) BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()";

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

        // Versement Commande for the last month
        public string total_versemnt_ttc_commande_last_month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_COMMANDE.VERSEMENT) FROM [dbo].TB_COMMANDE WHERE CAST(TB_COMMANDE.DATE AS DATE) BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE()";

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

        //total_versemnt_ttc_commande_between_dates
        public string total_versemnt_ttc_commande_between_dates(string startDate, string endDate)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_COMMANDE.VERSEMENT) FROM [dbo].TB_COMMANDE WHERE CAST(TB_COMMANDE.DATE AS DATE) BETWEEN @StartDate AND @EndDate";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

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

        #endregion

        #region  Total Facture Vente
        // Total Facture Vente for the last week
        public string total_facture_Vente_last_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_FACTURE_VENTE.TOTAL_FACURE_TTC) FROM [dbo].TB_FACTURE_VENTE WHERE CAST(TB_FACTURE_VENTE.DATE AS DATE) BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()";

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

        public string total_facture_Vente_last_Month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_FACTURE_VENTE.TOTAL_FACURE_TTC) " +
                    "FROM [dbo].TB_FACTURE_VENTE WHERE CAST(TB_FACTURE_VENTE.DATE AS DATE) " +
                    "BETWEEN DATEADD(Month, -1, GETDATE()) AND GETDATE()";

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

        // Total Facture Vente for the last month
        public string total_facture_Vente_last_month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_FACTURE_VENTE.TOTAL_FACURE_TTC) FROM [dbo].TB_FACTURE_VENTE WHERE CAST(TB_FACTURE_VENTE.DATE AS DATE) BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE()";

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

        //total_facture_Vente_between_dates
        public string total_facture_Vente_between_dates(string startDate, string endDate)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_FACTURE_VENTE.TOTAL_FACURE_TTC) FROM [dbo].TB_FACTURE_VENTE WHERE CAST(TB_FACTURE_VENTE.DATE AS DATE) BETWEEN @StartDate AND @EndDate";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

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

        #endregion

        #region Versement Facture Vente
        // Versement Facture Vente for the last week
        public string versement_facture_Vente_last_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_FACTURE_VENTE.VERSEMENT) " +
                    "FROM [dbo].TB_FACTURE_VENTE WHERE CAST(TB_FACTURE_VENTE.DATE AS DATE) " +
                    "BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()";

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

        public string versement_facture_Vente_last_Month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_FACTURE_VENTE.VERSEMENT) " +
                    "FROM [dbo].TB_FACTURE_VENTE WHERE CAST(TB_FACTURE_VENTE.DATE AS DATE) " +
                    "BETWEEN DATEADD(Month, -1, GETDATE()) AND GETDATE()";

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

        // Versement Facture Vente for the last month
        public string versement_facture_Vente_last_month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_FACTURE_VENTE.VERSEMENT) FROM [dbo].TB_FACTURE_VENTE WHERE CAST(TB_FACTURE_VENTE.DATE AS DATE) BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE()";

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

        //versement_facture_Vente_between_dates
        public string versement_facture_Vente_between_dates(string startDate, string endDate)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_FACTURE_VENTE.VERSEMENT) FROM [dbo].TB_FACTURE_VENTE WHERE CAST(TB_FACTURE_VENTE.DATE AS DATE) BETWEEN @StartDate AND @EndDate";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

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

        #endregion

        #region Total COUT Commande
        // Total COUT Commande for the last week
        public string total__COUT_TOTAL_commande_last_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_COMMANDE.COUT_TOTAL) FROM [dbo].TB_COMMANDE WHERE CAST(TB_COMMANDE.DATE AS DATE) BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()";

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

        // Total COUT Commande for the last month
        public string total__COUT_TOTAL_commande_last_month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_COMMANDE.COUT_TOTAL) FROM [dbo].TB_COMMANDE WHERE CAST(TB_COMMANDE.DATE AS DATE) BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE()";

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

        //total__COUT_TOTAL_commande_between_dates
        public string total__COUT_TOTAL_commande_between_dates(string startDate, string endDate)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_COMMANDE.COUT_TOTAL) FROM [dbo].TB_COMMANDE WHERE CAST(TB_COMMANDE.DATE AS DATE) BETWEEN @StartDate AND @EndDate";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

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

        #endregion

        #region COUT Facture Vente 
        // COUT Facture Vente for the last week
        public string cout_facteure_vente_last_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = @"SELECT SUM(TB_FACTURE_VENTE.cout_of_fctr) FROM [dbo].TB_FACTURE_VENTE 
                               WHERE CAST(TB_FACTURE_VENTE.DATE AS DATE) BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()";

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
        public string cout_facteure_vente_last_Month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = @"SELECT SUM(TB_FACTURE_VENTE.cout_of_fctr) FROM [dbo].TB_FACTURE_VENTE 
                               WHERE CAST(TB_FACTURE_VENTE.DATE AS DATE) BETWEEN DATEADD(Month, -1, GETDATE()) AND GETDATE()";

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

        // COUT Facture Vente for the last month
        public string cout_facteure_vente_last_month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_FACTURE_VENTE.cout_of_fctr) FROM [dbo].TB_FACTURE_VENTE WHERE CAST(TB_FACTURE_VENTE.DATE AS DATE) BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE()";

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

        //cout_facteure_vente_between_dates
        public string cout_facteure_vente_between_dates(string startDate, string endDate)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_FACTURE_VENTE.cout_of_fctr) FROM [dbo].TB_FACTURE_VENTE WHERE CAST(TB_FACTURE_VENTE.DATE AS DATE) BETWEEN @StartDate AND @EndDate";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

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

        #endregion

        #region COUT Depense
        // COUT Depense for the last week
        public string cout_depense_last_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM([VALEURE]) FROM [dbo].[TB_DEPENSE] WHERE CAST([DATE] AS DATE) BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()";

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
        public string cout_depense_last_Month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM([VALEURE]) FROM [dbo].[TB_DEPENSE] " +
                    "WHERE CAST([DATE] AS DATE) BETWEEN DATEADD(Month, -1, GETDATE()) AND GETDATE()";

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
        // COUT Depense for the last month
        public string cout_depense_last_month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM([VALEURE]) FROM [dbo].[TB_DEPENSE] WHERE CAST([DATE] AS DATE) BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE()";

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

        //cout_depense_between_dates
        public string cout_depense_between_dates(string startDate, string endDate)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM([VALEURE]) FROM [dbo].[TB_DEPENSE] WHERE CAST([DATE] AS DATE) BETWEEN @StartDate AND @EndDate";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

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

        #endregion

        #region COUT Ouvrier

        // COUT Ouvrier for the last week
        public string cout_ouverier_last_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(PRICE_PAYER) FROM [dbo].[TB_VERSEMNT_OUVERIER] WHERE CAST([DATE] AS DATE) BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()";

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

        // COUT Ouvrier for the last month
        public string cout_ouverier_last_month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(PRICE_PAYER) FROM [dbo].[TB_VERSEMNT_OUVERIER] WHERE CAST([DATE] AS DATE) BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE()";

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

        //cout_ouverier_between_dates
        public string cout_ouverier_between_dates(string startDate, string endDate)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(PRICE_PAYER) FROM [dbo].[TB_VERSEMNT_OUVERIER] WHERE CAST([DATE] AS DATE) BETWEEN @StartDate AND @EndDate";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

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

        #endregion 

        #region Routeure JOOUNE
        public string total_routeure_price(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";


            using (DAaL.sqlConnection)
            {
                // Use today's date in the format 'YYYY-MM-DD' 

                // Modify the query to filter by today's date
                string query = "SELECT Sum(Price_TTl)  FROM [dbo].TB_ROUTOUR_PRODUIT WHERE CAST([DATE] AS DATE)    = @Daya";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    // Add the parameter to the query
                    command.Parameters.AddWithValue("@Daya", datee);

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
        public string cout_derouteure(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";


            using (DAaL.sqlConnection)
            {
                // Use today's date in the format 'YYYY-MM-DD' 

                // Modify the query to filter by today's date
                string query = "SELECT Sum(PRice_achat_ttl)  FROM [dbo].TB_ROUTOUR_PRODUIT WHERE CAST([DATE] AS DATE)     = @Daya";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    // Add the parameter to the query
                    command.Parameters.AddWithValue("@Daya", datee);

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
        public string deference_routeur(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";


            using (DAaL.sqlConnection)
            {
                // Use today's date in the format 'YYYY-MM-DD' 

                // Modify the query to filter by today's date
                string query = "SELECT Sum(Price_TTl - PRice_achat_ttl)  FROM [dbo].TB_ROUTOUR_PRODUIT WHERE CAST([DATE] AS DATE)     = @Daya";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    // Add the parameter to the query
                    command.Parameters.AddWithValue("@Daya", datee);

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
        #endregion
        #region week
        public string total_routeure_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(Price_TTl) FROM [dbo].TB_ROUTOUR_PRODUIT WHERE CAST([DATE] AS DATE) BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()";

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
        public string cout_routeure_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(PRice_achat_ttl) FROM [dbo].TB_ROUTOUR_PRODUIT WHERE CAST([DATE] AS DATE) BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()";

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
        public string deference_routeure_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(Price_TTl-PRice_achat_ttl) FROM [dbo].TB_ROUTOUR_PRODUIT WHERE CAST([DATE] AS DATE) BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()";

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
        #endregion
        #region month
        public string total_routeur()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(Price_TTl) FROM [dbo].TB_ROUTOUR_PRODUIT WHERE CAST([DATE] AS DATE) BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE()";

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
        public string coout_route()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(PRice_achat_ttl) FROM [dbo].TB_ROUTOUR_PRODUIT WHERE CAST([DATE] AS DATE) BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE()";

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
        public string defernce()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(Price_TTl-PRice_achat_ttl) FROM [dbo].TB_ROUTOUR_PRODUIT WHERE CAST([DATE] AS DATE) BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE()";

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
        #endregion
        #region between tow date
        public string total_routeure(string startDate, string endDate)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(Price_TTl) FROM [dbo].[TB_ROUTOUR_PRODUIT] WHERE CAST([DATE] AS DATE) BETWEEN @StartDate AND @EndDate";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

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
        public string cout_total(string startDate, string endDate)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(PRice_achat_ttl) FROM [dbo].[TB_ROUTOUR_PRODUIT] WHERE CAST([DATE] AS DATE) BETWEEN @StartDate AND @EndDate";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

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
        public string deference(string startDate, string endDate)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(Price_TTl-PRice_achat_ttl) FROM [dbo].[TB_ROUTOUR_PRODUIT] WHERE CAST([DATE] AS DATE) BETWEEN @StartDate AND @EndDate";

                using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

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
        #endregion

    }

}
