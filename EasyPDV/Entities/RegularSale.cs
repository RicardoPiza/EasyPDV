using System.Collections.Generic;

namespace EasyPDV.Entities {
    internal class RegularSale : Sale{
        public List<string> Products { get; set; }

        public RegularSale() {
        }
    }
}
