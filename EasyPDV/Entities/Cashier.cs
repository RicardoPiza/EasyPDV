

using System;

namespace EasyPDV.Entities {
    internal class Cashier {
        public int ID { get; set; }
        public string EventName { get; set; }
        public int Number { get; set; }
        public bool Status { get; set; }
        public double InitialBalance { get; set; }
        public string Responsible { get; set; }
        public DateTime Date { get; set; }
    }
}
