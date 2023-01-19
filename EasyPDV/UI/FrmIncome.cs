using ClosedXML.Excel;
using EasyPDV.DAO;
using Npgsql;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EasyPDV.UI {
    public partial class FrmIncome : Form {
        NpgsqlDataAdapter adpt;
        IndividualSaleDAO individualSale = new IndividualSaleDAO();
        DataTable dt;
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        ToolTip toolTip = new ToolTip();
        public FrmIncome() {
            InitializeComponent();
        }

        private void FrmIncome_Load(object sender, EventArgs e) {
            FrmApp telaApp= new FrmApp();
            lblFatura.Text = telaApp._CashierTotal.ToString();
            LoadSales();
            ShowTotal();
            Invalidate();
        }
        public void LoadSales() { 
            adpt = new NpgsqlDataAdapter(individualSale.ReadIndividualSale());
            dt = new DataTable();
            adpt.Fill(dt);
            vendasGridView1.DataSource= dt;
            for (int i = 0; i <= 2; i++) {
                vendasGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        public void ShowTotal() {
            lblTotalFatura.Text = individualSale.ReadTotalIndividualSale().ToString();    
        }

        private void btnReport_Click(object sender, EventArgs e) {
            try {
                string path = "";
                if (fbd.ShowDialog() == DialogResult.OK) {
                    path = fbd.SelectedPath;
                }
                XLWorkbook wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(dt, "Relatório fatura");
                ws.Cell(ws.RangeUsed().Rows().Count() + 1, 3).Value = "Total: " + individualSale.ReadTotalIndividualSale();
                ws.Columns().AdjustToContents();
                ws.RangeUsed().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                if (path != "") {
                    wb.SaveAs(@path + "\\Relatório fatura " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx");
                    MessageBox.Show($"Relatório Salvo em {path}");
                    this.Close();
                    System.Diagnostics.Process.Start(@path + "\\Relatório fatura " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx");
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
        }

        private void button1_Click(object sender, EventArgs e) {
            individualSale.DeleteAllIndividualSales();
            LoadSales();
            Invalidate();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e) {
            button1.Cursor= Cursors.Hand;
            btnRefresh.Cursor = Cursors.Hand;
            btnRelatorio.Cursor = Cursors.Hand;
            toolTip.SetToolTip(button1, "Limpar as ocorrências de fatura");
            toolTip.SetToolTip(btnRefresh, "Atualizar tabela");
            toolTip.SetToolTip(btnRelatorio, "Gerar relatório");
        }

        private void label1_Click(object sender, EventArgs e) {

        }
    }
}
