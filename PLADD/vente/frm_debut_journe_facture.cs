using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Smart_Production_Pos.PLADD.vente
{
	public partial class frm_debut_journe_facture : Form
	{
		BL.BL_vente.BL_SP_LOGINE_Caisse classHistoryCaisse = new BL.BL_vente.BL_SP_LOGINE_Caisse();
		public frmVente_facturation frmVente; 
		public int ID_caissier;
		public string type; 
		public int ID_historique;
		public frm_debut_journe_facture()
		{
			InitializeComponent();
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			DateTime currentDateTime = DateTime.Now;

			if (type == "F")
			{
				classHistoryCaisse.update_history_caissier(
					 ID_historique,
					currentDateTime.TimeOfDay,
					decimal.Parse(txtBox.Text)
					);
				frmVente.Close();
				this.Close();
			}
			else
			{
				frmVente.FontCaisse = decimal.Parse(txtBox.Text);
				frmVente.panel1.Enabled = true;
				frmVente.panel2.Enabled = true;
				frmVente.panel3.Enabled = true;
				frmVente.panel4.Enabled = true;
				frmVente.panel5.Enabled = true;
				frmVente.btn1.Enabled = true;
				frmVente.BTN2.Enabled = true;
				frmVente.BTN3.Enabled = true;
				frmVente.BTN4.Enabled = true;
				frmVente.BTN5.Enabled = true;
				frmVente.BTN6.Enabled = true;
				frmVente.BTN7.Enabled = true;
				frmVente.BTN8.Enabled = true;
				frmVente.BTN9.Enabled = true;
				classHistoryCaisse.insert_history_caissier(
					ID_caissier,
					DateTime.Today,
					currentDateTime.TimeOfDay,
					currentDateTime.TimeOfDay,
					0,
					decimal.Parse(txtBox.Text)
					);
				DataTable dt = new DataTable();
				dt = classHistoryCaisse.historique_tracage_caissier();
				object ID = dt.Rows[0][0];
				frmVente.ID_historique = Convert.ToInt32(ID);
				frmVente.txt_code_barre.Focus();
				this.Close();
			}
			 
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			// Check if there is any text in the TextBox
			if (!string.IsNullOrEmpty(txtBox.Text))
			{
				// Remove the last character from the TextBox
				txtBox.Text = txtBox.Text.Substring(0, txtBox.Text.Length - 1);

				// Optional: Set the cursor to the end of the text
				txtBox.SelectionStart = txtBox.Text.Length;
				txtBox.SelectionLength = 0;
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			txtBox.Text = "";
			txtBox.Focus();
		}

		private void btnZero_Click(object sender, EventArgs e)
		{
			txtBox.Text = txtBox.Text + "0";
			txtBox.Focus();
		}

		private void btnpoint_Click(object sender, EventArgs e)
		{
			txtBox.Text = txtBox.Text + ".";
			txtBox.Focus();
		}

		private void btnOne_Click(object sender, EventArgs e)
		{
			txtBox.Text = txtBox.Text + "1";
			txtBox.Focus();
		}

		private void btnTwo_Click(object sender, EventArgs e)
		{
			txtBox.Text = txtBox.Text + "2";
			txtBox.Focus();
		}

		private void btnThree_Click(object sender, EventArgs e)
		{
			txtBox.Text = txtBox.Text + "3";
			txtBox.Focus();
		}

		private void btnFor_Click(object sender, EventArgs e)
		{
			txtBox.Text = txtBox.Text + "4";
			txtBox.Focus();
		}

		private void btnFive_Click(object sender, EventArgs e)
		{
			txtBox.Text = txtBox.Text + "5";
			txtBox.Focus();
		}

		private void btnSixe_Click(object sender, EventArgs e)
		{
			txtBox.Text = txtBox.Text + "6";
			txtBox.Focus();
		}

		private void btnSeven_Click(object sender, EventArgs e)
		{
			txtBox.Text = txtBox.Text + "7";
			txtBox.Focus();
		}

		private void btnEight_Click(object sender, EventArgs e)
		{
			txtBox.Text = txtBox.Text + "8";
			txtBox.Focus();
		}

		private void btnNine_Click(object sender, EventArgs e)
		{
			txtBox.Text = txtBox.Text + "9";
			txtBox.Focus();
		}

		private void kryptonButton12_Click(object sender, EventArgs e)
		{

			DateTime currentDateTime = DateTime.Now;

			if (type == "F")
			{
				classHistoryCaisse.update_history_caissier(
					 ID_historique,
					currentDateTime.TimeOfDay,
					decimal.Parse(txtBox.Text)
					);
				frmVente.Close();
				this.Close();
			}
			else
			{
				frmVente.FontCaisse = decimal.Parse(txtBox.Text);
				frmVente.panel1.Enabled = true;
				frmVente.panel2.Enabled = true;
				frmVente.panel3.Enabled = true;
				frmVente.panel4.Enabled = true;
				frmVente.panel5.Enabled = true;
				frmVente.btn1.Enabled = true;
				frmVente.BTN2.Enabled = true;
				frmVente.BTN3.Enabled = true;
				frmVente.BTN4.Enabled = true;
				frmVente.BTN5.Enabled = true;
				frmVente.BTN6.Enabled = true;
				frmVente.BTN7.Enabled = true;
				frmVente.BTN8.Enabled = true;
				frmVente.BTN9.Enabled = true;
				classHistoryCaisse.insert_history_caissier(
					ID_caissier,
					DateTime.Today,
					currentDateTime.TimeOfDay,
					currentDateTime.TimeOfDay,
					decimal.Parse(txtBox.Text),
					decimal.Parse(txtBox.Text)
					);
				DataTable dt = new DataTable();
				dt = classHistoryCaisse.historique_tracage_caissier();
				object ID = dt.Rows[0][0];
				frmVente.ID_historique = Convert.ToInt32(ID); 
				frmVente.txt_code_barre.Focus();
				this.Close();
			}
		}
	}
}
