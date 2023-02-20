using EasyPDV.Entities;
using Npgsql;
using System;
using System.Windows.Forms;

namespace EasyPDV.Model {
    internal class CancelledSaleDAO {
        string connectionString = DAO.ConnectionString;
        NpgsqlConnection connection;
        public NpgsqlCommand ReadCancelledSale() {
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try {
                connection.Open();
                cmd = new NpgsqlCommand(
                        "SELECT id AS ID, data_venda AS \"Data da venda\", array_to_string(produtos, ',') AS \"Produtos\", " +
                        "valor_venda AS \"Valor total da venda (R$)\" , meio_pagamento as \"Meio de pagamento\"" +
                        "FROM venda_cancelada " +
                        "ORDER BY id", connection);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            } finally {
                connection.Close();
            }
            return cmd;
        }

        public void DeleteCancelledSale(CancelledSale cancelledSale) {
            connection = new NpgsqlConnection(connectionString);
            try {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"DELETE FROM venda_cancelada " +
                    $"where id = {cancelledSale.ID}", connection);
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                connection.Close();
            }
        }
        public void DeleteAllCancelledSales() {
            connection = new NpgsqlConnection(connectionString);
            try {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"DELETE FROM venda_cancelada" , connection);
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                connection.Close();
            }
        }
    }
}
