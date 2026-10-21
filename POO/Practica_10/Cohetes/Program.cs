/*
    Ejercicio 1: Herencia y Polimorfismo (Cohetes)

    Objetivo: Implementar una jerarquía donde se utilicen métodos virtuales, redefiniciones y
    una clase terminal (sellada).

    Enunciado: Cree un sistema de lanzamientos espaciales. La clase base Cohete debe tener
    atributos protegidos para nombre y empujeNewton, y un método virtual IniciarSecuencia().
    Las clases hijas CoheteCarga, CoheteTripulado y la clase sellada CoheteReentrada deben
    añadir sus propios atributos (peso, tripulación y temperatura respectivamente) y usar
    override para mostrar dichos datos al iniciar la secuencia. Claramente de deben de crear los
    objetos dentro del método principal Main.

*/

class Cohete
{
    protected string nombre;
    protected int empujeNewton;

    public Cohete(string nombre, int empujeNewton)
    {
        this.nombre = nombre;
        this.empujeNewton = empujeNewton;
    }

    public virtual void IniciarSecuencia()
    {
        Console.WriteLine($"Nombre: {nombre}");
        Console.WriteLine($"Empuje: {empujeNewton} N");
    }
}

class CoheteCarga : Cohete
{
    protected double peso;

    public CoheteCarga(string nombre, int empujeNewton, double peso) : base(nombre, empujeNewton)
    {
        this.peso = peso;
    }

    public override void IniciarSecuencia()
    {
        Console.WriteLine($"Nombre: {nombre}");
        Console.WriteLine($"Empuje: {empujeNewton} N");
        Console.WriteLine($"Peso de carga: {peso} kg");
    }
}

class CoheteTripulado : Cohete
{
    protected int tripulacion;

    public CoheteTripulado(string nombre, int empujeNewton, int tripulacion) : base(nombre, empujeNewton)
    {
        this.tripulacion = tripulacion;
    }

    public override void IniciarSecuencia()
    {
        Console.WriteLine($"Nombre: {nombre}");
        Console.WriteLine($"Empuje: {empujeNewton} N");
        Console.WriteLine($"Tripulación: {tripulacion} astronautas");
    }
}

sealed class CoheteReentrada : Cohete
{
    private readonly double temperatura;

    public CoheteReentrada(string nombre, int empujeNewton, double temperatura) : base(nombre, empujeNewton)
    {
        this.temperatura = temperatura;
    }

    public override void IniciarSecuencia()
    {
        Console.WriteLine($"Nombre: {nombre}");
        Console.WriteLine($"Empuje: {empujeNewton} N");
        Console.WriteLine($"Temperatura: {temperatura} °C");
    }
}

class Program
{
    static void Main()
    {
        Cohete coheteBase = new Cohete("Saturno V", 35100000);
        CoheteCarga coheteCarga = new CoheteCarga("Falcon Heavy", 22800000, 63800);
        CoheteTripulado coheteTripulado = new CoheteTripulado("Apollo 11", 35000000, 3);
        CoheteReentrada coheteReentrada = new CoheteReentrada("Dragon", 12000000, 1600);

        Console.WriteLine("===== PRUEBA COHETE BASE =====");
        coheteBase.IniciarSecuencia();

        Console.WriteLine();

        Console.WriteLine("===== PRUEBA COHETE CARGA =====");
        coheteCarga.IniciarSecuencia();

        Console.WriteLine();

        Console.WriteLine("===== PRUEBA COHETE TRIPULADO =====");
        coheteTripulado.IniciarSecuencia();

        Console.WriteLine();

        Console.WriteLine("===== PRUEBA COHETE REENTRADA =====");
        coheteReentrada.IniciarSecuencia();
    }
}