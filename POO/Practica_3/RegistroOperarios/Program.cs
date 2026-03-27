/*
    Registro de Producción de Operarios.

    Problema: Una fabrica paga 100C$ por cada unidad producida.
    Se requiere calcular el gasto total de nómina para un grupo de operarios.

    * Requerimiento: Pedir la cantidad de operarios a procesar.
    Usar un ciclo for para solicitar la producción de cada uno.
    Si un operario produjo más de 50 unidades, se le suma un bono de 200C$ a su pago indivudial.

    * Punto clave: Al finalizar el ciclo, se debe aplicar un impuesto de seguridad del 2%
    sobre el gran total acumulado de la nómina. Mostrar el resultado final a pagar por la
    empresa como un número entero usando casting.
*/

Console.Clear();

Console.Write("Ingrese la cantidad de operarios: ");
if (!int.TryParse(Console.ReadLine(), out int cantidadDeOperarios))
{
    Console.WriteLine("Error: dato no válido.");
    return;
}

int precioUnidad = 100;
double nominaBrutaTotal = 0;
double impuestoTotal = 0;

Console.WriteLine("\n--- Registro de Operarios ---");

for (int i = 0; i < cantidadDeOperarios; i++)
{
    int unidadesProducidas;
    while (true)
    {
        Console.Write($"\nIngrese la cantidad de unidades producidas para el operario {i + 1}: ");
        if (int.TryParse(Console.ReadLine(), out unidadesProducidas) && unidadesProducidas >= 0)
        {
            break;
        }
        Console.WriteLine("Error: Ingrese un número entero no negativo.");
    }

    int pagoBase = precioUnidad * unidadesProducidas;
    int bono = unidadesProducidas > 50 ? 200 : 0;
    int pagoBrutoIndividual = pagoBase + bono;
    double impuestoIndividual = pagoBrutoIndividual * 0.02;

    Console.WriteLine($"Operario {i + 1}:");
    Console.WriteLine($"  Unidades: {unidadesProducidas}");
    Console.WriteLine($"  Pago Bruto: C${pagoBrutoIndividual} (Base: C${pagoBase}, Bono: C${bono})");
    Console.WriteLine($"  Impuesto (2%): C${impuestoIndividual:F2}");
    Console.WriteLine($"  Pago Neto: C${pagoBrutoIndividual - impuestoIndividual:F2}");

    nominaBrutaTotal += pagoBrutoIndividual;
    impuestoTotal += impuestoIndividual;
}

double nominaNetaTotal = nominaBrutaTotal * 0.98;

Console.WriteLine("\n------------------------------");
Console.WriteLine($"Impuesto total: C${(int)impuestoTotal}");
Console.WriteLine($"Total Nomina: C${(int)nominaNetaTotal}");