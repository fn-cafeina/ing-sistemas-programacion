/*
    El grupo COMPGRES pretende montar un congreso en el que se prevé
    una amplia participación tanto de ponentes y personas oyentes.

    Se desea crear una aplicación por medio de la cual se pueda registrar
    a los participantes del congreso (Ponentes y Oyentes) y así poder
    organizar convenientemente a los participantes.

    Información de los participantes:
    - Nombre completo
    - Sexo (M, F)
    - País de residencia
    - Documento de identidad (cédula, carnet, pasaporte)
    - Teléfono
    - E-mail

    La aplicación deberá mostrar el siguiente menú:

    1. Introducir Participante.
    2. Mostrar Participante.
    3. Crear una copia del participante.
    4. Asignar un participante en otro.
    5. Salir.

    Para los participantes Oyentes se desea llevar además:
    - Número de registro.
    - Grado académico (estudiante, egresado, profesional).

    Para los participantes Ponentes se desea llevar además:
    - Número de ponencia.
    - Título de la ponencia.
*/

using Compgres;

List<Participante> participantes = [];

Participante? copia = null;

while (true)
{
    Console.WriteLine();
    Console.WriteLine("1. Introducir participante");
    Console.WriteLine("2. Mostrar participantes");
    Console.WriteLine("3. Crear copia");
    Console.WriteLine("4. Asignar participante");
    Console.WriteLine("5. Salir");

    Console.Write("Opción: ");

    string? opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            CrearParticipante();
            break;

        case "2":
            MostrarParticipantes();
            break;

        case "3":
            CrearCopia();
            break;

        case "4":
            Asignar();
            break;

        case "5":
            return;
    }
}

void CrearParticipante()
{
    Console.WriteLine("1. Oyente");
    Console.WriteLine("2. Ponente");

    string? tipo = Console.ReadLine();

    if (tipo == "1")
    {
        Oyente o = new();

        LeerDatos(o);

        Console.Write("Número de registro: ");
        o.NumeroRegistro = int.Parse(Console.ReadLine()!);

        Console.Write("Grado académico: ");
        o.GradoAcademico = Console.ReadLine()!;

        participantes.Add(o);
    }
    else
    {
        Ponente p = new();

        LeerDatos(p);

        Console.Write("Número de ponencia: ");
        p.NumeroPonencia = int.Parse(Console.ReadLine()!);

        Console.Write("Título de la ponencia: ");
        p.TituloPonencia = Console.ReadLine()!;

        participantes.Add(p);
    }
}

void LeerDatos(Participante p)
{
    Console.Write("Nombre: ");
    p.NombreCompleto = Console.ReadLine()!;

    Console.Write("Sexo: ");
    p.Sexo = Console.ReadLine()![0];

    Console.Write("País: ");
    p.PaisResidencia = Console.ReadLine()!;

    Console.Write("Documento: ");
    p.Documento = Console.ReadLine()!;

    Console.Write("Teléfono: ");
    p.Telefono = Console.ReadLine()!;

    Console.Write("Email: ");
    p.Email = Console.ReadLine()!;
}

void MostrarParticipantes()
{
    foreach (Participante p in participantes)
    {
        p.Mostrar();
        Console.WriteLine();
    }
}

void CrearCopia()
{
    Console.Write("Índice del participante: ");
    int i = int.Parse(Console.ReadLine()!);

    copia = participantes[i].Clonar();

    Console.WriteLine("Copia creada.");
}

void Asignar()
{
    if (copia == null)
    {
        Console.WriteLine("No existe copia.");
        return;
    }

    participantes.Add(copia);

    Console.WriteLine("Participante asignado a la colección.");
}