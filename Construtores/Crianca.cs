using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodaConsole.Construtores
{
    internal class Crianca : Pessoa
    {

        public Adulto adulto;

        public Crianca(string nome, int idade, Adulto adulto) : base(nome, idade)
        {
            this.adulto = adulto;
        }

        public Crianca(String nome, int idade) : base(nome, idade)
        {
            this.adulto = null;
        }
    }
}
