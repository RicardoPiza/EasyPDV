using EasyPDV.Model;
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
            product.Status = "ativado";
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
            textBox2.Text = string.Empty;
            ShowProductList();
        }
        public void ShowProductList() {
            _adpt = new NpgsqlDataAdapter(productDAO.Read(productStatus.Text.ToLower()));
            _dt = new DataTable();
            _adpt.Fill(_dt);
            dataGridView1.DataSource = _dt;
            dataGridView1.MultiSelect = false;
            for (int i = 0; i <= 5; i++) {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows) {
                dataGridView1.AutoResizeRow(row.Index);
            }
        }

        private void FrmInsertProduct_Load(object sender, EventArgs e) {
            ShowProductList();
            dataGridView1.MultiSelect = true;
        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            product.ID = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
            DialogResult = MessageBox.Show("Confirma exclusão?", "Excluir produto", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (DialogResult == DialogResult.OK) {
                productDAO.DeleteProduct(product);
                ShowProductList();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            DialogResult = MessageBox.Show("Salvar alteração?", "Alteração", MessageBoxButtons.OKCancel);
            if (DialogResult == DialogResult.OK) {
                foreach (DataGridViewRow row in dataGridView1.Rows) {
                    product.ID = int.Parse(row.Cells[0].Value.ToString());
                    product.Name = row.Cells[1].Value.ToString();
                    product.Price = double.Parse(row.Cells[2].Value.ToString());
                    product.StockQuantity = int.Parse(row.Cells[4].Value.ToString());
                    product.Description = row.Cells[5].Value.ToString();
                    productDAO.Update(product);
                }
                MessageBox.Show("Produto alterado com sucesso");
            }
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

        private void siticoneButton1_Click(object sender, EventArgs e) {
            DialogResult dialogResult = new DialogResult();
            if (productStatus.Text == "Desativado") {
                dialogResult = MessageBox.Show("Ativar Produto?", "Ativar", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK) {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows) {
                        Product product = new Product();
                        product.ID = int.Parse(row.Cells[0].Value.ToString());
                        product.Status = productDAO.ReadStatus(product);
                        if (product.Status == "desativado") {
                            productDAO.ChangeStatus(product);
                        }
                    }
                    MessageBox.Show("Ativado");
                    ShowProductList();
                }
            } else if (productStatus.Text == "Ativado") {
                dialogResult = MessageBox.Show("Desativar Produto?", "Desativar", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK) {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows) {
                        Product product = new Product();
                        product.ID = int.Parse(row.Cells[0].Value.ToString());
                        product.Status = productDAO.ReadStatus(product);
                        if (product.Status == "ativado") {
                            productDAO.ChangeStatus(product);
                        }
                    }
                    MessageBox.Show("Desativado");
                    ShowProductList();
                }
            }
        }

        private void productStatus_SelectedIndexChanged(object sender, EventArgs e) {
            ShowProductList();
            dataGridView1.MultiSelect = true;
        }
    }
}
