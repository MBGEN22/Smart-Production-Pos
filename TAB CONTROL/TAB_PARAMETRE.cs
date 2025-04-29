using Smart_Production_Pos.BL;
using Smart_Production_Pos.PL.Fichier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.TAB_CONTROL
{
	public partial class TAB_PARAMETRE : UserControl
    {
        Sp_Logine classLogine = new Sp_Logine();
        public int id_User;
        int serverss;
        int facture_info;
        public TAB_PARAMETRE()
		{
			InitializeComponent();
		}

		private void button9_Click(object sender, EventArgs e)
		{
            //PL.paramtre.frm_information frm_paramtre = new PL.paramtre.frm_information();
            PLADD.frm_paramatre frm_paramtre = new PLADD.frm_paramatre();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_User);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][31];
                facture_info = Convert.ToInt32(stock);

            }
            if (facture_info == 1)
            {
                //Form1.getMainForm.pn_container.Controls.Clear();
                //Form1.getMainForm.pn_container.Controls.Add(frm_paramtre.pn_info);
                frm_paramtre.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }

        }

		private void button11_Click(object sender, EventArgs e)
		{
			PL.paramtre.frm_server frm_paramtre = new PL.paramtre.frm_server();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_User);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][30];
                serverss = Convert.ToInt32(stock);

            }
            if (serverss == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_paramtre.pn_info);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}
	}
}
