public class CuentaBancaria
{
    public double Saldo { get; private set; }

    public CuentaBancaria(double saldoInicial)
    {
        Saldo = saldoInicial;
    }

    public void Retirar(double monto)
    {
        if (monto < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(monto), "No puede retirar una cantidad negativa.");
        }

        if (monto > Saldo)
        {
            throw new InvalidOperationException("No puede retirar mas dinero del disponible.");
        }

        Saldo -= monto;
    }
}
