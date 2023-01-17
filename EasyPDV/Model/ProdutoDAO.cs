using DocumentFormat.OpenXml.Office2010.Excel;
using EasyPDV.Entities;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EasyPDV.DAO {
    internal class ProdutoDAO {
        DAO dao = new DAO();
        public ProdutoDAO() {
            dao.Connection();
        }
        public NpgsqlCommand Read() {
            NpgsqlCommand cmd;
            try {
                cmd = new NpgsqlCommand(
                    "SELECT id AS \"ID\", nome AS \"Nome do produto\", " +
                    "preco AS \"Preço\", imagem as \"Imagem\", estoque AS \"Estoque\"" +
                    " FROM produto ORDER by id", dao.Connection());
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
            return cmd;
        }
        public List<Produto> ReadAll() {
            List<Produto> list = new List<Produto>();
            NpgsqlCommand cmd;
            try {
                cmd = new NpgsqlCommand(
                    "SELECT id, nome, preco, estoque from produto order by id", dao.Connection());
                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        Produto p = new Produto();
                        p.ID = (int)reader.GetInt16(0);
                        p.Nome = reader.GetString(1);
                        p.Preco = (double)reader.GetDouble(2);
                        list.Add(p);
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
            return list;
        }
        public Image BuscarImagem(Produto p) {
            NpgsqlCommand cmd;
            Image imagem = null;
            try {
                cmd = new NpgsqlCommand("" +
                    $"SELECT imagem FROM produto where id = {p.ID}", dao.Connection());
                byte[] productImageByte = cmd.ExecuteScalar() as byte[];
                if (productImageByte != null) {
                    using (MemoryStream productImageStream = new System.IO.MemoryStream(productImageByte)) {
                        ImageConverter imageConverter = new System.Drawing.ImageConverter();
                        imagem = imageConverter.ConvertFrom(productImageByte) as System.Drawing.Image;
                        imagem = System.Drawing.Image.FromStream(productImageStream);
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
            return imagem;
        }
        public void Insert(Produto p) {
            NpgsqlCommand cmd;
            try {
                cmd = new NpgsqlCommand(
                    "INSERT INTO Produto(nome, preco, imagem, estoque) " +
                    $"VALUES(@n, @p,@i,@e)", dao.Connection());
                cmd.Parameters.AddWithValue("n", p.Nome);
                cmd.Parameters.AddWithValue("p", p.Preco);
                cmd.Parameters.AddWithValue("i", File.OpenRead(p.Imagem));
                cmd.Parameters.AddWithValue("e", p.QtdEstoque);
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        public void Update(Produto p) {
            try {
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    "UPDATE produto " +
                    "SET nome = @n, preco = @p, estoque = @e" +
                    $" WHERE id = {p.ID}", dao.Connection());
                cmd.Parameters.AddWithValue("n", p.Nome);
                cmd.Parameters.AddWithValue("p", p.Preco);
                cmd.Parameters.AddWithValue("e", p.QtdEstoque);
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
        public void SubtraiEstoque(int id) {
            try {
                NpgsqlCommand cmd;
                cmd = new NpgsqlCommand(
                    "UPDATE produto SET estoque = estoque - 1 " +
                    $"WHERE id = {id}", dao.Connection());
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
