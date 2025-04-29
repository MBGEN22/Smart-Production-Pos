using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.Bl_commande
{
	public class BL_livraison
	{ 
		public int get_id_TB_INFO_DE_LIV()
		{
			DAL.DAL DAaL = new DAL.DAL();
			int newID = 1;
			using (DAaL.sqlConnection)
			{
				string query = "select count(ID) from TB_INFO_DE_LIV;";
				using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
				{
					DAaL.sqlConnection.Open();
					var result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						newID = Convert.ToInt32(result) + 1;
					}
				}
			}
			return newID;
		}

		public DataTable get_table_liv()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("[GET_TB_LIVRAISON]", null);
			DAL.Close();
			return Dt;
		}
		public DataTable search_tb_liv(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@Search", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("search_tb_liv", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_tb_liv_by_date(DateTime id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@Date", SqlDbType.Date);
			param[0].Value = id;
			Dt = DAL.SelectData("search_tb_liv_by_date", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_tb_liv_client(int id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@IDCLiet", SqlDbType.Int);
			param[0].Value = id;
			Dt = DAL.SelectData("search_tb_liv_client", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search__Liveraison_between_Date(DateTime startDate, DateTime endDate)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[2];
			param[0] = new SqlParameter("@startDate", SqlDbType.Int);
			param[0].Value = startDate;
			param[1] = new SqlParameter("@endDate", SqlDbType.Int);
			param[1].Value = endDate;
			Dt = DAL.SelectData("search_tb_liv_between_date", param);
			DAL.Close();
			return Dt;
		}

		public DataTable get_client_of_commande(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@id_commande", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("get_client_of_commande", param);
			DAL.Close();
			return Dt;
		}
		public DataTable get_client_information(int id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@id_client", SqlDbType.Int);
			param[0].Value = id;
			Dt = DAL.SelectData("get_client_information", param);
			DAL.Close();
			return Dt;
		}
		DAL.DAL daoo;

		public void update_client_payment_(
				 int ID
			   , decimal Solde_verse
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("update_client_payment_", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure; 
					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
					cmd.Parameters.Add("@Solde_verse", SqlDbType.Money).Value = Solde_verse; 
					cmd.ExecuteNonQuery();
				}
			}
		}
		public void EDIT_COMPLETE_ORDER(
			string ID)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("edit_tb_sub_comande_whene_complete", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID_commande", SqlDbType.NVarChar).Value = ID;

					cmd.ExecuteNonQuery();
				}
			}
		}
		public void edit_commande_etas(
				 string ID
			   , string etas
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("edit_commande_etas", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID;
					cmd.Parameters.Add("@etas", SqlDbType.NVarChar).Value = etas;
					cmd.ExecuteNonQuery();
				}
			}
		}

		public void insert_livraiosn_information( 
			    int		ID
			   , DateTime DATE
			   , string NOM_DE_LIV
			   , string NOM_DE_RECU
			   , string TYPE_DE_LIV
			   , decimal PRIC_DE_LIV
			   , string info_chaufeur
			   , string info_matricule 
			   , string id_commande
			   ,decimal Versement

			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("insert_info_livraison", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID;
					cmd.Parameters.Add("@DATE", SqlDbType.Date).Value = DATE;
					cmd.Parameters.Add("@NOM_DE_LIV", SqlDbType.NVarChar).Value = NOM_DE_LIV;
					cmd.Parameters.Add("@NOM_DE_RECU", SqlDbType.NVarChar).Value = NOM_DE_RECU;
					cmd.Parameters.Add("@TYPE_DE_LIV", SqlDbType.NVarChar).Value = TYPE_DE_LIV;
					cmd.Parameters.Add("@PRIC_DE_LIV", SqlDbType.Money).Value = PRIC_DE_LIV;
					cmd.Parameters.Add("@info_chaufeur", SqlDbType.NVarChar).Value = info_chaufeur;
					cmd.Parameters.Add("@info_matricule", SqlDbType.NVarChar).Value = info_matricule; 
					cmd.Parameters.Add("@id_commande", SqlDbType.NVarChar).Value = id_commande;
					cmd.Parameters.Add("@Versement", SqlDbType.Money).Value = Versement;

					cmd.ExecuteNonQuery();
				}
			}
		}

		public void edit_versement_commande(
				 string ID
			   , decimal Money 
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("edit_versement_commande", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure; 
					cmd.Parameters.Add("@id_commande", SqlDbType.NVarChar).Value = ID;
					cmd.Parameters.Add("@price_versé", SqlDbType.Money).Value = Money; 
					cmd.ExecuteNonQuery();
				}
			}
		}


		//////seach region
		public DataTable search_TB_livraison(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
		DataTable Dt = new DataTable();
		SqlParameter[] param = new SqlParameter[1];
		param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar);
		param[0].Value = id;
			Dt = DAL.SelectData("search_TB_livraison", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_TB_livraison_by_client(int clientID)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_Client", SqlDbType.Int);
			param[0].Value = clientID;
			Dt = DAL.SelectData("search_TB_livraison_by_client", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_TB_livraison_by_Date(DateTime Date)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@Date", SqlDbType.DateTime);
			param[0].Value = Date;
			Dt = DAL.SelectData("search_TB_livraison_by_Date", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_TB_livraison_between_Date(DateTime StartDate, DateTime EndDate)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[2];
			param[0] = new SqlParameter("@StartDate", SqlDbType.NVarChar);
			param[0].Value = StartDate;
			param[1] = new SqlParameter("@EndDate", SqlDbType.NVarChar);
			param[1].Value = EndDate;
			Dt = DAL.SelectData("search_TB_livraison_between_Date", param);
			DAL.Close();
			return Dt;
		}
	}
}
