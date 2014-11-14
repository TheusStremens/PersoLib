using MySql.Data.MySqlClient;
using PersoLib.Business;
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
            Usuario loNovoUsuario = new Usuario(this.txt_email_cadastro.Value.ToString(), this.txt_name.Value.ToString(), this.txt_senha.Value.ToString(), this.txt_repete_senha.Value.ToString());
            string lsMensagemOperacao = String.Empty;
            BUsuario loBUsario = new BUsuario(loNovoUsuario);
            if(loBUsario.InserirNovoUsuario(out lsMensagemOperacao))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "abrir_popup", "<script> $('#modal_cadastrado_sucesso').modal('show'); </script>", false);
            }
            else
            {
                this.div_mensagem_modal.Visible = true;
                this.lbl_mensagem_modal.Text = lsMensagemOperacao;
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "abrir_popup", "<script> $('#modal_cadastro').modal('show'); </script>", false);
            }
        }      
    }
}