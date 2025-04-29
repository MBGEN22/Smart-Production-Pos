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
	public partial class tab_DB_SAVE : UserControl
	{
		public tab_DB_SAVE()
		{
			InitializeComponent();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			PL.save_and_backup.frm_save frm_stock = new PL.save_and_backup.frm_save();
			frm_stock.ShowDialog();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			PL.save_and_backup.frm_backup frm_stock = new PL.save_and_backup.frm_backup();
			frm_stock.ShowDialog();
		}
	}
}
