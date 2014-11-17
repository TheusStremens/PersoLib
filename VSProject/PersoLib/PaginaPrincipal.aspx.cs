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
            if (!IsPostBack)
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
        }

        protected void AtualizarPerfil(object sender, EventArgs e)
        {
            Entity.Usuario loAlterarUsuario = new Entity.Usuario(this.txt_email.Value.ToString(), this.txt_nome.Value.ToString(), this.txt_nova_senha.Value.ToString(), this.txt_nova_senha_confirmacao.Value.ToString());
            string lsMensagemOperacao = string.Empty;
            loAlterarUsuario.USR_id = (int)Session["ID_Usuario"];
            if (!new Business.Usuario().AlterarUsuario(loAlterarUsuario, out lsMensagemOperacao))
            {
                this.div_mensagem_perfil.Visible = true;
                this.lbl_mensagem_perfil.Text = lsMensagemOperacao;
            }
            else
            {
                this.div_mensagem_perfil.Visible = true;
                this.lbl_mensagem_perfil.Text = "Seu perfil foi atualizado com sucesso!";
            }
        }

        protected void DesativarUsuario(object sender, EventArgs e)
        {
            Entity.Usuario loUsuarioDesativado = new Entity.Usuario(string.Empty, string.Empty, string.Empty, string.Empty);
            loUsuarioDesativado.USR_id = (int)Session["ID_Usuario"];
            string lsMensagem = string.Empty;
            new Business.Usuario().DesativarUsuario(loUsuarioDesativado, out lsMensagem);
            Response.Redirect("PaginaInicial.aspx");
        }
    }
}