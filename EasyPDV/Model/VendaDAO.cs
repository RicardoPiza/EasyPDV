﻿using EasyPDV.Entities;
using Npgsql;
using System;
using System.Windows.Forms;

namespace EasyPDV.DAO {
    internal class VendaDAO {
        DAO dao = new DAO();
        public VendaDAO() {
            dao.Connection();
        }

        public void InsertVenda(Venda v) {
            try {
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand("" +
                    "INSERT INTO venda(valor_venda, data_venda, produtos, meio_pagamento)" +
                    " VALUES (@vv, @dv, @p, @mp)", dao.Connection());
                cmd.Parameters.AddWithValue("vv", v.ValorVenda);
                cmd.Parameters.AddWithValue("dv", DateTime.Parse(v.DataVenda));
                cmd.Parameters.AddWithValue("p", v.Produtos);
                cmd.Parameters.AddWithValue("mp", v.MeioPagamento);
                cmd.ExecuteNonQuery();
            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }
        public NpgsqlCommand ReadVenda() {
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
            return cmd;
        }
        public void DeleteVenda(Venda v) {
            try {
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"DELETE FROM venda " +
                    $"where id = {v.ID}", dao.Connection());
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

    }

}