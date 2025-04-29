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
    public partial class frm_Historique_dechet : Form
    {
        BL.BL_ACHAT_REVENT.BL_PRODUIT classPRoduit = new BL.BL_ACHAT_REVENT.BL_PRODUIT();
        public frm_Historique_dechet()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = classPRoduit.get_TB_historique_dechet();
        }
    }
}
