using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.Bl_commande
{
	public class BL_MATIER
	{
		public DataTable get_list_achat_by_id(string id)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@id_produit", SqlDbType.NVarChar, 50);
			param[0].Value = id;
			Dt = DAL.SelectData("get_tb_achat_by_id", param);
			DAL.Close();
			return Dt;
		}
		public DataTable GET_mtier(int Id_commannd)
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			param[0] = new SqlParameter("@ID_sub_commande", SqlDbType.Int);
			param[0].Value = Id_commannd;
			Dt = DAL.SelectData("get_MATIER_commande", param);
			DAL.Close();
			return Dt;
		}
		public DataTable get_tb_matier()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("select_matier_caisse", null);
			DAL.Close();
			return Dt;
		}
		public void delte_matier(
			 int id
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("delte_tb_matier", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
					cmd.ExecuteNonQuery();
				}
			}
		}

		DAL.DAL daoo;
		
		public void insert_TB_MATIER_USE_SUB_CMND(
				 string ID_MATIER
			   , int ID_SUB_COMMANDE
			   , int QT
			   , decimal COUT
			   , string NAME_MATIER
			   , int QTDECHET
			   , string delte
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("insert_TB_MATIER_USE_SUB_CMND", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID_MATIER", SqlDbType.NVarChar).Value = ID_MATIER;
					cmd.Parameters.Add("@ID_SUB_COMMANDE", SqlDbType.Int).Value = ID_SUB_COMMANDE;
					cmd.Parameters.Add("@QT", SqlDbType.Int).Value = QT;
					cmd.Parameters.Add("@COUT", SqlDbType.Money).Value = COUT;
					cmd.Parameters.Add("@NAME_MATIER", SqlDbType.NVarChar).Value = NAME_MATIER;
					cmd.Parameters.Add("@QTDECHET", SqlDbType.Int).Value = QTDECHET;
					cmd.Parameters.Add("@delte", SqlDbType.NVarChar).Value = delte;

					cmd.ExecuteNonQuery();
				}
			}
		}
		public decimal get_total_(int id)
		{
			DAL.DAL DAaL = new DAL.DAL();
			decimal total = 0;

			using (DAaL.sqlConnection)
			{
				string query = "SELECT SUM([COUT]) FROM TB_MATIER_USE_SUB_CMND_caise WHERE [ID_SUB_COMMANDE] = @id;";
				using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
				{
					command.Parameters.AddWithValue("@id", id);
					DAaL.sqlConnection.Open();
					var result = command.ExecuteScalar();
					if (result != DBNull.Value && result != null)
					{
						total = Convert.ToInt32(result);
					}
				}
			}
			return total;
		}
		public void edit_qt_table(
				 string id_commande
			   , int qt
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("edit_qt_matier", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@Id_matier", SqlDbType.NVarChar).Value = id_commande;
					cmd.Parameters.Add("@Qt_use", SqlDbType.Int).Value = qt;
					cmd.ExecuteNonQuery();
				}
			}
		}
		
		public void edit_whene_demontez(
			 string id_commande
			, int qt
			)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("edit_whene_demontez", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@Id_matier", SqlDbType.NVarChar).Value = id_commande;
					cmd.Parameters.Add("@Qt_use", SqlDbType.Int).Value = qt;
					cmd.ExecuteNonQuery();
				}
			}
		}
		public void edit_cout_sub(
				 int ID_sub
			   , decimal cout
			   )
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("edit_sub_cout", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@ID_sub", SqlDbType.Int).Value = ID_sub;
					cmd.Parameters.Add("@cout", SqlDbType.Money).Value = cout; 
					cmd.ExecuteNonQuery();
				}
			}
		}
	}
}
