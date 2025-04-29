using Smart_Production_Pos.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Statistique
{
	public partial class frm_historique_caisier : Form
	{
		BL.BL_Statistique.BL_historique_caisier classHistorique = new BL.BL_Statistique.BL_historique_caisier();
		BL.BL_COMBOBOX classCombo = new BL.BL_COMBOBOX();
		public frm_historique_caisier()
		{
			InitializeComponent();
			cmb_client.DataSource = classCombo.get_Combo_caisse();
			cmb_client.DisplayMember = "ANA";
			cmb_client.ValueMember = "ID";
			this.kryptonDataGridView1.DataSource = classHistorique.get_historique_caissiera();
			GetTTL();
		}

		private void button10_Click(object sender, EventArgs e)
		{ 
			this.kryptonDataGridView1.DataSource = classHistorique.search_by_caissier(Convert.ToInt32(cmb_client.SelectedValue));
			GetTTL();
		}

		private void button2_Click(object sender, EventArgs e)
		{

			this.kryptonDataGridView1.DataSource = classHistorique.search_by_date(Convert.ToDateTime(kryptonDateTimePicker1.Value));
			GetTTL();
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{

			this.kryptonDataGridView1.DataSource = classHistorique.get_historique_caissiera();
		}
		public void GetTTL()
		{
			double ttl = 0;
			lbttl.Text = ""; 
			foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
			{

				if (!row.IsNewRow && row.Cells[6].Value != null)
				{
					double cellValue;
					// Try to parse the cell value to double
					if (double.TryParse(row.Cells[6].Value.ToString(), out cellValue))
					{
						ttl += cellValue;
					}
					else
					{
						// Handle the case where parsing fails (e.g., log the issue)
						// Optionally you can display a message or handle it as needed
					}
				}
			}
			lbttl.Text = ttl.ToString("N2"); 
		}
	}
}

