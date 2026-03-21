/*
    2. Crea un programa que muestre un menú con tres opciones:

    * Mostrar la fecha actual
    * Mostrar la hora actual
    * Salir

    El programa debe ejecutarse al menos una vez y repetirse hasta que
    el usuario elija la opción 3. Usar la sentencia do-while.
*/

Console.Clear();

string opcion = "";

do
{
    Console.WriteLine("\n--- MENÚ ---");
    Console.WriteLine("1. Mostrar la fecha actual");
    Console.WriteLine("2. Mostrar la hora actual");
    Console.WriteLine("3. Salir");
    Console.Write("Elija una opción: ");

    opcion = Console.ReadLine() ?? "";

    Console.WriteLine();

    switch (opcion)
    {
        case "1":
            Console.WriteLine($"Fecha actual: {DateTime.Now.ToShortDateString()}");
            break;
        case "2":
            Console.WriteLine($"Hora actual: {DateTime.Now.ToShortTimeString()}");
            break;
        case "3":
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("Error: Opción no válida. Intente de nuevo.");
            break;
    }

} while (opcion != "3");