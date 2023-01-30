using ClosedXML.Excel;
using EasyPDV.Model;
using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace EasyPDV.UI {
    public partial class FrmCashierReport : Form {
        CashierOpenDAO cashierDAO = new CashierOpenDAO();
        NpgsqlDataAdapter _adpt;
        DataTable _dt;
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        public FrmCashierReport() {
            InitializeComponent();
        }

        private void FrmCashierReport_Load(object sender, EventArgs e) {
            LoadCashier();
        }
        private void LoadCashier() {
            _adpt = new NpgsqlDataAdapter(cashierDAO.ReadAll());
            _dt = new DataTable();
            _adpt.Fill(_dt);
            cashierGridView.DataSource = _dt;
            for (int i = 0; i <= 5; i++) {
                cashierGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnReport_Click(object sender, EventArgs e) {
            string fileName = "\\Relatório Abertura de caixa " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
            string path = "";
            if (fbd.ShowDialog() == DialogResult.OK) {
                path = fbd.SelectedPath;
            }
            XLWorkbook wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(_dt, "Aberturas");
            ws.Columns().AdjustToContents();
            if (path != "") {
                wb.SaveAs(@path + fileName);
                MessageBox.Show($"Relatório Salvo em {path}");
                System.Diagnostics.Process.Start(@path + fileName);
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            LoadCashier();
        }

        private void btnRefresh_MouseMove(object sender, MouseEventArgs e) {
            btnRefresh.Cursor = Cursors.Hand;
            btnReport.Cursor = Cursors.Hand;
        }

        private void button1_Click(object sender, EventArgs e) {
            DialogResult dialogResult = new DialogResult();
            dialogResult = MessageBox.Show("Certifique-se de ter um relatório antes de apagar essas informações",
                "Apagar informações", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK) {
                cashierDAO.DeleteAllClosedCashier();
                LoadCashier();
            }
        }
    }
}
