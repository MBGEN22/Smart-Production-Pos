using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL
{
    public class bl_produit_delete
    {
        DAL.DAL daoo;

        public void delet_reserve_pack_code_barre (
                string ID_PRODUIT 
              )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("delte_reserve_code_bare_pack_from_stock", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@codeBarre", SqlDbType.NVarChar).Value = ID_PRODUIT; 

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void delete_reserve_produit_code_barre(
               string ID_PRODUIT
             )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("delte_reserve_bc_produit_from_stock", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@codeBarre", SqlDbType.NVarChar).Value = ID_PRODUIT;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void delete_pack_link_to_produit(
               string ID_PRODUIT
             )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("delte_pack_from_stock", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@codeBarre", SqlDbType.NVarChar).Value = ID_PRODUIT;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void delete_produit(
               string ID_PRODUIT
             )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("delte_produit_from_stock", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@codeBarre", SqlDbType.NVarChar).Value = ID_PRODUIT;

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
