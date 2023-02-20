using EasyPDV.Entities;
using EasyPDV.Model;
using System;
using System.Drawing.Printing;
using System.Globalization;
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
            DialogResult dialogResult = MessageBox.Show("Confirma abertura?", "Abertura Caixa", MessageBoxButtons.OKCancel); int num2;
            if (int.TryParse(txtCashier.Text, out num2))
            {
                if (dialogResult == DialogResult.OK)
                {
                    if (cashierDAO.IsCashierOpen() == false)
                    {
                        cashier.Number = int.Parse(txtCashier.Text);
                        cashier.InitialBalance = double.Parse(txtBalance.Text.ToString(CultureInfo.InvariantCulture));
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
                    }
                    else
                    {
                        MessageBox.Show("Caixa já se encontra aberto!");

                    }
                }
            }
            else {
                MessageBox.Show("O caixa deve ser um número");
            }
        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void FrmOpenCashier_Load(object sender, EventArgs e)
        {

        }
    }
}
