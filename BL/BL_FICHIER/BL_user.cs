using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.QrCode.Internal;

namespace Smart_Production_Pos.BL.BL_FICHIER
{
	public class BL_user
	{
		//////////////////////// GetTable Client
		public DataTable select_user_()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("select_user_", null);
			DAL.Close();
			return Dt;
		}

		#region Search 
		public DataTable search_user(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar, 50);
			param[0].Value = id;
			Dt = DAL.SelectData("search_user", param);
			DAL.Close();
			return Dt;
		}
		#endregion
		////////////////*************   ADD Client   **************///////////////
		DAL.DAL daoo;

        public void Add_Funct(
    int ID_OUVERIER,
    string USERR,
    string PASS,
    string ROLE,
    string ETAS,
    string code,
    int Stock,
    int unite,
    int categorie,
    int marque,
    int favoris,
    int taille,
    int color,
    int fournisseure,
    int ouverier,
    int users,
    int caissier,
    int client,
    int historique_client,
    int remarque,
    int achat,
    int facture_achat,
    int dossier_fctr_achat,
    int historique_frnsre,
    int stock_produit,
    int pack,
    int facture_vente,
    int list_vente,
    int liv,
    int POS,
    int les_charge,
    int lapie,
    int transition_caissier,
    int state_total,
    int benifice,
    int serverss,
    int facture_info
)
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("insert_user_info", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ID_OUVERIER", SqlDbType.Int).Value = ID_OUVERIER;
                    cmd.Parameters.Add("@USERR", SqlDbType.NVarChar, 50).Value = USERR;
                    cmd.Parameters.Add("@PASS", SqlDbType.NVarChar, 50).Value = PASS;
                    cmd.Parameters.Add("@ROLE", SqlDbType.NVarChar, 50).Value = ROLE;
                    cmd.Parameters.Add("@ETAS", SqlDbType.NVarChar, 50).Value = ETAS;
                    cmd.Parameters.Add("@Code_Recupiraiton", SqlDbType.NVarChar, 50).Value = code;
                    cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = Stock;
                    cmd.Parameters.Add("@unite", SqlDbType.Int).Value = unite;
                    cmd.Parameters.Add("@categorie", SqlDbType.Int).Value = categorie;
                    cmd.Parameters.Add("@marque", SqlDbType.Int).Value = marque;
                    cmd.Parameters.Add("@favoris", SqlDbType.Int).Value = favoris;
                    cmd.Parameters.Add("@taille", SqlDbType.Int).Value = taille;
                    cmd.Parameters.Add("@color", SqlDbType.Int).Value = color;
                    cmd.Parameters.Add("@fournisseure", SqlDbType.Int).Value = fournisseure;
                    cmd.Parameters.Add("@ouverier", SqlDbType.Int).Value = ouverier;
                    cmd.Parameters.Add("@users", SqlDbType.Int).Value = users;
                    cmd.Parameters.Add("@caissier", SqlDbType.Int).Value = caissier;
                    cmd.Parameters.Add("@client", SqlDbType.Int).Value = client;
                    cmd.Parameters.Add("@historique_client", SqlDbType.Int).Value = historique_client;
                    cmd.Parameters.Add("@remarque", SqlDbType.Int).Value = remarque;
                    cmd.Parameters.Add("@achat", SqlDbType.Int).Value = achat;
                    cmd.Parameters.Add("@facture_achat", SqlDbType.Int).Value = facture_achat;
                    cmd.Parameters.Add("@dossier_fctr_achat", SqlDbType.Int).Value = dossier_fctr_achat;
                    cmd.Parameters.Add("@historique_frnsre", SqlDbType.Int).Value = historique_frnsre;
                    cmd.Parameters.Add("@stock_produit", SqlDbType.Int).Value = stock_produit;
                    cmd.Parameters.Add("@pack", SqlDbType.Int).Value = pack;
                    cmd.Parameters.Add("@facture_vente", SqlDbType.Int).Value = facture_vente;
                    cmd.Parameters.Add("@list_vente", SqlDbType.Int).Value = list_vente;
                    cmd.Parameters.Add("@liv", SqlDbType.Int).Value = liv;
                    cmd.Parameters.Add("@POS", SqlDbType.Int).Value = POS;
                    cmd.Parameters.Add("@les_charge", SqlDbType.Int).Value = les_charge;
                    cmd.Parameters.Add("@lapie", SqlDbType.Int).Value = lapie;
                    cmd.Parameters.Add("@transition_caissier", SqlDbType.Int).Value = transition_caissier;
                    cmd.Parameters.Add("@state_total", SqlDbType.Int).Value = state_total;
                    cmd.Parameters.Add("@benifice", SqlDbType.Int).Value = benifice;
                    cmd.Parameters.Add("@serverss", SqlDbType.Int).Value = serverss;
                    cmd.Parameters.Add("@facture_info", SqlDbType.Int).Value = facture_info;

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void edit_function(
          int ID,
          int ID_OUVERIER,
          string USERR,
          string PASS,
          string ROLE,
          string ETAS,
          string code,
          int Stock,
          int unite,
          int categorie,
          int marque,
          int favoris,
          int taille,
          int color,
          int fournisseure,
          int ouverier,
          int users,
          int caissier,
          int client,
          int historique_client,
          int remarque,
          int achat,
          int facture_achat,
          int dossier_fctr_achat,
          int historique_frnsre,
          int stock_produit,
          int pack,
          int facture_vente,
          int list_vente,
          int liv,
          int POS,
          int les_charge,
          int lapie,
          int transition_caissier,
          int state_total,
          int benifice,
          int serverss,
          int facture_info
        )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("update_user", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                    cmd.Parameters.Add("@ID_OUVERIER", SqlDbType.Int).Value = ID_OUVERIER;
                    cmd.Parameters.Add("@USERR", SqlDbType.NVarChar, 50).Value = USERR;
                    cmd.Parameters.Add("@PASS", SqlDbType.NVarChar, 50).Value = PASS;
                    cmd.Parameters.Add("@ROLE", SqlDbType.NVarChar, 50).Value = ROLE;
                    cmd.Parameters.Add("@ETAS", SqlDbType.NVarChar, 50).Value = ETAS;
                    cmd.Parameters.Add("@Code_Recupiraiton", SqlDbType.NVarChar, 50).Value = code;
                    cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = Stock;
                    cmd.Parameters.Add("@unite", SqlDbType.Int).Value = unite;
                    cmd.Parameters.Add("@categorie", SqlDbType.Int).Value = categorie;
                    cmd.Parameters.Add("@marque", SqlDbType.Int).Value = marque;
                    cmd.Parameters.Add("@favoris", SqlDbType.Int).Value = favoris;
                    cmd.Parameters.Add("@taille", SqlDbType.Int).Value = taille;
                    cmd.Parameters.Add("@color", SqlDbType.Int).Value = color;
                    cmd.Parameters.Add("@fournisseure", SqlDbType.Int).Value = fournisseure;
                    cmd.Parameters.Add("@ouverier", SqlDbType.Int).Value = ouverier;
                    cmd.Parameters.Add("@users", SqlDbType.Int).Value = users;
                    cmd.Parameters.Add("@caissier", SqlDbType.Int).Value = caissier;
                    cmd.Parameters.Add("@client", SqlDbType.Int).Value = client;
                    cmd.Parameters.Add("@historique_client", SqlDbType.Int).Value = historique_client;
                    cmd.Parameters.Add("@remarque", SqlDbType.Int).Value = remarque;
                    cmd.Parameters.Add("@achat", SqlDbType.Int).Value = achat;
                    cmd.Parameters.Add("@facture_achat", SqlDbType.Int).Value = facture_achat;
                    cmd.Parameters.Add("@dossier_fctr_achat", SqlDbType.Int).Value = dossier_fctr_achat;
                    cmd.Parameters.Add("@historique_frnsre", SqlDbType.Int).Value = historique_frnsre;
                    cmd.Parameters.Add("@stock_produit", SqlDbType.Int).Value = stock_produit;
                    cmd.Parameters.Add("@pack", SqlDbType.Int).Value = pack;
                    cmd.Parameters.Add("@facture_vente", SqlDbType.Int).Value = facture_vente;
                    cmd.Parameters.Add("@list_vente", SqlDbType.Int).Value = list_vente;
                    cmd.Parameters.Add("@liv", SqlDbType.Int).Value = liv;
                    cmd.Parameters.Add("@POS", SqlDbType.Int).Value = POS;
                    cmd.Parameters.Add("@les_charge", SqlDbType.Int).Value = les_charge;
                    cmd.Parameters.Add("@lapie", SqlDbType.Int).Value = lapie;
                    cmd.Parameters.Add("@transition_caissier", SqlDbType.Int).Value = transition_caissier;
                    cmd.Parameters.Add("@state_total", SqlDbType.Int).Value = state_total;
                    cmd.Parameters.Add("@benifice", SqlDbType.Int).Value = benifice;
                    cmd.Parameters.Add("@serverss", SqlDbType.Int).Value = serverss;
                    cmd.Parameters.Add("@facture_info", SqlDbType.Int).Value = facture_info;

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void edit_update_whene_Recupi(
     int ID,
     int ID_OUVERIER,
     string USERR,
     string PASS,
     string ROLE,
     string ETAS,
     string code 
 )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("edit_update_whene_Recupi", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                    cmd.Parameters.Add("@ID_OUVERIER", SqlDbType.Int).Value = ID_OUVERIER;
                    cmd.Parameters.Add("@USERR", SqlDbType.NVarChar, 50).Value = USERR;
                    cmd.Parameters.Add("@PASS", SqlDbType.NVarChar, 50).Value = PASS;
                    cmd.Parameters.Add("@ROLE", SqlDbType.NVarChar, 50).Value = ROLE;
                    cmd.Parameters.Add("@ETAS", SqlDbType.NVarChar, 50).Value = ETAS;
                    cmd.Parameters.Add("@Code_Recupiraiton", SqlDbType.NVarChar, 50).Value = code; 

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void delte_Client(
			 int id
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("delte_user", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
