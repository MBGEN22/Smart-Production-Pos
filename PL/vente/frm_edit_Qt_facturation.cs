using Smart_Production_Pos.PLADD.vente;
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
    public partial class frm_edit_Qt_facturation : Form
    {
        public frm_vente_caisse frmVente;
        public string codebarre;
        public string type;
        public string qt_danspack;
        public string price_achat_u;
        public Frm_vente_caissev5 frmVenteV5;
        public string Type;
        public frm_edit_Qt_facturation()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBox.Text = "";
            txtBox.Focus();  
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            // Check if there is any text in the TextBox
            if (!string.IsNullOrEmpty(txtBox.Text))
            {
                // Remove the last character from the TextBox
                txtBox.Text = txtBox.Text.Substring(0, txtBox.Text.Length - 1);

                // Optional: Set the cursor to the end of the text
                txtBox.SelectionStart = txtBox.Text.Length;
                txtBox.SelectionLength = 0;
            }
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + "0";
            txtBox.Focus();
        }

        private void btnpoint_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + ",";
            txtBox.Focus();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + "1";
            txtBox.Focus();
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + "2";
            txtBox.Focus();
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + "3";
            txtBox.Focus();
        }

        private void btnFor_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + "4";
            txtBox.Focus();
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtBox.Text + "5";
            txtBox.Focus();
        }

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
                            row.Cells["dgvQt"].Value = (txtBox.Text).ToString();
                            row.Cells["dgbTtl"].Value = decimal.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                    decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
                            row.Cells["cout_ttl"].Value = float.Parse(row.Cells["dgvQt"].Value.ToString()) *
                                                    float.Parse(price_achat_revent_pack.ToString());

                            frmVenteV5.GetTTL();
                            frmVenteV5.txtCount.Text = frmVenteV5.getCount().ToString();

                            frmVenteV5.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            frmVenteV5.dataGridView1.Refresh();

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
                            row.Cells["dgvQt"].Value = (txtBox.Text).ToString();
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
                }
            }
        }
    }
}
