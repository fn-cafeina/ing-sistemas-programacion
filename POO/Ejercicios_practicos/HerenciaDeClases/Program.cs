/*
    Ejercicios Resuelto 1: Herencia de Clases (Clases Derivadas)

    Enunciado: Una empresa de tecnología necesita gestionar su nómina.
    Todos los empleados tienen un nombre y un salario base.
    Existen Desarrolladores que reciben un bono por lenguaje,
    y Gerentes que reciben un bono por manejo de equipo.

    * Usa una clase base llamada Empleado
    * Usa virtual y override para permitir que el método de calculo del
    salario se comporte de forma distinta en las clases hijas

    Modificación: Agregar una clase derivada de la clase base llamada Empleado que registre
    los datos de los empleados del departamento de ventas quienes
    reciben un bono adicional del 10% de su salario base. (Redefinir el salario).
*/

public class Empleado
{
    public string Nombre { get; set; }
    public double SalarioBase { get; set; }

    public Empleado(string nombre, double salarioBase)
    {
        Nombre = nombre;
        SalarioBase = salarioBase;
    }

    public virtual double CalcularTotal()
    {
        return SalarioBase;
    }
}

public class Desarrollador : Empleado
{
    public double BonoLenguaje { get; set; }

    public Desarrollador(string nombre, double salarioBase, double bono) : base(nombre, salarioBase)
    {
        BonoLenguaje = bono;
    }

    public override double CalcularTotal()
    {
        return SalarioBase + BonoLenguaje;
    }
}

public class Gerente : Empleado
{
    public double BonoEquipo { get; set; }

    public Gerente(string nombre, double salarioBase, double bono) : base(nombre, salarioBase)
    {
        BonoEquipo = bono;
    }

    public override double CalcularTotal()
    {
        return SalarioBase + BonoEquipo;
    }
}

public class Ventas : Empleado
{
    public Ventas(string nombre, double salarioBase) : base(nombre, salarioBase)
    {
    }

    public override double CalcularTotal()
    {
        return SalarioBase + (SalarioBase * 0.10);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Sistema de Nómina ---");

        // Creamos instancias de las clases derivadas
        Desarrollador dev = new Desarrollador("Ana López", 2000, 300);
        Gerente jefe = new Gerente("Roberto Carlos", 3500, 1000);

        // Mostramos los resultados
        Console.WriteLine($"Empleado: {dev.Nombre}");
        Console.WriteLine($"Sueldo total del Desarrollador: ${dev.CalcularTotal()}");

        Console.WriteLine("---------------------------");
        Console.WriteLine($"Empleado: {jefe.Nombre}");
        Console.WriteLine($"Sueldo total del Gerente:  ${jefe.CalcularTotal()}");

        Console.WriteLine("\n\nResultado de la modificación:\n");
        Ventas vendedor = new Ventas("Carlos Pérez", 1800);
        Console.WriteLine("---------------------------");
        Console.WriteLine($"Empleado: {vendedor.Nombre}");
        Console.WriteLine($"Sueldo total de Ventas: ${vendedor.CalcularTotal()}");
    }
}