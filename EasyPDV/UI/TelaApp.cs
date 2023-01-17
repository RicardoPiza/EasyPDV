using System;
using System.Windows.Forms;
using EasyPDV.DAO;
using EasyPDV.Entities;
using EasyPDV.UI;
using System.Linq;
using System.Collections.Generic;
using Color = System.Drawing.Color;
using DocumentFormat.OpenXml.Drawing;

namespace EasyPDV {
    public partial class TelaApp : Form {
        public double Total { get; set; }
        public double TotalCaixa { get; set; }

        VendaDAO vendaDAO = new VendaDAO();
        Venda venda = new Venda();
        Produto produto = new Produto();
        ProdutoDAO produtoDAO = new ProdutoDAO();
        List<string> ListaDeProdutosVendidos = new List<string>();
        List<int> ListaQtdVendidos = new List<int>();
        List<int> ListaIDProdutos = new List<int>();
        List<string> list = new List<string>();
        public TelaApp() {
            InitializeComponent();
            ColorirLabels();
            CarregaBotoes();
        }
        private void Form1_Load(object sender, EventArgs e) {
        }
        private void ColorirLabels() {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
        }
        private void CarregaBotoes() {
            List<Button> botoesProdutos = new List<Button>();
            List<Produto> produtos = new List<Produto>();
            botoesProdutos = tableLayoutPanel1.Controls.OfType<Button>().ToList();
            int totalBotoes = botoesProdutos.Count();
            botoesProdutos.Reverse();
            produtos = produtoDAO.ReadAll();
            for (int i = 0; i < produtos.Count; i++) {
                produto.ID = produtos[i].ID;
                botoesProdutos[i].Image = produtoDAO.BuscarImagem(produto);
                int id = produto.ID;
                string name = produtos[i].Nome;
                double preco = produtos[i].Preco;
                botoesProdutos[i].Click += (s2, e2) => SomaProdutos(s2, e2, name, preco, id);
                botoesProdutos[i].Invalidate();
            }
        }
        public void SomaProdutos(object sender, EventArgs e, string nome, double preco, int id) {
            richTextBox3.Text = string.Empty;
            string descricaoCompra = nome +"........ R$"+ preco ;
            if (!list.Contains(nome)) {
                list.Add(nome);
                listViewProdutos.Items.Add(descricaoCompra);
                ListaQtdVendidos.Add(1);
            } else {
                for (int i = 0; i < list.Count; i++) {
                    if (listViewProdutos.Items[i].Text.Contains(nome.ToString())){
                        ListaQtdVendidos[i] += 1;
                        listViewProdutos.Items[i].Text = nome + "........ R$" + preco * ListaQtdVendidos[i]+ " | Qtd = x"+ ListaQtdVendidos[i];
                    }
                }
            }
            ListaDeProdutosVendidos.Add(nome + "|" + preco);
            ListaIDProdutos.Add(id);
            Total += preco;
            richTextBox3.Text += Total.ToString("F2");
        }
        public void SubtrairProdutoEstoque() {
            foreach (int item in ListaIDProdutos) {
                produtoDAO.SubtraiEstoque(item);
            }
            ListaIDProdutos.Clear();
        }
        private void btnRealizar_Click_1(object sender, EventArgs e) {
            venda.DataVenda = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            venda.ValorVenda = Total;
            venda.Produtos = AdicionarListaVendaBanco();
            venda.MeioPagamento = meioPagamentoBox.Text;
            foreach (string item in ListaDeProdutosVendidos) {
                //Aqui será implementado o código de impressão de fichas
                //Para cada item na lista, uma ficha impressa
            }
            if (listViewProdutos.Text != "" || richTextBox3.Text != "") {
                if (meioPagamentoBox.Text != "") {
                    DialogResult res = MessageBox.Show("Confirma a venda?", "Realizar venda", MessageBoxButtons.OKCancel);
                    if (res == DialogResult.OK) {
                        vendaDAO.InsertVenda(venda);
                        SubtrairProdutoEstoque();
                        AdicionarProdutoIndividual();
                        listViewProdutos.Clear();
                        ListaQtdVendidos.Clear();
                        list.Clear();
                        richTextBox3.Text = string.Empty;
                        meioPagamentoBox.Text = "";
                        Total = 0;
                        MessageBox.Show("Venda Realizada com sucesso!");
                    }
                } else {
                    MessageBox.Show("Escolha o meio de pagamento!", "Meio de pagamento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } else {
                MessageBox.Show("Nenhum produto selecionado!", "Produto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private List<string> AdicionarListaVendaBanco() {
            List<string> listaProdutosBanco = new List<string>();
            foreach (var item in listViewProdutos.Items) {
                listaProdutosBanco.Add(item.ToString());
            }
            return listaProdutosBanco;
        }
        private void AdicionarProdutoIndividual() {
            VendaIndividual vendaIndividual = new VendaIndividual();
            VendaIndividualDAO vendaIndividualDAO = new VendaIndividualDAO();
            foreach (string item in ListaDeProdutosVendidos) {
                vendaIndividual.DataVenda = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
                string[] prodSplit = item.Split('|');
                vendaIndividual.Produto = prodSplit[0];
                vendaIndividual.ValorVenda = double.Parse(prodSplit[1].Trim());
                vendaIndividual.MeioPagamento = meioPagamentoBox.Text;
                vendaIndividualDAO.InsertVendaIndividual(vendaIndividual);
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
                TelaCadastroProduto tc = new TelaCadastroProduto();
                tc.Show();
            }
        }       
        private void siticoneContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e) {

        }
        private void btnCancel_Click(object sender, EventArgs e) {
            richTextBox3.Text = string.Empty;
            listViewProdutos.Clear();
            ListaQtdVendidos.Clear();
            list.Clear();
            Total = 0;
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
            foreach (Form f in Application.OpenForms) {
                if (f.Text == "Fatura do dia") {
                    isOpen = true;
                    f.BringToFront();
                    break;
                }
            }
            if (isOpen == false) {
                TelaFatura telaFatura = new TelaFatura();
                telaFatura.Show();
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
                TelaVendasCanceladas tvc = new TelaVendasCanceladas();
                tvc.Show();
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
                TelaVendas tv = new TelaVendas();
                tv.Show();
            }
        }
    }
}
