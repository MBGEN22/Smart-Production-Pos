using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_vente
{
	public class BL_SP_LOGINE_Caisse
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
			Dt = DAL.SelectData("Logine_caisse", param);
			DAL.Close();
			return Dt;
		}
        public DataTable check_if_caisse_renter(int ID, DateTime date)
        {
            DAL.DAL DAL = new DAL.DAL();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID_caisse", SqlDbType.Int);
            param[0].Value = ID;

            param[1] = new SqlParameter("@DATE", SqlDbType.Date);
            param[1].Value = date;

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("check_if_caisse_renter", param);
            DAL.Close();
            return Dt;
        }
        public DataTable historique_tracage_caissier()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("historique_tracage_caissier", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_historique_Caissier(int ID_caissier, DateTime Data)
		{
			DAL.DAL DAL = new DAL.DAL();
			SqlParameter[] param = new SqlParameter[2];
			param[0] = new SqlParameter("@ID_caissier", SqlDbType.Int);
			param[0].Value = ID_caissier;

			param[1] = new SqlParameter("@Data", SqlDbType.Date);
			param[1].Value = Data;

			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_historique_Caissier", param);
			DAL.Close();
			return Dt;
		}

		DAL.DAL daoo;
		 
		public void insert_history_caissier(
				 int ID_CAISSIE
			   , DateTime DATE
			   , TimeSpan HEURE_ENTRE
			   , TimeSpan HEURE_SORTIE
			   , decimal PRIX_FOND
			   , decimal PRIX_CLOTURE
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("insert_history_caissier", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID_CAISSIE", SqlDbType.Int).Value = ID_CAISSIE;
					cmd.Parameters.Add("@DATE", SqlDbType.Date).Value = DATE;
					cmd.Parameters.Add("@HEURE_ENTRE", SqlDbType.Time).Value = HEURE_ENTRE;
					cmd.Parameters.Add("@HEURE_SORTIE", SqlDbType.Time).Value = HEURE_SORTIE;
					cmd.Parameters.Add("@PRIX_FOND", SqlDbType.Money).Value = PRIX_FOND;
					cmd.Parameters.Add("@PRIX_CLOTURE", SqlDbType.Money).Value = PRIX_CLOTURE;

					cmd.ExecuteNonQuery();
				}
			}
		}

		public void clear_vente_where_edit(
				 string ID
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();
				using (SqlCommand cmd = new SqlCommand("clear_vente_where_edit", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@idFctr", SqlDbType.NVarChar).Value = ID;
					cmd.ExecuteNonQuery();
				}
			}
		}
		public void update_history_caissier(
				 int ID
			   , TimeSpan HEURE_SORTIE 
			   , decimal PRIX_CLOTURE
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("update_history_caissier", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
					cmd.Parameters.Add("@HEURE_SORTIE", SqlDbType.Time).Value = HEURE_SORTIE; 
					cmd.Parameters.Add("@PRIX_CLOTURE", SqlDbType.Money).Value = PRIX_CLOTURE;

					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
