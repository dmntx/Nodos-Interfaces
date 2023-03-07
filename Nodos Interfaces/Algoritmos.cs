using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodos_Interfaces
{
    public abstract class GeneticOp
    {
        private Arbol offspring1, offspring2;
        public abstract void oper(Arbol parent1, Arbol parent2);
    }

    public class simpleCrossover : GeneticOp
    {
        public void subtree_swap(int nodo1, int nodo2)
        {

        }
        public override void oper(Arbol parent1, Arbol parent2)
        {
            throw new NotImplementedException();
        }
    }
    public class geneticDecorator : GeneticOp
    {
        private geneticDecorator base_operator;
        public geneticDecorator()
        {

        }

        public override void oper(Arbol parent1, Arbol parent2)
        {
            throw new NotImplementedException();
        }
    }
    public class protectedCrossover : geneticDecorator
    {
        public protectedCrossover(GeneticOp b_op)
        {

        }
        public override void oper(Arbol parent1, Arbol parent2)
        {
            base.oper(parent1, parent2);
        }
    }
}
