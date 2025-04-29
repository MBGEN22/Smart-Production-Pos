using ComponentFactory.Krypton.Toolkit;
using Smart_Production_Pos.BL.BL_FICHIER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Achat_revente
{
    public partial class frm_edit_fctr_achat : Form
    {
        BL.BL_ACHAT_REVENT.BL_PRODUIT classProduit = new BL.BL_ACHAT_REVENT.BL_PRODUIT();
        BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
        BL.BL_ACHAT_REVENT.BL_facture classFacture = new BL.BL_ACHAT_REVENT.BL_facture();
        BL.BL_edi_article edit_article = new BL.BL_edi_article();
        float Qt_OLD ,QT_new  ,Qt_deference;
        BL.BL_ACHAT_REVENT.BL_ACHAT classAchat = new BL.BL_ACHAT_REVENT.BL_ACHAT();
        int id;
        public frm_edit_fctr_achat()
        {
            InitializeComponent();
            cmbfrnse.DisplayMember = "frnsr";
            cmbfrnse.ValueMember = "ID";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm_edit_fctr_achat_Load(object sender, EventArgs e)
        { 
            this.dataGridView1.DataSource = classFacture.get_detaiile_fctr(txt_id_fctr.Text);
        }

        private void txt_Versement_Click(object sender, EventArgs e)
        {
            txt_Versement.SelectAll();
        }

        private void txtTotalHT_Click(object sender, EventArgs e)
        {
            txtTotalHT.SelectAll();
        }

        private void txtTotalTTC_Click(object sender, EventArgs e)
        { 
            txtTotalTTC.SelectAll();
        }

        private void credit_OLD_Click(object sender, EventArgs e)
        { 
            credit_OLD.SelectAll();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
            txt_achat_ht.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_achat_ttc.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txt_tva.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtNewQt.Enabled = true;
        }

        public void GetTTL()
        {
            double ttlTTC = 0;
            double tttlHT = 0;
             

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (!row.IsNewRow && row.Cells[6].Value != null)
                {
                    double cellValue;
                    // Try to parse the cell value to double
                    if (double.TryParse(row.Cells[8].Value.ToString(), out cellValue))
                    {
                        ttlTTC += cellValue;
                    }
                    if (double.TryParse(row.Cells[7].Value.ToString(), out cellValue))
                    {
                        tttlHT += cellValue;
                    }
                    else
                    {
                        // Handle the case where parsing fails (e.g., log the issue)
                        // Optionally you can display a message or handle it as needed
                    }
                }
            }
            txt_Versement.Text = ttlTTC.ToString("N2");
            txtTotalHT.Text = tttlHT.ToString("N2");
            txtTotalTTC.Text = ttlTTC.ToString("N2");
        }
        private void kryptonButton2_Click(object sender, EventArgs e)
        {

        }
        public decimal calcule_TVA(decimal PrixeTTc, decimal TVA)
        {
            decimal priceHT = PrixeTTc / (1 + (TVA / 100));
            priceHT = Math.Round(priceHT, 2);
            return priceHT;
        }
        private void txt_achat_ttc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_achat_ht.Text = calcule_TVA(
              decimal.Parse(txt_achat_ttc.Text),
              decimal.Parse(txt_tva.Text)
              ).ToString();
            }
            catch
            {
            }
        }

        private void txt_tva_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_achat_ht.Text = calcule_TVA(
              decimal.Parse(txt_achat_ttc.Text),
              decimal.Parse(txt_tva.Text)
              ).ToString();
            }
            catch
            {
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string idProduit = this.dataGridView1.CurrentRow.Cells["رقم المنتوج"].Value.ToString();
            DataTable dtProduit = new DataTable();
            dtProduit = classProduit.get_stock_produit_revenet_for_edit(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
            object QT_Vente = dtProduit.Rows[0][20];
            float QT_Ventee = float.Parse(QT_Vente.ToString());
            float quantite_achat = float.Parse(this.dataGridView1.CurrentRow.Cells["الكمية"].Value.ToString());
            float quantite_rest = float.Parse(this.dataGridView1.CurrentRow.Cells["الكمية"].Value.ToString());
            float qte_rest_original = quantite_rest - quantite_achat;
            classAchat.delete_produit_revente_from_list_achat((int)this.dataGridView1.CurrentRow.Cells[0].Value);
            if (QT_Ventee == 0)
            {
                classAchat.delete_caisse_new_pro(idProduit);
            }
            else
            {
                classAchat.edit_matier_on_caisse(idProduit, quantite_achat, qte_rest_original);
            }
            this.dataGridView1.DataSource = classFacture.get_detaiile_fctr(txt_id_fctr.Text);
            MessageBox.Show("تم حذف المنتج بنجاح"); 
            GetTTL();
        }

        private void frm_edit_fctr_achat_FormClosing(object sender, FormClosingEventArgs e)
        {
            classAchat.update_facture_achat(
                    txt_id_fctr.Text,
                    Convert.ToDateTime(kryptonDateTimePicker1.Value),
                    Convert.ToInt32(cmbfrnse.SelectedValue),
                    Convert.ToInt32(txt_nmbre_produit.Text),
                    decimal.Parse(txt_Versement.Text),
                    decimal.Parse(txtTotalTTC.Text), 
                    decimal.Parse(txtTotalHT.Text),
                    decimal.Parse(credit_OLD.Text),
                    decimal.Parse(credit_new.Text));
            edit_article.edit_historique_payment(
                txt_id_fctr.Text,
                decimal.Parse(txt_Versement.Text),
                    decimal.Parse(credit_OLD.Text),
                    decimal.Parse(credit_new.Text));
            MessageBox.Show("تم تحديث الفاتورة بنجاح");
        }

        private void txt_Versement_TextChanged(object sender, EventArgs e)
        {
            calculate();
        }
        public void calculate()
        {
            decimal oldCredit = decimal.Parse(credit_OLD.Text);
            decimal rest = decimal.Parse(txtTotalTTC.Text) - decimal.Parse(txt_Versement.Text);
            decimal newCredit = oldCredit + rest;
            credit_new.Text = newCredit.ToString(); 
        }
        private void credit_new_Click(object sender, EventArgs e)
        {
            credit_new.SelectAll();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        { 
                string idProduit = this.dataGridView1.CurrentRow.Cells["رقم المنتوج"].Value.ToString();
                Qt_OLD = float.Parse(this.dataGridView1.CurrentRow.Cells["الكمية"].Value.ToString());
                QT_new = float.Parse(txtNewQt.Text);
                Qt_deference = QT_new - Qt_OLD;
                edit_article.edit_Article(idProduit, Qt_deference);
                edit_article.edit_achat(id, Qt_deference, decimal.Parse(txt_achat_ht.Text), decimal.Parse(txt_achat_ttc.Text), decimal.Parse(txt_tva.Text)); 
                this.dataGridView1.DataSource = classFacture.get_detaiile_fctr(txt_id_fctr.Text); 
                MessageBox.Show("تم تحديث كميو المنتج بنجاح");
                txtNewQt.Enabled = false ; 
                GetTTL(); 
        }
    }
}
