class Libro
{
    public string Titulo { get; set; }
    public int CopiasDisponibles { get; set; }

    public Libro(string titulo, int copiasDisponibles)
    {
        Titulo = titulo;
        CopiasDisponibles = copiasDisponibles;
    }
}
