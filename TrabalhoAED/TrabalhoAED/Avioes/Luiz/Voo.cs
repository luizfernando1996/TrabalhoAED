using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoAED.FAeroporto.jonathan;

namespace TrabalhoAED.Avioes.Luiz
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

        public void cadastraVoo(int numVoo, int codigoOrigem, int codigoDestino)
        {
            NodeVoo objVoo = sentinela;
            Aeroporto objAero = new Aeroporto();
            objVoo = new NodeVoo(numVoo, codigoDestino, sentinela.next);
            objAero.vincularVooAeroporto(objVoo, codigoOrigem);
        }
        public string removeVoo(int numVoo)
        {
            string message;
            NodeVoo p = sentinela;
            while (p.next != null && p.next.numeroVoo != numVoo)
                p = p.next;

            if (p == null)
                message = "Nâo existe Voo com este número";
            else
            {
                p.next = p.next.next;
                message = "Voo removido com sucesso";
            }
            return message;
        }
        public void imprimeTudo()
        {
            NodeVoo p = sentinela;
            while (p != null)
            {
                Console.WriteLine("Cidade de destino: " + p.indiceCidadeDestino + " Número do Voo: " + p.numeroVoo);
                p = p.next;
            }
        }
        public void procuraVoo(string codigoOrigem, string codigoDestino, int maxConexoes) { }

    }
}
