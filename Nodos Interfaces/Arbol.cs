using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodos_Interfaces
{
    public class Arbol
    {
        private int profundidad;
        private int conteoNodos;
        protected NodoCreador nodeCreator;
        protected int input_vector_size;

        public Nodo[] nodos;
        public Arbol(int depth, int vect_size)
        {
            profundidad = depth;
            int profu = Convert.ToInt32(Math.Pow(2,(profundidad+1)));
            nodos = new Nodo[profu];
            input_vector_size = vect_size;
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
           //*Arbol arboln = new Arbol(this.profundidad);
            //arboln.nodos[0] = newRaiz;
            return null;
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
            Nodo raiz;
            nodeCreator = new FullDepthNodoCreator(profundidad, input_vector_size);
            raiz = nodeCreator.NodeFactory(0);
            create_child_nodes(raiz, 1);
            this.insertarNodo(raiz, 0);
        }

        public void create_child_nodes(Nodo n, int curr_depth)
        {
            
            if(n.no_hijos == 1)
            {
                n.izq = nodeCreator.NodeFactory(curr_depth);
                create_child_nodes(n.izq, curr_depth + 1);
            }
            if(n.no_hijos == 2)
            {
                n.izq = nodeCreator.NodeFactory(curr_depth);
                create_child_nodes(n.izq, curr_depth + 1);
                n.der = nodeCreator.NodeFactory(curr_depth);
                create_child_nodes(n.der, curr_depth + 1);
            }
            //return n;
        }
        public void update_node_depth(Nodo n, int depth)
        {

        }
        public int update_subtree_depth(Nodo n)
        {

        }
    }
}
