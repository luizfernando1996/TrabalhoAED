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

        public string buscaSigla(string cidade)
        {

            switch (cidade)
            {
                case "brasilia":
                    return "BSB";
                case "brasília":
                    return "BSB";
                case "belo horizonte":
                    return "CNF";                
                case "rio de janeiro":
                    return "GIG";
                case "são paulo":
                    return "GRU";
                case "sao paulo":
                    return "GRU";
                case "salvador":
                    return "SSA";

            }
            return "sigla não encontrada";
        }

        public void vincularVooAeroporto(NodeVoo voo, int indice)
        {
            //ja se passa a lacuna do vetor onde deve se inserir o Voo
            try
            {
                insereVoo(vetor[indice], voo);

            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Impossivel cadastrar este Voo, sendo que os aeroportos");
            }
        }

        //verifica se o aeroporto existe e se sim retorna o indice do aerporto
        public int verificarAeroportoExiste(string cidade,ref string message)
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
                //vetor ja tem 10 posições e não se encontrou a cidade
                catch (IndexOutOfRangeException)
                {
                    indice = 15;
                    sairWhile = false;
                }
                //vetor não tem as 10 posições e não se encontrou a cidade
                catch(NullReferenceException)
                {
                    indice = 15;
                    sairWhile = false;
                }
            }
            if (indice == 15)
                message = "Aeroporto não cadastrado";
            else
                message = "Aeroporto cadastrado";
            return indice;
        }

        public void insereVoo(NodeAeroporto aeroporto, NodeVoo voo)//insere o voo no fim da lista de aeroporto
        {
            //o next é um campo de NodeVoo
            NodeVoo p = aeroporto.next;
            if (p == null)
                aeroporto.next = voo;
            else
            {
                while (p.next != null)
                {
                    p = p.next;
                }

                p.next = voo;
            }
        }

        //imprime os voos de todos os aerportos
        public void imprimeVoo(string sigla)
        {
            int i = 0;
            NodeVoo p;
            while (vetor[i] != null)
            {
                //percorre o vetor até encontrar a sigla correspondete
                if(vetor[i].sigla == sigla)
                {
                    //ponteiro inicial que aponta para a origem...para o vertice
                    p = vetor[i].next;
                    if (p != null)
                        Console.WriteLine("\nAeroporto de " + vetor[i].cidade + " Código: " + vetor[i].codigo + " Sigla: " + vetor[i].sigla);

                    while (p != null)
                    {
                        Console.WriteLine("Voo: " + p.numeroVoo + " " + "Destino: " + p.indiceCidadeDestino);
                        p = p.next;
                    }
                    i++;
                }
                else
                {
                    i++;
                }                
            }
        }

        public void imprimeTudo()
        {
            int i = 0;
            NodeVoo p;
            while (vetor[i] != null)
            {                
                 p = vetor[i].next;
                 if (p != null)
                        Console.WriteLine("\nAeroporto de " + vetor[i].cidade + " Código: " + vetor[i].codigo + " Sigla: " + vetor[i].sigla);

                while (p != null)
                 {
                        Console.WriteLine("Voo: " + p.numeroVoo + " " + "Destino: " + p.indiceCidadeDestino);
                        p = p.next;
                 }
                 i++;              
               
            }
        }
    }
}
