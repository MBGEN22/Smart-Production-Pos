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
	public partial class frm_server : Form
	{
		public frm_server()
		{
			InitializeComponent(); 
			txtNomDeServeur.Text = Properties.Settings.Default.server;
			txtDataBase.Text = Properties.Settings.Default.dataBase;
			if (Properties.Settings.Default.mode == "SQL")
			{
				rbSql.Checked = true;
				txtUser.Text = Properties.Settings.Default.ID;
				txtPAss.Text = Properties.Settings.Default.PASS;
            }
            else if (Properties.Settings.Default.mode == "Local")
            {
                rb_local.Checked = true;
                txtUser.Clear();
                txtPAss.Clear();
                txtUser.ReadOnly = true;
                txtPAss.ReadOnly = true;
                txtNomDeServeur.Text = @".\SQLEXPRESS";
                txtDataBase.Text = "DB_PRODUCTION_POS";
            }
            else
			{
				rbWindows.Checked = true;
				txtUser.Clear();
				txtPAss.Clear();
				txtUser.ReadOnly = true;
				txtPAss.ReadOnly = true;
			}
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.server = txtNomDeServeur.Text;
			Properties.Settings.Default.dataBase = txtDataBase.Text;
			if (rbSql.Checked == true)
			{
                Properties.Settings.Default.mode = "SQL";

            }
			else if (rbWindows.Checked == true)
            {
                Properties.Settings.Default.mode = "Windows";

            }
            else if (rb_local.Checked == true)
            {
                Properties.Settings.Default.mode = "Local";
            } 
			Properties.Settings.Default.ID = txtUser.Text;
			Properties.Settings.Default.PASS = txtPAss.Text;
			Properties.Settings.Default.Save();
			Application.Restart();
		}

		private void rbWindows_CheckedChanged(object sender, EventArgs e)
		{
			txtUser.ReadOnly = true;
			txtPAss.ReadOnly = true;
		}

		private void rbSql_CheckedChanged(object sender, EventArgs e)
		{
			txtUser.ReadOnly = false;
			txtPAss.ReadOnly = false;
		}

        private void frm_server_FormClosed(object sender, FormClosedEventArgs e)
        {
			Application.Exit();      
		}

        private void kryptonGroup2_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void krypXXtonButton4_Click(object sender, EventArgs e)
        {
            Form_Query frm_qurty = new Form_Query();
            frm_qurty.Show();
        }
    }
}
