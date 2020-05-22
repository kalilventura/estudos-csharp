namespace Exercicio01
{
    public class Conta
    {
        public Conta(string titular, double saldo)
        {
            Titular = titular;
            Saldo = saldo;
        }

        public string Titular { get; private set; }
        public double Saldo { get; private set; }

        public void Depositar(double valorDeposito)
        {
            Saldo += valorDeposito;
        }
    }
}