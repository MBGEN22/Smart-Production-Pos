using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_FICHIER
{
	public class BL_favoire
	{
		public DataTable select_table_fav()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("select_table_fav", null);
			DAL.Close();
			return Dt;
		}
		DAL.DAL daoo;
		public void update_favoire(
			int id,
			string Fav
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("update_favoire", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
					cmd.Parameters.Add("@Fav", SqlDbType.NVarChar).Value = Fav;
					cmd.ExecuteNonQuery();
				}
			}
		}
        public void delete_all_fav(
            int id 
            )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {

                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("delete_all_fav", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id_fav", SqlDbType.Int).Value = id; 
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void delete_all_fav_pack(
            int id
            )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {

                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("delete_all_fav_pack", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id_fav", SqlDbType.Int).Value = id;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
