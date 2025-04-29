using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL
{
    public class BL_edi_article
    {
        DAL.DAL daoo;
        public void edit_Article(
                 string ID_PRODUIT
               , float QT_deference 
               )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("edit_Article", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CODEBARRE", SqlDbType.NVarChar).Value = ID_PRODUIT;
                    cmd.Parameters.Add("@QT_deference", SqlDbType.Float).Value = QT_deference; 

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void edit_historique_payment(
                 string NMR_fctr
               , decimal Versement
            , decimal Credit_old
            , decimal CreditNew 
               )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("edit_historique_payment", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NMR_fctr", SqlDbType.NVarChar).Value = NMR_fctr;
                    cmd.Parameters.Add("@Versement", SqlDbType.Money).Value = Versement;
                    cmd.Parameters.Add("@Credit_old", SqlDbType.Money).Value = Credit_old;
                    cmd.Parameters.Add("@CreditNew", SqlDbType.Money).Value = CreditNew; 

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void edit_achat(
                 int ID
               , float Quantite_deference
            ,   decimal PrixHT
            ,   decimal PrixTTC
            ,   decimal TVA
               )
        {
            daoo = new DAL.DAL();
            using (daoo.sqlConnection)
            {
                daoo.sqlConnection.Open();

                using (SqlCommand cmd = new SqlCommand("edit_achat", daoo.sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                    cmd.Parameters.Add("@Quantite_deference", SqlDbType.Float).Value = Quantite_deference;
                    cmd.Parameters.Add("@Prix_Achat_HT", SqlDbType.Money).Value = PrixHT;
                    cmd.Parameters.Add("@Prix_achat_TTC", SqlDbType.Money).Value = PrixTTC;
                    cmd.Parameters.Add("@TVA", SqlDbType.Money).Value = TVA;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
