using DocumentFormat.OpenXml.Bibliography;
using EasyPDV.Entities;
using EasyPDV.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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
        SaleDAO saleDAO = new SaleDAO();
        CashierOpenDAO cashierOpenDAO = new CashierOpenDAO();
        ReversedSale changeSale = new ReversedSale();
        ReversedSaleDAO changeSaleDAO = new ReversedSaleDAO();
        List<string> productsName = new List<string>();
        NpgsqlDataAdapter _adpt;
        DataTable _dt;
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
            ButtonCursor();
        }
        private void ButtonCursor()
        {
            btnChange.Cursor = Cursors.Hand;
        }
        private void HideStuff()
        {
            lblChange.Visible = false;
            comboProductChange.Visible = false;
            ToChangeProductsCount.Visible = false;
        }
        private void UnhideStuff()
        {
            lblChange.Visible = true;
            comboProductChange.Visible = true;
            ToChangeProductsCount.Visible = true;
        }

        private void PopulateCombos()
        {
            List<Product> products = new List<Product>();
            List<Product> soldProducts = new List<Product>();
            products = productDAO.ReadActivated();
            soldProducts = individualSaleDAO.ReadSoldProducts(int.Parse(txtValue.Text));
            paymentMethod.Items.Clear();
            paymentMethod.Items.Add(individualSaleDAO.GetPaymentMethod(int.Parse(txtValue.Text)));
            if (soldProducts != null)
            {
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
                if (SoldProductsCount.Value > 0 && ToChangeProductsCount.Value > 0
                    && comboProductChange.Text != "" && comboProduct.Text != ""
                    && paymentMethod.Text != "" && txtValue.Text != "")
                {
                    if (dialogResult == DialogResult.OK)
                    {
                        int saleId = int.Parse(txtValue.Text);
                        productsName = saleDAO.GetSaleProducts(saleId);
                        if (individualSaleDAO.HasProduct(splitProduct[0].Trim(), saleId) == true)
                        {
                            for (int i = 0; i < SoldProductsCount.Value; i++)
                            {

                                individualSaleDAO.DeleteIndividualSale(splitProduct[0].Trim(), saleId);
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
                                individualSale.PaymentMethod = paymentMethod.Text;
                                individualSale.ExternalSaleID = int.Parse(txtValue.Text);
                                individualSaleDAO.InsertIndividualSale(individualSale);

                                string name = splitProduct[0];
                                productsName.Remove(name.Trim());
                                productsName.Add(splitProductChange[0].Trim());

                                RawPrinterHelper.Print(
                                    "-------------------\n\n" +
                                TypeHelper.FormatToCenter(cashierOpenDAO.ReturnEventName().Trim()) + "\n" +
                                TypeHelper.FormatToCenter(DateTime.Now.ToString("d").Trim()) + "\n" +
                                "\n" + TypeHelper.FormatToCenter(product.Name.ToUpper().Trim()) + "\n\n" +
                                "Pagamento:\n" + individualSale.PaymentMethod + "\nId venda: " + individualSale.ExternalSaleID
                                + "\n" + "-------------------"
                                       );
                            }
                            changeSale.ChangeType = "Troca";
                            changeSale.SaleDate = DateTime.Now;
                            FromProduct = double.Parse(splitProduct[1]) * (int)SoldProductsCount.Value;
                            ToProduct = double.Parse(splitProductChange[1]) * (int)ToChangeProductsCount.Value;
                            changeSale.Balance = ToProduct - FromProduct;
                            changeSale.PaymentMethod = paymentMethod.Text;
                            changeSaleDAO.InsertChangedSale(changeSale);

                            saleDAO.Update(productsName, saleId, changeSale.Balance + saleDAO.GetSaleValue(saleId));


                            comboProduct.Items.Clear();
                            comboProductChange.Items.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Esse produto não foi vendido com esse meio de pagamento");
                        }


                    }
                }

                else
                {
                    MessageBox.Show("Preencha todos os campos corretamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (actionCombo.Text == "Estornar")
            {
                if (SoldProductsCount.Value > 0 && comboProduct.Text != "" && txtValue.Text != "")
                {
                    if (dialogResult == DialogResult.OK)
                    {
                        int saleId = int.Parse(txtValue.Text);
                        if (individualSaleDAO.HasProduct(splitProduct[0].Trim(), saleId) == true)
                        {
                            for (int i = 0; i < SoldProductsCount.Value; i++)
                            {
                                changeSale.ProductChangeFrom = splitProduct[0].Trim() + " x" + SoldProductsCount.Value.ToString();
                                individualSaleDAO.DeleteIndividualSale(splitProduct[0].Trim(), int.Parse(txtValue.Text));
                                product.Name = splitProduct[0].Trim();
                                productDAO.SumStock(product);
                            }

                            changeSale.ProductChangeTo = " - ";
                            changeSale.ChangeType = "Estorno";
                            changeSale.SaleDate = DateTime.Now;
                            FromProduct = double.Parse(splitProduct[1]) * (int)SoldProductsCount.Value;
                            changeSale.Balance = FromProduct * -1;
                            changeSale.PaymentMethod = paymentMethod.Text;
                            changeSaleDAO.InsertChangedSale(changeSale);

                            productsName = saleDAO.GetSaleProducts(saleId);
                            double value = saleDAO.GetSaleValue(saleId);
                            double discounted = double.Parse(splitProduct[1]) * (int)SoldProductsCount.Value;
                            string name = splitProduct[0];
                            productsName.Remove(name.Trim());
                            saleDAO.Update(productsName, saleId, value -  discounted);

                            comboProduct.Items.Clear();
                            comboProductChange.Items.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Esse produto não foi vendido com esse meio de pagamento");
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Preencha todos os campos corretamente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            PopulateForm();
        }

        private void comboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtValue.Text != "")
            {
                splitProduct = comboProduct.Text.Split('|'); // product sold
                SoldProductsCount.Maximum = individualSaleDAO.ReadTotalIndividualSoldProduct(splitProduct[0].Trim(), int.Parse(txtValue.Text));
            }
        }

        private void comboProductChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            splitProductChange = comboProductChange.Text.Split('|'); // product to give in change
            product.Name = splitProductChange[0].Trim();
            ToChangeProductsCount.Maximum = productDAO.CheckStock(product);

        }
        public void ShowSales(int id)
        {
            _adpt = new NpgsqlDataAdapter(individualSaleDAO.ReadBySaleId(id));
            _dt = new DataTable();
            _adpt.Fill(_dt);
            salesGridView1.DataSource = _dt;
            salesGridView1.MultiSelect = true;
            for (int i = 0; i <= 3; i++)
            {
                salesGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            comboProduct.Items.Clear();
            comboProductChange.Items.Clear();
            SoldProductsCount.Value = 0;
            ToChangeProductsCount.Value = 0;
            paymentMethod.Items.Clear();
            PopulateForm();
        }

        private void PopulateForm()
        {
            if (txtValue.Text != "")
            {
                lblFillId.Visible = false;
                ShowSales(int.Parse(txtValue.Text));
                PopulateCombos();
            }
        }
    }
}
