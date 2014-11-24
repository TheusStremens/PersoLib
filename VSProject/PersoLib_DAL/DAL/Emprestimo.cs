using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersoLib_DAL.DAL
{
    internal static partial class DAL
    {
        internal class Emprestimo
        {
            /* O metodo ja faz a atualizacao do livro em questão, alterando suas quantidades disponiveis e emprestadas.
             * Insere um novo emprestimo no banco.
             * Retorna 1 se a operção foi executada com sucesso.
             * Retorna -1 se ocorreu algum erro na operação, seja erro no banco ou alguma violação de integridade. */
            internal int RealizarEmprestimo(Entity.Livro aoLivro, Entity.Emprestimo aoEmprestimo)
            {
                int liResult = -1;
                MySqlConnection conn = new
                MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                try
                {
                    conn.Open();
                    StringBuilder lsSQLQuery = new StringBuilder();
                    lsSQLQuery.Append("update lvr_livro set lvr_qtd_disponivel = @disponivel, lvr_qtd_emprestada = @emprestada where lvr_id = @id_livro;");
                    lsSQLQuery.Append("insert into emp_emprestimo(emp_nome_emprestante, emp_email_emprestante, emp_data_devolucao, emp_id_livro, emp_id_usuario) ");
                    lsSQLQuery.Append("values(@nome_emprestante, @email_emprestante, @data_devolucao, @emp_id_livro, @emp_id_usuario)");
                    MySqlCommand cmd = new MySqlCommand(lsSQLQuery.ToString(), conn);
                    cmd.Parameters.AddWithValue("@id_livro", aoLivro.LVR_id);
                    cmd.Parameters.AddWithValue("@emprestada", aoLivro.LVR_emprestado + 1);
                    cmd.Parameters.AddWithValue("@disponivel", aoLivro.LVR_disponivel - 1);
                    cmd.Parameters.AddWithValue("@nome_emprestante", aoEmprestimo.EMP_nome_emprestante);
                    cmd.Parameters.AddWithValue("@email_emprestante", aoEmprestimo.EMP_email_emprestante);
                    cmd.Parameters.AddWithValue("@data_devolucao", aoEmprestimo.EMP_devolucao);
                    cmd.Parameters.AddWithValue("@emp_id_livro", aoEmprestimo.EMP_id_livro);
                    cmd.Parameters.AddWithValue("@emp_id_usuario", aoEmprestimo.EMP_id_usuario);
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
            /* O metodo ja faz a atualizacao do livro em questão, alterando suas quantidades disponiveis e emprestadas.
             * Remove um emprestimo no banco.
             * Retorna 1 se a operção foi executada com sucesso.
             * Retorna -1 se ocorreu algum erro na operação, seja erro no banco ou alguma violação de integridade. */
            internal int DevolverEmprestimo(Entity.Livro aoLivro, Entity.Emprestimo aoEmprestimo)
            {
                int liResult = -1;
                MySqlConnection conn = new
                MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                try
                {
                    conn.Open();
                    StringBuilder lsSQLQuery = new StringBuilder();
                    lsSQLQuery.Append("update lvr_livro set lvr_qtd_disponivel = @disponivel, lvr_qtd_emprestada = @emprestada where lvr_id = @id_livro;");
                    lsSQLQuery.Append("delete from emp_emprestimo where emp_id = @emp_id");
                    MySqlCommand cmd = new MySqlCommand(lsSQLQuery.ToString(), conn);
                    cmd.Parameters.AddWithValue("@id_livro", aoLivro.LVR_id);
                    cmd.Parameters.AddWithValue("@emprestada", aoLivro.LVR_emprestado - 1);
                    cmd.Parameters.AddWithValue("@disponivel", aoLivro.LVR_disponivel + 1);
                    cmd.Parameters.AddWithValue("@emp_id", aoEmprestimo.EMP_id);
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
            /* Altera a data de devolucao de um emprestimo
             * Retorna 1 se a operção foi executada com sucesso.
             * Retorna -1 se ocorreu algum erro na operação, seja erro no banco ou alguma violação de integridade. */
            internal int AlterarPrazoEmprestimo(Entity.Emprestimo aoEmprestimo)
            {
                int liResult = -1;
                MySqlConnection conn = new
                MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                try
                {
                    conn.Open();
                    StringBuilder lsSQLQuery = new StringBuilder();
                    lsSQLQuery.Append("update emp_emprestimo set emp_data_devolucao = @nova_data where emp_id = @emp_id");
                    MySqlCommand cmd = new MySqlCommand(lsSQLQuery.ToString(), conn);
                    cmd.Parameters.AddWithValue("@nova_data", aoEmprestimo.EMP_devolucao);
                    cmd.Parameters.AddWithValue("@emp_id", aoEmprestimo.EMP_id);
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
            /* Retorna uma lista de Emprestimos do usuario.
             * Retorna null se o usuario nao possui emprestimos ou ocorreu algum erro no banco. */
            internal List<Entity.Emprestimo> CarregarEmprestimosUsuario(int aiIdUsuario)
            {
                List<Entity.Emprestimo> loListaEmprestimos = new List<Entity.Emprestimo>();
                loListaEmprestimos = null;
                MySqlConnection conn = new
                MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                try
                {
                    conn.Open();
                    string lsSQLQuery = "select emp_id_livro, emp_email_emprestante, emp_nome_emprestante, emp_data_devolucao from emp_emprestimo where emp_id_usuario = @id_usuario";
                    MySqlCommand cmd = new MySqlCommand(lsSQLQuery, conn);

                    cmd.Parameters.AddWithValue("@emp_id_usuario", aiIdUsuario);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Entity.Emprestimo loEmprestimo = new Entity.Emprestimo((int)reader.GetValue(0), aiIdUsuario, (string)reader.GetValue(1), (string)reader.GetValue(2), (DateTime)reader.GetValue(3));
                        loListaEmprestimos.Add(loEmprestimo);
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
                return loListaEmprestimos;
            }
        }
    }
}
