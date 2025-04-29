using Smart_Production_Pos.BL.BL_FICHIER;
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
	public partial class frm_add_taille : Form
	{
		BL.BL_FICHIER.classe_taille classTaille  = new BL.BL_FICHIER.classe_taille();
		public PL.Fichier.frm_Taille formTaille;
		public int id;
		public string Type;
        public frm_add_achat FormAchat;
		public frm_Add_stock_sans_facture frm_achat_sans_fctr;
        BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
        public frm_add_taille()
		{
			InitializeComponent();
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			try
			{

                if (Type == "A")
                {
                    classTaille.insert_Taille(txt_taille.Text);
                    FormAchat.cmb_taille.DataSource = clasCombobox.get_combo_taille();
                    FormAchat.cmb_taille.DisplayMember = "TAILLE";
                    FormAchat.cmb_taille.ValueMember = "ID";
                    MessageBox.Show("تمت الاضافة  بنجاح");
                    this.Close();
                }
                else if (Type == "c")
                {
                    classTaille.insert_Taille(txt_taille.Text);
                    frm_achat_sans_fctr.cmb_taille.DataSource = clasCombobox.get_combo_taille();
                    frm_achat_sans_fctr.cmb_taille.DisplayMember = "TAILLE";
                    frm_achat_sans_fctr.cmb_taille.ValueMember = "ID";
                    this.Close();
                }
                else
                {
                    if (id > 0)
                    {
                        classTaille.update_taille(id, txt_taille.Text);
                        MessageBox.Show("تم التعديل بنجاح");
                        formTaille.dataGridView1.DataSource = classTaille.select_tb_taille();
                        this.Close();
                    }
                    else
                    {
                        classTaille.insert_Taille(txt_taille.Text);
                        MessageBox.Show("تمت الاضافة  بنجاح");
                        formTaille.dataGridView1.DataSource = classTaille.select_tb_taille();
                        this.Close();
                    }

                }
            }
			catch
			{
                this.Close();
			}
		}
	}
}
