using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodos_Interfaces
{
    /*public interface Nodo
    {
        
        string getFunc();
        float eval(float[] vec);
    }*/
    public abstract class Nodo
    {
        public Nodo izq;
        public Nodo der;
        public int no_hijos;

        public abstract string getFunc();
        public abstract float eval(float[] x);
        public abstract Nodo clonar();
    }
    class NodoCst : Nodo
    {
        float func;

        public NodoCst(float f)
        {
            func = f;
        }
        public override float eval(float[] vec)
        {
            return func;
        }

        public override string getFunc()
        {
            //Console.Write(func);
            return Convert.ToString(func);
        }
        public override Nodo clonar()
        {
            return new NodoCst(this.func);
        }
    }
    class NodoVar : Nodo
    {
        int func;

        public NodoVar(int f)
        {
            func = f;
            no_hijos = 0;
        }
        public override float eval(float[] vec)
        {
            return vec[func];
        }

        public override string getFunc()
        {
            //Console.Write("x" + func);
            return "x" + Convert.ToString(func);
        }
        public override Nodo clonar()
        {
            return new NodoVar(this.func);
        }
    }
    class NodoInterno : Nodo
    {
        public string func;
        public string funcion;
        //int no_hijos;
        float res;
        //public Nodo izq, der;

        public NodoInterno(string f)
        {
            func = f;
            switch (func) {
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
        public override float eval(float[] x)
        {
            switch (func)
            {
                case "+":
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

        public override string getFunc()
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
        public override Nodo clonar()
        {
            NodoInterno newNodo = new NodoInterno(this.func);
            //return new NodoInterno(this.func);
            no_hijos = newNodo.no_hijos;
            if (no_hijos == 1)
            {
                //clonar().izq = this.izq;
                izq = izq.clonar();
            }
            if(no_hijos == 2)
            {
                /*izq = this.izq.clonar();
                der = this.der.clonar();*/
                izq = this.izq.clonar();
                der = this.der.clonar();
                //return this.izq;
            }
            //newNodo.getFunc();
            return newNodo;
        }
    }
}
