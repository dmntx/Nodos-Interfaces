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
    class NodoCst : Nodo
    {
        int func;

        public NodoCst(int f)
        {
            func = f;
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
    class NodoVar : Nodo
    {
        float func;

        public NodoVar(float f)
        {
            func = f;
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
    class NodoInterno : Nodo
    {
        string func;
        int no_hijos;
        Nodo der, izq;

        public NodoInterno(string f)
        {
            func = f;
            switch (func){
                case "+":
                    no_hijos = 2;
                    break;
                case "*":
                    no_hijos = 2;
                    break;
                case "/":
                    no_hijos = 2;
                    break;
                case "-":
                    no_hijos = 2;
                    break;
                case "sqrt":
                    no_hijos = 1;
                    break;
            }
            
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
