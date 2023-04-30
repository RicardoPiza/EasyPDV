using EasyPDV.Entities;
using EasyPDV.Model;
using System;
using System.Drawing.Printing;
using System.Globalization;
using System.Windows.Forms;

namespace EasyPDV.UI
{
    public partial class FrmOpenCashier : Form
    {
        CashierOpen cashier = new CashierOpen();
        CashierOpenDAO cashierDAO = new CashierOpenDAO();
        RawPrinterHelper rawPrinter = new RawPrinterHelper();
        IndividualSale individualSale = new IndividualSale();
        IndividualSaleDAO individualSaleDAO = new IndividualSaleDAO();
        public FrmOpenCashier()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void btnOpenCashier_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirma abertura?", "Abertura Caixa", MessageBoxButtons.OKCancel);
            if (int.TryParse(txtCashier.Text, out int num2))
            {
                if (dialogResult == DialogResult.OK)
                {

                    cashier.Number = int.Parse(txtCashier.Text);
                    cashier.InitialBalance = double.Parse(txtBalance.Text.ToString(CultureInfo.InvariantCulture));
                    cashier.Responsible = txtResponsible.Text;
                    cashier.EventName = txtEventName.Text;
                    cashier.Date = DateTime.Now;
                    cashier.Status = true;
                    cashierDAO.OpenCashier(cashier);
                    individualSale.SaleDate = DateTime.Now;
                    individualSale.SalePrice = double.Parse(txtBalance.Text.ToString(CultureInfo.InvariantCulture));
                    individualSale.Product = "Valor abertura caixa";
                    individualSale.PaymentMethod = string.Empty;
                    individualSaleDAO.InsertIndividualSale(individualSale);
                    MessageBox.Show("Caixa aberto");
                    RawPrinterHelper.Print(txtEventName.Text +
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
            }
            else
            {
                MessageBox.Show("O caixa deve ser um número");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FrmOpenCashier_Load(object sender, EventArgs e)
        {
            btnOpenCashier.Cursor = Cursors.Hand;
        }
    }
}
