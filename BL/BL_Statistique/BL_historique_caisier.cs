using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_Statistique
{
	public class BL_historique_caisier
	{
		//////////////////////// GetTable Client
		public DataTable get_historique_caissiera()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_historique_caissiera", null);
			DAL.Close();
			return Dt;
		}
		public DataTable search_by_date(DateTime id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@Data", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("get_historique_Caissier_by_date", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_by_caissier(int id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_caissier", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("search_get_historique_Caissier", param);
			DAL.Close();
			return Dt;
		}
	}
}
