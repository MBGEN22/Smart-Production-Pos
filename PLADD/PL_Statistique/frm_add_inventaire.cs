using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.PL_Statistique
{
    public partial class frm_add_inventaire : Form
    {
        BL.BL_CAISSE caisseVente_classe = new BL.BL_CAISSE();
        BL.BL_Statistique.bl_inventaire class_inventaire = new BL.BL_Statistique.bl_inventaire();
        public int id_user;
        public frm_add_inventaire()
        {
            InitializeComponent();
            txt_id_inventaire.Text = class_inventaire.get_inventaire_nmr();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        public void GetTTL()
        {
            double ttl_thero = 0; double ttl_phy = 0; double ttl_ecart = 0;
            txt_theorique_ttl.Text = "0";
            txt_real_ttl.Text = "0";
            txt_ecart_ttl.Text = "0";

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Cells["dgv_Qt_theo"].Value != null)
                {
                    double cellValue;
                    // Try to parse the cell value to double
                    if (double.TryParse(row.Cells["dgv_Qt_theo"].Value.ToString(), out cellValue))
                    {
                        ttl_thero += cellValue;
                    }
                    else
                    {
                        // Handle the case where parsing fails (e.g., log the issue)
                        // Optionally you can display a message or handle it as needed
                    }
                }

                if (!row.IsNewRow && row.Cells["dgv_Qt_phy"].Value != null)
                {
                    double cellValue;
                    // Try to parse the cell value to double
                    if (double.TryParse(row.Cells["dgv_Qt_phy"].Value.ToString(), out cellValue))
                    {
                        ttl_phy += cellValue;
                    }
                    else
                    {
                        // Handle the case where parsing fails (e.g., log the issue)
                        // Optionally you can display a message or handle it as needed
                    }
                }

                if (!row.IsNewRow && row.Cells["dgv_ttl_PAchat"].Value != null)
                {
                    double cellValue;
                    // Try to parse the cell value to double
                    if (double.TryParse(row.Cells["dgv_ttl_PAchat"].Value.ToString(), out cellValue))
                    {
                        ttl_ecart += cellValue;
                    }
                    else
                    {
                        // Handle the case where parsing fails (e.g., log the issue)
                        // Optionally you can display a message or handle it as needed
                    }
                }
            }
            txt_theorique_ttl.Text = ttl_thero.ToString("N2");
            txt_real_ttl.Text = ttl_phy.ToString("N2");
            txt_ecart_ttl.Text = ttl_ecart.ToString("N2");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PLADD.PL_Statistique.frm_add_product_inv add = new frm_add_product_inv();
            add.add_inventaire = this;
            add.ShowDialog();
        }
        private void DeleteRowByCodeBarre(string codeBarre)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["dgv_CodeBr"].Value != null &&
                    row.Cells["dgv_CodeBr"].Value.ToString() == codeBarre)
                {
                    dataGridView1.Rows.Remove(row);
                    break; // Exit the loop after removing the row
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هذا الخيار سيقوم بحذف  كل البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DeleteRowByCodeBarre(this.dataGridView1.CurrentRow.Cells[1].Value.ToString());
                dataGridView1.Refresh();
                GetTTL();
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            frm_Qt_product_inventaire edit_QT = new frm_Qt_product_inventaire();
            DataTable Dtt = new DataTable();
            string barcode = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Dtt = caisseVente_classe.getSold_MAtier_revent(barcode);
            if (Dtt.Rows.Count > 0)
            {
                Object codeBarre = Dtt.Rows[0][0];
                Object name_product = Dtt.Rows[0][1];
                Object Qt_rest = Dtt.Rows[0][21];
                Object price_achat_produit_revent = Dtt.Rows[0][12];

                edit_QT.lb_Codebarre_.Text = barcode;
                edit_QT.lb_product_designation.Text = name_product.ToString();
                edit_QT.Lb_Qt_logiciels.Text = Qt_rest.ToString();
                edit_QT.txt_prix_achats.Text = price_achat_produit_revent.ToString();

                //get from this datagrid view
                edit_QT.lb_Real_Qt.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                edit_QT.lb_Ecart.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                edit_QT.txt_ttl.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
                edit_QT.txt_rmrqu.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();

            }
            edit_QT.etas = "edit";
            edit_QT.form_add_Qt = this;
            edit_QT.ShowDialog();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var charMap = new Dictionary<char, char>
                    {
                    { '&', '1' },
                    { 'é', '2' },
                    { '"', '3' },
                    { '\'', '4' },
                    { '(', '5' },
                    { '-', '6' },
                    { 'è', '7' },
                    { '_', '8' },
                    { 'ç', '9' },
                    { 'à', '0' }
                };

                // Use StringBuilder to build the converted string.
                var convertedCodeBarre = new StringBuilder(txt_barcode.Text.Length);

                foreach (char c in txt_barcode.Text)
                {
                    // If the character is in the dictionary, replace it; otherwise, keep it the same.
                    if (charMap.TryGetValue(c, out char replacement))
                    {
                        convertedCodeBarre.Append(replacement);
                    }
                    else
                    {
                        convertedCodeBarre.Append(c);
                    }
                }

                // Resulting converted code
                string bar = convertedCodeBarre.ToString();

                getinformation_matier_revent(bar);
                txt_barcode.Clear(); // تنظيف الـ TextBox بعد استدعاء الدالة
                e.Handled = true; // منع إصدار الصوت
            }
        }
        public void getinformation_matier_revent(string CodeBarrre)
        {
            DataTable Dt = new DataTable();
            Dt = caisseVente_classe.getSold_MAtier_revent(CodeBarrre);
            if (Dt.Rows.Count > 0)
            {
                Object codeBarre = Dt.Rows[0][0];
                Object name_product = Dt.Rows[0][1];  
                Object Qt_rest = Dt.Rows[0][21]; 
                Object price_achat_produit_revent = Dt.Rows[0][12];

                this.dataGridView1.Rows.Add(new object[] {
                            0,
                            codeBarre.ToString(),
                            name_product.ToString(),
                            Qt_rest.ToString(),
                            Qt_rest.ToString(),
                            "0",
                            price_achat_produit_revent.ToString(),
                            "0",
                            ""
                            });
                GetTTL();

            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            SoundPlayer sp = new SoundPlayer(Smart_Production_Pos.Properties.Resources.complete_sound_effectfree1);
            if (MessageBox.Show("هل قمت بالانتهاء من عملية الجرد ؟ هذا الخيار سيحفظ العملية", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                class_inventaire.INSERT_INVENTAIRE_PRINCIPAL(
                    txt_id_inventaire.Text,
                    Convert.ToDateTime(dateTimePicker1.Text),
                    TimeSpan.Parse(dateTimePicker2.Text),
                    decimal.Parse(txt_theorique_ttl.Text),
                    decimal.Parse(txt_real_ttl.Text),
                    decimal.Parse(txt_ecart_ttl.Text),
                    txt_observation.Text,
                    id_user
                    );

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        // Récupérez les valeurs nécessaires de la ligne actuelle du DataGridView

                        string CODEBARRE_PRODUIT =row.Cells["dgv_CodeBr"].Value.ToString();
                        decimal QUANTITE_THERORIQUE =decimal.Parse(row.Cells["dgv_Qt_theo"].Value.ToString());
                        decimal QUANTITE_PHY =decimal.Parse(row.Cells["dgv_Qt_phy"].Value.ToString());
                        decimal ECART =decimal.Parse(row.Cells["dgv_Ecart"].Value.ToString());
                        decimal PU =decimal.Parse(row.Cells["dgv_PU_achat"].Value.ToString());
                        decimal P_TTL_ECART = decimal.Parse(row.Cells["dgv_ttl_PAchat"].Value.ToString());
                        string OBSERVATION =row.Cells["dgv_remrque"].Value.ToString();
                        string ID_PRINCIPALE_INVENTAIRE =txt_id_inventaire.Text;

                          
                        // Assurez-vous de remplacer "nouvelle_quantite" par le nom réel de la colonne
                        class_inventaire.INSERT_DETAILLE_INVENTAIRE(
                                                  CODEBARRE_PRODUIT,
                                                  QUANTITE_THERORIQUE,
                                                  QUANTITE_PHY,
                                                  ECART,
                                                  PU,
                                                  P_TTL_ECART,
                                                  OBSERVATION,
                                                  ID_PRINCIPALE_INVENTAIRE
                                                  );
                        // Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit 
                    }
                }
                MessageBox.Show("تم حفظ الجرد بنجاح");
                sp.Play();
                this.Close();
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("هذه الخاصية ستكون متوفرة في التحديث القادم ان شاء الله");
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}