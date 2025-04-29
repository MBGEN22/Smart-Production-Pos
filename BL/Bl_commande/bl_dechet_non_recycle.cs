using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.Bl_commande
{
	public class bl_dechet_non_recycle
	{
		public DataTable getdechet()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_dechet", null);
			DAL.Close();
			return Dt;
		}
		public DataTable search_get_dechet(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar, 50);
			param[0].Value = id;
			Dt = DAL.SelectData("search_get_dechet", param);
			DAL.Close();
			return Dt;
		}
		DAL.DAL daoo;
		public void insert_dechet(
					string @ID_MATIER
					, int @QT_Dechet
					, string @etas
					, decimal price_u
					, decimal price_ttl
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();
				using (SqlCommand cmd = new SqlCommand("insert_dechet_non", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@ID_MATIER", SqlDbType.NVarChar).Value = ID_MATIER;
					cmd.Parameters.Add("@QT_Dechet", SqlDbType.Int).Value = QT_Dechet;
					cmd.Parameters.Add("@etas", SqlDbType.NVarChar).Value = etas;
					cmd.Parameters.Add("@price_u", SqlDbType.Money).Value = price_u;
					cmd.Parameters.Add("@price_ttl", SqlDbType.Money).Value = price_ttl;

					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
