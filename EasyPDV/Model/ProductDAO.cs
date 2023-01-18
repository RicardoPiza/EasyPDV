using DocumentFormat.OpenXml.Office2010.Excel;
using EasyPDV.Entities;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EasyPDV.DAO {
    internal class ProductDAO {
        DAO dao = new DAO();
        public NpgsqlCommand Read() {
            NpgsqlCommand cmd;
            try {
                cmd = new NpgsqlCommand(
                    "SELECT id AS \"ID\", nome AS \"Nome do produto\", " +
                    "preco AS \"Preço\", imagem as \"Imagem\", estoque AS \"Estoque\"" +
                    " FROM produto ORDER by id", dao.Connection());
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
            dao.Connection().Close();
            return cmd;
        }
        public List<Product> ReadAll() {
            List<Product> list = new List<Product>();
            NpgsqlCommand cmd;
            try {
                cmd = new NpgsqlCommand(
                    "SELECT id, nome, preco, estoque from produto order by id", dao.Connection());
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        Product p = new Product();
                        p.ID = (int)reader.GetInt16(0);
                        p.Name = reader.GetString(1);
                        p.Price = (double)reader.GetDouble(2);
                        list.Add(p);
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
            dao.Connection().Close();
            return list;
        }
        public Image BuscarImagem(Product product) {
            NpgsqlCommand cmd;
            Image image = null;
            try {
                cmd = new NpgsqlCommand("" +
                    $"SELECT imagem FROM produto where id = {product.ID}", dao.Connection());
                byte[] productImageByte = cmd.ExecuteScalar() as byte[];
                if (productImageByte != null) {
                    using (MemoryStream productImageStream = new System.IO.MemoryStream(productImageByte)) {
                        ImageConverter imageConverter = new System.Drawing.ImageConverter();
                        image = imageConverter.ConvertFrom(productImageByte) as System.Drawing.Image;
                        image = System.Drawing.Image.FromStream(productImageStream);
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
            dao.Connection().Close();
            return image;
        }
        public void Insert(Product product) {
            NpgsqlCommand cmd;
            try {
                cmd = new NpgsqlCommand(
                    "INSERT INTO Produto(nome, preco, imagem, estoque) " +
                    $"VALUES(@n, @p,@i,@e)", dao.Connection());
                cmd.Parameters.AddWithValue("n", product.Name);
                cmd.Parameters.AddWithValue("p", product.Price);
                cmd.Parameters.AddWithValue("i", File.OpenRead(product.Image));
                cmd.Parameters.AddWithValue("e", product.StockQuantity);
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            dao.Connection().Close();
        }
        public void Update(Product product) {
            try {
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    "UPDATE produto " +
                    "SET nome = @n, preco = @p, estoque = @e" +
                    $" WHERE id = {product.ID}", dao.Connection());
                cmd.Parameters.AddWithValue("n", product.Name);
                cmd.Parameters.AddWithValue("p", product.Price);
                cmd.Parameters.AddWithValue("e", product.StockQuantity);
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            dao.Connection().Close();
        }
        public void DeleteProduct(Product p) {
            try {
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"DELETE FROM produto " +
                    $"WHERE ID = {p.ID}", dao.Connection());
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            dao.Connection().Close();
        }
        public void SubtractStock(int id) {
            try {
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    "UPDATE produto SET estoque = estoque - 1 " +
                    $"WHERE id = {id}", dao.Connection());
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            dao.Connection().Close();
        }
    }
}
