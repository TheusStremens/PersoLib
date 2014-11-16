using System;


namespace PersoLib_DAL
{
    public static partial class Business
    {
        public class Usuario
        {
            internal bool VerificaExistenciaEmail(Entity.Usuario aoUsuario, out string lsMensagemOperacao)
            {
                lsMensagemOperacao = string.Empty;
                if (new DAL.Usuario().ExisteUsuarioEmail(aoUsuario) != 1)
                {
                    lsMensagemOperacao = "Email esta errado ou não existe cadastro!";
                    return false;
                }
                return true;
            }

            internal bool InserirNovoUsuario(Entity.Usuario aoUsuario, out string lsMensagemOperacao)
            {
                lsMensagemOperacao = string.Empty;
                bool lbValidado = true;

                //Confere se o nome da pessoa é muito curto
                if (!(Util.VerificarNome(aoUsuario.USR_nome,out lsMensagemOperacao)))
              {
                    lbValidado = false;
              }

                // Confere se email é valido
                if (!(Util.VerificaValidadeEmail(aoUsuario.USR_email, out lsMensagemOperacao)))
                {
                  lbValidado = false;
              }
                //Confere se o email informa ja foi utilizado
                if (!(VerificaExistenciaEmail(aoUsuario, out lsMensagemOperacao)))
              {
                  lbValidado = false;
              }

                //Confere se tamanho da senha é valido
                if (!(Util.VerificaTamanhoSenha(aoUsuario.USR_senha, out lsMensagemOperacao)))
              {
                  lbValidado = false;
              }

                // Confere se os campos 'senha' e 'repete senha' são iguais
                if (!(Util.VerificaIgualdadeSenha(aoUsuario.USR_senha, aoUsuario.USR_repete_senha, out lsMensagemOperacao)))
              {
                  lbValidado = false;
              }

                if (lbValidado)
                {
                    if (new DAL.Usuario().InserirNovoUsuario(aoUsuario) != 1)
                    {
                        lsMensagemOperacao = "Ocorreu um erro no servidor. Tente novamente mais tarde!";
                        lbValidado = false;
                    }
                }

                return lbValidado;
            }

            
            internal int VerificarLogin(Entity.Usuario aoUsuario, out string lsMensagemOperacao)
            {
                lsMensagemOperacao = string.Empty;

                if (!(VerificaExistenciaEmail(aoUsuario, out lsMensagemOperacao)))
                {
                    return -1;
                }
                else if (new DAL.Usuario().LoginUsuario(aoUsuario) == -1)
                    {
                        lsMensagemOperacao = "Senha invalida para este login!";
                        return -1;
                    }
                
                return new DAL.Usuario().LoginUsuario(aoUsuario);
            }

            internal bool AlterarUsuaio(Entity.Usuario aoUsuario, out string lsMensagemOperacao)
            {
                lsMensagemOperacao = string.Empty;
                bool lbValidado = true;

                //Confere se o nome da pessoa é muito curto
                if (!(Util.VerificarNome(aoUsuario.USR_nome, out lsMensagemOperacao)))
                {
                    lbValidado = false;
                }

                // Confere se email é valido
                if (!(Util.VerificaValidadeEmail(aoUsuario.USR_email, out lsMensagemOperacao)))
                {
                    lbValidado = false;
                }
                //Confere se o email informa ja foi utilizado
                if (!(VerificaExistenciaEmail(aoUsuario, out lsMensagemOperacao)))
                {
                    lbValidado = false;
                }

                //Confere se tamanho da senha é valido
                if (!(Util.VerificaTamanhoSenha(aoUsuario.USR_senha, out lsMensagemOperacao)))
                {
                    lbValidado = false;
                }

                // Confere se os campos 'senha' e 'repete senha' são iguais
                if (!(Util.VerificaIgualdadeSenha(aoUsuario.USR_senha, aoUsuario.USR_repete_senha, out lsMensagemOperacao)))
                {
                    lbValidado = false;
                }

                if(string.IsNullOrEmpty(aoUsuario.USR_nome) || string.IsNullOrEmpty(aoUsuario.USR_email){
                    lsMensagemOperacao = "Algum campo não foi preenchido. Favor Verificar dados!";
                }

                if (lbValidado)
                {
                    if(new DAL.Usuario().AtualizarDadosUsuario(aoUsuario) == -1){
                        lsMensagemOperacao = "Ocorreu algum erro no servidor!";
                        lbValidado = false;
                    }
                }

                return lbValidado;
            }

        }
    }
}