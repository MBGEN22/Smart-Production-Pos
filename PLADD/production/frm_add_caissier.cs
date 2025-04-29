using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.production
{
	public partial class frm_add_caissier : Form
	{
		BL.BL_FICHIER.BL_CAISSIER classCaissier = new BL.BL_FICHIER.BL_CAISSIER();
		public int id;
		public PL.Fichier.frm_caissier frm_caissier;
		public frm_add_caissier()
		{
			InitializeComponent();
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			try
			{

                if (id > 0)
                {
                    classCaissier.edit_client(id, txt_name.Text, txt_prname.Text, txt_user.Text, txt_mdps.Text);
                    MessageBox.Show("تم تعديل المعلومات بنجاح");
                    frm_caissier.dataGridView1.DataSource = classCaissier.get_tb_caissier();
                    this.Close();
                }
                else
                {
                    classCaissier.insert_cassier_info(txt_name.Text, txt_prname.Text, txt_user.Text, txt_mdps.Text);
                    MessageBox.Show("تم اضافة المعلومات بنجاح");
                    frm_caissier.dataGridView1.DataSource = classCaissier.get_tb_caissier();
                    this.Close();
                }
            }
			catch
            {
                this.Close(); 
            }
		}
	}
}
