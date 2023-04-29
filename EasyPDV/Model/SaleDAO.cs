using DocumentFormat.OpenXml.Office2010.Excel;
using EasyPDV.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EasyPDV.Model
{
    internal class SaleDAO
    {
        string connectionString = DAO.ConnectionString;
        NpgsqlConnection connection;

        public void InsertSale(RegularSale sale)
        {
            connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand("" +
                    "INSERT INTO venda(valor_venda, data_venda, produtos, meio_pagamento)" +
                    " VALUES (@vv, @dv, @p, @mp)", connection);
                cmd.Parameters.AddWithValue("vv", sale.SalePrice);
                cmd.Parameters.AddWithValue("dv", sale.SaleDate);
                cmd.Parameters.AddWithValue("p", sale.Products);
                cmd.Parameters.AddWithValue("mp", sale.PaymentMethod);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public NpgsqlCommand ReadSale()
        {
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                    "SELECT v.id AS ID, TO_char(data_venda,'dd/mm/yyyy hh24:mi') AS \"Data da venda\", array_to_string(produtos, ',') AS \"Produtos\", " +
                    "to_char(valor_venda, '9999999999999999D99') AS \"Valor total da venda (R$)\", meio_pagamento as \"Meio de pagamento\", numero as \"Numero Caixa\" " +
                    "FROM venda v, caixa c where c.status = 'true' " +
                    "ORDER BY id", connection);
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
        public Sale Get(int id)
        {
            connection = new NpgsqlConnection(connectionString);
            RegularSale sale = new RegularSale();
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                    $"SELECT *from venda where id = {id} ", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product p = new Product();
                        sale.ID = (int)reader.GetInt16(0);
                        sale.SaleDate = reader.GetDateTime(1);
                    }
                }
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
            return sale;
        }
        public void DeleteSale(RegularSale v)
        {
            connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"DELETE FROM venda " +
                    $"where id = {v.ID}", connection);
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
        public void DeleteAllSales()
        {
            connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"truncate venda restart identity", connection);
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
        public void Update(List<string> products, int id, double valor)
        {
            connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand($"update venda set produtos = @p, valor_venda = @vv where id = @id", connection);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("p", products);
                cmd.Parameters.AddWithValue("vv", valor);
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
        public List<string> GetSaleProducts(int id)
        {
            List<string> productsName = new List<string>();
            connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(
                    $"select produtos from venda where id = {id}", connection))
                {

                    string[] textArray = (string[])cmd.ExecuteScalar();
                    productsName.AddRange(textArray);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return productsName;
        }

        public double GetSaleValue(int id)
        {
            double total = 0;
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                    $"select valor_venda from venda where id = {id}", connection);
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

    }

}
