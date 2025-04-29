using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.PL_reparation
{
    public partial class frm_add_reparation : Form
    {
        BL.BL_REPARATION.BL_REPARATION class_reparation = new BL.BL_REPARATION.BL_REPARATION();
        public frm_reparation frm_reparation;
        public int id_user;
        public frm_add_reparation()
        {
            InitializeComponent();
        }
        private long GenerateRandomNumber()
        {
            Random random = new Random();

            // Generate a random 9-digit number
            long randomNumberPart = random.Next(0, 1_000_000_000);

            // Append "612" to the random number to ensure it starts with "612"
            string randomNumStr = "123" + randomNumberPart.ToString("D9");

            // Convert the 12-digit number string back to long
            long randomNum = long.Parse(randomNumStr);

            return randomNum;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            long randomNum = GenerateRandomNumber();

            // Display the random number in the textbox
            txtBarcode.Text = randomNum.ToString();
            string barCode = txtBarcode.Text;
            try
            {
                Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                pictureBox1.Image = brCode.Draw(barCode, 100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string barCode = txtBarcode.Text;
            Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            using (MemoryStream mss = new MemoryStream())
            {
                System.Drawing.Image barcodeImage = brCode.Draw(barCode, 100);
                barcodeImage.Save(mss, ImageFormat.Png); // Save the image in PNG format

                // Convert MemoryStream to byte array
                byte[] byteImage = mss.ToArray();

                class_reparation.Add_Reparation(
                        txtBarcode.Text,
                        Convert.ToDateTime(dateTimePicker1.Text),
                        TimeSpan.Parse(dateTimePicker2.Text),
                        txt_client.Text,
                        txt_nmr_tele.Text,
                        txt_problem.Text,
                        decimal.Parse(txt_price.Text),
                        "مرحلة الصيانة",
                        byteImage);
                frm_reparation.dataGridView1.DataSource = class_reparation.GetRepatationRecords();
                MessageBox.Show("تم ادخال المعلومات بنجاح");
                this.Close();
            }
              
        }

        
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            string barCode = txtBarcode.Text;
            try
            {
                Zen.Barcode.Code128BarcodeDraw brCode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                pictureBox1.Image = brCode.Draw(barCode, 100);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
