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

        //Theus da uma olhada nisso, a quantidade de livro emprestada vai ser zero então eu fiz uma subtração
        protected void CadastrarLivro(object sender, EventArgs e)
        {  
            Entity.Usuario loUsuarioLivro = new Entity.Usuario(string.Empty, string.Empty, string.Empty, string.Empty);
            loUsuarioLivro.USR_id = (int)Session["ID_Usuario"];
            
            Entity.Livro loNovoLivro = new Entity.Livro(this.txt_nome_livro.Value.ToString(), Convert.ToInt32(this.txt_livro_quantidade.Value.ToString()), 0, loUsuarioLivro.USR_id);
            string lsMensagemOperacao = string.Empty;

            if (! new Business.Livro().InserirNovoLivro(loNovoLivro, loUsuarioLivro, out lsMensagemOperacao))
            {
               this.div_mensagem_livro.Visible = true;
               this.lbl_mensagem_livro.Text = lsMensagemOperacao;
               ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "abrir_popup", "<script> $('#modal_novo_livro').modal('show'); </script>", false);
            }
            else
            {
               this.div_mensagem_livro.Visible = true;
               this.lbl_mensagem_livro.Text = "Seu livro foi cadastrado com sucesso!";               
            }
        }

        protected void AtualizarLivro(object sender, EventArgs e)
        {
            Entity.Usuario loUsuarioAlterarLivro = new Entity.Usuario(string.Empty, string.Empty, string.Empty, string.Empty);
            loUsuarioAlterarLivro.USR_id = (int)Session["ID_Usuario"];
            Entity.Livro loAlterarLivro = new Entity.Livro(this.txt_nome_livro.Value.ToString(), Convert.ToInt32(this.txt_livro_quantidade), (Convert.ToInt32(this.txt_livro_quantidade) - Convert.ToInt32(this.txt_livro_quantidade)), loUsuarioAlterarLivro.USR_id);
            string lsMensagemOperacao = string.Empty;
            if (!new Business.Livro().AlterarLivro(loAlterarLivro, out lsMensagemOperacao)){
                this.div_msg_alterar_livro.Visible = true;
                this.lbl_msg_alterar_livro.Text = lsMensagemOperacao;
            }
            else
            {
                this.div_msg_alterar_livro.Visible = true;
                this.lbl_msg_alterar_livro.Text = "Seu livro foi alterado com sucesso!";               
            }
        }

        // REFAZER!
        protected void ExcluirLivro(object sender, EventArgs e)
        {
            Entity.Usuario loUsuarioDesativadoLivro = new Entity.Usuario(string.Empty, string.Empty, string.Empty, string.Empty);
            loUsuarioDesativadoLivro.USR_id = (int)Session["ID_Usuario"];
            Entity.Livro loExcluirLivro = new Entity.Livro(string.Empty, Convert.ToInt32(string.Empty), (Convert.ToInt32(string.Empty) - Convert.ToInt32(string.Empty)), loUsuarioDesativadoLivro.USR_id);
            string lsMensagem = string.Empty;
            new Business.Livro().RemoverLivro(loExcluirLivro, out lsMensagem);
            Response.Redirect("PaginaInicial.aspx");
        }

        protected void EmprestarLivro(object sender, EventArgs e)
        {
            Entity.Usuario loUsuarioEmprestimo = new Entity.Usuario(string.Empty, string.Empty, string.Empty, string.Empty);
            loUsuarioEmprestimo.USR_id = (int)Session["ID_Usuario"];
             string lsMensagemOperacao = string.Empty;
            Entity.Livro loLivroEmprestimo = new Entity.Livro(string.Empty, Convert.ToInt32(string.Empty), (Convert.ToInt32(string.Empty) - Convert.ToInt32(string.Empty)), loUsuarioEmprestimo.USR_id);

            Entity.Emprestimo loNovoEmprestimo = new Entity.Emprestimo(loLivroEmprestimo.LVR_id, loUsuarioEmprestimo.USR_id, this.txt_nome_emprestante.Value.ToString(), this.txt_email_emprestante.Value.ToString(), Convert.ToDateTime(this.txt_nova_data.Value.ToString()));
            if (new Business.Emprestimo().InserirNovoEmprestimo(loLivroEmprestimo, loNovoEmprestimo, out lsMensagemOperacao))
            {
                //adicionar
            }
            else
            {
                this.div_msg_emprestimo.Visible = true;
                this.lbl_emprestimo.Text = lsMensagemOperacao;

            }

        }


    }
}


    