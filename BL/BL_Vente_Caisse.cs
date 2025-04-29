using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Smart_Production_Pos.BL
{
    public class BL_Vente_Caisse
    {
        DAL.DAL daoo;

        public void delete_fctr_vente_product(string ID_Fctr)
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("delete_fctr_vente_product", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ID_Fctr", SqlDbType.NVarChar).Value = ID_Fctr;

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void delete_just_one_fctr_en_attend(string CodeBarre)
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("delete_just_one_fctr_en_attend", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodeBarre", SqlDbType.NVarChar).Value = CodeBarre;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void delete_fct_vente_edit(string ID_Fctr)
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("delete_fct_vente_edit", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ID_Fctr", SqlDbType.NVarChar).Value = ID_Fctr;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable get_information_user(int id)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            Dt = DAL.SelectData("get_information_user", param);
            DAL.Close();
            return Dt;
        }
        public DataTable get_information_caissier(int id)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            Dt = DAL.SelectData("get_information_caissier", param);
            DAL.Close();
            return Dt;
        }

        public void edit_fav_produit(
                string Code_barre,
                int Fav
        )
        {
            daoo = new DAL.DAL();

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand("edit_fav_produit", daoo.sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure; 
                    command.Parameters.AddWithValue("@Code_barre", Code_barre);
                    command.Parameters.AddWithValue("@Fav", Fav);  
                    daoo.sqlConnection.Open();
                    command.ExecuteNonQuery();

                }
            }
        }
        public void edit_fav_pack(
                string Code_barre,
                int Fav
        )
        {
            daoo = new DAL.DAL();

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand("edit_fav_pack", daoo.sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Code_barre", Code_barre);
                    command.Parameters.AddWithValue("@Fav", Fav);
                    daoo.sqlConnection.Open();
                    command.ExecuteNonQuery();

                }
            }
        }
    }
}
