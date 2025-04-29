using Smart_Production_Pos.PL.paramtre;
using Smart_Production_Pos.PLADD.Fichier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos
{
	public partial class SplachScreen : Form
	{
		BL.BL_FICHIER.BL_fctr classFctr = new BL.BL_FICHIER.BL_fctr();
		//frm_Server frmserver;
		private Timer timer;
		 frm_Logine logine= new frm_Logine();
        //Form1 frmmain = new Form1();
        
		
		#region form
        private static SplachScreen frm;
        static void frm_formClosed(Object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static SplachScreen getMainForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new SplachScreen();
                    frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
                }
                return frm;
            }
        }
        #endregion
        public SplachScreen()
		{
			InitializeComponent();
			circleProgressBar1.ValueNumber = 0;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			circleProgressBar1.ValueNumber += 6;
			if (circleProgressBar1.ValueNumber == 30)
			{
				Lb_text.Text = "محاولة الاتصال بقاعدة البيانات";
			}
            else if (circleProgressBar1.ValueNumber == 40)
            {
                Lb_text.Text = "كل فواتير الشراء والبيع تسجل بدقة";
            }
            else if (circleProgressBar1.ValueNumber == 50)
            {
                Lb_text.Text = "لاتنسى حفظ نسخة من قاعدة البيانان عند نهاية كل أسبوع";
            }
            else if (circleProgressBar1.ValueNumber == 60)
			{
				Lb_text.Text = "يمكنك تتبع التحويلات مع الزبائن والموردين بدقة";
			}
            else if (circleProgressBar1.ValueNumber == 70)
            {
                Lb_text.Text = "نحن مستعدين لتقديم افضل خدمة ممكنة لكم";
            }
            else if (circleProgressBar1.ValueNumber == 90)
			{
				Lb_text.Text = "من تطوير  محمد بومرداسي";
			}
			else if (circleProgressBar1.ValueNumber == 100)
			{
				timer1.Enabled = false;
				check_if_trial_expirence();
			}
		}

		private void check_if_trial_expirence()
		{
			try
			{
				DAL.DAL DAL = new DAL.DAL();
				SqlConnection connectionString;
				connectionString = DAL.sqlConnection;
				//connectionString =   new SqlConnection(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\DB_PRODUCTION_POS.mdf;integrated security=True");

                string query = "SELECT COUNT(*) FROM [TB_MAX_ADRESS]";

				using (connectionString)
				{
					SqlCommand command = new SqlCommand(query, connectionString);
					connectionString.Open();
					int MacAdressCount = (int)command.ExecuteScalar();

					if (MacAdressCount == 0)
					{
						//calculeFacteur 
						string QR = "SELECT COUNT(*) FROM [TB_FACTURE_VENTE]";
						string QR_commande = "SELECT COUNT(*) FROM [TB_COMMANDE]";
						string QRClient = "SELECT COUNT(*) FROM [TB_CLIENT]";
                        string QRFournisseure = "SELECT COUNT(*) FROM [TB_FOURNISSUER]";
                        string QRCaissier = "SELECT COUNT(*) FROM [TB_INFO_CAISSIER]"; 
                        string QR_facture_Achat = "SELECT COUNT(*) FROM [TB_FACTURE_ACHAT_PRODUIT_REVENT]";
                        string QR_produit_revent = "SELECT COUNT(*) FROM [TB_Produit_revente]";


                        SqlCommand cmd = new SqlCommand(QR, connectionString);
                        SqlCommand cmdClient = new SqlCommand(QRClient, connectionString);
                        SqlCommand cmdFournisseuret = new SqlCommand(QRFournisseure, connectionString);
                        SqlCommand cmd_commande = new SqlCommand(QR_commande, connectionString);
                        SqlCommand cmdCaissier = new SqlCommand(QRCaissier, connectionString);
                        SqlCommand cmdfacture_Achat = new SqlCommand(QR_facture_Achat, connectionString);
                        SqlCommand cmd_produit_revent = new SqlCommand(QR_produit_revent, connectionString);

                        int CountFacteureVente = (int)cmd.ExecuteScalar();
                        int CountClient = (int)cmdClient.ExecuteScalar();
                        int Countfrnsre = (int)cmdFournisseuret.ExecuteScalar();
                        int count_commande = (int)cmd_commande.ExecuteScalar();
                        int count_Caissier = (int)cmdCaissier.ExecuteScalar();
                        int count_facture_Achat = (int)cmdfacture_Achat.ExecuteScalar();
						int count_produit_revent = (int)cmd_produit_revent.ExecuteScalar();

                        if (CountFacteureVente == 0 && count_commande == 0 && CountClient == 1 && Countfrnsre == 1  && count_Caissier <2 && count_facture_Achat <10)
                        {
                            MessageBox.Show("نسختك التجريبية تبدأ الآن\n" +
											"15 فاتورة بيع\n" +
											"3 زبائن\n" +
											"3 موردين\n" +
											"1 قابض\n" +
                                            "09 فواتير شراء\n" +
                                            "20 منتج\n"
                                            + "لا تستطيع طباعة الفواتير في هذه النسخة");

                            string queyr_user = "SELECT COUNT(*) FROM TB_USER";
							using (connectionString)
							{
								SqlCommand cmd_user = new SqlCommand(queyr_user, connectionString);
								int userCount = (int)cmd_user.ExecuteScalar();

								if (userCount == 0)
								{
									// Aucun utilisateur n'existe, afficher le formulaire pour ajouter des utilisateurs
									frm_add_user form = new frm_add_user();
									form.kryptonButton4.Text = "حفظ واعادة تشغيل";
									form.Show();
									this.Hide();
								}
								else
								{
									// Des utilisateurs existent, afficher le formulaire de connexion
									logine.Show();
									logine.splach = this;
									this.Hide(); // Cacher le formulaire de chargement
								}

								// Cacher le formulaire de chargement
							}

						}
						else if (CountFacteureVente >= 15 || count_commande >= 15 )
						{
							MessageBox.Show("انتهت النسخة التجريبية الخاصة بك  اذا اردت اقتناء النسخة الكاملة اتصل بنا");
							PL.frm_licences_programme license = new PL.frm_licences_programme();
							license.ShowDialog();
						}
                        else if (CountClient >= 4 || Countfrnsre >= 4)
                        {
                            MessageBox.Show("انتهت النسخة التجريبية الخاصة بك  اذا اردت اقتناء النسخة الكاملة اتصل بنا");
                            PL.frm_licences_programme license = new PL.frm_licences_programme();
                            license.ShowDialog();
                        }
                        else if (count_Caissier > 1 )
                        {
                            MessageBox.Show("انتهت النسخة التجريبية الخاصة بك  اذا اردت اقتناء النسخة الكاملة اتصل بنا");
                            PL.frm_licences_programme license = new PL.frm_licences_programme();
                            license.ShowDialog();
                        }
                        else if (count_facture_Achat >= 10 )
                        {
                            MessageBox.Show("انتهت النسخة التجريبية الخاصة بك  اذا اردت اقتناء النسخة الكاملة اتصل بنا");
                            PL.frm_licences_programme license = new PL.frm_licences_programme();
                            license.ShowDialog();
                        }
                        else if (count_produit_revent >= 20)
                        {
                            MessageBox.Show("انتهت النسخة التجريبية الخاصة بك  اذا اردت اقتناء النسخة الكاملة اتصل بنا");
                            PL.frm_licences_programme license = new PL.frm_licences_programme();
                            license.ShowDialog();
                        }
                        else
						{
							string queyr_user = "SELECT COUNT(*) FROM TB_USER";
							using (connectionString)
							{
								SqlCommand cmd_user = new SqlCommand(queyr_user, connectionString);
								int userCount = (int)cmd_user.ExecuteScalar();

								if (userCount == 0)
								{
									// Aucun utilisateur n'existe, afficher le formulaire pour ajouter des utilisateurs
									frm_add_user form = new frm_add_user();
									form.kryptonButton4.Text = "حفظ واعادة تشغيل";
									form.Show();
									this.Hide();
								}
								else
								{
									// Des utilisateurs existent, afficher le formulaire de connexion
									logine.ShowDialog();
									this.Hide(); // Cacher le formulaire de chargement
								}

								// Cacher le formulaire de chargement
							}
						}
					}
					else
					{
						//checl PC
						DataTable dt = new DataTable();
						dt = classFctr.getFctr();
						string MacAdress = GetMacAddress();
						object crypting = dt.Rows[0][2];
						string decryotin = Decrypt(crypting.ToString());
						if (decryotin != MacAdress.ToString())
						{

							MessageBox.Show("المفتاح الذي استعملته غير متطابق مع هذا الجهاز","المفتاح خطأ",MessageBoxButtons.OK,MessageBoxIcon.Error);
							PL.frm_licences_programme form = new PL.frm_licences_programme();
							form.ShowDialog();
						}
						else
						{
							string queyr_user = "SELECT COUNT(*) FROM TB_USER";
							using (connectionString)
							{
								SqlCommand cmd_user = new SqlCommand(queyr_user, connectionString);
								int userCount = (int)cmd_user.ExecuteScalar();

								if (userCount == 0)
								{
									// Aucun utilisateur n'existe, afficher le formulaire pour ajouter des utilisateurs
									frm_add_user form = new frm_add_user();
									form.kryptonButton4.Text = "حفظ واعادة تشغيل";
									form.Show();
									this.Hide();
								}
								else
								{
									// Des utilisateurs existent, afficher le formulaire de connexion
									logine.ShowDialog();
									this.Hide(); // Cacher le formulaire de chargement
								}

								// Cacher le formulaire de chargement
							}
						}
					}

				}
			}
			catch (Exception ex)
			{
				frm_server server = new frm_server();
				var st = MessageBox.Show(ex.Message);
				server.ShowDialog(); 
			}
		}
		//public string GetMacAddress()
		//{
		//	ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT VolumeSerialNumber FROM Win32_LogicalDisk WHERE DeviceID='C:'");
		//	foreach (ManagementObject disk in searcher.Get())
		//	{
		//		return disk["VolumeSerialNumber"].ToString();
		//	}
		//	return string.Empty;
		//}

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
		private void CheckUserExistence()
		{
			try
			{

				DAL.DAL DAL = new DAL.DAL();
				SqlConnection connectionString;
				connectionString = DAL.sqlConnection; 
				string query = "SELECT COUNT(*) FROM TB_USER";

				using (connectionString)
				{
					SqlCommand command = new SqlCommand(query, connectionString);
					connectionString.Open();
					int userCount = (int)command.ExecuteScalar();

					if (userCount == 0)
					{
						// Aucun utilisateur n'existe, afficher le formulaire pour ajouter des utilisateurs
						frm_add_user form = new frm_add_user();
						form.kryptonButton4.Text = "حفظ واعادة تشغيل";
						form.Show();
						this.Hide();
					}
					else
					{
						// Des utilisateurs existent, afficher le formulaire de connexion
						logine.ShowDialog();
						this.Hide(); // Cacher le formulaire de chargement
					}

					// Cacher le formulaire de chargement
				}
			}
			catch
			{
				frm_server server = new frm_server();
				server.ShowDialog();
			}
		}

        private void kryptonGroup1_Panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

