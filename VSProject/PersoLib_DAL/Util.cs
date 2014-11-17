using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersoLib_DAL
{
    public static class Util
    {

        public static bool VerificaValidadeEmail(string strEmail)
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (!(System.Text.RegularExpressions.Regex.IsMatch(strEmail, strModelo)))
            {
                return false;
            }
            return true;
        }

        public static bool VerificaTamanhoSenha(string str_Senha)
        {
            if (str_Senha.Length < 4 || str_Senha.Length >= 12)
            {
                return false;
            }
            return true;
        }

        public static bool VerificaIgualdadeSenha(string str_Senha, string str_Repete_Senha)
        {
            if (String.Compare(str_Senha, str_Repete_Senha, false) != 0)
            {
                return false;
            }
            return true;
        }

        public static bool VerificarNome(string str_Nome)
        {
            if (str_Nome.Length < 3)
            {
                return false;
            }
            return true;
        }

       

    }
}
