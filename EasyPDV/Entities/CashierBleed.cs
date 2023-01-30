using System;

namespace EasyPDV.Entities {
    internal class CashierBleed : Cashier{
        public string Type { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
    }
}
