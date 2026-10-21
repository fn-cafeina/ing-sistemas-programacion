/*
    Análisis de Ventas Mensuales (Procesamiento)
    Sumatoria de Ingresos por Sucursal.

    Problema: Una empresa tiene 2 sucursales y registra sus ventas de los últimos 3 días en una matriz.
    Requerimiento: Una vez llena la matriz, el programa debe calcular y mostrar el total de ventas
    de una sucursal específica elegida por el usuario.

    Punto clave: Implementar la lógica de "fijar una fila" y recorrer las columnas para realizar la sumatoria.
*/

double[,] ventas = new double[2, 3];
string header = "--- Análisis de Ventas Mensuales ---\n";

Console.Clear();
Console.WriteLine(header);
Console.WriteLine("Ingrese las ventas de los últimos 3 días para cada sucursal.");

for (int i = 0; i < ventas.GetLength(0); i++)
{
    for (int j = 0; j < ventas.GetLength(1); j++)
    {
        while (true)
        {
            Console.Write($"Sucursal {i + 1}, Día {j + 1}: ");
            if (double.TryParse(Console.ReadLine(), out double venta) && venta >= 0)
            {
                ventas[i, j] = venta;
                break;
            }

            Console.Clear();
            Console.WriteLine(header);
            Console.WriteLine("Error: Ingrese un monto de venta válido (número no negativo).");
        }
    }
}

int sucursalSeleccionada;
while (true)
{
    Console.Write("\nSeleccione la sucursal para ver el total (1 o 2): ");
    if (int.TryParse(Console.ReadLine(), out sucursalSeleccionada) && (sucursalSeleccionada == 1 || sucursalSeleccionada == 2))
    {
        break;
    }

    Console.Clear();
    Console.WriteLine(header);
    Console.WriteLine("Error: Seleccione una sucursal válida (1 o 2).");
}

int fila = sucursalSeleccionada - 1;
double totalVentas = 0;

for (int j = 0; j < ventas.GetLength(1); j++)
{
    totalVentas += ventas[fila, j];
}

Console.WriteLine($"\nEl total de ventas para la Sucursal {sucursalSeleccionada} es: C${totalVentas:F2}");
