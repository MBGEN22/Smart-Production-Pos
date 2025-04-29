using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL
{
    public class BL_STATE
    {
        public DataTable SELECT_COUNT_PRODUIT()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            Dt = DAL.SelectData("SELECT_COUNT_PRODUIT", null);
            DAL.Close();
            return Dt;
        }
        public DataTable select_benifice_state()
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            Dt = DAL.SelectData("select_benifice_state", null);
            DAL.Close();
            return Dt;
        }
        public DataTable get_list_historique_vente_produit_par_mois(string ID_Produit)
        {
            DAL.DAL DAL = new DAL.DAL();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_Produit", SqlDbType.NVarChar);
            param[0].Value = ID_Produit;
            Dt = DAL.SelectData("get_list_historique_vente_produit_par_mois", param);
            DAL.Close();
            return Dt;
        }
    }
}
