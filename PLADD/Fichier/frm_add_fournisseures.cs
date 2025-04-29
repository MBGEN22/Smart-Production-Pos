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
	public partial class frm_add_fournisseures : Form
	{
		BL.BL_FICHIER.BL_Fournisseur class_Fournsisseur = new BL.BL_FICHIER.BL_Fournisseur();
		public int id;
		public PL.Fichier.frm_fournisseur frm_fournisseur;

		public frm_add_fournisseures()
		{
			InitializeComponent();
		}
		private float CalculeTotal(float total, float versement)
		{
			float rest = total - versement;

			return rest;
		}
		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			try
			{

                if (id > 0)
                {
                    class_Fournsisseur.edit_fournisseur(
                      id
                    , prename_client.Text
                    , name_client.Text
                    , txt_phone.Text
                    , txt_fax.Text
                    , txt_email.Text
                    , float.Parse(txt_total.Text)
                    , float.Parse(txt_versé.Text)
                    , float.Parse(txt_rest.Text)
                    , txt_adress.Text
                    , txt_nif.Text
                    , txt_rc.Text
                    , txt_nic.Text
                    , txt_article.Text
                    , Register_commerce_name_prename.Text
                    );
                    MessageBox.Show("تمت عملية تعديل معلومات العميل بنجاح");
                    frm_fournisseur.dataGridView1.DataSource = class_Fournsisseur.Get_clien_Table();
                    this.Close();
                }
                else
                {

                    class_Fournsisseur.Add_Funct(
                     prename_client.Text
                    , name_client.Text
                    , txt_adress.Text
                    , txt_phone.Text
                    , txt_fax.Text
                    , txt_email.Text
                    , float.Parse(txt_total.Text)
                    , float.Parse(txt_versé.Text)
                    , float.Parse(txt_rest.Text)
                    , txt_nif.Text
                    , txt_rc.Text
                    , txt_nic.Text
                    , txt_article.Text
                    , Register_commerce_name_prename.Text
                    );
                    frm_fournisseur.dataGridView1.DataSource = class_Fournsisseur.Get_clien_Table();
                    MessageBox.Show("تم اضافة معلومات الزبون بنجاح", "عملية الاضافة");
                }
                this.Close();
            }
			catch
			{
                this.Close();
			}
		}

		private void txt_versé_TextChanged(object sender, EventArgs e)
		{
            try
            {
                float rest = CalculeTotal(float.Parse(txt_total.Text), float.Parse(txt_versé.Text));
                txt_rest.Text = rest.ToString();
            }
            catch
            {
            }
      
		}

		private void prename_client_TextChanged(object sender, EventArgs e)
		{
			Register_commerce_name_prename.Text = prename_client.Text + " " + name_client.Text;
		}

		private void name_client_TextChanged(object sender, EventArgs e)
		{
			Register_commerce_name_prename.Text = prename_client.Text + " " + name_client.Text;
		}

		private void txt_total_TextChanged(object sender, EventArgs e)
        {
            
            try
			{
			float rest = CalculeTotal(float.Parse(txt_total.Text), float.Parse(txt_versé.Text));
			txt_rest.Text = rest.ToString();
			}
			catch
			{
			}

		}

		private void txt_rest_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
