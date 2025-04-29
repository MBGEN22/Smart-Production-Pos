using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_Achats
{
	public class BL_Achats
	{

		
		public int get_TOTAL_HT()
		{
			DAL.DAL DAaL = new DAL.DAL();

			int newID = 0;

			using (DAaL.sqlConnection)
			{
				string query = "select SUM(TOTAL_HT) from TB_ACHAT_CAISSE;";
				using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
				{
					DAaL.sqlConnection.Open();
					var result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						newID = Convert.ToInt32(result) + 0;
					}
				}
			}
			return newID;
		}

		public int get_TOTAL_TTC()
		{
			DAL.DAL DAaL = new DAL.DAL();

			int newID = 0;

			using (DAaL.sqlConnection)
			{
				string query = "select SUM(TOTAL_TTC) from TB_ACHAT_CAISSE;";
				using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
				{
					DAaL.sqlConnection.Open();
					var result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						newID = Convert.ToInt32(result) + 0;
					}
				}
			}
			return newID;
		}
		 
		public void delete_caisse_product(
			 int id
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("delete_from_caisse_achat", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
					cmd.ExecuteNonQuery();
				}
			}
		}
		public void delete_caisse_new_pro(
			 string id
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("delete_product_new", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@barCode", SqlDbType.NVarChar).Value = id;
					cmd.ExecuteNonQuery();
				}
			}
		}
		public int _nmbre_produit()
		{
			DAL.DAL DAaL = new DAL.DAL();

			int newID = 1;

			using (DAaL.sqlConnection)
			{
				string query = "select Count(TOTAL_TTC) from TB_ACHAT_CAISSE;";
				using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
				{
					DAaL.sqlConnection.Open();
					var result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						newID = Convert.ToInt32(result) + 0;
					}
				}
			}
			return newID;
		}

		public string get_facture_number()
		{

			DAL.DAL DAaL = new DAL.DAL();

			string newID = "";

			using (DAaL.sqlConnection)
			{
				string query = "select concat('FC', format(convert(int, stuff(max(NMR_FCTR), 1, 3, ''))+1 , '0000'))  from TB_FACTURE_ACHAT";
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
		public DataTable get_Caisse_table()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("GET_CAISSE_PRODUCT", null);
			DAL.Close();
			return Dt;
		}
		DAL.DAL daoo; 
		public void add_on_caisse_matier_premier( 
				 string ID_PRODUIT
			   , int QUANTITE
			   , int QUANTITE_AFTER
			   , decimal PRIX_ACHAT_HT
			   , decimal TVA
			   , decimal PRIX_ACHAT_TTC
			   , decimal TOTAL_HT
			   , decimal TOTAL_TTC
			   , string REMARQUE
			   , string ID_FACTURE 
			   , string Type_achat
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("ADD_ON_CAISSE", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID_PRODUIT", SqlDbType.NVarChar).Value = ID_PRODUIT;
					cmd.Parameters.Add("@QUANTITE", SqlDbType.Int).Value = QUANTITE;
					cmd.Parameters.Add("@QUANTITE_AFTER", SqlDbType.Int).Value = QUANTITE_AFTER;
					cmd.Parameters.Add("@PRIX_ACHAT_HT", SqlDbType.Money).Value = PRIX_ACHAT_HT;
					cmd.Parameters.Add("@TVA", SqlDbType.Float).Value = TVA;
					cmd.Parameters.Add("@PRIX_ACHAT_TTC", SqlDbType.Money).Value = PRIX_ACHAT_TTC;
					cmd.Parameters.Add("@TOTAL_HT", SqlDbType.Money).Value = TOTAL_HT;
					cmd.Parameters.Add("@TOTAL_TTC", SqlDbType.Money).Value = TOTAL_TTC;
					cmd.Parameters.Add("@REMARQUE", SqlDbType.NVarChar).Value = REMARQUE;
					cmd.Parameters.Add("@ID_FACTURE", SqlDbType.NVarChar).Value = ID_FACTURE;
					cmd.Parameters.Add("@Type_achat", SqlDbType.NVarChar).Value = Type_achat;

					cmd.ExecuteNonQuery();
				}
			}
		}
		public void edit_matier_on_caisse(
				 string ID_PRODUIT
			   , int QUANTITE
			   , int QUANTITE_Rest 
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("calcel_update_matier", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@CODEBARRE", SqlDbType.NVarChar).Value = ID_PRODUIT;
					cmd.Parameters.Add("@QUANTITE", SqlDbType.Int).Value = QUANTITE;
					cmd.Parameters.Add("@QUANTITE_REST", SqlDbType.Int).Value = QUANTITE_Rest; 

					cmd.ExecuteNonQuery();
				}
			}
		}
		public void udate_matier_on_caisse(
				 string ID_PRODUIT
			   , int QUANTITE 
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("update_quantite_matier", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@CODEBARRE", SqlDbType.NVarChar).Value = ID_PRODUIT;
					cmd.Parameters.Add("@QUANTITE", SqlDbType.Int).Value = QUANTITE; 

					cmd.ExecuteNonQuery();
				}
			}
		}

		
		public DataTable get_sold_frnser(int id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@id", SqlDbType.Int);
			param[0].Value = id;
			Dt = DAL.SelectData("get_frnser_sold", param);
			DAL.Close();
			return Dt;
		}
	}
}
