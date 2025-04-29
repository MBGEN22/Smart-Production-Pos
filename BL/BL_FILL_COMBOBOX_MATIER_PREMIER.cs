using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL
{
	public class BL_FILL_COMBOBOX_MATIER_PREMIER
	{
		public DataTable fill_combo_matier_premier()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("fill_combo_matier_premier", null);
			DAL.Close();
			return Dt;
		}
		public DataTable fill_produit_revent()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("fill_produit_revent", null);
			DAL.Close();
			return Dt;
		}
	}
}
