using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart_Production_Pos.BL.BL_Achats;

namespace Smart_Production_Pos.BL.BL_PRODUCTION
{
	public class BL_Prodution
	{
		public DataTable get_quantite_matier_premier(string ID_PRODUIT_FINAUX)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@id_matier_premier", SqlDbType.NVarChar);
			param[0].Value = ID_PRODUIT_FINAUX;
			Dt = DAL.SelectData("get_tb_matier", param);
			DAL.Close();
			return Dt;
		}
		public DataTable select_tb_pack_pf_where(string ID_PRODUIT_FINAUX)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_PRODUIT_FINAUX", SqlDbType.NVarChar);
			param[0].Value = ID_PRODUIT_FINAUX;
			Dt = DAL.SelectData("select_tb_pack_pf_where", param);
			DAL.Close();
			return Dt;
		}
		public DataTable GetLastProductionInfo(string codebare)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@codebare", SqlDbType.NVarChar);
			param[0].Value = codebare;
			Dt = DAL.SelectData("GetLastProductionInfo", param);
			DAL.Close();
			return Dt;
		}
		public DataTable select_tb_history_production()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("select_tb_history_production", null);
			DAL.Close();
			return Dt;
		}
		public DataTable select_TB_HISTORIQUE_DEMONTER()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("select_TB_HISTORIQUE_DEMONTER", null);
			DAL.Close();
			return Dt;
		}
		public DataTable search_TB_HISTORIQUE_DEMONTER(string codebare)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar);
			param[0].Value = codebare;
			Dt = DAL.SelectData("search_TB_HISTORIQUE_DEMONTER", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_TB_HISTORIQUE_DEMONTER_by_code_baree(string codebare)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar);
			param[0].Value = codebare;
			Dt = DAL.SelectData("search_TB_HISTORIQUE_DEMONTER_by_code_baree", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_TB_HISTORIQUE_DEMONTER_by_date(DateTime codebare)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar);
			param[0].Value = codebare;
			Dt = DAL.SelectData("search_TB_HISTORIQUE_DEMONTER_by_date", param);
			DAL.Close();
			return Dt;
		}
		DAL.DAL daoo;
		public void update_stock_produit_fabrique(
				 string Codebarre
			   , int Qt_fabrique
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("update_stock_produit_fabrique", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@Codebarre", SqlDbType.NVarChar).Value = Codebarre;
					cmd.Parameters.Add("@Qt_fabrique", SqlDbType.Int).Value = Qt_fabrique;
					cmd.ExecuteNonQuery();
				}
			}
		}

		public DataTable search_tb_history_production_by_code_barre(string codebare)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@IDsearch", SqlDbType.NVarChar);
			param[0].Value = codebare;
			Dt = DAL.SelectData("search_tb_history_production_by_code_barre", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_tb_history_production(string codebare)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@IDsearch", SqlDbType.NVarChar);
			param[0].Value = codebare;
			Dt = DAL.SelectData("search_tb_history_production", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_tb_history_production_by_date(DateTime codebare)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@IDsearch", SqlDbType.NVarChar);
			param[0].Value = codebare;
			Dt = DAL.SelectData("search_tb_history_production_by_date", param);
			DAL.Close();
			return Dt;
		}

		public void update_qt_pack(
				 string Codebarre
			   , float Qt_fabrique
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("update_qt_pack", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID_PRODUIT_FINAUX", SqlDbType.NVarChar).Value = Codebarre;
					cmd.Parameters.Add("@number_update", SqlDbType.Float).Value = Qt_fabrique;
					cmd.ExecuteNonQuery();
				}
			}
		}
		public void INSERT_HISTORY_PRODUCTION(
				DateTime DATE
				,string ID_PRODUIT
				,int QT_BEFOR
				,int QT_PROUDCTION
				,int QT_AFTER
				,decimal COUT_PRODUCTION
				,int ID_USER 
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("INSERT_HISTORY_PRODUCTION", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@DATE", SqlDbType.DateTime).Value = DATE;
					cmd.Parameters.Add("@ID_PRODUIT", SqlDbType.NVarChar).Value = ID_PRODUIT;
					cmd.Parameters.Add("@QT_BEFOR", SqlDbType.Int).Value = QT_BEFOR;
					cmd.Parameters.Add("@QT_PROUDCTION", SqlDbType.Int).Value = QT_PROUDCTION;
					cmd.Parameters.Add("@QT_AFTER", SqlDbType.Int).Value = QT_AFTER;
					cmd.Parameters.Add("@COUT_PRODUCTION", SqlDbType.Money).Value = COUT_PRODUCTION;
					cmd.Parameters.Add("@ID_USER", SqlDbType.Int).Value = ID_USER; 

					cmd.ExecuteNonQuery();
				}
			}
		}

		public void INSERT_TB_HISTORIQUE_DEMONTER(
			    	DateTime DATE
				, string ID_PRODUIT
				, int QT_BEFOR
				, int QT_PROUDCTION
				, int QT_AFTER
				, decimal COUT_PRODUCTION
				, int ID_USER
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("INSERT_TB_HISTORIQUE_DEMONTER", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@DATE", SqlDbType.DateTime).Value = DATE;
					cmd.Parameters.Add("@ID_PRODUIT", SqlDbType.NVarChar).Value = ID_PRODUIT;
					cmd.Parameters.Add("@QT_BEFOR", SqlDbType.Int).Value = QT_BEFOR;
					cmd.Parameters.Add("@QT_PROUDCTION", SqlDbType.Int).Value = QT_PROUDCTION;
					cmd.Parameters.Add("@QT_AFTER", SqlDbType.Int).Value = QT_AFTER;
					cmd.Parameters.Add("@COUT_PRODUCTION", SqlDbType.Money).Value = COUT_PRODUCTION;
					cmd.Parameters.Add("@ID_USER", SqlDbType.Int).Value = ID_USER;

					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
