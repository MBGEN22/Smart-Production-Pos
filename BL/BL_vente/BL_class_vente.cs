using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_vente
{
	public class BL_class_vente
	{
		public DataTable listVente(string Etas)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable(); 
			SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ETAS", SqlDbType.NVarChar);
            param[0].Value = Etas;
            Dt = DAL.SelectData("get_list_vente", param);
			DAL.Close();
			return Dt;
		}
        public DataTable get_list_vente_credit_client(string Etas,int id_client)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ETAS", SqlDbType.NVarChar);
            param[0].Value = Etas;
            param[1] = new SqlParameter("@id_client", SqlDbType.Int);
            param[1].Value = id_client;
            Dt = DAL.SelectData("get_list_vente_credit_client", param);
            DAL.Close();
            return Dt;
        }
        public DataTable get_list_vente_By_date(DateTime codeBarre , string Etas)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[2];
			param[0] = new SqlParameter("@Date", SqlDbType.NVarChar);
			param[0].Value = codeBarre;
            param[1] = new SqlParameter("@ETAS", SqlDbType.NVarChar);
            param[1].Value = Etas;
            Dt = DAL.SelectData("[get_list_vente_by_DATEE]", param);
			DAL.Close();
			return Dt;
		}
	}
}
