using MySql.Data.MySqlClient;
using System.Configuration;
using PersoLib_DAL;
using System.Text;
using System;

namespace PersoLib_DAL
{
    internal static partial class DAL
    {
        internal class Usuario
        {
            /* Insere novo usuário no banco.
             * Retorna 1 se a operção foi executada com sucesso.
             * Retorna -1 se ocorreu algum erro na operação, seja erro no banco ou alguma violação de integridade. */
            internal int InserirNovoUsuario(Entity.Usuario aoUsuario)
            {
                int liResult = -1;
                MySqlConnection conn = new
                MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                try
                {
                    conn.Open();
                    string lsSQLQuery = "insert into usr_usuario(USR_email, USR_nome, USR_senha, USR_ativo) values(@email, @nome, @senha, 1)";
                    MySqlCommand cmd = new MySqlCommand(lsSQLQuery, conn);
                    cmd.Parameters.AddWithValue("@email", aoUsuario.USR_email);
                    cmd.Parameters.AddWithValue("@nome", aoUsuario.USR_nome);
                    cmd.Parameters.AddWithValue("@senha", aoUsuario.USR_senha);
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

            /* Atualiza dados de um usuário no banco.
             * A função já verifica se o nome, e-mail e senha estão vazios e atualiza cada um desses campos
             * apenas se eles não forem vazios. Se por exemplo, só nome estiver diferente de vazio, então só atualizará nome.
             * Retorna 1 se a operção foi executada com sucesso.
             * Retorna -1 se ocorreu algum erro na operação, seja erro no banco ou alguma violação de integridade. */
            internal int AtualizarDadosUsuario(Entity.Usuario aoUsuario)
            {
                int liResult = -1;
                MySqlConnection conn = new
                MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                try
                {
                    conn.Open();

                    StringBuilder loStb = new StringBuilder();

                    loStb.Append("UPDATE usr_usuario SET ");

                    if (!string.IsNullOrWhiteSpace(aoUsuario.USR_nome))
                    {
                        loStb.Append(" USR_nome = @nome ");
                    }

                    if (!string.IsNullOrWhiteSpace(aoUsuario.USR_email) && string.IsNullOrWhiteSpace(aoUsuario.USR_nome))
                    {
                        loStb.Append(" USR_email = @email ");
                    }
                    else if (!string.IsNullOrWhiteSpace(aoUsuario.USR_email))
                    {
                        loStb.Append(" , USR_email = @email ");
                    }

                    if (!string.IsNullOrWhiteSpace(aoUsuario.USR_senha) && 
                        string.IsNullOrWhiteSpace(aoUsuario.USR_email) && string.IsNullOrWhiteSpace(aoUsuario.USR_nome))
                    {
                        loStb.Append(" USR_senha = @senha ");
                    }
                    else if (!string.IsNullOrWhiteSpace(aoUsuario.USR_senha) && 
                        (!string.IsNullOrWhiteSpace(aoUsuario.USR_email) || !string.IsNullOrWhiteSpace(aoUsuario.USR_nome)))
                    {
                        loStb.Append(" , USR_senha = @senha ");
                    }

                    loStb.Append(" where USR_id = @id ");

                    MySqlCommand cmd = new MySqlCommand(loStb.ToString(), conn);

                    if (!string.IsNullOrWhiteSpace(aoUsuario.USR_nome))
                    {
                        cmd.Parameters.AddWithValue("@nome", aoUsuario.USR_nome);
                    }

                    if (!string.IsNullOrWhiteSpace(aoUsuario.USR_email))
                    {
                        cmd.Parameters.AddWithValue("@email", aoUsuario.USR_email);
                    }

                    if (!string.IsNullOrWhiteSpace(aoUsuario.USR_email))
                    {
                        cmd.Parameters.AddWithValue("@senha", aoUsuario.USR_senha);
                    }

                    cmd.Parameters.AddWithValue("@id", aoUsuario.USR_id);

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

            /* Retorna 1 se a operção foi executada com sucesso.
             * Retorna -1 se ocorreu algum erro na operação. */
            internal int DesativarUsuario(Entity.Usuario aoUsuario)
            {
                int liResult = -1;
                MySqlConnection conn = new
                MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                try
                {
                    conn.Open();
                    string lsSQLQuery = "update usr_usuario set USR_ativo = 0 where USR_id = @id";
                    MySqlCommand cmd = new MySqlCommand(lsSQLQuery, conn);
                    cmd.Parameters.AddWithValue("@id", aoUsuario.USR_id);
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

            /* Se já existe um usuário no banco com o e-mail em questão, ele retorna 1.
             * Se não existe um usuário com esse e-mail, retorna 0.
             * Retorna -1 se ocorreu algum erro na operação. */
            internal int ExisteUsuarioEmail(Entity.Usuario aoUsuario)
            {
                int liResult = -1;
                MySqlConnection conn = new
                MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                try
                {
                    conn.Open();

                    string lsSQLQuery = "select count(*) from usr_usuario where USR_email = @email and USR_id != @id";

                    MySqlCommand cmd = new MySqlCommand(lsSQLQuery, conn);

                    cmd.Parameters.AddWithValue("@email", aoUsuario.USR_email);
                    cmd.Parameters.AddWithValue("@id", aoUsuario.USR_id);
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

            /* Retorna o id do usuário caso exista um usuário com aquele e-mail e senha.
             * Retorna -1 se não existe usuário com aquele e-mail e senha ou ocorreu um erro no banco. */
            internal int LoginUsuario(Entity.Usuario aoUsuario)
            {
                int liResult = -1;
                MySqlConnection conn = new
                MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                try
                {
                    conn.Open();

                    string lsSQLQuery = "select USR_id from usr_usuario where USR_email = @email and USR_senha = @senha";
                    MySqlCommand cmd = new MySqlCommand(lsSQLQuery, conn);

                    cmd.Parameters.AddWithValue("@email", aoUsuario.USR_email);
                    cmd.Parameters.AddWithValue("@senha", aoUsuario.USR_senha);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        liResult = (int)reader.GetValue(0);
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

            /* Retorna os dados de um usuário através do id dele.
             * Retorna null se por algum motivo o usuário não existe ou ocorreu um erro no banco. */
            internal Entity.Usuario ObterDadosUsuario(int aiIdUsuario)
            {
                MySqlConnection conn = new
                MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                Entity.Usuario loUsuario = null;

                try
                {
                    conn.Open();

                    string lsSQLQuery = "select USR_email, USR_nome from usr_usuario where USR_id = @id";
                    MySqlCommand cmd = new MySqlCommand(lsSQLQuery, conn);

                    cmd.Parameters.AddWithValue("@id", aiIdUsuario);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        loUsuario = new Entity.Usuario((string)reader.GetValue(0), (string)reader.GetValue(1), string.Empty, string.Empty);
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

                return loUsuario;
            }

            internal int AtivarUsuario(Entity.Usuario aoUsuario)
            {
                int liResult = -1;
                MySqlConnection conn = new
                MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                try
                {
                    conn.Open();

                    StringBuilder loStb = new StringBuilder();
                    loStb.Append("UPDATE usr_usuario SET ");
                    loStb.Append("USR_ativo = 1 ");
                    loStb.Append(" where USR_id = @id ");
                    MySqlCommand cmd = new MySqlCommand(loStb.ToString(), conn);
                    cmd.Parameters.AddWithValue("@id", aoUsuario.USR_id);

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
        }
    }
}