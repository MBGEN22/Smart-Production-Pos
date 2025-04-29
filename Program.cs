using Smart_Production_Pos.PL.Achats;
using Smart_Production_Pos.PL.Statistique;
using Smart_Production_Pos.PL.vente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Production_Pos
{
	internal static class Program
    {
        

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new SplachScreen());
			 
        }
	}
}
