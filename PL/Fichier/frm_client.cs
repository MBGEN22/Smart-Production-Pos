using Smart_Production_Pos.TAB_CONTROL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Fichier
{
	public partial class frm_client : Form
	{
        BL.BL_Statistique.Query_Statistique classQyeru_state = new BL.BL_Statistique.Query_Statistique();
        BL.BL_FICHIER.BL_Client classClient = new BL.BL_FICHIER.BL_Client();
		public frm_client()
		{
			InitializeComponent();
			dataGridView1.DataSource = classClient.Get_clien_Table();
            txt_vers_client.Text = classQyeru_state.vers_client();
            txt_rest_client.Text = classQyeru_state.rest_client();
        }

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_add_client add_client = new PLADD.Fichier.frm_add_client();
			add_client.frm_clieent = this;
			add_client.ShowDialog();
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_add_client add_client = new PLADD.Fichier.frm_add_client();
			add_client.frm_clieent = this;  
			add_client.id = (int)this.dataGridView1.CurrentRow.Cells[0].Value;
			add_client.name_client.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
			add_client.prename_client.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
			add_client.txt_adress.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
			add_client.txt_phone.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
			add_client.txt_fax.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
			add_client.txt_email.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
			add_client.txt_total.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
			add_client.txt_versé.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
			add_client.txt_rest.Text   = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
			add_client.txt_avance.Text = this.dataGridView1.CurrentRow.Cells[10].Value.ToString();
			add_client.txt_retard.Text = this.dataGridView1.CurrentRow.Cells[11].Value.ToString();
			add_client.txt_nif.Text = this.dataGridView1.CurrentRow.Cells[12].Value.ToString();
			add_client.txt_rc.Text = this.dataGridView1.CurrentRow.Cells[13].Value.ToString();
			add_client.txt_nic.Text = this.dataGridView1.CurrentRow.Cells[14].Value.ToString();
			add_client.txt_article.Text = this.dataGridView1.CurrentRow.Cells[15].Value.ToString();
			add_client.ShowDialog();
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{
            try
            {
                if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    classClient.delte_Client((int)this.dataGridView1.CurrentRow.Cells[0].Value);
                    dataGridView1.DataSource = classClient.Get_clien_Table();
                    MessageBox.Show("تمت عملية الحذف بنجاح");
                }
            }
            catch
            {
                MessageBox.Show("هذا الزبون مربوط ببيانات حساسة لايمكن حذفها");
            }
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{

			dataGridView1.DataSource = classClient.Get_clien_Table();
		}

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			DataTable dtt = new DataTable();
			dtt = classClient.search_client(txtSearch.Text);
			dataGridView1.DataSource = dtt;
		}

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                report.historique_Client.RPT_DETAILLE_FCTR rpt = new report.historique_Client.RPT_DETAILLE_FCTR();
                #region re
                string mode = Properties.Settings.Default.mode;
                if (mode == "SQL")
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = false;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, Properties.Settings.Default.ID, Properties.Settings.Default.PASS);

                    rpt.Refresh();
                    rpt.SetParameterValue("@ID_CLIENT", this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
                else
                {
                    rpt.DataSourceConnections[0].IntegratedSecurity = true;
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.server, Properties.Settings.Default.dataBase, true);

                    rpt.Refresh();
                    rpt.SetParameterValue("@ID_CLIENT", this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    report.viewer_report viewer = new report.viewer_report();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
                #endregion
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (dataGridView1.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.ColumnHeader ||
                dataGridView1.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.TopLeftHeader)
            {
                ContextMenu menu = new ContextMenu();

                //add item to the menu
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    MenuItem item = new MenuItem();
                    item.Text = column.HeaderText;
                    item.Checked = column.Visible;

                    //now let add the event if the item was cheked
                    item.Click += (obj, ea) =>
                    {
                        column.Visible = !item.Checked;

                        //update the check
                        item.Checked = column.Visible;

                        //show the selection item 
                        menu.Show(dataGridView1, e.Location);
                    };
                    menu.MenuItems.Add(item);
                }
                //show the menu 
                menu.Show(dataGridView1, e.Location);

            }
        }
    }
}
