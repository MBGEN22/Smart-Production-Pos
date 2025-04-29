using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_FICHIER
{
	public class BL_CAISSIER
	{
		//////////////////////// GetTable Client
		public DataTable get_tb_caissier()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_tb_caissier", null);
			DAL.Close();
			return Dt;
		}
		#region Search 
		public DataTable search_caisiier(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar, 50);
			param[0].Value = id;
			Dt = DAL.SelectData("search_caissier", param);
			DAL.Close();
			return Dt;
		}
		#endregion
		////////////////*************   ADD Client   **************///////////////
		DAL.DAL daoo;
		public void insert_cassier_info(
			string NAME,
			string PRENAME,
			string USER_NAME,
			string PASSW
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("insert_cassier_info", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = NAME;
					cmd.Parameters.Add("@PRENAME", SqlDbType.NVarChar).Value = PRENAME;
					cmd.Parameters.Add("@USER_NAME", SqlDbType.NVarChar).Value = USER_NAME;
					cmd.Parameters.Add("@PASSW", SqlDbType.NVarChar).Value = PASSW; 


					cmd.ExecuteNonQuery();
				}
			}
		}


		public void edit_client(
				int ID
			   , string NAME,
				string PRENAME,
				string USER_NAME,
				string PASSW
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("update_cassier_info", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
					cmd.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = NAME;
					cmd.Parameters.Add("@PRENAME", SqlDbType.NVarChar).Value = PRENAME;
					cmd.Parameters.Add("@USER_NAME", SqlDbType.NVarChar).Value = USER_NAME;
					cmd.Parameters.Add("@PASSW", SqlDbType.NVarChar).Value = PASSW;

					cmd.ExecuteNonQuery();
				}
			}
		}

		public void delte_Client(
			 int id
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("delete_cassier_info", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
