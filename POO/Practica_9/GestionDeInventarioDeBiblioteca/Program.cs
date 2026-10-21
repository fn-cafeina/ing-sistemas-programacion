/*
    Ejercicio Propuesto:
    Gestión de Inventario de Biblioteca

    Enunciado:
    La biblioteca de la UNAN-León desea automatizar el control de su inventario.

    Estructura:
    1. Clase Base CRecurso
    2. Clase Derivada CLibro
    3. Clase Derivada CRevista

    Requerimientos:
    * Implementar constructores utilizando base
    * Redefinir el método MostrarInformacion()
    * Usar un arreglo de objetos tipo CRecurso
    * Demostrar polimorfismo
*/

public class CRecurso
{
    public string Titulo { get; set; }
    public string Codigo { get; set; }

    public CRecurso(string titulo, string codigo)
    {
        Titulo = titulo;
        Codigo = codigo;
    }

    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Título: {Titulo}");
        Console.WriteLine($"Código: {Codigo}");
    }
}

public class CLibro : CRecurso
{
    public int NumeroPaginas { get; set; }
    public string Autor { get; set; }

    public CLibro(string titulo, string codigo, int numeroPaginas, string autor)
        : base(titulo, codigo)
    {
        NumeroPaginas = numeroPaginas;
        Autor = autor;
    }

    public override void MostrarInformacion()
    {
        Console.WriteLine("----- LIBRO -----");
        Console.WriteLine($"Título: {Titulo}");
        Console.WriteLine($"Código: {Codigo}");
        Console.WriteLine($"Autor: {Autor}");
        Console.WriteLine($"Número de páginas: {NumeroPaginas}");
    }
}

public class CRevista : CRecurso
{
    public int NumeroEdicion { get; set; }
    public string FrecuenciaPublicacion { get; set; }

    public CRevista(string titulo, string codigo, int numeroEdicion, string frecuenciaPublicacion)
        : base(titulo, codigo)
    {
        NumeroEdicion = numeroEdicion;
        FrecuenciaPublicacion = frecuenciaPublicacion;
    }

    public override void MostrarInformacion()
    {
        Console.WriteLine("----- REVISTA -----");
        Console.WriteLine($"Título: {Titulo}");
        Console.WriteLine($"Código: {Codigo}");
        Console.WriteLine($"Número de edición: {NumeroEdicion}");
        Console.WriteLine($"Frecuencia de publicación: {FrecuenciaPublicacion}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Inventario Biblioteca UNAN-León ---");

        CRecurso[] recursos = new CRecurso[]
        {
            new CLibro("C# Fundamentals", "L001", 450, "Juan Pérez"),
            new CLibro("Programación Orientada a Objetos", "L002", 320, "Ana López"),

            new CRevista("National Geographic", "R001", 120, "Mensual"),
            new CRevista("Science Today", "R002", 45, "Trimestral")
        };

        foreach (CRecurso recurso in recursos)
        {
            recurso.MostrarInformacion();
            Console.WriteLine("---------------------------");
        }
    }
}
