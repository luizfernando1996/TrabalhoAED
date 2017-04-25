using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Trabalho AED
/// 15/04/2017 
/// Alunos:Luiz Fernando e Jonathan Dias.
/// </summary>
/// 
namespace TrabalhoAED.FolderPilha
{
    public class Pilha
    {
        //attribute of class
        private NodePilha fimPilha;

        //construtor
        public Pilha()
        {
            fimPilha = null;
        }

        //operation basic of stack
        public bool stackEmpty()
        {
            return fimPilha == null;
        }
        public void add(int aeroportoDoVoo, int indiceCidadeDestino, int numeroVoo, int maxConexoes, string mensagem)
        {
            if (stackEmpty())
            {
                NodePilha obj = new NodePilha(aeroportoDoVoo, indiceCidadeDestino, numeroVoo, maxConexoes, mensagem, null);
                fimPilha = obj;
            }
            else
            {
                NodePilha obj1 = new NodePilha(aeroportoDoVoo, indiceCidadeDestino, numeroVoo, maxConexoes, mensagem, fimPilha);
                fimPilha = obj1;
            }
        }
        public void remove()
        {
            if (fimPilha != null)
                fimPilha = fimPilha.next;
        }

        public void show()
        {
            NodePilha p = fimPilha;
            while (p != null)
            {
                Console.Write("\nO numero do Aeroporto é: " + p.aeroportoDoVoo + "\nO numero da cidade de destino é: " + p.indiceCidadeDestino + "\nO numero do Voo é: " + p.numeroVoo);
                p = p.next;
            }
            Console.WriteLine();
        }

        public NodePilha returnCaracter()
        {
            return fimPilha;
        }
        //retorna um atributo desejado do objeto pilha
        public int returnCaracter(int n = 0)
        {
            switch (n)
            {
                case 0:
                    n = fimPilha.aeroportoDoVoo;
                    break;
                case 1:
                    n = fimPilha.indiceCidadeDestino;
                    break;
                case 2:
                    n = fimPilha.numeroVoo;
                    break;
                case 3:
                    n = fimPilha.maxConexoes;
                    break;
                default:
                    Console.WriteLine("ERRO NA Pilha METODO RETURN CARACTER");
                    break;
            }
            return n;
        }
        //RETORNA a mensagem de todos os objetos empilhados na forma correta
        public string returnMensagem(int quantOpcao)
        {
            string message = null;
            NodePilha ponteiro = fimPilha;
            while (ponteiro != null)
            {
                if (stackEmpty())
                    message += null;
                else
                    //troca a ordem do conteudo
                    message = "Opção " + quantOpcao + ponteiro.mensagem + "," + message;

                ponteiro = ponteiro.next;
            }

            return message;
        }
    }

}


