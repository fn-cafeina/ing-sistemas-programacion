class RegistroAsistencia
{
    public string Carnet { get; }
    public string Nombre { get; }
    public DateTime FechaHora { get; }

    public RegistroAsistencia(string carnet, string nombre, DateTime fechaHora)
    {
        if (string.IsNullOrWhiteSpace(carnet))
            throw new ArgumentException("El carnet no puede estar vacio.", nameof(carnet));
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre no puede estar vacio.", nameof(nombre));

        Carnet = carnet;
        Nombre = nombre;
        FechaHora = fechaHora;
    }

    public override string ToString()
    {
        return $"{Carnet} - {Nombre} - {FechaHora:dd/MM/yyyy HH:mm:ss}";
    }

    public string ToArchivo()
    {
        return $"{Carnet} - {Nombre} - {FechaHora:dd/MM/yyyy HH:mm:ss}";
    }

    public static RegistroAsistencia? FromString(string linea)
    {
        if (string.IsNullOrWhiteSpace(linea))
            return null;

        string[] partes = linea.Split(" - ", 3);
        if (partes.Length < 3)
            return null;

        if (!DateTime.TryParseExact(partes[2], "dd/MM/yyyy HH:mm:ss",
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None, out DateTime fecha))
            return null;

        return new RegistroAsistencia(partes[0], partes[1], fecha);
    }
}
