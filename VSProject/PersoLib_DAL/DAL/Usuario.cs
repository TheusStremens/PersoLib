using MySql.Data.MySqlClient;
using System.Configuration;
using PersoLib_DAL;
using System.Text;

namespace PersoLib_DAL
{
    internal static partial class DAL
    {
        internal class Usuario
        {
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

            internal int ExisteUsuarioEmail(Entity.Usuario aoUsuario)
            {
                int liResult = -1;
                MySqlConnection conn = new
                MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                try
                {
                    conn.Open();

                    string lsSQLQuery = "select count(*) from usr_usuario where USR_email = @email";

                    MySqlCommand cmd = new MySqlCommand(lsSQLQuery, conn);

                    cmd.Parameters.AddWithValue("@email", aoUsuario.USR_email);
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
        }
    }
}