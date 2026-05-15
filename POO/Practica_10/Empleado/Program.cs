/*
    3. Declare una clase llamada Empleado que tenga como datos miembro el nombre
    y el salario de un empleado.
    Como funciones miembros debe tener un constructor que acepte argumentos,
    un constructor copia, las propie-dades para acceder a los atributos de la clase.
    A continuación, declare una clase derivada de Empleado llamada Vigilante que tenga
    como datos miembros la hora de entrada y salida. Como funciones miembros debe tener
    un constructor que acepte argumentos, un constructor copia,
    las propiedades para acceder a los atributos de la clase y los métodos para
    solicitar e imprimir los datos de la clase.

    En la función main() ponga a prueba cada una de las funciones definidas.
*/

public class Empleado
{
    string nombre;
    double salario;

    public Empleado(string nombre, double salario)
    {
        this.nombre = nombre;
        this.salario = salario;
    }

    public Empleado(Empleado otroEmpleado)
    {
        this.nombre = otroEmpleado.nombre;
        this.salario = otroEmpleado.salario;
    }

    public string Nombre
    {
        get => nombre;
        set => nombre = value;
    }

    public double Salario
    {
        get => salario;
        set => salario = value;
    }
}

public class Vigilante : Empleado
{
    string horaEntrada;
    string horaSalida;

    public Vigilante(string nombre, double salario, string horaEntrada, string horaSalida) : base(nombre, salario)
    {
        this.horaEntrada = horaEntrada;
        this.horaSalida = horaSalida;
    }

    public Vigilante(Vigilante otroVigilante) : base(otroVigilante)
    {
        this.horaEntrada = otroVigilante.horaEntrada;
        this.horaSalida = otroVigilante.horaSalida;
    }

    public string HoraEntrada
    {
        get => horaEntrada;
        set => horaEntrada = value;
    }

    public string HoraSalida
    {
        get => horaSalida;
        set => horaSalida = value;
    }

    public void SolicitarDatos()
    {
        string nombre;
        do
        {
            Console.Write("Ingrese el nombre: ");
            nombre = Console.ReadLine()?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("El nombre no puede quedar vacío.");
            }
        } while (string.IsNullOrWhiteSpace(nombre));
        Nombre = nombre;

        double salario;
        while (true)
        {
            Console.Write("Ingrese el salario: ");
            string entradaSalario = Console.ReadLine() ?? string.Empty;
            if (double.TryParse(entradaSalario, out salario) && salario >= 0)
            {
                break;
            }
            Console.WriteLine("Salario inválido. Ingrese un número mayor o igual a 0.");
        }
        Salario = salario;

        string horaEntrada;
        while (true)
        {
            Console.Write("Ingrese la hora de entrada (HH:MM): ");
            horaEntrada = Console.ReadLine()?.Trim() ?? string.Empty;
            if (System.Text.RegularExpressions.Regex.IsMatch(horaEntrada, "^([01]\\d|2[0-3]):[0-5]\\d$"))
            {
                break;
            }
            Console.WriteLine("Hora de entrada inválida. Use el formato HH:MM.");
        }
        HoraEntrada = horaEntrada;

        string horaSalida;
        while (true)
        {
            Console.Write("Ingrese la hora de salida (HH:MM): ");
            horaSalida = Console.ReadLine()?.Trim() ?? string.Empty;
            if (System.Text.RegularExpressions.Regex.IsMatch(horaSalida, "^([01]\\d|2[0-3]):[0-5]\\d$"))
            {
                break;
            }
            Console.WriteLine("Hora de salida inválida. Use el formato HH:MM.");
        }
        HoraSalida = horaSalida;
    }

    public void ImprimirDatos()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Salario: {Salario}");
        Console.WriteLine($"Hora entrada: {HoraEntrada}");
        Console.WriteLine($"Hora salida: {HoraSalida}");
    }
}

public class Program
{
    static void Main()
    {
        Console.Clear();

        Vigilante v1 = new Vigilante("Juan Pérez", 10500, "07:00", "18:00");
        v1.ImprimirDatos();

        Console.WriteLine("\n----------------------------------\n");

        Vigilante v2 = new Vigilante(v1);
        v2.Nombre = "José Pérez";
        v2.ImprimirDatos();

        Console.WriteLine("\n----------------------------------\n");

        Vigilante v3 = new Vigilante("Pendiente", 0, "00:00", "00:00");
        v3.SolicitarDatos();

        Console.WriteLine("\n----------------------------------\n");

        v3.ImprimirDatos();
    }
}