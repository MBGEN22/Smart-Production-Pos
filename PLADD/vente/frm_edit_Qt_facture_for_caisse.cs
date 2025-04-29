using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Smart_Production_Pos.PL.vente;


namespace Smart_Production_Pos.PLADD.vente
{
	public partial class frm_edit_Qt_facture_for_caisse : Form
	{
		public frm_vente_caisse frmVente;
        public frm_edit_bon edit_bn ;
		public string codebarre;
		public string type;
		public string qt_danspack;
		public string price_achat_u;
		public Frm_vente_caissev5 frmVenteV5;
		public string Type;

        public frm_edit_Qt_facture_for_caisse()
		{
			InitializeComponent();
            txtBox.Focus();
            txtBox.SelectAll();
        }

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnpoint_Click(object sender, EventArgs e)
		{
            // الحصول على الإعدادات الإقليمية للنظام
            CultureInfo currentCulture = CultureInfo.CurrentCulture;

            // التحقق إذا كانت اللغة فرنسية
            if (currentCulture.TwoLetterISOLanguageName == "fr")
            {
                // إضافة الفاصلة
                txtBox.Text = txtBox.Text + ",";
                txtBox.Focus(); // إعادة التركيز على TextBox
            }
            // التحقق إذا كانت اللغة إنجليزية
            else if (currentCulture.TwoLetterISOLanguageName == "en")
            {
                // إضافة النقطة
                txtBox.Text = txtBox.Text + ".";
                txtBox.Focus(); // إعادة التركيز على TextBox
            }
        }

		private void btnZero_Click(object sender, EventArgs e)
		{
			txtBox.Text = txtBox.Text + "0";
			txtBox.Focus();
		}

		private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

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

		private void kryptonButton12_Click(object sender, EventArgs e)
		{
			if (Type=="V5") 
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
            else if (Type == "edit")
            {
                decimal price_achat_revent_pack = decimal.Parse(qt_danspack) * decimal.Parse(price_achat_u);
                foreach (DataGridViewRow row in edit_bn.dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var cellValue = row.Cells["رقم المنتوج"].Value;
                        // Check if the cell value is not null before comparison
                        if (cellValue != null && cellValue.ToString() == codebarre)
                        {
                            row.Cells["كمية المنتوج"].Value = (txtBox.Text).ToString();
                            row.Cells["السعر الكلي"].Value = decimal.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                    decimal.Parse(row.Cells["سعر البيع"].Value.ToString());
                            row.Cells["التكلفة"].Value = float.Parse(row.Cells["كمية المنتوج"].Value.ToString()) *
                                                    float.Parse(price_achat_revent_pack.ToString());

                            edit_bn.GetTTL();
                            edit_bn.txtCount.Text = edit_bn.getCount().ToString();

                            edit_bn.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            edit_bn.dataGridView1.Refresh();

                            edit_bn.txt_barcode.Focus();
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

        private void frm_edit_Qt_facture_for_caisse_Load(object sender, EventArgs e)
        {
			txtBox.Focus();
			txtBox.SelectAll();
        }

        private void frm_edit_Qt_facture_for_caisse_KeyPress(object sender, KeyPressEventArgs e)
        {
   //         if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
   //         {
   //             // إلغاء الإدخال إذا كان المفتاح غير مسموح به
   //             e.Handled = true;
   //         }
			//txtBox.Focus();
        }

        private void frm_edit_Qt_facture_for_caisse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                // التحقق من أن الـ TextBox يحتوي على نص
                if (txtBox.Text.Length > 0)
                {
                    // مسح النص بالكامل
                    txtBox.Clear();
                }

                // إلغاء الإجراء الافتراضي لـ Backspace
                e.Handled = true;
            }
        }
    }
}
