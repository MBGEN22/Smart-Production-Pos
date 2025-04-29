using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_FICHIER
{
	public class class_color
	{
		public DataTable select_TB_color()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("select_TB_color", null);
			DAL.Close();
			return Dt;
		}
		DAL.DAL daoo;
		public void insert_color(  string color )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{ 
				daoo.sqlConnection.Open(); 
				using (SqlCommand cmd = new SqlCommand("insert_color", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure; 
					cmd.Parameters.Add("@Color", SqlDbType.NVarChar).Value = color;
					cmd.ExecuteNonQuery();
				}
			}
		}
		public void delete_color_(int id)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();
				using (SqlCommand cmd = new SqlCommand("delete_color_", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
					cmd.ExecuteNonQuery();
				}
			}
		}
		public void update_color_name( int id, string Color )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("update_color_name", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
					cmd.Parameters.Add("@Color", SqlDbType.NVarChar).Value = Color;
					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
