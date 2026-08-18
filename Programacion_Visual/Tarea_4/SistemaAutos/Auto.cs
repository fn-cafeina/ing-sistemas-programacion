namespace SistemaAutos;

public class Auto
{
    public string Marca { get; set; } = string.Empty;
    public int Kilometraje { get; set; }
    public string Estado { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public string Transmision { get; set; } = string.Empty;
    public bool RinesDeLujo { get; set; }
}