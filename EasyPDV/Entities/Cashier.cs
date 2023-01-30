using System;

namespace EasyPDV.Entities {
    internal abstract class Cashier {
        public int ID { get; set; }
        public string EventName { get; set; }
        public int Number { get; set; }
        public string Responsible { get; set; }
        public DateTime Date { get; set; }
    }
}
