using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.PL
{
    public partial class frm_notify : Form
    {
        BL.BL_NOTOFY classNotify = new BL.BL_NOTOFY();
        public frm_notify()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = classNotify.GET_NOTIFY();
        }
    }
}
