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

        private static NodeAeroporto[] vetor = new NodeAeroporto[10];
        //todos os objetos devem ter o mesmos aeroportos
        static int indice = 0;

        //objeto pilha
        public Pilha objPilha = new Pilha();

        //objeto para a opcao 6 do menu
        public NodeVoo primeiroAviaoDoAeroporto;

        //atributos
        private int aeroportoDoVoo;
        private int indiceOrigem;
        private int indiceDestinoDoVoo;
        private int indiceDestino;
        private int maxConexoes;
        private int k;

        //propriedades
        public int AeroportoDoVoo
        {
            get
            {
                return aeroportoDoVoo;
            }

            set
            {
                aeroportoDoVoo = value;
            }
        }
        public int IndiceOrigem
        {
            get
            {
                return indiceOrigem;
            }

            set
            {
                indiceOrigem = value;
            }
        }
        public int IndiceDestinoDoVoo
        {
            get
            {
                return indiceDestinoDoVoo;
            }

            set
            {
                indiceDestinoDoVoo = value;
            }
        }
        public int IndiceDestino
        {
            get
            {
                return indiceDestino;
            }

            set
            {
                indiceDestino = value;
            }
        }
        public int MaxConexoes
        {
            get
            {
                return maxConexoes;
            }

            set
            {
                maxConexoes = value;
            }
        }
        public int K
        {
            get
            {
                return k;
            }

            set
            {
                k = value;
            }
        }



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
        public void procuraVoo(string siglaOrigem, string siglaDestino,int maxConexoes)
        {
            
            int indiceOrigem = encontraIndiceAeroportoPelaSigla(siglaOrigem);
            int indiceDestino = encontraIndiceAeroportoPelaSigla(siglaDestino);


            primeiroAviaoDoAeroporto = vetor[indiceOrigem].next;

            int indiceDestinoDoVoo, aeroportoDoVoo = indiceOrigem;
            indiceDestinoDoVoo = aeroportoDoVoo;

            bool empilharTudo = true;
            bool mudarPonteiro = false;
            bool finalizarProcuraVoo = false;

            while (finalizarProcuraVoo == false)
            {
                //chama a função empilha
                empilhar();

                //coloca o retorno da função empilha nas variaveis corretas

                gerenciadorDePonteiro();


            }
        }
        public void empilhar()
        {
            string mensagem;
            bool mudarPonteiro=false, empilharTudo=true;
            //estrutura responsavel pelo empilhamento
            while (empilharTudo)
            {
                //inicio do 1° if
                if (empilharTudo)
                {

                    AeroportoDoVoo = IndiceDestinoDoVoo;
                    primeiroAviaoDoAeroporto = vetor[AeroportoDoVoo].next;

                    //deve se passar um voo porque o definido ja vai para o lugar
                    if (primeiroAviaoDoAeroporto.indiceCidadeDestino == IndiceDestino)
                    {
                        mudarPonteiro = true;
                        K++;
                    }

                    //inicio if mudar ponteiro
                    if (mudarPonteiro == false)
                    {
                        IndiceDestinoDoVoo = primeiroAviaoDoAeroporto.indiceCidadeDestino;
                        //decrementa o numero de conexões que se pode fazer
                        --MaxConexoes;
                        if (MaxConexoes != 0)
                        {
                            mensagem = null;
                            objPilha.add(AeroportoDoVoo, IndiceDestinoDoVoo, primeiroAviaoDoAeroporto.numeroVoo, MaxConexoes, null);
                        }
                        else
                        {
                            mensagem = "#";
                            empilharTudo = false;
                        }
                    }//fim if mudar ponteiro

                }//fim 1° if
            }
        }
        public void gerenciadorDePonteiro()
        {
            bool mudarPonteiro, empilharTudo, finalizarProcuraVoo;
            mudaPonteiroMtd();

            mudaPonteiroEmpilhamento();

            percorrerTudo();

          ordenarPilha();
        }
        public void mudaPonteiroMtd()
        {
            bool mudarPonteiro=false, empilharTudo=true;
            if (!empilharTudo || mudarPonteiro)//inicio do 1°if
            {
                //estrutura responsavel por  mudar o ponteiro do empilhamento
                --MaxConexoes;
                if (MaxConexoes == 0)
                {
                    mudarPonteiro = false;
                    empilharTudo = false;
                }
                if (mudarPonteiro)
                {
                    //muda o ponteiro ja que o anterior vai para o lugar desejado85 
                    primeiroAviaoDoAeroporto = primeiroAviaoDoAeroporto.next;
                    if (primeiroAviaoDoAeroporto != null && primeiroAviaoDoAeroporto.indiceCidadeDestino != IndiceDestino)
                    {

                        IndiceDestinoDoVoo = primeiroAviaoDoAeroporto.indiceCidadeDestino;
                        objPilha.add(AeroportoDoVoo, IndiceDestinoDoVoo, primeiroAviaoDoAeroporto.numeroVoo, MaxConexoes, null);
                        mudarPonteiro = false;
                    }
                }
            }//fim do if
            //************************************fim do programa*************************************************************

        }
        public void mudaPonteiroEmpilhamento()
        {
            bool mudarPonteiro=false, empilharTudo=false;
            int[] vet = new int[5];

            if (!empilharTudo || mudarPonteiro)
            {
                //estrutura responsavel por  mudar o ponteiro do empilhamento
                --MaxConexoes;
                if (MaxConexoes == 0)
                {
                    mudarPonteiro = false;
                    empilharTudo = false;
                }
                if (mudarPonteiro)
                {
                    //muda o ponteiro ja que o anterior vai para o lugar desejado
                    primeiroAviaoDoAeroporto = primeiroAviaoDoAeroporto.next;
                    if (primeiroAviaoDoAeroporto != null && primeiroAviaoDoAeroporto.indiceCidadeDestino != IndiceDestino)
                    {

                        IndiceDestinoDoVoo = primeiroAviaoDoAeroporto.indiceCidadeDestino;
                        objPilha.add(AeroportoDoVoo, IndiceDestinoDoVoo, primeiroAviaoDoAeroporto.numeroVoo, MaxConexoes, null);
                        mudarPonteiro = false;
                    }
                }

            }
        }
        public void percorrerTudo()
        {
            bool mudarPonteiro=false, empilharTudo=false;
            //estrutura responsavel por percorrer todas as combinações quando o maxConexao==0

            if ((mudarPonteiro == false && empilharTudo == false))
            {
                bool sairDoWhile = false;
                while (sairDoWhile == false)
                {
                    primeiroAviaoDoAeroporto = primeiroAviaoDoAeroporto.next;
                    //estrutura responsavel por terminar de realizar todas as combinações e mudar o ponteiro
                    if (primeiroAviaoDoAeroporto == null || primeiroAviaoDoAeroporto.indiceCidadeDestino == IndiceDestino)
                    {
                        sairDoWhile = true;
                        if (primeiroAviaoDoAeroporto != null)
                            K++;
                    }
                }//fim while
            }
        }
        public void ordenarPilha()
        {
            bool mudarPonteiro, empilharTudo, finalizarProcuraVoo;
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
                    IndiceDestinoDoVoo = objPilha.returnCaracter(1);

                    //localiza o voo correto
                    while (sairDoWhile == false)
                    {
                        if (primeiroAviaoDoAeroporto.indiceCidadeDestino != IndiceDestinoDoVoo)
                            primeiroAviaoDoAeroporto = primeiroAviaoDoAeroporto.next;
                        else
                            sairDoWhile = true;
                    }
                    AeroportoDoVoo = objPilha.returnCaracter(0);
                    MaxConexoes = objPilha.returnCaracter(3);
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
                        if (primeiroAviaoDoAeroporto == null || (primeiroAviaoDoAeroporto.indiceCidadeDestino != IndiceDestino && primeiroAviaoDoAeroporto.indiceCidadeDestino != IndiceOrigem))
                            sairDoWhile = true;
                        else if (primeiroAviaoDoAeroporto.indiceCidadeDestino == IndiceDestino)
                            K++;
                    }
                    if (primeiroAviaoDoAeroporto != null)
                        IndiceDestinoDoVoo = primeiroAviaoDoAeroporto.indiceCidadeDestino;
                    empilharTudo = true;
                }
                else
                    desempilhar = false;
            }

            //não ha nada a ser desempilhado
            if (primeiroAviaoDoAeroporto == null)
                finalizarProcuraVoo = true;


            //fim do if de mudar ponteiro e percorre tudo
        }
        //fim da opção 6 do menu-->procura caminhos de uma origem ate um destino
    }
}

