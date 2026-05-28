abstract class Producto
{
    public string Nombre { get; init; }
    public decimal Precio { get; init; }

    public Producto(string nombre, decimal precio)
    {
        Nombre = nombre;
        Precio = precio;
    }
}

class Medicamento : Producto
{
    public int Dosis { get; init; }

    public Medicamento(string nombre, decimal precio, int dosis) : base(nombre, precio)
    {
        Dosis = dosis;
    }

    public override string ToString()
    {
        return $"Medicamento: {Nombre}, Precio: ${Precio}, Dosis: {Dosis}mg";
    }
}

class Alimento : Producto
{
    public string FechaVencimiento { get; init; }

    public Alimento(string nombre, decimal precio, string fechaVencimiento) : base(nombre, precio)
    {
        FechaVencimiento = fechaVencimiento;
    }

    public override string ToString()
    {
        return $"Alimento: {Nombre}, Precio: ${Precio}, Vence: {FechaVencimiento}";
    }
}
