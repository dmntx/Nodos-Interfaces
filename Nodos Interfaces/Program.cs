using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodos_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleCrossover SubtreeCrossover;
            Arbol arbol1, arbol2, arbol3, arbol4;
            SubtreeCrossover = new SimpleCrossover();

            arbol1 = new Arbol(2, 2);
            arbol1.init_random_tree();
            //Console.WriteLine(arbol1.getFunc());

            arbol2 = new Arbol(2, 2);
            arbol2.init_random_tree();

            //arbol3 = arbol2.clonar();
            //Console.WriteLine(arbol3.getFunc());


            SubtreeCrossover.oper(arbol1, arbol2);

            System.Threading.Thread.Sleep(100);

            arbol3 = SubtreeCrossover.offspring1;
            arbol4 = SubtreeCrossover.offspring2;

            Console.WriteLine(arbol3.getFunc());
            Console.WriteLine(arbol4.getFunc());

            Console.WriteLine("\n\n");

            Console.WriteLine(arbol1.getFunc());
            Console.WriteLine(arbol2.getFunc());

            Console.ReadLine();
            Console.ReadLine();

        }
    }
}
