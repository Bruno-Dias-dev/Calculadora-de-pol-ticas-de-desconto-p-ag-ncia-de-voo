using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO.Ports;

namespace Agênicia_de_voo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Um agência de turismo possui uma política de descontos que variam com baseno
            //valor das passagens e na quantidade de pessoas envolvidas na compra.

            // As compras dessa modalidade são realizadas em conjunto (ex. pacote //família/empresa).

            //O valor original, sem descontos, é dado pelo valor da passagem multiplicado pela
            //quantidade de pessoas envolvidas na compra. 

            //O primeiro desconto leva em consideração o valor original do pacote.
            //Para passagens até mil reais, incide 10% de desconto sobre o valor original.
            //Para passagens acima disso, incide 15% de desconto sobre o valor original.

            //O segundo desconto leva em consideração a quantidade de pessoas. NEtre 2 e 10 peessoas, 5% de desconto.
            //Acima de 10 pessoas, 0.5% desconto por cada pessoa. Ambos incidem sobre o valor original da compra após o primeiro desconto.

            //O desconto baseado na quantidade de pessoas (acima de 10), tem um teto de 25%. Ou seja, nunca poderá ultrapassar esse percentual. 
            //O programa deverá ler o destino da viagem(X), o valor da passagem(X) e a quantidade de pessoas envolvidas na compra. (X)
            // Depois, deverá calcular o valor final da compra, realizando os descontos de acordo com as regras enunciadas.
            //Por fim, deverá exibir ao usuário a informação do destino da viagem, o número de pessoas envolvidas na compra e o valor final da compra.
            //Caso seja informado pelo usuário que só há uma pessoa envolvida na compra. O programa deverá imprimir uma mensagem informando: “Esse modalidade é restrita a compras a partir de duas passagens.” (X)
            //Após isso, o programa deverá encerrar.

            int qtdDePessoas;
            double valorDaPassagem;
            


         Console.WriteLine("---------Agência de voo---------");
         Console.WriteLine("Bem vindo(a) à nossa Agência de voo!");
         Console.WriteLine("");
         Console.WriteLine("-------Sistema de Cadastro-------");
         Console.WriteLine("Vou precisar de alguns dados para fazer o cadastro. Me informe por agora o seu nome, por favor:");
         string nome = Console.ReadLine();

         Console.WriteLine($"Ok {nome}, agora me diga o destino dá viagem para prosseguir:");
         string destino = Console.ReadLine();

         Console.WriteLine("Qual seria o valor da passagem:");
         valorDaPassagem = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

         Console.WriteLine("Quantas pessoas irão na viagem:");
         qtdDePessoas = int.Parse(Console.ReadLine());
         double valorOriginal = valorDaPassagem * qtdDePessoas;
         double valorAposPrimeiroDesconto;
         double valorAposSegundoDesconto;


         if ( qtdDePessoas <= 1 )
            {
                Console.WriteLine("Esse modalidade é restrita a compras a partir de duas passagens.");
                Console.WriteLine("Pressione qualquer tecla para sair...");
                Console.ReadKey();
                Environment.Exit(0);
            }

            else
            {
               // Desconto 1:
               if (valorDaPassagem <= 1000)
                {
                valorAposPrimeiroDesconto = valorOriginal - (valorOriginal * 0.1);
                }
              
                //Desconto 2
                else
                {
                 valorAposPrimeiroDesconto = valorOriginal - (valorOriginal * 0.15);

                }

                if (qtdDePessoas <= 10)
                {
                 valorAposSegundoDesconto = valorAposPrimeiroDesconto - (valorAposPrimeiroDesconto * 0.05);

                }

                else
                {
                 double percentualDeDescontoAgregado = qtdDePessoas * 0.005;

                    if (percentualDeDescontoAgregado > 0.25)
                        percentualDeDescontoAgregado = 0.25;

                 valorAposSegundoDesconto = valorAposPrimeiroDesconto - (valorAposPrimeiroDesconto * percentualDeDescontoAgregado);
                  
                
                
                }

                Console.WriteLine($"Seu destino é {destino}, a quantidade de pessoas é {qtdDePessoas} e o valor final é {valorAposSegundoDesconto}");

            }
            Console.ReadKey();

        }
    }
}
