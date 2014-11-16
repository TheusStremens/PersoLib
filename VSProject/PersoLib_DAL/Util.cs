using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersoLib_DAL
{
    public static class Util
    {

        public static bool VerificaValidadeEmail(string strEmail, out string lsMensagemOperacao)
        {
            lsMensagemOperacao = string.Empty;
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (!(System.Text.RegularExpressions.Regex.IsMatch(strEmail, strModelo)))
            {
                lsMensagemOperacao = "Formato de email incorreto!";
                return false;
            }
            return true;
        }

        public static bool VerificaTamanhoSenha(string str_Senha, out string lsMensagemOperacao)
        {
             lsMensagemOperacao = string.Empty;
            if (str_Senha.Length < 4 || str_Senha.Length >= 12)
            {
                lsMensagemOperacao = "A senha deve conter de 4 a 12 caracteres!";
                return false;
            }
            return true;
        }

        public static bool VerificaIgualdadeSenha(string str_Senha, string str_Repete_Senha, out string lsMensagemOperacao)
        {
            lsMensagemOperacao = string.Empty;
            if (String.Compare(str_Senha, str_Repete_Senha, false) != 0)
            {
                lsMensagemOperacao = "O campo 'repete senha' deve ser igual ao 'campo senha'!";
                return false;
            }
            return true;
        }

        public static bool VerificarNome(string str_Nome, out string lsMensagemOperacao)
        {
            lsMensagemOperacao = string.Empty;
            if (str_Nome.Length < 3)
            {
                lsMensagemOperacao = "Nome de tamanho invalido!";
                return false;
            }
            return true;
        }

       

    }
}
