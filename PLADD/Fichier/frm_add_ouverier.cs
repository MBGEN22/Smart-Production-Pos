using ComponentFactory.Krypton.Toolkit;
using Smart_Production_Pos.PL.Fichier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.Fichier
{
	public partial class frm_add_ouverier : Form
	{
		public int id;
        BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
        BL.BL_FICHIER.BL_ouverier classOuverier = new BL.BL_FICHIER.BL_ouverier();
		public frm_ouverier frmOuverier;
		public string type;
		public frm_add_user FormUser; 
        public frm_add_ouverier()
		{
			InitializeComponent();
		}

		private void frm_add_ouverier_Load(object sender, EventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void txt_phone_TextChanged(object sender, EventArgs e)
		{

		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			try
			{

                if (type == "logine")
                {
                    classOuverier.add_ouverier(txt_name.Text, txt_prename.Text, txt_fnction.Text, txt_phone.Text);
                    FormUser.kryptonComboBox1.DataSource = clasCombobox.get_combo_ouverier();
                    FormUser.kryptonComboBox1.DisplayMember = "Name";
                    FormUser.kryptonComboBox1.ValueMember = "ID";
                    MessageBox.Show("تم اضافة المعلومات  بنجاح");
                    this.Close();
                }
                else
                {
                    if (id > 0)
                    {
                        classOuverier.edit_tb_ouverier(id, txt_name.Text, txt_prename.Text, txt_fnction.Text, txt_phone.Text);
                        MessageBox.Show("تم تحديث المعلومات  بنجاح");
                        frmOuverier.dataGridView1.DataSource = classOuverier.get_tb_ouverier();
                    }
                    else
                    {
                        classOuverier.add_ouverier(txt_name.Text, txt_prename.Text, txt_fnction.Text, txt_phone.Text);
                        MessageBox.Show("تم اضافة المعلومات  بنجاح");
                        frmOuverier.dataGridView1.DataSource = classOuverier.get_tb_ouverier();
                    }
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
