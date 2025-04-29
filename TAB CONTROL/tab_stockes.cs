using Smart_Production_Pos.BL;
using Smart_Production_Pos.PL.Achat_revente;
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
	public partial class tab_stockes : UserControl
    {
        Sp_Logine classLogine = new Sp_Logine();
        public int id_User;
        int stock_produit;
        int pack;
        public tab_stockes()
		{
			InitializeComponent();
		}
		public void change_color_whene_click(Button bt)
		{ 
			this.button3.BackColor = Color.Transparent; 
			this.button5.BackColor = Color.Transparent;
			this.button1.BackColor = Color.Transparent;
			this.button2.BackColor = Color.Transparent;
			this.button4.BackColor = Color.Transparent;

			bt.BackColor = Color.LightSeaGreen;
		}
		private void button5_Click(object sender, EventArgs e)
		{
			PL.Achats.frm_dechet_recycle frm_Stock = new PL.Achats.frm_dechet_recycle();
			Form1.getMainForm.pn_container.Controls.Clear();
			Form1.getMainForm.pn_container.Controls.Add(frm_Stock.pn_stock_matier_premier);
			change_color_whene_click(button5);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			PL.Achats.frm_stock_matier_premier frm_Stock = new PL.Achats.frm_stock_matier_premier();
			Form1.getMainForm.pn_container.Controls.Clear();
			Form1.getMainForm.pn_container.Controls.Add(frm_Stock.pn_stock_matier_premier);
			change_color_whene_click(button3);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			PL.Fichier.frm_dechet frm_Stock = new PL.Fichier.frm_dechet();
			Form1.getMainForm.pn_container.Controls.Clear();
			Form1.getMainForm.pn_container.Controls.Add(frm_Stock.pn_stock_matier_premier);
			change_color_whene_click(button1);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			PL.Achat_revente.frm_stock_produit_revente frm_Stock = new PL.Achat_revente.frm_stock_produit_revente();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_User);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][19];
                stock_produit = Convert.ToInt32(stock);

            }
            if (stock_produit == 1)
            {
                frm_Stock.id_user = id_User;
                frm_Stock.ShowDialog();
				
                change_color_whene_click(button2);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void button4_Click(object sender, EventArgs e)
		{
			PL.Achat_revente.frm_stock_pack frm_Stock = new PL.Achat_revente.frm_stock_pack();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_User);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][20];
                pack = Convert.ToInt32(stock);

            }
            if (pack == 1)
            {
				//Form1.getMainForm.pn_container.Controls.Clear();
				//Form1.getMainForm.pn_container.Controls.Add(frm_Stock.pn_stock_matier_premier);
				//change_color_whene_click(button4);
				frm_Stock.Show();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

        private void button6_Click(object sender, EventArgs e)
        {
            frm_barcode_reserver code_barreReserver = new frm_barcode_reserver();
			code_barreReserver.ShowDialog();
        }
    }
}
