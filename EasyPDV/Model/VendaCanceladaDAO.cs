using EasyPDV.Entities;
using Npgsql;
using System;
using System.Windows.Forms;

namespace EasyPDV.DAO {
    internal class VendaCanceladaDAO {
        DAO dao= new DAO();
        public NpgsqlCommand ReadVendaCancelada() {
            NpgsqlCommand cmd;
            try {
                cmd = new NpgsqlCommand(
                    "SELECT id AS ID, data_venda AS \"Data da venda\", array_to_string(produtos, ',') AS \"Produtos\", " +
                    "valor_venda AS \"Valor total da venda (R$)\" , meio_pagamento as \"Meio de pagamento\"" +
                    "FROM venda_cancelada " +
                    "ORDER BY id", dao.Connection());
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
            dao.Connection().Close();
            return cmd;
        }
        public void DeleteVendaCancelada(VendaCancelada vc) {
            try {
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"DELETE FROM venda_cancelada " +
                    $"where id = {vc.ID}", dao.Connection());
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            dao.Connection().Close();
        }
    }
}
