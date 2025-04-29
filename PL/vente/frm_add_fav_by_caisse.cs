using Smart_Production_Pos.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.vente
{
    public partial class frm_add_fav_by_caisse : Form
    {
        public int id_fav;
        BL.BL_COMBOBOX Bl_combobox = new BL.BL_COMBOBOX();
        BL.BL_Vente_Caisse classEdit_Fav = new BL_Vente_Caisse(); 
        BL.BL_FICHIER.BL_favoire classFav = new BL.BL_FICHIER.BL_favoire();
        public frm_add_fav_by_caisse()
        {
            InitializeComponent();
            if (pack_check_produit_revent.Checked == true)
            {
                cmbProduct.DataSource = Bl_combobox.pack_produit_prevent();
                cmbProduct.ValueMember = "pack_code_barre";
                cmbProduct.DisplayMember = "pack_designation";
            }
            else if (check_produit_revent.Checked == true)
            {
                cmbProduct.DataSource = Bl_combobox.get_combo_produit_prevent();
                cmbProduct.DisplayMember = "designation";
                cmbProduct.ValueMember = "CodeBarre";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void check_produit_revent_CheckedChanged(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            Dt = Bl_combobox.get_combo_produit_prevent();
            if (Dt.Rows.Count > 0)
            {
                cmbProduct.DataSource = Bl_combobox.get_combo_produit_prevent();
                cmbProduct.DisplayMember = "designation";
                cmbProduct.ValueMember = "CodeBarre";
            }
            else
            {
                MessageBox.Show("لاتوجد منتجات");
                pack_check_produit_revent.Checked = true;
            }
           
        }

        private void pack_check_produit_revent_CheckedChanged(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            Dt = Bl_combobox.pack_produit_prevent();
            if (Dt.Rows.Count > 0)
            {
                cmbProduct.DataSource = Bl_combobox.pack_produit_prevent();
                cmbProduct.DisplayMember = "pack_designation";
                cmbProduct.ValueMember = "pack_code_barre"; 
            }
            else
            {
                MessageBox.Show("لاتوجد حزم");
                check_produit_revent.Checked = true;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                classFav.update_favoire(id_fav, textBox1.Text);
                this.Close();
            }
            else
            {
                if (check_produit_revent.Checked == true)
                {
                    classEdit_Fav.edit_fav_produit(
                    cmbProduct.SelectedValue.ToString()
                    , id_fav);
                    MessageBox.Show("تم اضافة المنتج بنجاح في المفضلة" + " " + textBox1.Text);
                }
                else
                {
                    classEdit_Fav.edit_fav_pack(
                    cmbProduct.SelectedValue.ToString()
                    , id_fav);
                    MessageBox.Show("تم اضافة الحزمة بنجاح في المفضلة" + " " + textBox1.Text);
                }
                classFav.update_favoire(id_fav, textBox1.Text);
                this.Close();
            }
            
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
