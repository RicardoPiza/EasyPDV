using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Office2010.Excel;
using EasyPDV.Entities;
using Npgsql;
using System;
using System.Windows.Forms;

namespace EasyPDV.Model {
    internal class CashierBleedDAO {
        DAO dao = new DAO();
        string connectionString = DAO.ConnectionString;
        NpgsqlConnection connection;
        public void BeginMovimentation(CashierBleed cashierBleed) {
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try {
                connection.Open();
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
            } finally {
                connection.Close();
            }
        }

        public NpgsqlCommand ReadAll() {
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try {
                connection.Open();
                cmd = new NpgsqlCommand("Select id as \"ID\", evento as \"Evento\", tipo_movimentacao as \"Tipo movimentação\", responsavel as" +
                    "\"Responsável\", data as \"Data\", numero_caixa as \"Número do caixa\", descricao as \"Descrição\"," +
                    " valor as \"Valor\" from sangria", dao.Connection());
            } catch (Exception) {
                throw;
            } finally {
                connection.Close();
            }
            return cmd;
        }

        public void DeleteAllBleedCashier() {
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try {
                cmd = new NpgsqlCommand(
                    $"DELETE FROM sangria", dao.Connection());
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                connection.Close();
            }
        }
        public double TotalReinforcement() { 
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            double reinf = 0;
            NpgsqlCommand cmd;
            try {
                connection.Open();
                cmd = new NpgsqlCommand(
                        $"select sum(valor) from sangria s where s.tipo_movimentacao = 'Reforço'", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        reinf = reader.GetDouble(0);
                    }
                }
            } catch (Exception) {
                reinf= 0;
            } finally {
                connection.Close();
            }
            return reinf;
        }
        public double TotalWithdraw() {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            double withdraw = 0;
            NpgsqlCommand cmd;
            try {
                connection.Open();
                cmd = new NpgsqlCommand(
                        $"select sum(valor) from sangria s where s.tipo_movimentacao = 'Retirada'", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        withdraw = reader.GetDouble(0);
                    }
                }
            } catch (Exception) {
                withdraw= 0;
            } finally {
                connection.Close();
            }
            return withdraw;
        }
    }
}
