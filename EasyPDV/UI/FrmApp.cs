using EasyPDV.DAO;
using EasyPDV.Entities;
using EasyPDV.UI;
using Siticone.Desktop.UI.WinForms;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace EasyPDV {
    public partial class FrmApp : Form {
        public double _Total { get; set; }
        public double _CashierTotal { get; set; }

        SaleDAO _saleDao = new SaleDAO();
        Sale _sale = new Sale();
        Product _product = new Product();
        ProductDAO _productDAO = new ProductDAO();
        List<string> _SoldProductsList = new List<string>();
        List<int> _SoldQuantityList = new List<int>();
        List<int> _ProductIDList = new List<int>();
        List<string> _SupportList = new List<string>();
        public FrmApp() {
            InitializeComponent();
            ColorLabels();
            LoadButtons();
        }
        private void Form1_Load(object sender, EventArgs e) {
        }
        private void ColorLabels() {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
        }
        private void LoadButtons() {
            List<SiticoneButton> _btnProducts = new List<SiticoneButton>();
            List<Product> _Products = new List<Product>();
            _btnProducts = tableLayoutPanel1.Controls.OfType<SiticoneButton>().ToList();
            int totalBotoes = _btnProducts.Count();
            _btnProducts.Reverse();
            _Products = _productDAO.ReadAll();
            for (int i = 0; i < _Products.Count; i++) {
                _product.ID = _Products[i].ID;
                _btnProducts[i].Image = _productDAO.BuscarImagem(_product);
                int id = _product.ID;
                string name = _Products[i].Name;
                double preco = _Products[i].Price;
                _btnProducts[i].Click += (s2, e2) => ProductSum(s2, e2, name, preco, id);
                _btnProducts[i].Invalidate();
            }
        }
        public void ProductSum(object sender, EventArgs e, string name, double price, int id) {
            richTextBox3.Text = string.Empty;
            string descricaoCompra = name +"........ R$"+ price ;
            if (!_SupportList.Contains(name)) {
                _SupportList.Add(name);
                _listViewProducts.Items.Add(descricaoCompra);
                _SoldQuantityList.Add(1);
            } else {
                for (int i = 0; i < _SupportList.Count; i++) {
                    if (_listViewProducts.Items[i].Text.Substring(0,10).Equals(descricaoCompra.Substring(0,10))){
                        _SoldQuantityList[i] += 1;
                        descricaoCompra = name +
                        "........ R$" + price * _SoldQuantityList[i] +
                        " | Qtd = x" + _SoldQuantityList[i];
                        _listViewProducts.Items[i].Text = descricaoCompra;
                    }
                }
            }
            _SoldProductsList.Add(name + "|" + price);
            _ProductIDList.Add(id);
            _Total += price;
            richTextBox3.Text += _Total.ToString("F2");
        }
        public void SubtractStockProduct() {
            foreach (int item in _ProductIDList) {
                _productDAO.SubtractStock(item);
            }
            _ProductIDList.Clear();
        }
        private void btnMakeSale_Click_1(object sender, EventArgs e) {
            _sale.SaleDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            _sale.SalePrice = _Total;
            _sale.Products = DBSaleAddList();
            _sale.PaymentMethod = meioPagamentoBox.Text;
            foreach (string item in _SoldProductsList) {
                //Aqui será implementado o código de impressão de fichas
                //Para cada item na lista, uma ficha impressa
            }
            if (_listViewProducts.Text != "" || richTextBox3.Text != "") {
                if (meioPagamentoBox.Text != "") {
                    DialogResult res = MessageBox.Show("Confirma a venda?", "Realizar venda", MessageBoxButtons.OKCancel);
                    if (res == DialogResult.OK) {
                        _saleDao.InsertSale(_sale);
                        SubtractStockProduct();
                        AddIndividualProduct();
                        _listViewProducts.Clear();
                        _SoldQuantityList.Clear();
                        _SupportList.Clear();
                        richTextBox3.Text = string.Empty;
                        meioPagamentoBox.Text = "";
                        _Total = 0;
                        MessageBox.Show("Venda Realizada com sucesso!");
                    }
                } else {
                    MessageBox.Show("Escolha o meio de pagamento!", "Meio de pagamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } else {
                MessageBox.Show("Nenhum produto selecionado!", "Produto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private List<string> DBSaleAddList() {
            List<string> listaProdutosBanco = new List<string>();
            foreach (var item in _listViewProducts.Items) {
                listaProdutosBanco.Add(item.ToString());
            }
            return listaProdutosBanco;
        }
        private void AddIndividualProduct() {
            IndividualSale individualSale = new IndividualSale();
            IndividualSaleDAO individualSaleDAO = new IndividualSaleDAO();
            foreach (string item in _SoldProductsList) {
                individualSale.SaleDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
                string[] prodSplit = item.Split('|');
                individualSale.Product = prodSplit[0];
                individualSale.SalePrice = double.Parse(prodSplit[1].Trim());
                individualSale.PaymentMethod = meioPagamentoBox.Text;
                individualSaleDAO.InsertIndividualSale(individualSale);
            }
        }
        private void TelaApp_Click(object sender, EventArgs e) {
            throw new NotImplementedException();
        }
        private void button9_Click(object sender, EventArgs e) {
        }
        private void button1_Click(object sender, EventArgs e) {
        }
        private void button2_Click(object sender, EventArgs e) {
        }
        private void button3_Click(object sender, EventArgs e) {
        }
        private void button4_Click(object sender, EventArgs e) {
        }
        private void button6_Click(object sender, EventArgs e) {

        }
        private void button7_Click(object sender, EventArgs e) {
        }
        private void button5_Click(object sender, EventArgs e) {
        }
        private void button12_Click(object sender, EventArgs e) {
        }
        private void button8_Click(object sender, EventArgs e) {
        }
        private void button11_Click(object sender, EventArgs e) {

        }
        private void button10_Click(object sender, EventArgs e) {

        }
        private void button13_Click(object sender, EventArgs e) {

        }
        private void button14_Click(object sender, EventArgs e) {

        }
        private void button15_Click(object sender, EventArgs e) {

        }
        private void button16_Click(object sender, EventArgs e) {

        }
        private void button12_MouseMove(object sender, MouseEventArgs e) {
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
            _Total = 0;
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
    }
}
