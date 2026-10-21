/*
    Ejercicio Propuesto 3: Sistema de Control Académico

    Se pretende desarrollar un sistema informático por medio del cual se
    llevará el control del personal (trabajadores) de una institución académica,
    además de la información del personal también se llevará el control de los
    estudiantes de dicha institución.

    Jerarquía de clases:
    CFecha (día, mes, año)
    CPersona → CAlumno → CBecadoExt, CBecadoInt
            → CEmpleado → CProfesor, CAdministrativo
    CFacultad (contiene List<CPersona>)

    Menú principal con submenús para insertar, eliminar y buscar.
*/

class CFecha
{
    public int Dia { get; set; }
    public int Mes { get; set; }
    public int Anio { get; set; }

    public CFecha(int dia, int mes, int anio)
    {
        if (!EsFechaValida(dia, mes, anio))
        {
            Console.WriteLine("Error: Fecha no válida. Se asignará 01/01/2000.");
            Dia = 1;
            Mes = 1;
            Anio = 2000;
            return;
        }
        Dia = dia;
        Mes = mes;
        Anio = anio;
    }

    private static bool EsFechaValida(int dia, int mes, int anio)
    {
        if (mes < 1 || mes > 12 || dia < 1 || anio < 1900)
            return false;

        int[] diasPorMes = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        if (mes == 2 && EsBisiesto(anio))
            diasPorMes[2] = 29;

        return dia <= diasPorMes[mes];
    }

    private static bool EsBisiesto(int anio)
    {
        return (anio % 4 == 0 && anio % 100 != 0) || (anio % 400 == 0);
    }

    public override string ToString()
    {
        return $"{Dia:D2}/{Mes:D2}/{Anio}";
    }
}

abstract class CPersona
{
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Sexo { get; set; }
    public string Telefono { get; set; }
    public CFecha FechaNacimiento { get; set; }

    protected CPersona(string nombre, string direccion, string sexo, string telefono, CFecha fechaNacimiento)
    {
        Nombre = nombre;
        Direccion = direccion;
        Sexo = sexo;
        Telefono = telefono;
        FechaNacimiento = fechaNacimiento;
    }

    public virtual string ObtenerIdentificador()
    {
        return Nombre;
    }

    public virtual void MostrarDatos()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Dirección: {Direccion}");
        Console.WriteLine($"Sexo: {Sexo}");
        Console.WriteLine($"Teléfono: {Telefono}");
        Console.WriteLine($"Fecha de nacimiento: {FechaNacimiento}");
    }
}

class CAlumno : CPersona
{
    public string Carnet { get; set; }
    public string Carrera { get; set; }

    public CAlumno(string nombre, string direccion, string sexo, string telefono, CFecha fechaNacimiento,
                   string carnet, string carrera)
        : base(nombre, direccion, sexo, telefono, fechaNacimiento)
    {
        Carnet = carnet;
        Carrera = carrera;
    }

    public override string ObtenerIdentificador()
    {
        return Carnet;
    }

    public override void MostrarDatos()
    {
        Console.WriteLine("--- ALUMNO ---");
        base.MostrarDatos();
        Console.WriteLine($"Carnet: {Carnet}");
        Console.WriteLine($"Carrera: {Carrera}");
    }
}

class CBecadoExt : CAlumno
{
    public double Monto { get; set; }

    public CBecadoExt(string nombre, string direccion, string sexo, string telefono, CFecha fechaNacimiento,
                      string carnet, string carrera, double monto)
        : base(nombre, direccion, sexo, telefono, fechaNacimiento, carnet, carrera)
    {
        Monto = monto;
    }

    public override void MostrarDatos()
    {
        Console.WriteLine("--- BECADO EXTERNO ---");
        base.MostrarDatos();
        Console.WriteLine($"Monto de beca: C${Monto:F2}");
    }
}

class CBecadoInt : CAlumno
{
    public string Residencia { get; set; }
    public int NumeroCuarto { get; set; }

    public CBecadoInt(string nombre, string direccion, string sexo, string telefono, CFecha fechaNacimiento,
                      string carnet, string carrera, string residencia, int numeroCuarto)
        : base(nombre, direccion, sexo, telefono, fechaNacimiento, carnet, carrera)
    {
        Residencia = residencia;
        NumeroCuarto = numeroCuarto;
    }

    public override void MostrarDatos()
    {
        Console.WriteLine("--- BECADO INTERNO ---");
        base.MostrarDatos();
        Console.WriteLine($"Residencia: {Residencia}");
        Console.WriteLine($"Número de cuarto: {NumeroCuarto}");
    }
}

class CEmpleado : CPersona
{
    public int NumeroINSS { get; set; }
    public string Titulo { get; set; }
    public string Cargo { get; set; }
    public double Salario { get; set; }
    public int Antiguedad { get; set; }

    public CEmpleado(string nombre, string direccion, string sexo, string telefono, CFecha fechaNacimiento,
                     int numeroINSS, string titulo, string cargo, double salario, int antiguedad)
        : base(nombre, direccion, sexo, telefono, fechaNacimiento)
    {
        NumeroINSS = numeroINSS;
        Titulo = titulo;
        Cargo = cargo;
        Salario = salario;
        Antiguedad = antiguedad;
    }

    public override string ObtenerIdentificador()
    {
        return NumeroINSS.ToString();
    }

    public override void MostrarDatos()
    {
        Console.WriteLine("--- EMPLEADO ---");
        base.MostrarDatos();
        Console.WriteLine($"INSS: {NumeroINSS}");
        Console.WriteLine($"Título: {Titulo}");
        Console.WriteLine($"Cargo: {Cargo}");
        Console.WriteLine($"Salario: C${Salario:F2}");
        Console.WriteLine($"Antigüedad: {Antiguedad} años");
    }
}

class CProfesor : CEmpleado
{
    public string Departamento { get; set; }
    public string Categoria { get; set; }

    public CProfesor(string nombre, string direccion, string sexo, string telefono, CFecha fechaNacimiento,
                     int numeroINSS, string titulo, string cargo, double salario, int antiguedad,
                     string departamento, string categoria)
        : base(nombre, direccion, sexo, telefono, fechaNacimiento, numeroINSS, titulo, cargo, salario, antiguedad)
    {
        Departamento = departamento;
        Categoria = categoria;
    }

    public override void MostrarDatos()
    {
        Console.WriteLine("--- PROFESOR ---");
        base.MostrarDatos();
        Console.WriteLine($"Departamento: {Departamento}");
        Console.WriteLine($"Categoría: {Categoria}");
    }
}

class CAdministrativo : CEmpleado
{
    public string Dependencia { get; set; }

    public CAdministrativo(string nombre, string direccion, string sexo, string telefono, CFecha fechaNacimiento,
                           int numeroINSS, string titulo, string cargo, double salario, int antiguedad,
                           string dependencia)
        : base(nombre, direccion, sexo, telefono, fechaNacimiento, numeroINSS, titulo, cargo, salario, antiguedad)
    {
        Dependencia = dependencia;
    }

    public override void MostrarDatos()
    {
        Console.WriteLine("--- ADMINISTRATIVO ---");
        base.MostrarDatos();
        Console.WriteLine($"Dependencia: {Dependencia}");
    }
}

class CFacultad
{
    private List<CPersona> personas = new List<CPersona>();

    public void InsertarAlumno(CAlumno alumno)
    {
        personas.Add(alumno);
        Console.WriteLine("Alumno insertado exitosamente.");
    }

    public void InsertarEmpleado(CEmpleado empleado)
    {
        personas.Add(empleado);
        Console.WriteLine("Empleado insertado exitosamente.");
    }

    public bool EliminarAlumno(string carnet)
    {
        CPersona? p = personas.Find(p => p is CAlumno a && a.Carnet == carnet);
        if (p != null)
        {
            personas.Remove(p);
            Console.WriteLine("Alumno eliminado exitosamente.");
            return true;
        }
        Console.WriteLine("Error: No se encontró alumno con ese carnet.");
        return false;
    }

    public bool EliminarEmpleado(int inss)
    {
        CPersona? p = personas.Find(p => p is CEmpleado e && e.NumeroINSS == inss);
        if (p != null)
        {
            personas.Remove(p);
            Console.WriteLine("Empleado eliminado exitosamente.");
            return true;
        }
        Console.WriteLine("Error: No se encontró empleado con ese INSS.");
        return false;
    }

    public CPersona? BuscarAlumno(string carnet)
    {
        return personas.Find(p => p is CAlumno a && a.Carnet == carnet);
    }

    public CPersona? BuscarBecadoExt(string carnet)
    {
        return personas.Find(p => p is CBecadoExt b && b.Carnet == carnet);
    }

    public CPersona? BuscarBecadoInt(string carnet)
    {
        return personas.Find(p => p is CBecadoInt b && b.Carnet == carnet);
    }

    public CPersona? BuscarProfesor(int inss)
    {
        return personas.Find(p => p is CProfesor pr && pr.NumeroINSS == inss);
    }

    public CPersona? BuscarAdministrativo(int inss)
    {
        return personas.Find(p => p is CAdministrativo ad && ad.NumeroINSS == inss);
    }

    public void BorrarTodo()
    {
        personas.Clear();
        Console.WriteLine("Todos los registros han sido eliminados.");
    }

    public int CantidadTotal()
    {
        return personas.Count;
    }
}

class Program
{
    static CFacultad facultad = new CFacultad();

    static void Main()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE CONTROL ACADÉMICO ===\n");
            Console.WriteLine($"Personas registradas: {facultad.CantidadTotal()}\n");
            Console.WriteLine("1. Insertar alumno");
            Console.WriteLine("2. Insertar empleado");
            Console.WriteLine("3. Eliminar alumno");
            Console.WriteLine("4. Eliminar empleado");
            Console.WriteLine("5. Buscar persona");
            Console.WriteLine("6. Borrar todo");
            Console.WriteLine("7. Salir");
            Console.Write("\nSeleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                opcion = 0;
            }

            Console.Clear();

            switch (opcion)
            {
                case 1:
                    SubmenuInsertarAlumno();
                    break;
                case 2:
                    SubmenuInsertarEmpleado();
                    break;
                case 3:
                    EliminarAlumno();
                    break;
                case 4:
                    EliminarEmpleado();
                    break;
                case 5:
                    SubmenuBuscar();
                    break;
                case 6:
                    facultad.BorrarTodo();
                    break;
                case 7:
                    Console.WriteLine("Saliendo del sistema...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            if (opcion != 7)
            {
                Console.Write("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        } while (opcion != 7);
    }

    static void SubmenuInsertarAlumno()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("--- INSERTAR ALUMNO ---\n");
            Console.WriteLine("1. Insertar alumno");
            Console.WriteLine("2. Insertar becado externo");
            Console.WriteLine("3. Insertar becado interno");
            Console.WriteLine("4. Regresar");
            Console.Write("\nSeleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                opcion = 0;
            }

            Console.Clear();

            switch (opcion)
            {
                case 1:
                    InsertarAlumno();
                    break;
                case 2:
                    InsertarBecadoExt();
                    break;
                case 3:
                    InsertarBecadoInt();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            if (opcion != 4)
            {
                Console.Write("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        } while (opcion != 4);
    }

    static void SubmenuInsertarEmpleado()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("--- INSERTAR EMPLEADO ---\n");
            Console.WriteLine("1. Insertar profesor");
            Console.WriteLine("2. Insertar administrativo");
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
                    InsertarProfesor();
                    break;
                case 2:
                    InsertarAdministrativo();
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

    static void SubmenuBuscar()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("--- BUSCAR PERSONA ---\n");
            Console.WriteLine("1. Buscar alumno");
            Console.WriteLine("2. Buscar becado externo");
            Console.WriteLine("3. Buscar becado interno");
            Console.WriteLine("4. Buscar profesor");
            Console.WriteLine("5. Buscar administrativo");
            Console.WriteLine("6. Regresar");
            Console.Write("\nSeleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                opcion = 0;
            }

            Console.Clear();

            CPersona? p = null;

            switch (opcion)
            {
                case 1:
                    string carnet = LeerTexto("Ingrese el carnet del alumno: ");
                    p = facultad.BuscarAlumno(carnet);
                    break;
                case 2:
                    carnet = LeerTexto("Ingrese el carnet del becado externo: ");
                    p = facultad.BuscarBecadoExt(carnet);
                    break;
                case 3:
                    carnet = LeerTexto("Ingrese el carnet del becado interno: ");
                    p = facultad.BuscarBecadoInt(carnet);
                    break;
                case 4:
                    int inss = LeerEntero("Ingrese el INSS del profesor: ");
                    p = facultad.BuscarProfesor(inss);
                    break;
                case 5:
                    inss = LeerEntero("Ingrese el INSS del administrativo: ");
                    p = facultad.BuscarAdministrativo(inss);
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            if (p != null)
            {
                Console.WriteLine();
                p.MostrarDatos();
            }
            else
            {
                Console.WriteLine("No se encontró la persona.");
            }

            if (opcion >= 1 && opcion <= 5)
            {
                Console.Write("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        } while (opcion != 6);
    }

    static void InsertarAlumno()
    {
        Console.WriteLine("--- NUEVO ALUMNO ---\n");
        string nombre = LeerTexto("Nombre: ");
        string direccion = LeerTexto("Dirección: ");
        string sexo = LeerTexto("Sexo (M/F): ");
        string telefono = LeerTexto("Teléfono: ");
        CFecha fecha = LeerFecha();
        string carnet = LeerTexto("Carnet: ");
        string carrera = LeerTexto("Carrera: ");

        facultad.InsertarAlumno(new CAlumno(nombre, direccion, sexo, telefono, fecha, carnet, carrera));
    }

    static void InsertarBecadoExt()
    {
        Console.WriteLine("--- NUEVO BECADO EXTERNO ---\n");
        string nombre = LeerTexto("Nombre: ");
        string direccion = LeerTexto("Dirección: ");
        string sexo = LeerTexto("Sexo (M/F): ");
        string telefono = LeerTexto("Teléfono: ");
        CFecha fecha = LeerFecha();
        string carnet = LeerTexto("Carnet: ");
        string carrera = LeerTexto("Carrera: ");
        double monto = LeerDouble("Monto de beca: ");

        facultad.InsertarAlumno(new CBecadoExt(nombre, direccion, sexo, telefono, fecha, carnet, carrera, monto));
    }

    static void InsertarBecadoInt()
    {
        Console.WriteLine("--- NUEVO BECADO INTERNO ---\n");
        string nombre = LeerTexto("Nombre: ");
        string direccion = LeerTexto("Dirección: ");
        string sexo = LeerTexto("Sexo (M/F): ");
        string telefono = LeerTexto("Teléfono: ");
        CFecha fecha = LeerFecha();
        string carnet = LeerTexto("Carnet: ");
        string carrera = LeerTexto("Carrera: ");
        string residencia = LeerTexto("Residencia: ");
        int numCuarto = LeerEntero("Número de cuarto: ");

        facultad.InsertarAlumno(new CBecadoInt(nombre, direccion, sexo, telefono, fecha, carnet, carrera, residencia, numCuarto));
    }

    static void InsertarProfesor()
    {
        Console.WriteLine("--- NUEVO PROFESOR ---\n");
        string nombre = LeerTexto("Nombre: ");
        string direccion = LeerTexto("Dirección: ");
        string sexo = LeerTexto("Sexo (M/F): ");
        string telefono = LeerTexto("Teléfono: ");
        CFecha fecha = LeerFecha();
        int inss = LeerEntero("Número INSS: ");
        string titulo = LeerTexto("Título: ");
        string cargo = LeerTexto("Cargo: ");
        double salario = LeerDouble("Salario: ");
        int antiguedad = LeerEntero("Antigüedad (años): ");
        string departamento = LeerTexto("Departamento: ");
        string categoria = LeerTexto("Categoría (titular/asistente): ");

        facultad.InsertarEmpleado(new CProfesor(nombre, direccion, sexo, telefono, fecha, inss, titulo, cargo, salario, antiguedad, departamento, categoria));
    }

    static void InsertarAdministrativo()
    {
        Console.WriteLine("--- NUEVO ADMINISTRATIVO ---\n");
        string nombre = LeerTexto("Nombre: ");
        string direccion = LeerTexto("Dirección: ");
        string sexo = LeerTexto("Sexo (M/F): ");
        string telefono = LeerTexto("Teléfono: ");
        CFecha fecha = LeerFecha();
        int inss = LeerEntero("Número INSS: ");
        string titulo = LeerTexto("Título: ");
        string cargo = LeerTexto("Cargo: ");
        double salario = LeerDouble("Salario: ");
        int antiguedad = LeerEntero("Antigüedad (años): ");
        string dependencia = LeerTexto("Dependencia: ");

        facultad.InsertarEmpleado(new CAdministrativo(nombre, direccion, sexo, telefono, fecha, inss, titulo, cargo, salario, antiguedad, dependencia));
    }

    static void EliminarAlumno()
    {
        Console.WriteLine("--- ELIMINAR ALUMNO ---\n");
        string carnet = LeerTexto("Ingrese el carnet del alumno: ");
        facultad.EliminarAlumno(carnet);
    }

    static void EliminarEmpleado()
    {
        Console.WriteLine("--- ELIMINAR EMPLEADO ---\n");
        int inss = LeerEntero("Ingrese el INSS del empleado: ");
        facultad.EliminarEmpleado(inss);
    }

    static CFecha LeerFecha()
    {
        int dia, mes, anio;
        while (true)
        {
            Console.Write("Ingrese fecha de nacimiento (dd/mm/aaaa): ");
            string? entrada = Console.ReadLine()?.Trim();
            string[] partes = (entrada ?? "").Split('/');

            if (partes.Length == 3 &&
                int.TryParse(partes[0], out dia) &&
                int.TryParse(partes[1], out mes) &&
                int.TryParse(partes[2], out anio))
            {
                return new CFecha(dia, mes, anio);
            }
            Console.WriteLine("Error: Formato inválido. Use dd/mm/aaaa.");
        }
    }

    static int LeerEntero(string mensaje)
    {
        int valor;
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out valor) && valor >= 0)
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
