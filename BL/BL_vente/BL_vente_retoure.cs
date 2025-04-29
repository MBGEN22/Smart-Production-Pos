using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_vente
{
	public class BL_vente_retoure
	{
		DAL.DAL daoo;
		public void edit_vente_QT(
			  int ID,
			  float Quantite
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();
				using (SqlCommand cmd = new SqlCommand("edit_vente_QT", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
					cmd.Parameters.Add("@Quantite", SqlDbType.Float).Value = Quantite;
					cmd.ExecuteNonQuery();
				}
			}
		}
		public void delete_vente_QT(
			  int ID 
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();
				using (SqlCommand cmd = new SqlCommand("delete_vente_QT", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID; 
					cmd.ExecuteNonQuery();
				}
			}
		}

		public string sum_vente(string ID)
		{ 
			string newID = "0";

			try
			{
				using (SqlConnection connection = daoo.sqlConnection)
				{
					string query = "SELECT SUM([PRIX]) FROM [dbo].[PRIX_TOTAL] WHERE ID_FACTURE = @ID"; // Assuming you're summing a column named 'PRIX'
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = ID;
						connection.Open();
						var result = command.ExecuteScalar();
						if (result != DBNull.Value)
						{
							newID = result.ToString();
						}
					}
				}
			}
			catch (Exception ex)
			{
				// Handle the exception (logging, rethrowing, etc.)
				Console.WriteLine(ex.Message);
			}

			return newID;
		}

        public DataTable get_TB_routeur()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("get_TB_routeur_produit", null);
            DAL.Close();
            return Dt;
        }
        public DataTable get_list_routeure_By_date(DateTime codeBarre)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Date", SqlDbType.Date);
            param[0].Value = codeBarre; 
            Dt = DAL.SelectData("[get_TB_routeur_produit_by_date]", param);
            DAL.Close();
            return Dt;
        }
    }
}
