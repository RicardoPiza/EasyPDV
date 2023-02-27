using ClosedXML.Excel;
using EasyPDV.Model;
using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace EasyPDV.UI
{
    public partial class FrmCashierBleedReport : Form
    {
        NpgsqlDataAdapter adpt;
        DataTable dt;
        CashierBleedDAO cashierBleedDAO = new CashierBleedDAO();
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        public FrmCashierBleedReport()
        {
            InitializeComponent();
        }

        private void FrmCashierBleedReport_Load(object sender, EventArgs e)
        {
            LoadBleedCashier();
        }
        public void LoadBleedCashier()
        {
            adpt = new NpgsqlDataAdapter(cashierBleedDAO.ReadAll());
            dt = new DataTable();
            adpt.Fill(dt);
            reportBleedGridView.DataSource = dt;
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            string fileName = "\\Relatório movimentações do caixa " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
            string path = "";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            XLWorkbook wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(dt, "Movimentações");
            ws.Columns().AdjustToContents();
            if (path != "")
            {
                wb.SaveAs(@path + fileName);
                MessageBox.Show($"Relatório Salvo em {path}");
                System.Diagnostics.Process.Start(@path + fileName);
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBleedCashier();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();
            dialogResult = MessageBox.Show("Certifique-se de ter um relatório antes de apagar essas informações",
                "Apagar informações", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                cashierBleedDAO.DeleteAllBleedCashier();
                LoadBleedCashier();
            }
        }
    }
}
