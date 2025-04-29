using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.PL_reparation
{
    public partial class frm_edit_reparation : Form
    {
        BL.BL_REPARATION.BL_REPARATION class_repearation = new BL.BL_REPARATION.BL_REPARATION(); 
        public frm_reparation frm_reparation;
        public frm_edit_reparation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            class_repearation.edit_etas(
                txtBarcode.Text,
                Convert.ToDateTime(dateTimePicker1.Text),
                decimal.Parse(txt_price.Text),
                txt_etas.Text
                );
            frm_reparation.dataGridView1.DataSource = class_repearation.GetRepatationRecords();
            MessageBox.Show("تم ادخال المعلومات بنجاح");

        }
    }
}
