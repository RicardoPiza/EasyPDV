using EasyPDV.DAO;
using EasyPDV.Entities;
using Npgsql;
using System;
using ClosedXML.Excel;
using System.Data;
using System.Windows.Forms;

namespace EasyPDV.UI {
    public partial class TelaVendas : Form {
        NpgsqlDataAdapter adpt;
        DataTable dt;
        VendaDAO vendaDAO = new VendaDAO();
        Venda venda = new Venda();
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        ToolTip toolTip= new ToolTip();
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
            for (int i = 0; i <= 4; i++) {
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
            string path = "";
            if (fbd.ShowDialog() == DialogResult.OK) {
                path = fbd.SelectedPath;
            }
            XLWorkbook wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(dt, "Vendas");
            ws.Columns().AdjustToContents();
            if (path != "") {
                wb.SaveAs(@path + "\\Relatório Vendas Realizadas " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx");
                MessageBox.Show($"Relatório Salvo em {path}");
                this.Close();
            }
            System.Diagnostics.Process.Start(@path + "\\Relatório Vendas Realizadas " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx");
        }

        private void btnCancelarVenda_MouseMove(object sender, MouseEventArgs e) {
            btnCancelarVenda.Cursor = Cursors.Hand;
            btnRelatorio.Cursor = Cursors.Hand;
        }
        private void btnRefresh_Click(object sender, EventArgs e) {
            ListarVendas();
        }

        private void btnRefresh_MouseMove(object sender, MouseEventArgs e) {
            btnRefresh.Cursor = Cursors.Hand;
            toolTip.SetToolTip(btnRelatorio, "Gerar relatório");
            toolTip.SetToolTip(btnRefresh, "Atualizar vendas");
        }

        private void vendasGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }
    }
}
