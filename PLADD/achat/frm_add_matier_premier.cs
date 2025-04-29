using Smart_Production_Pos.PL.Achats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using ZXing;
using Smart_Production_Pos.PLADD.Fichier;

namespace Smart_Production_Pos.PLADD.achat
{
	public partial class frm_add_matier_premier : Form
	{
		BL.BL_COMBOBOX clasCombobox = new BL.BL_COMBOBOX();
		BL.BL_Achats.BL_Produit classProduit = new BL.BL_Achats.BL_Produit();
		BL.BL_Achats.BL_Achats classAchats = new BL.BL_Achats.BL_Achats();
		public string  id_fctr;
		public frm_achat formCaise;
		public frm_add_matier_premier()
		{
			InitializeComponent();
			cmb_categories.DataSource = clasCombobox.get_combo_Categorie();
			cmb_categories.DisplayMember = "CATEGORIES";
			cmb_categories.ValueMember = "ID";

			cmb_marque.DataSource = clasCombobox.get_combo_Marque();
			cmb_marque.DisplayMember = "Marque";
			cmb_marque.ValueMember = "ID";

			cmb_stocke.DataSource = clasCombobox.get_combo_stock();
			cmb_stocke.DisplayMember = "STOCKE";
			cmb_stocke.ValueMember = "ID";

			cmb_unite.DataSource = clasCombobox.get_combo_Iunite();
			cmb_unite.DisplayMember = "UNITE";
			cmb_unite.ValueMember = "ID"; 
		}

		private void tabPage2_Click(object sender, EventArgs e)
		{

		}
		private long GenerateRandomNumber()
		{
			Random random = new Random();

			// Generate a random 10-digit number
			long randomNumberPart = random.Next(0, 10_000_000_0);

			// Append "612" to the random number to ensure it starts with "612"
			long randomNum = long.Parse("61" + randomNumberPart.ToString("D10"));

			return randomNum;
		}
		public static string GenerateEAN13()
		{
			Random random = new Random();

			// Generate a random 9-digit number
			long randomNumberPart = random.Next(0, 1000000000);

			// Append "612" to the random number to ensure it starts with "612"
			string partialEAN13 = "612" + randomNumberPart.ToString("D9");

			// Calculate the check digit
			int checkDigit = CalculateCheckDigit(partialEAN13);

			// Return the complete EAN-13 code
			return partialEAN13 + checkDigit.ToString();
		}
		private static int CalculateCheckDigit(string ean12)
		{
			int sum = 0;

			// Calculate the sum of the digits, alternating the weights between 1 and 3
			for (int i = 0; i < ean12.Length; i++)
			{
				int digit = int.Parse(ean12[i].ToString());
				if (i % 2 == 0)
				{
					sum += digit;
				}
				else
				{
					sum += digit * 3;
				}
			}

			// Calculate the check digit as the number that, when added to the sum, makes it a multiple of 10
			int remainder = sum % 10;
			int checkDigit = (10 - remainder) % 10;

			return checkDigit;
		}
		private long GenerateRandomNumberPack()
		{
			Random random = new Random();

			// Generate a random 10-digit number
			long randomNumberPart = random.Next(0, 10_000_000_0);

			// Append "612" to the random number to ensure it starts with "612"
			long randomNum = long.Parse("62" + randomNumberPart.ToString("D10"));

			return randomNum;
		}
		private void frm_add_matier_premier_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			string randomNum = GenerateRandomNumber().ToString();

			//// Display the random number in the textbox
			textBoxBarcode.Text = randomNum.ToString();
			string ean13Code = textBoxBarcode.Text;

			if (ean13Code.Length != 12)
			{
				MessageBox.Show("Please enter a 12-digit number.");
				return;
			}

			// توليد كود EAN-13
			var barcodeWriter = new BarcodeWriter
			{
				Format = BarcodeFormat.EAN_13,
				Options = new ZXing.Common.EncodingOptions
				{
					Width = 300,
					Height = 150
				}
			};

			try
			{
				using (Bitmap bitmap = barcodeWriter.Write(ean13Code))
				{
					// عرض الصورة في PictureBox
					pictureBoxBarcode.Image = new Bitmap(bitmap);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error generating barcode: " + ex.Message);
			}

			
			//string barCode = txtBarcode.Text;
			//try
			//{
			//	Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
			//	pictureBox1.Image = brCode.Draw(barCode, 100);
			//	lbBrCode.Text = barCode;
			//}
			//catch (Exception ex)
			//{
			//	MessageBox.Show(ex.ToString());
			//}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			long randomNum = GenerateRandomNumberPack();
 
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (check_Pack.Checked == true)
			{
				crownGroupBox1.Enabled = true;
			}
			else if (check_Pack.Checked == false)
			{
				crownGroupBox1.Enabled = false;
			}
		}

		public decimal calcule_TVA(decimal priceHt , decimal TVA)
		{
			decimal priceTTC = priceHt + (priceHt * (TVA / 100));
			return priceTTC;
		}

		public decimal _calcule_total(decimal price , decimal QT)
		{
			decimal total = price * QT;
			return total;
		}

		private void txt_achat_ht_TextChanged(object sender, EventArgs e)
		{
			
			txt_achat_ttc.Text = calcule_TVA(
				decimal.Parse(txt_achat_ht.Text),
				decimal.Parse(txt_tva.Text)
				).ToString();
		}

		private void txt_tva_TextChanged(object sender, EventArgs e)
		{
			txt_achat_ttc.Text = calcule_TVA(
				decimal.Parse(txt_achat_ht.Text),
				decimal.Parse(txt_tva.Text)
				).ToString();
		}

		private void txt_qt_TextChanged(object sender, EventArgs e)
		{
			txt_total_ht.Text =
			_calcule_total(decimal.Parse(txt_achat_ht.Text), decimal.Parse(txt_qt.Text)).ToString();
			txt_total_ttc.Text =
			_calcule_total(decimal.Parse(txt_achat_ttc.Text), decimal.Parse(txt_qt.Text)).ToString();
		}
		private decimal calculeQT(decimal Qt_u , decimal QT_pake )
		{
			decimal QT_on_pake = Qt_u / QT_pake;
			return QT_on_pake;
		}
		private void txt_qt_pack_TextChanged(object sender, EventArgs e)
		{
			qt_dans_pack_txt.Text = calculeQT(
				decimal.Parse(txt_qt.Text),
				decimal.Parse(txt_qt_pack.Text)
				).ToString();
		}
		private void add_produit_and_caisse()
		{
			MemoryStream ms = new MemoryStream();
			pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
			byte[] byteImage = ms.ToArray();

			int? qt_pack = null;
			DateTime? datePeretion = null;
			string produitPies;
			int stock_min;

			if (check_Pack.Checked == true)
			{
				qt_pack = Convert.ToInt32(qt_dans_pack_txt.Text);
			}
			else
			{
				qt_pack = null;
			}


			if (checkBox1.Checked == true)
			{
				datePeretion = Convert.ToDateTime(kryptonDateTimePicker2.Value);
			}
			else
			{
				datePeretion = null;
			}


			if (checkBox3.Checked == true)
			{
				produitPies = "yes";
			}
			else
			{
				produitPies = "no";
			}

			classProduit.Add_Funct(
				textBoxBarcode.Text,
				txt_designation.Text,
				Convert.ToInt16(cmb_unite.SelectedValue),
				Convert.ToInt16(cmb_categories.SelectedValue),
				Convert.ToInt16(cmb_stocke.SelectedValue),
				Convert.ToInt16(cmb_marque.SelectedValue),
				Convert.ToInt32(txt_qt.Text),
				Convert.ToInt32(txt_qt.Text),
				0,
				qt_pack,
				byteImage,
				datePeretion,
				txt_rmrq.Text,
				0,
				produitPies, 
				txt_reference.Text
				);
			classAchats.add_on_caisse_matier_premier(
				textBoxBarcode.Text,
				Convert.ToInt32(txt_qt.Text),
				Convert.ToInt32(txt_qt.Text),
				decimal.Parse(txt_achat_ht.Text),
				decimal.Parse(txt_tva.Text),
				decimal.Parse(txt_achat_ttc.Text),
				decimal.Parse(txt_total_ht.Text),
				decimal.Parse(txt_total_ttc.Text),
				txt_rmrq.Text,
				id_fctr,
				"شراء جديد"
				);
			formCaise.dataGridView1.DataSource = classAchats.get_Caisse_table();
			formCaise.txt_id_fctr.Text = classAchats.get_facture_number().ToString();
			formCaise.lb_total_ht.Text = classAchats.get_TOTAL_HT().ToString();
			formCaise.lb_total_ttc.Text = classAchats.get_TOTAL_TTC().ToString();
			formCaise.txt_nmbre_produit.Text = classAchats._nmbre_produit().ToString();
			formCaise.get_sold();
		}

		private void kryptonButton4_Click(object sender, EventArgs e)
		{
			add_produit_and_caisse();
			this.Close();
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			OpenFileDialog Ofd = new OpenFileDialog();
			Ofd.Filter = "Photo |*.JPG; *.PNG; *.GIF; *.BMP ";
			if (Ofd.ShowDialog() == DialogResult.OK)
			{
				pictureBox2.Image = Image.FromFile(Ofd.FileName);
			}
		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{
			detailes.frm_details_product_M_P detailes = new detailes.frm_details_product_M_P();
			add_produit_and_caisse();
			detailes.id_produit_txt.Text = this.textBoxBarcode.Text; 
			detailes.id_produit = this.textBoxBarcode.Text;
			detailes.ShowDialog();
			this.Close();
		}

		private void txt_achat_ht_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
			{
				e.Handled = true;
			}
		}

		private void txt_tva_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
			{
				e.Handled = true;
			}
		}

		private void txt_achat_ttc_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
			{
				e.Handled = true;
			}
		}

		private void txt_qt_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
			{
				e.Handled = true;
			}
		}

		private void txt_total_ht_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
			{
				e.Handled = true;
			}
		}

		private void txt_total_ttc_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
			{
				e.Handled = true;
			}
		}

		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void txt_qt_pack_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
			{
				e.Handled = true;
			}
		}

		private void qt_dans_pack_txt_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
			{
				e.Handled = true;
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_categories categoriesADD = new Fichier.frm_categories();
			categoriesADD.Type = "A";
			categoriesADD.ShowDialog();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_add_Stockes frm_add_StockesA = new Fichier.frm_add_Stockes();
			frm_add_StockesA.Type = "A";
			frm_add_StockesA.ShowDialog();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_add_marque frmMArqueA = new Fichier.frm_add_marque();
			frmMArqueA.Type = "A";
			frmMArqueA.ShowDialog();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			PLADD.Fichier.frm_unite uniteADD = new Fichier.frm_unite();
			uniteADD.Type = "A";
			uniteADD.ShowDialog();
		}

		private void txtBarcode_TextChanged(object sender, EventArgs e)
		{
			long randomNum = long.Parse(textBoxBarcode.Text);
			string barCode = textBoxBarcode.Text;
			try
			{
				Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
				pictureBoxBarcode.Image = brCode.Draw(barCode, 100);
				lbBrCode.Text = barCode;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void textBoxBarcode_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
			{
				e.Handled = true;
			}
		}
	}
}
