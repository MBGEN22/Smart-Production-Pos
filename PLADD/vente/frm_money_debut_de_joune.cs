using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.vente
{
	public partial class frm_money_debut_de_joune : Form
	{
		BL.BL_vente.BL_SP_LOGINE_Caisse classHistoryCaisse = new BL.BL_vente.BL_SP_LOGINE_Caisse(); 
		public int ID_caissier;
		public string type;
		public int ID_historique;
		public frm_vente_caisse frmVenteCaisse; 
        public Frm_vente_caissev5 frmVenteCaisseV5;
		public string Type;
        public frm_money_debut_de_joune()
		{
			InitializeComponent();
		}

		private void kryptonButton12_Click(object sender, EventArgs e)
		{

			DateTime currentDateTime = DateTime.Now;
			if (Type == "CaisseV5")
			{

                if (type == "F")
                {
                    classHistoryCaisse.update_history_caissier(
                         ID_historique,
                        currentDateTime.TimeOfDay,
                        decimal.Parse(txtBox.Text)
                        );
                    frmVenteCaisseV5.Close();
                    this.Close();
                }
                else
                {
                    frmVenteCaisseV5.FontCaisse = decimal.Parse(txtBox.Text);
                    //frmVenteCaisse.panel1.Enabled = true;
                    //frmVenteCaisse.panel2.Enabled = true;
                    //frmVenteCaisse.panel3.Enabled = true;
                    //frmVenteCaisse.panel4.Enabled = true;
                    frmVenteCaisseV5.flowLAyoutProduct.Enabled = true;
                    frmVenteCaisseV5.btn1.Enabled = true;
                    frmVenteCaisseV5.BTN2.Enabled = true;
                    frmVenteCaisseV5.BTN3.Enabled = true;
                    frmVenteCaisseV5.BTN4.Enabled = true;
                    frmVenteCaisseV5.BTN5.Enabled = true;
                    frmVenteCaisseV5.BTN6.Enabled = true;
                    frmVenteCaisseV5.BTN7.Enabled = true;
                    frmVenteCaisseV5.BTN8.Enabled = true;
                    frmVenteCaisseV5.BTN9.Enabled = true;
                    frmVenteCaisseV5.btn10.Enabled = true;
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
                    frmVenteCaisseV5.ID_historique = Convert.ToInt32(ID);
                    frmVenteCaisseV5.txt_barcode.Focus();
                    this.Close();
                }

            }
            else
			{
				if (type == "F")
				{
					classHistoryCaisse.update_history_caissier(
						 ID_historique,
						currentDateTime.TimeOfDay,
						decimal.Parse(txtBox.Text)
						);
					frmVenteCaisse.Close();
					this.Close();
				}
				else
				{
					frmVenteCaisse.FontCaisse = decimal.Parse(txtBox.Text);
					//frmVenteCaisse.panel1.Enabled = true;
					//frmVenteCaisse.panel2.Enabled = true;
					//frmVenteCaisse.panel3.Enabled = true;
					//frmVenteCaisse.panel4.Enabled = true;
					frmVenteCaisse.flowLAyoutProduct.Enabled = true;
					frmVenteCaisse.btn1.Enabled = true;
					frmVenteCaisse.BTN2.Enabled = true;
					frmVenteCaisse.BTN3.Enabled = true;
					frmVenteCaisse.BTN4.Enabled = true;
					frmVenteCaisse.BTN5.Enabled = true;
					frmVenteCaisse.BTN6.Enabled = true;
					frmVenteCaisse.BTN7.Enabled = true;
					frmVenteCaisse.BTN8.Enabled = true;
					frmVenteCaisse.BTN9.Enabled = true;
					frmVenteCaisse.btn10.Enabled = true;
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
					frmVenteCaisse.ID_historique = Convert.ToInt32(ID);
					frmVenteCaisse.txt_barcode.Focus();
					this.Close();
				}
			}
			this.Close();
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
        {
			PL.Dashboard dash = new PL.Dashboard();
			panel3.Height = 53;
			Form1.getMainForm.pn_container.Controls.Clear();
			Form1.getMainForm.pn_container.Controls.Add(dash.panel3);
			panel3.Height = 133;
			this.Close();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
				txtBox.Text = "";
				txtBox.Focus();
		}

		private void btnpoint_Click(object sender, EventArgs e)
		{
			txtBox.Text = txtBox.Text + ".";
			txtBox.Focus();
		}

		private void btnZero_Click(object sender, EventArgs e)
		{
			txtBox.Text = txtBox.Text + "0";
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

		private void btnClearspace_Click(object sender, EventArgs e)
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
	}
}
