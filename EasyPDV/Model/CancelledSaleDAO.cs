﻿using EasyPDV.Entities;
using Npgsql;
using System;
using System.Windows.Forms;

namespace EasyPDV.DAO {
    internal class CancelledSaleDAO {
        DAO dao= new DAO();
        public NpgsqlCommand ReadCancelledSale() {
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
        public void DeleteCancelledSale(CancelledSale cancelledSale) {
            try {
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"DELETE FROM venda_cancelada " +
                    $"where id = {cancelledSale.ID}", dao.Connection());
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            dao.Connection().Close();
        }
    }
}