/*
    3. Estructuras (struct)

    Objetivo: Diferenciar entre tipos de referencia (Clases) y tipos de valor (Estructuras).

    Ejercicio: Crea una struct Punto.

    * Atributos: int X, int Y.

    * Validación: Crea un Punto p1 y asígnale valores. Luego crea Punto p2 = p1. Cambia el
    valor de p2.X e imprime ambos.

    * Punto clave para clase: Los chicos verán que p1 no cambia,
    porque en las estructuras se crea una copia, no una referencia.
*/

struct Punto
{
    public int X;
    public int Y;
}

class Program
{
    static void Main()
    {
        Punto p1;
        p1.X = 5;
        p1.Y = 10;

        Punto p2 = p1;
        p2.X = 20;

        Console.WriteLine($"p1: X={p1.X}, Y={p1.Y}");
        Console.WriteLine($"p2: X={p2.X}, Y={p2.Y}");
    }
}