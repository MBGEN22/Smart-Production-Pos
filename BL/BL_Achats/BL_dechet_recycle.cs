using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_Achats
{
	public class BL_dechet_recycle
	{
		public DataTable get_recycle_dechet_()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_table_dechet", null);
			DAL.Close();
			return Dt;
		}
		public DataTable search_recycle_dechet(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar, 50);
			param[0].Value = id;
			Dt = DAL.SelectData("search_recycle_dechet", param);
			DAL.Close();
			return Dt;
		}
		DAL.DAL daoo;

		public void edit_etas_dechet(
				 int id,string etas
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("edit_etas_dechet", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
					cmd.Parameters.Add("@etas", SqlDbType.NVarChar).Value = etas;

					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
