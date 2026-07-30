namespace Compgres;

public class Oyente : Participante
{
    public int NumeroRegistro { get; set; }

    public string GradoAcademico { get; set; } = "";

    public Oyente()
    {
    }

    public Oyente(Oyente otro) : base(otro)
    {
        NumeroRegistro = otro.NumeroRegistro;
        GradoAcademico = otro.GradoAcademico;
    }

    public override Participante Clonar()
    {
        return new Oyente(this);
    }

    public override void Mostrar()
    {
        Console.WriteLine("===== OYENTE =====");
        Console.WriteLine($"Nombre: {NombreCompleto}");
        Console.WriteLine($"Sexo: {Sexo}");
        Console.WriteLine($"País: {PaisResidencia}");
        Console.WriteLine($"Documento: {Documento}");
        Console.WriteLine($"Teléfono: {Telefono}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Registro: {NumeroRegistro}");
        Console.WriteLine($"Grado: {GradoAcademico}");
    }
}