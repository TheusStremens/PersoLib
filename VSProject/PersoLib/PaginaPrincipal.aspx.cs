using PersoLib_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersoLib
{
    public partial class PaginaPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Entity.Usuario loUsuarioLogado = new Entity.Usuario(string.Empty, string.Empty, string.Empty, string.Empty);
                loUsuarioLogado.USR_id = (int)Session["ID_Usuario"];
                loUsuarioLogado = new Business.Usuario().CarregarDados(loUsuarioLogado);
                this.txt_nome.Value = loUsuarioLogado.USR_nome;
                this.txt_email.Value = loUsuarioLogado.USR_email;
            }
            catch
            {

            }
        }

        protected void AtualizarPerfil(object sender, EventArgs e)
        {
            try
            {
                //verificar a repetição de password
                Entity.Usuario loAlterarUsuario = new Entity.Usuario(this.txt_email.Value.ToString(), this.txt_nome.Value.ToString(), this.txt_nova_senha.Value.ToString(), this.password.Value.ToString());
                string lsMensagemOperacao = string.Empty;
                new  Business.Usuario().AlterarUsuario(loAlterarUsuario, lsMensagemOperacao);

            }
            catch
            {

            }
        }
    }
}