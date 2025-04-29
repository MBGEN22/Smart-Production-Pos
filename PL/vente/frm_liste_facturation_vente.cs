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
    public partial class frm_liste_facturation_vente : Form
    {
        BL.BL_vente.BL_FACTURE_VENTE class_facture_vente = new BL.BL_vente.BL_FACTURE_VENTE();
        public frm_liste_facturation_vente()
        {
            InitializeComponent();
            dataGridView1.DataSource = class_facture_vente.list_facture_vente();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_nmr_fctr.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_client.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_TTL.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            string nmr_fctr = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            dataGridView2.DataSource = class_facture_vente.list_detaille_facture_vente(nmr_fctr);
        }
    }
}
