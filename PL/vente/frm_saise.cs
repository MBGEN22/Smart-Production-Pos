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
    public partial class frm_saise : Form
    {
        public frm_facturation VenteCaisse;
        float price_Vente;
        public frm_detaille_product_enter frm_detaille_prdct;
        public string unite;
        public frm_saise()
        {
            InitializeComponent();
        }

        public float calcuate_unite(float Qt_pack , float Qt_dans_pack)
        {
            float Qt_U = Qt_dans_pack * Qt_pack;
            return Qt_U;
        }

        private void txt_N_colis_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_Qt.Text = calcuate_unite(float.Parse(txt_N_colis.Text), float.Parse(txt_colissage.Text)).ToString(); 
            }
            catch
            {

            }
        }

        private void txt_Qt_TextChanged(object sender, EventArgs e)
        {
              
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" هذا الخيار سيقوم بغلق النافذةوالالغاء هل انت متأكد", "غلق الواجهة  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in VenteCaisse.dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    var cellValue = row.Cells["DgvCodeBarr"].Value;

                    // Check if the cell value is not null before comparison
                    if (cellValue != null && cellValue.ToString() == txt_code_barre.Text)
                    {
                        row.Cells["dgvQtt"].Value = (int.Parse(row.Cells["dgvQtt"].Value.ToString()) + float.Parse(txt_Qt.Text)).ToString();
                        row.Cells["dgbTTTL"].Value = int.Parse(row.Cells["dgvQtt"].Value.ToString()) *
                                                decimal.Parse(row.Cells["dgvAmountt"].Value.ToString());
                        row.Cells["coute_ttl"].Value = int.Parse(row.Cells["dgvQtt"].Value.ToString()) *
                            decimal.Parse(priceachat.Text);
                        VenteCaisse.GetTTL();
                        VenteCaisse.txtCount.Text = VenteCaisse.getCount().ToString();
                        frm_detaille_prdct.Close();
                        this.Close();
                        return;;
                    }
                }
            }
            if (rd_prix_1.Checked)
            {
                price_Vente = float.Parse(txt_prix_vente_1.Text);
            }
            else if (rd_prix_2.Checked)
            {
                price_Vente = float.Parse(txt_prix_vente_2.Text);
            }
            else if (rd_prix_3.Checked)
            {
                price_Vente = float.Parse(txt_prix_vente_3.Text); 
            }
            else if (rd_prix_pack.Checked)
            {
                price_Vente = float.Parse(txt_prix_vente_pack.Text);
            }

            VenteCaisse.dataGridView1.Rows.Add
            (new object[] 
                 {
                 "0",//dgvN;
                 txt_code_barre.Text,//DgvCodeBarr
                 txt_designation.Text,//dgvName
                 txt_N_colis.Text,//NCOLIS
                 txt_colissage.Text,//COLISAGE
                 txt_Qt.Text ,//dgvQtt 
                 unite,
                 price_Vente.ToString(),//dgvAmountt
                 (decimal.Parse(price_Vente.ToString())*(decimal.Parse(txt_Qt.Text))),//dgbTTTL 
                 "0".ToString(),//Remise
                 "0".ToString(),//prsent_remise
                  (decimal.Parse(price_Vente.ToString())*(decimal.Parse(txt_Qt.Text))), //price_org
                 "U".ToString(),//DgvType
                  (decimal.Parse(priceachat.Text)*(decimal.Parse(txt_Qt.Text)))//coute_ttl
                  } 
            );
            VenteCaisse.GetTTL();
            frm_detaille_prdct.Close();
            this.Close(); 
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void rd_prix_pack_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_prix_vente_pack.Text == "/")
            {
                MessageBox.Show("لايمكن تفعيل سعر الحزمة لهذا المنتوج");
                rd_prix_1.Checked = true;
            }
        }

        private void txt_Qt_KeyDown(object sender, KeyEventArgs e)
        {
            txt_N_colis.Text = "";
            txt_colissage.Text = "";
        }

        private void frm_saise_Load(object sender, EventArgs e)
        {

        }
    }
    
}
