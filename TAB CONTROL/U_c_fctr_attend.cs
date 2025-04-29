using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos.TAB_CONTROL
{
    public partial class U_c_fctr_attend : UserControl
    {
        public event EventHandler onSelect = null;
        public U_c_fctr_attend()
        {
            InitializeComponent();
        }

        public string nmr_fctr { get; set; }
        public int id_client { get; set; }
        public decimal Price_ttl
        {
            get { return decimal.Parse(lb_Price_ttl.Text); }
            set { lb_Price_ttl.Text = value.ToString(); }
        }

        private void lb_Price_ttl_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }
    }
}
