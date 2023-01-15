using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.Entities {
    internal class Venda {
        public int ID { get; set; }
        public List<string> Produtos { get; set; }
        public double ValorVenda { get; set; }
        public string DataVenda { get; set; }
        public string MeioPagamento { get; set; }

        public Venda() {
        }
    }
}
