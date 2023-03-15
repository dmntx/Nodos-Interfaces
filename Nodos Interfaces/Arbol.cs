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
        public int conteoNodos;
        protected NodoCreador nodeCreator;
        protected int input_vector_size;
        protected int branch;

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
            insertarNodo(newRaiz, 0);
           //*Arbol arboln = new Arbol(this.profundidad);
            //arboln.nodos[0] = newRaiz;
            //return null;
            return new Arbol(this.profundidad, this.input_vector_size);
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
            this.insert_node_array(raiz, 0);
            this.update_node_depth(raiz, 0);
            this.update_subtree_depth(raiz);

        }

        public void create_child_nodes(Nodo n, int curr_depth)
        {
            
            if(n.no_hijos == 1)
            {
                n.izq = nodeCreator.NodeFactory(curr_depth);
                n.izq.parent = n;
                create_child_nodes(n.izq, curr_depth + 1);
            }
            if(n.no_hijos == 2)
            {
                n.izq = nodeCreator.NodeFactory(curr_depth);
                n.izq.parent = n; //se asigna el padre del nodo recien creado
                create_child_nodes(n.izq, curr_depth + 1);
                n.der = nodeCreator.NodeFactory(curr_depth);
                n.der.parent = n; //asigna padre del nodo recien creado
                create_child_nodes(n.der, curr_depth + 1);
            }
            //return n;
        }
        public void update_node_depth(Nodo n, int depth)
        {
            n.depth = depth;
            if(n.no_hijos == 1)
            {
                update_node_depth(n.izq, depth + 1);
            }else if (n.no_hijos == 2)
            {
                update_node_depth(n.izq, depth + 1);
                update_node_depth(n.der, depth + 1);
            }
        }
        public int update_subtree_depth(Nodo n)
        {
            int l_branch, r_branch;
            if(n.no_hijos == 0)
            {
                n.sub_tree = 0;
                return 0;
            }
            else if(n.no_hijos == 1)
            {
                l_branch = update_subtree_depth(n.izq) + 1;
                r_branch = 0;
                branch = r_branch;
            }
            else
            {
                l_branch = update_subtree_depth(n.izq) + 1;
                r_branch = update_subtree_depth(n.der) + 1;
            }
            if(l_branch >= r_branch)
            {
                n.sub_tree = l_branch;
                branch = l_branch;
            }
            else
            {
                n.sub_tree = r_branch;
                branch = r_branch;
            }
            return branch;
        }
        public void insert_node_array(Nodo n, int pos)
        {
            this.nodos[pos] = n;
            this.conteoNodos = this.conteoNodos + 1;
            if(n.no_hijos == 1)
            {
                insert_node_array(n.izq, this.conteoNodos);
            }else if(n.no_hijos == 2)
            {
                insert_node_array(n.izq, this.conteoNodos);
                insert_node_array(n.der, this.conteoNodos);
            }
        }
    }
}
