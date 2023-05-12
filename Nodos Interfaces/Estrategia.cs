using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Nodos_Interfaces
{
    public abstract class Estrategia
    {
        public Arbol[] population;
        public string metodo;
        public Estrategia(string metodo)
        {
            this.population[0] = new Arbol(2,2);
        }
        public abstract Arbol ejecutar(Arbol[] population);
    }

    public class RandomChoice : Estrategia
    {

            public RandomChoice() : base("Random")
            {
            
            }
            public override Arbol ejecutar(Arbol[] population) {
                var aux = new Random();

                int popSize = population.Length;
                return population[aux.Next(popSize)];
            }
    }
    public class BinaryTournament : Estrategia
    {

        public BinaryTournament():base("Estrategia BinaryTournament")
        {

        }

        public override Arbol ejecutar(Arbol[] population) {
            int pop_size;
            Arbol a1, a2, BinaryTournament;

            var aux = new Random();

            pop_size = population.Length;
            a1 = population[aux.Next(pop_size)];
            a2 = population[aux.Next(pop_size)];

            if (a1.fitness_value < a2.fitness_value)
            {
                BinaryTournament = a1;
            }
            else
            {
                BinaryTournament = a2;
            }

            return BinaryTournament;
        }
    }
}
