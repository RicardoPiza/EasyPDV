
using Npgsql;
using System.Windows.Forms;
using System;
using EasyPDV.Entities;
using System.Collections.Generic;

namespace EasyPDV.Model {
    internal class CashierOpenDAO {
        DAO dao = new DAO();
        CashierOpen cashier = new CashierOpen();
        public void OpenCashier(CashierOpen cashier) {
            NpgsqlCommand cmd;
            try {
                cmd = new NpgsqlCommand(
                    "INSERT INTO caixa(evento, numero, saldo_inicial, responsavel, data, status) " +
                    $"VALUES(@ev, @n, @si, @res, @d, @st)", dao.Connection());
                cmd.Parameters.AddWithValue("ev", cashier.EventName);
                cmd.Parameters.AddWithValue("n", cashier.Number);
                cmd.Parameters.AddWithValue("si", cashier.InitialBalance);
                cmd.Parameters.AddWithValue("res", cashier.Responsible);
                cmd.Parameters.AddWithValue("d", cashier.Date);
                cmd.Parameters.AddWithValue("st", cashier.Status);
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            dao.Connection().Close();
        }
        public bool IsCashierOpen() {
            bool isOpen = false;
            NpgsqlCommand cmd;
            try {
                cmd = new NpgsqlCommand("Select id, status from caixa order by id DESC LIMIT 1", dao.Connection());
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
            dao.Connection().Close();
            return isOpen;
        }
        public void CloseCashier() {
            if (IsCashierOpen() == true) {
                NpgsqlCommand cmd;
                try {
                    cmd = new NpgsqlCommand("Update caixa set status = false where id =" + cashier.ID, dao.Connection());
                    cmd.ExecuteNonQuery();
                } catch (Exception) {
                    throw;
                }
                dao.Connection().Close();
            } else {
                MessageBox.Show("Caixa já está fechado!");
            }

        }
        public string ReturnEventName() {
            string eventName = "";
            NpgsqlCommand cmd;
            try {
                cmd = new NpgsqlCommand("select evento from caixa where id = " + cashier.ID, dao.Connection());
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        eventName= reader.GetString(0);
                    }
                }
            } catch(Exception ex) {
                throw;
            }
            dao.Connection().Close();
            return eventName;
        }
        public NpgsqlCommand ReadAll() {
            NpgsqlCommand cmd;
            try {
                cmd = new NpgsqlCommand("Select id as \"ID\", evento as Evento, numero as \"Número do caixa\", " +
                    "saldo_inicial as \"Saldo Inicial\", responsavel as \"Responsável\", " +
                    "case status when 'false' then 'fechado' else 'aberto' end as \"Status do caixa\" from caixa ", dao.Connection());
            } catch (Exception ex) {
                throw;
            }
            dao.Connection().Close();
            return cmd;
        }
        public void DeleteAllClosedCashier() {
            try {
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"DELETE FROM caixa where status = false", dao.Connection());
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            dao.Connection().Close();
        }
        public void ReadSome(CashierBleed cashierBleed) {
            NpgsqlCommand cmd;
            try {
                cmd = new NpgsqlCommand(
                    "SELECT numero, responsavel, saldo_inicial from caixa", dao.Connection());
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
            }
            dao.Connection().Close();
        }
    }
}
