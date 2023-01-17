using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using EasyPDV.DAO;
using Npgsql;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EasyPDV.UI {
    public partial class TelaFatura : Form {
        NpgsqlDataAdapter adpt;
        VendaIndividualDAO vendaIndividualDAO = new VendaIndividualDAO();
        DataTable dt;
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        ToolTip toolTip = new ToolTip();
        public TelaFatura() {
            InitializeComponent();
        }

        private void TelaFatura_Load(object sender, EventArgs e) {
            TelaApp telaApp= new TelaApp();
            lblFatura.Text = telaApp.TotalCaixa.ToString();
            CarregaVendas();
            MostraTotal();
        }
        public void CarregaVendas() { 
            adpt = new NpgsqlDataAdapter(vendaIndividualDAO.ReadVendasIndividuais());
            dt = new DataTable();
            adpt.Fill(dt);
            vendasGridView1.DataSource= dt;
            for (int i = 0; i <= 2; i++) {
                vendasGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        public void MostraTotal() {
            lblTotalFatura.Text = vendaIndividualDAO.ReadTotalVendasIndividuais().ToString();    
        }

        private void btnRelatorio_Click(object sender, EventArgs e) {
            try {
                string path = "";
                if (fbd.ShowDialog() == DialogResult.OK) {
                    path = fbd.SelectedPath;
                }
                XLWorkbook wb = new XLWorkbook();
                var ws = wb.Worksheets.Add(dt, "Relatório fatura");
                ws.Cell(ws.RangeUsed().Rows().Count() + 1, 3).Value = "Total: " + vendaIndividualDAO.ReadTotalVendasIndividuais();
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
            CarregaVendas();
            MostraTotal();
        }

        private void button1_Click(object sender, EventArgs e) {
            vendaIndividualDAO.Delete();
            CarregaVendas();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e) {
            button1.Cursor= Cursors.Hand;
            btnRefresh.Cursor = Cursors.Hand;
            btnRelatorio.Cursor = Cursors.Hand;
            toolTip.SetToolTip(button1, "Limpar as ocorrências de fatura");
            toolTip.SetToolTip(btnRefresh, "Atualizar tabela");
            toolTip.SetToolTip(btnRelatorio, "Gerar relatório");
        }
    }
}
