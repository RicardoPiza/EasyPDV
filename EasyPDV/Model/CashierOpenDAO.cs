
using Npgsql;
using System.Windows.Forms;
using System;
using EasyPDV.Entities;
using System.Collections.Generic;

namespace EasyPDV.Model {
    internal class CashierOpenDAO {
        string connectionString = DAO.ConnectionString;
        NpgsqlConnection connection;
        CashierOpen cashier = new CashierOpen();
        public void OpenCashier(CashierOpen cashier) {
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try {

                connection.Open();
                cmd = new NpgsqlCommand(
                        "INSERT INTO caixa(evento, numero, saldo_inicial, responsavel, data, status) " +
                        $"VALUES(@ev, @n, @si, @res, @d, @st)", connection);
                cmd.Parameters.AddWithValue("ev", cashier.EventName);
                cmd.Parameters.AddWithValue("n", cashier.Number);
                cmd.Parameters.AddWithValue("si", cashier.InitialBalance);
                cmd.Parameters.AddWithValue("res", cashier.Responsible);
                cmd.Parameters.AddWithValue("d", cashier.Date);
                cmd.Parameters.AddWithValue("st", cashier.Status);
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                connection.Close();
            }
        }

        public bool IsCashierOpen() {
            connection = new NpgsqlConnection(connectionString);
            bool isOpen = false;
            NpgsqlCommand cmd;
            try {
                connection.Open();
                cmd = new NpgsqlCommand("Select id, status from caixa order by id DESC LIMIT 1", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        cashier.ID = reader.GetInt32(0);
                        isOpen = (bool)reader.GetBoolean(1);
                    }
                } else {
                    isOpen = false;
                }
            } catch (Exception) {
                throw;
            }
            return isOpen;
        }

        public void CloseCashier() {
            connection = new NpgsqlConnection(connectionString);
            try {
                connection.Open();
                if (IsCashierOpen() == true) {
                    NpgsqlCommand cmd;
                    try {
                        cmd = new NpgsqlCommand("Update caixa set status = false where id =" + cashier.ID, connection);
                        cmd.ExecuteNonQuery();
                    } catch (Exception) {
                        throw;
                    }
                } else {
                    MessageBox.Show("Caixa já está fechado!");
                }
            } catch (Exception) {
                throw;
            } finally {
                connection.Close();
            }
        }
        public string ReturnEventName() {
            connection = new NpgsqlConnection(connectionString);
            string eventName = "";
            NpgsqlCommand cmd;
            try {
                connection.Open();
                cmd = new NpgsqlCommand("select evento from caixa where id = " + cashier.ID, connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        eventName = reader.GetString(0);
                    }
                }
            } catch (Exception ex) {
                throw;
            } finally {
                connection.Close();
            }
            return eventName;
        }

        public NpgsqlCommand ReadAll() {
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try {
                connection.Open();
                cmd = new NpgsqlCommand("Select id as \"ID\", evento as Evento, numero as \"Número do caixa\", " +
                    "saldo_inicial as \"Saldo Inicial\", responsavel as \"Responsável\", " +
                    "case status when 'false' then 'fechado' else 'aberto' end as \"Status do caixa\" from caixa ", connection);
            } catch (Exception ex) {
                throw;
            } finally {
                connection.Close();
            }
            return cmd;
        }

        public void DeleteAllClosedCashier() {
            connection = new NpgsqlConnection(connectionString);
            try {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"DELETE FROM caixa where status = false", connection);
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                connection.Close();
            }
        }

        public void ReadSome(CashierBleed cashierBleed) {
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try {

                connection.Open();
                cmd = new NpgsqlCommand(
                        "SELECT numero, responsavel, saldo_inicial from caixa", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        Product p = new Product();
                        cashierBleed.Number = reader.GetInt16(0);
                        cashierBleed.Responsible = reader.GetString(1);
                        cashierBleed.Value = reader.GetDouble(2);
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                connection.Close();
            }
        }
    }
}
