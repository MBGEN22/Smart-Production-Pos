using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Production_Pos
{
    public class product
    {
    public string CodeBarre { get; set; }
    public string Designation { get; set; }
    public string Reference { get; set; }
    public int? IdCategories { get; set; }
    public int? IdStocke { get; set; }
    public int? IdMarque { get; set; }
    public int? IdUnite { get; set; }
    public int? IdTaille { get; set; }
    public int? IdColor { get; set; }
    public int? IdFavoire { get; set; }
    public string DateExpiration { get; set; }
    public string PriceAchatHT { get; set; }
    public string PriceAchatTTC { get; set; }
    public string TVA { get; set; }
    public string QuantiteTotal { get; set; }
    public string PriceVente1 { get; set; }
    public string PriceVente2 { get; set; }
    public string PriceMin { get; set; }
    public string VenteApresExpiration { get; set; }
    public string StockeNegatif { get; set; }
    public string QuantiteVente { get; set; }
    public string QuantiteRest { get; set; }
    public string QuantiteDechet { get; set; }
        //public string Photo { get; set; }
        public int? QTDansPack { get; set; }
        public int QuantiteAlert { get; set; }
    public string Ihtiyaj { get; set; }
    }
}
