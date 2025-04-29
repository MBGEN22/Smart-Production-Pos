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
    public partial class frm_adD_QT_produit_Existe : Form
    {
        BL.BL_ACHAT_REVENT.BL_ACHAT classAchat = new BL.BL_ACHAT_REVENT.BL_ACHAT();
        BL.BL_ACHAT_REVENT.BL_PRODUIT ClassProduit = new BL.BL_ACHAT_REVENT.BL_PRODUIT();
        public PL.Achat_revente.frm_stock_produit_revente frmStock;
        public frm_adD_QT_produit_Existe()
        {
            InitializeComponent();
        }
        private float calculateTheTotal(float QT_onStock , float QT_add)
        {
            float Qt_after = QT_onStock + QT_add;
            return Qt_after;
        }

        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_Qt_after.Text = calculateTheTotal(float.Parse(txt_qt_rest.Text), float.Parse(txtQ__qt_ADD.Text)).ToString();
            }
            catch
            {

            }
        }
        private decimal calcule_New_Price(decimal PriceOLd, decimal QtOld, decimal PriceNew, decimal Qt_new)
        {
            decimal PriceNew_Calculate = ((PriceOLd * QtOld) + (PriceNew * Qt_new)) / (QtOld + Qt_new);
            return PriceNew_Calculate;
        }
        private void txt_qt_rest_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_Qt_after.Text = calculateTheTotal(float.Parse(txt_qt_rest.Text), float.Parse(txtQ__qt_ADD.Text)).ToString();
            }
            catch
            {

            }
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            ClassProduit.ADD_QT_REST(txtBarcode.Text, float.Parse(txtQ__qt_ADD.Text));
            MessageBox.Show("تمت اضافةالكمية بنجاح");
            frmStock.dataGridView1.DataSource = ClassProduit.get_stock_produit_revenet();
            this.Close();
        }

        private void frm_adD_QT_produit_Existe_Load(object sender, EventArgs e)
        {
            DataTable Dt_OLD_information = new DataTable();
            Dt_OLD_information = classAchat.get_Price_and_QT_OLD(txtBarcode.Text); 
            object OldPrice_Ht = Dt_OLD_information.Rows[0][0];
            object OldPrice_ttc = Dt_OLD_information.Rows[0][1];
            object QtRest = Dt_OLD_information.Rows[0][3];
        }
    }
}
