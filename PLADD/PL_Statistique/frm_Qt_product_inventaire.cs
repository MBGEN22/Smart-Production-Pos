using Smart_Production_Pos.report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.PL_Statistique
{
    public partial class frm_Qt_product_inventaire : Form
    {
        public frm_Qt_product_inventaire()
        {
            InitializeComponent();
        }
        public string etas;
        public frm_add_inventaire form_add_Qt;
        public frm_add_product_inv frm_add_produt;
        
        private float calcule_Ecart(float Qt_theo , float Real)
        {
            float ecart =  Real - Qt_theo;
            return ecart;
        }
        private float Calcule_Ttl (float ecart ,float prix_achat)
        {
            float ttl = ecart * prix_achat;
            return ttl;
        }
        private void frm_Qt_product_inventaire_Load(object sender, EventArgs e)
        {

        }

        private void lb_Real_Qt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float num1 = float.Parse(Lb_Qt_logiciels.Text);
                float num2 = float.Parse(lb_Real_Qt.Text);
                lb_Ecart.Text = calcule_Ecart(num1 , num2).ToString();
                txt_ttl.Text = Calcule_Ttl(float.Parse(lb_Ecart.Text), float.Parse(txt_prix_achats.Text)).ToString();
            }
            catch
            {
                lb_Real_Qt.Text = "0";
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (etas == "edit")
            {
                foreach (DataGridViewRow row in form_add_Qt.dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var cellValue = row.Cells["dgv_CodeBr"].Value;
                        // Check if the cell value is not null before comparison
                        if (cellValue != null && cellValue.ToString() == lb_Codebarre_.Text)
                        {
                            row.Cells["dgv_Qt_phy"].Value = lb_Real_Qt.Text;
                            row.Cells["dgv_Ecart"].Value = lb_Ecart.Text;
                            row.Cells["dgv_PU_achat"].Value = txt_prix_achats.Text;
                            row.Cells["dgv_ttl_PAchat"].Value = txt_ttl.Text;
                            row.Cells["dgv_remrque"].Value = txt_rmrqu.Text; 
                            form_add_Qt.GetTTL();
                            this.Close();

                            return;
                        }
                    }
                }
            }
            else
            {
                form_add_Qt.dataGridView1.Rows.Add(new object[] {
                            0,
                            lb_Codebarre_.Text,
                            lb_product_designation.Text,
                            Lb_Qt_logiciels.Text,
                            lb_Real_Qt.Text,
                            lb_Ecart.Text,
                            txt_prix_achats.Text,
                            txt_ttl.Text,
                            txt_rmrqu.Text
                            });
                form_add_Qt.GetTTL();
                frm_add_produt.Close();
                this.Close(); 
            }
        }
    }
}
