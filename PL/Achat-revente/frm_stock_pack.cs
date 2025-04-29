using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Achat_revente
{
	public partial class frm_stock_pack : Form
	{
		BL.BL_ACHAT_REVENT.BL_PRODUIT classProduit = new BL.BL_ACHAT_REVENT.BL_PRODUIT();
		public frm_stock_pack()
		{
			InitializeComponent();
			this.dataGridView1.DataSource = classProduit.get_stock_pack();
		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{ 
			dataGridView1.DataSource = classProduit.search_pack_prevent_by_code_Barre_U(kryptonTextBox1.Text);
		}

		private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
		{
			dataGridView1.DataSource = classProduit.search_pack_prevent_by_code_Barre_Pack(kryptonTextBox2.Text);
		}

		private void طباعةالكودبارToolStripMenuItem_Click(object sender, EventArgs e)
		{
			report.code_barre_P_Revent.pack.code_Barre_pack rpt = new report.code_barre_P_Revent.pack.code_Barre_pack();
			string mode = Properties.Settings.Default.mode;
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

		private void تعديلمعلوماتالحزمةToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PLADD.Achat_revente.frm_edit_Pack_information pack_info = new PLADD.Achat_revente.frm_edit_Pack_information(); 
			DataTable dtProduit = new DataTable();
			dtProduit = classProduit.get_info_Pack_edit(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
			object codeBarre = dtProduit.Rows[0][0];
			object designation = dtProduit.Rows[0][1]; 
			object fav = dtProduit.Rows[0][6];
			object Prix1 = dtProduit.Rows[0][4];
			Byte[] image_array = (byte[])dtProduit.Rows[0][5];

			pack_info.txtBarcode.Text = codeBarre.ToString(); 
			pack_info.txt_vente_1.Text = Prix1.ToString();
            if (fav.ToString() != "")
            {
                pack_info.cmb_favoire.Enabled = true;
                pack_info.cmb_favoire.Text = fav.ToString();
            }
            else
            {
                pack_info.cmb_favoire.Enabled = false;
            }
            pack_info.cmb_favoire.Text = fav.ToString();
			pack_info.txt_designation.Text = designation.ToString();
			using (MemoryStream ms = new MemoryStream(image_array))
			{
				pack_info.pictureBox2.Image = Image.FromStream(ms);
			}
			pack_info.formStock = this;
			pack_info.ShowDialog();
		}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            string codebr = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            label9.Text = codebr;
            Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBox7.Image = brCode.Draw(codebr, 100);
            using (MemoryStream mss = new MemoryStream())
            {
                System.Drawing.Image barcodeImage = brCode.Draw(codebr, 100);
                barcodeImage.Save(mss, ImageFormat.Png); // Save the image in PNG format

                // Convert MemoryStream to byte array
                byte[] byteImage = mss.ToArray();

                // Call the method to add the picture
                classProduit.update_code_baree_pack(codebr, byteImage);
            }
        }
    }
}
