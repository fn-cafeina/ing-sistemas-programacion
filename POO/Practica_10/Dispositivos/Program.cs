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
        Console.WriteLine($"[INFO] Iniciando {marca}...");
        Console.WriteLine("  > Verificando hardware... OK");
        Console.WriteLine("  > Cargando sistema operativo... OK");
        Console.WriteLine("  > Configurando red... OK");
        Console.WriteLine($"[OK] {marca} está listo para usar.\n");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== SISTEMA DE ARRANQUE DE DISPOSITIVOS ===\n");

        List<Dispositivo> dispositivos = new List<Dispositivo>
        {
            new Laptop("Lenovo ThinkPad"),
            new Laptop("Dell XPS"),
            new Laptop("HP Spectre")
        };

        foreach (Dispositivo disp in dispositivos)
        {
            disp.Iniciar();
        }

        Console.WriteLine("=== TODOS LOS DISPOSITIVOS HAN INICIADO ===");
    }
}