using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ZXing.QrCode.Internal.Mode;
using ZXing.QrCode.Internal;
using Smart_Production_Pos.BL;
using System.Security.Permissions;
using Smart_Production_Pos.TAB_CONTROL;

namespace Smart_Production_Pos.PLADD.vente
{
	public partial class frmVente_facturation : Form
	{
		BL.BL_CAISSE caisseVente_classe = new BL.BL_CAISSE();
		BL.BL_PRODUCTION.BL_GESTION_PRODUIT_FINAUX ClassProduction = new BL.BL_PRODUCTION.BL_GESTION_PRODUIT_FINAUX();
		BL.BL_ACHAT_REVENT.BL_PRODUIT classProduit = new BL.BL_ACHAT_REVENT.BL_PRODUIT();
		BL.BL_vente.BL_vente_Fonction classVente = new BL.BL_vente.BL_vente_Fonction();
		BL.Client_history_sold historique_Client = new BL.Client_history_sold();
		BL.BL_COMBOBOX Bl_combobox = new BL.BL_COMBOBOX();
		BL.BL_vente.BL_SP_LOGINE_Caisse classCaisse = new BL.BL_vente.BL_SP_LOGINE_Caisse();
		BL.BL_vente.bl_diminuer_la_Qt_vente classQt_vente = new BL.BL_vente.bl_diminuer_la_Qt_vente();

		public string Typpped;
		public decimal FontCaisse;
		public int type;
		public int ID_historique;
		public decimal Prix_Cloture;
		public int ID_caissier;
		public int id_user;
		string txt_new_montant;
		string Typpe;
		public frmVente_facturation()
		{
			InitializeComponent();
			clientCmb.DataSource = Bl_combobox.get_combo_client();
			clientCmb.DisplayMember = "Client";
			clientCmb.ValueMember = "ID";
			dataGridView1.Columns[7].Visible = false;
			txt_id_facture.Text = classVente.get_fctr_vnt();
			//production 
			if (prix1check.Checked == true)
			{
				this.kryptonDataGridView1.DataSource = ClassProduction.GET_TB_GESTION_PRODUIT_FINAUX_Prix1();
			}
			else if (prix1check.Checked == true)
			{
				this.kryptonDataGridView1.DataSource = ClassProduction.GET_TB_GESTION_PRODUIT_FINAUX_Prix2();
			}
			else if (prix1check.Checked == true)
			{
				this.kryptonDataGridView1.DataSource = ClassProduction.GET_TB_GESTION_PRODUIT_FINAUX_Prix_min();
			}
			//pack

			if (prix1check.Checked == true)
			{
				this.kryptonDataGridView4.DataSource = ClassProduction.get_tab_pack_prix1();
			}
			else if (prix1check.Checked == true)
			{
				this.kryptonDataGridView4.DataSource = ClassProduction.get_tab_pack_prix2();
			}
			else if (prix1check.Checked == true)
			{
				this.kryptonDataGridView4.DataSource = ClassProduction.get_tab_pack_prixmin();
			}
			//revente
			//if (prix1check.Checked == true)
			//{
			//	this.kryptonDataGridView2.DataSource = classProduit.get_stock_produit_revenet_caisse();
			//}
			//else if (prix1check.Checked == true)
			//{
			//	this.kryptonDataGridView2.DataSource = classProduit.get_stock_produit_revenet_caisse_Prix2();
			//}
			//else if (prix1check.Checked == true)
			//{
			//	this.kryptonDataGridView2.DataSource = classProduit.get_stock_produit_revenet_caisse_prix_Min();
			//}
			////pack 
			//this.kryptonDataGridView3.DataSource = classProduit.get_stock_pack();
		}

		private void panel21_Paint(object sender, PaintEventArgs e)
		{

		}

		private void kryptonButton25_Click(object sender, EventArgs e)
		{

		}

		private void kryptonButton6_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void prix1check_CheckedChanged(object sender, EventArgs e)
		{ 
			this.kryptonDataGridView1.DataSource = ClassProduction.GET_TB_GESTION_PRODUIT_FINAUX_Prix1(); 
			this.kryptonDataGridView4.DataSource = ClassProduction.get_tab_pack_prix1();
			//this.kryptonDataGridView2.DataSource = classProduit.get_stock_produit_revenet_caisse();
		}

		public decimal calcule_TVA(decimal PrixeTTc, decimal TVA)
		{
			decimal priceHT = PrixeTTc / (1 + (TVA / 100));
			priceHT = Math.Round(priceHT, 2);
			return priceHT;
		}
		private void prix2check_CheckedChanged(object sender, EventArgs e)
		{
			//this.kryptonDataGridView2.DataSource = classProduit.get_stock_produit_revenet_caisse_Prix2();
			this.kryptonDataGridView1.DataSource = ClassProduction.GET_TB_GESTION_PRODUIT_FINAUX_Prix2();
			this.kryptonDataGridView4.DataSource = ClassProduction.get_tab_pack_prix2();
		}

		private void prixMincheck_CheckedChanged(object sender, EventArgs e)
		{
			//this.kryptonDataGridView2.DataSource = classProduit.get_stock_produit_revenet_caisse_prix_Min();
			this.kryptonDataGridView1.DataSource = ClassProduction.GET_TB_GESTION_PRODUIT_FINAUX_Prix_min();
			this.kryptonDataGridView4.DataSource = ClassProduction.get_tab_pack_prixmin();
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (tabControl1.SelectedIndex)
			{
				case 0:
					// Code for tab 1 
					chechHTbtn.Visible = true;
					prix1check.Visible = true;
					prix2check.Visible = true;
					prixMincheck.Visible = true;
					prix1check.Text = "السعر الأول";
					prix2check.Text = "السعر الثاني";
					prixMincheck.Text = "السعر الادنى ";
					break;
				case 1:
					// Code for tab 2 
					chechHTbtn.Visible = false;
					prix1check.Visible = true;
					prix2check.Visible = true;
					prixMincheck.Visible = true;
					prix1check.Text = "السعر الأول";
					prix2check.Text = "السعر الثاني";
					prixMincheck.Text = "السعر الادنى ";
					break;
				case 2:
					// Code for tab 3 
					chechHTbtn.Visible = false;
					prix1check.Visible = false;
					prix2check.Visible = false;
					prixMincheck.Visible = false;
					break;
				default:
					// Code for other tabs 
					chechHTbtn.Visible = false;
					prix1check.Visible = true;
					prix2check.Visible = true;
					prixMincheck.Visible = true;
					prix1check.Text = "ثمن الجملة";
					prix2check.Text = "ثمن التجزئة";
					prixMincheck.Text = "الثمن الادنى ";
					break;
			}
		}

		private void kryptonDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			string barcode =  this.kryptonDataGridView1.CurrentRow.Cells[0].Value.ToString(); 
			DataTable Dt = caisseVente_classe.select_produit_fabrique(barcode);
			string NamePO = this.kryptonDataGridView1.CurrentRow.Cells[1].Value.ToString();
			string Price = this.kryptonDataGridView1.CurrentRow.Cells[5].Value.ToString(); 
			Object codeBarre = Dt.Rows[0][0];
			Object name_product = Dt.Rows[0][1];
			Object price_Vente = Dt.Rows[0][11];
			Object Quanite_dans_pack = Dt.Rows[0][6];
			Object cout_de_prodution = Dt.Rows[0][5];
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (!row.IsNewRow)
				{
					var cellValue = row.Cells["DgvCodeBarre"].Value;

					// Check if the cell value is not null before comparison
					if (cellValue != null && cellValue.ToString() == barcode.ToString())
					{
						row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + int.Parse(txt_qt.Text)).ToString();
						row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
												decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
						row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
												decimal.Parse(cout_de_prodution.ToString());

						GetTTL();
						txtCount.Text = getCount().ToString();
						return;
					}
				}
			}
			//this Line add new product
			float ttlPrice = float.Parse(txt_qt.Text) * float.Parse(Price.ToString());
			dataGridView1.Rows.Add(new object[] { 0, barcode, NamePO.ToString(), txt_qt.Text, Price.ToString(), ttlPrice.ToString() ,"U" ,cout_de_prodution.ToString() });

			GetTTL();
			txtCount.Text = getCount().ToString();
			txt_qt.Text = "1";
		}
		public int getCount()
		{
			int rowCount = 0;
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (!row.IsNewRow) // This checks if the row is not the new row
				{
					rowCount++;
				}
			}
			return rowCount;
		}
		public void GetTTL()
		{
			double ttl = 0;
			lbttl.Text = "";
			//lbl_price_off.Text = "";
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{

				if (!row.IsNewRow && row.Cells["dgbTtl"].Value != null)
				{
					double cellValue;
					// Try to parse the cell value to double
					if (double.TryParse(row.Cells["dgbTtl"].Value.ToString(), out cellValue))
					{
						ttl += cellValue;
					}
					else
					{
						// Handle the case where parsing fails (e.g., log the issue)
						// Optionally you can display a message or handle it as needed
					}
				}
			}
			lbttl.Text = ttl.ToString("N2");
			//lbl_price_off.Text = ttl.ToString("N2");
			txt_Versement.Text = ttl.ToString("N2");
			lb_rest.Text = calculeRest(decimal.Parse(lbttl.Text), decimal.Parse(txt_Versement.Text)).ToString();
			if (decimal.Parse(lb_rest.Text) < 0)
			{
				lb_rest.ForeColor = Color.Green;
			}
			else if (decimal.Parse(lb_rest.Text) > 0)
			{
				lb_rest.ForeColor = Color.Red;
			}

			total_HT.Text = calcule_TVA(decimal.Parse(lbttl.Text) , decimal.Parse(txtTVA.Text)).ToString();
		}
		private decimal calculeRest(decimal ttl, decimal verse)
		{
			decimal rest = ttl - verse;
			return rest;
		}
		private void kryptonDataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			
		}

		//methode page 2 منتوجات جاهزة
		private void produit_jahiz()
		{
			//string barcode = this.kryptonDataGridView2.CurrentRow.Cells[0].Value.ToString();
			//string NamePO = this.kryptonDataGridView2.CurrentRow.Cells[1].Value.ToString();
			//string Price = this.kryptonDataGridView2.CurrentRow.Cells[4].Value.ToString();
			//foreach (DataGridViewRow row in dataGridView1.Rows)
			//{
			//	if (!row.IsNewRow)
			//	{
			//		var cellValue = row.Cells["DgvCodeBarre"].Value;

			//		// Check if the cell value is not null before comparison
			//		if (cellValue != null && cellValue.ToString() == barcode.ToString())
			//		{
			//			row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + int.Parse(txt_qt.Text)).ToString();
			//			row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
			//									decimal.Parse(row.Cells["dgvAmount"].Value.ToString());

			//			GetTTL();
			//			txtCount.Text = getCount().ToString();
			//			return;
			//		}
			//	}
			//}
			////this Line add new product
			//float ttlPrice = float.Parse(txt_qt.Text) * float.Parse(Price.ToString());
			//dataGridView1.Rows.Add(new object[] { 0, barcode, NamePO.ToString(), txt_qt.Text, Price.ToString(), ttlPrice.ToString(), "U" });

			//GetTTL();
			//txtCount.Text = getCount().ToString();
			//txt_qt.Text = "1";
		}

		private void packjahiz()
		{
			//string barcode = this.kryptonDataGridView3.CurrentRow.Cells[0].Value.ToString();
			//string NamePO = this.kryptonDataGridView3.CurrentRow.Cells[1].Value.ToString();
			//string Price = this.kryptonDataGridView3.CurrentRow.Cells[4].Value.ToString();
			//foreach (DataGridViewRow row in dataGridView1.Rows)
			//{
			//	if (!row.IsNewRow)
			//	{
			//		var cellValue = row.Cells["DgvCodeBarre"].Value;

			//		// Check if the cell value is not null before comparison
			//		if (cellValue != null && cellValue.ToString() == barcode.ToString())
			//		{
			//			row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + int.Parse(txt_qt.Text)).ToString();
			//			row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
			//									decimal.Parse(row.Cells["dgvAmount"].Value.ToString());

			//			GetTTL();
			//			txtCount.Text = getCount().ToString();
			//			return;
			//		}
			//	}
			//}
			////this Line add new product
			//float ttlPrice = float.Parse(txt_qt.Text) * float.Parse(Price.ToString());
			//dataGridView1.Rows.Add(new object[] { 0, barcode, NamePO.ToString(), txt_qt.Text, Price.ToString(), ttlPrice.ToString(), "P" });

			//GetTTL();
			//txtCount.Text = getCount().ToString();
			//txt_qt.Text = "1";
		}
		private void kryptonDataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			
		}

		private void kryptonDataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			
			string barcode = this.kryptonDataGridView4.CurrentRow.Cells[0].Value.ToString();
			DataTable Dt = caisseVente_classe.select_pack_Produit_finaux_info(barcode);
			string NamePO = this.kryptonDataGridView4.CurrentRow.Cells[1].Value.ToString();
			string Price = this.kryptonDataGridView4.CurrentRow.Cells[4].Value.ToString();

			Object codeBarre = Dt.Rows[0][0];
			Object name_product = Dt.Rows[0][1];
			Object price_Vente = Dt.Rows[0][4];
			Object coutTTL = Dt.Rows[0][8];
			Object qt_dans_pack = Dt.Rows[0][9]; 
			decimal cout_produire_pack_favrique = decimal.Parse(coutTTL.ToString()) * decimal.Parse(qt_dans_pack.ToString());
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (!row.IsNewRow)
				{
					var cellValue = row.Cells["DgvCodeBarre"].Value;

					// Check if the cell value is not null before comparison
					if (cellValue != null && cellValue.ToString() == barcode.ToString())
					{
						row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + int.Parse(txt_qt.Text)).ToString();
						row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
												decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
						row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
												decimal.Parse(cout_produire_pack_favrique.ToString());

						GetTTL();
						txtCount.Text = getCount().ToString();
						return;
					}
				}
			}
			//this Line add new product
			float ttlPrice = float.Parse(txt_qt.Text) * float.Parse(Price.ToString());
			dataGridView1.Rows.Add(new object[] { 0, barcode, NamePO.ToString(), txt_qt.Text, Price.ToString(), ttlPrice.ToString(), "P", cout_produire_pack_favrique .ToString()});

			GetTTL();
			txtCount.Text = getCount().ToString();
			txt_qt.Text = "1";
		}

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			int count = 0;
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				count++;
				var cellValue = row.Cells[0].Value;
				cellValue = count;
				row.Cells[0].Value = cellValue;
			}
		}

		private void منتجاتغيرموجودةToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frm_add_diver_facturation add_divers = new frm_add_diver_facturation();
			add_divers.formVente = this;
			add_divers.ShowDialog();
		}
		public void getinformation_matier_revent()
		{
			string CodeBarrre = txt_code_barre.Text;
			DataTable Dt = new DataTable();
			Dt = caisseVente_classe.getSold_MAtier_revent(CodeBarrre);
			if (Dt.Rows.Count > 0)
			{
				Object codeBarre = Dt.Rows[0][0];
				Object name_product = Dt.Rows[0][1];
				Object price_Vente = Dt.Rows[0][15];
				Object Quanite_dans_pack = Dt.Rows[0][24];
				Object price_achat_produit_revent = Dt.Rows[0][12];
				foreach (DataGridViewRow row in dataGridView1.Rows)
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
							row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) * 
								decimal.Parse(price_achat_produit_revent.ToString());
							//------------------------------------------------------------------------------//
							if (Quanite_dans_pack.ToString() != "")
							{
								if (float.Parse(row.Cells["dgvQt"].Value.ToString()) == float.Parse(Quanite_dans_pack.ToString()))
								{
									DialogResult dg = MessageBox.Show("هل تريد بيع حزمة من هذا المنتوج مباشرة؟", "بيع بالحزمة؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
									if (dg == DialogResult.Yes)
									{
										dataGridView1.Rows.Remove(row);
										DataTable DtPack = caisseVente_classe.select_pack_revent_by_code_barre_produit(CodeBarrre);
										Object codeBarrePack = DtPack.Rows[0][0];
										Object name_productPack = DtPack.Rows[0][1];
										Object price_VentePAck = DtPack.Rows[0][4];
										Object price_achat_revent = DtPack.Rows[0][7];
										Object qt_dans_pack = DtPack.Rows[0][8]; 
										decimal price_achat_revent_pack = decimal.Parse(price_achat_revent.ToString()) * 
											decimal.Parse(qt_dans_pack.ToString());
										foreach (DataGridViewRow rowP in dataGridView1.Rows)
										{
											if (!row.IsNewRow)
											{
												var cellValued = row.Cells["DgvCodeBarre"].Value;

												// Check if the cell value is not null before comparison
												if (cellValued != null && cellValued.ToString() == codeBarrePack.ToString())
												{
													row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
													row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
																			decimal.Parse(row.Cells["dgvAmount"].Value.ToString()); 
													row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) * 
																			decimal.Parse(price_achat_revent_pack.ToString());

													GetTTL();
													txtCount.Text = getCount().ToString();

													return;
												}
											}
										}
										//this Line add new product
										dataGridView1.Rows.Add(new object[] { 0, codeBarrePack.ToString(), name_productPack.ToString(), 1, price_VentePAck.ToString(), price_VentePAck.ToString(), "P", price_achat_revent_pack .ToString()}) ;
										GetTTL();
										txtCount.Text = getCount().ToString();

										return;
									}
								}
							}
							GetTTL();
							txtCount.Text = getCount().ToString();

							return;
						}
					}
				}
				//this Line add new product
				dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "U", price_achat_produit_revent.ToString() });

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
					Object cout_de_prodution = Dt.Rows[0][5];
					foreach (DataGridViewRow row in dataGridView1.Rows)
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
								row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
														decimal.Parse(cout_de_prodution.ToString());
								if (Quanite_dans_pack.ToString() != "")
								{
									if (float.Parse(row.Cells["dgvQt"].Value.ToString()) == float.Parse(Quanite_dans_pack.ToString()))
									{
										DialogResult dg = MessageBox.Show("هل تريد بيع حزمة من هذا المنتوج مباشرة؟", "بيع بالحزمة؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
										if (dg == DialogResult.Yes)
										{
											dataGridView1.Rows.Remove(row);
											DataTable DtPack = caisseVente_classe.select_pack_produit_finaux_by_Unite(CodeBarrre);
											Object codeBarrePack = DtPack.Rows[0][0];
											Object name_productPack = DtPack.Rows[0][1];
											Object price_VentePAck = DtPack.Rows[0][4];
											Object cout_produire_unite = DtPack.Rows[0][8];
											Object qt_dans_pack = DtPack.Rows[0][9];

											decimal cout_produire_pack_favrique = decimal.Parse(cout_produire_unite.ToString()) * decimal.Parse(qt_dans_pack.ToString());
											foreach (DataGridViewRow rowP in dataGridView1.Rows)
											{
												if (!row.IsNewRow)
												{
													var cellValued = row.Cells["DgvCodeBarre"].Value;

													// Check if the cell value is not null before comparison
													if (cellValued != null && cellValued.ToString() == codeBarrePack.ToString())
													{
														row.Cells["dgvQt"].Value = (int.Parse(row.Cells["dgvQt"].Value.ToString()) + 1).ToString();
														row.Cells["dgbTtl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
																				decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
														row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
																				decimal.Parse(cout_produire_pack_favrique.ToString());
														GetTTL();
														txtCount.Text = getCount().ToString();

														return;
													}
												}
											}
											//this Line add new product
											dataGridView1.Rows.Add(new object[] { 0, codeBarrePack.ToString(), name_productPack.ToString(), 1, price_VentePAck.ToString(), price_VentePAck.ToString(), "P", cout_produire_pack_favrique.ToString() }) ;
											GetTTL();
											txtCount.Text = getCount().ToString();

											return;
										}
									}
								}
								GetTTL();
								txtCount.Text = getCount().ToString();

								return;
							}
						}
					}
					//this Line add new product
					dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "U", cout_de_prodution.ToString()}) ;

				}
				else if (Dt.Rows.Count == 0)
				{
					Dt = caisseVente_classe.select_pack_info(CodeBarrre);
					if (Dt.Rows.Count > 0)
					{

						Object codeBarre = Dt.Rows[0][0];
						Object name_product = Dt.Rows[0][1];
						Object price_Vente = Dt.Rows[0][4];
						Object price_Achat = Dt.Rows[0][7];
						Object Qt_dans_pack = Dt.Rows[0][8]; 
						decimal cout_produire_pack_favrique = decimal.Parse(price_Achat.ToString()) * decimal.Parse(Qt_dans_pack.ToString());
						foreach (DataGridViewRow row in dataGridView1.Rows)
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
									row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
															decimal.Parse(cout_produire_pack_favrique.ToString());
									GetTTL();
									txtCount.Text = getCount().ToString();

									return;
								}
							}
						}
						//this Line add new product
						dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "P", cout_produire_pack_favrique });

					}
					else if (Dt.Rows.Count == 0)
					{
						Dt = caisseVente_classe.select_pack_Produit_finaux_info(CodeBarrre);
						if (Dt.Rows.Count > 0)
						{

							Object codeBarre = Dt.Rows[0][0];
							Object name_product = Dt.Rows[0][1];
							Object price_Vente = Dt.Rows[0][4];
							Object coutTTL = Dt.Rows[0][8];
							Object qt_dans_pack = Dt.Rows[0][9];
							decimal cout_produire_pack_favrique = decimal.Parse(coutTTL.ToString()) * decimal.Parse(qt_dans_pack.ToString());

							foreach (DataGridViewRow row in dataGridView1.Rows)
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
										row.Cells["cout_ttl"].Value = int.Parse(row.Cells["dgvQt"].Value.ToString()) *
																decimal.Parse(cout_produire_pack_favrique.ToString());
										GetTTL();
										txtCount.Text = getCount().ToString();

										return;
									}
								}
							}
							//this Line add new product
							dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "P", cout_produire_pack_favrique.ToString() }) ;

						}
						else if (Dt.Rows.Count == 0)
						{
							Dt = caisseVente_classe.select_produit_by_code_barre_reserve(CodeBarrre);
							if (Dt.Rows.Count > 0)
							{

								Object codeBarre = Dt.Rows[0][0];
								Object name_product = Dt.Rows[0][1];
								Object price_Vente = Dt.Rows[0][2];

								foreach (DataGridViewRow row in dataGridView1.Rows)
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

											GetTTL();
											txtCount.Text = getCount().ToString();

											return;
										}
									}
								}
								//this Line add new product
								dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "U" });

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

									foreach (DataGridViewRow row in dataGridView1.Rows)
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

												GetTTL();
												txtCount.Text = getCount().ToString();

												return;
											}
										}
									}
									//this Line add new product
									dataGridView1.Rows.Add(new object[] { 0, codeBarre.ToString(), name_product.ToString(), 1, price_Vente.ToString(), price_Vente.ToString(), "P" });

									//MessageBox.Show("هذا المنتوج غير موجود في قاعدة البيانات");
								}

								//
							}
						}
					}
				}
			}

			GetTTL();
			txtCount.Text = getCount().ToString();
		}

		private void txt_code_barre_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				getinformation_matier_revent();
			}
			txt_code_barre.Text = "";
		}

		private void frmVente_facturation_Load(object sender, EventArgs e)
		{
			if (type == 1)
			{
				frm_debut_journe_facture debutjourne = new frm_debut_journe_facture();
				debutjourne.frmVente = this;
				debutjourne.ID_caissier = ID_caissier;
				debutjourne.ShowDialog();
				txt_code_barre.Focus();
			}
			else
			{
				this.panel1.Enabled = true;
				this.panel2.Enabled = true;
				this.panel3.Enabled = true;
				this.panel4.Enabled = true;
				this.panel5.Enabled = true;
				this.btn1.Enabled = true;
				this.BTN2.Enabled = true;
				this.BTN3.Enabled = true;
				this.BTN4.Enabled = true;
				this.BTN5.Enabled = true;
				this.BTN6.Enabled = true;
				this.BTN7.Enabled = true;
				this.BTN8.Enabled = true;
				this.BTN9.Enabled = true;
				this.txt_code_barre.Focus();
			}
			
		}
		private decimal calcule_credit_after(decimal sold_old)
		{
			decimal sold_after = decimal.Parse(lb_rest.Text);
			decimal soldnew = sold_old + sold_after;
			return soldnew;
		}
		private void clientCmb_SelectedIndexChanged(object sender, EventArgs e)
		{
			DataRowView drv = (DataRowView)clientCmb.SelectedItem;
			string sold_non_pays = drv["SOLD_NON_PAYE"].ToString();
			lb_historique_credit.Text = sold_non_pays.ToString();
			calcule_credit_after(decimal.Parse(sold_non_pays.ToString()));
			lb_new_credit.Text = calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString();
		}

		private void txt_Versement_TextChanged(object sender, EventArgs e)
		{
			lb_rest.Text = calculeRest(decimal.Parse(lbttl.Text), decimal.Parse(txt_Versement.Text)).ToString();

			decimal sold_non_pays = decimal.Parse(lb_historique_credit.Text);
			calcule_credit_after(decimal.Parse(sold_non_pays.ToString()));
			lb_new_credit.Text = calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString();
			if (decimal.Parse(lb_rest.Text) < 0)
			{
				lb_rest.ForeColor = Color.Green;
			}
			else if (decimal.Parse(lb_rest.Text) > 0)
			{
				lb_rest.ForeColor = Color.Red;
			}
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			facture_non_terminer();
			DeleteRowByCodeBarre();
			dataGridView1.Refresh();
			GetTTL();
			txtCount.Text = getCount().ToString();
		}

		private void facture_non_terminer()
		{

			decimal Sum_cout_ttl = SumColumn(dataGridView1, "cout_ttl");
			DateTime currentDateTime = DateTime.Now;
				classVente.insertFacture(
							txt_id_facture.Text,
							Convert.ToDateTime(dateTimetxt.Value),
							currentDateTime.TimeOfDay,
							Convert.ToInt32(clientCmb.SelectedValue),
							decimal.Parse(lbttl.Text),
							decimal.Parse(total_HT.Text),
							float.Parse(txtTVA.Text),
							decimal.Parse(lb_historique_credit.Text),
							decimal.Parse(txt_Versement.Text),
							decimal.Parse(lb_new_credit.Text),
							decimal.Parse(txt_remis.Text),
							float.Parse(txt_pourcentage_remise.Text),
							int.Parse(txtCount.Text),
							txt_remarque.Text,
							"فاتورة قيد الانتظار",
							id_user,
							ID_caissier,
							Sum_cout_ttl
							);
				foreach (DataGridViewRow row in dataGridView1.Rows)
				{
					if (!row.IsNewRow)
					{
						// Récupérez les valeurs nécessaires de la ligne actuelle du DataGridView
						string codeBarrePRoduit = row.Cells["DgvCodeBarre"].Value.ToString();
						float Quantitevente = float.Parse(row.Cells["dgvQt"].Value.ToString());
						decimal PrixVente = decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
						decimal PrixTotal = decimal.Parse(row.Cells["dgbTtl"].Value.ToString());
						decimal cout_ttl = decimal.Parse(row.Cells["cout_ttl"].Value.ToString());
                    string DgvType = row.Cells["DgvType"].Value.ToString();
                    string IdFacture = txt_id_facture.Text;
						// Assurez-vous de remplacer "nouvelle_quantite" par le nom réel de la colonne
						classVente.InsertVente(
												  codeBarrePRoduit,
												  Quantitevente,
												  PrixVente,
												  PrixTotal,
												  IdFacture,
                                                  cout_ttl, DgvType
                                                  );
						// Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit 
					}
				}
				MessageBox.Show("تم  تسجيل الفاتورة بنجاح");
			
		}
		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			frm_debut_journe_facture debutjourne = new frm_debut_journe_facture();
			debutjourne.frmVente = this;
			debutjourne.ShowDialog();
		}
		private decimal SumColumn(DataGridView dataGridView, string columnName)
		{
			decimal sum = 0;

			// Iterate through each row in the DataGridView
			foreach (DataGridViewRow row in dataGridView.Rows)
			{
				if (row.Cells[columnName].Value != null && row.Cells[columnName].Value != DBNull.Value)
				{
					// Try to parse the cell value to decimal and add to the sum
					if (decimal.TryParse(row.Cells[columnName].Value.ToString(), out decimal value))
					{
						sum += value;
					}
				}
			}

			return sum;
		}
		public void Facture_terminer()
			{

			decimal Sum_cout_ttl = SumColumn(dataGridView1, "cout_ttl");
			DateTime currentDateTime = DateTime.Now;
			classVente.insertFacture(
						txt_id_facture.Text,
						Convert.ToDateTime(dateTimetxt.Value),
						currentDateTime.TimeOfDay,
						Convert.ToInt32(clientCmb.SelectedValue),
						decimal.Parse(lbttl.Text),
						decimal.Parse(total_HT.Text),
						float.Parse(txtTVA.Text),
						decimal.Parse(lb_historique_credit.Text),
						decimal.Parse(txt_Versement.Text),
						decimal.Parse(lb_new_credit.Text),
						decimal.Parse(txt_remis.Text),
						float.Parse(txt_pourcentage_remise.Text),
						int.Parse(txtCount.Text),
						txt_remarque.Text,
						"فاتورة مكتملة",
						id_user,
						ID_caissier,
						Sum_cout_ttl
						);
			classCaisse.update_history_caissier(
					ID_historique,
					currentDateTime.TimeOfDay,
					decimal.Parse(lbttl.Text)
					);
			historique_Client.insert_history_client(
						Convert.ToDateTime(dateTimetxt.Value),
						Convert.ToInt32(clientCmb.SelectedValue),
                        decimal.Parse(txt_Versement.Text),
                        decimal.Parse(txt_Versement.Text),
						decimal.Parse(lb_historique_credit.Text),
						decimal.Parse(lb_new_credit.Text),
						"فاتورة جديدة",
                        txt_id_facture.Text
                        );
			historique_Client.edit_sold_client(
						Convert.ToInt32(clientCmb.SelectedValue),
						decimal.Parse(txt_Versement.Text),
						decimal.Parse(lb_new_credit.Text),
						decimal.Parse(lbttl.Text)
						);
			delte_qt_matier();
			//insert list de vente
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (!row.IsNewRow)
				{
					// Récupérez les valeurs nécessaires de la ligne actuelle du DataGridView
					string codeBarrePRoduit = row.Cells["DgvCodeBarre"].Value.ToString();
					float Quantitevente = float.Parse(row.Cells["dgvQt"].Value.ToString());
					decimal PrixVente =   decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
					decimal PrixTotal =    decimal.Parse(row.Cells["dgbTtl"].Value.ToString());
                    decimal cout_ttl = decimal.Parse(row.Cells["cout_ttl"].Value.ToString());
                    string DgvType = row.Cells["DgvType"].Value.ToString();
                    string IdFacture = txt_id_facture.Text; 
					// Assurez-vous de remplacer "nouvelle_quantite" par le nom réel de la colonne
					classVente.InsertVente(
											  codeBarrePRoduit,
											  Quantitevente,
											  PrixVente,
											  PrixTotal,
											  IdFacture, cout_ttl, DgvType
                                              );
					// Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit 
				}
			}
			MessageBox.Show("تم  تسجيل الفاتورة بنجاح");
		}
		public void delte_qt_matier()
		{
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (!row.IsNewRow)
				{
					// Récupérez les valeurs nécessaires de la ligne actuelle du DataGridView
					string idProduit = row.Cells["DgvCodeBarre"].Value.ToString();
					DataTable Dt = caisseVente_classe.select_produit_fabrique(idProduit);
					if (Dt.Rows.Count > 0)
					{
						Object codeBarre = Dt.Rows[0][0];
						Object name_product = Dt.Rows[0][1];
						Object price_Vente = Dt.Rows[0][11];
						Object Quanite_dans_pack = Dt.Rows[0][6];
						Object cout_de_prodution = Dt.Rows[0][5];
						int quantite_vnt = Convert.ToInt32(row.Cells["dgvQt"].Value); // Assurez-vous de remplacer "nouvelle_quantite" par le nom réel de la colonne 
						// Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit
						classQt_vente.delte_produit_finaux(codeBarre.ToString(), quantite_vnt);
					}
					else
					{
						Dt = caisseVente_classe.select_pack_Produit_finaux_info(idProduit);
						if (Dt.Rows.Count > 0)
						{

							Object codeBarre = Dt.Rows[0][0];
							Object name_product = Dt.Rows[0][1];
							Object price_Vente = Dt.Rows[0][4];
							Object coutTTL = Dt.Rows[0][8];
							Object qt_dans_pack = Dt.Rows[0][9]; 
							Object codeBarre_Produit = Dt.Rows[0][10];
							int quantite_vnt = Convert.ToInt32(row.Cells["dgvQt"].Value) * 
																				int.Parse(qt_dans_pack.ToString()); 
							// Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit
							classQt_vente.delte_produit_finaux(codeBarre_Produit.ToString(), quantite_vnt);
						}
					}
					
				}
			}
		}
		public void edit_fctr_termeinier()
        {
            decimal Sum_cout_ttl = SumColumn(dataGridView1, "cout_ttl");
            DateTime currentDateTime = DateTime.Now;
			classVente.edit_facture(
						txt_id_facture.Text,
						Convert.ToDateTime(dateTimetxt.Value),
						currentDateTime.TimeOfDay,
						Convert.ToInt32(clientCmb.SelectedValue),
						decimal.Parse(lbttl.Text),
						decimal.Parse(total_HT.Text),
						float.Parse(txtTVA.Text),
						decimal.Parse(lb_historique_credit.Text),
						decimal.Parse(txt_Versement.Text),
						decimal.Parse(lb_new_credit.Text),
						decimal.Parse(txt_remis.Text),
						float.Parse(txt_pourcentage_remise.Text),
						int.Parse(txtCount.Text),
						txt_remarque.Text,
						"فاتورة مكتملة",
						id_user,
						ID_caissier, 
						Sum_cout_ttl
                        );

			classCaisse.clear_vente_where_edit(txt_id_facture.Text);
			 classCaisse.update_history_caissier(
					ID_historique,
					currentDateTime.TimeOfDay,
					decimal.Parse(lbttl.Text)
					);
			historique_Client.insert_history_client(
						Convert.ToDateTime(dateTimetxt.Value),
						Convert.ToInt32(clientCmb.SelectedValue),
                        decimal.Parse(txt_Versement.Text),
                        decimal.Parse(txt_Versement.Text),
						decimal.Parse(lb_historique_credit.Text),
						decimal.Parse(lb_new_credit.Text),
						"فاتورة جديدة",
                        txt_id_facture.Text
                        );
			historique_Client.edit_sold_client(
						Convert.ToInt32(clientCmb.SelectedValue),
						decimal.Parse(txt_Versement.Text),
						decimal.Parse(lb_new_credit.Text),
						decimal.Parse(lbttl.Text)
						);
			delte_qt_matier();

			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (!row.IsNewRow)
				{
					// Récupérez les valeurs nécessaires de la ligne actuelle du DataGridView
					string codeBarrePRoduit = row.Cells["DgvCodeBarre"].Value.ToString();
					float Quantitevente = float.Parse(row.Cells["dgvQt"].Value.ToString());
					decimal PrixVente = decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
					decimal PrixTotal = decimal.Parse(row.Cells["dgbTtl"].Value.ToString());
                    decimal cout_ttl = decimal.Parse(row.Cells["cout_ttl"].Value.ToString());
                    string DgvType = row.Cells["DgvType"].Value.ToString();
                    string IdFacture = txt_id_facture.Text;
					// Assurez-vous de remplacer "nouvelle_quantite" par le nom réel de la colonne
					classVente.InsertVente(
											  codeBarrePRoduit,
											  Quantitevente,
											  PrixVente,
											  PrixTotal,
											  IdFacture, cout_ttl, DgvType
                                              );
					// Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit 
				}
			}
			MessageBox.Show("تم  تسجيل الفاتورة بنجاح");
		}
		private void btn1_Click(object sender, EventArgs e)
			{
			if (dataGridView1.Rows.Count > 0)
			{
				if(Typpped == "edit")
				{
					DateTime currentDateTime = DateTime.Now;


					edit_fctr_termeinier();
					DeleteRowByCodeBarre();
					dataGridView1.Refresh();
					GetTTL();
					txtCount.Text = getCount().ToString();
					txt_id_facture.Text = classVente.get_fctr_vnt();

					Typpped = "add";
				}
				else
				{ 
					DateTime currentDateTime = DateTime.Now;


					Facture_terminer();
					DeleteRowByCodeBarre();
					dataGridView1.Refresh();
					GetTTL();
					txtCount.Text = getCount().ToString();
					txt_id_facture.Text = classVente.get_fctr_vnt();
					Typpped = "add";
				}

			}
			else
			{
				MessageBox.Show("لاتوجد منتوجات لبيعها ");
			}
			#region update table
			if (prix1check.Checked == true)
			{
				this.kryptonDataGridView1.DataSource = ClassProduction.GET_TB_GESTION_PRODUIT_FINAUX_Prix1();
			}
			else if (prix1check.Checked == true)
			{
				this.kryptonDataGridView1.DataSource = ClassProduction.GET_TB_GESTION_PRODUIT_FINAUX_Prix2();
			}
			else if (prix1check.Checked == true)
			{
				this.kryptonDataGridView1.DataSource = ClassProduction.GET_TB_GESTION_PRODUIT_FINAUX_Prix_min();
			}
			//pack

			if (prix1check.Checked == true)
			{
				this.kryptonDataGridView4.DataSource = ClassProduction.get_tab_pack_prix1();
			}
			else if (prix1check.Checked == true)
			{
				this.kryptonDataGridView4.DataSource = ClassProduction.get_tab_pack_prix2();
			}
			else if (prix1check.Checked == true)
			{
				this.kryptonDataGridView4.DataSource = ClassProduction.get_tab_pack_prixmin();
			}
			#endregion
		}

		private void txtTVA_TextChanged(object sender, EventArgs e)
		{
			GetTTL();
		}
		private decimal CalculeNew_montant(decimal montant_Principale, decimal Montante_remisier)
		{
			decimal montant_new = montant_Principale - Montante_remisier;
			montant_new = Math.Round(montant_new, 2);
			return montant_new;
		}
		private decimal calcule_pourcentage(decimal montant_Principale, decimal Montante_remisier)
		{
			decimal pourcentage = (Montante_remisier * 100) / montant_Principale;
			pourcentage = Math.Round(pourcentage, 2);
			return pourcentage;
		}
		private void txt_remis_TextChanged(object sender, EventArgs e)
		{
			txt_new_montant =
			CalculeNew_montant(decimal.Parse(lbttl.Text), decimal.Parse(txt_remis.Text)).ToString();
			txt_pourcentage_remise.Text =
			calcule_pourcentage(decimal.Parse(lbttl.Text), decimal.Parse(txt_remis.Text)).ToString();
		}

		private void total_HT_TextChanged(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			//frm_edit_QT_facturation editFctr = new frm_edit_QT_facturation();
			//editFctr.txtBox.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
			//editFctr.frmVente = this;
			//editFctr.codebarre = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
			//editFctr.ShowDialog();
		}
		private void DeleteRowByCodeBarre(string codeBarre)
		{
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (row.Cells["DgvCodeBarre"].Value != null &&
					row.Cells["DgvCodeBarre"].Value.ToString() == codeBarre)
				{
					dataGridView1.Rows.Remove(row);
					break; // Exit the loop after removing the row
				}
			}
		}

		private void BTN2_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (dataGridView1.Rows.Count > 0)
				{

					DeleteRowByCodeBarre(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
					dataGridView1.Refresh();
					GetTTL();
					txtCount.Text = getCount().ToString();

					return;
				}
				else
				{
					MessageBox.Show("لاتوجد منتوجات  لحذفها ");
				}
			}
		}
		private void DeleteRowByCodeBarre()
		{
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				 dataGridView1.Rows.Clear();
				break; // Exit the loop after removing the row 
			}
		}
		private void BTN3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف  كل البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (dataGridView1.Rows.Count > 0)
				{

					DeleteRowByCodeBarre();
					dataGridView1.Refresh();
					GetTTL();
					txtCount.Text = getCount().ToString();

					return;
				}
				else
				{
					MessageBox.Show("الجدول فارغ");
				}
			}
		}

		private void BTN4_Click(object sender, EventArgs e)
		{
			if (dataGridView1.Rows.Count > 0)
			{
				//frm_edit_QT_facturation editFctr = new frm_edit_QT_facturation();
				//editFctr.txtBox.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
				//editFctr.frmVente = this;
				//editFctr.codebarre = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
				//editFctr.ShowDialog();
			}
			else
			{
				MessageBox.Show("يرجى تحديد المنتوج");
			}
		}

		private void BTN8_Click(object sender, EventArgs e)
		{
			PLADD.PL_Statistique.frm_add_depense addDepense = new PLADD.PL_Statistique.frm_add_depense(); 
			addDepense.iduser = id_user;
			addDepense.ShowDialog();
		}

		private void txtTVA_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
			{
				e.Handled = true;
			}
		}

		private void BTN9_Click(object sender, EventArgs e)
		{
			//frm_debut_journe_facture debutjourne = new frm_debut_journe_facture();
			//debutjourne.frmVente = this;
			//debutjourne.type = "F";
			//debutjourne.ID_historique = ID_historique;
			//debutjourne.ID_caissier = ID_caissier;
			//debutjourne.ShowDialog(); 
			this.Close();
		}

		private void BTN6_Click(object sender, EventArgs e)
		{
			frm_facture_en_Attend factr_en_attend = new frm_facture_en_Attend();
			factr_en_attend.frmVente = this;
			factr_en_attend.ShowDialog();
		}

		private void BTN7_Click(object sender, EventArgs e)
		{
			if (Typpped == "edit")
			{

			}
			else
			{
				frm_livraison_vente liv = new frm_livraison_vente();
				if (dataGridView1.Rows.Count > 0)
				{
					DateTime currentDateTime = DateTime.Now;
					Facture_terminer();

					DeleteRowByCodeBarre();
					dataGridView1.Refresh();
					GetTTL();
					txtCount.Text = getCount().ToString();

					liv.nmr_fctr = txt_id_facture.Text;
					liv.id_caisier = ID_caissier;
					liv.id_user = id_user;
					txt_id_facture.Text = classVente.get_fctr_vnt();
					liv.ShowDialog();
				}
				else
				{
					MessageBox.Show("لاتوجد منتوجات لبيعها ");
				}
			}
		}
	}
}
