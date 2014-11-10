using System;
using System.Collections.Generic;
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
        }
    }
}