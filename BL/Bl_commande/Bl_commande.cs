using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.Bl_commande
{
	public class Bl_commande
	{
		public string get_commande_nmr()
		{

			DAL.DAL DAaL = new DAL.DAL();

			string newID = "";

			using (DAaL.sqlConnection)
			{
				string query = "select concat('CM', format(convert(int, stuff(max(ID), 1, 3, ''))+1 , '0000'))  from TB_COMMANDE";
				using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
				{
					DAaL.sqlConnection.Open();
					var result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						newID = result.ToString();
					}
				}
			}
			return newID;
		}
		public DataTable get_tb_commande()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_tb_commande", null);
			DAL.Close();
			return Dt;
		}
		public DataTable check_commande_pres(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_Search", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("search_TB_commande", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_TB_commande(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_Search", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("search_TB_commande", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_TB_commande_bY_date(DateTime id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_Search", SqlDbType.Date);
			param[0].Value = id;
			Dt = DAL.SelectData("search_TB_commande_bY_date", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_TB_commande_by_client(int id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_Client", SqlDbType.Int);
			param[0].Value = id;
			Dt = DAL.SelectData("search_TB_commande_by_client", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_TB_commande_between_Date(DateTime startDate, DateTime endDate)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[2];
			param[0] = new SqlParameter("@startDate", SqlDbType.DateTime);
			param[0].Value = startDate;
			param[1] = new SqlParameter("@endDate", SqlDbType.DateTime);
			param[1].Value = endDate;
			Dt = DAL.SelectData("search_TB_commande_between_Date", param);
			DAL.Close();
			return Dt;
		}
		public DataTable get_notification(int id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@id_client", SqlDbType.Int);
			param[0].Value = id;
			Dt = DAL.SelectData("get_tb_client_tb_remarque", param);
			DAL.Close();
			return Dt;
		}

		#region Add_Commande
		DAL.DAL daoo;

		public void insert_new_commande(
				 string		ID
			   , DateTime	DATE
			   , string		NOM_COMMANDE
			   , int		ID_CLIENT
			   , string		TYPE_COMMANDE
			   , decimal	COUT_TOTAL
			   , decimal	VERSEMENT
			   , int		QTE
			   , string		REMARQUE
			   , decimal	PRICE_TOTAL_HT
			   , decimal	PRICE_TOTAL_TTC
			   , float		TVA
			   , DateTime?	deadline_Date
			   , string		etas
			   , int        id_user
			   , double?      TMBER
			   , string     PRICE_ARAB 
			   , decimal  historique_Money
			   , decimal  new_money

			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("add_new_commande", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID;
					cmd.Parameters.Add("@DATE", SqlDbType.Date).Value = DATE;
					cmd.Parameters.Add("@NOM_COMMANDE", SqlDbType.NVarChar).Value = NOM_COMMANDE;
					cmd.Parameters.Add("@ID_CLIENT", SqlDbType.Int).Value = ID_CLIENT;
					cmd.Parameters.Add("@TYPE_COMMANDE", SqlDbType.NVarChar).Value = TYPE_COMMANDE;
					cmd.Parameters.Add("@COUT_TOTAL", SqlDbType.Money).Value = COUT_TOTAL;
					cmd.Parameters.Add("@VERSEMENT", SqlDbType.Money).Value = VERSEMENT;
					cmd.Parameters.Add("@REMARQUE", SqlDbType.NVarChar).Value = REMARQUE;
					cmd.Parameters.Add("@QTE", SqlDbType.Int).Value = QTE;
					cmd.Parameters.Add("@PRICE_TOTAL_HT", SqlDbType.Money).Value = PRICE_TOTAL_HT;
					cmd.Parameters.Add("@PRICE_TOTAL_TTC", SqlDbType.Money).Value = PRICE_TOTAL_TTC;
					cmd.Parameters.Add("@TVA", SqlDbType.Float).Value = TVA;
					if (deadline_Date.HasValue)
						cmd.Parameters.Add("@deadline_Date", SqlDbType.Date).Value = deadline_Date.Value;
					else
						cmd.Parameters.Add("@deadline_Date", SqlDbType.Date).Value = DBNull.Value;
					
					cmd.Parameters.Add("@etas", SqlDbType.NVarChar).Value = etas; 
					cmd.Parameters.Add("@id_user", SqlDbType.Int).Value = id_user; 
					if (TMBER.HasValue)
						cmd.Parameters.Add("@TMBER", SqlDbType.Float).Value = TMBER.Value;
					else
						cmd.Parameters.Add("@TMBER", SqlDbType.Float).Value = DBNull.Value;
					cmd.Parameters.Add("@PRICE_ARAB", SqlDbType.NVarChar).Value = PRICE_ARAB;

					cmd.Parameters.Add("@historique_Money", SqlDbType.Money).Value = historique_Money;
					cmd.Parameters.Add("@new_money", SqlDbType.Money).Value = new_money;

					cmd.ExecuteNonQuery();
				}
			}
		}

		#endregion
	}
}
