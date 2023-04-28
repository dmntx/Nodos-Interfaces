using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodos_Interfaces
{
    class ProgramaGenetico
    {
        private int pop_size, generations, max_trees_depth, vector_size;
        private Arbol[] population;
        private Arbol[] offspring;
        GeneticOp op1;

        public ProgramaGenetico(int pop_s, int gen, int max_depth, int vector_s, string method)
        {
            pop_size = pop_s;
            generations = gen;
            max_trees_depth = max_depth;
            vector_size = vector_s;

            population = new Arbol[pop_size];
            offspring = new Arbol[pop_size];

            op1 = new SimpleCrossover();

            for(int i = 0; i<pop_size; i++)
            {
                population[i] = new Arbol(max_trees_depth, vector_size);
                population[i].init_random_tree();
            }
        }
        public Arbol fit()
        {
            var rand = new Random();
            double val = pop_size / 2;
            Arbol tree1, tree2;

            for(int g = 1; g < generations; g++)
            {
                for(int i = 0; i< pop_size; i++)
                {
                    population[i].fitness_eval();
                }

                for(int i=0; i < Math.Round(val); i++)
                {
                /*tree1 = population[rand.Next(pop_size)];
                tree2 = population[rand.Next(pop_size)];
                */
                    tree1 = selection_method.select(population);
                    op1.oper(tree1, tree2);

                    offspring[i] = op1.offspring1;
                    offspring[i + Convert.ToInt32(Math.Round(val))] = op1.offspring2;
                }

                for(int i = 0; i < Math.Round(val); i++)
                {
                    population[rand.Next(pop_size)] = offspring[rand.Next(pop_size)];
                }
            }
            return population[0];
        }

        public Arbol RandomChoice(Arbol[] population)
        {
            var rand = new Random();
            int pop_size;
            pop_size = population.Length;
            return population[rand.Next(pop_size)];
        }
    }
}
