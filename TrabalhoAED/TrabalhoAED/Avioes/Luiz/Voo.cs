using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoAED.Avioes.Luiz
{
    class Voo
    {
        public NodeVoo sentinela;

        public Voo()
        {
            sentinela = new NodeVoo();
        }
        public void cadastraVoo(int numVoo, string codigoOrigem, string codigoDestino)
        {

        }
        public void removeVoo(int numVoo)
        {
            //numVoo é indentificador unico

            NodeVoo p = inicio;
            while (p.next != null && p.next.numeroVoo != numVoo)
                p = p.next;

            if (p == null)
                Console.WriteLine("Nâo existe Voo com este número");
            else
            {
                p.next = p.next.next;
            }
        }
        public void imprimeVoos(int numero, string nomeCidade)
        {

        }
        public void procuraVoo(string codigoOrigem, string codigoDestino, int maxConexoes) { }

    }
}
