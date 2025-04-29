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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using Smart_Production_Pos.BL.BL_FICHIER;
using Smart_Production_Pos.report;

namespace Smart_Production_Pos.PL.vente
{
	public partial class frm_facture_vente : Form
	{
		BL.BL_vente.BL_vente_Fonction classFacteure = new BL.BL_vente.BL_vente_Fonction();
		BL.BL_COMBOBOX Bl_combobox = new BL.BL_COMBOBOX();
        BL.BL_vente.BL_FACTURE_VENTE class_facture_vente = new BL.BL_vente.BL_FACTURE_VENTE();
        public int id_user;
        BL.BL_CAISSE caisseVente_classe = new BL.BL_CAISSE();
        //private string connectionString = @"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB_PRODUCTION_POS.mdf;Integrated Security=true;";
        DAL.DAL daoo = new DAL.DAL();
		BL.BL_vente.BL_DELETE_FCTR classDelete = new BL.BL_vente.BL_DELETE_FCTR();
		public frm_facture_vente()
		{
			InitializeComponent();
            dataGridView1.DataSource = class_facture_vente.list_facture_vente();
            kryptonDataGridView1.DataSource = classFacteure.get_facture_detailles();
			cmb_client.DataSource = Bl_combobox.get_combo_client();
            cmb_client.DisplayMember = "Client";
			cmb_client.ValueMember = "ID";
            kryptonComboBox1.DataSource = Bl_combobox.get_combo_client();
            kryptonComboBox1.DisplayMember = "Client";
            kryptonComboBox1.ValueMember = "ID";
            textTotalTTc.Text = classFacteure.get_fct_total();
            kryptonTextBox4.Text = class_facture_vente.get_fct_total();
        }

		private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void kryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (kryptonDataGridView1.RowCount > 0)
            {
                txt_nmr_fctr.Text = this.kryptonDataGridView1.CurrentRow.Cells[0].Value.ToString();
                txt_client.Text = this.kryptonDataGridView1.CurrentRow.Cells[3].Value.ToString();
                txt_TTL.Text = this.kryptonDataGridView1.CurrentRow.Cells[4].Value.ToString();
                kryptonDataGridView2.DataSource = classFacteure.get_vente_by_nmrr(this.kryptonDataGridView1.CurrentRow.Cells[0].Value.ToString()); 
            }
			else
			{
				MessageBox.Show("الجدول فارغ");
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			kryptonDataGridView1.DataSource = classFacteure.search_facture_par_date(Convert.ToDateTime(kryptonDateTimePicker1.Value));
		}

		private void txt_seach_TextChanged(object sender, EventArgs e)
		{
			kryptonDataGridView1.DataSource = classFacteure.search_facture_vente(txt_seach.Text);
		}

		private void button5_Click(object sender, EventArgs e)
		{

			kryptonDataGridView1.DataSource = classFacteure.search_facture_par_client(Convert.ToInt32(cmb_client.SelectedValue));
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			kryptonDataGridView1.DataSource = classFacteure.get_facture_detailles();
		}
		public bool TestConnection()
		{
			try
			{
				using (daoo.sqlConnection)
				{
                    daoo.sqlConnection.Open();
					// Connection successful
					MessageBox.Show("Connection successful!");
					return true;
				}
			}
			catch (Exception ex)
			{
				// Connection failed
				MessageBox.Show($"Connection failed: {ex.Message}");
				return false;
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			if (kryptonDataGridView1.Rows.Count > 0)
			{
				#region
				//	// Define the local database connection string
				//	string local = @"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB_PRODUCTION_POS.mdf;Integrated Security=true;";

				//	// Create an instance of the report
				//	report.vente.RP_fctr_vente rpt = new report.vente.RP_fctr_vente();

				//	// Set up the database connection for the report tables
				//	foreach (CrystalDecisions.CrystalReports.Engine.Table table in rpt.Database.Tables)
				//	{
				//		TableLogOnInfo logonInfo = table.LogOnInfo;
				//		logonInfo.ConnectionInfo.ServerName = @"(LocalDB)\MSSQLLocalDB";
				//		logonInfo.ConnectionInfo.DatabaseName = @"|DataDirectory|\DB_PRODUCTION_POS.mdf";
				//		logonInfo.ConnectionInfo.IntegratedSecurity = true;
				//		table.ApplyLogOnInfo(logonInfo);
				//	}

				//	// Set up the database connection for the report stored procedures
				//	foreach (ReportDocument subreport in rpt.Subreports)
				//	{
				//		foreach (CrystalDecisions.CrystalReports.Engine.Table table in subreport.Database.Tables)
				//		{
				//			TableLogOnInfo logonInfo = table.LogOnInfo;
				//			logonInfo.ConnectionInfo.ServerName = @"(LocalDB)\MSSQLLocalDB";
				//			logonInfo.ConnectionInfo.DatabaseName = @"|DataDirectory|\DB_PRODUCTION_POS.mdf";
				//			logonInfo.ConnectionInfo.IntegratedSecurity = true;
				//			table.ApplyLogOnInfo(logonInfo);
				//		}
				//	}

				//	// Refresh the report
				//	rpt.Refresh();

				//	// Set the parameter value for the report
				//	rpt.SetParameterValue("@nmr_Facture", this.kryptonDataGridView1.CurrentRow.Cells[0].Value);

				//	// Create an instance of the viewer and set the report source
				//	report.viewer_report viewer = new report.viewer_report();
				//	viewer.crystalReportViewer1.ReportSource = rpt;

				//	// Display the report
				//	viewer.ShowDialog();

				//}
				//if (kryptonDataGridView1.Rows.Count > 0)
				//{

				//	// Define the local database connection string
				//	string local = @"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB_PRODUCTION_POS.mdf;Integrated Security=true;";

				//	// Create an instance of the report
				//	report.vente.RP_fctr_vente rpt = new report.vente.RP_fctr_vente();

				//	try
				//	{
				//		string server = @"(LocalDB)\MSSQLLocalDB";
				//		string db = @"|DataDirectory|\DB_PRODUCTION_POS.mdf";

				//		// Check if DataSourceConnections is not empty
				//		if (rpt.DataSourceConnections.Count > 0)
				//		{
				//			// Set the database connection for the report
				//			rpt.DataSourceConnections[0].SetConnection(server, db, true);
				//			rpt.DataSourceConnections[0].IntegratedSecurity = true;

				//			// Refresh the report to ensure it gets the latest data
				//			rpt.Refresh();
				//		}
				//		else
				//		{
				//			throw new Exception("No data source connections found in the report.");
				//		}

				//		// Check if the DataGridView and its cell are valid
				//		if (this.kryptonDataGridView1.CurrentRow != null && this.kryptonDataGridView1.CurrentRow.Cells.Count > 0)
				//		{
				//			// Set the parameter value for the report
				//			rpt.SetParameterValue("@nmr_Facture", this.kryptonDataGridView1.CurrentRow.Cells[0].Value);
				//		}
				//		else
				//		{
				//			throw new Exception("Invalid DataGridView row or cell index.");
				//		}

				//		// Create an instance of the viewer and set the report source
				//		report.viewer_report viewer = new report.viewer_report();
				//		viewer.crystalReportViewer1.ReportSource = rpt;
				//		viewer.crystalReportViewer1.Refresh(); // Ensure the viewer is refreshed

				//		// Display the report
				//		viewer.ShowDialog();
				//	}
				//	catch (Exception ex)
				//	{
				//		// Handle any exceptions that occur
				//		MessageBox.Show("An error occurred: " + ex.Message);
				//	}


				//// Define the local database connection string
				//string local = @"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB_PRODUCTION_POS.mdf;Integrated Security=true;";

				//// Create an instance of the report
				//report.achat.rpt_facture_achat rpt = new report.achat.rpt_facture_achat();

				//try
				//{
				//	string server = @"(LocalDB)\MSSQLLocalDB";
				//	string db = @"|DataDirectory|\DB_PRODUCTION_POS.mdf";
				//	rpt.DataSourceConnections[0].IntegratedSecurity = true;
				//	rpt.DataSourceConnections[0].SetConnection(server, db, true);
				//	// Refresh the report
				//	rpt.Refresh();

				//	// Set the parameter value for the report
				//	rpt.SetParameterValue("@nmr_Facture", this.kryptonDataGridView1.CurrentRow.Cells[0].Value);

				//	// Create an instance of the viewer and set the report source
				//	report.viewer_report viewer = new report.viewer_report();
				//	viewer.crystalReportViewer1.ReportSource = rpt;
				//	viewer.crystalReportViewer1.Refresh(); // Ensure the viewer is refreshed

				//	// Display the report
				//	viewer.ShowDialog();



				//// Set up the database connection for the report tables
				//foreach (CrystalDecisions.CrystalReports.Engine.Table table in rpt.Database.Tables)
				//{
				//	TableLogOnInfo logonInfo = table.LogOnInfo;
				//	logonInfo.ConnectionInfo.ServerName = @"(LocalDB)\MSSQLLocalDB";
				//	logonInfo.ConnectionInfo.DatabaseName = "DB_PRODUCTION_POS"; // Changed to database name only
				//	logonInfo.ConnectionInfo.IntegratedSecurity = true;
				//	table.ApplyLogOnInfo(logonInfo);

				//	// Optional: Test connectivity
				//	if (!table.TestConnectivity())
				//	{
				//		throw new Exception($"Failed to connect to table: {table.Name}");
				//	}
				//}

				//// Set up the database connection for the report stored procedures
				//foreach (ReportDocument subreport in rpt.Subreports)
				//{
				//	foreach (CrystalDecisions.CrystalReports.Engine.Table table in subreport.Database.Tables)
				//	{
				//		TableLogOnInfo logonInfo = table.LogOnInfo;
				//		logonInfo.ConnectionInfo.ServerName = @"(LocalDB)\MSSQLLocalDB";
				//		logonInfo.ConnectionInfo.DatabaseName = "DB_PRODUCTION_POS"; // Changed to database name only
				//		logonInfo.ConnectionInfo.IntegratedSecurity = true;
				//		table.ApplyLogOnInfo(logonInfo);

				//		// Optional: Test connectivity
				//		if (!table.TestConnectivity())
				//		{
				//			throw new Exception($"Failed to connect to subreport table: {table.Name}");
				//		}
				//	}
				//}


				////}
				////catch (Exception ex)
				////{
				////	MessageBox.Show($"Error: {ex.Message}");
				////}

				#endregion

				report.vente.RP_fctr_vente rpt = new report.vente.RP_fctr_vente();
				#region re
				string mode = Properties.Settings.Default.mode;
				if (mode == "SQL")
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = false;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

					rpt.Refresh();
					rpt.SetParameterValue("@nmr_Facture", this.kryptonDataGridView1.CurrentRow.Cells[0].Value);
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				else
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = true;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

					rpt.Refresh();
					rpt.SetParameterValue("@nmr_Facture", this.kryptonDataGridView1.CurrentRow.Cells[0].Value);
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				#endregion
			}
		}


			#region debut
			//report.vente.RP_fctr_vente rpt = new report.vente.RP_fctr_vente();
			//#region re
			//string mode = Properties.Settings.Default.mode;
			//if (mode == "SQL")
			//{
			//	rpt.DataSourceConnections[0].IntegratedSecurity = false;
			//	rpt.DataSourceConnections[0].SetConnection(
			//		Properties.Settings.Default.server,
			//		Properties.Settings.Default.dataBase,
			//		Properties.Settings.Default.ID,
			//		Properties.Settings.Default.PASS
			//		);

			//	rpt.Refresh();
			//	rpt.SetParameterValue("@nmr_Facture", this.kryptonDataGridView1.CurrentRow.Cells[0].Value);
			//	report.viewer_report viewer = new report.viewer_report();
			//	viewer.crystalReportViewer1.ReportSource = rpt;
			//	viewer.ShowDialog();
			//}
			//else
			//{
			//	rpt.DataSourceConnections[0].IntegratedSecurity = true;
			//	rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

			//	rpt.Refresh();
			//	rpt.SetParameterValue("@nmr_Facture", this.kryptonDataGridView1.CurrentRow.Cells[0].Value);
			//	report.viewer_report viewer = new report.viewer_report();
			//	viewer.crystalReportViewer1.ReportSource = rpt;
			//	viewer.ShowDialog();
			//}
			#endregion




		private void button3_Click(object sender, EventArgs e)
		{
			if (kryptonDataGridView1.Rows.Count > 0)
			{
				#region local
				//// Define the local database connection string
				//string local = @"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB_PRODUCTION_POS.mdf;Integrated Security=true;";

				//// Create an instance of the report
				//report.vente.RP_fctr_vente rpt = new report.vente.RP_fctr_vente();

				//// Set up the database connection for the report tables
				//foreach (CrystalDecisions.CrystalReports.Engine.Table table in rpt.Database.Tables)
				//{
				//	TableLogOnInfo logonInfo = table.LogOnInfo;
				//	logonInfo.ConnectionInfo.ServerName = @"(LocalDB)\MSSQLLocalDB";
				//	logonInfo.ConnectionInfo.DatabaseName = @"|DataDirectory|\DB_PRODUCTION_POS.mdf";
				//	logonInfo.ConnectionInfo.IntegratedSecurity = true;
				//	table.ApplyLogOnInfo(logonInfo);
				//}

				//// Set up the database connection for the report stored procedures
				//foreach (ReportDocument subreport in rpt.Subreports)
				//{
				//	foreach (CrystalDecisions.CrystalReports.Engine.Table table in subreport.Database.Tables)
				//	{
				//		TableLogOnInfo logonInfo = table.LogOnInfo;
				//		logonInfo.ConnectionInfo.ServerName = @"(LocalDB)\MSSQLLocalDB";
				//		logonInfo.ConnectionInfo.DatabaseName = @"|DataDirectory|\DB_PRODUCTION_POS.mdf";
				//		logonInfo.ConnectionInfo.IntegratedSecurity = true;
				//		table.ApplyLogOnInfo(logonInfo);
				//	}
				//}

				//// Refresh the report
				//rpt.Refresh();

				//// Set the parameter value for the report
				//rpt.SetParameterValue("@nmr_Facture", this.kryptonDataGridView1.CurrentRow.Cells[0].Value);

				//// Create an instance of the viewer and set the report source
				//report.viewer_report viewer = new report.viewer_report();
				//viewer.crystalReportViewer1.ReportSource = rpt;

				//// Display the report
				//viewer.ShowDialog();
				#endregion

				report.vente.bon_de_vente rpt = new report.vente.bon_de_vente();
					#region re
					string mode = Properties.Settings.Default.mode;
					if (mode == "SQL")
					{
						rpt.DataSourceConnections[0].IntegratedSecurity = false;
						rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

						rpt.Refresh();
						rpt.SetParameterValue("@nmr_Facture", this.kryptonDataGridView1.CurrentRow.Cells[0].Value);
						report.viewer_report viewer = new report.viewer_report();
						viewer.crystalReportViewer1.ReportSource = rpt;
						viewer.ShowDialog();
					}
					else
					{
						rpt.DataSourceConnections[0].IntegratedSecurity = true;
						rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

						rpt.Refresh();
						rpt.SetParameterValue("@nmr_Facture", this.kryptonDataGridView1.CurrentRow.Cells[0].Value);
						report.viewer_report viewer = new report.viewer_report();
						viewer.crystalReportViewer1.ReportSource = rpt;
						viewer.ShowDialog();
					}
					#endregion
			}
		}
		

		private void button380cm_Click(object sender, EventArgs e)
		{
			if (kryptonDataGridView1.Rows.Count > 0)
			{
				report.vente.receipt1 rpt = new report.vente.receipt1();
				#region re
				string mode = Properties.Settings.Default.mode;
				if (mode == "SQL")
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = false;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

					rpt.Refresh();
					rpt.SetParameterValue("@nmr_Facture", this.kryptonDataGridView1.CurrentRow.Cells[0].Value);
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				else
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = true;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

					rpt.Refresh();
					rpt.SetParameterValue("@nmr_Facture", this.kryptonDataGridView1.CurrentRow.Cells[0].Value);
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				#endregion
			}
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			if (kryptonDataGridView1.Rows.Count > 0)
			{
				Microsoft.Office.Interop.Excel.ApplicationClass MExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
				MExcel.Application.Workbooks.Add(Type.Missing);
				for (int i = 1; i < kryptonDataGridView1.Columns.Count + 1; i++)
				{
					MExcel.Cells[1, i] = kryptonDataGridView1.Columns[i - 1].HeaderText;
				}
				for (int i = 0; i < kryptonDataGridView1.Rows.Count; i++)
				{
					for (int j = 0; j < kryptonDataGridView1.Columns.Count; j++)
					{
						MExcel.Cells[i + 2, j + 1] = kryptonDataGridView1.Rows[i].Cells[j].Value.ToString();
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

        private void kryptonDataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

            if (kryptonDataGridView1.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.ColumnHeader ||
                kryptonDataGridView1.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.TopLeftHeader)
            {
                ContextMenu menu = new ContextMenu();

                //add item to the menu
                foreach (DataGridViewColumn column in kryptonDataGridView1.Columns)
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
                        menu.Show(kryptonDataGridView1, e.Location);
                    };
                    menu.MenuItems.Add(item);
                }
                //show the menu 
                menu.Show(kryptonDataGridView1, e.Location);

            }
        }

        private void kryptonDataGridView2_MouseClick(object sender, MouseEventArgs e)
        {

            if (kryptonDataGridView1.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.ColumnHeader ||
                kryptonDataGridView1.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.TopLeftHeader)
            {
                ContextMenu menu = new ContextMenu();

                //add item to the menu
                foreach (DataGridViewColumn column in kryptonDataGridView1.Columns)
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
                        menu.Show(kryptonDataGridView1, e.Location);
                    };
                    menu.MenuItems.Add(item);
                }
                //show the menu 
                menu.Show(kryptonDataGridView1, e.Location);

            }
        }

        private void DELETE_FACTURE_Click(object sender, EventArgs e)
        {
			if (MessageBox.Show("هذا الخيار سيقوم بحذف الفاتورة هل انت متأكد", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				DataTable dt_facture = new DataTable();
				dt_facture = classDelete.get_tb_fctr_vente(txt_nmr_fctr.Text);
				object id_client = dt_facture.Rows[0][3];
				object total_ttc = dt_facture.Rows[0][4];
				object versement = dt_facture.Rows[0][8];

				//DELETE_VENTE
				classDelete.DELETE_LIST_VENTE(txt_nmr_fctr.Text);
				//DELETE_HISTORIQUE
				classDelete.DELETE_HISTORIQUE_CLIENT_BY_ID_FCTR(txt_nmr_fctr.Text);
				//DELETE_FACTURE_VENTE
				classDelete.DELETE_FACTURE_VENTE(txt_nmr_fctr.Text);
				//edit historique client
				classDelete.EDIT_HISTORIQE_WHENE_DELET_FCTRE(
					Convert.ToInt32(id_client.ToString()),
					decimal.Parse(versement.ToString()),
					decimal.Parse(total_ttc.ToString())
					);

                foreach (DataGridViewRow row in kryptonDataGridView2.Rows)
                {
                    if (!row.IsNewRow) // التحقق من أن الصف ليس فارغًا
                    {
                        string produitId = row.Cells[1].Value.ToString();
                        float quantite = float.Parse(row.Cells[3].Value.ToString());

						//get tb produit if tb produit > 0 so : 
						DataTable Dt_produit = new DataTable();
                        Dt_produit = caisseVente_classe.getSold_MAtier_revent(produitId);
                        if (Dt_produit.Rows.Count > 0)
                        {
                            classDelete.rectefier_after_vente(produitId, quantite);
						}
						else
                        {
                            DataTable dt_pack = new DataTable();
                            dt_pack = classDelete.get_pack_liee_with_product(produitId);
							if (dt_pack.Rows.Count > 0)
							{
								object codeBarre_produit = dt_pack.Rows[0][1];
                                object qt_dans_pack = dt_pack.Rows[0][3];
								float Qt_ttl = float.Parse(qt_dans_pack.ToString()) * quantite;
								string code_pr = codeBarre_produit.ToString();
                                classDelete.rectefier_after_vente(code_pr, Qt_ttl);
                            }
						}  
					}
                }

                classDelete.insert_hitorique(
					$"قام المستخدم {id_user} بحذف الفاتورة رقم {txt_nmr_fctr.Text}",
					DateTime.Today,
					DateTime.Now.TimeOfDay
				);
                MessageBox.Show("تم حذف الفاتورة بنجاح");
				kryptonDataGridView1.DataSource = classFacteure.get_facture_detailles();


            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            kryptonTextBox3.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            kryptonTextBox2.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            kryptonTextBox1.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            string nmr_fctr = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            dataGridView2.DataSource = class_facture_vente.list_detaille_facture_vente(nmr_fctr);
        }

        private void kryptonTextBox5_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = class_facture_vente.searh_facture_vente(kryptonTextBox5.Text);
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        { 
            dataGridView1.DataSource = class_facture_vente.list_facture_vente();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = class_facture_vente.searh_facture_vente_by_date(Convert.ToDateTime(kryptonDateTimePicker2.Value));
        }

        private void button9_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = class_facture_vente.search_facture_par_client(Convert.ToInt32(kryptonComboBox1.SelectedValue));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            { 
                report.vente.facture_officiel rpt = new report.vente.facture_officiel();
                #region re
                string mode = Properties.Settings.Default.mode;
                if (mode == "SQL")
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = false;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                    rpt.Refresh();
                    rpt.SetParameterValue("@nmr_facture", this.dataGridView1.CurrentRow.Cells[0].Value);
                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
                else
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = true;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                    rpt.Refresh();
                    rpt.SetParameterValue("@nmr_facture", this.dataGridView1.CurrentRow.Cells[0].Value);
                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
                #endregion
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                report.vente.bon_facturation1 rpt = new report.vente.bon_facturation1();
                #region re
                string mode = Properties.Settings.Default.mode;
                if (mode == "SQL")
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = false;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                    rpt.Refresh();
                    rpt.SetParameterValue("@nmr_facture", this.dataGridView1.CurrentRow.Cells[0].Value);
                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
                else
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = true;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                    rpt.Refresh();
                    rpt.SetParameterValue("@nmr_facture", this.dataGridView1.CurrentRow.Cells[0].Value);
                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
                #endregion
            }
        }

        private void edit_client_Click(object sender, EventArgs e)
        {
			frm_edit_bon edit_bon = new frm_edit_bon();
			edit_bon.ID_bon = this.kryptonDataGridView1.CurrentRow.Cells[0].Value.ToString(); 
            edit_bon.ShowDialog();
        }
    }
}
