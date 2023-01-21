

using EasyPDV.Entities;
using Npgsql;
using System.Windows.Forms;
using System;

namespace EasyPDV.DAO {
    internal class IndividualSaleDAO {
        DAO dao = new DAO();

        public void InsertIndividualSale(IndividualSale individualSale) {
            try {
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand("" +
                    "INSERT INTO venda_individual(data, produto, valor, meio_pagamento)" +
                    " VALUES (@dv, @p, @v, @mp)", dao.Connection());
                cmd.Parameters.AddWithValue("v", individualSale.SalePrice);
                cmd.Parameters.AddWithValue("dv", DateTime.Parse(individualSale.SaleDate));
                cmd.Parameters.AddWithValue("p", individualSale.Product);
                cmd.Parameters.AddWithValue("mp", individualSale.PaymentMethod);
                cmd.ExecuteNonQuery();
            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
            dao.Connection().Close();
        }
        public NpgsqlCommand ReadIndividualSale() {
            NpgsqlCommand cmd;
            try {
                cmd = new NpgsqlCommand(
                    "select produto as \"Produto\", count(produto) as \"Total vendido\"," +
                    "sum(valor) AS \"Fatura do produto(R$)\" " +
                    "from venda_individual group by produto ", dao.Connection());
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
            dao.Connection().Close();
            return cmd;
        }
        public double ReadTotalIndividualSale() {
            NpgsqlCommand cmd;
            double value = 0;
            try {
                cmd = new NpgsqlCommand(
                    "select sum(valor) as Total " +
                    "from venda_individual ", dao.Connection());
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        value = (double)reader.GetDouble(0);
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message + "\nNenhuma ocorrencia de venda até o momento");
                return 0;
            }
            dao.Connection().Close();
            return value;
        }
        public void DeleteAllIndividualSales() {
            try {
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"DELETE FROM venda_individual", dao.Connection());
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            dao.Connection().Close();
        }
    }
}
