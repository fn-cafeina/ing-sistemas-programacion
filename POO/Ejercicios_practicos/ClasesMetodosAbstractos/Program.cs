/*
    Enunciado: Modelar un sistema de procesamiento de pagos.
    La clase ProcesadorPago debe ser abstracta para
    evitar que se creen "pagos" genéricos sin un método definido.

    * Define el método abstracto ProcesarTransaccion(double monto).
    * PagoTarjeta aplica un recargo del 2%.
    * PagoCripto confirma la transacción mediante un mensaje de hash.
*/
public abstract class ProcesadorPago
{
    // Método abstracto: no tiene cuerpo, obliga a las hijas a implementarlo
    public abstract void ProcesarTransaccion(double monto);
}

public class PagoTarjeta : ProcesadorPago
{
    public override void ProcesarTransaccion(double monto)
    {
        double total = monto * 1.02;
        Console.WriteLine($"Procesando Tarjeta. Total con comisión: ${total}");
    }
}

public class PagoCripto : ProcesadorPago
{
    public override void ProcesarTransaccion(double monto)
    {
        Console.WriteLine($"Procesando Cripto por ${monto}. Transacción verificada en Blockchain.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Pasarela de Pagos ---");

        // Aunque la clase es abstracta, podemos usarla como tipo de referencia para aprovechar el polimorfismo
        ProcesadorPago miPago;

        // Caso 1: El cliente elige Tarjeta
        miPago = new PagoTarjeta();
        miPago.ProcesarTransaccion(100.00); // Salida: Total con comisión: $102

        // Caso 2: El cliente elige Cripto
        miPago = new PagoCripto();
        miPago.ProcesarTransaccion(100.00); // Salida: Transacción verificada en Blockchain

        Console.WriteLine("\nIntento de instanciar clase abstracta:");
        // Si descomentas la siguiente línea, el compilador dará error.
        // Es un excelente punto para mostrar a los alumnos.
        // miPago = new ProcesadorPago();
    }
}