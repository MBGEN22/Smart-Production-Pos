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
    public partial class frm_statistique_de_vente : Form
    {
        BL_STATE classStatistique = new BL_STATE();
        public frm_statistique_de_vente()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = classStatistique.SELECT_COUNT_PRODUIT();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // تأكد أن الخلية ليست فارغة لتفادي الأخطاء

                row.Cells["اسم المنتج"].Style.BackColor = Color.Yellow;
                row.Cells["الكمية المباعة"].Style.BackColor = Color.Green;

            }
        }
    }
}
