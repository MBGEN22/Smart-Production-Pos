using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart_Production_Pos.BL.BL_FICHIER;

namespace Smart_Production_Pos.BL.BL_vente
{
	public class bl_diminuer_la_Qt_vente
	{
		DAL.DAL daoo;
		public void delte_produit_finaux(
			  string codeBarre ,
			  int Qt_vente
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open(); 
				using (SqlCommand cmd = new SqlCommand("delte_produit_finaux", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure; 
					cmd.Parameters.Add("@codeBarre", SqlDbType.NVarChar).Value = codeBarre;
					cmd.Parameters.Add("@Qt_diminuer", SqlDbType.Int).Value = Qt_vente;  
					cmd.ExecuteNonQuery();
				}
			}
		}
		public void update_QT_apres_routour(
			  string codeBarre,
			  float Qt_vente
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();
				using (SqlCommand cmd = new SqlCommand("update_QT_apres_routour", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@codBarre", SqlDbType.NVarChar).Value = codeBarre;
					cmd.Parameters.Add("@QT", SqlDbType.Float).Value = Qt_vente;
					cmd.ExecuteNonQuery();
				}
			}
		}
		public void insert_routour_historique(
			  string codeBarre,
			  float QT,
			  int ID_CAISSIER,
			  int ID_USER,
			  DateTime DATE,
			  TimeSpan HEURE,
			  decimal price_U,
			  decimal Price_TTl,
			  decimal PRice_achat_ttl
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();
				using (SqlCommand cmd = new SqlCommand("insert_routour_historique", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@CODE_BARRE_PRODUIT ", SqlDbType.NVarChar).Value = codeBarre;
					cmd.Parameters.Add("@QT"	, SqlDbType.Float).Value = QT;
					cmd.Parameters.Add("@ID_CAISSIER", SqlDbType.Int).Value = ID_CAISSIER;
					cmd.Parameters.Add("@ID_USER", SqlDbType.Int).Value = ID_USER;
					cmd.Parameters.Add("@DATE", SqlDbType.Date).Value = DATE;
					cmd.Parameters.Add("@HEURE", SqlDbType.Time).Value = HEURE;
					cmd.Parameters.Add("@price_U", SqlDbType.Decimal).Value = price_U;
					cmd.Parameters.Add("@Price_TTl", SqlDbType.Decimal).Value = Price_TTl;
					cmd.Parameters.Add("@PRice_achat_ttl", SqlDbType.Decimal).Value = PRice_achat_ttl;
					cmd.ExecuteNonQuery();
				}
			}
		}

		public void delete_Produit_revent(
			string codeBarre,
			float Qt_vente
		)
		{
			DAL.DAL doo = new DAL.DAL();
			using (doo.sqlConnection)
			{
				using (SqlCommand cmd = new SqlCommand("deltee_produit_revent_Qt", doo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@Code_Barre_produit", SqlDbType.NVarChar).Value = codeBarre;
					cmd.Parameters.Add("@QT", SqlDbType.Float).Value = Qt_vente;

					doo.sqlConnection.Open(); // Ouvrir la connexion ici, avant d'exécuter la commande

					cmd.ExecuteNonQuery();

					// Fermer la connexion après avoir exécuté la commande
					doo.sqlConnection.Close();
				}
			}
		}

	}
}
