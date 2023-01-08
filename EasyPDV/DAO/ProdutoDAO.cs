using EasyPDV.Entities;
using Npgsql;
using System;
using System.Windows.Forms;

namespace EasyPDV.DAO {
    internal class ProdutoDAO {
        DAO dao = new DAO();
        public ProdutoDAO() {
            dao.Connection();
        }
        public NpgsqlCommand ReadAll() {
            NpgsqlCommand cmd;
            try {
                cmd = new NpgsqlCommand("" +
                    "SELECT id AS \"ID\", nome AS \"Nome do produto\", " +
                    "preco AS \"Preço\" FROM produto " +
                    "ORDER by id", dao.Connection());
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
            return cmd;
        }
        public void Insert(Produto p) {
            NpgsqlCommand cmd;
            try {
                cmd = new NpgsqlCommand(
                    "INSERT INTO Produto(Nome, Preco) " +
                    $"VALUES(@n, @p)", dao.Connection());
                cmd.Parameters.AddWithValue("n", p.Nome);
                cmd.Parameters.AddWithValue("p", p.Preco);
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        public void Update(Produto p) {
            try {
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"UPDATE produto " +
                    $"SET nome = @n, preco = @p WHERE id " +
                    $"= {p.ID}", dao.Connection());
                cmd.Parameters.AddWithValue("n", p.Nome);
                cmd.Parameters.AddWithValue("p", p.Preco);
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        public void Delete(Produto p) {
            try {
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    $"DELETE FROM produto " +
                    $"WHERE ID = {p.ID}", dao.Connection());
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
