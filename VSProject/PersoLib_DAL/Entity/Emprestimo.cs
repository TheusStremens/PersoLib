using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersoLib_DAL
{
    public partial class Entity
    {
        public class Emprestimo
        {
            public int EMP_id { set; get; }
            public int EMP_id_livro { set; get; }
            public int EMP_id_usuario { set; get; }
            public string EMP_email_emprestante { set; get; }
            public string EMP_nome_emprestante { set; get; }
            public DateTime EMP_devolucao { set; get; }
            

            public Emprestimo(int aEMP_id_livro, int aEMP_id_usuario, string aEMP_email_emprestante,
                                string aEMP_nome_emprestante, DateTime aEMP_devolucao)
            {
                this.EMP_id_livro = aEMP_id_livro;
                this.EMP_id_usuario = aEMP_id_usuario;
                this.EMP_email_emprestante = aEMP_email_emprestante;
                this.EMP_nome_emprestante = aEMP_nome_emprestante;
                this.EMP_devolucao = aEMP_devolucao;
            } 
        }
    }
}
