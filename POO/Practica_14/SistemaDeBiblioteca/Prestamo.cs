class Prestamo
{
    static List<Libro> catalogo = new()
    {
        new Libro("Cien anios de soledad", 3),
        new Libro("El principito", 0),
        new Libro("Don Quijote de la Mancha", 2),
    };

    public static void HacerPrestamo()
    {
        Console.WriteLine("Libros disponibles:");
        foreach (var l in catalogo)
        {
            Console.WriteLine($"  - {l.Titulo} ({l.CopiasDisponibles} copias)");
        }
        Console.WriteLine();

        Libro? libro = null;
        while (libro == null)
        {
            Console.Write("Ingrese el titulo del libro que desea prestar: ");
            string? tituloLibro = Console.ReadLine();

            libro = catalogo.Find(l =>
                l.Titulo.Equals(tituloLibro, StringComparison.OrdinalIgnoreCase));

            if (libro == null)
            {
                Console.WriteLine("Libro no encontrado. Intente de nuevo.");
            }
        }

        if (libro.CopiasDisponibles == 0)
        {
            throw new InvalidOperationException(
                $"El libro '{libro.Titulo}' no tiene copias disponibles.");
        }

        Console.Write("Ingrese la cantidad de dias que desea prestar: ");
        if (!int.TryParse(Console.ReadLine(), out int diasDePrestamo))
        {
            throw new FormatException("Solo se admiten numeros enteros.");
        }

        if (diasDePrestamo < 0 || diasDePrestamo > 15)
        {
            throw new ArgumentOutOfRangeException(
                "No puede prestar un libro por esa cantidad de dias (min 1, max 15).");
        }

        libro.CopiasDisponibles--;
        Console.WriteLine($"Prestamo exitoso. Quedan {libro.CopiasDisponibles} copia(s) de '{libro.Titulo}'.");
    }
}
