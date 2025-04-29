using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Data;
using System.Data.SqlClient;

namespace Smart_Production_Pos.BL
{
    class BL_State_new
    {
        #region bon
        //--------------------------- day
        public DataTable get_sum_of_Qt_vente_state_unite()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("get_sum_of_Qt_vente_state_unite", null);
			DAL.Close();
			return Dt;
		}
		 
		public DataTable get_sum_of_Qt_vente_state_pack()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("get_sum_of_Qt_vente_state_pack", null);
			DAL.Close();
			return Dt;
		}

		public DataTable get_fctr_on_state(DateTime date)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@date", SqlDbType.Date);
			param[0].Value = date;
			Dt = DAL.SelectData("get_fctr_on_state", param);
			DAL.Close();
			return Dt;
		}

		//------------------------------ week
		public DataTable get_sum_of_Qt_vente_state_unite_week()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("get_sum_of_Qt_vente_state_unite_week", null);
			DAL.Close();
			return Dt;
		}

		public DataTable get_sum_of_Qt_vente_state_pack_week()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("get_sum_of_Qt_vente_state_pack_week", null);
			DAL.Close();
			return Dt;
		}
		
		public DataTable get_fctr_on_state_week()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("get_fctr_on_state_week", null);
			DAL.Close();
			return Dt;
		}

		//------------------------------ Monthe
		public DataTable get_sum_of_Qt_vente_state_unite_Monthe()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("get_sum_of_Qt_vente_state_unite_Monthe", null);
			DAL.Close();
			return Dt;
		}

		public DataTable get_sum_of_Qt_vente_state_pack_Monthe()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("get_sum_of_Qt_vente_state_pack_Monthe", null);
			DAL.Close();
			return Dt;
		}

		public DataTable get_fctr_on_state_Monthe()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("get_fctr_on_state_Month", null);
			DAL.Close();
			return Dt;
		}

        //------------------------------ day specifique
        public DataTable get_sum_of_Qt_vente_state_unite_day_specifique(DateTime date)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@date", SqlDbType.Date);
            param[0].Value = date;
            Dt = DAL.SelectData("get_sum_of_Qt_vente_state_unite_day_specifique", param);
            DAL.Close();
            return Dt;
        }

        public DataTable get_sum_of_Qt_vente_state_pack_day_specifiuqe(DateTime date)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@date", SqlDbType.Date);
            param[0].Value = date;
            Dt = DAL.SelectData("get_sum_of_Qt_vente_state_pack_day_specifiuqe", param);
            DAL.Close();
            return Dt;
        }
        #endregion
        #region facture 
        //---------------------------------------------- facture vente -------------------------------------------------//
        //--------------------------- day
        public DataTable get_sum_of_Qt_facture_state_unite()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            Dt = DAL.SelectData("get_sum_of_Qt_facture_state_unite", null);
            DAL.Close();
            return Dt;
        }

        public DataTable get_sum_of_Qt_facture_state_pack()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            Dt = DAL.SelectData("get_sum_of_Qt_facture_state_pack", null);
            DAL.Close();
            return Dt;
        }

        public DataTable get_facturation_on_state(DateTime date)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@date", SqlDbType.Date);
            param[0].Value = date;
            Dt = DAL.SelectData("get_facturation_on_state", param);
            DAL.Close();
            return Dt;
        }

        //------------------------------ week
        public DataTable get_sum_of_Qt_facture_state_unite_week()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            Dt = DAL.SelectData("get_sum_of_Qt_facture_state_unite_week", null);
            DAL.Close();
            return Dt;
        }

        public DataTable get_sum_of_Qt_facture_state_pack_weel()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            Dt = DAL.SelectData("get_sum_of_Qt_facture_state_pack_weel", null);
            DAL.Close();
            return Dt;
        }

        public DataTable get_facturantion_on_state_week()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            Dt = DAL.SelectData("get_facturantion_on_state_week", null);
            DAL.Close();
            return Dt;
        }

        //------------------------------ Monthe
        public DataTable get_sum_of_Qt_facture_state_unite_month()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            Dt = DAL.SelectData("get_sum_of_Qt_facture_state_unite_month", null);
            DAL.Close();
            return Dt;
        }

        public DataTable get_sum_of_Qt_facture_state_pack_month()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            Dt = DAL.SelectData("get_sum_of_Qt_facture_state_pack_month", null);
            DAL.Close();
            return Dt;
        }

        public DataTable get_facturation_on_state_Month()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            Dt = DAL.SelectData("get_facturation_on_state_Month", null);
            DAL.Close();
            return Dt;
        }

        //------------------------------ day specifique
        public DataTable get_sum_of_Qt_facturatnion_state_unite_day_specifique(DateTime date)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@date", SqlDbType.Date);
            param[0].Value = date;
            Dt = DAL.SelectData("get_sum_of_Qt_facturatnion_state_unite_day_specifique", param);
            DAL.Close();
            return Dt;
        }

        public DataTable get_sum_of_Qt_facturatnion_state_pack_day_specifiuqe(DateTime date)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@date", SqlDbType.Date);
            param[0].Value = date;
            Dt = DAL.SelectData("get_sum_of_Qt_facturatnion_state_pack_day_specifiuqe", param);
            DAL.Close();
            return Dt;
        }
        #endregion

        #region calcule 
        public string total_facture_Vente(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_FACTURATION.Total_ttc) FROM [dbo].TB_FACTURATION WHERE TB_FACTURATION.DATE = @Daya";

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
        public string total_versement_facture_Vente(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_FACTURATION.versement) FROM [dbo].TB_FACTURATION WHERE TB_FACTURATION.DATE = @Daya";

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
        public string total_cout_facture_Vente(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_FACTURATION.cout_fctr) FROM [dbo].TB_FACTURATION WHERE TB_FACTURATION.DATE = @Daya";

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

        public string versement_facture_Vente_anonymos(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";


            using (DAaL.sqlConnection)
            {
                // Use today's date in the format 'YYYY-MM-DD' 

                // Modify the query to filter by today's date
                string query = @"SELECT SUM(TB_FACTURATION.VERSEMENT) FROM [dbo].TB_FACTURATION WHERE 
                                CAST(TB_FACTURATION.DATE AS DATE) = @Daya and TB_FACTURATION.ID_CLIENT = 1; ";

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

        public string versement_facture_Vente_non_anonymos(string datee)
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";


            using (DAaL.sqlConnection)
            {
                // Use today's date in the format 'YYYY-MM-DD' 

                // Modify the query to filter by today's date
                string query = @"SELECT SUM(TB_FACTURATION.VERSEMENT) FROM [dbo].TB_FACTURATION WHERE 
                                CAST(TB_FACTURATION.DATE AS DATE) = @Daya and TB_FACTURATION.ID_CLIENT != 1; ";

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

        #region calcule_rest
        //last week
        public string cout_facteure_vente_last_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = @"SELECT SUM(TB_FACTURATION.cout_fctr) FROM [dbo].TB_FACTURATION  WHERE CAST(TB_FACTURATION.DATE AS DATE) BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()";

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

        public string total__ttc_commande_last_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_FACTURATION.Total_ttc) FROM [dbo].TB_FACTURATION \r\nWHERE CAST(TB_FACTURATION.DATE AS DATE) BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()";

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
        
        public string versement_facture_Vente_last_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_FACTURATION.versement) FROM [dbo].TB_FACTURATION \r\nWHERE CAST(TB_FACTURATION.DATE AS DATE) BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()";

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
        public string versement_facture_Vente_anonymos_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = @" SELECT SUM(TB_FACTURATION.VERSEMENT) 
                                FROM [dbo].TB_FACTURATION 
                                WHERE CAST(TB_FACTURATION.DATE AS DATE) 
                                BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()
                                and TB_FACTURATION.ID_CLIENT = 1";

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

        public string versement_facture_Vente_non_anonymos_week()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = @" SELECT SUM(TB_FACTURATION.VERSEMENT) 
                                FROM [dbo].TB_FACTURATION 
                                WHERE CAST(TB_FACTURATION.DATE AS DATE) 
                                BETWEEN DATEADD(WEEK, -1, GETDATE()) AND GETDATE()
                                and TB_FACTURATION.ID_CLIENT != 1";

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

        //last month
        public string cout_facteure_vente_last_month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = @"SELECT SUM(TB_FACTURATION.cout_fctr) FROM [dbo].TB_FACTURATION  WHERE CAST(TB_FACTURATION.DATE AS DATE) BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE()";

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

        public string total__ttc_commande_last_month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_FACTURATION.Total_ttc) FROM [dbo].TB_FACTURATION \r\nWHERE CAST(TB_FACTURATION.DATE AS DATE) BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE()";

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

        public string versement_facture_Vente_lastmonth()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = "SELECT SUM(TB_FACTURATION.versement) FROM [dbo].TB_FACTURATION \r\nWHERE CAST(TB_FACTURATION.DATE AS DATE) BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE()";

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
        public string versement_facture_Vente_anonymos_month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = @" SELECT SUM(TB_FACTURATION.VERSEMENT) 
                                FROM [dbo].TB_FACTURATION 
                                WHERE CAST(TB_FACTURATION.DATE AS DATE) 
                                BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE()
                                and TB_FACTURATION.ID_CLIENT = 1";

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

        public string versement_facture_Vente_non_anonymos_month()
        {
            DAL.DAL DAaL = new DAL.DAL();
            string newID = "0";

            using (DAaL.sqlConnection)
            {
                string query = @" SELECT SUM(TB_FACTURATION.VERSEMENT) 
                                FROM [dbo].TB_FACTURATION 
                                WHERE CAST(TB_FACTURATION.DATE AS DATE) 
                                BETWEEN DATEADD(MONTH, -1, GETDATE()) AND GETDATE()
                                and TB_FACTURATION.ID_CLIENT != 1";

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
    }
}
