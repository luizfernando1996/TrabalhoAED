using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoAED.Avioes;


namespace TrabalhoAED.PastaAeroporto
{
    class Aeroporto
    {

        public static NodeAeroporto[] vetor = new NodeAeroporto[10];
        static int indice = 0;

        //construtor
        public Aeroporto() { }


        //verifica se o aeroporto existe e se sim retorna o indice do aerporto
        public int encontraIndiceAeroportoPelaCidade(string cidade)
        {
            bool sairWhile = true;

            while (sairWhile)
            {
                try
                {
                    if (vetor[indice].cidade == cidade)
                    {
                        sairWhile = false;
                    }
                    else
                        indice++;
                }
                //vetor ja tem 10 posições e não se encontrou a cidade
                catch (IndexOutOfRangeException)
                {
                    indice = 10;
                    sairWhile = false;
                }
                //vetor não tem as 10 posições e não se encontrou a cidade
                catch (NullReferenceException)
                {
                    indice = 10;
                    sairWhile = false;
                }
            }
            return indice;
        }
        public int encontraIndiceAeroportoPelaSigla(string sigla)
        {
            bool sairWhile = true;

            while (sairWhile)
            {
                try
                {
                    if (vetor[indice].sigla == sigla)
                    {
                        sairWhile = false;
                    }
                    else
                        indice++;
                }
                //vetor ja tem 10 posições e não se encontrou a cidade
                catch (IndexOutOfRangeException)
                {
                    indice = 10;
                    sairWhile = false;
                }
                //vetor não tem as 10 posições e não se encontrou a cidade
                catch (NullReferenceException)
                {
                    indice = 10;
                    sairWhile = false;
                }
            }
            return indice;
        }
        public string encontraSiglaAeroportoPeloIndice(int indice)
        {
            return vetor[indice].sigla;
        }

        //*****menu*****

        //Opção 1 do menu-->cadastra aeroporto
        public string cadastraAeroporto(string cidade)
        {
            string sigla = buscaSigla(cidade);
            string message;
            //o indice é statico

            if (aeroportoExistente(cidade))
            {
                if (indice != 10)
                {
                    vetor[indice] = new NodeAeroporto(cidade, indice, sigla, null);
                    indice++;
                    message = "Aeroporto Cadastrado com sucesso!!";
                }
                else
                    message = "O Vetor está com todas suas posições ocupadas";
                
            }
            else
            {
                message = "Impossível cadastrar! Aeroporto já cadastrado!";
            }
            return message;
        }
        //Checa se o aeroporto já está inserido no vetor
        public bool aeroportoExistente(string cidade)
        {
            bool result = true;
            int i = 0;
            while(vetor[i] != null && result != false)
            {
                if(vetor[i].cidade == cidade)
                {
                    result = false;
                }
                i++;
            }
            return result;
        }
        //Busca a sigla do aeroporto correspondete a cidade inserida
        public string buscaSigla(string cidade)
        {
            cidade = cidade.ToLower();
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

        //Opção 2 do menu-->Cadastra voo no aeroporto de origem
        public void vincularVooAeroporto(NodeVoo voo, int indice)
        {
            //insere o objeto voo na ultima posição do aeroporto de origem
            insereVoo(vetor[indice], voo);

        }
        //insere o voo no fim da lista de aeroporto
        public void insereVoo(NodeAeroporto aeroporto, NodeVoo voo)
        {
            //percorre os voos de uma origem até o ultimo
            NodeVoo p = aeroporto.next;
            if (p == null)
                aeroporto.next = voo;
            else
            {
                while (p.next != null)
                    p = p.next;

                p.next = voo;
            }
        }

        //Opção 3 do menu-->Remove voo com um determinado numero
        public void removeVoo(int numeroVoo)
        {
            int indice = 0;
            bool sairWhile = true;
            //ponteiro para percorrer todos os voos de cada origem
            NodeVoo p;
            while (vetor[indice] != null)
            {
                //primeiro voo
                p = vetor[indice].next;

                //remove o primeiro voo
                if (vetor[indice] != null && vetor[indice].next != null)
                    if (vetor[indice].next.numeroVoo == numeroVoo)
                        vetor[indice].next = vetor[indice].next.next;

                sairWhile = true;
                while (sairWhile)
                {
                    if (p != null && p.next != null)
                        if (p.next.numeroVoo == numeroVoo)
                        {
                            p.next = p.next.next;
                            sairWhile = false;
                        }
                    if (p == null)
                        sairWhile = false;
                    else
                        p = p.next;
                }

                indice++;

            }
        }

        //Opção 4 do menu-->Imprime os voos de um aeroporto
        public void imprimeVoo(string sigla)
        {
            int i = 0;
            NodeVoo p;
            while (vetor[i] != null)
            {
                //percorre o vetor até encontrar a sigla correspondete
                if (vetor[i].sigla == sigla)
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
        //Opção 5 do menu-->Imprime os voos de todos os aerportos
        public void imprimeTudo()
        {
            int i = 0;
            NodeVoo p;
            try
            {
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

            catch (IndexOutOfRangeException)
            {


            }
        }
        //Opção 6 do menu-->procura caminhos de uma origem ate um destino
        public void procuraVoo(string siglaOrigem, string siglaDestino, int maxConexoes)
        {
            bool sairWhile1 = true;
            int indiceOrigem = encontraIndiceAeroportoPelaSigla(siglaOrigem);
            NodeVoo ponteiroVoo;

            int indiceDestino = encontraIndiceAeroportoPelaSigla(siglaDestino);

        }
        public void procuraRecursivamente(NodeVoo ponteiroVoo, int indiceDestino,int maxConexoes)
        {
            //Finaliza a repetição se encontrar o voo com o destino ou se o limite de conexões for ultrapassado
            if ((ponteiroVoo.indiceCidadeDestino == indiceDestino) || (maxConexoes == 0))
                return;
            else
            {
                ponteiroVoo = vetor[indiceDestino].next;
                procuraRecursivamente(ponteiroVoo, indiceDestino, --maxConexoes);
            }
        }

        //*****fim do menu*****
    }
}
