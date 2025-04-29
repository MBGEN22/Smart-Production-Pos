using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL
{
	public class Client_history_sold
	{
		public DataTable get_TB_historique_Client()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("GET_TABLE_HISTORIQUE_CLIENT", null);
			DAL.Close();
			return Dt;
		}
		#region search
		public DataTable search_by_client(int ID_CLIENT)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_CLIENT", SqlDbType.Int);
			param[0].Value = ID_CLIENT;
			Dt = DAL.SelectData("SEARCH_HISTORIQUE_BY_CLIENT", param);
			DAL.Close();
			return Dt;
		}

		public DataTable search_on_histoyry_client(string ID_search)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar);
			param[0].Value = ID_search;
			Dt = DAL.SelectData("search_on_history_client", param);
			DAL.Close();
			return Dt;
		}

		public DataTable search_date(DateTime date)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@DATE", SqlDbType.Date);
			param[0].Value = date;
			Dt = DAL.SelectData("SEARCH_HISTORIQUE_CLIENT_BY_DATE", param);
			DAL.Close();
			return Dt;
		}

		public DataTable search_between_date(DateTime StartDate, DateTime EndDate)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[2];
			param[0] = new SqlParameter("@StartDate", SqlDbType.Date);
			param[0].Value = StartDate;
			param[1] = new SqlParameter("@EndDate", SqlDbType.Date);
			param[1].Value = EndDate;
			Dt = DAL.SelectData("SearchBetweenTwoDates", param);
			DAL.Close();
			return Dt;
		}


		#endregion


		DAL.DAL daoo; 

		public void edit_sold_client(
				 int ID
			   , decimal Solde_verse
			   , decimal credit_new
			   , decimal credit_total
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("update_client_payment", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
					cmd.Parameters.Add("@Solde_verse", SqlDbType.Money).Value = Solde_verse;
					cmd.Parameters.Add("@credit_new", SqlDbType.Money).Value = credit_new;
					cmd.Parameters.Add("@credit_total", SqlDbType.Money).Value = credit_total;

					cmd.ExecuteNonQuery();
				}
			}
		}

		public void edit_sold_client_avance(
				 int ID
			   , decimal avance
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("update_client_payment_avance", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
					cmd.Parameters.Add("@avance", SqlDbType.Money).Value = avance; 

					cmd.ExecuteNonQuery();
				}
			}
		}

		public void insert_history_client(
				  DateTime DATE
				, int ID_CLIENT
				, decimal total_amount
				, decimal PRICE
				, decimal CREDIT_OLD
				, decimal CREDIT_NEW
				, string REMARQUE 
				, string ID_FACTURE
               )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("insert_tb_historique_clien", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@DATE", SqlDbType.Date).Value = DATE;
					cmd.Parameters.Add("@ID_CLIENT", SqlDbType.Int).Value = ID_CLIENT;
                    cmd.Parameters.Add("@total_amount", SqlDbType.Money).Value = total_amount;
                    cmd.Parameters.Add("@PRICE", SqlDbType.Money).Value = PRICE;
					cmd.Parameters.Add("@CREDIT_OLD", SqlDbType.Money).Value = CREDIT_OLD;
					cmd.Parameters.Add("@CREDIT_NEW", SqlDbType.Money).Value = CREDIT_NEW;
					cmd.Parameters.Add("@REMARQUE", SqlDbType.NVarChar).Value = REMARQUE;
                    cmd.Parameters.Add("@ID_FACTURE", SqlDbType.NVarChar).Value = ID_FACTURE;


                    cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
