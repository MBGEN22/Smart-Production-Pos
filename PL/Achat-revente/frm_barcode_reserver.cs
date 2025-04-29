using Microsoft.Office.Interop.Excel;
using Smart_Production_Pos.BL.BL_ACHAT_REVENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace Smart_Production_Pos.PL.Achat_revente
{
    public partial class frm_barcode_reserver : Form
    {
        private Dictionary<string, Color> invoiceColors = new Dictionary<string, Color>();
        private Color[] colors = { Color.LightBlue, Color.LightGreen, Color.LightSalmon, Color.LightYellow, Color.LightPink };
        private int colorIndex = 0;
        BL_CLASS_BARCODE_RESERVER classReserver = new BL_CLASS_BARCODE_RESERVER(); 
        public frm_barcode_reserver()
        {
            InitializeComponent();
            dataU.DataSource = classReserver.get_reserve_code_all();
            dataP.DataSource = classReserver.get_reserve_code_all_pack();
        }
        private void ColorizeRowsByInvoiceNumberU()
        {
            // Check if the DataGridView has any rows
            if (dataU.Rows.Count == 0)
                return;

            // Create a dictionary to store the unique nmr_bon values and their associated color
            Dictionary<string, Color> invoiceColors = new Dictionary<string, Color>();

            // Define an array of colors to cycle through
            Color[] colors = { Color.LightBlue, Color.LightGreen, Color.LightSalmon, Color.LightYellow, Color.LightPink };
            int colorIndex = 0;

            // Loop through the rows in the DataGridView
            foreach (DataGridViewRow row in dataU.Rows)
            {
                // Make sure the cell is not null or empty
                if (row.Cells["الباركود الاساسي"].Value != null)
                {
                    string nmrBon = row.Cells["الباركود الاساسي"].Value.ToString();

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

        private void dataU_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow row = dataU.Rows[e.RowIndex];

            // Make sure the cell is not null or empty
            if (row.Cells["الباركود الاساسي"].Value != null)
            {
                string nmrBon = row.Cells["الباركود الاساسي"].Value.ToString();

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

        private void frm_barcode_reserver_Load(object sender, EventArgs e)
        {
            ColorizeRowsByInvoiceNumberU();
        }

        private void dataP_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow row = dataP.Rows[e.RowIndex];

            // Make sure the cell is not null or empty
            if (row.Cells["الباركود الاساسي"].Value != null)
            {
                string nmrBon = row.Cells["الباركود الاساسي"].Value.ToString();

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                dataU.DataSource = classReserver.get_reserve_code_all();
                dataP.DataSource = classReserver.get_reserve_code_all_pack();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DataTable dt_u = new DataTable();
                dt_u = classReserver.search_get_reserve_code_all(textBox1.Text);
                DataTable dt_p = new DataTable();
                dt_p = classReserver.search_get_reserve_code_all_pack(textBox1.Text);
                dataU.DataSource = dt_u;
                dataP.DataSource = dt_p;
                if(textBox1.Text == "")
                { 
                    dataU.DataSource = classReserver.get_reserve_code_all();
                    dataP.DataSource = classReserver.get_reserve_code_all_pack();
                }
                //if (dt_u.Rows.Count == 0 && dt_p.Rows.Count == 0 && textBox1.Text!="")
                //{
                //    frm_barcodeempty barccodeemty = new frm_barcodeempty();
                //    barccodeemty.Show();
                //}  

            }
        }
    }
}
