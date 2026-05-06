public class Persona
{
    protected string nombre;

    public Persona(string nom)
    {
        this.nombre = nom;
    }

    public virtual void Imprimir()
    {
        Console.WriteLine("Nombre: " + nombre);
    }
}

public class Estudiante : Persona
{
    protected string carnet;

    public Estudiante(string nom, string car) : base(nom)
    {
        this.carnet = car;
    }

    public override void Imprimir()
    {
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Carnet: " + carnet);
    }
}

public class Becado : Estudiante
{
    protected double monto;

    public Becado(string nom, string car, double mon) : base(nom, car)
    {
        this.monto = mon;
    }

    public override void Imprimir()
    {
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Carnet: " + carnet);
        Console.WriteLine("Monto beca: " + monto);
    }
}

class Program
{
    public static void Main()
    {
        Persona p3 = new Persona("Jasmir");
        Persona p1 = new Estudiante("Ernesto", "00-28052-0");
        Persona p2 = new Becado("Jennifer", "00-14060-9", 1300);

        p1.Imprimir();
        Console.WriteLine("-----------------------------");

        p2.Imprimir();
        Console.WriteLine("-----------------------------");

        p3.Imprimir();

        Console.WriteLine("Press any key to continue . . .");
        Console.ReadKey(true);
    }
}