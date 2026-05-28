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
    static int MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("=== PROCESADOR DE TRANSACCIONES FINANCIERAS ===\n");
        Console.WriteLine("Seleccione el tipo de moneda:");
        Console.WriteLine("1. Dolares (int)");
        Console.WriteLine("2. Moneda exacta (decimal)");
        Console.WriteLine("3. Criptomonedas (double)");
        Console.WriteLine("4. Salir");
        Console.Write("\nOpcion: ");
        if (int.TryParse(Console.ReadLine(), out int opcion) && opcion >= 1 && opcion <= 4)
            return opcion;
        return 0;
    }

    static void ProcesarInt()
    {
        Console.Write("Ingrese el monto en dolares: ");
        if (!int.TryParse(Console.ReadLine(), out int monto) || monto < 0)
        {
            Console.WriteLine("Error: Ingrese un monto valido mayor o igual a 0.");
            return;
        }

        Console.Write("Ingrese la tasa de impuesto (porcentaje): ");
        if (!double.TryParse(Console.ReadLine(), out double tasa) || tasa < 0 || tasa > 100)
        {
            Console.WriteLine("Error: Ingrese una tasa entre 0 y 100.");
            return;
        }

        int impuesto = ProcesadorFinanciero.CalcularImpuesto(monto, tasa);
        int total = monto + impuesto;

        Console.WriteLine($"\nMonto original: ${monto}");
        Console.WriteLine($"Tasa de impuesto: {tasa}%");
        Console.WriteLine($"Impuesto: ${impuesto}");
        Console.WriteLine($"Total a pagar: ${total}");
    }

    static void ProcesarDecimal()
    {
        Console.Write("Ingrese el monto en moneda exacta: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal monto) || monto < 0)
        {
            Console.WriteLine("Error: Ingrese un monto valido mayor o igual a 0.");
            return;
        }

        Console.Write("Ingrese la tasa de impuesto (porcentaje): ");
        if (!double.TryParse(Console.ReadLine(), out double tasa) || tasa < 0 || tasa > 100)
        {
            Console.WriteLine("Error: Ingrese una tasa entre 0 y 100.");
            return;
        }

        decimal impuesto = ProcesadorFinanciero.CalcularImpuesto(monto, tasa);
        decimal total = monto + impuesto;

        Console.WriteLine($"\nMonto original: ${monto:F2}");
        Console.WriteLine($"Tasa de impuesto: {tasa}%");
        Console.WriteLine($"Impuesto: ${impuesto:F2}");
        Console.WriteLine($"Total a pagar: ${total:F2}");
    }

    static void ProcesarDouble()
    {
        Console.Write("Ingrese el monto en criptomonedas: ");
        if (!double.TryParse(Console.ReadLine(), out double monto) || monto < 0)
        {
            Console.WriteLine("Error: Ingrese un monto valido mayor o igual a 0.");
            return;
        }

        Console.Write("Ingrese la tasa de impuesto (porcentaje): ");
        if (!double.TryParse(Console.ReadLine(), out double tasa) || tasa < 0 || tasa > 100)
        {
            Console.WriteLine("Error: Ingrese una tasa entre 0 y 100.");
            return;
        }

        double impuesto = ProcesadorFinanciero.CalcularImpuesto(monto, tasa);
        double total = monto + impuesto;

        Console.WriteLine($"\nMonto original: ${monto:F4}");
        Console.WriteLine($"Tasa de impuesto: {tasa}%");
        Console.WriteLine($"Impuesto: ${impuesto:F4}");
        Console.WriteLine($"Total a pagar: ${total:F4}");
    }

    static void Main()
    {
        int opcion;
        do
        {
            opcion = MostrarMenu();

            if (opcion == 0)
            {
                Console.WriteLine("Opcion no valida.");
                Console.Write("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                continue;
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
