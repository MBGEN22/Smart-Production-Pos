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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using Smart_Production_Pos.PLADD.vente;
using Smart_Production_Pos.BL;
using Smart_Production_Pos.report;
using Smart_Production_Pos.PL.vente;

namespace Smart_Production_Pos.PLADD.Fichier
{
	public partial class frm_add_client : Form
	{
		BL.BL_FICHIER.BL_Client classClient = new BL.BL_FICHIER.BL_Client();
		public int id;
        BL.BL_COMBOBOX Bl_combobox = new BL.BL_COMBOBOX();
        public PL.Fichier.frm_client frm_clieent;
		public string Type;
		public frm_vente_caisse vente_Caisse;
        public frm_facturation vente_facturation;
        public Frm_vente_caissev5 vente_Caissev5;

        public frm_add_client()
		{
			InitializeComponent();
		}

		private void frm_add_client_Load(object sender, EventArgs e)
		{

		}

		private void kryptonTextBox5_Click(object sender, EventArgs e)
		{
			txt_total.SelectAll();
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
            try
            {
                if (Type == "A")
                {
                    classClient.Add_Funct(
                         prename_client.Text
                        , name_client.Text
                        , txt_adress.Text
                        , txt_phone.Text
                        , txt_fax.Text
                        , txt_email.Text
                        , float.Parse(txt_total.Text)
                        , float.Parse(txt_versé.Text)
                        , float.Parse(txt_rest.Text)
                        , float.Parse(txt_avance.Text)
                        , float.Parse(txt_retard.Text)
                        , txt_nif.Text
                        , txt_rc.Text
                        , txt_nic.Text
                        , txt_article.Text
                        , Register_commerce_name_prename.Text
                    );
                    vente_Caisse.clientCmb.DataSource = Bl_combobox.get_combo_client();
                    vente_Caisse.clientCmb.DisplayMember = "Client";
                    vente_Caisse.clientCmb.ValueMember = "ID";
                    this.Close();
                }
                else if (Type == "f")
                {
                    classClient.Add_Funct(
                         prename_client.Text
                        , name_client.Text
                        , txt_adress.Text
                        , txt_phone.Text
                        , txt_fax.Text
                        , txt_email.Text
                        , float.Parse(txt_total.Text)
                        , float.Parse(txt_versé.Text)
                        , float.Parse(txt_rest.Text)
                        , float.Parse(txt_avance.Text)
                        , float.Parse(txt_retard.Text)
                        , txt_nif.Text
                        , txt_rc.Text
                        , txt_nic.Text
                        , txt_article.Text
                        , Register_commerce_name_prename.Text
                    );
                    vente_facturation.clientCmb.DataSource = Bl_combobox.get_combo_client();
                    vente_facturation.clientCmb.DisplayMember = "Client";
                    vente_facturation.clientCmb.ValueMember = "ID";
                    this.Close();
                }
                else if (Type == "B")
                {
                    classClient.Add_Funct(
                        prename_client.Text
                       , name_client.Text
                       , txt_adress.Text
                       , txt_phone.Text
                       , txt_fax.Text
                       , txt_email.Text
                       , float.Parse(txt_total.Text)
                       , float.Parse(txt_versé.Text)
                       , float.Parse(txt_rest.Text)
                       , float.Parse(txt_avance.Text)
                       , float.Parse(txt_retard.Text)
                       , txt_nif.Text
                       , txt_rc.Text
                       , txt_nic.Text
                       , txt_article.Text
                       , Register_commerce_name_prename.Text
                   );
                    vente_Caissev5.clientCmb.DataSource = Bl_combobox.get_combo_client();
                    vente_Caissev5.clientCmb.DisplayMember = "Client";
                    vente_Caissev5.clientCmb.ValueMember = "ID";
                    this.Close();
                }
                else
                {
                    if (id > 0)
                    {
                        classClient.edit_client(
                          id
                        , name_client.Text
                        , prename_client.Text
                        , txt_phone.Text
                        , txt_fax.Text
                        , txt_email.Text
                        , float.Parse(txt_total.Text)
                        , float.Parse(txt_versé.Text)
                        , float.Parse(txt_rest.Text)
                        , txt_adress.Text
                        , float.Parse(txt_avance.Text)
                        , float.Parse(txt_retard.Text)
                        , txt_nif.Text
                        , txt_rc.Text
                        , txt_nic.Text
                        , txt_article.Text
                        , Register_commerce_name_prename.Text
                        );
                        MessageBox.Show("تمت عملية تعديل معلومات العميل بنجاح");
                        frm_clieent.dataGridView1.DataSource = classClient.Get_clien_Table();
                        this.Close();
                        //classClient.(id, txt_Stocke.Text);
                        //frm_marque.dataGridView1.DataSource = ClassMarque.get_TB_MARQUE();
                        //MessageBox.Show("تم تعديل اسم الصنف بنجاح", "عملية التعديل");
                    }
                    else
                    {

                        classClient.Add_Funct(
                         prename_client.Text
                        , name_client.Text
                        , txt_adress.Text
                        , txt_phone.Text
                        , txt_fax.Text
                        , txt_email.Text
                        , float.Parse(txt_total.Text)
                        , float.Parse(txt_versé.Text)
                        , float.Parse(txt_rest.Text)
                        , float.Parse(txt_avance.Text)
                        , float.Parse(txt_retard.Text)
                        , txt_nif.Text
                        , txt_rc.Text
                        , txt_nic.Text
                        , txt_article.Text
                        , Register_commerce_name_prename.Text
                        );
                        frm_clieent.dataGridView1.DataSource = classClient.Get_clien_Table();
                        MessageBox.Show("تم اضافة معلومات الزبون بنجاح", "عملية الاضافة");
                    }
                    this.Close();
                }
            }
            catch
            {
                this.Close(); 
            }
			
			
		}

		private void name_client_TextChanged(object sender, EventArgs e)
		{
			Register_commerce_name_prename.Text = prename_client.Text + " " + name_client.Text;
		}

		private void prename_client_TextChanged(object sender, EventArgs e)
		{
           // var charMap = new Dictionary<char, char>
           //     {
           //     { '&', '1' },
           //     { 'é', '2' },
           //     { '"', '3' },
           //     { '\'', '4' },
           //     { '(', '5' },
           //     { '-', '6' },
           //     { 'è', '7' },
           //     { '_', '8' },
           //     { 'ç', '9' },
           //     { 'à', '0' }
           // };

           // // Use StringBuilder to build the converted string.
           // var convertedCodeBarre = new StringBuilder(prename_client.Text.Length);

           // foreach (char c in prename_client.Text)
           // {
           //     // If the character is in the dictionary, replace it; otherwise, keep it the same.
           //     if (charMap.TryGetValue(c, out char replacement))
           //     {
           //         convertedCodeBarre.Append(replacement);
           //     }
           //     else
           //     {
           //         convertedCodeBarre.Append(c);
           //     }
           // }

           // // Resulting converted code
           //string bar = convertedCodeBarre.ToString();
           // MessageBox.Show(bar.ToString());
            //Register_commerce_name_prename.Text = prename_client.Text + " " + name_client.Text;
        }
		private float CalculeTotal(float total, float versement)
		{
			float rest = total - versement;

			return rest;
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

		private void txt_total_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
			{
				e.Handled = true; // Prevent the character from being entered
			}
		}

        private void prename_client_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var charMap = new Dictionary<char, char>
                {
                { '&', '1' },
                { 'é', '2' },
                { '"', '3' },
                { '\'', '4' },
                { '(', '5' },
                { '-', '6' },
                { 'è', '7' },
                { '_', '8' },
                { 'ç', '9' },
                { 'à', '0' }
            };

                // Use StringBuilder to build the converted string.
                var convertedCodeBarre = new StringBuilder(prename_client.Text.Length);

                foreach (char c in prename_client.Text)
                {
                    // If the character is in the dictionary, replace it; otherwise, keep it the same.
                    if (charMap.TryGetValue(c, out char replacement))
                    {
                        convertedCodeBarre.Append(replacement);
                    }
                    else
                    {
                        convertedCodeBarre.Append(c);
                    }
                }

                // Resulting converted code
                string bar = convertedCodeBarre.ToString();
                MessageBox.Show(bar.ToString());
            }
        }
    }
}
