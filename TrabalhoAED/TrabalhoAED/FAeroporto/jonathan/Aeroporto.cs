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

        public static NodeAeroporto[] vetor = new NodeAeroporto[10];
        static int indice = 0;

        public Aeroporto()
        {

        }
        public void cadastraAeroporto(string cidade)
        {
            string sigla = buscaSigla(cidade.ToLower());
            if (indice != 10)
                vetor[indice] = new NodeAeroporto(cidade, indice, sigla, null);
            indice++;
        }

        public void imprimeTudo()
        {
            for (int i = 0; i < indice; i++)
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

        public void vincularVooAeroporto(NodeVoo voo, int indice)
        {
            //int i = 0;
            //while(i != indice)
            //{
            //    if ( cidadeOrigem== vetor[i].cidade)// encontra no vetor de aeroportos, o aeroporto de origem correspondente ao voo.
            //    {
            insereVoo(vetor[indice], voo);
            //    }
            //    i++;
            //}
        }

        //verifica se o aeroporto existe e se sim retorna o indice do aerporto
        public int verificarAeroportoExiste(string cidade)
        {
            bool sairWhile = true;
            indice = 0;
            while (sairWhile)
            {
                try
                {
                    if (vetor[indice].cidade == cidade)
                        sairWhile = false;
                    else
                        indice++;
                }
                catch (IndexOutOfRangeException)
                {
                    indice = 15;
                    sairWhile = false;
                }
            }
            return indice;
        }

        public void insereVoo(NodeAeroporto aeroporto, NodeVoo voo)//insere o voo no fim da lista de aeroporto
        {
            //o next é um campo de NodeVoo
            NodeVoo p = aeroporto.next;
            while (p != null)
            {
                p = p.next;
            }

            p = voo;
        }
    }
}
