using EasyPDV.Model;
using EasyPDV.Entities;
using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using System.Globalization;
using DocumentFormat.OpenXml.Drawing;

namespace EasyPDV.UI
{
    public partial class FrmInsertProduct : Form
    {
        NpgsqlDataAdapter _adpt;
        DataTable _dt;
        ProductDAO productDAO = new ProductDAO();
        Product product = new Product();
        OpenFileDialog ofd = new OpenFileDialog();
        ToolTip toolTip = new ToolTip();
        public FrmInsertProduct()
        {
            InitializeComponent();
        }
        private void FrmInsertProduct_Load(object sender, EventArgs e)
        {
            
            ShowProductList();
            dataGridView1.MultiSelect = true;
            WarningCheckBox();
            BlockProductId();
            siticoneButton1.Cursor = Cursors.Hand;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            product.Name = textBox1.Text;
            product.Image = txtImagePath.Text;
            product.Status = "ativado";
            double num;
            int num2;
            bool insert = true;
            if (double.TryParse(textBox2.Text, out num) && textBox1.Text != "" && textBox2.Text != "" && txtImagePath.Text != "")
            {
                if (textBox1.Text.Length < 19)
                {
                    foreach (Product product in productDAO.ReadActivated())
                    {
                        string nameProduct = product.Name.Substring(0, product.Name.Length).ToLower();
                        string nameProductTextBox = textBox1.Text.Substring(0, textBox1.Text.Length).ToLower();
                        if (nameProductTextBox == nameProduct)
                        {

                            MessageBox.Show("Esse produto está confiltando com um produto já cadastrado. \n" +
                                $"Produto conflitante: {product.Name}", "Conflito de produtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            insert = false;

                        }
                    }
                    product.Price = double.Parse(textBox2.Text.ToString(CultureInfo.InvariantCulture));
                    if (int.TryParse(txtStock.Text, out num2) && txtStock.Text != "" && insert == true)
                    {
                        product.StockQuantity = int.Parse(txtStock.Text);
                        productDAO.Insert(product);
                        MessageBox.Show("Cadastro efetuado!");
                        textBox1.Text = string.Empty;
                    }


                }
                else
                {

                    MessageBox.Show("O nome do produto deve ter no máximo 19 caractéres!");
                }
            }

            else
            {
                MessageBox.Show(
                    "Preencha TODOS os campos. Campo Preço e Estoque devem ser numeral");
            }

            textBox2.Text = string.Empty;
            ShowProductList();
        }
        public void ShowProductList()
        {
            _adpt = new NpgsqlDataAdapter(productDAO.Read(productStatus.Text.ToLower().Remove(productStatus.Text.Length -1,1)));
            _dt = new DataTable();
            _adpt.Fill(_dt);
            dataGridView1.DataSource = _dt;
            dataGridView1.MultiSelect = false;
            for (int i = 0; i <= 5; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView1.AutoResizeRow(row.Index);
            }
        }
        public void BlockProductId()
        {
            dataGridView1.Columns[0].ReadOnly = true;

        }
        public void WarningCheckBox()
        {
            if (FrmApp.warningProductsAboutToEnd == true)
            {
                chkProductsAboutToEndWarning.Checked = true;
            }
        }
        private void chkProductsAboutToEndWarning_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProductsAboutToEndWarning.Checked == true)
            {
                FrmApp.warningProductsAboutToEnd = true;
            }
            else
            {
                FrmApp.warningProductsAboutToEnd = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            product.ID = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
            DialogResult = MessageBox.Show("Confirma exclusão?", "Excluir produto", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (DialogResult == DialogResult.OK)
            {
                productDAO.DeleteProduct(product);
                ShowProductList();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Salvar alteração?", "Alteração", MessageBoxButtons.OKCancel);
            if (DialogResult == DialogResult.OK)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
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

        private void btnInsert_MouseMove(object sender, MouseEventArgs e)
        {
            btnInsert.Cursor = Cursors.Hand;
            btnDelete.Cursor = Cursors.Hand;
            btnUpdate.Cursor = Cursors.Hand;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCaminho_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Substring(ofd.FileName.Length - 3) == "png")
            {
                txtImagePath.Text = ofd.FileName;
            }
            else
            {
                MessageBox.Show("O arquivo deve ser uma imagem .PNG de no máximo 140x140 pixels");
            }
        }

        private void txtImagePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowProductList();
        }

        private void btnCaminho_MouseMove(object sender, MouseEventArgs e)
        {
            btnPath.Cursor = Cursors.Hand;
        }

        private void btnRefresh_MouseMove(object sender, MouseEventArgs e)
        {
            btnRefresh.Cursor = Cursors.Hand;
            toolTip.SetToolTip(btnRefresh, "Atualizar produtos");
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new DialogResult();
            if (productStatus.Text == "Desativados")
            {
                dialogResult = MessageBox.Show("Ativar Produto?", "Ativar", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        Product product = new Product();
                        product.ID = int.Parse(row.Cells[0].Value.ToString());
                        product.Status = productDAO.ReadStatus(product);
                        if (product.Status == "desativado")
                        {
                            productDAO.ChangeStatus(product);
                        }
                    }
                    MessageBox.Show("Ativado");
                    ShowProductList();
                }
            }
            else if (productStatus.Text == "Ativados")
            {
                dialogResult = MessageBox.Show("Desativar Produto?", "Desativar", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        Product product = new Product();
                        product.ID = int.Parse(row.Cells[0].Value.ToString());
                        product.Status = productDAO.ReadStatus(product);
                        if (product.Status == "ativado")
                        {
                            productDAO.ChangeStatus(product);
                        }
                    }
                    MessageBox.Show("Desativado");
                    ShowProductList();
                }
            }
        }

        private void productStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowProductList();
            dataGridView1.MultiSelect = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 19)
            {
                MessageBox.Show("O nome do produto deve ter no máximo 19 caractéres!");
            }
        }
    }
}
