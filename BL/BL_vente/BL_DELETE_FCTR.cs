using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_vente
{
    public class BL_DELETE_FCTR
    {
        public DataTable get_tb_fctr_vente(string id)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.NVarChar);
            param[0].Value = id;
            Dt = DAL.SelectData("get_tb_fctr_vente", param);
            DAL.Close();
            return Dt;
        }

        DAL.DAL daoo;
        public void DELETE_HISTORIQUE_CLIENT_BY_ID_FCTR( string ID_FACTURE, string remarque)
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE_HISTORIQUE_CLIENT_BY_ID_FCTR", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID_FACTURE", SqlDbType.NVarChar).Value = ID_FACTURE;
                    cmd.Parameters.Add("@remarque", SqlDbType.NVarChar).Value = remarque;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //
        public void DELETE_LIST_VENTE( string ID_FACTURE)
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE_LIST_VENTE", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID_FACTURE", SqlDbType.NVarChar).Value = ID_FACTURE;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //
        public void DELETE_FACTURE_VENTE(string ID_FACTURE)
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE_FACTURE_VENTE", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID_FACTURE", SqlDbType.NVarChar).Value = ID_FACTURE;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //
        public void EDIT_HISTORIQE_WHENE_DELET_FCTRE(
                 int ID
               , decimal VERSEMENT
               , decimal TOTAL_TTC
               )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("EDIT_HISTORIQE_WHENE_DELET_FCTRE", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                    cmd.Parameters.Add("@VERSEMENT", SqlDbType.Decimal).Value = VERSEMENT;
                    cmd.Parameters.Add("@TOTAL_TTC", SqlDbType.Decimal).Value = TOTAL_TTC;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void rectefier_after_vente(
                 string codebarre
               , float Qt_vente 
               )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("rectefier_after_vente", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.Add("@codebarre", SqlDbType.NVarChar).Value = codebarre;
                    cmd.Parameters.Add("@Qt_vente", SqlDbType.Float).Value = Qt_vente;  
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void insert_hitorique(
                string REMARQUE
              , DateTime DATEE
              , TimeSpan Heuree
              )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("insert_hitorique", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@REMARQUE", SqlDbType.NVarChar).Value = REMARQUE;
                    cmd.Parameters.Add("@DATEE", SqlDbType.Date).Value = DATEE;
                    cmd.Parameters.Add("@Heuree", SqlDbType.Time).Value = Heuree;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////// 
        public DataTable get_pack_liee_with_product(string codebarre_pack)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@codebarre_pack", SqlDbType.NVarChar);
            param[0].Value = codebarre_pack;
            Dt = DAL.SelectData("get_pack_liee_with_product", param);
            DAL.Close();
            return Dt;
        }
    }
}
