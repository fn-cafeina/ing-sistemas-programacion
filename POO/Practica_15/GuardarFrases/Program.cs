/*
    Ejercicio 1: Crea un programa que vaya leyendo las frases que el usuario
    teclea y las guarde en un fichero de texto llamado "frases.txt". Terminara
    cuando la frase introducida sea "fin" (esa frase no debera guardarse en el
    fichero).
*/

class Program
{
    static void Main()
    {
        Console.Clear();
        Console.WriteLine("=== GUARDAR FRASES ===\n");
        Console.WriteLine("Escriba frases para guardar en 'frases.txt'.");
        Console.WriteLine("Escriba 'fin' para terminar.\n");

        StreamWriter? writer = null;
        int contador = 0;

        try
        {
            writer = File.CreateText("frases.txt");

            while (true)
            {
                Console.Write($"Frase {contador + 1}: ");
                string? frase = Console.ReadLine();

                if (frase?.Trim().ToLower() == "fin")
                    break;

                if (string.IsNullOrWhiteSpace(frase))
                {
                    Console.WriteLine("La frase no puede estar vacia.");
                    continue;
                }

                writer.WriteLine(frase);
                contador++;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{contador} frase(s) guardada(s) en frases.txt.");
            Console.ResetColor();
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
            Console.WriteLine($"Sin permisos de escritura: {ex.Message}");
            Console.ResetColor();
        }
        finally
        {
            writer?.Close();
        }
    }
}
