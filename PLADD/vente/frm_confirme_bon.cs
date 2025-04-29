using Smart_Production_Pos.BL.BL_FICHIER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.vente
{
    public partial class frm_confirme_bon : Form
    {
        BL.BL_vente.BL_vente_Fonction classVente = new BL.BL_vente.BL_vente_Fonction(); 
        BL.Client_history_sold historique_Client = new BL.Client_history_sold();
        BL.BL_vente.BL_SP_LOGINE_Caisse classCaisse = new BL.BL_vente.BL_SP_LOGINE_Caisse();
        BL.BL_Vente_Caisse classCaisse1 = new BL.BL_Vente_Caisse();
        public frm_vente_caisse form_caisse;

        public string Typpped;
        public string pourcentageRemise; 
        public int id_client;
        public int Count;
        public int id_user, ID_caissier;

        public frm_confirme_bon()
        {
            InitializeComponent();
        }

        private decimal add_argent(decimal price_old , decimal pric_add)
        {
            decimal price_txt_versement = price_old + pric_add;
            return price_txt_versement;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                txt_versement.Text = add_argent(decimal.Parse(txt_versement.Text), 2000).ToString();
            }
            catch
            {
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                txt_versement.Text = add_argent(decimal.Parse(txt_versement.Text), 1000).ToString();
            }
            catch
            {
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                txt_versement.Text = add_argent(decimal.Parse(txt_versement.Text), 500).ToString();
            }
            catch
            {
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                txt_versement.Text = add_argent(decimal.Parse(txt_versement.Text), 200).ToString();
            }
            catch
            {
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                txt_versement.Text = add_argent(decimal.Parse(txt_versement.Text), 100).ToString();
            }
            catch
            {
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                txt_versement.Text = add_argent(decimal.Parse(txt_versement.Text), 50).ToString();
            }
            catch
            {
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            try
            {
                txt_versement.Text = add_argent(decimal.Parse(txt_versement.Text), 20).ToString();
            }
            catch
            {
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            try
            {
                txt_versement.Text = add_argent(decimal.Parse(txt_versement.Text), 10).ToString();
            }
            catch
            {
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                txt_versement.Text = add_argent(decimal.Parse(txt_versement.Text), 5).ToString();
            }
            catch
            {
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txt_versement.Text = txt_versement.Text + "0"; ;
        }
        public void Facture_terminer()
        {
            if (pourcentageRemise == null)
            {
                pourcentageRemise = "0";
            }
            decimal Sum_cout_ttl = form_caisse.SumColumn(form_caisse.dataGridView1, "cout_ttl");
            DateTime currentDateTime = DateTime.Now;
            classVente.insertFacture(
                        txt_nmr_bon.Text,
                        Convert.ToDateTime(form_caisse.dateTimetxt.Value),
                        currentDateTime.TimeOfDay,
                        id_client,
                        decimal.Parse(txt_ttl_fctr.Text),
                        decimal.Parse(txt_ttl_fctr.Text),
                        0,
                        decimal.Parse(lb_historique_credit.Text),
                        decimal.Parse(txt_versement.Text),
                        decimal.Parse(lb_new_credit.Text),
                        decimal.Parse(txt_vlr_remise.Text),
                        float.Parse(pourcentageRemise),
                        Count,
                        "",
                        "فاتورة مكتملة",
                        id_user,
                        ID_caissier,
                        Sum_cout_ttl
                        );


            classCaisse.update_history_caissier(
                    form_caisse.ID_historique,
                    currentDateTime.TimeOfDay,
                    decimal.Parse(txt_ttl_fctr.Text)
                    );


            historique_Client.insert_history_client(
                        Convert.ToDateTime(form_caisse.dateTimetxt.Value),
                        id_client,
                        decimal.Parse(txt_ttl_fctr.Text),
                        decimal.Parse(txt_versement.Text),
                        decimal.Parse(lb_historique_credit.Text),
                        decimal.Parse(lb_new_credit.Text),
                        "سند جديد",
                        txt_nmr_bon.Text
                        );


            historique_Client.edit_sold_client(
                        id_client,
                        decimal.Parse(txt_versement.Text),
                        decimal.Parse(lb_new_credit.Text),
                        decimal.Parse(txt_ttl_fctr.Text)
                        );


            form_caisse.delte_qt_matier();
            //insert list de vente
            foreach (DataGridViewRow row in form_caisse.dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Récupérez les valeurs nécessaires de la ligne actuelle du DataGridView
                    string codeBarrePRoduit = row.Cells["DgvCodeBarre"].Value.ToString();
                    float Quantitevente = float.Parse(row.Cells["dgvQt"].Value.ToString());
                    decimal PrixVente = decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
                    decimal PrixTotal = decimal.Parse(row.Cells["dgbTtl"].Value.ToString());
                    decimal cout_ttl = decimal.Parse(row.Cells["cout_ttl"].Value.ToString());
                    string DgvType = row.Cells["DgvType"].Value.ToString();
                    string IdFacture = this.txt_nmr_bon.Text;
                    // Assurez-vous de remplacer "nouvelle_quantite" par le nom réel de la colonne
                    classVente.InsertVente(
                                              codeBarrePRoduit,
                                              Quantitevente,
                                              PrixVente,
                                              PrixTotal,
                                              IdFacture, cout_ttl, DgvType
                                              );
                    // Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit 
                }
            }
        }
        public void edit_fctr_termeinier()
        {
            if (pourcentageRemise == null)
            {
                pourcentageRemise = "0";
            }
            decimal Sum_cout_ttl = form_caisse.SumColumn(form_caisse.dataGridView1, "cout_ttl");
            DateTime currentDateTime = DateTime.Now;
            classVente.edit_facture(
                       txt_nmr_bon.Text,
                        Convert.ToDateTime(form_caisse.dateTimetxt.Value),
                        currentDateTime.TimeOfDay,
                        id_client,
                        decimal.Parse(txt_ttl_fctr.Text),
                        decimal.Parse(txt_ttl_fctr.Text),
                        0,
                        decimal.Parse(lb_historique_credit.Text),
                        decimal.Parse(txt_versement.Text),
                        decimal.Parse(lb_new_credit.Text),
                        decimal.Parse(txt_vlr_remise.Text),
                        float.Parse(pourcentageRemise),
                        Count,
                        "",
                        "فاتورة مكتملة",
                        id_user,
                        ID_caissier,
                        Sum_cout_ttl
                        );

            classCaisse.clear_vente_where_edit(txt_nmr_bon.Text);
            classCaisse.update_history_caissier(
                   form_caisse.ID_historique,
                    currentDateTime.TimeOfDay,
                    decimal.Parse(txt_ttl_fctr.Text)
                   );
            historique_Client.insert_history_client(
                        Convert.ToDateTime(form_caisse.dateTimetxt.Value),
                        id_client,
                        decimal.Parse(txt_ttl_fctr.Text),
                        decimal.Parse(txt_versement.Text),
                        decimal.Parse(lb_historique_credit.Text),
                        decimal.Parse(lb_new_credit.Text),
                        "سند جديد",
                        txt_nmr_bon.Text
                        );
            historique_Client.edit_sold_client(
                        id_client,
                        decimal.Parse(txt_versement.Text),
                        decimal.Parse(lb_new_credit.Text),
                        decimal.Parse(txt_ttl_fctr.Text)
                        );


            form_caisse.delte_qt_matier();
            //insert list de vente
            foreach (DataGridViewRow row in form_caisse.dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Récupérez les valeurs nécessaires de la ligne actuelle du DataGridView
                    string codeBarrePRoduit = row.Cells["DgvCodeBarre"].Value.ToString();
                    float Quantitevente = float.Parse(row.Cells["dgvQt"].Value.ToString());
                    decimal PrixVente = decimal.Parse(row.Cells["dgvAmount"].Value.ToString());
                    decimal PrixTotal = decimal.Parse(row.Cells["dgbTtl"].Value.ToString());
                    decimal cout_ttl = decimal.Parse(row.Cells["cout_ttl"].Value.ToString()); 
                    string DgvType = row.Cells["DgvType"].Value.ToString();

                    string IdFacture = this.txt_nmr_bon.Text;
                    // Assurez-vous de remplacer "nouvelle_quantite" par le nom réel de la colonne
                    classVente.InsertVente(
                                              codeBarrePRoduit,
                                              Quantitevente,
                                              PrixVente,
                                              PrixTotal,
                                              IdFacture, cout_ttl, DgvType
                                              );
                    // Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit 
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Typpped == "edit")
            {
                DateTime currentDateTime = DateTime.Now;
                edit_fctr_termeinier();
                form_caisse.DeleteRowByCodeBarre();
                form_caisse.dataGridView1.Refresh();
                form_caisse.GetTTL();
                form_caisse.txtCount.Text = form_caisse.getCount().ToString();
                //ChecK_And_print();
                form_caisse.txt_id_fctr.Text = classVente.get_fctr_vnt();
                Typpped = "add";
            }
            else
            {
                DateTime currentDateTime = DateTime.Now;
                Facture_terminer();
                form_caisse.DeleteRowByCodeBarre();
                form_caisse.dataGridView1.Refresh();
                form_caisse.GetTTL();
                form_caisse.txtCount.Text = form_caisse.getCount().ToString();
                //form_caisse.ChecK_And_print();
                form_caisse.txt_id_fctr.Text = classVente.get_fctr_vnt();
                Typpped = "add";
            }
            this.Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            txt_versement.Text = txt_versement.Text + ",";
        }

        private void button17_Click(object sender, EventArgs e)
        {

            txt_versement.Text = "0";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            txt_versement.Text = txt_versement.Text + ".";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            txt_versement.Text = txt_versement.Text + "1";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            txt_versement.Text = txt_versement.Text + "2";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            txt_versement.Text = txt_versement.Text + "3";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txt_versement.Text = txt_versement.Text + "4";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txt_versement.Text = txt_versement.Text + "5";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txt_versement.Text = txt_versement.Text + "6";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txt_versement.Text = txt_versement.Text + "7";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txt_versement.Text = txt_versement.Text + "8";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txt_versement.Text = txt_versement.Text + "9";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_versement.Text))
            {
                // Remove the last character from the TextBox
                txt_versement.Text = txt_versement.Text.Substring(0, txt_versement.Text.Length - 1);

                // Optional: Set the cursor to the end of the text
                txt_versement.SelectionStart = txt_versement.Text.Length;
                txt_versement.SelectionLength = 0;
                if(txt_versement.Text == ""){
                    txt_versement.Text = "0";
                }
            }
        }
        private decimal calculeRest(decimal ttl, decimal verse)
        {
            decimal rest = ttl - verse;
            return rest;
        }
        public decimal calcule_credit_after(decimal sold_old)
        {
            decimal sold_after = decimal.Parse(txt_retour.Text);
            decimal soldnew = sold_old + sold_after;
            return soldnew;
        }
        private void txt_versement_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_retour.Text = calculeRest(decimal.Parse(txt_ttl_fctr.Text), decimal.Parse(txt_versement.Text)).ToString(); 

                decimal sold_non_pays = decimal.Parse(lb_historique_credit.Text); 

                lb_new_credit.Text = calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString(); 
            }
            catch
            {

            }
        }

        private void txt_ttl_fctr_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm_confirme_bon_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = classCaisse1.get_information_caissier(ID_caissier);
            object NamePrename = dt.Rows[0][1];
            txt_caissier.Text = NamePrename.ToString();

            DataTable dt_1 = new DataTable();
            dt = classCaisse1.get_information_user(id_user);
            object NamePrename_user = dt.Rows[0][2];
            txt_user.Text = NamePrename_user.ToString();

            try
            {
                txt_retour.Text = calculeRest(decimal.Parse(txt_ttl_fctr.Text), decimal.Parse(txt_versement.Text)).ToString();

                decimal sold_non_pays = decimal.Parse(lb_historique_credit.Text);

                lb_new_credit.Text = calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString();
            }
            catch
            {

            }
        }
    }
}
