using PersoLib_DAL;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersoLib
{
    public partial class PaginaInicial : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoginUsuario(object sender, EventArgs e)
        {
            this.div_erro_login.Visible = false;
            Entity.Usuario loUsuario = new Entity.Usuario(this.txt_email_login.Value.ToString(), string.Empty, this.txt_senha_login.Value.ToString(), this.txt_senha_login.Value.ToString());
            string lsMensagemOperacao = string.Empty;

            //if (new Business.Usuario().VerificarLogin(loUsuario, out lsMensagemOperacao) == -1)
            //{
            //    this.div_erro_login.Visible = true;
            //    this.lbl_mensagem_login.Text = lsMensagemOperacao;
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "abrir_popup", "<script> $('#modal_login').modal('show'); </script>", false);
            //}
            //else
            //{
                //this.Context.Items["ID_Usuario"] = 112;
                Response.Cookies["test"].Value = "testando";
                Response.Cookies["test"].Expires = DateTime.Now.AddMinutes(10);
                Response.Redirect("PaginaPrincipal.aspx?testando");                
            //}
        }

        protected void CadastrarUsuario(object sender, EventArgs e)
        {
            this.div_mensagem_modal.Visible = false;
            Entity.Usuario loNovoUsuario = new Entity.Usuario(this.txt_email_cadastro.Value.ToString(), this.txt_name.Value.ToString(), this.txt_senha.Value.ToString(), this.txt_repete_senha.Value.ToString());
            string lsMensagemOperacao = string.Empty;

            if (new Business.Usuario().InserirNovoUsuario(loNovoUsuario, out lsMensagemOperacao))
            {
                this.LimparCampos();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "registro_sucesso", "<script> document.getElementById('"+ btn_registro_sucesso.ClientID +"').click(); </script>", false);
            }
            else
            {
                this.div_mensagem_modal.Visible = true;
                this.lbl_mensagem_modal.Text = lsMensagemOperacao;
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "abrir_popup", "<script> $('#modal_cadastro').modal('show'); </script>", false);
            }
        }

        private void LimparCampos()
        {
            this.div_mensagem_modal.Visible = false;
            this.txt_name.Value = string.Empty;
            this.txt_email_cadastro.Value = string.Empty;
            this.txt_senha.Value = string.Empty;
            this.txt_repete_senha.Value = string.Empty;
        }

        protected void FecharPopupCadastro(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "fechar_popup_cadastro", "<script> $('#modal_cadastro').modal('hide'); </script>", false);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "fechar_popup_cadastro2", "<script> $('#modal_cadastrado_sucesso').modal('hide'); </script>", false);
            this.LimparCampos();
        }

        protected void AbrirPopupConfirmacao(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "abrir_popup", "<script> $('#modal_cadastrado_sucesso').modal('show'); </script>", false);
        }
    }
}