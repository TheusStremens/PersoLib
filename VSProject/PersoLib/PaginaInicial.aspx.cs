using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersoLib
{
    public partial class PaginaInicial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void CadastrarUsuario(object sender, EventArgs e)
        {
            Usuario loNovoUsuario = new Usuario(this.txt_email_cadastro.Value.ToString(), this.txt_name.Value.ToString(), this.txt_senha.Value.ToString());
            this.InserirNovoUsuario(loNovoUsuario);
        }

        protected void InserirNovoUsuario(Usuario aoNovoUsuario)
        {
            //int result = -1;
            MySqlConnection conn = new
            MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            try
            {
                conn.Open();
                string lsSQLQuery = "insert into usr_usuario(USR_email, USR_nome, USR_senha) values(@email, @nome, @senha)";
                MySqlCommand cmd = new MySqlCommand(lsSQLQuery, conn);
                cmd.Parameters.AddWithValue("@email", aoNovoUsuario.USR_email);
                cmd.Parameters.AddWithValue("@nome", aoNovoUsuario.USR_nome);
                cmd.Parameters.AddWithValue("@senha", aoNovoUsuario.USR_senha);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (MySqlException ex)
            {
                
            }
            finally
            {
                conn.Close();
            }
            //return result;




        }
    }
}