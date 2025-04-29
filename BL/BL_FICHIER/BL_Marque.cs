using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_FICHIER
{
	public class BL_Marque
	{
		#region SELECT region

		public DataTable get_TB_MARQUE()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_TB_MARQUE", null);
			DAL.Close();
			return Dt;
		}

		#endregion

		#region Add region   
		DAL.DAL daoo;
		public void insert_marque(
			string Marque
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("insert_marque", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@Marque", SqlDbType.NVarChar).Value = Marque;
					cmd.ExecuteNonQuery();
				}
			}
		}
		#endregion

		#region supp region 
		public void delte_TB_MARQUE(
			 int id
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("delte_TB_MARQUE", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
					cmd.ExecuteNonQuery();
				}
			}
		}
		#endregion

		#region edit region 
		public void edit_Marque(
			  int ID
			  , string Marque
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("edit_marque", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
					cmd.Parameters.Add("@Marque", SqlDbType.NVarChar).Value = Marque;
					cmd.ExecuteNonQuery();
				}
			}
		}
		#endregion

		#region Search 
		public DataTable searche_list_Marque(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar, 50);
			param[0].Value = id;
			Dt = DAL.SelectData("searche_list_Marque", param);
			DAL.Close();
			return Dt;
		}
		#endregion
	}
}
