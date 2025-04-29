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
    public partial class frm_historique_achat_produitr : Form
    {
        public string id_produit;
        BL.BL_ACHAT_REVENT.BL_PRODUIT classProduit = new BL.BL_ACHAT_REVENT.BL_PRODUIT();
        public frm_historique_achat_produitr()
        {
            InitializeComponent();

        }

        private void frm_historique_achat_produitr_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = classProduit.get_list_historique_achat_produit(id_produit);
        }
    }
}
