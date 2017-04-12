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
                sairWhile = verificaInt(num);//verifica se foi digitado um numero inteiro

                if (sairWhile == false)  //se o numero não for inteiro
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
                num = requisitaInt();//requisita um inteiro
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

            //exibe menu principal
            //gerencia a repetição e saida do menu
            while (sairWhile == false)
            {
                exibeMenu();
                //o menu tem 7 opções, logo o número deve estar no range 0-7
                int num = opcaoEscolhidaDoMenu(7);
                selecionaOptionMenu(num);
                //Usuario deseja sair do programa então não mostre menu e só saia
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
            obj.cadastraAeroporto(cidade, 1);
        }
        public void cadastraVoo()
        {
            Voo objVoo = new Voo();

            string message = "Identifique o codigo do Voo";
            imprimeMessage(message);
            int codigoVoo = requisitaInt();

            message = "Digite o codigo do Aeroporto de Origem";
            imprimeMessage(message);
            //int codigoOrigem = requisitaInt();//requisita codigo
            string codigoOrigem = Console.ReadLine();

            message = "Digite o codigo do Aeroporto de Destino";
            imprimeMessage(message);
            //int codigoDestino = requisitaInt();
            string codigoDestino = Console.ReadLine();


            objVoo.cadastraVoo(codigoVoo, codigoOrigem, codigoDestino);
        }
        public void removeVoo()
        {
            Voo objVoo = new Voo();

            string message = "Digite o numero do voo a ser removido";
            imprimeMessage(message);

            int numero = requisitaInt();
            objVoo.removeVoo(numero);
        }
        public void imprimeVoo()
        {
            //imprime todos voos de um determinado aeroporto
            string message = "Forneça o código do Aeroporto";
            imprimeMessage(message);

            int num = requisitaInt();
        }
        public void imprimeTudo()
        {
            Aeroporto obj = new Aeroporto();
            obj.imprimeTudo();
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
