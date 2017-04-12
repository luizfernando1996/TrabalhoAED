using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrabalhoAED.Aeroporto.jonathan;
using TrabalhoAED.Avioes.Luiz;

namespace TrabalhoAED.Menu
{
    class Menu
    {
        public static void Main(string[] args)
        {
            Voo obj1 = new Voo();
            Console.WriteLine("---------------------------Menu------------------------");
            Console.WriteLine("Digite 1 para Procurar Voos");
            Console.WriteLine("Digite 2 para Cadastrar Aeroportos");

            Console.ReadKey();
        }


    }
}
