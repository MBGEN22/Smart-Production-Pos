using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.PL_reparation
{
    public partial class frm_reparation : Form
    {
        BL.BL_REPARATION.BL_REPARATION class_reparation = new BL.BL_REPARATION.BL_REPARATION();
        public int id_user;
        public frm_reparation()
        {
            InitializeComponent();
            dataGridView1.DataSource = class_reparation.GetRepatationRecords();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_add_reparation add_reparation = new frm_add_reparation();
            add_reparation.id_user = id_user;
            add_reparation.frm_reparation = this;
            add_reparation.ShowDialog();
        }
        private void print()
        {
            PL.PL_reparation.reciepe_reperation rpt = new PL.PL_reparation.reciepe_reperation();
            //#region re
            string mode = Properties.Settings.Default.mode;
            if (mode == "Local")
            {

            }
            else
            {
                if (mode == "SQL")
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = false;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                    rpt.Refresh();
                    rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value); 
                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
                else
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = true;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                    rpt.Refresh();
                    rpt.SetParameterValue("@code_barre", this.dataGridView1.CurrentRow.Cells[0].Value); 
                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
            }
        }
        private void buttdon1_Click(object sender, EventArgs e)
        {
            print();
        }

        private void bdutton1_Click(object sender, EventArgs e)
        {
            frm_edit_reparation edit_reparation = new frm_edit_reparation();
            edit_reparation.frm_reparation = this;
            edit_reparation.txtBarcode.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            edit_reparation.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();
            DT = class_reparation.SEARCH_REPT(textBox1.Text);
            dataGridView1.DataSource = DT;
        }
    }
}
