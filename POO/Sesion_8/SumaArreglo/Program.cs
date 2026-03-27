/*
    1. Crea un programa que solicite al usuario ingresar 5 números enteros y los almacene
    en un arreglo unidimensional. Luego, utiliza un ciclo for para recorrer el arreglo
    y calcular la suma total de los números ingresados. Finalmente, muestra el resultado.
*/

Console.Clear();
Console.WriteLine("--- Suma de 5 Números ---");

int[] numeros = new int[5];
int sumaTotal = 0;

for (int i = 0; i < numeros.Length; i++)
{
    while (true)
    {
        Console.Write($"Ingrese el número entero {i + 1}: ");
        if (int.TryParse(Console.ReadLine(), out numeros[i]))
        {
            break;
        }
        Console.WriteLine("Error: Ingrese un número entero válido.");
    }
}

for (int i = 0; i < numeros.Length; i++)
{
    sumaTotal += numeros[i];
}

Console.WriteLine($"\nLa suma total de los números ingresados es: {sumaTotal}");
Console.WriteLine("\nProceso finalizado.");
