using System;
using System.Data;
using System.Data.SqlClient;
using Smart_Production_Pos.BL.BL_FICHIER;

namespace Smart_Production_Pos.BL.BL_ACHAT_REVENT
{
    public class BL_PRODUIT
	{
        public decimal inventaire_Total()
        {
            daoo = new DAL.DAL();
            decimal newID = 0;
            string query = "select sum(price_vente1*Quantite_rest) from TB_Produit_revente";

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand(query, daoo.sqlConnection))
                {
                    try
                    {
                        daoo.sqlConnection.Open();
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            newID = decimal.Parse(result.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log it)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

            return newID;
        }
        public decimal inventaire_TotalQT_TTL()
        {
            daoo = new DAL.DAL();
            decimal newID = 0;
            string query = "select sum(price_vente1*Quantite_TOTAL) from TB_Produit_revente";

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand(query, daoo.sqlConnection))
                {
                    try
                    {
                        daoo.sqlConnection.Open();
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            newID = decimal.Parse(result.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log it)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

            return newID;
        }
        public decimal inventaire_TotalQT_VENTE()
        {
            daoo = new DAL.DAL();
            decimal newID = 0;
            string query = "select sum(price_vente1*Quantite_vente) from TB_Produit_revente";

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand(query, daoo.sqlConnection))
                {
                    try
                    {
                        daoo.sqlConnection.Open();
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            newID = decimal.Parse(result.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log it)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

            return newID;
        }
        public decimal Count_Ttl_produit()
        {
            daoo = new DAL.DAL();
            decimal newID = 0;
            string query = "select count (CodeBarre) from TB_Produit_revente";

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand(query, daoo.sqlConnection))
                {
                    try
                    {
                        daoo.sqlConnection.Open();
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            newID = decimal.Parse(result.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log it)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

            return newID;
        }
        public decimal Count_Ttl_produit_Rest()
        {
            daoo = new DAL.DAL();
            decimal newID = 0;
            string query = "select Sum (Quantite_rest) from TB_Produit_revente";

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand(query, daoo.sqlConnection))
                {
                    try
                    {
                        daoo.sqlConnection.Open();
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            newID = decimal.Parse(result.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log it)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

            return newID;
        }
        public decimal Count_Ttl_produit_vendue()
        {
            daoo = new DAL.DAL();
            decimal newID = 0;
            string query = "select Sum (Quantite_vente) from TB_Produit_revente";

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand(query, daoo.sqlConnection))
                {
                    try
                    {
                        daoo.sqlConnection.Open();
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            newID = decimal.Parse(result.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log it)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

            return newID;
        }
        public decimal Count_Ttl_produit_dechet()
        {
            daoo = new DAL.DAL();
            decimal newID = 0;
            string query = "select Sum (Quantite_dechet) from TB_Produit_revente";

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand(query, daoo.sqlConnection))
                {
                    try
                    {
                        daoo.sqlConnection.Open();
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            newID = decimal.Parse(result.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log it)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

            return newID;
        }

        public decimal inventaire_Total_Achats_HT_Rest_Qt()
        {
            daoo = new DAL.DAL();
            decimal newID = 0;
            string query = "select sum(price_achat_HT*Quantite_rest) from TB_Produit_revente";

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand(query, daoo.sqlConnection))
                {
                    try
                    {
                        daoo.sqlConnection.Open();
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            newID = decimal.Parse(result.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log it)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

            return newID;
        }
        public decimal inventaire_Total_Achats_TTC_Rest_Qt()
        {
            daoo = new DAL.DAL();
            decimal newID = 0;
            string query = "select sum(price_achat_TTC*Quantite_rest) from TB_Produit_revente";

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand(query, daoo.sqlConnection))
                {
                    try
                    {
                        daoo.sqlConnection.Open();
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            newID = decimal.Parse(result.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log it)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

            return newID;
        }
        
        public decimal inventaire_TotalQT_TTL_Achats_HT()
        {
            daoo = new DAL.DAL();
            decimal newID = 0;
            string query = "select sum(price_achat_HT*Quantite_TOTAL) from TB_Produit_revente";

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand(query, daoo.sqlConnection))
                {
                    try
                    {
                        daoo.sqlConnection.Open();
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            newID = decimal.Parse(result.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log it)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

            return newID;
        }
        public decimal inventaire_TotalQT_TTL_Achats_TTC()
        {
            daoo = new DAL.DAL();
            decimal newID = 0;
            string query = "select sum(price_achat_TTC*Quantite_TOTAL) from TB_Produit_revente";

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand(query, daoo.sqlConnection))
                {
                    try
                    {
                        daoo.sqlConnection.Open();
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            newID = decimal.Parse(result.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log it)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

            return newID;
        }

        public decimal inventaire_TotalQT_VENTE_Achats_HT()
        {
            daoo = new DAL.DAL();
            decimal newID = 0;
            string query = "select sum(price_achat_HT*Quantite_vente) from TB_Produit_revente";

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand(query, daoo.sqlConnection))
                {
                    try
                    {
                        daoo.sqlConnection.Open();
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            newID = decimal.Parse(result.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log it)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

            return newID;
        }
        public decimal inventaire_TotalQT_VENTE_Achats_TTC()
        {
            daoo = new DAL.DAL();
            decimal newID = 0;
            string query = "select sum(price_achat_TTC*Quantite_vente) from TB_Produit_revente";

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand(query, daoo.sqlConnection))
                {
                    try
                    {
                        daoo.sqlConnection.Open();
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            newID = decimal.Parse(result.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log it)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

            return newID;
        }



        public DataTable get_stock_produit_revenet()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_stock_produit_revenet", null);
			DAL.Close();
			return Dt;
		}
        #region Search detaille
        public DataTable Search_stock_negative()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Search_stock_negative", null);
            DAL.Close();
            return Dt;
        }

        public DataTable Search_stock_Null()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Search_stock_Null", null);
            DAL.Close();
            return Dt;
        }
        public DataTable Search_stock_Alert()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Search_stock_Alert", null);
            DAL.Close();
            return Dt;
        }

        public DataTable Search_stock_exagere()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Search_stock_exagere", null);
            DAL.Close();
            return Dt;
        }

        public DataTable Search_stock_Controle_prix_Détail()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Search_stock_Controle_prix_Détail", null);
            DAL.Close();
            return Dt;
        }

        public DataTable Search_stock_Controle_prix_Gros()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Search_stock_Controle_prix_Gros", null);
            DAL.Close();
            return Dt;
        }

        public DataTable Search_stock_Controle_prix_min()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Search_stock_Controle_prix_min", null);
            DAL.Close();
            return Dt;
        }
        #endregion

        public DataTable insert_stock_for_facturation()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("insert_stock_for_facturation", null);
            DAL.Close();
            return Dt;
        }
        public DataTable GET_INFORATION_FOR_AFFICHER_PRODUIT_REVENT(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@CODE_BARRE", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("GET_INFORATION_FOR_AFFICHER_PRODUIT_REVENT", param);
			DAL.Close();
			return Dt;
		}
        public DataTable check_produit_if_exist(string CodeBarre)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CodeBarre", SqlDbType.NVarChar);
            param[0].Value = CodeBarre;
            Dt = DAL.SelectData("check_produit_if_exist", param);
            DAL.Close();
            return Dt;
        }

        public DataTable get_list_historique_achat_produit(string CodeBarre)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_Produit", SqlDbType.NVarChar);
            param[0].Value = CodeBarre;
            Dt = DAL.SelectData("get_list_historique_achat_produit", param);
            DAL.Close();
            return Dt;
        }
        public DataTable get_list_historique_vente_produit(string CodeBarre)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_Produit", SqlDbType.NVarChar);
            param[0].Value = CodeBarre;
            Dt = DAL.SelectData("get_list_historique_vente_produit", param);
            DAL.Close();
            return Dt;
        }

        public DataTable get_info_Pack_edit(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@CodeBarre", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("get_info_Pack_edit", param);
			DAL.Close();
			return Dt;
		}
		public DataTable get_stock_produit_revenet_for_edit(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@CodeBarre", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("get_stock_produit_revenet_for_edit", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_code_barre_produit_revent(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@CODE_BARRE", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("search_code_barre_produit_revent", param);
			DAL.Close();
			return Dt;
		}
        public DataTable search_produit_revente_repture_stock(string id)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar);
            param[0].Value = id;
            Dt = DAL.SelectData("search_produit_revente_repture_stock", param);
            DAL.Close();
            return Dt;
        }
        public DataTable search_produit_revente(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("search_produit_revente", param);
			DAL.Close();
			return Dt;
		}
        public DataTable search_produit_revente_on_fctr(string id)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar);
            param[0].Value = id;
            Dt = DAL.SelectData("search_produit_revente_on_fctr", param);
            DAL.Close();
            return Dt;
        }
        public DataTable search_pack_prevent_by_code_Barre_U(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@CodeBarre", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("search_pack_prevent_by_code_Barre_U", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_pack_prevent_by_code_Barre_Pack(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@CodeBarre", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("search_pack_prevent_by_code_Barre_Pack", param);
			DAL.Close();
			return Dt;
		}
        public DataTable search_pack_produit_revent(string id)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar);
            param[0].Value = id;
            Dt = DAL.SelectData("search_pack_produit_revent", param);
            DAL.Close();
            return Dt;
        }
        public DataTable get_stock_produit_revenet_caisse()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_stock_produit_revenet_stock", null);
			DAL.Close();
			return Dt;
		}
        public DataTable get_TB_historique_dechet()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("get_TB_historique_dechet", null);
            DAL.Close();
            return Dt;
        }
        public DataTable get_stock_produit_revenet_caisse_Prix2()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_stock_produit_revenet_stock_1", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_stock_produit_revenet_caisse_prix_Min()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_stock_produit_revenet_stock_2", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_stock_pack()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_stock_pack", null);
			DAL.Close();
			return Dt;
		}

		DAL.DAL daoo;
		public void Add_Funct( 
			   string CodeBarre
			 , string designation
			 , string reference
			 , int? id_categories
			 , int? id_stocke
			 , int? id_marque
			 , int? id_unite
			 , int? id_taille
			 , int? id_color
			 , int? id_favoire
			 , DateTime? date_expiration
			 , decimal price_achat_HT
			 , decimal price_achat_TTC
			 , float TVA
			 , float Quantite_TOTAL 
			 , decimal price_vente1
			 , decimal price_vente2
			 , decimal price_min
			 , string vente_apres_expiration
			 , string stocke_negatif
			 , float Quantite_vente
			 , float Quantite_rest
			 , float Quantite_dechet
			 , Byte[] Photo
			 , float? QT_DANS_PACK
		   	, float Quantite_alert
               , float ihtiyadj
            )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("add_prduit_revent", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure; 
					cmd.Parameters.Add("@CodeBarre", SqlDbType.NVarChar).Value = CodeBarre;
					cmd.Parameters.Add("@designation", SqlDbType.NVarChar).Value = designation;
					cmd.Parameters.Add("@reference", SqlDbType.NVarChar).Value = reference;
                    if (id_categories.HasValue)
                        cmd.Parameters.Add("@id_categories", SqlDbType.Int).Value = id_categories.Value;
                    else
                        cmd.Parameters.Add("@id_categories", SqlDbType.Int).Value = DBNull.Value;

                    if (id_stocke.HasValue)
                        cmd.Parameters.Add("@id_stocke", SqlDbType.Int).Value = id_stocke.Value;
                    else
                        cmd.Parameters.Add("@id_stocke", SqlDbType.Int).Value = DBNull.Value;

                    if (id_marque.HasValue)
                        cmd.Parameters.Add("@id_marque", SqlDbType.Int).Value = id_marque.Value;
                    else
                        cmd.Parameters.Add("@id_marque", SqlDbType.Int).Value = DBNull.Value;

                    if (id_unite.HasValue)
                        cmd.Parameters.Add("@id_unite", SqlDbType.Int).Value = id_unite.Value;
                    else
                        cmd.Parameters.Add("@id_unite", SqlDbType.Int).Value = DBNull.Value; 
					  
					if (id_taille.HasValue)
						cmd.Parameters.Add("@id_taille", SqlDbType.Int).Value = id_taille.Value;
					else
						cmd.Parameters.Add("@id_taille", SqlDbType.Int).Value = DBNull.Value;

					if (id_color.HasValue)
						cmd.Parameters.Add("@id_color", SqlDbType.Int).Value = id_color.Value;
					else
						cmd.Parameters.Add("@id_color", SqlDbType.Int).Value = DBNull.Value;

					if (id_favoire.HasValue)
						cmd.Parameters.Add("@id_favoire", SqlDbType.Int).Value = id_favoire.Value;
					else
						cmd.Parameters.Add("@id_favoire", SqlDbType.Int).Value = DBNull.Value;


					if (date_expiration.HasValue)
						cmd.Parameters.Add("@date_expiration", SqlDbType.Date).Value = date_expiration.Value;
					else
						cmd.Parameters.Add("@date_expiration", SqlDbType.Date).Value = DBNull.Value;
					 
					cmd.Parameters.Add("@price_achat_HT", SqlDbType.Money).Value = price_achat_HT;
					cmd.Parameters.Add("@price_achat_TTC", SqlDbType.Money).Value = price_achat_TTC;
					cmd.Parameters.Add("@TVA", SqlDbType.Float).Value = TVA;
					cmd.Parameters.Add("@Quantite_TOTAL", SqlDbType.Float).Value = Quantite_TOTAL; 
					cmd.Parameters.Add("@price_vente1", SqlDbType.Money).Value = price_vente1;
					cmd.Parameters.Add("@price_vente2", SqlDbType.Money).Value = price_vente2;
					cmd.Parameters.Add("@price_min", SqlDbType.Money).Value = price_min;
					cmd.Parameters.Add("@vente_apres_expiration", SqlDbType.NVarChar).Value = vente_apres_expiration;
					cmd.Parameters.Add("@stocke_negatif", SqlDbType.NVarChar).Value = stocke_negatif;
					cmd.Parameters.Add("@Quantite_vente", SqlDbType.Float).Value = Quantite_vente;  
					cmd.Parameters.Add("@Quantite_rest", SqlDbType.Float).Value = Quantite_rest;
					cmd.Parameters.Add("@Quantite_dechet", SqlDbType.Float).Value = Quantite_dechet;
					cmd.Parameters.Add("@Photo", SqlDbType.Image).Value = Photo; 
					if (QT_DANS_PACK.HasValue)
						cmd.Parameters.Add("@QT_DANS_PACK", SqlDbType.Float).Value = QT_DANS_PACK.Value;
					else
						cmd.Parameters.Add("@QT_DANS_PACK", SqlDbType.Float).Value = DBNull.Value;
                    cmd.Parameters.Add("@Quantite_alert", SqlDbType.Float).Value = Quantite_alert;
                    cmd.Parameters.Add("@ihtiyaj", SqlDbType.Float).Value = ihtiyadj;
                    cmd.ExecuteNonQuery();
				}
			}
		}
        public void add_picture(
               string CodeBarre 
             , Byte[] Photo 
            )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {

                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("add_picture", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@CodeBarre", SqlDbType.NVarChar).Value = CodeBarre; 
                    cmd.Parameters.Add("@Photo", SqlDbType.Image).Value = Photo; 
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void InsertPackProduitRevent(
			string packCodeBarre,
			string packDesignation,
			string codeBarreProduit,
			float quantite,
			decimal priceUnitair,
			byte[] photo,
			int? idFavoire,
            byte[] photo_code_barre

        )
		{
			daoo = new DAL.DAL();

			using (daoo.sqlConnection)
			{
				using (SqlCommand command = new SqlCommand("InsertPackProduitRevent", daoo.sqlConnection))
				{
					command.CommandType = CommandType.StoredProcedure;

					command.Parameters.AddWithValue("@pack_code_barre", packCodeBarre);
					command.Parameters.AddWithValue("@pack_designation", packDesignation);
					command.Parameters.AddWithValue("@code_barre_produit", codeBarreProduit);
					command.Parameters.AddWithValue("@quantite", quantite);
					command.Parameters.AddWithValue("@price_unitair", priceUnitair);
					command.Parameters.AddWithValue("@photo", photo); 
                    if (idFavoire.HasValue)
						command.Parameters.Add("@id_favoire", SqlDbType.Float).Value = idFavoire.Value;
					else
						command.Parameters.Add("@id_favoire", SqlDbType.Float).Value = DBNull.Value;
                    command.Parameters.AddWithValue("@photo_code_barre", photo_code_barre);

                    daoo.sqlConnection.Open();
					command.ExecuteNonQuery();
				}
			}
		}
        public void ADD_QUANTITE_DECHET_HISTORIQUE( 
            DateTime DATE,
            TimeSpan TIME,
            string CODE_BARRE,
            float QUANTITE,
            string LACAUSE,
            int ID_USER
        )
        {
            daoo = new DAL.DAL(); 
            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand("ADD_QUANTITE_DECHET_HISTORIQUE", daoo.sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure; 
                    command.Parameters.AddWithValue("@DATE", DATE);
                    command.Parameters.AddWithValue("@TIME", TIME);
                    command.Parameters.AddWithValue("@CODE_BARRE", CODE_BARRE);
                    command.Parameters.AddWithValue("@QUANTITE", QUANTITE);
                    command.Parameters.AddWithValue("@LACAUSE", LACAUSE);
                    command.Parameters.AddWithValue("@ID_USER", ID_USER); 
                    daoo.sqlConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void update_QT_dans_pack(
            string codBarre,
            float  QT 
        )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand("update_QT_dans_pack", daoo.sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@codBarre", codBarre);
                    command.Parameters.AddWithValue("@QT", QT); 
                    daoo.sqlConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void ADD_QUANTITE_DECHET(
            string CODE_BARRE,
            float QUANTITE 
        )
        {
            daoo = new DAL.DAL();

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand("ADD_QUANTITE_DECHET", daoo.sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CODE_BARRE", CODE_BARRE);
                    command.Parameters.AddWithValue("@QUANTITE", QUANTITE); 
                    daoo.sqlConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void ADD_QT_REST(
            string CODE_BARRE,
            float QUANTITE
        )
        {
            daoo = new DAL.DAL();

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand("ADD_QT_REST", daoo.sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CODEBARRE", CODE_BARRE);
                    command.Parameters.AddWithValue("@QUANTITE", QUANTITE);
                    daoo.sqlConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void update_code_baree_pack(
            string CODE_BARRE,
            byte[] photo_code_barre
        )
        {
            daoo = new DAL.DAL();

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand("update_code_baree_pack", daoo.sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@code_barre", CODE_BARRE);
                    command.Parameters.AddWithValue("@image_code", photo_code_barre);
                    daoo.sqlConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
