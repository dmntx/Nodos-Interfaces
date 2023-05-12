using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodos_Interfaces
{
    public abstract class GeneticOp
    {
        public Arbol offspring1, offspring2;
        public abstract void oper(Arbol parent1, Arbol parent2);
    }
    public class SimpleCrossover : GeneticOp
    {
        public SimpleCrossover()
        {

        }
        public void subtree_swap(int nodo1, int nodo2)
        {
            Nodo n1, n2, p1, p2, r1, r2;

            r1 = offspring1.nodos[0];
            r2 = offspring2.nodos[0];
            n1 = offspring1.nodos[nodo1];
            n2 = offspring2.nodos[nodo2];
            p1 = offspring1.nodos[nodo1].parent;
            p2 = offspring2.nodos[nodo2].parent;

            if (p1.izq == n1)
            {
                p1.izq = n2;
            }
            else
            {
                p1.der = n2;
            }
            if(p2.izq == n2)
            {
                p2.izq = n1;
            }
            else
            {
                p2.der = n1;
            }

            offspring1.insertarNodo(r1, 0);
            offspring2.insertarNodo(r2, 0);
            /////////////
            offspring1.update_node_depth(r1, 0);
            offspring2.update_node_depth(r2, 0);
            /////////////
            offspring1.update_subtree_depth(r1);
            offspring2.update_subtree_depth(r2);

        }
        public override void oper(Arbol parent1, Arbol parent2)
        {
            int n1, n2;
            offspring1 = parent1.clonar();
            offspring2 = parent2.clonar();
            var rand = new Random();
            n1 = rand.Next(offspring1.conteoNodos);
            while (n1 == 0)
            {
                n1 = rand.Next(offspring1.conteoNodos);
            }
            n2 = rand.Next(offspring2.conteoNodos);
            while(n2 == 0)
            {
                n2 = rand.Next(offspring2.conteoNodos);
            }
            subtree_swap(n1, n2);
        }
    }
    public class geneticDecorator : GeneticOp
    {
        public GeneticOp base_operator;
        public geneticDecorator(GeneticOp oper_base)
        {
            this.base_operator = oper_base;
            offspring1 = new Arbol(0, 0);
            offspring2 = new Arbol(0, 0);
        }


        public override void oper(Arbol parent1, Arbol parent2)
        {
            base_operator.oper(parent1, parent2);
        }
    }
    /*public class protectedCrossover : geneticDecorator
    {
        GeneticOp base_operator;
        public protectedCrossover(SimpleCrossover b_op)
        {
            throw new NotImplementedException();
        }
        public override void oper(Arbol parent1, Arbol parent2)
        {
            int n1, n2;
            offspring1 = parent1.clonar();
            offspring2 = parent2.clonar();

        }
    }*/
    public class Mutation : geneticDecorator
    {
        public Mutation(GeneticOp oper_base) : base(oper_base)
        {
            base_operator = oper_base;
        }
        public override void oper(Arbol padre1, Arbol padre2)
        {
            //Creación de nuevo árbol
            Arbol padreNuevo =
            new Arbol(padre2.profundidad, padre2.input_vector_size);
            padreNuevo.init_random_tree();

            //Realización de crossover simple
            // CrossOverSimple cruce = CrossOverSimple.create();

            base_operator.offspring1 = padre1.clonar();
            base_operator.offspring2 = padreNuevo.clonar();

            //print("Arbol susituto: " + padreNuevo.valor + '\n');

            //cruce.operar(padre1, padreNuevo);
            base_operator.oper(padre1, padreNuevo);

            //Asignación de árboles mutados a progenie1 y progenie2
            offspring1 = base_operator.offspring1;
            offspring2 = base_operator.offspring2;
        }
    }

}
