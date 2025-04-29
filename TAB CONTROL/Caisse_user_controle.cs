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
	public partial class Caisse_user_controle : UserControl
	{
		public event EventHandler onSelect = null;

		public Caisse_user_controle()
		{
			InitializeComponent();
		}
		public string PCodeBarre { get; set; }
        public int PIDFAV { get; set; }
        public string PFavoire { get; set; }
        public float QT_rest { get; set; }
        public float QT_Alert { get; set; }
        public string PPriceAchat { get; set; }
		public decimal PPriceTTC 
		{
			get { return decimal.Parse(lb_price.Text);}
			set { lb_price.Text = value.ToString() ; }
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

		private string _ptype;
		public string Ptype
		{
			get { return _ptype; }
			set
			{
				_ptype = value;
				UpdatePanelColor();
			}
		}
		private void UpdatePanelColor()
		{
			if (panel1 != null)
			{
				switch (_ptype)
				{
					case "U":
						panel1.BackColor = Color.Red;
						panel2.BackColor = Color.Red;

						break;
					case "P":
						panel1.BackColor = Color.Green;
						panel2.BackColor = Color.Green;

						break; 
				}
			}
		}
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			onSelect?.Invoke(this,e);
		}
	}
}
