using Smart_Production_Pos.TAB_CONTROL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Achats
{
	public partial class frm_historique_fournisseur : Form
	{
		BL.frnsre_history_sold classHistorique_frnsre = new BL.frnsre_history_sold();
		BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();

		public frm_historique_fournisseur()
		{
			InitializeComponent();
			cmbfrnse.DataSource = clasCombobox.getfrnsr();
			cmbfrnse.DisplayMember = "frnsr";
			cmbfrnse.ValueMember = "ID";
			this.dataGridView1.DataSource = classHistorique_frnsre.get_TB_historique_fournisseur();
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{

		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{

		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			PLADD.achat.frm_add_historique_frnsre add_historique = new PLADD.achat.frm_add_historique_frnsre();
			add_historique.frm_historique = this;
			add_historique.ShowDialog();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classHistorique_frnsre.search_by_frnsr(Convert.ToInt32(cmbfrnse.SelectedValue));
			dataGridView1.DataSource = dt;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classHistorique_frnsre.search_date(Convert.ToDateTime(kryptonDateTimePicker1.Value));
			dataGridView1.DataSource = dt;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classHistorique_frnsre.search_between_date(
				Convert.ToDateTime(startDate.Value),
				Convert.ToDateTime(end_date.Value));
			dataGridView1.DataSource = dt;
		}

		private void kryptonTextBox1_TextChanged_1(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classHistorique_frnsre.search_on_history_frnsr(kryptonTextBox1.Text);
			dataGridView1.DataSource = dt;
		}

		private void update(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = classHistorique_frnsre.get_TB_historique_fournisseur();
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			if (radioButton1.Checked == true)
			{
				DataTable dt = new DataTable();
				dt = classHistorique_frnsre.search_by_frnsr(Convert.ToInt32(cmbfrnse.SelectedValue));
				dataGridView1.DataSource = dt;
				if (dt.Rows.Count > 0)
				{
					report.Fournisseure.RP_historique_by_frnsre rpt = new report.Fournisseure.RP_historique_by_frnsre();
					#region re
					string mode = Properties.Settings.Default.mode;
					if (mode == "SQL")
					{
						rpt.DataSourceConnections[0].IntegratedSecurity = false;
						rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

						rpt.Refresh();
						rpt.SetParameterValue("@ID_FOURNISSEUR", Convert.ToInt32(cmbfrnse.SelectedValue));
						report.viewer_report viewer = new report.viewer_report();
						viewer.crystalReportViewer1.ReportSource = rpt;
						viewer.ShowDialog();
					}
					else
					{
						rpt.DataSourceConnections[0].IntegratedSecurity = true;
						rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

						rpt.Refresh();
						rpt.SetParameterValue("@ID_FOURNISSEUR", Convert.ToInt32(cmbfrnse.SelectedValue));
						report.viewer_report viewer = new report.viewer_report();
						viewer.crystalReportViewer1.ReportSource = rpt;
						viewer.ShowDialog();
					}
					#endregion
				}
			}
			else if (radioButton2.Checked == true)
			{
				DataTable dt = new DataTable();
				dt = classHistorique_frnsre.search_date(Convert.ToDateTime(kryptonDateTimePicker1.Value));
				dataGridView1.DataSource = dt;
				if (dt.Rows.Count > 0)
				{
					report.Fournisseure.RP_historique_frnsr_by_date rpt = new report.Fournisseure.RP_historique_frnsr_by_date();
					#region re
					string mode = Properties.Settings.Default.mode;
					if (mode == "SQL")
					{
						rpt.DataSourceConnections[0].IntegratedSecurity = false;
						rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

						rpt.Refresh();
						rpt.SetParameterValue("@DATE", Convert.ToDateTime(kryptonDateTimePicker1.Value));
						report.viewer_report viewer = new report.viewer_report();
						viewer.crystalReportViewer1.ReportSource = rpt;
						viewer.ShowDialog();
					}
					else
					{
						rpt.DataSourceConnections[0].IntegratedSecurity = true;
						rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

						rpt.Refresh();
						rpt.SetParameterValue("@DATE", Convert.ToDateTime(kryptonDateTimePicker1.Value));
						report.viewer_report viewer = new report.viewer_report();
						viewer.crystalReportViewer1.ReportSource = rpt;
						viewer.ShowDialog();
					}
					#endregion
				}
			}
			else if (radioButton3.Checked == true)
			{
				DataTable dt = new DataTable();
				dt = classHistorique_frnsre.search_between_date(
					Convert.ToDateTime(startDate.Value),
					Convert.ToDateTime(end_date.Value));
				dataGridView1.DataSource = dt;
				report.Fournisseure.RP_HISTORIQUE_FRNSRE_BETWEEN_DATE rpt = new report.Fournisseure.RP_HISTORIQUE_FRNSRE_BETWEEN_DATE();
				#region re
				string mode = Properties.Settings.Default.mode;
				if (mode == "SQL")
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = false;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

					rpt.Refresh();
					rpt.SetParameterValue("@StartDate", Convert.ToDateTime(startDate.Value)); 
					rpt.SetParameterValue("@EndDate", Convert.ToDateTime(end_date.Value));
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				else
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = true;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

					rpt.Refresh();
					rpt.SetParameterValue("@StartDate", Convert.ToDateTime(startDate.Value));
					rpt.SetParameterValue("@EndDate", Convert.ToDateTime(end_date.Value));
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				#endregion
			}

		}

		private void سندالدفعToolStripMenuItem_Click(object sender, EventArgs e)
		{
			 
			 
				report.Fournisseure.rpt_bon_frnsre rpt = new report.Fournisseure.rpt_bon_frnsre();
				#region re
				string mode = Properties.Settings.Default.mode;
				if (mode == "SQL")
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = false;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

					rpt.Refresh();
					rpt.SetParameterValue("@ID", this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				else
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = true;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

					rpt.Refresh();
					rpt.SetParameterValue("@ID", this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				#endregion
			 
		}

		private void exportExcel1_Click(object sender, EventArgs e)
		{
			if (dataGridView1.Rows.Count > 0)
			{
				Microsoft.Office.Interop.Excel.ApplicationClass MExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
				MExcel.Application.Workbooks.Add(Type.Missing);
				for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
				{
					MExcel.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
				}
				for (int i = 0; i < dataGridView1.Rows.Count; i++)
				{
					for (int j = 0; j < dataGridView1.Columns.Count; j++)
					{
						MExcel.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
					}
				}
				MExcel.Columns.AutoFit();
				MExcel.Rows.AutoFit();
				MExcel.Columns.Font.Size = 12;
				MExcel.Visible = true;
			}
			else
			{
				MessageBox.Show("No records found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
