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
	public partial class frm_livraison : Form
	{
		BL.Bl_commande.BL_livraison classLivraison = new BL.Bl_commande.BL_livraison(); 
		BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
		public frm_livraison()
		{
			InitializeComponent();
			this.dataGridView1.DataSource = classLivraison.get_table_liv();
			cmb_client.DataSource = clasCombobox.get_combo_client();
			cmb_client.DisplayMember = "Client";
			cmb_client.ValueMember = "ID";
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			detailes.frm_detaille_livraison frm = new detailes.frm_detaille_livraison();
			frm.id_liv = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
			frm.ShowDialog();
		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{
			DataTable Dt = new DataTable();
			Dt = classLivraison.search_TB_livraison(txt_Search.Text);
			dataGridView1.DataSource = Dt;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DataTable Dt = new DataTable();
			Dt = classLivraison.search_TB_livraison_by_client(Convert.ToInt32(cmb_client.SelectedValue));
			dataGridView1.DataSource = Dt;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DataTable Dt = new DataTable();
			Dt = classLivraison.search_TB_livraison_by_Date(Convert.ToDateTime(kryptonDateTimePicker1.Value));
			dataGridView1.DataSource = Dt;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			DataTable Dt = new DataTable();
			Dt = classLivraison.search_TB_livraison_between_Date(Convert.ToDateTime(startDate.Value), Convert.ToDateTime(end_date.Value));
			dataGridView1.DataSource = Dt;
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{

		}

		private void طباعةالمعلوماتToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int id_liv = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
			if (dataGridView1.Rows.Count > 0)
			{
				report.Livraison.rpt_livraison_by_id rpt = new report.Livraison.rpt_livraison_by_id();
				#region re
				string mode = Properties.Settings.Default.mode;
				if (mode == "SQL")
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = false;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

					rpt.Refresh();
					rpt.SetParameterValue("@ID_liv", id_liv);
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				else
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = true;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

					rpt.Refresh();
					rpt.SetParameterValue("@ID_liv", id_liv);
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
			}
			#endregion
		}
	}
}
