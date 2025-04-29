using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Smart_Production_Pos.PL.paramtre
{
	public partial class frm_information : Form
	{
		BL.BL_parametre.BL_paramtre_informatiion classInformation = new BL.BL_parametre.BL_paramtre_informatiion();
		public int id; 
		string PRINT_FACTURE;
        string PRINT_BON;
        string PRINT_BON_A4;
        BL.BL_NOTOFY classNotify = new BL.BL_NOTOFY();
        string DONT_PRINT; 
        BL.BL_parametre.BL_paramtre_informatiion class_setting = new BL.BL_parametre.BL_paramtre_informatiion();
        public frm_information()
		{
			InitializeComponent();
			DataTable dt = classInformation.get_inforamtion();
            if (dt.Rows.Count > 0)
            {

                DataTable dtP = new DataTable();
                dtP = classNotify.get_parametre_day();
                object DayVelue = dtP.Rows[0][0];
                int DayVelueC = Convert.ToInt16(DayVelue); 
				numericUpDown1.Value = DayVelueC;

                object NAME = dt.Rows[0][0];
				object PRENAME = dt.Rows[0][1];
				object ADRESS = dt.Rows[0][2];
				object ACTIVITY = dt.Rows[0][3];
				object NMR_REGISTRE = dt.Rows[0][4];
				object NMR_MATIER = dt.Rows[0][5];
				object NMR_JIBAI = dt.Rows[0][6];
				object LOGO = dt.Rows[0][7];
				object WILAYA = dt.Rows[0][9]; 
				object ID = dt.Rows[0][8];
				object CompanyName = dt.Rows[0][10]; 
				object Phone = dt.Rows[0][11];
				object Message = dt.Rows[0][12];
				if (LOGO != DBNull.Value && LOGO is Image logoImage)
				{
					pictureBox1.Image = logoImage;
				}
				txt_name.Text = NAME.ToString();
				txt_prename.Text = PRENAME.ToString();
				txt_adress.Text = ADRESS.ToString();
				txt_activity.Text = ACTIVITY.ToString();
				txt_nmr_sjl.Text = NMR_REGISTRE.ToString();
				nmr_matier.Text = NMR_MATIER.ToString();
				nmr_txt_jibai.Text = NMR_JIBAI.ToString();
				wilayay.Text = WILAYA.ToString();
				kryptonTextBox1.Text = CompanyName.ToString();
				id = int.Parse(ID.ToString());
				kryptonTextBox2.Text = Phone.ToString();
				kryptonTextBox3.Text = Message.ToString();
			}
			else
			{
				MessageBox.Show("لاتوجد معلومات مسبقة");
			}
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			OpenFileDialog Ofd = new OpenFileDialog();
			Ofd.Filter = "Photo |*.JPG; *.PNG; *.GIF; *.BMP ";
			if (Ofd.ShowDialog() == DialogResult.OK)
			{
				pictureBox1.Image = Image.FromFile(Ofd.FileName);
			}
		}

		private void frm_information_Load(object sender, EventArgs e)
		{
			DataTable dt = classInformation.get_inforamtion();
			if (dt.Rows.Count > 0)
			{
				object NAME = dt.Rows[0][0];
				object PRENAME = dt.Rows[0][1];
				object ADRESS = dt.Rows[0][2];
				object ACTIVITY = dt.Rows[0][3];
				object NMR_REGISTRE = dt.Rows[0][4];
				object NMR_MATIER = dt.Rows[0][5];
				object NMR_JIBAI = dt.Rows[0][6];
				object LOGO = dt.Rows[0][7];
				object WILAYA = dt.Rows[0][9];
				object CompanyName = dt.Rows[0][10];
				object Phone = dt.Rows[0][11];
				object Message = dt.Rows[0][12];

				Byte[] image_array = (byte[])dt.Rows[0][7];
				using (MemoryStream ms = new MemoryStream(image_array))
				{
					pictureBox1.Image = Image.FromStream(ms);
				}
				txt_name.Text = NAME.ToString();
				txt_prename.Text = PRENAME.ToString();
				txt_adress.Text = ADRESS.ToString();
				txt_activity.Text = ACTIVITY.ToString();
				txt_nmr_sjl.Text = NMR_REGISTRE.ToString();
				nmr_matier.Text = NMR_MATIER.ToString();
				nmr_txt_jibai.Text = NMR_JIBAI.ToString(); 
				wilayay.Text = WILAYA.ToString();
				kryptonTextBox1.Text = CompanyName.ToString();
				kryptonTextBox2.Text = Phone.ToString();
				kryptonTextBox3.Text = Message.ToString();
			}
			else
			{
				MessageBox.Show("لاتوجد معلومات مسبقة");
			}

            DataTable dtt = new DataTable();
            dtt = class_setting.Get_paramater_tb();
            object PRINT_FACTURE = dtt.Rows[0][0]; ;
            object PRINT_BON = dtt.Rows[0][1]; ;
            object PRINT_BON_A4 = dtt.Rows[0][2]; ;
            object DONT_PRINT = dtt.Rows[0][3]; ;

            string PRINT_FACTUREe = PRINT_FACTURE.ToString();
            string PRINT_BONn = PRINT_BON.ToString();
            string PRINT_BON_A44 = PRINT_BON_A4.ToString();
            string DONT_PRINTt = DONT_PRINT.ToString();

            if (PRINT_FACTUREe.ToString() == "true")
            {
                chech_facture.Checked = true;

            }
            else if (PRINT_BONn.ToString() == "true")
            {
                check_bon.Checked = true;
            }
            else if (PRINT_BON_A44.ToString() == "true")
            {
                check_bon_A4.Checked = true;
            }
            else if (DONT_PRINTt.ToString() == "true")
            {
                chec_no.Checked = true;
            }

            DataTable dtP = new DataTable();
            dtP = classNotify.get_parametre_day();
            object DayVelue = dtP.Rows[0][0];
            int DayVelueC = Convert.ToInt16(DayVelue);
			numericUpDown1.Value = DayVelueC;
        }

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
		
			if (chech_facture.Checked == true)
			{
				PRINT_FACTURE = "true";
			}
			else if (chech_facture.Checked == false)
            {
                PRINT_FACTURE = "false";
            }
			//
            if (check_bon.Checked == true)
            {
                PRINT_BON = "true";
            }
            else if (check_bon.Checked == false)
            {
                PRINT_BON = "false";
            }
			//
            if (check_bon_A4.Checked == true)
            {
                PRINT_BON_A4 = "true";
            }
            else if (check_bon_A4.Checked == false)
            {
                PRINT_BON_A4 = "false";
            }
			//
            if (chec_no.Checked == true)
            {
                DONT_PRINT = "true";
            }
            else if (chec_no.Checked == false)
            {
                DONT_PRINT = "false";
            }
            MemoryStream ms = new MemoryStream();
			pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
			byte[] byteImage = ms.ToArray();


			classInformation.edit_setting(
				txt_name.Text
				,txt_prename.Text
				,txt_adress.Text
				,txt_activity.Text
				,txt_nmr_sjl.Text
				,nmr_matier.Text
				, nmr_txt_jibai.Text
				, byteImage
				,wilayay.Text
				, kryptonTextBox1.Text
				, id
				, kryptonTextBox2.Text
				, kryptonTextBox3.Text
				, PRINT_FACTURE,
                  PRINT_BON 	,
				 PRINT_BON_A4 ,
				 DONT_PRINT ,
                Convert.ToInt32( numericUpDown1.Value)
                );
			MessageBox.Show("تم تعديل المعلوما بنجاح");


			DataTable dt = classInformation.get_inforamtion();
			if (dt.Rows.Count > 0)
			{
				object NAME = dt.Rows[0][0];
				object PRENAME = dt.Rows[0][1];
				object ADRESS = dt.Rows[0][2];
				object ACTIVITY = dt.Rows[0][3];
				object NMR_REGISTRE = dt.Rows[0][4];
				object NMR_MATIER = dt.Rows[0][5];
				object NMR_JIBAI = dt.Rows[0][6];
				object LOGO = dt.Rows[0][7];
				object WILAYA = dt.Rows[0][9];
				object CompanyName = dt.Rows[0][10];
				object Phone = dt.Rows[0][11];
				object Message = dt.Rows[0][12];

				txt_name.Text			= NAME.ToString();
				txt_prename.Text = PRENAME.ToString();
				txt_adress.Text		= ADRESS.ToString();
				txt_activity.Text		= ACTIVITY.ToString();
				txt_nmr_sjl.Text		= NMR_REGISTRE.ToString();
				nmr_matier.Text		= NMR_MATIER.ToString();
				nmr_txt_jibai.Text = NMR_JIBAI.ToString();
				wilayay.Text				= WILAYA.ToString();
				kryptonTextBox1.Text = CompanyName.ToString();
				kryptonTextBox2.Text = Phone.ToString();
				kryptonTextBox3.Text = Message.ToString();
			}
			else
			{
				MessageBox.Show("لاتوجد معلومات مسبقة");
			}
		}

        private void kryptonGroup1_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonGroup2_Panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
