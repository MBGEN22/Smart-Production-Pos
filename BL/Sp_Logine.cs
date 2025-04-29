using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL
{
	public class Sp_Logine
	{
		public DataTable LOGIN(string ID, string PWD)
		{
			DAL.DAL DAL = new DAL.DAL();
			SqlParameter[] param = new SqlParameter[2];
			param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
			param[0].Value = ID;

			param[1] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
			param[1].Value = PWD;

			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("SP_LOGIN", param);
			DAL.Close();
			return Dt;
		}

        public DataTable get_TB_USER_RECUPIRATION(string id)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Code_REcupiration", SqlDbType.VarChar, 50);
            param[0].Value = id;
            Dt = DAL.SelectData("get_TB_USER_RECUPIRATION", param);
            DAL.Close();
            return Dt;
        }
        public DataTable get_ACCES_USer(int id)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = id;
            Dt = DAL.SelectData("get_ACCES_USer", param);
            DAL.Close();
            return Dt;
        }
        DAL.DAL daoo;
		public void update_user_whene_logine(
				 int ID
			   , string Etas 
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("update_user_whene_logine", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
					cmd.Parameters.Add("@Etas", SqlDbType.NVarChar).Value = Etas; 

					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
