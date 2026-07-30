namespace Compgres;

public class Ponente : Participante
{
    public int NumeroPonencia { get; set; }

    public string TituloPonencia { get; set; } = "";

    public Ponente()
    {
    }

    public Ponente(Ponente otro) : base(otro)
    {
        NumeroPonencia = otro.NumeroPonencia;
        TituloPonencia = otro.TituloPonencia;
    }

    public override Participante Clonar()
    {
        return new Ponente(this);
    }

    public override void Mostrar()
    {
        Console.WriteLine("===== PONENTE =====");
        Console.WriteLine($"Nombre: {NombreCompleto}");
        Console.WriteLine($"Sexo: {Sexo}");
        Console.WriteLine($"País: {PaisResidencia}");
        Console.WriteLine($"Documento: {Documento}");
        Console.WriteLine($"Teléfono: {Telefono}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Ponencia #: {NumeroPonencia}");
        Console.WriteLine($"Título: {TituloPonencia}");
    }
}