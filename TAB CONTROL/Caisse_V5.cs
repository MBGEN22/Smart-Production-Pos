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
    public partial class Caisse_V5 : UserControl
    {
        public event EventHandler onSelect = null;

        public Caisse_V5()
        {
            InitializeComponent();
            //UpdatePanelColor();
        }
        public string PCodeBarre { get; set; }
        public int PIDFAV { get; set; }
        public string PFavoire { get; set; }
        public string PPriceAchat { get; set; }
        public decimal PPriceTTC
        {
            get { return decimal.Parse(lb_price.Text); }
            set { lb_price.Text = value.ToString(); }
        }
        public string PName
        {
            get { return lb_name.Text; }
            set { lb_name.Text = value; }
        }
        public Image PImage
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        private float _qtRest;
        private float _qtAlert;
        public float QT_rest
        {

            get { return _qtRest; }
            set
            {
                _qtRest = value;
                UpdatePanelColor(); // استدعاء الدالة بعد تغيير QT_rest
            }
        }
        public float QT_Alert 
        {

            get { return _qtAlert; }
            set
            {
                _qtAlert = value;
                UpdatePanelColor(); // استدعاء الدالة بعد تغيير QT_Alert
            }
        }

        private string _ptype;
        public string Ptype
        {
            get { return _ptype; }
            set
            {
                _ptype = value;
                //UpdatePanelColor();
            }
        }
        private void UpdatePanelColor()
        {  
            if (QT_rest <= QT_Alert)
            {
                panel3.Visible = true;
                ALERT.Text = QT_Alert.ToString();
                REST.Text = QT_rest.ToString();
            }
            else
            {
                panel3.Visible = false;
                ALERT.Text = QT_Alert.ToString();
                REST.Text = QT_rest.ToString();
            }   
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void kryptonButton24_Click(object sender, EventArgs e)
        { 
            onSelect?.Invoke(this, e);
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }

        private void lb_name_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }
    }
}
