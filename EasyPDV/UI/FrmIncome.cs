using ClosedXML.Excel;
using EasyPDV.Model;
using EasyPDV.Entities;
using Npgsql;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EasyPDV.UI
{
    public partial class FrmIncome : Form
    {
        NpgsqlDataAdapter adpt;
        IndividualSaleDAO individualSaleDAO = new IndividualSaleDAO();
        DataTable dt;
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        ToolTip toolTip = new ToolTip();
        CashierOpenDAO cashierOpenDAO = new CashierOpenDAO();
        public FrmIncome()
        {
            InitializeComponent();
        }

        private void FrmIncome_Load(object sender, EventArgs e)
        {
            LoadSales();
            ShowTotal();
            Invalidate();
            SetChart();
        }
        public void LoadSales()
        {
            adpt = new NpgsqlDataAdapter(individualSaleDAO.ReadIndividualSale());
            dt = new DataTable();
            adpt.Fill(dt);
            salesGridView1.DataSource = dt;
            for (int i = 0; i <= 2; i++)
            {
                salesGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        public void ShowTotal()
        {
            lblTotalFatura.Text = individualSaleDAO.ReadTotalIndividualSale().ToString("F2");
            lblTotalDebito.Text = "R$" + individualSaleDAO.ReadSumByPaymentMethod("Cartão débito").ToString("F2");
            lblTotalCredito.Text = "R$"+ individualSaleDAO.ReadSumByPaymentMethod("Cartão crédito").ToString("F2");
            lblTotalDinheiro.Text = "R$" + individualSaleDAO.ReadSumByPaymentMethod("Dinheiro").ToString("F2");
            lblTotalPix.Text = "R$" + individualSaleDAO.ReadSumByPaymentMethod("Pix").ToString("F2");
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            MakeReport();
        }

        public void MakeReport()
        {
            try
            {
                string fileName = "\\Relatório fatura - Caixa nº " + cashierOpenDAO.ReturnCashierNumber() + " - " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
                string path = "";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    path = fbd.SelectedPath;
                }
                XLWorkbook wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(dt, cashierOpenDAO.ReturnEventName());
                ws.Cell(ws.RangeUsed().Rows().Count() + 1, 4).Value = "Total: " + individualSaleDAO.ReadTotalIndividualSale();
                ws.Cell(1, 5).Value = "Total débito: " + individualSaleDAO.ReadSumByPaymentMethod("Cartão débito").ToString("F2");
                ws.Cell(2, 5).Value = "Total crédito: " + individualSaleDAO.ReadSumByPaymentMethod("Cartão crédito").ToString("F2");
                ws.Cell(3, 5).Value = "Total dinheiro: " + individualSaleDAO.ReadSumByPaymentMethod("Dinheiro").ToString("F2");
                ws.Cell(4, 5).Value = "Total Pix: " + individualSaleDAO.ReadSumByPaymentMethod("Pix").ToString("F2");
                ws.Columns().AdjustToContents();
                ws.RangeUsed().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                if (path != "")
                {
                    wb.SaveAs(path + fileName);
                    MessageBox.Show($"Relatório Salvo em {path}");
                    this.Close();
                    System.Diagnostics.Process.Start(@path + fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSales();
            ShowTotal();
            Invalidate();
            ClearChart();
            SetChart();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            btnRefresh.Cursor = Cursors.Hand;
            btnRelatorio.Cursor = Cursors.Hand;
            toolTip.SetToolTip(btnRefresh, "Atualizar tabela");
            toolTip.SetToolTip(btnRelatorio, "Gerar relatório");
        }
        public void SetChart()
        {
            IndividualSale IndividualSale = new IndividualSale();
            string x;
            double y = 0;
            for (int i = 0; i < salesGridView1.Rows.Count; i++)
            {
                x = salesGridView1.Rows[i].Cells[0].Value.ToString();
                y = double.Parse(salesGridView1.Rows[i].Cells[1].Value.ToString());
                chart1.Series[0].Points.AddXY(x, y);
                chart1.Series[0].AxisLabel = x;
            }
        }
        private void ClearChart()
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            LoadSales();
            ShowTotal();
            Invalidate();
            ClearChart();
            SetChart();
        }
    }
}
