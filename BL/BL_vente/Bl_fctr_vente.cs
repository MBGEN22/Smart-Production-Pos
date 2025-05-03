using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_vente
{
    public class Bl_fctr_vente
    {
        //public List<string> GetListeFacturesDesc()
        //{
        //    List<string> factures = new List<string>();
        //    DAL.DAL dao = new DAL.DAL(); // إنشاء الكائن هنا

        //    using (dao.sqlConnection)
        //    {
        //        SqlCommand cmd = new SqlCommand("GetAllFacturesInDesc", dao.sqlConnection);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        dao.sqlConnection.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            factures.Add(reader["NMR_FACTURE"].ToString());
        //        }
        //    }

        //    return factures;
        //}
        public List<string> GetListeFacturesDesc()
        {
            DAL.DAL Daoo = new DAL.DAL();
            List<string> factures = new List<string>();

            using (Daoo.sqlConnection)
            {
                SqlCommand cmd = new SqlCommand("GetAllFacturesInDesc", Daoo.sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                Daoo.sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    factures.Add(reader["NMR_FACTURE"].ToString());
                }
            }
            return factures;
        }



    }
}
