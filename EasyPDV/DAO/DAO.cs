using Npgsql;
using System;
using System.Windows.Forms;

namespace EasyPDV.DAO {
    internal class DAO {
        private static string User = "postgres";
        private static string Password = "45243253";
        private static string Host = "localhost:5432";
        private static string Database = "postgres;";
        private static string ConnectionString = 
            $"User ID={User}; " +
            $"Password={Password}; " +
            $"Host={Host}; " +
            $"Database={Database}" ;
        public NpgsqlConnection Connection() {
            var conn = new NpgsqlConnection(ConnectionString);
            try {
                conn.Open();
            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
            return conn;
        }

    }
}
