using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CarregarContas();
            }
            catch (Exception)
            {
                Console.WriteLine("CATCH NO METODO MAIN");
            }

            Console.WriteLine("Execução finalizada. Tecle enter para sair");
            Console.ReadLine();
        }

        /*
        try
        {
            Metodo();
        }

        catch (DivideByZeroException e)
        {
            Console.WriteLine("Não é possivel duvidir por zero !");
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }
        */


        private static void CarregarContas()
        {

            using (LeitorDeArquivo leitor = new LeitorDeArquivo("teste.txt"))
            {
                leitor.LerProximaLinha();
            }
        }

        public static void OperacoesConta()
        {
            try
            {
                ContaCorrente conta1 = new ContaCorrente(444, 543);

                ContaCorrente conta2 = new ContaCorrente(2344, 4567);

                conta1.Transferir(5000, conta2); ;

                //conta2.Transferir(-10, conta1);

                //conta1.Depositar(150);
                //Console.WriteLine("O saldo da conta após o deposito de 150 é: " + conta1.Saldo);

                //conta1.Sacar(500);




            }
            catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                Console.WriteLine("Informações da INNER EXCEPTION (exceção interna):");

                Console.WriteLine(e.InnerException.Message);
                Console.WriteLine(e.InnerException.StackTrace);
            }

            catch (ArgumentException ex)
            {
                if (ex.ParamName == "numero")
                {
                }

                Console.WriteLine("Argumento com problema: " + ex.ParamName);
                Console.WriteLine("Ocorreu exececao do tipo ArgumentException !");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ParamName);
            }

            catch (SaldoInsuficienteException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exceção do tipo SaldoInsuficienteException");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

            }

        }

        public static int Dividir(int numero, int divisor)
        {
            try
            {
                return numero / divisor;
            }

            catch (Exception)
            {
                Console.WriteLine("Exceção com o numero: " + numero + " dividido por: " + divisor);
                throw;
            }
        }


        static void Metodo()
        {
            TestaDivisao(0);

        }


        static void TestaDivisao(int divisor)
        {
            Dividir(10, divisor);
        }
    }
}
