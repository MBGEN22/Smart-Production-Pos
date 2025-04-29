using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.Bl_commande
{
	public class BL_sub_commande
	{
		public DataTable sub_commande_total_list()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("GET_SUB_COMMANDE", null);
			DAL.Close();
			return Dt;
		}
		public float get_sum_Qt()
		{
			DAL.DAL DAaL = new DAL.DAL();

			float sum = 0;

			using (DAaL.sqlConnection)
			{
				string query = "SELECT SUM([QUANTITE]) FROM [dbo].[TB_SUM_COMMANDE_caise]";
				using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
				{
					DAaL.sqlConnection.Open();
					var result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						sum = Convert.ToInt32(result);
					}
				}
			}
			return sum;
		}
		public DataTable get_detailles_sub_commande(string Id_commannd)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@Id_commannd", SqlDbType.NVarChar, 50);
			param[0].Value = Id_commannd;
			Dt = DAL.SelectData("select_tb_sub_commande", param);
			DAL.Close();
			return Dt;
		}

		public decimal get_sum_money()
		{
			DAL.DAL DAaL = new DAL.DAL();

			decimal sum = 0;

			using (DAaL.sqlConnection)
			{
				string query = "SELECT SUM([PRIX_TOTAL]) FROM [dbo].[TB_SUM_COMMANDE_caise]";
				using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
				{
					DAaL.sqlConnection.Open();
					var result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						sum = Convert.ToInt32(result);
					}
				}
			}
			return sum;
		}

		public decimal get_sum_money_cout()
		{
			DAL.DAL DAaL = new DAL.DAL();

			decimal sum = 0;

			using (DAaL.sqlConnection)
			{
				string query = "SELECT SUM([price_cout]) FROM [dbo].[TB_SUM_COMMANDE_caise]";
				using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
				{
					DAaL.sqlConnection.Open();
					var result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						sum = Convert.ToInt32(result);
					}
				}
			}
			return sum;
		}

		public void delete_sub_comnd(
			 int id
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("delete_sub_comnd", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
					cmd.ExecuteNonQuery();
				}
			}
		}

		//
		public DataTable get_tb_sub_commande_caisse(string Id_commannd)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@id_commande", SqlDbType.NVarChar, 50);
			param[0].Value = Id_commannd;
			Dt = DAL.SelectData("get_tb_sub_commande_caisse", param);
			DAL.Close();
			return Dt;
		} 
		DAL.DAL daoo;



		public void add_sub_commande_caise( 
				string ID_COMMANDE
			   , string SUB_COMMANDE_TITLE
			   , int QUANTITE
			   , decimal PRIX_UNITAIR
			   , decimal PRIX_TOTAL
			   , int QTE_REST
			   , int QT_LIVRE
			   , decimal price_cout
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("add_sub_commande_caise", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID_COMMANDE", SqlDbType.NVarChar).Value = ID_COMMANDE;
					cmd.Parameters.Add("@SUB_COMMANDE_TITLE", SqlDbType.NVarChar).Value = SUB_COMMANDE_TITLE;
					cmd.Parameters.Add("@QUANTITE", SqlDbType.NVarChar).Value = QUANTITE;
					cmd.Parameters.Add("@PRIX_UNITAIR", SqlDbType.NVarChar).Value = PRIX_UNITAIR;
					cmd.Parameters.Add("@PRIX_TOTAL", SqlDbType.NVarChar).Value = PRIX_TOTAL;
					cmd.Parameters.Add("@QTE_REST", SqlDbType.NVarChar).Value = QTE_REST;
					cmd.Parameters.Add("@QT_LIVRE", SqlDbType.NVarChar).Value = QT_LIVRE;
					cmd.Parameters.Add("@price_cout", SqlDbType.NVarChar).Value = price_cout; 

					cmd.ExecuteNonQuery();
				}
			}
		}

		public void EDIT_not_COMPLETE_ORDER(
			int ID, int qte_taket)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("[edit_tb_sub_comande_whene_not_complete]", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
					cmd.Parameters.Add("@qtetake", SqlDbType.Int).Value = qte_taket;
					cmd.ExecuteNonQuery();
				}
			}
		}

		public void add_info_livraison(
			int ID_HISTORUQE_LIVRAISON, int ID_SUB_COMMANDE, int QUANTITE_LIVRE)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("INSERT_INFO_SUB_LIV", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID_HISTORUQE_LIVRAISON", SqlDbType.Int).Value = ID_HISTORUQE_LIVRAISON;
					cmd.Parameters.Add("@ID_SUB_COMMANDE", SqlDbType.Int).Value = ID_SUB_COMMANDE;
					cmd.Parameters.Add("@QUANTITE_LIVRE", SqlDbType.Int).Value = QUANTITE_LIVRE;
					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
