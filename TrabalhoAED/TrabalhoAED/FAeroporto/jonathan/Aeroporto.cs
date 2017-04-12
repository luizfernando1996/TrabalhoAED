using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TrabalhoAED.FAeroporto.jonathan
{
    class Aeroporto
    {
        
        NodeAeroporto[] vetor = new NodeAeroporto[10];
        static int indice = 0;

        public Aeroporto()
        {
           
        }
        public void cadastraAeroporto(string cidade, string sigla)
        {
            NodeAeroporto novo = new NodeAeroporto(cidade, sigla, null);
            vetor[indice] = novo;
            indice++;
        } 

        public void imprimeTudo()
        {           
           
        }
    }
}
