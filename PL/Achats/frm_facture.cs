using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Achats
{
	public partial class frm_facture : Form
	{
		BL.BL_Achats.BL_facture classFacture = new BL.BL_Achats.BL_facture();
		BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
		public frm_facture()
		{
			InitializeComponent();
			cmbfrnse.DataSource = clasCombobox.getfrnsr();
			cmbfrnse.DisplayMember = "frnsr";
			cmbfrnse.ValueMember = "ID";
			this.dataGridView1.DataSource = classFacture.get_tb_facture();
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			detailes.frm_detailles_fctrr detailles_fctre = new detailes.frm_detailles_fctrr();
			detailles_fctre.id_fctre = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
			detailles_fctre.ShowDialog();
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{

		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			detailes.frm_upload_facture_fichier upload_folder = new detailes.frm_upload_facture_fichier();
			upload_folder.id_facture = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
			upload_folder.ShowDialog();
		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classFacture.search_Facture_achat(txt_seach.Text);
			this.dataGridView1.DataSource = dt;
		}

		private void bigLabel1_Click(object sender, EventArgs e)
		{

		}

		private void kryptonButton3_Click_1(object sender, EventArgs e)
		{
			cmbfrnse.DisplayMember = "frnsr";
			cmbfrnse.ValueMember = "ID";
			this.dataGridView1.DataSource = classFacture.get_tb_facture();
		}

		private void update4_Click(object sender, EventArgs e)
		{
			detailes.frm_upload_facture_fichier upload_folder = new detailes.frm_upload_facture_fichier();
			upload_folder.id_facture = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
			upload_folder.ShowDialog(); 
			 
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classFacture.search_Facture_achat_by_frnsre(Convert.ToInt32(cmbfrnse.SelectedValue));
			this.dataGridView1.DataSource = dt;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classFacture.search_Facture_achat_by_date(Convert.ToDateTime(txt_Date.Value));
			this.dataGridView1.DataSource = dt;
		}

		private void button3_Click(object sender, EventArgs e)
		{

			DataTable dt = new DataTable();
			dt = classFacture.search_Facture_achat_between_date(Convert.ToDateTime(startDate.Value), Convert.ToDateTime(end_date.Value));
			this.dataGridView1.DataSource = dt;
		}

		private void طباعةالفاتورةToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string Etas;
			 if (dataGridView1.Rows.Count > 0)
				{
					report.achat.rpt_facture_achat rpt = new report.achat.rpt_facture_achat();
					#region re
					string mode = Properties.Settings.Default.mode;
					if (mode == "SQL")
					{
						rpt.DataSourceConnections[0].IntegratedSecurity = false;
						rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

						rpt.Refresh();
						rpt.SetParameterValue("@ID_facture", this.dataGridView1.CurrentRow.Cells[0].Value);
						report.viewer_report viewer = new report.viewer_report();
						viewer.crystalReportViewer1.ReportSource = rpt;
						viewer.ShowDialog();
					}
					else
					{
						rpt.DataSourceConnections[0].IntegratedSecurity = true;
						rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

						rpt.Refresh();
						rpt.SetParameterValue("@ID_facture", this.dataGridView1.CurrentRow.Cells[0].Value);
						report.viewer_report viewer = new report.viewer_report();
						viewer.crystalReportViewer1.ReportSource = rpt;
						viewer.ShowDialog();
					}
					#endregion
				
			}
		}
	}
}
