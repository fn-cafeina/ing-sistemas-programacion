class Producto
{
    string nombre = string.Empty;

    public string Nombre
    {
        get => nombre;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El nombre del producto no puede estar vacio.");
            nombre = value;
        }
    }

    public decimal PrecioUnitario { get; }

    public Producto(string nombre, decimal precioUnitario)
    {
        Nombre = nombre;
        if (precioUnitario <= 0)
            throw new ArgumentOutOfRangeException(nameof(precioUnitario),
                "El precio unitario debe ser mayor a cero.");
        PrecioUnitario = precioUnitario;
    }
}
