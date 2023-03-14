using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2010.Excel;
using EasyPDV.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace EasyPDV.Model
{
    internal class ReversedSaleDAO
    {
        string connectionString = DAO.ConnectionString;
        NpgsqlConnection connection;

        public void InsertChangedSale(ReversedSale changeSale)
        {
            connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand("" +
                    "INSERT INTO troca(produto_de, produto_para, tipo_troca, data, saldo)" +
                    " VALUES (@pd, @pp, @tt, @d, @s)", connection);
                cmd.Parameters.AddWithValue("pd", changeSale.ProductChangeFrom);
                cmd.Parameters.AddWithValue("pp", changeSale.ProductChangeTo);
                cmd.Parameters.AddWithValue("tt", changeSale.ChangeType);
                cmd.Parameters.AddWithValue("d", changeSale.SaleDate);
                cmd.Parameters.AddWithValue("s", changeSale.Balance);
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

        public NpgsqlCommand ReadSaleReversal()
        {
            connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand cmd;
            try
            {
                connection.Open();
                cmd = new NpgsqlCommand(
                    "SELECT id AS ID, produto_de as \"Troca De\", produto_para as \"Troca Para\","+ 
                    "TO_char(data, 'dd/mm/yyyy hh24:mi') AS \"Data e Hora\", to_char(saldo, '9999999999999999D99') AS \"Saldo\" "+
                    "FROM troca ORDER BY id", connection);
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
            return cmd;
        }
        public void DeleteReversedSale(ReversedSale reversedSale)
        {
            connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"DELETE FROM troca " +
                    $"where id = {reversedSale.ID}", connection);
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
        public void DeleteAllReversedSales()
        {
            connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"truncate troca restart identity", connection);
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
    }
}
