/*
    Ejercicio 2: Crea un programa que pida al usuario el nombre de un fichero
    de texto y una frase a buscar, y que muestre en pantalla todas las lineas
    de ese fichero que contengan esa frase. Cada frase se debe preceder del
    numero de linea (la primera linea del fichero sera la 1, la segunda sera
    la 2, y asi sucesivamente).
*/

class Program
{
    static string? LeerString(string mensaje, int maxIntentos = 3)
    {
        for (int i = 0; i < maxIntentos; i++)
        {
            Console.Write(mensaje);
            string? valor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(valor))
                return valor;
            if (i < maxIntentos - 1)
                Console.WriteLine($"Valor invalido. Intentos restantes: {maxIntentos - i - 1}");
        }
        return null;
    }

    static void Main()
    {
        Console.Clear();
        Console.WriteLine("=== BUSCAR FRASE EN FICHERO ===\n");

        string? nombreFichero = LeerString("Ingrese el nombre del fichero (ej: frases.txt): ");
        if (nombreFichero == null)
        {
            Console.WriteLine("Operacion cancelada.");
            return;
        }

        string? fraseBuscar = LeerString("Ingrese la frase a buscar: ");
        if (fraseBuscar == null)
        {
            Console.WriteLine("Operacion cancelada.");
            return;
        }

        StreamReader? reader = null;
        try
        {
            if (!File.Exists(nombreFichero))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: El fichero '{nombreFichero}' no existe.");
                Console.ResetColor();
                return;
            }

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
                    Console.WriteLine($"Linea {numLinea}: {linea}");
                    coincidencias++;
                }
            }

            if (coincidencias == 0)
            {
                Console.WriteLine($"No se encontraron coincidencias de '{fraseBuscar}'.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nTotal de coincidencias: {coincidencias} linea(s)");
                Console.ResetColor();
            }
        }
        catch (IOException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error de E/S: {ex.Message}");
            Console.ResetColor();
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Sin permisos de lectura: {ex.Message}");
            Console.ResetColor();
        }
        finally
        {
            reader?.Close();
        }
    }
}
