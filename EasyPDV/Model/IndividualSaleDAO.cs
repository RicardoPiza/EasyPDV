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
                    "INSERT INTO venda_individual(data, produto, valor, meio_pagamento)" +
                    " VALUES (@dv, @p, @v, @mp)", connection);
                cmd.Parameters.AddWithValue("v", individualSale.SalePrice);
                cmd.Parameters.AddWithValue("dv", individualSale.SaleDate);
                cmd.Parameters.AddWithValue("p", individualSale.Product);
                cmd.Parameters.AddWithValue("mp", individualSale.PaymentMethod);
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

        public NpgsqlCommand ReadIndividualSale()
        {
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                    "select produto as \"Produto\", count(produto) as \"Quantidade vendida\", to_char(valor, '9999999999999999D99') as \"Valor unitário(R$)\"," +
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
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
            return total;
        }

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
        public void DeleteIndividualSale(string product)
        {
            connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"delete from venda_individual where id = (Select id from venda_individual where produto = '{product}' LIMIT 1)", connection);
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
        public List<Product> ReadSoldProducts()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            List<Product> list = new List<Product>();
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                        "select produto from venda_individual group by produto ", connection);
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
