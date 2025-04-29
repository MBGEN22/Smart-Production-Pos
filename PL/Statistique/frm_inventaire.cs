using Smart_Production_Pos.PLADD.PL_Statistique;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL.Statistique
{
    public partial class frm_inventaire : Form
    {
        BL.BL_Statistique.bl_inventaire classinv = new BL.BL_Statistique.bl_inventaire();
        public int _id_user;
        public frm_inventaire()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = classinv.GET_PRINCIPE_INVENTAIRE();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            frm_add_inventaire add_invetaire = new frm_add_inventaire();
            add_invetaire.id_user = _id_user;
            add_invetaire.ShowDialog();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable search_data = new DataTable();
            search_data = classinv.search_PRINCIPE_INVENTAIRE(textBox4.Text);
            this.dataGridView1.DataSource = search_data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable search_data = new DataTable();
            search_data = classinv.search_PRINCIPE_INVENTAIRE_by_date(Convert.ToDateTime(dateTimePicker1.Text));
            this.dataGridView1.DataSource = search_data;
        }
    }
}
