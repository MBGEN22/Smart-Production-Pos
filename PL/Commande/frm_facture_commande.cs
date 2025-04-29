using Smart_Production_Pos.BL.Bl_commande;
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

namespace Smart_Production_Pos.PL.Commande
{
	public partial class frm_facture_commande : Form
	{
		BL_proforma_commande classCommande_proforma = new BL_proforma_commande();
		public frm_facture_commande()
		{
			InitializeComponent();
			this.dataGridView1.DataSource = classCommande_proforma.get_table_commande_proforama("فاتورة أولية");
		}

		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			string rpns;
			PLADD.commande.edit_comande_proforma add_commande = new PLADD.commande.edit_comande_proforma();
			add_commande.txt_id_commande.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
			add_commande.cmb_client.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
			add_commande.txtname.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
			add_commande.cmb_tupe.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
			rpns = check_tmbre();
			if (rpns == "y")
			{
				add_commande.check_tmber.Checked = false;
			}
			else if (rpns == "n")
			{
				add_commande.check_tmber.Checked = true;
			}
			SendToTableSubCommand(this.dataGridView1.CurrentRow.Cells[0].Value.ToString()); 
			add_commande.ShowDialog();
		}
		public void SendToTableSubCommand(string idCommande)
		{
			DAL.DAL daoo = new DAL.DAL();
			string query = @"
			SET IDENTITY_INSERT [dbo].[TB_SUM_COMMANDE_caise] ON
            INSERT INTO [dbo].[TB_SUM_COMMANDE_caise]
            (
                [ID],
                [ID_COMMANDE],
                [SUB_COMMANDE_TITLE],
                [QUANTITE],
                [PRIX_UNITAIR],
                [PRIX_TOTAL],
                [QTE_REST],
                [QT_LIVRE],
                [price_cout]
            )
            SELECT 
                [ID],
                [ID_COMMANDE],
                [SUB_COMMANDE_TITLE],
                [QUANTITE],
                [PRIX_UNITAIR],
                [PRIX_TOTAL],
                [QTE_REST],
                [QT_LIVRE],
                [price_cout]
            FROM [dbo].[TB_SUM_COMMANDE]
            WHERE ID_COMMANDE = @id_commande
			SET IDENTITY_INSERT [dbo].[TB_SUM_COMMANDE_caise] OFF;
";

			try
			{
				using (daoo.sqlConnection)
				{
					daoo.sqlConnection.Open();

					using (SqlCommand command = new SqlCommand(query, daoo.sqlConnection))
					{
						// Add parameter for id_commande
						command.Parameters.AddWithValue("@id_commande", idCommande);

						int rowsAffected = command.ExecuteNonQuery();
						MessageBox.Show($"{rowsAffected} تم استعادة الجدول");
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				// You might want to log the error or handle it differently based on your application's requirements
			}
		}

		public string check_tmbre()
		{
			string yes;
			DataTable Dt = new DataTable();
			Dt = classCommande_proforma.get_table_commande_proforama_for_tmbre(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
			object tmbree;
			tmbree = Dt.Rows[0][13];
			if (tmbree.ToString() == "")
			{
				yes = "y";
			}
			else
			{
				yes = "n";
			}
			return yes;
		}

		private void تفاصيلالفاتورةToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PL.Commande.frm_sub_commaned_ formSub_commande = new frm_sub_commaned_();
			formSub_commande.id_commande = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
			formSub_commande.txt_cout.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString() + " د.ج";
			formSub_commande.txt_prix_total.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString() + " د.ج";
			formSub_commande.txt_Quantite.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
			formSub_commande.Show();
		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = classCommande_proforma.get_commande_proforma_and_date("فاتورة أولية",Convert.ToDateTime(kryptonDateTimePicker1.Value)) ;
		}

		private void button4_Click(object sender, EventArgs e)
		{

			this.dataGridView1.DataSource = classCommande_proforma.get_table_commande_proforama("فاتورة أولية");
		}
	}
}
