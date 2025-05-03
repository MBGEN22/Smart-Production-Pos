using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Smart_Production_Pos.PL.vente;

namespace Smart_Production_Pos.PLADD.vente
{
    public partial class frm_change_Price : Form
    {
        public frm_vente_caisse frmVente;
        public frm_edit_bon frm_edit_bon;
        public string codebarre;
        public decimal price_min;
        public string Typee;
        public frm_change_Price()
        {
            InitializeComponent();
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            decimal price = decimal.Parse(txt_new_montant.Text); 
            if(Properties.Settings.Default.check_price_min == "true")
            {
                if (price < price_min)
                {
                    MessageBox.Show("عذرا لايمكنك البيع بثمن أقل من الثمن الادنى", "سعر البيع اقل من الثمن الادنى", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Typee == "edit")
                    {
                        foreach (DataGridViewRow row in frm_edit_bon.dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                var cellValue = row.Cells["رقم المنتوج"].Value;
                                // Check if the cell value is not null before comparison
                                if (cellValue != null && cellValue.ToString() == codebarre)
                                {
                                    row.Cells["سعر البيع"].Value = (txt_new_montant.Text).ToString();
                                    row.Cells["السعر الكلي"].Value = decimal.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                                decimal.Parse(row.Cells["سعر البيع"].Value.ToString());
                                    frm_edit_bon.GetTTL();
                                    frm_edit_bon.txtCount.Text = frm_edit_bon.getCount().ToString();
                                    frm_edit_bon.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                                    frm_edit_bon.dataGridView1.Refresh();
                                    this.Close();
                                    return;
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
                                var cellValue = row.Cells["DgvCodeBarre"].Value;
                                // Check if the cell value is not null before comparison
                                if (cellValue != null && cellValue.ToString() == codebarre)
                                {
                                    row.Cells["dgvAmount"].Value = (txt_new_montant.Text).ToString();
                                    row.Cells["dgbTtl"].Value = decimal.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                                decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
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
            }
            else
            {
                foreach (DataGridViewRow row in frmVente.dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var cellValue = row.Cells["DgvCodeBarre"].Value;
                        // Check if the cell value is not null before comparison
                        if (cellValue != null && cellValue.ToString() == codebarre)
                        {
                            row.Cells["dgvAmount"].Value = (txt_new_montant.Text).ToString();
                            row.Cells["dgbTtl"].Value = decimal.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                        decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
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

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
