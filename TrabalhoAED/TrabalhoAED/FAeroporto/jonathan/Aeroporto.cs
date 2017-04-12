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
        public void cadastraAeroporto(string cidade, int codigo)
        {
            string sigla = buscaSigla(cidade.ToLower());
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

        public string buscaSigla(string cidade)
        {
            
            switch (cidade)
            {
                case "brasilia":
                    return "BSB";
                case "belo horizinte":
                    return "CNF";
                case "rio de janeiro":
                    return "GIG";
                case "São Paulo":
                    return "GRU";
                case "Salvador":
                    return "SSA";

            }
            return "sigla não encontrda";
        }
    }
}
