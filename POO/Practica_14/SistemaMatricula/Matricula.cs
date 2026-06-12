class Matricula
{
    static List<Asignatura> asignaturas = new()
    {
        new Asignatura("Programacion I", 3, 0),
        new Asignatura("Base de Datos", 2, 2),
        new Asignatura("Estructura de Datos", 1, 1, 50),
    };

    static List<Estudiante> estudiantes = new()
    {
        new Estudiante("Ana Lopez", 50),
        new Estudiante("Luis Perez", 30),
        new Estudiante("Carlos Ruiz", 45),
    };

    static HashSet<string> matriculasRealizadas = new();

    public static bool RealizarMatricula()
    {
        Console.WriteLine("Estudiantes registrados:");
        for (int i = 0; i < estudiantes.Count; i++)
        {
            Console.WriteLine($"  [{i + 1}] {estudiantes[i].Nombre} ({estudiantes[i].CreditosAprobados} creditos)");
        }
        Console.WriteLine();

        Estudiante? estudiante = null;
        while (estudiante == null)
        {
            Console.Write("Seleccione un estudiante (numero o nombre, '0' para salir): ");
            string? entrada = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine("Debe ingresar un numero o nombre valido.");
                continue;
            }

            if (entrada == "0")
            {
                Console.WriteLine("Operacion cancelada.");
                return false;
            }

            if (int.TryParse(entrada, out int idx) && idx >= 1 && idx <= estudiantes.Count)
            {
                estudiante = estudiantes[idx - 1];
            }
            else
            {
                estudiante = estudiantes.Find(e =>
                    e.Nombre.Equals(entrada, StringComparison.OrdinalIgnoreCase));
            }

            if (estudiante == null)
                Console.WriteLine("Estudiante no encontrado. Intente de nuevo.");
        }

        Console.Clear();
        Console.WriteLine($"Estudiante seleccionado: {estudiante.Nombre} ({estudiante.CreditosAprobados} creditos)");
        Console.WriteLine();

        Console.WriteLine("Asignaturas disponibles:");
        for (int i = 0; i < asignaturas.Count; i++)
        {
            var a = asignaturas[i];
            int disponibles = a.CupoMaximo - a.CuposInscritos;
            bool cupoDisponible = disponibles > 0;
            bool creditosOk = estudiante.CreditosAprobados >= a.CreditosRequeridos;

            string clave = $"{estudiante.Nombre}|{a.Nombre}";
            bool yaInscrito = matriculasRealizadas.Contains(clave);

            Console.Write($"  [{i + 1}] {a.Nombre}");
            if (yaInscrito)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(" (YA INSCRITO)");
            }
            else if (cupoDisponible && creditosOk)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" ({disponibles} cupo(s))");
            }
            else if (!cupoDisponible)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" (CUPO LLENO)");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($" (FALTAN {a.CreditosRequeridos - estudiante.CreditosAprobados} creditos)");
            }
            Console.ResetColor();
        }
        Console.WriteLine();

        Asignatura? asignatura = null;
        while (asignatura == null)
        {
            Console.Write("Seleccione una asignatura (numero o nombre, '0' para salir): ");
            string? entrada = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine("Debe ingresar un numero o nombre valido.");
                continue;
            }

            if (entrada == "0")
            {
                Console.WriteLine("Operacion cancelada.");
                return false;
            }

            if (int.TryParse(entrada, out int idx) && idx >= 1 && idx <= asignaturas.Count)
            {
                asignatura = asignaturas[idx - 1];
            }
            else
            {
                asignatura = asignaturas.Find(a =>
                    a.Nombre.Equals(entrada, StringComparison.OrdinalIgnoreCase));
            }

            if (asignatura == null)
                Console.WriteLine("Asignatura no encontrada. Intente de nuevo.");
        }

        Console.Clear();
        Console.WriteLine("Resumen de matricula:");
        Console.WriteLine($"  Estudiante: {estudiante.Nombre} ({estudiante.CreditosAprobados} creditos)");
        Console.WriteLine($"  Asignatura: {asignatura.Nombre}");
        Console.WriteLine();
        Console.Write("Confirmar matricula? (s/n): ");
        string? conf = Console.ReadLine()?.Trim().ToLower();
        if (conf != "s" && conf != "si" && conf != "y" && conf != "yes")
        {
            Console.WriteLine("Matricula cancelada.");
            return true;
        }

        string claveMatricula = $"{estudiante.Nombre}|{asignatura.Nombre}";
        if (matriculasRealizadas.Contains(claveMatricula))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"'{estudiante.Nombre}' ya esta inscrito en '{asignatura.Nombre}'.");
            Console.ResetColor();
            return true;
        }

        if (estudiante.CreditosAprobados < asignatura.CreditosRequeridos)
        {
            throw new CreditosInsuficientesException(
                $"El estudiante '{estudiante.Nombre}' tiene {estudiante.CreditosAprobados} creditos, " +
                $"pero se requieren {asignatura.CreditosRequeridos} creditos para '{asignatura.Nombre}'.");
        }

        if (asignatura.CuposInscritos >= asignatura.CupoMaximo)
        {
            throw new CupoAgotadoException(
                $"La asignatura '{asignatura.Nombre}' ha alcanzado el cupo maximo ({asignatura.CupoMaximo}).");
        }

        matriculasRealizadas.Add(claveMatricula);
        estudiante.CreditosAprobados -= asignatura.CreditosRequeridos;
        asignatura.CuposInscritos++;
        int cuposRestantes = asignatura.CupoMaximo - asignatura.CuposInscritos;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Matricula exitosa. {estudiante.Nombre} inscrito en '{asignatura.Nombre}'.");
        Console.WriteLine($"Cupos restantes en '{asignatura.Nombre}': {cuposRestantes}.");
        Console.WriteLine($"Creditos restantes de {estudiante.Nombre}: {estudiante.CreditosAprobados}.");
        Console.ResetColor();
        return true;
    }
}
