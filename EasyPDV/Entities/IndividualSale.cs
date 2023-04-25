

namespace EasyPDV.Entities
{
    internal class IndividualSale : Sale
    {
        public string Product { get; set; }
        public int ExternalSaleID { get; set; }
        public IndividualSale()
        {

        }
    }
}
