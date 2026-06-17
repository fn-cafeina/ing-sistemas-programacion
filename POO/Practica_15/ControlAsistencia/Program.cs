/*
    Ejercicio 2: Sistema de Control de Asistencia

    Disena una aplicacion de consola en C# que permita gestionar el acceso
    diario al gimnasio mediante un menu interactivo.

    El sistema debe contar con las siguientes opciones:
    - Registrar Ingreso: Solicitar al usuario el Carnet y el Nombre del
    estudiante. El programa debe almacenar estos datos en un archivo
    llamado asistencia.txt, guardando cada registro en una nueva linea
    con el formato: Carnet - Nombre - Fecha/Hora Actual.
    - Consultar Asistencia Total: Leer el archivo asistencia.txt por completo
    y mostrar en la consola la lista de todos los estudiantes que han
    ingresado.
    - Salir: Cerrar la aplicacion.
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
        Console.WriteLine("=== CONTROL DE ASISTENCIA - GIMNASIO ===\n");
        Console.WriteLine("1. Registrar ingreso");
        Console.WriteLine("2. Consultar asistencia total");
        Console.WriteLine("3. Salir");
        return LeerOpcion(1, 3, 3);
    }

    static void RegistrarIngreso()
    {
        string? carnet = LeerString("Ingrese el carnet del estudiante: ");
        if (carnet == null)
        {
            Console.WriteLine("Operacion cancelada. Carnet invalido.");
            return;
        }

        string? nombre = LeerString("Ingrese el nombre del estudiante: ");
        if (nombre == null)
        {
            Console.WriteLine("Operacion cancelada. Nombre invalido.");
            return;
        }

        RegistroAsistencia registro = new(carnet, nombre, DateTime.Now);

        StreamWriter? writer = null;
        try
        {
            writer = File.AppendText("asistencia.txt");
            writer.WriteLine(registro.ToArchivo());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nIngreso registrado exitosamente:");
            Console.WriteLine($"  {registro}");
            Console.ResetColor();
        }
        catch (IOException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error de E/S al escribir: {ex.Message}");
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

    static void ConsultarAsistenciaTotal()
    {
        StreamReader? reader = null;
        try
        {
            if (!File.Exists("asistencia.txt"))
            {
                Console.WriteLine("No hay registros de asistencia. El archivo asistencia.txt no existe.");
                return;
            }

            reader = File.OpenText("asistencia.txt");
            string? linea;
            int contador = 0;

            Console.WriteLine("=== REGISTRO DE ASISTENCIA ===\n");
            Console.WriteLine("Carnet - Nombre - Fecha/Hora");
            Console.WriteLine(new string('-', 50));

            while ((linea = reader.ReadLine()) != null)
            {
                contador++;
                Console.WriteLine($"{contador}. {linea}");
            }

            if (contador == 0)
            {
                Console.WriteLine("No hay registros de asistencia.");
            }
            else
            {
                Console.WriteLine(new string('-', 50));
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Total de ingresos registrados: {contador}");
                Console.ResetColor();
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("No hay registros de asistencia. El archivo asistencia.txt no existe.");
        }
        catch (IOException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error de E/S al leer: {ex.Message}");
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
                    RegistrarIngreso();
                    break;
                case 2:
                    ConsultarAsistenciaTotal();
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
