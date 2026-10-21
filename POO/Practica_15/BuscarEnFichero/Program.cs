/*
    Ejercicio 2: Crea un programa que pida al usuario el nombre de un fichero
    de texto y una frase a buscar, y que muestre en pantalla todas las lineas
    de ese fichero que contengan esa frase. Cada frase se debe preceder del
    numero de linea (la primera linea del fichero sera la 1, la segunda sera
    la 2, y asi sucesivamente).
*/

class Program
{
    const int MAX_INTENTOS = 3;

    static string? LeerString(string mensaje)
    {
        for (int i = 0; i < MAX_INTENTOS; i++)
        {
            Console.Write(mensaje);
            string? valor = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(valor))
                return valor.Trim();

            if (i < MAX_INTENTOS - 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("El valor no puede estar vacio.");
                Console.WriteLine($"Intentos restantes: {MAX_INTENTOS - i - 1}");
                Console.ResetColor();
            }
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Demasiados intentos fallidos. Regresando...");
        Console.ResetColor();
        return null;
    }

    static bool ValidarNombreFichero(string nombre)
    {
        char[] caracteresInvalidos = Path.GetInvalidFileNameChars();
        foreach (char c in nombre)
        {
            if (caracteresInvalidos.Contains(c))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: El nombre del fichero contiene caracteres no validos ('{c}').");
                Console.ResetColor();
                return false;
            }
        }
        return true;
    }

    static void Main()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("      BUSCAR FRASE EN FICHERO");
        Console.WriteLine("========================================\n");

        string? nombreFichero = LeerString("Ingrese el nombre del fichero (ej: frases.txt): ");
        if (nombreFichero == null) return;

        if (!ValidarNombreFichero(nombreFichero))
        {
            Console.Write("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
            return;
        }

        string? fraseBuscar = LeerString("Ingrese la frase a buscar: ");
        if (fraseBuscar == null) return;

        if (!File.Exists(nombreFichero))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: El fichero '{nombreFichero}' no existe.");
            Console.WriteLine("Verifique el nombre e intente de nuevo.");
            Console.ResetColor();
            Console.Write("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
            return;
        }

        StreamReader? reader = null;
        try
        {
            reader = File.OpenText(nombreFichero);
            string? linea;
            int numLinea = 0;
            int coincidencias = 0;

            Console.WriteLine($"\nBuscando '{fraseBuscar}' en '{nombreFichero}'...\n");

            while ((linea = reader.ReadLine()) != null)
            {
                numLinea++;

                if (linea.Contains(fraseBuscar, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"  Linea {numLinea,3}: {linea}");
                    coincidencias++;
                }
            }

            Console.WriteLine($"\n{new string('-', 40)}");
            if (coincidencias == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"No se encontraron coincidencias de '{fraseBuscar}'.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"  Total de coincidencias: {coincidencias} linea(s) de {numLinea}");
                Console.ResetColor();
            }
        }
        catch (IOException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error de E/S al leer el fichero: {ex.Message}");
            Console.ResetColor();
        }
        catch (UnauthorizedAccessException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: No hay permisos para leer el fichero.");
            Console.ResetColor();
        }
        finally
        {
            reader?.Close();
        }

        Console.Write("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}
