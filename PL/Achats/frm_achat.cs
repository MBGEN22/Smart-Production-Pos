using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Achats
{
	public partial class frm_achat : Form
	{
		BL.BL_Achats.BL_Produit classProduct = new BL.BL_Achats.BL_Produit();
		BL.BL_Achats.BL_Achats classAchat = new BL.BL_Achats.BL_Achats();
		BL.frnsre_history_sold class_frnsr_sold = new BL.frnsre_history_sold();
		int Nombre_Produit;
		string codeBare;
		DAL.DAL daoo;
		public int id_user;
		BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
		BL.BL_Achats.BL_facture classFacture = new BL.BL_Achats.BL_facture();
		public frm_achat()
		{
			InitializeComponent();
			this.dataGridView1.DataSource = classAchat.get_Caisse_table();
			txt_id_fctr.Text = classAchat.get_facture_number().ToString();
			lb_total_ht.Text = classAchat.get_TOTAL_HT().ToString();
			lb_total_ttc.Text = classAchat.get_TOTAL_TTC().ToString();
			txt_nmbre_produit.Text = classAchat._nmbre_produit().ToString();

			cmbfrnse.DataSource = clasCombobox.getfrnsr();
			cmbfrnse.DisplayMember = "frnsr";
			cmbfrnse.ValueMember = "ID";

			cmb_product.DataSource = clasCombobox.get_product();
			cmb_product.DisplayMember = "DESIGNATION";
			cmb_product.ValueMember = "CODEBARRE";
			get_sold();
		}

		private void label13_Click(object sender, EventArgs e)
		{

		}

		private void label12_Click(object sender, EventArgs e)
		{

		}
	
		private void label11_Click(object sender, EventArgs e)
		{
			
		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void button7_Click(object sender, EventArgs e)
		{
			PLADD.achat.frm_add_matier_premier add_matier = new PLADD.achat.frm_add_matier_premier();
			add_matier.id_fctr =  txt_id_fctr.Text;
			add_matier.formCaise = this;
			add_matier.ShowDialog();
		}

		public void get_sold()
		{
			int id_frnsrt = Convert.ToInt32(cmbfrnse.SelectedValue);
			DataTable Dt = new DataTable();
			Dt = classAchat.get_sold_frnser(id_frnsrt);

			Object ID = Dt.Rows[0][0];
			Object sold_non_pays = Dt.Rows[0][8];
			lb_historique_credit.Text = sold_non_pays.ToString();
			calcule_credit_after(decimal.Parse(sold_non_pays.ToString())) ;
			lb_new_credit.Text = calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString();
		}
		private decimal calcule_credit_after(decimal sold_old )
		{
			decimal sold_after = decimal.Parse(lb_total_ttc.Text) - decimal.Parse(txt_versement.Text);
			decimal soldnew = sold_old + sold_after;
			return soldnew;
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{ 
			if (MessageBox.Show("هذا الخيار سيقوم بحفظ الفاتورة هل انت متأكد", "عملية انشاء فاتورة  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{ 
				classFacture.create_facture_achat(
				txt_id_fctr.Text,
				Convert.ToDateTime(kryptonDateTimePicker1.Value),
				Convert.ToInt32(cmbfrnse.SelectedValue),
				Convert.ToInt32(txt_nmbre_produit.Text),
				decimal.Parse(txt_versement.Text),
				decimal.Parse(lb_total_ttc.Text),
				id_user,
				decimal.Parse(lb_total_ht.Text),
				decimal.Parse(lb_historique_credit.Text),
				decimal.Parse(lb_new_credit.Text)
				);
				class_frnsr_sold.edit_sold_frnse(
					Convert.ToInt16(cmbfrnse.SelectedValue),
					decimal.Parse(lb_total_ttc.Text),
					decimal.Parse(txt_versement.Text),
					decimal.Parse(lb_new_credit.Text)
					);
				class_frnsr_sold.insert_history_frnsre(
					Convert.ToDateTime(kryptonDateTimePicker1.Value),
					Convert.ToInt32(cmbfrnse.SelectedValue),
					decimal.Parse(txt_versement.Text),
					decimal.Parse(lb_historique_credit.Text),
					decimal.Parse(lb_new_credit.Text),
					"شراء"
					);
				send_toAchat();
				delletFromCaisse();
				MessageBox.Show("تم انشاء الفاتورة وحفظها بنجاح");
				this.dataGridView1.DataSource = classAchat.get_Caisse_table();
				txt_id_fctr.Text = classAchat.get_facture_number().ToString();
				lb_total_ht.Text = classAchat.get_TOTAL_HT().ToString();
				lb_total_ttc.Text = classAchat.get_TOTAL_TTC().ToString();
				txt_nmbre_produit.Text = classAchat._nmbre_produit().ToString();

			}
		}

		private void send_toAchat()
		{
			DAL.DAL DAaL = new DAL.DAL();
			string setIdentityOnQuery = @"SET IDENTITY_INSERT [dbo].TB_ACHAT ON;";
			string setIdentityOffQuery = @"SET IDENTITY_INSERT [dbo].TB_ACHAT OFF;";
			string insertQuery = @"
			INSERT INTO [dbo].[TB_ACHAT]
			([ID]
			,[ID_PRODUIT]
			,[QUANTITE]
			,[QUANTITE_AFTER]
			,[PRIX_ACHAT_HT]
			,[TVA]
			,[PRIX_ACHAT_TTC]
			,[TOTAL_HT]
			,[TOTAL_TTC]
			,[REMARQUE]
			,[ID_FACTURE]) 
        SELECT  
             [ID]
            ,[ID_PRODUIT]
            ,[QUANTITE]
            ,[QUANTITE_AFTER]
            ,[PRIX_ACHAT_HT]
            ,[TVA]
            ,[PRIX_ACHAT_TTC]
            ,[TOTAL_HT]
            ,[TOTAL_TTC]
            ,[REMARQUE]
            ,[ID_FACTURE]
        FROM [dbo].[TB_ACHAT_CAISSE];";

			try
			{
				using (DAaL.sqlConnection)
				{
					DAaL.sqlConnection.Open();

					// Turn on identity insert
					using (SqlCommand command = new SqlCommand(setIdentityOnQuery, DAaL.sqlConnection))
					{
						command.ExecuteNonQuery();
					}

					// Execute the insert query
					using (SqlCommand command = new SqlCommand(insertQuery, DAaL.sqlConnection))
					{
						int rowsAffected = command.ExecuteNonQuery();
						MessageBox.Show($"تم حفظ معلومات الشراء");
					}

					// Turn off identity insert
					using (SqlCommand command = new SqlCommand(setIdentityOffQuery, DAaL.sqlConnection))
					{
						command.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}
		private void delletFromCaisse()
		{



			//string mode = Properties.Settings.Default.mode;
			//if (mode == "SQL")
			//{
			//	sqlConnection = new SqlConnection(@"Server=" + Properties.Settings.Default.server + "; Database=" + Properties.Settings.Default.dataBase +
			//		"; Integrated Security=false ; User ID =" + Properties.Settings.Default.ID + ";Password=" + Properties.Settings.Default.PASS + "");
			//}
			//else
			//{
			//	sqlConnection = new SqlConnection(@"Server=" + Properties.Settings.Default.server + "; Database=" + Properties.Settings.Default.dataBase + "; Integrated Security=true");
			//}
			DAL.DAL daoo = new DAL.DAL();
			SqlConnection sqlConnection = daoo.sqlConnection;


			// SQL query
			string query = @"DELETE FROM [TB_ACHAT_CAISSE];";

			try
			{
				using (sqlConnection)
				{
					sqlConnection.Open();

					using (SqlCommand command = new SqlCommand(query, sqlConnection))
					{
						int rowsAffected = command.ExecuteNonQuery();
						MessageBox.Show($"تم تفريغ السلة.");
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}

		private void txt_versement_TextChanged(object sender, EventArgs e)
		{
			get_sold();
		}

		private void kryptonTextBox12_TextChanged(object sender, EventArgs e)
		{
			PLADD.achat.frm_add_matier_premier add_matier = new PLADD.achat.frm_add_matier_premier();
			txt_total_ttc.Text = add_matier._calcule_total(decimal.Parse(txt_achat_ttc.Text), decimal.Parse(txt_qt.Text)).ToString();
		}

		private void label25_Click(object sender, EventArgs e)
		{

		}

		private void txt_total_ttc_TextChanged(object sender, EventArgs e)
		{

		}

		private void cmb_product_SelectedIndexChanged(object sender, EventArgs e)
		{

			
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{ 
			DataRowView drv = (DataRowView)cmb_product.SelectedItem;

			string codeBare = drv["CODEBARRE"].ToString();
			string Quantite_rest = drv["QUANTITE_REST"].ToString(); ;


			txtBarcode.Text = codeBare.ToString();
			txt_qt_rest.Text = Quantite_rest.ToString();

		}

		private void tabPage4_Click(object sender, EventArgs e)
		{

		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			int qt_after = Convert.ToInt32(txt_qt.Text) + Convert.ToInt32(txt_qt_rest.Text);
			classAchat.add_on_caisse_matier_premier(
					txtBarcode.Text,
					Convert.ToInt32(txt_qt.Text),
					qt_after,
					decimal.Parse(txt_achat_ht.Text),
					decimal.Parse(txt_tva.Text),
					decimal.Parse(txt_achat_ttc.Text),
					decimal.Parse(txt_total_ht.Text),
					decimal.Parse(txt_total_ttc.Text),
					txt_rmrq.Text,
					txt_id_fctr.Text,
					"تحديث كمية"
					);
			classAchat.udate_matier_on_caisse(
					txtBarcode.Text,
					Convert.ToInt32(txt_qt.Text));
			dataGridView1.DataSource = classAchat.get_Caisse_table();
			txt_id_fctr.Text = classAchat.get_facture_number().ToString();
			lb_total_ht.Text = classAchat.get_TOTAL_HT().ToString();
			lb_total_ttc.Text = classAchat.get_TOTAL_TTC().ToString();
			txt_nmbre_produit.Text = classAchat._nmbre_produit().ToString();
			get_sold();
		}

		private void txt_achat_ht_TextChanged(object sender, EventArgs e)
		{
			PLADD.achat.frm_add_matier_premier add_matier = new PLADD.achat.frm_add_matier_premier();
			txt_total_ht.Text = add_matier._calcule_total(decimal.Parse(txt_achat_ht.Text), decimal.Parse(txt_qt.Text)).ToString();
		}

		private void txt_qt_TextChanged(object sender, EventArgs e)
		{
			PLADD.achat.frm_add_matier_premier add_matier = new PLADD.achat.frm_add_matier_premier();
			txt_total_ht.Text = add_matier._calcule_total(decimal.Parse(txt_achat_ht.Text), decimal.Parse(txt_qt.Text)).ToString();
			txt_achat_ttc.Text = add_matier._calcule_total(decimal.Parse(txt_achat_ttc.Text), decimal.Parse(txt_qt.Text)).ToString();
		}

		private void txt_tva_TextChanged(object sender, EventArgs e)
		{
			PLADD.achat.frm_add_matier_premier add_matier = new PLADD.achat.frm_add_matier_premier();
			txt_achat_ttc.Text = add_matier.calcule_TVA(decimal.Parse(txt_achat_ht.Text), decimal.Parse(txt_tva.Text)).ToString();
		}

		private void kryptonButton3_Click(object sender, EventArgs e)
		{

		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				string type_achat = this.dataGridView1.CurrentRow.Cells["نوع الشراء"].Value.ToString();
				string idProduit = this.dataGridView1.CurrentRow.Cells["رمز المنتج"].Value.ToString();
				int quantite_achat = ((int)this.dataGridView1.CurrentRow.Cells["الكمية"].Value);
				int quantite_rest = ((int)this.dataGridView1.CurrentRow.Cells["كمية المنتج بعد الشراء"].Value);
				int qte_rest_original = quantite_rest - quantite_achat;
				// Appelez la fonction prd2.Edit_Produit() pour mettre à jour le produit
				if (type_achat == "تحديث كمية")
				{
					classAchat.edit_matier_on_caisse(idProduit, quantite_achat, qte_rest_original);
				}
				else if (type_achat == "شراء جديد")
				{
					classAchat.delete_caisse_new_pro(idProduit);
				}
				classAchat.delete_caisse_product((int)this.dataGridView1.CurrentRow.Cells[0].Value);
				MessageBox.Show("تم حذف عملية الشراء بنجاح");
				this.dataGridView1.DataSource = classAchat.get_Caisse_table();
				txt_id_fctr.Text = classAchat.get_facture_number().ToString();
				lb_total_ht.Text = classAchat.get_TOTAL_HT().ToString();
				lb_total_ttc.Text = classAchat.get_TOTAL_TTC().ToString();
				txt_nmbre_produit.Text = classAchat._nmbre_produit().ToString();
			} 
		}

		private void cmbfrnse_SelectedIndexChanged(object sender, EventArgs e)
		{  
			DataRowView drv = (DataRowView)cmbfrnse.SelectedItem; 
			string sold_non_pays = drv["SOLD_NON_PAYE"].ToString();
			lb_historique_credit.Text = sold_non_pays.ToString();
			calcule_credit_after(decimal.Parse(sold_non_pays.ToString()));
			lb_new_credit.Text = calcule_credit_after(decimal.Parse(sold_non_pays.ToString())).ToString(); 
		}

		private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
