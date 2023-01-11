using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.Entities {
    internal class Produto {
        public int ID { get; set; }
        public double Preco { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

        public Produto() { 
        }
    }
}
