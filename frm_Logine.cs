using Microsoft.VisualBasic.Logging;
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
	public partial class frm_Logine : Form
	{
		BL.Sp_Logine log = new BL.Sp_Logine();
		Form1 form;
		public SplachScreen splach;
		string name;
		//clc_edit prd = new clc_edit();
		public frm_Logine()
		{
			InitializeComponent();
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{

			form = new Form1();
			DataTable Dt = log.LOGIN(txtUser.Text, txtPassword.Text);
			if (Dt.Rows.Count > 0)
			{
				Object userID = Dt.Rows[0][0];
				Object Role = Dt.Rows[0][5];
				Object Names = Dt.Rows[0][1]; 
				Object prename = Dt.Rows[0][2]; 

				form.ID_user = userID.ToString();
				form.Role = Role.ToString();
				form.User = Names.ToString();
				form.lb_user.Text = Names.ToString() + " " + prename.ToString();
				form.lb_role.Text = Role.ToString(); 
				log.update_user_whene_logine(
					Convert.ToInt32(userID),
					"نشط"
					);
				form.Show();
                this.ShowInTaskbar = false; 
				this.Close();

            }
			else
			{
                txtPassword.Text = "";
                txtPassword.StateCommon.Back.Color1 = Color.Red;
                txtPassword.Focus(); 
                MessageBox.Show("كلمة السر او اسم المستخدم خاطئ يرجى التأكد وإعادة تسجيل الدخول ");
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			txtPassword.UseSystemPasswordChar=false;
		}

        private void frm_Logine_Load(object sender, EventArgs e)
        {
			
        }

        private void kryptonButton4_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                form = new Form1();
                DataTable Dt = log.LOGIN(txtUser.Text, txtPassword.Text);
                if (Dt.Rows.Count > 0)
                {
                    Object userID = Dt.Rows[0][0];
                    Object Role = Dt.Rows[0][5];
                    Object Names = Dt.Rows[0][1];
                    Object prename = Dt.Rows[0][2];

                    form.ID_user = userID.ToString();
                    form.Role = Role.ToString();
                    form.User = Names.ToString();
                    form.lb_user.Text = Names.ToString() + " " + prename.ToString();
                    form.lb_role.Text = Role.ToString();
                    log.update_user_whene_logine(
                        Convert.ToInt32(userID),
                        "نشط"
                        );
                    form.Show();
                    this.ShowInTaskbar = false;
                    this.Close();

                }
                else
                {
                    txtPassword.Text = "";
                    txtPassword.StateCommon.Back.Color1 = Color.Red;
                    txtPassword.Focus();
                    MessageBox.Show("كلمة السر او اسم المستخدم خاطئ يرجى التأكد وإعادة تسجيل الدخول ");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            frm_Recupiration recupi = new frm_Recupiration();
            recupi.Show();
        }

        private void استعلاماتفقطللمطورToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Query frm_qurty = new Form_Query();
            frm_qurty.Show();
        }
    }
}
