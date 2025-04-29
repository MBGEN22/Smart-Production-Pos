using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.Bl_commande
{
	public class detaille_de_livraison
	{
		public DataTable get_table_detaille(int ID)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_liv", SqlDbType.Int);
			param[0].Value = ID;
			Dt = DAL.SelectData("select_detaille_livraison", param);
			DAL.Close();
			return Dt;
		}
	}
}
