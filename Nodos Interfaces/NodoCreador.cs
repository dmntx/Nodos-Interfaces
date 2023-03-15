using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodos_Interfaces
{
    public abstract class NodoCreador
    {
        protected int max_depth;
        protected int input_vector_size;
        protected Nodo Aux = null;
        public abstract Nodo NodeFactory(int current_depth);
        
    }

    public class FullDepthNodoCreator : NodoCreador
    {
        public FullDepthNodoCreator(int md, int ivs)
        {
            max_depth = md;
            input_vector_size = ivs;
        }
        public override Nodo NodeFactory(int current_depth)
        {
            int coin;
            //NodoInterno Aux;
            //Nodo Aux = new NodoInterno();
            var Rand = new Random();
            //Aux = null;
            //Nodo Aux = new NodoInterno("*");
            if (current_depth == max_depth){
                
                if(Rand.Next(-10,10) > 0.5)
                {
                    Aux = new NodoCst(Rand.Next(0,10));
                }
                else
                {
                    Aux = new NodoVar(Rand.Next(input_vector_size));
                }
            }
            else
            {
                coin = Rand.Next(0,4);
                //Console.WriteLine(coin);
                switch (coin)
                {
                    case 0:
                        Aux = new NodoInterno("+");
                        break;
                    case 1:
                        Aux = new NodoInterno("*");
                        break;
                    case 2:
                        Aux = new NodoInterno("/");
                        break;
                    case 3:
                        Aux = new NodoInterno("-");
                        break;
                    case 4:
                        Aux = new NodoInterno("sqrt");
                        break;
                }
                //return Aux;
            }
            //Aux.getFunc();
            System.Threading.Thread.Sleep(10);
            return Aux;
        }
    }

    public class RandomDepthNodeCreator : NodoCreador
    {
        public RandomDepthNodeCreator(int md, int ivs)
        {
            max_depth = md;
            input_vector_size = ivs;
        }

        public override Nodo NodeFactory(int current_depth)
        {
            int coin;
            var Random = new Random();
            if((current_depth == max_depth || Random.Next(-2,2) > 0.5) && current_depth>0){
                if (Random.Next(-2, 2) > 0.5)
                {
                    Aux = new NodoCst(Random.Next(0, 10));
                }
                else
                {
                    Aux = new NodoVar(Random.Next(input_vector_size));
                }
            }
            else
            {
                coin = Random.Next(0, 4);
                //Console.WriteLine(coin);
                switch (coin)
                {
                    case 0:
                        Aux = new NodoInterno("+");
                        break;
                    case 1:
                        Aux = new NodoInterno("*");
                        break;
                    case 2:
                        Aux = new NodoInterno("/");
                        break;
                    case 3:
                        Aux = new NodoInterno("-");
                        break;
                    case 4:
                        Aux = new NodoInterno("sqrt");
                        break;
                }
            }
            System.Threading.Thread.Sleep(10);
            return Aux;
        }
    }
    public class FullNodeRandom : NodoCreador
    {
        public FullNodeRandom(int md, int ivs)
        {

        }
        public override Nodo NodeFactory(int current_depth)
        {
            throw new NotImplementedException();
        }
    }
}
