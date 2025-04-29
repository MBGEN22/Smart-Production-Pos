using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos
{
    public partial class Form_Query : Form
    {
        public Form_Query()
        {
            InitializeComponent();
            LoadServerInstances();
        }

        private void LoadServerInstances()
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            DataTable table = instance.GetDataSources();

            foreach (DataRow row in table.Rows)
            {
                string serverName = row["ServerName"].ToString();
                string instanceName = row["InstanceName"].ToString();
                cmb_server.Items.Add(!string.IsNullOrEmpty(instanceName) ? $"{serverName}\\{instanceName}" : serverName);
            }

            // Manually add .\SQLEXPRESS if not detected
            if (!cmb_server.Items.Contains(@".\SQLEXPRESS"))
            {
                cmb_server.Items.Add(@".\SQLEXPRESS");
            }
        }

        private void Form_Query_Load(object sender, EventArgs e)
        {

        }

        private void cmb_server_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_db.Items.Clear();

            string server = cmb_server.SelectedItem.ToString();
            string connectionString = $"Server={server};Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    DataTable databases = connection.GetSchema("Databases");

                    foreach (DataRow row in databases.Rows)
                    {
                        string databaseName = row["database_name"].ToString();
                        cmb_db.Items.Add(databaseName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Failed to Load Databases", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_refreshDb_Click(object sender, EventArgs e)
        {
            cmb_db.Items.Clear();
            cmb_server_SelectedIndexChanged(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string server = cmb_server.SelectedItem?.ToString();
            string database = cmb_db.SelectedItem?.ToString();
            string query = txt_query.Text;

            if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(database))
            {
                MessageBox.Show("Please select a server and a database.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = $"Server={server};Database={database};Integrated Security=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} rows affected.", "Query Executed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Execution Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
