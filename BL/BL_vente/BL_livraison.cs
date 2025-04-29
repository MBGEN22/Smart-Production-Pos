using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_vente
{
	public class BL_livraison
	{
		public DataTable get_Tb_livraison_vente()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_Tb_livraison_vente", null);
			DAL.Close();
			return Dt;
		}
		public DataTable search_Tb_livraison_vente(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("search_Tb_livraison_vente", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_TB_livraison_byDate(DateTime id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("search_Tb_livraison_vente_by_date", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_TB_livraison_by_client(int id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.Int);
			param[0].Value = id;
			Dt = DAL.SelectData("search_Tb_livraison_vente_by_client", param);
			DAL.Close();
			return Dt;
		}
		DAL.DAL daoo;
		public void insertLivraison(
			  DateTime date,
			  string sender,
			  string recupirateur,
			  string typeLiv,
			  decimal priceLiv,
			  string informationChauffeur,
			  string matricule,
			  int idUser,
			  int idCaissier,
			  string idFacture)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("InsertIntoLivraisonVente", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@DATE", SqlDbType.DateTime).Value = date;
					cmd.Parameters.Add("@SENDER", SqlDbType.NVarChar, 50).Value = sender;
					cmd.Parameters.Add("@RECUPIRATEUR", SqlDbType.NVarChar, 50).Value = recupirateur;
					cmd.Parameters.Add("@TYPE_LIV", SqlDbType.NVarChar, 50).Value = typeLiv;
					cmd.Parameters.Add("@PRICE_LIV", SqlDbType.Money).Value = priceLiv;
					cmd.Parameters.Add("@INFORMATION_CHAUFEURE", SqlDbType.NVarChar, 50).Value = informationChauffeur;
					cmd.Parameters.Add("@MATRICULE", SqlDbType.NVarChar, 50).Value = matricule;
					cmd.Parameters.Add("@ID_USER", SqlDbType.Int).Value = idUser;
					cmd.Parameters.Add("@ID_CAISSIER", SqlDbType.Int).Value = idCaissier;
					cmd.Parameters.Add("@id_Facture", SqlDbType.NVarChar, 50).Value = idFacture;

					cmd.ExecuteNonQuery();
				}
			}
		}

	}
}
