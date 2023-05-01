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
        Product product;
        public static string EventName { get; set; }
        IndividualSaleDAO individualSaleDAO = new IndividualSaleDAO();
        CashierBleed cashierBleed = new CashierBleed();
        CashierBleedDAO cashierBleedDAO = new CashierBleedDAO();
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
        CashierOpenDAO cashierOpenDAO = new CashierOpenDAO();
        ReversedSaleDAO reversedSaleDAO = new ReversedSaleDAO();
        public static bool warningProductsAboutToEnd = true;
        int restingProductsRealNumber;
        User user = LoginInfo.GetUser();
        public FrmApp()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ColorLabels();
            HiddeStuff();
            LoadButtons();
            NameEvent();
            ButtonsAnimation();
            GetUserInfo();
            SetPermissions();
        }

        public void GetUserInfo()
        {
            txtLoggedUser.Text = user.Login;
        }
        public void SetPermissions()
        {
            if (!user.Admin)
            {
                configuraçõesToolStripMenuItem.Visible = false;
            }
        }
        private void NameEvent()
        {
            string[] eventName = txtEventName.Text.Split('-');
            EventName = eventName[0];
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
            List<SiticoneButton> buttons = new List<SiticoneButton>();
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
            buttons.Add(button10);
            buttons.Add(button11);
            buttons.Add(button12);
            buttons.Add(button13);
            buttons.Add(button14);
            buttons.Add(button15);
            buttons.Add(button16);
            buttons.Add(button17);
            buttons.Add(button18);
            buttons.Add(button19);
            buttons.Add(button20);
            buttons.Add(button21);
            buttons.Add(button22);
            buttons.Add(button23);
            buttons.Add(button24);
            buttons.Add(button25);

            if (cashierOpenDAO.IsCashierOpen())
            {
                txtEventName.Text = cashierOpenDAO.ReturnEventName() + " - " + DateTime.Now.ToString("d");
                txtEventName.Visible = true;
                //List<SiticoneButton> buttons = tableLayoutPanel1.Controls.OfType<SiticoneButton>().ToList();
                List<Product> _Products = new List<Product>();
                //int totalBotoes = _btnProducts.Count();
                //_btnProducts.Reverse();
                _Products = _productDAO.ReadActivated().Distinct().ToList();
                for (int i = 0; i < _Products.Count; i++)
                {
                    _product.ID = _Products[i].ID;
                    _Products[i].Description = _productDAO.GetDesc(_product); string buttontooltip = "R$ " + _Products[i].Price + " " + _Products[i].Description;
                    if (_productDAO.ReadStatus(_product) == "ativado")
                    {
                        buttons[i].TabIndex = i;
                        buttons[i].Image = _productDAO.GrabImage(_product);
                        buttons[i].Text = _Products[i].Name + "\n";
                        buttons[i].TextAlign = HorizontalAlignment.Center;
                        toolTip.SetToolTip(buttons[i], "R$ " + _Products[i].Price.ToString("F2") + " " + _Products[i].Description);
                        int id = _product.ID;
                        string name = _Products[i].Name;
                        double price = _Products[i].Price;
                        buttons[i].Click += (s2, e2) => ProductSum(s2, e2, name, price, id);
                        tableLayoutPanel1.Controls.Add(buttons[i]);
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
            product = new Product();
            product.Name = name;
            totalBox.Text = string.Empty;
            string saleDescription = name + "........ R$ " + price.ToString("F2") + " | x1";

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
                        "........ R$ " + (price * _SoldQuantityList[i]).ToString("F2") +
                        " | x" + _SoldQuantityList[i];
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
            totalBox.Text += "R$ " + _SaleTotal.ToString("F2");
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
        private void btnMakeSale_Click_1(object sender, EventArgs e)
        {

            ProductDAO productDAO = new ProductDAO();
            _sale.SaleDate = DateTime.UtcNow;
            _sale.SalePrice = _SaleTotal;
            _sale.Products = _SoldProductsListToDB;
            _sale.PaymentMethod = paymentMethod.Text;
            var _id = individualSaleDAO.GetExternalSaleId() + 1;

            if (_listViewProducts.Text != "" || totalBox.Text != "")
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
                            RawPrinterHelper.Print("-------------------\n\n" +
                                TypeHelper.FormatToCenter(cashierOpenDAO.ReturnEventName().Trim()) + "\n" +
                                TypeHelper.FormatToCenter(DateTime.Now.ToString("d").Trim()) + "\n" +
                                "\n" + TypeHelper.FormatToCenter(product[0].ToUpper().Trim()) + "\n\n" +
                                "Pagamento:\n"+_sale.PaymentMethod + "\nId venda: "+_id+"\n" +
                                "Caixa: " + cashierOpenDAO.ReturnCashierNumber().ToString()
                                +"\n" + "-------------------"
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
                                MessageBox.Show($"Atenção, restam apenas {_productDAO.CheckStock(p)} {p.Name}(s)", "Produto acabando", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        MessageBox.Show("Venda Realizada com sucesso!");
                        _saleDao.InsertSale(_sale);
                        SubtractStockProduct();
                        AddIndividualProduct();
                        _listViewProducts.Clear();
                        _SoldQuantityList.Clear();
                        _SupportList.Clear();
                        _SoldProductsList.Clear();
                        _SoldProductsListToDB.Clear();
                        totalBox.Text = string.Empty;
                        paymentMethod.Text = "";
                        _SaleTotal = 0;
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
            var externalSaleId = individualSaleDAO.GetExternalSaleId();
            foreach (string item in _SoldProductsList)
            {
                individualSale.ExternalSaleID = externalSaleId;
                individualSale.SaleDate = DateTime.Now;
                string[] prodSplit = item.Split('|');
                individualSale.Product = prodSplit[0];
                individualSale.SalePrice = double.Parse(prodSplit[1].Trim());
                individualSale.PaymentMethod = paymentMethod.Text;
                individualSaleDAO.InsertIndividualSale(individualSale);
            }
        }

        private void ButtonsAnimation()
        {
            toolTip.SetToolTip(btnCancel, "Limpar Visor");
            foreach (SiticoneButton _btn in tableLayoutPanel1.Controls.OfType<SiticoneButton>())
            {
                _btn.Cursor = Cursors.Hand;
            }
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
            totalBox.Text = string.Empty;
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
            toolTip.SetToolTip(btnRefresh, "Reiniciar o programa");
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
            if (cashierOpenDAO.IsCashierOpen() == false)
            {
                FrmOpenCashier frmOpenCashier = new FrmOpenCashier();
                FrmHelper.OpenIfIsNot("Abrir caixa", frmOpenCashier);
            }
            else
            {
                MessageBox.Show("Caixa já está aberto!");
            }
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
            DialogResult dialogResult = MessageBox.Show(
                "Deseja fechar o caixa? \n\n" +
                "Será gerado um relatório Geral com vendas, faturas e vendas canceladas." +
                "\n\nApós confirmação, selecione onde irá salva-lo",
                "Fechar caixa", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (cashierOpenDAO.IsCashierOpen())
            {
                if (dialogResult == DialogResult.OK)
                {

                    CancelledSaleDAO cancelledSaleDAO = new CancelledSaleDAO();
                    cashierOpenDAO.ReadSome(cashierBleed);
                    double totalSales = individualSaleDAO.ReadTotalIndividualSale();
                    double initialBalance = cashierOpenDAO.InitialBalance();
                    RawPrinterHelper.Print(EventName +
                              "\n ------------------" +
                              "\n  FECHAMENTO CAIXA\n" +
                              " ------------------\n" +
                              "\n\nCaixa: " + cashierBleed.Number +
                              "\nData: " + DateTime.Now.ToString("d") +
                              "\nResp.: " + cashierBleed.Responsible +
                              "\nSaldo inicial:\nR$" + initialBalance.ToString("F2") +
                              "\nSaldo final:\nR$" + (totalSales).ToString("F2")
                              );
                    ReportHelper.FinalReport(individualSaleDAO, cashierOpenDAO, _saleDao, cancelledSaleDAO, reversedSaleDAO, cashierBleedDAO);
                    cashierOpenDAO.CloseCashier();
                    _saleDao.DeleteAllSales();
                    cancelledSaleDAO.DeleteAllCancelledSales();
                    cashierBleedDAO.DeleteAllBleedCashier();
                    individualSaleDAO.DeleteAllIndividualSales();
                    reversedSaleDAO.DeleteAllReversedSales();
                    Application.Restart();
                }
            }
            else
            {
                MessageBox.Show("Caixa já está fechado");
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
            if (totalBox.Text != "" && txtChange.Text != "")
            {
                double change = double.Parse(txtChange.Text);
                double total = double.Parse(totalBox.Text.Substring(2));
                lblChange.Text = "Troco: R$ " + (change - total).ToString("F2");
            }
        }

        private void FrmApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void darkModeSwitch_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void visualizarTrocasEstornosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReversalReport frmReversalReport = new FrmReversalReport();
            FrmHelper.OpenIfIsNot("Troca/Estorno", frmReversalReport);
        }

        private void pesquisarVendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSaleSearch frmSaleSearch = new FrmSaleSearch();
            FrmHelper.OpenIfIsNot("Pesquisar vendas", frmSaleSearch);
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUser frmUser = new FrmUser();
            FrmHelper.OpenIfIsNot("Cadastro de usuários", frmUser);
        }
    }
}
