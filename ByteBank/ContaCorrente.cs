// using _05_ByteBank;
using System;


namespace ByteBank
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; }

        public static int TotalDeContasCriadas { get; private set; }

        public static double TaxaOperacao { get; private set; }

        public int Agencia { get; }

        public int Numero { get; }

        private double _saldo = 100;

        public int ContadorSaquesNaoPermitidos { get; private set; }

        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }


        public ContaCorrente(int agencia, int numero)
        {
            
            if (agencia <= 0)
            {
                throw new ArgumentException ("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }

            if (numero <= 0)
            {
                throw new ArgumentException ("O argumento numero deve ser maior que 0.", nameof(numero));
            }

            

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;

            TaxaOperacao = 30 / TotalDeContasCriadas;
            

        }
        
        

        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new SaldoInsuficienteException("Saque não pode ser negativo.");
            }

            if (_saldo < valor)
            {
                // throw new SaldoInsuficienteException(_saldo, valor);
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }
            

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            try
            {
                Sacar(valor);
            }
            catch(SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw;
            }

            contaDestino.Depositar(valor);
        }
    }
}
