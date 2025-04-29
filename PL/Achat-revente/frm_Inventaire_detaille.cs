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
    public partial class frm_Inventaire_detaille : Form
    {
        BL.BL_ACHAT_REVENT.BL_PRODUIT classProduit = new BL.BL_ACHAT_REVENT.BL_PRODUIT();
        public frm_Inventaire_detaille()
        {
            InitializeComponent();
        }

        private void frm_Inventaire_detaille_Load(object sender, EventArgs e)
        {
            lbttl_rest.Text = classProduit.inventaire_Total().ToString();
            lb_ttl_Qt.Text = classProduit.inventaire_TotalQT_TTL().ToString();
            lb_ttl_vente.Text = classProduit.inventaire_TotalQT_VENTE().ToString();
            lblCount_produit.Text = classProduit.Count_Ttl_produit().ToString();

            Qt_Rest.Text = classProduit.Count_Ttl_produit_Rest().ToString();
            Qt_Vente.Text = classProduit.Count_Ttl_produit_vendue().ToString();
            Qt_Dechet.Text = classProduit.Count_Ttl_produit_dechet().ToString();

            ttl_achat_ht.Text = classProduit.inventaire_TotalQT_TTL_Achats_HT().ToString();
            Rest_achat_ht.Text = classProduit.inventaire_Total_Achats_HT_Rest_Qt().ToString();
            Vente_achat_ht.Text = classProduit.inventaire_TotalQT_VENTE_Achats_HT().ToString();

            ttl_achat_TTC.Text = classProduit.inventaire_TotalQT_TTL_Achats_TTC().ToString();
            Rest_achat_TTC.Text = classProduit.inventaire_Total_Achats_TTC_Rest_Qt().ToString();
            Vente_achat_TTC.Text = classProduit.inventaire_TotalQT_VENTE_Achats_TTC().ToString();

        }
    }
}
