using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.Achat_revente
{
    public partial class frm_calcule_by_pack_sans_fctr : Form
    {
        public PLADD.Achat_revente.frm_Add_stock_sans_facture add_achat;

        public frm_calcule_by_pack_sans_fctr()
        {
            InitializeComponent();
        }
        public decimal calcule_TVA(decimal PrixeTTc, decimal TVA)
        {
            decimal priceHT = PrixeTTc / (1 + (TVA / 100));
            return priceHT;
        }
        private decimal calculeTotam_Qt(decimal Qt_dans_pack, decimal QT_de_pack)
        {
            decimal Qt_total = Qt_dans_pack * QT_de_pack;
            return Qt_total;
        }
        private decimal Calcule_Total_Price_u(decimal price_pack, decimal nmbre_pack)
        {
            decimal PriceU = price_pack * nmbre_pack;
            return PriceU;
        }
        private decimal CalculePrice_u(decimal PriceTotal, decimal Qt_ttl)
        {
            decimal PriceU = PriceTotal / Qt_ttl;
            return PriceU;
        }
        private void txt_achat_ttc_pack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_achat_ht_pack.Text = calcule_TVA(
                decimal.Parse(txt_achat_ttc_pack.Text),
                decimal.Parse(txt_achat_TVA.Text)
                ).ToString();
            }
            catch
            {
            }
        }

        private void txt_achat_TVA_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_achat_ht_pack.Text = calcule_TVA(
                decimal.Parse(txt_achat_ttc_pack.Text),
                decimal.Parse(txt_achat_TVA.Text)
                ).ToString();
            }
            catch
            {
            }
        }

        private void nmbre_u_dans_pack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal total = calculeTotam_Qt(decimal.Parse(nmbre_u_dans_pack.Text), decimal.Parse(QT_pack.Text));
                string formattedTotal = total.ToString("0.00"); // This formats the decimal to have two digits after the decimal point
                Qt_total_of_product.Text = formattedTotal;
                //
                if (radioButton1.Checked == true)
                {
                    price_achat_HT.Text =
                    CalculePrice_u(decimal.Parse(txt_achat_ht_pack.Text), decimal.Parse(nmbre_u_dans_pack.Text)).ToString("F2");
                    price_achat_TTC.Text =
                    CalculePrice_u(decimal.Parse(txt_achat_ttc_pack.Text), decimal.Parse(nmbre_u_dans_pack.Text)).ToString("F2");
                }
                else if (radioButton2.Checked == true)
                {
                    price_achat_HT.Text =
                    CalculePrice_u(decimal.Parse(Total_HT_pack.Text), decimal.Parse(Qt_total_of_product.Text)).ToString("F2");
                    price_achat_TTC.Text =
                    CalculePrice_u(decimal.Parse(price_achat_TTC.Text), decimal.Parse(Qt_total_of_product.Text)).ToString("F2");
                }
            }
            catch
            {
            }
        }

        private void QT_pack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Total_HT_pack.Text =
            Calcule_Total_Price_u(decimal.Parse(txt_achat_ht_pack.Text), decimal.Parse(QT_pack.Text)).ToString();
                //
                Total_TTC_pack.Text =
                Calcule_Total_Price_u(decimal.Parse(txt_achat_ttc_pack.Text), decimal.Parse(QT_pack.Text)).ToString();
                //
                Qt_total_of_product.Text =
                calculeTotam_Qt(decimal.Parse(nmbre_u_dans_pack.Text), decimal.Parse(QT_pack.Text)).ToString();
            }
            catch
            {
            }
        }

        private void Total_HT_pack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal total = calculeTotam_Qt(decimal.Parse(nmbre_u_dans_pack.Text), decimal.Parse(QT_pack.Text));
                string formattedTotal = total.ToString("0.00"); // This formats the decimal to have two digits after the decimal point
                Qt_total_of_product.Text = formattedTotal;
                //
                if (radioButton1.Checked == true)
                {
                    price_achat_HT.Text =
                    CalculePrice_u(decimal.Parse(txt_achat_ht_pack.Text), decimal.Parse(nmbre_u_dans_pack.Text)).ToString("F2");
                    price_achat_TTC.Text =
                    CalculePrice_u(decimal.Parse(txt_achat_ttc_pack.Text), decimal.Parse(nmbre_u_dans_pack.Text)).ToString("F2");
                }
                else if (radioButton2.Checked == true)
                {
                    price_achat_HT.Text =
                    CalculePrice_u(decimal.Parse(Total_HT_pack.Text), decimal.Parse(Qt_total_of_product.Text)).ToString("F2");
                    price_achat_TTC.Text =
                    CalculePrice_u(decimal.Parse(price_achat_TTC.Text), decimal.Parse(Qt_total_of_product.Text)).ToString("F2");
                }
            }
            catch
            {
            }
        }

        private void Total_TTC_pack_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Total_HT_pack.Text =
            Calcule_Total_Price_u(decimal.Parse(txt_achat_ht_pack.Text), decimal.Parse(QT_pack.Text)).ToString();
                //
                Total_TTC_pack.Text =
                Calcule_Total_Price_u(decimal.Parse(txt_achat_ttc_pack.Text), decimal.Parse(QT_pack.Text)).ToString();
                //
                Qt_total_of_product.Text =
                calculeTotam_Qt(decimal.Parse(nmbre_u_dans_pack.Text), decimal.Parse(QT_pack.Text)).ToString();
            }
            catch
            {
            }
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            add_achat.txt_achat_ht.Text = price_achat_HT.Text;
            add_achat.txt_achat_ttc.Text = price_achat_TTC.Text;
            add_achat.txt_tva.Text = txt_achat_TVA.Text;
            add_achat.txt_qt.Text = Qt_total_of_product.Text;
            //add_achat.txt_total_ht.Text = Total_HT_pack.Text;
            //add_achat.txt_total_ttc.Text = Total_TTC_pack.Text;
            add_achat.qt_dans_pack_txt.Text = nmbre_u_dans_pack.Text;
            add_achat.nmbre_pack.Text = QT_pack.Text;
            add_achat.txt_qt.Text = Qt_total_of_product.Text;

            this.Close();
        }

        private void txt_achat_ttc_pack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_achat_TVA.Focus();
            }
        }

        private void txt_achat_TVA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_achat_ht_pack.Focus();
            }
        }

        private void txt_achat_ht_pack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                nmbre_u_dans_pack.Focus();
            }
        }

        private void nmbre_u_dans_pack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                QT_pack.Focus();
            }
        }

        private void QT_pack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_achat.txt_achat_ht.Text = price_achat_HT.Text;
                add_achat.txt_achat_ttc.Text = price_achat_TTC.Text;
                add_achat.txt_tva.Text = txt_achat_TVA.Text;
                add_achat.txt_qt.Text = Qt_total_of_product.Text;
                //add_achat.txt_total_ht.Text = Total_HT_pack.Text;
                //add_achat.txt_total_ttc.Text = Total_TTC_pack.Text;
                add_achat.qt_dans_pack_txt.Text = nmbre_u_dans_pack.Text;
                add_achat.nmbre_pack.Text = QT_pack.Text;
                add_achat.txt_qt.Text = Qt_total_of_product.Text;

                this.Close();
            }
        }
    }
}
