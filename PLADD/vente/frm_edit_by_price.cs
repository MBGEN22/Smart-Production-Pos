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
	public partial class frm_edit_by_price : Form
	{
		public int id;
		public frm_vente_caisse frmVente;
		public Frm_vente_caissev5 frmVenteV5; 
        public string codebarre;
        public string Type;
        public string type;
		public string qt_danspack;
		public string price_achat_u;
		public frm_edit_by_price()
		{
			InitializeComponent();
		}
		private decimal calculate(decimal price1 , decimal priceBalance)
		{
			decimal Qt_balance = priceBalance   / price1  ;
			return Qt_balance;
		}

		private void txtPRice_balance_TextChanged(object sender, EventArgs e)
		{
			try
            {
                txtQT.Text = calculate(decimal.Parse(txtPriceU.Text), decimal.Parse(txtPRice_balance.Text)).ToString("F2"); 
            }
			catch
			{

			}
		}

		private void frm_edit_by_price_Load(object sender, EventArgs e)
		{

		}
        /*
		 
                decimal price_achat_revent_pack = decimal.Parse(qt_danspack) * decimal.Parse(price_achat_u);
                foreach (DataGridViewRow row in frmVenteV5.dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var cellValue = row.Cells["DgvCodeBarre"].Value;
                        // Check if the cell value is not null before comparison
                        if (cellValue != null && cellValue.ToString() == codebarre)
                        {
                            row.Cells["dgvQt"].Value = (txtQT.Text).ToString();
                            row.Cells["dgbTtl"].Value = decimal.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                    decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
                            row.Cells["cout_ttl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                    float.Parse(price_achat_revent_pack.ToString());

                            frmVenteV5.GetTTL();
                            frmVenteV5.txtCount.Text = frmVenteV5.getCount().ToString();

                            frmVenteV5.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            frmVenteV5.dataGridView1.Refresh();

                            frmVente.txt_barcode.Focus();
                            this.Close();

                            return;
                        }
                    }
                }
		 */
        private void kryptonButton12_Click(object sender, EventArgs e)
		{
			if (Type == "V5")
			{
                decimal price_achat_revent_pack = decimal.Parse(qt_danspack) * decimal.Parse(price_achat_u);
                foreach (DataGridViewRow row in frmVenteV5.dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var cellValue = row.Cells["DgvCodeBarre"].Value;
                        // Check if the cell value is not null before comparison
                        if (cellValue != null && cellValue.ToString() == codebarre)
                        {
                            //string Quantite = txtQT.Text;
                            // Assign the quantity text to the dgvQt cell
                            row.Cells["dgvQt"].Value = txtQT.Text;

                            // Calculate and format dgvQt and dgbTtl
                            decimal quantity = decimal.Parse(row.Cells["dgvQt"].Value.ToString());
                            decimal unitPrice = decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
                            row.Cells["dgbTtl"].Value = (quantity * unitPrice).ToString("F2");

                            // Calculate and format cout_ttl
                            float totalCost = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                              float.Parse(price_achat_revent_pack.ToString());
                            row.Cells["cout_ttl"].Value = totalCost.ToString("F2");

                            // Update the total count and refresh the DataGridView
                            frmVenteV5.GetTTL();
                            frmVenteV5.txtCount.Text = frmVenteV5.getCount().ToString();

                            frmVenteV5.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            frmVenteV5.dataGridView1.Refresh();

                            // Set focus back to the barcode input
                            frmVenteV5.txt_barcode.Focus();
                            this.Close();

                            return;
                        }
                    }
                }

            }
			else
            {
                decimal price_achat_revent_pack = decimal.Parse(qt_danspack) * decimal.Parse(price_achat_u);
                foreach (DataGridViewRow row in frmVente.dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var cellValue = row.Cells["DgvCodeBarre"].Value;
                        // Check if the cell value is not null before comparison
                        if (cellValue != null && cellValue.ToString() == codebarre)
                        {
                            // Assign the quantity text to the dgvQt cell
                            row.Cells["dgvQt"].Value = txtQT.Text;

                            // Calculate and format dgvQt and dgbTtl
                            decimal quantity = decimal.Parse(row.Cells["dgvQt"].Value.ToString());
                            decimal unitPrice = decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
                            row.Cells["dgbTtl"].Value = (quantity * unitPrice).ToString("F2");

                            // Calculate and format cout_ttl
                            float totalCost = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                              float.Parse(price_achat_revent_pack.ToString());
                            row.Cells["cout_ttl"].Value = totalCost.ToString("F2");

                            // Update the total count and refresh the DataGridView
                            frmVente.GetTTL();
                            frmVente.txtCount.Text = frmVente.getCount().ToString();

                            frmVente.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            frmVente.dataGridView1.Refresh();

                            // Set focus back to the barcode input
                            frmVente.txt_barcode.Focus();
                            this.Close();

                            return;
                        }
                    }
                }
/*
                decimal price_achat_revent_pack = decimal.Parse(qt_danspack) * decimal.Parse(price_achat_u);
				foreach (DataGridViewRow row in frmVente.dataGridView1.Rows)
				{
					if (!row.IsNewRow)
					{
						var cellValue = row.Cells["DgvCodeBarre"].Value;
						// Check if the cell value is not null before comparison
						if (cellValue != null && cellValue.ToString() == codebarre)
						{
							row.Cells["dgvQt"].Value = (txtQT.Text).ToString();
							row.Cells["dgbTtl"].Value = decimal.Parse(row.Cells["dgvQt"].Value.ToString()) *
													decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
							row.Cells["cout_ttl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
													float.Parse(price_achat_revent_pack.ToString());

							frmVente.GetTTL();
							frmVente.txtCount.Text = frmVente.getCount().ToString();

							frmVente.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
							frmVente.dataGridView1.Refresh();
							frmVente.txt_barcode.Focus();

                            this.Close();

							return;
						}
					}
				}*/
			}
		}
	}
}
