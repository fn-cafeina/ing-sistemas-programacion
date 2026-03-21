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
double nomina = 0;

for (int i = 0; i < cantidadDeOperarios; i++)
{
    Console.Write($"Ingrese la cantidad de unidades producidas para el operario {i + 1}: ");
    if (!int.TryParse(Console.ReadLine(), out int unidadesProducidas))
    {
        Console.WriteLine("Error: dato no válido.");
        return;
    }

    nomina += precioUnidad * unidadesProducidas;

    if (unidadesProducidas > 50)
    {
        nomina += 200;
    }
}

nomina *= 0.98;

Console.WriteLine($"Nomina: C${(int)nomina}");