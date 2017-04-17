using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoAED.Avioes
{
    public class NodeVoo
    {
        //a segurar que será null
        public NodeVoo next;
        public int indiceCidadeDestino;
        public int numeroVoo;

        public NodeVoo() { }

        public NodeVoo(int numeroVoo, int indiceCidadeDestino,NodeVoo next)
        {
            this.next = next;
            this.indiceCidadeDestino = indiceCidadeDestino;
            this.numeroVoo = numeroVoo;
        } 
    }
}
