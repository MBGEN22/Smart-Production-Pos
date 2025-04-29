using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.vente
{
    public partial class frm_routeure_article : Form
    {
        BL.BL_vente.BL_vente_retoure articleRouteur = new BL.BL_vente.BL_vente_retoure();

        public frm_routeure_article()
        {
            InitializeComponent();
            this.kryptonDataGridView1.DataSource = articleRouteur.get_TB_routeur();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        { 
            this.kryptonDataGridView1.DataSource = articleRouteur.get_TB_routeur();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (kryptonDataGridView1.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.ApplicationClass MExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                MExcel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < kryptonDataGridView1.Columns.Count + 1; i++)
                {
                    MExcel.Cells[1, i] = kryptonDataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < kryptonDataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < kryptonDataGridView1.Columns.Count; j++)
                    {
                        MExcel.Cells[i + 2, j + 1] = kryptonDataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                MExcel.Columns.AutoFit();
                MExcel.Rows.AutoFit();
                MExcel.Columns.Font.Size = 12;
                MExcel.Visible = true;
            }
            else
            {
                MessageBox.Show("No records found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = articleRouteur.get_list_routeure_By_date(Convert.ToDateTime(kryptonDateTimePicker1.Value));
            kryptonDataGridView1.DataSource = dt;
        }
    }
}
