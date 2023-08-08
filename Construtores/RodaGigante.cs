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

        public RodaGigante()
        {
            rodaGigante = new List<Gondola>();
        }

        public void embarcar(int numeroGondola, params Pessoa[] pessoas)
        {

            Pessoa pessoa = pessoas[0];

            Crianca crianca = pessoa as Crianca;

            bool isAcompanhado = pessoas.Length >= 2; //Confere se possui um acompanhante

            bool gondolaOcupada = true;

            //Conferindo se a Gôndola está ocupada
            foreach (Gondola gondola in rodaGigante)
            {
                if (gondola.numero == numeroGondola)
                {
                    gondolaOcupada = false;
                }
            }

            //--- Não embarcados ----
            if (!gondolaOcupada) //Caso a conferência da gôndola diga que ela está ocupada
            {
                Console.WriteLine($"ERRO: Gôndola {numeroGondola} já está ocupada");
                return;
            }

            if (pessoas.Length > 2) //Caso passem como argumento mais do que 2 pessoas no método
            {
                Console.WriteLine($"ERRO: Pessoa: {pessoas[0].nome} - Não é possível embarcar mais do que duas pessoas.");
                return;
            }

            if (crianca.idade < 12) //Caso a criança não esteja acompanhada de seu adulto cadastrado
            {
                if (isAcompanhado)
                {
                    if (pessoas[1] != crianca.adulto)
                    {
                        Console.WriteLine($"ERRO: Pessoa: {crianca.nome} - A pessoa que está acompanhando a criança não é seu responsável.");
                        return;
                    }
                }
            }

            if (crianca.idade < 12 && !isAcompanhado) //Caso seja menor de 12 anos e não esteja acompanhado de seu responsável
            {
                Console.WriteLine($"ERRO: Pessoa: {crianca.nome} - É menor de 12 anos e não está acompanhado.");
                return;
            }

            //--- Embarcados ---
            if (isAcompanhado) //Caso esteja acompanhado de seu responsável cadastrado
            {
                if (crianca.adulto == pessoas[1])
                {
                    Console.WriteLine($"OK: Pessoa: {crianca.nome} - Possui um acompanhante: {pessoas[1].nome}");
                    Gondola newGondola = new Gondola(numeroGondola, crianca, pessoas[1]);
                    rodaGigante.Add(newGondola);
                    return;
                }
            }

            if (crianca.idade >= 12) //Caso seja maior de 12 anos
            {
                Console.WriteLine($"OK: Pessoa: {crianca.nome} - Possui mais do que 12 anos, pode ir sozinho.");
                Gondola newGondola = new Gondola(numeroGondola, crianca);
                rodaGigante.Add(newGondola);
                return;
            }
        }

        //Printando o status da gondola
        public void status()
        {
            Console.WriteLine();
            Console.WriteLine("Gôndola Status");
            Console.WriteLine("-----------------");



            for (int i = 1; i <= 18; i++) // Loop pelas gôndolas possíveis
            {
                var gondola = rodaGigante.Find(g => g.numero == i);

                if (gondola == null)
                {
                    Console.WriteLine($"{i} (vazia)");
                    continue;
                }

                string passageirosInfo = "";

                if (gondola.assento1 != null)
                {
                    passageirosInfo += gondola.assento1.nome;
                }

                if (gondola.assento2 != null)
                {
                    if (!string.IsNullOrEmpty(passageirosInfo))
                    {
                        passageirosInfo += " e ";
                    }
                    passageirosInfo += gondola.assento2.nome;
                }

                if (string.IsNullOrEmpty(passageirosInfo))
                {
                    passageirosInfo = "(vazia)";
                }

                // Filtra crianças menores de 12 anos não acompanhadas por um adulto
                if (!passageirosInfo.Contains("e") && gondola.assento1 is Crianca crianca && crianca.idade < 12 && crianca.adulto == null)
                {
                    continue; // Pula essa gôndola no status
                }

                Console.WriteLine($"{i} {passageirosInfo}");
            }
        }
    }

}
