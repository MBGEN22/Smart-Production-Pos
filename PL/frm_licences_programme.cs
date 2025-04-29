using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL
{
	public partial class frm_licences_programme : Form
	{
		BL.BL_FICHIER.BL_fctr classFacteeunr = new BL.BL_FICHIER.BL_fctr();
		int count = 0;
		public frm_licences_programme()
		{
			InitializeComponent();
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

		private void frm_licences_programme_Load(object sender, EventArgs e)
		{ 
			textBox1.Text = GetMacAddress();
		}

		private void frm_licences_programme_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void kryptonButton7_Click(object sender, EventArgs e)
		{
			 DataTable dt = new DataTable();
			dt = classFacteeunr.getFctr();
			string MacAdress = GetMacAddress();
			string what = Decrypt(txtSerial.Text);
			//testSerial
			if (what != MacAdress)
			{
				MessageBox.Show("الرقم الذي ادخلته خاطئ");
				txtSerial.Text = "";
				txtSerial.Focus(); 
			}
			else
			{
				if (dt.Rows.Count > 0)
				{
					classFacteeunr.insert_proc_(
						textBox1.Text,
						txtSerial.Text,
						Convert.ToDateTime(DateTime.Now)
						); 
					MessageBox.Show("تم تفعيل البرنامج بنجاح ");
					Application.Restart();
				}
				else
				{
					classFacteeunr.insert_proc_(
						textBox1.Text,
						txtSerial.Text,
						Convert.ToDateTime(DateTime.Now)
						);
					MessageBox.Show("تم تفعيل البرنامج بنجاح ");
					Application.Restart();
				}
			}
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if textBox1 has any text
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                // Copy the text from textBox1 to the clipboard
                Clipboard.SetText(textBox1.Text);
                MessageBox.Show("تم نسخ الرقم بنجاح");
            }
            else
            {
                MessageBox.Show("TextBox is empty, nothing to copy.");
            }
        }
    }
}
