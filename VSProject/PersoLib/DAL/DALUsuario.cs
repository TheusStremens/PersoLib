using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PersoLib.DAL
{
    public class DALUsuario
    {
        public Usuario USUARIO { set; get; }

        public DALUsuario(Usuario aoUsuario)
        {
            this.USUARIO = aoUsuario;
        }
      
        public int InsertUsuario()
        {
            int liResult = -1;
            MySqlConnection conn = new
            MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                conn.Open();
                string lsSQLQuery = "insert into usr_usuario(USR_email, USR_nome, USR_senha, USR_ativo) values(@email, @nome, @senha, 1)";
                MySqlCommand cmd = new MySqlCommand(lsSQLQuery, conn);
                cmd.Parameters.AddWithValue("@email", USUARIO.USR_email);
                cmd.Parameters.AddWithValue("@nome", USUARIO.USR_nome);
                cmd.Parameters.AddWithValue("@senha", USUARIO.USR_senha);
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

        public int UpdateNome()
        {
            int liResult = -1;
            MySqlConnection conn = new
            MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                conn.Open();
                string lsSQLQuery = "update usr_usuario set USR_nome = @nome where USR_id = @id";
                MySqlCommand cmd = new MySqlCommand(lsSQLQuery, conn);         
                cmd.Parameters.AddWithValue("@nome", USUARIO.USR_nome);
                cmd.Parameters.AddWithValue("@id", USUARIO.USR_id);
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

        public int UpdateEmail()
        {
            int liResult = -1;
            MySqlConnection conn = new
            MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                conn.Open();
                string lsSQLQuery = "update usr_usuario set USR_email = @email where USR_id = @id";
                MySqlCommand cmd = new MySqlCommand(lsSQLQuery, conn);
                cmd.Parameters.AddWithValue("@email", USUARIO.USR_email);
                cmd.Parameters.AddWithValue("@id", USUARIO.USR_id);
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

        public int UpdateSenha()
        {
            int liResult = -1;
            MySqlConnection conn = new
            MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                conn.Open();
                string lsSQLQuery = "update usr_usuario set USR_senha = @senha where USR_id = @id";
                MySqlCommand cmd = new MySqlCommand(lsSQLQuery, conn);
                cmd.Parameters.AddWithValue("@senha", USUARIO.USR_nome);
                cmd.Parameters.AddWithValue("@id", USUARIO.USR_id);
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

        public int DesativarUsuario()
        {
            int liResult = -1;
            MySqlConnection conn = new
            MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                conn.Open();
                string lsSQLQuery = "update usr_usuario set USR_ativo = 0 where USR_id = @id";
                MySqlCommand cmd = new MySqlCommand(lsSQLQuery, conn);       
                cmd.Parameters.AddWithValue("@id", USUARIO.USR_id);
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

        public int ExisteUsuarioEmail()
        {
            int liResult = -1;
            MySqlConnection conn = new
            MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                conn.Open();
                string lsSQLQuery = "select count(*) from usr_usuario where USR_email = @email";
                MySqlCommand cmd = new MySqlCommand(lsSQLQuery, conn);
                cmd.Parameters.AddWithValue("@email", USUARIO.USR_email);
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

        public int LoginUsuario()
        {
            int liResult = -1;
            MySqlConnection conn = new
            MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                conn.Open();
                string lsSQLQuery = "select USR_id from usr_usuario where USR_email = @email and USR_senha = @senha";
                MySqlCommand cmd = new MySqlCommand(lsSQLQuery, conn);
                cmd.Parameters.AddWithValue("@email", USUARIO.USR_email);
                cmd.Parameters.AddWithValue("@senha", USUARIO.USR_senha);
                MySqlDataReader loMySqlDataReader = cmd.ExecuteReader();
                while(loMySqlDataReader.Read())
                {
                    liResult = (int)loMySqlDataReader.GetValue(0);
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