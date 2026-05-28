/*
    Ejercicio 2: Procesador de Transacciones Financieras (Manipulacion de Tipos Primitivos Numericos)

    Conceptos POO: Interfaces, Polimorfismo, Metodos Genericos independientes.

    Tipo de Dato Manipulado: Estructuras numericas nativas (decimal, double, int).

    Contexto:
    Una pasarela de pagos internacional procesa transacciones que manejan montos
    en diferentes formatos numericos dependiendo del origen de la API (algunas
    criptomonedas usan double por su precision cientifica, mientras que el sistema
    bancario tradicional exige decimal para evitar errores de redondeo).

    Enunciado:
    1. Disena una clase estatica llamada ProcesadorFinanciero.
    2. Implementa un metodo generico llamado CalcularImpuesto(T monto, double tasa)
    donde T sea el tipo numerico del dinero.
    3. Debido a que C# requiere un manejo especial para operar
    matematicamente con genericos, los estudiantes deberan investigar como
    usar el polimorfismo o la conversion dinamica (dynamic) para
    multiplicar monto por la tasa.
    4. El metodo debe recibir el monto del tipo T, aplicar el porcentaje de
    impuesto y retornar el mismo tipo T de origen.
*/

class Program
{
    static int LeerOpcion(int min, int max, int maxIntentos)
    {
        for (int i = 0; i < maxIntentos; i++)
        {
            Console.Write("\nOpcion: ");
            if (int.TryParse(Console.ReadLine(), out int opcion) && opcion >= min && opcion <= max)
                return opcion;
            if (i < maxIntentos - 1)
                Console.WriteLine($"Valor invalido. Intentos restantes: {maxIntentos - i - 1}");
        }
        return -1;
    }

    static int? LeerInt(string mensaje, int min, int max, int maxIntentos = 3)
    {
        for (int i = 0; i < maxIntentos; i++)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out int valor) && valor >= min && valor <= max)
                return valor;
            if (i < maxIntentos - 1)
                Console.WriteLine($"Valor invalido. Intentos restantes: {maxIntentos - i - 1}");
        }
        return null;
    }

    static decimal? LeerDecimal(string mensaje, decimal min, int maxIntentos = 3)
    {
        for (int i = 0; i < maxIntentos; i++)
        {
            Console.Write(mensaje);
            if (decimal.TryParse(Console.ReadLine(), out decimal valor) && valor >= min)
                return valor;
            if (i < maxIntentos - 1)
                Console.WriteLine($"Valor invalido. Intentos restantes: {maxIntentos - i - 1}");
        }
        return null;
    }

    static double? LeerDouble(string mensaje, double min, double max, int maxIntentos = 3)
    {
        for (int i = 0; i < maxIntentos; i++)
        {
            Console.Write(mensaje);
            if (double.TryParse(Console.ReadLine(), out double valor) && valor >= min && valor <= max)
                return valor;
            if (i < maxIntentos - 1)
                Console.WriteLine($"Valor invalido. Intentos restantes: {maxIntentos - i - 1}");
        }
        return null;
    }

    static int MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("=== PROCESADOR DE TRANSACCIONES FINANCIERAS ===\n");
        Console.WriteLine("Seleccione el tipo de moneda:");
        Console.WriteLine("1. Dolares (int)    — montos exactos sin decimales");
        Console.WriteLine("2. Moneda exacta (decimal) — ej: 1500.50");
        Console.WriteLine("3. Criptomonedas (double)  — ej: 0.045");
        Console.WriteLine("4. Salir");
        return LeerOpcion(1, 4, 3);
    }

    static void ProcesarInt()
    {
        int? monto = LeerInt("Ingrese el monto en dolares (max 2,000,000): ", 0, 2_000_000);
        if (monto == null) return;

        double? tasa = LeerDouble("Ingrese la tasa de impuesto (0-100, ej: 15): ", 0, 100);
        if (tasa == null) return;

        int impuesto = ProcesadorFinanciero.CalcularImpuesto(monto.Value, tasa.Value);
        int total;

        try
        {
            checked { total = monto.Value + impuesto; }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: El total excede el limite maximo de int.");
            return;
        }

        Console.WriteLine($"\nMonto original: ${monto.Value}");
        Console.WriteLine($"Tasa de impuesto: {tasa.Value}%");
        Console.WriteLine($"Impuesto: ${impuesto}  (Math.Round aplica redondeo bancario)");
        Console.WriteLine($"Total a pagar: ${total}");
    }

    static void ProcesarDecimal()
    {
        decimal? monto = LeerDecimal("Ingrese el monto en moneda exacta (ej: 1500.50): ", 0);
        if (monto == null) return;

        if (monto.Value != Math.Round(monto.Value, 2))
        {
            Console.WriteLine("Error: La moneda permite hasta 2 decimales (ej: 1500.50).");
            return;
        }

        double? tasa = LeerDouble("Ingrese la tasa de impuesto (0-100, ej: 10): ", 0, 100);
        if (tasa == null) return;

        decimal impuesto = ProcesadorFinanciero.CalcularImpuesto(monto.Value, tasa.Value);
        decimal total = monto.Value + impuesto;

        Console.WriteLine($"\nMonto original: ${monto.Value:F2}");
        Console.WriteLine($"Tasa de impuesto: {tasa.Value}%");
        Console.WriteLine($"Impuesto: ${impuesto:F2}");
        Console.WriteLine($"Total a pagar: ${total:F2}");
    }

    static void ProcesarDouble()
    {
        double? monto = LeerDouble("Ingrese el monto en criptomonedas (ej: 0.045): ", 0, double.MaxValue);
        if (monto == null) return;

        double? tasa = LeerDouble("Ingrese la tasa de impuesto (0-100, ej: 5): ", 0, 100);
        if (tasa == null) return;

        double impuesto = ProcesadorFinanciero.CalcularImpuesto(monto.Value, tasa.Value);

        if (double.IsInfinity(impuesto))
        {
            Console.WriteLine("Error: El impuesto calculado excede el rango permitido.");
            return;
        }

        double total = monto.Value + impuesto;

        if (double.IsInfinity(total))
        {
            Console.WriteLine("Error: El total excede el rango permitido.");
            return;
        }

        Console.WriteLine($"\nMonto original: ${monto.Value:F4}");
        Console.WriteLine($"Tasa de impuesto: {tasa.Value}%");
        Console.WriteLine($"Impuesto: ${impuesto:F4}");
        Console.WriteLine($"Total a pagar: ${total:F4}");
    }

    static void Main()
    {
        int opcion;
        do
        {
            opcion = MostrarMenu();

            if (opcion == -1)
            {
                Console.WriteLine("Demasiados intentos fallidos. Saliendo...");
                break;
            }

            Console.Clear();

            switch (opcion)
            {
                case 1: ProcesarInt(); break;
                case 2: ProcesarDecimal(); break;
                case 3: ProcesarDouble(); break;
                case 4: Console.WriteLine("Saliendo del programa..."); break;
            }

            if (opcion != 4)
            {
                Console.Write("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        } while (opcion != 4);
    }
}
