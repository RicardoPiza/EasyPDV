using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Npgsql;
using EasyPDV.Model;
using System.Windows.Forms;

namespace EasyPDV.Utils
{
    internal static class ReportHelper
    {
        private static DataTable dt;
        private static NpgsqlDataAdapter adpt;
        private static FolderBrowserDialog fbd = new FolderBrowserDialog();
        private static IndividualSaleDAO individualSaleDAO;

        public static void MakeReport(List<NpgsqlCommand> cmdList, string fileName, List<string> worksheetList)
        {

            string path = "";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            XLWorkbook wb = new XLWorkbook();
            for (int i =0; i < worksheetList.Count(); i++)
            {
                adpt = new NpgsqlDataAdapter(cmdList[i]);
                dt = new DataTable();
                adpt.Fill(dt);

                var ws = wb.Worksheets.Add(dt, worksheetList[i]);
                if(ws.Name == "Fatura")
                {
                    individualSaleDAO = new IndividualSaleDAO();
                    ws.Cell(ws.RangeUsed().Rows().Count() + 1, 4).Value = "Total: " + individualSaleDAO.ReadTotalIndividualSale();
                    ws.Cell(1, 5).Value = "Total débito: " + individualSaleDAO.ReadSumByPaymentMethod("Cartão débito").ToString("F2");
                    ws.Cell(2, 5).Value = "Total crédito: " + individualSaleDAO.ReadSumByPaymentMethod("Cartão crédito").ToString("F2");
                    ws.Cell(3, 5).Value = "Total dinheiro: " + individualSaleDAO.ReadSumByPaymentMethod("Dinheiro").ToString("F2");
                    ws.Cell(4, 5).Value = "Total Pix: " + individualSaleDAO.ReadSumByPaymentMethod("Pix").ToString("F2");
                    ws.Columns().AdjustToContents();
                    ws.RangeUsed().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                }
                ws.Columns().AdjustToContents();
            }
            if (path != "")
            {
                wb.SaveAs(@path + fileName + ".xlsx");
                MessageBox.Show($"Relatório Salvo em {path}");
                System.Diagnostics.Process.Start(@path + fileName + ".xlsx");
            }
        }
        public static void FinalReport(
            IndividualSaleDAO individualSaleDAO,
            CashierOpenDAO cashierOpenDAO,
            SaleDAO saleDAO,
            CancelledSaleDAO cancelledSaleDAO,
            ReversedSaleDAO saleReversalDAO,
            CashierBleedDAO cashierBleedDAO
            )
        {
            List<NpgsqlCommand> cmdList = new List<NpgsqlCommand>();
            List<string> wsList = new List<string>();
            wsList.Add("Vendas");
            wsList.Add("Vendas Canceladas");
            wsList.Add("Fatura");
            wsList.Add("Troca-Estorno");
            wsList.Add("Sangria-Reforço");
            cmdList.Add(saleDAO.ReadSale());
            cmdList.Add(cancelledSaleDAO.ReadCancelledSale());
            cmdList.Add(individualSaleDAO.ReadIndividualSale());
            cmdList.Add(saleReversalDAO.ReadSaleReversal());
            cmdList.Add(cashierBleedDAO.ReadAll());
            MakeReport(cmdList, "\\Relarório Geral Caixa nº " +
                cashierOpenDAO.ReturnCashierNumber() + " - " + DateTime.Now.ToString("dd-MM-yyyy"), wsList);
        }

    }
}
