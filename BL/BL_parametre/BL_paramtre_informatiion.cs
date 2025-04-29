using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL.BL_parametre
{
	public class BL_paramtre_informatiion
	{
		
		//////////////////////// GetTable Client
		public DataTable get_inforamtion()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			Dt = DAL.SelectData("get_inforamtion", null);
			DAL.Close();
			return Dt;
		}
        public DataTable Get_paramater_tb()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("Get_paramater_tb", null);
            DAL.Close();
            return Dt;
        }

        DAL.DAL daoo;
		public void edit_setting(
		string NAME,
		string PRENAME,
		string ADRESS,
		string ACTIVITY,
		string NMR_REGISTRE,
		string NMR_MATIER,
		string NMR_JIBAI,
		Byte[] LOGO, 
		string WILAYA,
		string CompanyName,
		int ID,
		string phone,
		string message  
        ,string PRINT_FACTURE
        , string PRINT_BON
        , string PRINT_BON_A4
        , string DONT_PRINT
		, int DAY_AVANT_PEREPRTION)
		{
			daoo = new DAL.DAL();
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();

				using (SqlCommand cmd = new SqlCommand("edit_setting", daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.Add("@NAME", SqlDbType.NVarChar, 50).Value = NAME;
					cmd.Parameters.Add("@PRENAME", SqlDbType.NVarChar, 50).Value = PRENAME;
					cmd.Parameters.Add("@ADRESS", SqlDbType.NVarChar, 50).Value = ADRESS;
					cmd.Parameters.Add("@ACTIVITY", SqlDbType.NVarChar, 50).Value = ACTIVITY;
					cmd.Parameters.Add("@NMR_REGISTRE", SqlDbType.NVarChar, -1).Value = NMR_REGISTRE; // -1 for nvarchar(max)
					cmd.Parameters.Add("@NMR_MATIER", SqlDbType.NVarChar, -1).Value = NMR_MATIER; // -1 for nvarchar(max)
					cmd.Parameters.Add("@NMR_JIBAI", SqlDbType.NVarChar, -1).Value = NMR_JIBAI; // -1 for nvarchar(max)
					cmd.Parameters.Add("@LOGO", SqlDbType.Image).Value = LOGO;
					cmd.Parameters.Add("@WILAYA", SqlDbType.NVarChar, 50).Value = WILAYA;
					cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 50).Value = CompanyName;
					cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
					cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 50).Value = phone;
					cmd.Parameters.Add("@Message", SqlDbType.NVarChar).Value = message;
                    cmd.Parameters.Add("@PRINT_FACTURE", SqlDbType.NVarChar).Value = PRINT_FACTURE;
                    cmd.Parameters.Add("@PRINT_BON", SqlDbType.NVarChar).Value = PRINT_BON;
                    cmd.Parameters.Add("@PRINT_BON_A4", SqlDbType.NVarChar).Value = PRINT_BON_A4;
                    cmd.Parameters.Add("@DONT_PRINT", SqlDbType.NVarChar).Value = DONT_PRINT;
                    cmd.Parameters.Add("@DAY_AVANT_PEREPRTION", SqlDbType.Int).Value = DAY_AVANT_PEREPRTION;

                    cmd.ExecuteNonQuery();
				}
			}
		}

		 
	}
}
