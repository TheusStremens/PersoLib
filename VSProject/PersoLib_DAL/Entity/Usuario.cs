using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersoLib_DAL
{
    public partial class Entity
    {
        public class Usuario
        {
            public int USR_id { set; get; }
            public string USR_email { set; get; }
            public string USR_nome { set; get; }
            public string USR_senha { set; get; }
            public string USR_repete_senha { set; get; }
            public bool USR_ativo { set; get; }

            public Usuario(string aUSR_email, string aUSR_nome, string aUSR_senha, string aUSR_repete_senha)
            {
                this.USR_email = aUSR_email;
                this.USR_nome = aUSR_nome;
                this.USR_senha = aUSR_senha;
                this.USR_repete_senha = aUSR_repete_senha;
            }
        }
    }
}