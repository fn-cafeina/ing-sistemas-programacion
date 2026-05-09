/*
    Ejercicio 2: Clases y Métodos Abstractos (Dispositivos)

    Objetivo: Utilizar una clase abstracta como plantilla obligatoria que no puede ser instanciada
    directamente.

    Enunciado: Diseñe una clase abstracta Dispositivo con un atributo para la marca y un
    método abstracto Iniciar(). Implemente la clase hija Laptop que herede de ella y proporcione
    la lógica necesaria para el arranque del sistema. En el método main, los objetos.
*/

public abstract class Dispositivo
{
    protected string marca;

    public Dispositivo(string marca)
    {
        this.marca = marca;
    }

    public abstract void Iniciar();
}

public class Laptop : Dispositivo
{
    public Laptop(string marca) : base(marca) { }

    public override void Iniciar()
    {
        Console.WriteLine($"Iniciando laptop {marca}");
    }
}

class Program
{
    static void Main()
    {
        Laptop lenovo = new Laptop("Lenovo");
        lenovo.Iniciar();
    }
}