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
            Arbol arbol1, arbol2, arbol3;
            float[] vector = new float[10];
            NodoInterno n0, n1, n2, n, n4;
            NodoCst n3, n6;
            NodoVar n5, n7;
            /*n0 = new NodoInterno("+");
            n1 = new NodoInterno("*");
            n2 = new NodoInterno("sqrt");
            n3 = new NodoCst(3);
            n4 = new NodoInterno("-");
            n5 = new NodoVar(0);
            n6 = new NodoCst(1);
            n7 = new NodoVar(0);*/
            arbol1 = new Arbol(10);
            arbol1.nodos[0] = new NodoInterno("+");
            arbol1.nodos[1] = new NodoInterno("*");
            arbol1.nodos[2] = new NodoInterno("sqrt");
            arbol1.nodos[3] = new NodoCst(3);
            arbol1.nodos[4] = new NodoInterno("-");
            arbol1.nodos[5] = new NodoVar(0);
            arbol1.nodos[6] = new NodoCst(1);
            arbol1.nodos[7] = new NodoVar(0);

            arbol1.nodos[0].izq = arbol1.nodos[1];
            arbol1.nodos[0].der = arbol1.nodos[2];
            arbol1.nodos[1].izq = arbol1.nodos[3];
            arbol1.nodos[1].der = arbol1.nodos[4];
            arbol1.nodos[4].izq = arbol1.nodos[5];
            arbol1.nodos[4].der = arbol1.nodos[6];
            arbol1.nodos[2].izq = arbol1.nodos[7];

            Console.WriteLine(arbol1.getFunc());

            /*tree0.nodes[0].l_child := tree0.nodes[1];
            tree0.nodes[0].r_child := tree0.nodes[2];
            tree0.nodes[1].l_child := tree0.nodes[3];
            tree0.nodes[1].r_child := tree0.nodes[4];
            tree0.nodes[4].l_child := tree0.nodes[5];
            tree0.nodes[4].r_child := tree0.nodes[6];
            tree0.nodes[2].l_child := tree0.nodes[7];*/

            /*n0.izq = n1;
            n0.der = n2;
            n1.izq = n3;*/
            /*n1.der = n4;
            n4.izq = n5;
            n4.der = n6;
            n2.izq = n7;*/
            /*vector[0] = 25;
            Console.WriteLine(n0.getFunc());
            Console.WriteLine("Resultado: " + n0.eval(vector));*/
       
            /*Console.Write(n1.getFunc());
            Console.Write(n2.getFunc());
            Console.Write(n3.getFunc());
            Console.Write(n4.getFunc());
            Console.Write(n5.getFunc());
            Console.Write(n6.getFunc());
            Console.Write(n7.getFunc());*/
            /*n1.getFunc();
            n2.getFunc();
            n3.getFunc();
            n4.getFunc();
            n5.getFunc();
            n6.getFunc();
            n7.getFunc();*/
            Console.ReadLine();
           
        }
    }
}
