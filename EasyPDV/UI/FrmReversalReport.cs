using ClosedXML.Excel;
using EasyPDV.Entities;
using EasyPDV.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPDV.UI
{
    public partial class FrmReversalReport : Form
    {
        NpgsqlDataAdapter _adpt;
        DataTable _dt;
        ReversedSaleDAO reversedSaleDao = new ReversedSaleDAO();
        ReversedSale reversedSale = new ReversedSale();
        CashierOpenDAO cashierOpenDAO = new CashierOpenDAO();
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        public FrmReversalReport()
        {
            InitializeComponent();
        }

        private void FrmReversalReport_Load(object sender, EventArgs e)
        {
            ShowReversals();
            ButtonCursors();
        }
        public void ButtonCursors()
        {
            btnRefresh.Cursor = Cursors.Hand;
            btnDelete.Cursor = Cursors.Hand;
            btnReport.Cursor = Cursors.Hand;
        }
        public void ShowReversals()
        {
            _adpt = new NpgsqlDataAdapter(reversedSaleDao.ReadSaleReversal());
            _dt = new DataTable();
            _adpt.Fill(_dt);
            gridReversal.DataSource = _dt;
            gridReversal.MultiSelect = true;
            for (int i = 0; i <= 4; i++)
            {
                gridReversal.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowReversals();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            MakeReport();
        }
        public void MakeReport()
        {
            string fileName = "\\Relatório Trocas/Estornos - Caixa nº " + cashierOpenDAO.ReturnCashierNumber() + " - " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
            string path = "";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            XLWorkbook wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(_dt, cashierOpenDAO.ReturnEventName());
            ws.Columns().AdjustToContents();
            if (path != "")
            {
                wb.SaveAs(@path + fileName);
                MessageBox.Show($"Relatório Salvo em {path}");
                Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Tem Certeza que deseja cancelar esta venda?", "Cancelar venda", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                foreach (DataGridViewRow row in gridReversal.Rows)
                {
                    if (row.Selected)
                    {
                        reversedSale.ID = int.Parse(row.Cells[0].Value.ToString());
                        reversedSaleDao.DeleteReversedSale(reversedSale);
                    }
                }
                ShowReversals();
            }
        }
    }
}
