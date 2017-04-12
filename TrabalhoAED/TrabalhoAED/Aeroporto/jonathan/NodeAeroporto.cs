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

        public  NodeAeroporto(string cidade, string sigla )
        {
            this.cidade = cidade;
            this.sigla = sigla;
        }
    }
}
