/*
    Opcion 2.- Motor de comparacion y validacion generica
    Desarrollar un sistema que permita comparar y validar distintos tipos de
    datos utilizando metodos genericos.
    El sistema debe incluir:
    - Metodo para comparar igualdad.
    - Metodo para determinar mayor y menor.
    - Metodo para validar condiciones.
    - Metodo con multiples tipos genericos <T, U>.
    Requisitos:
    - Aplicar restricciones genericas si es necesario.
    - Mostrar resultados en consola.
    - Realizar pruebas con diferentes tipos de datos.
    Ejemplo:
    - Comparar calificaciones.
    - Comparar precios.
    - Validar nombres o codigos.
*/

class ComparadorGenerico
{
    public static bool CompararIgualdad<T>(T a, T b)
    {
        return EqualityComparer<T>.Default.Equals(a, b);
    }

    public static (T mayor, T menor) ObtenerMayorMenor<T>(T a, T b) where T : IComparable<T>
    {
        if (a.CompareTo(b) >= 0)
            return (a, b);
        return (b, a);
    }

    public static bool ValidarCondicion<T>(T valor, Predicate<T> condicion)
    {
        return condicion(valor);
    }

    public static string CompararTipos<T, U>(T a, U b)
    {
        return $"Tipo T: {typeof(T).Name} = {a}, Tipo U: {typeof(U).Name} = {b}";
    }
}

class Program
{
    static int MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("=== MOTOR DE COMPARACION Y VALIDACION GENERICA ===\n");
        Console.WriteLine("1. Comparar calificaciones (int)");
        Console.WriteLine("2. Comparar precios (decimal)");
        Console.WriteLine("3. Validar nombres o codigos (string)");
        Console.WriteLine("4. Salir");
        Console.Write("\nOpcion: ");
        if (int.TryParse(Console.ReadLine(), out int opcion) && opcion >= 1 && opcion <= 4)
            return opcion;
        return 0;
    }

    static void CompararCalificaciones()
    {
        Console.Write("Ingrese primera calificacion: ");
        if (!int.TryParse(Console.ReadLine(), out int c1) || c1 < 0 || c1 > 100)
        {
            Console.WriteLine("Error: Ingrese una calificacion entre 0 y 100.");
            return;
        }

        Console.Write("Ingrese segunda calificacion: ");
        if (!int.TryParse(Console.ReadLine(), out int c2) || c2 < 0 || c2 > 100)
        {
            Console.WriteLine("Error: Ingrese una calificacion entre 0 y 100.");
            return;
        }

        Console.WriteLine($"\n{c1} == {c2}? {ComparadorGenerico.CompararIgualdad(c1, c2)}");
        var (mayor, menor) = ComparadorGenerico.ObtenerMayorMenor(c1, c2);
        Console.WriteLine($"Mayor: {mayor}, Menor: {menor}");
        Console.WriteLine($"{c1} es aprobatoria? {ComparadorGenerico.ValidarCondicion(c1, x => x >= 60)}");
        Console.WriteLine($"{c2} es aprobatoria? {ComparadorGenerico.ValidarCondicion(c2, x => x >= 60)}");
        Console.WriteLine(ComparadorGenerico.CompararTipos(c1, "puntos"));
    }

    static void CompararPrecios()
    {
        Console.Write("Ingrese primer precio: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal p1) || p1 < 0)
        {
            Console.WriteLine("Error: Ingrese un precio valido mayor o igual a 0.");
            return;
        }

        Console.Write("Ingrese segundo precio: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal p2) || p2 < 0)
        {
            Console.WriteLine("Error: Ingrese un precio valido mayor o igual a 0.");
            return;
        }

        Console.WriteLine($"\n{p1:C} == {p2:C}? {ComparadorGenerico.CompararIgualdad(p1, p2)}");
        var (mayor, menor) = ComparadorGenerico.ObtenerMayorMenor(p1, p2);
        Console.WriteLine($"Mayor: {mayor:C}, Menor: {menor:C}");
        Console.WriteLine($"{p1:C} supera los 200? {ComparadorGenerico.ValidarCondicion(p1, x => x > 200)}");
        Console.WriteLine($"{p2:C} supera los 200? {ComparadorGenerico.ValidarCondicion(p2, x => x > 200)}");
        Console.WriteLine(ComparadorGenerico.CompararTipos(p1, 100));
    }

    static void ValidarNombres()
    {
        Console.Write("Ingrese un nombre o codigo: ");
        string texto1 = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(texto1))
        {
            Console.WriteLine("Error: El texto no puede estar vacio.");
            return;
        }

        Console.Write("Ingrese otro nombre o codigo: ");
        string texto2 = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(texto2))
        {
            Console.WriteLine("Error: El texto no puede estar vacio.");
            return;
        }

        Console.WriteLine($"\n\"{texto1}\" == \"{texto2}\"? {ComparadorGenerico.CompararIgualdad(texto1, texto2)}");
        var (mayor, menor) = ComparadorGenerico.ObtenerMayorMenor(texto1, texto2);
        Console.WriteLine($"Mayor alfabeticamente: {mayor}, Menor: {menor}");
        Console.WriteLine($"\"{texto1}\" tiene mas de 3 caracteres? {ComparadorGenerico.ValidarCondicion(texto1, x => x.Length > 3)}");
        Console.WriteLine(ComparadorGenerico.CompararTipos(texto1, 1));
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
                case 1: CompararCalificaciones(); break;
                case 2: CompararPrecios(); break;
                case 3: ValidarNombres(); break;
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
