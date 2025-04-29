using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Smart_Production_Pos.BL.Bl_commande
{
	public class BL_FACTURE_VIERGE
	{
		public DataTable get_produit_of_principe(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID", SqlDbType.NVarChar, 50);
			param[0].Value = id;
			Dt = DAL.SelectData("select_produit_of_principe_with_id", param);
			DAL.Close();
			return Dt;
		}
		public DataTable GET_INFORMATION_FACTURE_VIERGE(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_FACTURE", SqlDbType.NVarChar, 50);
			param[0].Value = id;
			Dt = DAL.SelectData("GET_INFORMATION_FACTURE_VIERGE", param);
			DAL.Close();
			return Dt;
		}
		public DataTable get_produit_of_principe_globale()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("select_principale_facture", null);
			DAL.Close();
			return Dt;
		}
		public DataTable search_principale_facture(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_Search", SqlDbType.NVarChar);
			param[0].Value = id;
			Dt = DAL.SelectData("search_principale_facture", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_TB_commande_bY_date(DateTime id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_Search", SqlDbType.Date);
			param[0].Value = id;
			Dt = DAL.SelectData("search_principale_facture_by_date", param);
			DAL.Close();
			return Dt;
		}
		public DataTable search_principale_facture_by_client(int id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_Search", SqlDbType.Int);
			param[0].Value = id;
			Dt = DAL.SelectData("search_principale_facture_by_client", param);
			DAL.Close();
			return Dt;
		} 
		public string get_facture_number()
		{

			DAL.DAL DAaL = new DAL.DAL();

			string newID = "";

			using (DAaL.sqlConnection)
			{
				string query = "select concat('FC', format(convert(int, stuff(max(NMR_FACTURE), 1, 3, ''))+1 , '0000'))  from TB_PRINCIPE_fACTURE";
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
		public decimal getSum(string nmr_fctr)
		{
			DAL.DAL DAaL = new DAL.DAL();
			decimal sum = 0;

			using (DAaL.sqlConnection)
			{
				string query = "SELECT SUM([TOTAL]) FROM [dbo].[TB_PRODUIT_OF_FCTR_VIERGE] where [ID_FACTURE] = @ID ";
				using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
				{
					command.Parameters.Add("@ID", SqlDbType.NVarChar).Value = nmr_fctr; // Convert nmr_fctr to Int32

					DAaL.sqlConnection.Open();
					var result = command.ExecuteScalar();
					if (result != DBNull.Value && result != null) // Check for null before conversion
					{
						sum = Convert.ToDecimal(result); // Convert to Decimal instead of Int32
					}
				}
			}
			return sum;
		}

		public void delete_ouverier_Record(int id)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.Open();

				string deleteCommandText = "DELETE FROM [dbo].[TB_PRODUIT_OF_FCTR_VIERGE] where ID = @ID";

				using (SqlCommand command = new SqlCommand(deleteCommandText, daoo.sqlConnection))
				{
					command.Parameters.Add("@ID", SqlDbType.Int).Value = id;

					try
					{
						int rowsAffected = command.ExecuteNonQuery();
						if (rowsAffected > 0)
						{
							MessageBox.Show("تم الحذف بنجاح");
						}
						else
						{
							MessageBox.Show("لايوجد بيانات لحذفها");
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("خطأ: " + ex.Message);
					}
				}
			}
		}

		//add_produit_of_principe
		DAL.DAL daoo;
		public void add_product(
			string NAME,
			decimal PRIX_UNITE,
			int QUANTITE,
			decimal TOTAL,
			string ID_FACTURE
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("add_produit_on_principe_facture", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = NAME;
					cmd.Parameters.Add("@PRIX_UNITE", SqlDbType.Money).Value = PRIX_UNITE;
					cmd.Parameters.Add("@QUANTITE", SqlDbType.Int).Value = QUANTITE;
					cmd.Parameters.Add("@TOTAL", SqlDbType.Money).Value = TOTAL;
					cmd.Parameters.Add("@ID_FACTURE", SqlDbType.NVarChar).Value = ID_FACTURE;

					cmd.ExecuteNonQuery();
				}
			}
		}
		 
		public void delete_prin_fctr(
			string id_fctr
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("delete_prin_fctr", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@id_fctr", SqlDbType.NVarChar).Value = id_fctr; 

					cmd.ExecuteNonQuery();
				}
			}
		}
		public void add_vierge_fctr(
		   string NMR_FACTURE,
		   int ID_CLIENT,
		   DateTime DATE,
		   float TOTAL_HT,
		   float TVA,
		   float TMBRE,
		   float TOTAL_TTC,
		   float VERSE,
		   float REST,
		   int ID_USER,
		   string prix_on_arabe
		   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("create_facture_principale", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@NMR_FACTURE", SqlDbType.NVarChar).Value = NMR_FACTURE;
					cmd.Parameters.Add("@ID_CLIENT", SqlDbType.Float).Value = ID_CLIENT;
					cmd.Parameters.Add("@DATE", SqlDbType.Date).Value = DATE;
					cmd.Parameters.Add("@TOTAL_HT", SqlDbType.Float).Value = TOTAL_HT;
					cmd.Parameters.Add("@TVA", SqlDbType.Float).Value = TVA;
					cmd.Parameters.Add("@TMBRE", SqlDbType.Float).Value = TMBRE;
					cmd.Parameters.Add("@TOTAL_TTC", SqlDbType.Float).Value = TOTAL_TTC;
					cmd.Parameters.Add("@VERSE", SqlDbType.Float).Value = VERSE;
					cmd.Parameters.Add("@REST", SqlDbType.Float).Value = REST;
					cmd.Parameters.Add("@ID_USER", SqlDbType.Int).Value = ID_USER;
					cmd.Parameters.Add("@prix_on_arabe", SqlDbType.NVarChar).Value = prix_on_arabe;

					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
