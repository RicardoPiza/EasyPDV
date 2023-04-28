using EasyPDV.Entities;
using Npgsql;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace EasyPDV.Model
{
    internal class IndividualSaleDAO
    {
        string connectionString = DAO.ConnectionString;
        NpgsqlConnection connection;

        public void InsertIndividualSale(IndividualSale individualSale)
        {
            connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand("" +
                    "INSERT INTO venda_individual(data, produto, valor, meio_pagamento, id_venda)" +
                    " VALUES (@dv, @p, @v, @mp, @idv)", connection);

                cmd.Parameters.AddWithValue("v", individualSale.SalePrice);
                cmd.Parameters.AddWithValue("dv", individualSale.SaleDate);
                cmd.Parameters.AddWithValue("p", individualSale.Product);
                cmd.Parameters.AddWithValue("mp", individualSale.PaymentMethod);
                cmd.Parameters.AddWithValue("idv", individualSale.ExternalSaleID);
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
        public bool HasProduct(string product, int id)
        {
            bool hasProduct = false;
            connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"select * from venda_individual where id_venda = '{id}' and produto = '{product}' limit 1", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString(2) != "")
                    {
                        hasProduct = true; 
                        break;
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
            return hasProduct;
        }

        public NpgsqlCommand ReadIndividualSale()
        {
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                    "select produto as \"Produto\", count(produto) as \"Quantidade vendida\"," +
                    "to_char(valor, '9999999999999999D99') as \"Valor unitário(R$)\"," +
                    "to_char(sum(valor), '9999999999999999D99') AS \"Total faturado(R$)\" " +
                    "from venda_individual group by valor, produto ", connection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
            return cmd;
        }

        public double ReadTotalIndividualSale()
        {
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            double value = 0;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                    "select sum(valor) as Total " +
                    "from venda_individual ", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        value = (double)reader.GetDouble(0);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("\nNenhuma ocorrencia de venda até o momento");
                return 0;
            }
            finally
            {
                connection.Close();
            }
            return value;
        }
        public double ReadSumByPaymentMethod(string paymentMethod)
        {
            double total = 0;
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                    $"select sum(valor) from venda_individual where meio_pagamento = '{paymentMethod}'", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        total = reader.GetDouble(0);
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }
        public NpgsqlCommand ReadBySaleId(int id)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                        $"SELECT id_venda, produto, valor, meio_pagamento from venda_individual where id_venda  = {id} order by produto", connection);
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
<<<<<<< HEAD
        public int ReadTotalIndividualSoldProduct(string productName, int id)
=======
        public int ReadTotalIndividualSoldProduct(string productName)
>>>>>>> 629ac5ecaf3838e43e98063d326c5c61ab09f132
        {
            int total = 0;
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                    $"select count(produto) from venda_individual where produto  = '{productName}' and id_venda = {id}", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        total = reader.GetInt16(0);
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }
        public int GetExternalSaleId()
        {
            int value = 0;
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                    $"select id from venda order by data_venda desc limit 1", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        value = reader.GetInt16(0);
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
            return value;
        }
<<<<<<< HEAD
        public string GetPaymentMethod(int id)
        {
            string value = "";
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                    $"select meio_pagamento from venda_individual where id_venda = {id} order by data desc limit 1", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        value = reader.GetString(0);
                    }
                }
            }
            catch (Exception)
            {
                return "";
            }
            finally
            {
                connection.Close();
            }
            return value;
        }
=======
>>>>>>> 629ac5ecaf3838e43e98063d326c5c61ab09f132

        public void DeleteAllIndividualSales()
        {
            connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"truncate venda_individual restart identity", connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void DeleteIndividualSale(string product, int id)
        {
            connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"delete from venda_individual where id = (select id from venda_individual where id_venda " +
                    $"= '{id}' and produto = '{product}' limit 1)", connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public List<Product> ReadSoldProducts(int saleId)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            List<Product> list = new List<Product>();
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                        $"select produto from venda_individual where id_venda = {saleId} group by produto ", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product p = new Product();
                        p.Name = reader.GetString(0);
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
    }
}
