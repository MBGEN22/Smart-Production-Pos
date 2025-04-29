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
    public partial class frm_add_quantite_dechet : Form
    {
        BL.BL_ACHAT_REVENT.BL_PRODUIT classProduit = new BL.BL_ACHAT_REVENT.BL_PRODUIT();
        public int id_user;
        public frm_add_quantite_dechet()
        {
            InitializeComponent();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            classProduit.ADD_QUANTITE_DECHET_HISTORIQUE(
                Convert.ToDateTime(dateTimePicker1.Text),
                TimeSpan.Parse(dateTimePicker2.Text),
                txtCode_barre.Text,
                float.Parse(txtQuantite.Text),
                txtlaxausse.Text,
                id_user
                );
            classProduit.ADD_QUANTITE_DECHET(
                txtCode_barre.Text,
                float.Parse(txtQuantite.Text));
            MessageBox.Show("تم الحفظ بنجاح");
            this.Close();
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }
    }
}
