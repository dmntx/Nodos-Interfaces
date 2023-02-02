using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodos_Interfaces
{
    public interface Nodo
    {
        string getFunc();
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

        public string getFunc()
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

        public string getFunc()
        {
            return Convert.ToString(func);
        }
    }
    class NodoInterno : Nodo
    {
        string func;
        string funcion;
        int no_hijos;
        NodoInterno der, izq;

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

        public string getFunc()
        {
            switch (no_hijos)
            {
                case 1:
                    funcion += funcion + '(' + izq.getFunc() + ')';
                    break;
                case 2:
                    funcion += '(' + izq.getFunc() + func + der.getFunc() + ')';
                    break;
            }
        return funcion;
        }
    }
}
