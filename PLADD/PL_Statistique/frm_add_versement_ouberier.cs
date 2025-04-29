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

namespace Smart_Production_Pos.PLADD.PL_Statistique
{
	public partial class frm_add_versement_ouberier : Form
	{
		BL.BL_COMBOBOX clasCombo = new BL.BL_COMBOBOX();
		BL.BL_Statistique.BL_la_PAye classLapay = new BL.BL_Statistique.BL_la_PAye();
		public PL.Statistique.frm_versement_ouverier ouverier;
		public int id_user,id;
		public frm_add_versement_ouberier()
		{
			InitializeComponent();
			cmb_ouverier.DataSource = clasCombo.get_combo_ouverier();
			cmb_ouverier.DisplayMember = "Name";
			cmb_ouverier.ValueMember = "ID";
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{ 
			if (id > 0)
			{
				classLapay.update_Depense(
					id,
					Convert.ToDateTime(txtDate.Value),
					Convert.ToInt32(cmb_ouverier.SelectedValue),
					decimal.Parse(txt_money.Text),
					txt_remarque.Text, 
					id_user
					);
				MessageBox.Show("تم تعديل البيانات  بنجاح");
				this.Close();
			}
			else
			{
				classLapay.Add_Funct( 
					Convert.ToDateTime(txtDate.Value),
					Convert.ToInt32(cmb_ouverier.SelectedValue),
					decimal.Parse(txt_money.Text),
					txt_remarque.Text,
					id_user
					);
				MessageBox.Show("تم اضافة البيانات  بنجاح");
				this.Close();
			}
			ouverier.dataGridView1.DataSource = classLapay.select_versement_ouverier();
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
