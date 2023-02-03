using EasyPDV.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EasyPDV.Model {
    internal class ProductDAO {
        string connectionString = DAO.ConnectionString;
        NpgsqlConnection connection;

        public NpgsqlCommand Read() {
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try {
                connection.Open();
                cmd = new NpgsqlCommand(
                    "SELECT id AS \"ID\", nome AS \"Nome do produto\", " +
                    "preco AS \"Preço\", imagem as \"Imagem\", estoque AS \"Estoque\"" +
                    " FROM produto ORDER by id", connection);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            } finally {
                connection.Close();
            }
            return cmd;

        }
        public List<Product> ReadAll() {
            connection = new NpgsqlConnection(connectionString);
            List<Product> list = new List<Product>();
                NpgsqlCommand cmd;
                try {
                connection.Open();
                cmd = new NpgsqlCommand(
                        "SELECT id, nome, preco, estoque from produto order by id", connection);
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
                } finally {
                connection.Close();
            }
            return list;
            }
        public Image BuscarImagem(Product product) {
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
                Image image = null;
                try {
                connection.Open();
                cmd = new NpgsqlCommand(
                        $"SELECT imagem FROM produto where id = {product.ID}", connection);
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
                } finally {
                connection.Close();
            }
            return image;
            }
        
        public void Insert(Product product) {
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
                try {
                connection.Open();
                cmd = new NpgsqlCommand(
                        "INSERT INTO Produto(nome, preco, imagem, estoque) " +
                        $"VALUES(@n, @p,@i,@e)", connection);
                    cmd.Parameters.AddWithValue("n", product.Name);
                    cmd.Parameters.AddWithValue("p", product.Price);
                    cmd.Parameters.AddWithValue("i", File.OpenRead(product.Image));
                    cmd.Parameters.AddWithValue("e", product.StockQuantity);
                    cmd.ExecuteNonQuery();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                } finally {
                    connection.Close();
                }
            }
        
        public void Update(Product product) {
            connection = new NpgsqlConnection(connectionString);
            try {
                connection.Open();
                NpgsqlCommand cmd;
                    cmd = new NpgsqlCommand(
                        "UPDATE produto " +
                        "SET nome = @n, preco = @p, estoque = @e" +
                        $" WHERE id = {product.ID}", connection);
                    cmd.Parameters.AddWithValue("n", product.Name);
                    cmd.Parameters.AddWithValue("p", product.Price);
                    cmd.Parameters.AddWithValue("e", product.StockQuantity);
                    cmd.ExecuteNonQuery();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                } finally {
                connection.Close();
            }
        }
        
        public void DeleteProduct(Product p) {
            connection = new NpgsqlConnection(connectionString);
            try {
                connection.Open();
                NpgsqlCommand cmd;
                    cmd = new NpgsqlCommand(
                        $"DELETE FROM produto " +
                        $"WHERE ID = {p.ID}", connection);
                    cmd.ExecuteNonQuery();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                } finally {
                connection.Close();
            }
        }
        
        public void SubtractStock(int id) {
            connection = new NpgsqlConnection(connectionString);
            try {
                connection.Open();
                NpgsqlCommand cmd;
                    cmd = new NpgsqlCommand(
                        "UPDATE produto SET estoque = estoque - 1 " +
                        $"WHERE id = {id}", connection);
                    cmd.ExecuteNonQuery();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                } finally {
                connection.Close();
            }

        }
    }
}
