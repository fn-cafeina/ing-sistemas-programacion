/*
    Ejercicios Propuesto 2:
     
    Enunciado: Un banco requiere un sistema para gestionar diferentes productos financieros.
    Todos los productos tienen un numeroCuenta y un saldoActual.

    Sin embargo, el cálculo de intereses es distinto:
    Cuenta de Ahorro: Genera un 5% de interés mensual sobre el saldo.

    Certificado de Depósito (CDT): Genera un 12% de interés, pero solo si el saldo es mayor a C$ 10,000;
    de lo contrario, no genera nada.

    Instrucciones de desarrollo:
    Diseñe una clase abstracta llamada CProductoFinanciero que contenga un método abstracto AplicarInteres().
    Implemente las clases derivadas correspondientes asegurando el uso de protected para los atributos.
    En el método Main, cree un arreglo de productos y demuestre el polimorfismo
    al recorrer el arreglo y aplicar los intereses de forma masiva a todos los productos,
    independientemente de su tipo.
*/

using System.Text.RegularExpressions;

abstract class CProductoFinanciero
{
    protected string numeroCuenta;
    protected double saldoActual;

    protected CProductoFinanciero(string numeroCuenta, double saldoActual)
    {
        this.numeroCuenta = numeroCuenta;
        this.saldoActual = saldoActual;
    }

    public abstract void AplicarInteres();

    public virtual void MostrarDetalle()
    {
        Console.WriteLine($"Cuenta: {numeroCuenta} | Saldo: C$ {saldoActual:F2}");
    }
}

class CuentaAhorro : CProductoFinanciero
{
    public CuentaAhorro(string numeroCuenta, double saldoActual) : base(numeroCuenta, saldoActual) { }

    public override void AplicarInteres()
    {
        saldoActual += saldoActual * 0.05;
    }

    public override void MostrarDetalle()
    {
        Console.WriteLine($"Cuenta de Ahorro: {numeroCuenta} | Saldo: C$ {saldoActual:F2}");
    }
}

class CDT : CProductoFinanciero
{
    public CDT(string numeroCuenta, double saldoActual) : base(numeroCuenta, saldoActual) { }

    public override void AplicarInteres()
    {
        if (saldoActual > 10000)
        {
            saldoActual += saldoActual * 0.12;
        }
    }

    public override void MostrarDetalle()
    {
        Console.WriteLine($"CDT: {numeroCuenta} | Saldo: C$ {saldoActual:F2}");
    }
}

class Program
{
    static void Main()
    {
        int cantidadProductos;
        while (true)
        {
            Console.Write("Ingrese la cantidad de productos financieros a crear: ");
            string entrada = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(entrada, out cantidadProductos) && cantidadProductos > 0)
            {
                break;
            }
            Console.WriteLine("Cantidad inválida. Ingrese un número entero mayor a 0.");
        }

        CProductoFinanciero[] productos = new CProductoFinanciero[cantidadProductos];

        for (int i = 0; i < cantidadProductos; i++)
        {
            Console.WriteLine($"\nProducto #{i + 1}");

            string tipo;
            while (true)
            {
                Console.Write("Tipo (Ahorro/CDT): ");
                tipo = (Console.ReadLine() ?? string.Empty).Trim().ToUpper();
                if (tipo == "AHORRO" || tipo == "CDT")
                {
                    break;
                }
                Console.WriteLine("Tipo inválido. Ingrese 'Ahorro' o 'CDT'.");
            }

            string numeroCuenta;
            int intentosValidos = 3;
            while (true)
            {
                if (intentosValidos <= 0)
                {
                    Console.WriteLine("\nDemasiados intentos, intente de nuevo mas tarde.");
                    return;
                }

                Console.Write("Número de cuenta (NI-XXXX): ");
                numeroCuenta = Console.ReadLine()?.Trim() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(numeroCuenta) && Regex.IsMatch(numeroCuenta, @"^[Nn][Ii]-\d{4}$"))
                {
                    break;
                }
                Console.WriteLine("Número de cuenta inválido.");

                intentosValidos--;
            }

            double saldoActual;
            while (true)
            {
                Console.Write("Saldo actual: ");
                string entradaSaldo = Console.ReadLine() ?? string.Empty;
                if (double.TryParse(entradaSaldo, out saldoActual) && saldoActual >= 0)
                {
                    break;
                }
                Console.WriteLine("Saldo inválido. Ingrese un número mayor o igual a 0.");
            }

            if (tipo == "AHORRO")
            {
                productos[i] = new CuentaAhorro(numeroCuenta, saldoActual);
            }
            else
            {
                productos[i] = new CDT(numeroCuenta, saldoActual);
            }
        }

        Console.WriteLine("\nResumen de productos antes de aplicar intereses:\n");
        foreach (CProductoFinanciero producto in productos)
        {
            producto.MostrarDetalle();
        }

        Console.WriteLine("\nAplicando intereses a todos los productos...\n");
        foreach (CProductoFinanciero producto in productos)
        {
            producto.AplicarInteres();
        }

        Console.WriteLine("Resumen de productos después de aplicar intereses:\n");
        foreach (CProductoFinanciero producto in productos)
        {
            producto.MostrarDetalle();
        }
    }
}