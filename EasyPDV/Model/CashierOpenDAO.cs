
using Npgsql;
using System.Windows.Forms;
using System;
using EasyPDV.Entities;

namespace EasyPDV.Model
{
    internal class CashierOpenDAO
    {
        string connectionString = DAO.ConnectionString;
        CashierOpen cashier = new CashierOpen();
        public void OpenCashier(CashierOpen cashier)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try
            {

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
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
        public double InitialBalance()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            double ini = 0;
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                        $"SELECT saldo_inicial from caixa where status = true", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ini = reader.GetDouble(0);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return ini;
        }
        public bool IsCashierOpen()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            bool isOpen = false;
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand("Select id, status from caixa order by id DESC LIMIT 1", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cashier.ID = reader.GetInt32(0);
                        isOpen = (bool)reader.GetBoolean(1);
                    }
                }
                else
                {
                    isOpen = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return isOpen;
        }

        public void CloseCashier()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                if (IsCashierOpen() == true)
                {
                    NpgsqlCommand cmd;
                    try
                    {
                        cmd = new NpgsqlCommand("Update caixa set status = false where id =" + cashier.ID, connection);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else
                {
                    MessageBox.Show("Caixa já está fechado!");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
        public string ReturnEventName()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            string eventName = "";
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand("select evento from caixa where status = true", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        eventName = reader.GetString(0);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return eventName;
        }
        public string ReturnResponsibleName()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            string responsibleName = "";
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand("select responsavel from caixa where status = true", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        responsibleName = reader.GetString(0);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return responsibleName;
        }
        public int ReturnCashierNumber()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            int cashierNumber = 0;
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand("select numero from caixa where status = true", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cashierNumber = reader.GetInt16(0);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return cashierNumber;
        }

        public NpgsqlCommand ReadAll()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand("Select id as \"ID\", evento as Evento, numero as \"Número do caixa\", " +
                    "saldo_inicial as \"Saldo Inicial\", responsavel as \"Responsável\", " +
                    "case status when 'false' then 'fechado' else 'aberto' end as \"Status do caixa\" from caixa ", connection);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return cmd;
        }

        public void DeleteAllClosedCashier()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"DELETE FROM caixa where status = false", connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void ReadSome(CashierBleed cashierBleed)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try
            {

                connection.Open();
                cmd = new NpgsqlCommand(
                        "SELECT numero, responsavel, saldo_inicial from caixa", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product p = new Product();
                        cashierBleed.Number = reader.GetInt16(0);
                        cashierBleed.Responsible = reader.GetString(1);
                        cashierBleed.Value = reader.GetDouble(2);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
