using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.Entities {
    internal class Product {
        public int ID { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int StockQuantity { get; set; }

        public Product() { 
        }
    }
}
