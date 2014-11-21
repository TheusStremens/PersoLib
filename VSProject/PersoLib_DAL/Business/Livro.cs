using System.Collections.Generic;
namespace PersoLib_DAL
{
    public static partial class Business
    {
        public class Livro
        {
            public bool InserirNovoLivro(Entity.Livros aoLivro, out string lsMensagemOperacao)
            {
                lsMensagemOperacao = string.Empty;
                bool lbValidado = true;

                // Confere se o nome do livro é muito curto
                if (!(Util.VerificarNome(aoLivro.LVR_nome)))
                {
                    lsMensagemOperacao = "Nome do livro de tamanho invalido!";
                    lbValidado = false;
                }

                if (lbValidado)
                {
                    if (new DAL.Livros().InserirNovoLivro(aoLivro) != 1)
                    {
                        lsMensagemOperacao = "Ocorreu um erro no servidor. Tente novamente mais tarde!";
                        lbValidado = false;
                    }
                }

                return lbValidado;

            }

            public bool AlterarLivro(Entity.Livros aoLivro, out string lsMensagemOperacao)
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

                if (!(Util.VerificarQuantidade(aoLivro.LVR_disponivel)))
                {
                    lsMensagemOperacao = "Quantidade de livros inválida!";
                    lbValidado = false;
                }

                if (lbValidado)
                {
                    if (new DAL.Livros().AtualizarDadosLivro(aoLivro) == -1)
                    {
                        lsMensagemOperacao = "Ocorreu algum erro no servidor!";
                        lbValidado = false;
                    }
                }

                return lbValidado;
            }

            public bool RemoverLivro(Entity.Livros aoLivro, out string lsMensagemOperacao)
            {
                lsMensagemOperacao = string.Empty;

                if (new DAL.Livros().RemoverLivro(aoLivro) == -1)
                {
                    lsMensagemOperacao = "Ocorreu algum erro! Tente novamente!";
                    return false;
                }
                return true;
            }
            }


        }
    }
}
