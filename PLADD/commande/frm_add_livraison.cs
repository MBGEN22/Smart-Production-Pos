using Smart_Production_Pos.BL.Bl_commande;
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
using ZXing.QrCode.Internal;

namespace Smart_Production_Pos.PLADD.commande
{
	public partial class frm_add_livraison : Form
	{
		BL.Bl_commande.BL_sub_commande sub_commandeclass = new BL.Bl_commande.BL_sub_commande();
		BL.Client_history_sold historique_Client = new BL.Client_history_sold();
		public string id_commande;
		public int id_client;
		public decimal old_sold;
		BL.Bl_commande.BL_sub_commande class_Sub_Commande = new BL.Bl_commande.BL_sub_commande();
		BL.Bl_commande.BL_livraison prd = new BL.Bl_commande.BL_livraison();
		public frm_add_livraison()
		{
			InitializeComponent();
			txt_id.Text = prd.get_id_TB_INFO_DE_LIV().ToString();
			cmb_type.SelectedIndex = 0;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmb_type.Text == "توصيل")
			{
				txt_price.Enabled = true;
				txt_chaufeur.Enabled = true;
				txt_matricule.Enabled = true;
			}
			else if (cmb_type.Text == "لا يوجد توصيل")
			{
				txt_price.Enabled = false;
				txt_chaufeur.Enabled = false;
				txt_matricule.Enabled = false;
			}
		}

		private void txt_price_TextChanged(object sender, EventArgs e)
		{
			if (txt_price.Text == "")
			{
				txt_price.Text = "00";
			}
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			if(txt_price.Text == "")
			{
				txt_price.Text = "00";
			}
		}

		private void textBox2_Click(object sender, EventArgs e)
		{
			txt_price.SelectAll();
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			frm_edit_livraison frm;
			//edit versement commande
		    prd.edit_versement_commande(id_commande,decimal.Parse(txt_versement.Text));
			//edit client sold
			prd.update_client_payment_(id_client, decimal.Parse(txt_versement.Text));
			//add_historique_client
			historique_Client.insert_history_client(
						dateTimePicker1.Value,
						Convert.ToInt32(id_client),
                        decimal.Parse(txt_versement.Text),
                        decimal.Parse(txt_versement.Text),
						old_sold,
						old_sold+decimal.Parse(txt_versement.Text),
						"دفع اثناء الاستلام",
                        id_commande
                        );
			if (MessageBox.Show("هل أنت متأكد من هذا الاختيار . بهذا الاختيار لايمكنك الرجوع الى الحالة السابقة ", "هذا الاختيار سيقوم تغيير حالة الطلبية", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				//add_information_livraison
				prd.insert_livraiosn_information
					(
					Convert.ToInt16(txt_id.Text),
					Convert.ToDateTime(dateTimePicker1.Text),
					txt_nom_liv.Text,
					txt_recu.Text,
					cmb_type.Text,
					decimal.Parse(txt_price.Text),
					txt_chaufeur.Text,
					txt_matricule.Text, 
					id_commande,
					decimal.Parse(txt_versement.Text) 
					);
				prd.edit_commande_etas(id_commande, "تم تسليم الطلبية");
				if (radioButton1.Checked == true)
				{
					//complete_order
					prd.EDIT_COMPLETE_ORDER(id_commande);
					DataTable dt = sub_commandeclass.get_detailles_sub_commande(id_commande);
					if (dt.Rows.Count > 0)
					{
						foreach (DataRow row in dt.Rows)
						{
							Object ID_sub_commande = row[0]; // Use 'row' instead of 'dt.Rows[0]'
							Object Qt = row[3]; // Use 'row' instead of 'dt.Rows[0]'
							class_Sub_Commande.add_info_livraison(
								Convert.ToInt32(txt_id.Text),
								Convert.ToInt32(ID_sub_commande.ToString()),
								Convert.ToInt32(Qt.ToString())
							);
						}
					}

				}


			}
				else
				{
					//not complet order
					frm = new frm_edit_livraison();
					frm.id = id_commande;
					frm.id_commande = id_commande;
					frm.id_livraison = Convert.ToInt32(txt_id.Text);
					frm.ShowDialog();
				}
			
			MessageBox.Show("تم تغيير الحالة بنجاح ", "حالة الطلبية تغيرت", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void frm_add_livraison_Load(object sender, EventArgs e)
		{
			 
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void kryptonGroup1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void txt_versement_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
			{
				e.Handled = true;
			}
		}
	}
}
