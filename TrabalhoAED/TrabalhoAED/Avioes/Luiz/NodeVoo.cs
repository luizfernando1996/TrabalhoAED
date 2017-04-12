using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoAED.Avioes.Luiz
{
    public class NodeVoo
    {
        public NodeVoo next;
        public int indiceCidadeDestino;
        public int numeroVoo;
        
        public NodeVoo(NodeVoo next, int indiceCidadeDestino, int numeroVoo)
        {
            this.next = next;
            this.indiceCidadeDestino = indiceCidadeDestino;
            this.numeroVoo = numeroVoo;
        } 
    }
}
