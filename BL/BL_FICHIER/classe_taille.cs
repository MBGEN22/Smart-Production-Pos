using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_FICHIER
{
	public class classe_taille
	{
		public DataTable select_tb_taille()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("select_tb_taille", null);
			DAL.Close();
			return Dt;
		}
		DAL.DAL daoo;
		public void insert_Taille(string Taille)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();
				using (SqlCommand cmd = new SqlCommand("insert_Taille", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@Taille", SqlDbType.NVarChar).Value = Taille;
					cmd.ExecuteNonQuery();
				}
			}
		}
		public void delte_taille(int id)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();
				using (SqlCommand cmd = new SqlCommand("delte_taille", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
					cmd.ExecuteNonQuery();
				}
			}
		}
		public void update_taille(int id, string Taille)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("update_taille", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
					cmd.Parameters.Add("@Taille", SqlDbType.NVarChar).Value = Taille;
					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
