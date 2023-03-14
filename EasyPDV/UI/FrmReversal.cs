using EasyPDV.Entities;
using EasyPDV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EasyPDV.UI
{
    public partial class FrmReversal : Form
    {
        ProductDAO productDAO = new ProductDAO();
        IndividualSaleDAO individualSaleDAO = new IndividualSaleDAO();
        IndividualSale individualSale = new IndividualSale();
        Product product = new Product();
        CashierOpenDAO cashierOpenDAO = new CashierOpenDAO();
        ReversedSale changeSale = new ReversedSale();
        ReversedSaleDAO changeSaleDAO = new ReversedSaleDAO();
        string[] splitProduct;
        string[] splitProductChange;
        double FromProduct;
        double ToProduct;
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
            ToChangeProductsCount.Visible = false;
        }
        public void UnhideStuff()
        {
            lblChange.Visible = true;
            comboProductChange.Visible = true;
            ToChangeProductsCount.Visible = true;
        }

        public void PopulateCombos()
        {
            List<Product> products = new List<Product>();
            List<Product> soldProducts = new List<Product>();
            products = productDAO.ReadActivated();
            soldProducts = individualSaleDAO.ReadSoldProducts();
            List<Product> noRepeatSoldProducts = soldProducts.Distinct().ToList();
            foreach (Product product in noRepeatSoldProducts)
            {
                comboProduct.Items.Add(product.Name + " | " + productDAO.GetPrice(product.Name));
            }
            foreach (Product product in products)
            {
                comboProductChange.Items.Add(product.Name + " | " + productDAO.GetPrice(product.Name));
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
                if (SoldProductsCount.Value > 0 && ToChangeProductsCount.Value > 0)
                {
                    if (dialogResult == DialogResult.OK && comboProductChange.Text != "" && comboProduct.Text != "")
                    {

                        for (int i = 0; i < SoldProductsCount.Value; i++)
                        {

                            individualSaleDAO.DeleteIndividualSale(splitProduct[0].Trim());
                            product.Name = splitProduct[0].Trim();
                            changeSale.ProductChangeFrom = splitProduct[0].Trim() + " x" + SoldProductsCount.Value.ToString();
                            productDAO.SumStock(product);

                        }

                        for (int i = 0; i < ToChangeProductsCount.Value; i++)
                        {

                            product.Name = splitProductChange[0].Trim();
                            changeSale.ProductChangeTo = splitProductChange[0].Trim() + " x" + ToChangeProductsCount.Value.ToString();
                            product.ID = productDAO.GetID(product);
                            productDAO.SubtractStock(product);
                            individualSale.Product = splitProductChange[0].Trim();
                            individualSale.SaleDate = DateTime.Now;
                            individualSale.SalePrice = double.Parse(splitProductChange[1].Trim());
                            individualSale.PaymentMethod = "Troca ou estorno";
                            individualSaleDAO.InsertIndividualSale(individualSale);
                            RawPrinterHelper.Print(
                                   "-------------------\n\n" +
                                   TypeHelper.FormatToCenter(cashierOpenDAO.ReturnEventName().Trim()) + "\n" +
                                   TypeHelper.FormatToCenter(DateTime.Now.ToString("d").Trim()) + "\n" +
                                   "\n" + TypeHelper.FormatToCenter(product.Name.ToUpper().Trim()) + "\n\n" +
                                   "-------------------"
                                   );
                        }

                        changeSale.ChangeType = "Troca";
                        changeSale.SaleDate = DateTime.Now;
                        FromProduct = double.Parse(splitProduct[1]) * (int)SoldProductsCount.Value;
                        ToProduct = double.Parse(splitProductChange[1]) * (int)ToChangeProductsCount.Value;
                        changeSale.Balance = ToProduct - FromProduct;
                        changeSaleDAO.InsertChangedSale(changeSale);

                        comboProduct.Items.Clear();
                        comboProductChange.Items.Clear();
                        PopulateCombos();

                    }
                }

                else
                {
                    MessageBox.Show("Preencha todos os campos corretamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (actionCombo.Text == "Estornar")
            {
                if (SoldProductsCount.Value > 0)
                {
                    if (dialogResult == DialogResult.OK && comboProduct.Text != "")
                    {
                        for (int i = 0; i < SoldProductsCount.Value; i++)
                        {
                            changeSale.ProductChangeFrom = splitProduct[0].Trim() + " x" + SoldProductsCount.Value.ToString();
                            individualSaleDAO.DeleteIndividualSale(splitProduct[0].Trim());
                            product.Name = splitProduct[0].Trim();
                            productDAO.SumStock(product);
                        }

                        changeSale.ProductChangeTo = " - ";
                        changeSale.ChangeType = "Estorno";
                        changeSale.SaleDate = DateTime.Now;
                        FromProduct = double.Parse(splitProduct[1]) * (int)SoldProductsCount.Value;
                        changeSale.Balance = FromProduct * -1;
                        changeSaleDAO.InsertChangedSale(changeSale);

                        comboProduct.Items.Clear();
                        comboProductChange.Items.Clear();
                        PopulateCombos();
                    }
                }

                else
                {
                    MessageBox.Show("Preencha todos os campos corretamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void comboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

            splitProduct = comboProduct.Text.Split('|'); // product sold
            SoldProductsCount.Maximum = individualSaleDAO.ReadTotalIndividualSoldProduct(splitProduct[0].Trim());
        }

        private void comboProductChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            splitProductChange = comboProductChange.Text.Split('|'); // product to give in change
            product.Name = splitProductChange[0].Trim();
            ToChangeProductsCount.Maximum = productDAO.CheckStock(product);

        }
    }
}
