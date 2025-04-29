using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using Smart_Production_Pos.TAB_CONTROL;
using static System.Collections.Specialized.BitVector32;


namespace Smart_Production_Pos.PL.CLient
{
	public partial class frm_historique_client : Form
	{
		BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();

		BL.Client_history_sold class_Historique_client = new BL.Client_history_sold();
		public frm_historique_client()
		{
			InitializeComponent();
			dataGridView1.DataSource = class_Historique_client.get_TB_historique_Client();
			cmb_client.DataSource = clasCombobox.get_combo_client();
			cmb_client.DisplayMember = "Client";
			cmb_client.ValueMember = "ID";
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			if (radioButton1.Checked == true)
			{
				DataTable dt = new DataTable();
				dt = class_Historique_client.search_by_client(Convert.ToInt32(cmb_client.SelectedValue));
				dataGridView1.DataSource = dt;
				if (dt.Rows.Count > 0)
				{
					report.historique_Client.rpt_historique_By_client rpt = new report.historique_Client.rpt_historique_By_client();
					#region re
					string mode = Properties.Settings.Default.mode;
					if (mode == "SQL")
					{
						rpt.DataSourceConnections[0].IntegratedSecurity = false;
						rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

						rpt.Refresh();
						rpt.SetParameterValue("@ID_CLIENT", Convert.ToInt32(cmb_client.SelectedValue));
						report.viewer_report viewer = new report.viewer_report();
						viewer.crystalReportViewer1.ReportSource = rpt;
						viewer.ShowDialog();
					}
					else
					{
						rpt.DataSourceConnections[0].IntegratedSecurity = true;
						rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

						rpt.Refresh();
						rpt.SetParameterValue("@ID_CLIENT", Convert.ToInt32(cmb_client.SelectedValue));
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
				dt = class_Historique_client.search_date(Convert.ToDateTime(kryptonDateTimePicker1.Value));
				dataGridView1.DataSource = dt;
				if (dt.Rows.Count > 0)
				{
					report.historique_Client.rp_historique_client_byDate rpt = new report.historique_Client.rp_historique_client_byDate();
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
				dt = class_Historique_client.search_between_date(
					Convert.ToDateTime(startDate.Value),
					Convert.ToDateTime(end_date.Value));
				dataGridView1.DataSource = dt;
				report.historique_Client.rpt_histoeique_client_between_date rpt = new report.historique_Client.rpt_histoeique_client_between_date();
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

		private void kryptonCheckBox3_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void kryptonCheckBox2_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void kryptonCheckBox1_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = class_Historique_client.search_by_client(Convert.ToInt32(cmb_client.SelectedValue));
			dataGridView1.DataSource = dt;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = class_Historique_client.search_date(Convert.ToDateTime(kryptonDateTimePicker1.Value));
			dataGridView1.DataSource = dt;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = class_Historique_client.search_between_date(
				Convert.ToDateTime(startDate.Value),
				Convert.ToDateTime(end_date.Value));
			dataGridView1.DataSource = dt;
		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = class_Historique_client.search_on_histoyry_client(kryptonTextBox1.Text);
			dataGridView1.DataSource = dt;

		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			PLADD.vente.frm_historique_client add_historique_client = new PLADD.vente.frm_historique_client();
			add_historique_client.frm_historique = this;
			add_historique_client.ShowDialog();
		}

		private void طباعةسندللزبونToolStripMenuItem_Click(object sender, EventArgs e)
		{
			 
		 
				report.historique_Client.rpt_bon_client rpt = new report.historique_Client.rpt_bon_client();
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

		private void kryptonButton4_Click(object sender, EventArgs e)
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

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

            if (dataGridView1.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.ColumnHeader ||
                dataGridView1.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.TopLeftHeader)
            {
                ContextMenu menu = new ContextMenu();

                //add item to the menu
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    MenuItem item = new MenuItem();
                    item.Text = column.HeaderText;
                    item.Checked = column.Visible;

                    //now let add the event if the item was cheked
                    item.Click += (obj, ea) =>
                    {
                        column.Visible = !item.Checked;

                        //update the check
                        item.Checked = column.Visible;

                        //show the selection item 
                        menu.Show(dataGridView1, e.Location);
                    };
                    menu.MenuItems.Add(item);
                }
                //show the menu 
                menu.Show(dataGridView1, e.Location);

            }
        }
    }
}
