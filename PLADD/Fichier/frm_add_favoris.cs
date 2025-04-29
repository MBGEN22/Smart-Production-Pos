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
	public partial class frm_add_favoris : Form
	{
		BL.BL_FICHIER.class_color classeColor = new BL.BL_FICHIER.class_color();
		public PL.Fichier.frm_color formColor;
		public int id;
		public string Type;
        public frm_add_achat FormAchat;
		public frm_Add_stock_sans_facture frm_achat_sans_fctr;
        BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
        public frm_add_favoris()
		{
			InitializeComponent();
			
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			try
			{

                if (Type == "A")
                {
                    classeColor.insert_color(txt_color.Text);
                    MessageBox.Show("تمت الاضافة  بنجاح");
                    FormAchat.cmb_color.DataSource = clasCombobox.get_combo_color();
                    FormAchat.cmb_color.DisplayMember = "COLOR";
                    FormAchat.cmb_color.ValueMember = "ID";
                    this.Close();
                }
                else if (Type == "c")
                {
                    classeColor.insert_color(txt_color.Text);
                    MessageBox.Show("تمت الاضافة  بنجاح");
                    frm_achat_sans_fctr.cmb_color.DataSource = clasCombobox.get_combo_color();
                    frm_achat_sans_fctr.cmb_color.DisplayMember = "COLOR";
                    frm_achat_sans_fctr.cmb_color.ValueMember = "ID";
                    this.Close();
                }
                else
                {
                    if (id > 0)
                    {
                        classeColor.update_color_name(id, txt_color.Text);
                        MessageBox.Show("تم التعديل بنجاح");
                        formColor.dataGridView1.DataSource = classeColor.select_TB_color();
                        this.Close();
                    }
                    else
                    {
                        classeColor.insert_color(txt_color.Text);
                        MessageBox.Show("تمت الاضافة  بنجاح");
                        formColor.dataGridView1.DataSource = classeColor.select_TB_color();
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
