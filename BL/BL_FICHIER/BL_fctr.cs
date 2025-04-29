using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Smart_Production_Pos.BL.BL_FICHIER
{
	public class BL_fctr
	{
		public DataTable getFctr()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_fctrrr", null);
			DAL.Close();
			return Dt;
		}
		DAL.DAL daoo;
		public void insert_proc_(
			string MacAdress,
			string Serial,
			DateTime instal_Day 
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("insert_proc_", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@MacAdress", SqlDbType.NVarChar).Value = MacAdress;
					cmd.Parameters.Add("@Serial", SqlDbType.NVarChar).Value = Serial;
					cmd.Parameters.Add("@instal_Day", SqlDbType.Date).Value = instal_Day; 


					cmd.ExecuteNonQuery();
				}
			}
		}

		public void update_proc(
			int ID,
			string MacAdress,
			string Serial,
			DateTime instal_Day
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("update_proc", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID;
					cmd.Parameters.Add("@MacAdress", SqlDbType.NVarChar).Value = MacAdress;
					cmd.Parameters.Add("@Serial", SqlDbType.NVarChar).Value = Serial;
					cmd.Parameters.Add("@instal_Day", SqlDbType.Date).Value = instal_Day;


					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
