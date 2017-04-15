using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoAED.Avioes;
using TrabalhoAED.FolderPilha;

namespace TrabalhoAED.FolderAeroporto
{
    class Aeroporto
    {
        /****************objetos****************************/

        //objeto aeroporto
        public static NodeAeroporto[] vetor = new NodeAeroporto[10];
        //todos os objetos devem ter o mesmos aeroportos
        static int indice = 0;

        //objeto pilha
        public Pilha objPilha = new Pilha();

        /****************fim dos objetos****************************/

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
                    {
                        indice++;
                    }
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

        /***menu******/

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


            bool empilharTudo = true;

            NodeAeroporto aeroportoPartida = vetor[indiceOrigem];
            NodeVoo primeiroAviaoDoAeroporto = aeroportoPartida.next;

            int indiceDestinoDoVoo, aeroportoDoVoo = indiceOrigem;
            indiceDestinoDoVoo = aeroportoDoVoo;

            string mensagem = null;
            bool mudarPonteiro = false;
            bool finalizarProcuraVoo = false;
            int k = 0;
            int[] vet = new int[5];

            while (finalizarProcuraVoo == false)
            {
                //chama a função empilha
                vet = empilhar(aeroportoDoVoo, indiceDestinoDoVoo, k, maxConexoes, ref mudarPonteiro, ref empilharTudo, indiceDestino, ref primeiroAviaoDoAeroporto);

                //coloca o retorno da função empilha nas variaveis corretas
                aeroportoDoVoo = vet[0];
                indiceDestinoDoVoo = vet[1];
                k = vet[2];
                maxConexoes = vet[3];
                indiceDestino = vet[4];

                vet = mudarPonteiroAndPercorrer(aeroportoDoVoo, indiceDestinoDoVoo, k, maxConexoes, ref mudarPonteiro, ref empilharTudo, indiceDestino, ref primeiroAviaoDoAeroporto, ref finalizarProcuraVoo, indiceOrigem);
                aeroportoDoVoo = vet[0];
                indiceDestinoDoVoo = vet[1];
                k = vet[2];
                maxConexoes = vet[3];
                indiceDestino = vet[4];

            }

            Console.WriteLine(k);
        }
        public int[] empilhar(int aeroportoDoVoo, int indiceDestinoDoVoo, int k, int maxConexoes, ref bool mudarPonteiro, ref bool empilharTudo, int indiceDestino, ref NodeVoo primeiroAviaoDoAeroporto)
        {
            string mensagem;

            //estrutura responsavel pelo empilhamento
            while (empilharTudo)
            {
                //inicio do 1° if
                if (empilharTudo)
                {

                    aeroportoDoVoo = indiceDestinoDoVoo;
                    primeiroAviaoDoAeroporto = vetor[aeroportoDoVoo].next;

                    //deve se passar um voo porque o definido ja vai para o lugar
                    if (primeiroAviaoDoAeroporto.indiceCidadeDestino == indiceDestino)
                    {
                        mudarPonteiro = true;
                        k++;
                    }

                    //inicio if mudar ponteiro
                    if (mudarPonteiro == false)
                    {
                        indiceDestinoDoVoo = primeiroAviaoDoAeroporto.indiceCidadeDestino;
                        //decrementa o numero de conexões que se pode fazer
                        --maxConexoes;
                        if (maxConexoes != 0)
                        {
                            mensagem = null;
                            objPilha.add(aeroportoDoVoo, indiceDestinoDoVoo, primeiroAviaoDoAeroporto.numeroVoo, maxConexoes, null);
                        }
                        else
                        {
                            mensagem = "#";
                            empilharTudo = false;
                        }
                    }//fim if mudar ponteiro

                }//fim 1° if
            }
            int[] vet = new int[5];
            vet[0] = aeroportoDoVoo;
            vet[1] = indiceDestinoDoVoo;
            vet[2] = k;
            vet[3] = maxConexoes;
            vet[4] = indiceDestino;
            return vet;
        }
        public void gerenciadorDePonteiro(int aeroportoDoVoo, int indiceDestinoDoVoo, int k, int maxConexoes, ref bool mudarPonteiro, ref bool empilharTudo, int indiceDestino, ref NodeVoo primeiroAviaoDoAeroporto, ref bool finalizarProcuraVoo, int indiceOrigem)
        {
            int[] vet = new int[5];

            vet = mudaPonteiroMtd(aeroportoDoVoo, indiceDestinoDoVoo, maxConexoes, ref mudarPonteiro, ref empilharTudo, indiceDestino, ref primeiroAviaoDoAeroporto);
            aeroportoDoVoo = vet[0];
            indiceDestinoDoVoo = vet[1];
            maxConexoes = vet[3];
            indiceDestino = vet[4];

            vet = mudaPonteiroEmpilhamento(aeroportoDoVoo, indiceDestinoDoVoo, maxConexoes, ref mudarPonteiro, ref empilharTudo, indiceDestino, ref primeiroAviaoDoAeroporto);
            aeroportoDoVoo = vet[0];
            indiceDestinoDoVoo = vet[1];
            maxConexoes = vet[3];
            indiceDestino = vet[4];

            percorrerTudo(k, ref mudarPonteiro, ref empilharTudo, indiceDestino, ref primeiroAviaoDoAeroporto);
            k = vet[2];
            indiceDestino = vet[4];

            vet = ordenarPilha(aeroportoDoVoo, indiceDestinoDoVoo, k, maxConexoes, ref mudarPonteiro, ref empilharTudo, indiceDestino, ref primeiroAviaoDoAeroporto, ref finalizarProcuraVoo);
            aeroportoDoVoo = vet[0];
            indiceDestinoDoVoo = vet[1];
            k = vet[2];
            maxConexoes = vet[3];
            indiceDestino = vet[4];
        }
        public int[] mudaPonteiroMtd(int aeroportoDoVoo, int indiceDestinoDoVoo, int maxConexoes, ref bool mudarPonteiro, ref bool empilharTudo, int indiceDestino, ref NodeVoo primeiroAviaoDoAeroporto)
        {

            if (!empilharTudo || mudarPonteiro)//inicio do 1°if
            {
                //estrutura responsavel por  mudar o ponteiro do empilhamento
                --maxConexoes;
                if (maxConexoes == 0)
                {
                    mudarPonteiro = false;
                    empilharTudo = false;
                }
                if (mudarPonteiro)
                {
                    //muda o ponteiro ja que o anterior vai para o lugar desejado85 
                    primeiroAviaoDoAeroporto = primeiroAviaoDoAeroporto.next;
                    if (primeiroAviaoDoAeroporto != null && primeiroAviaoDoAeroporto.indiceCidadeDestino != indiceDestino)
                    {

                        indiceDestinoDoVoo = primeiroAviaoDoAeroporto.indiceCidadeDestino;
                        objPilha.add(aeroportoDoVoo, indiceDestinoDoVoo, primeiroAviaoDoAeroporto.numeroVoo, maxConexoes, null);
                        mudarPonteiro = false;
                    }
                }
            }//fim do if

            int[] vet = new int[5];
            vet[0] = aeroportoDoVoo;
            vet[1] = indiceDestinoDoVoo;
            vet[3] = maxConexoes;
            vet[4] = indiceDestino;

            return vet;
            //************************************fim do programa*************************************************************

        }
        public int[] mudaPonteiroEmpilhamento(int aeroportoDoVoo, int indiceDestinoDoVoo, int maxConexoes, ref bool mudarPonteiro, ref bool empilharTudo, int indiceDestino, ref NodeVoo primeiroAviaoDoAeroporto)
        {
            int[] vet = new int[5];

            if (!empilharTudo || mudarPonteiro)
            {
                //estrutura responsavel por  mudar o ponteiro do empilhamento
                --maxConexoes;
                if (maxConexoes == 0)
                {
                    mudarPonteiro = false;
                    empilharTudo = false;
                }
                if (mudarPonteiro)
                {
                    //muda o ponteiro ja que o anterior vai para o lugar desejado
                    primeiroAviaoDoAeroporto = primeiroAviaoDoAeroporto.next;
                    if (primeiroAviaoDoAeroporto != null && primeiroAviaoDoAeroporto.indiceCidadeDestino != indiceDestino)
                    {

                        indiceDestinoDoVoo = primeiroAviaoDoAeroporto.indiceCidadeDestino;
                        objPilha.add(aeroportoDoVoo, indiceDestinoDoVoo, primeiroAviaoDoAeroporto.numeroVoo, maxConexoes, null);
                        mudarPonteiro = false;
                    }
                }

            }
            vet[0] = aeroportoDoVoo;
            vet[1] = indiceDestinoDoVoo;
            vet[3] = maxConexoes;
            vet[4] = indiceDestino;
            return vet;

        }
        public void percorrerTudo(int k, ref bool mudarPonteiro, ref bool empilharTudo, int indiceDestino, ref NodeVoo primeiroAviaoDoAeroporto)
        {
            //estrutura responsavel por percorrer todas as combinações quando o maxConexao==0
            if ((mudarPonteiro == false && empilharTudo == false))
            {
                bool sairDoWhile = false;
                while (sairDoWhile == false)
                {
                    primeiroAviaoDoAeroporto = primeiroAviaoDoAeroporto.next;
                    //estrutura responsavel por terminar de realizar todas as combinações e mudar o ponteiro
                    if (primeiroAviaoDoAeroporto == null || primeiroAviaoDoAeroporto.indiceCidadeDestino == indiceDestino)
                    {
                        sairDoWhile = true;
                        if (primeiroAviaoDoAeroporto != null)
                            k++;
                    }
                }//fim while
            }
        }
        public int[] ordenarPilha(int aeroportoDoVoo, int indiceDestinoDoVoo, int k, int maxConexoes, ref bool mudarPonteiro, ref bool empilharTudo, int indiceDestino, ref NodeVoo primeiroAviaoDoAeroporto, ref bool finalizarProcuraVoo)
        {
            bool sairDoWhile;
            bool desempilhar = true;
            //desempilha e muda o ponteiro
            while (desempilhar)
            {
                /*****************desempilha******************/
                if (objPilha.returnCaracter() != null)
                {
                    sairDoWhile = false;
                    primeiroAviaoDoAeroporto = vetor[objPilha.returnCaracter(0)].next;
                    indiceDestinoDoVoo = objPilha.returnCaracter(1);

                    //localiza o voo correto
                    while (sairDoWhile == false)
                    {
                        if (primeiroAviaoDoAeroporto.indiceCidadeDestino != indiceDestinoDoVoo)
                            primeiroAviaoDoAeroporto = primeiroAviaoDoAeroporto.next;
                        else
                            sairDoWhile = true;
                    }
                    aeroportoDoVoo = objPilha.returnCaracter(0);
                    maxConexoes = objPilha.returnCaracter(3);
                    objPilha.remove();
                    mudarPonteiro = false;
                    /*****************desempilha******************/
                    sairDoWhile = false;
                    /**********************muda o Ponteiro*******************************/
                    while (sairDoWhile == false)
                    {
                        primeiroAviaoDoAeroporto = primeiroAviaoDoAeroporto.next;
                        //não pode só mudar o ponteiro ja que o ponteiro proximo pode ser o do destino...ai se mudar para ele...
                        //ira percorrer este vetor atra´s de um voo para ele msm

                        //não pode também achar um voo para o destino de origem pq ai vai percorrer o aeroporto de origem atrás de um qe va
                        //para o destino
                        if (primeiroAviaoDoAeroporto == null || (primeiroAviaoDoAeroporto.indiceCidadeDestino != indiceDestino && primeiroAviaoDoAeroporto.indiceCidadeDestino != indiceOrigem))
                            sairDoWhile = true;
                        else if (primeiroAviaoDoAeroporto.indiceCidadeDestino == indiceDestino)
                            k++;
                    }
                    if (primeiroAviaoDoAeroporto != null)
                        indiceDestinoDoVoo = primeiroAviaoDoAeroporto.indiceCidadeDestino;
                    empilharTudo = true;
                }
                else
                    desempilhar = false;
            }

            //não ha nada a ser desempilhado
            if (primeiroAviaoDoAeroporto == null)
                finalizarProcuraVoo = true;


            //fim do if de mudar ponteiro e percorre tudo
            int[] vet = new int[5];
            vet[0] = aeroportoDoVoo;
            vet[1] = indiceDestinoDoVoo;
            vet[2] = k;
            vet[3] = maxConexoes;
            vet[4] = indiceDestino;
            return vet;
        }
        //fim da opção 6 do menu-->procura caminhos de uma origem ate um destino

    }
}

