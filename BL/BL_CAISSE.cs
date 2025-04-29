using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace Smart_Production_Pos.BL
{
	public class BL_CAISSE
	{
		public DataTable getSold_MAtier_revent(string codeBarre)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@codeBarre", SqlDbType.NVarChar);
			param[0].Value = codeBarre;
			Dt = DAL.SelectData("get_information_matier_revent", param);
			DAL.Close();
			return Dt;
		}
		public DataTable select_produit_fabrique(string codeBarre)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@codeBarre", SqlDbType.NVarChar);
			param[0].Value = codeBarre;
			Dt = DAL.SelectData("select_produit_fabrique", param);
			DAL.Close();
			return Dt;
		}
		public DataTable select_pack_revent_by_code_barre_produit(string codeBarre)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@codeBarreProduit", SqlDbType.NVarChar);
			param[0].Value = codeBarre;
			Dt = DAL.SelectData("select_pack_revent_by_code_barre_produit", param);
			DAL.Close();
			return Dt;
		}
		public DataTable select_pack_produit_finaux_by_Unite(string codeBarre)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@codeBare", SqlDbType.NVarChar);
			param[0].Value = codeBarre;
			Dt = DAL.SelectData("select_pack_produit_finaux_by_Unite", param);
			DAL.Close();
			return Dt;
		}
		public DataTable select_pack_info(string codeBarre)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@codeBare", SqlDbType.NVarChar);
			param[0].Value = codeBarre;
			Dt = DAL.SelectData("select_pack_info", param);
			DAL.Close();
			return Dt;
		}
		public DataTable select_produit_by_code_barre_reserve(string codeBarre)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@codeBarre_Reserve", SqlDbType.NVarChar);
			param[0].Value = codeBarre;
			Dt = DAL.SelectData("get_information_by_code_Reserve", param);
			DAL.Close();
			return Dt;
		}
		public DataTable get_information_by_code_Reserve_pack(string codeBarre)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@codeBarre_Reserve", SqlDbType.NVarChar);
			param[0].Value = codeBarre;
			Dt = DAL.SelectData("get_information_by_code_Reserve_pack", param);
			DAL.Close();
			return Dt;
		}
		public DataTable select_pack_Produit_finaux_info(string codeBarre)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@codeBare", SqlDbType.NVarChar);
			param[0].Value = codeBarre;
			Dt = DAL.SelectData("select_pack_Produit_finaux_info", param);
			DAL.Close();
			return Dt;
		}
	}
}
