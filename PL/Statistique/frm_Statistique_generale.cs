using Smart_Production_Pos.BL.Bl_commande;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace Smart_Production_Pos.PL.Statistique
{
	public partial class frm_Statistique_generale : Form
	{
		BL.BL_Statistique.Query_Statistique classQyeru_state = new BL.BL_Statistique.Query_Statistique();
		decimal Cout_de_facture;
		public frm_Statistique_generale()
		{
			InitializeComponent();
			txt_count_caissier.Text=classQyeru_state.Count_Caissier().ToString();
		    txt_count_user.Text=classQyeru_state.count_user().ToString();
			txt_count_fournisseur.Text=classQyeru_state.Count_fournisseure().ToString();
			txt_count_client.Text=classQyeru_state.count_client().ToString();
			txt_count_ouverier.Text=classQyeru_state.count_ouverier().ToString();
			txt_count_fctr.Text=classQyeru_state.count_facture().ToString();
			txt_count_commande.Text=classQyeru_state.count_commande().ToString();
			txt_count_stock_p_f.Text=classQyeru_state.count_produit_stock().ToString();
			txt_count_g_p_f.Text=classQyeru_state.gestion_produit_finaux().ToString();
			txt_count_Pack_pF.Text = classQyeru_state.pack_gestion_produit_finaux().ToString();
			//------------------------------------------------------------------------------------------------------//
			txt_sum_depense.Text = classQyeru_state.sum_depense();
			txt_sum_taklufa_commande.Text = classQyeru_state.taklufa_commande();
			txt_sum_price_PF.Text = classQyeru_state.taklufa_PF();
			txt_sum_la_paye.Text = classQyeru_state.txt_sum_la_paye();
			//-----------------------------------------------------------------------------------------------------//
			txt_total_commande_ttc.Text = classQyeru_state.total_ttc_commande();
			txt_total_ttc_fctr.Text = classQyeru_state.total_ttc_fct_vente();
			txt_total_facture_Achat.Text = classQyeru_state.ttl_ttc_fctr_achat();
			txt_Versemnt_commande_ttc.Text = classQyeru_state.total_versemnt_ttc_commande();
			txt_versemnt_tctrtc_f.Text = classQyeru_state.total_versemnt_ttc_fct_vente();
			txt_versemnt_fctr_achat.Text = classQyeru_state.ttl_versemnt_ttc_fctr_achat();
			//------------------------------------------------------------------------------------------------------//
			txt_versement_frnsre.Text = classQyeru_state.vers_frnsre();
			txt_rest_frnsre.Text = classQyeru_state.rest_frnsre();
			//------------------------------------------------------------------------------------------------------//
			txt_vers_client.Text = classQyeru_state.vers_client();
			txt_rest_client.Text = classQyeru_state.rest_client();
			//------------------------------------------------------------------------------------------------++
			dataGridView2.DataSource = classQyeru_state.sp_UpdateIDClientCount();
			dataGridView1.DataSource = classQyeru_state.sp_UpdateIDClientCount_frnsre();
			//------------------------------------------------------------------------------------------------++ 
			txt_deche_no_restore.Text = classQyeru_state.dechet_no_receycle();
			txt_dechet_restore.Text = classQyeru_state.TB_DECHET_REClage();
			//----------------------------------------------------------------------------------------------------

			Cout_de_facture = decimal.Parse(classQyeru_state.cout_de_facture());
			lb_masrof_ttl.Text = masrouf_ttl(
				decimal.Parse(txt_sum_depense.Text),
				0,
				decimal.Parse(txt_sum_la_paye.Text)
				).ToString();

			lb_enterd_ttl.Text = txt_vers_client.Text;

			//----------------------------------------------------------------------------------------------------

			lb_fayda_ttl.Text = fayda(
                decimal.Parse(lb_enterd_ttl.Text),
                decimal.Parse(lb_masrof_ttl.Text)
				).ToString(); 
			if (decimal.Parse(lb_fayda_ttl.Text) < 0)
			{
				lb_fayda_ttl.BackColor = Color.Red;
			}
			//----------------------------------------------------------------------------------------------------
			LoadPieChart();
			LoadPieChart_client(); LoadChartDataA();

        }
        private void LoadChartDataA()
        {
            DAL.DAL daoo = new DAL.DAL();
            string connectionString = daoo.sqlConnection.ToString();
            string query = @"
                SELECT designation as 'المنتوج', Quantite_vente AS 'الكمية المباعة'
                FROM TB_Produit_revente ";

            using (daoo.sqlConnection)
            {
                SqlDataAdapter da = new SqlDataAdapter(query, daoo.sqlConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);

                chart4.Series.Clear();
                Series series = new Series("الكمية المباعة")
                {
                    ChartType = SeriesChartType.Column
                };

                chart4.Series.Add(series);

                foreach (DataRow row in dt.Rows)
                {
                    series.Points.AddXY(row["المنتوج"], row["الكمية المباعة"]);
                }
            }
        }
        private void LoadPieChart()
		{
			DAL.DAL daoo = new DAL.DAL();
			string connectionString = daoo.sqlConnection.ToString();
			string storedProcedure = "sp_GetFournisseurSums";
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();
				using (SqlCommand cmd = new SqlCommand(storedProcedure, daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							// Using Convert.ToDecimal to safely convert the values
							decimal sumSoldPaye = reader.IsDBNull(0) ? 0 : Convert.ToDecimal(reader.GetValue(0));
							decimal sumSoldNonPaye = reader.IsDBNull(1) ? 0 : Convert.ToDecimal(reader.GetValue(1));

							//Data for the pie chart

						   string[] labels = { "المبلغ المدفوع", "المبلغ الغير مدفوع" };
							decimal[] values = { sumSoldNonPaye , sumSoldPaye };

							// Clear existing series
							chart2.Series.Clear();

							// Create a new series and add points
							Series series = new Series
							{
								Name = "FournisseurSums",
								IsVisibleInLegend = true,
								ChartType = SeriesChartType.Pie
							};

							// Add new series to the chart
							chart2.Series.Add(series);

							// Clear existing data points if any
							series.Points.Clear();

							//Add new data points
							for (int i = 0; i < labels.Length; i++)
							{ 
								series.Points.AddXY(labels[i], values[i]); 
							}

							// Customize the chart
							series["PieLabelStyle"] = "Disabled";
							series["PieLineColor"] = "Black";

							chart2.ChartAreas[0].Area3DStyle.Enable3D = false;
							chart2.Legends[0].Enabled = false;

							chart2.Titles.Clear();
							//chart2.Titles.Add("Distribution of SOLD PAYE and SOLD NON PAYE");

						}
					}
				}
			}



		}
		private void LoadPieChart_client()
		{
			DAL.DAL daoo = new DAL.DAL();
			string connectionString = daoo.sqlConnection.ToString();
			string storedProcedure = "sp_GetclientSums";
			using (daoo.sqlConnection)
			{
				daoo.sqlConnection.Open();
				using (SqlCommand cmd = new SqlCommand(storedProcedure, daoo.sqlConnection))
				{
					cmd.CommandType = CommandType.StoredProcedure;

					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							// Using Convert.ToDecimal to safely convert the values
							decimal sumSoldPaye = reader.IsDBNull(0) ? 0 : Convert.ToDecimal(reader.GetValue(0));
							decimal sumSoldNonPaye = reader.IsDBNull(1) ? 0 : Convert.ToDecimal(reader.GetValue(1));

							//Data for the pie chart

							string[] labels = { "المبلغ المدفوع", "المبلغ الغير مدفوع" };
							decimal[] values = { sumSoldNonPaye, sumSoldPaye };

							// Clear existing series
							chart3.Series.Clear();

							// Create a new series and add points
							Series series = new Series
							{
								Name = "FournisseurSums",
								IsVisibleInLegend = true,
								ChartType = SeriesChartType.Pie
							};

							// Add new series to the chart
							chart3.Series.Add(series);

							// Clear existing data points if any
							series.Points.Clear();

							//Add new data points
							for (int i = 0; i < labels.Length; i++)
							{
								series.Points.AddXY(labels[i], values[i]);
							}

							// Customize the chart
							series["PieLabelStyle"] = "Disabled";
							series["PieLineColor"] = "Black";

							chart3.ChartAreas[0].Area3DStyle.Enable3D = false;
							chart3.Legends[0].Enabled = false;

							chart3.Titles.Clear();
							//chart2.Titles.Add("Distribution of SOLD PAYE and SOLD NON PAYE");

						}
					}
				}
			} 
		}
		private decimal masrouf_ttl(decimal depense , decimal achat , decimal khedamin)
		{
			decimal ttl = depense + achat + khedamin;
			return ttl;
		}
		private decimal fayda(decimal versement_client  , decimal makhrouj )
		{
			decimal ttl = versement_client - makhrouj;
			return ttl;
		}
		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void frm_Statistique_generale_Load(object sender, EventArgs e)
		{

		}

		private void panel18_Paint(object sender, PaintEventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void label13_Click(object sender, EventArgs e)
		{

		}

		private void kryptonGroup8_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
