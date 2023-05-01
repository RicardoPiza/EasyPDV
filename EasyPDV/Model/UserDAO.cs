using EasyPDV.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPDV.Model
{
    internal class UserDAO
    {
        string connectionString = DAO.ConnectionString;
        NpgsqlConnection connection;

        public void CreateUser(User user)
        {
            connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand("" +
                    "INSERT INTO usuario(login, nome, senha, admin, data_criacao, ativo)" +
                    " VALUES (@log, @n, @s, @adm, @dc, @a )", connection);
                cmd.Parameters.AddWithValue("log", user.Login);
                cmd.Parameters.AddWithValue("n", user.Name);
                cmd.Parameters.AddWithValue("s", user.Password);
                cmd.Parameters.AddWithValue("adm", user.Admin);
                cmd.Parameters.AddWithValue("dc", user.CreationDate);
                cmd.Parameters.AddWithValue("a", user.Active);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public User Get(int id)
        {
            connection = new NpgsqlConnection(connectionString);
            User user = new User();
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                    $"SELECT * from usuario where id = {id} ", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.Id = reader.GetInt32(0);
                        user.Login = reader.GetString(1);
                        user.Name = reader.GetString(2);
                        user.Password = reader.GetString(3);
                        user.Admin = reader.GetBoolean(4);
                        user.CreationDate = reader.GetDateTime(5);
                        user.Active = reader.GetBoolean(6);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
            return user;
        }
        public User GetByLogin(string login)
        {
            connection = new NpgsqlConnection(connectionString);
            User user = new User();
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                    $"SELECT * from usuario where login = '{login}' ", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.Id = reader.GetInt32(0);
                        user.Login = reader.GetString(1);
                        user.Name = reader.GetString(2);
                        user.Password = reader.GetString(3);
                        user.Admin = reader.GetBoolean(4);
                        user.CreationDate = reader.GetDateTime(5);
                        user.Active = reader.GetBoolean(6);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
            return user;
        }
        public bool CheckLogin(string login)
        {
            bool userExists = false;
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                    $"SELECT login from usuario where login = '{login.Trim().ToLower()}' ", connection);
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetString(0) != null)
                        {
                            userExists = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return userExists;
        }
    }
}
