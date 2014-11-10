using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersoLib
{
    public class Usuario
    {
        private int USR_id { set; get; }
        private string USR_email { set; get; }
        private string USR_nome { set; get; }
        private string USR_senha { set; get; }

        public Usuario(string aUSR_email, string aUSR_nome, string aUSR_senha)
        {
            this.USR_email = aUSR_email;
            this.USR_nome = aUSR_nome;
            this.USR_senha = aUSR_senha;
        }
    }
}