using System.Collections.Generic;
namespace PersoLib_DAL
{
    public static partial class Business
    {
        public class Livros
        {

            public bool VerificarLivroExistente(Entity.Livros aoLivros)
            {
                if (new DAL.Livros().ExisteLivro(aoLivros.LVR_nome) == 1)
                {
                    return true;
                }
                return false;
            }

            public bool VerificarLivroExistenteAlterar(Entity.Livros aoLivros)
            {
                if (new DAL.Livros().ExisteLivroAlterar(aoLivros.LVR_nome, aoLivros.LVR_id) == 1)
                {
                    return true;
                }
                return false;
            }

            public bool InserirNovoLivro(Entity.Livros aoLivros, out string lsMensagemOperacao)
            {
                lsMensagemOperacao = string.Empty;
                bool lbValidado = true;

                // Confere se o nome do livro é muito curto
                if (!(Util.VerificarNome(aoLivros.LVR_nome)))
                {
                    lsMensagemOperacao = "Nome do livro de tamanho invalido!";
                    lbValidado = false;
                }

                // Confere se o nome do livro já existe
                if (VerificarLivroExistente(aoLivros))
                {
                    lsMensagemOperacao = "Livro com este nome já existe!";
                    lbValidado = false;
                }

                if (lbValidado)
                {
                    if (new DAL.Livros().InserirNovoLivro(aoLivros) != 1)
                    {
                        lsMensagemOperacao = "Ocorreu um erro no servidor. Tente novamente mais tarde!";
                        lbValidado = false;
                    }
                }

                return lbValidado;

            }

            public bool AlterarLivro(Entity.Livros aoLivros, out string lsMensagemOperacao)
            {
                lsMensagemOperacao = string.Empty;
                bool lbValidado = true;

                if (string.IsNullOrEmpty(aoLivros.LVR_nome))
                {
                    lsMensagemOperacao = "O campo Nome do Livro não pode ser vazio!";
                    lbValidado = false;
                }

                if (!(Util.VerificarNome(aoLivros.LVR_nome)))
                {
                    lsMensagemOperacao = "Nome do Livro de tamanho inválido!";
                    lbValidado = false;
                }

                if (VerificarLivroExistenteAlterar(aoLivros))
                {
                    lsMensagemOperacao = "Livro com este nome já existe!";
                    lbValidado = false;
                }

                if (!(Util.VerificarQuantidade(aoLivros.LVR_disponivel)))
                {
                    lsMensagemOperacao = "Quantidade de livros inválida!";
                    lbValidado = false;
                }

                if (lbValidado)
                {
                    if (new DAL.Livros().AtualizarDadosLivro(aoLivros) == -1)
                    {
                        lsMensagemOperacao = "Ocorreu algum erro no servidor!";
                        lbValidado = false;
                    }
                }

                return lbValidado;
            }

            public bool RemoverLivro(Entity.Livros aoLivros, out string lsMensagemOperacao)
            {
                lsMensagemOperacao = string.Empty;

                if (new DAL.Livros().RemoverLivro(aoLivros) == -1)
                {
                    lsMensagemOperacao = "Ocorreu algum erro! Tente novamente!";
                    return false;
                }
                return true;
            }

            public bool EmprestarLivro(Entity.Livros aoLivros, out string lsmensagemOperacao)
            {
                lsMensagemOperacao = string.Empty;

                if (new DAL.Livros().EmprestarLivro(aoLivros) == -1)
                {
                    lsMensagemOperacao = "Ocorreu algum erro! Tente novamente!";
                    return false;
                }
            }
        }


        }
    }
}
