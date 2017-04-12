using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoAED.Avioes.Luiz;

namespace TrabalhoAED.FAeroporto.jonathan
{
    public class NodeAeroporto
    {
        public string cidade;
        public string sigla;
        public NodeVoo next;

        public NodeAeroporto()
        {
            cidade = null;
            sigla = null;
            next = null;
        }

        public  NodeAeroporto(string cidade, string sigla, NodeVoo next )
        {
            this.cidade = cidade;
            this.sigla = sigla;
            this.next = next;
        }
    }
}
