using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.Bl_commande
{
	public class BL_DECHET
	{
		DAL.DAL daoo;
		public void insert_dechet( 
					string	@ID_MATIER
					, int	@QT_Dechet 
					,string @etas 
					,decimal price_u
					, decimal price_ttl
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open(); 
				using (SqlCommand cmd = new SqlCommand("INSERT_DECHET", daoo.sqlConnection))
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
