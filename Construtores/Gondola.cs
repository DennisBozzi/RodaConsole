using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodaConsole.Construtores
{
    internal class Gondola
    {
        public int numero;
        public Pessoa assento1;
        public Pessoa assento2;

        public Gondola(int numero, Pessoa assento1)
        {
            this.numero = numero;
            this.assento1 = assento1;
        }

        public Gondola(int numero, Pessoa assento1, Pessoa assento2) : this(numero, assento1)
        {
            this.assento2 = assento2;
        }
    }
}
