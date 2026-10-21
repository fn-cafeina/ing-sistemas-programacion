/*
    Control de Calidad en una Línea de Producción

    Una fábrica de piezas mecánicas produce lotes de 8 piezas por turno.
    Cada pieza tiene un peso objetivo de 500 gramos.
    Se considera defectuosa si pesa menos de 495g o más de 505g.

    Requerimientos del programa:
    • Crear un arreglo para almacenar los pesos de las 8 piezas del turno.
    • Al finalizar el ingreso, el programa debe mostrar:
    • El peso total de todo el lote.
    • La cantidad de piezas "Aptas" y la cantidad de piezas "Defectuosas".
    • El peso de la pieza más pesada (Búsqueda del mayor).
*/

int[] piezas = new int[8];

Console.Clear();
Console.WriteLine("--- Control de Calidad - Línea de Producción ---\n");
Console.WriteLine("A continuación ingrese el peso de cada pieza del primer lote.");

for (int i = 0; i < piezas.Length; i++)
{
    int pieza;
    while (true)
    {
        Console.Write($"Ingrese al peso de la pieza {i + 1}: ");
        if (int.TryParse(Console.ReadLine(), out pieza) && pieza >= 0)
        {
            break;
        }

        Console.Clear();
        Console.WriteLine("--- Control de Calidad - Línea de Producción ---\n");
        Console.WriteLine("A continuación ingrese el peso de cada pieza del primer lote.");
        Console.WriteLine("Error: Ingrese un peso válido (número entero no negativo).");
    }

    piezas[i] = pieza;
}

int pesoTotal = piezas.Aggregate(0, (accum, current) => accum + current);
int piezasDefectuosas = 0;

for (int i = 0; i < piezas.Length; i++)
{
    if (piezas[i] < 495 || piezas[i] > 505)
    {
        piezasDefectuosas++;
    }
}

Console.WriteLine($"Peso total: {pesoTotal}g");
Console.WriteLine($"Piezas aptas: {piezas.Length - piezasDefectuosas}");
Console.WriteLine($"Piezas defectuosas: {piezasDefectuosas}");

Array.Sort(piezas);
Console.WriteLine($"Peso de la pieza mas pesada: {piezas[^1]}g");