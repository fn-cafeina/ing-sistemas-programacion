/*
    2. Crea un programa que solicite al usuario ingresar 6 números enteros y los almacene
    en un arreglo unidimensional. Utiliza un ciclo while para recorrer el arreglo y
    determinar cuál es el número mayor. Al final, muestra el número más grande ingresado.
*/

Console.Clear();
Console.WriteLine("--- Búsqueda del Número Mayor (6 ingresos) ---");

int[] numeros = new int[6];
int indiceInput = 0;

while (indiceInput < numeros.Length)
{
    Console.Write($"Ingrese el número entero {indiceInput + 1}: ");
    if (int.TryParse(Console.ReadLine(), out numeros[indiceInput]))
    {
        indiceInput++;
    }
    else
    {
        Console.WriteLine("Error: Ingrese un número entero válido.");
    }
}

int mayor = numeros[0];
int indiceBusqueda = 1;

while (indiceBusqueda < numeros.Length)
{
    if (numeros[indiceBusqueda] > mayor)
    {
        mayor = numeros[indiceBusqueda];
    }
    indiceBusqueda++;
}

Console.WriteLine($"\nEl número más grande ingresado es: {mayor}");
Console.WriteLine("\nProceso finalizado.");
