using Smart_Production_Pos.BL.BL_FICHIER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.vente
{
	public partial class frm_logine_caiise1 : Form
    {
        BL.BL_FICHIER.BL_CAISSIER classclient = new BL.BL_FICHIER.BL_CAISSIER();
        BL.BL_vente.BL_SP_LOGINE_Caisse classLogineCaisse = new BL.BL_vente.BL_SP_LOGINE_Caisse();
        PL.Fichier.frm_caissier frm_caissier = new PL.Fichier.frm_caissier();
        TAB_CONTROL.Tab_fichier tab_ficher = new TAB_CONTROL.Tab_fichier();
        public int id_user;
        public string Type;

        public frm_logine_caiise1()
		{
			InitializeComponent();
            
        }

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
            if (Type == "B")
            {
                DataTable Dt = classLogineCaisse.LOGIN(txtUser.Text, txtPassword.Text);
                if (Dt.Rows.Count > 0)
                {
                    Object ID_Caissier = Dt.Rows[0][0];
                    PLADD.vente.Frm_vente_caissev5 frmCaisse = new PLADD.vente.Frm_vente_caissev5();

                    DataTable dt2 = new DataTable();
                    dt2 = classLogineCaisse.check_if_caisse_renter(Convert.ToInt32(ID_Caissier), DateTime.Today);
                    if (dt2.Rows.Count > 0)
                    {
                        object id_historique = dt2.Rows[0][0];
                        frmCaisse.type = 2;
                        frmCaisse.ID_caissier = Convert.ToInt32(ID_Caissier);
                        frmCaisse.ID_historique = Convert.ToInt32(id_historique);
                        frmCaisse.id_user = id_user;
                    }
                    else
                    {
                        frmCaisse.type = 1;
                        frmCaisse.ID_caissier = Convert.ToInt32(ID_Caissier);
                        frmCaisse.id_user = id_user;
                        frmCaisse.flowLAyoutProduct.Enabled = true;
                        frmCaisse.panel1.Enabled = true;
                        //frmCaisse.panel2.Enabled = true;
                        //frmCaisse.panel3.Enabled = true;
                        //frmCaisse.panel4.Enabled = true;
                        //frmCaisse.panel5.Enabled = true;
                        frmCaisse.btn1.Enabled = true;
                        frmCaisse.BTN2.Enabled = true;
                        frmCaisse.BTN3.Enabled = true;
                        frmCaisse.BTN4.Enabled = true;
                        frmCaisse.BTN5.Enabled = true;
                        frmCaisse.BTN6.Enabled = true;
                        frmCaisse.BTN7.Enabled = true;
                        frmCaisse.BTN8.Enabled = true;
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
            else
            {
                DataTable Dt = classLogineCaisse.LOGIN(txtUser.Text, txtPassword.Text);
                if (Dt.Rows.Count > 0)
                {
                    Object ID_Caissier = Dt.Rows[0][0];
                    PLADD.vente.frm_vente_caisse frmCaisse = new PLADD.vente.frm_vente_caisse();

                    DataTable dt2 = new DataTable();
                    dt2 = classLogineCaisse.check_if_caisse_renter(Convert.ToInt32(ID_Caissier), DateTime.Today);
                    if (dt2.Rows.Count > 0)
                    {
                        object id_historique = dt2.Rows[0][0];
                        frmCaisse.type = 2;
                        frmCaisse.ID_caissier = Convert.ToInt32(ID_Caissier);
                        frmCaisse.ID_historique = Convert.ToInt32(id_historique);
                        frmCaisse.id_user = id_user;
                    }
                    else
                    {
                        frmCaisse.type = 1;
                        frmCaisse.ID_caissier = Convert.ToInt32(ID_Caissier);
                        frmCaisse.id_user = id_user;
                        frmCaisse.flowLAyoutProduct.Enabled = true;
                        frmCaisse.panel1.Enabled = true;
                        frmCaisse.panel2.Enabled = true;
                        frmCaisse.panel3.Enabled = true;
                        frmCaisse.panel4.Enabled = true;
                        frmCaisse.panel5.Enabled = true;
                        frmCaisse.btn1.Enabled = true;
                        frmCaisse.BTN2.Enabled = true;
                        frmCaisse.BTN3.Enabled = true;
                        frmCaisse.BTN4.Enabled = true;
                        frmCaisse.BTN5.Enabled = true;
                        frmCaisse.BTN6.Enabled = true;
                        frmCaisse.BTN7.Enabled = true;
                        frmCaisse.BTN8.Enabled = true;
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

		private void kryptonButton1_Click(object sender, EventArgs e)
		{ 
			this.Close();
		}

        private void kryptonGroup1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm_logine_caiise1_Load(object sender, EventArgs e)
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

        private void kryptonGroup1_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Type == "B")
                {
                    DataTable Dt = classLogineCaisse.LOGIN(txtUser.Text, txtPassword.Text);
                    if (Dt.Rows.Count > 0)
                    {
                        Object ID_Caissier = Dt.Rows[0][0];
                        PLADD.vente.Frm_vente_caissev5 frmCaisse = new PLADD.vente.Frm_vente_caissev5();

                        DataTable dt2 = new DataTable();
                        dt2 = classLogineCaisse.check_if_caisse_renter(Convert.ToInt32(ID_Caissier), DateTime.Today);
                        if (dt2.Rows.Count > 0)
                        {
                            object id_historique = dt2.Rows[0][0];
                            frmCaisse.type = 2;
                            frmCaisse.ID_caissier = Convert.ToInt32(ID_Caissier);
                            frmCaisse.ID_historique = Convert.ToInt32(id_historique);
                            frmCaisse.id_user = id_user;
                        }
                        else
                        {
                            frmCaisse.type = 1;
                            frmCaisse.ID_caissier = Convert.ToInt32(ID_Caissier);
                            frmCaisse.id_user = id_user;
                            frmCaisse.flowLAyoutProduct.Enabled = true;
                            frmCaisse.panel1.Enabled = true;
                            //frmCaisse.panel2.Enabled = true;
                            //frmCaisse.panel3.Enabled = true;
                            //frmCaisse.panel4.Enabled = true;
                            //frmCaisse.panel5.Enabled = true;
                            frmCaisse.btn1.Enabled = true;
                            frmCaisse.BTN2.Enabled = true;
                            frmCaisse.BTN3.Enabled = true;
                            frmCaisse.BTN4.Enabled = true;
                            frmCaisse.BTN5.Enabled = true;
                            frmCaisse.BTN6.Enabled = true;
                            frmCaisse.BTN7.Enabled = true;
                            frmCaisse.BTN8.Enabled = true;
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
                else
                {
                    DataTable Dt = classLogineCaisse.LOGIN(txtUser.Text, txtPassword.Text);
                    if (Dt.Rows.Count > 0)
                    {
                        Object ID_Caissier = Dt.Rows[0][0];
                        PLADD.vente.frm_vente_caisse frmCaisse = new PLADD.vente.frm_vente_caisse();

                        DataTable dt2 = new DataTable();
                        dt2 = classLogineCaisse.check_if_caisse_renter(Convert.ToInt32(ID_Caissier), DateTime.Today);
                        if (dt2.Rows.Count > 0)
                        {
                            object id_historique = dt2.Rows[0][0];
                            frmCaisse.type = 2;
                            frmCaisse.ID_caissier = Convert.ToInt32(ID_Caissier);
                            frmCaisse.ID_historique = Convert.ToInt32(id_historique);
                            frmCaisse.id_user = id_user;
                        }
                        else
                        {
                            frmCaisse.type = 1;
                            frmCaisse.ID_caissier = Convert.ToInt32(ID_Caissier);
                            frmCaisse.id_user = id_user;
                            frmCaisse.flowLAyoutProduct.Enabled = true;
                            frmCaisse.panel1.Enabled = true;
                            frmCaisse.panel2.Enabled = true;
                            frmCaisse.panel3.Enabled = true;
                            frmCaisse.panel4.Enabled = true;
                            frmCaisse.panel5.Enabled = true;
                            frmCaisse.btn1.Enabled = true;
                            frmCaisse.BTN2.Enabled = true;
                            frmCaisse.BTN3.Enabled = true;
                            frmCaisse.BTN4.Enabled = true;
                            frmCaisse.BTN5.Enabled = true;
                            frmCaisse.BTN6.Enabled = true;
                            frmCaisse.BTN7.Enabled = true;
                            frmCaisse.BTN8.Enabled = true;
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // تشغيل لوحة المفاتيح الافتراضية
                Process.Start("osk.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Problème", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
