class Prestamo
{
    static List<Libro> catalogo = new()
    {
        new Libro("Cien anios de soledad", 3),
        new Libro("El principito", 0),
        new Libro("Don Quijote de la Mancha", 2),
    };

    public static int TotalPrestamos { get; private set; }

    public static bool HacerPrestamo()
    {
        Console.WriteLine("Libros disponibles:");
        for (int i = 0; i < catalogo.Count; i++)
        {
            var l = catalogo[i];
            Console.Write("  ");
            if (l.CopiasDisponibles > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[{i + 1}] {l.Titulo} ({l.CopiasDisponibles} copias)");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[{i + 1}] {l.Titulo} (AGOTADO)");
            }
            Console.ResetColor();
        }
        Console.WriteLine();

        Libro? libro = null;
        while (libro == null)
        {
            Console.Write("Seleccione un libro (numero, o '0' para salir): ");
            string? entrada = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine("Debe ingresar un numero o titulo valido.");
                continue;
            }

            if (entrada == "0")
            {
                Console.WriteLine("Operacion cancelada.");
                return false;
            }

            if (int.TryParse(entrada, out int indice) && indice >= 1 && indice <= catalogo.Count)
            {
                libro = catalogo[indice - 1];
            }
            else
            {
                libro = catalogo.Find(l =>
                    l.Titulo.Equals(entrada, StringComparison.OrdinalIgnoreCase));
            }

            if (libro == null)
                Console.WriteLine("Libro no encontrado. Intente de nuevo.");
        }

        if (libro.CopiasDisponibles == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"'{libro.Titulo}' agotado. Seleccione otro libro.");
            Console.ResetColor();
            throw new InvalidOperationException(
                $"El libro '{libro.Titulo}' no tiene copias disponibles.");
        }

        Console.Clear();
        Console.WriteLine($"Libro seleccionado: {libro.Titulo} ({libro.CopiasDisponibles} copias disponibles)");
        Console.WriteLine();

        Console.Write("Dias de prestamo (ej: 7, max 15): ");
        if (!int.TryParse(Console.ReadLine(), out int diasDePrestamo))
        {
            throw new FormatException("Debe ingresar un numero entero valido. Ej: 7");
        }

        if (diasDePrestamo <= 0 || diasDePrestamo > 15)
        {
            throw new ArgumentOutOfRangeException(nameof(diasDePrestamo),
                "Los dias de prestamo deben estar entre 1 y 15.");
        }

        Console.Clear();
        Console.WriteLine("Resumen del prestamo:");
        Console.WriteLine($"  Libro: {libro.Titulo}");
        Console.WriteLine($"  Dias: {diasDePrestamo}");
        Console.WriteLine();
        Console.Write("Confirmar prestamo? (s/n): ");
        string? conf = Console.ReadLine()?.Trim().ToLower();
        if (conf != "s" && conf != "si" && conf != "y" && conf != "yes")
        {
            Console.WriteLine("Prestamo cancelado.");
            return true;
        }

        libro.CopiasDisponibles--;
        TotalPrestamos++;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Prestamo exitoso. Quedan {libro.CopiasDisponibles} copia(s) de '{libro.Titulo}'.");
        Console.ResetColor();
        return true;
    }
}
