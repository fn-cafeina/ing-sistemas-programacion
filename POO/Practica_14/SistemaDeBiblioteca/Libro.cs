class Libro
{
    string titulo = string.Empty;
    int copiasDisponibles;

    public string Titulo
    {
        get => titulo;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El titulo no puede estar vacio.");
            titulo = value;
        }
    }

    public int CopiasDisponibles
    {
        get => copiasDisponibles;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(CopiasDisponibles),
                    "Las copias disponibles no pueden ser negativas.");
            copiasDisponibles = value;
        }
    }

    public Libro(string titulo, int copiasDisponibles)
    {
        Titulo = titulo;
        CopiasDisponibles = copiasDisponibles;
    }
}
