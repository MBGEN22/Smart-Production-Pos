using System;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.vente
{
    public partial class frm_remise_produit_facturation : Form
    {
        public frm_facturation frmVente;
        public string codebarre;
        public decimal old_price;
        public decimal prcent;
        public decimal price_min;
        public frm_remise_produit_facturation()
        {
            InitializeComponent();
        }

        private decimal calcule_remise(decimal original_price , decimal new_remise)
        {
            decimal remise = original_price - new_remise;
            return remise;
        }

        private decimal calcule_prcnt_remise(decimal Original_price, decimal new_price)
        {
            decimal prcnt = 100 - ((new_price * 100) / Original_price);
            return prcnt;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            decimal price = decimal.Parse(txt_new_montant.Text);
            old_price = decimal.Parse(txt_price_product.Text);
            if (Properties.Settings.Default.check_price_min == "true")
            {
                if (price < price_min)
                {
                    MessageBox.Show("عذرا لايمكنك البيع بثمن أقل من الثمن الادنى", "سعر البيع اقل من الثمن الادنى", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    foreach (DataGridViewRow row in frmVente.dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            var cellValue = row.Cells["DgvCodeBarr"].Value;
                            // Check if the cell value is not null before comparison
                            if (cellValue != null && cellValue.ToString() == codebarre)
                            {
                                row.Cells["dgvAmountt"].Value = (txt_new_montant.Text).ToString();
                                row.Cells["dgbTTTL"].Value = decimal.Parse(row.Cells["dgvQtt"].Value.ToString()) *
                                                            decimal.Parse(row.Cells["dgvAmountt"].Value.ToString());
                                row.Cells["P_remise"].Value = calcule_remise(old_price , price).ToString();
                                //row.Cells[]
                                frmVente.GetTTL();
                                frmVente.txtCount.Text = frmVente.getCount().ToString();
                                frmVente.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                                frmVente.dataGridView1.Refresh();
                                this.Close();
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in frmVente.dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var cellValue = row.Cells["DgvCodeBarr"].Value;
                        // Check if the cell value is not null before comparison
                        if (cellValue != null && cellValue.ToString() == codebarre)
                        {
                            row.Cells["dgvAmountt"].Value = (txt_new_montant.Text).ToString();
                            row.Cells["dgbTTTL"].Value = decimal.Parse(row.Cells["dgvQtt"].Value.ToString()) *
                                                        decimal.Parse(row.Cells["dgvAmountt"].Value.ToString());
                            row.Cells["P_remise"].Value = calcule_remise(old_price, price).ToString();
                            row.Cells["prsnt_remise"].Value = txt_prcnt.Text;
                            frmVente.GetTTL();
                            frmVente.txtCount.Text = frmVente.getCount().ToString();
                            frmVente.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            frmVente.dataGridView1.Refresh();
                            this.Close();
                            return;
                        }
                    }
                }
            }
        }

        private void txt_new_montant_TextChanged(object sender, EventArgs e)
        {
            try
            {
                prcent = calcule_prcnt_remise(decimal.Parse(txt_price_product.Text), decimal.Parse(txt_new_montant.Text));
                txt_prcnt.Text = prcent.ToString();

            }
            catch
            { 
                
            }
        }
    }
}
