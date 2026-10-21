class Estudiante
{
    string nombre = string.Empty;

    public string Nombre
    {
        get => nombre;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre del estudiante no puede estar vacio.");
            nombre = value;
        }
    }

    int creditosAprobados;

    public int CreditosAprobados
    {
        get => creditosAprobados;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(CreditosAprobados),
                    "Los creditos aprobados no pueden ser negativos.");
            creditosAprobados = value;
        }
    }

    public Estudiante(string nombre, int creditosAprobados)
    {
        Nombre = nombre;
        CreditosAprobados = creditosAprobados;
    }
}
