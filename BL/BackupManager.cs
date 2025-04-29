using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Smart_Production_Pos.BL
{
    public class BackupManager
    {
        public SqlConnection sqlConnection;

        //This Contructor instialize the connection Object
        

        public void CreateBackup(string backupPath)
        {
            try
            {
                //sqlConnection = new SqlConnection(@"Server=DESKTOP-5FUM4DA\SQLEXPRESS; Database=Db_orthophonista ; Integrated Security=true");
                //sqlConnection = new SqlConnection(@"Server=DESKTOP-5FUM4DA\SQLEXPRESS; Database=DB_PRODUCTION_POS; Integrated Security=true");
                string mode = Properties.Settings.Default.mode; 
                if (mode == "SQL")
                {
                    sqlConnection = new SqlConnection(@"Server=" + Properties.Settings.Default.server + "; Database=" + Properties.Settings.Default.dataBase +
                        "; Integrated Security=false ; User ID =" + Properties.Settings.Default.ID + ";Password=" + Properties.Settings.Default.PASS + "");
                }
                else if (mode == "Local")
                {
                     sqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " + @"|DataDirectory|\DB_PRODUCTION_POS.mdf" + "; Integrated Security = True");
                }
                else
                {
                    sqlConnection = new SqlConnection(@"Server=" + Properties.Settings.Default.server + "; Database=" + Properties.Settings.Default.dataBase + "; Integrated Security=true");
                }
                if (string.IsNullOrWhiteSpace(backupPath))
                {
                    return; // لا يوجد مسار محفوظ، لا يتم النسخ الاحتياطي
                }

                string fileName = $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                string fullPath = Path.Combine(backupPath, fileName);

                string query = $"BACKUP DATABASE [DB_PRODUCTION_POS] TO DISK = '{fullPath}' WITH FORMAT, MEDIANAME = 'SQLServerBackups', NAME = 'Full Backup of DB_PRODUCTION_POS';";

                using (sqlConnection)
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("تم إنشاء النسخة الاحتياطية بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ أثناء النسخ الاحتياطي: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
