using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodos_Interfaces
{
    public abstract class NodoCreador
    {
        private int max_depth;
        private int input_vector_size;
        public abstract Nodo NodeFactory(int current_depth);
    }

    public class FullDepthNodoCreator : NodoCreador
    {
        public FullDepthNodoCreator()
        {

        }
        public override Nodo NodeFactory(int current_depth)
        {
            throw new NotImplementedException();
        }
    }
}
