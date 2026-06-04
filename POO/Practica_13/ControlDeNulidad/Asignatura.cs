namespace ControlDeNulidad;

public class Asignatura(Estudiante estudianteAsignatura)
{
    public Estudiante EstudiateAsignatura { get; set; } = estudianteAsignatura;

    public void MostrarReporte()
    {
        int totalNotas = 0;
        foreach (var nota in EstudiateAsignatura.Notas)
            totalNotas += nota;

        double promedio = totalNotas / EstudiateAsignatura.Notas.Count;
        Console.WriteLine($"Nombre: {EstudiateAsignatura.Nombre}\nPromedio: {promedio}");
    }
}