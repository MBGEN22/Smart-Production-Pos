using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_Achats
{
	public class BL_facture
	{
		public DataTable get_tb_facture()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_tb_fctr", null);
			DAL.Close();
			return Dt;
		}
		public DataTable search_Facture_achat(string search)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_SEARCH", SqlDbType.NVarChar, 50);
			param[0].Value = search;
			Dt = DAL.SelectData("search_Facture_achat", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_Facture_achat_by_frnsre(int frnsreID)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@frnsreID", SqlDbType.Int);
			param[0].Value = frnsreID;
			Dt = DAL.SelectData("search_Facture_achat_by_frnsre", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_Facture_achat_by_date(DateTime date)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@date", SqlDbType.Date);
			param[0].Value = date;
			Dt = DAL.SelectData("search_Facture_achat_by_date", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_Facture_achat_between_date(DateTime first_Date , DateTime end_Date)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[2];
			param[0] = new SqlParameter("@StartDate", SqlDbType.Date);
			param[0].Value = first_Date;
			param[1] = new SqlParameter("@EndDate", SqlDbType.Date);
			param[1].Value = end_Date;
			Dt = DAL.SelectData("search_Facture_achat_by_between_Date", param);
			DAL.Close();
			return Dt;
		}
		public DataTable GET_LIST_UPLOAD_FACTURE_ACHAT()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("GET_LIST_UPLOAD_FACTURE_ACHAT", null);
			DAL.Close();
			return Dt;
		}
		public DataTable search_upload_fichier_facture(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar, 50);
			param[0].Value = id;
			Dt = DAL.SelectData("search_upload_fichier_facture", param);
			DAL.Close();
			return Dt;
		}

		public DataTable GET_LIST_UPLOAD_FACTURE_ACHAT_img(int id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@id", SqlDbType.NVarChar, 50);
			param[0].Value = id;
			Dt = DAL.SelectData("get_image_folder", param);
			DAL.Close();
			return Dt;
		}
		public DataTable get_detailles(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@id_fctr", SqlDbType.NVarChar, 50);
			param[0].Value = id;
			Dt = DAL.SelectData("get_achat_by_id_fctre", param);
			DAL.Close();
			return Dt;
		}

		DAL.DAL daoo;

		public void create_facture_achat(

				 string NMR_FCTR
			   , DateTime DATE
			   , int ID_FRNSR
			   , int NMBRE_PRODUIT
			   , decimal VERSEMENT
			   , decimal TOTAL
			   , int ID_USER
			   , decimal total_HT
			   , decimal Creditprecidenet
			   , decimal creditNew
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("create_facture", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@NMR_FCTR", SqlDbType.NVarChar).Value = NMR_FCTR;
					cmd.Parameters.Add("@DATE", SqlDbType.Date).Value = DATE;
					cmd.Parameters.Add("@ID_FRNSR", SqlDbType.Int).Value = ID_FRNSR;
					cmd.Parameters.Add("@NMBRE_PRODUIT", SqlDbType.Int).Value = NMBRE_PRODUIT;
					cmd.Parameters.Add("@VERSEMENT", SqlDbType.Money).Value = VERSEMENT;
					cmd.Parameters.Add("@TOTAL", SqlDbType.Money).Value = TOTAL;
					cmd.Parameters.Add("@ID_USER", SqlDbType.Int).Value = ID_USER;
					cmd.Parameters.Add("@total_HT", SqlDbType.Money).Value = total_HT;
					cmd.Parameters.Add("@Creditprecidenet", SqlDbType.Money).Value = Creditprecidenet;
					cmd.Parameters.Add("@creditNew", SqlDbType.Money).Value = creditNew;

					cmd.ExecuteNonQuery();
				}
			}
		}
		public void INSERT_upload_folder( 
				 string ID_FACTURE
			   , string REMARQUE
			   , Byte[] IMAGE 
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("insert_folder_facture", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID_FACTURE", SqlDbType.NVarChar).Value = ID_FACTURE;
					cmd.Parameters.Add("@REMARQUE", SqlDbType.NVarChar).Value = REMARQUE;
					cmd.Parameters.Add("@IMAGE", SqlDbType.Image).Value = IMAGE; 

					cmd.ExecuteNonQuery();
				}
			}
		}

	}
}
