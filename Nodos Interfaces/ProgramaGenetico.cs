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
        Estrategia estrategia;
        GeneticOp crossover;

        public ProgramaGenetico(int pop_s, int gen, int max_depth, int vector_s, Estrategia estrategia, GeneticOp crossover)
        {
            pop_size = pop_s;
            generations = gen;
            max_trees_depth = max_depth;
            vector_size = vector_s;

            population = new Arbol[pop_size];
            offspring = new Arbol[pop_size];

            this.estrategia = estrategia;
            this.crossover = crossover;

            /*for(int i = 0; i<pop_size; i++)
            {
                population[i] = new Arbol(max_trees_depth, vector_size);
                population[i].init_random_tree();
            }*/
        }
        public Arbol fit()
        {
            var rand = new Random();
            double val = pop_size / 2;
            Arbol tree1, tree2;
            Arbol fit;
            string nombre = estrategia.metodo;

                for (int i = 0; i < pop_size; i++)
                {
                    population[i] = new Arbol(max_trees_depth, vector_size);
                    population[i].init_random_tree();
                    //print("Creando árbol $i de la población inicial");
                }

                //Ciclo evolutivo
                for (int g = 0; g < generations; g++)
                {
                    //Evaluación de la población
                    for (int i = 0; i < pop_size; i++)
                    {
                        population[i].fitness_eval();
                        //print("Evaluando árbol $i de la población");
                    }

                    //Generación de hijos
                    //División entera donde el resultado es redondeado al número entero más cercano
                    for (int i = 0; i < pop_size / 2 ; i++){

                    // Elección de dos padres de acuerdo 
                    // a la estrategia seleccionada
                    tree1 = estrategia.ejecutar(population);
                    tree2 = estrategia.ejecutar(population);

                    //print("Original 1: " + a1.valor);
                    //print("Original 2: " + a2.valor + '\n');

                    //Relización de la cruza (crossover)
                    //crossover.operar(a1, a2);
                    crossover.oper(tree1, tree2);


                    //Guardar los hijos en un arreglo (lista) temporal
                    //offspring[i] = crossover.progenie1;
                    //offspring[i + (pop_size~/2)] = crossover.progenie2;

                    offspring[i] = crossover.offspring1;
                    offspring[i + (pop_size / 2)] = crossover.offspring2;

                    //print("Árbol mutado 1: " + crossover_decorado.progenie1.valor);
                    //print("Árbol mutado 2: " + crossover_decorado.progenie2.valor + '\n');
                    //print("Generando hijos $i y ${i + (pop_size~/2)}");
                }

                // Reemplazar los elementos de la población original con los hijos generados
                for (int i = 0; i <= (pop_size / 2) ; i++){
                    //Reemplazo al azar
                    population[rand.Next(pop_size)] = offspring[rand.Next(pop_size)];
                    //print("Reemplazando árbol en la posición ${aux.nextInt(pop_size)} de la población");
                }
            }
            Console.WriteLine("Proceso terminado");
            Console.WriteLine(nombre);

            fit = population[0];
            return fit;
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
