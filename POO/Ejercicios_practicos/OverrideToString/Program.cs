Producto producto1 = new()
{
    Nombre = "Retornable",
    Precio = 50
};

Console.WriteLine(producto1.ToString());

class Producto
{
    public string? Nombre { get; set; }
    public decimal Precio { get; set; }

    public override string ToString()
    {
        return $"{Nombre} - Precio: {Precio:C}";
    }
}