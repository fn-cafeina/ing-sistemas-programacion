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
    const int MAX_INTENTOS = 3;
    const int MAX_LONGITUD_TITULO = 100;

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
                Console.WriteLine($"Intentos restantes: {MAX_INTENTOS - i - 1}");
                Console.ResetColor();
            }
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Demasiados intentos fallidos. Regresando...");
        Console.ResetColor();
        return -1;
    }

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

    static bool ValidarTitulo(string titulo)
    {
        if (titulo.Length > MAX_LONGITUD_TITULO)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: El titulo no puede exceder {MAX_LONGITUD_TITULO} caracteres.");
            Console.ResetColor();
            return false;
        }

        if (titulo.Any(c => c < 32 || (c > 126 && c < 160) || c > 255))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: El titulo contiene caracteres no permitidos.");
            Console.ResetColor();
            return false;
        }

        return true;
    }

    static int MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("       MINICLUB DE LECTURA");
        Console.WriteLine("========================================\n");
        Console.WriteLine("  1. Registrar libro");
        Console.WriteLine("     -> Agrega un nuevo libro a la lista");
        Console.WriteLine("  2. Mostrar libros");
        Console.WriteLine("     -> Consulta todos los libros guardados");
        Console.WriteLine("  3. Salir");
        Console.WriteLine("     -> Cierra el programa");
        Console.WriteLine("\n========================================");
        return LeerOpcion(1, 3);
    }

    static void RegistrarLibro()
    {
        Console.Clear();
        Console.WriteLine("--- REGISTRAR LIBRO ---\n");

        string? titulo = LeerString("Ingrese el titulo del libro: ");
        if (titulo == null) return;

        if (!ValidarTitulo(titulo))
        {
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            return;
        }

        Console.Write($"\nConfirma registrar '{titulo}'? (s/n): ");
        string? conf = Console.ReadLine()?.Trim().ToLower();
        if (conf != "s" && conf != "si" && conf != "y" && conf != "yes")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Registro cancelado.");
            Console.ResetColor();
            return;
        }

        StreamWriter? writer = null;
        try
        {
            writer = File.AppendText("libros.txt");
            writer.WriteLine(titulo);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nLibro '{titulo}' registrado exitosamente en libros.txt.");
            Console.ResetColor();
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: La ruta del archivo no es valida. {ex.Message}");
            Console.ResetColor();
        }
        catch (IOException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error de E/S al escribir: {ex.Message}");
            Console.ResetColor();
        }
        catch (UnauthorizedAccessException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: No hay permisos para escribir en el archivo.");
            Console.ResetColor();
        }
        finally
        {
            writer?.Close();
        }
    }

    static void MostrarLibros()
    {
        Console.Clear();
        Console.WriteLine("--- LISTA DE LIBROS ---\n");

        if (!File.Exists("libros.txt"))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Aun no hay libros registrados. Use la opcion 1 para agregar.");
            Console.ResetColor();
            return;
        }

        StreamReader? reader = null;
        try
        {
            reader = File.OpenText("libros.txt");
            string? linea;
            int contador = 0;

            while ((linea = reader.ReadLine()) != null)
            {
                contador++;
                Console.WriteLine($"  {contador,2}. {linea}");
            }

            Console.WriteLine($"\n{new string('-', 30)}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  Total de libros: {contador}");
            Console.ResetColor();
        }
        catch (IOException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error de E/S al leer: {ex.Message}");
            Console.ResetColor();
        }
        catch (UnauthorizedAccessException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: No hay permisos para leer el archivo.");
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

            if (opcion == -1) continue;

            Console.Clear();

            switch (opcion)
            {
                case 1: RegistrarLibro(); break;
                case 2: MostrarLibros(); break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Saliendo del programa...");
                    Console.ResetColor();
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
