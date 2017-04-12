using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoAED.Aeroporto.jonathan
{
    class NodeAeroporto
    {
        public string cidade;
        public string sigla;
        public NodeAeroporto next;

        public NodeAeroporto()
        {
            cidade = null;
            sigla = null;
            next = null;
        }

        public  NodeAeroporto(string cidade, string sigla, NodeAeroporto next )
        {
            this.cidade = cidade;
            this.sigla = sigla;
        }
    }
}
