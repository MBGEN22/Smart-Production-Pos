using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Smart_Production_Pos.BL.BL_REPARATION
{
    public class BL_REPARATION
    {
        public DataTable GetRepatationRecords()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("GetRepatationRecords", null);
            DAL.Close();
            return Dt;
        }

        public DataTable SEARCH_REPT(string ID_Produit)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar);
            param[0].Value = ID_Produit;
            Dt = DAL.SelectData("SEARCH_REPT", param);
            DAL.Close();
            return Dt;
        }
        DAL.DAL daoo;
        public void Add_Reparation(
            string NMR_OPERATION,
            DateTime DATE_ENTRE,
            TimeSpan TIME,
            string CLIENT,
            string NMR_TEL,
            string PROBLEM,
            decimal PRIX, // Nullable to allow inserting without a date
            string ETAS,
            byte[] PICTURE_CODE_BARRE // Binary image data
        )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("add_reparation", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NMR_OPERATION", SqlDbType.NVarChar).Value = NMR_OPERATION;
                    cmd.Parameters.Add("@DATE_ENTRE", SqlDbType.Date).Value = DATE_ENTRE;
                    cmd.Parameters.Add("@TIME", SqlDbType.Time).Value = TIME;
                    cmd.Parameters.Add("@CLIENT", SqlDbType.NVarChar).Value = CLIENT;
                    cmd.Parameters.Add("@NMR_TEL", SqlDbType.NVarChar).Value = NMR_TEL;
                    cmd.Parameters.Add("@PROBLEM", SqlDbType.NVarChar).Value = PROBLEM;
                    cmd.Parameters.Add("@PRIX", SqlDbType.Decimal).Value = PRIX; 
                    cmd.Parameters.Add("@ETAS", SqlDbType.NVarChar).Value = ETAS;

                    // Handle nullable PICTURE_CODE_BARRE
                    if (PICTURE_CODE_BARRE != null)
                        cmd.Parameters.Add("@PICTURE_CODE_BARRE", SqlDbType.Image).Value = PICTURE_CODE_BARRE;
                    else
                        cmd.Parameters.Add("@PICTURE_CODE_BARRE", SqlDbType.Image).Value = DBNull.Value;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void edit_etas(
           string NMR_OPERATION,
           DateTime DATE_ENTRE, 
           decimal PRIX ,
           string etas
       )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("edit_etas", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@nmr_operation", SqlDbType.NVarChar).Value = NMR_OPERATION;
                    cmd.Parameters.Add("@DATE_SORTIE", SqlDbType.Date).Value = DATE_ENTRE; 
                    cmd.Parameters.Add("@PRIX", SqlDbType.Decimal).Value = PRIX;
                    cmd.Parameters.Add("@etas", SqlDbType.NVarChar).Value = etas;

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
