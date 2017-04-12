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

        //o objeto Voo ja ta criado..Você só deve pegar este objeto Voo e jogar no aeroporto de origem através do método vincularVooAerporto
        //Acredito que vc terá que acrescentar métodos na classe aeroporto pq la deve haver algum método que recebe um voo e um codigo de origem 
        //e faz este vinculo.
        //Algumas notas...Voo só tem 2 campos...numero do voo e codigo de destino<---Restrição do exercicio
        //o outro campo abaixo codigo de origem ele só serve para você vincular o voo a um aeroporto

        public void cadastraVoo(int numVoo, int codigoOrigem, int codigoDestino)
        {
            NodeVoo objVoo=sentinela;
                Aeroporto objAero = new Aeroporto();

            if (listaVazia())
            {
                objVoo = new NodeVoo(numVoo, codigoDestino, sentinela.next);
            }
            else
            {
                NodeVoo p = sentinela;
                while (p.next != null)
                    p = p.next;
                objVoo = new NodeVoo(numVoo, codigoDestino, p.next);
            }
           objAero.vincularVooAeroporto(objVoo,codigoOrigem);
        }
        public string removeVoo(int numVoo)
        {
            string message;
            NodeVoo p = sentinela;
            while (p.next != null && p.next.numeroVoo != numVoo)
                p = p.next;

            if (p == null)
                message="Nâo existe Voo com este número";
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
