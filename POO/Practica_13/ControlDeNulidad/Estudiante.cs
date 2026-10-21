namespace ControlDeNulidad;

public class Estudiante(string nombre)
{
    public string Nombre { get; set; } = nombre;
    public List<int> Notas { get; set; } = [];
}