using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrabalhoAED.PastaAeroporto;
using TrabalhoAED.Avioes;

namespace TrabalhoAED.Menu
{
    class Menu
    {
        private Voo objVoo = new Voo();
        private Aeroporto objAero = new Aeroporto();

        //Métodos para string
        public void imprimeMessage(string message, int position = 0)
        {
            switch (position)
            {
                case 0:
                    break;
                case 1:
                    Console.Write("\t");
                    break;
                case 2:
                    Console.Write("\n");
                    break;
                case 3:
                    Console.WriteLine();
                    break;
                default:
                    break;
            }
            Console.WriteLine(message);
        }
        //solicita a string no inicio=0 ou no meio=1
        public string solicitaString(int position = 0)
        {
            switch (position)
            {
                //solicita string no meio da tela
                case 1:
                    Console.Write("\t");
                    break;
                default:
                    break;
            }
            return Console.ReadLine();
        }
        //fim dos métodos para string

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
                //o menu tem 8 opções, logo o número deve estar no range 0-9
                int num = opcaoEscolhidaDoMenu(9);
                Console.WriteLine();
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
            message += "\nDigite 8 para procurar voo";
            message += "\nDigite 9 para inserir entradas no programa - TESTE";
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
                    procuraVoo();
                    break;
                case 9:
                    insereDadosParaTeste();
                    break;
                case 0:
                    finalizarProgram();
                    break;
            }
        }

        //Opções do menu--> 1
        public void cadastraAeroporto()
        {
            Aeroporto obj = new Aeroporto();

            string message = "Digite o nome da cidade";
            imprimeMessage(message);

            string cidade = solicitaString();
            string resultado = obj.cadastraAeroporto(cidade);
            imprimeMessage(resultado);
        }

        //métodos para cadastrarVoo -->OPÇÃO 2 DO MENU
        public void cadastraVoo()
        {
            gerenciaIndicesCidades();

        }
        public void gerenciaIndicesCidades()
        {
            int numeroVoo = solicitaNumeroVoo();

            string message;
            //solicita uma aeroporto origem CADASTRADO
            int indiceCidadeOrigem = solicitaCidadeOrigem();
            if (indiceCidadeOrigem != 10)
            {
                //solicita uma aeroporto destino CADASTRADO
                int indiceCidadeDestino = solicitaCidadeDestino();
                if (indiceCidadeDestino != 10)
                {
                    //retorna se cadastrou ou não o voo
                    message = objVoo.cadastraVoo(numeroVoo, indiceCidadeOrigem, indiceCidadeDestino);
                }
                else
                    message = "Aeroporto de destino não cadastrado";
            }
            else
                message = "Aeroporto de origem não cadastrado";

            imprimeMessage(message);
        }
        public int solicitaNumeroVoo()
        {
            string message = "Identifique o codigo do Voo";
            imprimeMessage(message);
            int numeroVoo = requisitaInt();
            return numeroVoo;
        }
        public int solicitaCidadeOrigem()
        {
            string message = "Digite a cidade do Aeroporto de Origem";
            imprimeMessage(message);

            string cidadeOrigem = solicitaString(1);

            int indiceExiste = objAero.encontraIndiceAeroportoPelaCidade(cidadeOrigem);
            return indiceExiste;
        }
        public int solicitaCidadeDestino()
        {
            string message = "Digite o cidade do Aeroporto de Destino";
            imprimeMessage(message);

            string cidadeDestino = solicitaString(1);
            int indiceCidadeDestino = objAero.encontraIndiceAeroportoPelaCidade(cidadeDestino);
            return indiceCidadeDestino;
        }
        //fim dos métodos para cadastrarVoo

        //Opções do menu--> 3,4,5,6,7,8

        public void removeVoo()
        {
            string message = "Digite o numero do voo a ser removido";
            imprimeMessage(message);

            int numero = requisitaInt();
            //retorna uma mensagem de sucesso ou não sobre a remoção do Voo
            objAero.removeVoo(numero);
        }
        //imprime todos voos de um determinado aeroporto
        public void imprimeVoo()
        {
            string message = "Forneça a sigla do Aeroporto";
            imprimeMessage(message);
            string sigla = Console.ReadLine();
            objAero.imprimeVoo(sigla);
        }
        public void imprimeTudo()
        {
            objAero.imprimeTudo();
        }
        public void limparMenu()
        {
            Console.Clear();
        }
        public void procuraVoo()
        {
            string message = "Digite a sigla de origem do Aeroporto";
            imprimeMessage(message);
            string siglaOrigem = solicitaString();
            //objAero.buscaSigla();

            message = "Digite a sigla de destino do Aeroporto";
            imprimeMessage(message);
            string siglaDestino = solicitaString();
            //objAero.buscaSigla();

            message = "Digite o limite maximo de conexões que deve ser apresentado";
            imprimeMessage(message);
            int maximoConexoes = requisitaInt();

            objAero.procuraVoo(siglaOrigem, siglaDestino, maximoConexoes);

        }

        //métodos de teste -->OPÇÃO 9 DO MENU
        public void insereDadosParaTeste()
        {
            cadastrarAeroportosTeste();
            cadastrarVoosTeste();
            procuraVooTeste();
        }
        public void cadastrarAeroportosTeste()
        {
            //cadastra os aeroportos
            Aeroporto obj = new Aeroporto();
            string message = null;
            message += obj.cadastraAeroporto("Brasilia");
            message += "\n" + obj.cadastraAeroporto("Belo Horizonte");
            message += "\n" + obj.cadastraAeroporto("Rio de Janeiro");
            message += "\n" + obj.cadastraAeroporto("São Paulo");
            message += "\n" + obj.cadastraAeroporto("Salvador");
            imprimeMessage(message);

        }
        public void cadastrarVoosTeste()
        {
            //cadastra todos os voos
            string message = null;
            //cadastra voos em brasilia
            message += "\n" + objVoo.cadastraVoo(107, 0, 4);
            //cadastra voos em belo horizonte
            message += "\n" + objVoo.cadastraVoo(214, 1, 4);
            message += "\n" + objVoo.cadastraVoo(555, 1, 2);
            message += "\n" + objVoo.cadastraVoo(101, 1, 3);
            //cadastra voos em rio de janeiro
            message += "\n" + objVoo.cadastraVoo(554, 2, 1);
            message += "\n" + objVoo.cadastraVoo(090, 2, 3);
            message += "\n" + objVoo.cadastraVoo(090, 2, 3);
            //cadastra voos em sao paulo
            message += "\n" + objVoo.cadastraVoo(050, 3, 0);
            message += "\n" + objVoo.cadastraVoo(089, 3, 2);
            message += "\n" + objVoo.cadastraVoo(102, 3, 1);
            //cadastra voos em salvado
            message += "\n" + objVoo.cadastraVoo(215, 4, 1);
            message += "\n" + objVoo.cadastraVoo(215, 4, 1);

            imprimeMessage(message);
            //fim do cadastra todos os voos

        }
        public void procuraVooTeste()
        {

            objAero.procuraVoo("GIG", "CNF", 2);
        }
        //fim dos métodos de teste

        //Opção do menu--> 0
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
