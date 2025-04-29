using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Smart_Production_Pos.BL.BL_FICHIER;

namespace Smart_Production_Pos.BL
{
	public class frnsre_history_sold
	{
		public DataTable get_TB_historique_fournisseur()
		{ 
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_TB_historique_fournisseur", null);
			DAL.Close();
			return Dt;
		}
		DAL.DAL daoo;
		#region search
		public DataTable search_by_frnsr(int ID_FOURNISSEUR)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_FOURNISSEUR", SqlDbType.Int);
			param[0].Value = ID_FOURNISSEUR;
			Dt = DAL.SelectData("SEARCH_HISTORY_BY_FOURNISSEUR", param);
			DAL.Close();
			return Dt;
		}

		public DataTable search_on_history_frnsr(string ID_search)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar);
			param[0].Value = ID_search;
			Dt = DAL.SelectData("search_on_history_frnsr", param);
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
			Dt = DAL.SelectData("SEARCH_HISTORY_PAR_DATE", param);
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
			Dt = DAL.SelectData("SearchBetweenTwoDates_historique_frnsre", param);
			DAL.Close();
			return Dt;
		}

		#endregion
		public void edit_sold_frnse(
				 int ID
			   , decimal SOLD_TOTAL
			   , decimal SOLD_PAYE
			   , decimal SOLD_NON_PAYE
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("UPDATE_SOLD_FRNSRE", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
					cmd.Parameters.Add("@SOLD_TOTAL", SqlDbType.Money).Value = SOLD_TOTAL;
					cmd.Parameters.Add("@SOLD_PAYE", SqlDbType.Money).Value = SOLD_PAYE;
					cmd.Parameters.Add("@SOLD_NON_PAYE", SqlDbType.Money).Value = SOLD_NON_PAYE;

					cmd.ExecuteNonQuery();
				}
			}
		}


		public void insert_history_frnsre( 
				  DateTime DATE
				, int ID_CLIENT
				, decimal PRICE
				, decimal CREDIT_OLD
				, decimal CREDIT_NEW
				, string  REMARQUE 
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("insert_history_frnsre", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@DATE", SqlDbType.Date).Value = DATE;
					cmd.Parameters.Add("@ID_CLIENT", SqlDbType.Int).Value = ID_CLIENT;
					cmd.Parameters.Add("@PRICE", SqlDbType.Money).Value = PRICE;
					cmd.Parameters.Add("@CREDIT_OLD", SqlDbType.Money).Value = CREDIT_OLD;
					cmd.Parameters.Add("@CREDIT_NEW", SqlDbType.Money).Value = CREDIT_NEW;
					cmd.Parameters.Add("@REMARQUE", SqlDbType.NVarChar).Value = REMARQUE;

					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
