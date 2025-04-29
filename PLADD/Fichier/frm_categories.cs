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
	public partial class frm_categories : Form
	{
		BL.BL_FICHIER.BL_Categories classUnite = new BL.BL_FICHIER.BL_Categories();
		public PL.Fichier.frm_categories frm_categoriess;
		public int id;
        public frm_add_achat FormAchat;
        public frm_Add_stock_sans_facture frm_achat_sans_fctr;
        BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
        public string Type;

        public frm_categories()
		{
			InitializeComponent();
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			try
			{

                if (Type == "A")
                {
                    classUnite.insert_categories(txt_Stocke.Text);
                    MessageBox.Show("تم اضافة الصنف الصنف بنجاح", "عملية الاضافة");
                    //FormAchat.cmb_categories.Refresh();
                    FormAchat.cmb_categories.DataSource = clasCombobox.get_combo_Categorie();
                    FormAchat.cmb_categories.DisplayMember = "CATEGORIES";
                    FormAchat.cmb_categories.ValueMember = "ID";
                    this.Close();
                }
                else if (Type == "c")
                {
                    classUnite.insert_categories(txt_Stocke.Text);
                    MessageBox.Show("تم اضافة الصنف الصنف بنجاح", "عملية الاضافة");
                    frm_achat_sans_fctr.cmb_categories.DataSource = clasCombobox.get_combo_Categorie();
                    frm_achat_sans_fctr.cmb_categories.DisplayMember = "CATEGORIES";
                    frm_achat_sans_fctr.cmb_categories.ValueMember = "ID";
                    this.Close();
                }
                else
                {

                    if (id > 0)
                    {
                        classUnite.edit_CATEGORIES(id, txt_Stocke.Text);
                        frm_categoriess.dataGridView1.DataSource = classUnite.get_tb_Categories();
                        MessageBox.Show("تم تعديل اسم الصنف بنجاح", "عملية التعديل");
                    }
                    else
                    {
                        classUnite.insert_categories(txt_Stocke.Text);
                        frm_categoriess.dataGridView1.DataSource = classUnite.get_tb_Categories();
                        MessageBox.Show("تم اضافة الصنف الصنف بنجاح", "عملية الاضافة");
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
