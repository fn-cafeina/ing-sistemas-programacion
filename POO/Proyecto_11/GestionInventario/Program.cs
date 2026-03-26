/*
    Gestión de Inventario de una Tienda Tecnológica

    Una tienda vende 5 productos específicos (Laptop, Mouse, Teclado, Monitor, Webcam).
    El sistema debe gestionar el stock de cada uno mediante un arreglo de enteros.

    Requerimientos del programa:
    • Inicializar el arreglo con las cantidades actuales de stock (ejemplo: {10, 25, 15, 8, 12}).
    • El programa debe preguntar al usuario cuántas unidades se vendieron de cada producto y restar esa
    cantidad de la posición correspondiente del arreglo.
    • Validación: Si el usuario intenta vender más de lo que hay en stock, el programa debe mostrar un
    error y no realizar la resta para ese producto.
    • Al finalizar, mostrar el inventario actualizado y un mensaje de "REABASTECER" solo para aquellos
    productos que quedaron con menos de 3 unidades.
*/

Console.Clear();
Console.WriteLine("--- Gestión de Inventario - Tienda Tecnológica ---\n");

string[] productos = { "Laptop", "Mouse", "Teclado", "Monitor", "Webcam" };
int[] stock = { 10, 25, 15, 8, 12 };

for (int i = 0; i < productos.Length; i++)
{
    Console.Write($"Ingrese la cantidad de unidades vendidas de {productos[i]} (Stock actual: {stock[i]}): ");

    if (!int.TryParse(Console.ReadLine(), out int unidadesVendidas))
    {
        Console.WriteLine("Error: Ingrese un número válido. Se saltará este producto.");
        continue;
    }

    if (unidadesVendidas < 0)
    {
        Console.WriteLine("Error: La cantidad no puede ser negativa. No se realizó la venta.");
    }
    else if (unidadesVendidas > stock[i])
    {
        Console.WriteLine($"Error: Stock insuficiente para {productos[i]}. Solo hay {stock[i]} unidades disponibles.");
    }
    else
    {
        stock[i] -= unidadesVendidas;
        Console.WriteLine($"Venta realizada. Nuevo stock de {productos[i]}: {stock[i]}");
    }
}

Console.WriteLine("\n--- Inventario Actualizado ---");
Console.WriteLine("{0,-15} | {1,-10} | {2}", "Producto", "Stock", "Estado");
Console.WriteLine(new string('-', 40));

for (int i = 0; i < productos.Length; i++)
{
    string estado = stock[i] < 3 ? "REABASTECER" : "OK";
    Console.WriteLine("{0,-15} | {1,-10} | {2}", productos[i], stock[i], estado);
}

Console.WriteLine("\nProceso finalizado.");
