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

namespace Smart_Production_Pos.PL.Achat_revente
{
    public partial class frm_calcule_benifice : Form
    {
        BL_STATE classStatique = new BL_STATE();
        public frm_calcule_benifice()
        {
            InitializeComponent();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // تأكد أن الخلية ليست فارغة لتفادي الأخطاء

                row.Cells["اسم المنتج"].Style.BackColor = Color.Yellow;
                row.Cells["هامش الربح للسعر الاول"].Style.BackColor = Color.Green;
                row.Cells["هامش الربح للسعر الثاني"].Style.BackColor = Color.SpringGreen;
                row.Cells["هامش الربح للسعر الثالث"].Style.BackColor = Color.MediumSpringGreen;

            }
        }

        private void frm_calcule_benifice_Load(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.DataSource = classStatique.select_benifice_state();
            }
            catch
            {

            }

            
        }
    }
}
