using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Achat_revente
{
	public partial class frm_code_barre_reserve : Form
	{
			BL.BL_ACHAT_REVENT.BL_ACHAT classAchat = new BL.BL_ACHAT_REVENT.BL_ACHAT();
			public frm_code_barre_reserve()
		{
			InitializeComponent();
			dataGridView1.DataSource = classAchat.tb_reserve_code(txt_officale_barCode.Text);

		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			if (txt_officale_barCode.Text == "")
			{
				MessageBox.Show("يجب أولا ادخال الباركود الاساسي", "عملية ادخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
				txt_officale_barCode.BackColor = Color.Red;
				txt_officale_barCode.Focus();
			}
			else
			{
				classAchat.addReserveCode_barre(txt_officale_barCode.Text, txt_code_barre_reserver.Text);
                dataGridView1.DataSource = classAchat.tb_reserve_code(txt_officale_barCode.Text);
                txt_code_barre_reserver.Text = "";
			}
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			DialogResult Dg = MessageBox.Show("ستتم عملية حذف هذا الرقم هل انت متأكد", "عملية حذف البيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			DataTable DTt = classAchat.select_Tb_code_Barre(txt_officale_barCode.Text);
			if (Dg == DialogResult.Yes)
			{
				if (DTt .Rows.Count > 0)
				{
					classAchat.delete_one_from_tb_reserve_code((int)this.dataGridView1.CurrentRow.Cells[0].Value);
                    dataGridView1.DataSource = classAchat.tb_reserve_code(txt_officale_barCode.Text);
                    MessageBox.Show("تمت عملية الحذف بنجاح");
				}
				else
				{
					MessageBox.Show("لاتوجد بيانات لحذفها الجدول فارغ");
				}
			}
		}

		private void txt_code_barre_reserver_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{

				if (txt_officale_barCode.Text == "")
				{
					MessageBox.Show("يجب أولا ادخال الباركود الاساسي", "عملية ادخال البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
					txt_officale_barCode.BackColor = Color.Red;
					txt_officale_barCode.Focus();
				}
				else
				{
					classAchat.addReserveCode_barre(txt_officale_barCode.Text, txt_code_barre_reserver.Text);
					this.dataGridView1.DataSource = classAchat.tb_reserve_code(txt_officale_barCode.Text);
					txt_code_barre_reserver.Text = "";
				}
			}
		}

		private void frm_code_barre_reserve_Load(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = classAchat.tb_reserve_code(txt_officale_barCode.Text);
		}
	}
}
