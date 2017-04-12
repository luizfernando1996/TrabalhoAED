﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrabalhoAED.FAeroporto.jonathan;
using TrabalhoAED.Avioes.Luiz;

namespace TrabalhoAED.Menu
{
    class Menu
    {
        private Voo objVoo = new Voo();
        Aeroporto objAero = new Aeroporto();


        //Métodos para string
        public void imprimeMessage(string message)
        {
            Console.WriteLine(message);
        }

        //Métodos para inteiro
        public bool verificaInt(string num)
        {
            int n;
            bool wordIsString = int.TryParse(num, out n);
            return wordIsString;
        }
        public int requisitaInt()
        {
            bool sairWhile = false;
            string num = null;
            while (sairWhile == false)
            {
                Console.Write("\t");
                num = Console.ReadLine();
                //verifica se foi digitado um numero inteiro
                sairWhile = verificaInt(num);

                //se o numero não for inteiro
                if (sairWhile == false) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tDigite um número, por favor");
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }
            return int.Parse(num);
        }
        public int requisitaIntNoRange(int range)
        {
            int num = 0;
            bool sairWhile = false;
            while (sairWhile == false)
            {
                //requisita um inteiro
                num = requisitaInt();
                if (num >= 0 && num <= range)
                    sairWhile = true;
                else
                {
                    string message = "Digite um numero entre 0 a " + range;
                    imprimeMessage(message);
                }
                //requisitaIntRange();//pode dar overflow se o usuario errar mts vezes
                //melhor while
            }

            return num;
        }
        //fim dos métodos para inteiro

        //gerencia o menu
        public void gerenciadorMenu()
        {
            bool sairWhile = false;

            //gerencia a repetição e saida do menu
            while (sairWhile == false)
            {
                exibeMenu();
                //o menu tem 8 opções, logo o número deve estar no range 0-8
                int num = opcaoEscolhidaDoMenu(8);
                selecionaOptionMenu(num);
                //Usuario deseja sair do programa
                if (num == 0)
                    sairWhile = true;
            }
        }
        public void exibeMenu()
        {
            string message = null;
            message = "---------------------------Menu------------------------";
            message += "\nDigite 1 para cadastrar Aeroportos";
            message += "\nDigite 2 para cadastrar Voos";
            message += "\nDigite 3 para remover voos";
            message += "\nDigite 4 para imprimir os voos";
            message += "\nDigite 5 para imprimir tudo";
            message += "\nDigite 6 para procurar voo";
            message += "\nDigite 7 para limpar";
            message += "\nDigite 8 para inserir entradas no programa - TESTE";
            message += "\nDigite 0 para sair";
            imprimeMessage(message);
        }
        public int opcaoEscolhidaDoMenu(int range)
        {
            int num = 0;
            //requisita um numero inteiro valido no range
            num = requisitaIntNoRange(range);
            return num;
        }
        public void limparMenu()
        {
            Console.Clear();
        }

        //Opções do menu
        public void selecionaOptionMenu(int num)
        {
            switch (num)
            {
                case 1:
                    //cadastra um aeroporto solicitando uma cidade e gerando um código  
                    cadastraAeroporto();
                    break;
                case 2:
                    cadastraVoo();
                    break;
                case 3:
                    removeVoo();
                    break;
                case 4:
                    imprimeVoo();
                    break;
                case 5:
                    imprimeTudo();
                    break;
                case 6:
                    procuraVoo();
                    break;
                case 7:
                    limparMenu();
                    break;
                case 8:
                    insereDadosParaTeste();
                    break;
                case 0:
                    finalizarProgram();
                    break;
            }
        }
        public void cadastraAeroporto()
        {
            Aeroporto obj = new Aeroporto();

            string message = "Digite o nome da cidade";
            imprimeMessage(message);

            string cidade = Console.ReadLine();
            obj.cadastraAeroporto(cidade);
        }
        public void cadastraVoo()
        {
            //Voo objVoo = new Voo();
            Aeroporto objAero = new Aeroporto();

            string message = "Identifique o codigo do Voo";
            imprimeMessage(message);
            int codigoVoo = requisitaInt();

            int indiceCidadeOrigem;
            message = "Digite a cidade do Aeroporto de Origem";
            imprimeMessage(message);
            Console.Write("\t");
            string cidadeOrigem = Console.ReadLine();
            indiceCidadeOrigem=objAero.verificarAeroportoExiste(cidadeOrigem,ref message);
            //Exibe a mensagem se o Aeroporto está ou não cadastrado
            imprimeMessage(message);

            int indiceCidadeDestino;
            message = "Digite o cidade do Aeroporto de Destino";
            imprimeMessage(message);
            //int codigoDestino = requisitaInt();
            Console.Write("\t");
            string cidadeDestino = Console.ReadLine();
            indiceCidadeDestino=objAero.verificarAeroportoExiste(cidadeDestino,ref message);
            //Exibe a mensagem se o Aeroporto está ou não cadastrado
            imprimeMessage(message);

            //objVoo é um objeto da classe
            objVoo.cadastraVoo(codigoVoo, indiceCidadeOrigem, indiceCidadeDestino);
        }
        public void removeVoo()
        {
            string message = "Digite o numero do voo a ser removido";
            imprimeMessage(message);

            int numero = requisitaInt();
            //retorna uma mensagem de sucesso ou não sobre a remoção do Voo
            imprimeMessage(objVoo.removeVoo(numero));
        }
        public void imprimeVoo()
        {
           
            //imprime todos voos de um determinado aeroporto

            string message = "Forneça a sigla do Aeroporto";
            imprimeMessage(message);
            string sigla = Console.ReadLine();
            objAero.imprimeVoo(sigla);
            //int num = requisitaInt();
            //objAero.imprimeVoo(num);

        }
        public void imprimeTudo()
        {
            objAero.imprimeTudo();
        }
        public void procuraVoo()
        {
            Voo objVoo = new Voo();

            string message = "Digite o codigo de origem do Aeroporto";
            imprimeMessage(message);
            string codigoOrigem = Console.ReadLine();

            message = "Digite o codigo de destino do Aeroporto";
            imprimeMessage(message);
            string codigoDestino = Console.ReadLine();


            message = "Digite o limite maximo de conexões que deve ser apresentado";
            imprimeMessage(message);
            int maximoConexoes = requisitaInt();

            objVoo.procuraVoo(codigoOrigem, codigoDestino, maximoConexoes);

        }
        public void insereDadosParaTeste()
        {
            cadastrarAeroportosTeste();
            cadastrarVoosTeste();
        }
        public void cadastrarAeroportosTeste()
        {
            //cadastra os aeroportos
            Aeroporto obj = new Aeroporto();
            obj.cadastraAeroporto("Brasilia");
            obj.cadastraAeroporto("Belo Horizonte");
            obj.cadastraAeroporto("Rio de Janeiro");
            obj.cadastraAeroporto("São Paulo");
            obj.cadastraAeroporto("Salvador");

        }
        public void cadastrarVoosTeste()
        {
            //cadastra todos os voos        
            //cadastra voos em brasilia
            objVoo.cadastraVoo(107, 0, 5);
            //cadastra voos em belo horizonte
            objVoo.cadastraVoo(214, 1, 5);
            objVoo.cadastraVoo(555, 1, 3);
            objVoo.cadastraVoo(101, 1, 4);
            //cadastra voos em rio de janeiro
            objVoo.cadastraVoo(554, 2, 2);
            objVoo.cadastraVoo(090, 2, 4);
            //cadastra voos em sao paulo
            objVoo.cadastraVoo(050, 3, 1);
            objVoo.cadastraVoo(089, 3, 3);
            objVoo.cadastraVoo(102, 3, 2);
            //cadastra voos em salvador
            objVoo.cadastraVoo(215, 4, 2);

           //objAereo.imprimeVoo("CNF");
        }
        public void finalizarProgram()
        {
            int j = 100 * 100 * 100 * 100;
            for (int i = 0; i < 6 * j; i++)
            {
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tO programa será finalizado automaticamente");
                }
            }
        }
        //fim das opções do menu
    }
}
