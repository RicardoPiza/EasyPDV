using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPDV.DAO {
    internal class VendaCanceladaDAO {
        DAO dao= new DAO();
        public VendaCanceladaDAO() {
            dao.Connection();
        }
        public NpgsqlCommand ReadVendaCancelada() {
            NpgsqlCommand cmd;
            try {
                cmd = new NpgsqlCommand(
                    "SELECT id AS ID, data_venda AS \"Data da venda\", produtos[1] AS \"Produtos\", " +
                    "valor_venda AS \"Valor total da venda (R$)\" , meio_pagamento as \"Meio de pagamento\"" +
                    "FROM venda_cancelada " +
                    "ORDER BY id", dao.Connection());
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
            return cmd;
        }
    }
}
