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
	public partial class frm_add_marque : Form
	{
		BL.BL_FICHIER.BL_Marque ClassMarque = new BL.BL_FICHIER.BL_Marque();
		public PL.Fichier.frm_marque frm_marque;
		public int id;
		public string Type;
        public frm_add_achat FormAchat;
		public frm_Add_stock_sans_facture frm_achat_sans_fctr;
        BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
        public frm_add_marque()
		{
			InitializeComponent();
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			try
			{

                if (Type == "A")
                {
                    ClassMarque.insert_marque(txt_Stocke.Text);
                    FormAchat.cmb_marque.DataSource = clasCombobox.get_combo_Marque();
                    FormAchat.cmb_marque.DisplayMember = "Marque";
                    FormAchat.cmb_marque.ValueMember = "ID";
                    MessageBox.Show("تم اضافة الصنف الصنف بنجاح", "عملية الاضافة");

                    this.Close();
                }
                else if (Type == "c")
                {
                    ClassMarque.insert_marque(txt_Stocke.Text);
                    frm_achat_sans_fctr.cmb_marque.DataSource = clasCombobox.get_combo_Marque();
                    frm_achat_sans_fctr.cmb_marque.DisplayMember = "Marque";
                    frm_achat_sans_fctr.cmb_marque.ValueMember = "ID";
                    this.Close();
                }
                else
                {
                    if (id > 0)
                    {
                        ClassMarque.edit_Marque(id, txt_Stocke.Text);
                        frm_marque.dataGridView1.DataSource = ClassMarque.get_TB_MARQUE();
                        MessageBox.Show("تم تعديل اسم الصنف بنجاح", "عملية التعديل");
                    }
                    else
                    {
                        ClassMarque.insert_marque(txt_Stocke.Text);
                        frm_marque.dataGridView1.DataSource = ClassMarque.get_TB_MARQUE();
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
