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
        //todos os objetos devem ter o mesmos aeroportos
        static int indice = 0;

        public int k = 0;
        //construtor
        public Aeroporto() { }


        //verifica se o aeroporto existe e se sim retorna o indice do aerporto
        public int encontraIndiceAeroportoPelaCidade(string cidade)
        {
            bool sairWhile = true;
            //sempre se zera o indice que é static por via das duvidas
            indice = 0;
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
            //sempre se zera o indice que é static por via das duvidas
            indice = 0;
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
                //vetor não tem as 10 posições e não se encontrou a sigla da cidade
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

            if (aeroportoExistente(cidade))
            {
                message = "Impossível cadastrar! Aeroporto já cadastrado!";
            }
            else
            {
                //deve se ter um caso para testar o indice..assim ñ é necessario try-catch(indexOutOfException)
                while (indice < 10 && vetor[indice] != null)
                    indice++;
                if (indice < 10)
                {
                    vetor[indice] = new NodeAeroporto(cidade, indice, sigla, null);
                    message = "Aeroporto Cadastrado com sucesso!!";
                }
                else
                    message = "O Vetor está com todas suas posições ocupadas";
            }
            //retorna ele para 0 ja que é um atributo estatico
            indice = 0;
            return message;
        }
        //Checa se o aeroporto já está inserido no vetor
        public bool aeroportoExistente(string cidade)
        {
            bool aeroportoEncontrado = false;
            int i = 0;

            while (aeroportoEncontrado == false && i < 10 && vetor[i] != null)
            {
                if (vetor[i].cidade == cidade)
                {
                    aeroportoEncontrado = true;
                }
                i++;
                //O Vetor está com todas suas posições ocupadas
            }

            return aeroportoEncontrado;
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
        public string vincularVooAeroporto(NodeVoo voo, int indice)
        {
            string message;
            //insere o objeto voo na ultima posição do aeroporto de origem
            bool vooExistente = insereVoo(vetor[indice], voo);
            if (vooExistente)
                message = "Voo ja cadastrado anteriormente";
            else
                message = "Voo cadatrado com sucesso";
            return message;

        }
        //insere o voo no fim da lista de aeroporto
        public bool insereVoo(NodeAeroporto aeroporto, NodeVoo voo)
        {
            //retorna a informação se inseriu ou não o Voo
            bool vooExistente = false;
            //percorre os voos de uma origem até o ultimo
            NodeVoo p = aeroporto.next;
            //É o primeiro voo do aeroporto
            if (p == null)
                aeroporto.next = voo;
            else
            {
                vooExistente = false;
                bool sairWhile = false;
                while ((sairWhile == false) && (vooExistente == false))
                    if (p.numeroVoo == voo.numeroVoo)
                        vooExistente = true;
                    else
                    {
                        if (p.next == null)
                            sairWhile = true;
                        else
                            p = p.next;
                    }

                if (vooExistente == false)
                    p.next = voo;
            }
            return vooExistente;
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
            int indiceOrigem = encontraIndiceAeroportoPelaSigla(siglaOrigem);
            int indiceDestino = encontraIndiceAeroportoPelaSigla(siglaDestino);

            NodeVoo ponteiroVoo = null;

            int indiceAeroporto = indiceOrigem;
            //Se o numero de conexoes for 2 o programa terá que funcionar em 1 e 0
            maxConexoes = --maxConexoes;
            procuraRecursivamente(indiceOrigem, indiceDestino, maxConexoes, 0, ponteiroVoo);

        }
        //j captura o indice de origem do voo, isto é, captura o aeroporto
        //ponteiro para o aeroporto com o indice j (indice de origem)
        //int k é para mostrar quantos deram certo.
        public void procuraRecursivamente(int indiceAeroporto, int indiceDestinoVoo, int maxConexoes, int ultimoAeroporto, NodeVoo primeiroAviaoDoAeroporto)
        {

            if ((vetor[indiceAeroporto].next == null) || (vetor[indiceAeroporto].next.indiceCidadeDestino == indiceDestinoVoo))
            {

            }
            else if ((vetor[indiceAeroporto].next.indiceCidadeDestino != indiceDestinoVoo) && (maxConexoes >= 0))
            {
                //armazena o indice de origem do Aeroporto em um variavel segura
                ultimoAeroporto = indiceAeroporto;
                primeiroAviaoDoAeroporto = vetor[ultimoAeroporto].next;
                //atribui ao indice de origem o valor do indice de destino do Voo
                indiceAeroporto = vetor[indiceAeroporto].next.indiceCidadeDestino;

                //p não pode sair com o indice do voo desta estrutura.Ele deve sair com o indice do vetor
                //para que assim quando maxConexoes seja =0 ele sai daqui e percorra todo o vetor
                //o max de conexoes ele é decrementado no final deste algoritmo, logo devo pegar MaxConexoes==2
                //porque neste momento maxConexoes será==1
                if (maxConexoes == 1)
                {
                    procuraRecursivamente(indiceAeroporto, indiceDestinoVoo, --maxConexoes, ultimoAeroporto, primeiroAviaoDoAeroporto);
                    if (maxConexoes >= 0)
                    {
                        ultimoAeroporto = primeiroAviaoDoAeroporto.next.indiceCidadeDestino;
                        primeiroAviaoDoAeroporto = primeiroAviaoDoAeroporto.next;
                        procuraRecursivamente(ultimoAeroporto, indiceDestinoVoo, --maxConexoes, ultimoAeroporto, primeiroAviaoDoAeroporto);
                    }
                }
                //decrementa o numero de conexoes porque o ponteiro está indo para o maximo de conexoes
                else
                    procuraRecursivamente(indiceAeroporto, indiceDestinoVoo, --maxConexoes, ultimoAeroporto, primeiroAviaoDoAeroporto);

            }//fim if maxConexoes>0
            else //(maxConexoes < 0)
            {
                bool chave = true;
                if (maxConexoes == -1)
                {
                    while (chave)
                    {
                        if (primeiroAviaoDoAeroporto == null || primeiroAviaoDoAeroporto.indiceCidadeDestino == indiceDestinoVoo)
                        {
                            chave = false;
                            if (primeiroAviaoDoAeroporto != null)
                                if (primeiroAviaoDoAeroporto.indiceCidadeDestino == indiceDestinoVoo)
                                    k++;
                        }
                        if (primeiroAviaoDoAeroporto!=null && primeiroAviaoDoAeroporto.indiceCidadeDestino != indiceDestinoVoo)
                            primeiroAviaoDoAeroporto = primeiroAviaoDoAeroporto.next;
                    }
                }
                else
                {
                    if (maxConexoes >= 0)
                    {
                        ultimoAeroporto = primeiroAviaoDoAeroporto.next.indiceCidadeDestino;
                        primeiroAviaoDoAeroporto = primeiroAviaoDoAeroporto.next;
                        procuraRecursivamente(ultimoAeroporto, indiceDestinoVoo, maxConexoes, ultimoAeroporto, primeiroAviaoDoAeroporto);
                    }
                }
            }
        }//fim else

    }//fim procuraRecursivamente

}

    //*****fim do menu*****


