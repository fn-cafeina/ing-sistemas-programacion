public class Utilidades
{
    // Método que intercambia los valores de dos variables de cualquier tipo
    public static void Intercambiar<T>(ref T a, ref T b)
    {
        T temporal = a;
        a = b;
        b = temporal;
    }
}

class Program
{
    static void Main()
    {
        int x = 10, y = 20;
        Console.WriteLine($"x: {x} \ny: {y}");
        Utilidades.Intercambiar<int>(ref x, ref y); // Ahora x vale 20 e y vale 10
        Console.WriteLine($"\nx: {x} \ny: {y}");

        string nombre1 = "Ana", nombre2 = "Juan";
        Console.WriteLine($"\nnombre1: {nombre1} \nnombre2: {nombre2}");

        // Intercambia los nombres
        Utilidades.Intercambiar<string>(ref nombre1, ref nombre2);
        Console.WriteLine($"\nnombre1: {nombre1} \nnombre2: {nombre2}");
    }
}