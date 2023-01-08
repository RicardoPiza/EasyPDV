using EasyPDV.DAO;
using EasyPDV.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPDV.UI {
    public partial class TelaCadastroProduto : Form {
        NpgsqlDataAdapter adpt;
        DataTable dt;
        ProdutoDAO produto = new ProdutoDAO(); 
        Produto p = new Produto();
        public TelaCadastroProduto() {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void btnCadastrar_Click(object sender, EventArgs e) {
            ProdutoDAO pd = new ProdutoDAO();
            Produto p = new Produto();
            p.Nome = textBox1.Text;
            double num;
            if (double.TryParse(textBox2.Text, out num)) {
                p.Preco= double.Parse(textBox2.Text);
                pd.Insert(p);
            } else {
                MessageBox.Show("Campo Preço deve ser um numero");
            }
            MessageBox.Show("Cadastro efetuado!");
            textBox1.Text= string.Empty;
            textBox2.Text= string.Empty;
            ListarProdutos();
        }
        public void ListarProdutos() {
            adpt = new NpgsqlDataAdapter(produto.ReadAll());
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.MultiSelect = false;
            for (int i = 0; i < 2; i++) {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void TelaCadastroProduto_Load(object sender, EventArgs e) {
            ListarProdutos();
        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            p.ID = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
            produto.Delete(p);
            ListarProdutos();
        }

        private void btnAlterar_Click(object sender, EventArgs e) {
            p.ID = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
            p.Nome = dataGridView1.SelectedCells[1].Value.ToString();
            p.Preco = double.Parse(dataGridView1.SelectedCells[2].Value.ToString());
            produto.Update(p);
            MessageBox.Show("Produto alterado com sucesso");
        }

        private void btnCadastrar_MouseMove(object sender, MouseEventArgs e) {
            btnCadastrar.Cursor = Cursors.Hand;
            btnExcluir.Cursor = Cursors.Hand;
            btnAlterar.Cursor = Cursors.Hand;
        }
    }
}
