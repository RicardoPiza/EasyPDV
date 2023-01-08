using EasyPDV.DAO;
using EasyPDV.Entities;
using Npgsql;
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
    public partial class TelaVendas : Form {
        NpgsqlDataAdapter adpt;
        DataTable dt;
        VendaDAO vendaDAO = new VendaDAO();
        Venda venda = new Venda();
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        public TelaVendas() {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void TelaVendas_Load(object sender, EventArgs e) {
            ListarVendas();
        }
        public void ListarVendas() { 
            adpt = new NpgsqlDataAdapter(vendaDAO.ReadVenda());
            dt = new DataTable();
            adpt.Fill(dt);
            vendasGridView1.DataSource= dt;
            for (int i = 0; i < 3; i++) {
                vendasGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e) {
            DialogResult res = MessageBox.Show("Tem Certeza que deseja cancelar esta venda?", "Cancelar venda", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK) {
                venda.ID = int.Parse(vendasGridView1.SelectedCells[0].Value.ToString());
                vendaDAO.DeleteVenda(venda);
                ListarVendas();
            }
        }

        private void btnRelatorio_Click(object sender, EventArgs e) {
            
            //string path = "";
            //if (fbd.ShowDialog() == DialogResult.OK) {
            //    path = fbd.SelectedPath;
            //}
            //XLWorkbook wb = new XLWorkbook();
            //var ws = wb.Worksheets.Add(dt, "NFS-e");
            //ws.Columns().AdjustToContents();
            //if (path != "") {
            //    wb.SaveAs(@path + "\\Relatório Confronto NFS-e " + DateTime.Now.ToString("MM-yyyy") + ".xlsx");
            //    MessageBox.Show("Relatório Salvo");
            //    this.Close();
            //}
        }

        private void btnCancelarVenda_MouseMove(object sender, MouseEventArgs e) {
            btnCancelarVenda.Cursor = Cursors.Hand;
        }
    }
}
