using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PersoLib_DAL
{
    internal static partial class DAL
    {
        internal class Livro
        {
            /* Insere novo livro no banco.
             * Retorna 1 se a operção foi executada com sucesso.
             * Retorna -1 se ocorreu algum erro na operação, seja erro no banco ou alguma violação de integridade. */
            internal int InserirNovoLivro(Entity.Livro aoLivro, Entity.Usuario aoUsuario)
            {
                int liResult = -1;
                MySqlConnection conn = new
                MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                try
                {
                    conn.Open();
                    string lsSQLQuery = "insert into lvr_livro(lvr_id_usuario, lvr_nome, lvr_qtd_emprestada, lvr_qtd_disponivel) values(@id_usuario, @nome, 0, @disponivel)";
                    MySqlCommand cmd = new MySqlCommand(lsSQLQuery, conn);
                    cmd.Parameters.AddWithValue("@id_usuario", aoUsuario.USR_id);
                    cmd.Parameters.AddWithValue("@nome", aoLivro.LVR_nome);
                    cmd.Parameters.AddWithValue("@disponivel", aoLivro.LVR_disponivel);
                    liResult = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cmd.Parameters.Clear();
                }
                catch (MySqlException ex)
                {
                }
                finally
                {
                    conn.Close();
                }
                return liResult;
            }
             /* Atualiza o nome e a quantidade disponivel de um determinado livro
              * Retorna 1 se a operção foi executada com sucesso.
              * Retorna -1 se ocorreu algum erro na operação, seja erro no banco ou alguma violação de integridade. */
            internal int AtualizarDadosLivro(Entity.Livro aoLivro)
            {
                int liResult = -1;
                MySqlConnection conn = new
                MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                try
                {
                    conn.Open();
                    string lsSQLQuery = "update lvr_livro set lvr_nome = @nome, lvr_qtd_disponivel = @disponivel where lvr_id = @id_livro";
                    MySqlCommand cmd = new MySqlCommand(lsSQLQuery, conn);
                    cmd.Parameters.AddWithValue("@id_livro", aoLivro.LVR_id);
                    cmd.Parameters.AddWithValue("@nome", aoLivro.LVR_nome);
                    cmd.Parameters.AddWithValue("@disponivel", aoLivro.LVR_disponivel);
                    liResult = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cmd.Parameters.Clear();
                }
                catch (MySqlException ex)
                {
                }
                finally
                {
                    conn.Close();
                }
                return liResult;
            }
            /* Exclui um livro no banco.
             * Retorna 1 se a operção foi executada com sucesso.
             * Retorna -1 se ocorreu algum erro na operação, seja erro no banco ou alguma violação de integridade. */
            internal int RemoverLivro(Entity.Livro aoLivro)
            {
                int liResult = -1;
                MySqlConnection conn = new
                MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                try
                {
                    conn.Open();
                    string lsSQLQuery = "delete from lvr_livro where lvr_id = @id_livro";
                    MySqlCommand cmd = new MySqlCommand(lsSQLQuery, conn);
                    cmd.Parameters.AddWithValue("@id_livro", aoLivro.LVR_id);
                    liResult = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cmd.Parameters.Clear();
                }
                catch (MySqlException ex)
                {
                }
                finally
                {
                    conn.Close();
                }
                return liResult;
            }
            /* Retorna uma lista de Livros do usuario.
             * Retorna null se o usuario nao possui livros ou ocorreu algum erro no banco. */
            internal List<Entity.Livro> CarregarLivrosUsuario(int aiIdUsuario) 
            {
                List<Entity.Livro> loListaLivros = new List<Entity.Livro>();
                loListaLivros = null;
                MySqlConnection conn = new
                MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                try
                {
                    conn.Open();
                    string lsSQLQuery = "select lvr_id, lvr_nome, lvr_qtd_disponivel, lvr_qtd_emprestada from lvr_livro where lvr_id_usuario = @id_usuario";
                    MySqlCommand cmd = new MySqlCommand(lsSQLQuery, conn);

                    cmd.Parameters.AddWithValue("@id_usuario", aiIdUsuario);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Entity.Livro loLivro = new Entity.Livro((string)reader.GetValue(1), (int)reader.GetValue(2), (int)reader.GetValue(3), aiIdUsuario);
                        loLivro.LVR_id = (int)reader.GetValue(0);
                        loListaLivros.Add(loLivro);
                    }

                    cmd.Dispose();
                    cmd.Parameters.Clear();
                }
                catch (MySqlException ex)
                {
                }
                finally
                {
                    conn.Close();
                }
                return loListaLivros;
            }
            /* Se já existe um livro no banco com o nome em questão, ele retorna 1.
             * Se não existe um livro com esse nome, retorna 0.
             * Retorna -1 se ocorreu algum erro na operação. */
            internal int ExisteLivroNome(Entity.Livro aoLivro)
            {
                int liResult = -1;
                MySqlConnection conn = new
                MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                try
                {
                    conn.Open();

                    string lsSQLQuery = "select count(*) from lvr_livro where lvr_nome = @nome and lvr_id != @id_livro";

                    MySqlCommand cmd = new MySqlCommand(lsSQLQuery, conn);

                    cmd.Parameters.AddWithValue("@nome", aoLivro.LVR_nome);
                    cmd.Parameters.AddWithValue("@id_livro", aoLivro.LVR_id);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        liResult = Convert.ToInt32(reader.GetValue(0).ToString());
                    }

                    cmd.Dispose();
                    cmd.Parameters.Clear();
                }
                catch (MySqlException ex)
                {
                }
                finally
                {
                    conn.Close();
                }
                return liResult;
            }
        }
    }
}