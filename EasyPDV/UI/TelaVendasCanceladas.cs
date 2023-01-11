using ClosedXML.Excel;
using EasyPDV.DAO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPDV.UI {
    public partial class TelaVendasCanceladas : Form {
        DataTable dt;
        NpgsqlDataAdapter adpt;
        VendaCanceladaDAO vendaCanceladaDAO = new VendaCanceladaDAO();
        FolderBrowserDialog fbd= new FolderBrowserDialog();
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
    }
}
