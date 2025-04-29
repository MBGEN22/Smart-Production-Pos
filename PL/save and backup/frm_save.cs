using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.save_and_backup
{
	public partial class frm_save : Form
	{
		DAL.DAL daoo;
		SqlCommand cmd;
		public frm_save()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				txtautomatiqie.Text = folderBrowserDialog1.SelectedPath;
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			daoo = new DAL.DAL();

			string directoryPath = txtautomatiqie.Text;
			string fileName = "DB_PRODUCTION_POS" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".bak";
			string filePath = Path.Combine(directoryPath, fileName);

			string strQuery = "BACKUP DATABASE DB_PRODUCTION_POS TO DISK=@filePath";
			SqlCommand cmd = new SqlCommand(strQuery, daoo.sqlConnection);
			cmd.Parameters.AddWithValue("@filePath", filePath);

			daoo.sqlConnection.Open();
			cmd.ExecuteNonQuery();
			daoo.sqlConnection.Close();
			MessageBox.Show("Backup created successfully.");
		}
	}
}
