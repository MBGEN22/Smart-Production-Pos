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
    public partial class favCaisseV5 : UserControl
    {
        public event EventHandler onSelect = null;

        public favCaisseV5()
        {
            InitializeComponent();
        }
        public string PName
        {
            get { return LB_Name.Text; }
            set { LB_Name.Text = value; }
        }
        public int PID { get; set; }
        public void SetLabelBackColor(Color color)
        {
            LB_Name.BackColor = color;
        }
        private void LB_Name_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void LB_Name_Click_1(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void LB_Name_Click_2(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }
    }
}
