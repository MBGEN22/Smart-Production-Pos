using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_PRODUCTION
{
	public class BL_GESTION_PRODUIT_FINAUX
	{
		public DataTable GET_TB_GESTION_PRODUIT_FINAUX()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("GET_TB_GESTION_PRODUIT_FINAUX", null);
			DAL.Close();
			return Dt;
		}

		public DataTable getinformation_produtct_(string code_barre)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@code_barre", SqlDbType.NVarChar);
			param[0].Value = code_barre;
			Dt = DAL.SelectData("get_info_produit_finaux", param);
			DAL.Close();
			return Dt;
		}
		public DataTable GET_TB_GESTION_PRODUIT_FINAUX_Prix1()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("GET_TB_GESTION_PRODUIT_FINAUX_prix1", null);
			DAL.Close();
			return Dt;
		}
		public DataTable GET_TB_GESTION_PRODUIT_FINAUX_Prix2()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("GET_TB_GESTION_PRODUIT_FINAUX_prix2", null);
			DAL.Close();
			return Dt;
		}
		public DataTable GET_TB_GESTION_PRODUIT_FINAUX_Prix_min()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("GET_TB_GESTION_PRODUIT_FINAUX_prix_min", null);
			DAL.Close();
			return Dt;
		}
		public DataTable search_by_code_barre(string code_barre)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@codeBarre", SqlDbType.NVarChar);
			param[0].Value = code_barre;
			Dt = DAL.SelectData("search_gestion_produit_by_code_barre", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_gestion_produit_finaux_by_name(string code_barre)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@IDsearch", SqlDbType.NVarChar);
			param[0].Value = code_barre;
			Dt = DAL.SelectData("search_gestion_produit_finaux_by_name", param);
			DAL.Close();
			return Dt;
		}
		public DataTable select_pack(string ID_PRODUIT_FINAUX)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_PRODUIT_FINAUX", SqlDbType.NVarChar);
			param[0].Value = ID_PRODUIT_FINAUX;
			Dt = DAL.SelectData("select_pack", param);
			DAL.Close();
			return Dt;
		}
		public DataTable get_tb_matier_where_edit(string nmr_produit)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@nmr_produit", SqlDbType.NVarChar);
			param[0].Value = nmr_produit;
			Dt = DAL.SelectData("get_tb_matier_where_edit", param);
			DAL.Close();
			return Dt;
		}
		public DataTable get_tab_pack()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_table_pack", null);
			DAL.Close();
			return Dt;
		}

		public DataTable search_get_table_pack(string codebare)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@IDsearch", SqlDbType.NVarChar);
			param[0].Value = codebare;
			Dt = DAL.SelectData("search_get_table_pack", param);
			DAL.Close();
			return Dt;
		}

		public DataTable search_pack_by_code_barre(string codebare)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@IDsearch", SqlDbType.NVarChar);
			param[0].Value = codebare;
			Dt = DAL.SelectData("search_get_table_pack_by_code_barre", param);
			DAL.Close();
			return Dt;
		}


		public DataTable get_tab_pack_prix1()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_table_pack_1", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_tab_pack_prix2()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_table_pack_2", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_tab_pack_prixmin()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_table_pack_min", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_matier_premier_production_caisse()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_matier_premier_production_caisse", null);
			DAL.Close();
			return Dt;
		}


		DAL.DAL daoo;

		public void add_gestion_produit_finaux(
				  
				 string		CODE_BARRE
			   , string		DESIGNATION
			   , int		QT_PARAMETRAGE
			   , int		UNITE
			   , int		CATEGORIE
			   , decimal	COUT_DE_PRODUCTION
			   , int		QT_DANS_PACK
			   , int		QT_TOTAL
			   , int		QT_VENTE
			   , int		QT_REST
			   , int		QT_DECHET
			   , decimal	PRICE_VENTE_HT
			   , decimal	PRICE_VENTE_TTC
			   , float		TVA
			   , decimal	PRICE_GROS
			   , decimal	PRICE_MIN
			   , int		qt_alter
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("add_gestion_produit_finaux", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@CODE_BARRE", SqlDbType.NVarChar).Value = CODE_BARRE;
					cmd.Parameters.Add("@DESIGNATION", SqlDbType.NVarChar).Value = DESIGNATION;
					cmd.Parameters.Add("@QT_PARAMETRAGE", SqlDbType.Int).Value = QT_PARAMETRAGE;
					cmd.Parameters.Add("@UNITE", SqlDbType.Int).Value = UNITE;
					cmd.Parameters.Add("@CATEGORIE", SqlDbType.Int).Value = CATEGORIE;
					cmd.Parameters.Add("@COUT_DE_PRODUCTION", SqlDbType.Money).Value = COUT_DE_PRODUCTION;
					cmd.Parameters.Add("@QT_DANS_PACK", SqlDbType.Int).Value = QT_DANS_PACK;
					cmd.Parameters.Add("@QT_TOTAL", SqlDbType.Int).Value = QT_TOTAL;
					cmd.Parameters.Add("@QT_VENTE", SqlDbType.Int).Value = QT_VENTE;
					cmd.Parameters.Add("@QT_REST", SqlDbType.Int).Value = QT_REST;
					cmd.Parameters.Add("@QT_DECHET", SqlDbType.Int).Value = QT_DECHET;
					cmd.Parameters.Add("@PRICE_VENTE_HT", SqlDbType.Money).Value = PRICE_VENTE_HT;
					cmd.Parameters.Add("@PRICE_VENTE_TTC", SqlDbType.Money).Value = PRICE_VENTE_TTC;
					cmd.Parameters.Add("@TVA", SqlDbType.Float).Value = TVA;
					cmd.Parameters.Add("@PRICE_GROS", SqlDbType.Money).Value = PRICE_GROS;
					cmd.Parameters.Add("@PRICE_MIN", SqlDbType.Money).Value = PRICE_MIN;
					cmd.Parameters.Add("@qt_alter", SqlDbType.Int).Value = qt_alter;

					cmd.ExecuteNonQuery();
				}
			}
		}

		public void edit_gestion_produit_finaux( 
				 string CODE_BARRE
			   , string DESIGNATION
			   , int QT_PARAMETRAGE
			   , int UNITE
			   , int CATEGORIE
			   , decimal COUT_DE_PRODUCTION
			   , int QT_DANS_PACK 
			   , decimal PRICE_VENTE_HT
			   , decimal PRICE_VENTE_TTC
			   , float TVA
			   , decimal PRICE_GROS
			   , decimal PRICE_MIN
			   , int qt_alter
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("edit_gestion_produit_finaux", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@CODE_BARRE", SqlDbType.NVarChar).Value = CODE_BARRE;
					cmd.Parameters.Add("@DESIGNATION", SqlDbType.NVarChar).Value = DESIGNATION;
					cmd.Parameters.Add("@QT_PARAMETRAGE", SqlDbType.Int).Value = QT_PARAMETRAGE;
					cmd.Parameters.Add("@UNITE", SqlDbType.Int).Value = UNITE;
					cmd.Parameters.Add("@CATEGORIE", SqlDbType.Int).Value = CATEGORIE;
					cmd.Parameters.Add("@COUT_DE_PRODUCTION", SqlDbType.Money).Value = COUT_DE_PRODUCTION;
					cmd.Parameters.Add("@QT_DANS_PACK", SqlDbType.Int).Value = QT_DANS_PACK; 
					cmd.Parameters.Add("@PRICE_VENTE_HT", SqlDbType.Money).Value = PRICE_VENTE_HT;
					cmd.Parameters.Add("@PRICE_VENTE_TTC", SqlDbType.Money).Value = PRICE_VENTE_TTC;
					cmd.Parameters.Add("@TVA", SqlDbType.Float).Value = TVA;
					cmd.Parameters.Add("@PRICE_GROS", SqlDbType.Money).Value = PRICE_GROS;
					cmd.Parameters.Add("@PRICE_MIN", SqlDbType.Money).Value = PRICE_MIN;
					cmd.Parameters.Add("@qt_alter", SqlDbType.Int).Value = qt_alter;

					cmd.ExecuteNonQuery();
				}
			}
		}
		public void INSERT_matier_premier_production_caisse( 
				 string ID_PRODUIT_FINAUX
			   , string ID_MATIER_PREMIER
			   , int Qt
			   , decimal PRICE_ACHAT
			   , decimal PRICE_TTL
			   , int QT_DECHET
			   , string delete
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("INSERT_matier_premier_production_caisse", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID_PRODUIT_FINAUX", SqlDbType.NVarChar).Value = ID_PRODUIT_FINAUX;
					cmd.Parameters.Add("@ID_MATIER_PREMIER", SqlDbType.NVarChar).Value = ID_MATIER_PREMIER;
					cmd.Parameters.Add("@Qt", SqlDbType.Int).Value = Qt;
					cmd.Parameters.Add("@PRICE_ACHAT", SqlDbType.Money).Value = PRICE_ACHAT;
					cmd.Parameters.Add("@PRICE_TTL", SqlDbType.Money).Value = PRICE_TTL;
					cmd.Parameters.Add("@QT_DECHET", SqlDbType.Int).Value = QT_DECHET;
					cmd.Parameters.Add("@delete", SqlDbType.NVarChar).Value = delete;
					cmd.ExecuteNonQuery();
				}
			}
		}


		public void INSERT_matier_premier_production_for_edit(
				 string ID_PRODUIT_FINAUX
			   , string ID_MATIER_PREMIER
			   , int Qt
			   , decimal PRICE_ACHAT
			   , decimal PRICE_TTL
			   , int QT_DECHET
			   , string delete
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("insert_matier_premier_for_edit", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID_PRODUIT_FINAUX", SqlDbType.NVarChar).Value = ID_PRODUIT_FINAUX;
					cmd.Parameters.Add("@ID_MATIER_PREMIER", SqlDbType.NVarChar).Value = ID_MATIER_PREMIER;
					cmd.Parameters.Add("@Qt", SqlDbType.Int).Value = Qt;
					cmd.Parameters.Add("@PRICE_ACHAT", SqlDbType.Money).Value = PRICE_ACHAT;
					cmd.Parameters.Add("@PRICE_TTL", SqlDbType.Money).Value = PRICE_TTL;
					cmd.Parameters.Add("@QT_DECHET", SqlDbType.Int).Value = QT_DECHET;
					cmd.Parameters.Add("@delete", SqlDbType.NVarChar).Value = delete;
					cmd.ExecuteNonQuery();
				}
			}
		}

		public void insert_pack(
				 string		BARCODE_PACK
			   , string		DESIGNATION
			   , string		ID_PRODUIT_FINAUX
			   , float		QT_DISPONIBLE
			   , decimal	PRICE_GROS
			   , decimal	PRICE_DETAILLE
			   , decimal	PRICE_MIN
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("insert_pack_information", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@BARCODE_PACK", SqlDbType.NVarChar).Value = BARCODE_PACK;
					cmd.Parameters.Add("@DESIGNATION", SqlDbType.NVarChar).Value = DESIGNATION;
					cmd.Parameters.Add("@ID_PRODUIT_FINAUX", SqlDbType.NVarChar).Value = ID_PRODUIT_FINAUX;
					cmd.Parameters.Add("@QT_DISPONIBLE", SqlDbType.Float).Value = QT_DISPONIBLE;
					cmd.Parameters.Add("@PRICE_GROS", SqlDbType.Money).Value = PRICE_GROS;
					cmd.Parameters.Add("@PRICE_DETAILLE", SqlDbType.Money).Value = PRICE_DETAILLE;
					cmd.Parameters.Add("@PRICE_MIN", SqlDbType.Money).Value = PRICE_MIN;
					cmd.ExecuteNonQuery();
				}
			}
		}

		public void delete_tb_caisse_( 
				 int ID 
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open(); 
				using (SqlCommand cmd = new SqlCommand("delete_matier_premier_caisse_production", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure; 
					cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID; 
					cmd.ExecuteNonQuery();
				}
			}
		}
		public void delte_matier_for_edit(
				 int ID
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();
				using (SqlCommand cmd = new SqlCommand("delte_matier_for_edit", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
					cmd.ExecuteNonQuery();
				}
			}
		}

	}
}
