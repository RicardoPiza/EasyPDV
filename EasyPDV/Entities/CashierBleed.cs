using System;

namespace EasyPDV.Entities {
    internal class CashierBleed {
        public int ID { get; set; }
        public string EventName { get; set; }
        public string Type { get; set; }
        public string Responsible { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
    }
}
