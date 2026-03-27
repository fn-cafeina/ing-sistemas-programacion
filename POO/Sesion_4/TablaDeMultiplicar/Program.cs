/*
    1. Investigar y codificar un programa que solicite al usuario un número N y realice lo siguiente:

    ✓ Verifique si el dato ingresado es un número válido (usando int.TryParse).
    ✓ Si es válido, imprima la tabla de multiplicar de dicho número del 1 al 12 usando un ciclo for.
    ✓ Si el número es negativo, mostrar un mensaje de error usando if.
*/

Console.Clear();

static void ImprimirTablaMultiplicar(int n)
{
    for (int i = 1; i <= 12; i++)
    {
        Console.WriteLine($"{n} x {i + 0} = {n * i}");
    }
}

Console.Write("Ingrese un número entero: ");

string? stringNumero = Console.ReadLine();
bool esEntero = int.TryParse(stringNumero, out int numero);

if (esEntero)
{
    ImprimirTablaMultiplicar(numero);
}
else
{
    Console.WriteLine("Error: Ingrese un número valido.");
}