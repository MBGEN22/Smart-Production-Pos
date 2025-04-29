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
	public partial class Tab_fichier : UserControl
	{
		Sp_Logine classLogine = new Sp_Logine();
		public int id_User;
		int stocks;
		int unite;   
		int categorie			  ;
		int marque			  ;
		int favoris			  ;
		int taille			  ;
		int color				  ;
		int fournisseure		  ;
		int ouverier			  ;
		int users				  ;
		int caissier			  ;

        public Tab_fichier()
		{
			InitializeComponent();
            LoadDataAsync(); // 
        }
        private async void LoadDataAsync()
        {
            PL.Fichier.frm_stockes frm_stock = new PL.Fichier.frm_stockes();

            // استدعاء الدالة غير المتزامنة لجلب بيانات الوصول
            DataTable DT_acces = await Task.Run(() => classLogine.get_ACCES_USer(id_User));

            //if (DT_acces != null && DT_acces.Rows.Count > 0)
            //{
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_stock.pn_stocke);
                change_color_whene_click(button4);
            //}
            //else
            //{
            //    MessageBox.Show("فشل في جلب بيانات الوصول");
            //}
        }
        public void change_color_whene_click(Button bt)
		{
			Color highlightColor = Color.FromArgb(51, 153, 255);
			this.button1.BackColor = Color.Transparent;
			this.button1.ForeColor = Color.Black;

			this.button2.BackColor = Color.Transparent;
			this.button2.ForeColor = Color.Black;
			
			this.button3.BackColor = Color.Transparent;
			this.button3.ForeColor = Color.Black;

			this.button4.BackColor = Color.Transparent;
			this.button4.ForeColor = Color.Black;

			this.button5.BackColor = Color.Transparent;
			this.button5.ForeColor = Color.Black;

			this.button7.BackColor = Color.Transparent;
			this.button7.ForeColor = Color.Black;

			this.button8.BackColor = Color.Transparent;
			this.button8.ForeColor = Color.Black;

			this.button6.BackColor = Color.Transparent;
			this.button6.ForeColor = Color.Black;

			this.button9.BackColor = Color.Transparent;
			this.button9.ForeColor = Color.Black;

			this.button10.BackColor = Color.Transparent;
			this.button10.ForeColor = Color.Black;

			this.button11.BackColor = Color.Transparent;
			this.button11.ForeColor = Color.Black;

			bt.BackColor = highlightColor;
			bt.ForeColor = Color.White;
		}
        private async void button1_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_unite frm_stock = new PL.Fichier.frm_unite();

            // استدعاء الدالة غير المتزامنة لجلب بيانات الوصول
            DataTable DT_acces = await Task.Run(() => classLogine.get_ACCES_USer(id_User));

            //if (DT_acces != null && DT_acces.Rows.Count > 0)
            //{
                object stock = DT_acces.Rows[0][2];
                unite = Convert.ToInt32(stock);

                if (unite == 1)
                {
                    Form1.getMainForm.pn_container.Controls.Clear();
                    Form1.getMainForm.pn_container.Controls.Add(frm_stock.pn_stocke);
                    change_color_whene_click(button1);
                }
                else
                {
                    MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
                }
            //}
            //else
            //{
            //    MessageBox.Show("فشل في جلب بيانات الوصول");
            //}
        }


        private void button4_Click(object sender, EventArgs e)
		{
			
			PL.Fichier.frm_stockes frm_stock = new PL.Fichier.frm_stockes();
			DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_User);
			if (DT_acces.Rows.Count > 0)
			{
				object stock = DT_acces.Rows[0][1];
				stocks = Convert.ToInt32(stock);

            }
			if (stocks == 1)
			{
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_stock.pn_stocke);
                change_color_whene_click(button4);
			}
			else
			{
				MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
			}
                
            
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			PL.Fichier.frm_categories frm_stock = new PL.Fichier.frm_categories();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_User);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][3];
                categorie = Convert.ToInt32(stock);

            }
            if (categorie == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_stock.pn_categories);
                change_color_whene_click(button2);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void button3_Click(object sender, EventArgs e)
		{
			PL.Fichier.frm_marque frm_stock = new PL.Fichier.frm_marque();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_User);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][4];
                marque = Convert.ToInt32(stock);

            }
            if (marque == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_stock.pn_marque);
                change_color_whene_click(button3);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void button5_Click(object sender, EventArgs e)
		{
			PL.Fichier.frm_favoris frm_stock = new PL.Fichier.frm_favoris();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_User);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][5];
                favoris = Convert.ToInt32(stock);

            }
            if (favoris == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_stock.pn_stocke);
                change_color_whene_click(button5);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void button6_Click(object sender, EventArgs e)
		{
			
		}

		private void button7_Click(object sender, EventArgs e)
		{
			PL.Fichier.frm_fournisseur frm_stock = new PL.Fichier.frm_fournisseur();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_User);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][8];
                fournisseure = Convert.ToInt32(stock);

            }
            if (fournisseure == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_stock.pn_fournisseur);
                change_color_whene_click(button7);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void button8_Click(object sender, EventArgs e)
		{
			PL.Fichier.frm_ouverier frm_stock = new PL.Fichier.frm_ouverier();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_User);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][9];
                ouverier = Convert.ToInt32(stock);

            }
            if (ouverier == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_stock.pn_stocke);
                change_color_whene_click(button8);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void kryptonSeparator7_SplitterMoved(object sender, SplitterEventArgs e)
		{

		}

		private void button9_Click(object sender, EventArgs e)
		{
			PL.Fichier.frm_caissier frm_caissier = new PL.Fichier.frm_caissier();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_User);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][11];
                caissier = Convert.ToInt32(stock);

            }
            if (caissier == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_caissier.pn_caissier);
                change_color_whene_click(button9);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void button6_Click_1(object sender, EventArgs e)
		{
			PL.Fichier.frm_Taille frmTaille = new PL.Fichier.frm_Taille();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_User);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][6];
                taille = Convert.ToInt32(stock);

            }
            if (taille == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frmTaille.pn_marque);
                change_color_whene_click(button6);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void button10_Click(object sender, EventArgs e)
		{
			PL.Fichier.frm_color frm_color = new PL.Fichier.frm_color();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_User);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][7];
                color = Convert.ToInt32(stock);

            }
            if (color == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_color.pn_marque);
                change_color_whene_click(button10);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}

		private void button11_Click(object sender, EventArgs e)
		{
			PL.Fichier.frm_user frm_caissier = new PL.Fichier.frm_user();
            DataTable DT_acces = new DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(id_User);
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][10];
                users = Convert.ToInt32(stock);

            }
            if (users == 1)
            {
                Form1.getMainForm.pn_container.Controls.Clear();
                Form1.getMainForm.pn_container.Controls.Add(frm_caissier.pn_caissier);
                change_color_whene_click(button11);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
		}
	}
}
