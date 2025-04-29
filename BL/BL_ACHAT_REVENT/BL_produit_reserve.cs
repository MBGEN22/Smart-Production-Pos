using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Smart_Production_Pos.BL.BL_FICHIER;

namespace Smart_Production_Pos.BL.BL_ACHAT_REVENT
{
	public class BL_produit_reserve
	{
		public DataTable get_number_pack(string codeBarre)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@nmbre_product", SqlDbType.NVarChar);
			param[0].Value = codeBarre;
			Dt = DAL.SelectData("get_number_pack", param);
			DAL.Close();
			return Dt;
		}
		public DataTable get_tb_codeBarre_pack_reserver(string codeBarre)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@CODE_BARRE_OFFICIAL", SqlDbType.NVarChar);
			param[0].Value = codeBarre;
			Dt = DAL.SelectData("get_tb_codeBarre_pack_reserver", param);
			DAL.Close();
			return Dt;
		}
		DAL.DAL daoo;
		public void edit_pack_information(
			string packCodeBarre,
			string packDesignation, 
			decimal priceUnitair,
			byte[] photo,
			int? idFavoire
		)
		{
			daoo = new DAL.DAL();

			using (daoo.sqlConnection)
			{
				using (SqlCommand command = new SqlCommand("edit_pack_information", daoo.sqlConnection))
				{
					command.CommandType = CommandType.StoredProcedure;

					command.Parameters.AddWithValue("@pack_code_barre", packCodeBarre);
					command.Parameters.AddWithValue("@pack_designation", packDesignation); 
					command.Parameters.AddWithValue("@price_unitair", priceUnitair);
					command.Parameters.AddWithValue("@photo", photo);

					if (idFavoire.HasValue)
						command.Parameters.Add("@id_favoire", SqlDbType.Float).Value = idFavoire.Value;
					else
						command.Parameters.Add("@id_favoire", SqlDbType.Float).Value = DBNull.Value;

					daoo.sqlConnection.Open();
					command.ExecuteNonQuery();
				}
			}
		}
        public void edit_pack_info_without_pctr(
            string packCodeBarre,
            string packDesignation,
            decimal priceUnitair, 
            int? idFavoire
        )
        {
            daoo = new DAL.DAL();

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand("edit_pack_info_without_pctr", daoo.sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@pack_code_barre", packCodeBarre);
                    command.Parameters.AddWithValue("@pack_designation", packDesignation);
                    command.Parameters.AddWithValue("@price_unitair", priceUnitair); 

                    if (idFavoire.HasValue)
                        command.Parameters.Add("@id_favoire", SqlDbType.Float).Value = idFavoire.Value;
                    else
                        command.Parameters.Add("@id_favoire", SqlDbType.Float).Value = DBNull.Value;

                    daoo.sqlConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void edit_price_info(
            string packCodeBarre, 
            decimal priceUnitair 
        )
        {
            daoo = new DAL.DAL();

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand("EDIT_PRICE_PACK", daoo.sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CODE_BARE_PACK", packCodeBarre); 
                    command.Parameters.AddWithValue("@PRICE", priceUnitair); 
                    daoo.sqlConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void change_information_produit_revent(
				string CodeBarre,
				string designation,
				string reference,
				int? id_categories,
				int? id_stocke,
				int? id_marque,
				int? id_unite,
				int? id_taille,
				int? id_color,
				int? id_favoire,
				DateTime? date_expiration,
				decimal price_vente1,
				decimal price_vente2,
				decimal price_min,
				Byte[] Photo 
             , decimal price_achat_HT
             , decimal price_achat_TTC
             , float TVA
             , float Quantite_alert
             , float ihtiyadj
        )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("change_information_produit_revent", daoo.sqlConnection))
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
					 
					cmd.Parameters.Add("@price_vente1", SqlDbType.Money).Value = price_vente1;
					cmd.Parameters.Add("@price_vente2", SqlDbType.Money).Value = price_vente2;
					cmd.Parameters.Add("@price_min", SqlDbType.Money).Value = price_min; 
					cmd.Parameters.Add("@Photo", SqlDbType.Image).Value = Photo;
                    cmd.Parameters.Add("@price_achat_HT", SqlDbType.Money).Value = price_achat_HT;
                    cmd.Parameters.Add("@price_achat_TTC", SqlDbType.Money).Value = price_achat_TTC;
                    cmd.Parameters.Add("@TVA", SqlDbType.Float).Value = TVA;
                    cmd.Parameters.Add("@Quantite_alert", SqlDbType.Float).Value = Quantite_alert;
                    cmd.Parameters.Add("@ihtiyaj", SqlDbType.Float).Value = ihtiyadj;
					 
                    cmd.ExecuteNonQuery();
				}
			}
		}
        public void change_information_produit_revent_no_img(
                string CodeBarre,
                string designation,
                string reference,
                int? id_categories,
                int? id_stocke,
                int? id_marque,
                int? id_unite,
                int? id_taille,
                int? id_color,
                int? id_favoire,
                DateTime? date_expiration,
                decimal price_vente1,
                decimal price_vente2,
                decimal price_min
             , decimal price_achat_HT
             , decimal price_achat_TTC
             , float TVA
             , float Quantite_alert
             , float ihtiyadj
        )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {

                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("change_information_produit_revent_no_img", daoo.sqlConnection))
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

                    cmd.Parameters.Add("@price_vente1", SqlDbType.Money).Value = price_vente1;
                    cmd.Parameters.Add("@price_vente2", SqlDbType.Money).Value = price_vente2;
                    cmd.Parameters.Add("@price_min", SqlDbType.Money).Value = price_min; 
                    cmd.Parameters.Add("@price_achat_HT", SqlDbType.Money).Value = price_achat_HT;
                    cmd.Parameters.Add("@price_achat_TTC", SqlDbType.Money).Value = price_achat_TTC;
                    cmd.Parameters.Add("@TVA", SqlDbType.Float).Value = TVA;
                    cmd.Parameters.Add("@Quantite_alert", SqlDbType.Float).Value = Quantite_alert;
                    cmd.Parameters.Add("@ihtiyaj", SqlDbType.Float).Value = ihtiyadj;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
