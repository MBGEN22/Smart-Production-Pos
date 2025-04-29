using Smart_Production_Pos.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Commande
{
	public partial class frm_commande : Form
	{
		BL.Bl_commande.BL_livraison classLivraison = new BL.Bl_commande.BL_livraison();
		BL.Bl_commande.Bl_commande classComande = new BL.Bl_commande.Bl_commande();
		BL.BL_COMBOBOX Bl_combobox = new BL.BL_COMBOBOX();
		public int id_user;
		public frm_commande()
		{
			InitializeComponent();
			this.DataGridView1.DataSource = classComande.get_tb_commande();
			cmb_client.DataSource = Bl_combobox.get_combo_client();
			cmb_client.DisplayMember = "Client";
			cmb_client.ValueMember = "ID"; 
			panel5.Visible = false;
		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			PLADD.commande.frm_add_commande frm_add_commande = new PLADD.commande.frm_add_commande();
			frm_add_commande.id_type_entre = 1;
			frm_add_commande.id_user = id_user;
			frm_add_commande.Show();
		}

		private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void تفاصيلالطلبيةToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PL.Commande.frm_sub_commaned_ formSub_commande = new frm_sub_commaned_();
			formSub_commande.id_commande = this.DataGridView1.CurrentRow.Cells[0].Value.ToString();
			formSub_commande.txt_cout.Text = this.DataGridView1.CurrentRow.Cells[5].Value.ToString() + " د.ج";
			formSub_commande.txt_prix_total.Text = this.DataGridView1.CurrentRow.Cells[9].Value.ToString() + " د.ج";
			formSub_commande.txt_Quantite.Text = this.DataGridView1.CurrentRow.Cells[7].Value.ToString();
			formSub_commande.Show();
		}

		private void الأدواتالمستعملةToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PL.Commande.frm_tools_Commande formSub_commande = new frm_tools_Commande();
			formSub_commande.id_commande = this.DataGridView1.CurrentRow.Cells[0].Value.ToString();
			formSub_commande.Show();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			PLADD.commande.frm_add_commande_facture_proforma add_facture_proforma = new PLADD.commande.frm_add_commande_facture_proforma();
			add_facture_proforma.id_user = id_user;
			add_facture_proforma.Show();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			this.DataGridView1.DataSource = classComande.get_tb_commande();
		}

		private void groupBox4_Click(object sender, EventArgs e)
		{

		}

		private void توصيلToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DataTable Dt = new DataTable();
			Dt = classLivraison.get_client_of_commande(this.DataGridView1.CurrentRow.Cells[0].Value.ToString());
			object id_client;
			id_client = Dt.Rows[0][3];


			DataTable dt = new DataTable();
			dt = classLivraison.get_client_information(Convert.ToInt32(id_client));
			object old_sold;
			old_sold = dt.Rows[0][8];


			PLADD.commande.frm_add_livraison add_livre = new PLADD.commande.frm_add_livraison();
			add_livre.id_commande = this.DataGridView1.CurrentRow.Cells[0].Value.ToString();
			add_livre.id_client = Convert.ToInt32(id_client);
			add_livre.old_sold = decimal.Parse(old_sold.ToString());
			add_livre.ShowDialog();
		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{

		}

		private void button6_Click(object sender, EventArgs e)
		{
			string Etas;
			Etas = this.DataGridView1.CurrentRow.Cells[13].Value.ToString();
			/////////////////
			if (Etas== "طلبية جديدة")
			{

				if (DataGridView1.Rows.Count > 0)
				{
					report.commande.rpt_commande rpt = new report.commande.rpt_commande();
					#region re
					string mode = Properties.Settings.Default.mode;
					if (mode == "SQL")
					{
						rpt.DataSourceConnections[0].IntegratedSecurity = false;
						rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

						rpt.Refresh();
						rpt.SetParameterValue("@ID_facture", this.DataGridView1.CurrentRow.Cells[0].Value);
						report.viewer_report viewer = new report.viewer_report();
						viewer.crystalReportViewer1.ReportSource = rpt;
						viewer.ShowDialog();
					}
					else
					{
						rpt.DataSourceConnections[0].IntegratedSecurity = true;
						rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

						rpt.Refresh();
						rpt.SetParameterValue("@ID_facture", this.DataGridView1.CurrentRow.Cells[0].Value);
						report.viewer_report viewer = new report.viewer_report();
						viewer.crystalReportViewer1.ReportSource = rpt;
						viewer.ShowDialog();
					}
					#endregion
				}
			}

			else
			{
				if (DataGridView1.Rows.Count > 0)
				{
					report.commande.rpt_commande___Copy rpt = new report.commande.rpt_commande___Copy();
					#region re
					string mode = Properties.Settings.Default.mode;
					if (mode == "SQL")
					{
						rpt.DataSourceConnections[0].IntegratedSecurity = false;
						rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

						rpt.Refresh();
						rpt.SetParameterValue("@ID_facture", this.DataGridView1.CurrentRow.Cells[0].Value);
						report.viewer_report viewer = new report.viewer_report();
						viewer.crystalReportViewer1.ReportSource = rpt;
						viewer.ShowDialog();
					}
					else
					{
						rpt.DataSourceConnections[0].IntegratedSecurity = true;
						rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

						rpt.Refresh();
						rpt.SetParameterValue("@ID_facture", this.DataGridView1.CurrentRow.Cells[0].Value);
						report.viewer_report viewer = new report.viewer_report();
						viewer.crystalReportViewer1.ReportSource = rpt;
						viewer.ShowDialog();
					}
					#endregion
				}
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{ 
			if (DataGridView1.Rows.Count > 0)
			{
				report.commande.bon_de_commande rpt = new report.commande.bon_de_commande();
				#region re
				string mode = Properties.Settings.Default.mode;
				if (mode == "SQL")
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = false;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

					rpt.Refresh();
					rpt.SetParameterValue("@ID_facture", this.DataGridView1.CurrentRow.Cells[0].Value);
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				else
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = true;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

					rpt.Refresh();
					rpt.SetParameterValue("@ID_facture", this.DataGridView1.CurrentRow.Cells[0].Value);
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
			}
			#endregion
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if (DataGridView1.Rows.Count > 0)
			{
				report.commande.bon_de_commande___Copy rpt = new report.commande.bon_de_commande___Copy();
				#region re
				string mode = Properties.Settings.Default.mode;
				if (mode == "SQL")
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = false;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

					rpt.Refresh();
					rpt.SetParameterValue("@ID_facture", this.DataGridView1.CurrentRow.Cells[0].Value);
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				else
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = true;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

					rpt.Refresh();
					rpt.SetParameterValue("@ID_facture", this.DataGridView1.CurrentRow.Cells[0].Value);
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
			}
			#endregion

		}

		private void button11_Click(object sender, EventArgs e)
		{ 
			
		}

		private void button10_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classComande.search_TB_commande_by_client(Convert.ToInt32(cmb_client.SelectedValue));
			this.DataGridView1.DataSource = dt;
		}

		private void txt_seach_TextChanged(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classComande.search_TB_commande(txt_seach.Text); 
			this.DataGridView1.DataSource = dt;
		}

		private void button9_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classComande.search_TB_commande_bY_date(Convert.ToDateTime(DateTxt.Value));
			this.DataGridView1.DataSource = dt;
		}

		private void button8_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classComande.search_TB_commande_between_Date(Convert.ToDateTime(startDate.Value), Convert.ToDateTime(end_date.Value));
			this.DataGridView1.DataSource = dt;
		}

		private void طباعةالفاToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string Etas;
			Etas = this.DataGridView1.CurrentRow.Cells[13].Value.ToString();
			/////////////////
			if (Etas == "طلبية جديدة")
			{

				if (DataGridView1.Rows.Count > 0)
				{
					report.commande.rpt_commande rpt = new report.commande.rpt_commande();
					#region re
					string mode = Properties.Settings.Default.mode;
					if (mode == "SQL")
					{
						rpt.DataSourceConnections[0].IntegratedSecurity = false;
						rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

						rpt.Refresh();
						rpt.SetParameterValue("@ID_facture", this.DataGridView1.CurrentRow.Cells[0].Value);
						report.viewer_report viewer = new report.viewer_report();
						viewer.crystalReportViewer1.ReportSource = rpt;
						viewer.ShowDialog();
					}
					else
					{
						rpt.DataSourceConnections[0].IntegratedSecurity = true;
						rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

						rpt.Refresh();
						rpt.SetParameterValue("@ID_facture", this.DataGridView1.CurrentRow.Cells[0].Value);
						report.viewer_report viewer = new report.viewer_report();
						viewer.crystalReportViewer1.ReportSource = rpt;
						viewer.ShowDialog();
					}
					#endregion
				}
			}

			else
			{
				if (DataGridView1.Rows.Count > 0)
				{
					report.commande.rpt_commande___Copy rpt = new report.commande.rpt_commande___Copy();
					#region re
					string mode = Properties.Settings.Default.mode;
					if (mode == "SQL")
					{
						rpt.DataSourceConnections[0].IntegratedSecurity = false;
						rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

						rpt.Refresh();
						rpt.SetParameterValue("@ID_facture", this.DataGridView1.CurrentRow.Cells[0].Value);
						report.viewer_report viewer = new report.viewer_report();
						viewer.crystalReportViewer1.ReportSource = rpt;
						viewer.ShowDialog();
					}
					else
					{
						rpt.DataSourceConnections[0].IntegratedSecurity = true;
						rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

						rpt.Refresh();
						rpt.SetParameterValue("@ID_facture", this.DataGridView1.CurrentRow.Cells[0].Value);
						report.viewer_report viewer = new report.viewer_report();
						viewer.crystalReportViewer1.ReportSource = rpt;
						viewer.ShowDialog();
					}
					#endregion
				}
			}
		}

		private void سندالعمالToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (DataGridView1.Rows.Count > 0)
			{
				report.commande.bon_de_commande___Copy rpt = new report.commande.bon_de_commande___Copy();
				#region re
				string mode = Properties.Settings.Default.mode;
				if (mode == "SQL")
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = false;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

					rpt.Refresh();
					rpt.SetParameterValue("@ID_facture", this.DataGridView1.CurrentRow.Cells[0].Value);
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				else
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = true;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

					rpt.Refresh();
					rpt.SetParameterValue("@ID_facture", this.DataGridView1.CurrentRow.Cells[0].Value);
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
			}
			#endregion

		}

		private void طباعةالسندToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (DataGridView1.Rows.Count > 0)
			{
				report.commande.bon_de_commande rpt = new report.commande.bon_de_commande();
				#region re
				string mode = Properties.Settings.Default.mode;
				if (mode == "SQL")
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = false;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

					rpt.Refresh();
					rpt.SetParameterValue("@ID_facture", this.DataGridView1.CurrentRow.Cells[0].Value);
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				else
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = true;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

					rpt.Refresh();
					rpt.SetParameterValue("@ID_facture", this.DataGridView1.CurrentRow.Cells[0].Value);
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
			}
			#endregion

		}

		private void buttocn4_Click(object sender, EventArgs e)
		{
			if(panel5.Visible == true)
			{
				panel5.Visible = false;
			}
			else if (panel5.Visible == false)
			{
				panel5.Visible = true;
			}
		}

		private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			// تأكد من أن الصف يحتوي على بيانات
			if (e.RowIndex >= 0)
			{
				// الحصول على التاريخ الأقصى للصف الحالي
				DateTime deadlineDate;
				if (DateTime.TryParse(DataGridView1.Rows[e.RowIndex].Cells["التاريخ الأقصى"].Value.ToString(), out deadlineDate))
				{
					// حساب الفرق بين التاريخ الحالي والتاريخ الأقصى
					TimeSpan timeDifference = deadlineDate - DateTime.Today;

					// إذا كان التاريخ الأقصى يساوي تاريخ اليوم، يتم تلوين الصف باللون الأحمر
					if (timeDifference.TotalDays == 0)
					{
						DataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
					}
					// إذا كان الفرق خمسة أيام أو أقل، يتم تلوين الصف باللون البرتقالي
					else if (timeDifference.TotalDays > 0 && timeDifference.TotalDays <= 5)
					{
						DataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Orange;
					}
				}
			}
		}
		
	}
}
