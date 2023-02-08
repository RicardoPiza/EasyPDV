using EasyPDV.Entities;
using Npgsql;
using System.Windows.Forms;
using System;

namespace EasyPDV.Model {
    internal class IndividualSaleDAO {
        string connectionString = DAO.ConnectionString;
        NpgsqlConnection connection;

        public void InsertIndividualSale(IndividualSale individualSale) {
            connection = new NpgsqlConnection(connectionString);
            try {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand("" +
                    "INSERT INTO venda_individual(data, produto, valor, meio_pagamento)" +
                    " VALUES (@dv, @p, @v, @mp)", connection);
                cmd.Parameters.AddWithValue("v", individualSale.SalePrice);
                cmd.Parameters.AddWithValue("dv", DateTime.Parse(individualSale.SaleDate));
                cmd.Parameters.AddWithValue("p", individualSale.Product);
                cmd.Parameters.AddWithValue("mp", individualSale.PaymentMethod);
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                throw;
            } finally {
                connection.Close();
            }
        }

        public NpgsqlCommand ReadIndividualSale() {
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try {
                connection.Open();
                cmd = new NpgsqlCommand(
                    "select produto as \"Produto\", count(produto) as \"Total vendido\"," +
                    "sum(valor) AS \"Fatura do produto(R$)\" " +
                    "from venda_individual group by produto ", connection);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            } finally {
                connection.Close();
            }
            return cmd;
        }

        public double ReadTotalIndividualSale() {
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            double value = 0;
            try {
                connection.Open();
                cmd = new NpgsqlCommand(
                    "select sum(valor) as Total " +
                    "from venda_individual ", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        value = (double)reader.GetDouble(0);
                    }
                }
            } catch (Exception) {
                MessageBox.Show("\nNenhuma ocorrencia de venda até o momento");
                return 0;
            } finally { 
                connection.Close();
            }
            return value;
        }

        public void DeleteAllIndividualSales() {
            connection = new NpgsqlConnection(connectionString);
                try {
                connection.Open();
                NpgsqlCommand cmd;
                    cmd = new NpgsqlCommand(
                        $"DELETE FROM venda_individual", connection);
                    cmd.ExecuteNonQuery();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                } finally {
                connection.Close();
            }
        }
        public void DeleteIndividualSale(string individualSale) {
            connection = new NpgsqlConnection(connectionString);
            try {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"delete from venda_individual where id = (Select id from venda_individual where produto = '{individualSale}' LIMIT 1)", connection);
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                connection.Close();
            }
        }
    }
}
