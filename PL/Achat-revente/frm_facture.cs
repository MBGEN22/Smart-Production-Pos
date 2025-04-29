using ComponentFactory.Krypton.Toolkit;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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

namespace Smart_Production_Pos.PL.Achat_revente
{
	public partial class frm_facture : Form
	{
		BL.BL_ACHAT_REVENT.BL_facture classFacture = new BL.BL_ACHAT_REVENT.BL_facture();
		BL.BL_COMBOBOX classCombobox = new BL.BL_COMBOBOX();
        BL.BL_Statistique.Query_Statistique classQyeru_state = new BL.BL_Statistique.Query_Statistique();
        public frm_facture()
		{
			InitializeComponent();
			this.dataGridView1.DataSource = classFacture.get_tb_facture();
			cmbfrnse.DataSource = classCombobox.getfrnsr();
			cmbfrnse.DisplayMember = "frnsr";
			cmbfrnse.ValueMember = "ID";

            LB_TTL.Text = classQyeru_state.ttl_ttc_fctr_achat(); 
			LB_VERSEMENT.Text = classQyeru_state.ttl_versemnt_ttc_fctr_achat(); 
        }

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			PL.Achat_revente.frm_upload_fichier upload_folder = new PL.Achat_revente.frm_upload_fichier();
			upload_folder.id_facture = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
			upload_folder.ShowDialog();
		}

		private void button1_Click(object sender, EventArgs e)
		{

			this.dataGridView1.DataSource = classFacture.search_facture_produit_revent_by_frnsre(Convert.ToInt32(cmbfrnse.SelectedValue));
		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = classFacture.search_facture_produit_revent_(kryptonTextBox1.Text);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classFacture.search_facture_produit_revent_by_Date(Convert.ToDateTime(kryptonDateTimePicker1.Value));
			this.dataGridView1.DataSource = dt;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = classFacture.search_facture_produit_revent_between_Date(Convert.ToDateTime(startDate.Value),
																																		Convert.ToDateTime(end_date.Value));
			this.dataGridView1.DataSource = dt; 
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{ 
			this.dataGridView1.DataSource = classFacture.get_tb_facture();
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			detailes.frm_Detaille_fctr_Produit_revent detailles_fctre = new detailes.frm_Detaille_fctr_Produit_revent();
			detailles_fctre.id_fctre = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
			detailles_fctre.ShowDialog();
		}

		private void kryptoxnButton3_Click(object sender, EventArgs e)
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

		private void طباعةالفاتورةToolStripMenuItem_Click(object sender, EventArgs e)
		{
            
			if (dataGridView1.Rows.Count > 0)
			{
				//report.achat.rpt_Achat_Bachir rpt = new report.achat.rpt_Achat_Bachir();
                report.achat.FACTURE_ACHAT_REVENTE rpt = new report.achat.FACTURE_ACHAT_REVENTE();
                #region re
                string mode = Properties.Settings.Default.mode;
                if (mode == "SQL")
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = false;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                    rpt.Refresh();
                    rpt.SetParameterValue("@ID_FACTURE", this.dataGridView1.CurrentRow.Cells[0].Value);
                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
                else
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = true;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                    rpt.Refresh();
                    rpt.SetParameterValue("@ID_FACTURE", this.dataGridView1.CurrentRow.Cells[0].Value); 
                    // Display the report in the viewer
                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
                #endregion
              


            }
        }

        private void تعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
			frm_edit_fctr_achat editFCTR = new frm_edit_fctr_achat();
			editFCTR.txt_id_fctr.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            editFCTR.kryptonDateTimePicker1.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
            editFCTR.cmbfrnse.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            editFCTR.txt_nmbre_produit.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            editFCTR.txt_Versement.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            editFCTR.txtTotalHT.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            editFCTR.txtTotalTTC.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            editFCTR.credit_OLD.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            editFCTR.credit_new.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString(); 
            editFCTR.ShowDialog();
        }

        private void تحميلملفاتتابعةللفاتورةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Achat_revente.frm_upload_fichier upload_folder = new PL.Achat_revente.frm_upload_fichier();
            upload_folder.id_facture = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            upload_folder.ShowDialog();
        }
    }
}
