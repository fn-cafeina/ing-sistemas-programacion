/*
    Filtro de Datos en Matriz (Búsqueda y Decisión)
    Monitor de Inventario Crítico.

    Problema: En una bodega se almacenan diferentes productos, organizados en una matriz de 3x3.
    Cada celda de la matriz contiene el nombre de un producto y su respectivo stock en unidades.

    Requerimiento: Recorrer la matriz utilizando ciclos anidados y mostrar en pantalla aquellos
    productos cuyo stock sea menor a 10 unidades. Para cada producto crítico se debe indicar:
    • Nombre del producto
    • Ubicación en la matriz (Fila y Columna)
    • Cantidad de stock disponible

    Punto clave: Integrar la sentencia if dentro de los ciclos anidados para evaluar celda por celda.
*/

string[,] productos = new string[3, 3];
int[,] stock = new int[3, 3];
string header = "--- Monitor de Inventario Crítico ---\n";

Console.Clear();
Console.WriteLine(header);
Console.WriteLine("Ingrese el nombre y stock de los productos para la bodega (3x3).");

for (int i = 0; i < productos.GetLength(0); i++)
{
    for (int j = 0; j < productos.GetLength(1); j++)
    {
        Console.WriteLine($"\nConfigurando celda [{i}, {j}]:");
        
        Console.Write("Nombre del producto: ");
        productos[i, j] = Console.ReadLine() ?? "Sin nombre";

        int cantidad;
        while (true)
        {
            Console.Write($"Stock para {productos[i, j]}: ");
            if (int.TryParse(Console.ReadLine(), out cantidad) && cantidad >= 0)
            {
                stock[i, j] = cantidad;
                break;
            }

            Console.Clear();
            Console.WriteLine(header);
            Console.WriteLine($"Error: Ingrese un stock válido para {productos[i, j]} (número entero no negativo).");
        }
    }
}

Console.Clear();
Console.WriteLine(header);
Console.WriteLine("--- REPORTE DE PRODUCTOS CRÍTICOS (Stock < 10) ---");
Console.WriteLine("{0,-20} | {1,-10} | {2,-10}", "Producto", "Ubicación", "Stock");
Console.WriteLine(new string('-', 45));

bool hayCriticos = false;
for (int i = 0; i < stock.GetLength(0); i++)
{
    for (int j = 0; j < stock.GetLength(1); j++)
    {
        if (stock[i, j] < 10)
        {
            Console.WriteLine("{0,-20} | {1,-10} | {2,-10}", 
                productos[i, j], 
                $"[{i},{j}]", 
                stock[i, j]);
            hayCriticos = true;
        }
    }
}

if (!hayCriticos)
{
    Console.WriteLine("No se encontraron productos con stock crítico.");
}

