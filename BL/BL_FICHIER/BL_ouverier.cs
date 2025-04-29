using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; 
using System.Data;

namespace Smart_Production_Pos.BL.BL_FICHIER
{
	public class BL_ouverier
	{
		
		public DataTable get_tb_ouverier()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_list_ouverie", null);
			DAL.Close();
			return Dt;
		}

		////////////////*************   ADD Client   **************///////////////
		DAL.DAL daoo;
		public void add_ouverier(
			string NAME,
			string PRENAME,
			string FONCTION,
			string PHONE
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("add_ouverier", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = NAME;
					cmd.Parameters.Add("@PRENAME", SqlDbType.NVarChar).Value = PRENAME;
					cmd.Parameters.Add("@FONCTION", SqlDbType.NVarChar).Value = FONCTION;
					cmd.Parameters.Add("@PHONE", SqlDbType.NVarChar).Value = PHONE;  

					cmd.ExecuteNonQuery();
				}
			}
		}


		public void edit_tb_ouverier(
				int ID
			   , string NAME,
			   string PRENAME,
			   string FONCTION,
			   string PHONE
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("edit_tb_ouverier", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
					cmd.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = NAME;
					cmd.Parameters.Add("@PRENAME", SqlDbType.NVarChar).Value = PRENAME;
					cmd.Parameters.Add("@FONCTION", SqlDbType.NVarChar).Value = FONCTION;
					cmd.Parameters.Add("@PHONE", SqlDbType.NVarChar).Value = PHONE;

					cmd.ExecuteNonQuery();
				}
			}
		}
		#region Search 
		public DataTable search_ouverier(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar, 50);
			param[0].Value = id;
			Dt = DAL.SelectData("search_ouverier", param);
			DAL.Close();
			return Dt;
		}
		#endregion
		public void delte_ouverierID(
			 int id
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("delte_ouverierID", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
					cmd.ExecuteNonQuery();
				}
			}
		}

	}
}
