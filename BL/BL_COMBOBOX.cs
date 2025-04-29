using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos.BL
{
	public class BL_COMBOBOX
	{
		public DataTable get_combo_color()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("get_combo_color", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_combo_taille()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("get_combo_taille", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_combo_FAV()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("FILL_COMBO_FAV", null);
			DAL.Close();
			return Dt;
		}
		public DataTable pack_produit_prevent()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("fill_combo_produit_pack_produit_revent", null);
			DAL.Close();
			return Dt;
		}
		public DataTable produit_fabrique()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("fill_combo_produit_fabrique", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_combo_pack_fabrique()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("get_combo_pack_fabrique", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_combo_produit_prevent()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("fill_combo_produit_revent", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_combo_Iunite()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("FILL_COMBO_unite", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_combo_stock()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("FILL_COMBO_stock", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_combo_Marque()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("FILL_COMBO_Marque", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_combo_Categorie()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("FILL_COMBO_CATEGORIES", null);
			DAL.Close();
			return Dt;
		}
		public DataTable getfrnsr()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("get_combo_frnse", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_product()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("get_combo_matier_premier", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_combo_client()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("get_combo_client", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_Combo_caisse()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("get_Combo_caisse", null);
			DAL.Close();
			return Dt;
		}
		public DataTable get_combo_ouverier()
		{
			DAL.DAL DAL = new DAL.DAL();
			DataTable Dt = new DataTable();
			SqlParameter[] param = new SqlParameter[1];
			Dt = DAL.SelectData("get_combo_ouverier", null);
			DAL.Close();
			return Dt;
		}
	}
}
