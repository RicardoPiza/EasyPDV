﻿using ClosedXML.Excel;
using EasyPDV.DAO;
using EasyPDV.Entities;
using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using ToolTip = System.Windows.Forms.ToolTip;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EasyPDV.UI {
    public partial class FrmCancelledSale : Form {
        DataTable dt;
        NpgsqlDataAdapter adpt;
        CancelledSaleDAO cancelledSaleDAO = new CancelledSaleDAO();
        FolderBrowserDialog fbd= new FolderBrowserDialog();
        CancelledSale cancelledSale = new CancelledSale();
        ToolTip toolTip = new ToolTip();
        public FrmCancelledSale() {
            InitializeComponent();
        }

        private void salesGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }
        public void ListCancelledSales() {
            adpt = new NpgsqlDataAdapter(cancelledSaleDAO.ReadCancelledSale());
            dt = new DataTable();
            adpt.Fill(dt);
            vendasGridView1.DataSource = dt;
            for (int i = 0; i <= 4; i++) {
                vendasGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void FrmCancelledSale_Load(object sender, EventArgs e) {
            ListCancelledSales();
        }

        private void btnReport_Click(object sender, EventArgs e) {
            string fileName = "\\Relatório Vendas Canceladas " + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";
            string path = "";
            if (fbd.ShowDialog() == DialogResult.OK) {
                path = fbd.SelectedPath;
            }
            XLWorkbook wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(dt, "Vendas Canceladas");
            ws.Columns().AdjustToContents();
            if (path != "") {
                wb.SaveAs(@path + fileName);
                MessageBox.Show($"Relatório Salvo em {path}");
                System.Diagnostics.Process.Start(@path + fileName);
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            ListCancelledSales();
        }

        private void btnRefresh_MouseMove(object sender, MouseEventArgs e) {
            btnRefresh.Cursor = Cursors.Hand;
            btnRelatorio.Cursor = Cursors.Hand;
            toolTip.SetToolTip(btnRelatorio, "Gerar relatório");
            toolTip.SetToolTip(btnRefresh, "Atualizar vendas");
        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void btnSaleCancel_Click(object sender, EventArgs e) {
            DialogResult res = MessageBox.Show("Tem Certeza que deseja remover esta venda?\n" +
                "É uma venda cancelada e seus dados serão totalmente perdidos!", "Cancelar venda", MessageBoxButtons.OKCancel,MessageBoxIcon.Stop);
            if (res == DialogResult.OK) {
                cancelledSale.ID = int.Parse(vendasGridView1.SelectedCells[0].Value.ToString());
                cancelledSaleDAO.DeleteCancelledSale(cancelledSale);
                ListCancelledSales();
            }
        }
    }
}