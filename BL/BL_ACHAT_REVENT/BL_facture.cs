using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_ACHAT_REVENT
{
	public class BL_facture
	{
		public DataTable get_detaiile_fctr(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_fctr", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("get_detaiile_fctr", param);
			DAL.Close();
			return Dt;
		}
		public DataTable get_tb_facture()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("select_facture_produit_revente", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_fichier_facture_produit_prevent()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_fichier_facture_produit_prevent", null);
			DAL.Close();
			return Dt;
		}
		public DataTable search_fichier_facture_produit_prevent(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_Search", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("search_fichier_facture_produit_prevent", param);
			DAL.Close();
			return Dt;
		}
		public DataTable get_Img_fichier_facture_produit_prevent(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("get_Img_fichier_facture_produit_prevent", param);
			DAL.Close();
			return Dt;
		}
		public DataTable get_image_folder_produit_revernet(int id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("get_image_folder_produit_revernet", param);
			DAL.Close();
			return Dt;
		}
		public void insert_fichier_for_fctr(
				 string ID_FACTURE
			   , string REMARQUE
			   , Byte[] IMAGE
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("insert_fichier_for_fctr", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID_FACTURE", SqlDbType.NVarChar).Value = ID_FACTURE;
					cmd.Parameters.Add("@REMARQUE", SqlDbType.NVarChar).Value = REMARQUE;
					cmd.Parameters.Add("@IMAGE", SqlDbType.Image).Value = IMAGE;

					cmd.ExecuteNonQuery();
				}
			}
		}
		
		DAL.DAL daoo;
		public void InsertFactureAchatProduitRevent(
				string nmrFctr,
				DateTime date,
				int idFournisseur,
				int nombreDeProduit,
				decimal versement,
				decimal total,
				int idUser,
				decimal totalHt,
				decimal creditPrecedent,
				decimal creditAfter
		)
		{ 
			daoo = new DAL.DAL();

			using (daoo.sqlConnection)
			{
				using (SqlCommand command = new SqlCommand("Insert_FactureAchatProduitRevent", daoo.sqlConnection))
				{
					command.CommandType = CommandType.StoredProcedure;

					command.Parameters.AddWithValue("@NMR_FCTR", nmrFctr);
					command.Parameters.AddWithValue("@DATE", date);
					command.Parameters.AddWithValue("@ID_FOURNISSEUR", idFournisseur);
					command.Parameters.AddWithValue("@NMBRE_DE_PRODUIT", nombreDeProduit);
					command.Parameters.AddWithValue("@VERSEMNT", versement);
					command.Parameters.AddWithValue("@TOTAL", total);
					command.Parameters.AddWithValue("@ID_USER", idUser);
					command.Parameters.AddWithValue("@TOTAL_HT", totalHt);
					command.Parameters.AddWithValue("@CREDIT_PRECEDENT", creditPrecedent);
					command.Parameters.AddWithValue("@CREDIT_AFTER", creditAfter);

					daoo.sqlConnection.Open();
					command.ExecuteNonQuery();
					 
				}
			} 
		}


		////search
		public DataTable search_facture_produit_revent_by_frnsre(int id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_frnsre", SqlDbType.Int);
			param[0].Value = id;
			Dt = DAL.SelectData("search_facture_produit_revent_by_frnsre", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_facture_produit_revent_by_Date(DateTime id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@Date", SqlDbType.Date);
			param[0].Value = id;
			Dt = DAL.SelectData("search_facture_produit_revent_by_Date", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_facture_produit_revent_between_Date(DateTime StartDate, DateTime EndDate)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[2];
			param[0] = new SqlParameter("@StartDate", SqlDbType.Date);
			param[0].Value = StartDate;
			param[1] = new SqlParameter("@EndDate", SqlDbType.Date);
			param[1].Value = EndDate;
			Dt = DAL.SelectData("search_facture_produit_revent_between_Date", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_facture_produit_revent_(string ID_Search)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar);
			param[0].Value = ID_Search; 
			Dt = DAL.SelectData("search_facture_produit_revent_", param);
			DAL.Close();
			return Dt;
		}
	}
}
