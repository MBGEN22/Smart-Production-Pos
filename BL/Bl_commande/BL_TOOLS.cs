using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.Bl_commande
{
	public class BL_TOOLS
	{
		public DataTable get_tb_tools_commande()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_tb_tools_commande", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_tools_commande(string Id_commannd)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_commande", SqlDbType.NVarChar, 50);
			param[0].Value = Id_commannd;
			Dt = DAL.SelectData("get_tools_commande", param);
			DAL.Close();
			return Dt;
		}
		public void delete_caisse_tools(
			 int id
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("delete_caisse_tools", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
					cmd.ExecuteNonQuery();
				}
			}
		}
		DAL.DAL daoo;
		public void add_TOOLS_COMMANDE(
				 string  TOOLS
			   , string ID_COMMANDE 
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("add_tools_caisse_commande", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@TOOLS", SqlDbType.NVarChar).Value = TOOLS;
					cmd.Parameters.Add("@ID_COMMANDE", SqlDbType.NVarChar).Value = ID_COMMANDE; 

					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
