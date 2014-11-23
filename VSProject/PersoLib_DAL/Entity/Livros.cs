using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersoLib_DAL
{
    public partial class Entity
    {
        public class Livros
        {
            public int LVR_id { set; get; }
            public string LVR_nome { set; get; }
            public int LVR_emprestado { set; get; }
            public int LVR_disponivel { set; get; }
            public int LVR_id_usuario { set; get; }

            public Livros(string aLVR_nome, int aLVR_disponivel, int aLVR_id_usuario)
            {
                this.LVR_nome = aLVR_nome;
                this.LVR_emprestado = aLVR_disponivel;
                this.LVR_disponivel = aLVR_disponivel;
                this.LVR_id_usuario = aLVR_id_usuario;
            }
        }
    }
}
