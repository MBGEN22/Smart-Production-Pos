using Smart_Production_Pos.PL.Fichier;
using Smart_Production_Pos.PLADD.Achat_revente;
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
	public partial class frm_unite : Form
	{
		BL.BL_FICHIER.BL_unite classUnite = new BL.BL_FICHIER.BL_unite();
		public PL.Fichier.frm_unite frm_unitte;
		public int id;
		public string Type;
        public frm_add_achat FormAchat;
		public frm_Add_stock_sans_facture frm_achat_sans_fctr;
        BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
        public frm_unite()
		{
			InitializeComponent();
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			try
			{
                if (Type == "A")
                {
                    classUnite.insert_unite(txt_Stocke.Text);
                    MessageBox.Show("تم اضافة الوحدة بنجاح", "عملية الاضافة");
                    FormAchat.cmb_unite.DataSource = clasCombobox.get_combo_Iunite();
                    FormAchat.cmb_unite.DisplayMember = "UNITE";
                    FormAchat.cmb_unite.ValueMember = "ID";
                    this.Close();
                }
                else if (Type == "c")
                {
                    classUnite.insert_unite(txt_Stocke.Text);
                    MessageBox.Show("تم اضافة الوحدة بنجاح", "عملية الاضافة");
                    frm_achat_sans_fctr.cmb_unite.DataSource = clasCombobox.get_combo_Iunite();
                    frm_achat_sans_fctr.cmb_unite.DisplayMember = "UNITE";
                    frm_achat_sans_fctr.cmb_unite.ValueMember = "ID";
                    this.Close();
                }
                else
                {
                    if (id > 0)
                    {
                        classUnite.edit_unite(id, txt_Stocke.Text);
                        frm_unitte.dataGridView1.DataSource = classUnite.get_tb_unite();
                        MessageBox.Show("تم تعديل اسم الوحدة بنجاح", "عملية التعديل");
                    }
                    else
                    {
                        classUnite.insert_unite(txt_Stocke.Text);
                        frm_unitte.dataGridView1.DataSource = classUnite.get_tb_unite();
                        MessageBox.Show("تم اضافة الوحدة بنجاح", "عملية الاضافة");
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
