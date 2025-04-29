using Smart_Production_Pos.PLADD.Achat_revente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos
{
    public partial class frm_barcodeempty : Form
    {
        public frm_barcodeempty()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_Add_stock_sans_facture add_sans_facture = new frm_Add_stock_sans_facture();
            add_sans_facture.Type = "A";
            add_sans_facture.ShowDialog();
        }
    }
}
