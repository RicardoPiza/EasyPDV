using DocumentFormat.OpenXml.Office2010.Excel;
using EasyPDV.Entities;
using Npgsql;
using System;

namespace EasyPDV.Model {
    internal class CashierBleedDAO {
        DAO dao = new DAO();
        public void BeginMovimentation(CashierBleed cashierBleed) {
            NpgsqlCommand cmd;
            try {
                cmd = new NpgsqlCommand("INSERT INTO sangria(evento, tipo_movimentacao, responsavel, data, " +
                        "numero_caixa, descricao, valor) VALUES(@ev, @t,@resp,@d,@nc,@desc,@v)", dao.Connection());
                cmd.Parameters.AddWithValue("ev", cashierBleed.EventName);
                cmd.Parameters.AddWithValue("t", cashierBleed.Type);
                cmd.Parameters.AddWithValue("resp", cashierBleed.Responsible);
                cmd.Parameters.AddWithValue("d", cashierBleed.Date);
                cmd.Parameters.AddWithValue("nc", cashierBleed.Number);
                cmd.Parameters.AddWithValue("desc", cashierBleed.Description);
                cmd.Parameters.AddWithValue("v", cashierBleed.Value);
                cmd.ExecuteNonQuery();
            } catch (System.Exception) {

                throw;
            }
            dao.Connection().Close();
        }
        public NpgsqlCommand ReadAll() {
            NpgsqlCommand cmd;
            try {
                cmd = new NpgsqlCommand("Select id as \"ID\", evento as \"Evento\", tipo_movimentacao as \"Tipo movimentação\", responsavel as"+
                "\"Responsável\", data as \"Data\", numero_caixa as \"Número do caixa\", descricao as \"Descrição\","+
                " valor as \"Valor\" from sangria", dao.Connection());
            } catch (Exception) {
                throw;
            }
            dao.Connection().Close();
            return cmd;
        }
    }
}
