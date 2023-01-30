using System;

namespace EasyPDV.Entities {
    internal class CashierOpen : Cashier{
        public bool Status { get; set; }
        public double InitialBalance { get; set; }
    }
}
