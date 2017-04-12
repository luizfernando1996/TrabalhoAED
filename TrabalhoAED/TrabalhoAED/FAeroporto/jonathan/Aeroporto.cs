using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoAED.Avioes.Luiz;


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
            vetor[indice] = new NodeAeroporto(cidade, codigo, sigla, null);
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

        public void vincularVooAeroporto(NodeVoo voo)
        {
            int i = 0;
            while(i != indice)
            {
                if (voo.origem == vetor[i].cidade)// encontra no vetor de aeroportos, o aeroporto de origem correspondente ao voo.
                {
                    insereVoo(vetor[i], voo);
                }
                i++;
            }
        }

        public void insereVoo(NodeAeroporto aeroporto, NodeVoo voo)//insere o voo no fim da lista de aeroporto
        {
            NodeVoo p = aeroporto.next;
            while(p != null)
            {
                p = p.next;                
            }

            p = voo;
        }
    }
}
