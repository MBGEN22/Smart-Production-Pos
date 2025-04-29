using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_FICHIER
{
	public class BL_Client
	{
		//////////////////////// GetTable Client
		public DataTable Get_clien_Table()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_client_tb", null);
			DAL.Close();
			return Dt;
		}

		#region Search 
		public DataTable search_client(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_search", SqlDbType.NVarChar, 50);
			param[0].Value = id;
			Dt = DAL.SelectData("search_client", param);
			DAL.Close();
			return Dt;
		}
		#endregion
		////////////////*************   ADD Client   **************///////////////
		DAL.DAL daoo;
		public void Add_Funct(
			string NAME,
			string PRENAME,
			string ADRESSE,
			string PHONE,
			string FAX,
			string EMAIL,
			float SOLD_TOTAL,
			float SOLD_PAYEE,
			float SOLD_NON_PAYES,
			float soldVerse, 
			float Max_credit,
			string NIF,
			string RC,
			string Nic,
			string article,
			string original_name_prename
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{

				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("add_Client", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = NAME;
					cmd.Parameters.Add("@PRENAME", SqlDbType.NVarChar).Value = PRENAME;
					cmd.Parameters.Add("@ADRESSE", SqlDbType.NVarChar).Value = ADRESSE;
					cmd.Parameters.Add("@PHONE", SqlDbType.NVarChar).Value = PHONE;
					cmd.Parameters.Add("@FAX", SqlDbType.NVarChar).Value = FAX;
					cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = EMAIL;
					cmd.Parameters.Add("@SOLD_TOTAL", SqlDbType.Float).Value = SOLD_TOTAL;
					cmd.Parameters.Add("@SOLD_PAYEE", SqlDbType.Float).Value = SOLD_PAYEE;
					cmd.Parameters.Add("@SOLD_NON_PAYES", SqlDbType.Float).Value = SOLD_NON_PAYES;
					cmd.Parameters.Add("@sold_verse", SqlDbType.Float).Value = soldVerse; 
					cmd.Parameters.Add("@Max_credit", SqlDbType.Float).Value = Max_credit;
					cmd.Parameters.Add("@NIF", SqlDbType.NVarChar).Value = NIF;
					cmd.Parameters.Add("@Rc", SqlDbType.NVarChar).Value = RC;
					cmd.Parameters.Add("@Nic", SqlDbType.NVarChar).Value = Nic;
					cmd.Parameters.Add("@article", SqlDbType.NVarChar).Value = article;
					cmd.Parameters.Add("@original_name_prename", SqlDbType.NVarChar).Value = original_name_prename;


					cmd.ExecuteNonQuery();
				}
			}
		}


		public void edit_client(
				int ID
			   , string NAME
			   , string PRENAME
			   , string PHONE
			   , string FAX
			   , string EMAIL
			   , float SOLD_TOTAL
			   , float SOLD_PAYE
			   , float SOLD_NON_PAYE
			   , string ADRESSE
			   , float soldVerse 
				, float Max_credit
				, string NIF
				, string RC
				, string Nic
				, string Article
				, string original_name_prename
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("edit_client", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
					cmd.Parameters.Add("@NAME", SqlDbType.NVarChar).Value = NAME;
					cmd.Parameters.Add("@PRENAME", SqlDbType.NVarChar).Value = PRENAME;
					cmd.Parameters.Add("@PHONE", SqlDbType.NVarChar).Value = PHONE;
					cmd.Parameters.Add("@FAX", SqlDbType.NVarChar).Value = FAX;
					cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = EMAIL;
					cmd.Parameters.Add("@SOLD_TOTAL", SqlDbType.Float).Value = SOLD_TOTAL;
					cmd.Parameters.Add("@SOLD_PAYEE", SqlDbType.Float).Value = SOLD_PAYE;
					cmd.Parameters.Add("@SOLD_NON_PAYES", SqlDbType.Float).Value = SOLD_NON_PAYE;
					cmd.Parameters.Add("@ADRESSE", SqlDbType.NVarChar).Value = ADRESSE;
					cmd.Parameters.Add("@sold_verse", SqlDbType.Float).Value = soldVerse; 
					cmd.Parameters.Add("@Max_credit", SqlDbType.Float).Value = Max_credit;
					cmd.Parameters.Add("@NIF", SqlDbType.NVarChar).Value = NIF;
					cmd.Parameters.Add("@Rc", SqlDbType.NVarChar).Value = RC;
					cmd.Parameters.Add("@Nic", SqlDbType.NVarChar).Value = Nic;
					cmd.Parameters.Add("@Article", SqlDbType.NVarChar).Value = Article;
					cmd.Parameters.Add("@original_name_prename", SqlDbType.NVarChar).Value = original_name_prename;

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

				using (SqlCommand cmd = new SqlCommand("delete_client", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
