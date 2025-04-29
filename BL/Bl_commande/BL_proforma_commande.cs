using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.Bl_commande
{
	public class BL_proforma_commande
	{
		public DataTable get_table_commande_proforama(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@type_commande", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("get_commande_proforma", param);
			DAL.Close();
			return Dt;
		}
		public DataTable get_commande_proforma_and_date(string id,DateTime date)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[2];
			param[0] = new SqlParameter("@type_commande", SqlDbType.NVarChar);
			param[0].Value = id;
			param[1] = new SqlParameter("@Date", SqlDbType.NVarChar);
			param[1].Value = date;
			Dt = DAL.SelectData("get_commande_proforma", param);
			DAL.Close();
			return Dt;
		}

		public DataTable get_table_commande_proforama_for_tmbre(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@id_cmd", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("get_commande_proforma_for_tmbre", param);
			DAL.Close();
			return Dt;
		}
		#region Add_Commande
		DAL.DAL daoo;

		public void insert_new_commande(
				 string ID
			   , DateTime DATE
			   , string NOM_COMMANDE
			   , int ID_CLIENT
			   , string TYPE_COMMANDE
			   , decimal COUT_TOTAL
			   , decimal VERSEMENT
			   , int QTE
			   , string REMARQUE
			   , decimal PRICE_TOTAL_HT
			   , decimal PRICE_TOTAL_TTC
			   , float TVA
			   , DateTime? deadline_Date
			   , string etas
			   , int id_user
			   , double? TMBER
			   , string PRICE_ARAB


			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("edit_comd", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID;
					cmd.Parameters.Add("@DATE", SqlDbType.Date).Value = DATE;
					cmd.Parameters.Add("@NOM_COMMANDE", SqlDbType.NVarChar).Value = NOM_COMMANDE;
					cmd.Parameters.Add("@ID_CLIENT", SqlDbType.Int).Value = ID_CLIENT;
					cmd.Parameters.Add("@TYPE_COMMANDE", SqlDbType.NVarChar).Value = TYPE_COMMANDE;
					cmd.Parameters.Add("@COUT_TOTAL", SqlDbType.Money).Value = COUT_TOTAL;
					cmd.Parameters.Add("@VERSEMENT", SqlDbType.Money).Value = VERSEMENT;
					cmd.Parameters.Add("@REMARQUE", SqlDbType.NVarChar).Value = REMARQUE;
					cmd.Parameters.Add("@QTE", SqlDbType.Int).Value = QTE;
					cmd.Parameters.Add("@PRICE_TOTAL_HT", SqlDbType.Money).Value = PRICE_TOTAL_HT;
					cmd.Parameters.Add("@PRICE_TOTAL_TTC", SqlDbType.Money).Value = PRICE_TOTAL_TTC;
					cmd.Parameters.Add("@TVA", SqlDbType.Float).Value = TVA;
					if (deadline_Date.HasValue)
						cmd.Parameters.Add("@deadline_Date", SqlDbType.Date).Value = deadline_Date.Value;
					else
						cmd.Parameters.Add("@deadline_Date", SqlDbType.Date).Value = DBNull.Value;

					cmd.Parameters.Add("@etas", SqlDbType.NVarChar).Value = etas;
					cmd.Parameters.Add("@id_user", SqlDbType.Int).Value = id_user;
					if (TMBER.HasValue)
						cmd.Parameters.Add("@TMBER", SqlDbType.Float).Value = TMBER.Value;
					else
						cmd.Parameters.Add("@TMBER", SqlDbType.Float).Value = DBNull.Value;
					cmd.Parameters.Add("@PRICE_ARAB", SqlDbType.NVarChar).Value = PRICE_ARAB;

					cmd.ExecuteNonQuery();
				}
			}
		}

		#endregion
	}
}
