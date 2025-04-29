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
	public partial class tab_client : UserControl
    {
        Sp_Logine classLogine = new Sp_Logine();
        public int id_User; 
		int client;
        int historique_client;
        int remarque; 
        public tab_client()
		{
			InitializeComponent();
		}
		public void change_color_whene_click(Button bt)
		{
			this.button3.BackColor = Color.Transparent;    
		    this.button4.BackColor = Color.Transparent;
			this.button6.BackColor = Color.Transparent; 
			bt.BackColor = Color.LightSeaGreen;
		}
		private void button6_Click(object sender, EventArgs e)
		{
			PL.Fichier.frm_client frm_stock = new PL.Fichier.frm_client();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_User);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][12];
                client = Convert.ToInt32(stock);

            }
            if (client == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_stock.pn_client);
                change_color_whene_click(button6);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void button3_Click(object sender, EventArgs e)
		{
			PL.CLient.frm_historique_client histoeique_Client = new PL.CLient.frm_historique_client();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_User);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][13];
                historique_client = Convert.ToInt32(stock);

            }
            if (historique_client == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(histoeique_Client.pn_historique_client);
                change_color_whene_click(button3);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void button4_Click(object sender, EventArgs e)
		{
			PL.CLient.frm_remarque_client histoeique_Client = new PL.CLient.frm_remarque_client();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_User);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][14];
                historique_client = Convert.ToInt32(stock);

            }
            if (historique_client == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(histoeique_Client.pn_historique_client);
                change_color_whene_click(button4);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}
	}
}
