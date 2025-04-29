using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_CLIENT
{
	public class BL_REMARQUE_CLIENT
	{
		public DataTable get_tb_remarque_client()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_tb_remarque_client", null);
			DAL.Close();
			return Dt;
		}

		DAL.DAL daoo; 
		public void add_tb_remarque_client( 
			     int Client
			   , string REMARQUE 
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open(); 
				using (SqlCommand cmd = new SqlCommand("add_tb_remarque_client", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure; 
					cmd.Parameters.Add("@ID_CLIENT", SqlDbType.Int).Value = Client;
					cmd.Parameters.Add("@REMARQUE_DE_CLIENT", SqlDbType.NVarChar).Value = REMARQUE;  
					cmd.ExecuteNonQuery();
				}
			} 
		}

		public DataTable search_by_client(string Search)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@Search", SqlDbType.NVarChar);
			param[0].Value = Search;
			Dt = DAL.SelectData("search_tb_remarque_client", param);
			DAL.Close();
			return Dt;
		}

		public void delete_remarque_client(
				 int ID 
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();
				using (SqlCommand cmd = new SqlCommand("delete_remarque_client", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID; 
					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
