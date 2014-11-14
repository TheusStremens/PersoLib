using PersoLib.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersoLib.Business
{
    public class BUsuario
    {
        public Usuario USUARIO { set; get; }

        public BUsuario(Usuario aoUsuario)
        {
            this.USUARIO = aoUsuario;
        }

        public bool InserirNovoUsuario(out string lsMensagemOperacao)
        {
            if(String.Compare(this.USUARIO.USR_senha, this.USUARIO.USR_repete_senha, false) != 0)
            {
                lsMensagemOperacao = "O campo repete senha deve ser igual ao campo senha!";
                return false;
            }
            DALUsuario loDALUsuario = new DALUsuario(this.USUARIO);
            if (loDALUsuario.InsertUsuario() == 1)
            {
                lsMensagemOperacao = "Operação realizada com sucesso!";
                return true;
            }
            else
            {
                lsMensagemOperacao = "Ocorreu um erro no servidor. Tente novamente mais tarde!";
                return false;
            }                
        }
    }
}