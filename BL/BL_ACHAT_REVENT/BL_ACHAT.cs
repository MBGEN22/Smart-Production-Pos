using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Smart_Production_Pos.BL.BL_ACHAT_REVENT
{
	public class BL_ACHAT
    {
        DAL.DAL daoo;

        public DataTable select_Tb_code_Barre(string codeBarre)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@Code_barre_principale", SqlDbType.NVarChar);
			param[0].Value = codeBarre;
			Dt = DAL.SelectData("get_tb_codeBarre_resever", param);
			DAL.Close();
			return Dt;
		}
        public DataTable get_Price_and_QT_OLD(string codeBarre)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@codeBarre", SqlDbType.NVarChar);
            param[0].Value = codeBarre;
            Dt = DAL.SelectData("get_Price_and_QT_OLD", param);
            DAL.Close();
            return Dt;
        }
        public DataTable check_if_pack_exite(string codeBarre)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_Product", SqlDbType.NVarChar);
            param[0].Value = codeBarre;
            Dt = DAL.SelectData("check_if_pack_exite", param);
            DAL.Close();
            return Dt;
        }
        public DataTable get_tb_codeBarre_resever_pack(string codeBarre)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@CodeBarrePrincipale", SqlDbType.NVarChar);
			param[0].Value = codeBarre;
			Dt = DAL.SelectData("get_tb_codeBarre_resever_pack", param);
			DAL.Close();
			return Dt;
		}
        public void update_facture_achat(
                string nmrFctr,
                DateTime date,
                int idFournisseur,
                int nombreDeProduit,
                decimal versement,
                decimal total, 
                decimal totalHt,
                decimal creditPrecedent,
                decimal creditAfter
        )
        {
            daoo = new DAL.DAL();

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand("update_facture_achat", daoo.sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@NMR_FCTR", nmrFctr);
                    command.Parameters.AddWithValue("@DATE", date);
                    command.Parameters.AddWithValue("@ID_FOURNISSEUR", idFournisseur);
                    command.Parameters.AddWithValue("@NMBRE_DE_PRODUIT", nombreDeProduit);
                    command.Parameters.AddWithValue("@VERSEMNT", versement);
                    command.Parameters.AddWithValue("@TOTAL", total); 
                    command.Parameters.AddWithValue("@TOTAL_HT", totalHt);
                    command.Parameters.AddWithValue("@CREDIT_PRECEDENT", creditPrecedent);
                    command.Parameters.AddWithValue("@CREDIT_AFTER", creditAfter);

                    daoo.sqlConnection.Open();
                    command.ExecuteNonQuery();

                }
            }
        }
        public void insert_fichier_for_fctr(
				 string ID_PRODUIT
			   , string QUANTITE
			   , float QUANTITE_Rest
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("insert_fichier_for_fctr", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@CODEBARRE", SqlDbType.NVarChar).Value = ID_PRODUIT;
					cmd.Parameters.Add("@QUANTITE", SqlDbType.Float).Value = QUANTITE;
					cmd.Parameters.Add("@QUANTITE_REST", SqlDbType.Float).Value = QUANTITE_Rest;

					cmd.ExecuteNonQuery();
				}
			}
		}
		public DataTable tb_reserve_code(string codeBarre)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@Code_barre_principale", SqlDbType.NVarChar);
			param[0].Value = codeBarre;
			Dt = DAL.SelectData("tb_reserve_code", param);
			DAL.Close();
			return Dt;
		}
		public void deltete_new_revent_product(
			 string id
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("deltete_new_revent_product", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@barCode", SqlDbType.NVarChar).Value = id;
					cmd.ExecuteNonQuery();
				}
			}
		}
		public void edit_matier_on_caisse(
				 string ID_PRODUIT
			   , float QUANTITE
			   , float QUANTITE_Rest
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("calcel_update_matier_revente", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@CODEBARRE", SqlDbType.NVarChar).Value = ID_PRODUIT;
					cmd.Parameters.Add("@QUANTITE", SqlDbType.Float).Value = QUANTITE;
					cmd.Parameters.Add("@QUANTITE_REST", SqlDbType.Float).Value = QUANTITE_Rest;

					cmd.ExecuteNonQuery();
				}
			}
		}
        public void delete_produit_revente_from_list_achat(
             int id
            )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("delete_produit_revente_from_list_achat", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void delet_pack_produit_revent(
             string id
            )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("delet_pack_produit_revent", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id_produit", SqlDbType.NVarChar).Value = id;
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

				using (SqlCommand cmd = new SqlCommand("delete_produit_revent", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@codeBarre", SqlDbType.NVarChar).Value = id;
					cmd.ExecuteNonQuery();
				}
			}
		}
		public void delete_caisse_product(
			int id
		   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();
				//delet_from_Caisse_achat_prevent
				using (SqlCommand cmd = new SqlCommand("delet_from_Caisse_achat_prevent", daoo.sqlConnection))
				{
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
					cmd.ExecuteNonQuery();
				}
			}
		}
		public void delete_tb_reserve_code(
			string code_secodaire
		   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();
				//delet_from_Caisse_achat_prevent
				using (SqlCommand cmd = new SqlCommand("delete_tb_reserve_code", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@Code_barre_principale", SqlDbType.NVarChar).Value = code_secodaire;
					cmd.ExecuteNonQuery();
				}
			}
		} 
		public void delete_one_from_tb_reserve_code(
			int code_secodaire
		   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();
				//delet_from_Caisse_achat_prevent
				using (SqlCommand cmd = new SqlCommand("delete_one_from_tb_reserve_code", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@code_secodaire", SqlDbType.Int).Value = code_secodaire;
					cmd.ExecuteNonQuery();
				}
			}
		}

		public void delete_by_code_barre_secondaire_pack(
			string code_secodaire
		   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();
				//delet_from_Caisse_achat_prevent
				using (SqlCommand cmd = new SqlCommand("delete_by_code_barre_secondaire", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@codeSecondaire", SqlDbType.NVarChar).Value = code_secodaire;
					cmd.ExecuteNonQuery();
				}
			}
		}


		public void update_QT_produit_prevent(
				 string		CodeBarre 
				,DateTime?	date_expiration
				,decimal	price_achat_HT
				,decimal	price_achat_TTC
				,float		TVA
				,float		Quantite_shop
				, decimal price_vente1
				,decimal price_vente2
				 ,decimal price_min
				,float Quantite_alert
				, float ihtiyaj
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("update_QT_produit_prevent", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
 
					cmd.Parameters.Add("@CodeBarre", SqlDbType.NVarChar, 50).Value = CodeBarre;
					if (date_expiration.HasValue) 
						cmd.Parameters.Add("@date_expiration", SqlDbType.Date).Value = date_expiration.Value;
					else
						cmd.Parameters.Add("@date_expiration", SqlDbType.Date).Value = DBNull.Value; 
					//
					cmd.Parameters.Add("@price_achat_HT", SqlDbType.Money).Value = price_achat_HT;
					cmd.Parameters.Add("@price_achat_TTC", SqlDbType.Money).Value = price_achat_TTC;
					cmd.Parameters.Add("@TVA", SqlDbType.Float).Value = TVA;
					cmd.Parameters.Add("@Quantite_shop", SqlDbType.Float).Value = Quantite_shop;
					//
                    cmd.Parameters.Add("@price_vente1", SqlDbType.Money).Value = price_vente1;
                    cmd.Parameters.Add("@price_vente2", SqlDbType.Money).Value = price_vente2;
                    cmd.Parameters.Add("@price_min", SqlDbType.Money).Value =		  price_min;
                    cmd.Parameters.Add("@Quantite_alert", SqlDbType.Float).Value = Quantite_alert;
                    cmd.Parameters.Add("@ihtiyaj", SqlDbType.Float).Value =					ihtiyaj;
                    cmd.ExecuteNonQuery();
				}
			}
		}
		public void InsertAchatProduitReventCaisse(
				string codeProduit,
				float quantite,
				decimal priceAchatHT,
				float tva,
				decimal priceAchatTTC,
				decimal totalHT,
				decimal totalTTC,
				string remarque,
				string idFacture,
				float quantiteBefore,
				float quantiteAfter,
				string typeFacture
		)
		{
			daoo = new DAL.DAL();

			using (daoo.sqlConnection)
			{
				using (SqlCommand command = new SqlCommand("Insert_AchatProduitReventCaisse", daoo.sqlConnection))
				{
					command.CommandType = CommandType.StoredProcedure;

					command.Parameters.AddWithValue("@CODE_PRODUIT", codeProduit);
					command.Parameters.AddWithValue("@QUANTITE", quantite);
					command.Parameters.AddWithValue("@PRICE_ACHAT_HT", priceAchatHT);
					command.Parameters.AddWithValue("@TVA", tva);
					command.Parameters.AddWithValue("@PRICE_ACHAT_TTC", priceAchatTTC);
					command.Parameters.AddWithValue("@TOTAL_HT", totalHT);
					command.Parameters.AddWithValue("@TOTAL_TTC", totalTTC);
					command.Parameters.AddWithValue("@REMARQUE", remarque);
					command.Parameters.AddWithValue("@ID_FACTURE", idFacture);
					command.Parameters.AddWithValue("@QUANTITE_BEFOR", quantiteBefore);
					command.Parameters.AddWithValue("@QUANTITE_AFTER", quantiteAfter);
					command.Parameters.AddWithValue("@TYPE_FACTURE", typeFacture);

					daoo.sqlConnection.Open();
					command.ExecuteNonQuery();
				}
			}
		}
		public void addReserveCode_barre(
				 string code_barre_produit
			   , string code_barre_reserve
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("addReserveCode_barre", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@code_barre_produit", SqlDbType.NVarChar).Value = code_barre_produit;
					cmd.Parameters.Add("@code_barre_reserve", SqlDbType.NVarChar).Value = code_barre_reserve;

					cmd.ExecuteNonQuery();
				}
			}
		}
		public void addReserveCode_barre_pack(
				 string CODE_BARRE_OFFICIAL
			   , string CODE_BARRE_RESERVER
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("insert_code_Barre_reserver_codeBarre_pack", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@CODE_BARRE_OFFICIAL", SqlDbType.NVarChar).Value = CODE_BARRE_OFFICIAL;
					cmd.Parameters.Add("@CODE_BARRE_RESERVER", SqlDbType.NVarChar).Value = CODE_BARRE_RESERVER;

					cmd.ExecuteNonQuery();
				}
			}
		}
		public void add_achat_produit(
			string codeProduit,
			float quantite,
			decimal priceAchatHT,
			float tva,
			decimal priceAchatTTC,
			decimal totalHT,
			decimal totalTTC,
			string remarque,
			string idFacture,
			float quantiteBefore,
			float quantiteAfter
		)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();
				using (SqlCommand cmd = new SqlCommand("add_prduit_revent", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@CODE_PRODUIT", SqlDbType.NVarChar, 50).Value = codeProduit;
					cmd.Parameters.Add("@QUANTITE", SqlDbType.Float).Value = quantite;
					cmd.Parameters.Add("@PRICE_ACHAT_HT", SqlDbType.Money).Value = priceAchatHT;
					cmd.Parameters.Add("@TVA", SqlDbType.Float).Value = tva;
					cmd.Parameters.Add("@PRICE_ACHAT_TTC", SqlDbType.Money).Value = priceAchatTTC;
					cmd.Parameters.Add("@TOTAL_HT", SqlDbType.Money).Value = totalHT;
					cmd.Parameters.Add("@TOTAL_TTC", SqlDbType.Money).Value = totalTTC;
					cmd.Parameters.Add("@REMARQUE", SqlDbType.NVarChar, -1).Value = remarque;
					cmd.Parameters.Add("@ID_FACTURE", SqlDbType.NVarChar, 50).Value = idFacture;
					cmd.Parameters.Add("@QUANTITE_BEFOR", SqlDbType.Float).Value = quantiteBefore;
					cmd.Parameters.Add("@QUANTITE_AFTER", SqlDbType.Float).Value = quantiteAfter;
					cmd.ExecuteNonQuery();
				}
			}
		}
		public void edit_qt_pack_achat(
			string codeProduit,
			float quantite 
		)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();
				using (SqlCommand cmd = new SqlCommand("edit_qt_pack_achat", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@CODE_PRODUIT", SqlDbType.NVarChar, 50).Value = codeProduit;
					cmd.Parameters.Add("@QUANTITE", SqlDbType.Float).Value = quantite; 
					cmd.ExecuteNonQuery();
				}
			}
		}
		public void edit_qt_pack_achat_whene_delet(
			string codeProduit,
			float quantite
		)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();
				using (SqlCommand cmd = new SqlCommand("edit_qt_pack_achat", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@CODE_PRODUIT", SqlDbType.NVarChar, 50).Value = codeProduit;
					cmd.Parameters.Add("@QUANTITE", SqlDbType.Float).Value = quantite;
					cmd.ExecuteNonQuery();
				}
			}
		}

	}
}
