/*
    Enunciado:
    * Crea una clase Autor con propiedades Nombre y Nacionalidad. Sobrescribe su método ToString() para
    que devuelva: "Autor: [Nombre] ([Nacionalidad])".

    * Crea una clase Libro con propiedades ISBN (string), Titulo (string) y una propiedad de tipo Autor
    llamada Escritor.

    * En la clase Libro, sobrescribe el método Equals() para que dos libros sean considerados iguales si
    tienen el mismo ISBN.

    En el Main:
    * Crea un objeto Autor.
    * Crea dos objetos Libro con el mismo ISBN pero diferentes títulos (ej. Edición 1 y Edición 2).
    * Asigna el mismo autor a ambos libros.
    * Imprime los datos del libro usando ToString y verifica si son iguales con Equals.
*/

class Autor
{
    public string? Nombre { get; set; }
    public string? Nacionalidad { get; set; }

    public Autor(string nombre, string nacionalidad)
    {
        Nombre = nombre;
        Nacionalidad = nacionalidad;
    }

    public override string ToString()
    {
        return $"Autor: [{Nombre}] ([{Nacionalidad}])";
    }
}

class Libro
{
    public string? ISBN { get; set; }
    public string? Titulo { get; set; }
    public Autor Escritor { get; set; }

    public Libro(string isbn, string titulo, Autor escritor)
    {
        ISBN = isbn;
        Titulo = titulo;
        Escritor = escritor;
    }

    public override int GetHashCode() => ISBN?.GetHashCode() ?? 0;

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Libro otro = (Libro)obj;

        return ISBN == otro.ISBN;
    }
}

class Program
{
    static void Main()
    {
        Autor autor1 = new Autor("Rubén Darío", "Nicaraguense");

        Libro libro1 = new Libro("978-8491044222", "Edición 1", autor1);
        Libro libro2 = new Libro("978-8491044222", "Edición 2", autor1);

        Console.WriteLine(libro1.ToString());
        Console.WriteLine(libro2.ToString());

        Console.WriteLine("¿Son iguales?: " + libro1.Equals(libro2));
    }
}