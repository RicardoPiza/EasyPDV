using EasyPDV.DAO;
using EasyPDV.Entities;
using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace EasyPDV.UI {
    public partial class FrmInsertProduct : Form {
        NpgsqlDataAdapter _adpt;
        DataTable _dt;
        ProductDAO productDAO = new ProductDAO(); 
        Product product = new Product();
        OpenFileDialog ofd = new OpenFileDialog();
        ToolTip toolTip = new ToolTip();
        public FrmInsertProduct() {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void btnRegister_Click(object sender, EventArgs e) {
            product.Name = textBox1.Text;
            product.Image = siticoneTextBox1.Text;
            double num;
            int num2;
            if (double.TryParse(textBox2.Text, out num) && textBox1.Text != "" && textBox2.Text != "") {
                product.Price = double.Parse(textBox2.Text);
            
            } else {
                MessageBox.Show(
                    "Preencha TODOS os campos. Campo Preço e Estoque devem ser um numeros");
            }
            if (int.TryParse(txtStock.Text, out num2) && txtStock.Text != "") {
                product.StockQuantity = int.Parse(txtStock.Text);
                productDAO.Insert(product);
                MessageBox.Show("Cadastro efetuado!");
                textBox1.Text = string.Empty;
            }
            textBox2.Text= string.Empty;
            ShowProductList();
        }
        public void ShowProductList() {
            _adpt = new NpgsqlDataAdapter(productDAO.Read());
            _dt = new DataTable();
            _adpt.Fill(_dt);
            dataGridView1.DataSource = _dt;
            dataGridView1.MultiSelect = false;
            for (int i = 0; i <=4; i++) {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows) {
                dataGridView1.AutoResizeRow(row.Index);
            }
        }

        private void FrmInsertProduct_Load(object sender, EventArgs e) {
            ShowProductList();
        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            product.ID = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
            DialogResult = MessageBox.Show("Confirma exclusão?","Excluir produto",MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (DialogResult == DialogResult.OK) {
                productDAO.DeleteProduct(product);
                ShowProductList();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            product.ID = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
            product.Name = dataGridView1.SelectedCells[1].Value.ToString();
            product.Price = double.Parse(dataGridView1.SelectedCells[2].Value.ToString());
            product.StockQuantity= int.Parse(dataGridView1.SelectedCells[4].Value.ToString());
            productDAO.Update(product);
            MessageBox.Show("Produto alterado com sucesso");
        }

        private void btnInsert_MouseMove(object sender, MouseEventArgs e) {
            btnInsert.Cursor = Cursors.Hand;
            btnDelete.Cursor = Cursors.Hand;
            btnUpdate.Cursor = Cursors.Hand;
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
            ShowProductList();
        }

        private void btnCaminho_MouseMove(object sender, MouseEventArgs e) {
            btnPath.Cursor = Cursors.Hand;
        }

        private void btnRefresh_MouseMove(object sender, MouseEventArgs e) {
            btnRefresh.Cursor = Cursors.Hand;
            toolTip.SetToolTip(btnRefresh, "Atualizar produtos");
        }
    }
}
