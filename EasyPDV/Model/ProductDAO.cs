using EasyPDV.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace EasyPDV.Model
{
    internal class ProductDAO
    {
        string connectionString = DAO.ConnectionString;

        public NpgsqlCommand Read(string status)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                    "SELECT id AS \"ID\", nome AS \"Nome do produto\", " +
                    "to_char(preco, '9999999999999999D99') AS \"Preço\", imagem as \"Imagem\", estoque AS \"Estoque\", descricao as \"Descrição\" " +
                    "FROM produto " +
                   $"WHERE status  = '{status}' " +
                    "ORDER by id", connection);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                connection.Close();
            }
            return cmd;
        }
        public List<Product> ReadAll()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            List<Product> list = new List<Product>();
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                        "SELECT id, nome, preco, estoque from produto order by nome", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product p = new Product();
                        p.ID = (int)reader.GetInt16(0);
                        p.Name = reader.GetString(1);
                        p.Price = (double)reader.GetDouble(2);
                        list.Add(p);
                    }
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public List<Product> ReadActivated()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            List<Product> list = new List<Product>();
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                        "SELECT id, nome, preco, estoque from produto where status  = 'ativado' order by nome", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product p = new Product();
                        p.ID = (int)reader.GetInt16(0);
                        p.Name = reader.GetString(1);
                        p.Price = (double)reader.GetDouble(2);
                        list.Add(p);
                    }
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public Image GrabImage(Product product)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            Image image = null;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                        $"SELECT imagem FROM produto where id = {product.ID}", connection);
                byte[] productImageByte = cmd.ExecuteScalar() as byte[];
                if (productImageByte != null)
                {
                    using (MemoryStream productImageStream = new System.IO.MemoryStream(productImageByte))
                    {
                        ImageConverter imageConverter = new System.Drawing.ImageConverter();
                        image = imageConverter.ConvertFrom(productImageByte) as System.Drawing.Image;
                        image = System.Drawing.Image.FromStream(productImageStream);
                    }
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                connection.Close();
            }
            return image;
        }
        public void Insert(Product product)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            Image originalImage = Image.FromFile(product.Image);
            Image resizedImage = new Bitmap(originalImage, new Size(64, 64));
            resizedImage.Save("resized.png", ImageFormat.Png);
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                        "INSERT INTO Produto(nome, preco, imagem, estoque, status) " +
                        $"VALUES(@n, @p,@i,@e,@s)", connection);
                cmd.Parameters.AddWithValue("n", product.Name);
                cmd.Parameters.AddWithValue("p", product.Price);
                byte[] binaryData = System.IO.File.ReadAllBytes("resized.png");
                cmd.Parameters.AddWithValue("i", binaryData);
                cmd.Parameters.AddWithValue("e", product.StockQuantity);
                cmd.Parameters.AddWithValue("s", product.Status);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
        }
        public void Update(Product product)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    "UPDATE produto " +
                    "SET nome = @n, preco = @p, estoque = @e, descricao = @d" +
                    $" WHERE id = {product.ID}", connection);
                cmd.Parameters.AddWithValue("n", product.Name);
                cmd.Parameters.AddWithValue("p", product.Price);
                cmd.Parameters.AddWithValue("e", product.StockQuantity);
                cmd.Parameters.AddWithValue("d", product.Description);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteProduct(Product p)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"DELETE FROM produto " +
                    $"WHERE ID = {p.ID}", connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public void SubtractStock(Product product)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    "UPDATE produto SET estoque = estoque - 1 " +
                    $"WHERE id = {product.ID}", connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
        public void SumStock(Product product)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    "UPDATE produto SET estoque = estoque + 1 " +
                    $"WHERE nome = '{product.Name}'", connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
        public int CheckStock(Product product)
        {
            int productStockQuantity = 0;
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"SELECT estoque from produto where nome = '{product.Name}'", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productStockQuantity = reader.GetInt32(0);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return productStockQuantity;
        }
        public void ChangeStatus(Product p)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    "UPDATE produto set status = (CASE status " +
                    "WHEN 'desativado' THEN 'ativado'" +
                    "WHEN 'ativado' THEN 'desativado' " +
                    "else 'ativado' end) " +
                    $"WHERE id = {p.ID};", connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
        public string ReadStatus(Product p)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            string status = "";
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                        $"SELECT status from produto where id= {p.ID}", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        status = reader.GetString(0);
                    }
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                connection.Close();
            }
            return status;
        }
        public string GetDesc(Product p)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            string desc = "";
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                        $"SELECT descricao from produto where id= {p.ID}", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        desc = reader.GetString(0);
                    }
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
            finally
            {
                connection.Close();
            }
            return desc;
        }
        public double GetPrice(string name)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            double price = 0;
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                        $"SELECT preco from produto where nome = '{name}' limit 1", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        price = reader.GetDouble(0);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return price;
        }
        public int GetID(Product p)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            int id = 0;
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                        $"SELECT id from produto where nome = '{p.Name}' limit 1", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return id;
        }
    }
}
