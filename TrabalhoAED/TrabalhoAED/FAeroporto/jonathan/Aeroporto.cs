using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoAED.Aeroporto.jonathan
{
    class Aeroporto
    {
        NodeAeroporto sentinela;

        public Aeroporto()
        {
            sentinela = new NodeAeroporto();
        }
        public void cadastraAeroporto(string cidade, string sigla)
        {
            NodeAeroporto novo = new NodeAeroporto(cidade, sigla, null);

        } 

        public void imprimeTudo()
        {
            NodeAeroporto p = sentinela;
            while (p.next != null)
            {
                Console.WriteLine(p.next);
            }
        }
    }
}
