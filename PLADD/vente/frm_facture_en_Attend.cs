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

namespace Smart_Production_Pos.PLADD.vente
{
	public partial class frm_facture_en_Attend : Form
	{
		BL.BL_CAISSE caisseVente_classe = new BL.BL_CAISSE();
		BL.BL_vente.BL_vente_Fonction class_facturation = new BL.BL_vente.BL_vente_Fonction();
		public frmVente_facturation frmVente;
		public frm_facture_en_Attend()
		{
			InitializeComponent();
			dataGridFctr.DataSource = class_facturation.get_facture_attend("فاتورة قيد الانتظار");
		}

		private void dataGridFctr_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			txt_nmr_fctr.Text = this.dataGridFctr.CurrentRow.Cells[0].Value.ToString();
			txt_client.Text = this.dataGridFctr.CurrentRow.Cells[3].Value.ToString();
			txt_TTL.Text = this.dataGridFctr.CurrentRow.Cells[4].Value.ToString();
			kryptonDataGridView2.DataSource = class_facturation.get_vente_by_nmr(txt_nmr_fctr.Text); 
			btn_recupiration.Enabled = true;
		}

		private void btn_recupiration_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow roww in kryptonDataGridView2.Rows)
			{
				if (!roww.IsNewRow)
				{
					string CodeBarrre = roww.Cells["رقم المنتوج"].Value.ToString();
					DataTable Dt = new DataTable();
					Dt = caisseVente_classe.getSold_MAtier_revent(CodeBarrre);
					if (Dt.Rows.Count > 0)
					{
						Object codeBarre = Dt.Rows[0][0];
						Object name_product = Dt.Rows[0][1];
						Object price_Vente = Dt.Rows[0][15];
						Object Quanite_dans_pack = Dt.Rows[0][24];
						foreach (DataGridViewRow row in frmVente.dataGridView1.Rows)
						{
							if (!row.IsNewRow)
							{
								var cellValue = row.Cells["DgvCodeBarre"].Value;

								// Check if the cell value is not null before comparison
								if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
								{
									row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
									row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
															decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
									 
									frmVente.GetTTL();
									frmVente.txtCount.Text = frmVente.getCount().ToString();

									return;
								}
							}
						}
						//this Line add new product
						frmVente.dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "U" });

					}
					else if (Dt.Rows.Count == 0)
					{
						Dt = caisseVente_classe.select_produit_fabrique(CodeBarrre);
						if (Dt.Rows.Count > 0)
						{
							Object codeBarre = Dt.Rows[0][0];
							Object name_product = Dt.Rows[0][1];
							Object price_Vente = Dt.Rows[0][11];
							Object Quanite_dans_pack = Dt.Rows[0][6];
							foreach (DataGridViewRow row in frmVente.dataGridView1.Rows)
							{
								if (!row.IsNewRow)
								{
									var cellValue = row.Cells["DgvCodeBarre"].Value;

									// Check if the cell value is not null before comparison
									if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
									{
										row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
										row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
																decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
										 frmVente.GetTTL();
										frmVente.txtCount.Text = frmVente.getCount().ToString();

										return;
									}
								}
							}
							//this Line add new product
							frmVente.dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "U" });

						}
						else if (Dt.Rows.Count == 0)
						{
							Dt = caisseVente_classe.select_pack_info(CodeBarrre);
							if (Dt.Rows.Count > 0)
							{

								Object codeBarre = Dt.Rows[0][0];
								Object name_product = Dt.Rows[0][1];
								Object price_Vente = Dt.Rows[0][4];

								foreach (DataGridViewRow row in frmVente.dataGridView1.Rows)
								{
									if (!row.IsNewRow)
									{
										var cellValue = row.Cells["DgvCodeBarre"].Value;

										// Check if the cell value is not null before comparison
										if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
										{
											row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
											row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
																	decimal.Parse(row.Cells["dgvAmount"].Value.ToString());

											frmVente.GetTTL();
											frmVente.txtCount.Text = frmVente.getCount().ToString();

											return;
										}
									}
								}
								//this Line add new product
								frmVente.dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "P" });

							}
							else if (Dt.Rows.Count == 0)
							{
								Dt = caisseVente_classe.select_pack_Produit_finaux_info(CodeBarrre);
								if (Dt.Rows.Count > 0)
								{

									Object codeBarre = Dt.Rows[0][0];
									Object name_product = Dt.Rows[0][1];
									Object price_Vente = Dt.Rows[0][4];

									foreach (DataGridViewRow row in frmVente.dataGridView1.Rows)
									{
										if (!row.IsNewRow)
										{
											var cellValue = row.Cells["DgvCodeBarre"].Value;

											// Check if the cell value is not null before comparison
											if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
											{
												row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
												row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
																		decimal.Parse(row.Cells["dgvAmount"].Value.ToString());

												frmVente.GetTTL();
												frmVente.txtCount.Text = frmVente.getCount().ToString();

												return;
											}
										}
									}
									//this Line add new product
									frmVente.dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "P" });

								}
								else if (Dt.Rows.Count == 0)
								{
									Dt = caisseVente_classe.select_produit_by_code_barre_reserve(CodeBarrre);
									if (Dt.Rows.Count > 0)
									{

										Object codeBarre = Dt.Rows[0][0];
										Object name_product = Dt.Rows[0][1];
										Object price_Vente = Dt.Rows[0][2];

										foreach (DataGridViewRow row in frmVente.dataGridView1.Rows)
										{
											if (!row.IsNewRow)
											{
												var cellValue = row.Cells["DgvCodeBarre"].Value;

												// Check if the cell value is not null before comparison
												if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
												{
													row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
													row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
																						decimal.Parse(row.Cells["dgvAmount"].Value.ToString());

													frmVente.GetTTL();
													frmVente.txtCount.Text = frmVente.getCount().ToString();

													return;
												}
											}
										}
										//this Line add new product
										frmVente.dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "U" });

										//MessageBox.Show("هذا المنتوج غير موجود في قاعدة البيانات");
									}
									else if (Dt.Rows.Count == 0)
									{
										//
										Dt = caisseVente_classe.get_information_by_code_Reserve_pack(CodeBarrre);
										if (Dt.Rows.Count > 0)
										{

											Object codeBarre = Dt.Rows[0][0];
											Object name_product = Dt.Rows[0][1];
											Object price_Vente = Dt.Rows[0][2];

											foreach (DataGridViewRow row in frmVente.dataGridView1.Rows)
											{
												if (!row.IsNewRow)
												{
													var cellValue = row.Cells["DgvCodeBarre"].Value;

													// Check if the cell value is not null before comparison
													if (cellValue != null && cellValue.ToString() == codeBarre.ToString())
													{
														row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
														row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
																							decimal.Parse(row.Cells["dgvAmount"].Value.ToString());

														frmVente.GetTTL();
														frmVente.txtCount.Text = frmVente.getCount().ToString();

														return;
													}
												}
											}
											//this Line add new product
											frmVente.dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "P" });

											//MessageBox.Show("هذا المنتوج غير موجود في قاعدة البيانات");
										}

										//
									}
								}
							}
						}
					}

					frmVente.txt_id_facture.Text = txt_nmr_fctr.Text;
					frmVente.clientCmb.Text = txt_client.Text;
					frmVente.Typpped = "edit";
					frmVente.GetTTL();
					frmVente.txtCount.Text = frmVente.getCount().ToString();
					// Redundant line (explained below)
				}
			}
			this.Close();


				
			}

		private void button3_Click(object sender, EventArgs e)
		{
			if (dataGridFctr.Rows.Count > 0)
			{
				report.vente.RP_fctr_vente rpt = new report.vente.RP_fctr_vente();
				#region re
				string mode = Properties.Settings.Default.mode;
				if (mode == "SQL")
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = false;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

					rpt.Refresh();
					rpt.SetParameterValue("@nmr_Facture", this.dataGridFctr.CurrentRow.Cells[0].Value);
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				else
				{
					rpt.DataSourceConnections[0].IntegratedSecurity = true;
					rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

					rpt.Refresh();
					rpt.SetParameterValue("@nmr_Facture", this.dataGridFctr.CurrentRow.Cells[0].Value);
					report.viewer_report viewer = new report.viewer_report();
					viewer.crystalReportViewer1.ReportSource = rpt;
					viewer.ShowDialog();
				}
				#endregion
			}
		}

		private void frm_facture_en_Attend_Load(object sender, EventArgs e)
		{

		}
	}
	
}
