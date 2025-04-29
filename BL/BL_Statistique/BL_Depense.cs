using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_Statistique
{
	public class BL_Depense
	{//////////////////////// GetTable Client
		public DataTable get_TB_depense()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_tb_depense", null);
			DAL.Close();
			return Dt;
		}
		public DataTable search_get_tb_depense(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("search_get_tb_depense", param);
			DAL.Close();
			return Dt;
		}
		////////////////*************   ADD Client   **************///////////////
		DAL.DAL daoo;
		public void Add_Funct(
			 string CAUSE_DEPENSE,
			 decimal VALEURE,
			 DateTime DATE,
			  int USER_ID
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("insert_tb_depense", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@CAUSE_DEPENSE", SqlDbType.NVarChar).Value = CAUSE_DEPENSE;
					cmd.Parameters.Add("@VALEURE", SqlDbType.Money).Value = VALEURE;
					cmd.Parameters.Add("@DATE", SqlDbType.DateTime).Value = DATE;
					cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;  
					cmd.ExecuteNonQuery();
				}
			}
		}

		public void update_Depense(
			int ID,
			 string CAUSE_DEPENSE,
			 decimal VALEURE,
			 DateTime DATE,
			  int USER_ID
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("update_Depense", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
					cmd.Parameters.Add("@CAUSE_DEPENSE", SqlDbType.NVarChar).Value = CAUSE_DEPENSE;
					cmd.Parameters.Add("@VALEURE", SqlDbType.Money).Value = VALEURE;
					cmd.Parameters.Add("@DATE", SqlDbType.DateTime).Value = DATE;
					cmd.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;
					cmd.ExecuteNonQuery();
				}
			}
		}

		public void delte_depense(
			 int id
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("delte_depense", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
