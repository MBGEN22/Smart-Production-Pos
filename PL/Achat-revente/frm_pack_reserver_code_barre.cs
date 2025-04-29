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
	public partial class frm_pack_reserver_code_barre : Form
	{
		BL.BL_ACHAT_REVENT.BL_produit_reserve classPack_reserve = new BL.BL_ACHAT_REVENT.BL_produit_reserve();
		BL.BL_ACHAT_REVENT.BL_ACHAT classAchat = new BL.BL_ACHAT_REVENT.BL_ACHAT();
		public string codeBarre_produit;
		public string Principale_Code_Barre;
		
		public frm_pack_reserver_code_barre()
		{
			InitializeComponent();
			
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
				classAchat.addReserveCode_barre_pack(Principale_Code_Barre, txt_code_barre_reserver.Text);
				this.dataGridView1.DataSource = classAchat.get_tb_codeBarre_resever_pack(txt_officale_barCode.Text);
				txt_code_barre_reserver.Text = "";
			}
		}

		private void frm_pack_reserver_code_barre_Load(object sender, EventArgs e)
		{
			
			DataTable dtt = new DataTable();
			dtt = classPack_reserve.get_number_pack(codeBarre_produit);
			
			if (dtt.Rows.Count >0 )
			{
				Object CodeBarrePack = dtt.Rows[0][0];
				Principale_Code_Barre = CodeBarrePack.ToString();
				txt_officale_barCode.Text = Principale_Code_Barre;
				dataGridView1.DataSource = classPack_reserve.get_tb_codeBarre_pack_reserver(Principale_Code_Barre);
			}
			else
			{
				MessageBox.Show("هذا المنتوج لايحتوي على حزمة");
				this.Close();
			}
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			DialogResult Dg = MessageBox.Show("ستتم عملية حذف هذا الرقم هل انت متأكد", "عملية حذف البيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (Dg == DialogResult.Yes)
			{
				classAchat.delete_by_code_barre_secondaire_pack(this.dataGridView1.CurrentRow.Cells[2].Value.ToString()) ;
				dataGridView1.DataSource = classAchat.get_tb_codeBarre_resever_pack(txt_officale_barCode.Text);
				MessageBox.Show("تمت عملية الحذف بنجاح");
			}
		}
	}
}
