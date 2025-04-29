using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_ACHAT_REVENT
{
	public class BL_calculate
	{
		 
		public int _nmbre_produit()
		{
			DAL.DAL DAaL = new DAL.DAL();

			int newID = 1;

			using (DAaL.sqlConnection)
			{
				string query = "select Count(TOTAL_TTC) from TB_ACHAT_PRODUIT_REVENT_CAISSE;";
				using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
				{
					DAaL.sqlConnection.Open();
					var result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						newID = Convert.ToInt32(result) + 0;
					}
				}
			}
			return newID;
		}
		public int get_TOTAL_TTC()
		{
			DAL.DAL DAaL = new DAL.DAL();

			int newID = 0;

			using (DAaL.sqlConnection)
			{
				string query = "select SUM(TOTAL_TTC) from TB_ACHAT_PRODUIT_REVENT_CAISSE;";
				using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
				{
					DAaL.sqlConnection.Open();
					var result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						newID = Convert.ToInt32(result) + 0;
					}
				}
			}
			return newID;
		}
		public int get_TOTAL_HT()
		{
			DAL.DAL DAaL = new DAL.DAL();

			int newID = 0;

			using (DAaL.sqlConnection)
			{
				string query = "select SUM(TOTAL_HT) from TB_ACHAT_PRODUIT_REVENT_CAISSE;";
				using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
				{
					DAaL.sqlConnection.Open();
					var result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						newID = Convert.ToInt32(result) + 0;
					}
				}
			}
			return newID;
		}

		public string get_facture_number()
		{

			DAL.DAL DAaL = new DAL.DAL();

			string newID = "";

			using (DAaL.sqlConnection)
			{
				string query = "select concat('FCR', format(convert(int, stuff(max(NMR_FCTR), 1, 3, ''))+1 , '0000'))  from [TB_FACTURE_ACHAT_PRODUIT_REVENT]";
				using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
				{
					DAaL.sqlConnection.Open();
					var result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						newID = result.ToString();
					}
				}
			}
			return newID;
		}
		public DataTable get_Caisse_table()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("GET_CAISSE_PRODUIT_REVENT", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_count_product(string CodeBarre)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@CodeBarre", SqlDbType.NVarChar);
			param[0].Value = CodeBarre;
			Dt = DAL.SelectData("get_count_product", param);
			DAL.Close();
			return Dt;
		}
	}
}
