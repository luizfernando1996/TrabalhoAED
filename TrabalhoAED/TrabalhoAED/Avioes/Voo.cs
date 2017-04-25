using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoAED.FolderAeroporto;

/// <summary>
/// Trabalho AED
/// 15/04/2017 
/// Alunos:Luiz Fernando e Jonathan Dias.
/// </summary>

namespace TrabalhoAED.Avioes
{
    class Voo
    {
        
        public string cadastraVoo(int numVoo, int codigoOrigem, int codigoDestino)
        {
            Aeroporto objAero = new Aeroporto();
            NodeVoo objVoo = new NodeVoo(numVoo, codigoDestino, null);
            string message=objAero.vincularVooAeroporto(objVoo, codigoOrigem);
            return message;
        }

    }
}
