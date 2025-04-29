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
	public partial class frm_add_Stockes : Form
	{
		BL.BL_FICHIER.BL_STOCKE classStock = new BL.BL_FICHIER.BL_STOCKE();
		public int id;
		public PL.Fichier.frm_stockes frm_Stock;
		public string Type;
        public frm_add_achat FormAchat;
		public frm_Add_stock_sans_facture frm_achat_sans_fctr;
        BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
        public frm_add_Stockes()
		{
			InitializeComponent();
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			try
			{

                if (Type == "A")
                {
                    classStock.Add_Stockes(txt_Stocke.Text);
                    MessageBox.Show("تم اضافة المخزن بنجاح", "عملية الاضافة");
                    FormAchat.cmb_stocke.DataSource = clasCombobox.get_combo_stock();
                    FormAchat.cmb_stocke.DisplayMember = "STOCKE";
                    FormAchat.cmb_stocke.ValueMember = "ID";
                    this.Close();
                }
                else if (Type == "c")
                {
                    classStock.Add_Stockes(txt_Stocke.Text);
                    MessageBox.Show("تم اضافة المخزن بنجاح", "عملية الاضافة");
                    frm_achat_sans_fctr.cmb_stocke.DataSource = clasCombobox.get_combo_stock();
                    frm_achat_sans_fctr.cmb_stocke.DisplayMember = "STOCKE";
                    frm_achat_sans_fctr.cmb_stocke.ValueMember = "ID";
                    this.Close();
                }
                else
                {

                    if (id > 0)
                    {
                        classStock.edit_stockes(id, txt_Stocke.Text);
                        frm_Stock.dataGridView1.DataSource = classStock.get_Stockes_table();
                        MessageBox.Show("تم تعديل اسم المخزن بنجاح", "عملية التعديل");
                    }
                    else
                    {
                        classStock.Add_Stockes(txt_Stocke.Text);
                        frm_Stock.dataGridView1.DataSource = classStock.get_Stockes_table();
                        MessageBox.Show("تم اضافة المخزن بنجاح", "عملية الاضافة");
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
