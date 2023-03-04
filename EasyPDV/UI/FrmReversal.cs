using EasyPDV.Model;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using EasyPDV.Entities;
using System.Linq;

namespace EasyPDV.UI
{
    public partial class FrmReversal : Form
    {
        ProductDAO productDAO = new ProductDAO();
        IndividualSaleDAO individualSaleDAO = new IndividualSaleDAO();
        IndividualSale individualSale = new IndividualSale();
        Product product = new Product();
        public FrmReversal()
        {
            InitializeComponent();
        }

        private void FrmReversal_Load(object sender, EventArgs e)
        {
            HideStuff();
            PopulateCombos();
        }
        public void HideStuff()
        {
            lblChange.Visible = false;
            comboProductChange.Visible = false;
        }
        public void UnhideStuff()
        {
            lblChange.Visible = true;
            comboProductChange.Visible = true;
        }

        public void PopulateCombos()
        {
            List<Product> products = new List<Product>();
            List<Product> soldProducts = new List<Product>();
            products = productDAO.ReadAll();
            soldProducts = individualSaleDAO.ReadSoldProducts();
            List<Product> noRepeatSoldProducts = soldProducts.Distinct().ToList();
            foreach (Product product in noRepeatSoldProducts)
            {
                comboProduct.Items.Add(product.Name + " | " + productDAO.GetPrice(product));
            }
            foreach (Product product in products)
            {
                comboProductChange.Items.Add(product.Name + " | " + productDAO.GetPrice(product));
            }
        }

        private void actionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (actionCombo.Text == "Trocar")
            {
                UnhideStuff();
            }
            else
            {
                HideStuff();
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirma ação?", "Realizar Troca/Estorno", MessageBoxButtons.OKCancel);
            if (actionCombo.Text == "Trocar")
            {
                if (dialogResult == DialogResult.OK && comboProductChange.Text != "" && comboProduct.Text != "")
                {
                    string[] splitProductChange = comboProductChange.Text.Split('|');
                    string[] splitProduct = comboProduct.Text.Split('|');
                    individualSale.Product = splitProductChange[0].Trim();
                    individualSale.SaleDate = DateTime.Now;
                    individualSale.SalePrice = double.Parse(splitProductChange[1].Trim());
                    individualSale.PaymentMethod = "Troca ou estorno";
                    individualSaleDAO.DeleteIndividualSale(splitProduct[0].Trim());
                    individualSaleDAO.InsertIndividualSale(individualSale);
                    product.Name = splitProduct[0].Trim();
                    productDAO.SumStock(product);
                    product.Name = splitProductChange[0].Trim();
                    product.ID = productDAO.GetID(product);
                    productDAO.SubtractStock(product);
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos corretamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (actionCombo.Text == "Estornar")
            {
                if (dialogResult == DialogResult.OK && comboProduct.Text != "")
                {
                    string[] splitProduct = comboProduct.Text.Split('|');
                    individualSaleDAO.DeleteIndividualSale(splitProduct[0].Trim());
                    product.Name = splitProduct[0].Trim();
                    productDAO.SumStock(product);
                }
                else
                {
                    MessageBox.Show("Preencha o item a trocar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            comboProduct.Items.Clear();
            comboProductChange.Items.Clear();
            PopulateCombos();
        }

        private void comboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboProductChange_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
