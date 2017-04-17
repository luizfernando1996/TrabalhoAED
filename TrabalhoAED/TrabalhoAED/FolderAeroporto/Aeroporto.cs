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
        private static int indice = 0;

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
        private int caminhosPossiveis;
        private string mensagem = null;
        private int quantOpcao = 1;
        private int cont;

        //construtor
        public Aeroporto() { }


        /***Métodos auxiliares aos diversos métodos da classe******/

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

        /***Métodos auxiliares aos diversos métodos da classe******/


        //---------Menu-----------------//

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
            string messagem;
            switch (cidade)
            {
                case "brasilia":
                case "brasília":
                    messagem = "BSB";
                    break;
                case "belo horizonte":
                    messagem = "CNF";
                    break;
                case "rio de janeiro":
                    messagem = "GIG";
                    break;
                case "são paulo":
                case "sao paulo":
                    messagem = "GRU";
                    break;
                case "salvador":
                    messagem = "SSA";
                    break;
                default:
                    messagem = "sigla não encontrada";
                    break;
            }
            return messagem;
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
                message = "Voo cadastrado com sucesso";
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
            //seta alguns parametros necessarios
            indiceOrigem = encontraIndiceAeroportoPelaSigla(siglaOrigem);
            indiceDestino = encontraIndiceAeroportoPelaSigla(siglaDestino);

            indiceDestinoDoVoo = indiceOrigem;
            this.maxConexoes = maxConexoes;

            //Executa os métodos  necessario para percorrer todos os caminhos
            int selecionaMtd = 1;
            bool mudouPonteiro = false;
            bool desempilhou = false;
            bool empilharAtivou = false;

            while (selecionaMtd != 0)
            {
                //chama a função empilha
                if (selecionaMtd == 1)
                    selecionaMtd = empilhar(mudouPonteiro, ref desempilhou, ref empilharAtivou);

                //chama a mudança de ponteiro
                else if (selecionaMtd == 2)
                    selecionaMtd = mudaPonteiroMtd(ref mudouPonteiro, ref empilharAtivou);

                //percorreTudo
                else if (selecionaMtd == 3)
                    selecionaMtd = percorrerTudo();

                //desempilha a pilha
                else if (selecionaMtd == 4)
                    selecionaMtd = desempilharPilha(ref desempilhou);
            }
            Console.WriteLine();
            Console.WriteLine("\t Existem " + caminhosPossiveis + " caminhos");

        }

        public int empilhar(bool mudouPonteiro, ref bool desempilhou, ref bool empilharAtivou)
        {
            int selecionaMtd = 1;

            //estrutura responsavel pelo empilhamento consecutivo
            while (selecionaMtd == 1)
            {
                //Estrutura que impede que após a mudança de ponteiro se pegue o primeiro voo
                if (mudouPonteiro == false)
                {
                    aeroportoDoVoo = indiceDestinoDoVoo;
                    primeiroAviaoDoAeroporto = vetor[aeroportoDoVoo].next;
                }
                else
                    mudouPonteiro = false;

                //Empilha o voo posterior ao voo desempilhado
                if (desempilhou)
                {
                    indiceDestinoDoVoo = primeiroAviaoDoAeroporto.indiceCidadeDestino;
                    //primeiroAviaoDoAeroporto = vetor[aeroportoDoVoo].next;
                    desempilhou = false;
                    ++maxConexoes;
                }

                //Verifica se pode empilhar, isto é, se o voo não vai para a origem ou para o destino
                empilharAtivou = true;
                selecionaMtd = casosMudancaPonteiro(ref empilharAtivou);
                empilharAtivou = false;

                //SelecionaMtd==1-->Pode se empilhar o voo não vai para a origem ou para o destino
                if (selecionaMtd == 1)
                {
                    indiceDestinoDoVoo = primeiroAviaoDoAeroporto.indiceCidadeDestino;
                    --maxConexoes;

                    //Deve se percorrer tudo
                    if (maxConexoes == 0)
                    {
                        selecionaMtd = 3;//selecionaMtd3-->percorre tudo
                    }
                    else
                    {
                        string siglaOrigem = encontraSiglaAeroportoPeloIndice(aeroportoDoVoo);
                        string siglaDestino = encontraSiglaAeroportoPeloIndice(primeiroAviaoDoAeroporto.indiceCidadeDestino);
                        mensagem += "Opção " + quantOpcao + ":" + " (" + primeiroAviaoDoAeroporto.numeroVoo + ") " + siglaOrigem + " - " + siglaDestino + ",";
                        objPilha.add(aeroportoDoVoo, indiceDestinoDoVoo, primeiroAviaoDoAeroporto.numeroVoo, maxConexoes, mensagem);
                        mensagem = null;
                    }

                }//fim if 

            }//fim do while

            return selecionaMtd;
        }

        public int mudaPonteiroMtd(ref bool mudouPonteiro, ref bool empilharAtivou)
        {
            bool ponteiroNull = false;
            //Verifica se pode finalizar a mudança do ponteiro
            while (ponteiroNull == false && casosMudancaPonteiro(ref empilharAtivou) == 2)
            {
                //Efetua a mudança do ponteiro
                primeiroAviaoDoAeroporto = primeiroAviaoDoAeroporto.next;

                if (primeiroAviaoDoAeroporto == null)
                    ponteiroNull = true;
            }
            //Ocorreu a troca de ponteiro, logo o empilhar não pode empilhar o primeiro elemento
            //mas deve empilhar o voo alterado neste metodo
            mudouPonteiro = true;

            int retorno;
            if (ponteiroNull == false)
                retorno = 1;//retorno-->1 empilhar
            else
                retorno = 4;//retorno-->4 desempilhar

            return retorno;
        }
        public int casosMudancaPonteiro(ref bool empilharAtivou)
        {
            int selecionaMtd = 2;
            bool trocarPonteiroDesempilhamento = false;

            //O voo no momento é um voo que foi desempilhado,
            //logo ele só necessita OBRIGATORIAMENTE de UMA mudança de ponteiro
            if ((cont == 0) && (empilharAtivou == false))
            {
                if ((primeiroAviaoDoAeroporto.indiceCidadeDestino != indiceDestino) && (primeiroAviaoDoAeroporto.indiceCidadeDestino != indiceOrigem))
                {
                    selecionaMtd = 2;
                    trocarPonteiroDesempilhamento = true;
                }
            }

            //É um voo que está sendo empilhando
            if (trocarPonteiroDesempilhamento == false)
            {
                //O voo ja vai para o lugar desejado
                if (primeiroAviaoDoAeroporto.indiceCidadeDestino == indiceDestino)
                {
                    //muda o ponteiro
                    selecionaMtd = 2;
                    //Dois metodos diferentes acessam este método.
                    //Só deve ser permitido que um deles incremente
                    if (empilharAtivou == false)
                    {
                        caminhosPossiveis++;
                        string siglaOrigem = encontraSiglaAeroportoPeloIndice(aeroportoDoVoo);
                        string siglaDestino = encontraSiglaAeroportoPeloIndice(primeiroAviaoDoAeroporto.indiceCidadeDestino);


                        if (objPilha.returnMensagem() != null)
                            mensagem = "\n" + objPilha.returnMensagem() + "," + " Opção " + quantOpcao + ":" + " (" + primeiroAviaoDoAeroporto.numeroVoo + ") " + siglaOrigem + " - " + siglaDestino;
                        else
                            mensagem = "\nOpção " + quantOpcao + ":" + " (" + primeiroAviaoDoAeroporto.numeroVoo + ") " + siglaOrigem + " - " + siglaDestino;
                        //Incrementa sempre no final para que assim a mensagem esteja sempre correta
                        quantOpcao++;
                        Console.WriteLine(mensagem);
                        mensagem = null;
                    }
                }
                //O voo volta ao lugar de origem.
                else if (primeiroAviaoDoAeroporto.indiceCidadeDestino == indiceOrigem)
                {
                    //muda o ponteiro
                    selecionaMtd = 2;
                }
                //Não é necessario mais alterar o ponteiro
                else
                    //deve se empilhar
                    selecionaMtd = 1;
            }
            //Reseta o ponteiro de desempilhamento
            trocarPonteiroDesempilhamento = false;
            //variavel que Obriga pelo menos UMA mudança no ponteiro de desempilhamento 
            cont = 1;
            return selecionaMtd;
        }
        public int percorrerTudo()
        {

            bool sairDoWhile = false;

            //Estrutura responsável por percorrer todas as combinações quando o maxConexao==0
            while (sairDoWhile == false)
            {

                if (primeiroAviaoDoAeroporto == null)
                    sairDoWhile = true;
                else if (primeiroAviaoDoAeroporto.indiceCidadeDestino == indiceDestino)
                {
                    caminhosPossiveis++;
                    string siglaOrigem = encontraSiglaAeroportoPeloIndice(aeroportoDoVoo);
                    string siglaDestino = encontraSiglaAeroportoPeloIndice(primeiroAviaoDoAeroporto.indiceCidadeDestino);


                    if (objPilha.returnMensagem() != null)
                        mensagem = "\n" + objPilha.returnMensagem() + "," + " Opção " + quantOpcao + ":" + " (" + primeiroAviaoDoAeroporto.numeroVoo + ") " + siglaOrigem + " - " + siglaDestino;
                    else
                        mensagem = "\nOpção " + quantOpcao + ":" + " (" + primeiroAviaoDoAeroporto.numeroVoo + ") " + siglaOrigem + " - " + siglaDestino;

                    //Incrementa sempre no final porque assim a mensagem terá a opcao sempre no valor correto
                    quantOpcao++;


                }
                //else if (primeiroAviaoDoAeroporto.indiceCidadeDestino == IndiceOrigem)
                //No caso acima mudar o ponteiro é a ação necessaria
                if (primeiroAviaoDoAeroporto != null)
                    primeiroAviaoDoAeroporto = primeiroAviaoDoAeroporto.next;

            }//fim while

            int selecionaMtd = 4;//desempilhar a pilha
            return selecionaMtd;

        }
        public int desempilharPilha(ref bool desempilhou)
        {
            int selecionaMtd; ;

            /*****************desempilha******************/
            if (objPilha.returnCaracter() != null)
            {
                //O voo abaixo é o 1°Voo do aeroporto, não necessariamente o Voo que deseja desempilhar
                primeiroAviaoDoAeroporto = vetor[objPilha.returnCaracter(0)].next;
                indiceDestinoDoVoo = objPilha.returnCaracter(1);

                //Localiza o voo correto que deseja desempilhar
                bool sairDoWhile = false;
                while (sairDoWhile == false)
                {
                    if (primeiroAviaoDoAeroporto.indiceCidadeDestino == indiceDestinoDoVoo)
                        sairDoWhile = true;
                    else
                        primeiroAviaoDoAeroporto = primeiroAviaoDoAeroporto.next;
                }

                //finaliza o desempilhamento dos atributos do objeto pilha
                aeroportoDoVoo = objPilha.returnCaracter(0);
                maxConexoes = objPilha.returnCaracter(3);
                objPilha.remove();

                //ira mudar o ponteiro
                selecionaMtd = 2;

                /*****************desempilha******************/
            }
            //encerra a estrutura
            else
                selecionaMtd = 0;

            cont = 0;
            desempilhou = true;
            return selecionaMtd;
        }

        //---------Fim do Menu-----------------//

    }
}