using ClosedXML.Excel;
using EasyPDV.Model;
using EasyPDV.Entities;
using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using ToolTip = System.Windows.Forms.ToolTip;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EasyPDV.UI
{
    public partial class FrmCancelledSale : Form
    {
        DataTable dt;
        NpgsqlDataAdapter adpt;
        CancelledSaleDAO cancelledSaleDAO = new CancelledSaleDAO();
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        CancelledSale cancelledSale = new CancelledSale();
        ToolTip toolTip = new ToolTip();
        CashierOpenDAO cashierOpenDAO = new CashierOpenDAO();
        public FrmCancelledSale()
        {
            InitializeComponent();
        }

        private void salesGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void ListCancelledSales()
        {
            adpt = new NpgsqlDataAdapter(cancelledSaleDAO.ReadCancelledSale());
            dt = new DataTable();
            adpt.Fill(dt);
            vendasGridView1.DataSource = dt;
            vendasGridView1.MultiSelect = true;
            for (int i = 0; i <= 5; i++)
            {
                vendasGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void FrmCancelledSale_Load(object sender, EventArgs e)
        {
            ListCancelledSales();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            MakeReport();
        }
        public void MakeReport()
        {
            string fileName = "\\Relatório Vendas Canceladas - Caixa nº " + cashierOpenDAO.ReturnCashierNumber() + " - " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
            string path = "";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            XLWorkbook wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(dt, cashierOpenDAO.ReturnEventName());
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
            ListCancelledSales();
        }

        private void btnRefresh_MouseMove(object sender, MouseEventArgs e)
        {
            btnRefresh.Cursor = Cursors.Hand;
            btnRelatorio.Cursor = Cursors.Hand;
            toolTip.SetToolTip(btnRelatorio, "Gerar relatório");
            toolTip.SetToolTip(btnRefresh, "Atualizar vendas");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSaleCancel_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Tem Certeza que deseja remover esta venda?\n" +
                "É uma venda cancelada e seus dados serão totalmente perdidos!", "Cancelar venda", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (res == DialogResult.OK)
            {
                foreach (DataGridViewRow row in vendasGridView1.Rows)
                {
                    if (row.Selected)
                    {
                        cancelledSale.ID = int.Parse(row.Cells[0].Value.ToString());
                        cancelledSaleDAO.DeleteCancelledSale(cancelledSale);
                    }
                }
                ListCancelledSales();
            }
        }
    }
}
