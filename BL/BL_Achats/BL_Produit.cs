using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_Achats
{
	public class BL_Produit
	{
		#region detailes produit 
		public DataTable get_detailles(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_produit", SqlDbType.NVarChar, 50);
			param[0].Value = id;
			Dt = DAL.SelectData("get_detailles_produit", param);
			DAL.Close();
			return Dt;
		}

		public DataTable get_information_product(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@code_bare", SqlDbType.NVarChar, 50);
			param[0].Value = id;
			Dt = DAL.SelectData("get_tb_matier_premier", param);
			DAL.Close();
			return Dt;
		}

		public void insert_option_product(
			string ID_PRODUIT,
			string OPTION,
			string VALEUR
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{ 
				daoo.sqlConnection.Open(); 
				using (SqlCommand cmd = new SqlCommand("insert_option_product", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure; 
					cmd.Parameters.Add("@ID_PRODUIT", SqlDbType.NVarChar).Value = ID_PRODUIT;
					cmd.Parameters.Add("@OPTION", SqlDbType.NVarChar).Value = OPTION;
					cmd.Parameters.Add("@VALEUR", SqlDbType.NVarChar).Value = VALEUR;  
					cmd.ExecuteNonQuery();
				}
			}
		}

		public void delte_detailles(
			 int id
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("delte_detailles", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
					cmd.ExecuteNonQuery();
				}
			}
		}

		#endregion


		public DataTable get_detailles_produit(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@codeBarre", SqlDbType.NVarChar, 50);
			param[0].Value = id;
			Dt = DAL.SelectData("select_info", param);
			DAL.Close();
			return Dt;
		}

		public DataTable SEARCH_matier_premier(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar, 50);
			param[0].Value = id;
			Dt = DAL.SelectData("SEARCH_matier_premier", param);
			DAL.Close();
			return Dt;
		}



		public DataTable get_tb_stock_matier_premier()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_stock_matier_premier", null);
			DAL.Close();
			return Dt;
		} 
		DAL.DAL daoo;
		public void Add_Funct(
			string CODEBARRE,
			string DESIGNATION,
			int    UNITE,
			int    CATEGORIES,
			int    STOCKES,
			int    MARKE,
			int    QUANTITE,
			int    QUANTITE_REST,
			int    QUANTITE_USE,
			int?    QUANTITE_PACKES,
			 Byte[] PHOTO,
			DateTime? DATE_PREPARATION,
			string OBSERVATION,
			int STOCKES_MIN,
			string PRODUIT_DES_PIECES ,
			string reference
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("INSERT_MATIER_PREMIER", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@CODEBARRE", SqlDbType.NVarChar).Value = CODEBARRE;
					cmd.Parameters.Add("@DESIGNATION", SqlDbType.NVarChar).Value = DESIGNATION;
					cmd.Parameters.Add("@UNITE", SqlDbType.Int).Value = UNITE;
					cmd.Parameters.Add("@CATEGORIES", SqlDbType.Int).Value = CATEGORIES;
					cmd.Parameters.Add("@STOCKES", SqlDbType.Int).Value = STOCKES;
					cmd.Parameters.Add("@MARKE", SqlDbType.Int).Value = MARKE;
					cmd.Parameters.Add("@QUANTITE", SqlDbType.Int).Value = QUANTITE;
					cmd.Parameters.Add("@QUANTITE_REST", SqlDbType.Int).Value = QUANTITE_REST;
					cmd.Parameters.Add("@QUANTITE_USE", SqlDbType.Int).Value = QUANTITE_USE;
 					if (QUANTITE_PACKES.HasValue)
						cmd.Parameters.Add("@QUANTITE_PACKES", SqlDbType.Int).Value = QUANTITE_PACKES.Value;
					else
						cmd.Parameters.Add("@QUANTITE_PACKES", SqlDbType.Int).Value = DBNull.Value;

					cmd.Parameters.Add("@PHOTO", SqlDbType.Image).Value = PHOTO;
 					if (DATE_PREPARATION.HasValue)
						cmd.Parameters.Add("@DATE_PREPARATION", SqlDbType.Date).Value = DATE_PREPARATION.Value;
					else
						cmd.Parameters.Add("@DATE_PREPARATION", SqlDbType.Date).Value = DBNull.Value;


					cmd.Parameters.Add("@OBSERVATION", SqlDbType.NVarChar).Value = OBSERVATION;
					cmd.Parameters.Add("@STOCKES_MIN", SqlDbType.Int).Value = STOCKES_MIN;
					 
					cmd.Parameters.Add("@PRODUIT_DES_PIECES", SqlDbType.NVarChar).Value = PRODUIT_DES_PIECES;
					cmd.Parameters.Add("@reference", SqlDbType.NVarChar).Value = reference;


					cmd.ExecuteNonQuery();
				}
			}
		}

		 

	}
}
