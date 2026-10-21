namespace SimuladorDescargas;

// Información de cada archivo que se va a descargar (enunciado)
class ArchivoDescarga
{
    private static int contador;

    public int Id { get; }
    public string Nombre { get; set; }
    public int longitud { get; set; }

    public ArchivoDescarga(string nombre, int tam)
    {
        Id = ++contador;
        Nombre = nombre;
        longitud = tam;
    }
}
