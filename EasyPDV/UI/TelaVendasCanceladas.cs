using ClosedXML.Excel;
using EasyPDV.DAO;
using EasyPDV.Entities;
using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace EasyPDV.UI {
    public partial class TelaVendasCanceladas : Form {
        DataTable dt;
        NpgsqlDataAdapter adpt;
        VendaCanceladaDAO vendaCanceladaDAO = new VendaCanceladaDAO();
        FolderBrowserDialog fbd= new FolderBrowserDialog();
        VendaCancelada vendaCancelada = new VendaCancelada();
        public TelaVendasCanceladas() {
            InitializeComponent();
        }

        private void vendasGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }
        public void ListarCanceladas() {
            adpt = new NpgsqlDataAdapter(vendaCanceladaDAO.ReadVendaCancelada());
            dt = new DataTable();
            adpt.Fill(dt);
            vendasGridView1.DataSource = dt;
            for (int i = 0; i <= 4; i++) {
                vendasGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void TelaVendasCanceladas_Load(object sender, EventArgs e) {
            ListarCanceladas();
        }

        private void btnRelatorio_Click(object sender, EventArgs e) {
            string path = "";
            if (fbd.ShowDialog() == DialogResult.OK) {
                path = fbd.SelectedPath;
            }
            XLWorkbook wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(dt, "Vendas Canceladas");
            ws.Columns().AdjustToContents();
            if (path != "") {
                wb.SaveAs(@path + "\\Relatório Vendas Canceladas " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx");
                MessageBox.Show($"Relatório Salvo em {path}");
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            ListarCanceladas();
        }

        private void btnRefresh_MouseMove(object sender, MouseEventArgs e) {
            btnRefresh.Cursor = Cursors.Hand;
            btnRelatorio.Cursor = Cursors.Hand;
        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void btnCancelarVenda_Click(object sender, EventArgs e) {
            DialogResult res = MessageBox.Show("Tem Certeza que deseja remover esta venda?\n" +
                "É uma venda cancelada e seus dados serão totalmente perdidos!", "Cancelar venda", MessageBoxButtons.OKCancel,MessageBoxIcon.Stop);
            if (res == DialogResult.OK) {
                vendaCancelada.ID = int.Parse(vendasGridView1.SelectedCells[0].Value.ToString());
                vendaCanceladaDAO.DeleteVendaCancelada(vendaCancelada);
                ListarCanceladas();
            }
        }
    }
}
