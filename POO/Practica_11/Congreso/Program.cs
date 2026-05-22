/*
    Ejercicio Propuesto 2: Congreso (Ponentes/Oyentes)

    En la Universidad Nacional Autónoma de Nicaragua – León, se desea montar
    un congreso y se le pide al personal de desarrollo de software y sistemas
    diseñe un programa que permita almacenar la información de cada uno de
    los participantes al congreso. Estos participantes pueden ser ponentes u
    oyentes.

    Datos generales: nombre, apellido, sexo, país residencia, teléfono, email.

    Ponente: título ponencias, temática.
    Oyente: grado académico.

    Menú:
    1. Introducir participante (submenú: Ponente/Oyente/Regresar)
    2. Mostrar ponentes
    3. Mostrar oyentes
    4. Buscar participante
    5. Salir
*/

abstract class Participante
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Sexo { get; set; }
    public string PaisResidencia { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }

    protected Participante(string nombre, string apellido, string sexo, string paisResidencia,
                           string telefono, string email)
    {
        Nombre = nombre;
        Apellido = apellido;
        Sexo = sexo;
        PaisResidencia = paisResidencia;
        Telefono = telefono;
        Email = email;
    }

    private static List<Participante> listaParticipantes = new List<Participante>();

    public static void Agregar(Participante p)
    {
        listaParticipantes.Add(p);
        Console.WriteLine("Participante agregado exitosamente.");
    }

    public static void MostrarPonentes()
    {
        bool hay = false;
        foreach (Participante p in listaParticipantes)
        {
            if (p is Ponente)
            {
                Console.WriteLine(p);
                Console.WriteLine("---------------------------");
                hay = true;
            }
        }
        if (!hay) Console.WriteLine("No hay ponentes registrados.");
    }

    public static void MostrarOyentes()
    {
        bool hay = false;
        foreach (Participante p in listaParticipantes)
        {
            if (p is Oyente)
            {
                Console.WriteLine(p);
                Console.WriteLine("---------------------------");
                hay = true;
            }
        }
        if (!hay) Console.WriteLine("No hay oyentes registrados.");
    }

    public static Participante? Buscar(string criterio)
    {
        return listaParticipantes.Find(p =>
            p.Nombre.Contains(criterio, StringComparison.OrdinalIgnoreCase) ||
            p.Apellido.Contains(criterio, StringComparison.OrdinalIgnoreCase) ||
            p.Email.Equals(criterio, StringComparison.OrdinalIgnoreCase));
    }

    public static int CantidadTotal()
    {
        return listaParticipantes.Count;
    }
}

class Ponente : Participante
{
    public string TituloPonencias { get; set; }
    public string Tematica { get; set; }

    public Ponente(string nombre, string apellido, string sexo, string paisResidencia,
                   string telefono, string email, string tituloPonencias, string tematica)
        : base(nombre, apellido, sexo, paisResidencia, telefono, email)
    {
        TituloPonencias = tituloPonencias;
        Tematica = tematica;
    }

    public override string ToString()
    {
        return $"PONENTE: {Nombre} {Apellido} | {Sexo} | País: {PaisResidencia}\n" +
               $"Tel: {Telefono} | Email: {Email}\n" +
               $"Título ponencia: {TituloPonencias} | Temática: {Tematica}";
    }
}

class Oyente : Participante
{
    public string GradoAcademico { get; set; }

    public Oyente(string nombre, string apellido, string sexo, string paisResidencia,
                  string telefono, string email, string gradoAcademico)
        : base(nombre, apellido, sexo, paisResidencia, telefono, email)
    {
        GradoAcademico = gradoAcademico;
    }

    public override string ToString()
    {
        return $"OYENTE: {Nombre} {Apellido} | {Sexo} | País: {PaisResidencia}\n" +
               $"Tel: {Telefono} | Email: {Email}\n" +
               $"Grado académico: {GradoAcademico}";
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
            Console.WriteLine("=== SISTEMA DE GESTIÓN DE CONGRESO ===\n");
            Console.WriteLine($"Participantes registrados: {Participante.CantidadTotal()}\n");
            Console.WriteLine("1. Introducir participante");
            Console.WriteLine("2. Mostrar ponentes");
            Console.WriteLine("3. Mostrar oyentes");
            Console.WriteLine("4. Buscar participante");
            Console.WriteLine("5. Salir");
            Console.Write("\nSeleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                opcion = 0;
            }

            Console.Clear();

            switch (opcion)
            {
                case 1:
                    SubmenuIntroducir();
                    break;
                case 2:
                    Participante.MostrarPonentes();
                    break;
                case 3:
                    Participante.MostrarOyentes();
                    break;
                case 4:
                    BuscarParticipante();
                    break;
                case 5:
                    Console.WriteLine("Saliendo del sistema...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            if (opcion != 5)
            {
                Console.Write("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        } while (opcion != 5);
    }

    static void SubmenuIntroducir()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("--- INTRODUCIR PARTICIPANTE ---\n");
            Console.WriteLine("1. Introducir Ponente");
            Console.WriteLine("2. Introducir Oyente");
            Console.WriteLine("3. Regresar");
            Console.Write("\nSeleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                opcion = 0;
            }

            Console.Clear();

            switch (opcion)
            {
                case 1:
                    IntroducirPonente();
                    break;
                case 2:
                    IntroducirOyente();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            if (opcion != 3)
            {
                Console.Write("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        } while (opcion != 3);
    }

    static void IntroducirPonente()
    {
        Console.WriteLine("--- NUEVO PONENTE ---\n");

        string nombre = LeerTexto("Nombre: ");
        string apellido = LeerTexto("Apellido: ");
        string sexo = LeerTexto("Sexo (M/F): ");
        string pais = LeerTexto("País de residencia: ");
        string telefono = LeerTexto("Teléfono: ");
        string email = LeerTexto("Email: ");
        string titulo = LeerTexto("Título de ponencia(s): ");
        string tematica = LeerTexto("Temática: ");

        Participante.Agregar(new Ponente(nombre, apellido, sexo, pais, telefono, email, titulo, tematica));
    }

    static void IntroducirOyente()
    {
        Console.WriteLine("--- NUEVO OYENTE ---\n");

        string nombre = LeerTexto("Nombre: ");
        string apellido = LeerTexto("Apellido: ");
        string sexo = LeerTexto("Sexo (M/F): ");
        string pais = LeerTexto("País de residencia: ");
        string telefono = LeerTexto("Teléfono: ");
        string email = LeerTexto("Email: ");
        string grado = LeerTexto("Grado académico: ");

        Participante.Agregar(new Oyente(nombre, apellido, sexo, pais, telefono, email, grado));
    }

    static void BuscarParticipante()
    {
        Console.WriteLine("--- BUSCAR PARTICIPANTE ---\n");
        string criterio = LeerTexto("Ingrese nombre, apellido o email: ");

        Participante? p = Participante.Buscar(criterio);
        if (p != null)
        {
            Console.WriteLine($"\n{p}");
        }
        else
        {
            Console.WriteLine("No se encontró ningún participante con ese criterio.");
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
