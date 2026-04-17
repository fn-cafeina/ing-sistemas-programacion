/*
    Ejercicio 2: Referencias como Miembros de Clase (Composición)

    Contexto: Sistema de Asignación de Libros y Editoriales

    Objetivo: Modelar la relación "Un Libro pertenece a una Editorial". El estudiante debe
    comprender cómo una clase puede tener como atributo una referencia (objeto) de otra clase
    y cómo acceder a sus miembros.

    Enunciado:
    Se requiere un programa que vincule libros con sus respectivas casas
    editoriales.

    Clase Editorial:
    * Atributos: nombreEditorial (string) y pais (string).
    * Constructor: Inicializar ambos atributos usando this.
    * Método ObtenerInfoEditorial(): Debe retornar un string con el nombre de la
    editorial y su país de origen.

    Clase Libro:
    * Atributos: titulo (string), autor (string) y un objeto de tipo Editorial llamado
    casaEditorial.
    * Constructor: Debe recibir el título, el autor y un objeto ya instanciado de tipo
    Editorial.
    * Método MostrarDetallesCompletos(): Debe imprimir los datos del libro y, para los
    datos de la editorial, debe invocar al método ObtenerInfoEditorial() del objeto
    miembro (casaEditorial).

    Clase Principal (Program):
    * Primero, crear un objeto de la clase Editorial (ejemplo: "Editorial RAMA", "España").
    * Segundo, crear un objeto de la clase Libro pasando como argumento el objeto de la
    editorial creado anteriormente.
    * Tercero, llamar al método MostrarDetallesCompletos() desde el objeto Libro.
*/

class Editorial
{
    private string nombreEditorial;
    private string pais;

    public Editorial(string nombreEditorial, string pais)
    {
        this.nombreEditorial = nombreEditorial;
        this.pais = pais;
    }

    public string ObtenerInfoEditorial()
    {
        return $"{this.nombreEditorial} ({this.pais})";
    }
}

class Libro
{
    private string titulo;
    private string autor;
    private Editorial casaEditorial;

    public Libro(string titulo, string autor, Editorial casaEditorial)
    {
        this.titulo = titulo;
        this.autor = autor;
        this.casaEditorial = casaEditorial;
    }

    public void MostrarDetallesCompletos()
    {
        Console.WriteLine($"Libro: {this.titulo}");
        Console.WriteLine($"Autor: {this.autor}");

        Console.WriteLine($"Editorial: {this.casaEditorial.ObtenerInfoEditorial()}");
    }
}

class Program
{
    static void Main()
    {
        Editorial miEditorial = new Editorial("Editorial RAMA", "España");

        Libro miLibro = new Libro("Fundamentos de Programación", "Luis Joyanes", miEditorial);

        Console.WriteLine("=== DETALLES DEL LIBRO ===");
        miLibro.MostrarDetallesCompletos();
    }
}