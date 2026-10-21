/*
    Ejercicio Propuesto 1: Gestión de Personal Universitario (PDI/PAS)

    Una universidad necesita una aplicación capaz de gestionar su personal.
    Existen dos tipos de personal: el personal docente e investigador (PDI)
    y el personal de administración y servicios (PAS).

    Los PDI se identifican a través de un número y están caracterizados por
    pertenecer a un departamento y un área.

    Los PAS se identifican a través de un número y están caracterizados por
    pertenecer a una sección y ocupar un cargo.

    Operaciones:
    * Contratar PAS/PDI.
    * Jubilar PAS/PDI.
    * Modificar datos de un PAS/PDI.
    * Mostrar los datos de los PAS/PDI.
    * Generar la nómina de todo el personal.
*/

abstract class Personal
{
    public int Numero { get; set; }
    public string Nombre { get; set; }

    protected Personal(int numero, string nombre)
    {
        Numero = numero;
        Nombre = nombre;
    }

    public abstract double ObtenerSalario();

    private static List<Personal> listaPersonal = new List<Personal>();

    public static void Contratar(Personal p)
    {
        listaPersonal.Add(p);
        Console.WriteLine("Personal contratado exitosamente.");
    }

    public static bool Jubilar(int numero)
    {
        Personal? p = listaPersonal.Find(p => p.Numero == numero);
        if (p != null)
        {
            listaPersonal.Remove(p);
            Console.WriteLine("Personal jubilado exitosamente.");
            return true;
        }
        Console.WriteLine("Error: No se encontró personal con ese número.");
        return false;
    }

    public static Personal? Buscar(int numero)
    {
        return listaPersonal.Find(p => p.Numero == numero);
    }

    public static void MostrarTodo()
    {
        if (listaPersonal.Count == 0)
        {
            Console.WriteLine("No hay personal registrado.");
            return;
        }

        foreach (Personal p in listaPersonal)
        {
            Console.WriteLine(p);
            Console.WriteLine("---------------------------");
        }
    }

    public static void MostrarPDI()
    {
        bool hay = false;
        foreach (Personal p in listaPersonal)
        {
            if (p is PDI)
            {
                Console.WriteLine(p);
                Console.WriteLine("---------------------------");
                hay = true;
            }
        }
        if (!hay) Console.WriteLine("No hay PDI registrados.");
    }

    public static void MostrarPAS()
    {
        bool hay = false;
        foreach (Personal p in listaPersonal)
        {
            if (p is PAS)
            {
                Console.WriteLine(p);
                Console.WriteLine("---------------------------");
                hay = true;
            }
        }
        if (!hay) Console.WriteLine("No hay PAS registrados.");
    }

    public static void MostrarNomina()
    {
        if (listaPersonal.Count == 0)
        {
            Console.WriteLine("No hay personal registrado.");
            return;
        }

        double total = 0;
        Console.WriteLine("--- NÓMINA DEL PERSONAL ---\n");
        foreach (Personal p in listaPersonal)
        {
            Console.WriteLine($"{p.Nombre,-20} | C${p.ObtenerSalario(),8:F2}");
            total += p.ObtenerSalario();
        }
        Console.WriteLine(new string('-', 35));
        Console.WriteLine($"{"TOTAL",-20} | C${total,8:F2}");
    }
}

class Empleado : Personal
{
    protected double salario;

    public Empleado(int numero, string nombre, double salario) : base(numero, nombre)
    {
        this.salario = salario;
    }

    public override double ObtenerSalario()
    {
        return salario;
    }

    public double Salario
    {
        get => salario;
        set => salario = value;
    }
}

class PDI : Empleado
{
    public string Departamento { get; set; }
    public string Area { get; set; }

    public PDI(int numero, string nombre, double salario, string departamento, string area)
        : base(numero, nombre, salario)
    {
        Departamento = departamento;
        Area = area;
    }

    public override string ToString()
    {
        return $"PDI #{Numero}: {Nombre} | Depto: {Departamento} | Área: {Area} | Salario: C${salario:F2}";
    }
}

class PAS : Empleado
{
    public string Seccion { get; set; }
    public string Cargo { get; set; }

    public PAS(int numero, string nombre, double salario, string seccion, string cargo)
        : base(numero, nombre, salario)
    {
        Seccion = seccion;
        Cargo = cargo;
    }

    public override string ToString()
    {
        return $"PAS #{Numero}: {Nombre} | Sección: {Seccion} | Cargo: {Cargo} | Salario: C${salario:F2}";
    }
}

class Program
{
    static void Main()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE PERSONAL UNIVERSITARIO ===\n");
            Console.WriteLine("1. Contratar PDI");
            Console.WriteLine("2. Contratar PAS");
            Console.WriteLine("3. Jubilar personal");
            Console.WriteLine("4. Modificar datos");
            Console.WriteLine("5. Mostrar PDI");
            Console.WriteLine("6. Mostrar PAS");
            Console.WriteLine("7. Mostrar todo el personal");
            Console.WriteLine("8. Generar nómina");
            Console.WriteLine("9. Salir");
            Console.Write("\nSeleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                opcion = 0;
            }

            Console.Clear();

            switch (opcion)
            {
                case 1:
                    ContratarPDI();
                    break;
                case 2:
                    ContratarPAS();
                    break;
                case 3:
                    JubilarPersonal();
                    break;
                case 4:
                    ModificarDatos();
                    break;
                case 5:
                    Personal.MostrarPDI();
                    break;
                case 6:
                    Personal.MostrarPAS();
                    break;
                case 7:
                    Personal.MostrarTodo();
                    break;
                case 8:
                    Personal.MostrarNomina();
                    break;
                case 9:
                    Console.WriteLine("Saliendo del sistema...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            if (opcion != 9)
            {
                Console.Write("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        } while (opcion != 9);
    }

    static void ContratarPDI()
    {
        Console.WriteLine("--- CONTRATAR PDI ---\n");

        int numero = LeerEntero("Número: ");
        string nombre = LeerTexto("Nombre: ");
        double salario = LeerDouble("Salario: ");
        string departamento = LeerTexto("Departamento: ");
        string area = LeerTexto("Área: ");

        Personal.Contratar(new PDI(numero, nombre, salario, departamento, area));
    }

    static void ContratarPAS()
    {
        Console.WriteLine("--- CONTRATAR PAS ---\n");

        int numero = LeerEntero("Número: ");
        string nombre = LeerTexto("Nombre: ");
        double salario = LeerDouble("Salario: ");
        string seccion = LeerTexto("Sección: ");
        string cargo = LeerTexto("Cargo: ");

        Personal.Contratar(new PAS(numero, nombre, salario, seccion, cargo));
    }

    static void JubilarPersonal()
    {
        Console.WriteLine("--- JUBILAR PERSONAL ---\n");
        int numero = LeerEntero("Ingrese el número del personal a jubilar: ");
        Personal.Jubilar(numero);
    }

    static void ModificarDatos()
    {
        Console.WriteLine("--- MODIFICAR DATOS ---\n");
        int numero = LeerEntero("Ingrese el número del personal a modificar: ");

        Personal? p = Personal.Buscar(numero);
        if (p == null)
        {
            Console.WriteLine("Error: No se encontró personal con ese número.");
            return;
        }

        Console.WriteLine($"\nDatos actuales:\n{p}\n");

        string nombre = LeerTexto($"Nuevo nombre (actual: {p.Nombre}): ");
        if (!string.IsNullOrWhiteSpace(nombre))
            p.Nombre = nombre;

        if (p is Empleado emp)
        {
            string entradaSalario = LeerTexto($"Nuevo salario (actual: C${emp.Salario:F2}): ");
            if (double.TryParse(entradaSalario, out double nuevoSalario) && nuevoSalario >= 0)
                emp.Salario = nuevoSalario;
        }

        if (p is PDI pdi)
        {
            string depto = LeerTexto($"Nuevo departamento (actual: {pdi.Departamento}): ");
            if (!string.IsNullOrWhiteSpace(depto))
                pdi.Departamento = depto;

            string area = LeerTexto($"Nueva área (actual: {pdi.Area}): ");
            if (!string.IsNullOrWhiteSpace(area))
                pdi.Area = area;
        }
        else if (p is PAS pas)
        {
            string seccion = LeerTexto($"Nueva sección (actual: {pas.Seccion}): ");
            if (!string.IsNullOrWhiteSpace(seccion))
                pas.Seccion = seccion;

            string cargo = LeerTexto($"Nuevo cargo (actual: {pas.Cargo}): ");
            if (!string.IsNullOrWhiteSpace(cargo))
                pas.Cargo = cargo;
        }

        Console.WriteLine("Datos modificados exitosamente.");
    }

    static int LeerEntero(string mensaje)
    {
        int valor;
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out valor) && valor > 0)
                return valor;
            Console.WriteLine("Error: Ingrese un número entero válido.");
        }
    }

    static double LeerDouble(string mensaje)
    {
        double valor;
        while (true)
        {
            Console.Write(mensaje);
            if (double.TryParse(Console.ReadLine(), out valor) && valor >= 0)
                return valor;
            Console.WriteLine("Error: Ingrese un número válido.");
        }
    }

    static string LeerTexto(string mensaje)
    {
        string? texto;
        while (true)
        {
            Console.Write(mensaje);
            texto = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(texto))
                return texto;
            Console.WriteLine("Error: El campo no puede quedar vacío.");
        }
    }
}
