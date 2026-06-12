class Asignatura
{
    string nombre = string.Empty;
    int cupoMaximo;
    int cuposInscritos;

    public string Nombre
    {
        get => nombre;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre de la asignatura no puede estar vacio.");
            nombre = value;
        }
    }

    public int CupoMaximo
    {
        get => cupoMaximo;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(CupoMaximo),
                    "El cupo maximo debe ser mayor a cero.");
            cupoMaximo = value;
        }
    }

    public int CuposInscritos
    {
        get => cuposInscritos;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(CuposInscritos),
                    "Los cupos inscritos no pueden ser negativos.");
            if (value > CupoMaximo)
                throw new ArgumentOutOfRangeException(nameof(CuposInscritos),
                    "Los cupos inscritos no pueden superar el cupo maximo.");
            cuposInscritos = value;
        }
    }

    public int CreditosRequeridos { get; }

    public Asignatura(string nombre, int cupoMaximo, int cuposInscritos, int creditosRequeridos = 40)
    {
        Nombre = nombre;
        CupoMaximo = cupoMaximo;
        CuposInscritos = cuposInscritos;
        CreditosRequeridos = creditosRequeridos;
    }
}
