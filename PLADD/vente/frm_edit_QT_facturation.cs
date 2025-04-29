using Smart_Production_Pos.PL.vente;
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
	public partial class frm_edit_QT_facturation : Form
	{
		public frm_facturation frmVente;
		public string codebarre; 
        public string type;
        public string qt_danspack;
        public string price_achat_u; 
        public string Type;
		public decimal original_price;//org_pric
        public frm_edit_QT_facturation()
		{
			InitializeComponent();
			txtBox.Focus();
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnpoint_Click(object sender, EventArgs e)
		{
			txtBox.Text = txtBox.Text + ",";
			txtBox.Focus();
		}

		private void btnZero_Click(object sender, EventArgs e)
		{
			txtBox.Text = txtBox.Text + "0";
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

		private void btnSixe_Click(object sender, EventArgs e)
		{
				txtBox.Text = txtBox.Text + "6";
				txtBox.Focus();
		}

		private void btnNine_Click(object sender, EventArgs e)
		{
			txtBox.Text = txtBox.Text + "9";
			txtBox.Focus();
		}

		private void btnEight_Click(object sender, EventArgs e)
		{
			txtBox.Text = txtBox.Text + "8";
			txtBox.Focus();
		}

		private void btnSeven_Click(object sender, EventArgs e)
		{
			txtBox.Text = txtBox.Text + "7";
			txtBox.Focus();
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

		private void frm_edit_QT_facturation_Load(object sender, EventArgs e)
		{
			txtBox.Focus();
		}

		private void kryptonButton12_Click(object sender, EventArgs e)
		{
            decimal price_achat_revent_pack = decimal.Parse(qt_danspack) * decimal.Parse(price_achat_u);
            foreach (DataGridViewRow row in frmVente.dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    var cellValue = row.Cells["DgvCodeBarr"].Value;
                    // Check if the cell value is not null before comparison
                    if (cellValue != null && cellValue.ToString() == codebarre)
                    {
                        row.Cells["dgvQtt"].Value = (txtBox.Text).ToString();
                        row.Cells["dgbTTTL"].Value = decimal.Parse(row.Cells["dgvQtt"].Value.ToString()) *
                                                decimal.Parse(row.Cells["dgvAmountt"].Value.ToString());
                        row.Cells["org_pric"].Value = decimal.Parse(row.Cells["dgvQtt"].Value.ToString()) *
                                                original_price;
                        row.Cells["coute_ttl"].Value = float.Parse(row.Cells["dgvQtt"].Value.ToString()) *
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
