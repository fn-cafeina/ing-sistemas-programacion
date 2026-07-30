namespace Compgres;

public abstract class Participante
{
    public string NombreCompleto { get; set; } = "";
    public char Sexo { get; set; }
    public string PaisResidencia { get; set; } = "";
    public string Documento { get; set; } = "";
    public string Telefono { get; set; } = "";
    public string Email { get; set; } = "";

    protected Participante()
    {
    }

    protected Participante(Participante otro)
    {
        NombreCompleto = otro.NombreCompleto;
        Sexo = otro.Sexo;
        PaisResidencia = otro.PaisResidencia;
        Documento = otro.Documento;
        Telefono = otro.Telefono;
        Email = otro.Email;
    }

    public abstract Participante Clonar();

    public abstract void Mostrar();
}