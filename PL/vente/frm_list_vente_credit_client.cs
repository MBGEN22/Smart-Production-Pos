using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.vente
{
    public partial class frm_list_vente_credit_client : Form
    {
        private Dictionary<string, Color> invoiceColors = new Dictionary<string, Color>();
        private Color[] colors = { Color.LightBlue, Color.LightGreen, Color.LightSalmon, Color.LightYellow, Color.LightPink };
        private int colorIndex = 0;
        public frm_list_vente_credit_client()
        {
            InitializeComponent();
        }
        private void ColorizeRowsByInvoiceNumber()
        {
            // Check if the DataGridView has any rows
            if (dataGridView1.Rows.Count == 0)
                return;

            // Create a dictionary to store the unique nmr_bon values and their associated color
            Dictionary<string, Color> invoiceColors = new Dictionary<string, Color>();

            // Define an array of colors to cycle through
            Color[] colors = { Color.LightBlue, Color.LightGreen, Color.LightSalmon, Color.LightYellow, Color.LightPink };
            int colorIndex = 0;

            // Loop through the rows in the DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Make sure the cell is not null or empty
                if (row.Cells["رقم الفاتورة"].Value != null)
                {
                    string nmrBon = row.Cells["رقم الفاتورة"].Value.ToString();

                    // If this nmr_bon doesn't have an assigned color yet, assign one
                    if (!invoiceColors.ContainsKey(nmrBon))
                    {
                        invoiceColors[nmrBon] = colors[colorIndex % colors.Length];
                        colorIndex++;
                    }

                    // Apply the color to the entire row
                    row.DefaultCellStyle.BackColor = invoiceColors[nmrBon];
                }
            }
        }

        private void frm_list_vente_credit_client_Load(object sender, EventArgs e)
        {
            ColorizeRowsByInvoiceNumber();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            // Make sure the cell is not null or empty
            if (row.Cells["رقم الفاتورة"].Value != null)
            {
                string nmrBon = row.Cells["رقم الفاتورة"].Value.ToString();

                // If this nmr_bon doesn't have an assigned color yet, assign one
                if (!invoiceColors.ContainsKey(nmrBon))
                {
                    invoiceColors[nmrBon] = colors[colorIndex % colors.Length];
                    colorIndex++;
                }

                // Apply the color to the entire row
                row.DefaultCellStyle.BackColor = invoiceColors[nmrBon];
            }
        }
    }
}
