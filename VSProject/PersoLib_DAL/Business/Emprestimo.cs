using System.Collections.Generic;
namespace PersoLib_DAL
{
    public static partial class Business
    {
        public class Emprestimo
        {
                       
            public bool InserirNovoEmprestimo(Entity.Livro aoLivro, Entity.Emprestimo aoEmprestimo, out string lsMensagemOperacao)
            {
                lsMensagemOperacao = string.Empty;
                bool lbValidado = true;
                
                //Confere se o nome da pessoa é muito curto
                if (!(Util.VerificarNome(aoEmprestimo.EMP_nome_emprestante)))
                {
                    lsMensagemOperacao = "Nome de tamanho invalido!";
                    lbValidado = false;
                }
                
                // Confere se email é valido
                if (!(Util.VerificaValidadeEmail(aoEmprestimo.EMP_email_emprestante)))
                {
                    lsMensagemOperacao = "Formato de email incorreto!";
                    lbValidado = false;
                }
                //Confere se a data é valida
                if (!Util.VerificaData(aoEmprestimo.EMP_devolucao))
                {
                    lsMensagemOperacao = "A data não pode ser anterior ao dia atual";
                    lbValidado = false;
                }
                
                if (lbValidado)
                {
                    if (new DAL.Emprestimo().RealizarEmprestimo(aoLivro, aoEmprestimo) != 2)
                    {
                        lsMensagemOperacao = "Ocorreu um erro no servidor. Tente novamente mais tarde!";
                        lbValidado = false;
                    }
                }

                return lbValidado;
            }

            //Altera o prazo de entrega do livro emprestado
            public bool AlterarPrazo(Entity.Emprestimo aoEmprestimo, out string lsMensagemOperacao)
            {
                lsMensagemOperacao = string.Empty;
                bool lbValidado = true;

                //Confere se a data é valida
                if (!Util.VerificaData(aoEmprestimo.EMP_devolucao))
                {
                    lsMensagemOperacao = "A data não pode ser anterior ao dia atual";
                    lbValidado = false;
                }

                if (lbValidado)
                {
                    if (new DAL.Emprestimo().AlterarPrazoEmprestimo(aoEmprestimo) == -1)
                    {
                        lsMensagemOperacao = "Ocorreu algum erro no servidor!";
                        lbValidado = false;
                    }
                }

                return lbValidado;
            }

            //Carrega dados do emprestimo utilizando o ID do Usuario
            public List<Entity.Emprestimo> CarregarEmprestimos(Entity.Usuario aoUsuario)
            {
                List<Entity.Emprestimo> loEmprestimo = new DAL.Emprestimo().CarregarEmprestimosUsuario(aoUsuario.USR_id);
                return loEmprestimo;
            }
            
            //Finaliza um emprestimo usando ID do livro e ID do emprestimo
            public bool RealizaDevolucao(Entity.Emprestimo aoEmprestimo,out string lsMensagemOperacao)
            {
                lsMensagemOperacao = string.Empty;
                if (new DAL.Emprestimo().DevolverEmprestimo(aoEmprestimo) == -1)
                {
                    lsMensagemOperacao = "Ocorreu algum erro! Tente novamente!";
                    return false;
                }
                return true;
            }

        }
    }
}
