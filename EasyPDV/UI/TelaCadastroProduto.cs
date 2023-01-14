using EasyPDV.DAO;
using EasyPDV.Entities;
using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace EasyPDV.UI {
    public partial class TelaCadastroProduto : Form {
        NpgsqlDataAdapter adpt;
        DataTable dt;
        ProdutoDAO produto = new ProdutoDAO(); 
        Produto p = new Produto();
        OpenFileDialog ofd = new OpenFileDialog();
        public TelaCadastroProduto() {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void btnCadastrar_Click(object sender, EventArgs e) {
            p.Nome = textBox1.Text;
            p.Imagem = siticoneTextBox1.Text;
            double num;
            int num2;
            if (double.TryParse(textBox2.Text, out num) && textBox1.Text != "" && textBox2.Text != "") {
                p.Preco = double.Parse(textBox2.Text);
            
            } else {
                MessageBox.Show(
                    "Preencha TODOS os campos. Campo Preço e Estoque devem ser um numeros");
            }
            if (int.TryParse(txtEstoque.Text, out num2) && txtEstoque.Text != "") {
                p.QtdEstoque = int.Parse(txtEstoque.Text);
                produto.Insert(p);
                MessageBox.Show("Cadastro efetuado!");
                textBox1.Text = string.Empty;
            }
            textBox2.Text= string.Empty;
            ListarProdutos();
        }
        public void ListarProdutos() {
            adpt = new NpgsqlDataAdapter(produto.Read());
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.MultiSelect = false;
            for (int i = 0; i <=4; i++) {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows) {
                dataGridView1.AutoResizeRow(row.Index);
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
            DialogResult = MessageBox.Show("Confirma exclusão?","Excluir produto",MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (DialogResult == DialogResult.OK) {
                produto.Delete(p);
                ListarProdutos();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e) {
            p.ID = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
            p.Nome = dataGridView1.SelectedCells[1].Value.ToString();
            p.Preco = double.Parse(dataGridView1.SelectedCells[2].Value.ToString());
            p.QtdEstoque= int.Parse(dataGridView1.SelectedCells[4].Value.ToString());
            produto.Update(p);
            MessageBox.Show("Produto alterado com sucesso");
        }

        private void btnCadastrar_MouseMove(object sender, MouseEventArgs e) {
            btnCadastrar.Cursor = Cursors.Hand;
            btnExcluir.Cursor = Cursors.Hand;
            btnAlterar.Cursor = Cursors.Hand;
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void btnCaminho_Click(object sender, EventArgs e) {
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Substring(ofd.FileName.Length - 3) == "png") {
                siticoneTextBox1.Text = ofd.FileName;
            } else {
                MessageBox.Show("O arquivo deve ser uma imagem .PNG de no máximo 140x140 pixels");
            }
        }

        private void siticoneTextBox1_TextChanged(object sender, EventArgs e) {

        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            ListarProdutos();
        }

        private void btnCaminho_MouseMove(object sender, MouseEventArgs e) {
            btnCaminho.Cursor = Cursors.Hand;
        }

        private void btnRefresh_MouseMove(object sender, MouseEventArgs e) {
            btnRefresh.Cursor = Cursors.Hand;
        }
    }
}
