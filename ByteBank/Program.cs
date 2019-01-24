using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {

        static void Main(string[] args)
        {

            /*
            ContaCorrente conta = new ContaCorrente(7480, 874150);
            Console.WriteLine(ContaCorrente.TaxaOperacao);
        

            Console.ReadLine();
            */
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
        }


        public static int Dividir(int numero, int divisor)
        {
            //ContaCorrente conta = null;
            //Console.WriteLine(conta.Saldo);

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
