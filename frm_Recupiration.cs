using ComponentFactory.Krypton.Toolkit;
using Smart_Production_Pos.BL;
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
    public partial class frm_Recupiration : Form
    {
        BL.BL_FICHIER.BL_user ClassUSer = new BL.BL_FICHIER.BL_user();
        Sp_Logine classLogine = new Sp_Logine();
        int ID;
        int id_ouverierr;
        string Rolee;

        public frm_Recupiration()
        {
            InitializeComponent();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            ClassUSer.edit_update_whene_Recupi(
                        ID,
                        id_ouverierr,
                        kryptonTextBox1.Text,
                        kryptonTextBox2.Text,
                        Rolee,
                        "OFF",
                         txtPassword.Text
                         
                        );
            MessageBox.Show("تم  تحديث بياناتك يمكنك الولوج الان بالبيانات الجديدة");
            Application.Restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = classLogine.get_TB_USER_RECUPIRATION(txtPassword.Text);
            if (dt.Rows.Count > 0)
            {
                object id = dt.Rows[0][0];
                object id_ouverier = dt.Rows[0][1];
                object Role = dt.Rows[0][4];

                ID = Convert.ToInt32(id);
                id_ouverierr = Convert.ToInt32(id_ouverier);
                Rolee = Role.ToString();
                kryptonTextBox1.Enabled = true;
                kryptonTextBox2.Enabled = true;
            }
            else
            {
                MessageBox.Show("معلومات خاطئة");
            }
        }
    }
}
