using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using EasyPDV.DAO;
using EasyPDV.Entities;
using Npgsql;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EasyPDV.UI {
    public partial class FrmIncome : Form {
        NpgsqlDataAdapter adpt;
        IndividualSaleDAO individualSaleDAO = new IndividualSaleDAO();
        DataTable dt;
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        ToolTip toolTip = new ToolTip();
        public FrmIncome() {
            InitializeComponent();
        }

        private void FrmIncome_Load(object sender, EventArgs e) {
            TotalText();
            LoadSales();
            ShowTotal();
            Invalidate();
            SetChart();
        }

        private void TotalText() {
            FrmApp telaApp = new FrmApp();
            lblFatura.Text = telaApp._CashierTotal.ToString();
        }

        public void LoadSales() {
            adpt = new NpgsqlDataAdapter(individualSaleDAO.ReadIndividualSale());
            dt = new DataTable();
            adpt.Fill(dt);
            vendasGridView1.DataSource = dt;
            for (int i = 0; i <= 2; i++) {
                vendasGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        public void ShowTotal() {
            lblTotalFatura.Text = individualSaleDAO.ReadTotalIndividualSale().ToString();
        }

        private void btnReport_Click(object sender, EventArgs e) {
            try {
                string fileName = "\\Relatório fatura " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
                string path = "";
                if (fbd.ShowDialog() == DialogResult.OK) {
                    path = fbd.SelectedPath;
                }
                XLWorkbook wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(dt, "Relatório fatura");
                ws.Cell(ws.RangeUsed().Rows().Count() + 1, 3).Value = "Total: " + individualSaleDAO.ReadTotalIndividualSale();
                ws.Columns().AdjustToContents();
                ws.RangeUsed().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                if (path != "") {
                    wb.SaveAs(@path + "\\Relatório fatura " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx");
                    MessageBox.Show($"Relatório Salvo em {path}");
                    this.Close();
                    System.Diagnostics.Process.Start(@path + fileName);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            LoadSales();
            ShowTotal();
            Invalidate();
            ClearChart();
            SetChart();
        }

        private void button1_Click(object sender, EventArgs e) {
            individualSaleDAO.DeleteAllIndividualSales();
            LoadSales();
            Invalidate();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e) {
            button1.Cursor = Cursors.Hand;
            btnRefresh.Cursor = Cursors.Hand;
            btnRelatorio.Cursor = Cursors.Hand;
            toolTip.SetToolTip(button1, "Limpar as ocorrências de fatura");
            toolTip.SetToolTip(btnRefresh, "Atualizar tabela");
            toolTip.SetToolTip(btnRelatorio, "Gerar relatório");
        }
        public void SetChart() {
            IndividualSale IndividualSale = new IndividualSale();
            string x;
            double y = 0;
                for (int i = 0; i < vendasGridView1.Rows.Count; i++) {
                    x = vendasGridView1.Rows[i].Cells[0].Value.ToString();
                    y = double.Parse(vendasGridView1.Rows[i].Cells[1].Value.ToString());
                    chart1.Series[0].Points.AddXY(x, y);
                    chart1.Series[0].AxisLabel = x;
                }
        }
        private void ClearChart() {
            foreach (var series in chart1.Series) {
                series.Points.Clear();
            }
        }

        private void chart1_Click(object sender, EventArgs e) {

        }
    }
}
