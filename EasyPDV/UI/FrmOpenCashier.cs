using EasyPDV.Entities;
using EasyPDV.Model;
using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace EasyPDV.UI {
    public partial class FrmOpenCashier : Form {
        CashierOpen cashier = new CashierOpen();
        CashierOpenDAO cashierDAO = new CashierOpenDAO();
        RawPrinterHelper rawPrinter = new RawPrinterHelper();
        public FrmOpenCashier() {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e) {

        }
        public void Print(string s) {
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if (DialogResult.OK == pd.ShowDialog(this)) {
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s);
            }
        }

        private void btnOpenCashier_Click(object sender, EventArgs e) {
            DialogResult dialogResult = MessageBox.Show("Confirma abertura?", "Abertura Caixa", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK) {
                if (cashierDAO.IsCashierOpen() == false) {
                    cashier.Number = int.Parse(txtCashier.Text);
                    cashier.InitialBalance = int.Parse(txtBalance.Text);
                    cashier.Responsible = txtResponsible.Text;
                    cashier.EventName = txtEventName.Text;
                    cashier.Date = DateTime.Now;
                    cashier.Status = true;
                    cashierDAO.OpenCashier(cashier);
                    MessageBox.Show("Caixa aberto");
                    Print(txtEventName.Text +
                          "\n -----------------" +
                          "\n ABERTURA DE CAIXA\n" +
                          " -----------------\n" +
                          "\n\nCaixa: " + txtCashier.Text +
                          "\nData: " + DateTime.Now.ToString("d") +
                          "\nResp.: " + txtResponsible.Text +
                          "\nSaldo: " + txtBalance.Text
                          );
                    this.Dispose();
                    Application.Restart();
                } else {
                    MessageBox.Show("Caixa já se encontra aberto!");
                }
            }
        }

        private void label4_Click(object sender, EventArgs e) {

        }
    }
}
