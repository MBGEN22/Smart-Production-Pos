using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.save_and_backup
{
	public partial class frm_backup : Form
	{
		DAL.DAL daoo = new DAL.DAL();
		SqlCommand cmd;
		public frm_backup()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				txtautomatiqie.Text = openFileDialog1.FileName;
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			SqlConnection con = daoo.sqlConnection;

			// string filename = txtautomatiqie.Text + "\\DB_PRODUCTION" + DateTime.Now.ToShortDateString().Replace('/', '-') + " - " + DateTime.Now.ToLongTimeString().Replace(':', '-');
			string strQuery = "ALTER Database DB_PRODUCTION_POS SET OFFLINE WITH ROLLBACK IMMEDIATE ; Restore Database DB_PRODUCTION_POS From Disk ='" + txtautomatiqie.Text + "'";

			cmd = new SqlCommand(strQuery, con);
			con.Open();
			cmd.ExecuteNonQuery();
			MessageBox.Show("data une restore");
		}
	}
}
