using System;
using System.Data.SqlTypes;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;
using EasyPDV.DAO;
using EasyPDV.Entities;
using EasyPDV.UI;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace EasyPDV {
    public partial class TelaApp : Form {
        public double Total { get; set; }
        VendaDAO vendaDAO = new VendaDAO();
        Venda venda = new Venda();
        public TelaApp() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
        }

        private void button9_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            richTextBox3.Text = string.Empty;
            richTextBox3.Text = string.Empty;
            richTextBox1.Text += "Pastel .... " + 7 + "R$\t\t";
            Total += 7;
            richTextBox3.Text += Total.ToString("F2") + "R$";
        }

        private void button2_Click(object sender, EventArgs e) {
            richTextBox3.Text = string.Empty;
            richTextBox1.Text += "Cerveja .... " + 5 + "R$\t\t";
            Total += 5;
            richTextBox3.Text += Total.ToString("F2") + "R$";
        }

        private void button3_Click(object sender, EventArgs e) {
            richTextBox3.Text = string.Empty;
            richTextBox1.AppendText("Coca-cola .... " + 4 + "R$\t\t");
            Total += 4;
            richTextBox3.Text += Total.ToString("F2") + "R$";
        }

        private void button4_Click(object sender, EventArgs e) {
            richTextBox3.Text = string.Empty;
            richTextBox1.Text += "Sorvete .... " + 4 + "R$\t\t";
            Total += 4;
            richTextBox3.Text += Total.ToString("F2") + "R$";
        }

        private void button6_Click(object sender, EventArgs e) {

        }

        private void button7_Click(object sender, EventArgs e) {

        }

        private void button5_Click(object sender, EventArgs e) {
            richTextBox3.Text = string.Empty;
            richTextBox1.Text += "Bolo .... " + 4 + "R$\t\t";
            Total += 4;
            richTextBox3.Text += Total.ToString("F2") + "R$";
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

        private void btnRealizar_Click(object sender, EventArgs e) {

        }

        private void btnCancel_MouseMove(object sender, MouseEventArgs e) {
            btnCancel.Cursor = Cursors.Hand;

        }

        private void btnRealizar_MouseMove(object sender, MouseEventArgs e) {
            btnRealizar.Cursor = Cursors.Hand;
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e) {
            TelaCadastroProduto tc = new TelaCadastroProduto();
            tc.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) {
        }

        private void siticoneContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e) {

        }
        private void btnCancel_Click(object sender, EventArgs e) {
            richTextBox3.Text = string.Empty;
            richTextBox1.Text = string.Empty;
            Total = 0;
        }

        private void btnRealizar_Click_1(object sender, EventArgs e) {
            List<string> listaProdutos = richTextBox1.Lines.ToList();
            venda.DataVenda = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            venda.ValorVenda = Total;
            venda.Produtos = listaProdutos;
            foreach (string line in listaProdutos) {
                DialogResult res = MessageBox.Show(line.Replace("\t", "") + "\n", "Realizar venda", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK) {
                    vendaDAO.InsertVenda(venda);
                    richTextBox1.Text = string.Empty;
                    richTextBox3.Text = string.Empty;
                }
            }
        }
        private void visualizarVendasToolStripMenuItem_Click(object sender, EventArgs e) {
            TelaVendas tv = new TelaVendas();
            tv.Show();
        }
    }
}
