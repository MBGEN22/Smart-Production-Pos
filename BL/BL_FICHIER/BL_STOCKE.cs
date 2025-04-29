using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_FICHIER
{
	public class BL_STOCKE
	{ 
		#region SELECT region

		public DataTable get_Stockes_table()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_list_stocke", null);
			DAL.Close();
			return Dt;
		}

		
		#endregion

		#region Add region   
		DAL.DAL daoo;
		public void Add_Stockes(
			string Stock
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("add_stock", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@STOCK", SqlDbType.NVarChar).Value = Stock;
					cmd.ExecuteNonQuery();
				}
			}
		}
		#endregion

		#region supp region 
		public void delete_stockes(
			 int id
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("delte_stocke", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
					cmd.ExecuteNonQuery();
				}
			}
		}
		#endregion

		#region edit region 
		public void edit_stockes(
			  int ID
			  , string Stock
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("edit_stockes", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
					cmd.Parameters.Add("@STOCK", SqlDbType.NVarChar).Value = Stock;
					cmd.ExecuteNonQuery();
				}
			}
		}
		#endregion

		#region Search 
		public DataTable searche_list_stocke(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar, 50);
			param[0].Value = id;
			Dt = DAL.SelectData("searche_list_stocke", param);
			DAL.Close();
			return Dt;
		}
		#endregion


	}
}
