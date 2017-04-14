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
            indice = 0;
            int indiceOrigem = encontraIndiceAeroportoPelaSigla(siglaOrigem);
            int indiceDestino = encontraIndiceAeroportoPelaSigla(siglaDestino);

            bool sairWhile1 = true;
            //primeiro voo do vetor do aeroporto que parte da origem informada
            NodeVoo ponteiroVoo = vetor[indiceOrigem].next;
            NodeVoo pontVoo;
            while (sairWhile1)
            {
                int p = indiceOrigem;
                procuraRecursivamente(p, indiceDestino, maxConexoes, 0, ponteiroVoo, 0);
                pontVoo = ponteiroVoo.next;
                if (pontVoo == null)
                    sairWhile1 = false;
            }
        }
        //j captura o indice de origem do voo, isto é, captura o aeroporto
        //ponteiro para o aeroporto com o indice j (indice de origem)
        //int k é para mostrar quantos deram certo.
        public void procuraRecursivamente(int p, int indiceDestino, int maxConexoes, int j, NodeVoo ponteiroMaxConexoes0, int k)
        {

            if ((vetor[p].next == null) || (vetor[p].next.indiceCidadeDestino == indiceDestino))
            {

            }
            else
            {
                //procura o 1°voo do numero MaxConexoes e compara se = indiceDestino
                if ((vetor[p].next.indiceCidadeDestino != indiceDestino) && (maxConexoes > 0))
                {
                    //APAGAR DEPOIS
                    int a, b;
                    a = vetor[p].next.indiceCidadeDestino;
                    b = indiceDestino;
                    //APAGAR DEPOIS

                    //pega o indice de origem do 1°voo
                    j = p;
                    ponteiroMaxConexoes0 = vetor[j].next;
                    //o ponteiro vai progressivamente pegando o 1°voo até o maximo de conexoes, isto é,
                    //ele vai pegando o 1°voo de cada origem
                    p = vetor[p].next.indiceCidadeDestino;

                    //p não pode sair com o indice do voo desta estrutura.Ele deve sair com o indice do vetor
                    //para que assim quando maxConexoes seja =0 ele sai daqui e percorra todo o vetor
                    //o max de conexoes ele é decrementado no final deste algoritmo, logo devo pegar MaxConexoes==2
                    //porque neste momento maxConexoes será==1
                    if (maxConexoes == 2)
                    {
                        procuraRecursivamente(p, indiceDestino, --maxConexoes, j, ponteiroMaxConexoes0, 0);
                    }
                    //decrementa o numero de conexoes porque o ponteiro está indo para as conexoes
                    else
                        procuraRecursivamente(p, indiceDestino, --maxConexoes, j, ponteiroMaxConexoes0, 0);
                    bool chave = true;
                    while (chave)
                    {
                        if (ponteiroMaxConexoes0.indiceCidadeDestino != indiceDestino)
                            ponteiroMaxConexoes0 = ponteiroMaxConexoes0.next;
                        if (ponteiroMaxConexoes0 == null || ponteiroMaxConexoes0.indiceCidadeDestino == indiceDestino)
                        {
                            chave = false;
                            if (ponteiroMaxConexoes0 != null)
                                if (ponteiroMaxConexoes0.indiceCidadeDestino == indiceDestino)
                                    k++;
                        }
                    }
                }
            }


        }

    }

    //*****fim do menu*****
}

