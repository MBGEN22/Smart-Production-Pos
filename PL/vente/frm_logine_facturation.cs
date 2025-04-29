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
    
    public partial class frm_logine_facturation : Form
    {
        BL.BL_FICHIER.BL_CAISSIER classclient = new BL.BL_FICHIER.BL_CAISSIER();
        BL.BL_vente.BL_SP_LOGINE_Caisse classLogineCaisse = new BL.BL_vente.BL_SP_LOGINE_Caisse();
        PL.Fichier.frm_caissier frm_caissier = new PL.Fichier.frm_caissier();
        TAB_CONTROL.Tab_fichier tab_ficher = new TAB_CONTROL.Tab_fichier();
        public int id_user;
        public string Type;
        public frm_logine_facturation()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_logine_facturation_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = classclient.get_tb_caissier();
            if (dt.Rows.Count == 0)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_caissier.pn_caissier);
                MessageBox.Show("يجب أولا ان تقوم باضافة قابضين " + "الملفات-----> القابضين");
            }
            else
            {
                txtUser.Focus();
            }
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
             
            DataTable Dt = classLogineCaisse.LOGIN(txtUser.Text, txtPassword.Text);
            if (Dt.Rows.Count > 0)
            {
                Object ID_Caissier = Dt.Rows[0][0];
                Object NAME_caiss = Dt.Rows[0][1];
                Object prename_caissier = Dt.Rows[0][2];
                PL.vente.frm_facturation frmCaisse = new PL.vente.frm_facturation();

                DataTable dt2 = new DataTable();
                dt2 = classLogineCaisse.check_if_caisse_renter(Convert.ToInt32(ID_Caissier), DateTime.Today);
                if (dt2.Rows.Count > 0)
                {
                    object id_historique = dt2.Rows[0][0];
                    frmCaisse.type = 2;
                    frmCaisse.ID_caissier = Convert.ToInt32(ID_Caissier);
                    frmCaisse.txt_name_caissie.Text = NAME_caiss.ToString() + " " + prename_caissier.ToString();
                    frmCaisse.ID_historique = Convert.ToInt32(id_historique);
                    frmCaisse.id_user = id_user;
                }
                else
                {
                    frmCaisse.type = 1;
                    frmCaisse.ID_caissier = Convert.ToInt32(ID_Caissier);
                    frmCaisse.txt_name_caissie.Text = NAME_caiss.ToString() + " " + prename_caissier.ToString();
                    frmCaisse.id_user = id_user;  
                    frmCaisse.btn1.Enabled = true;
                    frmCaisse.BTN2.Enabled = true;
                    frmCaisse.BTN3.Enabled = true;
                    //frmCaisse.BTN4.Enabled = true;
                    frmCaisse.BTN5.Enabled = true; 
                    frmCaisse.BTN9.Enabled = true;
                    frmCaisse.txt_barcode.Focus();
                }
                frmCaisse.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("تسجيل دخول خاطئ ");
            }

 
        }
    }
}
