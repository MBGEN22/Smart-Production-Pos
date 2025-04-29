using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PLADD.production
{
	public partial class frm_paramétrage : Form
	{
		BL.BL_PRODUCTION.BL_GESTION_PRODUIT_FINAUX classProduit_finaux = new BL.BL_PRODUCTION.BL_GESTION_PRODUIT_FINAUX();
		BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
		decimal pricettl;
		string delte;
		public frm_paramétrage()
		{
			InitializeComponent();
			grid_matier.DataSource = classProduit_finaux.get_matier_premier_production_caisse();

			cmb_matier.DataSource = clasCombobox.get_product();
			cmb_matier.DisplayMember = "DESIGNATION";
			cmb_matier.ValueMember = "CODEBARRE";

			cmb_categories.DataSource = clasCombobox.get_combo_Categorie();
			cmb_categories.DisplayMember = "CATEGORIES";
			cmb_categories.ValueMember = "ID";
			
			cmb_unite.DataSource = clasCombobox.get_combo_Iunite();
			cmb_unite.DisplayMember = "UNITE";
			cmb_unite.ValueMember = "ID";
			cout_production.Text = get_sum_money_cout().ToString();
		}
		#region

		//FUNCTION
		public decimal calcule_TVA(decimal priceHt, decimal TVA)
		{
			decimal priceTTC = priceHt + (priceHt * (TVA / 100));
			return priceTTC;
		}

		private void delletFromCaisse_matier()
		{
			DAL.DAL DAaL = new DAL.DAL();
			// SQL query
			string query = @"DELETE FROM [dbo].[TB_MATIER_PREMIER_PRODUCTION_CAISS];";
			try
			{
				using (DAaL.sqlConnection)
				{
					DAaL.sqlConnection.Open();

					using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
					{
						int rowsAffected = command.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}
		private void sendTotable_matier()
		{
			DAL.DAL daoo = new DAL.DAL();
			// SQL query
			string query = @"
					      SET IDENTITY_INSERT [dbo].[TB_MATIER_PREMIER_PRODUCTION] on 
						INSERT INTO [dbo].[TB_MATIER_PREMIER_PRODUCTION]
						   (ID
						   ,[ID_PRODUIT_FINAUX]
						   ,[ID_MATIER_PREMIER]
						   ,[QT]
						   ,[PRICE_ACHAT]
						   ,[PRICE_TTL]
						   ,[QT_DECHET]
						   ,[delte]) 
						SELECT [ID]
							  ,[ID_PRODUIT_FINAUX]
							  ,[ID_MATIER_PREMIER]
							  ,[QT]
							  ,[PRICE_ACHAT]
							  ,[PRICE_TTL]
							  ,[QT_DECHET]
							  ,[delte]
						  FROM [dbo].[TB_MATIER_PREMIER_PRODUCTION_CAISS]
						SET IDENTITY_INSERT [dbo].[TB_MATIER_PREMIER_PRODUCTION] OFF ";
			try
			{
				using (daoo.sqlConnection)
				{
					daoo.sqlConnection.Open();

					using (SqlCommand command = new SqlCommand(query, daoo.sqlConnection))
					{
						int rowsAffected = command.ExecuteNonQuery();
						MessageBox.Show($"{rowsAffected} تم حفظ جدول المواد الأولية.");
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}

		}

		public decimal get_sum_money_cout()
		{
			DAL.DAL DAaL = new DAL.DAL();

			decimal sum = 0;

			using (DAaL.sqlConnection)
			{
				string query = "SELECT SUM(PRICE_TTL) FROM [dbo].[TB_MATIER_PREMIER_PRODUCTION_CAISS]";
				using (SqlCommand command = new SqlCommand(query, DAaL.sqlConnection))
				{
					DAaL.sqlConnection.Open();
					var result = command.ExecuteScalar();
					if (result != DBNull.Value)
					{
						sum = Convert.ToInt32(result);
					}
				}
			}
			return sum;
		}



		//
		#endregion

		private void label9_Click(object sender, EventArgs e)
		{

		}

		private void label15_Click(object sender, EventArgs e)
		{

		}
		private long GenerateRandomNumber()
		{
			Random random = new Random();

			// Generate a random 10-digit number
			long randomNumberPart = random.Next(0, 10_000_000_0);

			// Append "612" to the random number to ensure it starts with "612"
			long randomNum = long.Parse("812" + randomNumberPart.ToString("D10"));

			return randomNum;
		}

		private long GenerateRandomNumberPACK()
		{
			Random random = new Random();

			// Generate a random 10-digit number
			long randomNumberPart = random.Next(0, 10_000_000_0);

			// Append "612" to the random number to ensure it starts with "612"
			long randomNum = long.Parse("912" + randomNumberPart.ToString("D10"));

			return randomNum;
		}

		private int calculeQt_pack(int Qt_produit , int qt_danspack)
		{
			int Qt_pack = Qt_produit / qt_danspack;
			return Qt_produit;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			long randomNum = GenerateRandomNumber();
			long randomNum1 = GenerateRandomNumberPACK();
			// Display the random number in the textbox
			txtBarcode.Text = randomNum.ToString();
			txtbarcode_pack.Text = randomNum1.ToString();
			//
			string barCode = txtBarcode.Text;
			string barCode1 = txtbarcode_pack.Text;

			try
			{
				Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
				pictureBox1.Image = brCode.Draw(barCode, 100);
				lbBrCode.Text = barCode; 
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (check_recyvle.Checked == true)
			{
				delte = "نعم";
			}
			else if (check_recyvle.Checked == false)
			{
				delte = "لا";
			}
			pricettl = decimal.Parse(price_matier.Text) * decimal.Parse(qt_matier.Text);
			if (txtBarcode.Text == "")
			{
				MessageBox.Show("يجب أولا ملئ رقم المنتوج");
			}
			else
			{ 
				classProduit_finaux.INSERT_matier_premier_production_caisse(
					txtBarcode.Text,
					cmb_matier.SelectedValue.ToString(),
					Convert.ToInt16(qt_matier.Text),
					decimal.Parse(price_matier.Text),
					pricettl,
					Convert.ToInt16(qt_dechet.Text),
					delte
					);
				grid_matier.DataSource = classProduit_finaux.get_matier_premier_production_caisse();
				qt_matier.Text = qt_dechet.Text = price_matier.Text = "0";
				check_recyvle.Checked = false;
			}
			cout_production.Text = get_sum_money_cout().ToString();


		}

		private void button12_Click(object sender, EventArgs e)
		{
			detailes.frm_list_produit_primaire_for_produiree list_achat = new detailes.frm_list_produit_primaire_for_produiree();
			list_achat.id_type_edit_or_add = 1;
			list_achat.form_paramétrage = this;
			list_achat.id_produit = cmb_matier.SelectedValue.ToString();
			list_achat.ShowDialog();
		}

		private void kryptonButton2_Click(object sender, EventArgs e)
		{
			classProduit_finaux.add_gestion_produit_finaux(
				txtBarcode.Text,
				txt_designation.Text,
				Convert.ToInt16(txt_qt_parametrage.Text),//
				Convert.ToInt16(cmb_unite.SelectedValue),//
				Convert.ToInt16(cmb_categories.SelectedValue),//
				decimal.Parse(cout_production.Text),//
				Convert.ToInt16(qt_dans_pack.Text),//
				0,
				0,
				0,
				0,
				decimal.Parse(price_vente_HT.Text),//
				decimal.Parse(txt_vente_ttc.Text),//
				float.Parse(txt_tva.Text),//
				decimal.Parse(txt_price_gros.Text),
				decimal.Parse(txt_price_min.Text),
				Convert.ToInt32(txt_qt_alert.Text)
				);
			if (checkBox1.Checked == true)
			{ 
				classProduit_finaux.insert_pack(
					txtbarcode_pack.Text,
					pack_designation.Text,
					txtBarcode.Text,
					0,
					decimal.Parse(gros_pack.Text),
					decimal.Parse(ttc_pack.Text),
					decimal.Parse(gros_pack.Text)
					);
			}
			sendTotable_matier();
			delletFromCaisse_matier();
			MessageBox.Show("تم انشاء معلومات المنتج بنجاح");
			this.Close();
		}
		private void price_vente_HT_TextChanged(object sender, EventArgs e)
		{
			txt_vente_ttc.Text= calcule_TVA(
				decimal.Parse(price_vente_HT.Text),
				decimal.Parse(txt_tva.Text)
				).ToString();
		}

		private void txt_tva_TextChanged(object sender, EventArgs e)
		{
			txt_vente_ttc.Text = calcule_TVA(
				decimal.Parse(price_vente_HT.Text),
				decimal.Parse(txt_tva.Text)
				).ToString();
		}

		private void txt_price_min_TextChanged(object sender, EventArgs e)
		{

		}

		private void txt_price_min_Click(object sender, EventArgs e)
		{
			txt_price_min.SelectAll();
		}

		private void qt_matier_TextChanged(object sender, EventArgs e)
		{
			
		}

		private void qt_matier_Click(object sender, EventArgs e)
		{
			qt_matier.SelectAll();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("هذا الخيار سيقوم بحذف البيانات", "عملية الحذف  ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{ 
				classProduit_finaux.delete_tb_caisse_(
					(int)this.grid_matier.CurrentRow.Cells[0].Value
					);
				grid_matier.DataSource = classProduit_finaux.get_matier_premier_production_caisse();
				MessageBox.Show("تمت عملية الحذف بنجاح");
			} 
			cout_production.Text = get_sum_money_cout().ToString();
		}

		private void kryptonGroupBox1_Panel_Paint(object sender, PaintEventArgs e)
		{

		}

		private void txt_designation_TextChanged(object sender, EventArgs e)
		{
			pack_designation.Text = txt_designation.Text + " /Pack";
		}

		private void check_recyvle_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked == true)
			{
				qt_dans_pack.Enabled = true;
				kryptonGroup5.Enabled = true;
			}
			else if (checkBox1.Checked == false)
			{
				qt_dans_pack.Enabled = false;
				kryptonGroup5.Enabled = false;
			}
		}

		private void grid_matier_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void label25_Click(object sender, EventArgs e)
		{

		}
	}
}
