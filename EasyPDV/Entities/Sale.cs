

namespace EasyPDV.Entities {
    internal abstract class Sale {
        public int ID { get; set; }
        public double SalePrice { get; set; }
        public string SaleDate { get; set; }
        public string PaymentMethod { get; set; }
    }
}
