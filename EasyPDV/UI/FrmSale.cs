using EasyPDV.DAO;
using EasyPDV.Entities;
using Npgsql;
using System;
using ClosedXML.Excel;
using System.Data;
using System.Windows.Forms;

namespace EasyPDV.UI {
    public partial class FrmSale : Form {
        NpgsqlDataAdapter _adpt;
        DataTable _dt;
        SaleDAO saleDAO = new SaleDAO();
        RegularSale sale = new RegularSale();
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        ToolTip toolTip= new ToolTip();
        public FrmSale() {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void FrmSale_Load(object sender, EventArgs e) {
            ShowSales();
        }
        public void ShowSales() { 
            _adpt = new NpgsqlDataAdapter(saleDAO.ReadSale());
            _dt = new DataTable();
            _adpt.Fill(_dt);
            salesGridView1.DataSource= _dt;
            for (int i = 0; i <= 4; i++) {
                salesGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnDeleteSale_Click(object sender, EventArgs e) {
            DialogResult res = MessageBox.Show("Tem Certeza que deseja cancelar esta venda?", "Cancelar venda", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK) {
                sale.ID = int.Parse(salesGridView1.SelectedCells[0].Value.ToString());
                saleDAO.DeleteVenda(sale);
                ShowSales();
            }
        }

        private void btnReport_Click(object sender, EventArgs e) {
            string fileName = "\\Relatório Vendas Realizadas " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
            string path = "";
            if (fbd.ShowDialog() == DialogResult.OK) {
                path = fbd.SelectedPath;
            }
            XLWorkbook wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(_dt, "Vendas");
            ws.Columns().AdjustToContents();
            if (path != "") {
                wb.SaveAs(@path + fileName);
                MessageBox.Show($"Relatório Salvo em {path}");
                System.Diagnostics.Process.Start(@path + fileName);
                this.Close();
            }
        }

        private void btnCancelarVenda_MouseMove(object sender, MouseEventArgs e) {
            btnDeleteVenda.Cursor = Cursors.Hand;
            btnReport.Cursor = Cursors.Hand;
        }
        private void btnRefresh_Click(object sender, EventArgs e) {
            ShowSales();
        }

        private void btnRefresh_MouseMove(object sender, MouseEventArgs e) {
            btnRefresh.Cursor = Cursors.Hand;
            toolTip.SetToolTip(btnReport, "Gerar relatório");
            toolTip.SetToolTip(btnRefresh, "Atualizar vendas");
        }

        private void vendasGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }
    }
}
