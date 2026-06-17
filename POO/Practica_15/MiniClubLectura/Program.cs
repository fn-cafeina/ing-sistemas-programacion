/*
    Ejercicio 1: El miniclub de lectura

    Disenar un programa de consola que muestre un menu simple con dos opciones:
    Registrar Libro: El usuario digita el titulo de un libro y el programa lo
    agrega al final de un archivo llamado libros.txt.
    Mostrar Libros: El programa lee el archivo libros.txt y muestra en pantalla
    la lista de todos los libros guardados hasta el momento.
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

    static int MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("=== MINICLUB DE LECTURA ===\n");
        Console.WriteLine("1. Registrar libro");
        Console.WriteLine("2. Mostrar libros");
        Console.WriteLine("3. Salir");
        return LeerOpcion(1, 3, 3);
    }

    static void RegistrarLibro()
    {
        string? titulo = LeerString("Ingrese el titulo del libro: ");
        if (titulo == null)
        {
            Console.WriteLine("Operacion cancelada. No se pudo leer el titulo.");
            return;
        }

        StreamWriter? writer = null;
        try
        {
            writer = File.AppendText("libros.txt");
            writer.WriteLine(titulo);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Libro '{titulo}' registrado exitosamente.");
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
            Console.WriteLine($"Sin permisos para escribir: {ex.Message}");
            Console.ResetColor();
        }
        finally
        {
            writer?.Close();
        }
    }

    static void MostrarLibros()
    {
        StreamReader? reader = null;
        try
        {
            if (!File.Exists("libros.txt"))
            {
                Console.WriteLine("No hay libros registrados. El archivo libros.txt no existe.");
                return;
            }

            reader = File.OpenText("libros.txt");
            string? linea;
            int contador = 0;

            Console.WriteLine("=== LISTA DE LIBROS ===\n");
            while ((linea = reader.ReadLine()) != null)
            {
                contador++;
                Console.WriteLine($"{contador}. {linea}");
            }

            if (contador == 0)
                Console.WriteLine("No hay libros registrados.");
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nTotal de libros: {contador}");
                Console.ResetColor();
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("No hay libros registrados. El archivo libros.txt no existe.");
        }
        catch (IOException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error de E/S: {ex.Message}");
            Console.ResetColor();
        }
        finally
        {
            reader?.Close();
        }
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
                case 1:
                    RegistrarLibro();
                    break;
                case 2:
                    MostrarLibros();
                    break;
                case 3:
                    Console.WriteLine("Saliendo del programa...");
                    break;
            }

            if (opcion != 3)
            {
                Console.Write("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        } while (opcion != 3);
    }
}
