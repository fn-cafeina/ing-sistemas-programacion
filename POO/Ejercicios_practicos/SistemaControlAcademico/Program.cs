/*
    Ejemplo 2: Sistema de Control Académico con Matrices de Objetos

    La Universidad Nacional necesita un sistema para gestionar las notas de estudiantes en un curso de
    Programación Orientada a Objetos. El curso tiene un máximo de 30 estudiantes.
    Cada estudiante tiene: número de cuenta, nombre completo,
    y tres notas parciales (25%, 35% y 40% del curso respectivamente).

    El sistema debe permitir:
    1. Inscribir estudiantes hasta completar el cupo
    2. Registrar las tres notas de cada estudiante
    3. Calcular el promedio ponderado de cada estudiante
    4. Generar un reporte de todos los estudiantes con su estado (Aprobado ≥ 70, Reprobado < 70)
    5. Calcular estadísticas del curso: promedio general, nota máxima, nota mínima,
    porcentaje de Programación Orientada a Objetos.
*/

class Curso
{
    private readonly Estudiante[] _estudiantes = new Estudiante[30];
    private int _cantidadEstudiantes = 0;

    public void InscribirEstudiante(Estudiante estudiante)
    {
        if (_cantidadEstudiantes < 30)
        {
            _estudiantes[_cantidadEstudiantes] = estudiante;
            _cantidadEstudiantes++;
            Console.WriteLine($"[+] Estudiante {estudiante.Nombre} inscrito con éxito.");
        }
        else
        {
            Console.WriteLine("[-] Error: El curso ya alcanzó el cupo máximo de 30 estudiantes.");
        }
    }

    public void RegistrarNotas(int numeroCuenta, double nota1, double nota2, double nota3)
    {
        for (int i = 0; i < _cantidadEstudiantes; i++)
        {
            if (_estudiantes[i].NumeroCuenta == numeroCuenta)
            {
                _estudiantes[i].NotasParciales[0] = nota1;
                _estudiantes[i].NotasParciales[1] = nota2;
                _estudiantes[i].NotasParciales[2] = nota3;
                Console.WriteLine($"[+] Notas registradas para {_estudiantes[i].Nombre}.");
                return;
            }
        }
        Console.WriteLine($"[-] Error: No se encontró al estudiante con cuenta {numeroCuenta}.");
    }

    public void GenerarReporte()
    {
        Console.WriteLine("\n=== REPORTE DE ESTUDIANTES ===");
        Console.WriteLine("Cuenta\tNombre\t\tPromedio\tEstado");
        Console.WriteLine("--------------------------------------------------");

        for (int i = 0; i < _cantidadEstudiantes; i++)
        {
            Estudiante est = _estudiantes[i];
            Console.WriteLine($"{est.NumeroCuenta}\t{est.Nombre}\t{est.CalcularPromedio():F2}\t\t{est.ObtenerEstado()}");
        }
    }

    public void CalcularEstadisticas()
    {
        if (_cantidadEstudiantes == 0)
        {
            Console.WriteLine("No hay estudiantes inscritos para calcular estadísticas.");
            return;
        }

        double sumaPromedios = 0;
        double notaMax = double.MinValue;
        double notaMin = double.MaxValue;
        int aprobados = 0;

        for (int i = 0; i < _cantidadEstudiantes; i++)
        {
            double promedio = _estudiantes[i].CalcularPromedio();
            sumaPromedios += promedio;

            if (promedio > notaMax) notaMax = promedio;
            if (promedio < notaMin) notaMin = promedio;
            if (promedio >= 70) aprobados++;
        }

        double promedioGeneral = sumaPromedios / _cantidadEstudiantes;
        double porcentajeAprobados = (double)aprobados / _cantidadEstudiantes * 100;

        Console.WriteLine("\n=== ESTADÍSTICAS DEL CURSO ===");
        Console.WriteLine($"Promedio General: {promedioGeneral:F2}");
        Console.WriteLine($"Nota Máxima: {notaMax:F2}");
        Console.WriteLine($"Nota Mínima: {notaMin:F2}");
        Console.WriteLine($"Porcentaje de Aprobados: {porcentajeAprobados:F2}%");
    }
}

class Estudiante
{
    private int _numeroCuenta;
    private string? _nombre;
    private readonly double[] _notasParciales = new double[3];

    public int NumeroCuenta
    {
        get => _numeroCuenta;
        set => _numeroCuenta = value;
    }

    public string? Nombre
    {
        get => _nombre;
        set => _nombre = value;
    }

    public double[] NotasParciales
    {
        get => _notasParciales;
    }

    public Estudiante(int numeroCuenta, string nombre)
    {
        NumeroCuenta = numeroCuenta;
        Nombre = nombre;
    }

    public double CalcularPromedio()
    {
        return (_notasParciales[0] * 0.25) +
               (_notasParciales[1] * 0.35) +
               (_notasParciales[2] * 0.40);
    }

    public string ObtenerEstado()
    {
        return CalcularPromedio() >= 70 ? "Aprobado" : "Reprobado";
    }
}

class Program
{
    static void Main()
    {
        Curso cursoPOO = new();

        cursoPOO.InscribirEstudiante(new Estudiante(2026001, "Ana Garcia"));
        cursoPOO.InscribirEstudiante(new Estudiante(2026002, "Luis Perez"));
        cursoPOO.InscribirEstudiante(new Estudiante(2026003, "Marta Ruiz"));

        cursoPOO.RegistrarNotas(2026001, 90, 85, 95);

        cursoPOO.RegistrarNotas(2026002, 60, 70, 65);

        cursoPOO.RegistrarNotas(2026003, 100, 100, 100);

        cursoPOO.GenerarReporte();

        cursoPOO.CalcularEstadisticas();
    }
}