/*
    Trabajo Independiente

    Ejercicio 2: Sistema de Control de Asistencia

    Disena una aplicacion de consola en C# que permita gestionar el acceso
    diario al gimnasio mediante un menu interactivo. El sistema debe contar
    con las siguientes opciones:
    . Registrar Ingreso: Solicitar al usuario el Carnet y el Nombre del
      estudiante. El programa debe almacenar estos datos en un archivo
      llamado asistencia.txt, guardando cada registro en una nueva linea
      con el formato: Carnet - Nombre - Fecha/Hora Actual.
    . Consultar Asistencia Total: Leer el archivo asistencia.txt por completo
      y mostrar en la consola la lista de todos los estudiantes que han
      ingresado.
    . Salir: Cerrar la aplicacion.
*/

class Program
{
    const int MAX_INTENTOS = 3;
    const int MAX_LONGITUD_NOMBRE = 50;
    const int MAX_LONGITUD_CARNET = 15;

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

    static bool ValidarNombre(string nombre)
    {
        if (nombre.Length > MAX_LONGITUD_NOMBRE)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: El nombre no puede exceder {MAX_LONGITUD_NOMBRE} caracteres.");
            Console.ResetColor();
            return false;
        }
        if (!nombre.All(c => char.IsLetter(c) || c == ' ' || c == '.' || c == '\''))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: El nombre solo puede contener letras, espacios, puntos y apostrofos.");
            Console.ResetColor();
            return false;
        }
        return true;
    }

    static bool ValidarCarnet(string carnet)
    {
        if (carnet.Length > MAX_LONGITUD_CARNET)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: El carnet no puede exceder {MAX_LONGITUD_CARNET} caracteres.");
            Console.ResetColor();
            return false;
        }
        if (!carnet.All(c => char.IsLetterOrDigit(c)))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: El carnet solo puede contener letras y numeros.");
            Console.ResetColor();
            return false;
        }
        return true;
    }

    static int MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("============================================");
        Console.WriteLine("     CONTROL DE ASISTENCIA - GIMNASIO");
        Console.WriteLine("============================================\n");
        Console.WriteLine("  1. Registrar ingreso");
        Console.WriteLine("     -> Registra un estudiante con fecha/hora actual");
        Console.WriteLine("  2. Consultar asistencia total");
        Console.WriteLine("     -> Muestra todos los ingresos registrados");
        Console.WriteLine("  3. Salir");
        Console.WriteLine("     -> Cierra el programa");
        Console.WriteLine("\n============================================");
        return LeerOpcion(1, 3);
    }

    static void RegistrarIngreso()
    {
        Console.Clear();
        Console.WriteLine("--- REGISTRAR INGRESO ---\n");

        string? carnet = LeerString("Ingrese el carnet del estudiante (ej: U20240001): ");
        if (carnet == null) return;

        if (!ValidarCarnet(carnet))
        {
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            return;
        }

        string? nombre = LeerString("Ingrese el nombre del estudiante (ej: Ana Lopez): ");
        if (nombre == null) return;

        if (!ValidarNombre(nombre))
        {
            Console.Write("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            return;
        }

        RegistroAsistencia registro = new(carnet, nombre, DateTime.Now);

        Console.WriteLine($"\nResumen del ingreso:");
        Console.WriteLine($"  Carnet: {registro.Carnet}");
        Console.WriteLine($"  Nombre: {registro.Nombre}");
        Console.WriteLine($"  Fecha/Hora: {registro.FechaHora:dd/MM/yyyy HH:mm:ss}");
        Console.Write("\nConfirmar ingreso? (s/n): ");
        string? conf = Console.ReadLine()?.Trim().ToLower();
        if (conf != "s" && conf != "si" && conf != "y" && conf != "yes")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ingreso cancelado.");
            Console.ResetColor();
            return;
        }

        StreamWriter? writer = null;
        try
        {
            writer = File.AppendText("asistencia.txt");
            writer.WriteLine(registro.ToArchivo());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nIngreso registrado exitosamente en asistencia.txt.");
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

    static void ConsultarAsistenciaTotal()
    {
        Console.Clear();
        Console.WriteLine("--- REGISTRO DE ASISTENCIA ---\n");

        if (!File.Exists("asistencia.txt"))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Aun no hay ingresos registrados. Use la opcion 1 para registrar.");
            Console.ResetColor();
            return;
        }

        StreamReader? reader = null;
        try
        {
            reader = File.OpenText("asistencia.txt");
            string? linea;
            int contador = 0;

            Console.WriteLine(" #  Carnet  -  Nombre  -  Fecha/Hora");
            Console.WriteLine(new string('-', 55));

            while ((linea = reader.ReadLine()) != null)
            {
                contador++;
                Console.WriteLine($"{contador,2}. {linea}");
            }

            Console.WriteLine(new string('-', 55));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  Total de ingresos registrados: {contador}");
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
                case 1: RegistrarIngreso(); break;
                case 2: ConsultarAsistenciaTotal(); break;
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
