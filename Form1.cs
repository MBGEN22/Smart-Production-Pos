using Microsoft.Office.Interop.Excel;
using Smart_Production_Pos.BL;
using Smart_Production_Pos.BL.BL_FICHIER;
using Smart_Production_Pos.PL.Achat_revente;
using Smart_Production_Pos.PL.Achats;
using Smart_Production_Pos.PL.Fichier;
using Smart_Production_Pos.PLADD.Achat_revente;
using Smart_Production_Pos.PLADD.Fichier;
using Smart_Production_Pos.TAB_CONTROL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Smart_Production_Pos
{
	public partial class Form1 : Form
	{
		#region form
		private static Form1 frm;
		static void frm_formClosed(Object sender, FormClosedEventArgs e)
		{
			frm = null;
		}

		public static Form1 getMainForm
		{
			get
			{
				if (frm == null)
				{
					frm = new Form1();
					frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
				}
				return frm;
			}
		}
        #endregion

        Sp_Logine classLogine = new Sp_Logine();
        BL.BL_FICHIER.BL_fctr classFctr = new BL.BL_FICHIER.BL_fctr();
		public string ID_user ;
		public string Role;
		public string User ; 
		public int useridd ;
        //Fichier
        int stocks;
        int unite;
        int categorie;
        int marque;
        int favoris;
        int taille;
        int color;
        int fournisseure;
        int ouverier;
        int users;
        int caissier;
        //client 
        int client;
        int historique_client;
        int remarque;
        //Achat 
        int achat;
        int facture_achat;
        int dossier_fctr_achat;
        int historique_frnsre;
        //stock 
        int stock_produit;
        int pack;
        //
        int facture_vente;
        int list_vente;
        int liv;
        int POS;
        //state

        int les_charge;
        int lapie;
        int transition_caissier;
        int state_total;
        int benifice;

        public Form1()
		{
			InitializeComponent();
			if (frm == null)
				frm = this;
        }
        private async Task LoadDashboardAsync()
        {
            // عرض شاشة تحميل أو أي إشعار للمستخدم
            //SplachScreen.getMainForm.Show(); // عرض الشاشة المؤقتة إذا كان هذا الأمر ضرورياً

            // انتظار عملية إنشاء Dashboard بشكل غير متزامن
            

            // إغلاق شاشة التحميل بعد الانتهاء
            //SplachScreen.getMainForm.Close();
        }
        private void button1_Click(object sender, EventArgs e)
		{
            //  DAL.DAL daoo = new DAL.DAL();
            //// تحديد المسار الافتراضي لحفظ النسخة الاحتياطية
            //string defaultBackupPath = @"C:\Backups";
            //Directory.CreateDirectory(defaultBackupPath); // إنشاء المجلد إذا لم يكن موجودًا

            //string fileName = "DB_PRODUCTION_POS_" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".bak";
            //string filePath = Path.Combine(defaultBackupPath, fileName);

            //try
            //{
            //    string strQuery = "BACKUP DATABASE DB_PRODUCTION_POS TO DISK = @filePath";
            //    using (SqlCommand cmd = new SqlCommand(strQuery, daoo.sqlConnection))
            //    {
            //        cmd.Parameters.AddWithValue("@filePath", filePath);
            //        daoo.sqlConnection.Open();
            //        cmd.ExecuteNonQuery();
            //        daoo.sqlConnection.Close();
            //        MessageBox.Show("تم إنشاء النسخة الاحتياطية بنجاح في " + filePath);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("حدث خطأ أثناء إنشاء النسخة الاحتياطية: " + ex.Message);
            //}
            //finally
            //{
            //    if (daoo.sqlConnection.State == System.Data.ConnectionState.Open)
            //    {
            //        daoo.sqlConnection.Close();
            //    }
            //}
            ExitApplication();

        }
        private async void ExitApplication()
        {
            if (MessageBox.Show("هذا الخيار سيقوم بالخروج من البرنامج هل أنت متأكد؟", "عملية الخروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Properties.Settings.Default.save_the_db == "true")
                {
                    string backupPath = Properties.Settings.Default.BackupPath;
                    if (!string.IsNullOrWhiteSpace(backupPath))
                    {
                        // إظهار شاشة التحميل
                        Frm_Loading loadingForm = new Frm_Loading();
                        loadingForm.Show();

                        // تنفيذ النسخ الاحتياطي في الخلفية
                        await Task.Run(() =>
                        {
                            BackupManager backup = new BackupManager();
                            backup.CreateBackup(backupPath);
                        });

                        
                        // إخفاء شاشة التحميل
                        loadingForm.Hide(); System.Windows.Forms.Application.Exit();
                    }
                }

                System.Windows.Forms.Application.Exit();
            }
        }
        private    void button4_Click(object sender, EventArgs e)
		{

		    TAB_CONTROL.Tab_fichier tab_ficher = new TAB_CONTROL.Tab_fichier();
            tab_ficher.id_User = Convert.ToInt32(ID_user.ToString());
            pn_tab_container.Controls.Clear();
            pn_tab_container.Controls.Add(tab_ficher.flowLayoutPanel1);
            panel3.Height = 133;
            //lb_page.Text = "الأخصائيين";
        }

        private void pn_container_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (panel3.Height == 133)
			{
				panel3.Height = 53; 
			}
			else if (panel3.Height == 53)
			{
				panel3.Height = 133;
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			panel3.Height = 133;
			TAB_CONTROL.tab_achat tab_ficher = new TAB_CONTROL.tab_achat();
			pn_tab_container.Controls.Clear();
			pn_tab_container.Controls.Add(tab_ficher.flowLayoutPanel1);
		}

		private void button6_Click(object sender, EventArgs e)
		{
			panel3.Height = 133;
			TAB_CONTROL.tab_stockes tab_stock = new TAB_CONTROL.tab_stockes();
            tab_stock.id_User = Convert.ToInt32(ID_user.ToString());
            pn_tab_container.Controls.Clear();
			pn_tab_container.Controls.Add(tab_stock.flowLayoutPanel1);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			panel3.Height = 133;
			TAB_CONTROL.tab_client tab_client = new TAB_CONTROL.tab_client(); 
            tab_client.id_User = Convert.ToInt32(ID_user.ToString()); 
			pn_tab_container.Controls.Clear();
			pn_tab_container.Controls.Add(tab_client.flowLayoutPanel1); 
		}

		private void button8_Click(object sender, EventArgs e)
		{
			panel3.Height = 133;
			TAB_CONTROL.tab_commande tab_commande = new TAB_CONTROL.tab_commande();
			pn_tab_container.Controls.Clear();
			tab_commande.id_user = Convert.ToInt32(ID_user.ToString());
			pn_tab_container.Controls.Add(tab_commande.flowLayoutPanel1);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Normal)
			{
				this.WindowState = FormWindowState.Maximized;
			}
			else
			{
				this.WindowState = FormWindowState.Normal;
			}
		}

		private void panel5_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button9_Click(object sender, EventArgs e)
		{
			panel3.Height = 133;
			TAB_CONTROL.tab_production tba_produc = new TAB_CONTROL.tab_production();
			pn_tab_container.Controls.Clear();
			pn_tab_container.Controls.Add(tba_produc.flowLayoutPanel1);
		}

		private void button14_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void button10_Click(object sender, EventArgs e)
		{
			panel3.Height = 133;
			TAB_CONTROL.tab_controle_revenete tab_achat = new TAB_CONTROL.tab_controle_revenete();
			pn_tab_container.Controls.Clear();
			tab_achat.id_user = Convert.ToInt32(ID_user.ToString());
			pn_tab_container.Controls.Add(tab_achat.flowLayoutPanel1);
			//PLADD.Achat_revente.frm_add_achat add_achat = new PLADD.Achat_revente.frm_add_achat();
			//add_achat.ShowDialog();
		}

		private void button13_Click(object sender, EventArgs e)
		{
			panel3.Height = 133;
			TAB_CONTROL.TAB_PARAMETRE tb_paraptre = new TAB_CONTROL.TAB_PARAMETRE();
            tb_paraptre.id_User = Convert.ToInt32(ID_user.ToString()); 
			pn_tab_container.Controls.Clear();
			pn_tab_container.Controls.Add(tb_paraptre.flowLayoutPanel1);
		}

		private void button11_Click(object sender, EventArgs e)
		{
			panel3.Height = 133;
			TAB_CONTROL.tab_vente  tba_produc = new TAB_CONTROL.tab_vente();
			tba_produc.id_user = Convert.ToInt32(ID_user.ToString());
			pn_tab_container.Controls.Clear();
			pn_tab_container.Controls.Add(tba_produc.flowLayoutPanel1);
		}

		private void button15_Click(object sender, EventArgs e)
		{
			PL.Dashboard dash = new PL.Dashboard();
			panel3.Height = 53;
			dash.id_user = Convert.ToInt32(ID_user.ToString());
			pn_container.Controls.Clear();
			pn_container.Controls.Add(dash.panel3);
		}
        public string GetMacAddress()
        {
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                PhysicalAddress physicalAddress = networkInterface.GetPhysicalAddress();
                byte[] addressBytes = physicalAddress.GetAddressBytes();
                string macAddress = BitConverter.ToString(addressBytes);

                // Return the first MAC address found
                return macAddress;
            }

            return string.Empty; // In case no MAC address is found
        }
        public static string Decrypt(string MotChifre)
		{
			string[] token = MotChifre.Split('*', '#', '@', '$', '%', '€', 'm', 'R', 'H', '&', 'é', '(', '§', 'è', '!', 'ç', ')', '^');
			string MacAdress = "";
			for (int i = token.Length - 2; i >= 0; i--)
			{
				MacAdress += ((char)Convert.ToInt32(token[i])).ToString();
			}
			return MacAdress;
		}
		private void button12_Click(object sender, EventArgs e)
		{
			panel3.Height = 133;
			TAB_CONTROL.tab_statistique tb_state = new TAB_CONTROL.tab_statistique();
			tb_state.id_user =Convert.ToInt32(ID_user);
			pn_tab_container.Controls.Clear();
			pn_tab_container.Controls.Add(tb_state.flowLayoutPanel1);
			
		}

		private void delte()
		{
			DAL.DAL DAL = new DAL.DAL();
			SqlConnection connectionString;
			connectionString = DAL.sqlConnection;
			string query = "SELECT COUNT(*) FROM [TB_MAX_ADRESS]";

			using (connectionString)
			{
				SqlCommand command = new SqlCommand(query, connectionString);
				connectionString.Open();
				int MacAdressCount = (int)command.ExecuteScalar();

				if(MacAdressCount > 0)
				{
                    //checl PC
                    System.Data.DataTable dt = new System.Data.DataTable();
					dt = classFctr.getFctr();
					string MacAdress = GetMacAddress();
					object crypting = dt.Rows[0][2];
					string decryotin = Decrypt(crypting.ToString());
					if (decryotin != MacAdress.ToString())
					{
						 
					}
					else
					{
						button16.Visible = false;
					}
				}

			}

		}
			private void button16_Click(object sender, EventArgs e)
		{
			PL.frm_licences_programme license = new PL.frm_licences_programme();
			license.ShowDialog();
		}

        //public string GetMacAddress()
        //{
        //    ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT VolumeSerialNumber FROM Win32_LogicalDisk WHERE DeviceID='C:'");
        //    foreach (ManagementObject disk in searcher.Get())
        //    {
        //        return disk["VolumeSerialNumber"].ToString();
        //    }
        //    return string.Empty;
        //}
        private void Form1_Load(object sender, EventArgs e)
		{
            

            notify.Image = Properties.Resources.info2; 
            notify.TitleText = "أهلا بك من جديد في البرنامج";
            notify.ContentText = Properties.Settings.Default.doaa.ToString();
            notify.Popup();
            if (lb_role.Text== "مستخدم")
			{
				button12.Visible = false;
			}
			delte();
			timer1.Start();
            LB_heures.Text = DateTime.Now.ToLongDateString();
			LB_Date.Text = DateTime.Now.ToLongTimeString(); 
            PL.Dashboard dash  = new PL.Dashboard(); 
            panel3.Height = 53;
            dash.id_user = Convert.ToInt32(ID_user.ToString());
            pn_container.Controls.Clear();
            pn_container.Controls.Add(dash.panel3);

            if (Properties.Settings.Default.oppen_form_vente == "true")
            {
                PLADD.vente.frm_logine_caiise1 frmCaisse = new PLADD.vente.frm_logine_caiise1();
                System.Data.DataTable DT_acces = new System.Data.DataTable(); ;
                DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
                if (DT_acces.Rows.Count > 0)
                {
                    object stock = DT_acces.Rows[0][24];
                    POS = Convert.ToInt32(stock);

                }
                if (POS == 1)
                {
                    frmCaisse.id_user = Convert.ToInt32(ID_user);
                    frmCaisse.ShowDialog();
                }
                else
                {
                    MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
                }
            }
        }

		private void timer1_Tick(object sender, EventArgs e)
		{

			LB_Date.Text = DateTime.Now.ToLongTimeString();
			timer1.Start();
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F1)
			{
			}
			if (e.KeyCode == Keys.F2)
			{

			}
			if (e.KeyCode == Keys.F3)
			{

			}
			if (e.KeyCode == Keys.F4)
			{

			}
			if (e.KeyCode == Keys.F5)
			{

			}
			if (e.KeyCode == Keys.F6)
			{

			}
			if (e.KeyCode == Keys.F7)
			{

			}

		}

		private void button17_Click(object sender, EventArgs e)
		{
			panel3.Height = 133;
			TAB_CONTROL.tab_DB_SAVE tba_produc = new TAB_CONTROL.tab_DB_SAVE();
			pn_tab_container.Controls.Clear();
			pn_tab_container.Controls.Add(tba_produc.flowLayoutPanel1);
		}

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void المخازنToolStripMenuItem_Click(object sender, EventArgs e)
        {

            PL.Fichier.frm_stockes frm_stock = new PL.Fichier.frm_stockes();
			System.Data.DataTable DT_acces = new System.Data.DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32( ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][1];
                stocks = Convert.ToInt32(stock);

            }
            if (stocks == 1)
            {
				frm_stock.FormBorderStyle = FormBorderStyle.FixedSingle; 
                frm_stock.ShowDialog();
                //Form1.getMainForm.pn_container.Controls.Clear();
                //Form1.getMainForm.pn_container.Controls.Add(frm_stock.pn_stocke); 
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void الوحداتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_unite frm_stock = new PL.Fichier.frm_unite();

			// استدعاء الدالة غير المتزامنة لجلب بيانات الوصول
			System.Data.DataTable DT_acces = new System.Data.DataTable(); 
			DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user)) ;

            //if (DT_acces != null && DT_acces.Rows.Count > 0)
            //{
            object stock = DT_acces.Rows[0][2];
            unite = Convert.ToInt32(stock);

            if (unite == 1)
            {
                frm_stock.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_stock.ShowDialog(); 
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void العلاماتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_marque frm_stock = new PL.Fichier.frm_marque();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][4];
                marque = Convert.ToInt32(stock);

            }
            if (marque == 1)
            {
                frm_stock.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_stock.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void الاصنافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_categories frm_stock = new PL.Fichier.frm_categories();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][3];
                categorie = Convert.ToInt32(stock);

            }
            if (categorie == 1)
            {
                frm_stock.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_stock.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void المفضلةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_favoris frm_stock = new PL.Fichier.frm_favoris();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][5];
                favoris = Convert.ToInt32(stock);

            }
            if (favoris == 1)
            {
                frm_stock.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_stock.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void القياسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_Taille frmTaille = new PL.Fichier.frm_Taille();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][6];
                taille = Convert.ToInt32(stock);

            }
            if (taille == 1)
            { 
                frmTaille.FormBorderStyle = FormBorderStyle.FixedSingle;
                frmTaille.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void الالوانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_color frm_color = new PL.Fichier.frm_color();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][7];
                color = Convert.ToInt32(stock);

            }
            if (color == 1)
            {
                frm_color.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_color.ShowDialog(); 
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void الموردينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_fournisseur frm_stock = new PL.Fichier.frm_fournisseur();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][8];
                fournisseure = Convert.ToInt32(stock);

            }
            if (fournisseure == 1)
            {
                frm_stock.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_stock.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void العمالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_ouverier frm_stock = new PL.Fichier.frm_ouverier();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][9];
                ouverier = Convert.ToInt32(stock);

            }
            if (ouverier == 1)
            {
                frm_stock.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_stock.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void الصرافينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_caissier frm_caissier = new PL.Fichier.frm_caissier();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][11];
                caissier = Convert.ToInt32(stock);

            }
            if (caissier == 1)
            {
                frm_caissier.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_caissier.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void المستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_user frm_caissier = new PL.Fichier.frm_user();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][10];
                users = Convert.ToInt32(stock);

            }
            if (users == 1)
            {
                frm_caissier.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_caissier.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void الزبائنToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_client frm_stock = new PL.Fichier.frm_client();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][12];
                client = Convert.ToInt32(stock);

            }
            if (client == 1)
            {
                frm_stock.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_stock.ShowDialog(); 
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void تتبعمصاريفالزبائنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.CLient.frm_historique_client histoeique_Client = new PL.CLient.frm_historique_client();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][13];
                historique_client = Convert.ToInt32(stock);

            }
            if (historique_client == 1)
            {
                histoeique_Client.FormBorderStyle = FormBorderStyle.FixedSingle;
                histoeique_Client.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void ملاحظاتخاصةبالزبائنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.CLient.frm_remarque_client histoeique_Client = new PL.CLient.frm_remarque_client();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][14];
                historique_client = Convert.ToInt32(stock);

            }
            if (historique_client == 1)
            {
                histoeique_Client.FormBorderStyle = FormBorderStyle.FixedSingle;
                histoeique_Client.ShowDialog(); 
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }

        }

        private void عمليةالشراءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Achat_revente.Frm_Achat frmachat = new PL.Achat_revente.Frm_Achat();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][15];
                achat = Convert.ToInt32(stock);

            }
            if (achat == 1)
            {
                frmachat.id_user = Convert.ToInt32(ID_user);
                frmachat.Show();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void فواتيرالشراءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Achat_revente.frm_facture frmachat = new PL.Achat_revente.frm_facture();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][16];
                facture_achat = Convert.ToInt32(stock);

            }
            if (facture_achat == 1)
            {
                frmachat.FormBorderStyle = FormBorderStyle.FixedSingle;
                frmachat.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void ملفاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Achat_revente.FRM_fichier_fctr_produit_revente list_facture_folder = new PL.Achat_revente.FRM_fichier_fctr_produit_revente();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][17];
                dossier_fctr_achat = Convert.ToInt32(stock);

            }
            if (dossier_fctr_achat == 1)
            {
                list_facture_folder.FormBorderStyle = FormBorderStyle.FixedSingle;
                list_facture_folder.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void تتبعمصاريفالزبائنToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PL.Achats.frm_historique_fournisseur frmhistorique_fournisseur = new PL.Achats.frm_historique_fournisseur();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][18];
                dossier_fctr_achat = Convert.ToInt32(stock);

            }
            if (dossier_fctr_achat == 1)
            {
                frmhistorique_fournisseur.FormBorderStyle = FormBorderStyle.FixedSingle;
                frmhistorique_fournisseur.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void مخزونالموادToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Achat_revente.frm_stock_produit_revente frm_Stock = new PL.Achat_revente.frm_stock_produit_revente();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][19];
                stock_produit = Convert.ToInt32(stock);

            }
            if (stock_produit == 1)
            {
                frm_Stock.id_user = Convert.ToInt32(ID_user);
                frm_Stock.ShowDialog();
                 
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void مخزونالحزمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Achat_revente.frm_stock_pack frm_Stock = new PL.Achat_revente.frm_stock_pack();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][20];
                pack = Convert.ToInt32(stock);

            }
            if (pack == 1)
            {
                frm_Stock.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_Stock.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void فواتيرالبيعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.vente.frm_facture_vente frm_fctr = new PL.vente.frm_facture_vente();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][21];
                facture_vente = Convert.ToInt32(stock);

            }
            if (facture_vente == 1)
            {
                frm_fctr.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_fctr.ShowDialog();
                //change_color_whene_click(button1);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void قائمةالبيعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.vente.frm_list_vente frm_fctr = new PL.vente.frm_list_vente();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][22];
                list_vente = Convert.ToInt32(stock);

            }
            if (list_vente == 1)
            {
                frm_fctr.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_fctr.ShowDialog();
                //change_color_whene_click(button1);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void قائمةالنقلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.vente.frm_Livraison frm_fctr = new PL.vente.frm_Livraison();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][23];
                liv = Convert.ToInt32(stock);

            }
            if (liv == 1)
            {
                frm_fctr.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_fctr.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void واجهةالبيعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PLADD.vente.frm_logine_caiise1 frmCaisse = new PLADD.vente.frm_logine_caiise1();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][24];
                POS = Convert.ToInt32(stock);

            }
            if (POS == 1)
            {
                frmCaisse.id_user = Convert.ToInt32(ID_user);
                frmCaisse.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }

        }

        private void الخسائرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Statistique.frm_depense frm_stock = new PL.Statistique.frm_depense();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][25];
                les_charge = Convert.ToInt32(stock);

            }
            if (les_charge == 1)
            {
                frm_stock.id_user = Convert.ToInt32(ID_user);
                frm_stock.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_stock.ShowDialog();
                //change_color_whene_click(button4);
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void الدفعالشهريللعمالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Statistique.frm_versement_ouverier frm_stock = new PL.Statistique.frm_versement_ouverier();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][26];
                lapie = Convert.ToInt32(stock);

            }
            if (lapie == 1)
            {
                frm_stock.id_user = Convert.ToInt32(ID_user);
                frm_stock.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_stock.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void تحويلاتالقابضToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Statistique.frm_historique_caisier frm_stock = new PL.Statistique.frm_historique_caisier();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][27];
                transition_caissier = Convert.ToInt32(stock);

            }
            if (transition_caissier == 1)
            {
                frm_stock.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_stock.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void احصائياتعامةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Statistique.frm_Statistique_generale frm_stock = new PL.Statistique.frm_Statistique_generale();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][28];
                state_total = Convert.ToInt32(stock);

            }
            if (state_total == 1)
            {
                //frm_stock.id_user = id_user;
                frm_stock.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_stock.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void الفوائدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Statistique.frm_statique_par_time frm_stock = new PL.Statistique.frm_statique_par_time();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][29];
                state_total = Convert.ToInt32(stock);

            }
            if (state_total == 1)
            {
                frm_stock.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm_stock.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void اضافةمنتجبدونفاتورةشراءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Add_stock_sans_facture addstock = new frm_Add_stock_sans_facture(); 
            addstock.ShowDialog();
        }

        private void استيرادسلعةمنEXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_import_by_excel import = new frm_import_by_excel();
            import.ShowDialog();
        }

        private void اضافةمخزنToolStripMenuItem_Click(object sender, EventArgs e)
        {

            PL.Fichier.frm_stockes frm_stock = new PL.Fichier.frm_stockes();
            System.Data.DataTable DT_acces = new System.Data.DataTable(); ;
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][1];
                stocks = Convert.ToInt32(stock);

            }
            if (stocks == 1)
            {
                PLADD.Fichier.frm_add_Stockes add_Stockes = new PLADD.Fichier.frm_add_Stockes(); 
                add_Stockes.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void اضافةوحدةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_unite frm_stock = new PL.Fichier.frm_unite();

            // استدعاء الدالة غير المتزامنة لجلب بيانات الوصول
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));

            //if (DT_acces != null && DT_acces.Rows.Count > 0)
            //{
            object stock = DT_acces.Rows[0][2];
            unite = Convert.ToInt32(stock);

            if (unite == 1)
            {
                PLADD.Fichier.frm_unite add_unite = new PLADD.Fichier.frm_unite(); 
                add_unite.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void اضافةعلامةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_marque frm_stock = new PL.Fichier.frm_marque();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][4];
                marque = Convert.ToInt32(stock);

            }
            if (marque == 1)
            {
                PLADD.Fichier.frm_add_marque add_marque = new PLADD.Fichier.frm_add_marque();
                add_marque.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
            
        }

        private void اضافةصنفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_categories frm_stock = new PL.Fichier.frm_categories();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][3];
                categorie = Convert.ToInt32(stock);

            }
            if (categorie == 1)
            {
                PLADD.Fichier.frm_categories add_categories = new PLADD.Fichier.frm_categories(); 
                add_categories.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void اضافةقياسToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_Taille frmTaille = new PL.Fichier.frm_Taille();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][6];
                taille = Convert.ToInt32(stock);

            }
            if (taille == 1)
            {
                PLADD.Fichier.frm_add_taille add_taille = new PLADD.Fichier.frm_add_taille();
                 add_taille.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void اضافةلونToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_color frm_color = new PL.Fichier.frm_color();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][7];
                color = Convert.ToInt32(stock);

            }
            if (color == 1)
            {
                PLADD.Fichier.frm_add_favoris addColor = new PLADD.Fichier.frm_add_favoris(); 
                addColor.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void اضافةموردToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_fournisseur frm_stock = new PL.Fichier.frm_fournisseur();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][8];
                fournisseure = Convert.ToInt32(stock);

            }
            if (fournisseure == 1)
            {
                PLADD.Fichier.frm_add_fournisseures add_fournisseure = new PLADD.Fichier.frm_add_fournisseures(); 
                add_fournisseure.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void اضافةعاملToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_ouverier frm_stock = new PL.Fichier.frm_ouverier();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][9];
                ouverier = Convert.ToInt32(stock);

            }
            if (ouverier == 1)
            {
                PLADD.Fichier.frm_add_ouverier add_ouverier = new PLADD.Fichier.frm_add_ouverier(); 
                add_ouverier.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void اضافةصرافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_caissier frm_caissier = new PL.Fichier.frm_caissier();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][11];
                caissier = Convert.ToInt32(stock);

            }
            if (caissier == 1)
            {

                PLADD.production.frm_add_caissier add_caissier = new PLADD.production.frm_add_caissier(); 
                add_caissier.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void اضافةزبونجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Fichier.frm_client frm_stock = new PL.Fichier.frm_client();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][12];
                client = Convert.ToInt32(stock);

            }
            if (client == 1)
            {
                PLADD.Fichier.frm_add_client add_client = new PLADD.Fichier.frm_add_client(); 
                add_client.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void اضافةدفعجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.CLient.frm_historique_client histoeique_Client = new PL.CLient.frm_historique_client();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][13];
                historique_client = Convert.ToInt32(stock);

            }
            if (historique_client == 1)
            {
                PLADD.vente.frm_historique_client add_historique_client = new PLADD.vente.frm_historique_client(); 
                add_historique_client.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void الدخوللواجهةالبيعالمباشرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PLADD.vente.frm_logine_caiise1 frmCaisse = new PLADD.vente.frm_logine_caiise1();
            System.Data.DataTable DT_acces = new System.Data.DataTable();
            DT_acces = classLogine.get_ACCES_USer(Convert.ToInt32(ID_user));
            if (DT_acces.Rows.Count > 0)
            {
                object stock = DT_acces.Rows[0][24];
                POS = Convert.ToInt32(stock);

            }
            if (POS == 1)
            {
                frmCaisse.id_user = Convert.ToInt32(ID_user);
                frmCaisse.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذرا ليس مسموح لك ان تقوم بالدخول لهذه الصفحة");
            }
        }

        private void انشاءنسخةاحتياطيةلقاعدةالبياناتالمحليةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string localDbConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB_PRODUCTION_POS.mdf;Integrated Security=True";
            string serverDbConnectionString = @"Data Source=.\SQLEXPRESS;Integrated Security=True";
            string backupFilePath = @"C:\Backup\DB_PRODUCTION_POS.bak";

            // 1. إنشاء النسخة الاحتياطية
            using (SqlConnection localDbConnection = new SqlConnection(localDbConnectionString))
            {
                localDbConnection.Open();
                string backupCommandText = $"BACKUP DATABASE [{localDbConnection.Database}] TO DISK='{backupFilePath}'";

                using (SqlCommand backupCommand = new SqlCommand(backupCommandText, localDbConnection))
                {
                    backupCommand.ExecuteNonQuery(); 
                }
            }

            // 2. استعادة النسخة الاحتياطية إلى SQL Server Express
            using (SqlConnection serverDbConnection = new SqlConnection(serverDbConnectionString))
            {
                serverDbConnection.Open();
                string restoreCommandText = $"RESTORE DATABASE [DB_PRODUCTION_POS] FROM DISK='{backupFilePath}' WITH REPLACE";

                using (SqlCommand restoreCommand = new SqlCommand(restoreCommandText, serverDbConnection))
                {
                    restoreCommand.ExecuteNonQuery(); 
                }
            }
            MessageBox.Show("تم التحميل بنجاح");

        }

        private void notify_Click(object sender, EventArgs e)
        { 
        }

        private void استعلاماتفقطللمطورToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Query frm_qurty = new Form_Query();
            frm_qurty.Show();
        }

        private void إضافةمنتجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_add_produit_simple addstock = new frm_add_produit_simple();
            addstock.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_Add_stock_sans_facture addstock = new frm_Add_stock_sans_facture();
            addstock.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frm_add_produit_editable frm_add = new frm_add_produit_editable();
            frm_add.ShowDialog();
        }

        private void button5_Click_1(object sender, EventArgs e)
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
        //985AEBD59DDD
        //public string GetMacAddress()
        //{
        //	string str = "";
        //	foreach (NetworkInterface interface2 in NetworkInterface.GetAllNetworkInterfaces())
        //	{
        //		try
        //		{
        //			return (str + interface2.GetPhysicalAddress().ToString());
        //		}
        //		catch
        //		{
        //		}
        //	}
        //	return str;
        //}

    }
}
