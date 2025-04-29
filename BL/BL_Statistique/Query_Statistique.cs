using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_Statistique
{
	public class Query_Statistique
	{
		public string Count_Caissier()
		{
			DAL.DAL DAaL = new DAL.DAL(); 
			string newID ="0";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Count([ID]) FROM [dbo].[TB_INFO_DE_LIV] ";
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
		public string count_user()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Count([ID]) FROM [dbo].TB_USER";
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
		public string Count_fournisseure()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Count([ID]) FROM [dbo].TB_FOURNISSUER";
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
		public string count_client()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Count([ID]) FROM [dbo].TB_CLIENT";
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
		public string count_ouverier()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Count([ID]) FROM [dbo].TB_OUVERIER";
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
		public string count_facture()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Count(NMR_FACTURE) FROM [dbo].TB_FACTURE_VENTE";
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
		public string count_commande()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Count(ID) FROM [dbo].TB_COMMANDE";
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
		public string count_produit_stock()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "select count (CodeBarre)from TB_Produit_revente";
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
		public string gestion_produit_finaux()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Count(CODE_BARRE) FROM [dbo].TB_GESTION_PRODUIT_FINAUX";
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
		public string pack_gestion_produit_finaux()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Count(BARCODE_PACK) FROM [dbo].TB_PACK_GESTION_PRODUIT_FINAUX";
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
		//--------------------------------------------------------------------//
		public string sum_depense()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Sum(TB_DEPENSE.VALEURE) FROM [dbo].TB_DEPENSE";
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
		public string taklufa_commande()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = " SELECT Sum(TB_COMMANDE.COUT_TOTAL) FROM [dbo].TB_COMMANDE";
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
		public string taklufa_PF()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Sum(TB_GESTION_PRODUIT_FINAUX.COUT_DE_PRODUCTION) FROM [dbo].TB_GESTION_PRODUIT_FINAUX";
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
		public string txt_sum_la_paye()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "select SUM([PRICE_PAYER]) from [TB_VERSEMNT_OUVERIER]";
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
		//------------------------------TOTAL--------------------------------------//
		public string total_ttc_commande()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Sum(TB_COMMANDE.PRICE_TOTAL_TTC) FROM [dbo].TB_COMMANDE";
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
		public string total_ttc_fct_vente()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = " SELECT Sum(TB_FACTURE_VENTE.TOTAL_FACURE_TTC) FROM [dbo].TB_FACTURE_VENTE";
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
		//public string ttl_ttc_fctr_achat()
		//{
		//	DAL.DAL DAaL = new DAL.DAL();
		//	string newID = "0";

		//	using (DAaL.sqlConnection)
		//	{
		//		string query = "SELECT Sum(TB_FACTURE_ACHAT.TOTAL) FROM [dbo].TB_FACTURE_ACHAT";
		//		using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
		//		{
		//			DAaL.sqlConnection.Open();
		//			var result = command.ExecuteScalar();
		//			if (result != DBNull.Value)
		//			{
		//				newID = result.ToString();
		//			}
		//		}
		//	}
		//	return newID;
		//}
		public string ttl_ttc_fctr_achat()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Sum(TB_FACTURE_ACHAT_PRODUIT_REVENT.TOTAL) FROM [dbo].TB_FACTURE_ACHAT_PRODUIT_REVENT";
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
		//----------------------------VERSEMENT---------------------------------------//
		public string total_versemnt_ttc_commande()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Sum(TB_COMMANDE.VERSEMENT) FROM [dbo].TB_COMMANDE";
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
		public string total_versemnt_ttc_fct_vente()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Sum(TB_FACTURE_VENTE.VERSEMENT) FROM [dbo].TB_FACTURE_VENTE";
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
		//public string ttl_versemnt_ttc_fctr_achat()
		//{
		//	DAL.DAL DAaL = new DAL.DAL();
		//	string newID = "0";

		//	using (DAaL.sqlConnection)
		//	{
		//		string query = "SELECT Sum(TB_FACTURE_ACHAT.VERSEMENT) FROM [dbo].TB_FACTURE_ACHAT";
		//		using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
		//		{
		//			DAaL.sqlConnection.Open();
		//			var result = command.ExecuteScalar();
		//			if (result != DBNull.Value)
		//			{
		//				newID = result.ToString();
		//			}
		//		}
		//	}
		//	return newID;
		//}
		public string ttl_versemnt_ttc_fctr_achat()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Sum(TB_FACTURE_ACHAT_PRODUIT_REVENT.VERSEMNT) FROM [dbo].TB_FACTURE_ACHAT_PRODUIT_REVENT";
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
		public string cout_de_facture()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Sum([TB_FACTURE_VENTE].[cout_of_fctr]) FROM [dbo].[TB_FACTURE_VENTE]";
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

		//------------------------------Fournissure--------------------------------------//
		public string vers_frnsre()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Sum(TB_FOURNISSUER.SOLD_PAYE) FROM [dbo].TB_FOURNISSUER";
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
		public string rest_frnsre()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = " SELECT Sum(TB_FOURNISSUER.SOLD_NON_PAYE) FROM [dbo].TB_FOURNISSUER";
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
		//------------------------------client--------------------------------------//
		public string vers_client()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Sum(TB_CLIENT.SOLD_PAYE) FROM [dbo].TB_CLIENT";
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
		public string rest_client()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "SELECT Sum(TB_CLIENT.SOLD_NON_PAYE) FROM [dbo].TB_CLIENT";
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

		//------------------------------dechet--------------------------------------//
		public string dechet_no_receycle()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "select sum(price_ttl) from TB_DECHET";
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
		public string TB_DECHET_REClage()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string newID = "0";

			using (DAaL.sqlConnection)
			{
				string query = "select sum(price_ttl) from TB_DECHET_REClage";
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

		//------------------------------client--------------------------------------//
		public DataTable sp_UpdateIDClientCount()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("sp_UpdateIDClientCount", null);
			DAL.Close();
			return Dt;
		}
		public DataTable sp_UpdateIDClientCount_frnsre()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("sp_UpdateIDClientCount_frnsre", null);
			DAL.Close();
			return Dt;
		}
	}
}
