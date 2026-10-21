/*
    3. Registro de Estudiantes (Control Escolar)

    Crear una clase Estudiante para una universidad.

    Atributos: Matrícula, Nombre, Carrera, Semestre y Promedio.

    Constructores: Uno inicial para alumnos de primer ingreso (semestre 1), uno para traslados
    (semestre avanzado) y uno completo.
*/

class Estudiante
{
    private string? matricula;
    private string? nombre;
    private string? carrera;
    private int semestre;
    private double promedio;

    public string? Matricula { get { return matricula; } set { matricula = value; } }
    public string? Nombre { get { return nombre; } set { nombre = value; } }
    public string? Carrera { get { return carrera; } set { carrera = value; } }
    public int Semestre { get { return semestre; } set { semestre = value; } }
    public double Promedio { get { return promedio; } set { promedio = value; } }

    public Estudiante(string matricula, string nombre, string carrera, int semestre, double promedio)
    {
        this.matricula = matricula;
        this.nombre = nombre;
        this.carrera = carrera;
        this.semestre = semestre;
        this.promedio = promedio;
    }

    public Estudiante(string matricula, string nombre, string carrera)
        : this(matricula, nombre, carrera, 1, 0.0) { }

    public Estudiante(string matricula, string nombre, string carrera, int semestre)
        : this(matricula, nombre, carrera, semestre, 0.0) { }

    ~Estudiante()
    {
        Console.WriteLine($"[Destructor]: El objeto de '{this.nombre}' ha sido eliminado.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== SISTEMA DE REGISTRO UNIVERSITARIO ===\n");

        RegistrarEstudiantes();

        Console.WriteLine("\nForzando GC...");

        GC.Collect();
        GC.WaitForPendingFinalizers();

        Thread.Sleep(1000);

        Console.WriteLine("\nPrograma finalizado.");
    }

    static void RegistrarEstudiantes()
    {
        Console.Write("Matrícula: ");
        string matricula = Console.ReadLine() ?? "";

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";

        Console.Write("Carrera: ");
        string carrera = Console.ReadLine() ?? "";

        Console.Write("Semestre (1 si es primer ingreso): ");
        int semestre = int.Parse(Console.ReadLine() ?? "1");

        Console.Write("Promedio (0 si no aplica): ");
        double promedio = double.Parse(Console.ReadLine() ?? "0");

        Estudiante estudiante;

        if (promedio > 0)
        {
            estudiante = new Estudiante(matricula, nombre, carrera, semestre, promedio);
        }
        else if (semestre > 1)
        {
            estudiante = new Estudiante(matricula, nombre, carrera, semestre);
        }
        else
        {
            estudiante = new Estudiante(matricula, nombre, carrera);
        }

        MostrarEstudiante(estudiante);

        Console.WriteLine("\nSaliendo del ámbito de los objetos...");
    }

    static void MostrarEstudiante(Estudiante estudiante)
    {
        Console.WriteLine($"Alumno: {estudiante.Nombre} | Semestre: {estudiante.Semestre} | Promedio: {estudiante.Promedio}");
    }
}