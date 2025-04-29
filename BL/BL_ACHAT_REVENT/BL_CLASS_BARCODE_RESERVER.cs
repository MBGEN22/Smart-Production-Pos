using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_ACHAT_REVENT
{
    public class BL_CLASS_BARCODE_RESERVER
    {
        public DataTable get_reserve_code_all()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("get_reserve_code_all", null);
            DAL.Close();
            return Dt;
        }
        public DataTable get_reserve_code_all_pack()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("get_reserve_code_all_pack", null);
            DAL.Close();
            return Dt;
        }
        public DataTable search_get_reserve_code_all(string codeBarre)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_Search", SqlDbType.NVarChar);
            param[0].Value = codeBarre;
            Dt = DAL.SelectData("search_get_reserve_code_all", param);
            DAL.Close();
            return Dt;
        }
        public DataTable search_get_reserve_code_all_pack(string codeBarre)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_Search", SqlDbType.NVarChar);
            param[0].Value = codeBarre;
            Dt = DAL.SelectData("search_get_reserve_code_all_pack", param);
            DAL.Close();
            return Dt;
        }
    }
}
