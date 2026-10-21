/*
    Ejercicio Propuesto: – Sistema de Nómina Simplificado (Relación Empleado - Departamento)

    Objetivo: Aplicar lógica de composición en un contexto empresarial y validar la cascada de métodos ToString().

    Clase Departamento:
    * Atributos privados: nombreDepto (string) y codigoId (int).
    * Constructor: Usar this para inicializar.
    * Redefinir ToString(): Retornar: "Depto: [nombreDepto] (ID: [codigoId])".

    Clase Empleado:
    * Atributos privados: idEmpleado (int), nombre (string), salario (double) y un objeto Departamento.
    * Constructor: Recibir los 4 parámetros y resolver ambigüedades con this.
    * Redefinir ToString(): Retornar: "EMP #[idEmpleado]: [nombre] | Salario: $[salario] | Ubicación: [Departamento]".
    
    En el Main:
    * Crear el departamento de "Sistemas" y el de "Contabilidad".
    * Crear tres empleados, distribuyéndolos en los departamentos creados.
    * Imprimir la lista de empleados para verificar que el ToString() muestra la información del departamento de forma automática.
*/

class Departamento
{
    private string? nombreDepto { get; set; }
    private int codigoId { get; set; }

    public Departamento(string nombreDepto, int codigoId)
    {
        this.nombreDepto = nombreDepto;
        this.codigoId = codigoId;
    }

    public override string ToString()
    {
        return $"Depto: {nombreDepto} (ID: {codigoId})";
    }
}

class Empleado
{
    private int idEmpleado { get; set; }
    private string? nombre { get; set; }
    private double salario { get; set; }
    private Departamento departamento;

    public Empleado(int idEmpleado, string nombre, double salario, Departamento departamento)
    {
        this.idEmpleado = idEmpleado;
        this.nombre = nombre;
        this.salario = salario;
        this.departamento = departamento;
    }

    public override string ToString()
    {
        return $"EMP #{idEmpleado}: {nombre} | Salario: ${salario} | Ubicación: {departamento}";
    }
}

class Program
{
    static void Main()
    {
        Departamento dep1 = new Departamento("Sistemas", 1);
        Departamento dep2 = new Departamento("Contabilidad", 2);

        Empleado emp1 = new Empleado(1, "Juan", 1200, dep1);
        Empleado emp2 = new Empleado(2, "Pedro", 1500, dep2);
        Empleado emp3 = new Empleado(3, "José", 1800, dep1);

        Console.WriteLine(emp1.ToString());
        Console.WriteLine(emp2.ToString());
        Console.WriteLine(emp3.ToString());
    }
}