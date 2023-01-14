using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPDV.UI {
    public partial class TelaFatura : Form {
        public TelaFatura() {
            InitializeComponent();
        }

        private void TelaFatura_Load(object sender, EventArgs e) {
            TelaApp telaApp= new TelaApp();
            lblFatura.Text = telaApp.TotalCaixa.ToString();
        }
    }
}
