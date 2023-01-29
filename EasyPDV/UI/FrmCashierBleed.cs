using EasyPDV.Entities;
using EasyPDV.Model;
using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace EasyPDV.UI {
    public partial class FrmCashierBleed : Form {
        CashierBleed cashierBleed = new CashierBleed();
        CashierBleedDAO cashierBleedDao = new CashierBleedDAO();
        CashierDAO cashierDAO = new CashierDAO();

        public FrmCashierBleed() {
            InitializeComponent();
        }

        private void FrmCashierBleed_Load(object sender, EventArgs e) {

        }

        private void btnOpenCashier_Click(object sender, EventArgs e) {
            DialogResult dialogResult= new DialogResult();
            dialogResult = MessageBox.Show("Confirma movimentação do caixa?", "Confirmar realização", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK) {
                if (comboBleed.Text != "") {
                    cashierBleed.Number = int.Parse(txtCashier.Text);
                    cashierBleed.Date = DateTime.Now;
                    cashierBleed.Responsible = txtResponsible.Text;
                    cashierBleed.Value = double.Parse(txtValue.Text);
                    cashierBleed.EventName = FrmApp.EventName;
                    cashierBleed.Type = comboBleed.Text;
                    cashierBleed.Description = txtDescription.Text;
                    cashierBleedDao.BeginMovimentation(cashierBleed);
                    MessageBox.Show("Movimentação realizada", "Sangria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Print(FrmApp.EventName +
                          "\n -----------------" +
                          "\n     " + comboBleed.Text.ToUpper() + "\n" +
                          " -----------------\n" +
                          "\n\nCaixa: " + txtCashier.Text +
                          "\nData: " + DateTime.Now.ToString("d") +
                          "\nResp.: " + txtResponsible.Text +
                          "\nDescrição.: " + txtDescription.Text +
                          "\nValor: " + txtValue.Text
                          );
                } else {
                    MessageBox.Show("Escolha o tipo de movimentação");
                }
                Dispose();
            } 
        }
        public void Print(string s) {
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if (DialogResult.OK == pd.ShowDialog(this)) {
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s);
            }
        }

        private void label4_Click(object sender, EventArgs e) {

        }
    }
}
