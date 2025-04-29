using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Smart_Production_Pos.BL.BL_vente
{
    internal class Bl_edit_bon
    {
        public DataTable get_information_bon(string ID_bon)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_bon", SqlDbType.NVarChar);
            param[0].Value = ID_bon;
            Dt = DAL.SelectData("get_information_bon", param);
            DAL.Close();
            return Dt;
        }
        public DataTable get_vente_dtl(string ID_bon)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id_bon", SqlDbType.NVarChar);
            param[0].Value = ID_bon;
            Dt = DAL.SelectData("get_vente_dtl", param);
            DAL.Close();
            return Dt;
        }
    }
}
