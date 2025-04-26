using Npgsql;
using System;
using System.Windows.Forms;

namespace EasyPDV.Model
{
    internal class DAO
    {
        //private static string User = "RicardoPiza";
        //private static string Password = "aewvsf45243253";
        //private static string Host = "postgres-1.cwaca8kyoaaw.sa-east-1.rds.amazonaws.com:5432";
        //private static string Database = "easypdv";
        //private static string ConnectionString =
        private static string User = "postgres";
        private static string Password = "45243253";
        private static string Host = "localhost:5432";
        private static string Database = "postgres";
        public static string ConnectionString =
            $"User ID={User}; " +
            $"Password={Password}; " +
            $"Host={Host}; " +
            $"Database={Database}";
        public NpgsqlConnection Connection()
        {
            var conn = new NpgsqlConnection(ConnectionString);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return conn;
        }

    }
}
