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
        float eval(float[] vec);
    }
    class NodoCst : Nodo
    {
        float func;

        public NodoCst(float f)
        {
            func = f;
        }
        public float eval(float[] vec)
        {
            return func;
        }

        public string getFunc()
        {
            //Console.Write(func);
            return Convert.ToString(func);
        }
    }
    class NodoVar : Nodo
    {
        int func;

        public NodoVar(int f)
        {
            func = f;
        }
        public float eval(float[] vec)
        {
            return vec[func];
        }

        public string getFunc()
        {
            //Console.Write("x" + func);
            return "x" + Convert.ToString(func);
        }
    }
    class NodoInterno : Nodo
    {
        public string func;
        public string funcion;
        int no_hijos;
        float res;
        public Nodo izq, der;

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
        /*public float eval(float[] var)
        {
            return 0;
        }*/
        public float eval(float[] x)
        {
            switch (func)
            {
                case "+" : 
                    res += izq.eval(x) + der.eval(x);
                    break;
                case "*":
                    res += izq.eval(x) * der.eval(x);
                    break;
                case "/":
                    res += izq.eval(x) / der.eval(x);
                    break;
                case "-":
                    res += izq.eval(x) - der.eval(x);
                    break;
                case "sqrt":
                    res += Convert.ToSingle(Math.Sqrt(izq.eval(x)));
                    break;
            }
            return res;
            
        }

        public string getFunc()
        {
            switch (no_hijos)
            {
                case 1:
                    funcion += func + '(' + izq.getFunc() + ')';
                    break;
                case 2:
                    funcion += '(' + izq.getFunc() + func + der.getFunc() + ')';
                    break;
            }
            //Console.Write(func);
            return funcion;
        }
    }
}
