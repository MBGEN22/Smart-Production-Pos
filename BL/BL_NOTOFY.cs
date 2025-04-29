using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL
{
    public class BL_NOTOFY
    {
        public DataTable GET_NOTIFY()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("GET_NOTIFY", null);
            DAL.Close();
            return Dt;
        }
        public DataTable get_parametre_day()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("get_parametre_day", null);
            DAL.Close();
            return Dt;
        }
        public DataTable GET_ALL_PRODUCT()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("GET_ALL_PRODUCT", null);
            DAL.Close();
            return Dt;
        }
        DAL.DAL daoo;
        public void DeleteAllRows()
        {
            daoo = new DAL.DAL();
            string query = "DELETE FROM TB_NOTIFICATION";

            using (daoo.sqlConnection)
            {
                using (SqlCommand command = new SqlCommand(query, daoo.sqlConnection))
                {
                    try
                    {
                        daoo.sqlConnection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Handle exception (e.g., log it)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
        }

        public int GetCountNotify()
        {
            daoo = new DAL.DAL();
            int newID = 0;
            string query = "SELECT COUNT(*) FROM TB_NOTIFICATION";

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
                            newID = Convert.ToInt32(result);
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

        public void insert_notif(
            string NOTIFICATION 
            )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {

                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("insert_notif", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.Add("@NOTIFICATION", SqlDbType.NVarChar).Value = NOTIFICATION;  
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
