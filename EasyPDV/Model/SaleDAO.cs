using EasyPDV.Entities;
using Npgsql;
using System;
using System.Windows.Forms;

namespace EasyPDV.DAO {
    internal class SaleDAO {
        DAO dao = new DAO();

        public void InsertSale(Sale sale) {
            try {
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand("" +
                    "INSERT INTO venda(valor_venda, data_venda, produtos, meio_pagamento)" +
                    " VALUES (@vv, @dv, @p, @mp)", dao.Connection());
                cmd.Parameters.AddWithValue("vv", sale.SalePrice);
                cmd.Parameters.AddWithValue("dv", DateTime.Parse(sale.SaleDate));
                cmd.Parameters.AddWithValue("p", sale.Products);
                cmd.Parameters.AddWithValue("mp", sale.PaymentMethod);
                cmd.ExecuteNonQuery();
            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
            dao.Connection().Close();
        }
        public NpgsqlCommand ReadSale() {
            NpgsqlCommand cmd;
            try {
                cmd = new NpgsqlCommand(
                    "SELECT id AS ID, data_venda AS \"Data da venda\", array_to_string(produtos, ',') AS \"Produtos\", " +
                    "valor_venda AS \"Valor total da venda (R$)\", meio_pagamento as \"Meio de pagamento\" " +
                    "FROM venda " +
                    "ORDER BY id", dao.Connection());
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
            dao.Connection().Close();
            return cmd;
        }
        public void DeleteVenda(Sale v) {
            try {
                NpgsqlCommand cmd; 
                cmd = new NpgsqlCommand(
                    $"DELETE FROM venda " +
                    $"where id = {v.ID}", dao.Connection());
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            dao.Connection().Close();
        }

    }

}
