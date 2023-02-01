using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodos_Interfaces
{
    public interface Nodo
    {
        string getFuc();
        float eval(float x);
    }
    class NodoHoja : Nodo
    {
        public float eval(float x)
        {
            throw new NotImplementedException();
        }

        public string getFuc()
        {
            throw new NotImplementedException();
        }
    }
    class NodoVar : Nodo
    {
        public float eval(float x)
        {
            throw new NotImplementedException();
        }

        public string getFuc()
        {
            throw new NotImplementedException();
        }
    }
    class NodoInterno : Nodo
    {
        string func;
        int no_hijos;
        Nodo der, izq;

        public NodoInterno()
        {

        }
        public float eval(float x)
        {
            throw new NotImplementedException();
        }

        public string getFuc()
        {
            throw new NotImplementedException();
        }
    }
}
