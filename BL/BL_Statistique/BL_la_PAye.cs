using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_Statistique
{
	public class BL_la_PAye
	{
		//////////////////////// GetTable Client
		public DataTable select_versement_ouverier()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("select_versement_ouverier", null);
			DAL.Close();
			return Dt;
		}
		public DataTable search_select_versement_ouverier(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("search_select_versement_ouverier", param);
			DAL.Close();
			return Dt;
		}
		////////////////*************   ADD Client   **************///////////////
		DAL.DAL daoo;
		public void Add_Funct( 
			 DateTime DATE,
			 int ID_OUVERIER,
			 decimal PRICE_PAYER,
			  string REMARQUE,
			  int User_ID
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("sp_InsertVersementOuvrier", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@DATE", SqlDbType.DateTime).Value = DATE;
					cmd.Parameters.Add("@ID_OUVERIER", SqlDbType.Int).Value = ID_OUVERIER;
					cmd.Parameters.Add("@PRICE_PAYER", SqlDbType.Money).Value = PRICE_PAYER;
					cmd.Parameters.Add("@REMARQUE", SqlDbType.NVarChar).Value = REMARQUE;
					cmd.Parameters.Add("@User_ID", SqlDbType.Int).Value = User_ID;
					cmd.ExecuteNonQuery();
				}
			}
		}

		public void update_Depense(
			  int ID,
			  DateTime DATE,
			  int ID_OUVERIER,
			 decimal PRICE_PAYER,
			  string REMARQUE,
			  int User_ID
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("sp_UpdateVersementOuvrier", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
					cmd.Parameters.Add("@DATE", SqlDbType.DateTime).Value = DATE;
					cmd.Parameters.Add("@ID_OUVERIER", SqlDbType.Int).Value = ID_OUVERIER;
					cmd.Parameters.Add("@PRICE_PAYER", SqlDbType.Money).Value = PRICE_PAYER;
					cmd.Parameters.Add("@REMARQUE", SqlDbType.NVarChar).Value = REMARQUE;
					cmd.Parameters.Add("@User_ID", SqlDbType.Int).Value = User_ID;
					cmd.ExecuteNonQuery();
				}
			}
		}

		public void delte_ouverier(
			 int id
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("delte_ouverier", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
