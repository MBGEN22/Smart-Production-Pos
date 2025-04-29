using CrystalDecisions.CrystalReports.Engine;
using Smart_Production_Pos.PLADD.commande;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.QrCode.Internal;

namespace Smart_Production_Pos.PL.Commande
{
	public partial class frm_facture_vierge : Form
	{
		BL.Bl_commande.BL_FACTURE_VIERGE classVierge = new BL.Bl_commande.BL_FACTURE_VIERGE();
		BL.BL_parametre.BL_paramtre_informatiion classInformation = new BL.BL_parametre.BL_paramtre_informatiion();

		public frm_facture_vierge()
		{
			InitializeComponent();
			DataGridView1.DataSource = classVierge.get_produit_of_principe_globale();
		}

		private void frm_facture_vierge_Load(object sender, EventArgs e)
		{

		}

		private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void groupBox1_Click(object sender, EventArgs e)
		{

		}

		private void groupBox3_Click(object sender, EventArgs e)
		{

		}

		private void kryptonGroup1_Panel_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			frm_add_fctr_vierge add_fctr_vierge = new frm_add_fctr_vierge();
			add_fctr_vierge.fctre_vierge = this;
			add_fctr_vierge.ShowDialog();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				classVierge.delete_prin_fctr((this.DataGridView1.CurrentRow.Cells[0].Value.ToString()));
				DataGridView1.DataSource = classVierge.get_produit_of_principe_globale();
				MessageBox.Show("تمت عملية الحذف بنجاح");
			}
		}

		private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			frm_facture_vierge_product vierge = new frm_facture_vierge_product();
			vierge.ID_facture = this.DataGridView1.CurrentRow.Cells[0].Value.ToString();
			vierge.ShowDialog();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			DataGridView1.DataSource = classVierge.get_produit_of_principe_globale();
		}

		private void button6_Click(object sender, EventArgs e)
		{


			/////////////////
			 
			if (DataGridView1.Rows.Count > 0)
			{
				report.commande.rpt_commande_vierfe rpt = new report.commande.rpt_commande_vierfe();
				#region re
				string mode = Properties.Settings.Default.mode;
				if (mode == "SQL")
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = false;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);
					 
					rpt.Refresh();
					rpt.SetParameterValue("@ID_FACTURE", this.DataGridView1.CurrentRow.Cells[0].Value);
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				else
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = true;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

					rpt.Refresh();
					rpt.SetParameterValue("@ID_FACTURE", this.DataGridView1.CurrentRow.Cells[0].Value);
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				#endregion

				
			}
		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classVierge.search_principale_facture(kryptonTextBox1.Text);
			this.DataGridView1.DataSource = dt;
		}

		private void button10_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classVierge.search_principale_facture_by_client(Convert.ToInt32(cmb_client.SelectedValue));
			this.DataGridView1.DataSource = dt;
		}

		private void button9_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classVierge.search_TB_commande_bY_date(Convert.ToDateTime(kryptonDateTimePicker1.Value));
			this.DataGridView1.DataSource = dt;
		}
	}
}
