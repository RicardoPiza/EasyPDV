
using System;

namespace EasyPDV.Entities
{
    internal abstract class Sale
    {
        public int ID { get; set; }
        public double SalePrice { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.MaxValue;
        public string PaymentMethod { get; set; }
    }
}
