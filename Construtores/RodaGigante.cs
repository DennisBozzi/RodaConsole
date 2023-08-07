using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodaConsole.Construtores
{
    internal class RodaGigante
    {
        public List<Gondola> rodaGigante;

        public RodaGigante() { }


        public void embarcar(int numero, Crianca crianca)
        {

            if (crianca.idade >= 12 || crianca.adulto != null)
            {
                Gondola novaGondola = new Gondola(numero, crianca);
                rodaGigante.Add(novaGondola);
                Console.WriteLine($"{crianca.nome} embarcou na gondola {numero}");
            }
            else
            {

                Console.WriteLine($"{crianca}, não é maior de 12 anos e não está acompanhada");

            }

        }


    }
}
