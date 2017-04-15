using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoAED.FolderPilha
{
    public class NodePilha
    {
        //atributos
        public int indiceCidadeDestino;
        public int numeroVoo;
        public int aeroportoDoVoo;
        public int maxConexoes;
        public string mensagem;
        public NodePilha next;

        //construtor
        public NodePilha(int aeroportoDoVoo, int indiceCidadeDestino, int numeroVoo,int maxConexoes, string mensagem, NodePilha next)
        {
            this.indiceCidadeDestino = indiceCidadeDestino;
            this.numeroVoo = numeroVoo;
            this.aeroportoDoVoo = aeroportoDoVoo;
            this.maxConexoes = maxConexoes;
            this.mensagem = mensagem;
            this.next = next;
        }
    }
}
