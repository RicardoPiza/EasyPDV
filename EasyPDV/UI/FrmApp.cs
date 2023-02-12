using EasyPDV.Model;
using EasyPDV.Entities;
using EasyPDV.UI;
using Siticone.Desktop.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using System.Drawing;
using Font = System.Drawing.Font;
using System.Drawing.Printing;
using System.Globalization;
using EasyPDV.Utils;
using DocumentFormat.OpenXml.Spreadsheet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ToolTip = System.Windows.Forms.ToolTip;

namespace EasyPDV {
    public partial class FrmApp : Form {
        public double _SaleTotal { get; set; }
        public static string EventName { get; set; }

        SaleDAO _saleDao = new SaleDAO();
        RegularSale _sale = new RegularSale();
        Product _product = new Product();
        ProductDAO _productDAO = new ProductDAO();
        List<string> _SoldProductsList = new List<string>();
        List<string> _SoldProductsListToDB = new List<string>();
        List<int> _SoldQuantityList = new List<int>();
        List<int> _ProductIDList = new List<int>();
        ToolTip toolTip = new ToolTip();
        List<string> _SupportList = new List<string>();
        CashierOpenDAO cashierDAO = new CashierOpenDAO();
        CustomToolTip customToolTip = new CustomToolTip();
        public FrmApp() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            ColorLabels();
            LoadButtons();
            string[] eventName = txtEventName.Text.Split('-');
            EventName = eventName[0];
            CursorAnimation();
        }

        private void ColorLabels() {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
        }
        public void LoadButtons() {
            if (cashierDAO.IsCashierOpen()) {
                txtEventName.Text = cashierDAO.ReturnEventName()+" - "+DateTime.Now.ToString("d");
                txtEventName.Visible=true;
                List<SiticoneButton> _btnProducts = new List<SiticoneButton>();
                List<Product> _Products = new List<Product>();
                _btnProducts = tableLayoutPanel1.Controls.OfType<SiticoneButton>().ToList();
                int totalBotoes = _btnProducts.Count();
                _btnProducts.Reverse();
                _Products = _productDAO.ReadAll();
                for (int i = 0; i < _Products.Count; i++) {
                    _product.ID = _Products[i].ID;
                    _Products[i].Description = _productDAO.GetDesc(_product); string buttontooltip = "R$ " + _Products[i].Price + " " + _Products[i].Description;                   
                    if (_productDAO.ReadStatus(_product) == "ativado") {
                        _btnProducts[i].Image = _productDAO.BuscarImagem(_product);
                        _btnProducts[i].Text = _Products[i].Name;
                        _btnProducts[i].TextAlign = HorizontalAlignment.Center;
                        toolTip.SetToolTip(_btnProducts[i], "R$ " + _Products[i].Price.ToString("F2") + " " + _Products[i].Description);
                        int id = _product.ID;
                        string name = _Products[i].Name;
                        double price = _Products[i].Price;
                        _btnProducts[i].Click += (s2, e2) => ProductSum(s2, e2, name, price, id);
                        _btnProducts[i].Invalidate();
                    } 
                }
            } else {
                MessageBox.Show("Antes de começar os trabalhos. O caixa precisa estar aberto.");
            }
        }

        public void ProductSum(object sender, EventArgs e, string name, double price, int id) {
            richTextBox3.Text = string.Empty;
            string saleDescription = name + "........ R$" + price.ToString("F2");
            if (!_SupportList.Contains(name)) {
                _SupportList.Add(name);
                _listViewProducts.Items.Add(saleDescription);
                _SoldQuantityList.Add(1);
            } else {
                for (int i = 0; i < _SupportList.Count; i++) {
                    if (_listViewProducts.Items[i].Text.Substring(0, 10).Equals(saleDescription.Substring(0, 10))) {
                        _SoldQuantityList[i] += 1;
                        saleDescription = name +
                        "........ R$" + (price * _SoldQuantityList[i]).ToString("F2") +
                        " | Qtd = x" + _SoldQuantityList[i];
                        _listViewProducts.Items[i].Text = saleDescription;
                    }
                }
            }
            _SoldProductsList.Add(name + "|" + price.ToString("F2"));
            _SoldProductsListToDB.Add(name);
            _ProductIDList.Add(id);
            _SaleTotal += price;
            richTextBox3.Text += _SaleTotal.ToString("F2");
        }

        public void SubtractStockProduct() {
            foreach (int item in _ProductIDList) {
                _productDAO.SubtractStock(item);
            }
            _ProductIDList.Clear();
        }

        public void Print(string s) {
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if (DialogResult.OK == pd.ShowDialog(this)) {
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s);
            }
        }

        private void btnMakeSale_Click_1(object sender, EventArgs e) {
            _sale.SaleDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            _sale.SalePrice = _SaleTotal;
            _sale.Products = _SoldProductsListToDB;
            _sale.PaymentMethod = paymentMethod.Text;
            if (_listViewProducts.Text != "" || richTextBox3.Text != "") {
                if (paymentMethod.Text != "") {
                    DialogResult res = MessageBox.Show("Confirma a venda?", "Realizar venda", MessageBoxButtons.OKCancel);
                    if (res == DialogResult.OK) {
                        foreach (string item in _SoldProductsList) {
                            //Aqui será implementado o código de impressão de fichas
                            //Para cada item na lista, uma ficha impressa
                            string[] product = item.Split('|');
                            Print(
                                cashierDAO.ReturnEventName()+"\n\n " +
                                DateTime.Now.ToString("d") + "\n" +
                                "\n" + product[0].ToUpper() +"\n\n\n"
                                );
                        }
                        _saleDao.InsertSale(_sale);
                        SubtractStockProduct();
                        AddIndividualProduct();
                        _listViewProducts.Clear();
                        _SoldQuantityList.Clear();
                        _SupportList.Clear();
                        _SoldProductsList.Clear();
                        _SoldProductsListToDB.Clear();
                        richTextBox3.Text = string.Empty;
                        paymentMethod.Text = "";
                        _SaleTotal = 0;
                        MessageBox.Show("Venda Realizada com sucesso!");
                    }
                } else {
                    MessageBox.Show("Escolha o meio de pagamento!", "Meio de pagamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } else {
                MessageBox.Show("Nenhum produto selecionado!", "Produto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void AddIndividualProduct() {
            IndividualSale individualSale = new IndividualSale();
            IndividualSaleDAO individualSaleDAO = new IndividualSaleDAO();
            foreach (string item in _SoldProductsList) {
                individualSale.SaleDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
                string[] prodSplit = item.Split('|');
                individualSale.Product = prodSplit[0];
                individualSale.SalePrice = double.Parse(prodSplit[1].Trim());
                individualSale.PaymentMethod = paymentMethod.Text;
                individualSaleDAO.InsertIndividualSale(individualSale);
            }
        }

        private void CursorAnimation() {
            button1.Cursor = Cursors.Hand;
            button2.Cursor = Cursors.Hand;
            button3.Cursor = Cursors.Hand;
            button4.Cursor = Cursors.Hand;
            button5.Cursor = Cursors.Hand;
            button6.Cursor = Cursors.Hand;
            button7.Cursor = Cursors.Hand;
            button8.Cursor = Cursors.Hand;
            button9.Cursor = Cursors.Hand;
            button10.Cursor = Cursors.Hand;
            button11.Cursor = Cursors.Hand;
            button12.Cursor = Cursors.Hand;
            button13.Cursor = Cursors.Hand;
            button14.Cursor = Cursors.Hand;
            button15.Cursor = Cursors.Hand;
            button16.Cursor = Cursors.Hand;
        }
        private void button12_MouseMove(object sender, MouseEventArgs e) {
            
        }
        private void label1_Click(object sender, EventArgs e) {

        }
        private void btnCancel_MouseMove(object sender, MouseEventArgs e) {
            btnCancel.Cursor = Cursors.Hand;

        }
        private void btnRealizar_MouseMove(object sender, MouseEventArgs e) {
            btnRealizar.Cursor = Cursors.Hand;
        }
        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e) {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms) {
                if (f.Text == "Tela Cadastro Produto") {
                    isOpen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (isOpen == false) {
                FrmInsertProduct tc = new FrmInsertProduct();
                tc.Show();
            }
        }
        private void siticoneContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e) {

        }
        private void btnCancel_Click(object sender, EventArgs e) {
            richTextBox3.Text = string.Empty;
            _listViewProducts.Clear();
            _SoldQuantityList.Clear();
            _SupportList.Clear();
            _SoldProductsList.Clear();
            _SaleTotal = 0;
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {

        }
        private void btnRefresh_Click(object sender, EventArgs e) {
            Application.Restart();
        }
        private void btnRefresh_MouseMove(object sender, MouseEventArgs e) {
            btnRefresh.Cursor = Cursors.Hand;
        }
        private void conferirFaturaToolStripMenuItem_Click(object sender, EventArgs e) {
            bool isOpen = false;
            foreach (Form form in Application.OpenForms) {
                if (form.Text == "Fatura do dia") {
                    isOpen = true;
                    form.BringToFront();
                    break;
                }
            }
            if (isOpen == false) {
                FrmIncome frmIncome = new FrmIncome();
                frmIncome.Show();
            }
        }
        private void cancelarVendaToolStripMenuItem_Click_1(object sender, EventArgs e) {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms) {
                if (f.Text == "Vendas Canceladas") {
                    isOpen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (isOpen == false) {
                FrmCancelledSale frmCancelledSale = new FrmCancelledSale();
                frmCancelledSale.Show();
            }
        }
        private void visualizarVendasToolStripMenuItem_Click_1(object sender, EventArgs e) {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms) {
                if (f.Text == "Vendas") {
                    isOpen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (isOpen == false) {
                FrmSale tv = new FrmSale();
                tv.Show();
            }
        }

        private void button8_Click(object sender, EventArgs e) {

        }

        private void abrirCaixaToolStripMenuItem_Click(object sender, EventArgs e) {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms) {
                if (f.Text == "Abrir caixa") {
                    isOpen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (isOpen == false) {
                FrmOpenCashier tv = new FrmOpenCashier();
                tv.Show();
            }
        }

        private void fecharCaixaToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogResult dialogResult = MessageBox.Show("Certifique-se de tirar todos os relatórios antes de fechar o caixa.\n\nConfirma fechamento?",
                "Fechar caixa", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK) {
                IndividualSaleDAO individualSaleDAO = new IndividualSaleDAO();
                CashierOpenDAO cashierDAO = new CashierOpenDAO();
                CashierBleed cashierBleed = new CashierBleed();
                cashierDAO.ReadSome(cashierBleed);
                cashierDAO.CloseCashier();
                individualSaleDAO.DeleteAllIndividualSales();
                Print(EventName +
                          "\n ------------------" +
                          "\n  FECHAMENTO CAIXA\n" +
                          " ------------------\n" +
                          "\n\nCaixa: " + cashierBleed.Number +
                          "\nData: " + DateTime.Now.ToString("d") +
                          "\nResp.: " + cashierBleed.Responsible +
                          "\nSaldo inicial:\nR$" + cashierBleed.Value.ToString("F2") +
                          "\nSaldo final:\nR$"+ (individualSaleDAO.ReadTotalIndividualSale() + cashierBleed.Value).ToString("F2")
                          );
                Application.Restart();
            }
        }

        private void relatórioToolStripMenuItem_Click(object sender, EventArgs e) {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms) {
                if (f.Text == "Relatório de aberturas") {
                    isOpen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (isOpen == false) {
                FrmCashierReport frmCashierReport = new FrmCashierReport();
                frmCashierReport.Show();
            }
        }

        private void retiradaToolStripMenuItem_Click(object sender, EventArgs e) {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms) {
                if (f.Text == "Sangria de caixa") {
                    isOpen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (isOpen == false) {
                FrmCashierBleed frmCashierBleed = new FrmCashierBleed();
                frmCashierBleed.Show();
            }
        }

        private void históricoToolStripMenuItem_Click(object sender, EventArgs e) {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms) {
                if (f.Text == "Histórico de movimentação") {
                    isOpen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (isOpen == false) {
                FrmCashierBleedReport frmCashierBleedReport = new FrmCashierBleedReport();
                frmCashierBleedReport.Show();
            }
        }
    
    }
}
