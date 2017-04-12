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
            vetor[indice] = new NodeAeroporto(cidade, sigla, null);
            indice++;
        } 

        public void imprimeTudo()
        {           
           for(int i = 0; i < indice; i++)
            {
                Console.WriteLine("cidade: " + vetor[i].cidade + " sigla:" + vetor[i].sigla);                
            }
        }
    }
}
