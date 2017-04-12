using System;
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
        public static void Main(string[] args)
        {
            Aeroporto obj1 = new Aeroporto();
            Console.WriteLine("---------------------------Menu------------------------");
            Console.WriteLine("Digite 1 para Procurar Voos");
            Console.WriteLine("Digite 2 para Cadastrar Aeroportos");
            string num = Console.ReadLine();
            switch (num)
            {
                case "2":
                    Console.WriteLine("Digite o nome da cidade");
                    string cidade = Console.ReadLine();
                    Console.WriteLine("Digite o código");
                    string sigla = Console.ReadLine();
                    
                    break;

                default:
                    break;
            }

            Console.ReadKey();
        }


    }
}
