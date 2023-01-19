using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.Entities {
    internal class Sale {
        public int ID { get; set; }
        public List<string> Products { get; set; }
        public double SalePrice { get; set; }
        public string SaleDate { get; set; }
        public string PaymentMethod { get; set; }

        public Sale() {
        }
        public Sale(int iD, List<string> products, double salePrice, string saleDate, string paymentMethod) {
            ID = iD;
            Products = products;
            SalePrice = salePrice;
            SaleDate = saleDate;
            PaymentMethod = paymentMethod;
        }
    }
}
