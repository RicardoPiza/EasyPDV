using EasyPDV.Model;
using EasyPDV.Entities;
using EasyPDV.UI;
using Siticone.Desktop.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using System.Drawing.Printing;
using ToolTip = System.Windows.Forms.ToolTip;
using EasyPDV.Utils;

namespace EasyPDV
{
    public partial class FrmApp : Form
    {
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
        public static bool warningProductsAboutToEnd = true;
        int restingProductsRealNumber;
        public FrmApp()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ColorLabels();
            HiddeStuff();
            LoadButtons();
            string[] eventName = txtEventName.Text.Split('-');
            EventName = eventName[0];
            CursorAnimation();
        }
        public void HiddeStuff()
        {
            txtChange.Visible = false;
            lblChange.Visible = false;
        }
        private void ColorLabels()
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
        }
        public void LoadButtons()
        {
            if (cashierDAO.IsCashierOpen())
            {
                txtEventName.Text = cashierDAO.ReturnEventName() + " - " + DateTime.Now.ToString("d");
                txtEventName.Visible = true;
                List<SiticoneButton> _btnProducts = tableLayoutPanel1.Controls.OfType<SiticoneButton>().ToList();
                List<Product> _Products = new List<Product>();
                int totalBotoes = _btnProducts.Count();
                _btnProducts.Reverse();
                _Products = _productDAO.ReadAll();
                for (int i = 0; i < _Products.Count; i++)
                {
                    _product.ID = _Products[i].ID;
                    _Products[i].Description = _productDAO.GetDesc(_product); string buttontooltip = "R$ " + _Products[i].Price + " " + _Products[i].Description;
                    if (_productDAO.ReadStatus(_product) == "ativado")
                    {
                        _btnProducts[i].Image = _productDAO.GrabImage(_product);
                        _btnProducts[i].Text = _Products[i].Name + "\n";
                        _btnProducts[i].TextAlign = HorizontalAlignment.Center;
                        toolTip.SetToolTip(_btnProducts[i], "R$ " + _Products[i].Price.ToString("F2") + " " + _Products[i].Description);
                        int id = _product.ID;
                        string name = _Products[i].Name;
                        double price = _Products[i].Price;
                        _btnProducts[i].Click += (s2, e2) => ProductSum(s2, e2, name, price, id);
                    }
                }

            }
            else
            {
                FrmOpenCashier frmOpenCashier = new FrmOpenCashier();
                MessageBox.Show("Antes de começar os trabalhos. O caixa precisa estar aberto.");
                frmOpenCashier.ShowDialog();
            }
        }
        public void ProductSum(object sender, EventArgs e, string name, double price, int id)
        {
            Product product = new Product();
            product.Name = name;
            richTextBox3.Text = string.Empty;
            string saleDescription = name + "........ R$" + price.ToString("F2");
            if (!_SupportList.Contains(name))
            {
                _SupportList.Add(name);
                _listViewProducts.Items.Add(saleDescription);
                _SoldQuantityList.Add(1);
            }
            else
            {
                for (int i = 0; i < _SupportList.Count; i++)
                {
                    if (_listViewProducts.Items[i].Text.Substring(0, 10).Equals(saleDescription.Substring(0, 10)))
                    {
                        _SoldQuantityList[i] += 1;
                        restingProductsRealNumber = _productDAO.CheckStock(product) - _SoldQuantityList[i];
                        saleDescription = name +
                        "........ R$" + (price * _SoldQuantityList[i]).ToString("F2") +
                        " | Qtd = x" + _SoldQuantityList[i] + " | Estoque = " + restingProductsRealNumber;
                        _listViewProducts.Items[i].Text = saleDescription;
                        if (restingProductsRealNumber <= 0)
                        {
                            MessageBox.Show("Não temos mais " + name + " no estoque, se quiser, poderá continuar vendendo mas terá de repor posteriormente!\n\n",
                                "Acabou no estoque", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                        }
                    }
                }
            }
            _SoldProductsList.Add(name + "|" + price.ToString("F2"));
            _SoldProductsListToDB.Add(name);
            _ProductIDList.Add(id);
            _SaleTotal += price;
            richTextBox3.Text += _SaleTotal.ToString("F2");
            ChangeToGive();
        }

        public void SubtractStockProduct()
        {
            foreach (int item in _ProductIDList)
            {
                Product product = new Product();
                product.ID = item;
                _productDAO.SubtractStock(product);
            }
            _ProductIDList.Clear();
        }

        public void Print(string s)
        {
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if (DialogResult.OK == pd.ShowDialog(this))
            {
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s);
            }
        }

        private void btnMakeSale_Click_1(object sender, EventArgs e)
        {
            ProductDAO productDAO = new ProductDAO();
            _sale.SaleDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            _sale.SalePrice = _SaleTotal;
            _sale.Products = _SoldProductsListToDB;
            _sale.PaymentMethod = paymentMethod.Text;
            if (_listViewProducts.Text != "" || richTextBox3.Text != "")
            {
                if (paymentMethod.Text != "")
                {
                    DialogResult res = MessageBox.Show("Confirma a venda?", "Realizar venda", MessageBoxButtons.OKCancel);
                    if (res == DialogResult.OK)
                    {
                        Product p = new Product();
                        List<string> productsAbouToEnd = new List<string>();
                        foreach (string item in _SoldProductsList)
                        {
                            //Aqui será implementado o código de impressão de fichas
                            //Para cada item na lista, uma ficha impressa
                            string[] product = item.Split('|');
                            Print(
                                cashierDAO.ReturnEventName() + "\n\n " +
                                DateTime.Now.ToString("d") + "\n\n" +
                                "\n" + product[0].ToUpper() + "\n\n\n"
                                );
                            p.Name = product[0];
                            if (productDAO.CheckStock(p) <= 20)
                            {
                                productsAbouToEnd.Add(p.Name);
                            }
                        }
                        List<string> products = productsAbouToEnd.Distinct().ToList();
                        if (products.Count > 0 && warningProductsAboutToEnd == true)
                        {
                            foreach (string item in products)
                            {
                                p.Name = item;
                                MessageBox.Show($"Atenção, restam apenas {restingProductsRealNumber} {p.Name}(s)");
                            }
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
                }
                else
                {
                    MessageBox.Show("Escolha o meio de pagamento!", "Meio de pagamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Nenhum produto selecionado!", "Produto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void AddIndividualProduct()
        {
            IndividualSale individualSale = new IndividualSale();
            IndividualSaleDAO individualSaleDAO = new IndividualSaleDAO();
            foreach (string item in _SoldProductsList)
            {
                individualSale.SaleDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
                string[] prodSplit = item.Split('|');
                individualSale.Product = prodSplit[0];
                individualSale.SalePrice = double.Parse(prodSplit[1].Trim());
                individualSale.PaymentMethod = paymentMethod.Text;
                individualSaleDAO.InsertIndividualSale(individualSale);
            }
        }

        private void CursorAnimation()
        {
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
        private void button12_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btnCancel_MouseMove(object sender, MouseEventArgs e)
        {
            btnCancel.Cursor = Cursors.Hand;

        }
        private void btnRealizar_MouseMove(object sender, MouseEventArgs e)
        {
            btnRealizar.Cursor = Cursors.Hand;
        }
        private void siticoneContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            richTextBox3.Text = string.Empty;
            _listViewProducts.Clear();
            _SoldQuantityList.Clear();
            _SupportList.Clear();
            _SoldProductsList.Clear();
            _SoldProductsListToDB.Clear();
            _SaleTotal = 0;
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void btnRefresh_MouseMove(object sender, MouseEventArgs e)
        {
            btnRefresh.Cursor = Cursors.Hand;
        }
        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInsertProduct tc = new FrmInsertProduct();
            FrmHelper.OpenIfIsNot("Tela Cadastro Produto", tc);
        }
        private void conferirFaturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIncome frmIncome = new FrmIncome();
            FrmHelper.OpenIfIsNot("Fatura do dia", frmIncome);
        }
        private void cancelarVendaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmCancelledSale frmCancelledSale = new FrmCancelledSale();
            FrmHelper.OpenIfIsNot("Vendas Canceladas", frmCancelledSale);
        }
        private void visualizarVendasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmSale frmSale = new FrmSale();
            FrmHelper.OpenIfIsNot("Vendas", frmSale);
        }
        private void abrirCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOpenCashier frmOpenCashier = new FrmOpenCashier();
            FrmHelper.OpenIfIsNot("Abrir caixa", frmOpenCashier);
        }
        private void relatórioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCashierReport frmCashierReport = new FrmCashierReport();
            FrmHelper.OpenIfIsNot("Relatório de aberturas", frmCashierReport);
        }

        private void retiradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCashierBleed frmCashierBleed = new FrmCashierBleed();
            FrmHelper.OpenIfIsNot("Sangria de caixa", frmCashierBleed);
        }

        private void históricoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCashierBleedReport frmCashierBleedReport = new FrmCashierBleedReport();
            FrmHelper.OpenIfIsNot("Histórico de movimentação", frmCashierBleedReport);
        }
        private void trocaDeFichaEstornoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReversal frmReversal = new FrmReversal();
            FrmHelper.OpenIfIsNot("Estorno ou Troca", frmReversal);
        }
        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            FrmHelper.OpenIfIsNot("Sobre", frmAbout);
        }
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void fecharCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Certifique-se de tirar todos os relatórios antes de fechar o caixa.\n\nConfirma fechamento?",
                "Fechar caixa", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.OK)
            {
                IndividualSaleDAO individualSaleDAO = new IndividualSaleDAO();
                CashierOpenDAO cashierOpenDAO = new CashierOpenDAO();
                CashierBleed cashierBleed = new CashierBleed();
                CashierBleedDAO cashierBleedDAO = new CashierBleedDAO();
                SaleDAO saleDAO = new SaleDAO();
                CancelledSaleDAO cancelledSaleDAO = new CancelledSaleDAO();
                cashierOpenDAO.ReadSome(cashierBleed);
                double totalSales = individualSaleDAO.ReadTotalIndividualSale();
                double initialBalance = cashierOpenDAO.InitialBalance();
                Print(EventName +
                          "\n ------------------" +
                          "\n  FECHAMENTO CAIXA\n" +
                          " ------------------\n" +
                          "\n\nCaixa: " + cashierBleed.Number +
                          "\nData: " + DateTime.Now.ToString("d") +
                          "\nResp.: " + cashierBleed.Responsible +
                          "\nSaldo inicial:\nR$" + initialBalance.ToString("F2") +
                          "\nSaldo final:\nR$" + (totalSales).ToString("F2")
                          );
                cashierOpenDAO.CloseCashier();
                saleDAO.DeleteAllSales();
                cancelledSaleDAO.DeleteAllCancelledSales();
                cashierBleedDAO.DeleteAllBleedCashier();
                individualSaleDAO.DeleteAllIndividualSales();
                Application.Restart();
            }
        }


        private void paymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (paymentMethod.Text == "Dinheiro")
            {
                txtChange.Visible = true;
                lblChange.Visible = true;
                lblChange.Text = "";
                txtChange.Clear();
            }
            else
            {
                txtChange.Visible = false;
                lblChange.Visible = false;
            }
        }

        private void txtChange_TextChanged(object sender, EventArgs e)
        {
            ChangeToGive();
        }
        public void ChangeToGive()
        {
            if (richTextBox3.Text != "" && txtChange.Text != "")
            {
                double change = double.Parse(txtChange.Text);
                double total = double.Parse(richTextBox3.Text);
                lblChange.Text = "Troco: " + (change - total).ToString("F2");
            }
        }


    }
}
