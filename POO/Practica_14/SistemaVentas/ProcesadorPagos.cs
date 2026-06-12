class ProcesadorPagos
{
    public static void ProcesarFactura(string nombreProducto, int cantidad, decimal precioUnitario)
    {
        if (string.IsNullOrWhiteSpace(nombreProducto))
            throw new ArgumentException("El nombre del producto no puede estar vacio.", nameof(nombreProducto));

        if (cantidad <= 0)
            throw new ArgumentException("La cantidad debe ser mayor a cero.", nameof(cantidad));

        checked
        {
            decimal total = cantidad * precioUnitario;

            if (total > 1000000)
                throw new OverflowException(
                    $"El total de la factura ({total:C}) excede el limite financiero permitido de $1,000,000.00.");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Factura procesada exitosamente:");
            Console.WriteLine($"  Producto: {nombreProducto}");
            Console.WriteLine($"  Cantidad: {cantidad}");
            Console.WriteLine($"  Precio unitario: {precioUnitario:C}");
            Console.WriteLine($"  Total: {total:C}");
            Console.ResetColor();
        }
    }
}
