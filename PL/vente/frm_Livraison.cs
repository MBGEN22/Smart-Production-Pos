using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.vente
{
	public partial class frm_Livraison : Form
	{
		BL.BL_vente.BL_livraison classLivraison = new BL.BL_vente.BL_livraison();
		public frm_Livraison()
		{
			InitializeComponent(); 
			this.dataGridView1.DataSource = classLivraison.get_Tb_livraison_vente();
		}

		private void txt_Search_TextChanged(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = classLivraison.search_Tb_livraison_vente(txt_Search.Text);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = classLivraison.search_TB_livraison_by_client(Convert.ToInt32(cmb_client.SelectedValue));

		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = classLivraison.search_TB_livraison_byDate(Convert.ToDateTime(kryptonDateTimePicker1.Value));

			}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			if (dataGridView1.Rows.Count > 0)
			{
				report.Livraison_Vente.feuille_de_liv rpt = new report.Livraison_Vente.feuille_de_liv();
				#region re
				string mode = Properties.Settings.Default.mode;
				if (mode == "SQL")
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = false;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

					rpt.Refresh();
					rpt.SetParameterValue("@nmr_Facture", this.dataGridView1.CurrentRow.Cells[1].Value);
					rpt.SetParameterValue("@nmr_Facture1", this.dataGridView1.CurrentRow.Cells[1].Value);
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				else
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = true;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

					rpt.Refresh();
					rpt.SetParameterValue("@nmr_Facture", this.dataGridView1.CurrentRow.Cells[1].Value);
					rpt.SetParameterValue("@nmr_Facture1", this.dataGridView1.CurrentRow.Cells[1].Value);
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				#endregion
			}
		}
	}
}
