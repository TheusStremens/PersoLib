using PersoLib_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        [WebMethod]
        public static void selecao_livro(string codigo)
        {
            HttpContext.Current.Session["selecao_livro"] = codigo;
        }

        protected void detalhar_livro(object sender, EventArgs e)
        {
            //vamos supor um valor vindo da tela
            string valor = txt_livro_quantidade.Text;
            //pra validar vc usa o seguinte codigo
            int valor_em_int = 0;
            if (!Int32.TryParse(valor, out valor_em_int))
            {
                // se cair aqui significa que ele nao passou no teste de conversão.
                //ai vc exibi uma mensagem ao usuario informando que ele deve digivar um valor numerio para a 
                //QTD de livros
            }
            else
            {
                //se ele entrar no metodo significa que a string "valor" é um numero
                //inclusive vc pode fazer o oposto... se ele entrar aqui é pq falhou. é so acrescentar "!" na frente

                //ok?
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.PreenchePerfilUsuario();
                this.PreencheGridLivrosUsuario();
            }

            if (HttpContext.Current.Session["selecao_aba"] != null)
            {
                this.ajustar_tabs();
            }
        }
        /// <summary>
        /// Método responsável por preencher o grid de livros do Usuário.
        /// </summary>
        protected void PreencheGridLivrosUsuario()
        {
            Entity.Usuario loUsuarioLogado = new Entity.Usuario(string.Empty, string.Empty, string.Empty, string.Empty);
            loUsuarioLogado.USR_id = (int)Session["ID_Usuario"];
            StringBuilder loHTMLGridLivros = new StringBuilder();
            List<Entity.Livro> loListaLivros = new Business.Livro().CarregarLivros(loUsuarioLogado);
            if (loListaLivros.Count == 0)
            {
                this.literal_grid_livros.Text = "<h2>Você não possui nenhum livro cadastrado</h2>";
            }
            else
            {
                loHTMLGridLivros.Append("<table id=\"grid_livros\" runat=\"server\" class=\"table table-striped table-bordered\">");
                loHTMLGridLivros.Append("<thead><tr><th>Nome do Livro</th><th>Quantidade</th><th>Quantidade Emprestada</th><th class=\"acao\">Ações</th></tr></thead>");
                loHTMLGridLivros.Append("<tbody>");
                foreach (Entity.Livro loLivro in loListaLivros)
                {
                    loHTMLGridLivros.Append("<tr><td>");
                    loHTMLGridLivros.Append(loLivro.LVR_nome);
                    loHTMLGridLivros.Append("</td><td>");
                    loHTMLGridLivros.Append(loLivro.LVR_disponivel);
                    loHTMLGridLivros.Append("</td><td>");
                    loHTMLGridLivros.Append(loLivro.LVR_emprestado);
                    loHTMLGridLivros.Append("</td>");
                    loHTMLGridLivros.Append("<td><a title=\"Editar este livro\" onclick=\"selecionar_livro('");
                    loHTMLGridLivros.Append(loLivro.LVR_id.ToString());
                    loHTMLGridLivros.Append("', 'EDITAR', '");
                    loHTMLGridLivros.Append(loLivro.LVR_nome);
                    loHTMLGridLivros.Append("', '");
                    loHTMLGridLivros.Append(loLivro.LVR_disponivel);
                    loHTMLGridLivros.Append("');\"");
                    loHTMLGridLivros.Append("class=\"btn btn-primary btn-xs\">");
                    loHTMLGridLivros.Append("<span class=\"glyphicon glyphicon-pencil\"></span></a>");

                    loHTMLGridLivros.Append("<a title=\"Excluir este livro\" onclick=\"selecionar_livro('");
                    loHTMLGridLivros.Append(loLivro.LVR_id.ToString());
                    loHTMLGridLivros.Append("', 'EXCLUIR', ' ', ' ');\"");
                    loHTMLGridLivros.Append("class=\"btn btn-danger btn-xs\">");

                    if (loLivro.LVR_disponivel != loLivro.LVR_emprestado)
                    {
                        loHTMLGridLivros.Append("<span class=\"glyphicon glyphicon-trash\"></span></a>");
                        loHTMLGridLivros.Append("<a title=\"Empreste este livro\" onclick=\"selecionar_livro('");
                        loHTMLGridLivros.Append(loLivro.LVR_id.ToString());
                        loHTMLGridLivros.Append("', 'EMPRESTAR', '");
                        loHTMLGridLivros.Append(loLivro.LVR_nome);
                        loHTMLGridLivros.Append("', ' ');\"");
                        loHTMLGridLivros.Append("class=\"btn btn-warning btn-xs\">");
                        loHTMLGridLivros.Append("<span class=\"glyphicon glyphicon-new-window\"></span></a>");
                    }
                    loHTMLGridLivros.Append("</td></tr>");
                }
                loHTMLGridLivros.Append("</tbody>");
                loHTMLGridLivros.Append("</table>");
                this.literal_grid_livros.Text = loHTMLGridLivros.ToString();
            }
        }
        /// <summary>
        /// Método responsável por preencher os campos do Perfil do Usuário.
        /// </summary>
        protected void PreenchePerfilUsuario()
        {
            Entity.Usuario loUsuarioLogado = new Entity.Usuario(string.Empty, string.Empty, string.Empty, string.Empty);
            loUsuarioLogado.USR_id = (int)Session["ID_Usuario"];
            loUsuarioLogado = new Business.Usuario().CarregarDados(loUsuarioLogado);
            this.txt_nome.Value = loUsuarioLogado.USR_nome;
            this.txt_email.Value = loUsuarioLogado.USR_email;
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

        protected void CadastrarLivro(object sender, EventArgs e)
        {
            Entity.Usuario loUsuarioLivro = new Entity.Usuario(string.Empty, string.Empty, string.Empty, string.Empty);
            loUsuarioLivro.USR_id = (int)Session["ID_Usuario"];

            Entity.Livro loNovoLivro = new Entity.Livro(this.txt_nome_livro.Text.ToString(), Convert.ToInt32(this.txt_livro_quantidade.Text.ToString()), 0, loUsuarioLivro.USR_id);
            string lsMensagemOperacao = string.Empty;

            if (!new Business.Livro().InserirNovoLivro(loNovoLivro, loUsuarioLivro, out lsMensagemOperacao))
            {
                this.div_mensagem_livro.Visible = true;
                this.lbl_mensagem_livro.Text = lsMensagemOperacao;
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "abrir_popup", "<script> $('#modal_novo_livro').modal('show'); </script>", false);
            }
            else
            {
                this.div_mensagem_livro.Visible = true;
                this.lbl_mensagem_livro.Text = "Seu livro foi cadastrado com sucesso!";
                this.PreencheGridLivrosUsuario();
            }
        }

        protected void AtualizarLivro(object sender, EventArgs e)
        {
            Entity.Usuario loUsuarioAlterarLivro = new Entity.Usuario(string.Empty, string.Empty, string.Empty, string.Empty);
            loUsuarioAlterarLivro.USR_id = (int)Session["ID_Usuario"];
            //ESSE CONVERT.TOIN32 PODE DAR ERRO SE O USUARIO DIGITAR LETRAS
            Entity.Livro loAlterarLivro = new Entity.Livro(this.txt_editar_livro_nome.Value.ToString(), Convert.ToInt32(this.txt_editar_livro_qtd.Value.ToString()), 0, loUsuarioAlterarLivro.USR_id);
            if (HttpContext.Current.Session["selecao_livro"] != null)
                loAlterarLivro.LVR_id = Convert.ToInt32(HttpContext.Current.Session["selecao_livro"].ToString());
            string lsMensagemOperacao = string.Empty;
            if (!new Business.Livro().AlterarLivro(loAlterarLivro, out lsMensagemOperacao))
            {
                this.div_msg_alterar_livro.Visible = true;
                this.lbl_msg_alterar_livro.Text = lsMensagemOperacao;
            }
            else
            {
                this.div_msg_alterar_livro.Visible = true;
                this.lbl_msg_alterar_livro.Text = "Seu livro foi alterado com sucesso!";
                this.PreencheGridLivrosUsuario();
            }
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "abrir_popup", "<script> $('#edit').modal('show'); </script>", false);
        }

        // REFAZER!
        protected void ExcluirLivro(object sender, EventArgs e)
        {
            Entity.Usuario loUsuarioDesativadoLivro = new Entity.Usuario(string.Empty, string.Empty, string.Empty, string.Empty);
            loUsuarioDesativadoLivro.USR_id = (int)Session["ID_Usuario"];
            Entity.Livro loExcluirLivro = new Entity.Livro(string.Empty, Convert.ToInt32(string.Empty), (Convert.ToInt32(string.Empty) - Convert.ToInt32(string.Empty)), loUsuarioDesativadoLivro.USR_id);
            if (HttpContext.Current.Session["selecao_livro"] != null)
                loExcluirLivro.LVR_id = Convert.ToInt32(HttpContext.Current.Session["selecao_livro"].ToString());
            string lsMensagem = string.Empty;
            new Business.Livro().RemoverLivro(loExcluirLivro, out lsMensagem);
            this.PreencheGridLivrosUsuario();
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


