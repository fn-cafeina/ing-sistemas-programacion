/*
    Practica de Ficheros

    Ejercicio 1: Crea un programa que vaya leyendo las frases que el usuario
    teclea y las guarde en un fichero de texto llamado "frases.txt". Terminara
    cuando la frase introducida sea "fin" (esa frase no debera guardarse en el
    fichero).
*/

class Program
{
    const int MAX_INTENTOS = 3;
    const int MAX_LONGITUD_FRASE = 200;

    static int LeerOpcion(int min, int max)
    {
        for (int i = 0; i < MAX_INTENTOS; i++)
        {
            Console.Write("\n>>> Opcion: ");
            string? entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int opcion) && opcion >= min && opcion <= max)
                return opcion;

            if (i < MAX_INTENTOS - 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Opcion invalida. Ingrese un numero entre {min} y {max}.");
                Console.ResetColor();
            }
        }
        return -1;
    }

    static string? LeerFrase()
    {
        Console.Write($"Frase: ");
        string? frase = Console.ReadLine();

        if (frase?.Trim().ToLower() == "fin")
            return null; // senial para terminar

        if (string.IsNullOrWhiteSpace(frase))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("La frase no puede estar vacia.");
            Console.ResetColor();
            return ""; // reintentar
        }

        if (frase.Length > MAX_LONGITUD_FRASE)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: La frase no puede exceder {MAX_LONGITUD_FRASE} caracteres.");
            Console.ResetColor();
            return ""; // reintentar
        }

        return frase.Trim();
    }

    static void Main()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("          GUARDAR FRASES");
        Console.WriteLine("========================================\n");
        Console.WriteLine("Escriba frases para guardar en 'frases.txt'.");
        Console.WriteLine($"Maximo {MAX_LONGITUD_FRASE} caracteres por frase.");
        Console.WriteLine("Escriba 'fin' para terminar y salir.\n");

        Console.Write("Desea sobrescribir el archivo existente o agregar al final?");
        Console.Write("\n  1. Sobrescribir (empezar de cero)");
        Console.Write("\n  2. Agregar al final (anadir a frases existentes)");
        Console.Write("\n\n>>> Opcion: ");

        bool sobrescribir = Console.ReadLine()?.Trim() == "1";

        StreamWriter? writer = null;
        int contador = 0;

        try
        {
            if (sobrescribir)
                writer = File.CreateText("frases.txt");
            else
                writer = File.AppendText("frases.txt");

            Console.WriteLine($"\n(Modo: {(sobrescribir ? "sobrescribir" : "agregar")})");
            Console.WriteLine("(Escriba 'fin' para salir)\n");

            while (true)
            {
                string? resultado = LeerFrase();

                if (resultado == null)
                {
                    // usuario escribio "fin"
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\nFinalizando. Se guardaron {contador} frase(s) en frases.txt.");
                    Console.ResetColor();
                    break;
                }

                if (resultado == "")
                    continue; // vacio o invalido, reintentar

                writer.WriteLine(resultado);
                contador++;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Frase {contador} guardada.");
                Console.ResetColor();
            }
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: Ruta no valida. {ex.Message}");
            Console.ResetColor();
        }
        catch (IOException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error de E/S: {ex.Message}");
            Console.ResetColor();
        }
        catch (UnauthorizedAccessException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Sin permisos de escritura.");
            Console.ResetColor();
        }
        finally
        {
            writer?.Close();
        }

        Console.Write("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}
