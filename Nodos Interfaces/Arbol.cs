using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodos_Interfaces
{
    class Arbol
    {
        private int profundidad;
        private int conteoNodos;
        private NodoCreador nodeCreator;
        private int input_vector_size;

        public Nodo[] nodos;
        public Arbol(int depth)
        {
            profundidad = depth;
            nodos = new Nodo[depth];
        }
        public string getFunc()
        {
            return nodos[0].getFunc();
        }
        public float eval(float[] x)
        {
            return nodos[0].eval(x);
        }
        public Arbol clonar()
        {
            Nodo newRaiz;
            //new Arbol(this.profundidad);
            newRaiz = this.nodos[0].clonar();
            //newRaiz.getFunc();
            //Console.WriteLine(newRaiz.getFunc());
            //insertarNodo(newRaiz, 0);
            Arbol arboln = new Arbol(this.profundidad);
            arboln.nodos[0] = newRaiz;
            return arboln;
            //return new Arbol(this.profundidad);
        }
        public void insertarNodo(Nodo n, int pos)
        {
            this.nodos[pos] = n;
            this.conteoNodos = this.conteoNodos + 1;
            
            if (n.no_hijos == 1)
            {
                insertarNodo(n.izq, this.conteoNodos);
            }
            if(n.no_hijos == 2)
            {
                insertarNodo(n.izq, this.conteoNodos);
                insertarNodo(n.der, this.conteoNodos);
            }
            //Console.Write(n.getFunc());
        }
        public void init_random_tree()
        {

        }

        public void create_child_nodes(Nodo n, int curr_depth)
        {

        }
    }
}
