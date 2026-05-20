class Contenedor<T>
{
    private T elemento = default!;

    public void Agregar(T valor)
    {
        elemento = valor;
    }

    public T Obtener()
    {
        return elemento;
    }
}

class Program
{
    static void Main()
    {
        // Ejemplo con números enteros (int)
        Contenedor<int> cajaEnteros = new Contenedor<int>();
        cajaEnteros.Agregar(5);
        int numero = cajaEnteros.Obtener();
        Console.WriteLine(numero);

        // Ejemplo con cadenas de texto (string)
        Contenedor<string> cajaTexto = new Contenedor<string>();
        cajaTexto.Agregar("Hola Mundo");
        string texto = cajaTexto.Obtener();
        Console.WriteLine(texto);
    }
}