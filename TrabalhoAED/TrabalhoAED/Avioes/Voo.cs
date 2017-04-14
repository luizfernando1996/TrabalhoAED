using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoAED.PastaAeroporto;

namespace TrabalhoAED.Avioes
{
    class Voo
    {
        public NodeVoo sentinela;

        public Voo()
        {
            sentinela = new NodeVoo();
        }
        public bool listaVazia()
        {
            return sentinela.next == null;
        }

        public string cadastraVoo(int numVoo, int codigoOrigem, int codigoDestino)
        {
            NodeVoo objVoo = sentinela;
            Aeroporto objAero = new Aeroporto();
            objVoo = new NodeVoo(numVoo, codigoDestino, sentinela.next);
            string message=objAero.vincularVooAeroporto(objVoo, codigoOrigem);
            return message;
        }
    }
}
