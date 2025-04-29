using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Commande
{
	public partial class frm_sub_commande : Form
	{
		BL.Bl_commande.BL_sub_commande class_Commande = new BL.Bl_commande.BL_sub_commande();
		public frm_sub_commande()
		{
			InitializeComponent();
			this.dataGridView1.DataSource = class_Commande.sub_commande_total_list();
			txt_Quantite.Text = get_ttl_qt().ToString() ;
			txt_livre_ttl.Text = get_livre_qt().ToString();
			txt_rest_ttl.Text= get_rest_qt().ToString();
		}

		public float get_ttl_qt()
		{
			DAL.DAL DAaL = new DAL.DAL();

			float sum = 0;

			using (DAaL.sqlConnection)
			{
				string query = "SELECT SUM([QUANTITE]) FROM [dbo].[TB_SUM_COMMANDE]";
				using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
				{
					DAaL.sqlConnection.Open();
					var result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						sum = Convert.ToInt32(result);
					}
				}
			}
			return sum;
		}

		public float get_livre_qt()
		{
			DAL.DAL DAaL = new DAL.DAL();

			float sum = 0;

			using (DAaL.sqlConnection)
			{
				string query = "SELECT SUM([QT_LIVRE]) FROM [dbo].[TB_SUM_COMMANDE]";
				using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
				{
					DAaL.sqlConnection.Open();
					var result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						sum = Convert.ToInt32(result);
					}
				}
			}
			return sum;
		}

		public float get_rest_qt()
		{
			DAL.DAL DAaL = new DAL.DAL();

			float sum = 0;

			using (DAaL.sqlConnection)
			{
				string query = "SELECT SUM([QTE_REST]) FROM [dbo].[TB_SUM_COMMANDE]";
				using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
				{
					DAaL.sqlConnection.Open();
					var result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						sum = Convert.ToInt32(result);
					}
				}
			}
			return sum;
		}
	}
}
