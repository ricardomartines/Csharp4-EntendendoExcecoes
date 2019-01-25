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
            try
            {
                ContaCorrente conta = new ContaCorrente(54, 0);
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

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
