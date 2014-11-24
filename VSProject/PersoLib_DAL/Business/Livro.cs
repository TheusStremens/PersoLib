using System.Collections.Generic;
namespace PersoLib_DAL
{
    public static partial class Business
    {
        public class Livro
        {

            public bool VerificarLivroExistente(Entity.Livro aoLivro)
            {
                if (new DAL.Livro().ExisteLivroNome(aoLivro) == 1)
                {
                    return true;
                }
                return false;
            }
           

            public bool InserirNovoLivro(Entity.Livro aoLivro, Entity.Usuario aoUsuario, out string lsMensagemOperacao)
            {
                lsMensagemOperacao = string.Empty;
                bool lbValidado = true;

                // Confere se o nome do livro é muito curto
                if (!(Util.VerificarNome(aoLivro.LVR_nome)))
                {
                    lsMensagemOperacao = "Nome do livro de tamanho invalido!";
                    lbValidado = false;
                }

                // Confere se o nome do livro já existe
                if (VerificarLivroExistente(aoLivro))
                {
                    lsMensagemOperacao = "Livro com este nome já existe!";
                    lbValidado = false;
                }

                if (lbValidado)
                {
                    if (new DAL.Livro().InserirNovoLivro(aoLivro, aoUsuario) != 1)
                    {
                        lsMensagemOperacao = "Ocorreu um erro no servidor. Tente novamente mais tarde!";
                        lbValidado = false;
                    }
                }

                return lbValidado;

            }

            public bool AlterarLivro(Entity.Livro aoLivro, out string lsMensagemOperacao)
            {
                lsMensagemOperacao = string.Empty;
                bool lbValidado = true;

                if (string.IsNullOrEmpty(aoLivro.LVR_nome))
                {
                    lsMensagemOperacao = "O campo Nome do Livro não pode ser vazio!";
                    lbValidado = false;
                }

                if (!(Util.VerificarNome(aoLivro.LVR_nome)))
                {
                    lsMensagemOperacao = "Nome do Livro de tamanho inválido!";
                    lbValidado = false;
                }

                if (VerificarLivroExistente(aoLivro))
                {
                    lsMensagemOperacao = "Livro com este nome já existe!";
                    lbValidado = false;
                }

                if (!(Util.VerificarQuantidade(aoLivro.LVR_disponivel)))
                {
                    lsMensagemOperacao = "Quantidade de Livro inválida!";
                    lbValidado = false;
                }

                if (lbValidado)
                {
                    if (new DAL.Livro().AtualizarDadosLivro(aoLivro) == -1)
                    {
                        lsMensagemOperacao = "Ocorreu algum erro no servidor!";
                        lbValidado = false;
                    }
                }

                return lbValidado;
            }

            public bool RemoverLivro(Entity.Livro aoLivro, out string lsMensagemOperacao)
            {
                lsMensagemOperacao = string.Empty;

                if (new DAL.Livro().RemoverLivro(aoLivro) == -1)
                {
                    lsMensagemOperacao = "Ocorreu algum erro! Tente novamente!";
                    return false;
                }
                return true;
            }

            public List<Entity.Livro> CarregarLivro(Entity.Usuario aoUsuario, out string lsMensagemOperacao)
            {
                lsMensagemOperacao = string.Empty;
              
                List<Entity.Livro> loLivro = new DAL.Livro().CarregarLivrosUsuario(aoUsuario.USR_id);
                if(loLivro == null)
                        lsMensagemOperacao = "Ocorreu algum erro! Tente novamente!";

                else
                {
                    if (loLivro.Count == 0)                
                        lsMensagemOperacao = "Voce não realizou empréstimos.";
                
                }
                return loLivro;
            }

        }
    }
}
