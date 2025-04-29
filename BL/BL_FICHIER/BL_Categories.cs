using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_FICHIER
{
	public class BL_Categories
	{
		#region SELECT region

		public DataTable get_tb_Categories()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_tb_Categories", null);
			DAL.Close();
			return Dt;
		}

		#endregion

		#region Add region   
		DAL.DAL daoo;
		public void insert_categories(
			string CATEGORIES
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("insert_categories", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@CATEGORIES", SqlDbType.NVarChar).Value = CATEGORIES;
					cmd.ExecuteNonQuery();
				}
			}
		}
		#endregion

		#region supp region 
		public void delte_CATEGORIES(
			 int id
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("delte_CATEGORIES", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
					cmd.ExecuteNonQuery();
				}
			}
		}
		#endregion

		#region edit region 
		public void edit_CATEGORIES(
			  int ID
			  , string CATEGORIES
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("edit_CATEGORIES", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
					cmd.Parameters.Add("@CATEGORIES", SqlDbType.NVarChar).Value = CATEGORIES;
					cmd.ExecuteNonQuery();
				}
			}
		}
		#endregion

		#region Search 
		public DataTable searche_list_Categories(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar, 50);
			param[0].Value = id;
			Dt = DAL.SelectData("[searche_list_Categories]", param);
			DAL.Close();
			return Dt;
		}
		#endregion
	}
}
