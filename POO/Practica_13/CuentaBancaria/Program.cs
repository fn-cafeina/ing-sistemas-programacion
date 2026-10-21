/*
    Imagina que tiene una cuenta bancaria con un saldo fijo de $500.
    El programa debe solicitar al usuario que ingrese el monto a retirar,
    calcular el nuevo saldo y mostrarlo en pantalla.

    Requerimientos del código:
    Lanzar la excepción FormatException si el usuario escribe letras o deja el espacio vacío y lanzar
    una excepción general con throw si el usuario intenta retirar mas dinero del que tiene disponible o
    un monto negativo.
*/

class Program
{
    static void Main()
    {
        var cuenta = new CuentaBancaria(500);

        Console.Write($"Saldo: ${cuenta.Saldo}\nIngrese el monto a retirar: ");

        try
        {
            double monto = Convert.ToDouble(Console.ReadLine());
            cuenta.Retirar(monto);
            Console.WriteLine($"Saldo despues del retiro: ${cuenta.Saldo}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Solo se admiten numeros.");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}