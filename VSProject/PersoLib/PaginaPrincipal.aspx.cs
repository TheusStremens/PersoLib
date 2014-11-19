using PersoLib_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersoLib
{
    public partial class PaginaPrincipal : System.Web.UI.Page
    {

        [WebMethod]
        public static void selecao_aba(string codigo)
        {
            HttpContext.Current.Session["selecao_aba"] = codigo;
        }

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

            if (HttpContext.Current.Session["selecao_aba"] != null)
            {
                this.ajustar_tabs();
            }
        }

        /// <summary>
        /// Método responsável por ajustar as tabs toda vem que um pushback é gerado.
        /// </summary>
        private void ajustar_tabs()
        {
            String aba = (string)HttpContext.Current.Session["selecao_aba"];
            if (aba == "aba1")
            {
                this.div_aba2.Attributes["class"] = this.div_aba2.Attributes["class"].Replace("in", "");
                this.div_aba2.Attributes["class"] = this.div_aba2.Attributes["class"].Replace("active", "");
                this.div_aba3.Attributes["class"] = this.div_aba2.Attributes["class"].Replace("in", "");
                this.div_aba3.Attributes["class"] = this.div_aba2.Attributes["class"].Replace("active", "");
                this.div_aba2.Attributes.Add("class", "tab-pane fade");
                this.div_aba3.Attributes.Add("class", "tab-pane fade");
                this.li_aba1.Attributes.Add("class", "active");
                this.li_aba2.Attributes.Remove("class");
                this.li_aba3.Attributes.Remove("class");
                this.div_aba1.Attributes.Add("class", "in");
                this.div_aba1.Attributes.Add("class", "active");
            }
            else if (aba == "aba2")
            {
                this.div_aba1.Attributes["class"] = this.div_aba2.Attributes["class"].Replace("in", "");
                this.div_aba1.Attributes["class"] = this.div_aba2.Attributes["class"].Replace("active", "");
                this.div_aba3.Attributes["class"] = this.div_aba2.Attributes["class"].Replace("in", "");
                this.div_aba3.Attributes["class"] = this.div_aba2.Attributes["class"].Replace("active", "");
                this.li_aba2.Attributes.Add("class", "active");
                this.li_aba1.Attributes.Remove("class");
                this.li_aba3.Attributes.Remove("class");
                this.div_aba3.Attributes.Add("class", "tab-pane fade");
                this.div_aba1.Attributes.Add("class", "tab-pane fade");
                this.div_aba2.Attributes.Add("class", "in");
                this.div_aba2.Attributes.Add("class", "active");
            }
            else
            {
                this.div_aba1.Attributes["class"] = this.div_aba2.Attributes["class"].Replace("in", "");
                this.div_aba1.Attributes["class"] = this.div_aba2.Attributes["class"].Replace("active", "");
                this.div_aba2.Attributes["class"] = this.div_aba2.Attributes["class"].Replace("in", "");
                this.div_aba2.Attributes["class"] = this.div_aba2.Attributes["class"].Replace("active", "");
                this.li_aba3.Attributes.Add("class", "active");
                this.li_aba2.Attributes.Remove("class");
                this.li_aba1.Attributes.Remove("class");
                this.div_aba2.Attributes.Add("class", "tab-pane fade");
                this.div_aba1.Attributes.Add("class", "tab-pane fade");
                this.div_aba3.Attributes.Add("class", "in");
                this.div_aba3.Attributes.Add("class", "active");
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
            selecao_aba("aba3");
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